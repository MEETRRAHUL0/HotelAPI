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
           ,[NetBIll])
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
           ,@NetBIll)
";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("@order", order);
                cmd.Parameters.AddWithValue("@RefID", order);
                cmd.Parameters.AddWithValue("@APIKey", order);
                cmd.Parameters.AddWithValue("@OrderId", order);
                cmd.Parameters.AddWithValue("@Otp", order);
                cmd.Parameters.AddWithValue("@OrderDate", order);
                cmd.Parameters.AddWithValue("@OrderTime", order);
                cmd.Parameters.AddWithValue("@GuestName", order);
                cmd.Parameters.AddWithValue("@Phone", order);
                cmd.Parameters.AddWithValue("@ItemId", order);
                cmd.Parameters.AddWithValue("@ItemName", order);
                cmd.Parameters.AddWithValue("@GST", order);
                cmd.Parameters.AddWithValue("@Qty", order);
                cmd.Parameters.AddWithValue("@TotalBill", order);
                cmd.Parameters.AddWithValue("@Discount", order);
                cmd.Parameters.AddWithValue("@DiscountPercentage", order);
                cmd.Parameters.AddWithValue("@NetBIll", order);

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
