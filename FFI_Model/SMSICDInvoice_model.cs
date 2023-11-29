using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFI_Model
{
    public class SMSICDInvoice_model
    {
        public List<INVOICEHEADER> INVOICE { get; set; }

    }
    public class  INVOICEHEADER
    {
        public int INVOICEID { get; set; }
        public string INVOICENO { get; set; }
        public DateTime INVOICEDATE { get; set; }
        public string RECEIVER_LOCATION { get; set; }
        public string CUSOTMERTYPE { get; set; }
        public string FARMER_CODE { get; set; }
        public string FARMER_NAME { get; set; }
        public string FARMER_COUNTRY { get; set; }
        public string FARMER_STATE { get; set; }
        public string FARMER_DISTRICT { get; set; }
        public string FARMER_TALUK { get; set; }
        public string FARMER_PANCHAYAT { get; set; }
        public string FARMER_VILLAGE { get; set; }
        public string FARMER_HAMLET { get; set; }
        public string FARMERLATITUDEANDLONGITUDE { get; set; }
       // public string Farmer_Latitude { get; set; }
       // public string Farmer_Longitude { get; set; }
        public string FARMER_PINCODE { get; set; }
        public string FARMER_ADDRESS { get; set; }
        public decimal TOTALINVOICEAMOUNT { get; set; }
        public decimal BALANCEAMOUNT { get; set; }
        public string FPO_NAME { get; set; }
        public string INPUT_CENTER_NAME { get; set; }
        public string STATUS { get; set; }
        public List<INVOICEDETAILS> INVOICEDETAILS { get; set; }
    }

    public class INVOICEDETAILS
    {
        public string PRODUCT_CATEGORY { get; set; }
        public string PRODUCTSUB_CATEGORY { get; set; }
        public string PRODUCT_CODE { get; set; }
        public string PRODUCT_NAME { get; set; }
        public string HSN_CODE { get; set; }
        public string HSN_DESCRIPTION  { get; set; }
        public int QUANTITY { get; set; }
        public decimal BASEPRICE { get; set; }
        public decimal PRODUCT_AMOUNT { get; set; }
        public decimal TRANSPORTATION_AMOUNT { get; set; }
        public decimal DISCOUNT { get; set; }
        public decimal TAX { get; set; }
        public decimal GROSS_AMOUNT { get; set; }

    }
}
