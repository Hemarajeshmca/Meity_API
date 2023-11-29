using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
  public  class CaptialModel
    {
      
    }
    public class CaptialContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public CaptialFilter Filter { get; set; }
        public CaptialHeader Header { get; set; }
        //public List<Map> Map { get; set; }
    }
    public class SCaptialContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public SCaptialHeader Header { get; set; }
        //public List<Map> Map { get; set; }
    }
    public class CaptialFilter
    {
        public int captial_rowid { get; set; }
        public string fpoorgn_code { get; set; }

    }
    public class CaptialHeader
    {
        public int IOU_capital_rowid1 { get; set; }
        public string IOU_fpoorgn_code1 { get; set; }
        public string In_fpoorgn_desc { get; set; }
        public string In_authorized_capital { get; set; }
        public string In_paid_capital { get; set; }
        public int In_max_shares_per_applicant { get; set; }
        public string In_share_price { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }
    }
    public class SCaptialHeader
    {
        public int IOU_capital_rowid { get; set; }
        public string IOU_fpoorgn_code { get; set; }
        public string In_authorized_capital { get; set; }
        public string In_paid_capital { get; set; }
        public int In_max_shares_per_applicant { get; set; }
        public string In_share_price { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }


    }
    public class CaptialApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }
    }
        public class CaptialRootObject
        {
            public CaptialContext context { get; set; }
            public CaptialApplicationException ApplicationException { get; set; }
        }
        public class CaptialDocument
        {
            public SCaptialContext context { get; set; }

        }
        public class CaptialApplication
        {
            public CaptialDocument document { get; set; }

        }
}
