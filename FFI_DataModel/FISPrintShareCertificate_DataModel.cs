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
    public class FISPrintShareCertificate_DataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInvoice_DataModel)); //Declaring Log4Net. 
        string methodName = "";
        public PrintShareApplication GetSinglePrintShareDtl(PrintShareContext ObjContext, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataSet ds = new DataSet();
            DataTable dt_detail = new DataTable();
            DataTable dt_register = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            PrintShareApplication ObjFetchAll = new PrintShareApplication();
            ObjFetchAll.context = new PrintShareContext();
            ObjFetchAll.context.Header = new PrintShareHeader();
            ObjFetchAll.context.Header.Detail = new List<PrintShareDetail>();
            ObjFetchAll.context.Header.Register_History = new List<Register_History>();

            try
            {
                MySqlCommand cmd = new MySqlCommand("FIS_fetch_share_certificate_print", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_share_certificate", MySqlDbType.VarChar).Value = ObjContext.share_certificate;
                cmd.Parameters.Add("In_fpoorgn_code", MySqlDbType.VarChar).Value = ObjContext.fpoorgn_code;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add(new MySqlParameter("In_printeddate", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                dt_detail = ds.Tables[0];
                dt_register = ds.Tables[1];

                for (int i = 0; i < dt_detail.Rows.Count; i++)
                {
                    PrintShareDetail objList_details = new PrintShareDetail();
                    objList_details.In_register_rowid = Convert.ToInt32(dt_detail.Rows[i]["In_register_rowid"]);
                    objList_details.In_register_no = dt_detail.Rows[i]["In_register_no"].ToString();
                    objList_details.In_register_date = dt_detail.Rows[i]["In_register_date"].ToString();
                    objList_details.In_farmer_code = dt_detail.Rows[i]["In_farmer_code"].ToString();
                    objList_details.In_farmer_name = dt_detail.Rows[i]["In_farmer_name"].ToString();
                    objList_details.In_fpomember_code = dt_detail.Rows[i]["In_fpomember_code"].ToString();
                    objList_details.In_member_name = dt_detail.Rows[i]["In_member_name"].ToString();
                    objList_details.In_certificate_no = dt_detail.Rows[i]["In_certificate_no"].ToString();
                    objList_details.In_folio_no = dt_detail.Rows[i]["In_folio_no"].ToString();
                    objList_details.In_applied_shares = Convert.ToInt32(dt_detail.Rows[i]["In_applied_shares"]);
                    objList_details.In_approved_shares = Convert.ToInt32(dt_detail.Rows[i]["In_approved_shares"]);
                    objList_details.In_rejected_shares = Convert.ToInt32(dt_detail.Rows[i]["In_rejected_shares"]);
                    objList_details.In_status_desc = dt_detail.Rows[i]["In_status_desc"].ToString();
                    objList_details.In_mode_flag = dt_detail.Rows[i]["In_mode_flag"].ToString();
                    objList_details.In_row_timestamp = dt_detail.Rows[i]["In_row_timestamp"].ToString();

                    ObjFetchAll.context.Header.Detail.Add(objList_details);

                }

                for (int i = 0; i < dt_register.Rows.Count; i++)
                {
                    Register_History objList_register = new Register_History();
                    objList_register.In_register_rowid = Convert.ToInt32(dt_register.Rows[i]["In_register_rowid"]);
                    objList_register.In_register_no = dt_register.Rows[i]["In_register_no"].ToString();
                    objList_register.In_certificate_no = dt_register.Rows[i]["In_certificate_no"].ToString();
                    objList_register.In_printed_date = dt_register.Rows[i]["In_printed_date"].ToString();
                    objList_register.In_register_date = dt_register.Rows[i]["In_register_date"].ToString();
                    ObjFetchAll.context.Header.Register_History.Add(objList_register);

                }

                ObjFetchAll.context.Header.In_printeddate = (string)cmd.Parameters["In_printeddate"].Value.ToString();
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //throw ex;
            }

            return ObjFetchAll;
        }
        public Documentsave SavePrintShare(Applicationsave ObjContext, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            int ret = 0;
            MysqlCon = new DataConnection(mysqlcon);
            Documentsave ObjSaveDoc = new Documentsave();
            ObjSaveDoc.context = new Contextsave();
            ObjSaveDoc.context.Header = new Headersave();
            ObjSaveDoc.context.Detail = new Detailsave();

            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                //foreach (var Details in ObjContext.document.context.Detail)
                //{
                MySqlCommand cmd = new MySqlCommand("FIS_iud_share_certificate_print", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("IOU_share_certificate", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_share_certificate;
                cmd.Parameters.Add("IOU_fpoorgn_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_fpoorgn_code;
                cmd.Parameters.Add("In_printeddate", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_printeddate;
                cmd.Parameters.Add("In_register_rowid", MySqlDbType.Int32).Value = Convert.ToInt32(ObjContext.document.context.Detail.In_register_rowid);
                cmd.Parameters.Add("In_register_no", MySqlDbType.VarChar).Value = ObjContext.document.context.Detail.In_register_no;
                cmd.Parameters.Add("In_farmer_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Detail.In_farmer_code;
                cmd.Parameters.Add("In_fpomember_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Detail.In_fpomember_code;
                cmd.Parameters.Add("In_certificate_no", MySqlDbType.VarChar).Value = ObjContext.document.context.Detail.In_certificate_no;
                cmd.Parameters.Add("In_applied_shares", MySqlDbType.Int32).Value = Convert.ToInt32(ObjContext.document.context.Detail.In_applied_shares);
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Detail.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Detail.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjContext.document.context.Detail.In_row_timestamp;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("IOU_share_certificate1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_fpoorgn_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                //if (ret == 0)
                //{
                //    mysqltrans.Rollback();
                //    break;
                //}

                //}

                mysqltrans.Commit();

                ObjSaveDoc.context.orgnId = ObjContext.document.context.orgnId;
                ObjSaveDoc.context.userId = ObjContext.document.context.userId;
                ObjSaveDoc.context.locnId = ObjContext.document.context.locnId;
                ObjSaveDoc.context.localeId = ObjContext.document.context.localeId;
                ObjSaveDoc.context.Header.IOU_fpoorgn_code = (string)cmd.Parameters["IOU_fpoorgn_code1"].Value.ToString();
                ObjSaveDoc.context.Header.IOU_share_certificate = (string)cmd.Parameters["IOU_share_certificate1"].Value.ToString();
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                //throw ex;
                logger.Error("USERNAME :" + ObjContext.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }

            return ObjSaveDoc;
        }
    }
}

