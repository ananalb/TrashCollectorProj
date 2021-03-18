using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [Display(Name = "Street Name")]
        [Required(ErrorMessage = "Street Name is Required")]
        public string StreetName { get; set; }

        [Display(Name = "Zip Code")]
        [Required(ErrorMessage = "Zip Code is Required")]
        public int ZipCode { get; set; }
    }
}
