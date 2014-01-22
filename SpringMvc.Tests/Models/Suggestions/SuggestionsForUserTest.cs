using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Suggestions.Services.Interfaces;
using SpringMvc.Models.Suggestions.Services.Implementation;
using NMock;
using SpringMvc.Models.Shop.Services.Interfaces;
using SpringMvc.Models.Storehouse.Services.Interfaces;

namespace SpringMvc.Tests.Models.Suggestions
{
    [TestClass]
    public class SuggestionsForUserTest
    {

        
        private MockFactory _factory = new MockFactory();
        private ISuggestionService suggestionService;
        private Mock<IOrderInformationsService> orderInformationServiceMock;
        private Mock<IBooksInformationService> booksInformationServiceMock;

        [TestInitialize]
        public void Initialize()
        {
            suggestionService = new SuggestionService();
            orderInformationServiceMock = _factory.CreateMock<IOrderInformationsService>();
            booksInformationServiceMock = _factory.CreateMock<IBooksInformationService>();

            suggestionService.OrderInformationService = orderInformationServiceMock.MockObject;
            suggestionService.BooksInformationService = booksInformationServiceMock.MockObject;
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
            
            IEnumerable<BookType> result = suggestionService.GetSuggestionsForUser(1);

            Int32 counter = 0;
            foreach (BookType book in result)
            {
                Assert.IsNotNull(book);
                counter++;
            }

            Assert.AreEqual(counter, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BadUserIdTest()
        {
            
            orderInformationServiceMock.Expects.Any.MethodWith(x => x.GetOrdersByUserId(-1)).Will(Throw.Exception(new ArgumentException()));
            IEnumerable<BookType> result = suggestionService.GetSuggestionsForUser(-1);
        }


        [TestMethod]
        public void WrongCategoryIdRightUserParameterTest()
        {
            List<BookType> bookList = new List<BookType>();
            for (long i = 0; i < 10; i++)
            {
                BookType bookd = new BookType() { Id = i };
                bookList.Add(bookd);
                booksInformationServiceMock.
                    Expects.
                    Any.
                    MethodWith(x => x.GetBookTypeById(i)).WillReturn(bookd);
            }

            long wrongCategoryId = -1;

            

            booksInformationServiceMock.Expects.One.
                MethodWith(x => x.GetBooksByCategoryId(wrongCategoryId)).
                WillReturn(new List<BookType>());

            booksInformationServiceMock.Expects.One.
                MethodWith(x => x.GetAllBooks()).
                WillReturn(bookList);



            IEnumerable<BookType> result = suggestionService.GetSuggestionsForUser(0, wrongCategoryId);
            Assert.AreEqual(result.Count(), 5);
        }

        [TestMethod]
        public void RightCategoryIdRightUserParameterTest()
        {
            List<BookType> bookList = new List<BookType>();
            var rightCatlist = new List<BookType>();
            for (long i = 0; i < 10; i++)
            {
                BookType bookd = new BookType() { Id = i, Category = new Category() { Id = i } };
                bookList.Add(bookd);
                booksInformationServiceMock.
                    Expects.
                    Any.
                    MethodWith(x => x.GetBookTypeById(i)).WillReturn(bookd);
                if (i % 2 == 0) rightCatlist.Add(bookd);
            }

            long rightCategoryId = 1;

            booksInformationServiceMock.Expects.One.
                MethodWith(x => x.GetBooksByCategoryId(rightCategoryId)).
                WillReturn(rightCatlist);

            booksInformationServiceMock.Expects.One.
                MethodWith(x => x.GetAllBooks()).
                WillReturn(bookList);

            IEnumerable<BookType> result = suggestionService.GetSuggestionsForUser(0,rightCategoryId);
            Assert.AreEqual(result.Count(), rightCatlist.Count);
            foreach (var item in result)
            {
                Assert.IsTrue(rightCatlist.Contains(item));
            }
        }

        [TestMethod]
        public void WrongCategoryIdWrongUserParameterTest()
        {
            List<BookType> bookList = new List<BookType>();
            for (long i = 0; i < 10; i++)
            {
                BookType bookd = new BookType() { Id = i };
                bookList.Add(bookd);
                booksInformationServiceMock.
                    Expects.
                    Any.
                    MethodWith(x => x.GetBookTypeById(i)).WillReturn(bookd);
            }

            long wrongCategoryId = -1;

            long wrongUserId = -1;

            booksInformationServiceMock.Expects.One.
                MethodWith(x => x.GetBooksByCategoryId(wrongCategoryId)).
                WillReturn(new List<BookType>());

            booksInformationServiceMock.Expects.One.
                MethodWith(x => x.GetAllBooks()).
                WillReturn(bookList);

            orderInformationServiceMock.Expects.Any.
                MethodWith(x => x.GetOrdersByUserId(wrongUserId)).
                WillReturn(new List<Order>());

            IEnumerable<BookType> result = suggestionService.GetSuggestionsForUser(wrongUserId, wrongCategoryId);
            Assert.AreEqual(result.Count(), 5);
        }

        [TestMethod]
        public void RightCategoryIdWrongUserParameterTest()
        {
            List<BookType> bookList = new List<BookType>();
            var rightCatlist = new List<BookType>();
            for (long i = 0; i < 10; i++)
            {
                BookType bookd = new BookType() { Id = i, Category = new Category() { Id = i%2 } };
                booksInformationServiceMock.
                    Expects.
                    Any.
                    MethodWith(x => x.GetBookTypeById(i)).WillReturn(bookd);
                if (i % 2 == 0) rightCatlist.Add(bookd);
            }

            long rightCategoryId = 1;

            long wrongUserId = -1;

            booksInformationServiceMock.Expects.One.
                MethodWith(x => x.GetBooksByCategoryId(rightCategoryId)).
                WillReturn(rightCatlist);

            booksInformationServiceMock.Expects.One.
                MethodWith(x => x.GetAllBooks()).
                WillReturn(bookList);

            orderInformationServiceMock.Expects.Any.
                MethodWith(x => x.GetOrdersByUserId(wrongUserId)).
                WillReturn(new List<Order>());

            IEnumerable<BookType> result = suggestionService.GetSuggestionsForUser(wrongUserId, rightCategoryId);
            Assert.AreEqual(result.Count(), 5);
            foreach (var item in result)
            {
                Assert.IsTrue(rightCatlist.Contains(item));
            }

        }

    }
}
