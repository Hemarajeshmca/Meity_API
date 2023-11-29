using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class FISDividentRegisterModel
    {
    }


    #region fetch
    public class DivRegHeader
    {
        public int IOU_register_rowid { get; set; }
        public string IOU_register_no { get; set; }
        public string IOU_register_name { get; set; }
        public string IOU_report_date { get; set; }
        public string IOU_declared_date { get; set; }
        public int In_dividendstru_rowid { get; set; }
        public string IOU_payor_bank_code { get; set; }
        public string IOU_fpoorgn_code { get; set; }

    }
    public class DivRegDetail
    {
        public int In_dividend_rowid { get; set; }
        public int In_fpomember_rowid { get; set; }
        public string In_farmer_code { get; set; }
        public string In_fpomember_code { get; set; }
        public string In_farmer_name { get; set; }
        public string In_member_name { get; set; }
        public string In_certificate_no { get; set; }
        public int In_dist_from { get; set; }
        public int In_dist_to { get; set; }
        public Decimal In_dividend_due { get; set; }
        public string In_bank_code { get; set; }
        public string In_bank_acc_type { get; set; }
        public string In_bank_acc_type_desc { get; set; }
        public string In_bank_acc_no { get; set; }
        public string In_branch_name { get; set; }
        public string In_ifsc_code { get; set; }
        public string In_bank_ref_no { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class DivRegContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public DivRegHeader Header { get; set; }
        public IList<DivRegDetail> Detail { get; set; }

    }
    public class DivRegApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class DivRegApplication
    {
        public DivRegContext context { get; set; }
        public DivRegApplicationException ApplicationException { get; set; }

    }
    #endregion

    #region save
    public class SDivRegHeader
    {
        public int IOU_register_rowid { get; set; }
        public string IOU_register_no { get; set; }
        public string In_register_name { get; set; }
        public string In_report_date { get; set; }
        public string In_declared_date { get; set; }
        public int In_dividendstru_rowid { get; set; }
        public string In_payor_bank_code { get; set; }
        public string In_fpoorgn_code { get; set; }

    }
    public class SDivRegDetail
    {
        public int In_dividend_rowid { get; set; }
        public int In_fpomember_rowid { get; set; }
        public string In_farmer_code { get; set; }
        public string In_fpomember_code { get; set; }
        public string In_certificate_no { get; set; }
        public int In_dist_from { get; set; }
        public int In_dist_to { get; set; }
        public double In_dividend_due { get; set; }
        public string In_bank_code { get; set; }
        public string In_bank_acc_type { get; set; }
        public string In_bank_acc_no { get; set; }
        public string In_ifsc_code { get; set; }
        public string In_bank_ref_no { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class SDivRegContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public SDivRegHeader Header { get; set; }
        public IList<SDivRegDetail> Detail { get; set; }

    }
    public class SDivRegDocument
    {
        public SDivRegContext context { get; set; }

    }
    public class SDivRegApplication
    {
        public SDivRegDocument document { get; set; }

    }
    #endregion
}
