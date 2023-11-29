using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
   public class FISNameChange_model
    {
        
    }
    #region list
    public class FISNameChangeList
    {
        public int Out_servicereq_rowid { get; set; }
        public string Out_farmer_code { get; set; }
        public string Out_fpomember_code { get; set; }
        public string Out_farmer_name { get; set; }
        public string Out_sur_name { get; set; }
        public string Out_certificate_no { get; set; }
        public string Out_issued_date { get; set; }
        public int Out_dist_from { get; set; }
        public int Out_dist_to { get; set; }
        public string Out_servicereq_no { get; set; }
        public string Out_request_date { get; set; }
        public string Out_request_type { get; set; }
        public string Out_request_type_desc { get; set; }
        public string Out_requestsub_type { get; set; }
        public string Out_requestsub_type_desc { get; set; }
        public string Out_chklist_status_flag { get; set; }
        public string Out_sr_comments { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }

    }
    public class FISNameChangeFilter
    {
        public string FilterBy_Option { get; set; }
        public string fpoorgn_code { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }
    }
    public class FISNameChangeContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FISNameChangeFilter Filter { get; set; }
        public IList<FISNameChangeList> List { get; set; }
       
    }
    public class FISNameChangeApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class FISNameChangeApplication
    {
        public FISNameChangeContext context { get; set; }
        public FISNameChangeApplicationException ApplicationException { get; set; }
    }
    #endregion

    #region fetch
    public class FISNameChangeFHeader
    {
        public int IOU_servicereq_rowid { get; set; }
        public string IOU_fpomember_code { get; set; }
        public string IOU_servicereq_no { get; set; }
        public string In_farmer_code { get; set; }
        public string In_cur_farmer_name { get; set; }
        public string In_cur_sur_name { get; set; }
        public string In_changeto_farmer_name { get; set; }
        public string In_changeto_sur_name { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_chklist_status_code { get; set; }
        public string In_sr_comments { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class FISNameChangeFContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FISNameChangeFHeader Header { get; set; }

    }
    public class FISNameChangeFApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class FISNameChangeFApplication
    {
        public FISNameChangeFContext context { get; set; }
        public FISNameChangeFApplicationException ApplicationException { get; set; }

    }
    #endregion

    #region namefetch
    public class FISNameChangeFNHeader
    {
        public string In_farmer_code { get; set; }
        public string In_farmer_name { get; set; }
        public string In_sur_name { get; set; }
        public string IOU_fpomember_code { get; set; }
        public string IOU_request_type { get; set; }

    }
    public class FISNameChangeFNShare_certificate
    {
        public int In_certificatedist_rowid { get; set; }
        public string In_certificate_no { get; set; }
        public int In_dist_from { get; set; }
        public int In_dist_to { get; set; }
        public string In_issued_date { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }

    }
    public class FISNameChangeFNRequest_history
    {
        public int In_servicereq_rowid { get; set; }
        public string In_certificate_no { get; set; }
        public string In_issued_date { get; set; }
        public string In_servicereq_no { get; set; }
        public string In_request_date { get; set; }
        public string In_request_type { get; set; }
        public string In_request_type_desc { get; set; }
        public string In_requestsub_type { get; set; }
        public string In_requestsub_type_desc { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }

    }
    public class FISNameChangeFNContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FISNameChangeFNHeader Header { get; set; }
        public IList<FISNameChangeFNShare_certificate> Share_certificate { get; set; }
        public IList<FISNameChangeFNRequest_history> Request_history { get; set; }

    }
    public class FISNameChangeFNApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class FISNameChangeFNApplication
    {
        public FISNameChangeFNContext context { get; set; }
        public FISNameChangeFNApplicationException ApplicationException { get; set; }

    }
    #endregion

    #region save
    public class FISNameChangeSHeader
    {
        public int IOU_servicereq_rowid { get; set; }
        public string IOU_servicereq_no { get; set; }
        public string In_fpomember_code { get; set; }
        public string In_farmer_code { get; set; }
        public string In_cur_farmer_name { get; set; }
        public string In_cur_sur_name { get; set; }
        public string In_changeto_farmer_name { get; set; }
        public string In_changeto_sur_name { get; set; }
        public string In_chklst_status_flag { get; set; }
        public string In_sr_comments { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class FISNameChangeSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FISNameChangeSHeader Header { get; set; }

    }
    public class FISNameChangeSDocument
    {
        public FISNameChangeSContext context { get; set; }
        public FISNameChangeSApplicationException ApplicationException { get; set; }
    }
    public class FISNameChangeSApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }

    public class FISNameChangeSApplication
    {
        public FISNameChangeSDocument document { get; set; }

    }
    #endregion
}
