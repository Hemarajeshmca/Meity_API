using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class ICDInputCenter_model
    {
    }
     
    #region list
    public class ICDInputList
    {
        public int Out_ic_rowid { get; set; }
        public string Out_ic_code { get; set; }
        public string Out_ic_name { get; set; }
        public string Out_orgn_code { get; set; }
        public int Out_version_no { get; set; }
        public string Out_orgn_cin { get; set; }
        public string Out_primary_lang_code { get; set; }
        public string Out_parent_code { get; set; }
        public string Out_orgn_name { get; set; }
        public string Out_orgn_ll_name { get; set; }
        public string Out_orgn_level { get; set; }
        public string Out_orgn_level_desc { get; set; }
        public string Out_orgn_type { get; set; }
        public string Out_orgn_type_desc { get; set; }
        public string Out_orgn_subtype { get; set; }
        public string Out_orgn_subtype_desc { get; set; }
        public string Out_secondary_lang_code { get; set; }
        public string Out_orgn_logo { get; set; }
        public string Out_orgn_auth_sign { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_row_timestamp { get; set; }

    }
    public class ICDInputContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<ICDInputList> List { get; set; }
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }

    }
    public class ICDInputApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class ICDInputApplication
    {
        public ICDInputContext context { get; set; }
        public ICDInputApplicationException ApplicationException { get; set; }

    }
    #endregion


    #region fetch
    public class ICDInputCenter_FHeader
    {
        public int IOU_orgn_rowid { get; set; }
        public string IOU_orgn_code { get; set; }
        public int IOU_version_no { get; set; }
        public string In_orgn_cin { get; set; }
        public string In_parent_code { get; set; }
        public string In_orgn_name { get; set; }
        public string In_orgn_ll_name { get; set; }
        public string In_orgn_level { get; set; }
        public string In_orgn_level_desc { get; set; }
        public string In_orgn_type { get; set; }
        public string In_orgn_type_desc { get; set; }
        public string In_orgn_subtype { get; set; }
        public string In_orgn_subtype_desc { get; set; }
        public string In_primary_lang_code { get; set; }
        public string In_secondary_lang_code { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_ic_code { get; set; }
        public string In_ic_type { get; set; }
        public string In_ic_name { get; set; }
        public string In_fpo_name { get; set; }
        public string In_orgn_logo { get; set; }
        public string In_orgn_auth_sign { get; set; }

    }
    public class ICDInputCenter_FAddress
    {
        public int In_orgnaddr_rowid { get; set; }
        public string In_addr_type { get; set; }
        public string In_addr_type_desc { get; set; }
        public string In_orgn_add1 { get; set; }
        public string In_orgn_addr2 { get; set; }
        public string In_orgn_country { get; set; }
        public string In_orgn_country_desc { get; set; }
        public string In_orgn_state { get; set; }
        public string In_orgn_state_desc { get; set; }
        public string In_orgn_dist { get; set; }
        public string In_orgn_dist_desc { get; set; }
        public string In_orgn_taluk { get; set; }
        public string In_orgn_taluk_desc { get; set; }
        public string In_orgn_panchayat { get; set; }
        public string In_orgn_panchayat_desc { get; set; }
        public string In_orgn_village { get; set; }
        public string In_orgn_village_desc { get; set; }
        public string In_orgn_pincode { get; set; }
        public string In_orgn_pincode_desc { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class ICDInputCenter_FBank
    {
        public int In_orgnbank_rowid { get; set; }
        public string In_bank_acc_no { get; set; }
        public string In_bank_acc_type { get; set; }
        public string In_bank_acc_type_desc { get; set; }
        public string In_bank_code { get; set; }
        public string In_bank_desc { get; set; }
        public string In_branch_code { get; set; }
        public string In_branch_desc { get; set; }
        public string In_ifsc_code { get; set; }
        public string In_dflt_dr_acc { get; set; }
        public string In_dflt_dr_acc_desc { get; set; }
        public string In_dflt_cr_acc { get; set; }
        public string In_dflt_cr_acc_desc { get; set; }
        public string In_bank_acc_purpose { get; set; }
        public string In_bank_acc_purpose_desc { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class ICDInputCenter_FUser
    {
        public int In_aggrlocuser_rowid { get; set; }
        public string In_aggrorgn_type { get; set; }
        public string In_aggrorgn_type_desc { get; set; }
        public string In_aggrorgn_code { get; set; }
        public string In_aggrloc_type { get; set; }
        public string In_aggrloc_type_desc { get; set; }
        public string In_aggrloc_code { get; set; }
        public string In_role_code { get; set; }
        public string In_user_code { get; set; }
        public string In_user_name { get; set; }
        public string In_email_id { get; set; }
        public string In_contact_no { get; set; }
        public string In_valid_till { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class ICDInputCenter_FContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public ICDInputCenter_FHeader Header { get; set; }
        public IList<ICDInputCenter_FAddress> Address { get; set; }
        public IList<ICDInputCenter_FBank> Bank { get; set; }
        public IList<ICDInputCenter_FUser> User { get; set; }
        public int version_no { get; set; }
        public string orgn_code { get; set; }
        public int ic_rowid { get; set; }

    }
    public class ICDInputCenter_FApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class ICDInputCenter_FApplication
    {
        public ICDInputCenter_FContext context { get; set; }
        public ICDInputCenter_FApplicationException ApplicationException { get; set; }

    }
    #endregion


    #region save
    public class ICDInput_SHeader
    {
        public int IOU_orgn_rowid { get; set; }
        public string IOU_orgn_code { get; set; }
        public int IOU_version_no { get; set; }
        public string In_orgn_cin { get; set; }
        public string In_parent_code { get; set; }
        public string In_orgn_name { get; set; }
        public string In_orgn_ll_name { get; set; }
        public string In_orgn_level { get; set; }
        public string In_orgn_type { get; set; }
        public string In_orgn_subtype { get; set; }
        public string In_primary_lang_code { get; set; }
        public string In_secondary_lang_code { get; set; }
        public string In_orgn_logo { get; set; }
        public string In_orgn_auth_sign { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_inputcenter_code { get; set; }
        public string In_inputcenter_type { get; set; }
        public string In_inputcenter_name { get; set; }
        public string In_fpo_name { get; set; }

    }
    public class ICDInput_SAddress
    {
        public int In_orgnaddr_rowid { get; set; }
        public string In_addr_type { get; set; }
        public string In_orgn_add1 { get; set; }
        public string In_orgn_addr2 { get; set; }
        public string In_orgn_country { get; set; }
        public string In_orgn_state { get; set; }
        public string In_orgn_dist { get; set; }
        public string In_orgn_taluk { get; set; }
        public string In_orgn_panchayat { get; set; }
        public string In_orgn_village { get; set; }
        public string In_orgn_pincode { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class ICDInput_SBank
    {
        public int In_orgnbank_rowid { get; set; }
        public string In_bank_acc_no { get; set; }
        public string In_bank_acc_type { get; set; }
        public string In_bank_code { get; set; }
        public string In_branch_code { get; set; }
        public string In_ifsc_code { get; set; }
        public string In_dflt_dr_acc { get; set; }
        public string In_dflt_cr_acc { get; set; }
        public string In_bank_acc_purpose { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class ICDInput_SUser
    {
        public int In_aggrlocuser_rowid { get; set; }
        public string In_aggrorgn_type { get; set; }
        public string In_aggrorgn_code { get; set; }
        public string In_aggrloc_type { get; set; }
        public string In_aggrloc_code { get; set; }
        public string In_role_code { get; set; }
        public string In_user_code { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class ICDInput_SContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }

        public string errorMsg { get; set; }
        public ICDInput_SHeader Header { get; set; }
        public IList<ICDInput_SAddress> Address { get; set; }
        public IList<ICDInput_SBank> Bank { get; set; }
        public IList<ICDInput_SUser> User { get; set; }

    }
    public class ICDInput_SDocument
    {
        public ICDInput_SContext context { get; set; }

    }
    public class ICDInput_SApplication
    {
        public ICDInput_SDocument document { get; set; }

    }
    #endregion
}
