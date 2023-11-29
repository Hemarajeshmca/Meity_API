using System;
using System.Collections.Generic;
using System.Text;
using FFI_Model;
using FFI_DataModel;
using System.Data;
using System.Security;


namespace FFI_Service
{
   public class PAWHSWarehouseMaster_Service
    {
        public static WarehouseMstApplication GetAllWarehouseList(WarehouseMstContext ObjContext, string Mysql)
        {
            WarehouseMstApplication ObjFetchAll = new WarehouseMstApplication();
            PAWHSWarehouseMaster_DataModel objDataModel = new PAWHSWarehouseMaster_DataModel();
            try
            {
                ObjFetchAll = objDataModel.GetAllWarehouseList(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
        public static WarehouseMstSingleApplication GetSingleWarehouseList(WarehouseMstSingleContext ObjContext, string Mysql)
        {
            WarehouseMstSingleApplication ObjFetchAll = new WarehouseMstSingleApplication();
            PAWHSWarehouseMaster_DataModel objDataModel = new PAWHSWarehouseMaster_DataModel();
            try
            {
                ObjFetchAll = objDataModel.GetSingleWarehouseMasterDtl(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
        public static WarehouseMstDocument SaveWarehouseMaster(WarehouseMstSaveApplication ObjContext, string Mysql)
        {
            WarehouseMstDocument ObjFetchAll = new WarehouseMstDocument();
            PAWHSWarehouseMaster_DataModel objDataModel = new PAWHSWarehouseMaster_DataModel();
            try
            {
                ObjFetchAll = objDataModel.SaveWareHouseMaster(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
    }
}
