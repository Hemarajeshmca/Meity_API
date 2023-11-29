using System;
using FFI_Model;
using FFI_DataModel;

namespace FFI_Service
{
    public class MasterDefinition_service
    {
        public static MasterRootObject MasterDefinition_List(MasterContext ObjContext, string Mysql)
        {
            MasterRootObject ObjFetchAll = new MasterRootObject();
            MasterDefinition_DB objDataModel = new MasterDefinition_DB();
            try
            {
                ObjFetchAll = objDataModel.MasterDefinition_List(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }

        public static Master_FRoot MasterDefinition_SingleFetch(Master_FContext objfarmer, string Mysql)
        {
            Master_FRoot ObjFarmerRoot = new Master_FRoot();
            MasterDefinition_DB objDataModel = new MasterDefinition_DB();

            try
            {
                ObjFarmerRoot = objDataModel.MasterDefinition_SingleFetch(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }

        public static Master_DocumentSave MasterDefinition_Save(Master_RootSave objmodel, string MysqlCon)
        {
            Master_DocumentSave objIUStockDocument = new Master_DocumentSave();
            try
            {
                MasterDefinition_DB objDataModel = new MasterDefinition_DB();
                objIUStockDocument = objDataModel.MasterDefinition_Save(objmodel, MysqlCon);
                return objIUStockDocument;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }

        public static MasterCodeScreenID GetMasterCodeScreenId_srv(string org, string locn, string user, string lang, string screen_code,string ConString)
        {
            MasterCodeScreenID objScreen = new MasterCodeScreenID();
            try
            {
                MasterDefinition_DB objDataModel = new MasterDefinition_DB();
                objScreen = objDataModel.GetMasterCodeScreenId_db(org, locn, user, lang, screen_code, ConString);
            }
            catch (Exception ex)
            {
                //logger.Error(ex);
            }
            return objScreen;
        }
    }
}
