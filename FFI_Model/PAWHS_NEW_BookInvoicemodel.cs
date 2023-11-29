using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
  public class PAWHS_NEW_BookInvoicemodel
    {
      
    }
    #region list
    public class PAWHSBookInvoiceList
    {
        public int Out_Book_invoce_rowid { get; set; }
        public string Out_invoice_no { get; set; }
        public string Out_invoice_date { get; set; }
        public string Out_Buyer_name { get; set; }
        public string Out_Buyer_Location { get; set; }
        public string Out_po_id { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_row_timestamp { get; set; }
        public string Out_agg_code { get; set; }
        public string Out_agg_name { get; set; }

    }
    public class PAWHSBookInvoiceFilter
    {
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }

    }
    public class PAWHSBookInvoiceContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSBookInvoiceFilter Filter { get; set; }
        public IList<PAWHSBookInvoiceList> List { get; set; }

    }
    public class PAWHSBookInvoiceApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSBookInvoiceApplication
    {
        public PAWHSBookInvoiceContext context { get; set; }
        public PAWHSBookInvoiceApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region SAVE
    public class PAWHSBookInvoiceSInvoiceDetails
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
        //public Double In_discount { get; set; }
        public Double In_tax_amount { get; set; }
        public Double In_net_amount { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSBookInvoiceSTaxDetails
    {
        public int In_bitax_rowid { get; set; }        
        public string In_taxrate_rowid { get; set; }
        public string In_taxratedtl_rowid { get; set; }
        public string In_tax_sub_type { get; set; }
        public Double In_taxable_amt { get; set; }
        public Double In_tax_rate { get; set; }
        public Double In_tax_gst { get; set; }       
        public string In_mode_flag { get; set; }

    }
    public class PAWHSBookInvoiceSothercost
    {
        public int In_othercostdtl_rowid { get; set; }
        public string In_cost_type { get; set; }       
        public Double In_othercost_amt { get; set; }
        public string In_mode_flag { get; set; }

    }

    public class PAWHSBookInvoiceStransport
    {
        public int In_transdtl_rowid { get; set; }
        public string In_vehicle_no { get; set; }
        public int In_vehicle_weight { get; set; }
        public string In_prodcut_code { get; set; }
        public Double In_prodcut_qty { get; set; }
        public int In_no_of_bags { get; set; }
        public string In_location { get; set; }
        public int In_sl_no { get; set; }       
        public string In_mode_flag { get; set; }
        public IList<PAWHSBookInvoiceStransportslno> transportslno { get; set; }
    }
    public class PAWHSBookInvoiceStransportslno
    {
        public int In_slno_rowid { get; set; }
        public string In_sl_no { get; set; }
        public Double In_sl_qty { get; set; }
        public string In_UOM { get; set; }
        public string In_mode_flag { get; set; }
    }

        public class PAWHSBookInvoiceSHeader
    {
        public int IOU_invoice_rowid { get; set; }
        public string IOU_invoice_no { get; set; }
        public string In_agg_code { get; set; }
        public string In_invoice_date { get; set; }
        public string In_po_ID { get; set; }
        public string In_Buyer_Location { get; set; }
        public string In_provider_state { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }
        public Double In_tranport { get; set; }
        public Double In_discount { get; set; }
        public Double In_net_amount { get; set; }
        public IList<PAWHSBookInvoiceSInvoiceDetails> InvoiceDetails { get; set; }
        public IList<PAWHSBookInvoiceSTaxDetails> TaxDetails { get; set; }
        public IList<PAWHSBookInvoiceSothercost> othercost { get; set; }
        public IList<PAWHSBookInvoiceStransport> transport { get; set; }

    }
    public class PAWHSBookInvoiceSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSBookInvoiceSHeader Header { get; set; }
       
    }
    public class PAWHSBookInvoiceSDocument
    {
        public PAWHSBookInvoiceSContext context { get; set; }
        public PAWHSBookInvoiceSApplicationException ApplicationException { get; set; }
    }
    public class PAWHSBookInvoiceSApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSBookInvoiceSApplication
    {
        public PAWHSBookInvoiceSDocument document { get; set; }
    }
    #endregion
    #region fetch
    public class PAWHSBookInvoiceFInvoiceDetails
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
        public string In_others { get; set; }
        public Double In_tax_amount { get; set; }
        public Double In_net_amount { get; set; }
        public Double In_current_qty { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSBookInvoiceFTaxDetails
    {
        public int In_taxdetails_rowid { get; set; }
        public string In_product_code { get; set; }
        public string In_product_name { get; set; }
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
    public class PAWHSBookInvoiceFothercost
    {
        //public int In_othercostdtl_rowid { get; set; }
        //public string In_cost_type { get; set; }
        //public string In_cost_type_desc { get; set; }
        //public Double In_othercost_amt { get; set; }        
        //public string In_mode_flag { get; set; }
        public int In_othercost_rowid { get; set; }
        public string In_cost_type { get; set; }
        public string In_cost_name { get; set; }
        public Double In_cost_value { get; set; }
        public string In_mode_flag { get; set; }
    }
    public class PAWHSBookInvoiceFtransport
    {
        public int In_transdtl_rowid { get; set; }
        public string In_vehicle_no { get; set; }
        public string In_vehicle_weight { get; set; }
        public string In_prodcut_code { get; set; }
        public Double In_prodcut_qty { get; set; }
        public string In_location { get; set; }
        public int In_no_of_bags { get; set; }
        public int In_sl_no { get; set; }       
        public string In_mode_flag { get; set; }

    }
    public class PAWHSBookInvoiceFHeader
    {
        public int IOU_invoice_rowid { get; set; }       
        public string In_invoice_date { get; set; }
        public string In_invoice_no { get; set; }
        public string In_buyer_code { get; set; }
        public string In_buyer_name { get; set; }
        public string In_customer_state { get; set; }
        public string In_provider_state { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_po_no { get; set; }
        public string In_po_date { get; set; }
        public string In_agg_code { get; set; }
        public string In_agg_name { get; set; }
        public Double In_Transport_Amt { get; set; }
        public Double In_Discount_Amt { get; set; }
        public Double In_net_amount { get; set; }
        public Double In_bal_amount { get; set; }
        public IList<PAWHSBookInvoiceFInvoiceDetails> InvoiceDetails { get; set; }
        public IList<PAWHSBookInvoiceFTaxDetails> TaxDetails { get; set; }
        public IList<PAWHSBookInvoiceFothercost> othercost { get; set; }
        public IList<PAWHSBookInvoiceFtransport> transport { get; set; }

    }
    public class PAWHSBookInvoiceFContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public int IOU_invoice_rowid { get; set; }
        public PAWHSBookInvoiceFHeader Header { get; set; }

    }

    public class PAWHSBookInvoiceFApplication
    {
        public PAWHSBookInvoiceFContext context { get; set; }
        public PAWHSBookInvoiceFApplicationException ApplicationException { get; set; }

    }
    public class PAWHSBookInvoiceFApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    #endregion
    #region  new product fetch
    public class PAWHSBookInvoicenewProductDetail
    {
        public string In_ic_code { get; set; }
        public string In_product_code { get; set; }
        public string In_product_name { get; set; }
        public string In_uomtype_code { get; set; }
        public string In_uomtype_desc { get; set; }
        public string In_qty { get; set; }
        public string In_rate { get; set; }
        public string In_amount { get; set; }
        public string In_tax_amount { get; set; }
        public Double In_net_amount { get; set; }
        public string In_discount { get; set; }
        public string In_others { get; set; }


    }
    public class PAWHSBookInvoicenewInvoiceTax
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

    public class PAWHSBookInvoicenewProductContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public string In_location_code { get; set; }
        public string In_po_no { get; set; }
        public IList<PAWHSBookInvoicenewProductDetail> Detail { get; set; }
        public IList<PAWHSBookInvoicenewInvoiceTax> InvoiceTax { get; set; }
        public List<BIBatchOtherDetails> OtherDtl { get; set; }

    }
    public class BIBatchOtherDetails
    {
        public int In_othercost_rowid { get; set; }
        public string In_cost_type { get; set; }
        public string In_cost_name { get; set; }
        public Double In_cost_value { get; set; }
        public string In_mode_flag { get; set; }
    }


    public class PAWHSBookInvoicenewProductApplication
    {
        public PAWHSBookInvoicenewProductContext context { get; set; }
        public PAWHSBookInvoiceApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region product fetch
    public class PAWHSBookInvoiceProductDetail
    {
        public string In_ic_code { get; set; }
        public string In_productcategory { get; set; }
        public string In_productcategory_desc { get; set; }
        public string In_productsubcategory { get; set; }
        public string In_productsubcategory_desc { get; set; }
        public string In_product_code { get; set; }
        public string In_product_name { get; set; }
        public string In_uomtype_code { get; set; }
        public string In_uomtype_desc { get; set; }
        public Double In_tax_rate { get; set; }
        public Double In_base_price { get; set; }
        public Double In_current_qty { get; set; }

    }
    public class PAWHSBookInvoiceInvoiceTax
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

    public class PAWHSBookInvoiceProductContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public string In_location_code { get; set; }
        public string In_po_no { get; set; }
        public IList<PAWHSBookInvoiceProductDetail> Detail { get; set; }
        public IList<PAWHSBookInvoiceInvoiceTax> InvoiceTax { get; set; }


    }


    public class PAWHSBookInvoiceProductApplication
    {
        public PAWHSBookInvoiceProductContext context { get; set; }
        public PAWHSBookInvoiceApplicationException ApplicationException { get; set; }

    }
    #endregion

    #region transslno
    public class PAWHSBookInvoiceFTRANSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public int In_transdtl_rowid { get; set; }
        public IList<PAWHSBookInvoiceFtransportslno> transport { get; set; }

    }
    public class PAWHSBookInvoiceFtransportslno
    {
        public int In_slno_rowid { get; set; }
        public string In_sl_no { get; set; }
        public string In_sl_qty { get; set; }
        public string In_UOM { get; set; }
        public string In_mode_flag { get; set; }
    }
    public class PAWHSBookInvoiceFTRANS
    {
        public PAWHSBookInvoiceFTRANSContext context { get; set; }      
    }
    #endregion
    #region PO location search
    public class POLocContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSPO_FHeader Header { get; set; }
        public int IOU_PO_rowid { get; set; }
        public string In_po_no { get; set; }

    }
    public class PAWHSPO_FHeader
    {
        public string In_buyer_location { get; set; }
        public string In_buyer_location_code { get; set; }
        public string In_buyer_date { get; set; }

    }
    public class POLocApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class POLocApplication
    {
        public POLocContext context { get; set; }
        public POLocApplicationException ApplicationException { get; set; }

    }
    #endregion
}
