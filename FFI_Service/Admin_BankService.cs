using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Service
{
   public class Admin_BankService
    {
        Admin_BankDataModel objDataModel = new Admin_BankDataModel();

        public BankList BankList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue,string ConString)
        {
            BankList ObjList = new BankList();
            try
            {
                ObjList = objDataModel.BankList(org, locn, user, lang, filterby_option, filterby_code, filterby_fromvalue, filterby_tovalue, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjList;
        }
        public FetchBank FetchBank(string org, string locn, string user, string lang, int finyear_rowid, string ConString)
        {
            FetchBank ObjFetch = new FetchBank();
            try
            {
                ObjFetch = objDataModel.FetchBank(org, locn, user, lang, finyear_rowid, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetch;
        }

        public OutputBank SaveBank(SaveBank objBank, string ConString)
        {
            OutputBank ObjFetch = new OutputBank();
            try
            {
                ObjFetch = objDataModel.SaveBank(objBank, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetch;
        }
    }
}
