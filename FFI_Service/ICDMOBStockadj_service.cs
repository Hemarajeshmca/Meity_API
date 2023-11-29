using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
   public class ICDMOBStockadj_service
    {
        public static ICDMOBSADocument SaveICDStockAdj(ICDMOBSARoot objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            ICDMOBSADocument objIUStockDocument = new ICDMOBSADocument();
            try
            {
                ICDMOBStockadj_datamodel objDataModel = new ICDMOBStockadj_datamodel();
                objIUStockDocument = objDataModel.SaveICDStockAdj(objmodel, MysqlCon);
                return objIUStockDocument;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
        public static ICDMOBCRoot1 icdStockadjLRP(string org, string locn, string user, string lang, string In_orgn_code, string ConString)
        {
            ICDMOBCRoot1 ObjList = new ICDMOBCRoot1();
            ICDMOBStockadj_datamodel objDataModel = new ICDMOBStockadj_datamodel();
            try
            {
                ObjList = objDataModel.icdStockadjLRP_DB(org, locn, user, lang, In_orgn_code, ConString);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ObjList;
        }
    }
}
