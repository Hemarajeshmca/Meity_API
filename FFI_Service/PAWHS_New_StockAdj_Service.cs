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
   public class PAWHS_New_StockAdj_Service
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FarmerReg_Service)); //Declaring Log4Net. 
        public static StockRootObject GetAllStockDtls_Srv(StockContext ObjModel, string Mysql)
        {
            StockRootObject ObjModelRoot = new StockRootObject();
            PAWHS_New_StockAdj_DB objDataModel = new PAWHS_New_StockAdj_DB();
            try
            {
                ObjModelRoot = objDataModel.GetAllStockDtls(ObjModel, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjModelRoot;
        }
        public static PAWHSStock_Save_Document NewPAWHSStockDetail(PAWHSStock_Save_Application objmodel, string MysqlCon)
        {
            string[] result = { };
            PAWHSStock_Save_Document objfarmer = new PAWHSStock_Save_Document();
            try
            {
                PAWHS_New_StockAdj_DB objDataModel = new PAWHS_New_StockAdj_DB();
                objfarmer = objDataModel.SaveStockDetails(objmodel, MysqlCon);

                return objfarmer;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
        public static PAWHSStockFetchApplication Single_StockFetch(PAWHSStock_FetchContext objfarmer, string Mysql)
        {
            PAWHSStockFetchApplication ObjFarmerRoot = new PAWHSStockFetchApplication();
            PAWHS_New_StockAdj_DB objDataModel = new PAWHS_New_StockAdj_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Single_FetchStock(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
    }
}
