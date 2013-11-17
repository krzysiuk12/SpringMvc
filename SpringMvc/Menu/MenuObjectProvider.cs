using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
namespace SpringMvc.Menu
{
    public class MenuObjectProvider
    {
        public MenuObject AdministratorMenu { get; set; }
        public MenuObject UserAccountMenu { get; set; }
        public MenuObject WorkerMenu { get; set; }
        public MenuObject GuestMenu { get; set; }
        public List<MenuObject> GetAllMenuObjects { get; set; }
    }
}