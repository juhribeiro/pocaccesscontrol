using System.ComponentModel.DataAnnotations;
using accesscontrol.Util;

namespace accesscontrol.Model
{
    public class ChangePasswordModel
    {
        [Required]
        public int Code { get; set; }

        [Required]
        [Compare("ConfirmPassword")]
        public string NewPassword { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}