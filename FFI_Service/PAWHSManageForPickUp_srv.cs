using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
    public class PAWHSManageForPickUp_srv
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSManageForPickUp_srv)); //Declaring Log4Net. 
        public static PAWHSManageForPickUpApplication Getallreadyto_pickup_Srv(PAWHSManageForPickUpContext objfarmer, string Mysql)
        {
            PAWHSManageForPickUpApplication ObjFarmerRoot = new PAWHSManageForPickUpApplication();
            PAWHSManageForPickUp_DB objDataModel = new PAWHSManageForPickUp_DB();
            try
            {
                ObjFarmerRoot = objDataModel.Getallreadyto_pickup_DB(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSManageForPickUpFApplication Getreadyto_pickup_Srv(PAWHSManageForPickUpFContext objfarmer, string Mysql)
        {
            PAWHSManageForPickUpFApplication ObjFarmerRoot = new PAWHSManageForPickUpFApplication();
            PAWHSManageForPickUp_DB objDataModel = new PAWHSManageForPickUp_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Getreadyto_pickup_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSManageForPickUpSDocument Savenew_readyto_pickup_srv(PAWHSManageForPickUpSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            PAWHSManageForPickUpSDocument objfarmer = new PAWHSManageForPickUpSDocument();
            try
            {
                PAWHSManageForPickUp_DB objDataModel = new PAWHSManageForPickUp_DB();
                objfarmer = objDataModel.Savenew_readyto_pickup_DB(objmodel, MysqlCon);

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


