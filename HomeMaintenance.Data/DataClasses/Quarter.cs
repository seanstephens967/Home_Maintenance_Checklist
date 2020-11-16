using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMaintenance.Data.DataClasses
{
    public class Quarter
    {
        [Key]
        public int QuarterID { get; set; }

        [Required]
        public string QuarterName { get; set; }

        [Required]
        public int YearID { get; set; }
        [ForeignKey(nameof(YearID))]
        public virtual Year Year { get; set; }
    }
}
