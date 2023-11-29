using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class Admin_FinancialYearModel
    {
    }
    #region List
    public class FinList
    {
        public int finyear_rowid { get; set; }
        public string finyear_code { get; set; }
        public string finyear_desc { get; set; }
        public string finyear_start_date { get; set; }
        public string finyear_end_date { get; set; }
        public string finyear_narration { get; set; }
        public string status_code { get; set; }
        public string status_desc { get; set; }
    }

    public class FnContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public List<FinList> List { get; set; }
    }
    public class FinYearList
    {
        public FnContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }

    #endregion

    #region SingleFetch

    public class FetchFinancialYearHeader
    {
        public int finyear_rowid { get; set; }
        public string finyear_code { get; set; }
        public string finyear_desc { get; set; }
        public string finyear_start_date { get; set; }
        public string finyear_end_date { get; set; }
        public string finyear_narration { get; set; }
        public string status_code { get; set; }
        public string status_desc { get; set; }
        public string mode_flag { get; set; }
        public string row_timestamp { get; set; }
    }

    public class FetchFinancialYearContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FetchFinancialYearHeader Header { get; set; }
    }

    public class FetchFinancialYear
    {
        public FetchFinancialYearContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion

    #region Saveinput
    public class SaveFYHeader
    {
        public int finyear_rowid { get; set; }
        public string finyear_code { get; set; }
        public string finyear_desc { get; set; }
        public string finyear_start_date { get; set; }
        public string finyear_end_date { get; set; }
        public string finyear_narration { get; set; }
        public string status_code { get; set; }
        public string mode_flag { get; set; }
        public string row_timestamp { get; set; }
    }

    public class SaveFYContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public SaveFYHeader Header { get; set; }
    }

    public class SaveFYDocument
    {
        public SaveFYContext context { get; set; }
    }

    public class SaveFinYear
    {
        public SaveFYDocument document { get; set; }
    }
    #endregion

    #region SaveOutPut
    public class FYOutHeader
    {
        public int finyear_rowid { get; set; }
    }

    public class FYOutContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FYOutHeader Header { get; set; }
    }
    public class SaveFYOut
    {
        public FYOutContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion
}


