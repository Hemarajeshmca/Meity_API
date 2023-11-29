using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
  public class ICDData_Model
    {

    }

 #region ICD-ProductMaster

    public class ICDDataInputParams
    {
        public string In_FPO_Code { get; set; } 
    }

    public class ICDProductDetails
    {
        public List<GetICDProductList> ICD_Products { get; set; }
    } 
    public class GetICDProductList
    {
        public string FPO_NAME { get; set; }
        public string DISTRICT { get; set; }
        public string STATE { get; set; } 
        public string IC_CODE { get; set; }
        public string IC_NAME { get; set; } 
        public string PRODUCT_CODE { get; set; }
        public string PRODUCT_NAME { get; set; }
        public string PRODUCT_CATEGORY{ get; set; }
        public decimal BASE_PRICE{ get; set; }
        public string UOM { get; set; }
        public string DATE_EFFECTIVE_FROM { get; set; }  
    }

    #endregion

 #region ICD-Invoice

    public class ICDInvoiceInputParams
    {
        public string InstanceName { get; set; }
        public string In_FPO_Code { get; set; }
        public string In_From_Date { get; set; }
        public string In_To_Date { get; set; }
    }

    public class ServiceStatus
    {
         public string Message { get; set; }
    }
    public class ICDInvoiceDetails
    {
        public List<GetIcdInvoiceList> ICD_INVOICE { get; set; }
        public ServiceStatus ServiceResponse {get;set;}
    } 

    public class GetIcdInvoiceList
    {
        public string INVOICE_NUMBER { get; set; }
        public string INVOICE_DATE { get; set; }
        public string FARMER_NAME { get; set; }
        public string FARMER_CODE { get; set; }
        public string MEMBER_TYPE { get; set; }
        public string VILLAGE { get; set; }
        public string DISTRICT { get; set; }
        public string TALUK { get; set; }
        public string STATE { get; set; }
        public string MOBILE_NUMBER { get; set; }
        public string GENDER { get; set; }
        public string IC_CODE { get; set; }
        public string ICD_NAME { get; set; } 
        public decimal INVOICE_AMOUNT { get; set; }
        public string PAYMENT_MODE { get; set; }
        public decimal AMOUNT_PAID { get; set; }
        public decimal BALANCE_AMOUNt { get; set; }
        public List<InvoiceDetails> INVOICEDETAILS { get; set; }
    }

    public class InvoiceDetails
    {

       // public string INVOICE_NUMBER { get; set; }
        public string PRODUCT_NAME { get; set; }
        public string PRODUCT_CATEGORY { get; set; }
        public string UOM { get; set; }
        public decimal RATE { get; set; }
        public decimal QUANTITY { get; set; }
        public decimal WITHOUT_TAX_AMOUNT { get; set; }
        public decimal CGST { get; set; }
        public decimal SGST { get; set; }
        public decimal IGST { get; set; }
        public decimal DISCOUNT { get; set; }
        public decimal TOTAL_AMOUNT { get; set; }

    }

    #endregion


#region ICD-SupplierMaster
    public class ICDSupplierInputParams
    {
        public string In_FPO_Code { get; set; }
    } 
    public class ICDSupplierList
    {
        public List<GetICDSupplierList> ICD_SupplierList { get; set; }
    }
    public class GetICDSupplierList
    {
        public string IC_CODE { get; set; }
        public string IC_NAME { get; set; }
        public string FPO_Name { get; set; }
        public string SUPPLIER_CODE { get; set; }
        public string SUPPLIER_NAME { get; set; }
        public string DISTRICT { get; set; }
        public string STATE { get; set; }
    }

    #endregion



