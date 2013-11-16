using SpringMvc.Menu.MenuPositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Menu
{
    public class MenuObject
    {
        public int CurrentPrimaryPosition { get; set; }

        public IList<PrimaryMenuPosition> PrimaryMenuPositions { get; set; }
    }
}