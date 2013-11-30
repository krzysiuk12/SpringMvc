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
using System.Web.Mvc;

namespace SpringMvc.Models.Invoices.Services.Implementation
{
    public class PdfInvoiceBuilder : IPdfInvoiceBuilder
    {
        public string BuildInvoice(Order orderDetails, UserAccount userDetails, Invoice invoice)
        {
            BaseFont f_cb = BaseFont.CreateFont("c:\\windows\\fonts\\calibrib.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            BaseFont f_cn = BaseFont.CreateFont("c:\\windows\\fonts\\calibri.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            try {

                string currentDate = DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString();
                string projectPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
                string invoiceName = "Invoice_" + orderDetails.Id.ToString() + "_" + currentDate + ".pdf";
                using (System.IO.FileStream fs = new FileStream(projectPath + "\\Tmp\\" + invoiceName, FileMode.Create))
                {
                    Document document = new Document(PageSize.A4, 25, 25, 30, 1);
                    PdfWriter writer = PdfWriter.GetInstance(document, fs);

                    document.AddAuthor("BookStore");
                    document.AddTitle("Customer Invoice - order id:" + orderDetails.Id.ToString());
                    document.Open();

                    PdfContentByte cb = writer.DirectContent;
                    iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(projectPath + "\\Images\\logo.png");
                    png.ScaleAbsolute(200, 55);
                    png.SetAbsolutePosition(40, 750);
                    cb.AddImage(png);
                    cb.BeginText();
                        
                    writeText(cb, "BookStore Invoice", 350, 820, f_cb, 14);
                    writeText(cb, "Invoice Id", 350, 800, f_cb, 10);
                    writeText(cb, invoice.Id.ToString(), 420, 800, f_cn, 10);
                    writeText(cb, "Order date", 350, 788, f_cb, 10);
                    writeText(cb, orderDetails.OrderDate.ToString(), 420, 788, f_cn, 10);
                    writeText(cb, "Order Id", 350, 776, f_cb, 10);
                    writeText(cb, orderDetails.Id.ToString(), 420, 776, f_cn, 10);
                    writeText(cb, "Customer Id", 350, 764, f_cb, 10);
                    writeText(cb, orderDetails.User.Id.ToString(), 420, 764, f_cn, 10);

                    int left_margin = 40;
                    int top_margin = 720;
                    writeText(cb, "Delivery address", left_margin, top_margin, f_cb, 10);
                    writeText(cb, userDetails.PersonalData.FirstName
                        + " " + userDetails.PersonalData.LastName, left_margin, top_margin-12, f_cn, 10);
                    writeText(cb, userDetails.PersonalData.Address.Street, left_margin, top_margin-24, f_cn, 10);
                    writeText(cb, userDetails.PersonalData.Address.PostalCode 
                        + " " + userDetails.PersonalData.Address.City, left_margin, top_margin-36, f_cn, 10);
                    writeText(cb, userDetails.PersonalData.Address.Country, left_margin, top_margin-48, f_cn, 10);

                    left_margin = 350;
                    writeText(cb, "Invoice address", left_margin, top_margin, f_cb, 10);
                    writeText(cb, ApplicationScope.CompanyName, left_margin, top_margin - 12, f_cn, 10);
                    writeText(cb, ApplicationScope.CompanyStreet, left_margin, top_margin - 24, f_cn, 10);
                    writeText(cb, ApplicationScope.CompanyPostalCode + " " + ApplicationScope.CompanyCity,
                        left_margin, top_margin - 36, f_cn, 10);
                    writeText(cb, ApplicationScope.CompanyCountry, left_margin, top_margin - 48, f_cn, 10);

                    cb.EndText();
                    cb.SetLineWidth(0f);
                    cb.MoveTo(40, 620);
                    cb.LineTo(610, 620);
                    cb.Stroke();
                    cb.BeginText();
                    int lastwriteposition = 100;

                    top_margin = 600;
                    left_margin = 40;
                    writeText(cb, "Item Id", left_margin, top_margin, f_cb, 10);
                    writeText(cb, "Description", left_margin+70, top_margin, f_cb, 10);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "Qty", left_margin + 415, top_margin, 0);
                    writeText(cb, "Unit", left_margin + 420, top_margin, f_cb, 10);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "Price", left_margin + 495, top_margin, 0);
                    writeText(cb, "Curr", left_margin+500, top_margin, f_cb, 10);

                    top_margin = 588;

                    Decimal totalInvoicedPrice = 0;
                    foreach (OrderEntry entry in orderDetails.OrderEntries)
                    {
                        writeText(cb, entry.BookType.Id.ToString(), left_margin, top_margin, f_cn, 10);
                        writeText(cb, entry.BookType.Authors + ", \"" + entry.BookType.Title + "\"", left_margin + 70, top_margin, f_cn, 10);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, entry.Amount.ToString(), left_margin + 415, top_margin, 0);
                        writeText(cb, ApplicationScope.InvoiceUnit, left_margin + 420, top_margin, f_cn, 10);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, entry.Price.ToString(), left_margin + 495, top_margin, 0);
                        writeText(cb, ApplicationScope.InvoiceCurrency, left_margin + 500, top_margin, f_cn, 10);

                        totalInvoicedPrice = Decimal.Add(totalInvoicedPrice, Decimal.Multiply(entry.Price, (Decimal) entry.Amount));

                        top_margin -= 12;

                        if(top_margin <= lastwriteposition)
                        {
                            cb.EndText();
                            document.NewPage();
                            cb.BeginText();
                            top_margin = 780;
                        }
                    }
                    
                    top_margin -= 80;
                    left_margin = 350;

                    writeText(cb, "Invoice line totals", left_margin, top_margin, f_cb, 10);
                    writeText(cb, "VAT amount", left_margin, top_margin-12, f_cb, 10);
                    writeText(cb, "Invoice grand total", left_margin, top_margin-36, f_cb, 10);
                    left_margin = 540;
                    cb.SetFontAndSize(f_cn, 10);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ApplicationScope.InvoiceCurrency, left_margin, top_margin, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ApplicationScope.InvoiceCurrency, left_margin, top_margin - 12, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, ApplicationScope.InvoiceCurrency, left_margin, top_margin - 36, 0);
                    left_margin = 535;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, totalInvoicedPrice.ToString(), left_margin, top_margin, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, invoice.VatPriceValue.ToString(), left_margin, top_margin - 12, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, invoice.TotalValue.ToString(),
                        left_margin, top_margin - 36, 0);

                    cb.EndText();

                    document.Close();
                    writer.Close();
                    fs.Close();
                    return invoiceName;
                }
            }
            catch(Exception error)
            {
                System.Console.WriteLine(error.ToString());
                return null;
            }
        }

        private void writeText(PdfContentByte cb, string Text, int X, int Y, BaseFont font, int Size)
        {
            cb.SetFontAndSize(font, Size);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Text, X, Y, 0);
        }
    }
}