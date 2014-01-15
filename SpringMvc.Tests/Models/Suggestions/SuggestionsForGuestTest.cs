﻿using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Suggestions.Services.Implementation;
using SpringMvc.Models.Storehouse.Services.Interfaces;
using NMock;
using SpringMvc.Models.Suggestions.Services.Interfaces;
using SpringMvc.Models.Shop.Services.Interfaces;


namespace SpringMvc.Tests.Models.Suggestions
{
    [TestClass]
    public class SuggestionsForGuestTest
    {
        private static MockFactory _factory = new MockFactory();
        private ISuggestionService suggestionService;
        private Mock<IOrderInformationsService> orderInformationServiceMock;
        private Mock<IBooksInformationService> booksInformationServiceMock;

        [ClassInitialize]
        public static void TestsSetup(TestContext context)
        {

            //TODO!!
            //serviceLocator.BooksInformationService = mockBookInformationService
        }

        [TestInitialize]
        public void Initialize()
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

            suggestionService = new SuggestionService();
            orderInformationServiceMock = _factory.CreateMock<IOrderInformationsService>();
            booksInformationServiceMock = _factory.CreateMock<IBooksInformationService>();

            suggestionService.OrderInformationService = orderInformationServiceMock.MockObject;
            suggestionService.BooksInformationService = booksInformationServiceMock.MockObject;
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
            IList<Order> orders = new List<Order>();

            IList<BookType> books = new List<BookType>();
            Category cat = new Category();
            cat.Id = 5;
            cat.Name = "Kategoria";
            for (long i = 1; i < 8; i++)
            {
                BookType bookd = new BookType();
                Order order = new Order();
                OrderEntry entry = new OrderEntry();
                order.OrderEntries = new List<OrderEntry>();
                order.SentDate = DateTime.Now;
                order.Id = 10;
                order.User = null;
                entry.Id = i;
                entry.BookType = bookd;
                order.OrderEntries.Add(entry);
                bookd.Title = "Title" + i;
                bookd.Authors = "Auotr";
                bookd.Id = i;
                bookd.Category = cat;
                booksInformationServiceMock.Expects.Any.MethodWith(x => x.GetBookTypeById(i)).WillReturn(bookd);
                booksInformationServiceMock.Expects.Any.MethodWith(x => x.GetBooksByCategoryId(5)).WillReturn(books);

                orders.Add(order);
                books.Add(bookd);
            }
            booksInformationServiceMock.Expects.Any.Method(x => x.GetAllBooks()).WillReturn(books);

            orderInformationServiceMock.Expects.Any.MethodWith(x => x.GetOrdersByUserId(1)).WillReturn(orders);
            orderInformationServiceMock.Expects.Any.Method(x => x.GetUndeliveredOrders()).WillReturn(orders.Where(x => x.Status != Order.OrderState.DELIVERED));
            IEnumerable<BookType> result = suggestionService.GetSuggestionsForGuest();

            Int32 counter = 0;
            foreach (BookType book in result)
            {
                Assert.IsNotNull(book);
                counter++;
            }

            Assert.AreEqual(counter, 5);
        }

        [TestMethod]
        public void DistinctBookTest()
        {
            IEnumerable<BookType> result = null;
            IList<Order> orders = new List<Order>();

            IList<BookType> books = new List<BookType>();
            Category cat = new Category();
            cat.Id = 5;
            cat.Name = "Kategoria";
            for (long i = 1; i < 8; i++)
            {
                BookType bookd = new BookType();
                Order order = new Order();
                OrderEntry entry = new OrderEntry();
                order.OrderEntries = new List<OrderEntry>();
                order.SentDate = DateTime.Now;
                order.Id = 10;
                order.User = null;
                entry.Id = i;
                entry.BookType = bookd;
                order.OrderEntries.Add(entry);
                bookd.Title = "Title" + i;
                bookd.Authors = "Auotr";
                bookd.Id = i;
                bookd.Category = cat;
                booksInformationServiceMock.Expects.Any.MethodWith(x => x.GetBookTypeById(i)).WillReturn(bookd);
                booksInformationServiceMock.Expects.Any.MethodWith(x => x.GetBooksByCategoryId(5)).WillReturn(books);

                orders.Add(order);
                books.Add(bookd);
            }
            booksInformationServiceMock.Expects.Any.Method(x => x.GetAllBooks()).WillReturn(books);

            orderInformationServiceMock.Expects.Any.MethodWith(x => x.GetOrdersByUserId(1)).WillReturn(orders);
            orderInformationServiceMock.Expects.Any.Method(x => x.GetUndeliveredOrders()).WillReturn(orders.Where(x => x.Status != Order.OrderState.DELIVERED));
            
            
            result = suggestionService.GetSuggestionsForGuest();
            Assert.AreEqual(result.Count(), result.Distinct().Count());
        }
    }
}
