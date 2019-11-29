using System;
using System.Collections.Generic;

namespace Animals.Share
{
    public partial class Hinh
    {
        public int Idhinh { get; set; }
        public int? Idtin { get; set; }
        public string DuongDan { get; set; }
        public TinTuc IdtinNavigation { get; set; }
    }
}
