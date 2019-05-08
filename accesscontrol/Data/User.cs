using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace accesscontrol.Data
{
    public class User : BaseEntity
    {
        public User()
        {
            this.UserApplications = new List<UserApplication>();
            this.UserGroups = new List<UserGroup>();
        }

        public List<UserApplication> UserApplications { get; set; }

        public List<UserGroup> UserGroups { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string DocumentNumber { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string CellPhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}