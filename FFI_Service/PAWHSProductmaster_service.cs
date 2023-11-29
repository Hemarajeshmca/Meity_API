using System;
using System.Collections.Generic;
using System.Text;
using FFI_Model;
using FFI_DataModel;
using System.Data;
using System.Security;

namespace FFI_Service
{
    public class PAWHSProductmaster_service
    {
        public static PAWHSProductmasterApplication GetAllProductMasterList(PAWHSProductmasterContext ObjContext, string Mysql)
        {
            PAWHSProductmasterApplication ObjFetchAll = new PAWHSProductmasterApplication();
            PAWHSProductmaster_Datamodel objDataModel = new PAWHSProductmaster_Datamodel();
            try
            {
                ObjFetchAll = objDataModel.GetAllProductMasterList(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }


        //
        public static PAWHSProductmasterFApplication Single_ProductMaster(PAWHSProductmasterFContext objfarmer, string Mysql)
        {
            PAWHSProductmasterFApplication ObjFarmerRoot = new PAWHSProductmasterFApplication();
            PAWHSProductmaster_Datamodel objDataModel = new PAWHSProductmaster_Datamodel();

            try
            {
                ObjFarmerRoot = objDataModel.Single_ProductMaster(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSProductmasterSDocument newSaveProductMaster(PAWHSProductmasterSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            PAWHSProductmasterSDocument objfarmer = new PAWHSProductmasterSDocument();
            try
            {
                PAWHSProductmaster_Datamodel objDataModel = new PAWHSProductmaster_Datamodel();
                objfarmer = objDataModel.newSaveProductMaster(objmodel, MysqlCon);

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
