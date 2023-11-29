using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
   public class FISProcessShareAppModel
    {
    }
    #region list
    public class ProcessList
    {
        public int Out_shareapp_rowid { get; set; }
        public string Out_shareapp_no { get; set; }
        public string Out_fpoorgn_code { get; set; }
        public string Out_farmer_code { get; set; }
        public string Out_fpomember_code { get; set; }
        public string Out_member_name { get; set; }
        public string Out_farmer_name { get; set; }
        public string Out_sur_name { get; set; }
        public string Out_applied_on { get; set; }
        public Double Out_applied_shares { get; set; }
        public Double Out_amount_due { get; set; }
        public string Out_payment_mode { get; set; }
        public string Out_payment_mode_desc { get; set; }
        public string Out_payment_ref_no { get; set; }
        public string Out_payment_status { get; set; }
        public string Out_payment_status_desc { get; set; }
        public string Out_shareapp_remark { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }

    }  
    public class AllContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<ProcessList> List { get; set; }
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }

    }

    public class AllApplication
    {
        public AllContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }

    }
    #endregion

    #region fetch
    public class FetchHeader
    {
        public int IOU_shareapp_rowid { get; set; }
        public string IOU_fpoorgn_code { get; set; }
        public string In_shareapp_no { get; set; }
        public string In_farmer_code { get; set; }
        public string In_fpomember_code { get; set; }
        public string In_member_name { get; set; }
        public string In_farmer_name { get; set; }
        public string In_sur_name { get; set; }
        public string In_photo_farmer { get; set; }
        public string In_signature_farmer { get; set; }
        public string In_applied_on { get; set; }
        public int In_applied_shares { get; set; }
        public Double In_amount_due { get; set; }
        public string In_payment_mode { get; set; }
        public string In_payment_mode_desc { get; set; }
        public string In_payment_ref_no { get; set; }
        public string In_payment_status { get; set; }
        public string In_payment_status_desc { get; set; }
        public string In_shareapp_remark { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }
        //Ramya Added on 29 Apr 21
        public string In_Collected_By { get; set; }
        public string In_Received_By { get; set; }
        public string In_BankName { get; set; }
        public string In_AcctNo { get; set; }
        public string In_IFSCCode { get; set; }
        public string In_AadharNo { get; set; }

    }
    public class FetchContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FetchHeader Header { get; set; }
        public string fpoorgn_code { get; set; }
        public int shareapp_rowid { get; set; }

    }
 
    public class FetchApplication
    {
        public FetchContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }

    }
    #endregion

    #region save
    public class SaveHeader
    {
        public int IOU_shareapp_rowid { get; set; }
        public string IOU_shareapp_no { get; set; }
        public string In_fpoorgn_code { get; set; }
        public string In_farmer_code { get; set; }
        public string In_fpomember_code { get; set; }
        public string In_signature_farmer { get; set; }
        public string In_photo_farmer { get; set; }
        public string In_applied_on { get; set; }
        public float In_applied_shares { get; set; }
        public float In_amount_due { get; set; }
        public string In_payment_mode { get; set; }
        public string In_payment_ref_no { get; set; }
        public string In_payment_status { get; set; }
        public string In_shareapp_remark { get; set; }
        public string In_status_code { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }
        //Ramya Added on 29 Apr 21
        public string In_Collected_By { get; set; }
        public string In_Received_By { get; set; }

    }
    public class SaveContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public SaveHeader Header { get; set; }

    }
    public class ProcessShareDocument
    {
        public SaveContext context { get; set; }
        public ProcessShareApplicationException ApplicationException { get; set; }

    }
    public class ProcessShareApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class ProcessShareApplication
    {
        public ProcessShareDocument document { get; set; }

    }
    #endregion
}
