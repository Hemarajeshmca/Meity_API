using FFI_DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static FFI_Model.ICDMOB_PAYTMModel;

namespace FFI_Service
{
   public class ICDMOB_PAYTMService
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDMOB_PAYTMService)); //Declaring Log4Net.
        public static ICDMOPOORDERDocument SavePO_OrderIDGenerate(ICDMOPOORDERRoot objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            ICDMOPOORDERDocument objinvoice = new ICDMOPOORDERDocument();
            try
            {
                ICDMOB_PAYTMDatamodel objDataModel = new ICDMOB_PAYTMDatamodel();
                objinvoice = objDataModel.SSavePO_OrderIDGenerateNew(objmodel, MysqlCon);

                return objinvoice;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
        public static ICDMOBPTMHISDocument SavePayHisReponse_service(ICDMOBPTMHISRoot objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            ICDMOBPTMHISDocument objinvoice = new ICDMOBPTMHISDocument();
            try
            {
                ICDMOB_PAYTMDatamodel objDataModel = new ICDMOB_PAYTMDatamodel();
                objinvoice = objDataModel.SSavePayHisReponse_DB(objmodel, MysqlCon);

                return objinvoice;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
        public static ICDInvoicePaytmApplication GetSingleICDInvoicefetch_Srv(ICDInvoicePaymentContext objinvoice, string Mysql)
        {
            ICDInvoicePaytmApplication objinvoiceRoot = new ICDInvoicePaytmApplication();
            ICDMOB_PAYTMDatamodel objDataModel = new ICDMOB_PAYTMDatamodel();

            try
            {
                objinvoiceRoot = objDataModel.GetICDInvoicepatymfetch(objinvoice, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }
    }
}
