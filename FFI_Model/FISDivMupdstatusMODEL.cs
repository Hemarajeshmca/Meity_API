using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class FISDivMupdstatusMODEL
    {
    }

    #region filldiv

    public class fisDMPDetail
    {
        public int In_dividend_rowid { get; set; }
        public string In_share_holder_name { get; set; }
        public string In_certificate_no { get; set; }
        public string In_ditinct_from_to { get; set; }
        public Decimal In_dividend_amount { get; set; }
        public string In_payment_mode { get; set; }
        public string In_payment_mode_desc { get; set; }
        public string In_despatch_date { get; set; }
        public string In_bank_ref_no { get; set; }
        public string In_despatch_status { get; set; }
        public string In_despatch_status_desc { get; set; }
        public string In_despatch_remark { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class fisDMPContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<fisDMPDetail> Detail { get; set; }
        public string In_fpoorgn_code { get; set; }
        public string In_despatch_status { get; set; }
        public string In_despatch_date { get; set; } 

    }
    public class fisDMPApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class fisDMPApplication
    {
        public fisDMPContext context { get; set; }
        public fisDMPApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region SAVE
    public class SfisDMPHeader
    {
        public string In_fpoorgn_code { get; set; }
        public string In_despatch_status { get; set; }
        public string In_despatch_date { get; set; }

    }
    public class SfisDMPDetail
    {
        public int In_dividend_rowid { get; set; }
        public string In_certificate_no { get; set; }
        public string In_ditinct_from_to { get; set; }
        public Decimal In_dividend_amount { get; set; }
        public string In_payment_mode { get; set; }
        public string In_despatch_date { get; set; }
        public string In_bank_ref_no { get; set; }
        public string In_despatch_status { get; set; }
        public string In_despatch_remark { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class SfisDMPContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public SfisDMPHeader Header { get; set; }
        public IList<SfisDMPDetail> Detail { get; set; }

    }
    public class SfisDMPDocument
    {
        public SfisDMPContext context { get; set; }

    }
    public class SfisDMPApplication
    {
        public SfisDMPDocument document { get; set; }

    }
    #endregion
}
