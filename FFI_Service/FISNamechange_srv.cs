using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
    public class FISNamechange_srv
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FISNamechange_srv)); //Declaring Log4Net. 
        public static FISNameChangeApplication allservice_requestList_srv(FISNameChangeContext objfarmer, string Mysql)
        {
            FISNameChangeApplication ObjFarmerRoot = new FISNameChangeApplication();
            FISNameChange_DB objDataModel = new FISNameChange_DB();
            try
            {
                ObjFarmerRoot = objDataModel.Getallservice_request_DB(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static FISNameChangeFApplication Getservice_req_name_Srv(FISNameChangeFContext objfarmer, string Mysql)
        {
            FISNameChangeFApplication ObjFarmerRoot = new FISNameChangeFApplication();
            FISNameChange_DB objDataModel = new FISNameChange_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Getservice_req_name_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static FISNameChangeFNApplication Getservice_req_Srv(FISNameChangeFNContext objfarmer, string Mysql)
        {
            FISNameChangeFNApplication ObjFarmerRoot = new FISNameChangeFNApplication();
            FISNameChange_DB objDataModel = new FISNameChange_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Getservice_req_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static FISNameChangeSDocument Savenewservicerequestname_Srv(FISNameChangeSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            FISNameChangeSDocument objfarmer = new FISNameChangeSDocument();
            try
            {
                FISNameChange_DB objDataModel = new FISNameChange_DB();
                objfarmer = objDataModel.Savenewservicerequestname_DB(objmodel, MysqlCon);

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
