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
    public class FISProcessShareApp_DataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInvoice_DataModel)); //Declaring Log4Net. 
        string methodName = "";

        public AllApplication GetAllProcessList(AllContext ObjContext, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            AllApplication ObjFetchAll = new AllApplication();
            ObjFetchAll.context = new AllContext();
            ObjFetchAll.context.List = new List<ProcessList>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("FIS_fetch_process_share_app_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("in_FilterBy_Option", MySqlDbType.VarChar).Value = ObjContext.FilterBy_Option;
                cmd.Parameters.Add("in_FilterBy_Code", MySqlDbType.VarChar).Value = ObjContext.FilterBy_Code;
                cmd.Parameters.Add("in_FilterBy_Fromvalue", MySqlDbType.VarChar).Value = ObjContext.FilterBy_FromValue;
                cmd.Parameters.Add("in_FilterBy_Tovalue", MySqlDbType.VarChar).Value = ObjContext.FilterBy_ToValue;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;


                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ProcessList objList = new ProcessList();
                    objList.Out_shareapp_rowid = Convert.ToInt32(dt.Rows[i]["Out_shareapp_rowid"]);
                    objList.Out_shareapp_no = dt.Rows[i]["Out_shareapp_no"].ToString();
                    objList.Out_fpoorgn_code = dt.Rows[i]["Out_fpoorgn_code"].ToString();
                    objList.Out_farmer_code = dt.Rows[i]["Out_farmer_code"].ToString();
                    objList.Out_fpomember_code = dt.Rows[i]["Out_fpomember_code"].ToString();
                    objList.Out_member_name = dt.Rows[i]["Out_member_name"].ToString();
                    objList.Out_farmer_name = dt.Rows[i]["Out_farmer_name"].ToString();
                    objList.Out_sur_name = dt.Rows[i]["Out_sur_name"].ToString();
                    objList.Out_applied_on = dt.Rows[i]["Out_applied_on"].ToString();
                    objList.Out_applied_shares = Convert.ToDouble(dt.Rows[i]["Out_applied_shares"]);
                    objList.Out_amount_due = Convert.ToDouble(dt.Rows[i]["Out_amount_due"]);
                    objList.Out_payment_mode = dt.Rows[i]["Out_payment_mode"].ToString();
                    objList.Out_payment_mode_desc = dt.Rows[i]["Out_payment_mode_desc"].ToString();
                    objList.Out_payment_ref_no = dt.Rows[i]["Out_payment_ref_no"].ToString();
                    objList.Out_payment_status = dt.Rows[i]["Out_payment_status"].ToString();
                    objList.Out_payment_status_desc = dt.Rows[i]["Out_payment_status_desc"].ToString();
                    objList.Out_shareapp_remark = dt.Rows[i]["Out_shareapp_remark"].ToString();
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.Out_status_desc = dt.Rows[i]["Out_status_desc"].ToString();

                    ObjFetchAll.context.List.Add(objList);

                }
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }

            return ObjFetchAll;
        }

        public FetchApplication GetSingleProcessDtls_db(FetchContext ObjContext, string mysqlcon)
        {
           
            methodName = MethodBase.GetCurrentMethod().Name;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);
            int ret = 0;
            FetchApplication ObjFetchAll = new FetchApplication();
            ObjFetchAll.context = new FetchContext();
            ObjFetchAll.context.Header = new FetchHeader();
            try
            {
                MySqlCommand cmd = new MySqlCommand("FIS_fetch_process_share_app", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("IOU_shareapp_rowid", MySqlDbType.Int32).Value = ObjContext.shareapp_rowid;
                cmd.Parameters.Add("IOU_fpoorgn_code", MySqlDbType.VarChar).Value = ObjContext.fpoorgn_code;
                cmd.Parameters.Add(new MySqlParameter("IOU_shareapp_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_fpoorgn_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_shareapp_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_farmer_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_fpomember_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_member_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_farmer_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_sur_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_photo_farmer", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_signature_farmer", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_applied_on", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_applied_shares", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_amount_due", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_payment_mode", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_payment_mode_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_payment_ref_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_payment_status", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_payment_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_shareapp_remark", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_Collected_By", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_Received_By", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_BankName", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_AcctNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_IFSCCode", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_AadharNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                ObjFetchAll.context.Header.IOU_shareapp_rowid = (Int32)cmd.Parameters["IOU_shareapp_rowid1"].Value;
                ObjFetchAll.context.Header.IOU_fpoorgn_code = (string)cmd.Parameters["IOU_fpoorgn_code1"].Value.ToString();
                ObjFetchAll.context.Header.In_shareapp_no = (string)cmd.Parameters["In_shareapp_no"].Value.ToString();
                ObjFetchAll.context.Header.In_farmer_code = (string)cmd.Parameters["In_farmer_code"].Value.ToString();
                ObjFetchAll.context.Header.In_fpomember_code = (string)cmd.Parameters["In_fpomember_code"].Value.ToString();
                ObjFetchAll.context.Header.In_member_name = (string)cmd.Parameters["In_member_name"].Value.ToString();
                ObjFetchAll.context.Header.In_farmer_name = (string)cmd.Parameters["In_farmer_name"].Value.ToString();
                ObjFetchAll.context.Header.In_sur_name = (string)cmd.Parameters["In_sur_name"].Value.ToString();
                ObjFetchAll.context.Header.In_photo_farmer = (string)cmd.Parameters["In_photo_farmer"].Value.ToString();
                ObjFetchAll.context.Header.In_signature_farmer = (string)cmd.Parameters["In_signature_farmer"].Value.ToString();
                ObjFetchAll.context.Header.In_applied_on = (string)cmd.Parameters["In_applied_on"].Value.ToString();
                ObjFetchAll.context.Header.In_applied_shares = (Int32)cmd.Parameters["In_applied_shares"].Value;
                ObjFetchAll.context.Header.In_amount_due = (Double)cmd.Parameters["In_amount_due"].Value;               
                ObjFetchAll.context.Header.In_payment_mode = (string)cmd.Parameters["In_payment_mode"].Value.ToString();
                ObjFetchAll.context.Header.In_payment_mode_desc = (string)cmd.Parameters["In_payment_mode_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_payment_ref_no = (string)cmd.Parameters["In_payment_ref_no"].Value.ToString();
                ObjFetchAll.context.Header.In_payment_status = (string)cmd.Parameters["In_payment_status"].Value.ToString();
                ObjFetchAll.context.Header.In_payment_status_desc = (string)cmd.Parameters["In_payment_status_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_shareapp_remark = (string)cmd.Parameters["In_shareapp_remark"].Value.ToString();
                ObjFetchAll.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                ObjFetchAll.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();
                ObjFetchAll.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                ObjFetchAll.context.Header.In_Collected_By = (string)cmd.Parameters["In_Collected_By"].Value.ToString();
                ObjFetchAll.context.Header.In_Received_By = (string)cmd.Parameters["In_Received_By"].Value.ToString();
                ObjFetchAll.context.Header.In_BankName = (string)cmd.Parameters["In_BankName"].Value.ToString();
                ObjFetchAll.context.Header.In_AcctNo = (string)cmd.Parameters["In_AcctNo"].Value.ToString();
                ObjFetchAll.context.Header.In_IFSCCode = (string)cmd.Parameters["In_IFSCCode"].Value.ToString();
                ObjFetchAll.context.Header.In_AadharNo = (string)cmd.Parameters["In_AadharNo"].Value.ToString();
                ObjFetchAll.context.localeId = ObjContext.localeId;
                ObjFetchAll.context.userId = ObjContext.userId;
                ObjFetchAll.context.locnId = ObjContext.locnId;
                ObjFetchAll.context.orgnId = ObjContext.orgnId;


            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }
            return ObjFetchAll;
        }

        public ProcessShareDocument SaveProcessShare(ProcessShareApplication ObjContext, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            int ret = 0;
            MysqlCon = new DataConnection(mysqlcon);
            ProcessShareDocument objProcessDoc = new ProcessShareDocument();
            objProcessDoc.context = new SaveContext();
            objProcessDoc.context.Header = new SaveHeader();
            objProcessDoc.ApplicationException = new ProcessShareApplicationException();
            string errorNo = "";
            string errorMsg = "";
            try
            {
                MySqlCommand cmd = new MySqlCommand("FIS_insupd_process_share_app", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("in_fpoorgn_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_fpoorgn_code;
                cmd.Parameters.Add("in_farmer_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_farmer_code;
                cmd.Parameters.Add("in_fpomember_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_fpomember_code;
                cmd.Parameters.Add("in_signature_farmer", MySqlDbType.LongText).Value = ObjContext.document.context.Header.In_signature_farmer;
                cmd.Parameters.Add("in_photo_farmer", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_photo_farmer;
                cmd.Parameters.Add("In_applied_on", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_applied_on;
                cmd.Parameters.Add("in_applied_shares", MySqlDbType.Int32).Value = ObjContext.document.context.Header.In_applied_shares;
                cmd.Parameters.Add("in_amount_due", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_amount_due;
                cmd.Parameters.Add("in_payment_mode", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_payment_mode;
                cmd.Parameters.Add("in_payment_ref_no", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_payment_ref_no;
                cmd.Parameters.Add("in_payment_status", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_payment_status;
                cmd.Parameters.Add("in_shareapp_remark", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_shareapp_remark;
                cmd.Parameters.Add("in_status_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("in_collected_by", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_Collected_By;
                cmd.Parameters.Add("in_received_by", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_Received_By;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmd.Parameters.Add("IOU_shareapp_rowid", MySqlDbType.Int32).Value = ObjContext.document.context.Header.IOU_shareapp_rowid;
                cmd.Parameters.Add("IOU_shareapp_no", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_shareapp_no;

                cmd.Parameters.Add(new MySqlParameter("IOU_shareapp_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_shareapp_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();
                                
                if (ret > 0)
                {
                    objProcessDoc.context.orgnId = ObjContext.document.context.orgnId;
                    objProcessDoc.context.locnId = ObjContext.document.context.locnId;
                    objProcessDoc.context.userId = ObjContext.document.context.userId;
                    objProcessDoc.context.localeId = ObjContext.document.context.localeId;

                    objProcessDoc.context.Header.IOU_shareapp_rowid = (Int32)cmd.Parameters["IOU_shareapp_rowid1"].Value;
                    objProcessDoc.context.Header.IOU_shareapp_no = (string)cmd.Parameters["IOU_shareapp_no1"].Value.ToString();
                }
                else
                {
                    errorNo = (string)cmd.Parameters["errorNo"].Value;
                    errorMsg = ObjErrormsg.ErrorMessage(errorNo);

                    objProcessDoc.ApplicationException.errorNumber = (string)cmd.Parameters["errorNo"].Value;
                    objProcessDoc.ApplicationException.errorDescription = errorMsg;
                }

            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjContext.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex); 
            }

            return objProcessDoc;
        }
    }
}
