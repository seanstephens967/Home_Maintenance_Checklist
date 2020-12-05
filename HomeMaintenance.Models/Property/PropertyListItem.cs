using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMaintenance.Models.Property
{
    public class PropertyListItem
    {
        [Display(Name = "Property ID")]
        public int PropertyID { get; set; }

        [Display(Name = "First Name")]
        public string PropertyOwnerFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string PropertyOwnerLastName { get; set; }

        [Display(Name = "Address")]
        public string PropertyAddress { get; set; }

        [Display(Name = "Phone")]
        public string PropertyPhone { get; set; }

        [Display(Name = "Email")]
        public string PropertyOwnerEmail { get; set; }
    }
}
