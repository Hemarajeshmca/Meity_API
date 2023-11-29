using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
    public class PAWHSPaydtlupdate_service
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSPaydtlupdate_service)); //Declaring Log4Net. 

        public static PAWHSPaydtlupdateApplication all_pawhs_payment_update(PAWHSPaydtlupdateContext objfarmer, string Mysql)
        {
            PAWHSPaydtlupdateApplication ObjFarmerRoot = new PAWHSPaydtlupdateApplication();
            PAWHSPaydtlupdate_Datamodel objDataModel = new PAWHSPaydtlupdate_Datamodel();
            try
            {
                ObjFarmerRoot = objDataModel.all_pawhs_payment_update(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }

        public static PAWHSPaydtlupdateSDocument new_pawhs_payment_update(PAWHSPaydtlupdateSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            PAWHSPaydtlupdateSDocument objfarmer = new PAWHSPaydtlupdateSDocument();
            try
            {
                PAWHSPaydtlupdate_Datamodel objDataModel = new PAWHSPaydtlupdate_Datamodel();
                objfarmer = objDataModel.new_pawhs_payment_update(objmodel, MysqlCon);

                return objfarmer;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }

    }
}
