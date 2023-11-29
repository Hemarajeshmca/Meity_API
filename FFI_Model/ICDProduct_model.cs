using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class ICDProduct_model
    {
      
    }

    #region list
    public class ICDProductList
    {
        public int Out_product_rowid { get; set; }
        public string Out_product_catg_code { get; set; }
        public string Out_product_catg_desc { get; set; }
        public string Out_product_subcatg_code { get; set; }
        public string Out_product_subcatg_desc { get; set; }
        public string Out_product_code { get; set; }
        public string Out_product_name { get; set; }
        public string Out_product_tax_verified { get; set; }
        public string Out_gstrate_verified { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_base_price { get; set; }
        public string Out_ic_name { get; set; }

    }
    public class ICDProductContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<ICDProductList> List { get; set; }
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }

    }
    public class ICDProductApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class ICDProductApplication
    {
        public ICDProductContext context { get; set; }
        public ICDProductApplicationException ApplicationException { get; set; }

    }
    #endregion

    #region fetch
    public class ICDProduct_Detail
    {
        public int IOU_product_rowid { get; set; }
        public string In_orgn_code { get; set; }
        public string In_ic_code { get; set; }
        public string In_ic_name { get; set; }
        public int In_taxrate_rowid { get; set; }
        public string In_product_catg_code { get; set; }
        public string In_product_catg_desc { get; set; }
        public string In_product_subcatg_code { get; set; }
        public string In_product_subcatg_desc { get; set; }
        public string In_product_code { get; set; }
        public string In_product_name { get; set; }
        public string In_hsn_code { get; set; }
        public string In_hsn_description { get; set; }
        public float In_base_price { get; set; }
        public float In_base_price_extax { get; set; }
        public float In_base_price_intax { get; set; }
        public string In_productwithtax { get; set; }
        public string In_valuewithtax { get; set; }
        public string In_gstrate { get; set; }
        public float In_current_qty { get; set; }
        public string In_uomtype_code { get; set; }
        public string In_uomtype_desc { get; set; }
        public string In_effective_from { get; set; }
        public string In_effective_to { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class ICDProduct_FContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public ICDProduct_Detail Detail { get; set; }
        public int product_rowid { get; set; }


    }
    public class ICDProduct_FApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class ICDProduct_FApplication
    {
        public ICDProduct_FContext context { get; set; }
        public ICDProduct_FApplicationException ApplicationException { get; set; }

    }
    #endregion

    #region save
    public class ICDProduct_SDetail
    {
        public int IOU_product_rowid { get; set; }
        public string In_orgn_code { get; set; }
        public string In_ic_code { get; set; }
        public int In_taxrate_rowid { get; set; }
        public string In_product_catg_code { get; set; }
        public string In_product_subcatg_code { get; set; }
        public string In_product_code { get; set; }
        public int In_current_product { get; set; }
        public string In_hsn_code { get; set; }
        public string In_hsn_description { get; set; }
        public float In_base_price { get; set; }
        public float In_base_price_extax { get; set; }
        public float In_base_price_intax { get; set; }
        public string In_productwithtax { get; set; }
        public string In_valuewithtax { get; set; }
        public string In_gstrate { get; set; }
        public float In_current_qty { get; set; }
        public string In_uomtype_code { get; set; }
        public string In_effective_from { get; set; }
        public string In_effective_to { get; set; }
        public string In_status_code { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }
        public string In_product_name { get; set; }
        public string In_product_code1 { get; set; }
        public string errorNo { get; set; }

    } 
    public class ICDProduct_SContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public ICDProduct_SDetail Detail { get; set; }

    }
    public class ICDProduct_Document
    {
        public ICDProduct_SContext context { get; set; }
        public ICDProductSAApplicationException ApplicationException { get; set; }

    }
    public class ICDProduct_SApplication
    {
        public ICDProduct_Document document { get; set; }

    }
    public class ICDProductSAApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    #endregion
}
