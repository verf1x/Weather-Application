global using Verf1xWeatherApp.Models;
global using System;
using System.Windows.Input;
using System.Threading.Tasks;
using Verf1xWeatherApp.Services;
using Verf1xWeatherApp.Interfaces;
using MvvmCross.ViewModels;
using MvvmCross.Commands;

namespace Verf1xWeatherApp.ViewModels;

internal sealed class MainViewModel : MvxViewModel
{
    #region Properties
    private WeatherDataModel? _weatherModel;
    public WeatherDataModel? WeatherModel
    {
        get => _weatherModel;
        set => SetProperty(ref _weatherModel, value, nameof(WeatherModel));
    }


    private string? _searchCityName;
    public string? SearchCityName
    {
        get => _searchCityName;
        set => SetProperty(ref _searchCityName, value, nameof(SearchCityName));
    }


    private ICommand? _searchCommand;
    public ICommand? SearchCommand
    {
        get => _searchCommand ??= new MvxCommand(() =>
        {
            WeatherModel = null;
            Task.Run(GetWeather).Wait();
        });
    }
    #endregion

    public async Task GetWeather()
    {
        IWeatherService weatherService = new WeatherService(SearchCityName);
        WeatherModel = await weatherService.GetWeatherDataAsync();
    }

}
