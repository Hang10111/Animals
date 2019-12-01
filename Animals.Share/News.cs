using System;
using System.Collections.Generic;

namespace Animals.Share 
{
    public partial class News
    {
        public News()
        {
            Images = new HashSet<Images>();
            Videos = new HashSet<Videos>();
        }

        public int NewsId { get; set; }
        public int? UsrId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public int? TopicId { get; set; }
        public string NewsType { get; set; }
        public DateTime? TimeStamp { get; set; }
        public short? Censored { get; set; }
        public int? CensoredBy { get; set; }
        public DateTime? CensoredDate { get; set; }
        public string Feedback { get; set; }
        public short? Deleted { get; set; }

        public Users CensoredByNavigation { get; set; }
        public Topics Topic { get; set; }
        public Users Usr { get; set; }
        public Species Species { get; set; }
        public ICollection<Images> Images { get; set; }
        public ICollection<Videos> Videos { get; set; }
    }
}
