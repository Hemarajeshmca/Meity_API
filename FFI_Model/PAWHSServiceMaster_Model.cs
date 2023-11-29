using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class PAWHSServiceMaster_Model
    {

    }
    #region list
    public class ServiceMasterList
    {
        public int Out_service_rowid { get; set; }
        public string Out_agg_code { get; set; }
        public string Out_service_code { get; set; }
        public string Out_service_name { get; set; }
        public string Out_service_ll_name { get; set; }
        public string Out_hsn_code { get; set; }
        public string Out_hsn_description { get; set; }
        public decimal Out_rate { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_row_timestamp { get; set; }

    }
    public class SrviceMasterContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }

        public IList<ServiceMasterList> List { get; set; }
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }

    }
   
    public class ServiceMasterApplication
    {
        public SrviceMasterContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }

    }

    #endregion

    #region fetch
    public class FetchServiceMasterHeader
    {
        public int IOU_service_rowid { get; set; }
        public string IOU_agg_code { get; set; }
        public string IOU_service_code { get; set; }
        public string In_service_name { get; set; }
        public string In_service_ll_name { get; set; }
        public string In_output_name_code { get; set; }
        public string In_output_name_desc { get; set; }
        public string In_hsn_code { get; set; }
        public string In_hsn_description { get; set; }
        public Double In_rate { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class FetchServiceMasterContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FetchServiceMasterHeader Header { get; set; }
        public int service_rowid { get; set; }
        public string agg_code { get; set; }
        public string service_code { get; set; }
    }
  
    public class FetchServiceMasterApplication
    {
        public FetchServiceMasterContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }

    }
    #endregion

    #region save 
    public class SaveServiceMasterHeader
    {
        public int IOU_service_rowid { get; set; }
        public string In_agg_code { get; set; }
        public string IOU_service_code { get; set; }
        public string In_service_name { get; set; }
        public string In_service_ll_name { get; set; }
        public string In_output_name_code { get; set; }
        public string In_hsn_code { get; set; }
        public string In_hsn_description { get; set; }
        public float In_rate { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class SaveServiceMasterContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public SaveServiceMasterHeader Header { get; set; }

    }
    public class SaveServiceMasterDocument
    {
        public SaveServiceMasterContext context { get; set; }

    }
    public class SaveServiceMasterApplication
    {
        public SaveServiceMasterDocument document { get; set; }

    }
    #endregion
}
