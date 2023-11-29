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
    public class FISGenerateShareCertificate_Service
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FISGenerateShareCertificate_Service)); //Declaring Log4Net. 
        public static GenerateShareApplication GetAllGenerateShareList(GenerateShareContext ObjContext, string Mysql)
        {
            GenerateShareApplication ObjFetchAll = new GenerateShareApplication();
            FISGenerateShareCertificate_DataModel objDataModel = new FISGenerateShareCertificate_DataModel();
            try
            {
                ObjFetchAll = objDataModel.GetAllGenerateShareList(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
        public static GenerateShareFetchApplication GetSingleGenerateShareList(GenerateShareFetchContext ObjContext, string Mysql)
        {
            GenerateShareFetchApplication ObjFetchAll = new GenerateShareFetchApplication();
            FISGenerateShareCertificate_DataModel objDataModel = new FISGenerateShareCertificate_DataModel();
            try
            {
                ObjFetchAll = objDataModel.GetSingleGenerateShareDtl(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
        public static GenerateShareDocument SaveGenerateShareList(GenerateShareSaveApplication ObjContext, string Mysql)
        {
            GenerateShareDocument ObjSaveDoc = new GenerateShareDocument();
            FISGenerateShareCertificate_DataModel objDataModel = new FISGenerateShareCertificate_DataModel();
            try
            {
                ObjSaveDoc = objDataModel.SaveGenerateShare(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjSaveDoc;
        }
    }
}
