using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpringMvc.Models.POCO;

namespace SpringMvc.Tests.Models.UserAccounts
{
    class AuthorizationTestData
    {
        #region LoginInformation
        public static string LOGIN = "test";
        public static string PASSWORD = "password";
        public static string NEW_PASSWORD = "newPassword";
        public static string WRONG_PASSWORD = "wrongPassword";
        #endregion 

        #region AccountInformation
        public static string FIRST_NAME = "Jan";
        public static string LAST_NAME = "Nowak";
        public static string PESEL = "92010100000";
        public static string PHONE_NUMBER = "1122334455";
        public static string ADDRESS_STREET = "Mickiewicza";
        public static string ADDRESS_POSTAL_CODE = "00-000";
        public static string ADDRESS_CITY = "Krakow";
        public static string ADDRESS_COUNTRY = "Polska";
        #endregion  

        #region EditAccountInformation
        public static string EDIT_FIRST_NAME = "Adam";
        public static string EDIT_LAST_NAME = "Kowalski";
        public static string EDIT_PESEL = "92010100001";
        public static string EDIT_PHONE_NUMBER = "2222222222";
        public static string EDIT_ADDRESS_STREET = "Czarnowiejska";
        public static string EDIT_ADDRESS_POSTAL_CODE = "11-111";
        public static string EDIT_ADDRESS_CITY = "Warszawa";
        public static string EDIT_ADDRESS_COUNTRY = "Great Britain";
        #endregion



    }
}
