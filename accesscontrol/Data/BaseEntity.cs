using System;
using System.ComponentModel.DataAnnotations;

namespace accesscontrol.Data
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int? CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public int? LastChangeUser { get; set; }
        public DateTime LastChangeDate { get; set; }
        public bool Active { get; set; }
    }
}