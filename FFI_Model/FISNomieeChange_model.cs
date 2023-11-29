using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class FISNomieeChange_model
    {
    }
    #region nomiee fetch
    public class FISNomieeChangeHeader
    {
        public int IOU_servicereq_rowid { get; set; }
        public string IOU_fpomember_code { get; set; }
        public string IOU_servicereq_no { get; set; }
        public string In_farmer_code { get; set; }
        public string In_cur_member_nominee { get; set; }
        public string In_changeto_member_nominee { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_chklist_status_flag { get; set; }
        public string In_sr_comments { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class FISNomieeChangeContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FISNomieeChangeHeader Header { get; set; }

    }
    public class FISNomieeChangeApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class FISNomieeChangeApplication
    {
        public FISNomieeChangeContext context { get; set; }
        public FISNomieeChangeApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region save
    public class FISNomieeChangeSHeader
    {
        public int IOU_servicereq_rowid { get; set; }
        public string IOU_servicereq_no { get; set; }
        public string In_fpomember_code { get; set; }
        public string In_farmer_code { get; set; }
        public string In_cur_member_nominee { get; set; }
        public string In_changeto_member_nominee { get; set; }
        public string In_status_code { get; set; }
        public string In_chklst_status_flag { get; set; }
        public string In_sr_comments { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class FISNomieeChangeSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FISNomieeChangeSHeader Header { get; set; }

    }
    public class FISNomieeChangeSDocument
    {
        public FISNomieeChangeSContext context { get; set; }
        public FISNomieeChangeSApplicationException ApplicationException { get; set; }
    }
    public class FISNomieeChangeSApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class FISNomieeChangeSApplication
    {
        public FISNomieeChangeSDocument document { get; set; }

    }
    #endregion
}
