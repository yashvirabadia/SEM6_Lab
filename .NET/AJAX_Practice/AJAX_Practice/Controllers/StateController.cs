using AJAX_Practice.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace AJAX_Practice.Controllers
{
    public class StateController : Controller
    {
     
        private List<CountryModel> GetCountries()
        {
            return new List<CountryModel>
            {
                new CountryModel { Id = 1, Name = "India" },
                new CountryModel { Id = 2, Name = "USA" },
                new CountryModel { Id = 3, Name = "Germany" },
                new CountryModel { Id = 4, Name = "Japan" },
                new CountryModel { Id = 5, Name = "Canada" }
            };
        }

        public IActionResult Index()
        {
            ViewBag.CountryList = GetCountries();
            return View();
        }

        [HttpPost]
        public IActionResult Index(int CountryId)
        {
            ViewBag.CountryList = GetCountries();
            ViewBag.SelectedCountryId = CountryId;

            return View();
        }
    }
}
