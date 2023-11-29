using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class PAWHSServiceReceipt_model
    {
    }
    #region list
    public class PAWHSServiceReceiptList
    {
        public int Out_receipt_rowid { get; set; }
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
    public class PAWHSServiceReceiptFilter
    {
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }        
    }
    public class PAWHSServiceReceiptContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSServiceReceiptFilter Filter { get; set; }
        public IList<PAWHSServiceReceiptList> List { get; set; }

    }
    public class PAWHSServiceReceiptApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSServiceReceiptApplication
    {
        public PAWHSServiceReceiptContext context { get; set; }
        public PAWHSServiceReceiptApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region fetch
    public class PAWHSServiceReceiptFHeader
    {
        public int IOU_receipt_rowid { get; set; }
        public string IOU_service_receipt_no { get; set; }
        public string In_warehouse_code { get; set; }
        public string In_warehouse_name { get; set; }
        public string In_service_receipt_date { get; set; }
        public string In_farmer_code { get; set; }
        public string In_farmer_name { get; set; }
        public string In_request_id { get; set; }
        public Double In_amount { get; set; }
        public Double In_paid_amount { get; set; }
        public Double In_balance_amount { get; set; }
        public string In_remarks { get; set; }
        public string In_output_item { get; set; }
        public string In_service_type { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class PAWHSServiceReceiptFDetail
    {
        public int In_receiptdtl_rowid { get; set; }
        public string In_item_code { get; set; }
        public string In_item_name { get; set; }
        public string In_uom { get; set; }
        public Double In_quantity { get; set; }
        public Double In_received_qty { get; set; }
        public Double In_accepted_qty { get; set; }
        public string In_remarks { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSServiceReceiptFContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public int IOU_receipt_rowid { get; set; }
        public string IOU_service_receipt_no { get; set; }
        public PAWHSServiceReceiptFHeader Header { get; set; }
        public IList<PAWHSServiceReceiptFDetail> Detail { get; set; }

    }

    public class PAWHSServiceReceiptFApplication
    {
        public PAWHSServiceReceiptFContext context { get; set; }
        public PAWHSServiceReceiptFApplicationException ApplicationException { get; set; }

    }
    public class PAWHSServiceReceiptFApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    #endregion
    #region save
    public class PAWHSServiceReceiptSHeader
    {
        public int IOU_receipt_rowid { get; set; }
        public string IOU_service_receipt_no { get; set; }
        public string In_warehouse_code { get; set; }
        public string In_service_receipt_date { get; set; }
        public string In_farmer_code { get; set; }
        public string In_request_id { get; set; }
        public Double In_amount { get; set; }
        public Double In_paid_amount { get; set; }
        public string In_remarks { get; set; }
        public string In_output_item { get; set; }
        public string In_service_type { get; set; }
        public Double In_balance_amount { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class PAWHSServiceReceiptSDetail
    {
        public int In_receiptdtl_rowid { get; set; }
        public string In_item_code { get; set; }
        public string In_uom { get; set; }
        public Double In_quantity { get; set; }
        public Double In_received_qty { get; set; }
        public Double In_accepted_qty { get; set; }
        public string In_remarks { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSServiceReceiptSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSServiceReceiptSHeader Header { get; set; }
        public IList<PAWHSServiceReceiptSDetail> Detail { get; set; }

    }
    public class PAWHSServiceReceiptSDocument
    {
        public PAWHSServiceReceiptSContext context { get; set; }
        public PAWHSServiceReceiptSApplicationException ApplicationException { get; set; }

    }
    public class PAWHSServiceReceiptSApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSServiceReceiptSApplication
    {
        public PAWHSServiceReceiptSDocument document { get; set; }

    }
    #endregion
}
