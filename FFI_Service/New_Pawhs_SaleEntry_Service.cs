using FFI_DataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static FFI_Model.New_Pawhs_SaleEntryModel;

namespace FFI_Service
{
   public class New_Pawhs_SaleEntry_Service
    {
        public static PawhsBatSaleEntryApplication PawhsSaleEntry_List(PawhsSaleEntryContext ObjContext, string Mysql)
        {
            PawhsBatSaleEntryApplication ObjFetchAll = new PawhsBatSaleEntryApplication();
            New_Pawhs_SaleEntry_DataModel objDataModel = new New_Pawhs_SaleEntry_DataModel();
            try
            {
                ObjFetchAll = objDataModel.PawhsSaleEntry_List(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }

        public static PAWHSSaleEntryFetchApplication PawhsSaleEntry_SingleFetch(PAWHSSaleEntry_FetchContext objfarmer, string Mysql)
        {
            PAWHSSaleEntryFetchApplication ObjFarmerRoot = new PAWHSSaleEntryFetchApplication();
            New_Pawhs_SaleEntry_DataModel objDataModel = new New_Pawhs_SaleEntry_DataModel();

            try
            {
                ObjFarmerRoot = objDataModel.PawhsSaleEntry_SingleFetch(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }

        public static PAWHSSaleEntry_Save_Document newSaveSaleEntry(PAWHSSaleEntry_Save_Application objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            PAWHSSaleEntry_Save_Document objfarmer = new PAWHSSaleEntry_Save_Document();
            try
            {
                New_Pawhs_SaleEntry_DataModel objDataModel = new New_Pawhs_SaleEntry_DataModel();
                objfarmer = objDataModel.save_new_saleentry_DB(objmodel, MysqlCon);

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
