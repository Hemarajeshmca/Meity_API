using System;
using System.Collections.Generic;
using System.Text;
using FFI_DataModel;
using FFI_Model;

namespace FFI_Service
{
    public class FISDupRegister_Service
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FISTransferRegister_Service)); //Declaring Log4Net. 
        public static FISDupRegApplication FetchfisDupRegister(FISDupRegContext objfisdivContext, string Mysql)
        {

            FISDupRegApplication objinvoiceRoot = new FISDupRegApplication();
            FISDupRegister_DataModel objDataModel = new FISDupRegister_DataModel();
            try
            {
                objinvoiceRoot = objDataModel.FetchfisDupRegister(objfisdivContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }

        public static SFISDupRegDocument newDuplicateRegister(SFISDupRegApplication objmodel, string MysqlCon)
        {
            SFISDupRegDocument IUOShareRefund = new SFISDupRegDocument();
            try
            {
                FISDupRegister_DataModel objDataModel = new FISDupRegister_DataModel();
                IUOShareRefund = objDataModel.newDuplicateRegister(objmodel, MysqlCon);
                return IUOShareRefund;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
    }
}
