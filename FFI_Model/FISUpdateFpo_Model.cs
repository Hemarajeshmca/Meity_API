using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    public class FISUpdateFpo_Model
    {
    }

    #region fetch
    public class UpdateFetchHeader
    {
        public string IOU_fpoorgn_code { get; set; }
        public string IOU_alloc_status_code { get; set; }
        public string IOU_board_approval_date { get; set; }

    }
    public class UpdateFetchDetail
    {
        public int In_shareapp_rowid { get; set; }
        public string In_shareapp_no { get; set; }
        public string In_shareapp_date { get; set; }
        public string In_member_name { get; set; }
        public int In_applied_shares { get; set; }
        public int In_approved_shares { get; set; }
        public int In_rejected_shares { get; set; }
        public string In_rejected_comment { get; set; }
        public string In_approved_date { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class UpdateFetchContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public UpdateFetchHeader Header { get; set; }
        public IList<UpdateFetchDetail> Detail { get; set; }
        public string fpoorgn_code { get; set; }
        public string alloc_status_code { get; set; }
        public string board_approval_date { get; set; }

    }

    public class UpdateFetchApplication
    {
        public UpdateFetchContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }

    }
    #endregion

    #region save
    public class UpdateSaveHeader
    {
        public string In_fpoorgn_code { get; set; }
        public string In_alloc_status_code { get; set; }

    }
    public class UpdateSaveDetail
    {
        public int In_shareapp_rowid { get; set; }
        public string In_shareapp_no { get; set; }
        public string In_member_name { get; set; }
        public int In_applied_shares { get; set; }
        public int In_approved_shares { get; set; }
        public int In_rejected_shares { get; set; }
        public string In_rejected_comment { get; set; }
        public string In_approved_date { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class UpdateSaveContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public UpdateSaveHeader Header { get; set; }
        public IList<UpdateSaveDetail> Detail { get; set; }

    }
    public class UpdateSaveDocument
    {
        public UpdateSaveContext context { get; set; }
        public UpdateSaveApplication ApplicationException { get; set; }

    }
    public class UpdateSaveApplication
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }
        public UpdateSaveDocument document { get; set; }


    }

    #endregion
}

