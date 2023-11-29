using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class Mobile_FDR_FHeader_model
    {
    }
    #region save farmer header
    public class MFHHeader
    {
        public int in_farmer_rowid { get; set; }
        public string in_farmer_code { get; set; }
        public int in_version_no { get; set; }
        public string in_fpo_orgncode { get; set; }
        public string in_photo_farmer { get; set; }
        public string in_farmer_name { get; set; }
        public string in_sur_name { get; set; }
        public string in_fhw_name { get; set; }
        public string in_farmer_dob { get; set; }
        public string in_farmer_addr1 { get; set; }
        public string in_farmer_addr2 { get; set; }        
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
        public string in_created_by { get; set; }
        public string Aadhar_no { get; set; } //live changes field visit on April 17th
        public string in_dup_flag { get; set; }// ramya added on 23 jun 21 for Potential Duplicate
    }
    public class MFHContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public MFHHeader Header { get; set; }
        public string instance { get; set; }
    }
    public class MFHDocument
    {
        public MFHContext context { get; set; }
        public MFHApplicationException ApplicationException { get; set; }
    }
    public class MFHApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class MFHApplication
    {
        public MFHDocument document { get; set; }

    }
    #endregion

    #region kycsave
    public class MFKKYC
    {
        public string in_farmer_code { get; set; }
        public string in_farmer_name { get; set; }
        public int in_farmerkyc_rowid { get; set; }
        public string in_proof_type { get; set; }
        public string in_proof_doc { get; set; }
        public string in_proof_doc_no { get; set; }
        public string in_proof_doc_adharno { get; set; }
        public string in_proof_valid_till { get; set; }
        public string in_status_code { get; set; }
        public string in_mode_flag { get; set; }
        public string in_created_by { get; set; }
        public string in_modified_by { get; set; }
        public string in_photo_kyc { get; set; }
    }
    public class MFKContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public MFKKYC KYC { get; set; }
        public string instance { get; set; }
    }
    public class MFKDocument
    {
        public MFKContext context { get; set; }

        public MFKApplicationException ApplicationException { get; set; }
    }
    public class MFKApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class MFKApplication
    {
        public MFKDocument document { get; set; }

    }
    #endregion
    #region bank save
    public class MFBBank
    {
        public string in_farmer_code { get; set; }
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
        public string in_created_by { get; set; }
        public string in_modified_by { get; set;}
    }
    public class MFBContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public MFBBank Bank { get; set; }
        public string instance { get; set; }
    }
    public class MFBDocument
    {
        public MFBContext context { get; set; }

        public MFBApplicationException ApplicationException { get; set; }
    }
    public class MFBApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class MFBApplication
    {
        public MFBDocument document { get; set; }

    }
    #endregion
    
}
