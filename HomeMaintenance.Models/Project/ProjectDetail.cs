using HomeMaintenance.Data.DataClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMaintenance.Models.Project
{
    public class ProjectDetail
    {
        [Display(Name = "Work Order ID")]
        public int ProjectID { get; set; }

        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        public ProjectTask ProjectTask { get; set; }

        public string Description { get; set; }

        [Display(Name = "Supplies Needed")]
        public string SuppliesNeeded { get; set; }

        [Display(Name = "Instructions")]
        public string Instructions { get; set; }

        [Display(Name = "Estimated Time")]
        public string EstimatedTime { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset ProjectionCreateationDate { get; set; }

        [Display(Name = "Completed")]
        public DateTimeOffset? ProjectCompletionDate { get; set; }

        [Display(Name = "Technician Notes")]
        public string TechnicianNotes { get; set; }

        [Display(Name = "Technician ID")]
        public int TechnicianID { get; set; }

        [Display(Name = "Property ID")]
        public int PropertyID { get; set; }
    }
}
