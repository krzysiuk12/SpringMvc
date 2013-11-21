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

        public static string AdministratorLogin { get { return "admin"; } }
        public static string AdministratorPassword { get { return "admin";  } }

        public static string WorkerLogin { get { return "worker"; } }
        public static string WorkerPassword { get { return "worker"; } }

        public static string CompanyName { get { return "BookStore"; } }
        public static string CompanyStreet { get { return "Big Tower with Red Eye"; } }
        public static string CompanyPostalCode { get { return "666"; } }
        public static string CompanyCity { get { return "Barad-Dur"; } }
        public static string CompanyCountry { get { return "Mordor"; } }
        public static string CompanyMail { get { return "bookshopto2@gmail.com"; } }

        public static string DataGenFixedIp { get { return "10.0.0.1"; } }

        public MenuObjectProvider MenuProvider { get; set; }

        public static Models.Suggestions.Services.Implementation.SuggestionCache GlobalSuggestionCache = null;

        public static bool ApplicationInitializationDone = false;

    }
}