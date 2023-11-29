using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    public class FISGenerateShareCertificate_Model
    {
    }

    #region list
    public class GenerateShareList
    {
        public int Out_register_rowid { get; set; }
        public string Out_fpoorgn_code { get; set; }
        public string Out_register_no { get; set; }
        public string Out_register_type_code { get; set; }
        public string Out_register_type_desc { get; set; }
        public string Out_register_date { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }

    }
    public class GenerateShareContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<GenerateShareList> List { get; set; }
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }

    }
 
    public class GenerateShareApplication
    {
        public GenerateShareContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }

    }
    #endregion

    #region fetch
    public class GenerateShareHeader
    {
        public string In_register_type_desc { get; set; }
        public string In_register_date { get; set; }
        public string In_register_no { get; set; }
        public int In_record_count { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class GenerateShareDetail
    {
        public int In_shareapp_rowid { get; set; }
        public string In_farmer_code { get; set; }
        public string In_fpomember_code { get; set; }
        public string In_shareapp_no { get; set; }
        public string In_member_name { get; set; }
        public string In_member_sur_name { get; set; }
        public int In_applied_shares { get; set; }
        public int In_approved_shares { get; set; }
        public int In_rejected_shares { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_chklist_status_flag { get; set; }
        public string In_shareapp_remark { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class GenerateShareFetchContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public GenerateShareHeader Header { get; set; }
        public IList<GenerateShareDetail> Detail { get; set; }
        public int register_rowid { get; set; }
        public string register_type { get; set; }
        public string fpoorgn_code { get; set; }


    }
   
    public class GenerateShareFetchApplication
    {
        public GenerateShareFetchContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }

    }
    #endregion

    #region save
    public class GenerateShareSaveHeader
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
    public class GenerateShareSaveDetail
    {
        public int In_shareapp_rowid { get; set; }
        public string In_shareapp_no { get; set; }
        public string In_farmer_code { get; set; }
        public string In_fpomember_code { get; set; }
        public string In_member_name { get; set; }
        public string In_member_sur_name { get; set; }
        public int In_applied_shares { get; set; }
        public string In_status_code { get; set; }
        public string In_chklist_status_flag { get; set; }
        public string In_shareapp_remark { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class GenerateShareSaveContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public GenerateShareSaveHeader Header { get; set; }
        public IList<GenerateShareSaveDetail> Detail { get; set; }

    }
    public class GenerateShareDocument
    {
        public GenerateShareSaveContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }

    }
    public class GenerateShareSaveApplication
    {
        public GenerateShareDocument document { get; set; }

    }
    #endregion
}
