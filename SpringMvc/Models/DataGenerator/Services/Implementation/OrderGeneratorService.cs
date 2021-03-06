﻿using SpringMvc.Models.DataGenerator.Services.Interfaces;
using SpringMvc.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMvc.Models.DataGenerator.Services.Implementation
{
	public class OrderGeneratorService : IOrderGeneratorService
	{
		#region Data
		private Random random = new Random();

		private string[] orderDates = { 
										"2013-2-6", "2013-8-1", "2013-2-20", "2013-1-16", "2013-3-4", "2013-8-17", "2013-7-6", "2013-6-15", "2013-6-26", "2013-9-9", 
										"2013-8-19", "2013-9-27", "2013-3-21", "2013-9-2", "2013-5-17", "2013-3-7", "2013-6-8", "2013-9-13", "2013-7-22", "2013-9-23", 
										"2013-8-27", "2013-3-26", "2013-7-25", "2013-9-13", "2013-5-8", "2013-7-4", "2013-5-16", "2013-6-5", "2013-1-2", "2013-8-12", 
										"2013-5-20", "2013-6-3", "2013-2-6", "2013-2-21", "2013-8-14", "2013-5-13", "2013-3-4", "2013-7-25", "2013-5-21", "2013-8-5", 
										"2013-1-16", "2013-9-26", "2013-1-21", "2013-9-20", "2013-3-9", "2013-1-24", "2013-3-16", "2013-7-16", "2013-8-7", "2013-7-13", 
										"2013-1-1", "2013-7-23", "2013-1-10", "2013-5-14", "2013-4-6", "2013-1-10", "2013-6-10", "2013-3-1", "2013-8-25", "2013-5-19", 
										"2013-2-20", "2013-9-15", "2013-4-8", "2013-7-5", "2013-5-17", "2013-5-25", "2013-4-15", "2013-8-21", "2013-7-5", "2013-6-19", 
										"2013-3-12", "2013-6-8", "2013-9-23", "2013-8-6", "2013-9-9", "2013-3-5", "2013-8-23", "2013-9-16", "2013-6-19", "2013-8-13", 
										"2013-4-25", "2013-9-27", "2013-4-26", "2013-2-12", "2013-3-8", "2013-3-13", "2013-8-21", "2013-9-5", "2013-9-5", "2013-6-2", 
										"2013-5-6", "2013-1-4", "2013-5-13", "2013-7-23", "2013-9-22", "2013-1-22", "2013-3-25", "2013-6-6", "2013-8-18", "2013-5-25", 
									  };


		private int[] sentDaysToAdd = { 
										3, 5, 3, 4, 4, 4, 7, 9, 9, 5, 
										8, 8, 3, 5, 8, 3, 5, 8, 6, 7, 
										3, 5, 5, 3, 9, 7, 4, 9, 8, 9, 
										7, 5, 9, 8, 8, 5, 6, 6, 7, 9, 
										6, 7, 5, 4, 8, 7, 4, 6, 9, 6, 
										6, 7, 6, 8, 6, 7, 4, 9, 5, 8, 
										6, 9, 4, 4, 6, 8, 3, 9, 6, 3, 
										9, 3, 7, 8, 6, 5, 5, 9, 8, 5, 
										7, 5, 7, 5, 8, 6, 3, 7, 6, 6, 
										6, 6, 4, 5, 7, 9, 8, 8, 8, 8, 
									  };


		private int[] deliveryDaysToAdd = { 
											5, 5, 7, 5, 5, 4, 8, 6, 4, 9, 
											9, 6, 4, 4, 5, 5, 3, 6, 3, 9, 
											5, 9, 6, 9, 8, 6, 6, 4, 6, 4, 
											7, 5, 9, 5, 9, 3, 8, 3, 4, 3, 
											9, 6, 3, 5, 9, 3, 6, 7, 4, 5, 
											5, 4, 3, 9, 7, 6, 4, 5, 8, 6, 
											5, 6, 4, 9, 6, 4, 6, 8, 3, 5, 
											3, 3, 3, 5, 6, 5, 5, 9, 9, 4, 
											8, 6, 5, 9, 4, 3, 4, 7, 8, 8, 
											5, 8, 7, 9, 7, 5, 9, 4, 3, 6, 
										  };

		private int[] amountsOfBooks = { 
											2, 1, 2, 2, 2, 3, 3, 3, 3, 1, 
											3, 3, 1, 1, 1, 1, 2, 3, 2, 1, 
											2, 2, 1, 1, 1, 2, 3, 2, 1, 2, 
											2, 2, 2, 1, 2, 2, 1, 2, 3, 2, 
											3, 2, 2, 1, 1, 2, 2, 3, 1, 3, 
											3, 3, 2, 2, 2, 2, 3, 2, 1, 1, 
											1, 2, 1, 1, 3, 3, 3, 3, 3, 2, 
											3, 3, 2, 3, 2, 2, 3, 2, 2, 1, 
											2, 3, 1, 1, 1, 1, 3, 1, 1, 1, 
											1, 1, 3, 3, 1, 1, 2, 3, 2, 1, 
									   };


		private int[] numberOfEntries = { 
											4, 4, 3, 4, 1, 1, 1, 5, 3, 4, 
											3, 3, 4, 2, 4, 5, 3, 4, 4, 1, 
											4, 5, 4, 1, 1, 3, 3, 1, 1, 5, 
											1, 2, 1, 5, 3, 4, 1, 1, 1, 4, 
											2, 3, 5, 2, 3, 1, 4, 3, 4, 2, 
											3, 3, 1, 2, 2, 3, 5, 2, 4, 1, 
											1, 2, 1, 4, 3, 4, 1, 2, 3, 3, 
											3, 3, 4, 1, 5, 1, 5, 2, 5, 2, 
											5, 1, 3, 5, 1, 1, 3, 3, 2, 5, 
											1, 4, 1, 2, 5, 2, 2, 2, 1, 2, 
										}; 





		#endregion Data

		private List<OrderEntry> GenerateOrderEntries(List<BookType> bookTypes, Order order, int dataIndex)
		{
			List<OrderEntry> orderEntries = new List<OrderEntry>();
			for (int i = 0; i < numberOfEntries[dataIndex]; i++)
			{
				OrderEntry entry = new OrderEntry()
				{
					Amount = amountsOfBooks[dataIndex],
					BookType = bookTypes.ElementAt(random.Next(bookTypes.Count)),
				};
				entry.Price = entry.BookType.Price;
				orderEntries.Add(entry);
			}

			return orderEntries;
		}


		public List<Order> GenerateOrders(List<BookType> bookTypes, List<UserAccount> userAccounts)
		{
			List<Order> orders = new List<Order>();

			for (int index = 0; index < userAccounts.Count; index++)
			{
				DateTime orderDate = DateTime.Parse(orderDates[index]);
				DateTime sentDate = orderDate.AddDays(sentDaysToAdd[index]);
				DateTime deliveryDate = sentDate.AddDays(deliveryDaysToAdd[index]);
				for ( int orderType = 0; orderType < 3; orderType++ )
				{
					Order order = new Order()
					{
						OrderDate = orderDate,
						User = userAccounts[index],
					};

					switch ( orderType )
					{
						case 0:
							order.Status = Order.OrderState.DELIVERED;
							order.SentDate = sentDate;
							order.DeliveryDate = deliveryDate;
							break;

						case 1:
							order.Status = Order.OrderState.SENT;
							order.SentDate = sentDate;
							break;

						default:
							order.Status = Order.OrderState.ORDERED;
							break;
					}
					order.OrderEntries = GenerateOrderEntries(bookTypes, order, index);
					orders.Add(order);
				}
			}
			return orders;
		}

		public List<Invoice> GenerateInvoices(List<Order> orders, List<VatMap> vatValues)
		{
			List<Invoice> invoices = new List<Invoice>();
			foreach (Order order in orders)
			{
				Invoice invoice = new Invoice()
				{
					Order = order,
					TotalValue = 0,
					Counter = 0,
					Vat = vatValues[2]
				};
                Decimal totalValue = 0;
				foreach (OrderEntry entry in order.OrderEntries)
				{
					totalValue += entry.Amount * entry.Price;
                }
                invoice.VatPriceValue = Decimal.Multiply(totalValue, invoice.Vat.Value);
                invoice.TotalValue = totalValue + invoice.VatPriceValue;
				invoices.Add(invoice);
			}
			return invoices;
		}


	}
}