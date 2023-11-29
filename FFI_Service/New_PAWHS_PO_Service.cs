using System;
using System.Collections.Generic;
using System.Text;
using FFI_Model;
using FFI_DataModel;
using System.Data;
using System.Security;
using log4net;

namespace FFI_Service
{
    public class New_PAWHS_PO_Service
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FarmerReg_Service)); //Declaring Log4Net. 
        public static PORootObject GetAllPODtls_Srv(POContext objfarmer, string Mysql)
        {
            PORootObject ObjFarmerRoot = new PORootObject();
            New_PAWHS_PO_DB objDataModel = new New_PAWHS_PO_DB();
            try
            {
                ObjFarmerRoot = objDataModel.GetAllPODtls(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSPO_Save_Document NewPAWHSPODetail(PAWHSPO_Save_Application objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            PAWHSPO_Save_Document objfarmer = new PAWHSPO_Save_Document();
            try
            {
                New_PAWHS_PO_DB objDataModel = new New_PAWHS_PO_DB();
                objfarmer = objDataModel.SavePODetails(objmodel, MysqlCon);

                return objfarmer;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
        public static PAWHSPOFetchApplication Single_POFetch(PAWHSPO_FetchContext objfarmer, string Mysql)
        {
            PAWHSPOFetchApplication ObjFarmerRoot = new PAWHSPOFetchApplication();
            New_PAWHS_PO_DB objDataModel = new New_PAWHS_PO_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Single_FetchPO(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSPurchaseOrderShipment Getshipmentfetch_srv(PAWHSPurchaseOrderShipmentContext objfarmer, string Mysql)
        {
            PAWHSPurchaseOrderShipment ObjFarmerRoot = new PAWHSPurchaseOrderShipment();
            New_PAWHS_PO_DB objDataModel = new New_PAWHS_PO_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Getshipmentfetch_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
    }
}
