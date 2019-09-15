using System;
using System.Collections.Generic;
using MySql.Data.Types;
using Animals.Share;

namespace Animals.Server.Models
{
    public partial class VungDiaLi
    {
        public int IdVung { get; set; }
        public int? IdSinhVat { get; set; }
        public MySqlGeometry? ToaDo { get; set; }

        public SinhVat IdSinhVatNavigation { get; set; }
    }
}
