using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
   public class FISDublicateReq_srv
    {
        public static FISDublicateReqApplication Getservice_req_duplicate_Srv(FISDublicateReqContext objfarmer, string Mysql)
        {
            FISDublicateReqApplication ObjFarmerRoot = new FISDublicateReqApplication();
            FISDublicateReq_DB objDataModel = new FISDublicateReq_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Getservice_req_duplicate_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }

        public static FISDublicateReqSDocument SavenewServiceRequestDuplicate_Srv(FISDublicateReqSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            FISDublicateReqSDocument objfarmer = new FISDublicateReqSDocument();
            try
            {
                FISDublicateReq_DB objDataModel = new FISDublicateReq_DB();
                objfarmer = objDataModel.SavenewServiceRequestDuplicate_DB(objmodel, MysqlCon);

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
