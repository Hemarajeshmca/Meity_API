using System;
using System.Collections.Generic;

namespace FFI_Model
{
    class PAWHSServiceInvoice_model
    {
    }
    #region list



    public class PAWHSServiceInvoiceList
    {
        public int Out_invoce_rowid { get; set; }
        public string Out_invoice_no { get; set; }
        public string Out_invoice_date { get; set; }
        public string Out_customer_name { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_row_timestamp { get; set; }

    }
    public class PAWHSServiceInvoiceFilter
    {
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }

    }
    public class PAWHSServiceInvoiceContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<PAWHSServiceInvoiceList> List { get; set; }

        // public PAWHSServiceInvoiceFilter Filter { get; set; }

        public string filterby_option { get; set; }
        public string filterby_code { get; set; }
        public string filterby_fromvalue { get; set; }
        public string filterby_tovalue { get; set; }

    }
    public class PAWHSServiceInvoiceApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSServiceInvoiceApplication
    {
        public PAWHSServiceInvoiceContext context { get; set; }
        public PAWHSServiceInvoiceApplicationException ApplicationException { get; set; }

    }
    #endregion


    #region fetchservice
    public class PAWHSFSerInvoiceInvoiceDetails
    {
        public int In_invoice_details_rowid { get; set; }
        public string In_service_code { get; set; }
        public string In_service_desc { get; set; }
        public int In_qty { get; set; }
        public string In_uom_code { get; set; }
        public string In_uom_desc { get; set; }
        public double In_rate { get; set; }
        public double In_amount { get; set; }
        public double In_discount { get; set; }
        public double In_tax_amount { get; set; }
        public double In_net_amount { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSFSerInvoiceTaxDetails
    {
        public int In_taxdetails_rowid { get; set; }
        public string In_state { get; set; }
        public string In_hsn_code { get; set; }
        public string In_hsn_description { get; set; }
        public double In_cgst { get; set; }
        public double In_sgst { get; set; }
        public double In_igst { get; set; }
        public double In_tax_rate { get; set; }
        public double In_taxable_amount { get; set; }
        public double In_tax_amount { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSFSerInvoiceHeader
    {
        public int IOU_invoice_rowid { get; set; }
        public string In_fpo_name { get; set; }
        public string In_invoice_date { get; set; }
        public string In_invoice_no { get; set; }
        public string In_service_code { get; set; }
        public string In_customer_code { get; set; }
        public string In_customer_name { get; set; }
        public string In_customer_state { get; set; }
        public string In_provider_state { get; set; }
        public string In_output_field { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }
        public IList<PAWHSFSerInvoiceInvoiceDetails> InvoiceDetails { get; set; }
        public IList<PAWHSFSerInvoiceTaxDetails> TaxDetails { get; set; }

    }
    public class PAWHSFSerInvoiceContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }

        public int invoice_rowid { get; set; }
        public PAWHSFSerInvoiceHeader Header { get; set; }

    }
    public class PAWHSFSerInvoiceApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSFSerInvoiceApplication
    {
        public PAWHSFSerInvoiceContext context { get; set; }
        public PAWHSFSerInvoiceApplicationException ApplicationException { get; set; }

    }
    #endregion


    #region save
    public class PAWHSServiceInvoiceSInvoiceDetails
    {
        public int In_invoice_details_rowid { get; set; }
        public string In_service_code { get; set; }
        public float In_qty { get; set; }
        public string In_uom_code { get; set; }
        public float In_rate { get; set; }
        public float In_amount { get; set; }
        public float In_discount { get; set; }
        public float In_tax_amount { get; set; }
        public float In_net_amount { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSServiceInvoiceSTaxDetails
    {
        public int In_taxdetails_rowid { get; set; }
        public string In_state { get; set; }
        public string In_hsn_code { get; set; }
        public float In_cgst { get; set; }
        public float In_sgst { get; set; }
        public float In_igst { get; set; }
        public float In_tax_rate { get; set; }
        public float In_taxable_amount { get; set; }
        public float In_tax_amount { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSServiceInvoiceSHeader
    {
        public int IOU_invoice_rowid { get; set; }
        public string IOU_invoice_no { get; set; }
        public string In_service_code { get; set; }
        public string In_fpo_name { get; set; }
        public string In_invoice_date { get; set; }
        public string In_customer_code { get; set; }
        public string In_customer_state { get; set; }
        public string In_provider_state { get; set; }
        public string In_output_field { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }
        public IList<PAWHSServiceInvoiceSInvoiceDetails> InvoiceDetails { get; set; }
        public IList<PAWHSServiceInvoiceSTaxDetails> TaxDetails { get; set; }

    }
    public class PAWHSServiceInvoiceSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSServiceInvoiceSHeader Header { get; set; }

    }
    public class PAWHSServiceInvoiceSDocument
    {
        public PAWHSServiceInvoiceSContext context { get; set; }

    }
    public class PAWHSServiceInvoiceSApplication
    {
        public PAWHSServiceInvoiceSDocument document { get; set; }

    }
    #endregion

}
