﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.Common
{
    public class ApplicationScope
    {
        public static long GuestId { get { return 0; } }
        public static long AdministratorId { get { return 1;  } }
        public static long WorkerId { get { return 2; } }
    }
}