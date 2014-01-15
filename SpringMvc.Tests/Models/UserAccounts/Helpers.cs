using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpringMvc.Models.POCO;

namespace SpringMvc.Tests.Models.UserAccounts
{
    class Helpers
    {
        public UserAccount UserAccountHelper(UserAccount userAccount)
        {
            userAccount.AccountStatus = SpringMvc.Models.POCO.UserAccount.Status.ACTIVE;
            userAccount.Login = AuthorizationTestData.LOGIN;
            userAccount.Password = AuthorizationTestData.PASSWORD;
            userAccount.PersonalData = PersonalDataHelper();
            return userAccount;
        }

        public PersonalData PersonalDataHelper()
        {
            PersonalData testPersonalData = new PersonalData();
            testPersonalData.FirstName = AuthorizationTestData.FIRST_NAME;
            testPersonalData.LastName = AuthorizationTestData.LAST_NAME;
            testPersonalData.PESEL = AuthorizationTestData.PESEL;
            testPersonalData.PhoneNumber = AuthorizationTestData.PHONE_NUMBER;
            testPersonalData.Address = new Address();
            testPersonalData.Address.Street = AuthorizationTestData.ADDRESS_STREET;
            testPersonalData.Address.PostalCode = AuthorizationTestData.ADDRESS_POSTAL_CODE;
            testPersonalData.Address.City = AuthorizationTestData.ADDRESS_CITY;
            testPersonalData.Address.Country = AuthorizationTestData.ADDRESS_COUNTRY;
            return testPersonalData;
        }
    }
}
