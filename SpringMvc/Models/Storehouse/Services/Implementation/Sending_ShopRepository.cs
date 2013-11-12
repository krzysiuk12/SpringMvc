using SpringMvc.Models.Common;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Warehouse.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.Warehouse.Services.Implementation
{
    public class Sending_ShopRepository //: ISending_ShopRepository, BaseSpringService
    {

        //public bool MarkSold(long id, int quantity)
        //{
        //    using (var isession = NHibernateHelper.OpenSession())
        //    {
        //        using (var transaction = isession.BeginTransaction())
        //        {

        //            var result = isession.QueryOver<BookType>().Where(x => x.Id == id).SingleOrDefault();
        //            var detailsResult = isession.QueryOver<BookTypeDetails>().Where(x => x.Id == id).SingleOrDefault();
        //            if (result == null)
        //            {
        //                Console.WriteLine("Given BookTypeId does not exist");
        //                return false;
        //            }
        //            else if (detailsResult.Quantity - quantity < 0)
        //            {
        //                Console.WriteLine("There is not enough quantity in storehouse");
        //                return false;
        //            }
        //            else
        //            {
        //                detailsResult.Quantity -= quantity;
        //                isession.Update(detailsResult);
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