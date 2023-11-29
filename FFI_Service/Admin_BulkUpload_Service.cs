using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;
using static FFI_Model.Admin_BulkUpload_Model;

namespace FFI_Service
{
   public class Admin_BulkUpload_Service
    {
        Admin_BulkUpload_Datamodel objDataModel = new Admin_BulkUpload_Datamodel();
        public BulkExceltempApplication exceltempfetch(string org, string locn, string user, string lang,  string excel_upload_code, string ConString)
        {
            BulkExceltempApplication ObjFetch = new BulkExceltempApplication();
            try
            {
                ObjFetch = objDataModel.exceltempfetch(org, locn, user, lang, excel_upload_code, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetch;
        }
        public savevectorApplicationouput SaveBulkvector(vectorApplication objRole, string ConString)
        {
            savevectorApplicationouput ObjFetch = new savevectorApplicationouput();
            try
            {
                ObjFetch = objDataModel.SaveBulkvector(objRole, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetch;
        }
        public ScalerApplicationRes SaveBulkScalar(ScalerApplication objRole, string ConString)
        {
            ScalerApplicationRes ObjFetch = new ScalerApplicationRes();
            try
            {
                ObjFetch = objDataModel.SaveBulkScalar(objRole, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetch;
        }
        public SaveHistoryContextRes SaveexcelHistory(SaveHistoryApplication objRole, string ConString)
        {
            SaveHistoryContextRes ObjFetch = new SaveHistoryContextRes();
            try
            {
                ObjFetch = objDataModel.SaveexcelHistory(objRole, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetch;
        }

        public ScalerApplicationRes SaveBulkDuplicateCheck(duplicatefarmerdata objRole, string ConString)
        {
            ScalerApplicationRes ObjFetch = new ScalerApplicationRes();
            try
            {
                ObjFetch = objDataModel.SaveBulkDuplicateCheck(objRole, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetch;
        }
    }
}
