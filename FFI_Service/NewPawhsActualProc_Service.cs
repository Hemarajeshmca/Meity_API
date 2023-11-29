using System;
using System.Collections.Generic;
using System.Text;
using FFI_Model;
using FFI_DataModel;
using System.Data;
using System.Security;

namespace FFI_Service
{
    public class NewPawhsActualProc_Service
    {
        public static PAWHSActualProcurmentApplication GetActualProcList(PAWHSActualProcurmentContext ObjContext, string Mysql)
        {
            PAWHSActualProcurmentApplication ObjFetchAll = new PAWHSActualProcurmentApplication();
            NewPawhsActualProc_DB objDataModel = new NewPawhsActualProc_DB();
            try
            {
                ObjFetchAll = objDataModel.GetActualProcurmentList(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
        public static PAWHSActualProcurmentFetchApplication Single_ActualPro(PAWHSActualProcurment_FetchContext objfarmer, string Mysql)
        {
            PAWHSActualProcurmentFetchApplication ObjFarmerRoot = new PAWHSActualProcurmentFetchApplication();
            NewPawhsActualProc_DB objDataModel = new NewPawhsActualProc_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Single_ActualProcurment(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSActualProcurment_Save_Document newSaveActualProcur(PAWHSActualProcurment_Save_Application objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            PAWHSActualProcurment_Save_Document objfarmer = new PAWHSActualProcurment_Save_Document();
            try
            {
                NewPawhsActualProc_DB objDataModel = new NewPawhsActualProc_DB();
                objfarmer = objDataModel.newSaveActualProcurment(objmodel, MysqlCon);

                return objfarmer;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
        public static PAWHSEstimateActWRApplication Estimate_Actual_Approve_List(PAWHSEstimateActWRContext objfarmer, string Mysql)
        {
            PAWHSEstimateActWRApplication ObjFarmerRoot = new PAWHSEstimateActWRApplication();
            NewPawhsActualProc_DB objDataModel = new NewPawhsActualProc_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Estimate_Actual_Approve_List(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSActualProcurmentSlnoFetchApplication Single_ActualPro_Slno(PAWHSActualProcurment_SlnoFetchContext objfarmer, string Mysql)
        {
            PAWHSActualProcurmentSlnoFetchApplication ObjFarmerRoot = new PAWHSActualProcurmentSlnoFetchApplication();
            NewPawhsActualProc_DB objDataModel = new NewPawhsActualProc_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Actual_slno_List(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
    }
}
