using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class Mobile_FDR_Login_model
    {
    }
    #region detailfetch
    public class FDRLoginfetch
    {
        public string In_user_code1 { get; set; }
        public string In_user_name { get; set; }
        public string In_role_code { get; set; }
        public string In_role_name { get; set; }
        public string In_orgn_code { get; set; }
        public string In_location { get; set; }
        public string In_Reponse { get; set; }
    }
    public class FDRLoginfetchContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FDRLoginfetch FDRLoginfetch { get; set; }
        public string instance { get; set; }
        public string In_user_code { get; set; }
        public string In_user_pwd { get; set; }

    }
    public class FDRLoginfetchApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class FDRLoginfetchApplication
    {
        public FDRLoginfetchContext context { get; set; }
        public FDRLoginfetchApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region loginfetch
    public class Loginfetch
    {

        public string In_parent_code { get; set; }
        public string In_orgn_desc { get; set; }
        public string In_orgn_code { get; set; }       
    }
    public class LoginfetchContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public List<Loginfetch> List { get; set; }
        public string In_user_code { get; set; }
        public string In_user_pwd { get; set; }
        public string In_Reponse { get; set; }
        public string instance { get; set; }
    }
    public class LoginfetchApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class LoginfetchApplication
    {
        public LoginfetchContext context { get; set; }
        public LoginfetchApplicationException ApplicationException { get; set; }

    }

    #endregion


    #region comloginfetch
    public class comLoginfetch
    {
        public string In_user_code1 { get; set; }
        public string In_user_name { get; set; }
        public string In_role_code { get; set; }
        public string In_ic_role_code { get; set; }
        public string in_ic_orgn_code { get; set; }
        public string in_ic_role_name { get; set; }
        public string In_role_name { get; set; }
        public string In_orgn_code { get; set; }
        public string In_location { get; set; }
        public string In_Reponse { get; set; }       
        public string config { get; set; }
        public string In_orgn_level { get; set; }
    }
    public class comLoginfetchContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public comLoginfetch List { get; set; }
        public string In_user_code { get; set; }
        public string In_user_pwd { get; set; }
        public string In_Reponse { get; set; }
        public string instance { get; set; }
        
    }
    public class ICDMOBLDetailcom
    {
        public string In_orgnlvl_code { get; set; }
        public string In_orgnlvl_name { get; set; }

    }
    public class comLoginfetchApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSLoginfetchcom
    {
        public string In_FPO_Code { get; set; }
        public string In_FPO_Name { get; set; }
        public string In_orgn_code { get; set; }
        public string In_orgn_name { get; set; }
        public string In_FPO_ORGN { get; set; }
    }
    public class Fpolist
    {
        public string fpo_orgn_code { get; set; }
        public string fpo_role_name { get; set; }
    }
        public class comLoginfetchApplication
    {
        public comLoginfetchContext context { get; set; }
        public List<ICDMOBLDetailcom> icd { get; set; }
        public List<PAWHSLoginfetchcom> pawhs { get; set; }
        public List<Fpolist> Fpo { get; set; }
        public comLoginfetchApplicationException ApplicationException { get; set; }

    }

    #endregion
}


