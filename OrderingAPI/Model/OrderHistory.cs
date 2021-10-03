using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderingAPI.Model
{
    public class OrderDetails
    {
        public string SNo { get; set; }  //	1
        public string OrderID { get; set; }  //	3983446300
        public string OrderDate { get; set; }  //	9/18/2021 11:14
        public string ResName { get; set; }  //	Royal Bakery
        public string ResID { get; set; }  //	102322
        public string Modeofpayment { get; set; }  //	Online
        public string Orderstatus { get; set; }  //	Delivered
        public string GrossRevenue { get; set; }  //	441
        public string ProDiscountShare { get; set; }  //	0
        public string CustomerCompensation { get; set; }  //	0
        public string CustomerDiscountAmount { get; set; }  //	0
        public string CommissionableAmount { get; set; }  //	420
        public string CommissionPercentage { get; set; }  //	20
        public string CommissionValue { get; set; }  //	84
        public string ConvenienceFee { get; set; }  //	8.11
        public string Piggybank { get; set; }  //	0
        public string LogisticsCharge { get; set; }  //	0
        public string PenaltyAmount { get; set; }  //	0
        public string CreditsCharge { get; set; }  //	0
        public string CancellationRefund { get; set; }  //	0
        public string TaxesonZomatofees { get; set; }  //	16.58
        public string Taxcollectedatsource { get; set; }  //	4.2
        public string TDSamount { get; set; }  //	4.2
        public string Amountreceivedincash { get; set; }  //	0
        public string Creditnoteadjustment { get; set; }  //	0
        public string Promorecoveryadjustment { get; set; }  //	0
        public string IcecreamdeductionsHyperpure { get; set; }  //	0
        public string Icecreamhandlingcharge { get; set; }  //	0
        public string Supportcostadjustment { get; set; }  //	0
        public string Totaladjustment { get; set; }  //	0
        public string Netreceivable { get; set; }  //	323.91
        public string Settlementstatus { get; set; }  //	pending
        public string Settlementdate { get; set; }  //
        public string BankUTR { get; set; }  //

    }
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
