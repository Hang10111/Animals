using System;
using System.Collections.Generic;
using System.Linq;
using Animals.Server.Extensions;
using Animals.Share;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Animals.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IHostingEnvironment _environment;

        public AnimalController(IHostingEnvironment  environment)
        {
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var sinhVat = Services.DataBaseService.DataBase.SinhVat.ToList();
            List<Tuple<SinhVat, Hinh>> Result = new List<Tuple<SinhVat, Hinh>>();
            foreach (var item in sinhVat)
            {
                var hinh = Services.DataBaseService.DataBase.Hinh.FirstOrDefault(e => e.Idtin == item.IdSinhVat);
                Result.Add(new Tuple<SinhVat, Hinh>(item, hinh));
            }
            return this.OKResult(Result);
        }
    }
}
