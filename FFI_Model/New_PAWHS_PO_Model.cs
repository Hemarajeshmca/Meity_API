using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class New_PAWHS_PO_Model
    {
    }

    #region GetFarmersList
    public class GetPOParam
    {
        public string org { get; set; }
        public string locn { get; set; }
        public string user { get; set; }
        public string lang { get; set; }
        public string filterby_option { get; set; }
        public string filterby_code { get; set; }
        public string filterby_fromvalue { get; set; }
        public string filterby_tovalue { get; set; }
        public int out_record_count { get; set; }
        public int from_index { get; set; }
        public int to_index { get; set; }
        public int record_count { get; set; }
    }
    public class POFilter
    {
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }
        public int out_record_count { get; set; }
        public int from_index { get; set; }
        public int to_index { get; set; }
        public int record_count { get; set; }
    }
    public class POLIst
    {
        public int Out_po_rowid { get; set; }
        public string Out_agg_code { get; set; }
        public string Out_agg_name { get; set; }
        public string Out_po_no { get; set; }
        public string Out_po_date { get; set; }
        public string Out_buyer_code { get; set; }
        public string Out_buyer_name { get; set; }
        public string Out_buyer_location { get; set; }
        public string Out_po_remarks { get; set; }
        public string Out_status_code { get; set; }
        public string Out_row_timestamp { get; set; }

        public string Out_GivenBy { get; set; }
        public string Out_GivenByNo { get; set; }
        public string Out_TakenBy { get; set; }
        public string OutTakenByNo { get; set; }



    }
    public class POContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }
        public List<POLIst> List { get; set; }
    }

    public class POApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }
    }

    public class PORootObject
    {
        public POContext context { get; set; }
        public POApplicationException ApplicationException { get; set; }
    }
    #endregion

    #region Save

    public class PAWHSPO_Save_Application
    {
        public PAWHSPO_Save_Document document { get; set; }

    }
    public class PAWHSPO_Save_Document
    {
        public PAWHSPO_Save_Context context { get; set; }
        public POApplicationException ApplicationException { get; set; }

    }
    public class PAWHSPO_Save_Context
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<PAWHSPO_Save_PODetail> QtyDetail { get; set; }
        //  public IList<PAWHSPO_Save_POAttchDtl> AttchDetail { get; set; }      
        public PAWHSPO_Save_Header Header { get; set; }

    }

    public class PAWHSPO_Save_Header
    {

        public Int32 In_po_rowid { get; set; }
        public string In_agg_code { get; set; }
        public string In_po_no { get; set; }
        public string In_po_date { get; set; }
        public string In_buyer_code { get; set; }
        public string In_buyer_name { get; set; }
        public string In_buyer_location { get; set; }
        public string In_po_remarks { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_bill_attachment { get; set; }
        public Int32 IOU_po_rowid { get; set; }
        public string IOU_PO_No { get; set; }
        public string IOU_ErroNo { get; set; }
        public string In_OrderBy { get; set; }
        public string In_OrderByNO { get; set; }
        public string In_TakenBy { get; set; }
        public string In_TakenByNo { get; set; }
    }
    public class PAWHSPO_Save_PODetail
    {
        public Int32 In_podtl_rowid { get; set; }
        public Int32 In_sln_no { get; set; }
        public string In_product_code { get; set; }
        public string In_hsn_code { get; set; }
        public double In_qty { get; set; }
        public double In_rate { get; set; }
        public double In_product_amount { get; set; }
        public double In_discount { get; set; }
        public double In_othercharges { get; set; }
        public double In_tax { get; set; }
        public double In_gross_amount { get; set; }
        public string In_remarks { get; set; }
        public string In_mode_flag { get; set; }
        public Int32 IOU_podtl_rowid { get; set; }
        public string IOU_po_no { get; set; }
        public string IOU_Error { get; set; }
        public IList<PAWHSPO_Save_POShipDtl> ShipDetail { get; set; }

    }

    public class PAWHSPO_Save_POShipDtl
    {
        public Int32 In_shipment_rowid { get; set; }
        public Int32 In_podtl_rowid { get; set; }
        public Int32 In_sl_no { get; set; }
        public string In_address { get; set; }
        public double In_qty { get; set; }
        public string In_product_code { get; set; }
        public string In_mode_flag { get; set; }

        public string IOU_Error { get; set; }
    }

    //public class PAWHSPO_Save_POAttchDtl
    //{
    //    public Int32 In_attch_rowid { get; set; }
    //    public string In_filename { get; set; }
    //    public string In_document { get; set; }
    //    public string In_description { get; set; }
    //    public string In_attch_date { get; set; }
    //    public string In_attch_upload { get; set; }
    //    public string In_mode_flag { get; set; }
    //    public Int32 IOU_attch_rowid { get; set; }

    //    public string IOU_po_no { get; set; }
    //    public string IOU_Error { get; set; }
    //}


    #endregion

    #region SingleFetch

    public class PAWHSPOFetchApplication
    {

        public PAWHSPO_FetchContext context { get; set; }

    }
    public class PAWHSPO_FetchContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }

        public Int32 IOU_PO_rowid { get; set; }
        public string IOU_agg_code { get; set; }
        public string IOU_PONo { get; set; }
        public PAWHSPO_FetchHeader Header { get; set; }
        public IList<PAWHSPO_Fetch_QtyDetail> QtyDetail { get; set; }

        public IList<PAWHSPO_Fetch_TaxDetail> TaxDetail { get; set; }
        //public IList<PAWHSPO_Fetch_AttchDetail> AttchDetail { get; set; }
    }

    public class PAWHSPO_FetchHeader
    {
        public string In_po_date { get; set; }
        public string In_buyer_code { get; set; }
        public string In_buyer_name { get; set; }
        public string In_buyer_location { get; set; }
        public string In_buyer_location_desc { get; set; }
        public string In_po_remarks { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_bill_attachment { get; set; }
        public Int32 IOU_PO_rowid { get; set; }
        public string IOU_agg_code { get; set; }
        public string IOU_PO_No { get; set; }
        public string IOU_agg_name { get; set; }
        public string In_OrderBy { get; set; }
        public string In_OrderByNO { get; set; }
        public string In_TakenBy { get; set; }
        public string In_TakenByNo { get; set; }
    }
    public class PAWHSPO_Fetch_QtyDetail
    {
        public Int32 In_podtl_rowid { get; set; }
        public string In_po_no { get; set; }
        public Int32 In_sln_no { get; set; }
        public string In_product_code { get; set; }
        public string In_product_Type { get; set; }
        public string In_product_Name { get; set; }
        public string In_product_Variety { get; set; }
        public string In_hsn_code { get; set; }
        public double In_qty { get; set; }
        public double In_rate { get; set; }
        public double In_product_amount { get; set; }
        public double In_discount { get; set; }
        public double In_othercharges { get; set; }
        public double In_tax { get; set; }
        public double In_gross_amount { get; set; }
        public double In_Stock_Qty { get; set; }
        public string In_remarks { get; set; }
        public string In_mode_flag { get; set; }
    }


    public class PAWHSPO_Fetch_TaxDetail
    {
        public int In_potax_rowid { get; set; }
        public string In_product_code { get; set; }
        public string In_product_name { get; set; }
        public int In_taxdetails_rowid { get; set; }
        public string In_po_no { get; set; }
        public string In_state { get; set; }
        public double In_taxable_amount { get; set; }
        public double In_tax { get; set; }
        public double In_cgst_rate { get; set; }
        public double In_sgst_rate { get; set; }
        public double In_igst_rate { get; set; }
        public double In_ugst_rate { get; set; }
        public string In_status_code { get; set; }
        public string In_hsn_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_hsn_desc { get; set; }
        public double In_tax_rate { get; set; }
        public string In_mode_flag { get; set; }
    }

    //public class PAWHSPO_Fetch_AttchDetail
    //{
    //    public int In_attch_rowid { get; set; }
    //    public string In_po_no { get; set; }
    //    public string In_filename { get; set; }
    //    public string In_document { get; set; }
    //    public string In_description { get; set; }
    //    public string In_attch_date { get; set; }
    //    public string In_attch_upload { get; set; }
    //    public string In_mode_flag { get; set; }
    //}

    #endregion

    #region shipmentfetch
    public class PAWHSPurchaseOrderShipmentContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public int In_podtl_rowid { get; set; }
        public IList<PAWHSPO_Fetch_ShipDetail> ShipDetail { get; set; }

    }
    public class PAWHSPO_Fetch_ShipDetail
    {
        public int In_shipment_rowid { get; set; }
        public int In_podtl_rowid { get; set; }
        public string In_po_no { get; set; }
        public int In_sl_no { get; set; }
        public string In_address { get; set; }
        public double In_qty { get; set; }
        public string In_product_code { get; set; }
        public string In_mode_flag { get; set; }
    }
    public class PAWHSPurchaseOrderShipment
    {
        public PAWHSPurchaseOrderShipmentContext context { get; set; }
    }
    #endregion

}
