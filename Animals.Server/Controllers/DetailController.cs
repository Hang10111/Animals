using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animals.Server.Extensions;
using Animals.Share;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Animals.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailController : ControllerBase
    {
        private readonly IHostingEnvironment _environment;
        public DetailController(IHostingEnvironment  environment)
        {
            _environment = environment;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var sinhVat = Services.DataBaseService.DataBase.SinhVat.ToList();
            List<Tuple<SinhVat, Hinh>> Result = new List<Tuple<SinhVat, Hinh>>();
            foreach (var item in sinhVat)
            {
                var hinh = Services.DataBaseService.DataBase.Hinh.FirstOrDefault(e => e.Idtin == item.IdSinhVat);
                hinh.DuongDan = hinh.DuongDan.ConvertToURLString();
                Result.Add(new Tuple<SinhVat, Hinh>(item, hinh));
            }
            return this.OKResult(Result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
