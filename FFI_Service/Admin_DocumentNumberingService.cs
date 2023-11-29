using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Service
{
    public class Admin_DocumentNumberingService
    {
        Admin_DocumentNumberingDataModel objDataModel = new Admin_DocumentNumberingDataModel();
        public DCNumberList DocNumberList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue,string ConString)
        {
            DCNumberList ObjList = new DCNumberList();
            try
            {
                ObjList = objDataModel.DocNumberList(org, locn, user, lang, filterby_option, filterby_code, filterby_fromvalue, filterby_tovalue, ConString);
            }
            catch (Exception ex)
            {
                throw(ex);
            }
            return ObjList;
        }

        public FetchDocNumber FetchDocNum(string org, string locn, string user, string lang, string activity_code, string finyear_code, int docnum_rowid,string ConString)
        {
            FetchDocNumber ObjFetch = new FetchDocNumber();
            try
            {
                ObjFetch = objDataModel.FetchDocNum(org, locn, user, lang, activity_code, finyear_code, docnum_rowid, ConString);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ObjFetch;
        }
        public OutputDoc SaveDC(SaveDocNum objDoc,string ConString)
        {
            OutputDoc ObjFetch = new OutputDoc();
            try
            {
                ObjFetch = objDataModel.SaveDC(objDoc, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetch;
        }
    }
}
