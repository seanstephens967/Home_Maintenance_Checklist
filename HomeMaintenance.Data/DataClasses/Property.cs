using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMaintenance.Data.DataClasses
{
    public class Property
    {
        [Key]
        [Display(Name = "Property ID")]
        public int PropertyID { get; set; }

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
