using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreMvc.Models
{
    public class StampedRecord
    {
        [MaxLength(450)]
        public string Id { get; set; }

        [Key, MaxLength(450)]
        public string VersionId { get; set; }

        public DateTime DateTimeStamp { get; set; }

        [MaxLength(450)]
        public string UserId { get; set; }

        public DateTime Deleted { get; set; }




        public void SetId()
        {
            if (Id == null || Id == string.Empty)
            {
                Id = System.Guid.NewGuid().ToString();
            }
        }

        public void SetVersion(string userId = "default_user")
        {
            VersionId = System.Guid.NewGuid().ToString();
            DateTimeStamp = DateTime.Now;
            UserId = userId;
        }

        public void Delete()
        {
            Deleted = DateTime.Now;
        }
    }
}
