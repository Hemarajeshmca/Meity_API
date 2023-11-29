using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class FISDublicateReq_model
    {
    }
    #region dub req fetch
    public class FISDublicateReqHeader
    {
        public int IOU_servicereq_rowid { get; set; }
        public string IOU_fpomember_code { get; set; }
        public string IOU_servicereq_no { get; set; }
        public string In_farmer_code { get; set; }
        public string In_dup_certificate_reason { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_chklist_status_flag { get; set; }
        public string In_sr_comments { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class FISDublicateReqContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FISDublicateReqHeader Header { get; set; }

    }
    public class FISDublicateReqApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class FISDublicateReqApplication
    {
        public FISDublicateReqContext context { get; set; }
        public FISDublicateReqApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region dub save
    public class FISDublicateReqSHeader
    {
        public int IOU_servicereq_rowid { get; set; }
        public string IOU_servicereq_no { get; set; }
        public string In_fpomember_code { get; set; }
        public string In_farmer_code { get; set; }
        public string In_dup_certificate_reason { get; set; }
        public string In_status_code { get; set; }
        public string In_chklist_status_flag { get; set; }
        public string In_sr_comments { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class FISDublicateReqSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FISDublicateReqSHeader Header { get; set; }

    }
    public class FISDublicateReqSDocument
    {
        public FISDublicateReqSContext context { get; set; }
        public FISDublicateReqSApplicationException ApplicationException { get; set; }
    }
    public class FISDublicateReqSApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class FISDublicateReqSApplication
    {
        public FISDublicateReqSDocument document { get; set; }

    }
    #endregion
}
