using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;

namespace SpringMvc.Models.Suggestions.Services.Implementation
{
    public class SuggestionCache
    {
        public virtual DateTime GenerationTime { get; set; }
        public virtual List<long> BookList { get; set; }
    }
}