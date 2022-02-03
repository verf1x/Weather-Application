using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Windows.Media;

namespace Verf1xWeatherApp.Models
{
    public class Coord
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }

    public class Weather
    {
        public string? Main { get; set; }
        public string? Description { get; set; }


        private string? _icon;
        public string? Icon 
        { 
            get => _icon;
            set
            {
                _icon = value;
                IconSource = $"https://openweathermap.org/img/w/{_icon}.png";
            }
        }


        [JsonIgnore]
        public string? IconSource { get; set; }
    }

    public class Main
    {
        private double _temp;
        public double Temp 
        { 
            get => _temp;
            set
            {
                _temp = Convert.ToInt32(value);

                if(_temp >= 0)
                {
                    CorrectTemp = $"+{_temp} °C";
                }
                else
                {
                    CorrectTemp = $"-{_temp} °C";
                }
            }
        }


        [JsonIgnore]
        public string? CorrectTemp { get; set; }


        private double _feelsLike;
        public double FeelsLike 
        { 
            get => _feelsLike; 
            set => _feelsLike = Convert.ToInt32(value);
        }


        public double Pressure { get; set; }
        public double Humidity { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
    }

    public class Sys
    {
        private long _sunrise;
        public long Sunrise 
        {
            get => _sunrise;
            set
            {
                _sunrise = value;
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dateTime = dateTime.AddSeconds(_sunrise).ToLocalTime();
                CorrectSunrise = string.Format($"T: {dateTime}");
            }
        }


        private long _sunset;
        public long Sunset 
        { 
            get => _sunset; 
            set
            {
                _sunset = value;
                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dateTime = dateTime.AddSeconds(_sunset).ToLocalTime();
                CorrectSunset = string.Format($"T: {dateTime}");
            } 
        }

        [JsonIgnore]
        public string? CorrectSunset { get; set; }

        [JsonIgnore]
        public string? CorrectSunrise { get; set; }

    }

    public class WeatherDataModel : ObservableObject
    {
        private Coord? _coord;
        public Coord? Coord
        {
            get => _coord;
            set => SetValue(ref _coord, value, nameof(Coord));
        }


        private List<Weather>? _weather;
        public List<Weather>? Weather
        {
            get => _weather;
            set => SetValue(ref _weather, value, nameof(Weather));
        }


        private Main? _main;
        public Main? Main
        {
            get => _main;
            set => SetValue(ref _main, value, nameof(Main));
        }


        private Wind? _wind;
        public Wind? Wind
        {
            get => _wind;
            set => SetValue(ref _wind, value, nameof(Wind));
        }


        private Sys? _sys;
        public Sys? Sys
        {
            get => _sys;
            set => SetValue(ref _sys, value, nameof(Sys));
        }


        private string? _name;
        public string? Name
        {
            get => _name;
            set => SetValue(ref _name, value, nameof(Name));
        }
    }
}
