using SpringMvc.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.Common
{
    public class ApplicationScope
    {
        public static long GuestId { get { return 0; } }
        public static long AdministratorId { get { return 1;  } }
        public static long WorkerId { get { return 2; } }

        public static String AdministratorLogin { get { return "admin"; } }
        public static String AdministratorPassword { get { return "admin";  } }

        public static String WorkerLogin { get { return "worker"; } }
        public static String WorkerPassword { get { return "worker"; } }

        public MenuObjectProvider MenuProvider { get; set; }

        public static Models.Suggestions.Services.Implementation.SuggestionCache GlobalSuggestionCache = null;

        public static bool ApplicationInitializationDone = false;

    }
}