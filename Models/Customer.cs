using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }

        [Display(Name = "Zip Code")]
        [Required(ErrorMessage = "Zip Code is Required")]
        public int ZipCode { get; set; }

        [Display(Name = "Pickup Day")]
        [Required(ErrorMessage = "Pickup Day is Required")]
        public string PickupDay { get; set; }

        [Display(Name = "Is Pickup Confirmed")]
        public string IsPickupConfirmed { get; set; }

        [Display(Name = "Extra Pickup Day")]
        
        public DateTime? ExtraPickupDay { get; set; }

        [Display(Name = "Amount Owed")]
        public int AmountOwed { get; set; }

        [Display(Name = "Start Suspension Day")]
  
        public DateTime? StartSuspensionDay { get; set; }

        [Display(Name = "End Suspension Day")]
       
        public DateTime? EndSuspensionDay { get; set; }

        [Display(Name = "Last Pickup Day")]
        public DateTime? LastPickupDay { get; set; }

        [ForeignKey("IdentityUser")]
        [Display(Name = "Customer")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }


       

    }
}
