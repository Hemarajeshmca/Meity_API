using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
   public class PAWHSStageItem_srv
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSStageItem_srv)); //Declaring Log4Net. 
        public static PAWHSStageItemApplication Getallstageitem_definition_Srv(PAWHSStageItemContext objfarmer, string Mysql)
        {
            PAWHSStageItemApplication ObjFarmerRoot = new PAWHSStageItemApplication();
            PAWHSStageItem_DB objDataModel = new PAWHSStageItem_DB();
            try
            {
                ObjFarmerRoot = objDataModel.Getallstageitem_definition_Srv(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSStageItemFApplication Getstageitem_definition_Srv(PAWHSStageItemFContext objfarmer, string Mysql)
        {
            PAWHSStageItemFApplication ObjFarmerRoot = new PAWHSStageItemFApplication();
            PAWHSStageItem_DB objDataModel = new PAWHSStageItem_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Getstageitem_definition_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSStageItemIApplication Getstage_definition_Srv(PAWHSStageItemIContext objfarmer, string Mysql)
        {
            PAWHSStageItemIApplication ObjFarmerRoot = new PAWHSStageItemIApplication();
            PAWHSStageItem_DB objDataModel = new PAWHSStageItem_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Getstage_definition_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static PAWHSStageItemSDocument Savenew_stage_item_definition_srv(PAWHSStageItemSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            PAWHSStageItemSDocument objfarmer = new PAWHSStageItemSDocument();
            try
            {
                PAWHSStageItem_DB objDataModel = new PAWHSStageItem_DB();
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



