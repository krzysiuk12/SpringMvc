using SpringMvc.Models.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.Common
{
    public class BaseSpringService
    {
        public IDaoFactory DaoFactory { get; set; }

        public ServiceLocator ServiceLocator { get; set; }
    }
}