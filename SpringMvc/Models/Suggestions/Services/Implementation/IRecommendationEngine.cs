using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpringMvc.Models.POCO;

namespace SpringMvc.Models.Suggestions.Services.Implementation
{
    interface IRecommendationEngine
    {
        IEnumerable<BookType> GenerateRecommendation();
    }
}
