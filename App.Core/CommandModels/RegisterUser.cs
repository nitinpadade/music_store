using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.CommandModels
{
    public class RegisterUser
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Firstname Required")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Lastname Required")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [StringLength(50)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Invalid Email Id")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile Required")]
        [StringLength(20)]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
