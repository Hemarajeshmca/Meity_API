using System;
using System.Collections.Generic;
using System.Text;
using FFI_DataModel;
using FFI_Model;
using System.Data;
namespace FFI_Service
{
   public class PAWHS_New_PaymentAdvice_Update_Service
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHS_New_PaymentAdvice_Update_Service)); //Declaring Log4Net. 

        public static PAWHS_New_PaymentAdvice_UpdateApplication all_pawhs_payment_update(PAWHS_New_PaymentAdvice_UpdateContext objfarmer, string Mysql)
        {
            PAWHS_New_PaymentAdvice_UpdateApplication ObjFarmerRoot = new PAWHS_New_PaymentAdvice_UpdateApplication();
            PAWHS_New_PaymentAdvice_Update_DataModel objDataModel = new PAWHS_New_PaymentAdvice_Update_DataModel();
            try
            {
                ObjFarmerRoot = objDataModel.all_pawhs_payment_update(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }

        //End

        //start 

        public static PAWHS_New_PaymentAdvice_UpdateSDocument new_pawhs_payment_update(PAWHS_New_PaymentAdvice_UpdateSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            PAWHS_New_PaymentAdvice_UpdateSDocument objfarmer = new PAWHS_New_PaymentAdvice_UpdateSDocument();
            try
            {
                PAWHS_New_PaymentAdvice_Update_DataModel objDataModel = new PAWHS_New_PaymentAdvice_Update_DataModel();
                objfarmer = objDataModel.new_pawhs_payment_update(objmodel, MysqlCon);

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
