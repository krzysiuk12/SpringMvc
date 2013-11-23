﻿using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using SpringMvc.Models.Common;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Storehouse.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.Storehouse.Services.Implementation
{
    [Repository]
    public class BooksInformationService : BaseSpringService, IBooksInformationService
    {
        IEnumerable<BookType> bookTypeCache = null;

        [Transaction(ReadOnly=true)]
        public IEnumerable<BookType> GetBooksByCategoryId(long categoryId)
        {
            return DaoFactory.BooksInformationDao.GetBooksByCategoryId(categoryId);
        }

        [Transaction(ReadOnly = true)]
        public IEnumerable<BookType> GetAllBooks()
        {
//            if (bookTypeCache == null)
//            {
                bookTypeCache = DaoFactory.BooksInformationDao.GetAllBooks();
//            }
            return bookTypeCache;
        }

        [Transaction(ReadOnly = true)]
        public BookType GetBookTypeById(long bookTypeId)
        {
            return DaoFactory.BooksInformationDao.GetBookTypeById(bookTypeId);
        }

        [Transaction(ReadOnly = true)]
        public IList<Category> GetAllCategories()
        {
            return DaoFactory.BooksInformationDao.GetAllCategories();
        }
    }
}