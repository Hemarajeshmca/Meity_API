using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class PAWHS_New_StockAdj_Model
    {
    }
    #region GetStockAdjList

    public class StockApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }
    }
    public class StockRootObject
    {
        public StockContext context { get; set; }
        public StockApplicationException ApplicationException { get; set; }
    }
    public class StockContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }
        public List<StockLIst> List { get; set; }
    }
    public class StockLIst
    {
        public int Out_adjustment_rowid { get; set; }
        public string Out_agg_code { get; set; }
        public string Out_adjustment_no { get; set; }
        public string Out_adjustment_date { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
       
    }
    #endregion
    #region Save

    public class PAWHSStock_Save_Application
    {
        public PAWHSStock_Save_Document document { get; set; }

    }
    public class PAWHSStock_Save_Document
    {
        public PAWHSStock_Save_Context context { get; set; }
        public StockApplicationException ApplicationException { get; set; }

    }
    public class PAWHSStock_Save_Context
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<PAWHSStock_Save_PODetail> QtyDetail { get; set; }      
        public PAWHSStock_Save_Header Header { get; set; }

    }
    public class PAWHSStock_Save_Header
    {

        public Int32 In_adjustment_rowid { get; set; }
        public string In_agg_code { get; set; }
        public string In_adjustment_no { get; set; }
        public string In_adjustment_date { get; set; }
        public string In_status_code { get; set; }
        public string In_process_status { get; set; }
        public string in_mode_flag { get; set; }      
        public Int32 IOU_adjustment_rowid { get; set; }
        public string IOU_adjustment_no { get; set; }
        public string IOU_ErroNo { get; set; }

    }
    public class PAWHSStock_Save_PODetail
    {
        public int IOU_adjustment_rowid { get; set; }
        public string IOU_adjustment_no { get; set; }
        public int In_adjustmentdtl_rowid { get; set; }
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
    }

    #endregion

    #region SingleFetch

    public class PAWHSStockFetchApplication
    {
        public PAWHSStock_FetchContext context { get; set; }

    }
    public class PAWHSStock_FetchContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public Int32 IOU_adjustment_rowid { get; set; }
        public string IOU_agg_code { get; set; }
        public string IOU_adjustment_no { get; set; }      
        public PAWHSStock_FetchHeader Header { get; set; }
        public IList<PAWHSStock_Fetch_QtyDetail> QtyDetail { get; set; }
     
    }
    public class PAWHSStock_FetchHeader
    {
        public int IOU_adjustment_rowid1 { get; set; }
        public string In_agg_code { get; set; }
        public string In_adjustment_no { get; set; }
        public string In_adjustment_date { get; set; }
        public string  In_status_code { get; set; }
        public string In_process_status { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }
    }
    public class PAWHSStock_Fetch_QtyDetail
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
        public string In_uom_type { get; set; }
        public string In_uom_type_desc { get; set; }
        public double In_adjustment_qty { get; set; }
        public string In_remarks { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public double In_out_qty { get; set; }
        public string In_mode_flag { get; set; }
    }

    #endregion

}
