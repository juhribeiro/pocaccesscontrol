using System;
using System.ComponentModel.DataAnnotations;

namespace accesscontrol.Data
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public string LastChangeUser { get; set; }
        public DateTime LastChangeDate
        {
            get
            {
                return DateTime.UtcNow;
            }
        }

        public bool Active { get; set; }
    }
}