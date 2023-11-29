using System;
using FFI_Model;
using FFI_DataModel;

namespace FFI_Service
{
    public class ChecklistDefinition_service
    {
        public static Chklist_FetchApplication ChecklistDefinition_List(Chklist_FetchContext ObjContext, string Mysql)
        {
            Chklist_FetchApplication ObjFetchAll = new Chklist_FetchApplication();
            ChecklistDefinition_DB objDataModel = new ChecklistDefinition_DB();
            try
            {
                ObjFetchAll = objDataModel.ChecklistDefinition_List(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }

        public static Chklist_SDocument ChecklistDefinition_save(Chklist_SApplication objmodel, string MysqlCon)
        {
            Chklist_SDocument objIUStockDocument = new Chklist_SDocument();
            try
            {
                ChecklistDefinition_DB objDataModel = new ChecklistDefinition_DB();
                objIUStockDocument = objDataModel.ChecklistDefinition_save(objmodel, MysqlCon);
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
