using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Service
{
    public class Mobile_FDR_FHeader_srv
    {
       static log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Mobile_FDR_FHeader_srv));
        public static MFHDocument SaveNewMobileFarmerHeader_Srv(MFHApplication objmodel, string MysqlCon)
        {
            MFHDocument IUOShareRefund = new MFHDocument();
            try
            {
                Mobile_FDR_FHeader_DB objDataModel = new Mobile_FDR_FHeader_DB();
                IUOShareRefund = objDataModel.SaveNewMobileFarmerHeader_DB(objmodel, MysqlCon);
                return IUOShareRefund;
            }
            catch (Exception ex)
            {
                logger.Debug(ex.ToString());
                throw ex;
            }
        }
        public static MFKDocument SaveNewMobileFarmerkyc_Srv(MFKApplication objmodel, string MysqlCon)
        {
            MFKDocument IUOShareRefund = new MFKDocument();
            try
            {
                Mobile_FDR_FHeader_DB objDataModel = new Mobile_FDR_FHeader_DB();
                IUOShareRefund = objDataModel.SaveNewMobileFarmerkyc_DB(objmodel, MysqlCon);
                return IUOShareRefund;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
        public static MFBDocument SaveNewMobileFarmerBank_Srv(MFBApplication objmodel, string MysqlCon)
        {
            MFBDocument IUOShareRefund = new MFBDocument();
            try
            {
                Mobile_FDR_FHeader_DB objDataModel = new Mobile_FDR_FHeader_DB();
                IUOShareRefund = objDataModel.SaveNewMobileFarmerBank_DB(objmodel, MysqlCon);
                return IUOShareRefund;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
       
    }
}
