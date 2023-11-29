using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Service
{
   public class FDR_Constent_service
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInvoice_Service)); //Declaring Log4Net. 
        public static tempalteList FarmerConstenttemplatefetch_Srv(tempalteContext objinvoice, string Mysql)
        {
            tempalteList objinvoiceRoot = new tempalteList();
            FDR_Constent_Datamodel objDataModel = new FDR_Constent_Datamodel();
            try
            {
                objinvoiceRoot = objDataModel.FarmerConstenttemplatefetch_DB(objinvoice, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }
        public static fdrconstentfetch FarmerConstentfetch_Srv(fdrconstentfetchContext objinvoice, string Mysql)
        {
            fdrconstentfetch objinvoiceRoot = new fdrconstentfetch();
            FDR_Constent_Datamodel objDataModel = new FDR_Constent_Datamodel();
            try
            {
                objinvoiceRoot = objDataModel.FarmerConstentfetch_DB(objinvoice, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }

        public static fdrconstentDocument FarmerConstentsave_Srv(fdrconstentroot objinvoice, string Mysql)
        {
            fdrconstentDocument objinvoiceRoot = new fdrconstentDocument();
            FDR_Constent_Datamodel objDataModel = new FDR_Constent_Datamodel();
            try
            {
                objinvoiceRoot = objDataModel.FarmerConstentsave_DB(objinvoice, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }

        public static gpsDocument gpssave_Srv(gpsroot objinvoice, string Mysql)
        {
            gpsDocument objinvoiceRoot = new gpsDocument();
            FDR_Constent_Datamodel objDataModel = new FDR_Constent_Datamodel();
            try
            {
                objinvoiceRoot = objDataModel.gpssave_DB(objinvoice, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }
    }
}
