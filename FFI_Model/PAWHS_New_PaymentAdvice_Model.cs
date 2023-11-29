using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class PAWHS_New_PaymentAdvice_Model
    {

    }

    #region list
    public class PAWHS_New_PaymentAdvice_List
    {
        public int Out_payment_rowid { get; set; }
        public string Out_payment_id { get; set; }
        public string Out_date { get; set; }
        public string Out_period_from { get; set; }
        public string Out_period_to { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string out_agg_code { get; set; }
        public string out_agg_name { get; set; }

    }
    public class PAWHS_New_PaymentAdvice_ALL_Context
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<PAWHS_New_PaymentAdvice_List> List { get; set; }

        public string filterby_option { get; set; }
        public string filterby_code { get; set; }
        public string filterby_fromvalue { get; set; }
        public string filterby_tovalue { get; set; }


    }
    public class PAWHS_New_PaymentAdvice_ALL_ApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHS_New_PaymentAdvice_List_Application
    {
        public PAWHS_New_PaymentAdvice_ALL_Context context { get; set; }
        public PAWHS_New_PaymentAdvice_ALL_ApplicationException ApplicationException { get; set; }

    }
  
    #endregion

    #region fetch
    public class PAWHS_New_PaymentAdvice_Single_FHeader
    {
        public int IOU_payment_rowid { get; set; }
        public string IOU_payment_id { get; set; }
        public string IOU_from_date { get; set; }
        public string IOU_to_date { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }
        public string In_agg_name { get; set; }
        public string In_agg_code { get; set; }

    }
    public class PAWHS_New_PaymentAdvice_Single_FDetail
    {
        public int In_paymentdtl_rowid { get; set; }
        public string In_lot_no { get; set; }
        public string In_farmer_code { get; set; }
        public string In_farmer_name { get; set; }
        public string In_procurment_date { get; set; }
        public decimal In_qty { get; set; }
        public decimal In_price { get; set; }
        public decimal In_amount_paid { get; set; }
        public decimal In_total_othercost { get; set; }
        public decimal In_advance { get; set; }
        public decimal In_balance { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHS_New_PaymentAdvice_Single_FContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHS_New_PaymentAdvice_Single_FHeader Header { get; set; }
        public IList<PAWHS_New_PaymentAdvice_Single_FDetail> Detail { get; set; }
        public Int32 payment_rowid { get; set; }
        public string payment_id { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }


    }
    public class PAWHS_New_PaymentAdvice_Single_FApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHS_New_PaymentAdvice_Single_FApplication
    {
        public PAWHS_New_PaymentAdvice_Single_FContext context { get; set; }
        public PAWHS_New_PaymentAdvice_Single_FApplicationException ApplicationException { get; set; }

    }
    #endregion

    #region save
    public class PAWHS_New_PaymentAdvice_SHeader
    {
        public int IOU_payment_rowid { get; set; }
        public string IOU_payment_no { get; set; }
        public string In_payment_advice_no { get; set; }
        public string In_from_date { get; set; }
        public string In_to_date { get; set; }
        public string In_bank_name { get; set; }
        public string In_status_code { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHS_New_PaymentAdvice_SDetail
    {
        public int In_paymentdtl_rowid { get; set; }
        public string In_req_no { get; set; }
        public string In_farmer_code { get; set; }
        public decimal In_balance { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_payment_remark { get; set; }
        public string In_lot_no { get; set; }

    }
    public class PAWHS_New_PaymentAdvice_SContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHS_New_PaymentAdvice_SHeader Header { get; set; }
        public IList<PAWHS_New_PaymentAdvice_SDetail> Detail { get; set; }

    }
    public class PAWHS_New_PaymentAdvice_SDocument
    {
        public PAWHS_New_PaymentAdvice_SContext context { get; set; }

    }
    public class PAWHS_New_PaymentAdvice_SApplication
    {
        public PAWHS_New_PaymentAdvice_SDocument document { get; set; }

    }
    #endregion

    #region From date and Todate 
    //public class PAWHS_New_PaymentAdvice_Single_FHeader
    //{
    //    public int IOU_payment_rowid { get; set; }
    //    public string IOU_payment_id { get; set; }
    //    public string IOU_from_date { get; set; }
    //    public string IOU_to_date { get; set; }
    //    public string In_status_code { get; set; }
    //    public string In_status_desc { get; set; }
    //    public string In_row_timestamp { get; set; }
    //    public string In_mode_flag { get; set; }

    //}
    public class PAWHS_New_PaymentAdvice_fetchgrid_FDetail
    {
        public int In_paymentdtl_rowid { get; set; }

        public string In_farmer_code { get; set; }
        public string In_lot_no { get; set; }
        public string In_farmer_name { get; set; }
        public string In_procurment_date { get; set; }
        public decimal In_qty { get; set; }
        public decimal In_price { get; set; }
        public decimal In_amount_paid { get; set; }
        public decimal In_total_othercost { get; set; }
        public decimal In_advance { get; set; }
        public decimal In_balance { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHS_New_PaymentAdvice_fetchgrid_FContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
       // public PAWHS_New_PaymentAdvice_Single_FHeader Header { get; set; }
        public IList<PAWHS_New_PaymentAdvice_fetchgrid_FDetail> Detail { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }


    }
    //public class PAWHS_New_PaymentAdvice_fetchgrid_FApplicationException
    //{
    //    public string errorNumber { get; set; }
    //    public string errorDescription { get; set; }

    //}
    public class PAWHS_New_PaymentAdvice_fetchgrid_FApplication
    {
        public PAWHS_New_PaymentAdvice_fetchgrid_FContext context { get; set; }
       // public PAWHS_New_PaymentAdvice_fetchgrid_FApplicationException ApplicationException { get; set; }

    }
    #endregion
}
