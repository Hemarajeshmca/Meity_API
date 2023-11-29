using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
   public class FISBankchange_srv
    {
        public static FISBankchangeApplication Getservice_req_bank_Srv(FISBankchangeContext objfarmer, string Mysql)
        {
            FISBankchangeApplication ObjFarmerRoot = new FISBankchangeApplication();
            FISBankchange_DB objDataModel = new FISBankchange_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Getservice_req_bank_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }

        public static FISBankchangeSDocument SavenewServiceRequestBank_Srv(FISBankchangeSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            FISBankchangeSDocument objfarmer = new FISBankchangeSDocument();
            try
            {
                FISBankchange_DB objDataModel = new FISBankchange_DB();
                objfarmer = objDataModel.SavenewServiceRequestBank_DB(objmodel, MysqlCon);

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
