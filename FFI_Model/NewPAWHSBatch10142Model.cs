using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    public class BatchDetailsBasedOnDest
    {
        public List<BatchDetails> BatchDetails { get; set; }
        public List<BatchProductDetails> ProductDetails { get; set; }
        public List<BatchProductTaxDetails> ProductTaxDetails { get; set; }
    }
    public class BatchDetails
    {
        public int In_act_row_id { get; set; }
        public string In_orgn_code { get; set; }
        public string In_agg_code { get; set; }
        public string In_product_type { get; set; }
        public string In_lot_type { get; set; }
        public string In_farmer_code { get; set; }
        public string In_farmer_name { get; set; }
        public string In_item_code { get; set; }
        public string In_item_name { get; set; }
        public decimal In_actual_qty { get; set; }
        public double In_actual_price { get; set; }
        public double In_actual_value { get; set; }
        public double In_advance_amt { get; set; }
        public int In_no_of_bags { get; set; }
        public string In_hsn_code { get; set; }
        public string In_hsn_desc { get; set; }
        public string In_mode_flag { get; set; }
        public double tax_rate { get; set; }
    }

    public class BatchProductDetails
    {
        public int In_podtl_rowid { get; set; }
        public int In_sln_no { get; set; }
        public string In_po_no { get; set; }
        public string In_item_code { get; set; }
        public string In_item_name { get; set; }
        public string In_product_Variety { get; set; }
        public string In_hsn_code { get; set; }
        public string In_hsn_desc { get; set; }
        public string In_qty { get; set; }
        public string In_rate { get; set; }
        public string In_tax_rate { get; set; }
        public string In_product_amount { get; set; }
        public string In_discount { get; set; }
        public double In_othercharges { get; set; }
        public string In_tax { get; set; }
        public double In_gross_amount { get; set; }
        public string In_remarks { get; set; }
        public string In_ShipDetail { get; set; }
        public string In_unique_id { get; set; }
        public string In_cgst_rate { get; set; }
        public string In_sgst_rate { get; set; }
        public string In_igst_rate { get; set; }
        public string In_product_code { get; set; }
        public string In_mode_flag { get; set; }
    }
    public class BatchProductTaxDetails
    {
        public int In_potax_rowid { get; set; }
        public string In_po_no { get; set; }
        public string In_product_code { get; set; }
        public string In_product_name { get; set; }
        public string In_hsn_code { get; set; }
        public string In_hsn_code_desc { get; set; }
        public string In_hsn_desc { get; set; }
        public string In_cgst_rate { get; set; }
        public string In_sgst_rate { get; set; }
        public string In_sugst_rate { get; set; }
        public string In_igst_rate { get; set; }
        public string In_tax_rate { get; set; }
        public string In_taxable_amount { get; set; }
        public string In_tax_amount { get; set; }
        public string In_mode_flag { get; set; }
        public string In_tax_type { get; set; }
        public string In_status_code { get; set; }
    }

    public class BatchOtherDetails
    {
        public int In_othercost_rowid { get; set; }
        public string In_cost_type { get; set; }
        public string In_cost_name { get; set; }
        public int In_cost_value { get; set; }
        public string In_mode_flag { get; set; }
    }
    public class BatchAttachments
    {
        public int In_attch_rowid { get; set; }
        public string In_filename { get; set; }
        public string In_document { get; set; }
        public string In_description { get; set; }
        public string In_attch_date { get; set; }
        public string In_attch_upload { get; set; }
        public string In_attch_unique_id { get; set; }
        public string In_mode_flag { get; set; }
    }

    public class PAWHSNewBatchCreation_Save_Header
    {
        public int In_batch_rowid { get; set; }
        public string In_batch_no { get; set; }
        public string In_buyer_code { get; set; }
        public string In_buyer_location { get; set; }
        public string In_buyer_state_code { get; set; }
        public string In_buyer_name { get; set; }
        public string In_Vehicle_no { get; set; }
        public string In_po_no { get; set; }
        public string In_remarks { get; set; }
        public string In_mode_flag { get; set; }
    }
    public class PAWHSNewBatchCreation_Save_Context
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSNewBatchCreation_Save_Header Header { get; set; }
        public List<BatchDetails> Batch { get; set; }
        public List<BatchOtherDetails> OtherDtl { get; set; }
        public List<BatchProductDetails> Invoice { get; set; }
        public List<BatchProductTaxDetails> Tax { get; set; }
        public List<BatchAttachments> Attachment { get; set; }
    }

    public class FetchPODetails
    {
        public List<BatchProductDetails> PODetails { get; set; }
        public List<BatchProductTaxDetails> POTaxDetails { get; set; }
    }

    public class BatchCreationList
    {
        public List<PAWHSNewBatchCreation_Save_Header> NewBatchCreationList { get; set; }
    }
    public class BatchCreationSingleFetch
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSNewBatchCreation_Save_Header Header { get; set; }
        public List<BatchDetails> Batch { get; set; }
        public List<BatchOtherDetails> OtherDtl { get; set; }
        public List<BatchProductDetails> Invoice { get; set; }
        public List<BatchProductTaxDetails> Tax { get; set; }
        public List<BatchAttachments> Attachment { get; set; }
    }

    public class FetchBatchListNew
    {
        public List<FetchBatchListNewPAWHS> BatchList { get; set; }
    }
    public class FetchBatchListNewPAWHS
    {
        public int Out_batch_rowid { get; set; }
        public string Out_batch_no { get; set; }
        public string Out_batch_date { get; set; }
        public string Out_buyer_name { get; set; }
        public string Out_Vehicle_no { get; set; }

    }
}
