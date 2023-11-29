using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class PAWHSPaydetailsupdate_model
    {
    }

    #region list
    public class PAWHSPaydtlupdatePaymentDtl
    {
        public int In_paymentdtl_rowid { get; set; }
        public string In_payment_advice_no { get; set; }
        public string In_receipt_id { get; set; }
        public string In_farmer_name { get; set; }
        public double In_payment_amount { get; set; }
        public string In_payment_date { get; set; }
        public string In_payment_mode { get; set; }
        public string In_payment_mode_desc { get; set; }
        public string In_payment_remark { get; set; }
        public string In_bank_ref_no { get; set; }
        public string In_payment_status { get; set; }
        public string In_payment_status_desc { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSPaydtlupdateContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<PAWHSPaydtlupdatePaymentDtl> PaymentDtl { get; set; }
        public string payment_status { get; set; }
        

    }
    public class PAWHSPaydtlupdateApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSPaydtlupdateApplication
    {
        public PAWHSPaydtlupdateContext context { get; set; }
        public PAWHSPaydtlupdateApplicationException ApplicationException { get; set; }

    }
    #endregion


    #region save
    public class PAWHSPaydtlupdateSPaymentDtl
    {
        public int In_paymentdtl_rowid { get; set; }
        public string In_payment_advice_no { get; set; }
        public string In_receipt_id { get; set; }
        public string In_farmer_name { get; set; }
        public double In_payment_amount { get; set; }
        public string In_payment_date { get; set; }
        public string In_payment_mode { get; set; }
        public string In_payment_remark { get; set; }
        public string In_bank_ref_no { get; set; }
        public string In_payment_status { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSPaydtlupdateSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<PAWHSPaydtlupdateSPaymentDtl> PaymentDtl { get; set; }

    }
    public class PAWHSPaydtlupdateSDocument
    {
        public PAWHSPaydtlupdateSContext context { get; set; }

    }
    public class PAWHSPaydtlupdateSApplication
    {
        public PAWHSPaydtlupdateSDocument document { get; set; }

    }
    #endregion
}
