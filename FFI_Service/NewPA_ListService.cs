using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;
using static FFI_Model.NewPA_ListModel;

namespace FFI_Service
{
   public class NewPA_ListService
    {
        public static MOBPA_PAYRoot PA_paymentcollection_List_srv(string org, string locn, string user, string lang, int invoice_rowid, string Mysql)
        {
            MOBPA_PAYRoot ObjFetchAll = new MOBPA_PAYRoot();
            NewPA_ListDataModel objDataModel = new NewPA_ListDataModel();
            try
            {
                ObjFetchAll = objDataModel.PA_paymentcollectionlist_DB(org, locn, user, lang, invoice_rowid, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }

        public static PA_SaleApplication GetAllPASaleList_Srv(PA_SaleContext objinvoice, string Mysql)
        {
            PA_SaleApplication objinvoiceRoot = new PA_SaleApplication();
            NewPA_ListDataModel objDataModel = new NewPA_ListDataModel();
            try
            {
                objinvoiceRoot = objDataModel.GetAllPASaleList_DB(objinvoice, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }
        public static PASalePayApplication GetAllPASalePayList_Srv(PASalePayContext objinvoice, string Mysql)
        {
            PASalePayApplication objinvoiceRoot = new PASalePayApplication();
            NewPA_ListDataModel objDataModel = new NewPA_ListDataModel();
            try
            {
                objinvoiceRoot = objDataModel.GetAllPASalePayList_DB(objinvoice, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }
    }
}
