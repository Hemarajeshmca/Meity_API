using System;
using System.Collections.Generic;
using System.Text;
using FFI_Model;
using FFI_DataModel;
using System.Data;
using System.Security;

namespace FFI_Service
{
    public class PAWHS_New_Aggregator_service
    {
        public static New_PAWHSAggregator_all_Application GetAllpawhs_aggregator_List(New_PAWHSAggregator_all_Context ObjContext, string Mysql)
        {
            New_PAWHSAggregator_all_Application ObjFetchAll = new New_PAWHSAggregator_all_Application();
            PAWHS_New_Aggregator_Datamodel objDataModel = new PAWHS_New_Aggregator_Datamodel();
            try
            {
                ObjFetchAll = objDataModel.GetAllpawhs_aggregator_List(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
        //Single_new_pawhs_aggregator
        public static New_PAWHSAggregator_single_Application Single_new_pawhs_aggregator(New_PAWHSAggregator_single_Context objfarmer, string Mysql)
        {
            New_PAWHSAggregator_single_Application ObjFarmerRoot = new New_PAWHSAggregator_single_Application();
            PAWHS_New_Aggregator_Datamodel objDataModel = new PAWHS_New_Aggregator_Datamodel();

            try
            {
                ObjFarmerRoot = objDataModel.Single_new_pawhs_aggregator(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        //
        public static New_PAWHSAggregator_SDocument save_new_pawhs_aggregator(New_PAWHSAggregator_SApplication objmodel, string MysqlCon)
        {
             
            DataTable tab = new DataTable();
            New_PAWHSAggregator_SDocument objfarmer = new New_PAWHSAggregator_SDocument();
            try
            {
                PAWHS_New_Aggregator_Datamodel objDataModel = new PAWHS_New_Aggregator_Datamodel();
                objfarmer = objDataModel.save_new_pawhs_aggregator(objmodel, MysqlCon);

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
