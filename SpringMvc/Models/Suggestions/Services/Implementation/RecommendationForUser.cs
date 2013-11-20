using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Common;
using SpringMvc.Models.Common.Interfaces;

namespace SpringMvc.Models.Suggestions.Services.Implementation
{
    public class RecommendationForUser : IRecommendationEngine
    {
        private IServiceLocator serviceLocator;
        private long userID;
        private Nullable<long> categoryID;

        private readonly int quantity = 5;

        public RecommendationForUser(IServiceLocator serviceLocator, long userID, Nullable<long> categoryID)
        {
            this.serviceLocator = serviceLocator;
            this.userID = userID;
            this.categoryID = categoryID;
        }

        public IEnumerable<long> GenerateRecommendation()
        {
            if (serviceLocator.OrderInformationsService.GetOrdersByUserId(userID) == null)
            {
                throw new ArgumentException("No user with that id");
            }

            List<long> resultList = new List<long>();

            if (categoryID.HasValue)
            {
                generateWithCategory(resultList, categoryID.Value);
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
            Dictionary<long, long> categoryDictionary = new Dictionary<long,long>();

            foreach(Order order in serviceLocator.OrderInformationsService.GetOrdersByUserId(userID))
            {
                foreach (OrderEntry orderEntry in order.OrderEntries)
                {
                    long category = orderEntry.BookType.Category.Id;
                    if (categoryDictionary.ContainsKey(category))
                        categoryDictionary[category]++;
                    else
                        categoryDictionary.Add(category, 1);
                }
            }

            if (categoryDictionary.Count != 0)
            {
                var popularCategory = categoryDictionary.OrderBy(x => x.Value).First();
                generateWithCategory(list, popularCategory.Key);
            }
        }

        private void generateWithCategory(List<long> list, long categoryId)
        {
            List<BookType> booksList = serviceLocator.BooksInformationService.GetBooksByCategoryId(categoryId).ToList();

            Random rnd = new Random();
            int number = Math.Min(quantity, booksList.Count);
            foreach (BookType book in booksList.OrderBy(x => rnd.Next()).Take(number))
            {
                list.Add(book.Id);
            }
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
    }
}