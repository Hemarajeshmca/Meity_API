using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Service
{
   public class ICDMOBList_service
    {
        public static ADJCOUNTRoot ICDProduct_List(string org, string locn, string user, string lang,string customer_code, string product_code, string adjustment_type, string adjustment_date, string Mysql)
        {
            ADJCOUNTRoot ObjFetchAll = new ADJCOUNTRoot();
            ICDMOBList_datamodel objDataModel = new ICDMOBList_datamodel();
            try
            {
                ObjFetchAll = objDataModel.ICDProduct_List(org, locn, user, lang, customer_code, product_code, adjustment_type, adjustment_date, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
        public static ICDMOBSRoot ICD_Supplier_list_SRV(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue, string ConString)
        {
            ICDMOBSRoot ObjList = new ICDMOBSRoot();
            ICDMOBList_datamodel objDataModel = new ICDMOBList_datamodel();
            try
            {
                ObjList = objDataModel.ICD_Supplier_list_DB(org, locn, user, lang, filterby_option, filterby_code, filterby_fromvalue, filterby_tovalue, ConString);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ObjList;
        }
        public static ICDMOBCRoot Customerslist_SRV(string org, string locn, string user, string lang, string ConString)
        {
            ICDMOBCRoot ObjList = new ICDMOBCRoot();
            ICDMOBList_datamodel objDataModel = new ICDMOBList_datamodel();
            try
            {
                ObjList = objDataModel.Customerslist_DB(org, locn, user, lang, ConString);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ObjList;
        }
        public static MasterRootObject allmasterlist_SRV(string org, string locn, string user, string lang,string parent_code, string ConString)
        {
            MasterRootObject ObjList = new MasterRootObject();
            ICDMOBList_datamodel objDataModel = new ICDMOBList_datamodel();
            try
            {
                ObjList = objDataModel.allmasterlist_DB(org, locn, user, lang,parent_code, ConString);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ObjList;
        }
        public static ICDMOBTRoot geticdtransactionlist_SRV(string org, string locn, string user, string lang, string ConString)
        {
            ICDMOBTRoot ObjList = new ICDMOBTRoot();
            ICDMOBList_datamodel objDataModel = new ICDMOBList_datamodel();
            try
            {
                ObjList = objDataModel.geticdtransactionlist_DB(org, locn, user, lang, ConString);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ObjList;
        }
    }
}
