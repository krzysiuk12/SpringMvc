using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Menu.MenuElementMapping;

namespace SpringMvc.Menu.MenuComponents
{
    public abstract class MenuComponent
    {
        public string Label { get; set; }

        public string ControllerAction { get; set; }

        public string ControllerName { get; set; }

        public abstract MenuComponent GetMappedChildMenuPosition(int globalMenuPosition);
    }
}