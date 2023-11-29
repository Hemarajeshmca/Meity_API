using System;
using System.Collections.Generic;
using System.Text;
using FFI_Model;
using FFI_DataModel;
using System.Data;
using System.Security;
using log4net;

namespace FFI_Service
{
   public class FISAllotmentReg_Service
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FISAllotmentReg_Service)); //Declaring Log4Net. 
        public static AllotemntApplication GetAllotmentList(AllotemntContext ObjContext, string Mysql)
        {
            AllotemntApplication ObjAllotmentAll = new AllotemntApplication();
            FISAllotmentReg_DataModel objDataModel = new FISAllotmentReg_DataModel();
            try
            {
                ObjAllotmentAll = objDataModel.GetAllAllotmentList(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjAllotmentAll;
        }
        public static AllotemntFetchApplication GetSingleAllotmentList(AllotmentContext ObjContext, string Mysql)
        {
            AllotemntFetchApplication ObjAllotmentList = new AllotemntFetchApplication();
            FISAllotmentReg_DataModel objDataModel = new FISAllotmentReg_DataModel();
            try
            {
                ObjAllotmentList = objDataModel.GetSingleAllotmentDtls(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjAllotmentList;
        }
        public static SaveAllotmentDocument SaveAllotmentReg(SaveAllotmentApplication ObjContext, string Mysql)
        {
            SaveAllotmentDocument ObjAllotmentDoc = new SaveAllotmentDocument();
            FISAllotmentReg_DataModel objDataModel = new FISAllotmentReg_DataModel();
            try
            {
                ObjAllotmentDoc = objDataModel.SaveAllotmentReg(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjAllotmentDoc;
        }
    }
}
