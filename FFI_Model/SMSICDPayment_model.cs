using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFI_Model
{
    public class SMSICDPayment_model    {

        public List<ICDPAYMENTHEADER> PAYMENT { get; set; }
    }
    public class  ICDPAYMENTHEADER
    {
        public string FPO_NAME { get; set; }
        public string INPUT_CENTRE_NAME { get; set; }
        public string INVOICE_NO { get; set; }
        public DateTime INVOICEDATE { get; set; }
        public decimal INVOICE_AMOUNT { get; set; }
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
        //public string Farmer_Latitude { get; set; }
        // public string Farmer_Longitude { get; set; }
        public string FARMER_PINCODE { get; set; }
        public string FARMER_ADDRESS { get; set; }
        public decimal PAID_AMOUNT { get; set; }
        public decimal BALANCE_AMOUNT { get; set; }
        public List<ICDPAYMENTDETAIL> PAYMENTDETAIL { get; set; }
    }
    public class ICDPAYMENTDETAIL
    {
        public string PAYMENT_MODE { get; set; }
        public string PAYMENT_REF_NO  { get; set; }
        public decimal PAYMENT_AMOUNT { get; set; }
        public DateTime PAYMENT_DATE { get; set; }
    }

}
