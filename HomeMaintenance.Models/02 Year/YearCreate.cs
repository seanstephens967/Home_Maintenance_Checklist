﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMaintenance.Models._02_Year
{
    public class YearCreate
    {
        [Required]
        public int Year { get; set; }
    }
}
