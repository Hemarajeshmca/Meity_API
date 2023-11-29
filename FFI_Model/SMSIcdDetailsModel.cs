using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    public class SMSIcdDetailsModel
    {
        public string InstanceName { get; set; }
        public string FROMDATE { get; set; }
        public string TODATE { get; set; }
        public string ICCODE { get; set; }
    }

    public class ICD_Invoice_Details
    {
        public List<GetIcdInvoice> InvoiceDetails { get; set; }
    }


    public class GetIcdInvoice
    {
        public string Invoice_ID { get; set; }
        public string FPO_Name { get; set; }
        public string ICDCentername { get; set; }
        public string Invoiceno { get; set; }
        public string InvoiceDate { get; set; }
        public string Product { get; set; }
        public string Quantity { get; set; }
        public string BasePrice { get; set; }
        public string Product_Amount { get; set; }
        public string Discount { get; set; }
        public string Tax { get; set; }
        public string Total_Amount { get; set; }
        public string TransportAmount { get; set; }
        public string OthersAmount { get; set; }
        public string Invoice_Amount { get; set; }


    }



    public class ICD_Payment_Details
    {
        public List<GetIcdPayment> PaymentDetails { get; set; }
    }
    public class GetIcdPayment
    {
        public string FPO_Name { get; set; }
        public string ICDCenter_name { get; set; }
        public string Invoice_No { get; set; }
        public string Date { get; set; }
        public string Invoice_Amount { get; set; }
        public string Paid_Amount { get; set; }
        public string Balance_Amount { get; set; }

    }


    public class ICD_Stock_Details
    {
        public List<GetIcdStock> StockDetails { get; set; }
    }
    public class GetIcdStock
    {
        public string InwardID { get; set; }
        public string FPOName { get; set; }
        public string CenterName { get; set; }
        public string InwardNo { get; set; }
        public string Date { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Quantity { get; set; }
        public string ProductAmount { get; set; }
        public string TaxAmount { get; set; }
        public string TransportAmount { get; set; }
        public string TotalAmount { get; set; }

    }
}
