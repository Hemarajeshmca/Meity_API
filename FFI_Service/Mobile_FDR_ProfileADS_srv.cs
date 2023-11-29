using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FFI_Service
{
    public class Mobile_FDR_ProfileADS_srv
    {
        public static FDRRootObjectads FarmerProfileSaveADS_Srv(FDRRootObjectads objfarmer, string Mysql)
        {
            FDRRootObjectads ObjFarmerRoot = new FDRRootObjectads();
            Mobile_FDR_ProfileADS_DB objDataModel = new Mobile_FDR_ProfileADS_DB();
            MFPAdderssDetails obj = new MFPAdderssDetails();
            ObjFarmerRoot.context = new FDRContextads();
            ObjFarmerRoot.context.Header = new FDRHeaderads();
            if (objfarmer.context.farmer_code == "")
            {
                ObjFarmerRoot.context.orgnId = objfarmer.context.orgnId;
                ObjFarmerRoot.context.locnId = objfarmer.context.locnId;
                ObjFarmerRoot.context.userId = objfarmer.context.userId;
                ObjFarmerRoot.context.localeId = objfarmer.context.localeId;
                ObjFarmerRoot.context.farmer_code = objfarmer.context.farmer_code;
                ObjFarmerRoot.context.adsvalue = "Farmer Code cannot be empty";
            }
            else {
                try
                {
                    var stringProps = objfarmer.context.Header.GetType().GetProperties().Where(p => p.PropertyType == typeof(string));
                    foreach (var prop in stringProps)
                    {
                        string entity_group = prop.Name;
                        string entity_value = (string)prop.GetValue(objfarmer.context.Header);
                        obj.in_farmerdetail_rowid = 0;
                        obj.in_entitygrp_code = "EC_ADS";
                        obj.in_entity_code = entity_group;
                        obj.in_entity_value = entity_value;
                        obj.in_row_slno = "1";
                        obj.in_mode_flag = "I";
                        objDataModel.FarmerAddressDetailsSave(obj, objfarmer.context.orgnId, objfarmer.context.locnId, objfarmer.context.userId, objfarmer.context.localeId, objfarmer.context.farmer_code, Mysql);
                    }
                
                ObjFarmerRoot.context.orgnId = objfarmer.context.orgnId;
                ObjFarmerRoot.context.locnId = objfarmer.context.locnId;
                ObjFarmerRoot.context.userId = objfarmer.context.userId;
                ObjFarmerRoot.context.localeId = objfarmer.context.localeId;
                ObjFarmerRoot.context.farmer_code = objfarmer.context.farmer_code;
                ObjFarmerRoot.context.adsvalue = "sucess";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
            return ObjFarmerRoot;
        }
    }
}
