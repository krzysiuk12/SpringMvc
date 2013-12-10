using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Storehouse.Dao.Interfaces;
using SpringMvc.Models.Storehouse.Services.Implementation;
using SpringMvc.Models.Storehouse.Services.Interfaces;
namespace SpringMvc.Tests.Models.Storehouse
{
    [TestClass]
    public class StorehouseManagmentServiceTest
    {
        private BookType testBook;
        private Category testCategory;
        private BookType testGetBook;
        private string TEST_CAT_NAME;
        private int TEST_QUANTITY;
        private int TEST_ADD_QUANTITY;
        private IBooksInformationService bis = new BooksInformationService();
        private IStorehouseManagementService sms = new StorehouseManagementService();
        private MockFactory _factory = new MockFactory();
        private IList<Category> categoryList;
        private IList<BookType> bookTypeList;

        [TestInitialize]
        public void Initialize()
        {
            TEST_QUANTITY = 5;
            TEST_ADD_QUANTITY = 4;
            TEST_CAT_NAME = "testowa kategoria";
            testCategory = new Category();
            testCategory.Id = 1;
            testCategory.Name = TEST_CAT_NAME;
            testBook = new BookType();
            testGetBook = new BookType();
            testBook.Id = 47123;
            testBook.Title = "Książka testowa";
            testBook.Authors = "Autor testowy";
            testBook.Category = testCategory;
            testBook.QuantityMap = new QuantityMap();
            testBook.QuantityMap.Quantity = TEST_QUANTITY;
            testBook.Price = 40;
            

            categoryList = new List<Category>();
            bookTypeList = new List<BookType>();

            var bookInformationMock = _factory.CreateMock<IBooksInformationDao>();
            bis.BooksInformationDao = bookInformationMock.MockObject;

            bookInformationMock.Expects.One.MethodWith<IEnumerable<BookType>>(x => x.GetAllBooks()).WillReturn(bookTypeList);
            bookInformationMock.Expects.One.MethodWith<IList<Category>>(x => x.GetAllCategories()).WillReturn(categoryList);
            bookInformationMock.Expects.One.MethodWith<BookType>(x => x.GetBookTypeById(testBook.Id)).WillReturn(testBook);
            bookInformationMock.Expects.One.MethodWith<BookType>(x => x.GetBookTypeById(testGetBook.Id)).WillReturn(testGetBook);

            var storehouseManagmentMock = _factory.CreateMock<IStorehouseManagementDao>();
            sms.StorehouseManagementDao = storehouseManagmentMock.MockObject;

            NMock.Actions.InvokeAction markSold = new NMock.Actions.InvokeAction(new Action(() => changeQuantity()));
            storehouseManagmentMock.Expects.Any.MethodWith(x => x.MarkSold(testBook.Id, testBook.QuantityMap.Quantity)).Will(markSold);
            storehouseManagmentMock.Expects.One.MethodWith<bool>(x => x.MarkSold(-1,5)).WillReturn(false);

            NMock.Actions.InvokeAction saveCategory = new NMock.Actions.InvokeAction(new Action(() => categoryList.Add(testCategory)));
            storehouseManagmentMock.Expects.Any.MethodWith(x => x.SaveCategory(testCategory)).Will(saveCategory);
            NMock.Actions.InvokeAction saveBookType = new NMock.Actions.InvokeAction(new Action(() => bookTypeList.Add(testBook)));
            storehouseManagmentMock.Expects.Any.MethodWith(x => x.SaveBookType(testBook)).Will(saveBookType);
            NMock.Actions.InvokeAction addCategory = new NMock.Actions.InvokeAction(new Action(() => categoryList.Add(testCategory)));
            storehouseManagmentMock.Expects.Any.MethodWith(x => x.AddCategory(TEST_CAT_NAME)).Will(addCategory);
            NMock.Actions.InvokeAction addBookType = new NMock.Actions.InvokeAction(new Action(() => bookTypeList.Add(testBook)));
            storehouseManagmentMock.Expects.Any.MethodWith(x => x.AddBookType(testBook.Title, testBook.Authors, testBook.Price, TEST_QUANTITY, testBook.Category)).Will(addBookType);
           // NMock.Actions.InvokeAction addQuantity = new NMock.Actions.InvokeAction(new Action(() => 

            
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
            sms.SaveCategory(testCategory);
            IList<Category> list = bis.GetAllCategories();
            bool isInList = false;
            foreach (var item in list)
            {
                if (item.Equals(testCategory)) isInList = true;
            }
            Assert.IsTrue(isInList);
        }
        [TestMethod]
        public void TestAddBookType()
        {
            sms.AddBookType(testBook.Title, testBook.Authors, testBook.Price, TEST_QUANTITY, testBook.Category, null);
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

        [TestMethod]
        public void TestMarkSoldEnough()
        {
            bool marked = false;
            sms.SaveBookType(testBook);
            marked = (sms.MarkSold(testBook.Id, testBook.QuantityMap.Quantity));
            testGetBook = bis.GetBookTypeById(testGetBook.Id);
            Assert.IsTrue(testGetBook.QuantityMap.Quantity == 0) ;
        }

        [TestMethod]
        public void TestMarkSoldTooMany()
        {
            sms.SaveBookType(testBook);
            Assert.IsFalse(sms.MarkSold(testBook.Id, testBook.QuantityMap.Quantity + 1));
        }

        [TestMethod]
        public void TestMarkSoldWrongId()
        {
            Assert.IsFalse(sms.MarkSold(-1, 5));
        }

        [TestMethod]
        public void AddQuantityWrongId()
        {
            Assert.IsFalse(sms.AddQuantity(-1, 5));
        }

        [TestMethod]
        public void AddQuantity()
        {
            bool added = false;
            sms.SaveBookType(testBook);
            added = (sms.AddQuantity(testBook.Id, TEST_ADD_QUANTITY));
            testGetBook = bis.GetBookTypeById(testBook.Id);
            Assert.IsTrue(added && testGetBook.QuantityMap.Quantity == testBook.QuantityMap.Quantity + TEST_ADD_QUANTITY);
        }
        public void changeQuantity()
        {
            foreach (var item in bookTypeList)
                if (item.Id == testBook.Id) item.QuantityMap.Quantity -= testBook.QuantityMap.Quantity;
        }
    }
    
        
}