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

        private readonly int quantity = 5;

        public RecommendationForGuest(IServiceLocator serviceLocator, Nullable<long> categoryID)
        {
            this.serviceLocator = serviceLocator;
            this.categoryID = categoryID;
        }

        public IEnumerable<long> GenerateRecommendation()
        {
            List<long> resultList = new List<long>();

            if (categoryID.HasValue)
            {
                generateWithCategory(resultList);
            }
            else
            {
                generateWithoutCategory(resultList);
            }

            if (resultList.Count < quantity) fillUpWithRandom(resultList);

            return resultList;
        }

        private void generateWithoutCategory(List<long> list)
        {
            if (!isCacheValid()) updateCache();

            list = ApplicationScope.GlobalSuggestionCache.BookList.ToList();
        }

        private void generateWithCategory(List<long> list)
        {
            List<BookType> booksList = serviceLocator.BooksInformationService.GetBooksByCategoryId(categoryID.Value).ToList();
            
            Random rnd = new Random();
            int number = Math.Min(quantity, booksList.Count);
            foreach (BookType book in booksList.OrderBy(x => rnd.Next()).Take(number))
            {
                list.Add(book.Id);
            }        
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
            IEnumerable<Order> ordersInProgres = serviceLocator.OrderInformationsService.GetUndeliveredOrders();

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

            int number = Math.Min(quantity, topDictionary.Count);

            List<long> topList = new List<long>();

            foreach (var pair in topDictionary.OrderBy(i => i.Value).Take(number))
            {
                topList.Add(pair.Key);
            }

            if (number < quantity) fillUpWithRandom(topList);

            SuggestionCache newSuggestionCache = new SuggestionCache();
            newSuggestionCache.BookList = topList;
            newSuggestionCache.GenerationTime = DateTime.Now;

            ApplicationScope.GlobalSuggestionCache = newSuggestionCache;
        }

        private void fillUpWithRandom(List<long> list)
        {
            Random rnd = new Random();

            var randomBooks = serviceLocator.BooksInformationService.GetAllBooks().OrderBy(x => rnd.Next()).Take(quantity);

            foreach (BookType book in randomBooks)
            {
                if (list.Count == quantity) break;

                if (!list.Contains(book.Id)) list.Add(book.Id);
            }
        }


        public Shop.Services.Interfaces.IOrderInformationsService OrderInformationsService
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}