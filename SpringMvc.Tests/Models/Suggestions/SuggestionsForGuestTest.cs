using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Suggestions.Services.Implementation;
using SpringMvc.Models.Storehouse.Services.Interfaces;
using NMock;


namespace SpringMvc.Tests.Models.Suggestions
{
    [TestClass]
    public class SuggestionsForGuestTest
    {
        private static MockFactory _factory = new MockFactory();

        [ClassInitialize]
        public static void TestsSetup(TestContext context)
        {
            var mockBookInformationService = _factory.CreateMock<IBooksInformationService>();
            BookType book = new BookType();
            List<BookType> bookList = new List<BookType>();
            for (int i = 0; i < 10; i++)
            {
                BookType tempBook = new BookType();
                tempBook.Id = 0;
            }

            mockBookInformationService.Expects.Any.Method(_ => _.GetAllBooks()).WillReturn(bookList);
            mockBookInformationService.Expects.Any.Method(_ => _.GetBooksByCategoryId(0)).WithAnyArguments().WillReturn(bookList);
            mockBookInformationService.Expects.Any.Method(_ => _.GetBookTypeById(0)).WithAnyArguments().WillReturn(book);

            //TODO!!
            //serviceLocator.BooksInformationService = mockBookInformationService
        }

        [TestInitialize]
        public void Initialize()
        {
            //TODO!!
            //AplicationScope.GlobalSuggestionCache = null
        }

        [TestCleanup]
        public void Cleanup()
        {
            _factory.VerifyAllExpectationsHaveBeenMet();
            _factory.ClearExpectations();
        }

        [TestMethod]
        public void NoCacheUpdateTest()
        {
            var mockSuggestionCache = _factory.CreateMock<SuggestionCache>();
            mockSuggestionCache.Expects.One.GetProperty(_ => _.GenerationTime).WillReturn(DateTime.Now);
            List<long> bookList = new List<long>();
            mockSuggestionCache.Expects.One.GetProperty(_ => _.BookList).WillReturn(bookList);

            //TODO!!
            //AplicationScope.GlobalSuggestionCache = mockSuggestionCache
        }

        [TestMethod]
        public void ResultQuantityTest()
        {
            IEnumerable<BookType> result = null;
            //TODO!!
            // result = suggestionService.GetSuggestionsForGuest();
            Assert.Equals(result.Count(), 5);
        }

        [TestMethod]
        public void DistinctBookTest()
        {
            IEnumerable<BookType> result = null;
            //TODO!!
            // result = suggestionService.GetSuggestionsForGuest();
            Assert.Equals(result.Count(), result.Distinct().Count());
        }
    }
}
