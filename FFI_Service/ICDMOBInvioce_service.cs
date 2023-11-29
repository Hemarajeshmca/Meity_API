using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static FFI_Model.ICDMOBInvoice_model;

namespace FFI_Service
{
  public class ICDMOBInvioce_service
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDMOBInvioce_service)); //Declaring Log4Net.
        public static ICDMOBIDocument Saveinvoice(ICDMOBIRoot objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            ICDMOBIDocument objinvoice = new ICDMOBIDocument();
            try
            {
                ICDMOBInvioce_datamodel objDataModel = new ICDMOBInvioce_datamodel();
                objinvoice = objDataModel.SaveinvoiceNew(objmodel, MysqlCon);

                return objinvoice;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
        public static ICDMOBIPDocument mobnewsavePaymentCollection_srv(ICDMOBIPRoot objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            ICDMOBIPDocument objinvoice = new ICDMOBIPDocument();
            try
            {
                ICDMOBInvioce_datamodel objDataModel = new ICDMOBInvioce_datamodel();
                objinvoice = objDataModel.mobnewsavePaymentCollection_Db(objmodel, MysqlCon);

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
