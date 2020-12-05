using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMaintenance.Models.Property
{
    public class PropertyCreate
    {
        [Required]
        [Display(Name = "First Name")]
        public string PropertyOwnerFirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string PropertyOwnerLastName { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string PropertyAddress { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public string PropertyPhone { get; set; }

        [Display(Name = "Email")]
        public string PropertyOwnerEmail { get; set; }
    }
}
