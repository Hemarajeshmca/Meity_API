using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFI_Model
{
    public class SMSICDSTOCK_model
    {
        public List<STOCKHEADER> INWARD { get; set; }

    }
    public class STOCKHEADER
    {
        public int INWARDID { get; set; }
        public string GRN_NO { get; set; }
        public string SUPPLIER_NAME{ get; set; }
        public string SUPPLIER_LOCATION { get; set; }
        public string FROM_STATE { get; set; }
        public DateTime GRN_DATE { get; set; }
        public string BILL_NO { get; set; }
        public decimal TOTALINWARDAMOUNT { get; set; }
        public string TRANSPORT_COST { get; set; }
        public string LOADING_UNLOADING_COST { get; set; }
        public string LOCAL_TRANSPORT_COST { get; set; }
        public string LOCAL_LOADING_UNLOADING_COST { get; set; }
        public string INPUT_CENTRE_NAME { get; set; }
        public string FPO_NAME { get; set; }
        public string FPO_COUNTRY { get; set; }
        public string FPO_STATE { get; set; }
        public string FPO_DISTRICT { get; set; }
        public string FPO_TALUK { get; set; }
        public string FPO_PANCHAYAT { get; set; }
        public string FPO_VILLAGE { get; set; }
        //public string FPO_Hamlet { get; set; }
        //public string FPO_Latitude { get; set; }
        //public string FPO_Longitude { get; set; }
        public string FPO_PINCODE { get; set; }
        public string FPO_ADDR1 { get; set; }
        public string FPO_ADDR2 { get; set; }
        public string STATUS { get; set; }
        public List<STOCKDETAILS> INWARDDETAIL { get; set; }

    }
    public class STOCKDETAILS
    {
        public string PRODUCT_CATEGORY { get; set; }
        public string PRODUCTSUB_CATEGORY { get; set; }
        public string PRODUCT_CODE { get; set; }
        public string PRODUCT_NAME { get; set; }
        public string HSN_CODE { get; set; }
        public string HSN_DESCRIPTION { get; set; }
        public int RECEIVED_QUANTITY { get; set; }
        public decimal RATE { get; set; }
        public decimal PRODUCT_AMOUNT { get; set; }
        public decimal TRANSPORTATION_AMOUNT { get; set; }
        public decimal DISCOUNT { get; set; }
        public decimal TAX { get; set; }
        public decimal GROSS_AMOUNT  { get; set; }
    }
}
