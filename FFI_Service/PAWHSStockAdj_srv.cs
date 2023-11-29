using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
    public class PAWHSStockAdj_srv
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSStockAdj_srv)); //Declaring Log4Net. 
        public static PAWHSStockAdjApplication Getallstock_adjustment_Srv(PAWHSStockAdjContext objfarmer, string Mysql)
        {
            PAWHSStockAdjApplication ObjFarmerRoot = new PAWHSStockAdjApplication();
            PAWHSStockAdj_DB objDataModel = new PAWHSStockAdj_DB();
            try
            {
                ObjFarmerRoot = objDataModel.Getallstock_adjustment_DB(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSStockAdjFApplication Getstock_adjustment_srv(PAWHSStockAdjFContext objfarmer, string Mysql)
        {
            PAWHSStockAdjFApplication ObjFarmerRoot = new PAWHSStockAdjFApplication();
            PAWHSStockAdj_DB objDataModel = new PAWHSStockAdj_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Getstock_adjustment_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSStockAdjSDocument SavenewSaveStockAdjustment_srv(PAWHSStockAdjSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            PAWHSStockAdjSDocument objfarmer = new PAWHSStockAdjSDocument();
            try
            {
                PAWHSStockAdj_DB objDataModel = new PAWHSStockAdj_DB();
                objfarmer = objDataModel.SavenewSaveStockAdjustment_DB(objmodel, MysqlCon);

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

