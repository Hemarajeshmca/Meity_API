using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class FISTransferchange_model
    {
    }
    #region transfer fetch
    public class FISTransferchangeHeader
    {
        public int IOU_servicereq_rowid { get; set; }
        public string IOU_fpomember_code { get; set; }
        public string IOU_servicereq_no { get; set; }
        public string In_farmer_code { get; set; }
        public string In_tran_member_code { get; set; }
        public string In_tran_member_desc { get; set; }
        public string In_tran_farmer_code { get; set; }
        public string In_tran_farmer_desc { get; set; }
        public string In_tran_member_sign { get; set; }
        public string In_tran_farmer_name { get; set; }
        public string In_tran_sur_name { get; set; }
        public string In_tran_reason { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_chklist_status_flag { get; set; }
        public string In_sr_comments { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class FISTransferchangeContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FISTransferchangeHeader Header { get; set; }

    }
    public class FISTransferchangeApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class FISTransferchangeApplication
    {
        public FISTransferchangeContext context { get; set; }
        public FISTransferchangeApplicationException ApplicationException { get; set; }

    }
    #endregion

    #region save
    public class FISTransferchangeSHeader
    {
        public int IOU_servicereq_rowid { get; set; }
        public string IOU_servicereq_no { get; set; }
        public string In_fpomember_code { get; set; }
        public string In_farmer_code { get; set; }
        public string In_tran_member_code { get; set; }
        public string In_tran_farmer_code { get; set; }
        public string In_tran_member_sign { get; set; }
        public string In_tran_farmer_name { get; set; }
        public string In_tran_sur_name { get; set; }
        public string In_tran_reason { get; set; }
        public string In_status_code { get; set; }
        public string In_chklist_status_flag { get; set; }
        public string In_sr_comments { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class FISTransferchangeSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FISTransferchangeSHeader Header { get; set; }

    }
    public class FISTransferchangeSDocument
    {
        public FISTransferchangeSContext context { get; set; }
        public FISTransferchangeSApplicationException ApplicationException { get; set; }

    }
    public class FISTransferchangeSApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class FISTransferchangeSApplication
    {
        public FISTransferchangeSDocument document { get; set; }

    }
    #endregion
}
