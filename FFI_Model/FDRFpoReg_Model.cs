using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
   public class FDRFpoReg_Model
    {
    }
    public class FPOList
    {
        public int out_orgn_rowid { get; set; }
        public string out_orgn_code { get; set; }
        public int out_version_no { get; set; }
        public string out_orgn_cin { get; set; }
        public string out_primary_lang_code { get; set; }
        public string out_parent_code { get; set; }
        public string out_orgn_name { get; set; }
        public string out_orgn_ll_name { get; set; }
        public string out_orgn_level { get; set; }
        public string out_orgn_level_desc { get; set; }
        public string out_orgn_type { get; set; }
        public string out_orgn_type_desc { get; set; }
        public string out_orgn_subtype { get; set; }
        public string out_orgn_subtype_desc { get; set; }
        public string out_secondary_lang_code { get; set; }
        public string out_orgn_logo { get; set; }
        public string out_orgn_auth_sign { get; set; }
        public string out_status_code { get; set; }
        public string out_status_desc { get; set; }
        public string out_row_timestamp { get; set; }
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }
    }
    public class fetchcontextlist
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FPOList list { get; set; }
    }
    public class Contextlist
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public List<FPOList> list { get; set; }
    }

    public class ApplicationExceptionlist
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }
    }

    public class RootObjectlist
    {
        public Contextlist context { get; set; }
        public ApplicationExceptionlist ApplicationException { get; set; }
    }
    #region SaveFPO


    public class FPOAddress
    {
        public int in_orgnaddr_rowid { get; set; }
        public string in_addr_type { get; set; }
        public string in_orgn_add1 { get; set; }
        public string in_orgn_addr2 { get; set; }
        public string in_orgn_country { get; set; }
        public string in_orgn_state { get; set; }
        public string in_orgn_dist { get; set; }
        public string in_orgn_taluk { get; set; }
        public string in_orgn_panchayat { get; set; }
        public string in_orgn_village { get; set; }
        public string in_orgn_pincode { get; set; }
        public string in_status_code { get; set; }
        public string in_mode_flag { get; set; }
    }

    public class Fig
    {
        public int in_orgnfig_rowid { get; set; }
        public string in_fig_type { get; set; }
        public string in_fig_short_name { get; set; }
        public string in_fig_name { get; set; }
        public string in_fig_village_covered { get; set; }
        public string in_fig_president { get; set; }
        public string in_fig_treasurer { get; set; }
        public string in_fig_secretary { get; set; }
        public string in_fig_contact_person { get; set; }
        public string in_status_code { get; set; }
        public string in_mode_flag { get; set; }
    }

    public class Bearer
    {
        public int in_orgnofficebearers_rowid { get; set; }
        public string in_officebearer_role { get; set; }
        public string in_officebearer_name { get; set; }
        public string in_officebearer_contact_no { get; set; }
        public string in_status_code { get; set; }
        public string in_mode_flag { get; set; }
    }

    public class Bank
    {
        public int in_orgnbank_rowid { get; set; }
        public string in_bank_acc_no { get; set; }
        public string in_bank_acc_type { get; set; }
        public string in_bank_code { get; set; }
        public string in_branch_code { get; set; }
        public string in_ifsc_code { get; set; }
        public string in_dflt_dr_acc { get; set; }
        public string in_dflt_cr_acc { get; set; }
        public string in_bank_acc_purpose { get; set; }
        public string in_status_code { get; set; }
        public string in_mode_flag { get; set; }
    }

    public class User
    {
        public int in_aggrlocuser_rowid { get; set; }
        public string in_aggrorgn_type { get; set; }
        public string in_aggrorgn_code { get; set; }
        public string in_aggrloc_type { get; set; }
        public string in_aggrloc_code { get; set; }
        public string in_role_code { get; set; }
        public string in_user_code { get; set; }
        public string in_status_code { get; set; }
        public string in_mode_flag { get; set; }
    }

    public class Tax
    {
        public int in_tax_rowid { get; set; }
        public string in_tax_type { get; set; }
        public string in_tax_reg_no { get; set; }
        public string in_state_code { get; set; }
        public string in_status_code { get; set; }
        public string in_mode_flag { get; set; }
    }

    public class GeoLoc
    {
        public int in_geoloc_rowid { get; set; }
        public string in_geoloc_country { get; set; }
        public string orgn_geoloc_desc { get; set; }
        public string in_geoloc_state { get; set; }
        public string geoloc_state_desc { get; set; }
        public string in_geoloc_dist { get; set; }
        public string geoloc_dist_desc { get; set; }
        public string in_geoloc_taluk { get; set; }
        public string geoloc_taluk_desc { get; set; }
        public string in_geoloc_panchayat { get; set; }
        public string geoloc_panchayat_desc { get; set; }
        public string in_geoloc_village { get; set; }
        public string geoloc_village_desc { get; set; }
        public string in_status_code { get; set; }
        public string status_desc { get; set; }
        public string in_mode_flag { get; set; }
    }

    public class CheckList
    {
        public int in_checklist_rowid { get; set; }
        public string in_checklist_code { get; set; }
        public string checklist_desc { get; set; }
        public string in_complied_code { get; set; }
        public string in_complied_desc { get; set; }
        public string in_attachment { get; set; }
        public string in_status_code { get; set; }
        public string in_mode_flag { get; set; }
    }
    public class LoanDet
    {
        public int in_loan_rowid { get; set; }
        public string in_loan_type { get; set; }
        public string in_loan_from { get; set; }
        public string in_institution_name { get; set; }
        public string in_institution_branch { get; set; }
        public string in_loan_amount { get; set; }
        public string in_loan_tenor { get; set; }
        public string in_interest_rate { get; set; }
        public string in_emi_amount { get; set; }
        public string in_loan_start_date { get; set; }
        public string in_loan_end_date { get; set; }
        public string in_collateral_security { get; set; }
        public string in_status_code { get; set; }
        public string in_mode_flag { get; set; }
    }


    public class FPOHeader
    {
        public int inout_orgn_rowid { get; set; }
        public string inout_orgn_code { get; set; }
        public int inout_version_no { get; set; }
        public string in_orgn_cin { get; set; }
        public string in_parent_code { get; set; }
        public string in_orgn_name { get; set; }
        public string in_orgn_ll_name { get; set; }
        public string in_orgn_level { get; set; }
        public string in_orgn_type { get; set; }
        public string in_orgn_subtype { get; set; }
        public string in_primary_lang_code { get; set; }
        public string in_secondary_lang_code { get; set; }
        public string in_orgn_logo { get; set; }
        public string in_orgn_auth_sign { get; set; }
        public string in_status_code { get; set; }
        public string in_mode_flag { get; set; }
        public string in_row_timestamp { get; set; }
        public List<FPOAddress> address { get; set; }
        public List<Fig> fig { get; set; }
        public List<Bearer> bearers { get; set; }
        public List<Bank> bank { get; set; }
        public List<User> user { get; set; }
        public List<Tax> tax { get; set; }
        public List<GeoLoc> GeoLoc { get; set; }
        public List<CheckList> CheckList { get; set; }
        public List<LoanDet> LoanDet { get; set; }
    }

    public class FPOContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FPOHeader header { get; set; }
    }
  

    public class FPODocument
    {
        public FPOContext context { get; set; }
        public ApplicationExceptionlist ApplicationException { get; set; }
    }

    public class FPORootObject
    {
        public FPODocument document { get; set; }
    }


    #endregion

    #region GetFPO
    public class Address1
    {
        public int in_orgnaddr_rowid { get; set; }
        public string in_addr_type { get; set; }
        public string addr_type_desc { get; set; }
        public string in_orgn_add1 { get; set; }
        public string in_orgn_addr2 { get; set; }
        public string in_orgn_country { get; set; }
        public string orgn_country_desc { get; set; }
        public string in_orgn_state { get; set; }
        public string orgn_state_desc { get; set; }
        public string in_orgn_dist { get; set; }
        public string orgn_dist_desc { get; set; }
        public string in_orgn_taluk { get; set; }
        public string orgn_taluk_desc { get; set; }
        public string in_orgn_panchayat { get; set; }
        public string orgn_panchayat_desc { get; set; }
        public string in_orgn_village { get; set; }
        public string orgn_village_desc { get; set; }
        public string in_orgn_pincode { get; set; }
        public string orgn_pincode_desc { get; set; }
        public string in_status_code { get; set; }
        public string status_desc { get; set; }
        public string in_mode_flag { get; set; }
    }

    public class Fig1
    {
        public int in_orgnfig_rowid { get; set; }
        public string in_fig_type { get; set; }
        public string fig_type_desc { get; set; }
        public string in_fig_short_name { get; set; }
        public string in_fig_name { get; set; }
        public string in_fig_village_covered { get; set; }
        public string fig_village_covered_desc { get; set; }
        public string in_fig_president { get; set; }
        public string in_fig_treasurer { get; set; }
        public string in_fig_secretary { get; set; }
        public string in_fig_contact_person { get; set; }
        public string in_status_code { get; set; }
        public string status_desc { get; set; }
        public string in_mode_flag { get; set; }
    }

    public class Bearer1
    {
        public int in_orgnofficebearers_rowid { get; set; }
        public string in_officebearer_role { get; set; }
        public string officebearer_role_desc { get; set; }
        public string in_officebearer_name { get; set; }
        public string in_officebearer_contact_no { get; set; }
        public string in_status_code { get; set; }
        public string status_desc { get; set; }
        public string in_mode_flag { get; set; }
    }

    public class Bank1
    {
        public int in_orgnbank_rowid { get; set; }
        public string in_bank_acc_no { get; set; }
        public string in_bank_acc_type { get; set; }
        public string bank_acc_type_desc { get; set; }
        public string in_bank_code { get; set; }
        public string bank_desc { get; set; }
        public string in_branch_code { get; set; }
        public string branch_desc { get; set; }
        public string in_ifsc_code { get; set; }
        public string in_dflt_dr_acc { get; set; }
        public string dflt_dr_acc_desc { get; set; }
        public string in_dflt_cr_acc { get; set; }
        public string dflt_cr_acc_desc { get; set; }
        public string in_bank_acc_purpose { get; set; }
        public string bank_acc_purpose_desc { get; set; }
        public string in_status_code { get; set; }
        public string status_desc { get; set; }
        public string in_mode_flag { get; set; }
    }

    public class User1
    {
        public int in_aggrlocuser_rowid { get; set; }
        public string in_aggrorgn_type { get; set; }
        public string aggrorgn_type_desc { get; set; }
        public string in_aggrorgn_code { get; set; }
        public string in_aggrloc_type { get; set; }
        public string aggrloc_type_desc { get; set; }
        public string in_aggrloc_code { get; set; }
        public string in_role_code { get; set; }
        public string in_user_code { get; set; }
        public string user_name { get; set; }
        public string email_id { get; set; }
        public string contact_no { get; set; }
        public string valid_till { get; set; }
        public string in_status_code { get; set; }
        public string status_desc { get; set; }
        public string in_mode_flag { get; set; }
    }

    public class Tax1
    {
        public int in_tax_rowid { get; set; }
        public string in_tax_type { get; set; }
        public string in_tax_reg_no { get; set; }
        public string in_state_code { get; set; }
        public string state_desc { get; set; }
        public string in_status_code { get; set; }
        public string status_desc { get; set; }
        public string in_mode_flag { get; set; }
    }
    public class CheckList1
    {
        public int in_checklist_rowid { get; set; }
        public string in_checklist_code { get; set; }
        public string checklist_desc { get; set; }
        public string in_complied_code { get; set; }
        public string in_complied_desc { get; set; }
        public string in_attachment { get; set; }
        public string in_status_code { get; set; }
        public string status_desc { get; set; }
        public string in_mode_flag { get; set; }
    }
    public class LoanDet1
    {
        public int in_loan_rowid { get; set; }
        public string in_loan_type { get; set; }
        public string in_loan_from { get; set; }
        public string in_institution_name { get; set; }
        public string in_institution_branch { get; set; }
        public string in_loan_amount { get; set; }
        public string in_loan_tenor { get; set; }
        public string in_interest_rate { get; set; }
        public string in_emi_amount { get; set; }
        public string in_loan_start_date { get; set; }
        public string in_loan_end_date { get; set; }
        public string in_collateral_security { get; set; }
        public string in_status_code { get; set; }
        public string status_desc { get; set; }
        public string in_mode_flag { get; set; }
    }
    public class Header1
    {
        public int out_orgn_rowid { get; set; }
        public string out_orgn_code { get; set; }
        public int out_version_no { get; set; }
        public string out_orgn_cin { get; set; }
        public string out_parent_code { get; set; }
        public string out_orgn_name { get; set; }
        public string out_orgn_ll_name { get; set; }
        public string out_orgn_level { get; set; }
        public string out_orgn_level_desc { get; set; }
        public string out_orgn_type { get; set; }
        public string out_orgn_type_desc { get; set; }
        public string out_orgn_subtype { get; set; }
        public string out_orgn_subtype_desc { get; set; }
        public string out_primary_lang_code { get; set; }
        public string out_secondary_lang_code { get; set; }
        public string out_status_code { get; set; }
        public string out_status_desc { get; set; }
        public string out_mode_flag { get; set; }
        public string out_row_timestamp { get; set; }
        public string out_orgn_logo { get; set; }
        public string out_orgn_auth_sign { get; set; }
        public List<Address1> Address { get; set; }
        public List<Fig1> Fig { get; set; }
        public List<Bearer1> Bearers { get; set; }
        public List<Bank1> Bank { get; set; }
        public List<User1> User { get; set; }
        public List<Tax1> Tax { get; set; }
        public List<GeoLoc> GeoLoc { get; set; }
        public List<CheckList1> CheckList { get; set; }
        public List<LoanDet1> LoanDet { get; set; }
    }

    public class Context1
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public Header1 Header { get; set; }
    }
    public class RootObjectFetch
    {
        public Context1 context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion

    #region NewFetch

    public class AddressNewFetch
    {

        public int in_orgnaddr_rowid { get; set; }
        public string in_addr_type { get; set; }
        public string addr_type_desc { get; set; }
        public string in_orgn_country { get; set; }
        public string orgn_country_desc { get; set; }
        public string in_orgn_state { get; set; }
        public string orgn_state_desc { get; set; }
        public string in_orgn_dist { get; set; }
        public string orgn_dist_desc { get; set; }
        public string in_orgn_taluk { get; set; }
        public string orgn_taluk_desc { get; set; }
        public string in_orgn_panchayat { get; set; }
        public string orgn_panchayat_desc { get; set; }
        public string in_orgn_village { get; set; }
        public string orgn_village_desc { get; set; }
        public string in_orgn_add1 { get; set; }
        public string in_orgn_addr2 { get; set; }
        public string in_orgn_pincode { get; set; }
        public string orgn_pincode_desc { get; set; }
        public string in_status_code { get; set; }
        public string status_desc { get; set; }
        public string in_mode_flag { get; set; }
    }


    public class HeaderNewFetch
    {
        public int out_orgn_rowid { get; set; }
        public string out_orgn_code { get; set; }
        public int out_version_no { get; set; }
        public string out_orgn_cin { get; set; }
        public string out_parent_code { get; set; }
        public string out_orgn_name { get; set; }
        public string out_orgn_ll_name { get; set; }
        public string out_orgn_level { get; set; }
        public string out_orgn_level_desc { get; set; }
        public string out_orgn_type { get; set; }
        public string out_orgn_type_desc { get; set; }
        public string out_orgn_subtype { get; set; }
        public string out_orgn_subtype_desc { get; set; }
        public string out_primary_lang_code { get; set; }
        public string out_secondary_lang_code { get; set; }
        public string out_status_code { get; set; }
        public string out_status_desc { get; set; }
        public string out_mode_flag { get; set; }
        public string out_row_timestamp { get; set; }
        public string out_orgn_logo { get; set; }
        public string out_orgn_auth_sign { get; set; }
        public List<AddressNewFetch> Address { get; set; }
        public List<Fig1> Fig { get; set; }
        public List<Bearer1> Bearers { get; set; }
        public List<Bank1> Bank { get; set; }
        public List<User1> User { get; set; }
        public List<Tax1> Tax { get; set; }
        public List<CheckList1> CheckList { get; set; }
        public List<LoanDet1> LoanDet { get; set; }
    }

    public class ContextNewFetch
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public HeaderNewFetch Header { get; set; }
    }

    public class ApplicationExceptionNewFetch
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }
    }

    public class RootObjectFetchNewFetch
    {
        public ContextNewFetch context { get; set; }
        public ApplicationExceptionNewFetch ApplicationException { get; set; }
    }

    #endregion
}
