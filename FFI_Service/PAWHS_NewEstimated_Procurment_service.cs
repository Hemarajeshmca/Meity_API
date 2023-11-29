using System;
using System.Collections.Generic;
using System.Text;
using FFI_Model;
using FFI_DataModel;
using System.Data;
using System.Security;

namespace FFI_Service
{
    public class PAWHS_NewEstimated_Procurment_service
    {
        public static pawhs_NewEstimate_Proc_ALL_Application pawhs_NewEstimated_Procurment_List(pawhs_NewEstimate_Proc_ALL_Context ObjContext, string Mysql)
        {
            pawhs_NewEstimate_Proc_ALL_Application ObjFetchAll = new pawhs_NewEstimate_Proc_ALL_Application();
            PAWHS_NewEstimated_Procurment_Datamodel objDataModel = new PAWHS_NewEstimated_Procurment_Datamodel();
            try
            {
                ObjFetchAll = objDataModel.pawhs_NewEstimated_Procurment_List(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }

          //
        public static pawhs_NewEstimate_Proc_single_Application Single_pawhs_NewEstimate_Proc(pawhs_NewEstimate_Proc_single_Context objfarmer, string Mysql)
        {
            pawhs_NewEstimate_Proc_single_Application ObjFarmerRoot = new pawhs_NewEstimate_Proc_single_Application();
            PAWHS_NewEstimated_Procurment_Datamodel objDataModel = new PAWHS_NewEstimated_Procurment_Datamodel();

            try
            {
                ObjFarmerRoot = objDataModel.Single_pawhs_NewEstimate_Proc(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }

        //
        public static pawhs_NewEstimate_Proc_SDocument save_pawhs_NewEstimate_Procurement(pawhs_NewEstimate_Proc_SApplication objmodel, string MysqlCon)
        {

            DataTable tab = new DataTable();
            pawhs_NewEstimate_Proc_SDocument objfarmer = new pawhs_NewEstimate_Proc_SDocument();
            try
            {
                PAWHS_NewEstimated_Procurment_Datamodel objDataModel = new PAWHS_NewEstimated_Procurment_Datamodel();
                objfarmer = objDataModel.save_pawhs_NewEstimate_Procurement(objmodel, MysqlCon);

                return objfarmer;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
    }
    //
}


