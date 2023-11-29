using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class FISsharecertifcatedispatch_Model
    {
    }

    #region fetch

    public class FsharecertallDetail
    {
        public int In_shareapp_rowid { get; set; }
        public string In_shareapp_no { get; set; }
        public string In_shareapp_date { get; set; }
        public string In_fpomember_code { get; set; }
        public string In_farmer_code { get; set; }
        public string In_member_name { get; set; }
        public string In_certificate_no { get; set; }
        public string In_folio_no { get; set; }
        public string In_despatch_date { get; set; }
        public string In_despatch_awb_no { get; set; }
        public string In_process_status { get; set; }
        public string In_process_status_desc { get; set; }
        public string In_despatch_remark { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class FsharecertallContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<FsharecertallDetail> Detail { get; set; }
        public string fpoorgn_code { get; set; }
        public string despatch_status { get; set; }
        public string despatch_date { get; set; }

    }
    public class FsharecertallApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class FsharecertallApplication
    {
        public FsharecertallContext context { get; set; }
        public FsharecertallApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region save
    public class SavecertDisHeader
    {
        public string In_fpoorgn_code { get; set; }
        public string In_despatch_status { get; set; }
        public string In_despatch_date { get; set; }

    }

    public class SavecertDisDetail
    {
        public int In_shareapp_rowid { get; set; }
        public string In_shareapp_no { get; set; }
        public string In_fpomember_code { get; set; }
        public string In_farmer_code { get; set; }
        public string In_certificate_no { get; set; }
        public string In_despatch_date { get; set; }
        public string In_despatch_awb_no { get; set; }
        public string In_process_status { get; set; }
        public string In_despatch_remark { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class SavecertDisContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public SavecertDisHeader Header { get; set; }
        public IList<SavecertDisDetail> Detail { get; set; }

    }
    public class SavecertDisDocument
    {
        public SavecertDisContext context { get; set; }
        public SavecertDisApplicationException ApplicationException { get; set; }
    }
    public class SavecertDisApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }

    public class SavecertDisApplication
    {
        public SavecertDisDocument document { get; set; }

    }


    #endregion
}

