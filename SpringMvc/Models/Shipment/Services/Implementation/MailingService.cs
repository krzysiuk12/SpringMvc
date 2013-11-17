using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using SpringMvc.Models.Common;
using SpringMvc.Models.Shipment.Services.Interfaces;
using SpringMvc.Models.POCO;
using SpringMvc.Models.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.Security;
using System.Net;

namespace SpringMvc.Models.Shipment.Services.Implementation
{
    [Repository]
    public class MailingService : BaseSpringService, IMailingService
    {
        [Transaction]
        public Boolean SendEmail(string to, string subject, string message)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("bookshopTo@gmail.com", "Sklep Internetowy");
            msg.To.Add(new MailAddress(to));
            msg.Subject = subject;
            msg.Body = message;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("bookshopto2@gmail.com", "bookshop");
            smtp.EnableSsl = true;
            smtp.Port = 587;

            Boolean result = true;
            try
            {
                smtp.Send(msg);
            }
            catch
            {
                result = false;
            }

            return result;
        }

    }
}