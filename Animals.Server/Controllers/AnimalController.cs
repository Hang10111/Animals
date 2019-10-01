using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public AnimalController() { }

        [HttpGet]
        public IActionResult Get()
        {
            var sinhVat = Services.DataBaseService.DataBase.SinhVat.ToList();
            List<Tuple<SinhVat, Hinh, ObservableCollection<Location>>> Result = new List<Tuple<SinhVat, Hinh, ObservableCollection<Location>>>();
            foreach (var item in sinhVat)
            {
                var hinh = Services.DataBaseService.DataBase.Hinh.FirstOrDefault(e => e.Idtin == item.IdSinhVat);
                var location = Services.DataBaseService.DataBase.VungDiaLi.Where(locationitem => locationitem.IdSinhVat == item.IdSinhVat);
                Result.Add(new Tuple<SinhVat, Hinh, ObservableCollection<Location>>(
                    item,
                    hinh,
                    new ObservableCollection<Location>(location.Select(locationitem =>
                    new Location(locationitem.ToaDo.Value.XCoordinate ?? 0,
                    locationitem.ToaDo.Value.YCoordinate ?? 0)))));
            }
            return this.OKResult(Result);
        }
    }
}
