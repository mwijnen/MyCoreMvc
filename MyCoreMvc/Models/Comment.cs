using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreMvc.Models
{
    public class Comment : StampedRecord
    {        
        public string Contents { get; set; }

        [MaxLength(450)]
        public string PostId { get; set; }

        public Post Post { get; set; }
    }
}
