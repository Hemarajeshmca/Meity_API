using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Service
{
   public class Mobile_FDR_Login_srv
    {
        public static FDRLoginfetchApplication GetAllFdrLogin_Srv(string org, string locn, string user, string lang, string In_user_code, string In_user_pwd,int version_number, string Mysql)
        {
            FDRLoginfetchApplication ObjFarmerRoot = new FDRLoginfetchApplication();
            Mobile_FDR_Login_DB objDataModel = new Mobile_FDR_Login_DB();
            try
            {
                ObjFarmerRoot = objDataModel.GetAllFdrLogin_DB(org, locn, user, lang, In_user_code, In_user_pwd, version_number,Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static LoginfetchApplication GetAllLogin_Srv(LoginfetchContext objfarmer, string Mysql)
        {
            LoginfetchApplication ObjFarmerRoot = new LoginfetchApplication();
            Mobile_FDR_Login_DB objDataModel = new Mobile_FDR_Login_DB();
            try
            {
                ObjFarmerRoot = objDataModel.GetAllLogin_DB(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }

        public static comLoginfetchApplication GetAllmodLogin_Srv(string org, string locn, string user, string lang,string In_user_code, string In_user_pwd, int version_number , string Mysql)
        {
            comLoginfetchApplication ObjFarmerRoot = new comLoginfetchApplication();
            Mobile_FDR_Login_DB objDataModel = new Mobile_FDR_Login_DB();
            try
            {
                ObjFarmerRoot = objDataModel.GetAllmodLogin_DB(org, locn, user, lang, In_user_code, In_user_pwd, version_number, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
    }
}

