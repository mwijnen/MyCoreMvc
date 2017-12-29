using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyCoreMvc.Models
{
    public class Post : StampedRecord
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string CategoryId { get; set; }
        public string Abstract { get; set; }
        public string Body { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
