using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class FISDupRegisterModel
    {
    }

    #region Fetch
    public class FISDupRegHeader
    {
        public string In_register_type { get; set; }
        public string In_register_type_desc { get; set; }
        public string In_register_no { get; set; }
        public string In_register_date { get; set; }
        public int In_record_count { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class FISDupRegDetail
    {
        public int In_servicereq_rowid { get; set; }
        public string In_farmer_code { get; set; }
        public string In_fpomember_code { get; set; }
        public string In_member_name { get; set; }
        public string In_member_sur_name { get; set; }
        public string In_certificate_sno { get; set; }
        public string In_issued_date { get; set; }
        public int In_dist_from { get; set; }
        public int In_dist_to { get; set; }
        public string In_servicereq_no { get; set; }
        public string In_request_date { get; set; }
        public string In_request_type { get; set; }
        public string In_request_type_desc { get; set; }
        public string In_requestsub_type { get; set; }
        public string In_requestsub_type_desc { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_chklist_status_flag { get; set; }
        public string In_sr_comments { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class FISDupRegContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FISDupRegHeader Header { get; set; }
        public IList<FISDupRegDetail> Detail { get; set; }
        public Int32 In_register_rowid { get; set; }
        public string In_fpoorgn_code { get; set; }
    }
    public class FISDupRegApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class FISDupRegApplication
    {
        public FISDupRegContext context { get; set; }
        public FISDupRegApplicationException ApplicationException { get; set; }

    }

    #endregion

    #region save
    public class SFISDupRegHeader
    {
        public int IOU_register_rowid { get; set; }
        public string IOU_register_no { get; set; }
        public string In_fpoorgn_code { get; set; }
        public string In_register_type { get; set; }
        public string In_register_date { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class SFISDupRegDetail
    {
        public int In_servicereq_rowid { get; set; }
        public string In_farmer_code { get; set; }
        public string In_fpomember_code { get; set; }
        public string In_member_name { get; set; }
        public string In_member_sur_name { get; set; }
        public string In_certificate_sno { get; set; }
        public string In_issued_date { get; set; }
        public int In_dist_from { get; set; }
        public int In_dist_to { get; set; }
        public string In_servicereq_no { get; set; }
        public string In_request_date { get; set; }
        public string In_request_type { get; set; }
        public string In_requestsub_type { get; set; }
        public string In_status_code { get; set; }
        public string In_chklist_status_flag { get; set; }
        public string In_sr_comments { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class SFISDupRegContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public SFISDupRegHeader Header { get; set; }
        public IList<SFISDupRegDetail> Detail { get; set; }

    }
    public class SFISDupRegDocument
    {
        public SFISDupRegContext context { get; set; }

    }
    public class SFISDupRegApplication
    {
        public SFISDupRegDocument document { get; set; }

    }
    #endregion
}
