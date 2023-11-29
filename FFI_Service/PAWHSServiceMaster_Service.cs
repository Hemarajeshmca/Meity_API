using System;
using System.Collections.Generic;
using System.Text;
using FFI_Model;
using FFI_DataModel;
using System.Data;
using System.Security;

namespace FFI_Service
{
  public  class PAWHSServiceMaster_Service
    {
        public static ServiceMasterApplication GetAllServiceMasterList(SrviceMasterContext ObjContext, string Mysql)
        {
            ServiceMasterApplication ObjFetchAll = new ServiceMasterApplication();
            PAWHSServiceMaster_DataModel objDataModel = new PAWHSServiceMaster_DataModel();
            try
            {
                ObjFetchAll = objDataModel.GetAllServiceMasterList(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
        public static FetchServiceMasterApplication GetServiceMasterSingle(FetchServiceMasterContext ObjContext, string Mysql)
        {
            FetchServiceMasterApplication ObjFetchAll = new FetchServiceMasterApplication();
            PAWHSServiceMaster_DataModel objDataModel = new PAWHSServiceMaster_DataModel();
            try
            {
                ObjFetchAll = objDataModel.GetSingleServiceMasterDtl(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
        public static SaveServiceMasterDocument SaveServiceMasterDtls(SaveServiceMasterApplication ObjContext, string Mysql)
        {
            SaveServiceMasterDocument ObjFetchAll = new SaveServiceMasterDocument();
            PAWHSServiceMaster_DataModel objDataModel = new PAWHSServiceMaster_DataModel();
            try
            {
                ObjFetchAll = objDataModel.SaveCustomerMaster(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
    }
}
