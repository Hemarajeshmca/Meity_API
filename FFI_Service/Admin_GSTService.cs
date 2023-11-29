using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Service
{
    public class Admin_GSTService
    {
        Admin_GSTDataModel objDataModel = new Admin_GSTDataModel();
        public GSTList GSTList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue,string ConString)
        {
            GSTList ObjList = new GSTList();
            try
            {
                ObjList = objDataModel.GSTList(org, locn, user, lang, filterby_option, filterby_code, filterby_fromvalue, filterby_tovalue, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjList;
        }
        public FetchGST FetchGST(string org, string locn, string user, string lang, int taxrate_rowid, string provider_location, string ConString)
        {
            FetchGST ObjFetch = new FetchGST();
            try
            {
                ObjFetch = objDataModel.FetchGST(org, locn, user, lang, taxrate_rowid, provider_location, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetch;
        }

        //public OutGST SaveGST(SaveGST objGST, string ConString)
        //{
        //    OutGST ObjFetch = new OutGST();
        //    try
        //    {
        //        ObjFetch = objDataModel.SaveGST(objGST, ConString);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ObjFetch;
        //}

        public SaveGSTDocument SaveGST(SaveGST objGST, string ConString)
        {
            SaveGSTDocument ObjFetch = new SaveGSTDocument();
            try
            {
                Admin_GSTDataModel objDataModel = new Admin_GSTDataModel();
                ObjFetch = objDataModel.SaveGST(objGST, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetch;
        }
    }
}
