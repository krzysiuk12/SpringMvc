﻿using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.UserAccounts.Services.Interfaces
{
    public interface IUserInformationService
    {
        UserAccount GetUserAccountById(long userAccountId);
    }
}
