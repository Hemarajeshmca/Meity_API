using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FFI_Model;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using MySqlX.XDevAPI.Common;
using System.Reflection;

namespace FFI_DataModel
{
    public class FISUpdateFpo_DataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInvoice_DataModel)); //Declaring Log4Net. 
        string methodName = "";
        public UpdateFetchApplication GetUpdateFpoList(UpdateFetchContext ObjContext, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            UpdateFetchApplication ObjFetchAll = new UpdateFetchApplication();
            ObjFetchAll.context = new UpdateFetchContext();
            ObjFetchAll.context.Detail = new List<UpdateFetchDetail>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("FIS_fetch_update_share_allotment", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("IOU_fpoorgn_code", MySqlDbType.VarChar).Value = ObjContext.fpoorgn_code;
                cmd.Parameters.Add("IOU_alloc_status_code", MySqlDbType.VarChar).Value = ObjContext.alloc_status_code;
                cmd.Parameters.Add("IOU_board_approval_date", MySqlDbType.VarChar).Value = ObjContext.board_approval_date;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    UpdateFetchDetail objList = new UpdateFetchDetail();
                    objList.In_shareapp_rowid = Convert.ToInt32(dt.Rows[i]["In_shareapp_rowid"]);
                    objList.In_shareapp_no = dt.Rows[i]["In_shareapp_no"].ToString();
                    objList.In_shareapp_date = dt.Rows[i]["In_shareapp_date"].ToString();
                    objList.In_member_name = dt.Rows[i]["In_member_name"].ToString();
                    objList.In_applied_shares = Convert.ToInt32(dt.Rows[i]["In_applied_shares"]);
                    objList.In_approved_shares = Convert.ToInt32(dt.Rows[i]["In_approved_shares"]);
                    objList.In_rejected_shares = Convert.ToInt32(dt.Rows[i]["In_rejected_shares"]);
                    objList.In_rejected_comment = dt.Rows[i]["In_rejected_comment"].ToString();
                    objList.In_approved_date = dt.Rows[i]["In_approved_date"].ToString();
                    objList.In_status_code = dt.Rows[i]["In_status_code"].ToString();
                    objList.In_status_desc = dt.Rows[i]["In_status_desc"].ToString();
                    objList.In_mode_flag = dt.Rows[i]["In_mode_flag"].ToString();
                    objList.In_row_timestamp = dt.Rows[i]["In_row_timestamp"].ToString();

                    ObjFetchAll.context.Detail.Add(objList);

                }
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }

            return ObjFetchAll;
        }
        public UpdateSaveDocument SaveUpdateFpo(UpdateSaveApplication ObjContext, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            int ret = 0;
            string errorNo = "";
            string errorMsg = "";

            MysqlCon = new DataConnection(mysqlcon);
            UpdateSaveDocument ObjSaveDoc = new UpdateSaveDocument();
            ObjSaveDoc.context = new UpdateSaveContext();
            ObjSaveDoc.context.Header = new UpdateSaveHeader();
            ObjSaveDoc.context.Detail = new List<UpdateSaveDetail>();

            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                foreach (var Details in ObjContext.document.context.Detail)
                {
                    MySqlCommand cmd = new MySqlCommand("FIS_iud_update_share_allotment", MysqlCon.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("In_fpoorgn_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_fpoorgn_code;
                    cmd.Parameters.Add("In_alloc_status_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_alloc_status_code;
                    cmd.Parameters.Add("In_shareapp_rowid", MySqlDbType.Int32).Value = Convert.ToInt32(Details.In_shareapp_rowid);
                    cmd.Parameters.Add("In_shareapp_no", MySqlDbType.VarChar).Value = Details.In_shareapp_no;
                    cmd.Parameters.Add("In_member_name", MySqlDbType.VarChar).Value = Details.In_member_name;
                    cmd.Parameters.Add("In_applied_shares", MySqlDbType.Int32).Value = Convert.ToInt32(Details.In_applied_shares);
                    cmd.Parameters.Add("In_approved_shares", MySqlDbType.Int32).Value = Convert.ToInt32(Details.In_approved_shares);
                    cmd.Parameters.Add("In_rejected_shares", MySqlDbType.Int32).Value = Convert.ToInt32(Details.In_rejected_shares);
                    cmd.Parameters.Add("In_rejected_comment", MySqlDbType.VarChar).Value = Details.In_rejected_comment;
                    cmd.Parameters.Add("In_approved_date", MySqlDbType.VarChar).Value = Details.In_approved_date;
                    cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = Details.In_status_code;
                    cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Details.In_mode_flag;
                    cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = Details.In_row_timestamp;
                    cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                    cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                    cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                    cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                    cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                    ret = cmd.ExecuteNonQuery();
                    LogHelper.ConvertCmdIntoString(cmd);
                    if (ret == 0)
                    {
                        mysqltrans.Rollback();

                        errorNo = (string)cmd.Parameters["errorNo"].Value;
                        errorMsg = ObjErrormsg.ErrorMessage(errorNo);

                        ObjSaveDoc.ApplicationException.errorNumber = (string)cmd.Parameters["errorNo"].Value;
                        ObjSaveDoc.ApplicationException.errorDescription = errorMsg;
                        break;
                    }
                    else
                    {
                        ObjSaveDoc.context.orgnId = ObjContext.document.context.orgnId;
                        ObjSaveDoc.context.userId = ObjContext.document.context.userId;
                        ObjSaveDoc.context.locnId = ObjContext.document.context.locnId;
                        ObjSaveDoc.context.localeId = ObjContext.document.context.localeId;
                        ObjSaveDoc.context.Header.In_fpoorgn_code = ObjContext.document.context.Header.In_fpoorgn_code;
                        ObjSaveDoc.context.Header.In_alloc_status_code = ObjContext.document.context.Header.In_alloc_status_code;
                    }
                }

                mysqltrans.Commit();


            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                logger.Error("USERNAME :" + ObjContext.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }

            return ObjSaveDoc;
        }
    }
}

