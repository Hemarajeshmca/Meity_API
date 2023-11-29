using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using static FFI_Model.ICDSupplier_Model;

namespace FFI_DataModel
{
    public class ICDSupplier_DataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDStockInward_DataModel)); //Declaring Log4Net. 
        string methodName = MethodBase.GetCurrentMethod().Name;
        public SaveSupplierDocument SaveICDSupplier(SaveSupplierApplication ObjICDSupplier, string mysqlcon)
        {
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            SaveSupplierDocument ObjresICDSupplier = new SaveSupplierDocument();
            ObjresICDSupplier.context = new SaveSupplierContext();
            ObjresICDSupplier.ApplicationException = new FFI_Model.ApplicationException();
            ObjresICDSupplier.context.Header = new SaveSupplierHeader();
            ApplicationException objerr = new ApplicationException();
            try
            {
                int ret = 0;


                // objresICDStock.context.Detail = new IUDetail();
                int In_supplier_rowid1 = 0;
                string In_supplier_code1 = "";
                string errorNo = "";
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }
                MySqlCommand cmd = new MySqlCommand("insupd_supplier_reg", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_supplier_rowid", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_supplier_rowid;// ObjFarmer.document.context.Header.in_farmer_rowid;
                cmd.Parameters.Add("In_supplier_code", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_supplier_code;
                cmd.Parameters.Add("In_version_no", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_version_no;
                cmd.Parameters.Add("In_supplier_name", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_supplier_name;
                cmd.Parameters.Add("In_pan_no", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_pan_no;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.localeId;
                //cmd.Parameters.Add("In_supplier_rowid1", MySqlDbType.Int32).Value = ObjICDSupplier.document.context.Header.In_supplier_rowid1;
                //cmd.Parameters.Add("In_supplier_code1", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_supplier_code1;
                cmd.Parameters.Add(new MySqlParameter("In_supplier_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_supplier_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_version_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                LogHelper.ConvertCmdIntoString(cmd);
                ret = cmd.ExecuteNonQuery();
                errorNo = (string)cmd.Parameters["errorNo"].Value;

                ObjresICDSupplier.ApplicationException.errorNumber = errorNo.ToString();
                ObjresICDSupplier.ApplicationException.errorDescription = ObjErrormsg.ErrorMessage(errorNo);
                if (ret > 0)
                {
                    In_supplier_rowid1 = (Int32)cmd.Parameters["In_supplier_rowid1"].Value;
                    In_supplier_code1 = (string)cmd.Parameters["In_supplier_code1"].Value;                   
                    ObjresICDSupplier.context.Header.In_supplier_rowid = Convert.ToInt32(In_supplier_rowid1);
                    ObjresICDSupplier.context.Header.In_supplier_code = In_supplier_code1;
                    ObjresICDSupplier.context.orgnId = ObjICDSupplier.document.context.orgnId;
                    ObjresICDSupplier.context.locnId = ObjICDSupplier.document.context.locnId;
                    ObjresICDSupplier.context.userId = ObjICDSupplier.document.context.userId;
                    ObjresICDSupplier.context.localeId = ObjICDSupplier.document.context.localeId;

                    if (ObjresICDSupplier.context.Header.In_supplier_rowid > 0)
                    {
                        if (ObjICDSupplier.document.context.SupplierAddress != null)
                        {
                            ret = SaveICDSupplierAddress(ObjICDSupplier, ObjresICDSupplier, mysqlcon, MysqlCon);
                        }
                        if (ObjICDSupplier.document.context.SupplierTax != null)
                        {
                            ret = SaveICDSupplierTax(ObjICDSupplier, ObjresICDSupplier, mysqlcon, MysqlCon);
                        }

                        mysqltrans.Commit();
                    }

                }
                else
                {
                    mysqltrans.Rollback();
                    return ObjresICDSupplier;
                }



            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                // throw ex;
                logger.Error("USERNAME :" + ObjICDSupplier.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return ObjresICDSupplier;
        }
        public int SaveICDSupplierAddress(SaveSupplierApplication ObjmodelA, SaveSupplierDocument objIUStock, string MysqlCons, DataConnection MysqlCon)
        {
            int saving = 0;
            int count = 1;
            DataTable tab = new DataTable();
            SaveSupplierAddress objadddtl = new SaveSupplierAddress();
            SaveSupplierTax objtaxdtl = new SaveSupplierTax();
            try
            {
                ICDSupplier_DataModel objproduct1 = new ICDSupplier_DataModel();
                foreach (var Kyc in ObjmodelA.document.context.SupplierAddress)
                {
                    objadddtl.In_supplier_code = Kyc.In_supplier_code;
                    objadddtl.In_version_no = Kyc.In_version_no;
                    objadddtl.In_supplier_addr_rowid = Kyc.In_supplier_addr_rowid;
                    objadddtl.In_supplieraddr_type = Kyc.In_supplieraddr_type;
                    objadddtl.In_supplier_addr1 = Kyc.In_supplier_addr1;
                    objadddtl.In_supplier_addr2 = Kyc.In_supplier_addr2;
                    objadddtl.In_supplier_country = Kyc.In_supplier_country;
                    objadddtl.In_supplier_state = Kyc.In_supplier_state;
                    objadddtl.In_supplier_dist = Kyc.In_supplier_dist;
                    objadddtl.In_supplier_taluk = Kyc.In_supplier_taluk;
                    objadddtl.In_supplier_panchayat = Kyc.In_supplier_panchayat;
                    objadddtl.In_supplier_village = Kyc.In_supplier_village;
                    objadddtl.In_supplier_pincode = Kyc.In_supplier_pincode;
                    objadddtl.In_status_code = Kyc.In_status_code;
                    objadddtl.In_mode_flag = Kyc.In_mode_flag;
                    objadddtl.errorNo = Kyc.errorNo;
                    saving = objproduct1.SaveICDSupplierAddressSP(objadddtl, objIUStock, ObjmodelA, MysqlCons, MysqlCon);
                    count = count + 1;
                    if (saving == 0)
                    {
                        break;
                    }
                }
                return saving;
            }
            //        result = objproduct1.SaveICDSupplierAddressSP(objadddtl, objIUStock, Objmodel, MysqlCons, MysqlCon);


            //    }
            //    return result;
            //}
            catch (Exception ex)
            {
                return saving;
                logger.Error("USERNAME :" + ObjmodelA.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
        }
        public int SaveICDSupplierAddressSP(SaveSupplierAddress objadddtl, SaveSupplierDocument objIUStock, SaveSupplierApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {

            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("iud_supplier_addr", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_supplier_code", MySqlDbType.VarChar).Value = objadddtl.In_supplier_code;
                cmd.Parameters.Add("In_version_no", MySqlDbType.VarChar).Value = objadddtl.In_version_no;
                cmd.Parameters.Add("In_supplieraddr_rowid", MySqlDbType.Int32).Value = objadddtl.In_supplier_addr_rowid;
                cmd.Parameters.Add("In_supplieraddr_type", MySqlDbType.VarChar).Value = objadddtl.In_supplieraddr_type;
                cmd.Parameters.Add("In_supplier_addr1", MySqlDbType.VarChar).Value = objadddtl.In_supplier_addr1;
                cmd.Parameters.Add("In_supplier_addr2", MySqlDbType.VarChar).Value = objadddtl.In_supplier_addr2;
                cmd.Parameters.Add("In_supplier_country", MySqlDbType.VarChar).Value = objadddtl.In_supplier_country;
                cmd.Parameters.Add("In_supplier_state", MySqlDbType.VarChar).Value = objadddtl.In_supplier_state;
                cmd.Parameters.Add("In_supplier_dist", MySqlDbType.VarChar).Value = objadddtl.In_supplier_dist;
                cmd.Parameters.Add("In_supplier_taluk", MySqlDbType.VarChar).Value = objadddtl.In_supplier_taluk;
                cmd.Parameters.Add("In_supplier_panchayat", MySqlDbType.VarChar).Value = objadddtl.In_supplier_panchayat;
                cmd.Parameters.Add("In_supplier_village", MySqlDbType.VarChar).Value = objadddtl.In_supplier_village;
                cmd.Parameters.Add("In_supplier_pincode", MySqlDbType.VarChar).Value = objadddtl.In_supplier_pincode;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = objadddtl.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objadddtl.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                cmd.Parameters.Add("In_supplier_rowid1", MySqlDbType.Int32).Value = Objmodel.document.context.Header.In_supplier_rowid1;
                cmd.Parameters.Add("In_supplier_code1", MySqlDbType.VarChar).Value = Objmodel.document.context.Header.In_supplier_code1;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                LogHelper.ConvertCmdIntoString(cmd);
                ret = cmd.ExecuteNonQuery();

                return ret;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return ret;
            }
        }
        public int SaveICDSupplierTax(SaveSupplierApplication ObjmodelT, SaveSupplierDocument objIUSuppT, string MysqlCons, DataConnection MysqlCon)
        {
            int saving = 0;
            int count = 1;
            DataTable tab = new DataTable();
            // SaveSupplierAddress objadddtl = new SaveSupplierAddress();
            SaveSupplierTax objtaxdtl = new SaveSupplierTax();
            try
            {
                ICDSupplier_DataModel objproduct1 = new ICDSupplier_DataModel();
                foreach (var Kyc in ObjmodelT.document.context.SupplierTax)
                {
                    objtaxdtl.In_supplier_code = Kyc.In_supplier_code;
                    objtaxdtl.In_version_no = Kyc.In_version_no;
                    objtaxdtl.In_tax_rowid = Kyc.In_tax_rowid;
                    objtaxdtl.In_tax_type = Kyc.In_tax_type;
                    objtaxdtl.In_tax_reg_no = Kyc.In_tax_reg_no;
                    objtaxdtl.In_state_code = Kyc.In_state_code;
                    objtaxdtl.In_status_code = Kyc.In_status_code;
                    objtaxdtl.In_mode_flag = Kyc.In_mode_flag;

                    saving = objproduct1.SaveICDSupplierTaxSP(objtaxdtl, objIUSuppT, ObjmodelT, MysqlCons, MysqlCon);
                    count = count + 1;
                    if (saving == 0)
                    {
                        break;
                    }
                }
                return saving;
            }

            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjmodelT.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return saving;
            }
        }
        public int SaveICDSupplierTaxSP(SaveSupplierTax objtaxdtl, SaveSupplierDocument objIUSuppT, SaveSupplierApplication ObjmodelT, string mysqlcons, DataConnection MysqlCon)
        {

            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("iud_supplier_tax", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_supplier_code", MySqlDbType.VarChar).Value = objtaxdtl.In_supplier_code;
                cmd.Parameters.Add("In_version_no", MySqlDbType.Int32).Value = objtaxdtl.In_version_no;
                cmd.Parameters.Add("In_tax_rowid", MySqlDbType.Int32).Value = objtaxdtl.In_tax_rowid;
                cmd.Parameters.Add("In_tax_type", MySqlDbType.VarChar).Value = objtaxdtl.In_tax_type;
                cmd.Parameters.Add("In_tax_reg_no", MySqlDbType.VarChar).Value = objtaxdtl.In_tax_reg_no;
                cmd.Parameters.Add("In_state_code", MySqlDbType.VarChar).Value = objtaxdtl.In_state_code;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = objtaxdtl.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objtaxdtl.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjmodelT.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjmodelT.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjmodelT.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjmodelT.document.context.localeId;
                cmd.Parameters.Add("In_supplier_rowid1", MySqlDbType.Int32).Value = ObjmodelT.document.context.Header.In_supplier_rowid1;
                cmd.Parameters.Add("In_supplier_code1", MySqlDbType.VarChar).Value = ObjmodelT.document.context.Header.In_supplier_code1;
                LogHelper.ConvertCmdIntoString(cmd);
                ret = cmd.ExecuteNonQuery();

                return ret;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjmodelT.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return ret;

            }
        }
        public ICDSupplierApplication ICDSupplier_List(ICDSupplierContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            ICDSupplierApplication ObjFetchAll = new ICDSupplierApplication();
            ObjFetchAll.context = new ICDSupplierContext();
            ObjFetchAll.context.List = new List<ICDSupplierList>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("fetch_supplier_reg_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("In_filterby_option", MySqlDbType.VarChar).Value = ObjContext.FilterBy_Option;
                cmd.Parameters.Add("In_filterby_code", MySqlDbType.VarChar).Value = ObjContext.FilterBy_Code;
                cmd.Parameters.Add("In_filterby_fromvalue", MySqlDbType.VarChar).Value = ObjContext.FilterBy_FromValue;
                cmd.Parameters.Add("In_filterby_tovalue", MySqlDbType.VarChar).Value = ObjContext.FilterBy_ToValue;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ICDSupplierList objList = new ICDSupplierList();
                    objList.Out_supplier_rowid = Convert.ToInt32(dt.Rows[i]["Out_supplier_rowid"]);
                    objList.Out_supplier_code = dt.Rows[i]["Out_supplier_code"].ToString();
                    objList.Out_version_no = dt.Rows[i]["Out_version_no"].ToString();
                    objList.Out_supplier_name = dt.Rows[i]["Out_supplier_name"].ToString();
                    objList.Out_pan_no = dt.Rows[i]["Out_pan_no"].ToString();
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.Out_status_desc = dt.Rows[i]["Out_status_desc"].ToString();
                    objList.Out_row_timestamp = dt.Rows[i]["Out_row_timestamp"].ToString();
                    objList.Out_ic_name = dt.Rows[i]["Out_ic_name"].ToString();                  
        ObjFetchAll.context.List.Add(objList);
                }
                ObjFetchAll.context.orgnId = ObjContext.orgnId;
                ObjFetchAll.context.locnId = ObjContext.locnId;
                ObjFetchAll.context.userId = ObjContext.userId;
                ObjFetchAll.context.localeId = ObjContext.localeId;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }

            return ObjFetchAll;
        }
        public ICDSupplierFetchApplication ICDSupplier_SingleFetch(ICDSupplierFetchContext objfpoSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();

            ICDSupplierFetchApplication objfpoSearchRoot = new ICDSupplierFetchApplication();

            DataTable Map = new DataTable();
            DataTable OtherDt = new DataTable();
            DataTable SlnoDt = new DataTable();

            objfpoSearchRoot.context = new ICDSupplierFetchContext();
            objfpoSearchRoot.context.Header = new ICDSupplierFetchHeader();
            objfpoSearchRoot.context.SupplierAddress = new List<ICDSupplierFetchAddress>();
            objfpoSearchRoot.context.SupplierTax = new List<ICDSupplierFetchTax>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("fetch_supplier_reg", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;
                cmd.Parameters.Add("In_supplier_rowid", MySqlDbType.Int32).Value = objfpoSearch.supplier_rowid;
                cmd.Parameters.Add("In_supplier_code", MySqlDbType.VarChar).Value = objfpoSearch.supplier_code;
                cmd.Parameters.Add("In_version_no", MySqlDbType.VarChar).Value = objfpoSearch.version_no;
                cmd.Parameters.Add(new MySqlParameter("In_supplier_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_supplier_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_version_no1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_supplier_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_pan_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_ic_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_ic_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();
                if (ds.Tables.Count > 0)
                {
                    //Map = ds.Tables[0];
                    //for (int i = 0; i < Map.Rows.Count; i++)
                    //{
                    //    ICDSupplierFetchDetail objDetailList = new ICDSupplierFetchDetail(); 
                    //    objDetailList.In_supplier_name = Map.Rows[i]["In_supplier_name"].ToString();
                    //    objDetailList.In_pan_no = Map.Rows[i]["In_pan_no"].ToString();
                    //    objDetailList.In_status_code = Map.Rows[i]["In_status_code"].ToString();
                    //    objDetailList.In_status_desc = Map.Rows[i]["In_status_desc"].ToString(); 
                    //    objDetailList.In_row_timestamp = Map.Rows[i]["In_row_timestamp"].ToString();
                    //    objDetailList.In_mode_flag = Map.Rows[i]["In_mode_flag"].ToString();
                    //    objfpoSearchRoot.context.Detail.Add(objDetailList);
                    //}
                    OtherDt = ds.Tables[0];
                    for (int i = 0; i < OtherDt.Rows.Count; i++)
                    {
                        ICDSupplierFetchAddress ObjOtherList = new ICDSupplierFetchAddress();
                        ObjOtherList.In_supplier_addr_rowid = (Int32)OtherDt.Rows[i]["In_supplier_addr_rowid"];
                        ObjOtherList.In_supplier_addr_type = OtherDt.Rows[i]["In_supplier_addr_type"].ToString();
                        ObjOtherList.In_supplier_addr_type_desc = OtherDt.Rows[i]["In_supplier_addr_type_desc"].ToString();
                        ObjOtherList.In_supplier_addr1 = OtherDt.Rows[i]["In_supplier_addr1"].ToString();
                        ObjOtherList.In_supplier_addr2 = OtherDt.Rows[i]["In_supplier_addr2"].ToString();
                        ObjOtherList.In_supplier_country = OtherDt.Rows[i]["In_supplier_country"].ToString();
                        ObjOtherList.In_supplier_country_desc = OtherDt.Rows[i]["In_supplier_country_desc"].ToString();
                        ObjOtherList.In_supplier_state = OtherDt.Rows[i]["In_supplier_state"].ToString();
                        ObjOtherList.In_supplier_state_desc = OtherDt.Rows[i]["In_supplier_state_desc"].ToString();
                        ObjOtherList.In_supplier_dist = OtherDt.Rows[i]["In_supplier_dist"].ToString();
                        ObjOtherList.In_supplier_dist_desc = OtherDt.Rows[i]["In_supplier_dist_desc"].ToString();
                        ObjOtherList.In_supplier_taluk = OtherDt.Rows[i]["In_supplier_taluk"].ToString();
                        ObjOtherList.In_supplier_taluk_desc = OtherDt.Rows[i]["In_supplier_taluk_desc"].ToString();
                        ObjOtherList.In_supplier_panchayat = OtherDt.Rows[i]["In_supplier_panchayat"].ToString();
                        ObjOtherList.In_supplier_panchayat_desc = OtherDt.Rows[i]["In_supplier_panchayat_desc"].ToString();
                        ObjOtherList.In_supplier_village = OtherDt.Rows[i]["In_supplier_village"].ToString();
                        ObjOtherList.In_supplier_village_desc = OtherDt.Rows[i]["In_supplier_village_desc"].ToString();
                        ObjOtherList.In_supplier_pincode = OtherDt.Rows[i]["In_supplier_pincode"].ToString();
                        ObjOtherList.In_supplier_pincode_desc = OtherDt.Rows[i]["In_supplier_pincode_desc"].ToString();
                        ObjOtherList.In_status_code = OtherDt.Rows[i]["In_status_code"].ToString();
                        ObjOtherList.In_status_desc = OtherDt.Rows[i]["In_status_desc"].ToString();
                        ObjOtherList.In_mode_flag = OtherDt.Rows[i]["In_mode_flag"].ToString();
                        objfpoSearchRoot.context.SupplierAddress.Add(ObjOtherList);
                    }
                    SlnoDt = ds.Tables[1];
                    for (int i = 0; i < SlnoDt.Rows.Count; i++)
                    {
                        ICDSupplierFetchTax ObjSlnoList = new ICDSupplierFetchTax();
                        ObjSlnoList.In_tax_rowid = Convert.ToInt32(SlnoDt.Rows[i]["In_tax_rowid"]);
                        ObjSlnoList.In_tax_type = SlnoDt.Rows[i]["In_tax_type"].ToString();
                        ObjSlnoList.In_tax_reg_no = SlnoDt.Rows[i]["In_tax_reg_no"].ToString();
                        ObjSlnoList.In_state_code = SlnoDt.Rows[i]["In_state_code"].ToString();
                        ObjSlnoList.In_state_desc = SlnoDt.Rows[i]["In_state_desc"].ToString();
                        ObjSlnoList.In_status_code = SlnoDt.Rows[i]["In_status_code"].ToString();
                        ObjSlnoList.In_status_desc = SlnoDt.Rows[i]["In_status_desc"].ToString();
                        ObjSlnoList.In_mode_flag = SlnoDt.Rows[i]["In_mode_flag"].ToString();
                        objfpoSearchRoot.context.SupplierTax.Add(ObjSlnoList);
                    }
                    objfpoSearchRoot.context.orgnId = objfpoSearch.orgnId;
                    objfpoSearchRoot.context.locnId = objfpoSearch.locnId;
                    objfpoSearchRoot.context.userId = objfpoSearch.userId;
                    objfpoSearchRoot.context.localeId = objfpoSearch.localeId;
                    objfpoSearchRoot.context.supplier_rowid = objfpoSearch.supplier_rowid;
                    objfpoSearchRoot.context.supplier_code = objfpoSearch.supplier_code;
                    objfpoSearchRoot.context.version_no = objfpoSearch.version_no;

                    objfpoSearchRoot.context.Header.In_supplier_rowid = (Int32)cmd.Parameters["In_supplier_rowid1"].Value;
                    objfpoSearchRoot.context.Header.In_supplier_code = (string)cmd.Parameters["In_supplier_code1"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_version_no = (Int32)cmd.Parameters["In_version_no1"].Value;
                    objfpoSearchRoot.context.Header.In_supplier_name = (string)cmd.Parameters["In_supplier_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_ic_code = (string)cmd.Parameters["In_ic_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_ic_name = (string)cmd.Parameters["In_ic_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_pan_no = (string)cmd.Parameters["In_pan_no"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();


                }
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objfpoSearch.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }
            return objfpoSearchRoot;
        }

    }

}
