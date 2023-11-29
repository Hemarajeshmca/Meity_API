using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class ICDMOBProduct_model
    {
    }
    #region list
    public class ICDMOBPDetail
    {
        public string In_product_code { get; set; }
        public string In_product_name { get; set; }
        public string In_productcategory_code { get; set; }
        public string In_productcategory_desc { get; set; }
        public string In_productsubcategory_code { get; set; }
        public string In_productsubcategory_desc { get; set; }
        public string In_uomtype_code { get; set; }
        public string In_uomtype_desc { get; set; }
        public string In_hsn_code { get; set; }
        public string In_hsn_desc { get; set; }
        public double In_base_price { get; set; }
        public string In_product_tax_verified { get; set; }
        public string In_value_addproduct_verified { get; set; }
        public double In_current_qty { get; set; }
        public decimal In_cgst { get; set; }
        public decimal In_sgst { get; set; }
        public decimal In_igst { get; set; }
        public string In_orgn_code { get; set; }
        public string In_ic_code { get; set; }
    }

    public class ICDMOBPContext
    {
        public string org { get; set; }
        public string locn { get; set; }
        public string user { get; set; }
        public string lang { get; set; }
        public List<ICDMOBPDetail> Detail { get; set; }
    }

    public class ICDMOBPApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }
    }

    public class ICDMOBPRoot
    {
        public ICDMOBPContext context { get; set; }
        public ICDMOBPApplicationException ApplicationException { get; set; }
    }


    #endregion

    #region paymentcollection
    public class MOBPAYHeader
    {
        public string In_invoice_no { get; set; }
        public string In_invoice_date { get; set; }
        public double In_invoice_amount { get; set; }
        public double In_balance_amount { get; set; }
    }

    public class MOBPAYDetail
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

    public class MOBPAYContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public MOBPAYHeader Header { get; set; }
        public List<MOBPAYDetail> Detail { get; set; }
    }

    public class MOBPAYApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }
    }

    public class MOBPAYRoot
    {
        public MOBPAYContext context { get; set; }
        public MOBPAYApplicationException ApplicationException { get; set; }
    }


    #endregion
}
