using Microsoft.Extensions.Configuration;

namespace TryingRestSharp;

//It is not used anywhere yet because I encountered problem that RestSharp User-agent header gives away
// that it is a API client and meteo website rejects it. It is also impossible to rewrite User-agent header in RestSharp.
// only append. I may change the test object to start using this class.
public class RestSharpRequestHelper
{
    private readonly IConfiguration _configuration;

    public RestSharpRequestHelper()
    {
        var basePath = Path.Combine(AppContext.BaseDirectory);
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.GetFullPath(basePath))
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        _configuration = builder.Build();
    }
}
