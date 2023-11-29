using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
    public class Admin_ReportconfigDataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        Admin_ErrorMessage ObjErrormsg = new Admin_ErrorMessage();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Admin_ReportconfigDataModel));
        // Exception Log Method Name Purpose written start 
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public ReportconfigList ReportconfigList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue, string ConString)
        {
            ReportconfigList ObjFetchAll = new ReportconfigList();
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MysqlCon = new DataConnection(ConString);
                RCContext objContext = new RCContext();
                objContext.orgnId = org;
                objContext.localeId = lang;
                objContext.locnId = locn;
                objContext.userId = user;
                ObjFetchAll.context = objContext;
                MySqlCommand cmd = new MySqlCommand("Admin_fetch_reports_config_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("in_FilterBy_Option", MySqlDbType.VarChar).Value = filterby_option;
                cmd.Parameters.Add("in_FilterBy_Code", MySqlDbType.VarChar).Value = filterby_code;
                cmd.Parameters.Add("in_FilterBy_FromValue", MySqlDbType.VarChar).Value = filterby_fromvalue;
                cmd.Parameters.Add("in_FilterBy_ToValue", MySqlDbType.VarChar).Value = filterby_tovalue;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                List<RCList> objRoleLst = new List<RCList>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    RCList objList = new RCList();
                    objList.Out_report_rowid = Convert.ToInt32(dt.Rows[i]["Out_report_rowid"].ToString());
                    objList.Out_module_code = dt.Rows[i]["Out_module_code"].ToString();
                    objList.Out_module_name = dt.Rows[i]["Out_module_name"].ToString();
                    objList.Out_report_code = dt.Rows[i]["Out_report_code"].ToString();
                    objList.Out_report_name = dt.Rows[i]["Out_report_name"].ToString();
                    objList.Out_report_type = dt.Rows[i]["Out_report_type"].ToString();
                    objList.Out_report_type_desc = dt.Rows[i]["Out_report_type_desc"].ToString();
                    objList.out_report_source = dt.Rows[i]["out_report_source"].ToString();
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.Out_status_desc = dt.Rows[i]["Out_status_desc"].ToString();
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

        public FetchRC FetchReportConfig(string org, string locn, string user, string lang, int report_rowid, string ConString)
        {
            FetchRC ObjFetch = new FetchRC();
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MysqlCon = new DataConnection(ConString);
                FetchRCContext objContext = new FetchRCContext();
                objContext.orgnId = org;
                objContext.localeId = lang;
                objContext.locnId = locn;
                objContext.userId = user;
                ObjFetch.context = objContext;
                MySqlCommand cmd = new MySqlCommand("Admin_fetch_reports_config", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("IOU_report_rowid", MySqlDbType.Int32).Value = report_rowid;
                cmd.Parameters.Add(new MySqlParameter("IOU_report_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_module_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_report_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_report_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_report_type", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_report_type_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_report_source", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();
                FetchRCHeader objHeader = new FetchRCHeader();
                objHeader.IOU_report_rowid = (int)cmd.Parameters["IOU_report_rowid1"].Value;
                objHeader.In_module_code = (string)cmd.Parameters["In_module_code"].Value.ToString();
                objHeader.In_report_code = (string)cmd.Parameters["In_report_code"].Value.ToString();
                objHeader.In_report_name = (string)cmd.Parameters["In_report_name"].Value.ToString();
                objHeader.In_report_type = (string)cmd.Parameters["In_report_type"].Value.ToString();
                objHeader.In_report_type_desc = (string)cmd.Parameters["In_report_type_desc"].Value.ToString();
                objHeader.In_report_source = (string)cmd.Parameters["In_report_source"].Value.ToString();
                objHeader.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                objHeader.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                objHeader.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                objHeader.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();
                ObjFetch.context.Header = objHeader;

                List<FetchRCParamDetail> ObjRoleList = new List<FetchRCParamDetail>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FetchRCParamDetail objList = new FetchRCParamDetail();
                    objList.In_reportparam_rowid = Convert.ToInt32(dt.Rows[i]["In_reportparam_rowid"]);
                    objList.In_param_slno = Convert.ToInt32(dt.Rows[i]["In_param_slno"]);
                    objList.In_param_name = dt.Rows[i]["In_param_name"].ToString();
                    objList.In_param_desc = dt.Rows[i]["In_param_desc"].ToString();
                    objList.In_param_type = dt.Rows[i]["In_param_type"].ToString();
                    objList.In_param_type_desc = dt.Rows[i]["In_param_type_desc"].ToString();
                    objList.In_param_value = dt.Rows[i]["In_param_value"].ToString();
                    objList.In_param_value_desc = dt.Rows[i]["In_param_value_desc"].ToString();
                    objList.In_mandatory_flag = dt.Rows[i]["In_mandatory_flag"].ToString();
                    objList.In_status_code = dt.Rows[i]["In_status_code"].ToString();
                    objList.in_status_desc = dt.Rows[i]["in_status_desc"].ToString();
                    objList.In_mode_flag = dt.Rows[i]["In_mode_flag"].ToString();
                    ObjRoleList.Add(objList);
                }
                ObjFetch.context.Param_detail = ObjRoleList;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }

        public OutReportConfig SaveReport(SaveReportConfig objRC, string ConString)
        {
            OutReportConfig ObjFetch = new OutReportConfig();
            try
            {

                int ret = 0;
                int retdtls = 0;
                MysqlCon = new DataConnection(ConString);

                OutRCContext objContext = new OutRCContext();
                objContext.orgnId = objRC.document.context.orgnId;
                objContext.localeId = objRC.document.context.localeId;
                objContext.locnId = objRC.document.context.locnId;
                objContext.userId = objRC.document.context.userId;
                ObjFetch.context = objContext;
                OutRCHeader objOutHeader = new OutRCHeader();

                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }


                FFI_Model.ApplicationException objex = new FFI_Model.ApplicationException();
                MySqlCommand cmd = new MySqlCommand("Admin_insupd_reports_config", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("IOU_report_rowid", MySqlDbType.Int32).Value = objRC.document.context.Header.IOU_report_rowid;
                cmd.Parameters.Add("In_module_code", MySqlDbType.VarChar).Value = objRC.document.context.Header.In_module_code;
                cmd.Parameters.Add("In_report_code", MySqlDbType.VarChar).Value = objRC.document.context.Header.In_report_code;
                cmd.Parameters.Add("In_report_name", MySqlDbType.VarChar).Value = objRC.document.context.Header.In_report_name;
                cmd.Parameters.Add("In_report_type", MySqlDbType.VarChar).Value = objRC.document.context.Header.In_report_type;
                cmd.Parameters.Add("In_report_source", MySqlDbType.VarChar).Value = objRC.document.context.Header.In_report_source;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = objRC.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = objRC.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objRC.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objRC.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objRC.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objRC.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objRC.document.context.localeId;

                retdtls = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                if (retdtls > 0)
                {
                    objOutHeader.IOU_report_rowid = 0;
                }
                objContext.Header = objOutHeader;

                bool isvaild = true;

                foreach (var Details in objRC.document.context.Param_detail)
                {
                    MySqlCommand cmds = new MySqlCommand("Admin_iud_reports_config", MysqlCon.con);
                    cmds.CommandType = CommandType.StoredProcedure;
                    cmds.Parameters.Add("In_report_code", MySqlDbType.VarChar).Value = objRC.document.context.Header.In_report_code;
                    cmds.Parameters.Add("In_reportparam_rowid", MySqlDbType.Int32).Value = Details.In_reportparam_rowid;
                    cmds.Parameters.Add("In_param_slno", MySqlDbType.Int32).Value = Details.In_param_slno;
                    cmds.Parameters.Add("In_param_name", MySqlDbType.VarChar).Value = Details.In_param_name;
                    cmds.Parameters.Add("In_param_desc", MySqlDbType.VarChar).Value = Details.In_param_desc;
                    cmds.Parameters.Add("In_param_type", MySqlDbType.VarChar).Value = Details.In_param_type;
                    cmds.Parameters.Add("In_param_value", MySqlDbType.VarChar).Value = Details.In_param_value;
                    cmds.Parameters.Add("In_mandatory_flag", MySqlDbType.VarChar).Value = Details.In_mandatory_flag;
                    cmds.Parameters.Add("Instatus_code", MySqlDbType.VarChar).Value = Details.Instatus_code;
                    cmds.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Details.In_mode_flag;
                    cmds.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objRC.document.context.orgnId;
                    cmds.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objRC.document.context.locnId;
                    cmds.Parameters.Add("userId", MySqlDbType.VarChar).Value = objRC.document.context.userId;
                    cmds.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objRC.document.context.localeId;
                    ret = cmds.ExecuteNonQuery();
                    LogHelper.ConvertCmdIntoString(cmd);
                    if (ret == 0)
                    {
                        mysqltrans.Rollback();
                        objex.errorNumber = (string)cmds.Parameters["errorNo"].Value;
                        objex.errorDescription = ObjErrormsg.ErrorMessage(objex.errorNumber);
                        isvaild = false;
                        break;
                    }
                }
                if (isvaild == true)
                {
                    mysqltrans.Commit();
                }
                MySqlCommand vcmd = new MySqlCommand("Admin_validate_reports_config", MysqlCon.con);
                vcmd.CommandType = CommandType.StoredProcedure;
                vcmd.Parameters.Add("IOU_report_rowid", MySqlDbType.Int32).Value = objRC.document.context.Header.IOU_report_rowid;
                vcmd.Parameters.Add("In_module_code", MySqlDbType.VarChar).Value = objRC.document.context.Header.In_module_code;
                vcmd.Parameters.Add("In_report_code", MySqlDbType.VarChar).Value = objRC.document.context.Header.In_report_code;
                vcmd.Parameters.Add("In_report_name", MySqlDbType.VarChar).Value = objRC.document.context.Header.In_report_name;
                vcmd.Parameters.Add("In_report_type", MySqlDbType.VarChar).Value = objRC.document.context.Header.In_report_type;
                vcmd.Parameters.Add("In_report_source", MySqlDbType.VarChar).Value = objRC.document.context.Header.In_report_source;
                vcmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = objRC.document.context.Header.In_status_code;
                vcmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = objRC.document.context.Header.In_row_timestamp;
                vcmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objRC.document.context.Header.In_mode_flag;
                vcmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objRC.document.context.orgnId;
                vcmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objRC.document.context.locnId;
                vcmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objRC.document.context.userId;
                vcmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objRC.document.context.localeId;
                ret = vcmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);

                if (MysqlCon.con.State == ConnectionState.Open)
                {
                    MysqlCon.con.Close();
                }

                ObjFetch.ApplicationException = objex;

            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                logger.Error("USERNAME :" + objRC.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }

    }
}
