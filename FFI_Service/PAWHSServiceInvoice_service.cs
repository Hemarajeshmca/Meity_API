using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
    public class PAWHSServiceInvoice_service
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSServiceInvoice_service)); //Declaring Log4Net. 

        public static PAWHSServiceInvoiceApplication GetallService_invoice_Srv(PAWHSServiceInvoiceContext objfarmer, string Mysql)
        {
            PAWHSServiceInvoiceApplication ObjFarmerRoot = new PAWHSServiceInvoiceApplication();
            PAWHSServiceInvoice_DB objDataModel = new PAWHSServiceInvoice_DB();
            try
            {
                ObjFarmerRoot = objDataModel.Getallservice_invoice_DB(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }

        public static PAWHSFSerInvoiceApplication Getservice_invoice_srv(PAWHSFSerInvoiceContext objfarmer, string Mysql)
        {
            PAWHSFSerInvoiceApplication ObjFarmerRoot = new PAWHSFSerInvoiceApplication();
            PAWHSServiceInvoice_DB objDataModel = new PAWHSServiceInvoice_DB();

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
        public static PAWHSServiceInvoiceSDocument Savenew_service_invoice(PAWHSServiceInvoiceSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            PAWHSServiceInvoiceSDocument objfarmer = new PAWHSServiceInvoiceSDocument();
            try
            {
                PAWHSServiceInvoice_DB objDataModel = new PAWHSServiceInvoice_DB();
                objfarmer = objDataModel.Savenew_service_invoice(objmodel, MysqlCon);

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
