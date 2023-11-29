using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class NewPawhsSaleEntry_Model
    {
    }
    public class PAWHSSaleEntryApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSSaleEntryApplication
    {
        public PAWHSSaleEntryContext context { get; set; }
        public PAWHSSaleEntryApplicationException ApplicationException { get; set; }

    }
    #region List
    public class PAWHSSaleEntryContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }
        public IList<PAWHSSaleEntryList> List { get; set; }

    }
    public class PAWHSSaleEntryList
    {

        public int Out_sale_rowid { get; set; }
        public string Out_agg_code { get; set; }
        public string Out_agg_name { get; set; }
        public string Out_saleno { get; set; }
        public string Out_buyer_code { get; set; }
        public string Out_buyer_name { get; set; }
        public string Out_item_code { get; set; }
        public string Out_item_name { get; set; }
        public double Out_sale_qty { get; set; }
        public double Out_sale_price { get; set; }
        public string Out_sale_remarks { get; set; }
        public string Out_status { get; set; }
        public string Out_rowtimestamp { get; set; }
        public string Out_invoice_date { get; set; }
        public decimal Out_NoOf_bags { get; set; }
        public string Out_vehicle_type { get; set; }
        public string Out_vehicle_No { get; set; }
        public string Out_QC_person { get; set; }
        public string Out_Lrp_Name { get; set; }

    }
    #endregion 
    #region Fetch
    public class PAWHS_SaleEntryFetchApplication
    {
        public PAWHS_SaleEntry_FetchContext context { get; set; }

    }
    public class PAWHS_SaleEntry_FetchContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public int IOU_sale_rowid { get; set; }
        public string IOU_agg_code { get; set; }
        public string IOU_sale_no { get; set; }
        public PAWHS_SaleEntry_FetchHeader Header { get; set; }
        public List<PAWHS_SaleEntry_Fetch_SlnoDetail> SlnoDetail { get; set; }
        //public IList<PAWHS_SaleEntry_Fetch_QlyDetail> QlyDetail { get; set; }
    }
    public class PAWHS_SaleEntry_FetchHeader
    {
        public int IOU_sale_rowid { get; set; }
        public string IOU_agg_code { get; set; }
        public string IOU_sale_no { get; set; }
        public string IOU_lotno { get; set; }
        public string In_buyer_code { get; set; }
        public string In_buyer_name { get; set; }
        //public string In_item_code { get; set; }
        public string In_crop_variety { get; set; } //ramya added on 13 jul 21
        public string In_item_name { get; set; } //its crop name
        public double In_sale_qty { get; set; }
        public double In_sale_price { get; set; }
        public double In_sale_value { get; set; }
        public string In_sale_date { get; set; }
        public double In_advance_amt { get; set; }
        public string In_pickup_date { get; set; }
        public int In_no_of_bags { get; set; }
        public string In_payment_type { get; set; }
        public string In_bank_acc_no { get; set; }
        public string In_cheque_no { get; set; }
        public string In_status { get; set; }
        public string In_sale_remarks { get; set; }
        public string In_sale_attach { get; set; }
        public string In_vehicle_type { get; set; }
        public string In_vehicle_no { get; set; }
        public string In_qcperson_name { get; set; }
        public string In_LRP_Name { get; set; }
        public string In_LRP_Mobile_no { get; set; }
        public string In_whs_code { get; set; }
        public string In_whs_name { get; set; }

    }
    public class PAWHS_SaleEntry_Fetch_SlnoDetail
    {
        public int In_slno_row_id { get; set; }
        public string In_agg_code { get; set; }
        public string In_lotno { get; set; }
        public string In_slno { get; set; }
        public string In_temp1 { get; set; }
        public string In_temp2 { get; set; }
        public string In_qty { get; set; }
        public string In_PO_serialno { get; set; }
        public string In_PO_lotno { get; set; }
        public string In_farmername { get; set; }
        public List<PAWHS_SaleEntry_Fetch_QlyDetail> QlyDetail { get; set; }
    }
    public class PAWHS_SaleEntry_Fetch_QlyDetail
    {
        public int In_qly_row_id { get; set; }
        public string In_agg_code { get; set; }
        public string In_sale_no { get; set; }
        public int In_slno_rowid { get; set; }
        public string In_slno { get; set; }
        public string In_item_code { get; set; }
        public string In_qly_code { get; set; }
        public string In_actual_value { get; set; }
        public double In_wr_qly_value { get; set; }
        public double In_estimate_qly_value { get; set; }
    }


    #endregion
    #region Save
    public class PAWHSSalesEntry_Save_Application
    {
        public PAWHSSalesEntry_Save_Document document { get; set; }
    }
    public class PAWHSSalesEntry_Save_Document
    {
        public PAWHSSalesEntry_Save_Context context { get; set; }
        public PAWHSSaleEntryApplicationException ApplicationException { get; set; }
    }

    public class PAWHSSalesEntry_Save_Context
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public string errorMsg { get; set; }
        public PAWHSSalesEntry_Save_Header Header { get; set; }
        public IList<PAWHSSaleEntry_Save_SlnoDetail> SlnoDetail { get; set; }
        public IList<PAWHSSaleEntry_Save_QlyDetail1> QlyDetail1 { get; set; }
    }

    public class PAWHSSalesEntry_Save_Header
    {

        public int in_Sale_rowid { get; set; }
        public string in_SaleNo { get; set; }
        public string In_Buyer_code { get; set; }
        public string In_Buyer_name { get; set; }
        public string in_Item_Code { get; set; }
        public string in_Item_Name { get; set; }
        public double in_Sale_Qty { get; set; }
        public double in_Sale_Price { get; set; }
        public double in_Sale_Value { get; set; }
        public double in_advance_amt { get; set; }
        public Int32 in_no_of_bags { get; set; }
        public string in_Status { get; set; }
        public string in_mode_flag { get; set; }
        public string in_sale_remarks { get; set; }
        public string in_sale_attach { get; set; }
        public string in_vehicle_type { get; set; }
        public string in_vehicle_no { get; set; }
        public string in_qcperson_name { get; set; }
        public string in_LRP_Name { get; set; }
        public string In_LRP_Mobile_no { get; set; }
        public string In_Payment_type { get; set; }
        public string In_Bank_acc_no { get; set; }
        public string In_cheque_no { get; set; }
        public string In_whs_code { get; set; }
        public string In_whs_name { get; set; }
        public string In_Saledate { get; set; }
        public string In_batch_type { get; set; }
        public string In_buyer_mobileno { get; set; }

    }
    public class PAWHSSaleEntry_Save_SlnoDetail
    {

        public Int32 In_slno_row_id { get; set; }
        public string In_slno { get; set; }
        public string In_temp1 { get; set; }
        public string In_temp2 { get; set; }
        public string in_qty { get; set; }
        public string In_mode_flag { get; set; }
        public int In_rowtimestamp { get; set; }
        public Int32 IOU_slno_row_id { get; set; }
        public string IOU_lotno { get; set; }
        public string lotno { get; set; }
        public IList<PAWHSSaleEntry_Save_QlyDetail> QlyDetail { get; set; }


    }
    public class PAWHSSaleEntry_Save_QlyDetail
    {
        public Int32 In_qly_dtl_rowid { get; set; }
        public string In_qly_code { get; set; }
        public Int32 In_slno_rowid { get; set; }
        public string In_slno { get; set; }
        public double In_actual_value { get; set; }
        public double In_wr_qly_value { get; set; }
        public double in_estimate_qly_value { get; set; }
        public string In_mode_flag { get; set; }
        public int In_rowtimestamp { get; set; }
        public Int32 IOU_qly_dtl_rowid { get; set; }
        public string lotno { get; set; }

    }
    public class PAWHSSaleEntry_Save_QlyDetail1
    {
        public Int32 In_qly_dtl_rowid { get; set; }
        public string In_qly_code { get; set; }
        public Int32 In_slno_rowid { get; set; }
        public string In_slno { get; set; }
        public double In_actual_value { get; set; }
        public double In_wr_qly_value { get; set; }
        public double in_estimate_qly_value { get; set; }
        public string In_mode_flag { get; set; }
        public int In_rowtimestamp { get; set; }
        public Int32 IOU_qly_dtl_rowid { get; set; }
        public string lotno { get; set; }

    }

    #endregion

    #region serialnodub
    public class PAWHSSaleEntrydubContext
    {
        public string Instance { get; set; }
        public string sale_no { get; set; }
        public List<PAWHSSaleEntrydub> List { get; set; }
    }
    public class PAWHSSaleEntrydub
    {
        public string sale_no { get; set; }
        public string serial_no { get; set; }
        public string err_serial_no { get; set; }
    }
    #endregion

    #region serialnodubpurchase
    public class PAWHSpurEntrydubContext
    {
        public string Instance { get; set; }
        public string purchase_no { get; set; }
        public List<PAWHSpurEntrydub> List { get; set; }
    }
    public class PAWHSpurEntrydub
    {
        public string serial_no { get; set; }
        public string err_serial_no { get; set; }
    }
    #endregion


    #region serial sale qty
    public class PAWHSsaleqtyContext
    {
        public string Instance { get; set; }
        public string fpocode { get; set; }
        public string aggcode { get; set; }
        public List<PAWHSsaleqty> List { get; set; }
    }
    public class PAWHSsaleqty
    {
        public string serial_no { get; set; }
        public string serial_qty { get; set; }
        public string product_code { get; set; }
        public string lotno { get; set; }
        public int serial_rowid { get; set; }
    }
    #endregion
}
