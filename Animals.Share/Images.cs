using System;
using System.Collections.Generic;

namespace Animals.Share 
{
    public partial class Images
    {
        public int ImgId { get; set; }
        public int? NewsId { get; set; }
        public string ImgPath { get; set; }

        public News News { get; set; }
    }
}
