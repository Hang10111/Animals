using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Animals.Server.Extensions;
using Animals.Server.Models;
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
            var sinhVat = Services.DataBaseService.DataBase.Species.ToList();
            List<Tuple<Species, ObservableCollection<Images>, ObservableCollection<Location>>> Result = new List<Tuple<Species, ObservableCollection<Images>, ObservableCollection<Location>>>();
            foreach (var item in sinhVat)
            {
                var hinhs = Services.DataBaseService.DataBase.Images.Where(e => e.NewsId == item.SpeciesId);
                Services.DataBaseService.DataBase.ConsvStatus.FirstOrDefault(e=>e.StatusId == item.StatusId);
                var location = Services.DataBaseService.DataBase.Coordinates.Where(locationitem => locationitem.SpeciesId == item.SpeciesId);
                Result.Add(new Tuple<Species, ObservableCollection<Images>, ObservableCollection<Location>>(
                    item,
                    new ObservableCollection<Images>(hinhs),
                    new ObservableCollection<Location>(location.Select(locationitem =>
                    new Location(locationitem.Coord.Value.XCoordinate ?? 0,
                    locationitem.Coord.Value.YCoordinate ?? 0)))));
            }
            return this.OKResult(Result);
        }
    }
}
