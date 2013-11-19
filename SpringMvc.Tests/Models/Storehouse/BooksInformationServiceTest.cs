using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Storehouse.Services.Implementation;

namespace SpringMvc.Tests.Models.Storehouse
{
    [TestClass]
    public class BooksInformationServiceTest
    {
        private BooksInformationService bis = new BooksInformationService();
        [TestMethod]
        public void TestGetAllCategories()
        {
            IList<Category> list = bis.GetAllCategories();
            Assert.AreEqual(10, list.Count);
        }
        [TestMethod]
        public void TestGetBookTypeById()
        {
            BookType book = bis.GetBookTypeById(-1);
            Assert.IsNull(book);
        }
        [TestMethod]
        public void TestGetAllBooks()
        {
            IEnumerable<BookType> list = bis.GetAllBooks();
            Assert.AreEqual(100, (new LinkedList<BookType> (list)).Count);
        }
        [TestMethod]
        public void TestGetBooksByCategoryId()
        {
            IEnumerable<BookType> list = bis.GetBooksByCategoryId(-1);
            Assert.AreEqual(0, (new LinkedList<BookType>(list)).Count);
        }
    }
}
