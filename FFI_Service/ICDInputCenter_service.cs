using System;
using FFI_Model;
using FFI_DataModel;

namespace FFI_Service
{
    public class ICDInputCenter_service
    {
        public static ICDInputApplication ICDInputCenter_List(ICDInputContext ObjContext, string Mysql)
        {
            ICDInputApplication ObjFetchAll = new ICDInputApplication();
            ICDInputCenter_DB objDataModel = new ICDInputCenter_DB();
            try
            {
                ObjFetchAll = objDataModel.ICDInputCenter_List(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }

        public static ICDInputCenter_FApplication ICDInputCenter_SingleFetch(ICDInputCenter_FContext objfarmer, string Mysql)
        {
            ICDInputCenter_FApplication ObjFarmerRoot = new ICDInputCenter_FApplication();
            ICDInputCenter_DB objDataModel = new ICDInputCenter_DB();

            try
            {
                ObjFarmerRoot = objDataModel.ICDInputCenter_SingleFetch(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }

        public static ICDInput_SDocument ICDInputCenter_Save(ICDInput_SApplication objmodel, string MysqlCon)
        {
            ICDInput_SDocument objIUStockDocument = new ICDInput_SDocument();
            try
            {
                ICDInputCenter_DB objDataModel = new ICDInputCenter_DB();
                objIUStockDocument = objDataModel.ICDInputCenter_Save(objmodel, MysqlCon);
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
