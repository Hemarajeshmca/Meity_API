using System;
using System.Collections.Generic;
using System.Text;
using FFI_DataModel;
using FFI_Model;
using System.Data;
namespace FFI_Service
{
   public class PAWHS_New_PaymentAdvice_Service
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHS_New_PaymentAdvice_Service)); //Declaring Log4Net. 

        //Start 
        public static PAWHS_New_PaymentAdvice_List_Application PAWHS_New_PaymentAdvice_All(PAWHS_New_PaymentAdvice_ALL_Context objPAWHSNewPaymentAdviceontext, string Mysql)
        {
            PAWHS_New_PaymentAdvice_List_Application ObjFarmerRoot = new PAWHS_New_PaymentAdvice_List_Application();
            PAWHS_New_PaymentAdvice_DataModel objDataModel = new PAWHS_New_PaymentAdvice_DataModel();
            try
            {
                ObjFarmerRoot = objDataModel.PAWHS_New_PaymentAdvice_All(objPAWHSNewPaymentAdviceontext, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }

        //End

        //Single Fetch start

        public static PAWHS_New_PaymentAdvice_Single_FApplication PAWHS_New_PaymentAdvice_Single(PAWHS_New_PaymentAdvice_Single_FContext objPAWHSNewPaymentAdviceSingleContext, string Mysql)
        {
            PAWHS_New_PaymentAdvice_Single_FApplication ObjFarmerRoot = new PAWHS_New_PaymentAdvice_Single_FApplication();
            PAWHS_New_PaymentAdvice_DataModel objDataModel = new PAWHS_New_PaymentAdvice_DataModel();

            try
            {
                ObjFarmerRoot = objDataModel.PAWHS_New_PaymentAdvice_Single(objPAWHSNewPaymentAdviceSingleContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }

        //End


        //Save And Update Start 

        public static PAWHS_New_PaymentAdvice_SDocument PAWHS_New_PaymentAdvice_Save(PAWHS_New_PaymentAdvice_SApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            PAWHS_New_PaymentAdvice_SDocument objfarmer = new PAWHS_New_PaymentAdvice_SDocument();
            try
            {
                PAWHS_New_PaymentAdvice_DataModel objDataModel = new PAWHS_New_PaymentAdvice_DataModel();
                objfarmer = objDataModel.PAWHS_New_PaymentAdvice_Save(objmodel, MysqlCon);

                return objfarmer;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }

        //End

        //start 

        public static PAWHS_New_PaymentAdvice_fetchgrid_FApplication PAWHS_New_PaymentAdvice_Fetch_Gridvalue(PAWHS_New_PaymentAdvice_fetchgrid_FContext objPAWHSNewPaymentAdviceSingleContext, string Mysql)
        {
            PAWHS_New_PaymentAdvice_fetchgrid_FApplication ObjFarmerRoot = new PAWHS_New_PaymentAdvice_fetchgrid_FApplication();
            PAWHS_New_PaymentAdvice_DataModel objDataModel = new PAWHS_New_PaymentAdvice_DataModel();

            try
            {
                ObjFarmerRoot = objDataModel.PAWHS_New_PaymentAdvice_Fetch_Gridvalue(objPAWHSNewPaymentAdviceSingleContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }

        //End
    }
}
