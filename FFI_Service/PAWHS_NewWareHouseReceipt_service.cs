using System;
using System.Collections.Generic;
using System.Text;
using FFI_Model;
using FFI_DataModel;
using System.Data;
using System.Security;

namespace FFI_Service
{
   public  class PAWHS_NewWareHouseReceipt_service
    {
        public static PAWHS_NewWareHouseReceipt_ALL_Application pawhs_NewWareHouseReceipt_Lists(PAWHS_NewWareHouseReceipt_ALL_Context ObjContext, string Mysql)
        {
            PAWHS_NewWareHouseReceipt_ALL_Application ObjFetchAll = new PAWHS_NewWareHouseReceipt_ALL_Application();
            PAWHS_NewWareHouseReceipt_datamodel objDataModel = new PAWHS_NewWareHouseReceipt_datamodel();
            try
            {
                ObjFetchAll = objDataModel.pawhs_NewWareHouseReceipt_Lists(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
        public static PAWHS_NewWareHouseReceipt_single_Application Single_pawhs_NewWareHouseReceipt(PAWHS_NewWareHouseReceipt_single_Context objfarmer, string Mysql)
        {
            PAWHS_NewWareHouseReceipt_single_Application ObjFarmerRoot = new PAWHS_NewWareHouseReceipt_single_Application();
            PAWHS_NewWareHouseReceipt_datamodel objDataModel = new PAWHS_NewWareHouseReceipt_datamodel();

            try
            {
                ObjFarmerRoot = objDataModel.Single_pawhs_NewWareHouseReceipt(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }

        //
        public static PAWHS_NewWareHouseReceipt_SDocument save_pawhs_NewWareHouseReceipt(PAWHS_NewWareHouseReceipt_SApplication objmodel, string MysqlCon)
        {
            PAWHS_NewWareHouseReceipt_ApplicationException errorexp = new PAWHS_NewWareHouseReceipt_ApplicationException();
            DataTable tab = new DataTable();
            PAWHS_NewWareHouseReceipt_SDocument objfarmer = new PAWHS_NewWareHouseReceipt_SDocument();
            try
            {
                PAWHS_NewWareHouseReceipt_datamodel objDataModel = new PAWHS_NewWareHouseReceipt_datamodel();
                objfarmer = objDataModel.save_pawhs_NewWareHouseReceipt(objmodel, MysqlCon);

                return objfarmer;
            }
            catch (Exception ex)
            {               
                throw ex;
            }
        }



    }
}
