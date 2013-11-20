using SpringMvc.Menu.MenuComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
namespace SpringMvc.Menu
{
    public class MenuObjectProvider
    {

        public MenuComponent AdministratorMenu { get; set; }
        public MenuComponent UserAccountMenu { get; set; }
        public MenuComponent WorkerMenu { get; set; }
        public MenuComponent GuestMenu { get; set; }


    }
}