using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class PAWHS_New_PaymentAdvice_Update_Model
    {

    }

    #region list
    public class PAWHS_New_PaymentAdvice_UpdatePaymentDtl
    {
        public int In_paymentdtl_rowid { get; set; }
        public string In_payment_advice_no { get; set; }
    //    public string In_receipt_id { get; set; }
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
    public class PAWHS_New_PaymentAdvice_UpdateContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<PAWHS_New_PaymentAdvice_UpdatePaymentDtl> PaymentDtl { get; set; }
        public string payment_status { get; set; }


    }
    public class PAWHS_New_PaymentAdvice_UpdateApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHS_New_PaymentAdvice_UpdateApplication
    {
        public PAWHS_New_PaymentAdvice_UpdateContext context { get; set; }
        public PAWHS_New_PaymentAdvice_UpdateApplicationException ApplicationException { get; set; }

    }
    #endregion

    #region save
    public class PAWHS_New_PaymentAdvice_UpdateSPaymentDtl
    {
        public int In_paymentdtl_rowid { get; set; }
        public string In_payment_advice_no { get; set; }
   //     public string In_receipt_id { get; set; }
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
    public class PAWHS_New_PaymentAdvice_UpdateSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<PAWHS_New_PaymentAdvice_UpdateSPaymentDtl> PaymentDtl { get; set; }

    }
    public class PAWHS_New_PaymentAdvice_UpdateSDocument
    {
        public PAWHS_New_PaymentAdvice_UpdateSContext context { get; set; }

    }
    public class PAWHS_New_PaymentAdvice_UpdateSApplication
    {
        public PAWHS_New_PaymentAdvice_UpdateSDocument document { get; set; }

    }
    #endregion


}
