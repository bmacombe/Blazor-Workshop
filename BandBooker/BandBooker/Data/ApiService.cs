using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BandBookerData.Models;
using Newtonsoft.Json;


namespace BandBooker.Data
{
    public class ApiService
    {
        // TODO: Replace the baseURL with your app's base url.
        static string baseURL = "https://localhost:44303/";


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