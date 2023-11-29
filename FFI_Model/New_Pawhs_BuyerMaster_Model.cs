using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    public class New_Pawhs_BuyerMaster_Model
    {
        #region List
        public class PawhsBuyerMasterRootObject
        {
            public PawhsBuyerMasterContext context { get; set; }
            public PawhsBuyerMasterApplicationException ApplicationException { get; set; }
        }
        public class PawhsBuyerMasterApplication
        {
            public PawhsBuyerMasterContext context { get; set; }
            public PawhsBuyerMasterApplicationException ApplicationException { get; set; }

        }
        public class PawhsBuyerMasterApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class PawhsBuyerMasterContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public string FilterBy_Option { get; set; }
            public string FilterBy_Code { get; set; }
            public string FilterBy_FromValue { get; set; }
            public string FilterBy_ToValue { get; set; }
            public IList<PawhsBuyerMasterList> List { get; set; }

        }
        public class PawhsBuyerMasterList
        {

            public int Out_buyer_rowid { get; set; }
            public string Out_agg_code { get; set; }
            public string Out_agg_name { get; set; }
            public string Out_buyer_code { get; set; }
            public string Out_version_no { get; set; }
            public string Out_buyer_name { get; set; }
            public string Out_pan_no { get; set; }
            public string Out_status_code { get; set; }
            public string Out_status_desc { get; set; }
            public string Out_row_timestamp { get; set; }

            public string Out_mob_no { get; set; }
            public string Out_whatsapp_no { get; set; }
            public string Out_contact_person { get; set; }
            public string Out_emailid { get; set; }
            public string Out_onboarding_date { get; set; }
            public string Out_buyer_type { get; set; }

        }
        #endregion
        #region Fetch 

        public class PawhsBuyerMasterFetchApplication
        {

            public PawhsBuyerMasterFetchContext context { get; set; }

        }
        public class PawhsBuyerMasterFetchContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }

            public int buyer_rowid { get; set; }
            public string buyer_code { get; set; }
            public int version_no { get; set; }
            public PawhsBuyerMasterFetchHeader Header { get; set; }
            public IList<PawhsBuyerMasterFetchAddress> buyerAddress { get; set; }
            public IList<PawhsBuyerMasterFetchTax> buyerTax { get; set; }
        }
        public class PawhsBuyerMasterFetchHeader
        {
            public Int32 In_buyer_rowid { get; set; }
            public string In_buyer_code { get; set; }
            public Int32 In_version_no { get; set; }
            public string In_buyer_name { get; set; }
            public string In_pan_no { get; set; }
            public string In_status_code { get; set; }
            public string In_status_desc { get; set; }
            public string In_mode_flag { get; set; }
            public string In_row_timestamp { get; set; }
            public string In_agg_code { get; set; }
            public string In_agg_name { get; set; }
            public string In_MobileNo { get; set; }
            public string In_WhatsappeNo { get; set; }
            public string In_Contact_name { get; set; }
            public string In_Email { get; set; }
            public string In_Onboard_Date { get; set; }
            public string In_buyer_type { get; set; }

        }
        public class PawhsBuyerMasterFetchAddress
        {
            public string buyerAddress { get; set; }
            public int In_buyer_addr_rowid { get; set; }
            public string In_buyeraddr_type { get; set; }
            public string In_buyer_addr_type_desc { get; set; }
            public string In_buyer_addr1 { get; set; }
            public string In_buyer_addr2 { get; set; }
            public string In_buyer_country { get; set; }
            public string In_buyer_country_desc { get; set; }
            public string In_buyer_state { get; set; }
            public string In_buyer_state_desc { get; set; }
            public string In_buyer_dist { get; set; }
            public string In_buyer_dist_desc { get; set; }
            public string In_buyer_taluk { get; set; }
            public string In_buyer_taluk_desc { get; set; }
            public string In_buyer_panchayat { get; set; }
            public string In_buyer_panchayat_desc { get; set; }
            public string In_buyer_village { get; set; }
            public string In_buyer_village_desc { get; set; }
            public string In_buyer_pincode { get; set; }
            public string In_buyer_pincode_desc { get; set; }
            public string In_status_code { get; set; }
            public string In_status_desc { get; set; }
            public string In_mode_flag { get; set; }
        }
        public class PawhsBuyerMasterFetchTax
        {
            public string buyerTax { get; set; }
            public int In_tax_rowid { get; set; }
            public string In_tax_type { get; set; }
            public string In_tax_reg_no { get; set; }
            public string In_state_code { get; set; }
            public string In_state_desc { get; set; }
            public string In_status_code { get; set; }
            public string In_status_desc { get; set; }
            public string In_mode_flag { get; set; }
        }


        #endregion
        #region Save
        public class SavebuyerHeader
        {
            public int In_buyer_rowid { get; set; }
            public string In_buyer_code { get; set; }
            public int In_version_no { get; set; }
            public string In_buyer_name { get; set; }
            public string In_pan_no { get; set; }
            public string In_status_code { get; set; }
            public string In_mode_flag { get; set; }
            public string In_row_timestamp { get; set; }
            public int In_buyer_rowid1 { get; set; }
            public string In_buyer_code1 { get; set; }
            public string errorNo { get; set; }
            public string In_MobileNo { get; set; }
            public string In_WhatsappeNo { get; set; }
            public string In_Contact_name { get; set; }
            public string In_Email { get; set; }
            public string In_Onboard_Date { get; set; }
            public string module_code { get; set; }
        }
        public class SavebuyerAddress
        {
            public string In_buyer_code { get; set; }
            public int In_version_no { get; set; }
            public int In_buyeraddr_rowid { get; set; }
            public string In_buyeraddr_type { get; set; }
            public string In_buyer_addr1 { get; set; }
            public string In_buyer_addr2 { get; set; }
            public string In_buyer_country { get; set; }
            public string In_buyer_state { get; set; }
            public string In_buyer_dist { get; set; }
            public string In_buyer_taluk { get; set; }
            public string In_buyer_panchayat { get; set; }
            public string In_buyer_village { get; set; }
            public string In_buyer_pincode { get; set; }
            public string In_status_code { get; set; }
            public string In_mode_flag { get; set; }
            public string errorNo { get; set; }
        }
        public class SavebuyerTax
        {
            public string In_buyer_code { get; set; }
            public int In_version_no { get; set; }
            public int In_tax_rowid { get; set; }
            public string In_tax_type { get; set; }
            public string In_tax_reg_no { get; set; }
            public string In_state_code { get; set; }
            public string In_status_code { get; set; }
            public string In_mode_flag { get; set; }

        }
        public class SavebuyerContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public SavebuyerHeader Header { get; set; }
            public IList<SavebuyerAddress> buyerAddress { get; set; }
            public IList<SavebuyerTax> buyerTax { get; set; }

        }
        public class SavebuyerDocument
        {
            public SavebuyerContext context { get; set; }
            public PawhsBuyerMasterApplicationException ApplicationException { get; set; }

        }
        public class SavebuyerApplication
        {
            public SavebuyerDocument document { get; set; }

        }
        #endregion
    }
}
