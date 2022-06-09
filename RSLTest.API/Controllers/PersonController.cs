using Logic;
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
    public class PersonController : ModelBaseController<Models.Person>
    {
        protected override string BaseUrl
        {
            get
            {
                return "https://62a1829acc8c0118ef4d1007.mockapi.io/api/Person";
            }
        }

        protected override List<Person> DeseializeGetAll(HttpResponseMessage response)
        {
            List<Person> res = JsonConvert.DeserializeObject<List<Person>>(response.Content.ReadAsStringAsync().Result);
            return res;
        }

        protected override Person DeseializeGetSingle(HttpResponseMessage response)
        {
            Person res = JsonConvert.DeserializeObject<Person>(response.Content.ReadAsStringAsync().Result);
            return res;
        }
    }
}
