using System.Net.Http; // Add this for HttpMethod
using RestSharp;
using Newtonsoft.Json;
using PrayerTimesWebApp.Models;

namespace PrayerTimesWebApp.Services
{
    public class PrayerTimesService
    {
        public async Task<PrayerTimesModel> GetPrayerTimes(string city)
        {
            string apiUrl = $"https://api.aladhan.com/v1/timingsByCity?city={city}&country=&method=2";

            var client = new RestClient(apiUrl);
            var request = new RestRequest(apiUrl, Method.Get); // Updated for the latest RestSharp syntax
            var response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                var data = JsonConvert.DeserializeObject<dynamic>(response.Content);
                var timings = data.data.timings;

                return new PrayerTimesModel
                {
                    Fajr = timings.Fajr,
                    Dhuhr = timings.Dhuhr,
                    Asr = timings.Asr,
                    Maghrib = timings.Maghrib,
                    Isha = timings.Isha
                };
            }

            return null;
        }
    }
}
