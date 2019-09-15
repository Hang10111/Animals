using System;
using System.Collections.Generic;

namespace Animals.Share
{
    public partial class Video
    {
        public int Idvideo { get; set; }
        public string DuongDanVideo { get; set; }

        public TinTuc IdvideoNavigation { get; set; }
    }
}
