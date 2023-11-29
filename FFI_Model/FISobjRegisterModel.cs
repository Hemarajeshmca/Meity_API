using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class FISobjRegisterModel
    {
    }

    #region fetch
    public class fisobregisHeader
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
    public class fisobregisDetail
    {
        public int In_servicereq_rowid { get; set; }
        public string In_farmer_code { get; set; }
        public string In_fpomember_code { get; set; }
        public string In_member_name { get; set; }
        public string In_member_sur_name { get; set; }
        public string In_certificate_sno { get; set; }
        public string In_issued_date { get; set; }
        public string In_dist_from { get; set; }
        public string In_dist_to { get; set; }
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
    public class fisobregisContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public fisobregisHeader Header { get; set; }
        public IList<fisobregisDetail> Detail { get; set; }
        public Int32 register_rowid { get; set; }
        public string fpoorgn_code { get; set; }

    }
    public class fisobregisApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class fisobregisApplication
    {
        public fisobregisContext context { get; set; }
        public fisobregisApplicationException ApplicationException { get; set; }

    }
    #endregion

    #region SAVE
    public class SfisobregisHeader
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
    public class SfisobregisDetail
    {
        public int In_servicereq_rowid { get; set; }
        public string In_farmer_code { get; set; }
        public string In_fpomember_code { get; set; }
        public string In_member_name { get; set; }
        public string In_member_sur_name { get; set; }
        public string In_certificate_sno { get; set; }
        public string In_issued_date { get; set; }
        public string In_dist_from { get; set; }
        public string In_dist_to { get; set; }
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
    public class SfisobregisContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public SfisobregisHeader Header { get; set; }
        public IList<SfisobregisDetail> Detail { get; set; }

    }
    public class SfisobregisDocument
    {
        public SfisobregisContext context { get; set; }

    }
    public class SfisobregisApplication
    {
        public SfisobregisDocument document { get; set; }

    }
    #endregion
}
