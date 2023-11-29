using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class Admin_AggregatorRegistrationModel
    {
    }
    #region  List
    public class AGGREGList
    {
        public int Out_orgn_rowid { get; set; }
        public string Out_aggregator_code { get; set; }
        public string Out_aggregator_name { get; set; }
        public string Out_orgn_level { get; set; }
        public string Out_aggregator_type { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_row_timestamp { get; set; }
    }

    public class AGGContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public List<AGGREGList> List { get; set; }
    }


    public class PAWHSAggregatorRegistrationList
    {
        public AGGContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }

    #endregion

    #region  SingleFetch
    public class FetchARAddress
    {
        public int Out_orgnaddr_rowid { get; set; }
        public string Out_addr_type { get; set; }
        public string Out_addr_type_desc { get; set; }
        public string Out_orgn_addr1 { get; set; }
        public string Out_orgn_addr2 { get; set; }
        public string Out_orgn_country { get; set; }
        public string Out_orgn_country_desc { get; set; }
        public string Out_orgn_state { get; set; }
        public string Out_orgn_state_desc { get; set; }
        public string Out_orgn_dist { get; set; }
        public string Out_orgn_dist_desc { get; set; }
        public string Out_orgn_taluk { get; set; }
        public string Out_orgn_taluk_desc { get; set; }
        public string Out_orgn_panchayat { get; set; }
        public string Out_orgn_panchayat_desc { get; set; }
        public string Out_orgn_village { get; set; }
        public string Out_orgn_village_desc { get; set; }
        public string Out_orgn_pincode { get; set; }
        public string Out_orgn_pincode_desc { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_mode_flag { get; set; }
    }

    public class FetchARBank
    {
        public int Out_orgnbank_rowid { get; set; }
        public string Out_bank_acc_no { get; set; }
        public string Out_bank_acc_type { get; set; }
        public string Out_bank_acc_type_desc { get; set; }
        public string Out_bank_code { get; set; }
        public string Out_bank_desc { get; set; }
        public string Out_branch_code { get; set; }
        public string Out_branch_desc { get; set; }
        public string Out_ifsc_code { get; set; }
        public string Out_dflt_dr_acc { get; set; }
        public string Out_dflt_dr_acc_desc { get; set; }
        public string Out_dflt_cr_acc { get; set; }
        public string Out_dflt_cr_acc_desc { get; set; }
        public string Out_bank_acc_purpose { get; set; }
        public string Out_bank_acc_purpose_desc { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_mode_flag { get; set; }
    }

    public class FetchARFig
    {
        public int Out_aggrfig_rowid { get; set; }
        public string Out_aggrfig_type { get; set; }
        public string Out_aggrfig_type_desc { get; set; }
        public string Out_aggrfig_code { get; set; }
        public string Out_aggrfig_name { get; set; }
        public string Out_aggrvillage_code { get; set; }
        public string Out_aggrvillage_name { get; set; }
        public string Out_contact_person { get; set; }
        public string Out_contact_no { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_mode_flag { get; set; }
    }

    public class FetchARHeader
    {
        public int IOU_orgn_rowid { get; set; }
        public string IOU_aggregator_code { get; set; }
        public string Out_aggregator_type { get; set; }
        public string Out_fpo_code { get; set; }
        public string Out_fpo_desc { get; set; }
        public string Out_aggregator_name { get; set; }
        public string Out_aggregator_ll_name { get; set; }
        public string Out_orgn_level { get; set; }
        public string Out_facilitator_code { get; set; }
        public string Out_facilitator_name { get; set; }
        public string Out_facilitator_ll_code { get; set; }
        public string Out_facilitator_ll_name { get; set; }
        public string Out_member_name { get; set; }
        public string Out_member_ll_name { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_mode_flag { get; set; }
        public string Out_row_timestamp { get; set; }
        public List<FetchARAddress> Address { get; set; }
        public List<FetchARBank> Bank { get; set; }
        public List<FetchARFig> Fig { get; set; }
    }

    public class FetchARContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FetchARHeader Header { get; set; }
    }


    public class FectAggregatorRegistration
    {
        public FetchARContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion

    #region  MemberFetch
    public class AggrMemberFetchHeader
    {
        public int IOU_orgn_rowid { get; set; }
        public string IOU_aggregator_code { get; set; }
        public string Out_orgn_code { get; set; }
        public string Out_fpo_code { get; set; }
        public string Out_fpo_desc { get; set; }
        public string Out_aggregator_type { get; set; }
        public string Out_aggregator_name { get; set; }
        public string Out_aggregator_ll_name { get; set; }
        public string Out_orgn_level { get; set; }
        public string Out_facilitator_code { get; set; }
        public string Out_facilitator_name { get; set; }
        public string Out_facilitator_ll_code { get; set; }
        public string Out_facilitator_ll_name { get; set; }
        public string Out_member_name { get; set; }
        public string Out_member_ll_name { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_mode_flag { get; set; }
        public string Out_row_timestamp { get; set; }
    }

    public class AggrMemberFetchAddress
    {
        public int Out_orgnaddr_rowid { get; set; }
        public string Out_addr_type { get; set; }
        public string Out_addr_type_desc { get; set; }
        public string Out_orgn_addr1 { get; set; }
        public string Out_orgn_addr2 { get; set; }
        public string Out_orgn_country { get; set; }
        public string Out_orgn_country_desc { get; set; }
        public string Out_orgn_state { get; set; }
        public string Out_orgn_state_desc { get; set; }
        public string Out_orgn_dist { get; set; }
        public string Out_orgn_dist_desc { get; set; }
        public string Out_orgn_taluk { get; set; }
        public string Out_orgn_taluk_desc { get; set; }
        public string Out_orgn_panchayat { get; set; }
        public string Out_orgn_panchayat_desc { get; set; }
        public string Out_orgn_village { get; set; }
        public string Out_orgn_village_desc { get; set; }
        public string Out_orgn_pincode { get; set; }
        public string Out_orgn_pincode_desc { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_mode_flag { get; set; }
    }

    public class AggrMemberFetchBank
    {
        public int Out_orgnbank_rowid { get; set; }
        public string Out_bank_acc_no { get; set; }
        public string Out_bank_acc_type { get; set; }
        public string Out_bank_acc_type_desc { get; set; }
        public string Out_bank_code { get; set; }
        public string Out_bank_desc { get; set; }
        public string Out_branch_code { get; set; }
        public string Out_branch_desc { get; set; }
        public string Out_ifsc_code { get; set; }
        public string Out_dflt_dr_acc { get; set; }
        public string Out_dflt_dr_acc_desc { get; set; }
        public string Out_dflt_cr_acc { get; set; }
        public string Out_dflt_cr_acc_desc { get; set; }
        public string Out_bank_acc_purpose { get; set; }
        public string Out_bank_acc_purpose_desc { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_mode_flag { get; set; }
    }

    public class AggrMemberFetchFIG
    {
        public int Out_aggrfig_rowid { get; set; }
        public string Out_aggrfig_type { get; set; }
        public string Out_aggrfig_type_desc { get; set; }
        public string Out_aggrfig_code { get; set; }
        public string Out_aggrfig_name { get; set; }
        public string Out_aggrvillage_code { get; set; }
        public string Out_aggrvillage_name { get; set; }
        public string Out_contact_person { get; set; }
        public string Out_contact_no { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_mode_flag { get; set; }
    }

    public class AggrMemberFetchContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public AggrMemberFetchHeader Header { get; set; }
        public List<AggrMemberFetchAddress> Address { get; set; }
        public List<AggrMemberFetchBank> Bank { get; set; }
        public List<AggrMemberFetchFIG> FIG { get; set; }
        public int orgn_rowid { get; set; }
        public string orgn_code { get; set; }
        public string aggregator_code { get; set; }
        public string fpo_code { get; set; }
    }

    public class AggrMemberFetch
    {
        public AggrMemberFetchContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion
    #region memeber
    public class MHeader
    {
        public int IOU_orgn_rowid { get; set; }
        public string IOU_aggregator_code { get; set; }
        public string Out_orgn_code { get; set; }
        public string Out_fpo_code { get; set; }
        public string Out_fpo_desc { get; set; }
        public string Out_aggregator_type { get; set; }
        public string Out_aggregator_name { get; set; }
        public string Out_aggregator_ll_name { get; set; }
        public string Out_orgn_level { get; set; }
        public string Out_facilitator_code { get; set; }
        public string Out_facilitator_name { get; set; }
        public string Out_facilitator_ll_code { get; set; }
        public string Out_facilitator_ll_name { get; set; }
        public string Out_member_name { get; set; }
        public string Out_member_ll_name { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_mode_flag { get; set; }
        public string Out_row_timestamp { get; set; }

    }
    public class MAddress
    {
        public int Out_orgnaddr_rowid { get; set; }
        public string Out_addr_type { get; set; }
        public string Out_addr_type_desc { get; set; }
        public string Out_orgn_addr1 { get; set; }
        public string Out_orgn_addr2 { get; set; }
        public string Out_orgn_country { get; set; }
        public string Out_orgn_country_desc { get; set; }
        public string Out_orgn_state { get; set; }
        public string Out_orgn_state_desc { get; set; }
        public string Out_orgn_dist { get; set; }
        public string Out_orgn_dist_desc { get; set; }
        public string Out_orgn_taluk { get; set; }
        public string Out_orgn_taluk_desc { get; set; }
        public string Out_orgn_panchayat { get; set; }
        public string Out_orgn_panchayat_desc { get; set; }
        public string Out_orgn_village { get; set; }
        public string Out_orgn_village_desc { get; set; }
        public string Out_orgn_pincode { get; set; }
        public string Out_orgn_pincode_desc { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_mode_flag { get; set; }

    }
    public class MBank
    {
        public int Out_orgnbank_rowid { get; set; }
        public string Out_bank_acc_no { get; set; }
        public string Out_bank_acc_type { get; set; }
        public string Out_bank_acc_type_desc { get; set; }
        public string Out_bank_code { get; set; }
        public string Out_bank_desc { get; set; }
        public string Out_branch_code { get; set; }
        public string Out_branch_desc { get; set; }
        public string Out_ifsc_code { get; set; }
        public string Out_dflt_dr_acc { get; set; }
        public string Out_dflt_dr_acc_desc { get; set; }
        public string Out_dflt_cr_acc { get; set; }
        public string Out_dflt_cr_acc_desc { get; set; }
        public string Out_bank_acc_purpose { get; set; }
        public string Out_bank_acc_purpose_desc { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_mode_flag { get; set; }

    }
    public class MFIG
    {
        public int Out_aggrfig_rowid { get; set; }
        public string Out_aggrfig_type { get; set; }
        public string Out_aggrfig_type_desc { get; set; }
        public string Out_aggrfig_code { get; set; }
        public string Out_aggrfig_name { get; set; }
        public string Out_aggrvillage_code { get; set; }
        public string Out_aggrvillage_name { get; set; }
        public string Out_contact_person { get; set; }
        public string Out_contact_no { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_mode_flag { get; set; }

    }
    public class MContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public MHeader Header { get; set; }
        public IList<MAddress> Address { get; set; }
        public IList<MBank> Bank { get; set; }
        public IList<MFIG> FIG { get; set; }
        public int orgn_rowid { get; set; }
        public string orgn_code { get; set; }
        public string aggregator_code { get; set; }
        public string fpo_code { get; set; }

    }
    public class MApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class MApplication
    {
        public MContext context { get; set; }
        public MApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region Mobile Fetch list
    public class AggregatorFetch_application
    {
        public AggrFetchContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }

    public class AggrFetchContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public List<AggeFetchList_Mobile> AggrFetchList_Mob { get; set; }
    }
    public class AggeFetchList_Mobile
    {
        public string FPO_Code { get; set; }
        public string FPO_Name { get; set; }
        public string orgn_code { get; set; }
        public string orgn_name { get; set; }
        public string FPO_ORGN { get; set; }
    }

    #endregion

    #region  SaveInput
    public class SaveAGGAddress
    {
        public int Out_orgnaddr_rowid { get; set; }
        public string Out_addr_type { get; set; }
        public string Out_orgn_addr1 { get; set; }
        public string Out_orgn_addr2 { get; set; }
        public string Out_orgn_country { get; set; }
        public string Out_orgn_state { get; set; }
        public string Out_orgn_dist { get; set; }
        public string Out_orgn_taluk { get; set; }
        public string Out_orgn_panchayat { get; set; }
        public string Out_orgn_village { get; set; }
        public string Out_orgn_pincode { get; set; }
        public string Out_status_code { get; set; }
        public string Out_mode_flag { get; set; }
    }

    public class SaveAGGBank
    {
        public int Out_orgnbank_rowid { get; set; }
        public string Out_bank_acc_no { get; set; }
        public string Out_bank_acc_type { get; set; }
        public string Out_bank_code { get; set; }
        public string Out_branch_code { get; set; }
        public string Out_ifsc_code { get; set; }
        public string Out_dflt_dr_acc { get; set; }
        public string Out_dflt_cr_acc { get; set; }
        public string Out_bank_acc_purpose { get; set; }
        public string Out_status_code { get; set; }
        public string Out_mode_flag { get; set; }
    }

    public class SaveAGGFig
    {
        public int Out_aggrfig_rowid { get; set; }
        public string Out_aggrfig_type { get; set; }
        public string Out_aggrfig_code { get; set; }
        public string Out_aggrfig_name { get; set; }
        public string Out_aggrvillage_code { get; set; }
        public string Out_aggrvillage_name { get; set; }
        public string Out_contact_person { get; set; }
        public string Out_contact_no { get; set; }
        public string Out_status_code { get; set; }
        public string Out_mode_flag { get; set; }
    }

    public class SaveAGGHeader
    {
        public int IOU_orgn_rowid { get; set; }
        public string IOU_aggregator_code { get; set; }
        public string Out_aggregator_type { get; set; }
        public string Out_fpo_code { get; set; }
        public string Out_orgn_code { get; set; }
        public string Out_aggregator_name { get; set; }
        public string Out_aggregator_ll_name { get; set; }
        public string Out_orgn_level { get; set; }
        public string Out_facilitator_code { get; set; }
        public string Out_facilitator_ll_code { get; set; }
        public string Out_member_name { get; set; }
        public string Out_member_ll_name { get; set; }
        public string Out_status_code { get; set; }
        public string Out_mode_flag { get; set; }
        public string Out_row_timestamp { get; set; }
        public List<SaveAGGAddress> Address { get; set; }
        public List<SaveAGGBank> Bank { get; set; }
        public List<SaveAGGFig> Fig { get; set; }
    }

    public class SaveAGGContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public SaveAGGHeader Header { get; set; }
    }

    public class SaveAGGDocument
    {
        public SaveAGGContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }

    public class SaveAggregatorRegistration
    {
        public SaveAGGDocument document { get; set; }
    }

    #endregion

    #region  SaveOutput
    public class OutputAGGHeader
    {
        public int IOU_orgn_rowid { get; set; }
        public string IOU_aggregator_code { get; set; }
    }

    public class OutputAGGContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public OutputAGGHeader Header { get; set; }
    }
    public class OutputAggregatorRegistration
    {
        public OutputAGGContext context { get; set; }
      
    }

    #endregion
}
