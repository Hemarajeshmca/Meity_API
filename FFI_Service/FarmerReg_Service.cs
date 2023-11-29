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
    public class FarmerReg_Service
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FarmerReg_Service)); //Declaring Log4Net. 

        public static SFarmerDocument SaveFarmerReg(SFarmerRootObject objmodel, string MysqlCon)
        {
            string[] result = { };
            DataTable tab = new DataTable();
            SFarmerDocument objfarmer = new SFarmerDocument();
            try
            {
                FarmerReg_DataModel objDataModel = new FarmerReg_DataModel();
                objfarmer = objDataModel.SaveFarmerNew(objmodel, MysqlCon);

                return objfarmer;
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        public static FarmerRootObject GetAllFarmerDtls_Srv(FarmerContext objfarmer, string Mysql)
        {
            FarmerRootObject ObjFarmerRoot = new FarmerRootObject();
            FarmerReg_DataModel objDataModel = new FarmerReg_DataModel();
            try
            {
                ObjFarmerRoot = objDataModel.GetAllFarmerDtls(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }
        public static FRootObject GetSingleFarmerDtls_Srv(FContext objfarmer, string Mysql)
        {
            FRootObject ObjFarmerRoot = new FRootObject();
            FarmerReg_DataModel objDataModel = new FarmerReg_DataModel();

            try
            {
                ObjFarmerRoot = objDataModel.GetSingleFarmerDtls(objfarmer, Mysql);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }

    }
}
