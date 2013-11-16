using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;

namespace SpringMvc.Models.Suggestions.Services.Implementation
{
    public class RecommendationForUser : IRecommendationEngine
    {

        public IEnumerable<long> GenerateRecommendation()
        {
            throw new NotImplementedException();
        }
    }
}