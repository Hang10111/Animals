using System;
using System.Collections.Generic;

namespace Animals.Share 
{
    public partial class Users
    {
        public Users()
        {
            NewsCensoredByNavigation = new HashSet<News>();
            NewsUsr = new HashSet<News>();
        }

        public int UsrId { get; set; }
        public string Usrname { get; set; }
        public string Pass { get; set; }
        public string UsrType { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? PhoneNum { get; set; }
        public short? Exist { get; set; }

        public ICollection<News> NewsCensoredByNavigation { get; set; }
        public ICollection<News> NewsUsr { get; set; }
    }
}
