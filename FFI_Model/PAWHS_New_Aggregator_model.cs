using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class PAWHS_New_Aggregator_model
    {
    }
    #region List
    public class New_PAWHSAggregator_all_RootObject
    {
        public New_PAWHSAggregator_all_Context context { get; set; }
        public New_PAWHSAggregator_all_ApplicationException ApplicationException { get; set; }
    }
    public class New_PAWHSAggregator_all_Application
    {
        public New_PAWHSAggregator_all_Context context { get; set; }
        public New_PAWHSAggregator_all_ApplicationException ApplicationException { get; set; }

    }

    public class New_PAWHSAggregator_all_ApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class New_PAWHSAggregator_all_Context
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }
        public IList<New_PAWHSAggregator_all_List> List { get; set; }

    }
   


    public class New_PAWHSAggregator_all_List
    {
        //product_rowid, agg_code,product_code,product_name,product_category,product_subcategory,hsn_code,hsn_description
        public int Out_orgn_rowid { get; set; }
        public string Out_aggregator_code { get; set; }
        public string Out_aggregator_name { get; set; }
        public string Out_orgn_level { get; set; }
        public string Out_aggregator_type { get; set; }
        public string Out_status_code { get; set; } 
        public string Out_status_desc { get; set; }
        public string Out_row_timestamp { get; set; }

    }

    #endregion

    #region Fetch 

    public class New_PAWHSAggregator_single_Application
    {
        //public PAWHSProductmasterFDocument document { get; set; }
        public New_PAWHSAggregator_single_Context context { get; set; }

    } 

    public class New_PAWHSAggregator_single_Context
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        //public int IOU_orgn_rowid { get; set; }
        //public string IOU_aggregator_code { get; set; }
        public New_PAWHSAggregator_single_Header Header { get; set; }
        public IList<New_PAWHSAggregator_single_Address> Address { get; set; }
        public IList<New_PAWHSAggregator_single_Bank> Bank { get; set; }
        public IList<New_PAWHSAggregator_single_FIG> FIG { get; set; }
    }

    public class New_PAWHSAggregator_single_Header
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
    }

    public class New_PAWHSAggregator_single_Address
    {
        public int IOU_orgn_rowid { get; set; }
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

    public class New_PAWHSAggregator_single_Bank
    {
        public int IOU_orgn_rowid { get; set; }
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

    public class  New_PAWHSAggregator_single_FIG
    {
        public int IOU_orgn_rowid { get; set; }
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
    #endregion

    #region Save

    public class New_PAWHSAggregator_SApplication
    {
        public New_PAWHSAggregator_SDocument document { get; set; }

    }
    public class New_PAWHSAggregator_SDocument
    {
        public New_PAWHSAggregator_SContext context { get; set; }

    }
    public class New_PAWHSAggregator_SContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
      

        public New_PAWHSAggregator_saveHeader Header { get; set; }
        public IList<New_PAWHSAggregator_save_Address> Address { get; set; }
        public IList<New_PAWHSAggregator_save_Bank> Bank { get; set; }
        public IList<New_PAWHSAggregator_save_FIG> FIG { get; set; }

    }

    public class New_PAWHSAggregator_saveHeader
    {
        public int IOU_orgn_rowid { get; set; }
        public string IOU_aggregator_code { get; set; }
        public string Out_aggregator_type { get; set; } 
        public string Out_fpo_code { get; set; } 
        public string Out_aggregator_name { get; set; }
        public string Out_aggregator_ll_name { get; set; }
        public string Out_orgn_level { get; set; }
        public string Out_facilitator_code { get; set; } 
        public string Out_facilitator_ll_code { get; set; }
        public string Out_facilitator_ll_name { get; set; }
        public string Out_member_name { get; set; }
        public string Out_member_ll_name { get; set; }
        public string Out_status_code { get; set; } 
        public string Out_mode_flag { get; set; }
        public string Out_row_timestamp { get; set; }
    }

    public class New_PAWHSAggregator_save_Address
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

    public class New_PAWHSAggregator_save_Bank
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

    public class New_PAWHSAggregator_save_FIG
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

    #endregion

}
