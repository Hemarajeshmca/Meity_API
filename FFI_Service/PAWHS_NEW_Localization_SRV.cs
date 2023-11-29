using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Service
{
    public class PAWHS_NEW_Localization_SRV
    {
        public static MFMApplication GetAllFarmermaster_Srv(MFMContext objfarmer, string Mysql)
        {
            MFMApplication ObjFarmerRoot = new MFMApplication();
            PAWHS_NEW_Localization_DB objDataModel = new PAWHS_NEW_Localization_DB();
            try
            {
                ObjFarmerRoot = objDataModel.GetallFarmermaster_DB(objfarmer, Mysql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
    }
}
