using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_Service
{
    public class FISCertifiDes_srv
    {
        public static FISCertifiDesApplication Getservice_req_Dispatch_Srv(FISCertifiDesContext objfarmer, string Mysql)
        {
            FISCertifiDesApplication ObjFarmerRoot = new FISCertifiDesApplication();
            FISCertifiDes_DB objDataModel = new FISCertifiDes_DB();

            try
            {
                ObjFarmerRoot = objDataModel.Getservice_req_Dispatch_DB(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }

        public static FISCertifiDesSDocument SavenewCertificateDispatch_Srv(FISCertifiDesSApplication objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            FISCertifiDesSDocument objfarmer = new FISCertifiDesSDocument();
            try
            {
                FISCertifiDes_DB objDataModel = new FISCertifiDes_DB();
                objfarmer = objDataModel.SavenewCertificateDispatch_DB(objmodel, MysqlCon);

                return objfarmer;
            }
            catch (Exception ex)
            {
                // logger.Error(ex.ToString());
                throw ex;
            }
        }
    }
}
