using Microsoft.AspNetCore.Mvc;
using PrayerTimesWebApp.Models;
using PrayerTimesWebApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrayerTimesWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly PrayerTimesService _prayerTimesService;

        public HomeController()
        {
            _prayerTimesService = new PrayerTimesService();
        }

        public IActionResult Index()
        {
            // List of countries and cities
            var countries = new Dictionary<string, string>
            {
                {"Saudi Arabia", "Riyadh"},
                {"Egypt", "Cairo"},
                {"United States", "Washington"},
                {"India", "New Delhi"},
                {"Pakistan", "Islamabad"},
                {"United Kingdom", "London"},
                {"UAE", "Abu Dhabi"},
                {"Turkey", "Ankara"}
            };
            ViewBag.Countries = countries;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetPrayerTimes(string selectedCountry)
        {
            var countries = new Dictionary<string, string>
            {
                {"Saudi Arabia", "Riyadh"},
                {"Egypt", "Cairo"},
                {"United States", "Washington"},
                {"India", "New Delhi"},
                {"Pakistan", "Islamabad"},
                {"United Kingdom", "London"},
                {"UAE", "Abu Dhabi"},
                {"Turkey", "Ankara"}
            };

            if (countries.ContainsKey(selectedCountry))
            {
                string city = countries[selectedCountry];
                PrayerTimesModel prayerTimes = await _prayerTimesService.GetPrayerTimes(city);
                ViewBag.PrayerTimes = prayerTimes;
            }

            ViewBag.Countries = countries;
            return View("Index");
        }
    }
}
