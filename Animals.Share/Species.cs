using System;
using System.Collections.Generic;

namespace Animals.Share 
{
    public partial class Species
    {
        public Species() { }

        public int SpeciesId { get; set; }
        public string ScientificName { get; set; }
        public string VietName { get; set; }
        public string EngName { get; set; }
        public int? Genus { get; set; }
        public string Distribution { get; set; }
        public string MorphoCharcs { get; set; }
        public string BioCharcs { get; set; }
        public string Reproduction { get; set; }
        public string Habitats { get; set; }
        public string Danger { get; set; }
        public string UseValue { get; set; }
        public string SampleId { get; set; }
        public byte? IsAnimal { get; set; }
        public string StatusId { get; set; }

        public Taxonomy GenusNavigation { get; set; }
        public News SpeciesNavigation { get; set; }
        public ConsvStatus Status { get; set; }
    }
}
