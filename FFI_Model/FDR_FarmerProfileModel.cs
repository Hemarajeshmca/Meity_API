using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class FDR_FarmerProfileModel
    {
    }
    #region List
    public class FPFilter
    {
        public int out_record_count { get; set; }
    }

    public class FPList
    {
        public int out_farmer_rowid { get; set; }
        public string out_farmer_code { get; set; }
        public int out_version_no { get; set; }
        public string out_photo_farmer { get; set; }
        public string out_farmer_name { get; set; }
        public string out_sur_name { get; set; }
        public string out_fhw_name { get; set; }
        public string out_farmer_dob { get; set; }
        public string out_farmer_addr1 { get; set; }
        public string out_farmer_addr2 { get; set; }
        public string out_farmer_ll_name { get; set; }
        public string out_sur_ll_name { get; set; }
        public string out_fhw_ll_name { get; set; }
        public string out_farmer_ll_addr1 { get; set; }
        public string out_farmer_ll_addr2 { get; set; }
        public string out_farmer_country { get; set; }
        public string out_farmer_country_desc { get; set; }
        public string out_farmer_state { get; set; }
        public string out_farmer_state_desc { get; set; }
        public string out_farmer_dist { get; set; }
        public string out_farmer_dist_desc { get; set; }
        public string out_farmer_taluk { get; set; }
        public string out_farmer_taluk_desc { get; set; }
        public string out_farmer_panchayat { get; set; }
        public string out_farmer_panchayat_desc { get; set; }
        public string out_farmer_village { get; set; }
        public string out_farmer_village_desc { get; set; }
        public string out_farmer_pincode { get; set; }
        public string out_farmer_pincode_desc { get; set; }
        public string out_marital_status { get; set; }
        public string out_marital_status_desc { get; set; }
        public string out_gender_flag { get; set; }
        public string out_gender_flag_desc { get; set; }
        public string out_reg_mobile_no { get; set; }
        public string out_reg_note { get; set; }
        public string out_status_code { get; set; }
        public string out_status_desc { get; set; }
        public string out_row_timestamp { get; set; }
        //Prema added for meity demo changes on May 13
        public string out_member_id { get; set; }
        public string out_fpo_name { get; set; }
        //Prema end
    }

    public class FPContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FPFilter Filter { get; set; }
        public List<FPList> List { get; set; }
    }
    public class FarmerProfileList
    {
        public FPContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion

    #region SingleFetch
    public class FetchFPHeader
    {
        public int inout_farmer_rowid { get; set; }
        public string inout_farmer_code { get; set; }
        public int inout_version_no { get; set; }
        public string out_photo_farmer { get; set; }
        public string out_farmer_name { get; set; }
        public string out_sur_name { get; set; }
        public string out_fhw_name { get; set; }
        public string out_farmer_dob { get; set; }
        public string out_farmer_addr1 { get; set; }
        public string out_farmer_addr2 { get; set; }
        public string out_farmer_ll_name { get; set; }
        public string out_sur_ll_name { get; set; }
        public string out_fhw_ll_name { get; set; }
        public string out_farmer_ll_addr1 { get; set; }
        public string out_farmer_ll_addr2 { get; set; }
        public string out_farmer_country { get; set; }
        public string out_farmer_country_desc { get; set; }
        public string out_farmer_state { get; set; }
        public string out_farmer_state_desc { get; set; }
        public string out_farmer_dist { get; set; }
        public string out_farmer_dist_desc { get; set; }
        public string out_farmer_taluk { get; set; }
        public string out_farmer_taluk_desc { get; set; }
        public string out_farmer_panchayat { get; set; }
        public string out_farmer_panchayat_desc { get; set; }
        public string out_farmer_village { get; set; }
        public string out_farmer_village_desc { get; set; }
        public string out_farmer_pincode { get; set; }
        public string out_farmer_pincode_desc { get; set; }
        public string out_marital_status { get; set; }
        public string out_marital_status_desc { get; set; }
        public string out_gender_flag { get; set; }
        public string out_gender_flag_desc { get; set; }
        public string out_reg_mobile_no { get; set; }
        public string out_reg_note { get; set; }
        public string out_status_code { get; set; }
        public string out_status_desc { get; set; }
        public string out_mode_flag { get; set; }
        public string out_row_timestamp { get; set; }
        public string out_fpo_name { get; set; }
        public string out_member_id { get; set; }
        public string out_detail { get; set; }
    }

    public class FetchFPDynamic
    {
        public int out_sl_no { get; set; }
        public string out_dynamic_list { get; set; }
    }

    public class FetchFPContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FetchFPHeader header { get; set; }
        public List<FetchFPDynamic> dynamic { get; set; }
    }

    public class FarmerProfileFetch
    {
        public FetchFPContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion
    #region Save FarmerProfileInput
    public class SaveFPHeader
    {
        public int inout_farmer_rowid { get; set; }
        public string inout_farmer_code { get; set; }
        public int inout_version_no { get; set; }
        public string in_photo_farmer { get; set; }
        public string in_farmer_name { get; set; }
        public string in_sur_name { get; set; }
        public string in_fhw_name { get; set; }
        public string in_farmer_dob { get; set; }
        public string in_farmer_addr1 { get; set; }
        public string in_farmer_addr2 { get; set; }
        public string in_farmer_ll_name { get; set; }
        public string in_sur_ll_name { get; set; }
        public string in_fhw_ll_name { get; set; }
        public string in_farmer_ll_addr1 { get; set; }
        public string in_farmer_ll_addr2 { get; set; }
        public string in_farmer_country { get; set; }
        public string in_farmer_state { get; set; }
        public string in_farmer_dist { get; set; }
        public string in_farmer_taluk { get; set; }
        public string in_farmer_panchayat { get; set; }
        public string in_farmer_village { get; set; }
        public string in_farmer_pincode { get; set; }
        public string in_marital_status { get; set; }
        public string in_gender_flag { get; set; }
        public string in_reg_mobile_no { get; set; }
        public string in_reg_note { get; set; }
        public string in_status_code { get; set; }
        public string in_mode_flag { get; set; }
        //Prema added for meity demo changes on May 13
        public string in_fpo_name { get; set; }
        public string in_member_id { get; set; }
        //END
        public string in_row_timestamp { get; set; }
    }

    public class SaveFPDetail
    {
        public int in_farmerdetail_rowid { get; set; }
        public string in_entitygrp_code { get; set; }
        public string in_entity_code { get; set; }
        public string in_row_slno { get; set; }
        public string in_entity_value { get; set; }
        public string in_mode_flag { get; set; }
    }

    public class SaveFPContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public SaveFPHeader Header { get; set; }
        public List<SaveFPDetail> Detail { get; set; }
    }

    public class SaveFPDocument
    {
        public SaveFPContext context { get; set; }
    }

    public class SaveFarmerProfile
    {
        public SaveFPDocument document { get; set; }
    }
    #endregion
    #region SaveOutput
    public class OutFPHeader
    {
        public int inout_farmer_rowid { get; set; }
        public string inout_farmer_code { get; set; }
        public int inout_version_no { get; set; }
    }

    public class OutFPContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public OutFPHeader Header { get; set; }
    }
    public class OutputFarmerProfile
    {
        public OutFPContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion
}
