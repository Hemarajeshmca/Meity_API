using FFI_DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static FFI_Model.New_Pawhs_BuyerMaster_Model;

namespace FFI_Service
{
   public class New_Pawhs_BuyerMaster_Service
    {
        public static PawhsBuyerMasterApplication PawhsBuyerMaster_List(PawhsBuyerMasterContext ObjContext, string Mysql)
        {
            PawhsBuyerMasterApplication ObjFetchAll = new PawhsBuyerMasterApplication();
            New_Pawhs_BuyerMaster_DataModel objDataModel = new New_Pawhs_BuyerMaster_DataModel();
            try
            {
                ObjFetchAll = objDataModel.PawhsBuyerMaster_List(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
        public static PawhsBuyerMasterFetchApplication PawhsBuyerMaster_SingleFetch(PawhsBuyerMasterFetchContext objfarmer, string Mysql)
        {
            PawhsBuyerMasterFetchApplication ObjFarmerRoot = new PawhsBuyerMasterFetchApplication();
            New_Pawhs_BuyerMaster_DataModel objDataModel = new New_Pawhs_BuyerMaster_DataModel();

            try
            {
                ObjFarmerRoot = objDataModel.PawhsBuyerMaster_SingleFetch(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }

        public static SavebuyerDocument SaveBuyerMaster_service(SavebuyerApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            SavebuyerDocument objIUStockDocument = new SavebuyerDocument();
            try
            {
                New_Pawhs_BuyerMaster_DataModel objDataModel = new New_Pawhs_BuyerMaster_DataModel();
                objIUStockDocument = objDataModel.SaveBuyerMaster_DB(objmodel, MysqlCon);
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
