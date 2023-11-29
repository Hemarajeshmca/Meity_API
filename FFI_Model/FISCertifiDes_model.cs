using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class FISCertifiDes_model
    {
    }
    #region fetch
    public class FISCertifiDesDetail
    {
        public string In_sel_flag { get; set; }
        public int In_servicereq_rowid { get; set; }
        public string In_servicereq_no { get; set; }
        public string In_request_date { get; set; }
        public string In_request_type { get; set; }
        public string In_request_type_desc { get; set; }
        public string In_farmer_name { get; set; }
        public string In_sur_name { get; set; }
        public string In_certificate_sno { get; set; }
        public string In_distinct_from_to { get; set; }
        public string In_printed_on { get; set; }
        public string In_despatch_date { get; set; }
        public string In_despatch_awb_no { get; set; }
        public string In_processstatus { get; set; }
        public string In_process_status_desc { get; set; }
        public string In_despatch_remark { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_chklist_status_flag { get; set; }
        public string In_sr_comments { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class FISCertifiDesHeader
    {
        public string In_fpoorgn_code { get; set; }
        public string In_process_status { get; set; }

    }
    public class FISCertifiDesContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FISCertifiDesHeader Header { get; set; }
        public IList<FISCertifiDesDetail> Detail { get; set; }

    }
    public class FISCertifiDesApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class FISCertifiDesApplication
    {
        public FISCertifiDesContext context { get; set; }
        public FISCertifiDesApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region save
    public class FISCertifiDesSHeader
    {
        public string In_fpoorgn_code { get; set; }
        public string In_process_status { get; set; }

    }
    public class FISCertifiDesSDetail
    {
        public int In_servicereq_rowid { get; set; }
        public string In_servicereq_no { get; set; }
        public string In_request_date { get; set; }
        public string In_request_type { get; set; }
        public string In_farmer_name { get; set; }
        public string In_sur_name { get; set; }
        public string In_certificate_sno { get; set; }
        public string In_distinct_from_to { get; set; }
        public string In_printed_on { get; set; }
        public string In_despatch_date { get; set; }
        public string In_despatch_awb_no { get; set; }
        public string In_processstatus { get; set; }
        public string In_despatch_remark { get; set; }
        public string In_status_code { get; set; }
        public string In_chklist_status_flag { get; set; }
        public string In_sr_comments { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class FISCertifiDesSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FISCertifiDesSHeader Header { get; set; }
        public IList<FISCertifiDesSDetail> Detail { get; set; }

    }
    public class FISCertifiDesSDocument
    {
        public FISCertifiDesSContext context { get; set; }
        public FISCertifiDesSApplicationException ApplicationException { get; set; }
    }
    public class FISCertifiDesSApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class FISCertifiDesSApplication
    {
        public FISCertifiDesSDocument document { get; set; }

    }
    #endregion


}
