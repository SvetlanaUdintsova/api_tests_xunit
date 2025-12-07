using Microsoft.Extensions.Configuration;
using RestSharp;

namespace TryingRestSharp;

public class RequestHelper
{
    private readonly IConfiguration _configuration;

    public RequestHelper()
    {
        var basePath = Path.Combine(AppContext.BaseDirectory);
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.GetFullPath(basePath))
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        _configuration = builder.Build();
    }

    public RestClient CreateWeatherClientAPIV20()
    {
        //api.met.no requires self-identification in User-Agent header and contact information
        //More than 20 requests per second per application will get you rate-limited
        var contactEmail = _configuration["AppSettings:ContactEmail"];
        var userAgent = _configuration["AppSettings:UserAgent"];
        var userAgentHeader = $"{userAgent}, {contactEmail}";

        return (RestClient)new RestClient("https://api.met.no/weatherapi/locationforecast/2.0").AddDefaultHeader("User-Agent", userAgentHeader);
    }
}
