using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Service
{
   public class Admin_AggregatorRegistrationService
    {
        Admin_AggregatorRegistrationDataModel objDataModel = new Admin_AggregatorRegistrationDataModel();
        public PAWHSAggregatorRegistrationList AggregatorRegistrationList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue, string ConString)
        {
            PAWHSAggregatorRegistrationList ObjList = new PAWHSAggregatorRegistrationList();
            try
            {
                ObjList = objDataModel.AggregatorRegistrationList(org, locn, user, lang, filterby_option, filterby_code, filterby_fromvalue, filterby_tovalue, ConString);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ObjList;
        }

        public FectAggregatorRegistration FectAggregatorRegistration(string org, string locn, string user, string lang, int orgn_rowid, string aggregator_code, string ConString)
        {
            FectAggregatorRegistration ObjList = new FectAggregatorRegistration();
            try
            {
                ObjList = objDataModel.FectAggregatorRegistration(org, locn, user, lang, orgn_rowid, aggregator_code, ConString);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ObjList;
        }

        public MApplication AggrMemberFetch(string userId, string orgnId, string locnId, string localeId, int orgn_rowid, string orgn_code, string aggregator_code, string fpo_code, string ConString)
        {
            MApplication ObjFetch = new MApplication();
            try
            {
               ObjFetch = objDataModel.AggrMemberFetch(orgnId, locnId, userId, localeId, orgn_rowid, orgn_code, aggregator_code, fpo_code, ConString);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ObjFetch;
        }

        public SaveAGGDocument SavePAWHSAggregatorRegistration(SaveAggregatorRegistration objAggReg, string ConString)
        {
            string[] response = { };
            SaveAGGDocument Objresult = new SaveAGGDocument();
            try
            {
                Objresult = objDataModel.SavePAWHSAggregatorRegistration(objAggReg, ConString);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return Objresult;

        }
        public static AggregatorFetch_application GetAggrMobileList(AggrFetchContext ObjContext, string Mysql)
        {
            AggregatorFetch_application ObjFetchAll = new AggregatorFetch_application();
            Admin_AggregatorRegistrationDataModel objDataModel = new Admin_AggregatorRegistrationDataModel();
            try
            {
                ObjFetchAll = objDataModel.FetchMobileList(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
    }
}
