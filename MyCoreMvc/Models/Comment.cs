using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreMvc.Models
{
    public class Comment
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
        public string UserId { get; set; }
        public string Contents { get; set; }

        public string PostId { get; set; }
        public Post Post { get; set; }
    }
}
