using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreMvc.Models
{
    public class StampedRecord
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime Updated { get; set; }
        public string UpdatedByUserId { get; set; }
    }
}
