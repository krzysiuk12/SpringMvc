using SpringMvc.Models.POCO;
using SpringMvc.Models.Warehouse.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.Storehouse.Services.Implementation
{
    public class StorehouseRepository //: IStorehouseRepository
    {
        //public bool AddBookType(String title, String authors, string category, int price)
        //{
        //    using (var isession = NHibernateHelper.OpenSession())
        //    {
        //        using (var transaction = isession.BeginTransaction())
        //        {

        //            var result = isession.QueryOver<BookType>().Where(x => x.Title == title && x.Authors == authors && x.Category == category).SingleOrDefault();
        //            if (result == null)
        //            {
        //                var bookTypeDetails = new BookTypeDetails { Quantity = 0 };
        //                var bookType = new BookType { Title = title, Authors = authors, Price = price, BookTypeDetails = bookTypeDetails, Category = category };
        //                isession.Save(bookType);
        //                transaction.Commit();
        //                return true;
        //            }
        //            else
        //            {
        //                Console.WriteLine("Given Type Already exists");
        //                return false;
        //            }
        //        }
        //    }
        //}

        //public bool AddBooks(long id, int quantity)
        //{
        //    using (var isession = NHibernateHelper.OpenSession())
        //    {
        //        using (var transaction = isession.BeginTransaction())
        //        {

        //            var result = isession.QueryOver<BookTypeDetails>().Where(x => x.Id == id).SingleOrDefault();
        //            if (result == null)
        //            {
        //                Console.WriteLine("Given BookTypeId does not exist");
        //                return false;
        //            }
        //            else
        //            {
        //                result.Quantity += quantity;
        //                isession.Update(result);
        //                transaction.Commit();
        //                return true;
        //            }
        //        }
        //    }
        //}

        //public BookType GetBookTypeByID(long id)
        //{
        //    using (var isession = NHibernateHelper.OpenSession())
        //    {
        //        using (var transaction = isession.BeginTransaction())
        //        {

        //            var result = isession.QueryOver<BookType>().Where(x => x.Id == id).SingleOrDefault();
        //            if (result == null)
        //            {
        //                Console.WriteLine("Given BookTypeId does not exist");
        //                return null;
        //            }
        //            else
        //            {
        //                return result;
        //            }
        //        }
        //    }
        //}
    }
}