using Dapper;
using Microsoft.Extensions.Logging;
using OrderingAPI.Helpers;
using OrderingAPI.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace OrderingAPI.SQL
{
	public class DBConnect
	{
		SqlConnection conStr = new SqlConnection("Data Source=.;Initial Catalog=Hotal;Integrated Security=True");
		SqlConnection con2 = new SqlConnection("Data Source=103.228.112.145;Initial Catalog=rest_pro;Persist Security Info=True;User ID=royals");
		SqlConnection conStr1 = new SqlConnection("Data Source=103.228.112.145;Initial Catalog=rest_pro;Persist Security Info=True;User ID=rest_Pro");


		private ILogger _logger;

		public DBConnect(ILogger logger)
		{
			_logger = logger;
		}
		public string AddOrder(OrderRelayCallBack order)
		{
			conStr.Open();
			SqlTransaction objTrans = conStr.BeginTransaction();
			try
			{
				#region order
				var sqlOrder = @"INSERT INTO [dbo].[Order]
		   ([customer_phone]
		   ,[customer_address]
		   ,[customer_email]
		   ,[customer_name]
		   ,[next_state]
		   ,[store_name]
		   ,[store_longitude]
		   ,[store_merchant_ref_id]
		   ,[store_address]
		   ,[store_latitude]
		   ,[store_id]
		   ,[coupon]
		   ,[total_taxes]
		   ,[merchant_ref_id]
		   ,[order_level_total_charges]
		   ,[Order_id]
		   ,[payable_amount]
		   ,[total_external_discount]
		   ,[order_total]
		   ,[order_type]
		   ,[state]
		   ,[modified_from]
		   ,[channel]
		   ,[delivery_datetime]
		   ,[item_level_total_charges]
		   ,[item_taxes]
		   ,[modified_to]
		   ,[item_level_total_taxes]
		   ,[biz_id]
		   ,[order_state]
		   ,[instructions]
		   ,[total_charges]
		   ,[discount]
		   ,[created]
		   ,[order_level_total_taxes]
		   ,[order_subtotal]
		   ,[dash_config_auto_assign]
		   ,[dash_config_enabled],
			OrderJSON)
	 VALUES
		   (
		   @customer_phone
		   ,@customer_address
		   ,@customer_email
		   ,@customer_name
		   ,@next_state
		   ,@store_name
		   ,@store_longitude
		   ,@store_merchant_ref_id
		   ,@store_address
		   ,@store_latitude
		   ,@store_id
		   ,@coupon
		   ,@total_taxes
		   ,@merchant_ref_id
		   ,@order_level_total_charges
		   ,@Order_id
		   ,@payable_amount
		   ,@total_external_discount
		   ,@order_total
		   ,@order_type
		   ,@state
		   ,@modified_from
		   ,@channel
		   ,@delivery_datetime
		   ,@item_level_total_charges
		   ,@item_taxes
		   ,@modified_to
		   ,@item_level_total_taxes
		   ,@biz_id
		   ,@order_state
		   ,@instructions
		   ,@total_charges
		   ,@discount
		   ,@created
		   ,@order_level_total_taxes
		   ,@order_subtotal
		   ,@dash_config_auto_assign
		   ,@dash_config_enabled
			,@OrderJSON)
";
				SqlCommand cmdOrder = new SqlCommand(sqlOrder, conStr, objTrans);
				cmdOrder.CommandType = CommandType.Text;
				cmdOrder.Parameters.AddWithValue("@customer_phone", String.IsNullOrEmpty(order.customer.phone) ? DBNull.Value : order.customer.phone);
				cmdOrder.Parameters.AddWithValue("@customer_address", (order.customer.address == null) ? DBNull.Value : Newtonsoft.Json.JsonConvert.SerializeObject(order.customer.address));
				cmdOrder.Parameters.AddWithValue("@customer_email", String.IsNullOrEmpty(order.customer.email) ? DBNull.Value : order.customer.email);
				cmdOrder.Parameters.AddWithValue("@customer_name", String.IsNullOrEmpty(order.customer.name) ? DBNull.Value : order.customer.name);

				cmdOrder.Parameters.AddWithValue("@next_state", String.IsNullOrEmpty(order.order.next_state) ? DBNull.Value : order.order.next_state);

				cmdOrder.Parameters.AddWithValue("@store_name", String.IsNullOrEmpty(order.order.store.name) ? DBNull.Value : order.order.store.name);
				cmdOrder.Parameters.AddWithValue("@store_longitude", order.order.store.longitude);
				cmdOrder.Parameters.AddWithValue("@store_merchant_ref_id", String.IsNullOrEmpty(order.order.store.merchant_ref_id) ? DBNull.Value : order.order.store.merchant_ref_id);
				cmdOrder.Parameters.AddWithValue("@store_address", String.IsNullOrEmpty(order.order.store.address) ? DBNull.Value : order.order.store.address);
				cmdOrder.Parameters.AddWithValue("@store_latitude", order.order.store.latitude);
				cmdOrder.Parameters.AddWithValue("@store_id", order.order.store.id);

				cmdOrder.Parameters.AddWithValue("@coupon", String.IsNullOrEmpty(order.order.details.coupon) ? DBNull.Value : order.order.details.coupon);
				cmdOrder.Parameters.AddWithValue("@total_taxes", order.order.details.total_taxes);
				cmdOrder.Parameters.AddWithValue("@merchant_ref_id", String.IsNullOrEmpty(order.order.details.merchant_ref_id) ? DBNull.Value : order.order.details.merchant_ref_id);
				cmdOrder.Parameters.AddWithValue("@order_level_total_charges", order.order.details.order_level_total_charges);
				cmdOrder.Parameters.AddWithValue("@Order_id", order.order.details.id);
				cmdOrder.Parameters.AddWithValue("@payable_amount", order.order.details.payable_amount);
				cmdOrder.Parameters.AddWithValue("@total_external_discount", order.order.details.total_external_discount);
				cmdOrder.Parameters.AddWithValue("@order_total", order.order.details.order_total);
				cmdOrder.Parameters.AddWithValue("@order_type", String.IsNullOrEmpty(order.order.details.order_type) ? DBNull.Value : order.order.details.order_type);
				cmdOrder.Parameters.AddWithValue("@state", String.IsNullOrEmpty(order.order.details.state) ? DBNull.Value : order.order.details.state);
				cmdOrder.Parameters.AddWithValue("@modified_from", (order.order.details.modified_from == null) ? DBNull.Value : order.order.details.modified_from);
				cmdOrder.Parameters.AddWithValue("@channel", String.IsNullOrEmpty(order.order.details.channel) ? DBNull.Value : order.order.details.channel);
				cmdOrder.Parameters.AddWithValue("@delivery_datetime", order.order.details.delivery_datetime);
				cmdOrder.Parameters.AddWithValue("@item_level_total_charges", order.order.details.item_level_total_charges);
				cmdOrder.Parameters.AddWithValue("@item_taxes", order.order.details.item_taxes);
				cmdOrder.Parameters.AddWithValue("@modified_to", (order.order.details.modified_to == null) ? DBNull.Value : order.order.details.modified_to);
				cmdOrder.Parameters.AddWithValue("@item_level_total_taxes", order.order.details.item_level_total_taxes);
				cmdOrder.Parameters.AddWithValue("@biz_id", order.order.details.biz_id);
				cmdOrder.Parameters.AddWithValue("@order_state", String.IsNullOrEmpty(order.order.details.order_state) ? DBNull.Value : order.order.details.order_state);
				cmdOrder.Parameters.AddWithValue("@instructions", String.IsNullOrEmpty(order.order.details.instructions) ? DBNull.Value : order.order.details.instructions);
				cmdOrder.Parameters.AddWithValue("@total_charges", order.order.details.total_charges);
				cmdOrder.Parameters.AddWithValue("@discount", order.order.details.discount);
				cmdOrder.Parameters.AddWithValue("@created", order.order.details.created);
				cmdOrder.Parameters.AddWithValue("@order_level_total_taxes", order.order.details.item_level_total_taxes);
				cmdOrder.Parameters.AddWithValue("@order_subtotal", order.order.details.order_subtotal);

				cmdOrder.Parameters.AddWithValue("@dash_config_auto_assign", order.order.details.dash_config.auto_assign);
				cmdOrder.Parameters.AddWithValue("@dash_config_enabled", order.order.details.dash_config.enabled);

				cmdOrder.Parameters.AddWithValue("@OrderJSON", (order == null) ? DBNull.Value : Newtonsoft.Json.JsonConvert.SerializeObject(order));

				cmdOrder.ExecuteNonQuery();
				#endregion


				#region ItemfromLoop
				foreach (var item in order.order.items)
				{
					var sqlItem = @"INSERT INTO [dbo].[Items]
		   ([Order_id]
		   ,[image_url]
		   ,[total]
		   ,[title]
		   ,[total_with_tax]
		   ,[price]
		   ,[unit_weight]
		   ,[discount]
		   ,[image_landscape_url]
		   ,[food_type]
		   ,[merchant_id]
		   ,[ItemId]
		   ,[quantity])
	 VALUES
		   (
		   @Order_id,
		   @image_url,
		   @total,
		   @title,
		   @total_with_tax,
		   @price,
		   @unit_weight,
		   @discount,
		   @image_landscape_url,
		   @food_type,
		   @merchant_id,
		   @ItemId,
		   @quantity)
";
					SqlCommand cmdItem = new SqlCommand(sqlItem, conStr, objTrans);
					cmdItem.CommandType = CommandType.Text;
					cmdItem.Parameters.AddWithValue("@Order_id", order.order.details.id);
					cmdItem.Parameters.AddWithValue("@image_url", String.IsNullOrEmpty(item.image_url) ? DBNull.Value : item.image_url);
					cmdItem.Parameters.AddWithValue("@total", item.total);
					cmdItem.Parameters.AddWithValue("@title", String.IsNullOrEmpty(item.title) ? DBNull.Value : item.title);
					cmdItem.Parameters.AddWithValue("@total_with_tax", item.total_with_tax);
					cmdItem.Parameters.AddWithValue("@price", item.price);
					//cmdItem.Parameters.AddWithValue("@translations_language", item.translations.language);
					//cmdItem.Parameters.AddWithValue("@translations_title", item.translations.title);
					cmdItem.Parameters.AddWithValue("@unit_weight", item.unit_weight);
					cmdItem.Parameters.AddWithValue("@discount", item.discount);
					cmdItem.Parameters.AddWithValue("@image_landscape_url", String.IsNullOrEmpty(item.image_landscape_url) ? DBNull.Value : item.image_landscape_url);
					cmdItem.Parameters.AddWithValue("@food_type", String.IsNullOrEmpty(item.food_type) ? DBNull.Value : item.food_type);
					cmdItem.Parameters.AddWithValue("@merchant_id", String.IsNullOrEmpty(item.merchant_id) ? DBNull.Value : item.merchant_id);
					cmdItem.Parameters.AddWithValue("@ItemId", item.id);
					cmdItem.Parameters.AddWithValue("@quantity", item.quantity);

					cmdItem.ExecuteNonQuery();
				}
				#endregion

				objTrans.Commit();

				return ("Data save Successfully");
			}
			catch (Exception ex)
			{
				objTrans.Rollback();
				if (conStr.State == ConnectionState.Open)
				{
					conStr.Close();
				}
				_logger.LogError(ex.Message);
				return (ex.Message.ToString());
			}
			finally
			{
				conStr.Close();
			}
		}

		public string AddOrderDetails(OrderRelayCallBack order)
		{
			try
			{
				var sql = @"INSERT INTO [dbo].[Order]
		   ([RefID]
		   ,[APIKey]
		   ,[OrderId]
		   ,[Otp]
		   ,[OrderDate]
		   ,[OrderTime]
		   ,[GuestName]
		   ,[Phone]
		   ,[ItemId]
		   ,[ItemName]
		   ,[GST]
		   ,[Qty]
		   ,[TotalBill]
		   ,[Discount]
		   ,[DiscountPercentage]
		   ,[NetBIll]
		   ,[OrderStatus])
	 VALUES
		   (@RefID
		   ,@APIKey
		   ,@OrderId
		   ,@Otp
		   ,@OrderDate
		   ,@OrderTime
		   ,@GuestName
		   ,@Phone
		   ,@ItemId
		   ,@ItemName
		   ,@GST
		   ,@Qty
		   ,@TotalBill
		   ,@Discount
		   ,@DiscountPercentage
		   ,@NetBIll
		   ,@OrderStatus)
";
				SqlCommand cmd = new SqlCommand(sql, conStr);
				cmd.CommandType = CommandType.Text;
				//cmd.Parameters.AddWithValue("@order", order);
				cmd.Parameters.AddWithValue("@RefID", order.order.store.merchant_ref_id);
				cmd.Parameters.AddWithValue("@OrderId", order.order.details.biz_id);

				cmd.Parameters.AddWithValue("@OrderDate", Helper.UnixTimeStampToDateTime(order.order.details.created.ToString()));
				cmd.Parameters.AddWithValue("@OrderTime", Helper.UnixTimeStampToDateTime(order.order.details.created.ToString()));

				cmd.Parameters.AddWithValue("@GuestName", order.customer.name);
				cmd.Parameters.AddWithValue("@Phone", order.customer.phone);
				cmd.Parameters.AddWithValue("@GST", order.order.details.total_taxes);

				cmd.Parameters.AddWithValue("@Qty", string.Join(',', order.order.items.Select(q => q.quantity))); // need to check
				cmd.Parameters.AddWithValue("@ItemId", string.Join(',', order.order.items.Select(q => q.id))); // need to check
				cmd.Parameters.AddWithValue("@ItemName", string.Join(',', order.order.items.Select(q => q.title))); // need to check
				cmd.Parameters.AddWithValue("@OrderStatus", order.order.details.order_state);

				cmd.Parameters.AddWithValue("@TotalBill", order.order.details.order_subtotal); // need to check
				cmd.Parameters.AddWithValue("@NetBIll", order.order.details.order_subtotal); // need to check

				cmd.Parameters.AddWithValue("@Discount", order.order.details.discount);

				cmd.Parameters.AddWithValue("@DiscountPercentage", "");
				cmd.Parameters.AddWithValue("@APIKey", "");
				cmd.Parameters.AddWithValue("@Otp", "");

				conStr.Open();
				cmd.ExecuteNonQuery();
				conStr.Close();
				return ("Data save Successfully");
			}
			catch (Exception ex)
			{
				if (conStr.State == ConnectionState.Open)
				{
					conStr.Close();
				}
				return (ex.Message.ToString());
			}
		}
		public List<Orders> GetOrderHistoryDapper121()
		{
			string sql1 = "SELECT * FROM Invoice AS A INNER JOIN InvoiceDetail AS B ON A.InvoiceID = B.InvoiceID;";
			string sql = "select * From [dbo].[Order] As O left join [dbo].[Items] As I on O.Order_id = I.Order_id;";


			using (var connection = conStr)
			{
				connection.Open();

				var res = connection.Query<Orders, OrderItem, Orders>(
						sql,
						(order, orderItem) =>
						{
							order.Items.Add(orderItem);
							return order;
						},
						splitOn: "Order_id")
					.Distinct()
					.ToList();
				return res;
			}
		}
		public List<Orders> GetOrderHistoryDapper()
		{
			string sql = "select * From [dbo].[Order] As O left join [dbo].[Items] As I on O.Order_id = I.Order_id;";

			string sql1 = "SELECT TOP 10 * FROM Orders AS A INNER JOIN OrderDetails AS B ON A.OrderID = B.OrderID;";


			using (var connection = conStr) // new SqlConnection(FiddleHelper.GetConnectionStringSqlServerW3Schools()))
			{
				var orderDictionary = new Dictionary<string, Orders>();


				var orderList = connection.Query<Orders, OrderItem, Orders>(
					sql,
					(order, orderItem) =>
					{
						Orders orderEntry;


						if (!orderDictionary.TryGetValue(order.Order_id, out orderEntry))
						{
							orderEntry = order;
							orderEntry.Items = new List<OrderItem>();
							orderDictionary.Add(orderEntry.Order_id, order);
						}

						orderEntry.Items.Add(orderItem);
						return orderEntry;
					},
					splitOn: "Order_id")
				.Distinct()
				.ToList();

				_logger.LogInformation("Orders Count:" + orderList.Count);

				return orderList;
			}
		}
		public List<Orders> GetOrderHistory()
		{
			List<Orders> res = new List<Orders>();
			try
			{
				var sql = @"select * from [dbo].[Order]";
				using (SqlConnection con = new SqlConnection(conStr.ConnectionString))
				{
					con.Open();
					using (SqlCommand cmd = new SqlCommand(sql, con)) //"SELECT description FROM myTable WHERE ID=@ID"
					{
						//cmd.Parameters.AddWithValue("@ID", myId);
						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							while (reader.Read())
							{
								res.Add(new Orders
								{
									Items = GetOrderItem((string)reader["Order_id"]),
									next_state = (string)reader["RefID"],
									//Customer_address = (string)reader["RefID"],
									//Customer_email = (string)reader["RefID"],
									//Customer_name = (string)reader["RefID"],
									//Customer_phone = (string)reader["RefID"],
									//Store_address = (string)reader["RefID"],
									//Store_id = (string)reader["RefID"],
									//Store_latitude = (string)reader["RefID"],
									//Store_longitude = (string)reader["RefID"],
									//Store_merchant_ref_id = (string)reader["RefID"],
									//Store_name = (string)reader["RefID"],
									//biz_id = (string)reader["RefID"],
									//channel = (string)reader["RefID"],
									//coupon = (string)reader["RefID"],
									//created = (string)reader["RefID"],
									//dash_config = (string)reader["RefID"],
									//delivery_datetime = (string)reader["RefID"],
									//discount = (string)reader["RefID"],
									//total_external_discount = (string)reader["RefID"],
									//id = (string)reader["RefID"],
									//instructions = (string)reader["RefID"],
									//item_level_total_charges = (string)reader["RefID"],
									//item_level_total_taxes = (string)reader["RefID"],
									//item_taxes = (string)reader["RefID"],
									//merchant_ref_id = (string)reader["RefID"],
									//modified_from = (string)reader["RefID"],
									//modified_to = (string)reader["RefID"],
									//order_level_total_charges = (string)reader["RefID"],
									//order_level_total_taxes = (string)reader["RefID"],
									//order_state = (string)reader["RefID"],
									//order_subtotal = (string)reader["RefID"],
									//order_total = (string)reader["RefID"],
									//payable_amount = (string)reader["RefID"],
									//time_slot_end = (string)reader["RefID"],
									//time_slot_start = (string)reader["RefID"],
									//order_type = (string)reader["RefID"],
									//state = (string)reader["RefID"],
									//total_charges = (string)reader["RefID"],
									//total_taxes = (string)reader["RefID"],
								});
							}
						}
					}
				}
			}

			catch (Exception ex)
			{
				_logger.LogError($"Error: GetOrderHistory" + ex.Message.ToString());
			}
			return res;
		}

		private List<OrderItem> GetOrderItem(string v)
		{
			return null;
		}

		public List<OrderDetails> GetOrderReport()
		{
			List<OrderDetails> res = new List<OrderDetails>();
			try
			{
				var sql = @"select * from [dbo].[Order]";
				using (SqlConnection con = new SqlConnection(conStr.ConnectionString))
				{
					con.Open();
					using (SqlCommand cmd = new SqlCommand(sql, con)) //"SELECT description FROM myTable WHERE ID=@ID"
					{
						//cmd.Parameters.AddWithValue("@ID", myId);
						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							var count = 1;
							while (reader.Read())
							{
								res.Add(new OrderDetails
								{
									SNo = count.ToString(),  //	1
									OrderID = (string)reader["OrderId"],  //	3983446300
									OrderDate = (string)reader["OrderDate"],  //	9/18/2021 11:14
									ResName = (string)reader["RefID"],  //	Royal Bakery
									ResID = (string)reader["RefID"],  //	102322
									Modeofpayment = (string)reader["RefID"],  //	Online
									Orderstatus = (string)reader["RefID"],  //	Delivered
									GrossRevenue = (string)reader["RefID"],  //	441
									CommissionableAmount = (string)reader["RefID"],  //	420
									CommissionPercentage = (string)reader["RefID"],  //	20
									CommissionValue = (string)reader["RefID"],  //	84
									ConvenienceFee = (string)reader["RefID"],  //	8.11
									Netreceivable = (string)reader["RefID"],  //	323.91
									Settlementstatus = (string)reader["RefID"],  //	pending
									TaxesonZomatofees = (string)reader["RefID"],  //	16.58
									Taxcollectedatsource = (string)reader["RefID"],  //	4.2
									TDSamount = (string)reader["RefID"],  //	4.2


									CustomerCompensation = (string)reader["RefID"],  //	0
									CustomerDiscountAmount = (string)reader["RefID"],  //	0


									Piggybank = (string)reader["RefID"],  //	0
									ProDiscountShare = (string)reader["RefID"],  //	0
									LogisticsCharge = (string)reader["RefID"],  //	0
									PenaltyAmount = (string)reader["RefID"],  //	0
									CreditsCharge = (string)reader["RefID"],  //	0
									CancellationRefund = (string)reader["RefID"],  //	0
									Amountreceivedincash = (string)reader["RefID"],  //	0
									Creditnoteadjustment = (string)reader["RefID"],  //	0
									Promorecoveryadjustment = (string)reader["RefID"],  //	0
									IcecreamdeductionsHyperpure = (string)reader["RefID"],  //	0
									Icecreamhandlingcharge = (string)reader["RefID"],  //	0
									Supportcostadjustment = (string)reader["RefID"],  //	0
									Totaladjustment = (string)reader["RefID"],  //	0
									Settlementdate = (string)reader["RefID"],  //
									BankUTR = (string)reader["RefID"],  //
								});
								count++;
							}
						}
					}
				}
			}

			catch (Exception ex)
			{
				_logger.LogError($"Error: GetOrderHistory" + ex.Message.ToString());
			}
			return res;
		}

		public List<OrderHistory> GetOrderByOrderID(string OrderId)
		{
			List<OrderHistory> res = new List<OrderHistory>();
			try
			{
				var sql = @"select * from [dbo].[Order] WHERE OrderId=@OrderId";
				using (SqlConnection con = new SqlConnection(conStr.ConnectionString))
				{
					con.Open();
					using (SqlCommand cmd = new SqlCommand(sql, con)) //"SELECT description FROM myTable WHERE ID=@OrderId"
					{
						cmd.Parameters.AddWithValue("@OrderId", OrderId);
						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							while (reader.Read())
							{
								res.Add(new OrderHistory
								{
									RefID = (string)reader["RefID"],
									APIKey = (string)reader["APIKey"],
									OrderId = (string)reader["OrderId"],
									Otp = (string)reader["Otp"],
									OrderDate = (string)reader["OrderDate"],
									OrderTime = (string)reader["OrderTime"],
									GuestName = (string)reader["GuestName"],
									Phone = (string)reader["Phone"],
									ItemId = (string)reader["ItemId"],
									ItemName = (string)reader["ItemName"],
									GST = (string)reader["GST"],
									Qty = (string)reader["Qty"],
									TotalBill = (string)reader["TotalBill"],
									Discount = (string)reader["Discount"],
									DiscountPercentage = (string)reader["DiscountPercentage"],
									NetBIll = (string)reader["NetBIll"],
									OrderStatus = (string)reader["OrderStatus"]
								});
							}
						}
					}
				}
			}

			catch (Exception ex)
			{
				_logger.LogError($"Error: GetOrderHistory" + ex.Message.ToString());
			}
			return res;
		}
	}
}
