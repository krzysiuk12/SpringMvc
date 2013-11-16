using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Menu.MenuPositions
{
    public abstract class BaseMenuPosition
    {
        public string Label { get; set; }

        public string ControllerAction { get; set; }

        public string ControllerName { get; set; }
    }
}