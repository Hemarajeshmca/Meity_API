using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
   public class ICDStockInwardModel
    {
        #region GetICDStockList
        public class ICDSTList
        {
            public int Out_inward_rowid { get; set; }
            public string Out_ic_code { get; set; }
            public string Out_ic_name { get; set; }
            public string Out_grn_no { get; set; }
            public string Out_grn_date { get; set; }
            public string Out_supplier_name { get; set; }
            public string Out_supplier_location { get; set; }
            public string Out_from_state { get; set; }
            public string Out_status_code { get; set; }

        }
        public class ICDStockContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public string FilterBy_Option { get; set; }
            public string FilterBy_Code { get; set; }
            public string FilterBy_FromValue { get; set; }
            public string FilterBy_ToValue { get; set; }
            public IList<ICDSTList> List { get; set; }
        

        }

      
        public class ICDStockRootObject
        {
            public ICDStockContext context { get; set; }
            public ICDSTListApplicationException ApplicationException { get; set; }
        }
        public class ICDSTListApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }
        }

        public class ICDStockDocument
        {
            public ICDStockContext context { get; set; }
            public ApplicationException ApplicationException { get; set; }
        }
        #endregion

        #region FetchICDStock
        public class SICDStockContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public int inward_rowid { get; set; }
            public ICDStockFetchHeader Header { get; set; }
            public List<ICDStockFetchDetail> Detail { get; set; }
            public List<ICDStockFetchDetailSlno> Slno { get; set; }
            public List<ICDINFetchDetailOtherCost> OtherCostInfo { get; set; }
            public List<ICDINFetchOtherInputs> OtherInputs { get; set; }
        }
      

        public class SICDStockRootObject
        {
            public SICDStockContext context { get; set; }
            public ApplicationException ApplicationException { get; set; }
        }
        //Ramya Added for Discount Screen CR
        public class ICDINFetchDetailOtherCost
        {
            public string In_inwardOtherCost_rowid { get; set; }
            public int In_inwarddtl_rowid { get; set; }
            public string In_OtherCostCode { get; set; }
            public string In_OtherCostType { get; set; }
            public string In_OtherCostOn { get; set; }
            public string In_OtherCostAmount { get; set; }
            public string In_grn_no { get; set; }
            public string In_product_catg_code { get; set; }
            public string In_product_subcatg_code { get; set; }
            public string In_product_code { get; set; }
            public string In_status_code { get; set; }
            public string In_mode_flag { get; set; }
        }
        public class ICDINFetchOtherInputs
        {
            public string In_inwardOtherinput_rowid { get; set; }
            public int In_inwarddtl_rowid { get; set; }
            public int In_NoOfLoosePack { get; set; }
            public int In_CartonVolume { get; set; }
            public string In_Type { get; set; }
            public string In_ManufactureDate { get; set; }
            public string In_ExpDate { get; set; }
            public string In_mode_flag { get; set; }
            public string In_grn_no { get; set; }
            public string In_product_catg_code { get; set; }
            public string In_product_subcatg_code { get; set; }
            public string In_product_code { get; set; }
            public string In_status_code { get; set; }
            public decimal In_Mrp { get; set; }
        }
        public class ICDStockFetchHeader
        {
            public int IOU_inward_rowid { get; set; }
            public string In_orgn_code { get; set; }
            public string In_ic_code { get; set; }
            public string In_ic_desc { get; set; }
            public string In_inward_code { get; set; }
            public string In_inward_desc { get; set; }
            public string In_grn_no { get; set; }
            public string In_grn_date { get; set; }
            public string In_supplier_name { get; set; }
            public string In_supplier_location { get; set; }
            public string In_from_state { get; set; }
            public string In_Remarks { get; set; }
            public string In_status_code { get; set; }
            public string In_process_status { get; set; }
            public DateTime In_row_timestamp { get; set; }
            public string In_mode_flag { get; set; }

            public string In_bill_image { get; set; }
            public Int32 In_transport_amount { get; set; }
            public Int32 In_others { get; set; }
            public Int32 In_loading_unloading_cost { get; set; }
            public Int32 In_local_transport_cost { get; set; }
            public Int32 In_local_loading_unloading_cost { get; set; }
            public Double In_roundoff { get; set; }
        }
        public class ICDStockFetchDetail
        {
            public int In_inwarddtl_rowid { get; set; }
            public string In_inward_code { get; set; }
            public string In_inward_desc { get; set; }
            public string In_grn_no { get; set; }
            public string In_product_catg_code { get; set; }
            public string In_product_catg_desc { get; set; }
            public string In_product_subcatg_code { get; set; }
            public string In_product_subcatg_desc { get; set; }
            public string In_product_code { get; set; }
            public string In_product_desc { get; set; }
            public string In_uomtype_code { get; set; }
            public string In_uomtype_desc { get; set; }
            public string In_batch_no { get; set; }
            public double In_received_qty { get; set; }
            public double In_product_amount { get; set; }
            public double In_tax_amount { get; set; }
            public double In_net_amount { get; set; }
            public double In_transport_amount { get; set; }
            public double In_discount { get; set; }
            public double In_cgst_rate { get; set; }
            public double In_sgst_rate { get; set; }
            public double In_igst_rate { get; set; }
            public double In_ugst_rate { get; set; }
            public double In_tax_rate { get; set; }
            public string In_hsn_code { get; set; }
            public string In_hsn_desc { get; set; }
            public string In_status_code { get; set; }
            public string In_status_desc { get; set; }
            public string In_mode_flag { get; set; }
            //Ramya Added
            public decimal In_Base_Price { get; set; }
            public decimal In_Non_Base_Price { get; set; }
            //Ramya End
           

            

        }
        public class ICDStockFetchDetailSlno
        {
            public int In_inwardslno_rowid { get; set; }
            public int In_inwarddtl_rowid { get; set; }

            public string In_slno { get; set; }
            public string In_no_of_bags { get; set; }
            public string In_grn_no { get; set; }
            public string In_product_catg_code { get; set; }
            public string In_product_subcatg_code { get; set; }
            public string In_product_code { get; set; }
            public string In_status_code { get; set; }
            public string In_mode_flag { get; set; }

        }
        #endregion

        #region SaveICDStock
        public class ICDStocksaveHeader
        {
            public int IOU_inward_rowid { get; set; }
            public string In_orgn_code { get; set; }
            public string In_ic_code { get; set; }
            public string In_inward_code { get; set; }
            public string In_grn_no { get; set; }
            public string In_grn_date { get; set; }
            public string In_supplier_name { get; set; }
            public string In_supplier_location { get; set; }
            public string In_from_state { get; set; }
            public string In_Remarks { get; set; }
            public string In_status_code { get; set; }
            public string In_process_status { get; set; }
            public string In_row_timestamp { get; set; }
            public string In_mode_flag { get; set; }
            public string In_bill_image { get; set; }
            public Int32 In_transport_amount { get; set; }
            public Int32 In_others { get; set; }
            public Int32 In_loading_unloading_cost { get; set; }
            public Int32 In_local_transport_cost { get; set; }
            public Int32 In_local_loading_unloading_cost { get; set; }
            public float In_roundoff { get; set; }
        }
        public class IUStocksaveDetail
        {
            public int In_inwarddtl_rowid { get; set; }
            public string In_inward_code { get; set; }
            public string In_grn_no { get; set; }
            public string In_product_catg_code { get; set; }
            public string In_product_subcatg_code { get; set; }
            public string In_product_code { get; set; }
            public string In_uomtype_code { get; set; }
            public string In_batch_no { get; set; }
            public float In_received_qty { get; set; }
            public float In_product_amount { get; set; }
            public float In_tax_amount { get; set; }
            public float In_transport_amount { get; set; }
            public float In_discount { get; set; }
            public float In_net_amount { get; set; }          
            public string In_status_code { get; set; }
            public string In_mode_flag { get; set; }
            //Ramya Added
            public decimal In_Base_Price { get; set; }
            public decimal In_Non_Base_Price { get; set; }
            public IList<ICDINSDetailSlno> Slnoinfo { get; set; }
            public IList<ICDINSDetailOtherCost> OtherCostInfo { get; set; }
            public IList<ICDINSDetailOtherInputs> OtherInputInfo { get; set; }
        }
        public class IUStocksaveContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public ICDStocksaveHeader Header { get; set; }
            public IList<IUStocksaveDetail> Detail { get; set; }

        }
        public class IUStockDocument
        {
            public IUStocksaveContext context { get; set; }

        }
        public class IUStockApplication
        {
            public IUStockDocument document { get; set; }

        }
        #endregion

        #region productfetch
        public class PDetail
        {
            public string In_ic_code { get; set; }
            public string In_productcategory { get; set; }
            public string In_productcategory_desc { get; set; }
            public string In_productsubcategory { get; set; }
            public string In_productsubcategory_desc { get; set; }
            public string In_product_code { get; set; }
            public string In_product_name { get; set; }
            public string In_uomtype_code { get; set; }
            public string In_uomtype_code_desc { get; set; }
            public double In_base_price { get; set; }
            public double In_current_qty { get; set; }

        }
        public class PInvoiceTax
        {
            public int In_invoicetax_rowid { get; set; }
            public string In_invoice_no { get; set; }
            public string In_product_code { get; set; }
            public string In_product_name { get; set; }
            public string In_hsn_code { get; set; }
            public string In_hsn_desc { get; set; }
            public double In_cgst_rate { get; set; }
            public double In_sgst_rate { get; set; }
            public double In_igst_rate { get; set; }
            public double In_ugst_rate { get; set; }
            public string In_tax_type { get; set; }
            public double In_tax_rate { get; set; }
            public double In_taxable_amount { get; set; }
            public double In_tax_amount { get; set; }
            public string In_status_code { get; set; }
            public string In_status_desc { get; set; }
            public string In_mode_flag { get; set; }

        }
        public class PContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public IList<PDetail> Detail { get; set; }
            public IList<PInvoiceTax> InvoiceTax { get; set; }
            public string FilterBy_Option { get; set; }
            public string FilterBy_Code { get; set; }
            public string FilterBy_FromValue { get; set; }
            public string FilterBy_ToValue { get; set; }

        }
        public class PApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class PApplication
        {
            public PContext context { get; set; }
            public PApplicationException ApplicationException { get; set; }

        }
        #endregion
    }


}
