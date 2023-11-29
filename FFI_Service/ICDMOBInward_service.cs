using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
     public class ICDMOBInward_service
    {
        public static ICDINSDocument SaveICDStock(ICDINSRoot objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            ICDINSDocument objIUStockDocument = new ICDINSDocument();
            try
            {
                ICDMOBInward_Datamodel objDataModel = new ICDMOBInward_Datamodel();
                objIUStockDocument = objDataModel.SaveICDStock(objmodel, MysqlCon);
                return objIUStockDocument;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
        public static IssueList IssueList(string org, string locn, string user, string lang, string Mysql)
        {

            IssueList ICDStockRoot = new IssueList();
            ICDMOBInward_Datamodel objDataModel = new ICDMOBInward_Datamodel();
            try
            {
                ICDStockRoot = objDataModel.IssueList(org, locn, user, lang, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ICDStockRoot;
        }
    }
}
