using SpringMvc.Models.POCO;
using SpringMvc.Models.Warehouse.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.Storehouse.Services.Implementation
{
    public class SuggestingRepository : ISuggestingRepository
    {
        public List<BookType> GetAllBooks()
        {
            List<BookType> booksList = new List<BookType>();
            using (var isession = NHibernateHelper.OpenSession())
            {
                using (var transaction = isession.BeginTransaction())
                {
                    int i = 1;
                    var result = isession.QueryOver<BookType>().Where(x => x.Id == i).SingleOrDefault();
                    while (result != null)
                    {
                        booksList.Add(result);
                        i++;
                        result = isession.QueryOver<BookType>().Where(x => x.Id == i).SingleOrDefault();
                    }
                    return booksList;
                }
            }
        }

        public List<BookType> GetBooksByCategory(string category)
        {
            List<BookType> booksList = new List<BookType>();
            using (var isession = NHibernateHelper.OpenSession())
            {
                using (var transaction = isession.BeginTransaction())
                {
                    int i = 1;
                    var result = isession.QueryOver<BookType>().Where(x => x.Id == i && x.Category == category).SingleOrDefault();
                    var resultid = isession.QueryOver<BookType>().Where(x => x.Id == i).SingleOrDefault();
                    while (resultid != null)
                    {
                        if (result != null)
                            booksList.Add(result);
                        i++;
                        result = isession.QueryOver<BookType>().Where(x => x.Id == i && x.Category == category).SingleOrDefault();
                        resultid = isession.QueryOver<BookType>().Where(x => x.Id == i).SingleOrDefault();
                    }
                    return booksList;
                }
            }
        }
    }
}