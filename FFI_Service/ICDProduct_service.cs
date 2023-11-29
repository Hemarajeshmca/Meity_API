using System; 
using FFI_Model;
using FFI_DataModel; 
namespace FFI_Service
{
    public class ICDProduct_service
    {
        public static ICDProductApplication ICDProduct_List(ICDProductContext ObjContext, string Mysql)
        {
            ICDProductApplication ObjFetchAll = new ICDProductApplication();
            ICDProduct_DB objDataModel = new ICDProduct_DB();
            try
            {
                ObjFetchAll = objDataModel.ICDProduct_List(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }

        public static ICDProduct_FApplication ICDProduct_SingleFetch(ICDProduct_FContext objfarmer, string Mysql)
        {
            ICDProduct_FApplication ObjFarmerRoot = new ICDProduct_FApplication();
            ICDProduct_DB objDataModel = new ICDProduct_DB();

            try
            {
                ObjFarmerRoot = objDataModel.ICDProduct_SingleFetch(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }


        public static ICDProduct_Document ICDProduct_Save(ICDProduct_SApplication objmodel, string MysqlCon)
        { 
            ICDProduct_Document objIUStockDocument = new ICDProduct_Document();
            try
            {
                ICDProduct_DB objDataModel = new ICDProduct_DB();
                objIUStockDocument = objDataModel.ICDProduct_Save(objmodel, MysqlCon);
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
