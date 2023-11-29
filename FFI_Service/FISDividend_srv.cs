using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Service
{
    public class FISDividend_srv
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FarmerReg_Service)); //Declaring Log4Net. 
        public static FISDividendApplication GetallDividend_Srv(FISDividendContext objfarmer, string Mysql)
        {
            FISDividendApplication ObjFarmerRoot = new FISDividendApplication();
            FISDividend_datamodel objDataModel = new FISDividend_datamodel();
            try
            {
                ObjFarmerRoot = objDataModel.GetallDividend_DB(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static FISDividendFApplication GetDividendfetch_Srv(FISDividendFContext objfarmer, string Mysql)
        {
            FISDividendFApplication ObjFarmerRoot = new FISDividendFApplication();
            FISDividend_datamodel objDataModel = new FISDividend_datamodel();

            try
            {
                ObjFarmerRoot = objDataModel.GetDividendfetch_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static FISDividendSDocument SavenewDividendStructure(FISDividendSApplication objfarmer, string Mysql)
        {
            FISDividendSDocument ObjFarmerRoot = new FISDividendSDocument();
            FISDividend_datamodel objDataModel = new FISDividend_datamodel();

            try
            {
                ObjFarmerRoot = objDataModel.newDividendStructure_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
    }
}
