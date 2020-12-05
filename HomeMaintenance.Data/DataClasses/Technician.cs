using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMaintenance.Data.DataClasses
{
    public class Technician
    {
        [Key]
        [Display(Name = "Technician ID")]
        public int TechnicianID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string TechnicianName { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public string TechnicianPhoneNumber { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string TechnicianEmail { get; set; }
    }
}
