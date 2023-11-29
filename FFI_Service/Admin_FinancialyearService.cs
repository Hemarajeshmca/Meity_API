using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Service
{
    public class Admin_FinancialyearService
    {

        Admin_FinancialYearDataModel objDataModel = new Admin_FinancialYearDataModel();
        public FinYearList FinancialyearList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue, string Mysql)
        {
            FinYearList ObjFetchAll = new FinYearList();
            try
            {
                ObjFetchAll = objDataModel.FinancialyearList(org, locn, user, lang, filterby_option, filterby_code, filterby_fromvalue, filterby_tovalue, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
        public FetchFinancialYear FetchFinancialYear(string org, string locn, string user, string lang, int finyear_rowid,string ConString)
        {
            FetchFinancialYear ObjFetch = new FetchFinancialYear();
            try
            {
                ObjFetch = objDataModel.FetchFinancialYear(org, locn, user, lang, finyear_rowid, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetch;
        }

        public SaveFYOut SaveFinYear(SaveFinYear objFin, string ConString)
        {
            SaveFYOut ObjFetch = new SaveFYOut();
            try
            {
                ObjFetch = objDataModel.SaveFinYear(objFin, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetch;
        }

    }
}
