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
    public class PdfInvoiceBuilder : BaseSpringService, IPdfInvoiceBuilder
    {
        public void BuildInvoice(Order orderDetails)
        {
            throw new NotImplementedException();
        }

        /*protected void BuildInvoice(Order orderDetails)
        {
            BaseFont f_cb = BaseFont.CreateFont("c:\\windows\\fonts\\calibrib.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            BaseFont f_cn = BaseFont.CreateFont("c:\\windows\\fonts\\calibri.ttf", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            try {

                UserAccount userDetails = ServiceLocator.UserInformationService.GetUserAccountById(orderDetails.User.Id);

                using (System.IO.FileStream fs = new FileStream("~\\Tmp" + "\\" 
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
                        
                        // Invoice main details.
                        
                        writeText(cb, "BookStore Invoice", 350, 820, f_cb, 14);
                        writeText(cb, "Invoice Id", 350, 800, f_cb, 10);
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

                        // Invoice address
                        left_margin = 350;
                        writeText(cb, "Invoice address", left_margin, top_margin, f_cb, 10);
                        writeText(cb, "BookStore", left_margin, top_margin - 12, f_cn, 10);
                        writeText(cb, "Big Tower with Red Eye", left_margin, top_margin - 24, f_cn, 10);
                        writeText(cb, "00-666 Mordor", left_margin, top_margin - 36, f_cn, 10);
                        writeText(cb, "MiddleEarth", left_margin, top_margin - 48, f_cn, 10);

                        // NOTE! You need to call the EndText() method before we can write graphics to the document!
                        cb.EndText();
                        // Separate the header from the rows with a line
                        // Draw a line by setting the line width and position
                        cb.SetLineWidth(0f);
                        cb.MoveTo(40, 570);
                        cb.LineTo(560, 570);
                        cb.Stroke();
                        // Don't forget to call the BeginText() method when done doing graphics!
                        cb.BeginText();

                        // Before we write the lines, it's good to assign a "last position to write"
                        // variable to validate against if we need to make a page break while outputting.
                        // Change it to 510 to write to test a page break; the fourth line on a new page
                        int lastwriteposition = 100;

                        // Loop thru the rows in the rows table
                        // Start by writing out the line headers
                        top_margin = 550;
                        left_margin = 40;
                        // Line headers
                        writeText(cb, "Item", left_margin, top_margin, f_cb, 10);
                        writeText(cb, "Description", left_margin+70, top_margin, f_cb, 10);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "Qty", left_margin + 415, top_margin, 0);
                        writeText(cb, "Unit", left_margin + 420, top_margin, f_cb, 10);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, "Price", left_margin + 495, top_margin, 0);
                        writeText(cb, "Curr", left_margin+500, top_margin, f_cb, 10);

                        // First item line position starts here
                        top_margin = 538;

                        // Loop thru the table of items and set the linespacing to 12 points.
                        // Note that we use the -= operator, the coordinates goes from the bottom of the page!
                        foreach (DataRow drItem in invoice.GetInvoiceRows().Rows)
                        {
                            writeText(cb, drItem["itemId"].ToString(), left_margin, top_margin, f_cn, 10);
                            writeText(cb, drItem["itemDescription"].ToString(), left_margin + 70, top_margin, f_cn, 10);
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, drItem["invoicedQuantity"].ToString(), left_margin + 415, top_margin, 0);
                            writeText(cb, drItem["unit"].ToString(), left_margin + 420, top_margin, f_cn, 10);
                            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, drItem["price"].ToString(), left_margin + 495, top_margin, 0);
                            writeText(cb, drItem["currency"].ToString(), left_margin + 500, top_margin, f_cn, 10);

                            // This is the line spacing, if you change the font size, you might want to change this as well.
                            top_margin -= 12;

                            // Implement a page break function, checking if the write position has reached the lastwriteposition
                            if(top_margin <= lastwriteposition)
                            {
                                // We need to end the writing before we change the page
                                cb.EndText();
                                // Make the page break
                                document.NewPage();
                                // Start the writing again
                                cb.BeginText();
                                // Assign the new write location on page two!
                                // Here you might want to implement a new header function for the new page
                                top_margin = 780;
                            }
                        }

                        // Okay, write out the totals table
                        // Here you might want to do some page break scenarios, as well:
                        // Example:
                        // Calculate how many rows you are about to print and see if they fit before the lastwriteposition, 
                        // then decide how to do; write some on first page, then the rest on second page or perhaps all the 
                        // total lines after the page break.
                        // We are not doing this here, we just write them out 80 points below the last writed item row

                        top_margin -= 80;
                        left_margin = 350;

                        // First the headers
                        writeText(cb, "Invoice line totals", left_margin, top_margin, f_cb, 10);
                        writeText(cb, "Freight fee", left_margin, top_margin-12, f_cb, 10);
                        writeText(cb, "VAT amount", left_margin, top_margin-24, f_cb, 10);
                        writeText(cb, "Invoice grand total", left_margin, top_margin-48, f_cb, 10);
                        // Move right to write out the values
                        left_margin = 540;
                        // Write out the invoice currency and values in regular text
                        cb.SetFontAndSize(f_cn, 10);
                        string curr = drTotal["currency"].ToString();
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, curr, left_margin, top_margin, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, curr, left_margin, top_margin-12, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, curr, left_margin, top_margin-24, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, curr, left_margin, top_margin-48, 0);
                        left_margin = 535;
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, drTotal["invoicedAmount"].ToString(), left_margin, top_margin, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, drTotal["freightCharge"].ToString(), left_margin, top_margin - 12, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, drTotal["VAT"].ToString(), left_margin, top_margin - 24, 0);
                        cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT, drTotal["totalAmount"].ToString(), left_margin, top_margin-48, 0);

                        // End the writing of text
                        cb.EndText();

                        // Close the document, the writer and the filestream!
                        document.Close();
                        writer.Close();
                        fs.Close();

                        //lblMsg.Text = "Invoiced saved to the invoice folder. Good job!";
                    }
            }
            catch(Exception rror)
            {
            }
        }

        // This is the method writing text to the content byte
        private void writeText(PdfContentByte cb, string Text, int X, int Y, BaseFont font, int Size)
        {
            cb.SetFontAndSize(font, Size);
            cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, Text, X, Y, 0);
        }
        */
    }
}