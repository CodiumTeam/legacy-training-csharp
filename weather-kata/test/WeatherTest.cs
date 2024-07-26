using System.Text.Json.Nodes;
using Xunit.Abstractions;

namespace WeatherKata;

using Weather;

public class WeatherTest
{
    private readonly ITestOutputHelper _output;

    private StringWriter _stringWriter;
    // https://positionstack.com/geo_api.php?query=Barcelona
    // https://api.open-meteo.com/v1/forecast?latitude=41.400347&longitude=2.159592&daily=weathercode,windspeed_10m_max&timezone=Europe%2FBerlin
    
   
    [Fact]
    public void find_the_weather_of_today()
    {
        var forecast = new TestableForecast();

        var prediction = forecast.Predict("Barcelona", null, false);

        Assert.Equal("Clear sky", prediction);
    }        
    [Fact]
    public void find_the_weather_of_2_days_in_advance()
    {
        var forecast = new TestableForecast();

        var prediction = forecast.Predict("Barcelona", forecast.TODAY.AddDays(2), false);

        Assert.Equal("Mainly clear, partly cloudy, and overcast", prediction);
    }     
    
    [Fact]
    public void the_api_is_working()
    {
        var forecast = new Forecast();

        forecast.Predict("Barcelona", null, false);

    }    
    
}

public class TestableForecast: Forecast
{
    public readonly DateTime TODAY = new DateTime(2024,07, 24);

    protected override string FindLatitudeAndLongitude(string city)
    {
        return "{\"data\":[{\"latitude\":41.400347,\"longitude\":2.159592,\"type\":\"locality\",\"name\":\"Barcelona\",\"number\":null,\"postal_code\":null,\"street\":null,\"confidence\":1,\"region\":\"Barcelona\",\"region_code\":\"CT\",\"county\":null,\"locality\":\"Barcelona\",\"administrative_area\":null,\"neighbourhood\":null,\"country\":\"Spain\",\"country_code\":\"ESP\",\"continent\":\"Europe\",\"label\":\"Barcelona, Spain\",\"bbox_module\":[2.05247,41.316956,2.22922,41.468282],\"country_module\":{\"latitude\":40.396026611328125,\"longitude\":-3.550692558288574,\"common_name\":\"Spain\",\"official_name\":\"Kingdom of Spain\",\"capital\":\"Madrid\",\"flag\":\"\\ud83c\\uddea\\ud83c\\uddf8\",\"area\":505992,\"landlocked\":false,\"independent\":true,\"global\":{\"alpha2\":\"ES\",\"alpha3\":\"ESP\",\"numeric_code\":\"724\",\"region\":\"Europe\",\"subregion\":\"Southern Europe\",\"region_code\":\"150\",\"subregion_code\":\"039\",\"world_region\":\"EMEA\",\"continent_name\":\"Europe\",\"continent_code\":\"EU\"},\"dial\":{\"calling_code\":\"34\",\"national_prefix\":null,\"international_prefix\":\"00\"},\"currencies\":[{\"symbol\":\"\\u20ac\",\"code\":\"EUR\",\"name\":\"Euro\",\"numeric\":978,\"minor_unit\":2}],\"languages\":{\"spa\":\"Spanish\"}},\"sun_module\":{\"rise\":{\"time\":1721795956,\"astronomical\":1721788948,\"civil\":1721794046,\"nautical\":1721791654},\"set\":{\"time\":1721848593,\"astronomical\":1721855601,\"civil\":1721850503,\"nautical\":1721852895},\"transit\":1721822274},\"timezone_module\":{\"name\":\"Europe\\/Madrid\",\"offset_sec\":7200,\"offset_string\":\"+02:00\"}}]}\n";
    }

    protected override string FindPredictions(string latitude, string longitude)
    {
        return "{\"latitude\":41.4,\"longitude\":2.1599998,\"generationtime_ms\":0.2650022506713867,\"utc_offset_seconds\":7200,\"timezone\":\"Europe/Berlin\",\"timezone_abbreviation\":\"CEST\",\"elevation\":62.0,\"current_weather_units\":{\"time\":\"iso8601\",\"interval\":\"seconds\",\"temperature\":\"\u00b0C\",\"windspeed\":\"km/h\",\"winddirection\":\"\u00b0\",\"is_day\":\"\",\"weathercode\":\"wmo code\"},\"current_weather\":{\"time\":\"2024-07-24T12:30\",\"interval\":900,\"temperature\":29.3,\"windspeed\":10.2,\"winddirection\":132,\"is_day\":1,\"weathercode\":0},\"daily_units\":{\"time\":\"iso8601\",\"weathercode\":\"wmo code\",\"windspeed_10m_max\":\"km/h\"},\"daily\":{\"time\":[\"2024-07-24\",\"2024-07-25\",\"2024-07-26\",\"2024-07-27\",\"2024-07-28\",\"2024-07-29\",\"2024-07-30\"],\"weathercode\":[0,0,1,3,3,0,0],\"windspeed_10m_max\":[15.3,19.7,15.1,18.2,15.0,14.1,15.9]}}\n";
    }

    protected override DateTime Today()
    {
        return TODAY;
    }
}