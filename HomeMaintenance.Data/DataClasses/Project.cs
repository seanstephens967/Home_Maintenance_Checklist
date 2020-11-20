﻿using System;
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
        public int ProjectID { get; set; }

        [Required]
        public string ProjectName { get; set; }

        [Required]
        public ProjectTask ProjectTask { get; set; }

        [Required]
        public string Description { get; set; }

        public string SuppliesNeeded { get; set; }

        public string Instructions { get; set; }

        public string EstimatedTime { get; set; }

        [Required]
        public DateTimeOffset ProjectionCreateationDate { get; set; }

        public DateTimeOffset? ProjectCompletionDate { get; set; }

        public string TechnicianNotes { get; set; }

        public int TechnicianID { get; set; }
        public virtual Technician Technician { get; set; }

        public int PropertyID { get; set; }
        public virtual Property Property { get; set; }
    }
}
