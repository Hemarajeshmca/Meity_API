using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Service
{
    public class Admin_AttributeGroupMappingService
    {
        Admin_AttributeGroupMappingDataModel objDataModel = new Admin_AttributeGroupMappingDataModel();
        public AttributeGroupMappingList AttributeGroupMappingList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue,string ConString)
        {
            AttributeGroupMappingList ObjList = new AttributeGroupMappingList();
            try
            {
                ObjList = objDataModel.AttributeGroupMappingList(org, locn, user, lang, filterby_option, filterby_code, filterby_fromvalue, filterby_tovalue, ConString);
            }
            catch (Exception ex)
            {
                throw(ex);
            }
            return ObjList;
        }
        public FtchAttributeGroupMapping FetchAttributeGroupMapping(string org, string locn, string user, string lang, string activity_code,string ConString)
        {
            FtchAttributeGroupMapping ObjFetch = new FtchAttributeGroupMapping();
            try
            {
                ObjFetch = objDataModel.FetchAttributeGroupMapping(org, locn, user, lang, activity_code, ConString);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ObjFetch;
        }

        public OutputAGM SaveAttributeGroupMapping(SaveAttributeGroupMapping objAG,string ConString)
        {
            OutputAGM ObjFetch = new OutputAGM();
            try
            {
                ObjFetch = objDataModel.SaveAttributeGroupMapping(objAG, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetch;
        }
    }
}
