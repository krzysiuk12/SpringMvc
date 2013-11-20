using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Menu.MenuElementMapping
{
    public class MenuPrimaryPositionMappings
    {
        public const int ADMINISTRATOR_VIEW_ALL_USER_ACCOUNTS = 0;
        public const int ADMINISTRATOR_CHANGE_USER_PASSWORD = 1;
        public const int ADMINISTRATOR_CHANGE_USER_STATUS = 2;
        public const int ADMINISTRATOR_VIEW_USER_INFORMATION = 3;

        public const int USERACCOUNT_VIEW = 4;
        public const int USERACCOUNT_EDIT = 5;
        public const int USERACCOUNT_CHANGEPASSWORD = 6;

        public const int SHOP_VIEW_ALL_BOOKS = 7;
        public const int SHOP_CATEGORY_FANTASY = 8;
        public const int SHOP_CATEGORY_FICTIONLITERARY = 9;
        public const int SHOP_CATEGORY_SUSPENCETHRILLERS = 10;
        public const int SHOP_CATEGORY_WESTERN = 11;
        public const int SHOP_CATEGORY_ACTIONADVENTURE = 12;
        public const int SHOP_CATEGORY_CLASSICS = 13;
        public const int SHOP_CATEGORY_GENERAL = 14;
        public const int SHOP_CATEGORY_MYSTERY = 15;
        public const int SHOP_CATEGORY_ROMANCE = 16;
        public const int SHOP_CATEGORY_SCIENCEFICTION = 17;

        public const int WORKER_UNDELIVEREDORDERS = 18;
        public const int WORKER_STOREHOUSESUMMARY = 19;
        public const int WORKER_ADDBOOKWUANTITYVIEW = 20;
        public const int WORKER_ADDBOOK = 21;
    }
}