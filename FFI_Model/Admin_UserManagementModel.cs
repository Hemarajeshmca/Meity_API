﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class Admin_UserManagementModel
    {
    }
    #region List
    public class UserList
    {
        public string orgn_code { get; set; }
        public string orgn_desc { get; set; }
        public string user_code { get; set; }
        public string user_name { get; set; }
        public string role_code { get; set; }
        public string role_name { get; set; }
        public string valid_till { get; set; }
        public string contact_no { get; set; }
        public string email_id { get; set; }
        public string status_desc { get; set; }
    }

    public class UserContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public List<UserList> list { get; set; }
    }

       public class UserManagementList
    {
        public  UserContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion

    #region singleFetch
    public class FetchUserManagementDetail
    {
        public string out_activity_code { get; set; }
        public string out_activity_desc { get; set; }
        public string out_add_perm { get; set; }
        public string out_mod_perm { get; set; }
        public string out_auth_perm { get; set; }
        public string out_view_perm { get; set; }
        public string out_inactivate_perm { get; set; }
        public string out_print_perm { get; set; }
        public string out_deny_perm { get; set; }
    }

    public class FetchUserManagementContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public List<FetchUserManagementDetail> detail { get; set; }
    }
    public class FetchUserManagement
    {
        public FetchUserManagementContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }

    #endregion

    #region SaveInput
    public class SaveUMHeader
    {
        public string In_orgn_code { get; set; }
        public string In_role_code { get; set; }
        public string In_user_code { get; set; }
        public string In_user_name { get; set; }
        public string In_user_pwd { get; set; }
        public string In_valid_till { get; set; }
        public string In_contact_no { get; set; }
        public string In_email_id { get; set; }
        public string In_profile_photo { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }
    }

    public class SaveUMContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public SaveUMHeader Header { get; set; }
    }

    public class SaveUMDocument
    {
        public SaveUMContext context { get; set; }
    }

    public class SaveUMRoot
    {
        public SaveUMDocument document { get; set; }
    }

    #endregion

    #region SaveOutput
    public class OutContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
    }
    public class UserManagementOutput
    {
        public OutContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }

    #endregion

    #region FetchRole
    public class FetchUserRoleHeader
    {
        public string out_orgn_code { get; set; }
        public string out_user_name { get; set; }
        public string out_role_code { get; set; }
        public string out_user_pwd { get; set; }
        public string out_valid_till { get; set; }
        public string out_contact_no { get; set; }
        public string out_email_id { get; set; }
        public string out_profile_photo { get; set; }
        public string out_status_code { get; set; }
        public string out_status_desc { get; set; }
        public string out_row_timestamp { get; set; }
    }

    public class FetchUserRoleDetail
    {
        public string out_activity_code { get; set; }
        public string out_activity_desc { get; set; }
        public string out_add_perm { get; set; }
        public string out_mod_perm { get; set; }
        public string out_view_perm { get; set; }
        public string out_auth_perm { get; set; }
        public string out_inactivate_perm { get; set; }
        public string out_print_perm { get; set; }
        public string out_deny_perm { get; set; }
    }

    public class FetchUserRoleContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FetchUserRoleHeader Header { get; set; }
        public List<FetchUserRoleDetail> Detail { get; set; }
    }
    public class FetchUserRole
    {
        public FetchUserRoleContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion

    #region SaveMap
    public class SaveMapHeader
    {
        public string In_parent_code { get; set; }
        public string In_orgn_code { get; set; }
        public string In_user_code { get; set; }
        public string In_orgn_level { get; set; }
        public string In_fpo_code { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }
    }

    public class SaveMapContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public SaveMapHeader Header { get; set; }
    }

    public class SaveMapDocument
    {
        public SaveMapContext context { get; set; }
    }

    public class SaveMapRoot
    {
        public SaveMapDocument document { get; set; }
    }

    #endregion

    #region FPOfetchlist model

    public class FpoList
    {
        public string parent_code { get; set; }

        public string user_code { get; set; }
    }
    public class FpoListdetail
    {
        public string fpo_code { get; set; }
        public string fpo_desc { get; set; }
    }
    public class fpoContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FpoList Header { get; set; }
        public IList<FpoListdetail> Detail { get; set; }
    }

    public class FPOUSERList
    {
        public fpoContext context { get; set; }
        public fpoApplicationException ApplicationException { get; set; }
    }
    public class fpoApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    #endregion

    #region UserList
    public class RIUserList
    {
        public string orgn_code { get; set; }
        public string orgn_desc { get; set; }
        public string user_code { get; set; }
        public string user_name { get; set; }
        public string role_code { get; set; }
        public string role_name { get; set; }
        public string valid_till { get; set; }
        public string contact_no { get; set; }
        public string email_id { get; set; }
        public string status_desc { get; set; }
    }

    public class RIUserContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public List<RIUserList> list { get; set; }
    }

    public class RIUserManagementList
    {
        public RIUserContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion

    #region FPOlistG model


    public class FpoListG
    {
        public string fpo_code { get; set; }
        public string fpo_desc { get; set; }
    }
    public class FPOLISTContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public List<FpoListG> List { get; set; }
    }

    public class FPOListGL
    {
        public FPOLISTContext context { get; set; }
        public FPOLISTApplicationException ApplicationException { get; set; }
    }
    public class FPOLISTApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    #endregion
}
