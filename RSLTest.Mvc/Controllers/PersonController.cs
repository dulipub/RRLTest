using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RSLTest.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RSLTest.Mvc.Controllers
{
    public class PersonController : Controller
    {
        public async Task<IActionResult> Index()
        {
            IList<PersonViewModel> people = new List<PersonViewModel>();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constants.WebApiUrl);
                    //HTTP GET
                    var responseTask = client.GetAsync("Person");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync().Result;
                        people = JsonConvert.DeserializeObject<IList<PersonViewModel>>(readTask);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(people);
        }

        [Route("Person/{id}")]
        public async Task<IActionResult> Single(int id)
        {
            PersonViewModel person = null;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constants.WebApiUrl);
                    //HTTP GET
                    var responseTask = client.GetAsync($"Person/{id}");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync().Result;
                        person = JsonConvert.DeserializeObject<PersonViewModel>(readTask);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    }
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(person);
        }
    }
}
