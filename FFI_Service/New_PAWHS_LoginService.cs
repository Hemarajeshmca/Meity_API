using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Service
{
   public class New_PAWHS_LoginService
    {
        public static PAWHSLoginfetchApplication GetPAWHSLogin_Srv(string org, string locn, string user, string lang, string In_user_code, string In_user_pwd,int version_number, string Mysql)
        {
            PAWHSLoginfetchApplication ObjFarmerRoot = new PAWHSLoginfetchApplication();
            New_PAWHS_LoginDB objDataModel = new New_PAWHS_LoginDB();
            try
            {
                ObjFarmerRoot = objDataModel.GetAllLogin_DB(org, locn, user, lang, In_user_code, In_user_pwd, version_number, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSLoginfetchApplication GetPAWHSGramPachant(string org, string Mdatetime, string Mysql)
        {
            PAWHSLoginfetchApplication ObjFarmerRoot = new PAWHSLoginfetchApplication();
            New_PAWHS_LoginDB objDataModel = new New_PAWHS_LoginDB();
            try
            {
                ObjFarmerRoot = objDataModel.GetAllGram_DB(org,Mdatetime, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
    }
}
