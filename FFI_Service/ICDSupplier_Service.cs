using FFI_DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static FFI_Model.ICDSupplier_Model;

namespace FFI_Service
{
   public class ICDSupplier_Service
    {
        public static SaveSupplierDocument SaveICDSupplier(SaveSupplierApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            SaveSupplierDocument objIUStockDocument = new SaveSupplierDocument();
            try
            {
                ICDSupplier_DataModel objDataModel = new ICDSupplier_DataModel();
                objIUStockDocument = objDataModel.SaveICDSupplier(objmodel, MysqlCon);
                return objIUStockDocument;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
        public static ICDSupplierApplication ICDSupplier_List(ICDSupplierContext ObjContext, string Mysql)
        {
            ICDSupplierApplication ObjFetchAll = new ICDSupplierApplication();
            ICDSupplier_DataModel objDataModel = new ICDSupplier_DataModel();
            try
            {
                ObjFetchAll = objDataModel.ICDSupplier_List(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
        public static ICDSupplierFetchApplication ICDSupplier_SingleFetch(ICDSupplierFetchContext objfarmer, string Mysql)
        {
            ICDSupplierFetchApplication ObjFarmerRoot = new ICDSupplierFetchApplication();
            ICDSupplier_DataModel objDataModel = new ICDSupplier_DataModel();

            try
            {
                ObjFarmerRoot = objDataModel.ICDSupplier_SingleFetch(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
    }
}
