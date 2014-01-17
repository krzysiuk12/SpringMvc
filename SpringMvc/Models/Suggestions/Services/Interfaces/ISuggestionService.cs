using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Shop.Services.Interfaces;
using SpringMvc.Models.Storehouse.Services.Interfaces;
using SpringMvc.Models.Suggestions.Services.Implementation;

namespace SpringMvc.Models.Suggestions.Services.Interfaces
{
    public interface ISuggestionService
    {
       IOrderInformationsService OrderInformationService
       { 
            get; 
            set; 
        }

       SuggestionCache SuggestionCache { get; set; }

       IBooksInformationService BooksInformationService
       {
           get;
           set;
       }

        IEnumerable<BookType> GetSuggestionsForUser(long userID);
        IEnumerable<BookType> GetSuggestionsForUser(long userID, long categoryID);

        IEnumerable<BookType> GetSuggestionsForGuest();
        IEnumerable<BookType> GetSuggestionsForGuest(long categoryID);
    }
}
