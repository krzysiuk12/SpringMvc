using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;

namespace SpringMvc.Models
{
    public interface IAddressService
    {
        void SaveAddress(Address address);
    }
}