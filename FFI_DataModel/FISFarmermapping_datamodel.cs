using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace FFI_DataModel
{
    public class FISFarmermapping_datamodel
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInvoice_DataModel)); //Declaring Log4Net. 
        string methodName = "";

        public fpofarmerApplication GetallFPOFarmer_map_DB(fpofarmerContext objinvoice, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataTable dt = new DataTable();

            fpofarmerApplication objinvoiceRoot = new fpofarmerApplication();
            FISFarmermapping_datamodel objDataModel = new FISFarmermapping_datamodel();

            objinvoiceRoot.context = new fpofarmerContext();
            objinvoiceRoot.context.List = new List<fpofarmerList>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("FIS_fetch_fpo_farmer_map_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_filterby_option", MySqlDbType.VarChar).Value = objinvoice.Filter.FilterBy_Option;
                cmd.Parameters.Add("In_filterby_code", MySqlDbType.VarChar).Value = objinvoice.Filter.FilterBy_Code;
                cmd.Parameters.Add("In_filterby_fromvalue", MySqlDbType.VarChar).Value = objinvoice.Filter.FilterBy_FromValue;
                cmd.Parameters.Add("In_filterby_tovalue", MySqlDbType.VarChar).Value = objinvoice.Filter.FilterBy_ToValue;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    fpofarmerList objList = new fpofarmerList();
                    objList.In_sel_flag = dt.Rows[i]["In_sel_flag"].ToString();
                    objList.In_farmer_code = dt.Rows[i]["In_farmer_code"].ToString();
                    objList.In_farmer_name = dt.Rows[i]["In_farmer_name"].ToString();
                    objList.In_sur_name = dt.Rows[i]["In_sur_name"].ToString();
                    objList.In_farmer_dob = dt.Rows[i]["In_farmer_dob"].ToString();
                    objList.In_gender_flag = dt.Rows[i]["In_gender_flag"].ToString();
                    objList.In_gender_flag_desc = dt.Rows[i]["In_gender_flag_desc"].ToString();
                    objList.In_reg_mobile_no = dt.Rows[i]["In_reg_mobile_no"].ToString();
                    objList.In_status_code = dt.Rows[i]["In_status_code"].ToString();
                    objList.In_status_desc = dt.Rows[i]["In_status_desc"].ToString();
                   objList.In_village = dt.Rows[i]["In_village"].ToString();
                    objinvoiceRoot.context.List.Add(objList);

                }
                objinvoiceRoot.context.orgnId = objinvoice.orgnId;
                objinvoiceRoot.context.locnId = objinvoice.locnId;
                objinvoiceRoot.context.localeId = objinvoice.localeId;
                objinvoiceRoot.context.userId = objinvoice.userId;

            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objinvoice.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }
            return objinvoiceRoot;
        }
        public fpofarmerFApplication GetFPOFarmer_mapfetch_DB(fpofarmerFContext objfpoSearch, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataSet ds = new DataSet();

            fpofarmerFApplication objfpoSearchRoot = new fpofarmerFApplication();
            FISFarmermapping_datamodel objDataModel = new FISFarmermapping_datamodel();

            DataTable Map = new DataTable();


            objfpoSearchRoot.context = new fpofarmerFContext();
            objfpoSearchRoot.context.Header = new fpofarmerHeader();
            objfpoSearchRoot.context.Map = new List<Map>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("FIS_fetch_fpo_farmerMap", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_fpoorgn_code", MySqlDbType.VarChar).Value = objfpoSearch.Filter.fpoorgn_code;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;
                cmd.Parameters.Add(new MySqlParameter("In_fpoorgn_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();
                if (ds.Tables.Count > 0)
                {
                    Map = ds.Tables[0];

                    for (int i = 0; i < Map.Rows.Count; i++)
                    {
                        Map objDetailList = new Map();
                        objDetailList.In_fpomember_rowid = Convert.ToInt32(Map.Rows[i]["In_fpomember_rowid"]);
                        objDetailList.In_fpomember_code = Map.Rows[i]["In_fpomember_code"].ToString();
                        objDetailList.In_farmer_code = Map.Rows[i]["In_farmer_code"].ToString();
                        objDetailList.In_member_name = Map.Rows[i]["In_member_name"].ToString();
                        objDetailList.In_member_sur_name = Map.Rows[i]["In_member_sur_name"].ToString();
                        objDetailList.In_member_dob = Map.Rows[i]["In_member_dob"].ToString();
                        objDetailList.In_member_gender_flag = Map.Rows[i]["In_member_gender_flag"].ToString();
                        objDetailList.In_member_gender_flag_desc = Map.Rows[i]["In_member_gender_flag_desc"].ToString();
                        objDetailList.In_member_reg_mob_no = Map.Rows[i]["In_member_reg_mob_no"].ToString();
                        objDetailList.In_status_code = Map.Rows[i]["In_status_code"].ToString();
                        objDetailList.In_status_desc = Map.Rows[i]["In_status_desc"].ToString();
                        objDetailList.In_row_timestamp = Map.Rows[i]["In_row_timestamp"].ToString();
                        objDetailList.In_mode_flag = Map.Rows[i]["In_mode_flag"].ToString();
                        objDetailList.In_village = Map.Rows[i]["In_village"].ToString();
                        objfpoSearchRoot.context.Map.Add(objDetailList);
                    }
                    objfpoSearchRoot.context.orgnId = objfpoSearch.orgnId;
                    objfpoSearchRoot.context.locnId = objfpoSearch.locnId;
                    objfpoSearchRoot.context.userId = objfpoSearch.userId;
                    objfpoSearchRoot.context.localeId = objfpoSearch.localeId;

                    objfpoSearchRoot.context.Header.In_fpoorgn_desc = (string)cmd.Parameters["In_fpoorgn_desc"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objfpoSearch.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }
            return objfpoSearchRoot;
        }
        public fpofarmerSDocument SaveFPOFarmerMap_DB(fpofarmerSApplication ObjContext, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            int ret = 0;
            string errorNo = "";
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            fpofarmerSDocument objresFarmer = new fpofarmerSDocument();
            objresFarmer.context = new fpofarmerSContext();
            objresFarmer.context.Header = new fpofarmerSHeader();
            objresFarmer.context.Map = new List<fpofarmerSMap>();
            objresFarmer.ApplicationException = new fpofarmerSApplicationException();

            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }
                for (int i = 0; i < ObjContext.document.context.Map.Count; i++)
                {
                    MySqlCommand cmd = new MySqlCommand("FIS_iud_fpo_farmer_map", MysqlCon.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("In_fpomember_rowid", MySqlDbType.VarChar).Value = ObjContext.document.context.Map[i].In_fpomember_rowid;
                    cmd.Parameters.Add("In_fpomember_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Map[i].In_fpomember_code;
                    cmd.Parameters.Add("In_farmer_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Map[i].In_farmer_code;
                    cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Map[i].In_status_code;
                    cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjContext.document.context.Map[i].In_row_timestamp;
                    cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Map[i].In_mode_flag;
                    cmd.Parameters.Add("In_fpoorgn_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_fpoorgn_code;
                    cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                    cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                    cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                    cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                    cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                    ret = cmd.ExecuteNonQuery();                    
                        errorNo = (string)cmd.Parameters["errorNo"].Value;                   
                }
                
                mysqltrans.Commit();
                if (MysqlCon.con.State == ConnectionState.Open)
                {
                    MysqlCon.con.Close();
                }
                objresFarmer.context.orgnId = ObjContext.document.context.orgnId;
                objresFarmer.context.userId = ObjContext.document.context.userId;
                objresFarmer.context.locnId = ObjContext.document.context.locnId;
                objresFarmer.context.localeId = ObjContext.document.context.localeId;
                objresFarmer.context.Header.In_fpoorgn_code = ObjContext.document.context.Header.In_fpoorgn_code;               
                objresFarmer.ApplicationException.errorNumber = errorNo;
                objresFarmer.ApplicationException.errorDescription = errorNo;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                // throw ex;
                MysqlCon.con.Close();
                logger.Error("USERNAME :" + ObjContext.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }

            return objresFarmer;
        }

    }
}
