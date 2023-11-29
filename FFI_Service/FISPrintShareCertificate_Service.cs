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
    public class FISPrintShareCertificate_Service
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FISPrintShareCertificate_Service)); //Declaring Log4Net. 
        public static PrintShareApplication GetSinglePrintShareList(PrintShareContext ObjContext, string Mysql)
        {
            PrintShareApplication ObjFetchAll = new PrintShareApplication();
            FISPrintShareCertificate_DataModel objDataModel = new FISPrintShareCertificate_DataModel();
            try
            {
                ObjFetchAll = objDataModel.GetSinglePrintShareDtl(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
        public static Documentsave SavePrintShareDtls(Applicationsave ObjContext, string Mysql)
        {
            Documentsave ObjSaveDoc = new Documentsave();
            FISPrintShareCertificate_DataModel objDataModel = new FISPrintShareCertificate_DataModel();
            try
            {
                ObjSaveDoc = objDataModel.SavePrintShare(ObjContext, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjSaveDoc;
        }
    }
}
