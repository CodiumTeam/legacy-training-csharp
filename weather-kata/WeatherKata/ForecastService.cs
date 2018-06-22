using System;

namespace WeatherKata
{
    interface ForecastService
    {
        string PredictWeather(string cityName, DateTime when);

        string predictWind(string cityName, DateTime when);
    }
}
