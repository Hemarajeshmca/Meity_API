using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FFI_Service
{
    public class FDR_FarmerProfileService
    {
        FDR_FarmerProfileDataModel objDataModel = new FDR_FarmerProfileDataModel();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FDR_FarmerProfileService));
        string methodName = "";
        public FarmerProfileList FarmerProfileList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue, int from_index, int to_index, int record_count, string ConString)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            FarmerProfileList objList = new FarmerProfileList();
            try
            {
                objList = objDataModel.FarmerProfileList(org, locn, user, lang, filterby_option, filterby_code, filterby_fromvalue, filterby_tovalue, from_index, to_index, record_count, ConString);
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objList;
        }

        public FarmerProfileFetch FetchFarmerProfile(string org, string locn, string user, string lang, int farmer_rowid, string farmer_code, int version_no, string ConString)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            FarmerProfileFetch ObjRootList = new FarmerProfileFetch();
            try
            {
                ObjRootList = objDataModel.FetchFarmerProfile(org, locn, user, lang, farmer_rowid, farmer_code, version_no, ConString);
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjRootList;
        }

        public OutputFarmerProfile SaveFarmerProfile(SaveFarmerProfile objFP, string jsonstring, string ConString)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            OutputFarmerProfile objOutFp = new OutputFarmerProfile();
            try
            {
                objOutFp = objDataModel.SaveFarmerProfile(objFP, jsonstring, ConString);
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objFP.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objOutFp;
        }
    }
}
