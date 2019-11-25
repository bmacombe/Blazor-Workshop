using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BandBookerData.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace BandBooker.Data
{
    public class ApiService
    {
        static string baseURL = "";

        static ApiService()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var Configuration = builder.Build();
            baseURL = Configuration["BaseURL"];
        }

        public static async Task<List<Instrument>> GetInstruments()
        {
            using (var http = new HttpClient())
            {
                var uri = new Uri(baseURL + "api/instruments");
                string json = await http.GetStringAsync(uri);
                var instruments = JsonConvert.DeserializeObject<List<Instrument>>(json);
                return instruments;
            }
        }
    }
}