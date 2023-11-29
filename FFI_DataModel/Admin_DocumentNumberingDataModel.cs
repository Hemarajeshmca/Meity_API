using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
    public class Admin_DocumentNumberingDataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        Admin_ErrorMessageModel ObjErrormsg = new Admin_ErrorMessageModel();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Admin_DocumentNumberingDataModel));
        // Exception Log Method Name Purpose written start 
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public DCNumberList DocNumberList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue, string ConString)
        {
            DCNumberList ObjFetchAll = new DCNumberList();
            
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MysqlCon = new DataConnection(ConString);
                DCContext objContext = new DCContext();
                objContext.orgnId = org;
                objContext.localeId = lang;
                objContext.locnId = locn;
                objContext.userId = user;
                ObjFetchAll.context = objContext;
                MySqlCommand cmd = new MySqlCommand("Admin_fetch_docnumber_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("in_FilterBy_Option", MySqlDbType.VarChar).Value = filterby_option;
                cmd.Parameters.Add("in_FilterBy_Code", MySqlDbType.VarChar).Value = filterby_code;
                cmd.Parameters.Add("in_FiltereBy_Fromvalue", MySqlDbType.VarChar).Value = filterby_fromvalue;
                cmd.Parameters.Add("in_FiltereBy_Tovalue", MySqlDbType.VarChar).Value = filterby_tovalue;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                List<DCList> objRoleLst = new List<DCList>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DCList objList = new DCList();
                    objList.Out_activity_code = dt.Rows[i]["Out_activity_code"].ToString();
                    objList.Out_finyear_code = dt.Rows[i]["Out_finyear_code"].ToString();
                    objList.Out_docnum_rowid = Convert.ToInt32(dt.Rows[i]["Out_docnum_rowid"].ToString());
                    objList.Out_docnum_preview = dt.Rows[i]["Out_docnum_preview"].ToString();
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

        public FetchDocNumber FetchDocNum(string org, string locn, string user, string lang, string activity_code, string finyear_code, int docnum_rowid, string ConString)
        {
            FetchDocNumber ObjFetch = new FetchDocNumber();
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MysqlCon = new DataConnection(ConString);
                FetchDocContext objContext = new FetchDocContext();
                objContext.orgnId = org;
                objContext.localeId = lang;
                objContext.locnId = locn;
                objContext.userId = user;
                ObjFetch.context = objContext;
                MySqlCommand cmd = new MySqlCommand("Admin_fetch_docnumber", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("In_activity_code", MySqlDbType.VarChar).Value = activity_code;
                cmd.Parameters.Add("In_finyear_code", MySqlDbType.VarChar).Value = finyear_code;
                cmd.Parameters.Add("In_docnum_rowid", MySqlDbType.Int32).Value = docnum_rowid;
                cmd.Parameters.Add(new MySqlParameter("In_activity_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_finyear_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_docnum_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_docnum_preview", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();
                FetchDocHeader objHeader = new FetchDocHeader();
                objHeader.In_activity_code = (string)cmd.Parameters["In_activity_code1"].Value.ToString();
                objHeader.In_finyear_code = (string)cmd.Parameters["In_finyear_code1"].Value.ToString();
                objHeader.In_docnum_rowid = (int)cmd.Parameters["In_docnum_rowid1"].Value;
                objHeader.In_docnum_preview = (string)cmd.Parameters["In_status_code"].Value;
                objHeader.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                objHeader.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                objHeader.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();
                objHeader.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                ObjFetch.context.Header = objHeader;

                List<FetchDocDetail> ObjRoleList = new List<FetchDocDetail>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FetchDocDetail objList = new FetchDocDetail();
                    objList.In_docnumformat_rowid = Convert.ToInt32(dt.Rows[i]["In_docnumformat_rowid"]);
                    objList.In_row_slno = Convert.ToInt32(dt.Rows[i]["In_row_slno"]);
                    objList.In_format_type = dt.Rows[i]["In_format_type"].ToString();
                    objList.In_format_type_desc = dt.Rows[i]["In_format_type_desc"].ToString();
                    objList.In_format_desc = dt.Rows[i]["In_format_desc"].ToString();
                    objList.In_format_value = dt.Rows[i]["In_format_value"].ToString();
                    objList.In_format_length = dt.Rows[i]["In_format_length"].ToString();
                    objList.In_status_code = dt.Rows[i]["In_status_code"].ToString();
                    objList.In_status_desc = dt.Rows[i]["In_status_desc"].ToString();
                    objList.In_row_timestamp = dt.Rows[i]["In_row_timestamp"].ToString();
                    objList.In_mode_flag = dt.Rows[i]["In_mode_flag"].ToString();
                    ObjRoleList.Add(objList);
                }
                ObjFetch.context.Detail = ObjRoleList;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }

        public OutputDoc SaveDC(SaveDocNum objDoc, string ConString)
        {
            OutputDoc ObjFetch = new OutputDoc();
            try
            {
                int ret = 0;
                int retdtls = 0;
                MysqlCon = new DataConnection(ConString);

                OutputDocContext objContext = new OutputDocContext();
                objContext.orgnId = objDoc.document.context.orgnId;
                objContext.localeId = objDoc.document.context.localeId;
                objContext.locnId = objDoc.document.context.locnId;
                objContext.userId = objDoc.document.context.userId;
                ObjFetch.context = objContext;
                OutputDocHeader objOutHeader = new OutputDocHeader();

                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }


                FFI_Model.ApplicationException objex = new FFI_Model.ApplicationException();
                MySqlCommand cmd = new MySqlCommand("Admin_insupd_docnumber", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_docnum_rowid", MySqlDbType.Int32).Value = objDoc.document.context.Header.In_docnum_rowid;
                cmd.Parameters.Add("In_activity_code", MySqlDbType.VarChar).Value = objDoc.document.context.Header.In_activity_code;
                cmd.Parameters.Add("In_finyear_code", MySqlDbType.VarChar).Value = objDoc.document.context.Header.In_finyear_code;
                cmd.Parameters.Add("In_docnum_preview", MySqlDbType.VarChar).Value = objDoc.document.context.Header.In_docnum_preview;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = objDoc.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = objDoc.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objDoc.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objDoc.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objDoc.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objDoc.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objDoc.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("In_docnum_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                retdtls = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                if (retdtls > 0)
                {
                    objOutHeader.In_docnum_rowid = (Int32)cmd.Parameters["In_docnum_rowid1"].Value;
                }
                if (cmd.Parameters["errorNo"].Value.ToString() != "")
                {
                    objex.errorNumber = cmd.Parameters["errorNo"].Value.ToString();
                    objex.errorDescription = ObjErrormsg.ErrorMessage(objex.errorNumber);
                }
                objContext.Header = objOutHeader;

                bool isvaild = true;
                if (objOutHeader.In_docnum_rowid > 0)
                {
                    foreach (var Details in objDoc.document.context.Detail)
                    {
                        MySqlCommand cmds = new MySqlCommand("Admin_iud_docnumber", MysqlCon.con);
                        cmds.CommandType = CommandType.StoredProcedure;
                        cmds.Parameters.Add("In_docnum_rowid", MySqlDbType.Int32).Value = objOutHeader.In_docnum_rowid;
                        cmds.Parameters.Add("In_docnumformat_rowid", MySqlDbType.Int32).Value = Details.In_docnumformat_rowid;
                        cmds.Parameters.Add("In_row_slno", MySqlDbType.Int32).Value = Details.In_row_slno;
                        cmds.Parameters.Add("In_format_type", MySqlDbType.VarChar).Value = Details.In_format_type;
                        cmds.Parameters.Add("In_format_type_desc", MySqlDbType.VarChar).Value = Details.In_format_type_desc;
                        cmds.Parameters.Add("In_format_desc", MySqlDbType.VarChar).Value = Details.In_format_desc;
                        cmds.Parameters.Add("In_format_value", MySqlDbType.VarChar).Value = Details.In_format_value;
                        cmds.Parameters.Add("In_format_length", MySqlDbType.VarChar).Value = Details.In_format_length;
                        cmds.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = Details.In_status_code;
                        cmds.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = Details.In_row_timestamp;
                        cmds.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Details.In_mode_flag;
                        cmds.Parameters.Add("userId", MySqlDbType.VarChar).Value = objDoc.document.context.userId;
                        cmds.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objDoc.document.context.orgnId;
                        cmds.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objDoc.document.context.locnId;
                        cmds.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objDoc.document.context.localeId;
                        cmds.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                        ret = cmds.ExecuteNonQuery();
                        LogHelper.ConvertCmdIntoString(cmd);

                        if (ret == 0)
                        {
                            mysqltrans.Rollback();
                            objex.errorNumber = (string)cmd.Parameters["errorNo"].Value;
                            objex.errorDescription = ObjErrormsg.ErrorMessage(objex.errorNumber);
                            isvaild = false;
                            break;
                        }
                    }
                    if (isvaild == true)
                    {
                        mysqltrans.Commit();
                    }
                }
                else
                {
                    mysqltrans.Rollback();
                }
                MySqlCommand vcmd = new MySqlCommand("Admin_validate_docnumber", MysqlCon.con);
                vcmd.CommandType = CommandType.StoredProcedure;
                vcmd.Parameters.Add("In_docnum_rowid", MySqlDbType.Int32).Value = objDoc.document.context.Header.In_docnum_rowid;
                vcmd.Parameters.Add("In_activity_code", MySqlDbType.VarChar).Value = objDoc.document.context.Header.In_activity_code;
                vcmd.Parameters.Add("In_finyear_code", MySqlDbType.VarChar).Value = objDoc.document.context.Header.In_finyear_code;
                vcmd.Parameters.Add("In_docnum_preview", MySqlDbType.VarChar).Value = objDoc.document.context.Header.In_docnum_preview;
                vcmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = objDoc.document.context.Header.In_status_code;
                vcmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = objDoc.document.context.Header.In_row_timestamp;
                vcmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objDoc.document.context.Header.In_mode_flag;
                vcmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objDoc.document.context.orgnId;
                vcmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objDoc.document.context.locnId;
                vcmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objDoc.document.context.userId;
                vcmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objDoc.document.context.localeId;
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
                MysqlCon.con.Close();
                logger.Error("USERNAME :" + objDoc.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }
    }
}
