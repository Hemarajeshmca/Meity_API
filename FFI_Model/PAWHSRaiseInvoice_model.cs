using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class PAWHSRaiseInvoice_model
    {
    }
    #region list
    public class PAWHSRaiseInvoiceList
    {
        public int Out_raise_invoce_rowid { get; set; }
        public string Out_invoice_no { get; set; }
        public string Out_invoice_date { get; set; }
        public string Out_customer_name { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_row_timestamp { get; set; }

    }
    public class PAWHSRaiseInvoiceFilter
    {
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }
       
    }
    public class PAWHSRaiseInvoiceContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSRaiseInvoiceFilter Filter { get; set; }
        public IList<PAWHSRaiseInvoiceList> List { get; set; }

    }
    public class PAWHSRaiseInvoiceApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSRaiseInvoiceApplication
    {
        public PAWHSRaiseInvoiceContext context { get; set; }
        public PAWHSRaiseInvoiceApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region fetch
    public class PAWHSRaiseInvoiceFInvoiceDetails
    {
        public int In_invoice_details_rowid { get; set; }
        public string In_item_code { get; set; }
        public string In_item_desc { get; set; }
        public string In_item_name { get; set; }
        public string In_type { get; set; }
        public Double In_qty { get; set; }
        public string In_uom_code { get; set; }
        public string In_uom_desc { get; set; }
        public Double In_rate { get; set; }
        public Double In_amount { get; set; }
        public Double In_discount { get; set; }
        public Double In_tax_amount { get; set; }
        public Double In_net_amount { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSRaiseInvoiceFTaxDetails
    {
        public int In_taxdetails_rowid { get; set; }
        public string In_state { get; set; }
        public string In_hsn_code { get; set; }
        public string In_hsn_desc { get; set; }
        public Double In_tax_rate { get; set; }
        public Double In_taxable_amount { get; set; }
        public Double In_tax_amount { get; set; }
        public Double In_cgst_rate { get; set; }
        public Double In_sgst_rate { get; set; }
        public Double In_igst_rate { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSRaiseInvoiceFHeader
    {
        public int IOU_invoice_rowid { get; set; }
        public string In_fpo_name { get; set; }
        public string In_invoice_date { get; set; }
        public string In_invoice_no { get; set; }
        public string In_customer_code { get; set; }
        public string In_customer_name { get; set; }
        public string In_customer_state { get; set; }
        public string In_provider_state { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }
        public IList<PAWHSRaiseInvoiceFInvoiceDetails> InvoiceDetails { get; set; }
        public IList<PAWHSRaiseInvoiceFTaxDetails> TaxDetails { get; set; }

    }
    public class PAWHSRaiseInvoiceFContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public int IOU_invoice_rowid { get; set; }
        public PAWHSRaiseInvoiceFHeader Header { get; set; }

    }

    public class PAWHSRaiseInvoiceFApplication
    {
        public PAWHSRaiseInvoiceFContext context { get; set; }
        public PAWHSRaiseInvoiceFApplicationException ApplicationException { get; set; }

    }
    public class PAWHSRaiseInvoiceFApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    #endregion
    #region SAVE
    public class PAWHSRaiseInvoiceSInvoiceDetails
    {
        public int In_invoice_details_rowid { get; set; }
        public string In_item_code { get; set; }
        public string In_item_desc { get; set; }
        public string In_item_name { get; set; }
        public string In_type { get; set; }
        public Double In_qty { get; set; }
        public string In_uom_code { get; set; }
        public Double In_rate { get; set; }
        public Double In_amount { get; set; }
        public Double In_discount { get; set; }
        public Double In_tax_amount { get; set; }
        public Double In_net_amount { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSRaiseInvoiceSTaxDetails
    {
        public int In_taxdetails_rowid { get; set; }
        public string In_state { get; set; }
        public string In_hsn_code { get; set; }
        public string In_hsn_desc { get; set; }
        public Double In_tax_rate { get; set; }
        public Double In_taxable_amount { get; set; }
        public Double In_tax_amount { get; set; }
        public Double In_cgst_rate { get; set; }
        public Double In_sgst_rate { get; set; }
        public Double In_igst_rate { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSRaiseInvoiceSHeader
    {
        public int IOU_invoice_rowid { get; set; }
        public string IOU_invoice_no { get; set; }
        public string In_fpo_name { get; set; }
        public string In_invoice_date { get; set; }
        public string In_customer_code { get; set; }
        public string In_customer_state { get; set; }
        public string In_provider_state { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }
        public IList<PAWHSRaiseInvoiceSInvoiceDetails> InvoiceDetails { get; set; }
        public IList<PAWHSRaiseInvoiceSTaxDetails> TaxDetails { get; set; }

    }
    public class PAWHSRaiseInvoiceSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSRaiseInvoiceSHeader Header { get; set; }
        //public IList<NewInvoiceDetails> InvoiceDetails { get; set; }
        //public IList<NewTaxDetails> TaxDetails { get; set; }

    }
    public class PAWHSRaiseInvoiceSDocument
    {
        public PAWHSRaiseInvoiceSContext context { get; set; }
        public PAWHSRaiseInvoiceSApplicationException ApplicationException { get; set; }
    }
    public class PAWHSRaiseInvoiceSApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSRaiseInvoiceSApplication
    {
        public PAWHSRaiseInvoiceSDocument document { get; set; }
    }
    #endregion
    #region payment fetch
    public class PAWHSRaiseInvoicePHeader
    {
        public string In_invoice_no { get; set; }
        public Double In_amount { get; set; }
        public Double In_balance_amount { get; set; }
        public string In_paymode_code { get; set; }
        public string In_paymode_desc { get; set; }
        public string In_ref_no { get; set; }
        public string In_payment_date { get; set; }
        public Double In_payment_amount { get; set; }

    }
    public class PAWHSRaiseInvoicePDetail
    {
        public int In_paymentcollection_rowid { get; set; }
        public string In_payment_type { get; set; }
        public string In_payment_type_desc { get; set; }
        public string In_payment_no { get; set; }
        public Double In_balance_amount { get; set; }
        public Double In_payment_amount { get; set; }
        public string In_payment_mode { get; set; }
        public string In_payment_mode_desc { get; set; }
        public string In_ref_no { get; set; }
        public string In_payment_date { get; set; }
        public string In_process_status { get; set; }
        public string In_process_status_desc { get; set; }
        public Double In_paid_amount { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSRaiseInvoicePContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public string IOU_invoice_rowid { get; set; }
        public PAWHSRaiseInvoicePHeader Header { get; set; }
        public IList<PAWHSRaiseInvoicePDetail> Detail { get; set; }

    }

    public class PAWHSRaiseInvoicePApplication
    {
        public PAWHSRaiseInvoicePContext context { get; set; }
        public PAWHSRaiseInvoiceSApplicationException ApplicationException { get; set; }
    }
    public class PAWHSRaiseInvoicePApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    #endregion
    #region payment save
    public class PAWHSRaiseInvoicePSHeader
    {
        public int In_invoice_rowid { get; set; }
        public string In_invoice_no { get; set; }
        public int In_amount { get; set; }
        public Double In_balance_amount { get; set; }
        public string In_paymode_code { get; set; }
        public string In_ref_no { get; set; }
        public string In_payment_date { get; set; }
        public Double In_payment_amount { get; set; }
        public string In_status_code { get; set; }
        public string In_modeflag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class PAWHSRaiseInvoicePSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSRaiseInvoicePSHeader Header { get; set; }

    }
    public class PAWHSRaiseInvoicePSDocument
    {
        public PAWHSRaiseInvoicePSContext context { get; set; }
        public PAWHSRaiseInvoicePSApplicationException ApplicationException { get; set; }
    }
    public class PAWHSRaiseInvoicePSApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSRaiseInvoicePSApplication
    {
        public PAWHSRaiseInvoicePSDocument document { get; set; }

    }
    #endregion
    #region product fetch
    public class PAWHSRaiseInvoiceProductDetail
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
        public Double In_base_price { get; set; }
        public Double In_current_qty { get; set; }

    }
    public class PAWHSRaiseInvoiceInvoiceTax
    {
        public int In_invoicetax_rowid { get; set; }
        public string In_invoice_no { get; set; }
        public string In_product_code { get; set; }
        public string In_product_name { get; set; }
        public string In_hsn_code { get; set; }
        public string In_hsn_desc { get; set; }
        public Double In_cgst_rate { get; set; }
        public Double In_sgst_rate { get; set; }
        public Double In_igst_rate { get; set; }
        public Double In_ugst_rate { get; set; }
        public string In_tax_type { get; set; }
        public Double In_tax_rate { get; set; }
        public Double In_taxable_amount { get; set; }
        public Double In_tax_amount { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }

    }

    public class PAWHSRaiseInvoiceProductContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSRaiseInvoiceFilter Filter { get; set; }
        public IList<PAWHSRaiseInvoiceProductDetail> Detail { get; set; }
        public IList<PAWHSRaiseInvoiceInvoiceTax> InvoiceTax { get; set; }

    }

    public class PAWHSRaiseInvoiceProductApplication
    {
        public PAWHSRaiseInvoiceProductContext context { get; set; }
        public PAWHSRaiseInvoiceApplicationException ApplicationException { get; set; }

    }
    #endregion
}
