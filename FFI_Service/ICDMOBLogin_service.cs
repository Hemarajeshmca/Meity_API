using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Service
{
    public class ICDMOBLogin_service
    {
        public static ICDMOBLogin user_validation_Srv(string org, string locn, string user, string lang, string In_user_code, string In_user_pwd, string Mysql)
        {
            ICDMOBLogin ObjFarmerRoot = new ICDMOBLogin();
            ICDMOBLogin_datamodel objDataModel = new ICDMOBLogin_datamodel();
            try
            {
                ObjFarmerRoot = objDataModel.GetAllFdrLogin_DB(org, locn, user, lang, In_user_code, In_user_pwd, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static ICDMOBLogin1 icdmob_user_validation_Srv(string org, string locn, string user, string lang, string In_user_code, string In_user_pwd,int version_number,string Mysql)
        {
            ICDMOBLogin1 ObjFarmerRoot = new ICDMOBLogin1();
            ICDMOBLogin_datamodel objDataModel = new ICDMOBLogin_datamodel();
            try
            {
                ObjFarmerRoot = objDataModel.icdmob_GetAllFdrLogin_DB(org, locn, user, lang, In_user_code, In_user_pwd, version_number, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
    }

}
