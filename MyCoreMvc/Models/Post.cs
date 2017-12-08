using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreMvc.Models
{
    public class Post
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
        public string UpdatedBy { get; set; }
        public string CategoryId { get; set; }
        public string Abstract { get; set; }
        public string Contents { get; set; }
    }
}
