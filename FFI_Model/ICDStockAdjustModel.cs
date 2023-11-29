using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
  public  class ICDStockAdjust_Model
    {
    }

    #region Adjus_list
    public class ICDStockAdjList
    {
        public int Out_adjustment_rowid { get; set; }
        public string Out_ic_code { get; set; }
        public string Out_ic_name { get; set; }
        public string Out_adjustment_no { get; set; }
        public string Out_adjustment_date { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
    }
    public class ICDStockAdjContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<ICDStockAdjList> List { get; set; }
        //public ICDStockAdjFilter Filter { get; set; }
        public string filterby_option { get; set; }
        public string filterby_code { get; set; }
        public string filterby_fromvalue { get; set; }
        public string filterby_tovalue { get; set; }
    }

   // public class ICDStockAdjFilter
    //{
        
   // }

    public class ICDStockAdjRootObject
    {
        public ICDStockAdjContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion

    #region FetchICDStockAdj

    public class SingleICDStockAdjHeader
    {
        public int IOU_adjustment_rowid { get; set; }
        public string In_orgn_code { get; set; }
        public string In_ic_code { get; set; }
        public string In_ic_desc { get; set; }
        public string In_adjustment_no { get; set; }
        public string In_adjustment_date { get; set; }
        public string In_status_code { get; set; }
        public string In_process_status { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class SingleICDStockAdjDetail
    {
        public int In_adjustmentdtl_rowid { get; set; }
        public string In_adjustment_no { get; set; }
        public string In_receipt_ref_doc_no { get; set; }
        public string In_ref_doc_date { get; set; }
        public string In_adjustment_type { get; set; }
        public string In_adjustment_desc { get; set; }
        public string In_product_catg_code { get; set; }
        public string In_product_catg_desc { get; set; }
        public string In_product_subcatg_code { get; set; }
        public string In_product_subcatg_desc { get; set; }
        public string In_product_code { get; set; }
        public string In_product_desc { get; set; }
        public int In_adjustment_qty { get; set; }
        public string In_uom_type { get; set; }
        public string In_uom_type_desc { get; set; }
        public string In_remarks { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public decimal In_out_qty { get; set; }
        public Decimal In_adj_amt { get; set; }

    }
    public class SingleICDStockAdjContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public SingleICDStockAdjHeader Header { get; set; }
        public IList<SingleICDStockAdjDetail> Detail { get; set; }

        public int adjustment_rowid{ get; set; }

    }
    public class SFApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class SingleICDStockAdjApplication
    {
        public SingleICDStockAdjContext context { get; set; }
        public SFApplicationException ApplicationException { get; set; }

    }

    #endregion

    #region INSUPD
    public class IUStockAHeader
    {
        public int IOU_adjustment_rowid { get; set; }
        public string In_orgn_code { get; set; }
        public string In_ic_code { get; set; }
        public string In_ic_desc { get; set; }
        public string In_adjustment_no { get; set; }
        public string In_adjustment_date { get; set; }
        public string In_status_code { get; set; }
        public string In_process_status { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class IUStockADetail
    {
        public int IOU_adjustment_rowid { get; set; }
        public int In_adjustmentdtl_rowid { get; set; }
        public string In_adjustment_no { get; set; }
        public string In_receipt_ref_doc_no { get; set; }
        public string In_ref_doc_date { get; set; }
        public string In_adjustment_type { get; set; }
        public string In_product_catg_code { get; set; }
        public string In_product_catg_desc { get; set; }
        public string In_product_subcatg_code { get; set; }
        public string In_product_subcatg_desc { get; set; }
        public string In_product_code { get; set; }
        public string In_product_desc { get; set; }
        public double In_adjustment_qty { get; set; }
        public string In_uom_type { get; set; }
        public string In_remarks { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public double In_out_qty { get; set; }
        public Decimal In_adj_amt { get; set; }
    }
    public class IUStockAContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IUStockAHeader Header { get; set; }
        public IList<IUStockADetail> Detail { get; set; }

    }
    public class IUStockADocument
    {
        public IUStockAContext context { get; set; }
        public IUApplicationException ApplicationException { get; set; }
    }
    public class IUApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class IUStockAApplication
    {
        public IUStockADocument document { get; set; }

    }
    #endregion
}
