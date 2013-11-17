using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Menu.MenuPositions
{
    public class PrimaryMenuPosition : BaseMenuPosition
    {
        public int CurrentSecondaryPosition { get; set; }
        public IList<SecondaryMenuPosition> SecondaryMenuPositions { get; set; }
    }
}