using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
   public class PAWHSServiceReceipt_srv
    {

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSServiceReceipt_srv)); //Declaring Log4Net. 
        public static PAWHSServiceReceiptApplication Getallservice_receipting_Srv(PAWHSServiceReceiptContext objfarmer, string Mysql)
        {
            PAWHSServiceReceiptApplication ObjFarmerRoot = new PAWHSServiceReceiptApplication();
            PAWHSServiceReceipt_DB objDataModel = new PAWHSServiceReceipt_DB();
            try
            {
                ObjFarmerRoot = objDataModel.Getallservice_receipting_DB(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSServiceReceiptFApplication Getservice_receipting_srv(PAWHSServiceReceiptFContext objfarmer, string Mysql)
        {
            PAWHSServiceReceiptFApplication ObjFarmerRoot = new PAWHSServiceReceiptFApplication();
            PAWHSServiceReceipt_DB objDataModel = new PAWHSServiceReceipt_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Getservice_receipting_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSServiceReceiptSDocument Savenew_pawhs_service_receipting_srv(PAWHSServiceReceiptSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            PAWHSServiceReceiptSDocument objfarmer = new PAWHSServiceReceiptSDocument();
            try
            {
                PAWHSServiceReceipt_DB objDataModel = new PAWHSServiceReceipt_DB();
                objfarmer = objDataModel.Savenew_pawhs_service_receipting_DB(objmodel, MysqlCon);

                return objfarmer;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
    }
}

