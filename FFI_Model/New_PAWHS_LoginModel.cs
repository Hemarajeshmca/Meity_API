using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class New_PAWHS_LoginModel
    {
    }
    #region PAWHSLogin
    public class PAWHSLoginfetchApplication
    {
        public PAWHSLoginfetchContext context { get; set; }
        public PAWHSGramfetchContext GramFetchContext { get; set; }
        public PAWHSLoginfetchApplicationException ApplicationException { get; set; }
    }
    public class PAWHSLoginfetchApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSLoginfetchContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public List<PAWHSLoginfetch> List { get; set; }
        public string In_user_code { get; set; }
        public string In_user_pwd { get; set; }

        public string instance { get; set; }
        public string IOU_user_code { get; set; }
        public string IOU_user_name { get; set; }
        public string IOU_role_code { get; set; }
        public string IOU_role_name { get; set; }
        public string IOU_orgn_code { get; set; }
        public string IOU_location { get; set; }
        public string IOU_Reponse { get; set; }
    }
    public class PAWHSLoginfetch
    {
        public string In_FPO_Code { get; set; }
        public string In_FPO_Name { get; set; }
        public string In_orgn_code { get; set; }
        public string In_orgn_name { get; set; }
        public string In_FPO_ORGN { get; set; }
    }
    public class PAWHSGramfetchContext
    {
        public string ErrorMsg { get; set; }
        public List<PAWHSGramPachayatFetch> List { get; set; }
    }
    public class PAWHSGramPachayatFetch
    {
      
        public string country_mst { get; set; }
        public string country_desc { get; set; }
        public string state_mst { get; set; }
        public string state_desc { get; set; }
        public string dist_mst { get; set; }
        public string dist_desc { get; set; }
        public string taluk_mst { get; set; }
        public string taluk_desc { get; set; }
        public string panchayat_mst { get; set; }
        public string panchayat_desc { get; set; }
        public string village_mst { get; set; }
        public string village_desc { get; set; }
        public string pincode { get; set; }

    }

    #endregion
}
