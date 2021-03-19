using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [Display(Name = "Zip Code")]
        [Required(ErrorMessage = "Zip Code is Required")]
        public string ZipCode { get; set; }

        [ForeignKey("IdentityUser")]
        [Display(Name = "Employee")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }


    }

}
