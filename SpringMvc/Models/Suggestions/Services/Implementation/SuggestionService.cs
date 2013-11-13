using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using SpringMvc.Models.Common;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Suggestions.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.Suggestions.Services.Implementation
{
    [Repository]
    public class SuggestionService : BaseSpringService, ISuggestionService
    {
        [Transaction(ReadOnly = true)]
        public IEnumerable<BookType> GetSuggestionsForUser(long userID)
        {
            throw new NotImplementedException();
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<BookType> GetSuggestionsForUser(long userID, string category)
        {
            throw new NotImplementedException();
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<BookType> GetSuggestionsForGuest()
        {
            throw new NotImplementedException();
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<BookType> GetSuggestionsForGuest(string category)
        {
            throw new NotImplementedException();
        }
    }
}