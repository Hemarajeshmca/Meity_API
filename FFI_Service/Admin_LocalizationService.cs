using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Service
{
    public class Admin_LocalizationService
    {
        Admin_LocalizationDataModel objDataModel = new Admin_LocalizationDataModel();
        public LocalizationList LocalizationList(string org, string locn, string user, string lang, string activity_code,string ConString)
        {
            LocalizationList ObjList = new LocalizationList();
            try
            {
                ObjList = objDataModel.LocalizationList(org, locn, user, lang, activity_code,ConString);
            }
            catch (Exception ex)
            {
                throw(ex);
            }
            return ObjList;
        }
        public LocalOutput SaveLocalization(SaveLocalization objLoc,string ConString)
        {
            LocalOutput ObjFetch = new LocalOutput();
            try
            {
                ObjFetch = objDataModel.SaveLocalization(objLoc, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetch;
        }
    }
}
