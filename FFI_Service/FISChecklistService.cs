using FFI_DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static FFI_Model.FISChecklistModel;

namespace FFI_Service
{
  public  class FISChecklistService
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FISChecklistService)); //Declaring Log4Net. 
        public static FApplication FISChecklistFetchSrtran(FContext objfarmer, string Mysql)
        {
            FApplication ObjFarmerRoot = new FApplication();
            FISChecklistDataModel objDataModel = new FISChecklistDataModel();

            try
            {
                ObjFarmerRoot = objDataModel.FISChecklistFetchDBtran(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static HApplication FISChecklistFetchSrHistory(HContext objfarmerH, string Mysql)
        {
            HApplication ObjFarmerRootH = new HApplication();
            FISChecklistDataModel objDataModelH = new FISChecklistDataModel();

            try
            {
                ObjFarmerRootH = objDataModelH.FISChecklistFetchDBHistory(objfarmerH, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRootH;
        }

        public static SaveCheckTranDocument SaveCheckTransrv(SaveCheckTranApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            SaveCheckTranDocument objIUStockDocument = new SaveCheckTranDocument();
            try
            {
                FISChecklistDataModel objDataModel = new FISChecklistDataModel();
                objIUStockDocument = objDataModel.SaveCheckTranDB(objmodel, MysqlCon);
                return objIUStockDocument;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
    }
}
