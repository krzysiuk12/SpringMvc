using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using SpringMvc.Models.Common;
using SpringMvc.Models.POCO;
using SpringMvc.Models.UserAccounts.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.UserAccounts.Services.Implementation
{
    [Repository]
    public class AccountManagementService : BaseSpringService, IAccountManagementService
    {
        [Transaction]
        public void ChangePassword(long userAccountId, string oldPassword, string newPassword)
        {
            UserAccount userAccount = ServiceLocator.UserInformationService.GetUserAccountById(userAccountId);
            if (userAccount.Password != ServiceLocator.AuthorizationService.EncryptPassword(oldPassword))
            {
                //PASSWORD DOES NOT MATCH
            }
            else
            {
                userAccount.Password = ServiceLocator.AuthorizationService.EncryptPassword(newPassword);
                ServiceLocator.AccountAdministrationService.SaveOrUpdateUser(userAccount);
            }
        }

        [Transaction]
        public void EditUserPersonalData(long userId, PersonalData personalData)
        {
            UserAccount userAccount = ServiceLocator.UserInformationService.GetUserAccountById(userId);
            userAccount.PersonalData.FirstName = personalData.FirstName;
            userAccount.PersonalData.LastName = personalData.LastName;
            userAccount.PersonalData.PESEL = personalData.PESEL;
            userAccount.PersonalData.PhoneNumber = personalData.PhoneNumber;
            userAccount.PersonalData.Address.Street = personalData.Address.Street;
            userAccount.PersonalData.Address.PostalCode = personalData.Address.PostalCode;
            userAccount.PersonalData.Address.City = personalData.Address.City;
            userAccount.PersonalData.Address.Country = personalData.Address.Country;
            ServiceLocator.AccountAdministrationService.SaveOrUpdateUser(userAccount);
        }

        [Transaction]
        public void ChangeUserPassword(long userId, String newPassword)
        {
            UserAccount userAccount = ServiceLocator.UserInformationService.GetUserAccountById(userId);
            userAccount.Password = ServiceLocator.AuthorizationService.EncryptPassword(newPassword);
            DaoFactory.AccountAdministrationDao.SaveOrUpdateUser(userAccount);
        }


        [Transaction(ReadOnly = true)]
        public IEnumerable<UserAccount> GetAllUserAccounts()
        {
            return DaoFactory.AccountAdministrationDao.AllUserAccounts;
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<UserAccount> GetAllActiveUserAccounts()
        {
            return DaoFactory.AccountAdministrationDao.AllActiveUserAccounts;
        }

        [Transaction]
        public void LockUser(long userAccountId)
        {
            UserAccount userAccount = DaoFactory.UserInformationDao.GetUserAccountById(userAccountId);
            userAccount.AccountStatus = UserAccount.Status.LOCKED_OUT;
            DaoFactory.AccountAdministrationDao.SaveOrUpdateUser(userAccount);
        }

        [Transaction]
        public void RemoveUser(long userAccountId)
        {
            UserAccount userAccount = DaoFactory.UserInformationDao.GetUserAccountById(userAccountId);
            userAccount.ValidTo = DateTime.Now;
            userAccount.AccountStatus = UserAccount.Status.REMOVED;
            DaoFactory.AccountAdministrationDao.SaveOrUpdateUser(userAccount);
        }

        [Transaction]
        public void TurnOnUser(long userAccountId)
        {
            UserAccount userAccount = DaoFactory.UserInformationDao.GetUserAccountById(userAccountId);
            userAccount.AccountStatus = UserAccount.Status.ACTIVE;
            DaoFactory.AccountAdministrationDao.SaveOrUpdateUser(userAccount);
        }
    }
}