using System;
using System.Collections.Generic;
using System.Text;
using FFI_Model;
using FFI_DataModel;
using System.Data;
using System.Security;
using log4net;

namespace FFI_Service
{
   public class Captial_Service
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Captial_Service)); //Declaring Log4Net. 

        public static CaptialRootObject GetCaptialDtl(CaptialContext ObjContext, string Mysql)
        {
            CaptialRootObject ObjCaptialRoot = new CaptialRootObject();
            Captial_DataModel objDataModel = new Captial_DataModel();
            try
            {
                ObjCaptialRoot = objDataModel.GetSingleCaptialDtls(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjCaptialRoot;
        }

        public static CaptialDocument SaveCaptialDtl(CaptialApplication ObjContext, string MysqlCon)
        {
            string[] result = { };          
            CaptialDocument objcaptial = new CaptialDocument();
            try
            {
                Captial_DataModel objDataModel = new Captial_DataModel();
                objcaptial = objDataModel.SaveCaptialDtls(ObjContext, MysqlCon);

                return objcaptial;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

    }
}
