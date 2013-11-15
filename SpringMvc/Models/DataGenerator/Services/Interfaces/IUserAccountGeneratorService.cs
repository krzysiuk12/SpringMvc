using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpringMvc.Models.DataGenerator.Services.Interfaces
{
    public interface IUserAccountGeneratorService
    {
        List<Address> GenerateAddress();

        List<PersonalData> GeneratePersonalData(List<Address> userAddressList);

        List<UserAccount> GenerateUsers(List<PersonalData> userPersonalDataList);
    }
}
