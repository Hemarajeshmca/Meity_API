using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Service
{
   public class FISshareRefund_Service
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FISshareRefund_Service)); //Declaring Log4Net. 

        public static ShareRefundApplication GetAllsharerefund(ShareRefundContext objICDStockContext, string Mysql)
        {

            ShareRefundApplication ICDStockRoot = new ShareRefundApplication();
        FISshareRefund_DataModel objDataModel = new FISshareRefund_DataModel();
            // FISshareRefund_DataModel objDataModel = new FISshareRefund_DataModel();
            try
            {
                ICDStockRoot = objDataModel.GetAllsharerefund(objICDStockContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ICDStockRoot;
        }

        
            public static IUSrefundDocument newShareRefund(IUSrefundApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            IUSrefundDocument IUOShareRefund = new IUSrefundDocument();
            try
            {
                FISshareRefund_DataModel objDataModel = new FISshareRefund_DataModel();
                IUOShareRefund = objDataModel.newShareRefund(objmodel, MysqlCon);
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
