using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpringMvc.Models.POCO;

namespace SpringMvc.Models.Suggestions.Services.Interfaces
{
    public interface ISuggestionService
    {
        IEnumerable<BookType> GetSuggestionsForUser(long userID);
        IEnumerable<BookType> GetSuggestionsForUser(long userID, long categoryID);

        IEnumerable<BookType> GetSuggestionsForGuest();
        IEnumerable<BookType> GetSuggestionsForGuest(long categoryID);
    }
}
