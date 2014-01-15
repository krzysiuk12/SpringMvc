using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using SpringMvc.Models.Common;
using SpringMvc.Models.POCO;
using SpringMvc.Models.UserAccounts.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.UserAccounts.Dao.Interfaces;

namespace SpringMvc.Models.UserAccounts.Services.Implementation
{
    [Repository]
    public class AccountManagementService : BaseSpringService, IAccountManagementService
    {
        #region IUserInformationService
        private IUserInformationService userInformationService;

        public IUserInformationService UserInformationService
        {
            get
            {
                if (userInformationService == null)
                    return ServiceLocator.UserInformationService;
                return userInformationService;
            }
            set
            {
                userInformationService = value;
            }
        }
        #endregion
        #region IAuthorizationService
        private IAuthorizationService authorizationService;

        public IAuthorizationService AuthorizationService
        {
            get
            {
                if (authorizationService == null)
                    return ServiceLocator.AuthorizationService;
                return authorizationService;
            }
            set
            {
                authorizationService = value;
            }
        }
        #endregion
        #region IAccountAdministrationService
        private IAccountAdministrationService accountAdministrationService;

        public IAccountAdministrationService AccountAdministrationService
        {
            get
            {
                if (accountAdministrationService == null)
                    return ServiceLocator.AccountAdministrationService;
                return accountAdministrationService;
            }
            set
            {
                accountAdministrationService = value;
            }
        }
        #endregion
        #region IUserInformationDao
        private IUserInformationDao userInformationDao;

        public IUserInformationDao UserInformationDao
        {
            get
            {
                if (userInformationDao == null)
                    return DaoFactory.UserInformationDao;

                return userInformationDao;
            }
            set
            {
                userInformationDao = value;
            }
        }
        #endregion
        #region IAccountAdministrationDao
        private IAccountAdministrationDao accountAdministrationDao;

        public IAccountAdministrationDao AccountAdministrationDao
        {
            get
            {
                if (accountAdministrationDao == null)
                    return DaoFactory.AccountAdministrationDao;

                return accountAdministrationDao;
            }
            set
            {
                accountAdministrationDao = value;
            }
        }
        #endregion

        [Transaction]
        public void ChangePassword(long userAccountId, string oldPassword, string newPassword)
        {
            UserAccount userAccount = UserInformationService.GetUserAccountById(userAccountId);
            if (userAccount.Password != AuthorizationService.EncryptPassword(oldPassword))
            {
                //PASSWORD DOES NOT MATCH
            }
            else
            {
                userAccount.Password = AuthorizationService.EncryptPassword(newPassword);
                AccountAdministrationService.SaveOrUpdateUser(userAccount);
            }
        }

        [Transaction]
        public void EditUserPersonalData(long userId, PersonalData personalData)
        {
            UserAccount userAccount = UserInformationService.GetUserAccountById(userId);
            userAccount.PersonalData.FirstName = personalData.FirstName;
            userAccount.PersonalData.LastName = personalData.LastName;
            userAccount.PersonalData.PESEL = personalData.PESEL;
            userAccount.PersonalData.PhoneNumber = personalData.PhoneNumber;
            userAccount.PersonalData.Address.Street = personalData.Address.Street;
            userAccount.PersonalData.Address.PostalCode = personalData.Address.PostalCode;
            userAccount.PersonalData.Address.City = personalData.Address.City;
            userAccount.PersonalData.Address.Country = personalData.Address.Country;
            AccountAdministrationService.SaveOrUpdateUser(userAccount);
        }

        [Transaction]
        public void ChangeUserPassword(long userId, String newPassword)
        {
            UserAccount userAccount = UserInformationService.GetUserAccountById(userId);
            userAccount.Password = AuthorizationService.EncryptPassword(newPassword);
            AccountAdministrationDao.SaveOrUpdateUser(userAccount);
        }


        [Transaction(ReadOnly = true)]
        public IEnumerable<UserAccount> GetAllUserAccounts()
        {
            return AccountAdministrationDao.AllUserAccounts;
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<UserAccount> GetAllActiveUserAccounts()
        {
            return AccountAdministrationDao.AllActiveUserAccounts;
        }

        [Transaction]
        public void LockUser(long userAccountId)
        {
            UserAccount userAccount = UserInformationDao.GetUserAccountById(userAccountId);
            userAccount.AccountStatus = UserAccount.Status.LOCKED_OUT;
            AccountAdministrationDao.SaveOrUpdateUser(userAccount);
        }

        [Transaction]
        public void RemoveUser(long userAccountId)
        {
            UserAccount userAccount = UserInformationDao.GetUserAccountById(userAccountId);
            userAccount.ValidTo = DateTime.Now;
            userAccount.AccountStatus = UserAccount.Status.REMOVED;
            AccountAdministrationDao.SaveOrUpdateUser(userAccount);
        }

        [Transaction]
        public void TurnOnUser(long userAccountId)
        {
            UserAccount userAccount = UserInformationDao.GetUserAccountById(userAccountId);
            userAccount.AccountStatus = UserAccount.Status.ACTIVE;
            AccountAdministrationDao.SaveOrUpdateUser(userAccount);
        }
    }
}