using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RSLTest.API.Models;
using RSLTest.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RSLTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ModelBaseController<Post>
    {
        private readonly IIOService<Post> _iOService;

        protected override string BaseUrl
        {
            get
            {
                return "https://62a1829acc8c0118ef4d1007.mockapi.io/api/Post";
            }
        }

        public PostController(IIOService<Post> iOService)
        {
            _iOService = iOService;
        }

        protected override List<Post> DeseializeGetAll(HttpResponseMessage response)
        {
            List<Post> res = JsonConvert.DeserializeObject<List<Post>>(response.Content.ReadAsStringAsync().Result);
            return res;
        }

        protected override Post DeseializeGetSingle(HttpResponseMessage response)
        {
            Post res = JsonConvert.DeserializeObject<Post>(response.Content.ReadAsStringAsync().Result);
            return res;
        }

        [HttpPost("Export")]
        public FileResult ExportPosts()
        {
            string csv = _iOService.ConvertListToCSV(GetModelList());
            return File(Encoding.UTF8.GetBytes(csv), "text/csv", "posts.csv");
        }
    }
}
