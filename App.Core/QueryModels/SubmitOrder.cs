using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.QueryModels
{
    public class SubmitOrder
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Firstname Required")]
        [DisplayName("Firstname:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lastname Required")]
        [DisplayName("Lastname:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address Required")]
        [DisplayName("Address:")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City Required")]
        [DisplayName("City:")]
        public string City { get; set; }

        [Required(ErrorMessage = "State Required")]
        [DisplayName("State:")]
        public string State { get; set; }

        [Required(ErrorMessage = "Postal Code Required")]
        [DisplayName("Postal Code:")]
        [RegularExpression(@"^[^<>.!@#%/*~`ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz]+$", ErrorMessage = "Invalid format for postal code")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Country Required")]
        [DisplayName("Country:")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Phone Required")]
        [DisplayName("Phone:")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid format for phone")]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [DisplayName("Email:")]
        [StringLength(50)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Invalid Email Id")]
        public string Email { get; set; }

        public List<CartDetails> CartDetails { get; set; }

    }
}
