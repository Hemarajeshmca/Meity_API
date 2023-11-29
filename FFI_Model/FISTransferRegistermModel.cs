using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class FISTransferRegistermModel
    {
    }

    #region fetch
    public class FISTrnregHeader
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
    public class FISTrnregDetail
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
    public class FISTrnregContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FISTrnregHeader Header { get; set; }
        public IList<FISTrnregDetail> Detail { get; set; }
        public Int32 In_register_rowid { get; set; }
        public string In_fpoorgn_code { get; set; }

    }
    public class FISTrnregApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class FISTrnregApplication
    {
        public FISTrnregContext context { get; set; }
        public FISTrnregApplicationException ApplicationException { get; set; }

    }
    #endregion


    #region save
    public class SFISTrnregHeader
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
    public class SFISTrnregDetail
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
    public class SFISTrnregContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public SFISTrnregHeader Header { get; set; }
        public IList<SFISTrnregDetail> Detail { get; set; }

    }
    public class SFISTrnregDocument
    {
        public SFISTrnregContext context { get; set; }

    }
    public class SFISTrnregApplication
    {
        public SFISTrnregDocument document { get; set; }

    }
    #endregion
}
