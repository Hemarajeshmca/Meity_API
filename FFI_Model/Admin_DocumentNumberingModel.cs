using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class Admin_DocumentNumberingModel
    {
    }
    #region List
    public class DCList
    {
        public string Out_activity_code { get; set; }
        public string Out_finyear_code { get; set; }
        public int Out_docnum_rowid { get; set; }
        public string Out_docnum_preview { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
    }

    public class DCContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public List<DCList> List { get; set; }
    }
    public class DCNumberList
    {
        public DCContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion
    #region SingleFetch
    public class FetchDocHeader
    {
        public string In_activity_code { get; set; }
        public string In_finyear_code { get; set; }
        public int In_docnum_rowid { get; set; }
        public string In_docnum_preview { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }
    }

    public class FetchDocDetail
    {
        public int In_docnumformat_rowid { get; set; }
        public int In_row_slno { get; set; }
        public string In_format_type { get; set; }
        public string In_format_type_desc { get; set; }
        public string In_format_desc { get; set; }
        public string In_format_value { get; set; }
        public string In_format_length { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }
    }

    public class FetchDocContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FetchDocHeader Header { get; set; }
        public List<FetchDocDetail> Detail { get; set; }
    }
    public class FetchDocNumber
    {
        public FetchDocContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }

    #endregion

    #region SaveInput
    public class SaveDCHeader
    {
        public int In_docnum_rowid { get; set; }
        public string In_activity_code { get; set; }
        public string In_finyear_code { get; set; }
        public string In_docnum_preview { get; set; }
        public string In_status_code { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }
    }

    public class SaveDCDetail
    {
        public int In_docnumformat_rowid { get; set; }
        public int In_row_slno { get; set; }
        public string In_format_type { get; set; }
        public string In_format_type_desc { get; set; }
        public string In_format_desc { get; set; }
        public string In_format_value { get; set; }
        public string In_format_length { get; set; }
        public string In_status_code { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }
    }

    public class SaveDCContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public SaveDCHeader Header { get; set; }
        public List<SaveDCDetail> Detail { get; set; }
    }

    public class SaveDCDocument
    {
        public SaveDCContext context { get; set; }
    }

    public class SaveDocNum
    {
        public SaveDCDocument document { get; set; }
    }
    #endregion

    #region Output
    public class OutputDocHeader
    {
        public int In_docnum_rowid { get; set; }
    }

    public class OutputDocContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public OutputDocHeader Header { get; set; }
    }
    public class OutputDoc
    {
        public OutputDocContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }

    #endregion
}
