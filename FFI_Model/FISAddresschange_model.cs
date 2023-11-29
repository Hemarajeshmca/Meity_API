using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class FISAddresschange_model
    {
    }
    #region address fetch
    public class FISAddressChangeHeader
    {
        public int IOU_servicereq_rowid { get; set; }
        public string IOU_fpomember_code { get; set; }
        public string IOU_servicereq_no { get; set; }
        public string In_farmer_code { get; set; }
        public string In_current_member_addr1 { get; set; }
        public string In_current_member_addr2 { get; set; }
        public string In_current_member_state { get; set; }
        public string In_current_member_state_desc { get; set; }
        public string In_current_member_village { get; set; }
        public string In_current_member_village_desc { get; set; }
        public string In_current_member_panchayat { get; set; }
        public string In_current_member_panchayat_desc { get; set; }
        public string In_current_member_taluk { get; set; }
        public string In_current_member_taluk_desc { get; set; }
        public string In_current_member_dist { get; set; }
        public string In_current_member_dist_desc { get; set; }
        public string In_current_member_pincode { get; set; }
        public string In_change_member_addr1 { get; set; }
        public string In_change_member_addr2 { get; set; }
        public string In_change_member_state { get; set; }
        public string In_change_member_state_desc { get; set; }
        public string In_change_member_village { get; set; }
        public string In_change_member_village_desc { get; set; }
        public string In_change_member_panchayat { get; set; }
        public string In_change_member_panchayat_desc { get; set; }
        public string In_change_member_taluk { get; set; }
        public string In_change_member_taluk_desc { get; set; }
        public string In_change_member_dist { get; set; }
        public string In_change_member_dist_desc { get; set; }
        public string In_change_member_pincode { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_chklist_status_flag { get; set; }
        public string In_sr_comments { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class FISAddressChangeContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FISAddressChangeHeader Header { get; set; }

    }
    public class FISAddressChangeApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class FISAddressChangeApplication
    {
        public FISAddressChangeContext context { get; set; }
        public FISAddressChangeApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region address save
    public class FISAddressChangeSHeader
    {
        public int IOU_servicereq_rowid { get; set; }
        public string IOU_servicereq_no { get; set; }
        public string In_fpomember_code { get; set; }
        public string In_farmer_code { get; set; }
        public string In_current_member_addr1 { get; set; }
        public string In_current_member_addr2 { get; set; }
        public string In_current_member_state { get; set; }
        public string In_current_member_village { get; set; }
        public string In_current_member_panchayat { get; set; }
        public string In_current_member_taluk { get; set; }
        public string In_current_member_dist { get; set; }
        public string In_current_member_pincode { get; set; }
        public string In_change_member_addr1 { get; set; }
        public string In_change_member_addr2 { get; set; }
        public string In_change_member_state { get; set; }
        public string In_change_member_village { get; set; }
        public string In_change_member_panchayat { get; set; }
        public string In_change_member_taluk { get; set; }
        public string In_change_member_dist { get; set; }
        public string In_change_member_pincode { get; set; }
        public string In_status_code { get; set; }
        public string In_chklist_status_flag { get; set; }
        public string In_sr_comments { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class FISAddressChangeSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FISAddressChangeSHeader Header { get; set; }

    }
    public class FISAddressChangeSDocument
    {
        public FISAddressChangeSContext context { get; set; }
        public FISAddressChangeSApplicationException ApplicationException { get; set; }
    }
    public class FISAddressChangeSApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class FISAddressChangeSApplication
    {
        public FISAddressChangeSDocument document { get; set; }

    }
    #endregion
}
