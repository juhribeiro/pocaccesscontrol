using System.ComponentModel.DataAnnotations;
using accesscontrol.Util;

namespace accesscontrol.Model
{
    public class ResetPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}