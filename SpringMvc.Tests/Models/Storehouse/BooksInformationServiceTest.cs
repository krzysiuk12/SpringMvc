using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Storehouse.Services.Implementation;
using SpringMvc.Models.Storehouse.Services.Interfaces;
using SpringMvc.Models.Storehouse.Dao.Interfaces;

namespace SpringMvc.Tests.Models.Storehouse
{
    [TestClass]
    public class BooksInformationServiceTest
    {
        private IBooksInformationService bis = new BooksInformationService();
        private IStorehouseManagementService sms = new StorehouseManagementService();
        private MockFactory _factory = new MockFactory();

        private Category category;
        private BookType bookType;
        private QuantityMap quantityMap;
        private string CATEGORY_NAME;
        private string BOOK_TITLE;
        private string BOOK_AUTHORS;
        private decimal price;
        private int quantity;
        private IList<BookType> bookTypeList;
        private IList<Category> categoryList;

        [TestInitialize]
        public void Initialize()
        {
            CATEGORY_NAME = "Przygodowa";
            BOOK_TITLE = "Robinson";
            BOOK_AUTHORS = "A I B";
            price = 100;
            quantityMap = new QuantityMap();
            quantity = 10;
            quantityMap.Quantity = quantity;
            quantityMap.Id = 1;
            category = new Category();
            category.Name = CATEGORY_NAME;
            bookType = new BookType();
            bookType.Category = category;
            bookType.Title = BOOK_TITLE;
            bookType.Image = null;
            bookType.Price = price;
            bookType.Id = 1;
            bookType.Authors = BOOK_AUTHORS;
            bookTypeList = new List<BookType>();
            categoryList = new List<Category>();


            var bookInformationMock = _factory.CreateMock<IBooksInformationDao>();
            bis.BooksInformationDao = bookInformationMock.MockObject;

            bookInformationMock.Expects.One.MethodWith<BookType>(x => x.GetBookTypeById(-1)).WillReturn(null);
            bookInformationMock.Expects.One.MethodWith<BookType>(x => x.GetBookTypeById(bookType.Id)).WillReturn(bookType);
            bookInformationMock.Expects.One.MethodWith<IEnumerable<BookType>>(x => x.GetAllBooks())
                .WillReturn(bookTypeList);
            bookInformationMock.Expects.One.MethodWith<IList<Category>>(x => x.GetAllCategories())
                .WillReturn(categoryList);
            bookInformationMock.Expects.One.MethodWith<IEnumerable<BookType>>(x => x.GetBooksByCategoryId(category.Id))
                .WillReturn(bookTypeList);
            bookInformationMock.Expects.One.MethodWith<IEnumerable<BookType>>(x => x.GetBooksByCategoryId(-1))
                .WillReturn(null);


            var storehouseManagementMock = _factory.CreateMock<IStorehouseManagementDao>();
            sms.StorehouseManagementDao = storehouseManagementMock.MockObject;

            NMock.Actions.InvokeAction saveBookTypeAction = new NMock.Actions.InvokeAction(
            new Action(() => bookTypeList.Add(bookType)));

            storehouseManagementMock.Expects.Any.MethodWith(x => x.SaveBookType(bookType)).Will(saveBookTypeAction);

            NMock.Actions.InvokeAction saveCategoryAction = new NMock.Actions.InvokeAction(
            new Action(() => categoryList.Add(category)));

            storehouseManagementMock.Expects.Any.MethodWith(x => x.SaveCategory(category)).Will(saveCategoryAction);

        }
        [ClassInitialize]
        public static void Class_Initialize(TestContext context)
        {

        }
        [TestMethod]
        public void TestGetBookTypeByWrongId()
        {
            BookType book = bis.GetBookTypeById(-1);
            Assert.IsNull(book);
        }

        [TestMethod]
        public void TestGetBookTypeById()
        {
            sms.SaveBookType(bookType);
            BookType book = bis.GetBookTypeById(bookType.Id);
            Assert.IsNotNull(book);
            Assert.AreEqual(book, bookType);
        }

        [TestMethod]
        public void TestGetAllBooksEmpty()
        {
            IEnumerable<BookType> list = bis.GetAllBooks();
            foreach (var item in list)
            {
                Assert.IsNull(item);
            }
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void TestGetAllCategories()
        {
            sms.SaveCategory(category);
            IList<Category> list = bis.GetAllCategories();
            bool isCategoryThere = false;
            foreach (var item in list)
            {
                if (item.Equals(category)) isCategoryThere = true;
                Assert.IsNotNull(item);
            }
            Assert.IsTrue(isCategoryThere);
        }

        [TestMethod]
        public void TestGetAllCategoriesEmpty()
        {
            IList<Category> list = bis.GetAllCategories();
            foreach (var item in list)
            {
                Assert.IsNull(item);
            }
        }

        [TestMethod]
        public void TestGetBooksByCategoryId()
        {
            sms.SaveBookType(bookType);
            sms.SaveCategory(category);
            IEnumerable<BookType> list = bis.GetBooksByCategoryId(category.Id);
            bool isBookThere = false;
            foreach (var item in list)
            {
                if (item.Equals(bookType)) isBookThere = true;
                Assert.IsNotNull(item);
            }
            Assert.IsTrue(isBookThere);
        }

        [TestMethod]
        public void TestGetBooksByCategoryWrongId()
        {
            IEnumerable<BookType> list = bis.GetBooksByCategoryId(-1);
            Assert.IsNull(list);
        }
    }
}
