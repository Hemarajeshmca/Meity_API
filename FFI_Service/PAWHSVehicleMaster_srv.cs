using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
   public class PAWHSVehicleMaster_srv
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSVehicleMaster_srv)); //Declaring Log4Net. 
        public static PAWHSVehicleMasterApplication Getallvehicle_srv(PAWHSVehicleMasterContext objfarmer, string Mysql)
        {
            PAWHSVehicleMasterApplication ObjFarmerRoot = new PAWHSVehicleMasterApplication();
            PAWHSVehicleMaster_DB objDataModel = new PAWHSVehicleMaster_DB();
            try
            {
                ObjFarmerRoot = objDataModel.Getallvehicle_srv_DB(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSVehicleMasterFApplication Getvehicle_srv(PAWHSVehicleMasterFContext objfarmer, string Mysql)
        {
            PAWHSVehicleMasterFApplication ObjFarmerRoot = new PAWHSVehicleMasterFApplication();
            PAWHSVehicleMaster_DB objDataModel = new PAWHSVehicleMaster_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Getvehicle_srv_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSVehicleMasterSDocument Savenew_vehicle_master_srv(PAWHSVehicleMasterSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            PAWHSVehicleMasterSDocument objfarmer = new PAWHSVehicleMasterSDocument();
            try
            {
                PAWHSVehicleMaster_DB objDataModel = new PAWHSVehicleMaster_DB();
                objfarmer = objDataModel.Savenew_vehicle_master_srv_DB(objmodel, MysqlCon);

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


