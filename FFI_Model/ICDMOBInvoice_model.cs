using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
   public class ICDMOBInvoice_model
    {
        #region save
        public class ICDMOBIHeader
        {
            public string IOU_invoice_rowid { get; set; }
            public string In_orgn_code { get; set; }
            public string In_invoice_no { get; set; }
            public string errorNo { get; set; }
            public string In_ic_code { get; set; }
            public string In_invoice_date { get; set; }
            public string In_customer_type { get; set; }
            public string In_customer_name { get; set; }
            public string In_customer_address { get; set; }
            public string In_farmer_code { get; set; }
            public string In_provider_location { get; set; }
            public string In_reciver_location { get; set; }
            public string In_totalinvoice_amount { get; set; }
            public string In_balance_amount { get; set; }
            public string In_status_code { get; set; }
            public string In_process_status { get; set; }
            public string In_row_timestamp { get; set; }
            public string In_mode_flag { get; set; }
            public string In_transport_amount { get; set; }
            public string In_others { get; set; }
            public string In_phone_no { get; set; }

        }

        public class ICDMOBIInvoiceDetail
        {
            public int In_invoicedtl_rowid { get; set; }
            public string In_product_catg_code { get; set; }
            public string In_product_subcatg_code { get; set; }
            public string In_product_code { get; set; }
            public string In_hsn_code { get; set; }
            public string In_qty { get; set; }
            public string In_base_price { get; set; }
            public string In_product_amount { get; set; }
            public string In_discount_amount { get; set; }
            public string In_tax_amount { get; set; }
            public string In_net_amount { get; set; }
            public string In_status_code { get; set; }
            public string In_mode_flag { get; set; }
            public IList<ICDMOBIInvoiceDetailSlno> Slnoinfo { get; set; }
        }
        public class ICDMOBIInvoiceDetailSlno
        {
            public int In_invoiceslno_rowid { get; set; }
            public int In_invoicedtl_rowid { get; set; }
            public string In_slno { get; set; }
            public string In_no_of_bags { get; set; }
            public string In_invoice_no { get; set; }
            public string In_product_code { get; set; }
            public string In_status_code { get; set; }
            public string In_mode_flag { get; set; }
        }
        public class ICDMOBIContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public ICDMOBIHeader Header { get; set; }
            public IList<ICDMOBIInvoiceDetail> InvoiceDetail { get; set; }
        }

        public class ICDMOBIDocument
        {
            public ICDMOBIContext context { get; set; }
            public ICDMOBApplicationException ApplicationException { get; set; }
        }
        public class ICDMOBApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class ICDMOBIRoot
        {
            public ICDMOBIDocument document { get; set; }
        }


        #endregion

        #region paysave
        public class ICDMOBIPHeader
        {
            public string IOU_invoice_rowid { get; set; }
            public string IOU_invoice_no { get; set; }
            public string In_invoice_date { get; set; }
            public string In_invoice_amount { get; set; }
            public string In_balance_amount { get; set; }
            public string In_payment_mode { get; set; }
            public string In_ref_no { get; set; }
            public string In_payment_date { get; set; }
            public string In_payment_amount { get; set; }
            public string In_payment_response { get; set; }
            public string In_status_code { get; set; }
            public string In_row_timestamp { get; set; }
            public string In_mode_flag { get; set; }
            public string In_check_no { get; set; }
        }

        public class ICDMOBIPDetail
        {
            public string In_paymentcollection_rowid { get; set; }
            public string In_payment_type { get; set; }
            public string In_payment_no { get; set; }
            public string In_balance_amount { get; set; }
            public string In_payment_amount { get; set; }
            public string In_payment_mode { get; set; }
            public string In_ref_no { get; set; }
            public string In_payment_date { get; set; }
            public string In_process_status { get; set; }
            public string In_paid_amount { get; set; }
            public string In_mode_flag { get; set; }
        }

        public class ICDMOBIPContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public ICDMOBIPHeader Header { get; set; }
            public List<ICDMOBIPDetail> Detail { get; set; }
        }

        public class ICDMOBIPDocument
        {
            public ICDMOBIPContext context { get; set; }
        }

        public class ICDMOBIPRoot
        {
            public ICDMOBIPDocument document { get; set; }
        }


        #endregion
    }

}
