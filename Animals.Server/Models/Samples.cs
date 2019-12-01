using System;
using System.Collections.Generic;
using Animals.Share;
using MySql.Data.Types;

namespace Animals.Server.Models 
{
    public partial class Samples
    {
        public Samples()
        {
            Species = new HashSet<Species>();
        }

        public string SampleId { get; set; }
        public int? Quantity { get; set; }
        public string Archive { get; set; }
        public MySqlGeometry? SampleCoord { get; set; }
        public string State { get; set; }
        public DateTime? CollectDate { get; set; }
        public string Collector { get; set; }
        public string Identifier { get; set; }
        public string Expert { get; set; }

        public ICollection<Species> Species { get; set; }
    }
}
