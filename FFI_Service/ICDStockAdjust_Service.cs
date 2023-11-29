using System;
using System.Collections.Generic;
using System.Text;
using FFI_Model;
using FFI_DataModel;
using System.Data;

namespace FFI_Service
{
 public   class ICDStockAdjust_Service
    { 
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDStockAdjust_Service)); //Declaring Log4Net. 
        public static ICDStockAdjRootObject GetAllICDStockDtls_Srv(ICDStockAdjContext objICDStockAdjContext, string Mysql)
        {

            ICDStockAdjRootObject ICDStockAdjRoot = new ICDStockAdjRootObject();
            ICDStockAdjust_DataModel objDataModel = new ICDStockAdjust_DataModel();
            try
            {
                ICDStockAdjRoot = objDataModel.GetAllStockAdjList(objICDStockAdjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ICDStockAdjRoot;
        }

        public static SingleICDStockAdjApplication SingleICDstockAdj(SingleICDStockAdjContext SobjICDStockAdjContext, string Mysql)
        {

            SingleICDStockAdjApplication ICDStockRoot = new SingleICDStockAdjApplication();
            ICDStockAdjust_DataModel objDataModel = new ICDStockAdjust_DataModel();
            try
            {
                ICDStockRoot = objDataModel.SingleICDStockAdjList(SobjICDStockAdjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ICDStockRoot;
        }
         
         public static IUStockADocument SaveICDStockAdj(IUStockAApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            IUStockADocument objIUStockDocument = new IUStockADocument();
            try
            {
                ICDStockAdjust_DataModel objDataModel = new ICDStockAdjust_DataModel();
                objIUStockDocument = objDataModel.SaveICDStockAdj(objmodel, MysqlCon);
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
