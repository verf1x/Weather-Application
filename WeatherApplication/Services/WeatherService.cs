using Verf1xWeatherApp.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Verf1xWeatherApp.Services;

internal class WeatherService : IWeatherService
{
    internal WeatherService(string cityName)
    {
        _cityName = cityName;
    }

    #region Fields

    private const string _token = "dd03c3d87712477e9c56e53221144266";
    private string _cityName;
    private static readonly HttpClient _httpClient = new();

    #endregion

    public async Task<WeatherDataModel> GetWeatherDataAsync()
    {
        string request = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&units=metric&appid={1}", _cityName, _token);

        HttpResponseMessage response = (await _httpClient.GetAsync(request)).EnsureSuccessStatusCode();

        var jsonWeather = await response.Content.ReadAsStringAsync();

#pragma warning disable CS8603
        return JsonConvert.DeserializeObject<WeatherDataModel>(jsonWeather);
#pragma warning restore CS8603
    }
}
