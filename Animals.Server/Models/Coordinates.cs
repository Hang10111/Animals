using System;
using System.Collections.Generic;
using Animals.Share;
using MySql.Data.Types;

namespace Animals.Server.Models
{
    public partial class Coordinates
    {
        public int CoordId { get; set; }
        public int SpeciesId { get; set; }
        public MySqlGeometry? Coord { get; set; }
        public int? HotspotId { get; set; }

        public Hotspots Hotspot { get; set; }
        public Species Species { get; set; }
    }
}
