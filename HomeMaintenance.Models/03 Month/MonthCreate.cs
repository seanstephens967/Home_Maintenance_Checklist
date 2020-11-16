using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMaintenance.Models._03_Month
{
    public class MonthCreate
    {
        [Required]
        public string MonthName { get; set; }

        [Required]
        public int Year { get; set; }
    }
}
