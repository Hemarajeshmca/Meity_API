using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace FFI_Service
{
  public  class FDRFpoReg_Service
    {

        FDRFpoReg_DB objDataModel = new FDRFpoReg_DB();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FDRFpoReg_Service));
        string methodName = "";
        public RootObjectlist AllFPOList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue, string ConString)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            RootObjectlist objList = new RootObjectlist();
            try
            {
                objList = objDataModel.GetAllFPOList(org, locn, user, lang, filterby_option, filterby_code, filterby_fromvalue, filterby_tovalue,ConString);
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objList;
        }
        public RootObjectFetch FetchFPO(string org, string locn, string user, string lang, int farmer_rowid, string farmer_code, int version_no, string ConString)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            RootObjectFetch ObjRootList = new RootObjectFetch();
            try
            {
                ObjRootList = objDataModel.FetchFPOReg(org, locn, user, lang, farmer_rowid, farmer_code, version_no, ConString);
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjRootList;
        }
        public FPODocument SaveFPOReg(FPORootObject objFP, string ConString)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            FPODocument objOutFp = new FPODocument();
            try
            {
                objOutFp = objDataModel.SaveFPOReg(objFP, ConString);
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objFP.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objOutFp;
        }



    }
}
