using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
   public class PAWHSProductionTransaction_srv
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSProductionTransaction_srv)); //Declaring Log4Net. 
        public static PAWHSProductionTransactionApplication Getallproduction_transaction_Srv(PAWHSProductionTransactionContext objfarmer, string Mysql)
        {
            PAWHSProductionTransactionApplication ObjFarmerRoot = new PAWHSProductionTransactionApplication();
            PAWHSProductionTransaction_DB objDataModel = new PAWHSProductionTransaction_DB();
            try
            {
                ObjFarmerRoot = objDataModel.Getallproduction_transaction_DB(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSProductionTransactionFApplication Getproduction_transaction_Srv(PAWHSProductionTransactionFContext objfarmer, string Mysql)
        {
            PAWHSProductionTransactionFApplication ObjFarmerRoot = new PAWHSProductionTransactionFApplication();
            PAWHSProductionTransaction_DB objDataModel = new PAWHSProductionTransaction_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Getproduction_transaction_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSProductionTransactionSDocument Savenew_production_transaction_srv(PAWHSProductionTransactionSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            PAWHSProductionTransactionSDocument objfarmer = new PAWHSProductionTransactionSDocument();
            try
            {
                PAWHSProductionTransaction_DB objDataModel = new PAWHSProductionTransaction_DB();
                objfarmer = objDataModel.Savenew_production_transaction_DB(objmodel, MysqlCon);

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


