using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Service
{
   public class Mobile_FDR_FDetailFetch_srv
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Mobile_FDR_servicecs)); //Declaring Log4Net. 
        public static FarmerdetailfetchApplication GetAllFarmerdetailfetch_Srv(FarmerdetailfetchContext objfarmer, string Mysql)
        {
            FarmerdetailfetchApplication ObjFarmerRoot = new FarmerdetailfetchApplication();
            Mobile_FDR_FDetailFetch_DB objDataModel = new Mobile_FDR_FDetailFetch_DB();
            try
            {
                ObjFarmerRoot = objDataModel.GetallFarmerdetailfetch_DB(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
    }
}
