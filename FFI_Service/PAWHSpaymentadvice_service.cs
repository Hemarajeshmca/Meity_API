using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
    public class PAWHSpaymentadvice_service
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSpaymentadvice_service)); //Declaring Log4Net. 
        public static PAWHSpayadviceApplication allpawhs_payment_advice(PAWHSpayadviceContext objfarmer, string Mysql)
        {
            PAWHSpayadviceApplication ObjFarmerRoot = new PAWHSpayadviceApplication();
            PAWHSpaymentadvice_DataModel objDataModel = new PAWHSpaymentadvice_DataModel();
            try
            {
                ObjFarmerRoot = objDataModel.allpawhs_payment_advice(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }

        public static PAWHSpaymentadvice_FApplication Gepayment_advice(PAWHSpaymentadvice_FContext objfarmer, string Mysql)
        {
            PAWHSpaymentadvice_FApplication ObjFarmerRoot = new PAWHSpaymentadvice_FApplication();
            PAWHSpaymentadvice_DataModel objDataModel = new PAWHSpaymentadvice_DataModel();

            try
            {
                ObjFarmerRoot = objDataModel.Getservice_invoice_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }

        public static PAWHSpaymentadvice_SDocument new_pawhs_payment_advice(PAWHSpaymentadvice_SApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            PAWHSpaymentadvice_SDocument objfarmer = new PAWHSpaymentadvice_SDocument();
            try
            {
                PAWHSpaymentadvice_DataModel objDataModel = new PAWHSpaymentadvice_DataModel();
                objfarmer = objDataModel.new_pawhs_payment_advice(objmodel, MysqlCon);

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
