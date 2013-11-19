using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Suggestions.Services.Interfaces;
using SpringMvc.Models.Suggestions.Services.Implementation;


namespace SpringMvc.Tests.Models.Suggestions
{
    [TestClass]
    public class SuggestionsForGuestTest
    {

        private ISuggestionService suggestionService;

        [TestInitialize]
        public void Initialize()
        {
            suggestionService = new SuggestionService();
        }

        [TestMethod]
        public void ResultQuantityTest()
        {
            IEnumerable<BookType> result = suggestionService.GetSuggestionsForGuest();

            Int32 counter = 0;
            foreach (BookType book in result)
            {
                Assert.IsNotNull(book);
                counter++;
            }

            Assert.Equals(counter, 5);
        }

        [TestMethod]
        public void NoCacheUpdateTest()
        {
            List<BookType> result1 = suggestionService.GetSuggestionsForGuest().ToList();
            List<BookType> result2 = suggestionService.GetSuggestionsForGuest().ToList();

            Assert.Equals(result1.Count, result2.Count);

            foreach (BookType book in result1)
            {
                Assert.IsTrue(result2.Contains(book));
            }
        }

        [TestMethod]
        public void DistinctBookTest()
        {
            IEnumerable<BookType> result = suggestionService.GetSuggestionsForGuest();
            Assert.Equals(result.Count(), result.Distinct().Count());
        }
    }
}
