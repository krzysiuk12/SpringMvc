using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using SpringMvc.Models.Common;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Suggestions.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.Shop.Services.Implementation;
using SpringMvc.Models.Shop.Services.Interfaces;
using SpringMvc.Models.Storehouse.Services.Interfaces;

namespace SpringMvc.Models.Suggestions.Services.Implementation
{
    [Repository]
    public class SuggestionService : BaseSpringService, ISuggestionService
    {

        private SuggestionCache suggestionCache;
        private IOrderInformationsService orderInformationsService;
        private IBooksInformationService booksInformationService;

        public IOrderInformationsService OrderInformationService
        {
            get
            {
                if (orderInformationsService == null)
                    return ServiceLocator.OrderInformationsService;
                return orderInformationsService;
            }
            set
            {
                orderInformationsService = value;
            }
        }

        public IBooksInformationService BooksInformationService
        {
            get
            {
                if (booksInformationService == null)
                    return ServiceLocator.BooksInformationService;
                return booksInformationService;
            }
            set
            {
                booksInformationService = value;
            }
        }

        public SuggestionCache SuggestionCache
        {
            get
            {
                if (suggestionCache == null)
                    return ApplicationScope.GlobalSuggestionCache;
                return suggestionCache;
            }
            set
            {
                suggestionCache = value;
            }
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<BookType> GetSuggestionsForUser(long userID)
        {
            IRecommendationEngine engine = new RecommendationForUser(ServiceLocator, userID, null);
            engine.OrderInformationsService = this.OrderInformationService;
            engine.BooksInformationService = this.BooksInformationService;
            IEnumerable<long> resultList = engine.GenerateRecommendation();
            return toIEnumerableBookType(resultList);
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<BookType> GetSuggestionsForUser(long userID, long categoryID)
        {
            IRecommendationEngine engine = new RecommendationForUser(ServiceLocator, userID, categoryID);
            engine.OrderInformationsService = this.OrderInformationService;
            engine.BooksInformationService = this.BooksInformationService;
            IEnumerable<long> resultList = engine.GenerateRecommendation();
            return toIEnumerableBookType(resultList);
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<BookType> GetSuggestionsForGuest()
        {
            IRecommendationEngine engine = new RecommendationForGuest(ServiceLocator, null);
            engine.OrderInformationsService = this.OrderInformationService;
            engine.BooksInformationService = this.BooksInformationService;
            engine.SuggestionCache = SuggestionCache;
            IEnumerable<long> resultList = engine.GenerateRecommendation();
            return toIEnumerableBookType(resultList);
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<BookType> GetSuggestionsForGuest(long categoryID)
        {
            IRecommendationEngine engine = new RecommendationForGuest(ServiceLocator, categoryID);
            engine.OrderInformationsService = this.OrderInformationService;
            engine.BooksInformationService = this.BooksInformationService;
            engine.SuggestionCache = SuggestionCache;
            IEnumerable<long> resultList = engine.GenerateRecommendation();
            return toIEnumerableBookType(resultList);
        }

        private IEnumerable<BookType> toIEnumerableBookType(IEnumerable<long> list)
        {
            List<BookType> resultList = new List<BookType>();
            foreach (long bookId in list)
            {
                resultList.Add(BooksInformationService.GetBookTypeById(bookId));
            }
            return resultList;
        }

        
    }
}