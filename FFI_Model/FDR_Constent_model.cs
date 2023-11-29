using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class FDR_Constent_model
    {
    }
    #region List
    public class tempalteContextDtl
    {
        public int template_id { get; set; }
        public string template_consent { get; set; }
        public string effective_From { get; set; }
        public string effective_to { get; set; }
        public string lang_code { get; set; }
        public string status_code { get; set; }
        public string status_desc { get; set; }
    }

    public class tempalteContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public string instance { get; set; }
        public List<tempalteContextDtl> tempalteContextDtl { get; set; }
    }

    public class tempalteList
    {
        public tempalteContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion

    #region save

    public class fdrconstentDetail
    {
        public int In_farmerconsent_rowid { get; set; }
        public string In_template_id { get; set; }
        public string In_consent_owner_id { get; set; }
        public string In_consent_to { get; set; }
        public string In_lang_code { get; set; }
        public string In_otp { get; set; }
        public string In_otp_flag { get; set; }
        public string In_isverified { get; set; }
        public string In_attach_consent { get; set; }
        public string In_attachment_flag { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_mobile_no { get; set; }
        public string In_attach_type { get; set; }
        public string In_verified_date { get; set; }
    }

    public class fdrconstentContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public string instance { get; set; }
        public fdrconstentDetail Header { get; set; }
    }

    public class fdrconstentDocument
    {
        public fdrconstentContext context { get; set; }
    }

    public class fdrconstentroot
    {
        public fdrconstentDocument document { get; set; }
    }


    #endregion

    #region List fetch
    public class fdrconstentDtl
    {
        public int In_farmerconsent_rowid { get; set; }
        public string In_template_id { get; set; }
        public string In_consent_owner_id { get; set; }
        public string In_consent_to { get; set; }
        public string In_lang_code { get; set; }
        public string template_consent { get; set; }
        public string In_otp_flag { get; set; }
        public string In_isverified { get; set; }
        public string In_attach_consent { get; set; }
        public string In_attachment_flag { get; set; }
        public string In_mobile_no { get; set; }
        public string In_attach_type { get; set; }
        public string In_verified_date { get; set; }
    }

    public class fdrconstentfetchContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public string instance { get; set; }
        public string In_farmer_code { get; set; }
        public List<fdrconstentDtl> fdrconstentDtl { get; set; }
    }

    public class fdrconstentfetch
    {
        public fdrconstentfetchContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion


    #region gps

    public class gpsDetail
    {
        public string In_qrvalue { get; set; }
        public string In_latitude { get; set; }
        public string In_longitude { get; set; }
        public string In_date { get; set; }
        public string In_input_start_time { get; set; }
        public string In_input_close_time { get; set; }
        public string In_pa_start_time { get; set; }
        public string In_pa_close_time { get; set; }
        public string In_usercode { get; set; }
        public int In_usergps_id { get; set; }
        public string In_mode_flag { get; set; }
        public string errorNo { get; set; }
        public Int32 IOU_usergps_id { get; set; }
    }

    public class gpsContext
    {   
        public string instance { get; set; }
        public gpsDetail Header { get; set; }
    }

    public class gpsDocument
    {
        public gpsContext context { get; set; }
    }

    public class gpsroot
    {
        public gpsDocument document { get; set; }
    }
    #endregion

}
