using System.ComponentModel.DataAnnotations;
using accesscontrol.Util;

namespace accesscontrol.Model
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

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
                password = Criptografy.EncriptPassword(this.Email, value);
            }
        }
    }
}