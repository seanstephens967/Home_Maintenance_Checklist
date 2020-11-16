using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMaintenance.Data.DataClasses
{
    public enum ProjectSchedule
    {
        Monthly,
        Quarerly,
        Yearly,
        BiAnnually
    }

    public class Project
    {
        [Key]
        public int ProjectID { get; set; }

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
