using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Common;
using SpringMvc.Models.Common.Interfaces;

namespace SpringMvc.Models.Suggestions.Services.Implementation
{
    public class RecommendationForGuest : IRecommendationEngine
    {
        private IServiceLocator serviceLocator;
        private Nullable<long> categoryID;

        public RecommendationForGuest(IServiceLocator serviceLocator, Nullable<long> categoryID)
        {
            this.serviceLocator = serviceLocator;
            this.categoryID = categoryID;
        }

        public IEnumerable<BookType> GenerateRecommendation()
        {
            throw new NotImplementedException();
        }

        private Boolean isCacheValid()
        {
            SuggestionCache cache = ApplicationScope.GlobalSuggestionCache;

            if (cache == null)
            {
                return false;
            }

            if ((DateTime.Now - cache.GenerationTime) > new TimeSpan(1, 0, 0))
            {
                return false;
            }

            return true;
        }

        private void updateCache()
        {
            Dictionary<long, long> topDictionary = new Dictionary<long, long>();
            IEnumerable<Order> ordersInProgres = serviceLocator.OrderInformationsService.GetInProgressOrders();
            foreach (Order order in ordersInProgres)
            {
                foreach (OrderEntry orderEntity in order.OrderEntries)
                {
                    if (topDictionary.ContainsKey(orderEntity.BookType.Id))
                    {
                        topDictionary[orderEntity.BookType.Id] += orderEntity.Amount;
                    }
                    else
                    {
                        topDictionary.Add(orderEntity.BookType.Id, orderEntity.Amount);
                    }
                }
            }

            int number = 5;
            if (topDictionary.Count < 5) number = topDictionary.Count;

            List<long> topList = new List<long>();

            foreach (var pair in topDictionary.OrderBy(i => i.Value).Take(number))
            {
                topList.Add(pair.Key);
            }

            if (number < 5) fillUpWithRandom(topList);

            SuggestionCache newSuggestionCache = new SuggestionCache();
            newSuggestionCache.BookList = topList;
            newSuggestionCache.GenerationTime = DateTime.Now;

            ApplicationScope.GlobalSuggestionCache = newSuggestionCache;
        }

        private void fillUpWithRandom(List<long> list)
        {
            Random rnd = new Random();

            var randomBooks = serviceLocator.BooksInformationService.GetAllBooks().OrderBy(x => rnd.Next()).Take(5);

            foreach (BookType book in randomBooks)
            {
                if (!list.Contains(book.Id)) list.Add(book.Id);

                if (list.Count == 5) break;
            }
        }
    }
}