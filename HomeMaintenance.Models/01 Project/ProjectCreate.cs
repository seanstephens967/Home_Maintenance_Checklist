using HomeMaintenance.Data.DataClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMaintenance.Models._01_Project
{
    public class ProjectCreate
    {
        [Required]
        public string ProjectName { get; set; }

        [Required]
        public ProjectSchedule ProjectSchedule { get; set; }

        public string SuppliesNeeded { get; set; }

        public string Instructions { get; set; }

        public string EstimatedTime { get; set; }

        public DateTimeOffset? ProjectCompletionDate { get; set; }

        public string ProjectCompletionINTS { get; set; }
    }
}
