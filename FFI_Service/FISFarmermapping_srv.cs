using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
   public class FISFarmermapping_srv
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FarmerReg_Service)); //Declaring Log4Net. 
        public static fpofarmerApplication GetallFPOFarmer_map_Srv(fpofarmerContext objfarmer, string Mysql)
        {
            fpofarmerApplication ObjFarmerRoot = new fpofarmerApplication();
            FISFarmermapping_datamodel objDataModel = new FISFarmermapping_datamodel();
            try
            {
                ObjFarmerRoot = objDataModel.GetallFPOFarmer_map_DB(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static fpofarmerFApplication GetSingleFPOFarmer_map_Srv(fpofarmerFContext objfarmer, string Mysql)
        {
            fpofarmerFApplication ObjFarmerRoot = new fpofarmerFApplication();
            FISFarmermapping_datamodel objDataModel = new FISFarmermapping_datamodel();

            try
            {
                ObjFarmerRoot = objDataModel.GetFPOFarmer_mapfetch_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static fpofarmerSDocument SaveFPOFarmerMap(fpofarmerSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            fpofarmerSDocument objfarmer = new fpofarmerSDocument();
            try
            {
                FISFarmermapping_datamodel objDataModel = new FISFarmermapping_datamodel();
                objfarmer = objDataModel.SaveFPOFarmerMap_DB(objmodel, MysqlCon);

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
