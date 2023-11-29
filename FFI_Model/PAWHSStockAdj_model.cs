using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class PAWHSStockAdj_model
    {
    }
    #region  list 

    public class PAWHSStockAdjList
    {
        public int Out_adjustment_rowid { get; set; }
        public string Out_adjustment_no { get; set; }
        public string Out_adjustment_date { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }

    }
    public class PAWHSStockAdjContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public string filterby_option { get; set; }
        public string filterby_code { get; set; }
        public string filterby_fromvalue { get; set; }
        public string filterby_tovalue { get; set; }
        public IList<PAWHSStockAdjList> List { get; set; }

    }
    public class PAWHSStockAdjApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSStockAdjApplication
    {
        public PAWHSStockAdjContext context { get; set; }
        public PAWHSStockAdjApplicationException ApplicationException { get; set; }

    }

    #endregion


    #region fetch
    public class PAWHSStockAdjFHeader
    {
        public int IOU_adjustment_rowid { get; set; }
        public string IOU_adjustment_no { get; set; }
        public string In_whs_code { get; set; }
        public string In_whs_name { get; set; }
        public string In_adjustment_date { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_process_status { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSStockAdjFDetail
    {
        public int In_adjustmentdtl_rowid { get; set; }
        public string In_grn_invoiceno { get; set; }
        public string In_adjustment_type { get; set; }
        public string In_adjustment_desc { get; set; }
        public string In_item_code { get; set; }
        public string In_item_name { get; set; }
        public string In_inward_outward { get; set; }
        public string In_uom { get; set; }
        public double In_quantity { get; set; }
        public double In_adjustment_qty { get; set; }
        public string In_remarks { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSStockAdjFContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSStockAdjFHeader Header { get; set; }
        public IList<PAWHSStockAdjFDetail> Detail { get; set; }

        public int adjustment_rowid { get; set; }
        public string adjustment_no { get; set; }

    }
    public class PAWHSStockAdjFApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSStockAdjFApplication
    {
        public PAWHSStockAdjFContext context { get; set; }
        public PAWHSStockAdjFApplicationException ApplicationException { get; set; }

    }
    #endregion


    #region  save
    public class PAWHSStockAdjSHeader
    {
        public int IOU_adjustment_rowid { get; set; }
        public string IOU_adjustment_no { get; set; }
        public string In_whs_code { get; set; }
        public string In_adjustment_date { get; set; }
        public string In_status_code { get; set; }
        public string In_process_status { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSStockAdjSDetail
    {
        public int In_adjustmentdtl_rowid { get; set; }
        public string In_grn_invoiceno { get; set; }
        public string In_adjustment_type { get; set; }
        public string In_item_code { get; set; }
        public string In_inward_outward { get; set; }
        public string In_uom { get; set; }
        public int In_quantity { get; set; }
        public int In_adjustment_qty { get; set; }
        public string In_remarks { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSStockAdjSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSStockAdjSHeader Header { get; set; }
        public IList<PAWHSStockAdjSDetail> Detail { get; set; }

    }
    public class PAWHSStockAdjSDocument
    {
        public PAWHSStockAdjSContext context { get; set; }
        public PAWHSStockAdjSApplicationException ApplicationException { get; set; }
    }
    public class PAWHSStockAdjSApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSStockAdjSApplication
    {
        public PAWHSStockAdjSDocument document { get; set; }

    }
    #endregion
}
