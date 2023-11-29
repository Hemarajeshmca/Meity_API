using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
   public class PAWHS_NEW_BookInvoice_service
    {
        public static PAWHSBookInvoiceApplication GetAllnew_bookinvoiceList_srv(PAWHSBookInvoiceContext ObjContext, string Mysql)
        {
            PAWHSBookInvoiceApplication ObjFetchAll = new PAWHSBookInvoiceApplication();
            PAWHS_NEW_BookInvoice_datamodel objDataModel = new PAWHS_NEW_BookInvoice_datamodel();
            try
            {
                ObjFetchAll = objDataModel.GetAllnew_bookinvoiceList_DB(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
        //Single_new_pawhs_aggregator
        public static PAWHSBookInvoiceFApplication Single_new_new_book_invoice_srv(PAWHSBookInvoiceFContext objfarmer, string Mysql)
        {
            PAWHSBookInvoiceFApplication ObjFarmerRoot = new PAWHSBookInvoiceFApplication();
            PAWHS_NEW_BookInvoice_datamodel objDataModel = new PAWHS_NEW_BookInvoice_datamodel();
            try
            {
                ObjFarmerRoot = objDataModel.Single_new_new_book_invoice_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        //
        public static PAWHSBookInvoiceSDocument save_new_book_invoice_srv(PAWHSBookInvoiceSApplication objmodel, string MysqlCon)
        {

            DataTable tab = new DataTable();
            PAWHSBookInvoiceSDocument objfarmer = new PAWHSBookInvoiceSDocument();
            try
            {
                PAWHS_NEW_BookInvoice_datamodel objDataModel = new PAWHS_NEW_BookInvoice_datamodel();
                objfarmer = objDataModel.save_new_book_invoice_DB(objmodel, MysqlCon);

                return objfarmer;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
        public static PAWHSBookInvoicenewProductApplication Getproductsearch_srv(PAWHSBookInvoicenewProductContext objfarmer, string Mysql)
        {
            PAWHSBookInvoicenewProductApplication ObjFarmerRoot = new PAWHSBookInvoicenewProductApplication();
            PAWHS_NEW_BookInvoice_datamodel objDataModel = new PAWHS_NEW_BookInvoice_datamodel();

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
        public static POLocApplication Getpolocationsearch_srv(POLocContext objfarmer, string Mysql)
        {
            POLocApplication ObjFarmerRoot = new POLocApplication();
            PAWHS_NEW_BookInvoice_datamodel objDataModel = new PAWHS_NEW_BookInvoice_datamodel();

            try
            {
                ObjFarmerRoot = objDataModel.Getpolocationsearch_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSBookInvoiceFTRANS Gettransportslnofetch_srv(PAWHSBookInvoiceFTRANSContext objfarmer, string Mysql)
        {
            PAWHSBookInvoiceFTRANS ObjFarmerRoot = new PAWHSBookInvoiceFTRANS();
            PAWHS_NEW_BookInvoice_datamodel objDataModel = new PAWHS_NEW_BookInvoice_datamodel();

            try
            {
                ObjFarmerRoot = objDataModel.Gettransportslnofetch_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static Document SavePAWHSinvoicepayment(PSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            Document objfarmer = new Document();
            try
            {
                PAWHS_NEW_BookInvoice_datamodel objDataModel = new PAWHS_NEW_BookInvoice_datamodel();
                objfarmer = objDataModel.SavePAWHSinvoicepayment_DB(objmodel, MysqlCon);

                return objfarmer;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
        public static ICDInvoicepayApplication GetSinglePAWHSInvoicePayfetch_Srv(ICDInvoicepayContext objinvoice, string Mysql)
        {
            ICDInvoicepayApplication objinvoiceRoot = new ICDInvoicepayApplication();
            PAWHS_NEW_BookInvoice_datamodel objDataModel = new PAWHS_NEW_BookInvoice_datamodel();

            try
            {
                objinvoiceRoot = objDataModel.GetPAWHSProductInvPayfetch_DB(objinvoice, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }
    }
}

