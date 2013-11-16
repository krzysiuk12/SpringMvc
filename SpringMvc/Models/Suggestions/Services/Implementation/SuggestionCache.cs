using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;

namespace SpringMvc.Models.Suggestions.Services.Implementation
{
    public class SuggestionCache
    {
        public DateTime GenerationTime { get; set; }
        public List<long> BookList { get; set; }
    }
}