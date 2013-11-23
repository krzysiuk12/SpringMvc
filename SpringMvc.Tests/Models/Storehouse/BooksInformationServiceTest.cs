using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Storehouse.Services.Implementation;
using SpringMvc.Models.Storehouse.Services.Interfaces;

namespace SpringMvc.Tests.Models.Storehouse
{
    [TestClass]
    public class BooksInformationServiceTest
    {
        private IBooksInformationService bis = new BooksInformationService();
        private IStorehouseManagementService sms = new StorehouseManagementService();
        private Category category;
        private BookType bookType;
        private string CATEGORY_NAME = "Te";
        private string BOOK_NAME = "T";
        private const string BOOK_AUTHORS = "Tesa";
        [TestInitialize]
        public void TestInit()
        {
            CATEGORY_NAME += CATEGORY_NAME;
            BOOK_NAME += BOOK_NAME;
            category = new Category();
            category.Name = CATEGORY_NAME;
            bookType = new BookType();
            bookType.Category = category;
            bookType.Title = BOOK_NAME;
            bookType.Authors = BOOK_AUTHORS;
        }

        [TestMethod]
        public void TestGetAllCategories()
        {
            sms.AddCategory(CATEGORY_NAME);
            IList<Category> list = bis.GetAllCategories();
            bool isCategoryThere = false;
            foreach (var item in list)
            {
                if (item.Name.Equals(CATEGORY_NAME)) isCategoryThere = true;
                Assert.IsNotNull(item);
            }
            Assert.IsTrue(isCategoryThere);
        }
        [TestMethod]
        public void TestGetBookTypeById()
        {
            sms.SaveBookType(bookType);
            BookType book = bis.GetBookTypeById(bookType.Id);
            Assert.IsNotNull(book);
            Assert.IsTrue(book.Authors.Equals(bookType.Authors));
            Assert.IsTrue(book.Title.Equals(bookType.Title));
            Assert.IsTrue(book.Category.Name.Equals(bookType.Category.Name));
        }
        [TestMethod]
        public void TestGetAllBooks()
        {
            sms.SaveBookType(bookType);
            IEnumerable<BookType> list = bis.GetAllBooks();
            bool isBookThere = false;
            foreach (var item in list)
            {
                if (item.Id==bookType.Id) isBookThere = true;
                Assert.IsNotNull(item);
            }
            Assert.IsTrue(isBookThere);
        }
        [TestMethod]
        public void TestGetBooksByCategoryId()
        {
            sms.SaveCategory(category);
            IEnumerable<BookType> list = bis.GetBooksByCategoryId(category.Id);
            bool isBookThere = false;
            foreach (var item in list)
            {
                if (item.Id == bookType.Id) isBookThere = true;
                Assert.IsNotNull(item);
            }
            Assert.IsTrue(isBookThere);
        }
    }
}
