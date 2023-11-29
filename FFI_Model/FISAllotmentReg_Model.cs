using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
   public class FISAllotmentReg_Model
    {
    }

    #region list
    public class AllotemntList
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
    public class AllotemntContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<AllotemntList> List { get; set; }
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }

    }
   
    public class AllotemntApplication
    {
        public AllotemntContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }

    }
    #endregion

    #region fetch
    public class AllotemntHeader
    {
        public string In_register_type { get; set; }
        public string In_register_type_desc { get; set; }
        public string In_register_no { get; set; }
        public string In_register_date { get; set; }
        public int In_record_count { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class Detail
    {
        public int In_shareapp_rowid { get; set; }
        public string In_farmer_code { get; set; }
        public string In_fpomember_code { get; set; }
        public string In_shareapp_no { get; set; }
        public string In_member_name { get; set; }
        public string In_member_sur_name { get; set; }
        public int In_applied_shares { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_chklist_status_flag { get; set; }
        public string In_shareapp_remark { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class AllotmentContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public AllotemntHeader Header { get; set; }
        public IList<Detail> Detail { get; set; }
        public int register_rowid { get; set; }
        public string fpoorgn_code { get; set; }

    }
 
    public class AllotemntFetchApplication
    {
        public AllotmentContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }

    }
    #endregion

    #region save
    public class SaveAllotemntHeader
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
    public class SaveAllotemntDetail
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
    public class SaveAllotmentContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public SaveAllotemntHeader Header { get; set; }
        public IList<SaveAllotemntDetail> Detail { get; set; }

    }
    public class SaveAllotmentDocument
    {
        public SaveAllotmentContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }

    }
    public class SaveAllotmentApplication
    {
        public SaveAllotmentDocument document { get; set; }

    }
    #endregion
}
