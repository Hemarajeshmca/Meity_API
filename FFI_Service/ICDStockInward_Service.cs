using System;
using System.Collections.Generic;
using System.Text;
using FFI_Model;
using FFI_DataModel;
using System.Data;
using static FFI_Model.ICDStockInwardModel;

namespace FFI_Service
{
    public class ICDStockInward_Service
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDStockInward_Service)); //Declaring Log4Net. 

        public static ICDStockRootObject GetAllICDStockDtls_Srv(ICDStockContext objICDStockContext, string Mysql)
        {

            ICDStockRootObject ICDStockRoot = new ICDStockRootObject();
            ICDStockInward_DataModel objDataModel = new ICDStockInward_DataModel();
            try
            {
                ICDStockRoot = objDataModel.GetAllStockList(objICDStockContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ICDStockRoot;
        }

        public static SICDStockRootObject SingleICDstockInward(SICDStockContext SobjICDStockContext, string Mysql)
        {

            SICDStockRootObject ICDStockRoot = new SICDStockRootObject();
            ICDStockInward_DataModel objDataModel = new ICDStockInward_DataModel();
            try
            {
                ICDStockRoot = objDataModel.SingleICDStockList(SobjICDStockContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ICDStockRoot;
        }
        public static IUStockDocument SaveICDStock (IUStockApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            IUStockDocument objIUStockDocument = new IUStockDocument();
            try
            {
                ICDStockInward_DataModel objDataModel = new ICDStockInward_DataModel();
                objIUStockDocument = objDataModel.SaveICDStock(objmodel, MysqlCon); 
                return objIUStockDocument;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
        public static PApplication ProductsearchStock(PContext objinvoice, string Mysql)
        {
            PApplication objinvoiceRoot = new PApplication();
            ICDStockInward_DataModel objDataModel = new ICDStockInward_DataModel();

            try
            {
                objinvoiceRoot = objDataModel.ProductsearchStock(objinvoice, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }

        public static Document Saveinwardpayment(PSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            Document objfarmer = new Document();
            try
            {
                ICDStockInward_DataModel objDataModel = new ICDStockInward_DataModel();
                objfarmer = objDataModel.Saveinwardpayment(objmodel, MysqlCon);

                return objfarmer;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public static ICDInvoicepayApplication GetSingleICDInwardPayfetch_Srv(ICDInvoicepayContext objinvoice, string Mysql)
        {
            ICDInvoicepayApplication objinvoiceRoot = new ICDInvoicepayApplication();
            ICDStockInward_DataModel objDataModel = new ICDStockInward_DataModel();

            try
            {
                objinvoiceRoot = objDataModel.GetICDProductInwardPayfetch(objinvoice, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }

        public static MOBPAYRoot paymentcollection_InwardList(string org, string locn, string user, string lang, int invoice_rowid, string Mysql)
        {
            MOBPAYRoot ObjFetchAll = new MOBPAYRoot();
            ICDStockInward_DataModel objDataModel = new ICDStockInward_DataModel();
            try
            {
                ObjFetchAll = objDataModel.paymentcollection_InwardList(org, locn, user, lang, invoice_rowid, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }


    }
}
