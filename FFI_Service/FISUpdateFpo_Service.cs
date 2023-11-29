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
   public class FISUpdateFpo_Service
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Captial_Service)); //Declaring Log4Net.

        public static UpdateFetchApplication GetUpdatetList(UpdateFetchContext ObjContext, string Mysql)
        {
            UpdateFetchApplication ObjFetchUpdate = new UpdateFetchApplication();
            FISUpdateFpo_DataModel objDataModel = new FISUpdateFpo_DataModel();
            try
            {
                ObjFetchUpdate = objDataModel.GetUpdateFpoList(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchUpdate;
        }
        public static UpdateSaveDocument SaveUpdateFpo(UpdateSaveApplication ObjContext, string Mysql)
        {
            UpdateSaveDocument ObjUpdateSave = new UpdateSaveDocument();
            FISUpdateFpo_DataModel objDataModel = new FISUpdateFpo_DataModel();
            try
            {
                ObjUpdateSave = objDataModel.SaveUpdateFpo(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjUpdateSave;
        }
    }
}
