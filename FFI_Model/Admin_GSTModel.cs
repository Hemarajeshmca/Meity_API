using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class Admin_GSTModel
    {
    }
    #region List
    public class GST
    {
        public int Out_taxrate_rowid { get; set; }
        public string Out_provider_location { get; set; }
        public string Out_provider_location_desc { get; set; }
        public string Out_reciver_location { get; set; }
        public string Out_reciver_location_desc { get; set; }
        public string Out_hsn_code { get; set; }
        public string Out_hsn_category_code { get; set; }
        public string Out_hsn_category { get; set; }
        public string Out_hsn_description { get; set; }
        public string Out_status_desc { get; set; }
    }

    public class GSTContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public List<GST> List { get; set; }
    }
    public class GSTList
    {
        public GSTContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion

    #region SingleFetch
    public class FetchGSTHeader
    {
        public int IOU_taxrate_rowid { get; set; }
        public string IOU_provider_location { get; set; }
        public string In_provider_location_desc { get; set; }
        public string In_reciver_location { get; set; }
        public string In_reciver_location_desc { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }
    }

    public class FetchGSTDetail
    {
        public int In_taxratedtl_rowid { get; set; }
        public string In_hsn_code { get; set; }
        public string In_hsn_category_code { get; set; }
        public string In_hsn_category { get; set; }
        public string In_hsn_description { get; set; }
        public double In_cgst_rate { get; set; }
        public double In_sgst_rate { get; set; }
        public double In_igst_rate { get; set; }
        public double In_ugst_rate { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
    }

    public class FetchGSTContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FetchGSTHeader Header { get; set; }
        public List<FetchGSTDetail> Detail { get; set; }
    }
    public class FetchGST
    {
        public FetchGSTContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion

    #region SaveInput
    public class SaveGSTHeader
    {
        public int IOU_taxrate_rowid { get; set; }
        public string In_provider_location { get; set; }
        public string In_reciver_location { get; set; }
        public string In_status_code { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }
    }

    public class SaveGSTDetail
    {
        public int In_taxratedtl_rowid { get; set; }
        public string In_hsn_code { get; set; }
        public string In_hsn_category_code { get; set; }
        public string In_hsn_description { get; set; }
        public float In_cgst_rate { get; set; }
        public float In_sgst_rate { get; set; }
        public float In_igst_rate { get; set; }
        public float In_ugst_rate { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
    }

    public class SaveGSTContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public SaveGSTHeader Header { get; set; }
        public List<SaveGSTDetail> Detail { get; set; }
    }

    public class SaveGSTDocument
    {
        public SaveGSTContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }

    public class SaveGST
    {
        public SaveGSTDocument document { get; set; }
    }

    #endregion
    #region output
    public class OutGSTHeader
    {
        public int IOU_taxrate_rowid { get; set; }
    }

    public class OutGSTContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public OutGSTHeader Header { get; set; }
    }
    public class OutGST
    {
        public OutGSTContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }

    #endregion
}
