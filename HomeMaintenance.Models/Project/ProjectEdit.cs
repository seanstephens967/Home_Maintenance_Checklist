using HomeMaintenance.Data.DataClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMaintenance.Models.Project
{
    public class ProjectEdit
    {
        public int ProjectID { get; set; }

        public string ProjectName { get; set; }

        public ProjectTask ProjectTask { get; set; }

        public string Description { get; set; }

        public string SuppliesNeeded { get; set; }

        public string Instructions { get; set; }

        public string EstimatedTime { get; set; }

        public DateTimeOffset? ProjectCompletionDate { get; set; }

        public string TechnicianNotes { get; set; }

        public int TechnicianID { get; set; }

        public int PropertyID { get; set; }
    }
}
