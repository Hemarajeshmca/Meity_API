using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
    public class PAWHSRaiseInvoice_srv
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSRaiseInvoice_srv)); //Declaring Log4Net. 
        public static PAWHSRaiseInvoiceApplication Getallraise_invoice_Srv(PAWHSRaiseInvoiceContext objfarmer, string Mysql)
        {
            PAWHSRaiseInvoiceApplication ObjFarmerRoot = new PAWHSRaiseInvoiceApplication();
            PAWHSRaiseInvoice_DB objDataModel = new PAWHSRaiseInvoice_DB();
            try
            {
                ObjFarmerRoot = objDataModel.Getallraise_invoice_DB(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSRaiseInvoiceFApplication Getraise_invoice_srv(PAWHSRaiseInvoiceFContext objfarmer, string Mysql)
        {
            PAWHSRaiseInvoiceFApplication ObjFarmerRoot = new PAWHSRaiseInvoiceFApplication();
            PAWHSRaiseInvoice_DB objDataModel = new PAWHSRaiseInvoice_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Getraise_invoice_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSRaiseInvoiceSDocument Savenew_raise_invoice_srv(PAWHSRaiseInvoiceSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            PAWHSRaiseInvoiceSDocument objfarmer = new PAWHSRaiseInvoiceSDocument();
            try
            {
                PAWHSRaiseInvoice_DB objDataModel = new PAWHSRaiseInvoice_DB();
                objfarmer = objDataModel.Savenew_pawhs_service_receipting_DB(objmodel, MysqlCon);

                return objfarmer;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
        public static PAWHSRaiseInvoicePApplication Getpayment_collection_srv(PAWHSRaiseInvoicePContext objfarmer, string Mysql)
        {
            PAWHSRaiseInvoicePApplication ObjFarmerRoot = new PAWHSRaiseInvoicePApplication();
            PAWHSRaiseInvoice_DB objDataModel = new PAWHSRaiseInvoice_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Getpayment_collection_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSRaiseInvoicePSDocument new_payment_collection_raise_invoice_srv(PAWHSRaiseInvoicePSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            PAWHSRaiseInvoicePSDocument objfarmer = new PAWHSRaiseInvoicePSDocument();
            try
            {
                PAWHSRaiseInvoice_DB objDataModel = new PAWHSRaiseInvoice_DB();
                objfarmer = objDataModel.Savenew_payment_collection_raise_invoice_DB(objmodel, MysqlCon);

                return objfarmer;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
        public static PAWHSRaiseInvoiceProductApplication Getproductsearch_srv(PAWHSRaiseInvoiceProductContext objfarmer, string Mysql)
        {
            PAWHSRaiseInvoiceProductApplication ObjFarmerRoot = new PAWHSRaiseInvoiceProductApplication();
            PAWHSRaiseInvoice_DB objDataModel = new PAWHSRaiseInvoice_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Getproductsearch_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
    }
}

