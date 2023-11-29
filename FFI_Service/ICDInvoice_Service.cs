using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
   public class ICDInvoice_Service
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInvoice_Service)); //Declaring Log4Net. 
        public static ICDInvoiceApplication GetAllICDInvoice_Srv(ICDInvoiceContext objinvoice, string Mysql)
        {
            ICDInvoiceApplication objinvoiceRoot = new ICDInvoiceApplication();
            ICDInvoice_DataModel objDataModel = new ICDInvoice_DataModel();
            try
            {
                objinvoiceRoot = objDataModel.GetAllICDInvoice_DB(objinvoice, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }
        public static ICDInvoiceFApplication GetSingleICDInvoicefetch_Srv(ICDInvoiceFContext objinvoice, string Mysql)
        {
            ICDInvoiceFApplication objinvoiceRoot = new ICDInvoiceFApplication();
            ICDInvoice_DataModel objDataModel = new ICDInvoice_DataModel();

            try
            {
                objinvoiceRoot = objDataModel.GetSingleICDInvoicefetch(objinvoice, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }
        public static ICDSIProApplication GetICDProductInvfetch_Srv(ICDSIProContext objinvoice, string Mysql)
        {
            ICDSIProApplication objinvoiceRoot = new ICDSIProApplication();
            ICDInvoice_DataModel objDataModel = new ICDInvoice_DataModel();

            try
            {
                objinvoiceRoot = objDataModel.GetICDProductInvfetch(objinvoice, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }
        public static ICDInvoiceSADocument Saveinvoice(ICDInvoiceSAApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            ICDInvoiceSADocument objinvoice = new ICDInvoiceSADocument();
            try
            {
                ICDInvoice_DataModel objDataModel = new ICDInvoice_DataModel();
                objinvoice = objDataModel.SaveinvoiceNew(objmodel, MysqlCon);

                return objinvoice;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
        public static Document Saveinvoicepayment(PSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            Document objfarmer = new Document();
            try
            {
                ICDInvoice_DataModel objDataModel = new ICDInvoice_DataModel();
                objfarmer = objDataModel.Saveinvoicepayment(objmodel, MysqlCon);

                return objfarmer;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
        public static ICDInvoicepayApplication GetSingleICDInvoicePayfetch_Srv(ICDInvoicepayContext objinvoice, string Mysql)
        {
            ICDInvoicepayApplication objinvoiceRoot = new ICDInvoicepayApplication();
            ICDInvoice_DataModel objDataModel = new ICDInvoice_DataModel();

            try
            {
                objinvoiceRoot = objDataModel.GetICDProductInvPayfetch(objinvoice, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }
        public static InvoiceApplication GetAllInvoiceList_Srv(InvoiceContext objinvoice, string Mysql)
        {
            InvoiceApplication objinvoiceRoot = new InvoiceApplication();
            ICDInvoice_DataModel objDataModel = new ICDInvoice_DataModel();
            try
            {
                objinvoiceRoot = objDataModel.GetAllInvoiceList_DB(objinvoice, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }
        public static InvoicePayApplication GetAllInvoicePayList_Srv(InvoicePayContext objinvoice, string Mysql)
        {
            InvoicePayApplication objinvoiceRoot = new InvoicePayApplication();
            ICDInvoice_DataModel objDataModel = new ICDInvoice_DataModel();
            try
            {
                objinvoiceRoot = objDataModel.GetAllInvoicePayList_DB(objinvoice, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }
    }
}
