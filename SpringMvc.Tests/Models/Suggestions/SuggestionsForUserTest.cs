using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Suggestions.Services.Interfaces;
using SpringMvc.Models.Suggestions.Services.Implementation;

namespace SpringMvc.Tests.Models.Suggestions
{
    [TestClass]
    public class SuggestionsForUserTest
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
            IEnumerable<BookType> result = suggestionService.GetSuggestionsForUser(1);

            Int32 counter = 0;
            foreach (BookType book in result)
            {
                Assert.IsNotNull(book);
                counter++;
            }

            Assert.Equals(counter, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BadUserIdTest()
        {
            IEnumerable<BookType> result = suggestionService.GetSuggestionsForUser(-1);
        }


    }
}
