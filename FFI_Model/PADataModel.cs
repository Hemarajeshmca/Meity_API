using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
   public class PADataModel
    {
        #region PA-Purchase

        public class PAPurchaseParams
        {
            public string In_FPO_Code { get; set; }
        }

        public class PAPurchaseList
        {
            public List<GetPAPurchaseList> PA_PurchaseList { get; set; }
        }

        public class GetPAPurchaseList
        {
            public string PURCHASE_NO { get; set; }
            public string PURCHASE_DATE { get; set; }
            public string FPO_NAME { get; set; }
            public string FARMER_NAME { get; set; }
            public string FARMER_CODE { get; set; }
            public string MEMBER_TYPE { get; set; }
            public string VILLAGE { get; set; }
            public string PANCHAYAT { get; set; }
            public string TALUK { get; set; }
            public string DISTRICT { get; set; }
            public string STATE { get; set; }
            public string SEASON { get; set; }
            public string CROP_NAME { get; set; }
            public string CROP_VARIETY { get; set; }
            public decimal QUANTITY_PROCURED { get; set; }
            public decimal PURCHASE_RATE { get; set; }      
            public decimal TOTAL_AMOUNT { get; set; }

        }

        #endregion

        #region PA-Sale

        public class PASaleInputParams
        {
            public string In_FPO_Code { get; set; }
            public string In_From_Date { get; set; }
            public string In_To_Date { get; set; }
        }

        public class ServiceStatus
        {
            public string Message { get; set; }
        }
        public class PASaleDetails
        {
            public List<GetPASaleList> PASALE { get; set; }
            public ServiceStatus ServiceResponse { get; set; }
        }

        public class GetPASaleList
        {
            public string SALE_NO { get; set; }
            public string SALE_DATE { get; set; }
            public string AGGREGATOR_CODE { get; set; }
            public string AGGREGATOR_NAME { get; set; }
            public string BUYER_CODE { get; set; }
            public string BUYER_NAME { get; set; }
            public decimal SALE_AMOUNT { get; set; }
            public string PAYMENT_MODE { get; set; }
            public decimal AMOUNT_PAID { get; set; }
            public decimal BALANCE_AMOUNT { get; set; }
            public List<SaleDetails> SALEDETAILS { get; set; }
        }

        public class SaleDetails
        {
            public string ITEM_NAME { get; set; }
            public string ITEM_CATEGORY { get; set; }
            public decimal QUANTITY_PROCURED { get; set; }
            public decimal SALE_RATE { get; set; }
            public string UOM { get; set; }
            public decimal CGST { get; set; }
            public decimal SGST { get; set; }
            public decimal IGST { get; set; }
            public decimal WITHOUT_TAX_AMOUNT { get; set; }
            public decimal DISCOUNT { get; set; }
            public decimal TOTAL_AMOUNT { get; set; }

        }

        #endregion
    }
}
