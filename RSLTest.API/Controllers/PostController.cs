using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RSLTest.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RSLTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ModelBaseController<Post>
    {
        protected override string BaseUrl
        {
            get
            {
                return "https://62a1829acc8c0118ef4d1007.mockapi.io/api/Post";
            }
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
    }
}
