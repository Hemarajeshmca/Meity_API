using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
   public class FISAddresschange_srv
    {
       
        public static FISAddressChangeApplication Getservice_req_address_Srv(FISAddressChangeContext objfarmer, string Mysql)
        {
            FISAddressChangeApplication ObjFarmerRoot = new FISAddressChangeApplication();
            FISAddressChange_DB objDataModel = new FISAddressChange_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Getservice_req_address_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
      
        public static FISAddressChangeSDocument SavenewServiceRequestAddress_Srv(FISAddressChangeSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            FISAddressChangeSDocument objfarmer = new FISAddressChangeSDocument();
            try
            {
                FISAddressChange_DB objDataModel = new FISAddressChange_DB();
                objfarmer = objDataModel.SavenewServiceRequestAddress_DB(objmodel, MysqlCon);

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
