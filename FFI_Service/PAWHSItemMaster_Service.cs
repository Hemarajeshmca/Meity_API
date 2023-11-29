using System;
using System.Collections.Generic;
using System.Text;
using FFI_Model;
using FFI_DataModel;
using System.Data;
using System.Security;

namespace FFI_Service
{
    public class PAWHSItemMaster_Service
    {
        public static ItemMasterApplication GetAllItemMasterList(ItemMasterContext ObjContext, string Mysql)
        {
            ItemMasterApplication ObjFetchAll = new ItemMasterApplication();
            PAWHSItemMaster_DataModel objDataModel = new PAWHSItemMaster_DataModel();
            try
            {
                ObjFetchAll = objDataModel.GetAllItemMasterList(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
        public static SingleItemMasterApplication GetSingleItemMaster(SingleItemMasterContext ObjContext, string Mysql)
        {
            SingleItemMasterApplication ObjFetchAll = new SingleItemMasterApplication();
            PAWHSItemMaster_DataModel objDataModel = new PAWHSItemMaster_DataModel();
            try
            {
                ObjFetchAll = objDataModel.GetSingleItemMasterDtl(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
        public static SaveItemMasterDocument SaveItemMasterDtls(SaveItemMasterApplication ObjContext, string Mysql)
        {
            SaveItemMasterDocument ObjFetchAll = new SaveItemMasterDocument();
            PAWHSItemMaster_DataModel objDataModel = new PAWHSItemMaster_DataModel();
            try
            {
                ObjFetchAll = objDataModel.SaveItemMaster(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
    }
}
