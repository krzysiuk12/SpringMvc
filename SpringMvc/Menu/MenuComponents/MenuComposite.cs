using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Menu.MenuComponents
{
    public class MenuComposite : MenuComponent
    {
        public int CurrentChildPosition { get; set; }

        public IList<MenuComponent> ChildrenMenuPositions { get; set; }

        public virtual int GetMappedChildMenuPosition()
        {
            return 0;
        }
    }
}