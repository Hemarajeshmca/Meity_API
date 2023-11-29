using System;
using System.Collections.Generic;
using System.Text;
using FFI_DataModel;
using FFI_Model;

namespace FFI_Service
{
   public class FISTransferRegister_Service
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FISTransferRegister_Service)); //Declaring Log4Net. 
        public static FISTrnregApplication FetchTrnRegister(FISTrnregContext objfisdivContext, string Mysql)
        {

            FISTrnregApplication objinvoiceRoot = new FISTrnregApplication();
            FISTransferRegister_DataModel objDataModel = new FISTransferRegister_DataModel();
            try
            {
                objinvoiceRoot = objDataModel.FetchTrnRegister(objfisdivContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }

        public static SFISTrnregDocument newTransferRegister(SFISTrnregApplication objmodel, string MysqlCon)
        {
            SFISTrnregDocument IUOShareRefund = new SFISTrnregDocument();
            try
            {
                FISTransferRegister_DataModel objDataModel = new FISTransferRegister_DataModel();
                IUOShareRefund = objDataModel.newTransferRegister(objmodel, MysqlCon);
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
