using System;
using System.Collections.Generic;
using System.Text;
using FFI_DataModel;
using FFI_Model;

namespace FFI_Service
{
    public class FISDividentRegister_Service
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FISDividentRegister_Service)); //Declaring Log4Net. 
        public static DivRegApplication divident_reg(DivRegContext objfisdivContext, string Mysql)
        {

            DivRegApplication objinvoiceRoot = new DivRegApplication();
            FISDividentRegister_DataModel objDataModel = new FISDividentRegister_DataModel();
            try
            {
                objinvoiceRoot = objDataModel.divident_reg(objfisdivContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }

        //SaveDividendRegister
        public static SDivRegDocument SaveDividendRegister(SDivRegApplication objmodel, string MysqlCon)
        { 
            SDivRegDocument objinvoice = new SDivRegDocument();
            try
            {
                FISDividentRegister_DataModel objDataModel = new FISDividentRegister_DataModel();
                objinvoice = objDataModel.SaveDividendRegister(objmodel, MysqlCon);

                return objinvoice;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
    }
}
