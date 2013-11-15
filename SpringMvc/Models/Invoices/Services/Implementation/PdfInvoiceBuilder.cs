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
    public class PdfInvoiceBuilder : IPdfInvoiceBuilder
    {
        public void BuildInvoice(Order orderDetails, UserAccount userDetails)
        {
            BaseFont f_cb = BaseFont.CreateFont("c:\\windows\\fonts\\calibrib.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            BaseFont f_cn = BaseFont.CreateFont("c:\\windows\\fonts\\calibri.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            try {
                
                using (System.IO.FileStream fs = new FileStream("~\\Tmp" + "\\" 
                    + orderDetails.Id.ToString() + DateTime.Now.ToString() + ".pdf", FileMode.Create))
                {
                    Document document = new Document(PageSize.A4, 25, 25, 30, 1);
                    PdfWriter writer = PdfWriter.GetInstance(document, fs);

                    document.AddAuthor("BookStore");
                    document.AddTitle("Customer Invoice - order id:" + orderDetails.Id.ToString());
                    document.Open();

                    PdfContentByte cb = writer.DirectContent;
                    iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance("~\\Images\\logo.png");
                    png.ScaleAbsolute(200, 55);
                    png.SetAbsolutePosition(40, 750);
                    cb.AddImage(png);
                    cb.BeginText();
                        
                    // Invoice main details.
                    writeText(cb, "BookStore Invoice", 350, 820, f_cb, 14);
                    writeText(cb, "Invoice Id", 350, 800, f_cb, 10);
                    // Not yet implemented - method to get InvoiceId
                    //writeText(cb, InvoiceId.ToString(), 420, 800, f_cn, 10);
                    writeText(cb, "Order date", 350, 788, f_cb, 10);
                    writeText(cb, orderDetails.OrderDate.ToString(), 420, 788, f_cn, 10);
                    writeText(cb, "Customer Id", 350, 764, f_cb, 10);
                    writeText(cb, orderDetails.User.Id.ToString(), 420, 764, f_cn, 10);

                    // Delivery address details.
                    int left_margin = 40;
                    int top_margin = 720;
                    writeText(cb, "Delivery address", left_margin, top_margin, f_cb, 10);
                    writeText(cb, userDetails.PersonalData.FirstName
                        + " " + userDetails.PersonalData.LastName, left_margin, top_margin-12, f_cn, 10);
                    writeText(cb, userDetails.PersonalData.Address.Street, left_margin, top_margin-24, f_cn, 10);
                    writeText(cb, userDetails.PersonalData.Address.PostalCode 
                        + " " + userDetails.PersonalData.Address.City, left_margin, top_margin-36, f_cn, 10);
                    writeText(cb, userDetails.PersonalData.Address.Country, left_margin, top_margin-48, f_cn, 10);

                    // Fixed invoice address
                    left_margin = 350;
                    writeText(cb, "Invoice address", left_margin, top_margin, f_cb, 10);
                    writeText(cb, "BookStore", left_margin, top_margin - 12, f_cn, 10);
                    writeText(cb, "Big Tower with Red Eye 1", left_margin, top_margin - 24, f_cn, 10);
                    writeText(cb, "00-666 Mordor", left_margin, top_margin - 36, f_cn, 10);
                    writeText(cb, "MiddleEarth", left_margin, top_margin - 48, f_cn, 10);

                    cb.EndText();
                    cb.SetLineWidth(0f);
                    cb.MoveTo(40, 620);
                    cb.LineTo(610, 620);
                    cb.Stroke();
                    cb.BeginText();
                    int lastwriteposition = 100;

                    top_margin = 660;
                    left_margin = 40;
                    writeText(cb, "Item Id", left_margin, top_margin, f_cb, 10);
                    writeText(cb, "Description", left_margin+70, top_margin, f_cb, 10);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "Qty", left_margin + 415, top_margin, 0);
                    writeText(cb, "Unit", left_margin + 420, top_margin, f_cb, 10);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "Price", left_margin + 495, top_margin, 0);
                    writeText(cb, "Curr", left_margin+500, top_margin, f_cb, 10);

                    top_margin = 648;

                    Decimal totalInvoicedPrice = 0;
                    foreach (OrderEntry entry in orderDetails.OrderEntries)
                    {
                        writeText(cb, entry.BookType.Id.ToString(), left_margin, top_margin, f_cn, 10);
                        writeText(cb, entry.BookType.Authors + ", " + entry.BookType.Title, left_margin + 70, top_margin, f_cn, 10);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, entry.Amount.ToString(), left_margin + 415, top_margin, 0);
                        // Fixed unit type.
                        writeText(cb, "PCS", left_margin + 420, top_margin, f_cn, 10);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, entry.Price.ToString(), left_margin + 495, top_margin, 0);
                        // Fixed currency.
                        writeText(cb, "PLN", left_margin + 500, top_margin, f_cn, 10);

                        totalInvoicedPrice += entry.Price;

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
                    // Fixed currency.
                    string curr = "PLN";
                    // Fixed Vat*TotalInvoicedPrice
                    Decimal vatTaxValue = Decimal.Multiply(0.22m, totalInvoicedPrice);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, curr, left_margin, top_margin, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, curr, left_margin, top_margin-12, 0);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, curr, left_margin, top_margin-36, 0);
                    left_margin = 535;
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, totalInvoicedPrice.ToString(), left_margin, top_margin, 0);
                    // Fixed VAT = 22%.
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, vatTaxValue.ToString(), left_margin, top_margin - 12, 0);
                    //Fixed total amount.
                    cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, (totalInvoicedPrice + vatTaxValue).ToString(),
                        left_margin, top_margin - 36, 0);

                    cb.EndText();

                    document.Close();
                    writer.Close();
                    fs.Close();
                }
            }
            catch(Exception error)
            {
                Console.WriteLine(error.ToString());
            }
        }

        private void writeText(PdfContentByte cb, string Text, int X, int Y, BaseFont font, int Size)
        {
            cb.SetFontAndSize(font, Size);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Text, X, Y, 0);
        }
    }
}