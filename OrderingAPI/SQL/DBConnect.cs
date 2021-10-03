﻿using Microsoft.Extensions.Logging;
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
        SqlConnection con1 = new SqlConnection("Data Source=.;Initial Catalog=Hotel;Integrated Security=True");
        SqlConnection con2 = new SqlConnection("Data Source=103.228.112.145;Initial Catalog=rest_pro;Persist Security Info=True;User ID=royals");
        SqlConnection conStr = new SqlConnection("Data Source=103.228.112.145;Initial Catalog=rest_pro;Persist Security Info=True;User ID=rest_Pro");


        private ILogger _logger;

        public DBConnect(ILogger logger)
        {
            _logger = logger;
        }

        public string AddOrder(OrderRelayCallBack order)
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

                cmd.Parameters.AddWithValue("@OrderDate", Helper.UnixTimeStampToDateTime(order.order.details.created).Date);
                cmd.Parameters.AddWithValue("@OrderTime", Helper.UnixTimeStampToDateTime(order.order.details.created).TimeOfDay);

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

        public List<OrderHistory> GetOrderHistory()
        {
            List<OrderHistory> res = new List<OrderHistory>();
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
