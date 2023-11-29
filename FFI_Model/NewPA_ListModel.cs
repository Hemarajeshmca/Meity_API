using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
  public class NewPA_ListModel
    {
        /* Prema Including new List API */
        #region PA_paymentcollection
        public class MOBPA_PAYHeader
        {
            public string In_invoice_no { get; set; }
            public string In_invoice_date { get; set; }
            public double In_invoice_amount { get; set; }
            public double In_balance_amount { get; set; }
        }

        public class MOBPA_PAYDetail
        {
            public int In_paymentcollection_rowid { get; set; }
            public string In_payment_type { get; set; }
            public string In_payment_type_desc { get; set; }
            public string In_payment_no { get; set; }
            public double In_balance_amount { get; set; }
            public double In_payment_amount { get; set; }
            public string In_payment_mode { get; set; }
            public string In_payment_mode_desc { get; set; }
            public string In_ref_no { get; set; }
            public string In_payment_date { get; set; }
            public string In_process_status { get; set; }
            public string In_process_status_desc { get; set; }
            public double In_paid_amount { get; set; }
            public string In_mode_flag { get; set; }
        }

        public class MOBPA_PAYContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public MOBPA_PAYHeader Header { get; set; }
            public List<MOBPA_PAYDetail> Detail { get; set; }
        }

        public class MOBPA_PAYApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }
        }

        public class MOBPA_PAYRoot
        {
            public MOBPA_PAYContext context { get; set; }
            public MOBPA_PAYApplicationException ApplicationException { get; set; }
        }


        #endregion       
        #region PA_SALElist 
        public class PA_SaleList
        {
            public int Out_invoice_rowid { get; set; }
            public string Out_agg_code { get; set; }
            public string Out_agg_paname { get; set; }
            public string Out_invoice_no { get; set; }
            public string Out_invoice_date { get; set; }
            public string Out_PurchaseOrder_Id { get; set; }
            public string Out_totalinvoice_amount { get; set; }
            public string Out_balance_amount { get; set; }
        }
        public class PA_SaleContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public IList<PA_SaleList> List { get; set; }

        }
        public class PA_SaleApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class PA_SaleApplication
        {
            public PA_SaleContext context { get; set; }
            public PA_SaleApplicationException ApplicationException { get; set; }

        }
        #endregion
        #region PASalePAYlist 
        public class PASalePayList
        {
            public int Out_pasalepay_rowid { get; set; }
            public string Out_pasalepay_no { get; set; }
            public string Out_pasalepay_date { get; set; }
            public string Out_reference_no { get; set; }
            public string Out_paymode { get; set; }
            public string Out_payment_amount { get; set; }
            public string Out_balance_amount { get; set; }
            public string Out_status { get; set; }

        }
        public class PASalePayContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public string sale_no { get; set; }
            public IList<PASalePayList> List { get; set; }

        }
        public class PASalePayApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class PASalePayApplication
        {
            public PASalePayContext context { get; set; }
            public PASalePayApplicationException ApplicationException { get; set; }

        }
        #endregion
        /* END */
    }
}
