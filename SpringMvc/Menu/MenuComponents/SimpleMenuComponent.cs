using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Menu.MenuComponents
{
    public class SimpleMenuComponent : MenuComponent
    {
        public override MenuComponent GetMappedChildMenuPosition(int globalMenuPosition)
        {
            return null;
        } 
    }
}