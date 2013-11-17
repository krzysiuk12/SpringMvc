using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Menu
{
    public class MenuMapping
    {
        public enum MenuObjectsOrder
        {
            ADMINISTRATOR_MENU = 0,
            USER_ACCOUNT_MENU = 1,
            WORKER_MENU = 2,
            GUEST_MENU = 3
        }

        public enum MenuPrimaryPositionOrder
        { 
            ADMINISTRATOR_PANEL = 0,
            WORKER_PANEL = 1,
            SHOP = 2,
            USER_ACCOUNT_PANEL = 3,
            ABOUT = 4,
            CONTACT = 5
        }
    }
}