#region ICD-StockTranfer

    public class ICDStockTransferParams
    {
        public string In_FPO_Code { get; set; }
        public string In_From_Date { get; set; }
        public string In_To_Date { get; set; }
    }

    public class ICDStockTransferList
    {
        public List<GetIcdStockTransferList> ICD_StockTransferList { get; set; }
        public ServiceStatus ServiceResponse { get; set; }
    }

    public class GetIcdStockTransferList
    {
        public string GRN_NO { get; set; }
        public string FPO_NAME { get; set; }
        public string IC_CODE { get; set; }
        public string IC_NAME { get; set; }
        public string GRN_DATE { get; set; }

        public string DISTRICT { get; set; }
        public string REMARKS { get; set; }
        public List<StockTransferDetails> StockTransferDetails { get; set; }
    }

    public class StockTransferDetails
    {

        // public string INVOICE_NUMBER { get; set; }
        public string ITEM { get; set; }
        public string UOM { get; set; }
        public decimal RECEIVED_STOCK { get; set; }
        public decimal ACCEPTED_STOCK { get; set; }

    }

    #endregion



#region ICD-StockInward

    public class ICDStockInwardParams
    {
        public string In_FPO_Code { get; set; }
        public string In_From_Date { get; set; }
        public string In_To_Date { get; set; }
    }

    public class ICDStockInwardList
    {
        public List<GetIcdStockInwardList> ICD_StockInwardList { get; set; }
        public ServiceStatus ServiceResponse { get; set; }
    }

    public class GetIcdStockInwardList
    {
        public string GRN_NO { get; set; }
        public string GRN_DATE { get; set; }
        public string FPO_NAME { get; set; }
        public string IC_CODE { get; set; }
        public string IC_NAME { get; set; }
        public string DISTRICT { get; set; }
        public string SUPPLIER_NAME { get; set; }
        public string SUPPLIER_LOCATION { get; set; }
        public string SUPPLIER_STATE { get; set; }
        public decimal TOTAL_TAXAMOUNT { get; set; }
        public decimal TOTAL_AMOUNT { get; set; }
        public List<StockInwardDetails> StockInwardDetails { get; set; }
    }

    public class StockInwardDetails
    {

        // public string INVOICE_NUMBER { get; set; }
        public string PRODUCT_NAME { get; set; }
        public string PRODUCT_CATEGORY { get; set; }
        public string HSN_CODE { get; set; }
        public string UOM { get; set; }
        public decimal QUANTITY_PURCHASED { get; set; }
        public decimal RATE { get; set; }
        public decimal CGST { get; set; }
        public decimal SGST { get; set; }
        public decimal IGST { get; set; }
        public decimal DISCOUNT { get; set; }
        public decimal AMOUNT { get; set; }

    }

    #endregion

 
#region ICD-stockadj
    public class ICDstockadjInputParams
    {
        public string In_FPO_Code { get; set; }
        public string In_From_Date { get; set; }
        public string In_To_Date { get; set; }
    }

    public class ICDstockadjDetails
    {
        public List<GetIcdstockadjList> ICD_STOCKADJ { get; set; }
        public ServiceStatus ServiceResponse { get; set; }
    }

    public class GetIcdstockadjList
    {
        public string ICD { get; set; }
        public string FPO { get; set; }
        public string Stock_Adjusrment_No { get; set; }
        public string District { get; set; }
        public string DATE { get; set; }

        public List<purchasedetails> purchasedetails { get; set; }
        public List<saledetails> saledetails { get; set; }
        public List<openingbaldetails> openingbaldetails { get; set; }
    }

    public class purchasedetails
    {
        public string ST { get; set; }
        public string Item { get; set; }
        public string UOM { get; set; }
        public string grnno { get; set; }
        public string supplier_name { get; set; }
        public decimal adjust_quantity { get; set; }
        public decimal revise_quantity { get; set; }
    }
    public class saledetails
    {
        public string ST { get; set; }
        public string Item { get; set; }
        public string UOM { get; set; }
        public string Invoiceno { get; set; }
        public string Farmername { get; set; }
        public decimal adjust_quantity { get; set; }
        public decimal sales_return { get; set; }
    }
    public class openingbaldetails
    {
        public string ST { get; set; }
        public string Item { get; set; }
        public string UOM { get; set; }
        public decimal adjust_quantity { get; set; }
    }

    #endregion



}
