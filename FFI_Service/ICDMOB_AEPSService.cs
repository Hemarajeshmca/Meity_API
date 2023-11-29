using FFI_DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static FFI_Model.ICDMOB_AEPSModel;

namespace FFI_Service
{
    public class ICDMOB_AEPSService
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDMOB_AEPSService)); //Declaring Log4Net.
        public static ICDMOAEPSORDERDocument SaveAEPS_OrderIDGenerate(ICDMOAEPSORDERRoot objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            ICDMOAEPSORDERDocument objinvoice = new ICDMOAEPSORDERDocument();
            try
            {
                ICDMOB_AEPSDatamodel objDataModel = new ICDMOB_AEPSDatamodel();
                objinvoice = objDataModel.SSaveAEPS_OrderIDGenerateNew(objmodel, MysqlCon);

                return objinvoice;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
        public static ICDMOBAEPSHISDocument SavePayHisReponse_AEPSservice(ICDMOBAEPSHISRoot objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            ICDMOBAEPSHISDocument objinvoice = new ICDMOBAEPSHISDocument();
            try
            {
                ICDMOB_AEPSDatamodel objDataModel = new ICDMOB_AEPSDatamodel();
                objinvoice = objDataModel.SSavePayHisReponse_AEPSDB(objmodel, MysqlCon);

                return objinvoice;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
        public static ICDInvoiceAEPSApplication GetSingleICDInvoicefetchAEPS_Srv(ICDInvoicePaymentContext objinvoice, string Mysql)
        {
            ICDInvoiceAEPSApplication objinvoiceRoot = new ICDInvoiceAEPSApplication();
            ICDMOB_AEPSDatamodel objDataModel = new ICDMOB_AEPSDatamodel();

            try
            {
                objinvoiceRoot = objDataModel.GetICDInvoiceAEPSfetch(objinvoice, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }
    }
}
