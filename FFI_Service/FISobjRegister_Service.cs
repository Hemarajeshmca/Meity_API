using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using FFI_DataModel;
using FFI_Model;

namespace FFI_Service
{
   public class FISobjRegister_Service
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FISDividentRegister_Service)); //Declaring Log4Net. 
        public static fisobregisApplication allfisObjRegister(fisobregisContext objfisdivContext, string Mysql)
        {

            fisobregisApplication objinvoiceRoot = new fisobregisApplication();
            FISobjRegister_DataModel objDataModel = new FISobjRegister_DataModel();
            try
            {
                objinvoiceRoot = objDataModel.allfisObjRegister(objfisdivContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }

        public static SfisobregisDocument newObjectionRegister(SfisobregisApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();

            SfisobregisDocument IUOShareRefund = new SfisobregisDocument();
            try
            {
                FISobjRegister_DataModel objDataModel = new FISobjRegister_DataModel();
                IUOShareRefund = objDataModel.newObjectionRegister(objmodel, MysqlCon);
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
