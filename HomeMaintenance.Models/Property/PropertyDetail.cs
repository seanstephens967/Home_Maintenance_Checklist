using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMaintenance.Models.Property
{
    public class PropertyDetail
    {
        public int PropertyID { get; set; }

        public string PropertyOwnerFirstName { get; set; }

        public string PropertyOwnerLastName { get; set; }

        public string PropertyAddress { get; set; }

        public string PropertyPhone { get; set; }

        public string PropertyOwnerEmail { get; set; }
    }
}
