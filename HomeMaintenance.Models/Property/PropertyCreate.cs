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
        public string PropertyOwnerFirstName { get; set; }

        [Required]
        public string PropertyOwnerLastName { get; set; }

        [Required]
        public string PropertyAddress { get; set; }

        [Required]
        public string PropertyPhone { get; set; }

        public string PropertyOwnerEmail { get; set; }
    }
}
