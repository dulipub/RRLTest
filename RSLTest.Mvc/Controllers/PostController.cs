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
    public class PostController : Controller
    {
        public async Task<IActionResult> Index()
        {
            IList<PostViewModel> posts = new List<PostViewModel>();

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constants.WebApiUrl);
                    //HTTP GET
                    var responseTask = client.GetAsync("Post");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync().Result;
                        posts = JsonConvert.DeserializeObject<IList<PostViewModel>>(readTask);
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

            return View(posts);
        }

        [Route("Post/{id}")]
        public async Task<IActionResult> Single(int id)
        {
            PostViewModel post = null;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constants.WebApiUrl);
                    //HTTP GET
                    var responseTask = client.GetAsync($"Post/{id}");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsStringAsync().Result;
                        post = JsonConvert.DeserializeObject<PostViewModel>(readTask);
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

            return View(post);
        }
    }
}
