using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
   public class PAWHSWarehouseReceipt_srv
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSWarehouseReceipt_srv)); //Declaring Log4Net. 
        public static PAWHSWarehouseReceiptApplication Getallwarehouse_receipt_Srv(PAWHSWarehouseReceiptContext objfarmer, string Mysql)
        {
            PAWHSWarehouseReceiptApplication ObjFarmerRoot = new PAWHSWarehouseReceiptApplication();
            PAWHSWarehouseReceipt_DB objDataModel = new PAWHSWarehouseReceipt_DB();
            try
            {
                ObjFarmerRoot = objDataModel.Getallwarehouse_receipt_DB(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSWarehouseReceiptFApplication Getwarehouse_receipt_srv(PAWHSWarehouseReceiptFContext objfarmer, string Mysql)
        {
            PAWHSWarehouseReceiptFApplication ObjFarmerRoot = new PAWHSWarehouseReceiptFApplication();
            PAWHSWarehouseReceipt_DB objDataModel = new PAWHSWarehouseReceipt_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Getwarehouse_receipt_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSWarehouseReceiptSDocument Savenew_warehouse_receipt_srv(PAWHSWarehouseReceiptSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            PAWHSWarehouseReceiptSDocument objfarmer = new PAWHSWarehouseReceiptSDocument();
            try
            {
                PAWHSWarehouseReceipt_DB objDataModel = new PAWHSWarehouseReceipt_DB();
                objfarmer = objDataModel.Savenew_warehouse_receipt_DB(objmodel, MysqlCon);

                return objfarmer;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
        public static PAWHSWarehouseReceiptIApplication Getitem_master_srv(PAWHSWarehouseReceiptIContext objfarmer, string Mysql)
        {
            PAWHSWarehouseReceiptIApplication ObjFarmerRoot = new PAWHSWarehouseReceiptIApplication();
            PAWHSWarehouseReceipt_DB objDataModel = new PAWHSWarehouseReceipt_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Getitem_master_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
    }
}


