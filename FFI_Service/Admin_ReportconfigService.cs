using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Service
{
    public class Admin_ReportconfigService
    {
        Admin_ReportconfigDataModel objDataModel = new Admin_ReportconfigDataModel();
        public ReportconfigList ReportconfigList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue, string ConString)
        {
            ReportconfigList ObjList = new ReportconfigList();
            try
            {
                ObjList = objDataModel.ReportconfigList(org, locn, user, lang, filterby_option, filterby_code, filterby_fromvalue, filterby_tovalue, ConString);
            }
            catch (Exception ex)
            {
               throw ex;
            }
            return ObjList;
        }
        public FetchRC FetchReportConfig(string org, string locn, string user, string lang, int report_rowid, string ConString)
        {
            FetchRC ObjFetch = new FetchRC();
            try
            {
                ObjFetch = objDataModel.FetchReportConfig(org, locn, user, lang, report_rowid, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetch;
        }

        public OutReportConfig SaveReport(SaveReportConfig objRC,string ConString)
        {
            OutReportConfig ObjFetch = new OutReportConfig();
            try
            {
                ObjFetch = objDataModel.SaveReport(objRC, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetch;
        }
    }
}
