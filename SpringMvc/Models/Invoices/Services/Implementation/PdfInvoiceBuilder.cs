using SpringMvc.Models.POCO;
using SpringMvc.Models.Common;
using SpringMvc.Models.Common.Interfaces;
using SpringMvc.Models.Invoices.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SpringMvc.Models.Invoices.Services.Implementation
{
    class PdfInvoiceBuilder : BaseSpringService, IPdfInvoiceBuilder
    {
        protected void BuildInvoice(Order orderDetails)
        {
            try {

                UserAccount userDetails = ServiceLocator.UserInformationService.GetUserAccountById(orderDetails.User.Id);

                using (System.IO.FileStream fs = new FileStream("~\\tmp" + "\\" 
                    + orderDetails.Id.ToString() + DateTime.Now.ToString() + ".pdf", FileMode.Create))
                    {
                        Document document = new Document(PageSize.A4, 25, 25, 30, 1);
                        PdfWriter writer = PdfWriter.GetInstance(document, fs);

                        document.AddAuthor("BookStore");
                        document.AddTitle("Customer Invoice - order id:" + orderDetails.Id.ToString());

                        document.Open();

                        PdfContentByte cb = writer.DirectContent;
                        //cb.AddTemplate(PdfFooter(cb, drPayee), 30, 1);

                        iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance("~\\Images\\logo.png");
                        png.ScaleAbsolute(200, 55);
                        png.SetAbsolutePosition(40, 750);
                        cb.AddImage(png);

                        cb.BeginText();
                    }
            }
            catch(Exception e)
            {
                
            }
        }

        public void BuildInvoice(Order orderDetails, UserAccount userDetails)
        {
            throw new NotImplementedException();
        }
    }
}