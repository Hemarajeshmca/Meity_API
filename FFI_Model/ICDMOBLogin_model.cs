using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class ICDMOBLogin_model
    {
    }
    public class ICDMOBLHeader
    {
        public string In_user_code { get; set; }
        public string In_user_name { get; set; }
        public string In_role_code { get; set; }
        public string In_role_name { get; set; }
        public string In_orgn_code { get; set; }
        public string In_location { get; set; }
        public string In_Reponse { get; set; }
        public string config { get; set; }
    }
    public class ICDMOBLDetail
    {
        public string In_orgnlvl_code { get; set; }
        public string In_orgnlvl_name { get; set; }
    }
    public class ICDMOBLContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public ICDMOBLHeader Header { get; set; }

    }
    public class ICDMOBLContext1
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public ICDMOBLHeader Header { get; set; }
        public List<ICDMOBLDetail> Detail { get; set; }

    }
    public class ICDMOBLApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }
    }

    public class ICDMOBLogin
    {
        public ICDMOBLContext context { get; set; }
        public ICDMOBLApplicationException ApplicationException { get; set; }
    }
    public class ICDMOBLogin1
    {
        public ICDMOBLContext1 context { get; set; }
        public ICDMOBLApplicationException ApplicationException { get; set; }
    }

}
