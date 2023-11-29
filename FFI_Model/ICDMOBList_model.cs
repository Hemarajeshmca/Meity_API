using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class ICDMOBList_model
    {
    }
    #region adjust count
    public class ADJCOUNTList
    {
        public string grn_or_invoice_no { get; set; }
        public int adjustment_qty { get; set; }
        public string product_code { get; set; }
        public string product_name { get; set; }
        public int adjusted_qty { get; set; }
        public int avl_adjust_qty { get; set; }
        public string product_price { get; set; }
    }

    public class ADJCOUNTContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public List<ADJCOUNTList> List { get; set; }
    }

    public class ADJCOUNTApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }
    }

    public class ADJCOUNTRoot
    {
        public ADJCOUNTContext context { get; set; }
        public ADJCOUNTApplicationException ApplicationException { get; set; }
    }


    #endregion

    #region suplier list
    public class ICDMOBSList
    {
        public int In_supplier_rowid { get; set; }
        public string In_supplier_code { get; set; }
        public int In_version_no { get; set; }
        public string In_supplier_name { get; set; }
        public string In_pan_no { get; set; }
        public string In_supplier_state_code { get; set; }
        public string In_supplier_state_desc { get; set; }
        public string In_supplier_location { get; set; }
        public string In_ic_code { get; set; }
        public string In_status_code { get; set; }
        public string In_row_timestamp { get; set; }
    }

    public class ICDMOBSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public List<ICDMOBSList> List { get; set; }
    }

    public class ICDMOBSApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }
    }

    public class ICDMOBSRoot
    {
        public ICDMOBSContext context { get; set; }
        public ICDMOBSApplicationException ApplicationException { get; set; }
    }


    #endregion

    #region icdcustomerlist
    public class ICDMOBCustomerList
    {
        public string farmer_code { get; set; }
        public string farmer_name { get; set; }
        public string sur_name { get; set; }
        public string fhw_name { get; set; }
        public string village_name { get; set; }
        public string farmer_address { get; set; }
        public string state_name { get; set; }
        public string farmer_village_code { get; set; }
        public string farmer_state_code { get; set; }
        public string phone_no { get; set; }
        public string ic_code { get; set; }

        
    }

    public class ICDMOBCContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public List<ICDMOBCustomerList> CustomerList { get; set; }
    }

    public class ICDMOBApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }
    }

    public class ICDMOBCRoot
    {
        public ICDMOBCContext context { get; set; }
        public ICDMOBApplicationException ApplicationException { get; set; }
    }


    #endregion

    #region transaction
    public class ICDMOBTHeader
    {
        public string In_inward_no { get; set; }
        public string In_invoice_no { get; set; }
        public string In_adjustment_no { get; set; }
        public string In_ic_code { get; set; }
        
    }

    public class ICDMOBTContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public ICDMOBTHeader Header { get; set; }
    }

    public class ICDMOBTApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }
    }

    public class ICDMOBTRoot
    {
        public ICDMOBTContext context { get; set; }
        public ICDMOBTApplicationException ApplicationException { get; set; }
    }


    #endregion
}
