﻿using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.Common
{
    public class SessionScope
    {
        public UserAccount LoggedUser { get; set; }
    }
}