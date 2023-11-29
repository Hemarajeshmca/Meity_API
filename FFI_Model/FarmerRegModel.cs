using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    public class FarmerRegModel
    {

    }

    #region SingleFetch
    public class FHeader
    {
        public int in_farmer_rowid { get; set; }
        public string in_farmer_code { get; set; }
        //Prema added for meity demo changes on may 16
        public string in_member_id { get; set; }
        public string in_fpo_name { get; set; }
        //END
        public int in_version_no { get; set; }
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
        public string in_farmer_country_desc { get; set; }
        public string in_farmer_country_ll_desc { get; set; }
        public string in_farmer_state { get; set; }
        public string in_farmer_state_desc { get; set; }
        public string in_farmer_state_ll_desc { get; set; }
        public string in_farmer_dist { get; set; }
        public string in_farmer_dist_desc { get; set; }
        public string in_farmer_dist_ll_desc { get; set; }
        public string in_farmer_taluk { get; set; }
        public string in_farmer_taluk_desc { get; set; }
        public string in_farmer_taluk_ll_desc { get; set; }
        public string in_farmer_panchayat { get; set; }
        public string in_farmer_panchayat_desc { get; set; }
        public string in_farmer_panchayat_ll_desc { get; set; }
        public string in_farmer_village { get; set; }
        public string in_farmer_village_desc { get; set; }
        public string in_farmer_village_ll_desc { get; set; }
        public string in_farmer_pincode { get; set; }
        public string in_farmer_pincode_desc { get; set; }
        public string in_marital_status { get; set; }
        public string in_marital_status_desc { get; set; }
        public string in_gender_flag { get; set; }
        public string in_gender_flag_desc { get; set; }
        public string in_reg_mobile_no { get; set; }
        public string in_reg_note { get; set; }
        public string in_status_code { get; set; }
        public string in_status_desc { get; set; }
        public string in_mode_flag { get; set; }
        public string in_row_timestamp { get; set; }
        public string Aadhar_no { get; set; }

    }

    public class FKyc
    {
        public int in_farmerkyc_rowid { get; set; }
        public string in_proof_type { get; set; }
        public string in_proof_type_desc { get; set; }
        public string in_proof_doc { get; set; }
        public string in_proof_doc_desc { get; set; }
        public string in_proof_doc_no { get; set; }
        public string in_proof_doc_adharno { get; set; }
        public string in_proof_valid_till { get; set; }
        public string in_status_code { get; set; }
        public string in_status_desc { get; set; }
        public string in_mode_flag { get; set; }
        public string in_photo_kyc { get; set; }
    }

    public class FBank
    {
        public int in_farmerbank_rowid { get; set; }
        public string in_bank_acc_no { get; set; }
        public string in_bank_acc_type { get; set; }
        public string in_bank_acc_type_desc { get; set; }
        public string in_bank_code { get; set; }
        public string in_bank_desc { get; set; }
        public string in_branch_code { get; set; }
        public string in_branch_desc { get; set; }
        public string in_ifsc_code { get; set; }
        public string in_dflt_dr_acc { get; set; }
        public string in_dflt_dr_acc_desc { get; set; }
        public string in_dflt_cr_acc { get; set; }
        public string in_dflt_cr_acc_desc { get; set; }
        public string in_status_code { get; set; }
        public string in_status_desc { get; set; }
        public string in_mode_flag { get; set; }
    }
    public class constentDtl
    {
        public int In_farmerconsent_rowid { get; set; }
        public string In_template_id { get; set; }
        public string In_consent_owner_id { get; set; }
        public string In_consent_to { get; set; }
        public string In_consent_to_desc { get; set; }
        public string In_lang_code { get; set; }
        public string template_consent { get; set; }
        public string In_otp_flag { get; set; }
        public string In_isverified { get; set; }
        public string In_attach_consent { get; set; }
        public string In_attachment_flag { get; set; }
        public string In_mobile_no { get; set; }
        public string In_attach_type { get; set; }
        public string In_verified_date { get; set; }
        public string in_isverified_code { get; set; }
    }
    public class FContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; } 
        public FHeader header { get; set; }
        public List<FKyc> kyc { get; set; }
        public List<FBank> bank { get; set; }
        public List<constentDtl> consent { get; set; }
    }

    public class FRootObject
    {
        public FContext context { get; set; }
        public object ApplicationException { get; set; }
    }
    #endregion 

    #region GetFarmersList

    public class GetFarmerParam
    {
        public string org { get; set; }
        public string locn { get; set; }
        public string user { get; set; }
        public string lang { get; set; }
        public string filterby_option { get; set; }
        public string filterby_code { get; set; }
        public string filterby_fromvalue { get; set; }
        public string filterby_tovalue { get; set; }
        public int out_record_count { get; set; }
        public int from_index { get; set; }
        public int to_index { get; set; }
        public int record_count { get; set; }
    }
    public class FarmerFilter
    {
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }
        public int out_record_count { get; set; }
        public int from_index { get; set; }
        public int to_index { get; set; }
        public int record_count { get; set; }
    }

    public class FarmerList
    {
        public int out_farmer_rowid { get; set; }
        public string out_farmer_code { get; set; }
        public int out_version_no { get; set; }
        public string out_photo_farmer { get; set; }
        //Prema added for meity demo changes on may 16
        public string out_member_id { get; set; }
        public string out_fpo_name { get; set; }
        //END
        public string out_farmer_name { get; set; }
        public string out_sur_name { get; set; }
        public string out_fhw_name { get; set; }
        public string out_farmer_dob { get; set; }
        public string out_farmer_addr1 { get; set; }
        public string Hamlet { get; set; } //Sanjay Field visit changes on April 12
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
    }
    public class FarmerQrContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public string FarmerCode { get; set; }
    }

        public class FarmerContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FarmerFilter Filter { get; set; }
        public List<FarmerList> List { get; set; }
    }

    public class FarmerApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }
    }

    public class FarmerRootObject
    {
        public FarmerContext context { get; set; }
        public FarmerApplicationException ApplicationException { get; set; }
    }

    #endregion

    #region SaveFarmer
    public class SFarmerHeaderSegment
    {
        public int in_farmer_rowid { get; set; }
        public string in_farmer_code { get; set; }
        public string in_fpo_orgncode { get; set; }
        public int in_version_no { get; set; }
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
        public string in_row_timestamp { get; set; }
        public string Aadhar_no { get; set; } //live changes field visit on April 17th
        public string in_dup_flag { get; set; }// ramya added on 23 jun 21 for Potential Duplicate
    }

    public class SFarmerKycSegment
    {
        public int in_farmerkyc_rowid { get; set; }
        public string in_proof_type { get; set; }
        public string in_proof_doc { get; set; }
        public string in_proof_doc_no { get; set; }
        public string in_proof_doc_adharno { get; set; }
        public string in_proof_valid_till { get; set; }
        public string in_status_code { get; set; }
        public string in_mode_flag { get; set; }
    }

    public class SFarmerBankSegment
    {
        public int in_farmerbank_rowid { get; set; }
        public string in_bank_acc_no { get; set; }
        public string in_bank_acc_type { get; set; }
        public string in_bank_code { get; set; }
        public string in_branch_code { get; set; }
        public string in_ifsc_code { get; set; }
        public string in_dflt_dr_acc { get; set; }
        public string in_dflt_cr_acc { get; set; }
        public string in_status_code { get; set; }
        public string in_mode_flag { get; set; }
    }

    public class SFarmerContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public int in_farmer_rowid { get; set; }
        public string in_farmer_code { get; set; }
        public int in_version_no { get; set; }
        public SFarmerHeaderSegment Header { get; set; }
        public List<SFarmerKycSegment> KYC { get; set; }
        public List<SFarmerBankSegment> Bank { get; set; }
    }

    public class SFarmerDocument
    {
        public SFarmerContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    public class ApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }

    public class SFarmerRootObject
    {
        public SFarmerDocument document { get; set; }
    }

    #endregion


    #region View Content
    public class FView
    {
        public int in_farmer_tacrowid { get; set; }
        public string in_farmer_code { get; set; }
        public string in_farmer_codeview { get; set; }
        public int in_farmer_OTP { get; set; }
        public string in_farmer_URl { get; set; }
        public string in_created_datetime { get; set; }
        public string FPO_Name { get; set; }
    }



    public class FContextview
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FView header { get; set; }
     
    }

    public class FRootObjectview
    {
        public FContextview context { get; set; }
        public object ApplicationException { get; set; }
    }

    #endregion

}
