using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using accesscontrol.Util;

namespace accesscontrol.Model
{
    public class UserModel : BaseModel
    {
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

        private string password = string.Empty;

        [Required]
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = password = Criptografy.EncriptPassword(this.Email, value);
            }
        }

        public DateTime ExpirationDate { get; set; }
    }
}