using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
   public class FISNomieeChange_srv
    {

        public static FISNomieeChangeApplication Getservice_req_nominee_Srv(FISNomieeChangeContext objfarmer, string Mysql)
        {
            FISNomieeChangeApplication ObjFarmerRoot = new FISNomieeChangeApplication();
            FISNomieeChange_DB objDataModel = new FISNomieeChange_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Getservice_req_nominee_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }

        public static FISNomieeChangeSDocument Savenewservicerequestnomiee_Srv(FISNomieeChangeSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            FISNomieeChangeSDocument objfarmer = new FISNomieeChangeSDocument();
            try
            {
                FISNomieeChange_DB objDataModel = new FISNomieeChange_DB();
                objfarmer = objDataModel.Savenewservicerequestnomiee_DB(objmodel, MysqlCon);

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
