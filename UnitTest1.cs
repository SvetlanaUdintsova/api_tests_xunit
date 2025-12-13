using RestSharp;

namespace TryingRestSharp;

public class UnitTest1
{
    private readonly HttpClientRequest _httpClientRequest;

    public UnitTest1()
    {
        _httpClientRequest = new HttpClientRequest();
    }

    [Fact]
    //This method uses RestSharp
    public void SimpleHealthzCheck()
    {
        var client = new RestClient("https://api.met.no/weatherapi/locationforecast/2.0");
        var request = new RestRequest("/healthz", Method.Get);
        var response = client.Execute(request);

        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }


    [Fact]
    //This method uses HttpClient via _httpClientRequest
    public async Task GetWeatherLocations()
    {
        var WeatherClient = _httpClientRequest.GetHttpClient();

        var url = "locations";
        var response = await WeatherClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseContent);
        Assert.Contains("properties", responseContent);
    }


    [Fact]
    //This method uses HttpClient via _httpClientRequest
    public async Task GetCompactForecastForStavanger()
    {
        const double stavangerLatitude = 58.9701;
        const double stavangerLongitude = 5.7332;

        var WeatherClient = _httpClientRequest.GetHttpClient();

        var url = $"compact?lat={stavangerLatitude.ToString(System.Globalization.CultureInfo.InvariantCulture)}&lon={stavangerLongitude.ToString(System.Globalization.CultureInfo.InvariantCulture)}";
        var response = await WeatherClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        Assert.NotNull(responseContent);
        Assert.Contains("properties", responseContent);
    }
}
