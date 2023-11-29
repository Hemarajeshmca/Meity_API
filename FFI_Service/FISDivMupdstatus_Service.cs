using System;
using System.Collections.Generic;
using System.Text;
using FFI_DataModel;
using FFI_Model;

namespace FFI_Service
{
    public class FISDivMupdstatus_Service
    {
        //FillDIVupdate
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FISDivMupdstatus_Service)); //Declaring Log4Net. 
        public static fisDMPApplication FillDIVupdate(fisDMPContext objfisdivContext, string Mysql)
        {

            fisDMPApplication objinvoiceRoot = new fisDMPApplication();
            FISDivMupdstatus_DataModel objDataModel = new FISDivMupdstatus_DataModel();
            try
            {
                objinvoiceRoot = objDataModel.FillDIVupdate(objfisdivContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }

        public static SfisDMPDocument newDividendUpdateStatus(SfisDMPApplication objmodel, string MysqlCon)
        {
            SfisDMPDocument IUOShareRefund = new SfisDMPDocument();
            try
            {
                FISDivMupdstatus_DataModel objDataModel = new FISDivMupdstatus_DataModel();
                IUOShareRefund = objDataModel.newDividendUpdateStatus(objmodel, MysqlCon);
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
