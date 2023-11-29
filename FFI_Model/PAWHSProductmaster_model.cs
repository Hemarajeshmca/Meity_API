using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class PAWHSProductmaster_model
    {
    }

    #region List
    public class PAWHSProductmasterRootObject
    {
        public PAWHSProductmasterContext context { get; set; }
        public PAWHSProductmasteApplicationException ApplicationException { get; set; }
    }
    public class PAWHSProductmasterApplication
    {
        public PAWHSProductmasterContext context { get; set; }
        public PAWHSProductmasteApplicationException ApplicationException { get; set; }

    }

    public class PAWHSProductmasteApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSProductmasterContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }
        //public PAWHSProductmasteFilter Filter { get; set; }
        public IList<PAWHSProductmasterList> List { get; set; }

    }
    public class PAWHSProductmasteFilter
    {
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }

    }


    public class PAWHSProductmasterList
    {
        //product_rowid, agg_code,product_code,product_name,product_category,product_subcategory,hsn_code,hsn_description
        public int Out_product_rowid { get; set; }
        public string Out_pawhs_code { get; set; }
        public string Out_agg_code { get; set; }
        public string Out_agg_name { get; set; }
        public string Out_product_code { get; set; }
        public string Out_product_name { get; set; }
        public string Out_product_name_mst { get; set; }
        public string Out_product_category_mst { get; set; }
        public string Out_product_subcategory_mst { get; set; }
        public string Out_crop_variety { get; set; }
        public string Out_crop_variety_mst { get; set; }
        public string Out_product_category { get; set; }
        public string Out_product_subcategory { get; set; }
        public string Out_hsn_code { get; set; }
        public string Out_hsn_desctiption { get; set; }
        public string Out_uomtype_code { get; set; }
        public string Out_uomtype_code_mst { get; set; }
        public string Out_value_withtax { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_row_timestamp { get; set; }

    }

    #endregion

    #region Save


    public class PAWHSProductmasterSApplication
    {
        public PAWHSProductmasterSDocument document { get; set; }


    }
    public class PAWHSProductmasterSDocument
    {
        public PAWHSProductmasterSContext context { get; set; }
        public PAWHSProductmasteApplicationException ApplicationException { get; set; }

    }

    public class PAWHSProductmasterSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        //  public PAWHSProductmasteSFilter Filter { get; set; }
        public IList<PAWHSProductmastersDetail> Detail { get; set; }

        public PAWHSProductmasterSHeader Header { get; set; }

    }


    public class PAWHSProductmasterSHeader
    {
        public int IOU_product_rowid { get; set; }
        public string In_agg_code { get; set; }
        public string IOU_pawhs_code { get; set; }
        public string In_product_code { get; set; }
        public string In_product_category { get; set; }
        public string In_product_subcategory { get; set; }
        public string In_cmb_season { get; set; }
        public string In_valuewithtax { get; set; }
        public string In_hsn_code { get; set; }
        public string In_hsn_description { get; set; }
        public string In_uomtype_code { get; set; }
        public string In_crop_variety { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }


    public class PAWHSProductmastersDetail
    {
        public int In_product_dtl_rowid { get; set; }
        public string In_pawhs_code { get; set; }
        public int In_row_slno { get; set; }
        public string In_maize_code { get; set; }
        public string In_maize_name { get; set; }
        public double In_min_value { get; set; }
        public double In_max_value { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public int IOU_product_rowid { get; set; }

    }
    #endregion


    #region Fetch 

    public class PAWHSProductmasterFApplication
    {
        //public PAWHSProductmasterFDocument document { get; set; }
        public PAWHSProductmasterFContext context { get; set; }

    }


    public class PAWHSProductmasterFContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSProductmasterFHeader Header { get; set; }
        public IList<PAWHSProductmasterFDetail> Detail { get; set; }
    }

    public class PAWHSProductmasterFHeader
    {
        public int IOU_product_rowid { get; set; }
        public string IOU_agg_code { get; set; }
        public string IOU_pawhs_code { get; set; }
        public string In_product_code { get; set; }
        public string IOU_agg_name { get; set; }
        public string In_product_name { get; set; }
        public string In_product_name_mst { get; set; }
        public string In_crop_variety { get; set; }
        public string In_crop_variety_mst { get; set; }
        public string In_product_category { get; set; }
        public string In_product_subcategory { get; set; }
        public string In_cmb_season { get; set; }
        public string In_cmb_season_mst { get; set; }
        public string In_valuewithtax { get; set; }
        public string In_hsn_code { get; set; }
        public string In_hsn_description { get; set; }
        public string In_hsn_code_mst { get; set; }
        public string In_uomtype_code { get; set; }
        public string In_uomtype_code_mst { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }
    }

    public class PAWHSProductmasterFDetail
    {
        public int In_product_dtl_rowid { get; set; }
        public string In_pawhs_code { get; set; }
        public int In_row_slno { get; set; }
        public string In_maize_code { get; set; }
        public string In_maize_name { get; set; }
        public string In_range { get; set; }
        public string In_maize_interval { get; set; }
        public string In_maize_unit { get; set; }
        public double In_min_value { get; set; }
        public double In_max_value { get; set; }

        public double In_temp_min_value { get; set; }
        public double In_temp_max_value { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }

    }

    #endregion

}
