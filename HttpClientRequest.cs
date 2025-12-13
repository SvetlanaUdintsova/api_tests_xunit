
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TryingRestSharp;

public class HttpClientRequest
{
    private readonly HttpClient _httpClient;
    // It was recommended in the latest articles to use httpClient as an interface

    public HttpClientRequest()
    {
        // Build configuration
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        // Set up dependency injection
        var services = new ServiceCollection();

        services.AddHttpClient("WeatherApi", client =>
        {
            client.BaseAddress = new Uri("https://api.met.no/weatherapi/locationforecast/2.0");

            // Set User-Agent header from configuration
            var contactEmail = configuration["AppSettings:ContactEmail"];
            var userAgent = configuration["AppSettings:UserAgent"];
            var userAgentHeader = $"{userAgent}, {contactEmail}";
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", userAgentHeader);
        });

        var serviceProvider = services.BuildServiceProvider();

        // Get the HttpClient factory and create a named client "WeatherApi"
        var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
        _httpClient = httpClientFactory.CreateClient("WeatherApi");
    }

    public HttpClient GetHttpClient()
    {
        return _httpClient;
    }
}
