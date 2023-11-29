using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
    public class PAWHSProductionStageSetup_srv
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSProductionStageSetup_srv)); //Declaring Log4Net. 
        public static PAWHSProductionStageSetupApplication Getallproduction_stagesetup_Srv(PAWHSProductionStageSetupContext objfarmer, string Mysql)
        {
            PAWHSProductionStageSetupApplication ObjFarmerRoot = new PAWHSProductionStageSetupApplication();
            PAWHSProductionStageSetup_DB objDataModel = new PAWHSProductionStageSetup_DB();
            try
            {
                ObjFarmerRoot = objDataModel.Getallproduce_calendar_DB(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSProductionStageSetupFApplication Getproduction_stagesetup_Srv(PAWHSProductionStageSetupFContext objfarmer, string Mysql)
        {
            PAWHSProductionStageSetupFApplication ObjFarmerRoot = new PAWHSProductionStageSetupFApplication();
            PAWHSProductionStageSetup_DB objDataModel = new PAWHSProductionStageSetup_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Getproduce_calendar_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSProductionStageSetupSDocument Savenew_production_stagesetup_srv(PAWHSProductionStageSetupSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            PAWHSProductionStageSetupSDocument objfarmer = new PAWHSProductionStageSetupSDocument();
            try
            {
                PAWHSProductionStageSetup_DB objDataModel = new PAWHSProductionStageSetup_DB();
                objfarmer = objDataModel.Savenew_produce_calendar_DB(objmodel, MysqlCon);

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



