using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Service
{
   public class Admin_UserManagementService
    {

        Admin_UserManagementDataModel objRoleModel = new Admin_UserManagementDataModel();
        public UserManagementList AllUsers(string org, string locn, string user, string lang,string ConString)
        {
            UserManagementList ObjList = new UserManagementList();
            try
            {
                ObjList = objRoleModel.GetAllRoleList(org, locn, user, lang, ConString);
            }
            catch (Exception ex)
            {
                throw(ex);
            }
            return ObjList;
        }
        public FetchUserManagement GetUserRoleaAtivity(string org, string locn, string user, string lang, string user_id, string role_code, string ConString)
        {
            FetchUserManagement ObjFetch = new FetchUserManagement();
            try
            {
                ObjFetch = objRoleModel.GetUserRoleaAtivity(org, locn, user, lang, user_id, role_code, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetch;
        }

        public UserManagementOutput SaveUserRoleActivity(SaveUMRoot objUser, string ConString)
        {
            UserManagementOutput ObjFetch = new UserManagementOutput();
            try
            {
                ObjFetch = objRoleModel.SaveUserRoleActivity(objUser, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetch;
        }

        public FetchUserRole UserRole(string org, string locn, string user, string lang, string user_code,string ConString)
        {
            FetchUserRole ObjList = new FetchUserRole();
            try
            {
                ObjList = objRoleModel.UserRole(org, locn, user, lang, user_code, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjList;
        }

        public UserManagementOutput SaveUserMap(SaveMapRoot objUser, string ConString)
        {
            UserManagementOutput ObjFetch = new UserManagementOutput();
            try
            {
                ObjFetch = objRoleModel.SaveUserMap(objUser, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetch;
        }

        public FPOUSERList Fpolist(string org, string locn, string user, string lang,string user_code, string ConString)
        {
            FPOUSERList ObjList = new FPOUSERList();
            try
            {
                ObjList = objRoleModel.GetAllFpoList(org, locn, user, lang, user_code, ConString);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ObjList;
        }
        public RIUserManagementList MapUsersList(string org, string locn, string user, string lang, string ConString)
        {
            RIUserManagementList ObjList = new RIUserManagementList();
            try
            {
                ObjList = objRoleModel.GetMapUsersList(org, locn, user, lang, ConString);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ObjList;
        }
        public FPOListGL FPOlist(string org, string locn, string user, string lang, string ConString)
        {
            FPOListGL ObjList = new FPOListGL();
            try
            {
                ObjList = objRoleModel.GetFPOlist(org, locn, user, lang, ConString);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ObjList;
        }
    }
}
