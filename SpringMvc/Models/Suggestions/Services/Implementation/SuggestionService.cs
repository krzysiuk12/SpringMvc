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
            IRecommendationEngine engine = new RecommendationForUser(ServiceLocator, userID, null);
            IEnumerable<long> resultList = engine.GenerateRecommendation();
            return toIEnumerableBookType(resultList);
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<BookType> GetSuggestionsForUser(long userID, long categoryID)
        {
            IRecommendationEngine engine = new RecommendationForUser(ServiceLocator, userID, categoryID);
            IEnumerable<long> resultList = engine.GenerateRecommendation();
            return toIEnumerableBookType(resultList);
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<BookType> GetSuggestionsForGuest()
        {
            IRecommendationEngine engine = new RecommendationForGuest(ServiceLocator, null);
            IEnumerable<long> resultList = engine.GenerateRecommendation();
            return toIEnumerableBookType(resultList);
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<BookType> GetSuggestionsForGuest(long categoryID)
        {
            IRecommendationEngine engine = new RecommendationForGuest(ServiceLocator, categoryID);
            IEnumerable<long> resultList = engine.GenerateRecommendation();
            return toIEnumerableBookType(resultList);
        }

        private IEnumerable<BookType> toIEnumerableBookType(IEnumerable<long> list)
        {
            List<BookType> resultList = new List<BookType>();
            foreach (long bookId in list)
            {
                resultList.Add(ServiceLocator.BooksInformationService.GetBookTypeById(bookId));
            }
            return resultList;
        }
    }
}