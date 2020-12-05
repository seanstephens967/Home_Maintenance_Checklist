using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMaintenance.Models.Technician
{
    public class TechnicianCreate
    {
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
