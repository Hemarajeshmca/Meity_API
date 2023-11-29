using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class PAWHSWarehouseReceipt_model
    {
    }
    #region list
    public class PAWHSWarehouseReceiptList
    {
        public int Out_whs_receipt_rowid { get; set; }
        public string Out_grn { get; set; }
        public string Out_farmer_code { get; set; }
        public string Out_farmer_name { get; set; }
        public string Out_pickup_request_id { get; set; }
        public string Out_pickup_date { get; set; }
        public string Out_pickup_slot { get; set; }
        public string Out_procurement { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_row_timestamp { get; set; }
    }
    public class PAWHSWarehouseReceiptFilter
    {
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }       
    }
    public class PAWHSWarehouseReceiptContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSWarehouseReceiptFilter Filter { get; set; }
        public IList<PAWHSWarehouseReceiptList> List { get; set; }
    }
    public class PAWHSWarehouseReceiptApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }
    }
    public class PAWHSWarehouseReceiptApplication
    {
        public PAWHSWarehouseReceiptContext context { get; set; }
        public PAWHSWarehouseReceiptApplicationException ApplicationException { get; set; }
    }
    #endregion
    #region list fetch
    public class PAWHSWarehouseReceiptFHeader
    {
        public int IOU_whs_receipt_rowid { get; set; }
        public string IOU_grn_invoice_no { get; set; }
        public string In_whs_code { get; set; }
        public string In_whs_name { get; set; }
        public string In_receipt_date { get; set; }
        public string In_farmer_code { get; set; }
        public string In_farmer_name { get; set; }
        public string In_reg_mobile_no { get; set; }
        public string In_pickup_request_id { get; set; }
        public string In_item_code { get; set; }
        public string In_item_name { get; set; }
        public string In_uom { get; set; }
        public Double In_quantity { get; set; }
        public Double In_quality { get; set; }
        public string In_quality_desc { get; set; }
        public Double In_received_qty { get; set; }
        public Double In_accepted_qty { get; set; }
        public Double In_rate { get; set; }
        public Double In_amount { get; set; }
        public Double In_paid_amount { get; set; }
        public Double In_balance_amount { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }
    }
    public class PAWHSWarehouseReceiptFDetail
    {
        public string In_quality_code { get; set; }
        public string In_quality_desc { get; set; }
        public string In_range_1 { get; set; }
        public string In_range_2 { get; set; }
        public string In_range_3 { get; set; }
        public string In_range_4 { get; set; }
        public string In_range_5 { get; set; }
        public string In_product_range { get; set; }
        public string In_product_range_desc { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
    }
    public class PAWHSWarehouseReceiptFContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public int IOU_whs_receipt_rowid { get; set; }
        public string IOU_grn_invoice_no { get; set; }
        public PAWHSWarehouseReceiptFHeader Header { get; set; }
        public IList<PAWHSWarehouseReceiptFDetail> Detail { get; set; }
    }

    public class PAWHSWarehouseReceiptFApplication
    {
        public PAWHSWarehouseReceiptFContext context { get; set; }
        public PAWHSWarehouseReceiptFApplicationException ApplicationException { get; set; }
    }
    public class PAWHSWarehouseReceiptFApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }
    }
    #endregion
    #region save
    public class PAWHSWarehouseReceiptSHeader
    {
        public int IOU_whs_receipt_rowid { get; set; }
        public string IOU_grn_invoice_no { get; set; }
        public string In_whs_code { get; set; }
        public string In_receipt_date { get; set; }
        public string In_farmer_code { get; set; }
        public string In_reg_mobile_no { get; set; }
        public string IOU_pickup_request_id { get; set; }
        public string In_item_code { get; set; }
        public string In_uom { get; set; }
        public int In_quantity { get; set; }
        public int In_quality { get; set; }
        public int In_received_qty { get; set; }
        public int In_accepted_qty { get; set; }
        public Double In_rate { get; set; }
        public Double In_amount { get; set; }
        public Double In_paid_amount { get; set; }
        public Double In_balance_amount { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }
    }
    public class PAWHSWarehouseReceiptSDetail
    {
        public string In_quality_code { get; set; }
        public string In_range_1 { get; set; }
        public string In_range_2 { get; set; }
        public string In_range_3 { get; set; }
        public string In_range_4 { get; set; }
        public string In_range_5 { get; set; }
        public string In_product_range { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
    }
    public class PAWHSWarehouseReceiptSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSWarehouseReceiptSHeader Header { get; set; }
        public IList<PAWHSWarehouseReceiptSDetail> Detail { get; set; }
    }
    public class PAWHSWarehouseReceiptSDocument
    {
        public PAWHSWarehouseReceiptSContext context { get; set; }
        public PAWHSWarehouseReceiptSApplicationException ApplicationException { get; set; }
    }
    public class PAWHSWarehouseReceiptSApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }
    }
    public class PAWHSWarehouseReceiptSApplication
    {
        public PAWHSWarehouseReceiptSDocument document { get; set; }
    }
    #endregion
    #region ltem fetch
    public class PAWHSWarehouseReceiptIHeader
    {
        public int IOU_item_rowid { get; set; }
        public string IOU_agg_code { get; set; }
        public string IOU_item_code { get; set; }
        public string In_item_name { get; set; }
        public string In_item_ll_name { get; set; }
        public string In_item_type { get; set; }
        public string In_fg_category { get; set; }
        public string In_fg_subcategory { get; set; }
        public string In_uom_code { get; set; }
        public string In_hsn_code { get; set; }
        public string In_hsn_description { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }
    }
    public class PAWHSWarehouseReceiptIDetail
    {
        public int In_item_dtl_rowid { get; set; }
        public string In_item_code { get; set; }
        public string In_quality { get; set; }
        public string In_quality_desc { get; set; }
        public Double In_base_price { get; set; }
        public string In_range_1 { get; set; }
        public string In_range_2 { get; set; }
        public string In_range_3 { get; set; }
        public string In_range_4 { get; set; }
        public string In_range_5 { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
    }
    public class PAWHSWarehouseReceiptIContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSWarehouseReceiptIHeader Header { get; set; }
        public IList<PAWHSWarehouseReceiptIDetail> Detail { get; set; }
    }

    public class PAWHSWarehouseReceiptIApplication
    {
        public PAWHSWarehouseReceiptIContext context { get; set; }
        public PAWHSWarehouseReceiptIApplicationException ApplicationException { get; set; }
    }
    public class PAWHSWarehouseReceiptIApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }
    }
    #endregion
}
