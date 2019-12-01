using System;
using System.Collections.Generic;

namespace Animals.Share 
{
    public partial class Topics
    {
        public Topics()
        {
            InverseParent = new HashSet<Topics>();
            News = new HashSet<News>();
        }

        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public int? ParentId { get; set; }
        public short Censored { get; set; }

        public Topics Parent { get; set; }
        public ICollection<Topics> InverseParent { get; set; }
        public ICollection<News> News { get; set; }
    }
}
