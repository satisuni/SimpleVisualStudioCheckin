using Newtonsoft.Json;
using simple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace simple.Services
{
    public class ServiceClient
    {
        private const string ApiBaseAddress = "http://192.168.1.3:8080";
        public async Task<List<HotelInfo>> GetHotels()
        {

            IEnumerable<HotelInfo> hotels = Enumerable.Empty<HotelInfo>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiBaseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync("hotel-services/webapi/hotels");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        hotels = await Task.Run(() =>
                            JsonConvert.DeserializeObject<IEnumerable<HotelInfo>>(json)
                        ).ConfigureAwait(false);
                    }

                }
            }

          
            //List<HotelInfo> hotels = new List<HotelInfo>();
            //hotels.Add(new HotelInfo { Id = 1, Name = "Satish11", Address = "Sr Software" });
            return hotels.ToList();
        }

       // private const string ApiBaseAddress = "http://192.168.1.3:8080/hotel-services/webapi/hotels";
        private HttpClient CreateClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(ApiBaseAddress)
            };

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }
    }
}
