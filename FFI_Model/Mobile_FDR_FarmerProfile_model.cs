using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
   public class Mobile_FDR_FarmerProfile_model
    {
        public MFPHeaderDetails MFarmerHeaderDetails { get; set; }
       
    }
    public class MFPHeaderDetails
    {
        
        public int in_farmer_rowid { get; set; }
       
        public string in_farmer_code { get; set; }

        public string in_fpo_orgncode { get; set; }
        public int in_version_no { get; set; }
     
        public string in_farmer_name { get; set; }
      
        public string in_photo_farmer { get; set; }
       
        public string in_sur_name { get; set; }
      
        public string in_fhw_name { get; set; }
       
        public string in_farmer_addr1 { get; set; }
       
        public string in_farmer_addr2 { get; set; }
       
        public string in_farmer_dob { get; set; }
       
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
       
        public string in_row_timestamp { get; set; }
       
        public string orgnId { get; set; }
      
        public string locnId { get; set; }
      
        public string userId { get; set; }
       
        public string localeId { get; set; }
        public string instance { get; set; }
        public string in_mode_flag { get; set; }
        public string in_dup_flag { get; set; }
        public List<MFPBankDetails> MfarmerBankDetails { get; set; }
        public List<MFPkYCDetails> MfarmerKycDetails { get; set; }
        //public List<Address> MfarmerAddressDetails { get; set; }
        public List<List<MFPAdderssDetails>> MfarmerAddressDetails { get; set; }
        public List<List<MFPAdderssDetails>> Mfarmercrop { get; set; }
        public List<List<MFPAdderssDetails>> Mfarmercropsowing { get; set; }
        public List<List<MFPAdderssDetails>> Mfarmerpersonal { get; set; }
        public List<List<MFPAdderssDetails>> Mfarmerfamily { get; set; }
        public List<List<MFPAdderssDetails>> Mfarmerloans { get; set; }
        public List<List<MFPAdderssDetails>> MfarmerloansrePay { get; set; }
        public List<List<MFPAdderssDetails>> Mfarmerland { get; set; }
        public List<List<MFPAdderssDetails>> Mfarmerlivestock { get; set; }
        public List<List<MFPAdderssDetails>> MfarmerAssets { get; set; }
        public List<List<MFPAdderssDetails>> Mfarmerinsurance { get; set; }
        public List<List<MFPAdderssDetails>> MfarmerInputs { get; set; }
        public List<List<MFPAdderssDetails>> Mfarmerproduction { get; set; }
        public List<List<MFPAdderssDetails>> Mfarmersale { get; set; }
        public List<List<MFPAdderssDetails>> Mfarmerstock { get; set; }
        public List<List<MFPAdderssDetails>> Mfarmertraning { get; set; }
        public List<List<MFPAdderssDetails>> Mfarmershareholding { get; set; }
        public List<List<MFPAdderssDetails>> Mfarmerbusiness { get; set; }
        public List<List<MFPAdderssDetails>> Mfarmerloanreq { get; set; }
    }

    public class MFPBankDetails
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
    public class MFPkYCDetails
    {
        public int in_farmerkyc_rowid { get; set; }
        public string in_proof_type { get; set; }
        public string in_proof_doc { get; set; }
        public string in_proof_doc_no { get; set; }
        public string in_proof_doc_adharno { get; set; }
        public string in_proof_valid_till { get; set; }
        public string in_status_code { get; set; }
        public string in_mode_flag { get; set; }
        public string in_photo_kyc { get; set; }

    }
    public class Address
    {
        public List<MFPAdderssDetails1> MFPAdderssDetails1 { get; set; }

    }
    public class MFPAdderssDetails
    {
        public int in_farmerdetail_rowid { get; set; }
        public string in_entitygrp_code { get; set; }
        public string in_entity_code { get; set; }
        public string in_row_slno { get; set; }
        public string in_entity_value { get; set; }
        public string in_owned_picture { get; set; }
        public string in_mode_flag { get; set; }
        //public List<MFPAdderssDetails1> MFPAdderssDetails1 { get; set; }
    }
    public class MFPAdderssDetails1
    {
        public int in_farmerdetail_rowid { get; set; }
        public string in_entitygrp_code { get; set; }
        public string in_entity_code { get; set; }
        public string in_row_slno { get; set; }
        public string in_entity_value { get; set; }
        public string in_mode_flag { get; set; }
    }
    public class FarmerProfileOutput
    {
        public int in_farmer_rowid { get; set; }
        public string in_farmer_code { get; set; }
        public int in_version_no { get; set; }
        public string error_msg { get; set; }
    }
}


