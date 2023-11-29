using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class FISDividend_model
    {
    }
    #region list
    public class FISDividendList
    {
        public int Out_dividendstru_rowid { get; set; }
        public string Out_fpoorgn_code { get; set; }
        public string Out_finyear_code { get; set; }
        public string Out_finyear_desc { get; set; }
        public string Out_period_from { get; set; }
        public string Out_period_to { get; set; }
        public string Out_dividend_type { get; set; }
        public string Out_dividend_type_desc { get; set; }
        public double Out_dividend_percent { get; set; }
        public string Out_report_date { get; set; }
        public string Out_declared_date { get; set; }
        public string Out_payor_bank_code { get; set; }
        public string Out_payor_bank_desc { get; set; }
        public string Out_payor_bank_acc_type { get; set; }
        public string Out_payor_bank_acc_type_desc { get; set; }
        public string Out_payor_bank_acc_no { get; set; }
        public string Out_payor_ifsc_code { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_row_timestamp { get; set; }
        public string Out_mode_flag { get; set; }

    }
    public class FISDividendFilter
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
    public class FISDividendContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<FISDividendList> List { get; set; }
        public FISDividendFilter Filter { get; set; }
       

    }
    public class FISDividendApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class FISDividendApplication
    {
        public FISDividendContext context { get; set; }
        public FISDividendApplicationException ApplicationException { get; set; }

    }
    #endregion

    #region fetch
    public class FISDividendFHeader
    {
        public int IOU_dividendstru_rowid { get; set; }
        public string IOU_fpoorgn_code { get; set; }
        public string In_finyear_code { get; set; }
        public string In_finyear_desc { get; set; }
        public string In_period_from { get; set; }
        public string In_period_to { get; set; }
        public string In_dividend_type { get; set; }
        public string In_dividend_type_desc { get; set; }
        public double In_dividend_percent { get; set; }
        public string In_report_date { get; set; }
        public string In_declared_date { get; set; }
        public string In_payor_bank_code { get; set; }
        public string In_payor_bank_desc { get; set; }
        public string In_payor_bank_acc_type { get; set; }
        public string In_payor_bank_acc_type_desc { get; set; }
        public string In_payor_bank_acc_no { get; set; }
        public string In_payor_ifsc_code { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class FISDividendFContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FISDividendFHeader Header { get; set; }

    }
    public class FISDividendFApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class FISDividendFApplication
    {
        public FISDividendFContext context { get; set; }
        public FISDividendFApplicationException ApplicationException { get; set; }

    }
    #endregion

    #region save
    public class FISDividendSHeader
    {
        public int IOU_dividendstru_rowid { get; set; }
        public string IOU_fpoorgn_code { get; set; }
        public string In_finyear_code { get; set; }
        public string In_period_from { get; set; }
        public string In_period_to { get; set; }
        public string In_dividend_type { get; set; }
        public double In_dividend_percent { get; set; }
        public string In_report_date { get; set; }
        public string In_declared_date { get; set; }
        public string In_payor_bank_code { get; set; }
        public string In_payor_bank_acc_type { get; set; }
        public string In_payor_bank_acc_no { get; set; }
        public string In_payor_ifsc_code { get; set; }
        public string In_status_code { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class FISDividendSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FISDividendSHeader Header { get; set; }

    }
    public class FISDividendSDocument
    {
        public FISDividendSContext context { get; set; }
        public FISDividendSApplicationException ApplicationException { get; set; }

    }
    public class FISDividendSApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class FISDividendSApplication
    {
        public FISDividendSDocument document { get; set; }

    }
    #endregion
}
