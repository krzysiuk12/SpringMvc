using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;

namespace SpringMvc.Models.Suggestions.Services.Implementation
{
    public class RecommendationForGuest : IRecommendationEngine
    {
        public IEnumerable<BookType> GenerateRecommendation()
        {
            throw new NotImplementedException();
        }
    }
}