using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public static class ApiService
    {
        public static async Task<Root> GetWeather(double latitude, double longtitude)
        {
            var httpClient = new HttpClient();
            var respone = httpClient.GetStringAsync(string.Format("https://api.openweathermap.org/data/2.5/forecast?lat={0}&lon={1}&appid=301d88cfa61f6365b9de06604abd3193", latitude, longtitude));
            return JsonConvert.DeserializeObject<Root>(await respone);

        }
        public static async Task<Root> GetWeatherByCity(string city)
        {
            var httpClient = new HttpClient();
            var respone = httpClient.GetStringAsync(string.Format("api.openweathermap.org/data/2.5/forecast?q={0}&appid=301d88cfa61f6365b9de06604abd3193", city));
            return JsonConvert.DeserializeObject<Root>(await respone);

        }
    }
}
