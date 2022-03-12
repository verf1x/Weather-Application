using System.Threading.Tasks;

namespace Verf1xWeatherApp.Interfaces;

internal interface IWeatherService 
{
    Task<WeatherDataModel> GetWeatherDataAsync(); 
}
