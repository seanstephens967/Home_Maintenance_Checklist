using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMaintenance.Data.DataClasses
{
    public class Year
    {
        [Key]
        public int YearID { get; set; }

        [Required]
        public int YearName { get; set; }
    }
}
