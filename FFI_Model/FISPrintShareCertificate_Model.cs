using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    public class FISPrintShareCertificate_Model
    {
    }
    #region fetch
    public class PrintShareDetail
    {
        public int In_register_rowid { get; set; }
        public string In_register_no { get; set; }
        public string In_register_date { get; set; }
        public string In_farmer_code { get; set; }
        public string In_farmer_name { get; set; }
        public string In_fpomember_code { get; set; }
        public string In_member_name { get; set; }
        public string In_certificate_no { get; set; }
        public string In_folio_no { get; set; }
        public int In_applied_shares { get; set; }
        public int In_approved_shares { get; set; }
        public int In_rejected_shares { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class Register_History
    {
        public int In_register_rowid { get; set; }
        public string In_register_no { get; set; }
        public string In_certificate_no { get; set; }
        public string In_printed_date { get; set; }
        public string In_register_date { get; set; }

    }
    public class PrintShareHeader
    {
        public string In_printeddate { get; set; }
        public IList<PrintShareDetail> Detail { get; set; }
        public IList<Register_History> Register_History { get; set; }

    }
    public class PrintShareContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PrintShareHeader Header { get; set; }
        public string share_certificate { get; set; }
        public string fpoorgn_code { get; set; }

    }

    public class PrintShareApplication
    {
        public PrintShareContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }

    }
    #endregion

    #region save
    public class Headersave
    {
        public string IOU_share_certificate { get; set; }
        public string IOU_fpoorgn_code { get; set; }
        public string In_printeddate { get; set; }

    }
    public class Detailsave
    {
        public int In_register_rowid { get; set; }
        public string In_register_no { get; set; }
        public string In_farmer_code { get; set; }
        public string In_fpomember_code { get; set; }
        public string In_certificate_no { get; set; }
        public int In_applied_shares { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class Contextsave
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public Headersave Header { get; set; }
        //public IList<Detailsave> Detail { get; set; }
        public Detailsave Detail { get; set; }

    }
    public class Documentsave
    {
        public Contextsave context { get; set; }

    }
    public class Applicationsave
    {
        public Documentsave document { get; set; }

    }
    #endregion
}

