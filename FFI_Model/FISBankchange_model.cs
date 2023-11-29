using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class FISBankchange_model
    {
    }
    #region bank fetch
    public class FISBankchangeHeader
    {
        public int IOU_servicereq_rowid { get; set; }
        public string IOU_fpomember_code { get; set; }
        public string IOU_servicereq_no { get; set; }
        public string In_farmer_code { get; set; }
        public string In_current_bank_acc_no { get; set; }
        public string In_current_bank_acc_type { get; set; }
        public string In_current_bank_acc_type_desc { get; set; }
        public string In_current_bank_code { get; set; }
        public string In_current_bank_desc { get; set; }
        public string In_current_branch_name { get; set; }
        public string In_current_ifsc_code { get; set; }
        public string In_change_bank_acc_no { get; set; }
        public string In_change_bank_acc_type { get; set; }
        public string In_change_bank_acc_type_desc { get; set; }
        public string In_change_bank_code { get; set; }
        public string In_change_bank_desc { get; set; }
        public string In_change_branch_name { get; set; }
        public string In_change_ifsc_code { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_chklist_status_flag { get; set; }
        public string In_sr_comments { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class FISBankchangeContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FISBankchangeHeader Header { get; set; }

    }
    public class FISBankchangeApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class FISBankchangeApplication
    {
        public FISBankchangeContext context { get; set; }
        public FISBankchangeApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region save
    public class FISBankchangeSHeader
    {
        public int IOU_servicereq_rowid { get; set; }
        public string IOU_servicereq_no { get; set; }
        public string In_fpomember_code { get; set; }
        public string In_farmer_code { get; set; }
        public string In_current_bank_acc_no { get; set; }
        public string In_current_bank_acc_type { get; set; }
        public string In_current_bank_code { get; set; }
        public string In_current_branch_name { get; set; }
        public string In_current_ifsc_code { get; set; }
        public string In_change_bank_acc_no { get; set; }
        public string In_change_bank_acc_type { get; set; }
        public string In_change_bank_code { get; set; }
        public string In_change_branch_name { get; set; }
        public string In_change_ifsc_code { get; set; }
        public string In_status_code { get; set; }
        public string In_chklist_status_flag { get; set; }
        public string In_sr_comments { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class FISBankchangeSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FISBankchangeSHeader Header { get; set; }

    }
    public class FISBankchangeSDocument
    {
        public FISBankchangeSContext context { get; set; }
        public FISBankchangeSApplicationException ApplicationException { get; set; }

    }
    public class FISBankchangeSApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class FISBankchangeSApplication
    {
        public FISBankchangeSDocument document { get; set; }

    }
    #endregion
}
