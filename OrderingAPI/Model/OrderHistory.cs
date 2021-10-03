using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingAPI.Model
{
    public class OrderHistory
    {
        public string RefID { get; set; }
           public string APIKey { get; set; }
           public string OrderId { get; set; }
           public string Otp { get; set; }
           public string OrderDate { get; set; }
           public string OrderTime { get; set; }
           public string GuestName { get; set; }
           public string Phone { get; set; }
           public string ItemId { get; set; }
           public string ItemName { get; set; }
           public string GST { get; set; }
           public string Qty { get; set; }
           public string TotalBill { get; set; }
           public string Discount { get; set; }
           public string DiscountPercentage { get; set; }
           public string NetBIll { get; set; }
           public string OrderStatus { get; set; }
    }
}
