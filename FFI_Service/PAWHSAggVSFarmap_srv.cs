using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
    public class PAWHSAggVSFarmap_srv
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FarmerReg_Service)); //Declaring Log4Net. 
        public static PAWHSAggVSFarmapApplication Getallmapped_farmers_Srv(PAWHSAggVSFarmapContext objfarmer, string Mysql)
        {
            PAWHSAggVSFarmapApplication ObjFarmerRoot = new PAWHSAggVSFarmapApplication();
            PAWHSAggVSFarmap_DB objDataModel = new PAWHSAggVSFarmap_DB();
            try
            {
                ObjFarmerRoot = objDataModel.Getallmapped_farmers_DB(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSAggVSFarmapFApplication Getaggr_farmer_map_Srv(PAWHSAggVSFarmapFContext objfarmer, string Mysql)
        {
            PAWHSAggVSFarmapFApplication ObjFarmerRoot = new PAWHSAggVSFarmapFApplication();
            PAWHSAggVSFarmap_DB objDataModel = new PAWHSAggVSFarmap_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Getaggr_farmer_map_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSAggVSFarmapSDocument Savenew_aggr_vs_farmer_mapping_srv(PAWHSAggVSFarmapSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            PAWHSAggVSFarmapSDocument objfarmer = new PAWHSAggVSFarmapSDocument();
            try
            {
                PAWHSAggVSFarmap_DB objDataModel = new PAWHSAggVSFarmap_DB();
                objfarmer = objDataModel.Savenew_aggr_vs_farmer_mapping_DB(objmodel, MysqlCon);

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

