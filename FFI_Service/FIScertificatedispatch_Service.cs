using System;
using System.Collections.Generic;
using System.Text;
using FFI_Model;
using FFI_DataModel;
using System.Data;

namespace FFI_Service
{
  public  class FIScertificatedispatch_Service
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FIScertificatedispatch_Service)); //Declaring Log4Net. 

        public static FsharecertallApplication GetAllshare_pending(FsharecertallContext objICDStockContext, string Mysql)
        {

            FsharecertallApplication ICDStockRoot = new FsharecertallApplication();
            FISsharecertifcatedispatch_DataModel objDataModel = new FISsharecertifcatedispatch_DataModel();
            try
            {
                ICDStockRoot = objDataModel.GetAllshare_pending(objICDStockContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ICDStockRoot;
        }

        public static SavecertDisDocument newCertificateDispatch(SavecertDisApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            SavecertDisDocument objIUStockDocument = new SavecertDisDocument();
            try
            {
                FISsharecertifcatedispatch_DataModel objDataModel = new FISsharecertifcatedispatch_DataModel();
                objIUStockDocument = objDataModel.newCertificateDispatch(objmodel, MysqlCon);
                return objIUStockDocument;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
    }
}
