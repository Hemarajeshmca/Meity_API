using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
   public class PAWHSProduceCal_srv
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSProduceCal_srv)); //Declaring Log4Net. 
        public static PAWHSProduceCalApplication Getallproduce_calendar_Srv(PAWHSProduceCalContext objfarmer, string Mysql)
        {
            PAWHSProduceCalApplication ObjFarmerRoot = new PAWHSProduceCalApplication();
            PAWHSProduceCal_DB objDataModel = new PAWHSProduceCal_DB();
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
        public static PAWHSProduceCalFApplication Getproduce_calendar_Srv(PAWHSProduceCalFContext objfarmer, string Mysql)
        {
            PAWHSProduceCalFApplication ObjFarmerRoot = new PAWHSProduceCalFApplication();
            PAWHSProduceCal_DB objDataModel = new PAWHSProduceCal_DB();

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
        public static PAWHSProduceCalSDocument Savenew_produce_calendar_srv(PAWHSProduceCalSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            PAWHSProduceCalSDocument objfarmer = new PAWHSProduceCalSDocument();
            try
            {
                PAWHSProduceCal_DB objDataModel = new PAWHSProduceCal_DB();
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


