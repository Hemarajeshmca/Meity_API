using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class FISUpdateservice_model
    {
    }
    #region fetch
    public class FISUpdateserviceDetail
    {
        public int In_servicereq_rowid { get; set; }
        public string In_servicereq_no { get; set; }
        public string In_servicereq_date { get; set; }
        public string In_request_type { get; set; }
        public string In_request_type_desc { get; set; }
        public string In_requestsub_type { get; set; }
        public string In_requestsub_type_desc { get; set; }
        public string In_farmer_name { get; set; }
        public string In_sur_name { get; set; }
        public string In_certificate_sno { get; set; }
        public string In_Approvaldate { get; set; }
        public string In_processstatus { get; set; }
        public string In_process_status_desc { get; set; }
        public string In_reject_comments { get; set; }
        public string In_sr_comments { get; set; }
        public string In_certificate_no { get; set; }
        public string In_certificate_desc { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_chklist_status_flag { get; set; }

    }
    public class FISUpdateserviceHeader
    {
        public string In_fpoorgn_code { get; set; }
        public string In_process_status { get; set; }
        public string In_Approval_date { get; set; }
    }
    public class FISUpdateserviceContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FISUpdateserviceHeader Header { get; set; }
        public IList<FISUpdateserviceDetail> Detail { get; set; }

    }
    public class FISUpdateserviceApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class FISUpdateserviceApplication
    {
        public FISUpdateserviceContext context { get; set; }
        public FISUpdateserviceApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region save
    public class FISUpdateserviceSHeader
    {
        public string In_fpoorgn_code { get; set; }
        public string In_process_status { get; set; }
        public string In_Approval_date { get; set; }

    }
    public class FISUpdateserviceSDetail
    {
        public int In_servicereq_rowid { get; set; }
        public string In_servicereq_no { get; set; }
        public string In_request_type { get; set; }
        public string In_requestsub_type { get; set; }
        public string In_farmer_name { get; set; }
        public string In_sur_name { get; set; }
        public string In_certificate_sno { get; set; }
        public string In_Approvaldate { get; set; }
        public string In_processstatus { get; set; }
        public string In_reject_comments { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_chklist_status_flag { get; set; }
        public string In_sr_comments { get; set; }

    }
    public class FISUpdateserviceSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FISUpdateserviceSHeader Header { get; set; }
        public IList<FISUpdateserviceSDetail> Detail { get; set; }

    }
    public class FISUpdateserviceSDocument
    {
        public FISUpdateserviceSContext context { get; set; }
        public FISUpdateserviceSApplicationException ApplicationException { get; set; }
}
    public class FISUpdateserviceSApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class FISUpdateserviceSApplication
    {
        public FISUpdateserviceSDocument document { get; set; }

    }
    #endregion
}
