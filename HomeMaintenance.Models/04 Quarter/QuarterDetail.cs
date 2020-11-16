using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMaintenance.Models._04_Quarter
{
    public class QuarterDetail
    {
        [Required]
        public int QuarterID { get; set; }

        [Required]
        public string QuarterName { get; set; }

        [Required]
        public int Year { get; set; }
    }
}
