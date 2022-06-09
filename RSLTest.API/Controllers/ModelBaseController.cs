using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace RSLTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ModelBaseController<T> : ControllerBase where T : Models.BaseModel
    {
        protected abstract string BaseUrl { get; }

        // GET: api/<ModelController>
        [HttpGet]
        public async Task<ActionResult<List<T>>> Get()
        {
            List<T> results = new List<T>();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(BaseUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                results = DeseializeGetAll(response);
            }

            return Ok(results);
        }

        // GET api/<ModelController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<T>> Get(int id)
        {
            string getSingleUrl =  $"{BaseUrl}/{id}";
            T result = default;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(getSingleUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                result = DeseializeGetSingle(response);
            }

            return Ok(result);
        }

        //// POST api/<ModelController>
        //[HttpPost]
        //public async Task<ActionResult> Post([FromBody] T value)
        //{
        //    return Ok();
        //}

        //// PUT api/<ModelController>/5
        //[HttpPut("{id}")]
        //public async Task<ActionResult> Put(int id, [FromBody] T value)
        //{
        //    return Ok();
        //}

        //// DELETE api/<ModelController>/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    return Ok();
        //}

        protected abstract List<T> DeseializeGetAll(HttpResponseMessage response);

        protected abstract T DeseializeGetSingle(HttpResponseMessage response);
    }
}
