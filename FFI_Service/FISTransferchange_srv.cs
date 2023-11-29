using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
    public class FISTransferchange_srv
    {
        public static FISTransferchangeApplication Getservice_req_transfer_Srv(FISTransferchangeContext objfarmer, string Mysql)
        {
            FISTransferchangeApplication ObjFarmerRoot = new FISTransferchangeApplication();
            FISTransferchange_DB objDataModel = new FISTransferchange_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Getservice_req_transfer_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }

        public static FISTransferchangeSDocument SavenewServiceRequestTransfer_Srv(FISTransferchangeSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            FISTransferchangeSDocument objfarmer = new FISTransferchangeSDocument();
            try
            {
                FISTransferchange_DB objDataModel = new FISTransferchange_DB();
                objfarmer = objDataModel.SavenewServiceRequestTransfer_DB(objmodel, MysqlCon);

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
