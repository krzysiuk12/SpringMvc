using System;
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

        }
    }
}
