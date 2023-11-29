using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class PAWHSWarehouseMaster_Model
    {
    }
    public class WarehouseMstList
    {
        public int Out_whs_rowid { get; set; }
        public string Out_agg_code { get; set; }
        public string Out_whs_code { get; set; }
        public string Out_whs_type { get; set; }
        public string Out_whs_name { get; set; }
        public string Out_whs_addr1 { get; set; }
        public string Out_whs_addr2 { get; set; }
        public string Out_whs_country { get; set; }
        public string Out_whs_state { get; set; }
        public string Out_whs_dist { get; set; }
        public string Out_whs_taluk { get; set; }
        public string Out_whs_panchayat { get; set; }
        public string Out_whs_village { get; set; }
        public string Out_whs_pincode { get; set; }
        public int Out_sqrf_area { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_row_timestamp { get; set; }

    }
    public class WarehouseMstFarmerFilter
    {
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }
        public int out_record_count { get; set; }
        public int from_index { get; set; }
        public int to_index { get; set; }
        public int record_count { get; set; }
    }
    public class WarehouseMstContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public WarehouseMstFarmerFilter Filter { get; set; }
        public IList<WarehouseMstList> List { get; set; }

    }
  
    public class WarehouseMstApplication
    {
        public WarehouseMstContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }

    }
    public class WarehouseMstHeader
    {
        public int IOU_whs_rowid { get; set; }
        public string IOU_agg_code { get; set; }
        public string IOU_whs_code { get; set; }
        public string In_whs_type { get; set; }
        public string In_whs_name { get; set; }
        public string In_whs_addr1 { get; set; }
        public string In_whs_addr2 { get; set; }
        public string In_whs_country { get; set; }
        public string In_whs_country_desc { get; set; }
        public string In_whs_state { get; set; }
        public string In_whs_state_desc { get; set; }
        public string In_whs_dist { get; set; }
        public string In_whs_dist_desc { get; set; }
        public string In_whs_taluk { get; set; }
        public string In_whs_taluk_desc { get; set; }
        public string In_whs_panchayat { get; set; }
        public string In_whs_panchayat_desc { get; set; }
        public string In_whs_village { get; set; }
        public string In_whs_village_desc { get; set; }
        public string In_whs_pincode { get; set; }
        public int In_sqrf_area { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class WarehouseMstSingleContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public int IOU_whs_rowid { get; set; }
        public string IOU_agg_code { get; set; }
        public string IOU_whs_code { get; set; }
        public WarehouseMstHeader Header { get; set; }

    }

    public class WarehouseMstSingleApplication
    {
        public WarehouseMstSingleContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }

    }
    public class WarehouseMstSaveHeader
    {
        public int IOU_whs_rowid { get; set; }
        public string In_agg_code { get; set; }
        public string IOU_whs_code { get; set; }
        public string In_whs_type { get; set; }
        public string In_whs_name { get; set; }
        public string In_whs_addr1 { get; set; }
        public string In_whs_addr2 { get; set; }
        public string In_whs_country { get; set; }
        public string In_whs_state { get; set; }
        public string In_whs_dist { get; set; }
        public string In_whs_taluk { get; set; }
        public string In_whs_panchayat { get; set; }
        public string In_whs_village { get; set; }
        public string In_whs_pincode { get; set; }
        public int In_sqrf_area { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class WarehouseMstSaveContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public WarehouseMstSaveHeader Header { get; set; }

    }
    public class WarehouseMstDocument
    {
        public WarehouseMstSaveContext context { get; set; }

    }
    public class WarehouseMstSaveApplication
    {
        public WarehouseMstDocument document { get; set; }

    }
}
