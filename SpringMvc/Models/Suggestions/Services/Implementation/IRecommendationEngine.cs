using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Shop.Services.Interfaces;

namespace SpringMvc.Models.Suggestions.Services.Implementation
{
    interface IRecommendationEngine
    {
        IEnumerable<long> GenerateRecommendation();

        IOrderInformationsService OrderInformationsService
        {
            get;
            set;
        }
    }
}
