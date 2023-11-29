using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Service
{
    public class ICDStockIssue_Service
    {
        ICDStockIssue_DataModel objDataModel = new ICDStockIssue_DataModel();
        public ICDStockIssue_Model IssueTransferList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue, string issue_status,string ConString)
        {
            ICDStockIssue_Model ObjFetch = new ICDStockIssue_Model();
            try
            {
                ObjFetch = objDataModel.IssueTransferList(org, locn, user, lang, filterby_option, filterby_code, filterby_fromvalue, filterby_tovalue, issue_status ,ConString);
            }
            catch (Exception ex)
            {
            }
            return ObjFetch;
        }
    }
}
