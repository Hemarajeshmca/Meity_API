using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Service
{
   public class PAWHS_NEW_Farmerlist_SRV
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Mobile_FDR_FList_srv)); //Declaring Log4Net. 
        public static PAWHSFarmerRootObject GetAllFarmerList_Srv(PAWHSFarmerContext objfarmer, string Mysql)
        {
            PAWHSFarmerRootObject ObjFarmerRoot = new PAWHSFarmerRootObject();
            PAWHS_NEW_Farmerlist_DB objDataModel = new PAWHS_NEW_Farmerlist_DB();
            try
            {
                ObjFarmerRoot = objDataModel.GetAllFarmerList_DB(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
    }
}
