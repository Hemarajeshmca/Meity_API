using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Service
{
   public class ICDMOBProduct_service
    {
        public static ICDMOBPRoot ICDProduct_List(string org, string locn, string user, string lang, string Mysql)
        {
            ICDMOBPRoot ObjFetchAll = new ICDMOBPRoot();
            ICDMOBProduct_datamodel objDataModel = new ICDMOBProduct_datamodel();
            try
            {
                ObjFetchAll = objDataModel.ICDProduct_List(org, locn, user, lang, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
        public static MOBPAYRoot paymentcollection_List_srv(string org, string locn, string user, string lang, int invoice_rowid ,string Mysql)
        {
            MOBPAYRoot ObjFetchAll = new MOBPAYRoot();
            ICDMOBProduct_datamodel objDataModel = new ICDMOBProduct_datamodel();
            try
            {
                ObjFetchAll = objDataModel.paymentcollectionlist_DB(org, locn, user, lang, invoice_rowid, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
    }
}
