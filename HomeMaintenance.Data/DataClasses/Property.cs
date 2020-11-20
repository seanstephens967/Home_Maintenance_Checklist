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
        public int PropertyID { get; set; }

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
