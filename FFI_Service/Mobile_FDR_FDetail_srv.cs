using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Service
{
  public  class Mobile_FDR_FDetail_srv
    {
        public static fdrDocument SaveNewMobileFarmerCrop_Srv(fdrsaveRootObject objmodel, string MysqlCon)
        {
            fdrDocument IUOShareRefund = new fdrDocument();
            try
            {
                Mobile_FDR_FDetail_DB objDataModel = new Mobile_FDR_FDetail_DB();
                IUOShareRefund = objDataModel.SaveNewMobileFarmerCrop_DB(objmodel, MysqlCon);
                return IUOShareRefund;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
    }
}
