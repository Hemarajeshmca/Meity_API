using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
   public class FISUpdateservice_srv
    {
        public static FISUpdateserviceApplication Getservice_req_update_Srv(FISUpdateserviceContext objfarmer, string Mysql)
        {
            FISUpdateserviceApplication ObjFarmerRoot = new FISUpdateserviceApplication();
            FISUpdateservice_DB objDataModel = new FISUpdateservice_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Getservice_req_update_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }

        public static FISUpdateserviceSDocument SavenewservicerequestUpdate_Srv(FISUpdateserviceSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            FISUpdateserviceSDocument objfarmer = new FISUpdateserviceSDocument();
            try
            {
                FISUpdateservice_DB objDataModel = new FISUpdateservice_DB();
                objfarmer = objDataModel.SavenewservicerequestUpdate_DB(objmodel, MysqlCon);

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
