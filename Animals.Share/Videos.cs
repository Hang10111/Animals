using System;
using System.Collections.Generic;

namespace Animals.Share 
{
    public partial class Videos
    {
        public int VideoId { get; set; }
        public int NewsId { get; set; }
        public string VideoPath { get; set; }

        public News News { get; set; }
    }
}
