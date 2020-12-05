using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMaintenance.Data.DataClasses
{
    public enum ProjectTask
    {
        Plumbing,
        Electrial,
        AC,
        HVAC,
        Appliance,
        Locks,
        Exterior,
        Miscellaneous
    }

    public class Project
    {
        [Key]
        [Display(Name = "Work Order ID")]
        public int ProjectID { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required]
        public ProjectTask ProjectTask { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Supplies Needed")]
        public string SuppliesNeeded { get; set; }

        [Display(Name = "Description")]
        public string Instructions { get; set; }

        [Display(Name = "Estimated Time")]
        public string EstimatedTime { get; set; }

        [Required]
        [Display(Name = "Created")]
        public DateTimeOffset ProjectionCreateationDate { get; set; }

        [Display(Name = "Completed")]
        public DateTimeOffset? ProjectCompletionDate { get; set; }

        [Display(Name = "Technician Notes")]
        public string TechnicianNotes { get; set; }

        [Display(Name = "Technician ID")]
        public int TechnicianID { get; set; }
        public virtual Technician Technician { get; set; }

        [Display(Name = "Property ID")]
        public int PropertyID { get; set; }
        public virtual Property Property { get; set; }
    }
}
