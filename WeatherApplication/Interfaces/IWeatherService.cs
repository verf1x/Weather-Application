using System.Threading.Tasks;
using Verf1xWeatherApp.Models;

namespace Verf1xWeatherApp.Interfaces
{
    internal interface IWeatherService { public Task<WeatherDataModel> GetWeatherDataAsync(); }
}
