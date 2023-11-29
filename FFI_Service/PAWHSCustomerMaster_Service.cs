using System;
using System.Collections.Generic;
using System.Text;
using FFI_Model;
using FFI_DataModel;
using System.Data;
using System.Security;
using log4net;

namespace FFI_Service
{
    public class PAWHSCustomerMaster_Service
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSCustomerMaster_Service)); //Declaring Log4Net. 
        public static PAWHSCustomerApplication GetAllCustomerList(Context ObjContext, string Mysql)
        {
            PAWHSCustomerApplication ObjFetchAll = new PAWHSCustomerApplication();
            PAWHSCustomerMaster_DataModel objDataModel = new PAWHSCustomerMaster_DataModel();
            try
            {
                ObjFetchAll = objDataModel.GetAllCustomerMasterList(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
        public static SingleApplication GetSingleCustomerMasterList(SingleContext ObjContext, string Mysql)
        {
            SingleApplication ObjFetchAll = new SingleApplication();
            PAWHSCustomerMaster_DataModel objDataModel = new PAWHSCustomerMaster_DataModel();
            try
            {
                ObjFetchAll = objDataModel.GetSingleCustomerMasterDtl(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
        public static DocumentCustomer SaveCustomerMasterList(SaveApplication ObjContext, string Mysql)
        {
            DocumentCustomer ObjSaveDoc = new DocumentCustomer();
            PAWHSCustomerMaster_DataModel objDataModel = new PAWHSCustomerMaster_DataModel();
            try
            {
                ObjSaveDoc = objDataModel.SaveCustomerMaster(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjSaveDoc;
        }
    }
}
