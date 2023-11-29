using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class FISshareRefundModel
    {
    }

    public class ShareRefundDetail
    {
        public int In_shareapp_rowid { get; set; }
        public Int64 In_refund_rowid { get; set; }
        public string In_shareapp_no { get; set; }
        public string In_shareapp_date { get; set; }
        public string In_member_name { get; set; }
        public string In_farmer_name { get; set; }
        public int In_applied_shares { get; set; }
        public Int64 In_rejected_shares { get; set; }
        public string In_payment_mode { get; set; }
        public string In_payment_mode_desc { get; set; }
        public string In_refund_date { get; set; }
        public decimal In_refund_amount { get; set; }
        public string In_payment_ref_no { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class ShareRefundContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<ShareRefundDetail> Detail { get; set; }

        public string In_fpoorgn_code { get; set; }
        public string In_refund_status { get; set; }
        public string In_refund_date { get; set; }

    }
    public class ShareRefundApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class ShareRefundApplication
    {
        public ShareRefundContext context { get; set; }
        public ShareRefundApplicationException ApplicationException { get; set; }

    }



    #region Save share refund

    public class IUSrefundHeader
    {
        public string In_refund_status { get; set; }
        public string In_fpoorgn_code { get; set; }
        public string In_refund_date { get; set; }
        public string detail_formatted { get; set; }


    }
    public class IUSrefundDetail
    {
        public int In_shareapp_rowid { get; set; }
        public int In_refund_rowid { get; set; }
        public string In_shareapp_no { get; set; }
        public int In_applied_shares { get; set; }
        public int In_rejected_shares { get; set; }
        public string In_payment_mode { get; set; }
        public string In_refund_date { get; set; }
        public int In_refund_amount { get; set; }
        public string In_payment_ref_no { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class IUSrefundContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IUSrefundHeader Header { get; set; }
        public IList<IUSrefundDetail> Detail { get; set; }

    }
    public class IUSrefundDocument
    {
        public IUSrefundContext context { get; set; }

    }
    public class IUSrefundApplication
    {
        public IUSrefundDocument document { get; set; }

    }
    #endregion
}