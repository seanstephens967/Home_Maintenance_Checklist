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
        public string TechnicianName { get; set; }

        [Required]
        public string TechnicianPhoneNumber { get; set; }

        [Required]
        public string TechnicianEmail { get; set; }
    }
}
