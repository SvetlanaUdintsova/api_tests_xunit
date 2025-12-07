using RestSharp;

namespace TryingRestSharp;

public class UnitTest1
{
    private readonly RestClient _client;

    public UnitTest1()
    {
        var helper = new RequestHelper();
        _client = helper.CreateWeatherClientAPIV20();
    }


    [Fact]
    public void SimpleHealthzCheck()
    {
        var request = new RestRequest("/healthz", Method.Get);
        var response = _client.Execute(request);

        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public void GetCompactForecastForStavanger()
    {
        const double stavangerLatitude = 58.9701;
        const double stavangerLongitude = 5.7332;

        var request = new RestRequest("/compact", Method.Get)
        .AddQueryParameter("lat", stavangerLatitude.ToString())
        .AddQueryParameter("lon", stavangerLongitude.ToString());

        var response = _client.Execute(request);

        Assert.True(response.StatusCode.Equals(System.Net.HttpStatusCode.OK), response.Content);
        Assert.NotNull(response.Content);
    }
}
