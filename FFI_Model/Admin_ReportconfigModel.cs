using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class Admin_ReportconfigModel
    {
    }
    #region List
    public class RCList
    {
        public int Out_report_rowid { get; set; }
        public string Out_module_code { get; set; }
        public string Out_module_name { get; set; }
        public string Out_report_code { get; set; }
        public string Out_report_name { get; set; }
        public string Out_report_type { get; set; }
        public string Out_report_type_desc { get; set; }
        public string out_report_source { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
    }

    public class RCContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public List<RCList> List { get; set; }
    }
    public class ReportconfigList
    {
        public RCContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion
    #region SingleFetch
    public class FetchRCHeader
    {
        public int IOU_report_rowid { get; set; }
        public string In_module_code { get; set; }
        public string In_report_code { get; set; }
        public string In_report_name { get; set; }
        public string In_report_type { get; set; }
        public string In_report_type_desc { get; set; }
        public string In_report_source { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }
    }

    public class FetchRCParamDetail
    {
        public int In_reportparam_rowid { get; set; }
        public int In_param_slno { get; set; }
        public string In_param_name { get; set; }
        public string In_param_desc { get; set; }
        public string In_param_type { get; set; }
        public string In_param_type_desc { get; set; }
        public string In_param_value { get; set; }
        public string In_param_value_desc { get; set; }
        public string In_mandatory_flag { get; set; }
        public string In_status_code { get; set; }
        public string in_status_desc { get; set; }
        public string In_mode_flag { get; set; }
    }

    public class FetchRCContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FetchRCHeader Header { get; set; }
        public List<FetchRCParamDetail> Param_detail { get; set; }
    }
    public class FetchRC
    {
        public FetchRCContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion
    #region SaveInput
    public class SaveRCHeader
    {
        public int IOU_report_rowid { get; set; }
        public string In_module_code { get; set; }
        public string In_report_code { get; set; }
        public string In_report_name { get; set; }
        public string In_report_type { get; set; }
        public string In_report_source { get; set; }
        public string In_status_code { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }
    }

    public class SaveRCParamDetail
    {
        public int In_reportparam_rowid { get; set; }
        public int In_param_slno { get; set; }
        public string In_param_name { get; set; }
        public string In_param_desc { get; set; }
        public string In_param_type { get; set; }
        public string In_param_value { get; set; }
        public string In_mandatory_flag { get; set; }
        public string Instatus_code { get; set; }
        public string In_mode_flag { get; set; }
    }

    public class SaveRCContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public SaveRCHeader Header { get; set; }
        public List<SaveRCParamDetail> Param_detail { get; set; }
    }

    public class SaveRCDocument
    {
        public SaveRCContext context { get; set; }
    }

    public class SaveReportConfig
    {
        public SaveRCDocument document { get; set; }
    }
    #endregion
    #region SaveOutput
    public class OutRCHeader
    {
        public int IOU_report_rowid { get; set; }
    }
    public class OutRCContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public OutRCHeader Header { get; set; }
    }
    public class OutReportConfig
    {
        public OutRCContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion
}
