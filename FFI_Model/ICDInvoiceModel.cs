using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class ICDInvoiceModel
    {
    }
    #region list 
    public class ICDInvoiceList
    {
        public int Out_invoice_rowid { get; set; }
        public string Out_ic_code { get; set; }
        public string Out_ic_name { get; set; }
        public string Out_invoice_no { get; set; }
        public string Out_invoice_date { get; set; }
        public string Out_customer_type { get; set; }
        public string Out_customer_type_desc { get; set; }
        public string Out_customer_name { get; set; }
        public string Out_reciver_location { get; set; }
        public string Out_reciver_location_desc { get; set; }
        public string Out_reciver_address { get; set; }
        public string Out_process_status { get; set; }
        public string Out_process_status_desc { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_totalinvoice_amount { get; set; }
    }
    public class ICDInvoiceContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<ICDInvoiceList> List { get; set; }
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }

    }
    public class ICDInvoiceApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class ICDInvoiceApplication
    {
        public ICDInvoiceContext context { get; set; }
        public ICDInvoiceApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region list fetch
    public class ICDInvoiceDetail
    {
        public int In_invoicedtl_rowid { get; set; }
        public string In_invoice_no { get; set; }
        public string In_product_catg_code { get; set; }
        public string In_product_catg_desc { get; set; }
        public string In_product_subcatg_code { get; set; }
        public string In_product_subcatg_desc { get; set; }
        public string In_product_code { get; set; }
        public string In_product_desc { get; set; }
        public string In_hsn_code { get; set; }
        public string In_hsn_desc { get; set; }
        public double In_qty { get; set; }
        public string In_uomtype_code { get; set; }
        public string In_uomtype_desc { get; set; }
        public double In_base_price { get; set; }
        public double In_product_amount { get; set; }
        public double In_discount_amount { get; set; }
        public double In_tax_amount { get; set; }
        public double In_tax_rate { get; set; }
        public double In_net_amount { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }


    }
    public class ICDInvoiceDetailSlno
    {
        public int In_invoicedtl_rowid { get; set; }
        public string In_slno { get; set; }
        public string In_no_of_bags { get; set; }
        public string In_invoice_no { get; set; }
        public string In_product_code { get; set; }
        public string In_product_name { get; set; }
        public string In_mode_flag { get; set; }
    }
    public class ICDInvoiceTax
    {
        public int In_invoicetax_rowid { get; set; }
        public string In_invoice_no { get; set; }
        public string In_product_code { get; set; }
        public string In_product_name { get; set; }
        public string In_hsn_code { get; set; }
        public string In_hsn_desc { get; set; }
        public double In_cgst_rate { get; set; }
        public double In_sgst_rate { get; set; }
        public double In_igst_rate { get; set; }
        public double In_ugst_rate { get; set; }
        public string In_tax_type { get; set; }
        public double In_tax_rate { get; set; }
        public double In_taxable_amount { get; set; }
        public double In_tax_amount { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class ICDInvoicePaymentCollection
    {
        public int In_paymentcollection_rowid { get; set; }
        public string In_payment_type { get; set; }
        public string In_payment_no { get; set; }
        public double In_balance_amount { get; set; }
        public double In_payment_amount { get; set; }
        public string In_payment_mode { get; set; }
        public string In_ref_no { get; set; }
        public string In_payment_date { get; set; }
        public string In_process_status { get; set; }
        public string In_process_desc { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class ICDInvoiceHeader
    {
        public int IOU_invoice_rowid { get; set; }
        public string In_orgn_code { get; set; }
        public string In_invoice_no { get; set; }
        public string In_ic_code { get; set; }
        public string In_ic_desc { get; set; }
        public string In_invoice_date { get; set; }
        public string In_customer_type { get; set; }
        public string In_customer_type_desc { get; set; }
        public string In_customer_name { get; set; }
        public string In_customer_address { get; set; }
        public string In_farmer_code { get; set; }
        public string In_farmer_name { get; set; }
        public string In_provider_location { get; set; }
        public string In_provider_location_desc { get; set; }
        public string In_reciver_location { get; set; }
        public string In_reciver_location_desc { get; set; }
        public double In_totalinvoice_amount { get; set; }
        public double In_balance_amount { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_process_status { get; set; }
        public string In_process_status_desc { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }
        public double In_transport_amount { get; set; }
        public string In_others { get; set; }
        public string In_phone_no { get; set; }
        public IList<ICDInvoiceDetail> InvoiceDetail { get; set; }
        public IList<ICDInvoiceTax> InvoiceTax { get; set; }
        public IList<ICDInvoicePaymentCollection> PaymentCollection { get; set; }
        public IList<ICDInvoiceDetailSlno> Slno { get; set; }

    }
    public class ICDInvoiceFContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public ICDInvoiceHeader Header { get; set; }
        public int invoice_rowid { get; set; }


    }
    public class FApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class ICDInvoiceFApplication
    {
        public ICDInvoiceFContext context { get; set; }
        public FApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region productfetch
    public class ICDSIProDetail
    {
        public string In_ic_code { get; set; }
        public string In_productcategory { get; set; }
        public string In_productcategory_desc { get; set; }
        public string In_productsubcategory { get; set; }
        public string In_productsubcategory_desc { get; set; }
        public string In_product_code { get; set; }
        public string In_product_name { get; set; }
        public string In_uomtype_code { get; set; }
        public string In_uomtype_code_desc { get; set; }
        public double In_base_price { get; set; }
        public double In_current_qty { get; set; }

    }
    public class ICDSIProInvoiceTax
    {
        public int In_invoicetax_rowid { get; set; }
        public string In_invoice_no { get; set; }
        public string In_product_code { get; set; }
        public string In_product_name { get; set; }
        public string In_hsn_code { get; set; }
        public string In_hsn_desc { get; set; }
        public double In_cgst_rate { get; set; }
        public double In_sgst_rate { get; set; }
        public double In_igst_rate { get; set; }
        public double In_ugst_rate { get; set; }
        public string In_tax_type { get; set; }
        public double In_tax_rate { get; set; }
        public double In_taxable_amount { get; set; }
        public double In_tax_amount { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class ICDSIProContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<ICDSIProDetail> Detail { get; set; }
        public IList<ICDSIProInvoiceTax> InvoiceTax { get; set; }
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }

    }
    public class ICDSIProApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class ICDSIProApplication
    {
        public ICDSIProContext context { get; set; }
        public ICDSIProApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region save
    public class SAHeader
    {
        public int IOU_invoice_rowid { get; set; }
        public string In_orgn_code { get; set; }
        public string In_invoice_no { get; set; }
        public string In_ic_code { get; set; }
        public string In_invoice_date { get; set; }
        public string In_customer_type { get; set; }
        public string In_customer_name { get; set; }
        public string In_customer_address { get; set; }
        public string In_farmer_code { get; set; }
        public string In_provider_location { get; set; }
        public string In_reciver_location { get; set; }
        public double In_totalinvoice_amount { get; set; }
        public double In_balance_amount { get; set; }
        public string In_status_code { get; set; }
        public string In_process_status { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }
        public double In_transport_amount { get; set; }
        public string In_others { get; set; }

    }
    public class SAInvoiceDetail
    {
        public int In_invoicedtl_rowid { get; set; }
        public string In_product_catg_code { get; set; }
        public string In_product_subcatg_code { get; set; }
        public string In_product_code { get; set; }
        public string In_hsn_code { get; set; }
        public double In_qty { get; set; }
        public double In_base_price { get; set; }
        public double In_product_amount { get; set; }
        public double In_discount_amount { get; set; }
        public double In_tax_amount { get; set; }
        public double In_net_amount { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class SAContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public SAHeader Header { get; set; }
        public IList<SAInvoiceDetail> InvoiceDetail { get; set; }

    }
    public class SADocument
    {
        public SAContext context { get; set; }
        public SAApplicationException ApplicationException { get; set; }
    }
    public class SAApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class SAApplication
    {
        public SADocument document { get; set; }

    }
    #endregion
    #region ICDInvoice payment fetch
    public class ICDInvoicepayHeader
    {
        public string In_invoice_no { get; set; }
        public string In_invoice_date { get; set; }
        public double In_invoice_amount { get; set; }
        public double In_balance_amount { get; set; }

    }
    public class ICDInvoicepayDetail
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
    public class ICDInvoicepayContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public ICDInvoicepayHeader Header { get; set; }
        public IList<ICDInvoicepayDetail> Detail { get; set; }
        public int invoice_rowid { get; set; }


    }
    public class ICDInvoicepayApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class ICDInvoicepayApplication
    {
        public ICDInvoicepayContext context { get; set; }
        public ICDInvoicepayApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region payemntsave
    public class PSHeader
    {
        public int IOU_invoice_rowid { get; set; }
        public string IOU_invoice_no { get; set; }
        public string In_invoice_date { get; set; }
        public double In_invoice_amount { get; set; }
        public double In_balance_amount { get; set; }
        public string In_payment_mode { get; set; }
        public string In_ref_no { get; set; }
        public string In_payment_date { get; set; }
        public double In_payment_amount { get; set; }
        public string In_payment_response { get; set; }
        public string In_status_code { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }
        public string In_check_no { get; set; }

    }
    public class PSDetail
    {
        public int In_paymentcollection_rowid { get; set; }
        public string In_payment_type { get; set; }
        public string In_payment_no { get; set; }
        public double In_balance_amount { get; set; }
        public double In_payment_amount { get; set; }
        public string In_payment_mode { get; set; }
        public string In_ref_no { get; set; }
        public string In_payment_date { get; set; }
        public string In_process_status { get; set; }
        public double In_paid_amount { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PSHeader Header { get; set; }
        public IList<PSDetail> Detail { get; set; }

    }
    public class Document
    {
        public PSContext context { get; set; }
        public PSAApplicationException ApplicationException { get; set; }
    }
    public class PSApplication
    {
        public Document document { get; set; }

    }
    public class PSAApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    #endregion
    #region ICDInvoicesave
    public class ICDInvoiceSAHeader
    {
        public int IOU_invoice_rowid { get; set; }
        public string In_orgn_code { get; set; }
        public string In_invoice_no { get; set; }
        public string In_ic_code { get; set; }
        public string In_invoice_date { get; set; }
        public string In_customer_type { get; set; }
        public string In_customer_name { get; set; }
        public string In_customer_address { get; set; }
        public string In_farmer_code { get; set; }
        public string In_provider_location { get; set; }
        public string In_reciver_location { get; set; }
        public double In_totalinvoice_amount { get; set; }
        public double In_balance_amount { get; set; }
        public string In_status_code { get; set; }
        public string In_process_status { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }
        public Int32 In_transport_amount { get; set; }
        public Int32 In_others { get; set; }
        public string In_phone_no { get; set; }
    }
    public class ICDInvoiceSAInvoiceDetail
    {
        public int In_invoicedtl_rowid { get; set; }
        public string In_product_catg_code { get; set; }
        public string In_product_subcatg_code { get; set; }
        public string In_product_code { get; set; }
        public string In_hsn_code { get; set; }
        public double In_qty { get; set; }
        public double In_base_price { get; set; }
        public double In_product_amount { get; set; }
        public double In_discount_amount { get; set; }
        public double In_tax_amount { get; set; }
        public double In_net_amount { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class ICDInvoiceDetailSerialno
    {
        public int In_slno_row_id { get; set; }
        public string In_slno { get; set; }
        public string In_no_of_bags { get; set; }
        public string In_invoice_no { get; set; }
        public string In_product_code { get; set; }
        public string In_product_name { get; set; }
        public string In_mode_flag { get; set; }
    }
    public class ICDInvoiceSAContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public ICDInvoiceSAHeader Header { get; set; }
        public IList<ICDInvoiceSAInvoiceDetail> InvoiceDetail { get; set; }
        public IList<ICDInvoiceDetailSerialno> serialno { get; set; }
    }
    public class ICDInvoiceSADocument
    {
        public ICDInvoiceSAContext context { get; set; }
        public ICDInvoiceSAApplicationException ApplicationException { get; set; }
    }
    public class ICDInvoiceSAApplication
    {
        public ICDInvoiceSADocument document { get; set; }

    }

    public class ICDInvoiceSAApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    #endregion
    /* Prema Including new List API */
    #region INVOICElist 
    public class InvoiceList
    {
        public int Out_invoice_rowid { get; set; }
        public string Out_ic_code { get; set; }
        public string Out_ic_name { get; set; }
        public string Out_invoice_no { get; set; }
        public string Out_invoice_date { get; set; }
        public string Out_customer_name { get; set; }
        public string Out_totalinvoice_amount { get; set; }
        public string Out_balance_amount { get; set; }
    }
    public class InvoiceContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<InvoiceList> List { get; set; }

    }
    public class InvoiceApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class InvoiceApplication
    {
        public InvoiceContext context { get; set; }
        public InvoiceApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region INVOICEPAYlist 
    public class InvoicePayList
    {
        public int Out_invoice_rowid { get; set; }
        public string Out_invoice_no { get; set; }
        public string Out_invoice_date { get; set; }
        public string Out_reference_no { get; set; }
        public string Out_paymode { get; set; }
        public string Out_totalinvoice_amount { get; set; }
        public string Out_balance_amount { get; set; }
        public string Out_status { get; set; }

    }
    public class InvoicePayContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public string invoice_no { get; set; }
        public IList<InvoicePayList> List { get; set; }

    }
    public class InvoicePayApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class InvoicePayApplication
    {
        public InvoicePayContext context { get; set; }
        public InvoicePayApplicationException ApplicationException { get; set; }

    }
    #endregion
    /* END */
}
