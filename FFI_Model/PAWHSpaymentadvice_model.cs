using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class PAWHSpaymentadvice_model
    {
    }

    #region list
    public class PAWHSpayadviceList
    {
        public int Out_payment_rowid { get; set; }
        public string Out_payment_id { get; set; }
        public string Out_date { get; set; }
        public string Out_period_from { get; set; }
        public string Out_period_to { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }

    }
    public class PAWHSpayadviceContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<PAWHSpayadviceList> List { get; set; }

        public string filterby_option { get; set; }
        public string filterby_code { get; set; }
        public string filterby_fromvalue { get; set; }
        public string filterby_tovalue { get; set; }


    }
    public class PAWHSpayadviceApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSpayadviceApplication
    {
        public PAWHSpayadviceContext context { get; set; }
        public PAWHSpayadviceApplicationException ApplicationException { get; set; }

    }

    #endregion

    #region fetch
    public class PAWHSpaymentadvice_FHeader
    {
        public int IOU_payment_rowid { get; set; }
        public string IOU_payment_id { get; set; }
        public string IOU_from_date { get; set; }
        public string IOU_to_date { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSpaymentadvice_FDetail
    {
        public int In_paymentdtl_rowid { get; set; }
        public string In_farmer_code { get; set; }
        public string In_farmer_name { get; set; }
        public double In_amount_paid { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSpaymentadvice_FContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSpaymentadvice_FHeader Header { get; set; }
        public IList<PAWHSpaymentadvice_FDetail> Detail { get; set; }
        public Int32 payment_rowid { get; set; }
        public string payment_id { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }


    }
    public class PAWHSpaymentadvice_FApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSpaymentadvice_FApplication
    {
        public PAWHSpaymentadvice_FContext context { get; set; }
        public PAWHSpaymentadvice_FApplicationException ApplicationException { get; set; }

    }
    #endregion

    #region save
    public class PAWHSpaymentadvice_SHeader
    {
        public int IOU_payment_rowid { get; set; }
        public string In_payment_id { get; set; }
        public string In_from_date { get; set; }
        public string In_to_date { get; set; }
        public string In_bank_name { get; set; }
        public double IOU_total_amount { get; set; }
        public string In_status_code { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSpaymentadvice_SDetail
    {
        public int In_paymentdtl_rowid { get; set; }
        public string In_req_no { get; set; }
        public string In_farmer_code { get; set; }
        public int In_amount_paid { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSpaymentadvice_SContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSpaymentadvice_SHeader Header { get; set; }
        public IList<PAWHSpaymentadvice_SDetail> Detail { get; set; }

    }
    public class PAWHSpaymentadvice_SDocument
    {
        public PAWHSpaymentadvice_SContext context { get; set; }

    }
    public class PAWHSpaymentadvice_SApplication
    {
        public PAWHSpaymentadvice_SDocument document { get; set; }

    }
    #endregion
}
