using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Service
{
    public class Admin_AttributeGroupService
    {
        Admin_AttributeGroupDataModel objDataModel = new Admin_AttributeGroupDataModel();
        public AttributeGroupList AttributeGroupList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue,string ConString)
        {
            AttributeGroupList ObjList = new AttributeGroupList();
            try
            {
                ObjList = objDataModel.AttributeGroupList(org, locn, user, lang, filterby_option, filterby_code, filterby_fromvalue, filterby_tovalue, ConString);
            }
            catch (Exception ex)
            {
                throw(ex);
            }
            return ObjList;
        }
        public FetchAttributeGroup FetchAttributeGroup(string org, string locn, string user, string lang, int entitygrp_rowid, string entitygrp_code, string ConString)
        {
            FetchAttributeGroup ObjFetch = new FetchAttributeGroup();
            try
            {
                ObjFetch = objDataModel.FetchAttributeGroup(org, locn, user, lang, entitygrp_rowid, entitygrp_code, ConString);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ObjFetch;
        }
        public OutputAG SaveAttributeGroup(SaveAG objAG, string ConString)
        {
            OutputAG ObjFetch = new OutputAG();
            try
            {
                ObjFetch = objDataModel.SaveAttributeGroup(objAG, ConString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetch;
        }
    }
}
