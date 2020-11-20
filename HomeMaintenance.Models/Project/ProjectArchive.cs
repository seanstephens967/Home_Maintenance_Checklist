using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMaintenance.Models.Project
{
    public class ProjectArchive
    {
        [Required]
        public int ProjectID { get; set; }

        [Required]
        public DateTimeOffset? ProjectCompletionDate { get; set; }
    }
}
