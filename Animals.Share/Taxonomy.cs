using System;
using System.Collections.Generic;

namespace Animals.Share 
{
    public partial class Taxonomy
    {
        public Taxonomy()
        {
            InverseParent = new HashSet<Taxonomy>();
            Species = new HashSet<Species>();
        }

        public int TaxonId { get; set; }
        public string TaxonName { get; set; }
        public int? ParentId { get; set; }

        public Taxonomy Parent { get; set; }
        public ICollection<Taxonomy> InverseParent { get; set; }
        public ICollection<Species> Species { get; set; }
    }
}
