using FFI_DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static FFI_Model.LRS_FPOLoanModel;

namespace FFI_Service
{
    public class LRS_FPOLoanService
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(LRS_FPOLoanService)); //Declaring Log4Net. 
        public static LRSFpoLoanApplication GetAllLoanFPO_Srv(LRSFpoLoanContext objlrs, string Mysql)
        {
            LRSFpoLoanApplication objlrsRoot = new LRSFpoLoanApplication();
            LRS_FPOLoanDataModel objDataModel = new LRS_FPOLoanDataModel();
            try
            {
                objlrsRoot = objDataModel.GetAllLoanFPO_DB(objlrs, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objlrsRoot;
        }
        public static LRSFpoLoanFApplication GetSingleLRSFpoLoanfetch_Srv(LRSFpoLoanFContext objlrs, string Mysql)
        {
            LRSFpoLoanFApplication objLrsRoot = new LRSFpoLoanFApplication();
            LRS_FPOLoanDataModel objDataModel = new LRS_FPOLoanDataModel();

            try
            {
                objLrsRoot = objDataModel.GetSingleLRSFpoLoanfetch_DB(objlrs, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objLrsRoot;
        }

        public static LRSSaveDocument SaveLRSFpoLoan(LRSSaveApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            LRSSaveDocument objLrsFpoLoanS = new LRSSaveDocument();
            try
            {
                LRS_FPOLoanDataModel objDataModel = new LRS_FPOLoanDataModel();
                objLrsFpoLoanS = objDataModel.SaveLrsFpoLoanNew(objmodel, MysqlCon);

                return objLrsFpoLoanS;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
    }
}
