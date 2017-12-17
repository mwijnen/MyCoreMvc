using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreMvc.Models
{
    public class Comment : StampedRecord
    {        
        public string Contents { get; set; }

        public string PostId { get; set; }
        public Post Post { get; set; }
    }
}
