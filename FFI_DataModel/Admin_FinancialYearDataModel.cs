using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
    public class Admin_FinancialYearDataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        Admin_ErrorMessageModel ObjErrormsg = new Admin_ErrorMessageModel();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Admin_RoleManagementDataModel));
        LogHelper objHelper = new LogHelper();
        public FinYearList FinancialyearList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue, string Mysql)
        {
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            FinYearList ObjFetchAll = new FinYearList();
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MysqlCon = new DataConnection(Mysql);
                FnContext objContext = new FnContext();
                objContext.orgnId = org;
                objContext.localeId = lang;
                objContext.locnId = locn;
                objContext.userId = user;
                ObjFetchAll.context = objContext;
                MySqlCommand cmd = new MySqlCommand("Admin_fetch_finyear_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("FilterBy_Option", MySqlDbType.VarChar).Value = filterby_option;
                cmd.Parameters.Add("FilterBy_Code", MySqlDbType.VarChar).Value = filterby_code;
                cmd.Parameters.Add("FilterBy_Fromvalue", MySqlDbType.VarChar).Value = filterby_fromvalue;
                cmd.Parameters.Add("FilterBy_Tovalue", MySqlDbType.VarChar).Value = filterby_tovalue;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);

                MysqlCon.con.Close();

                List<FinList> objRoleLst = new List<FinList>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FinList objList = new FinList();
                    objList.finyear_rowid = Convert.ToInt32(dt.Rows[i]["finyear_rowid"]);
                    objList.finyear_code = dt.Rows[i]["finyear_code"].ToString();
                    objList.finyear_desc = dt.Rows[i]["finyear_desc"].ToString();
                    objList.finyear_start_date = dt.Rows[i]["finyear_start_date"].ToString();
                    objList.finyear_end_date = dt.Rows[i]["finyear_end_date"].ToString();
                    objList.finyear_narration = dt.Rows[i]["finyear_narration"].ToString();
                    objList.status_code = dt.Rows[i]["status_code"].ToString();
                    objList.status_desc = dt.Rows[i]["status_desc"].ToString();
                    objRoleLst.Add(objList);
                }
                ObjFetchAll.context.List = objRoleLst;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return ObjFetchAll;
        }

        public FetchFinancialYear FetchFinancialYear(string org, string locn, string user, string lang, int finyear_rowid, string ConString)
        {
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            FetchFinancialYear ObjFetch = new FetchFinancialYear();
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MysqlCon = new DataConnection(ConString);
                FetchFinancialYearContext objContext = new FetchFinancialYearContext();
                objContext.orgnId = org;
                objContext.localeId = lang;
                objContext.locnId = locn;
                objContext.userId = user;
                ObjFetch.context = objContext;
                MySqlCommand cmd = new MySqlCommand("Admin_fetch_finyear", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("In_finyear_rowid", MySqlDbType.Int32).Value = finyear_rowid;

                cmd.Parameters.Add(new MySqlParameter("Out_finyear_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_finyear_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_finyear_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_finyear_start_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_finyear_end_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_finyear_narration", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);

                MysqlCon.con.Close();


                FetchFinancialYearHeader objHeader = new FetchFinancialYearHeader();

                objHeader.finyear_rowid = (Int32)cmd.Parameters["Out_finyear_rowid1"].Value;
                objHeader.finyear_code = (string)cmd.Parameters["Out_finyear_code"].Value.ToString();
                objHeader.finyear_desc = (string)cmd.Parameters["Out_finyear_desc"].Value.ToString();
                objHeader.finyear_start_date = (string)cmd.Parameters["Out_finyear_start_date"].Value;
                objHeader.finyear_end_date = (string)cmd.Parameters["Out_finyear_end_date"].Value.ToString();
                objHeader.finyear_narration = (string)cmd.Parameters["Out_finyear_narration"].Value.ToString();
                objHeader.status_code = (string)cmd.Parameters["Out_status_code"].Value.ToString();
                objHeader.status_desc = (string)cmd.Parameters["Out_status_desc"].Value.ToString();
                objHeader.mode_flag = (string)cmd.Parameters["Out_mode_flag"].Value.ToString();
                objHeader.row_timestamp = (string)cmd.Parameters["Out_row_timestamp"].Value.ToString();
                ObjFetch.context.Header = objHeader;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return ObjFetch;
        }

        public SaveFYOut SaveFinYear(SaveFinYear objFin, string ConString)
        {
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            SaveFYOut objOut = new SaveFYOut();
            try
            {
                int ret = 0;
                int retdtls = 0;
                MysqlCon = new DataConnection(ConString);

                FYOutContext objContext = new FYOutContext();
                objContext.orgnId = objFin.document.context.orgnId;
                objContext.localeId = objFin.document.context.localeId;
                objContext.locnId = objFin.document.context.locnId;
                objContext.userId = objFin.document.context.userId;
                objOut.context = objContext;
                FYOutHeader objOutHeader = new FYOutHeader();

                FFI_Model.ApplicationException objex = new FFI_Model.ApplicationException();
                MySqlCommand cmd = new MySqlCommand("Admin_insupd_finyear", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("InOut_finyear_rowid", MySqlDbType.Int32).Value = objFin.document.context.Header.finyear_rowid;
                cmd.Parameters.Add("In_finyear_code", MySqlDbType.VarChar).Value = objFin.document.context.Header.finyear_code;
                cmd.Parameters.Add("In_finyear_desc", MySqlDbType.VarChar).Value = objFin.document.context.Header.finyear_desc;
                cmd.Parameters.Add("In_finyear_start_date", MySqlDbType.VarChar).Value = objFin.document.context.Header.finyear_start_date;
                cmd.Parameters.Add("In_finyear_end_date", MySqlDbType.VarChar).Value = objFin.document.context.Header.finyear_end_date;
                cmd.Parameters.Add("In_finyear_narration", MySqlDbType.VarChar).Value = objFin.document.context.Header.finyear_narration;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = objFin.document.context.Header.status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objFin.document.context.Header.mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = objFin.document.context.Header.row_timestamp;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objFin.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objFin.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objFin.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objFin.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("InOut_finyear_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                retdtls = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);

                MysqlCon.con.Close();

                objOutHeader.finyear_rowid = (Int32)cmd.Parameters["InOut_finyear_rowid1"].Value;

                if (cmd.Parameters["errorNo"].Value.ToString() != "")
                {
                    objex.errorNumber = cmd.Parameters["errorNo"].Value.ToString();
                    objex.errorDescription = ObjErrormsg.ErrorMessage(objex.errorNumber);
                }

                objOut.context.Header = objOutHeader;

                MySqlCommand vcmd = new MySqlCommand("Admin_validate_finyear", MysqlCon.con);
                vcmd.CommandType = CommandType.StoredProcedure;
                vcmd.Parameters.Add("In_finyear_code", MySqlDbType.VarChar).Value = objFin.document.context.Header.finyear_code;
                vcmd.Parameters.Add("In_finyear_desc", MySqlDbType.VarChar).Value = objFin.document.context.Header.finyear_desc;
                vcmd.Parameters.Add("In_finyear_start_date", MySqlDbType.VarChar).Value = objFin.document.context.Header.finyear_start_date;
                vcmd.Parameters.Add("In_finyear_end_date", MySqlDbType.VarChar).Value = objFin.document.context.Header.finyear_end_date;
                vcmd.Parameters.Add("In_finyear_narration", MySqlDbType.VarChar).Value = objFin.document.context.Header.finyear_narration;
                vcmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = objFin.document.context.Header.status_code;
                vcmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objFin.document.context.Header.mode_flag;
                vcmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = objFin.document.context.Header.row_timestamp;
                vcmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objFin.document.context.userId;
                vcmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objFin.document.context.orgnId;
                vcmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objFin.document.context.locnId;
                vcmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objFin.document.context.localeId;
                vcmd.Parameters.Add("InOut_finyear_rowid", MySqlDbType.Int32).Value = objFin.document.context.Header.finyear_rowid;
                vcmd.Parameters.Add(new MySqlParameter("InOut_finyear_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                retdtls = vcmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);

                MysqlCon.con.Close();
                objOut.ApplicationException = objex;
            }
            catch (Exception ex)
            {
                MysqlCon.con.Close();
                logger.Error("USERNAME :" + objFin.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return objOut; ;
        }
    }
}
