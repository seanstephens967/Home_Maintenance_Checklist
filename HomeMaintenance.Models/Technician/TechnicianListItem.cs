using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMaintenance.Models.Technician
{
    public class TechnicianListItem
    {
        public int TechnicianID { get; set; }

        public string TechnicianName { get; set; }

        public string TechnicianPhoneNumber { get; set; }

        public string TechnicianEmail { get; set; }
    }
}
