﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeMaintenance.Models.Users
{
    public class UserEdit
    {
        public string UserID { get; set; }

        public string UserName { get; set; }

        public bool IsAdmin { get; set; }
    }
}
