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
    public class FISProcessShareApp_Service
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FISProcessShareApp_Service)); //Declaring Log4Net. 
        public static AllApplication GetAllProcessList(AllContext ObjContext, string Mysql)
        {
            AllApplication ObjProcessList = new AllApplication();
            FISProcessShareApp_DataModel objDataModel = new FISProcessShareApp_DataModel();
            try
            {
                ObjProcessList = objDataModel.GetAllProcessList(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjProcessList;
        }
        public static FetchApplication GetSingleProcessDtls(FetchContext ObjContext, string Mysql)
        {
            FetchApplication ObjProcessList = new FetchApplication();
            FISProcessShareApp_DataModel objDataModel = new FISProcessShareApp_DataModel();
            try
            {
                ObjProcessList = objDataModel.GetSingleProcessDtls_db(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjProcessList;
        }
        public static ProcessShareDocument SaveProcessDtls(ProcessShareApplication ObjContext, string Mysql)
        {
            ProcessShareDocument ObjProcessList = new ProcessShareDocument();
            FISProcessShareApp_DataModel objDataModel = new FISProcessShareApp_DataModel();
            try
            {
                ObjProcessList = objDataModel.SaveProcessShare(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjProcessList;
        }
    }
}
