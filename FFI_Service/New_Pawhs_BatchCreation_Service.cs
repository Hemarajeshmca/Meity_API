using FFI_DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using static FFI_Model.New_Pawhs_BatchCreation_Model;

namespace FFI_Service
{
    public class New_Pawhs_BatchCreation_Service
    {
        public static PawhsBatchCreationApplication PawhsBatchCreation_List(PawhsBatchCreationContext ObjContext, string Mysql)
        {
            PawhsBatchCreationApplication ObjFetchAll = new PawhsBatchCreationApplication();
            New_Pawhs_BatchCreation_DataModel objDataModel = new New_Pawhs_BatchCreation_DataModel();
            try
            {
                ObjFetchAll = objDataModel.PawhsBatchCreation_List(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
        public static PawhsBatchCreationLotApplication PawhsBatchCreationLotNo_List(PawhsBatchCreationLotContext ObjContext, string Mysql)
        {
            PawhsBatchCreationLotApplication ObjFetchAll = new PawhsBatchCreationLotApplication();
            New_Pawhs_BatchCreation_DataModel objDataModel = new New_Pawhs_BatchCreation_DataModel();
            try
            {
                ObjFetchAll = objDataModel.PawhsBatchCreationLotNo_List(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
        public static PAWHSBatchCreation_Save_Document NewSaveBatchCreation(PAWHSBatchCreation_Save_Application objmodel, string MysqlCon)
        {
                 
            PAWHSBatchCreation_Save_Document objfarmer = new PAWHSBatchCreation_Save_Document();
            try
            {
                New_Pawhs_BatchCreation_DataModel objDataModel = new New_Pawhs_BatchCreation_DataModel();
                objfarmer = objDataModel.NewSaveBatchCreation(objmodel, MysqlCon);

                return objfarmer;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
        public static PAWHSBatchCreationFetchApplication Single_PawhsBatchCreationLotNo_List(PAWHSBatchCreation_FetchContext ObjContext, string Mysql)
        {
            PAWHSBatchCreationFetchApplication ObjFetchAll = new PAWHSBatchCreationFetchApplication();
            New_Pawhs_BatchCreation_DataModel objDataModel = new New_Pawhs_BatchCreation_DataModel();
            try
            {
                ObjFetchAll = objDataModel.Single_BatchCreation(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
    }
}
