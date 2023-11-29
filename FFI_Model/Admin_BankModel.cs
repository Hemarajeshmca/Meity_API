using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class Admin_BankModel
    {
    }
    #region List
    public class BankDtl
    {
        public int Out_bank_rowid { get; set; }
        public string Out_bank_code { get; set; }
        public string Out_bank_name { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
    }

    public class BankContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public List<BankDtl> BankDtl { get; set; }
    }

    public class BankList
    {
        public BankContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion
    #region SingleFetch

    public class FBHeader
    {
        public int In_bank_rowid { get; set; }
        public string In_bank_code { get; set; }
        public string In_bank_name { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }
    }

    public class FBBankDtl
    {
        public int In_bankifsc_rowid { get; set; }
        public string In_ifsc_code { get; set; }
        public string In_branch_name { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }
    }

    public class FBContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FBHeader Header { get; set; }
        public List<FBBankDtl> BankDtl { get; set; }
    }
    public class FetchBank
    {
        public FBContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion
    #region SaveInput
    public class SBHeader
    {
        public int IOU_bank_rowid { get; set; }
        public string In_bank_code { get; set; }
        public string In_bank_name { get; set; }
        public string In_status_code { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }
    }

    public class SBBankDtl
    {
        public int In_bankifsc_rowid { get; set; }
        public string In_ifsc_code { get; set; }
        public string In_branch_name { get; set; }
        public string In_status_code { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }
    }

    public class SBContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public SBHeader Header { get; set; }
        public List<SBBankDtl> BankDtl { get; set; }
    }

    public class SBDocument
    {
        public SBContext context { get; set; }
    }

    public class SaveBank
    {
        public SBDocument document { get; set; }
    }

    #endregion
    #region SaveOutput
    public class OBHeader
    {
        public int IOU_bank_rowid { get; set; }
    }

    public class OBContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public OBHeader Header { get; set; }
    }
    public class OutputBank
    {
        public OBContext context { get; set; }
        public ApplicationExceptionSB ApplicationException { get; set; }
    }
    public class ApplicationExceptionSB
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    #endregion
}
