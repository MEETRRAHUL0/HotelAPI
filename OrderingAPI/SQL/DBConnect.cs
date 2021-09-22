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
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Hotal;Integrated Security=True");
        public string AddOrder(OrderRelayCallBack order)
        {
            try
            {
                var sql = @"INSERT INTO[dbo].[Order]
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
                SqlCommand cmd = new SqlCommand(sql, con);
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

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Data save Successfully");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }
    }
}
