using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Storehouse.Services.Implementation;
using SpringMvc.Models.Storehouse.Services.Interfaces;
namespace SpringMvc.Tests.Models.Storehouse
{
    [TestClass]
    public class StorehouseManagmentServiceTest
    {
        private BookType testBook;
        private string TEST_CAT_NAME;
        private int TEST_QUANTITY;
        private IBooksInformationService bis;
        private IStorehouseManagementService sms;
        [ClassInitialize]
        public void Initialize()
        {
            Category testCategory = new Category();
            testCategory.Name = TEST_CAT_NAME;
            IBooksInformationService bis = new BooksInformationService();
            IStorehouseManagementService sms = new StorehouseManagementService();
            TEST_CAT_NAME = "testowa kategoria";
            testBook = new BookType();
            testBook.Id = 47123;
            testBook.Title = "Książka testowa";
            testBook.Authors = "Autor testowy";
            testBook.Category = testCategory;
            testBook.Price = 40;
            TEST_QUANTITY = 5;
        }
        [TestMethod]
        public void TestAddCategory()
        {
            sms.AddCategory(TEST_CAT_NAME);
            IList<Category> list = bis.GetAllCategories();
            bool isInList = false;
            foreach (var item in list)
            {
                if (item.Name.Equals(TEST_CAT_NAME)) isInList = true;
            }
            Assert.IsTrue(isInList);
        }
        [TestMethod]
        public void TestSaveCategory()
        {
            Category testCategory = new Category();
            testCategory.Name = TEST_CAT_NAME;
            sms.SaveCategory(testCategory);
            IList<Category> list = bis.GetAllCategories();
            bool isInList = false;
            foreach (var item in list)
            {
                if (item.Name.Equals(TEST_CAT_NAME)) isInList = true;
            }
            Assert.IsTrue(isInList);
        }
        [TestMethod]
        public void TestAddBookType()
        {
            sms.AddBookType(testBook.Title, testBook.Authors, testBook.Price, TEST_QUANTITY, testBook.Category);
            IEnumerable<BookType> list = bis.GetAllBooks();
            bool isInList = false;
            foreach (var item in list)
            {
                if (item.Title.Equals(testBook.Title) &&
                    item.Authors.Equals(testBook.Authors) &&
                    item.Category.Name.Equals(testBook.Category.Name)) isInList = true;
            }
            Assert.IsTrue(isInList);
        }
        [TestMethod]
        public void TestSaveBookType()
        {
            sms.SaveBookType(testBook);
            IEnumerable<BookType> list = bis.GetAllBooks();
            bool isInList = false;
            foreach (var item in list)
            {
                if (item.Title.Equals(testBook.Title) &&
                    item.Authors.Equals(testBook.Authors) &&
                    item.Category.Name.Equals(testBook.Category.Name)) isInList = true;
            }
            Assert.IsTrue(isInList);
        }
    }
}
