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
    public class FISGenerateShareCertificate_DataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInvoice_DataModel)); //Declaring Log4Net. 
        string methodName = "";


        public GenerateShareApplication GetAllGenerateShareList(GenerateShareContext ObjContext, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            GenerateShareApplication ObjFetchAll = new GenerateShareApplication();
            ObjFetchAll.context = new GenerateShareContext();
            ObjFetchAll.context.List = new List<GenerateShareList>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("FIS_fetch_share_Register_list", MysqlCon.con);
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
                    GenerateShareList objList = new GenerateShareList();
                    objList.Out_register_rowid = Convert.ToInt32(dt.Rows[i]["Out_register_rowid"]);
                    objList.Out_fpoorgn_code = dt.Rows[i]["Out_fpoorgn_code"].ToString();
                    objList.Out_register_no = dt.Rows[i]["Out_register_no"].ToString();
                    objList.Out_register_type_code = dt.Rows[i]["Out_register_type_code"].ToString();
                    objList.Out_register_type_desc = dt.Rows[i]["Out_register_type_desc"].ToString();
                    objList.Out_register_date = dt.Rows[i]["Out_register_date"].ToString();
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

        public GenerateShareFetchApplication GetSingleGenerateShareDtl(GenerateShareFetchContext ObjContext, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            GenerateShareFetchApplication ObjFetchAll = new GenerateShareFetchApplication();
            ObjFetchAll.context = new GenerateShareFetchContext();
            ObjFetchAll.context.Detail = new List<GenerateShareDetail>();
            ObjFetchAll.context.Header = new GenerateShareHeader();
            try
            {
                MySqlCommand cmd = new MySqlCommand("FIS_fetch_Allotment_share_register", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_register_rowid", MySqlDbType.Int32).Value = ObjContext.register_rowid;
                cmd.Parameters.Add("In_register_type", MySqlDbType.VarChar).Value = ObjContext.register_type;
                cmd.Parameters.Add("In_fpoorgn_code", MySqlDbType.VarChar).Value = ObjContext.fpoorgn_code;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add(new MySqlParameter("In_register_type_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_register_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_register_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_record_count", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    GenerateShareDetail objList = new GenerateShareDetail();
                    objList.In_shareapp_rowid = Convert.ToInt32(dt.Rows[i]["In_shareapp_rowid"]);
                    objList.In_farmer_code = dt.Rows[i]["In_farmer_code"].ToString();
                    objList.In_fpomember_code = dt.Rows[i]["In_fpomember_code"].ToString();
                    objList.In_shareapp_no = dt.Rows[i]["In_shareapp_no"].ToString();
                    objList.In_member_name = dt.Rows[i]["In_member_name"].ToString();
                    objList.In_member_sur_name = dt.Rows[i]["In_member_sur_name"].ToString();
                    objList.In_applied_shares = Convert.ToInt32(dt.Rows[i]["In_applied_shares"]);
                    objList.In_approved_shares = Convert.ToInt32(dt.Rows[i]["In_approved_shares"]);
                    objList.In_rejected_shares = Convert.ToInt32(dt.Rows[i]["In_rejected_shares"]);
                    objList.In_status_code = dt.Rows[i]["In_status_code"].ToString();
                    objList.In_status_desc = dt.Rows[i]["In_status_desc"].ToString();
                    objList.In_chklist_status_flag = dt.Rows[i]["In_chklist_status_flag"].ToString();
                    objList.In_shareapp_remark = dt.Rows[i]["In_shareapp_remark"].ToString();
                    objList.In_mode_flag = dt.Rows[i]["In_mode_flag"].ToString();
                    objList.In_row_timestamp = dt.Rows[i]["In_row_timestamp"].ToString();

                    ObjFetchAll.context.Detail.Add(objList);

                }

                ObjFetchAll.context.Header.In_register_type_desc = (string)cmd.Parameters["In_register_type_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_register_date = (string)cmd.Parameters["In_register_date"].Value.ToString();
                ObjFetchAll.context.Header.In_register_no = (string)cmd.Parameters["In_register_no"].Value.ToString();
                ObjFetchAll.context.Header.In_record_count = (Int32)cmd.Parameters["In_record_count"].Value;
                ObjFetchAll.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                ObjFetchAll.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                ObjFetchAll.context.Header.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();
            }
            catch (Exception ex)
            {

                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }

            return ObjFetchAll;
        }

        public GenerateShareDocument SaveGenerateShare(GenerateShareSaveApplication ObjContext, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            int ret = 0;
            int retdtls = 0;
            //int errorcount = 0;
            string errorNo = "";
            string errorMsg = "";
            MysqlCon = new DataConnection(mysqlcon);
            GenerateShareDocument ObjSaveDoc = new GenerateShareDocument();
            ObjSaveDoc.context = new GenerateShareSaveContext();
            ObjSaveDoc.context.Header = new GenerateShareSaveHeader();
            ObjSaveDoc.context.Detail = new List<GenerateShareSaveDetail>();
            ObjSaveDoc.ApplicationException = new FFI_Model.ApplicationException();
            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                MySqlCommand cmd = new MySqlCommand("FIS_insupd_allotment_share_register", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_fpoorgn_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_fpoorgn_code;
                cmd.Parameters.Add("In_register_type", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_register_type;
                cmd.Parameters.Add("In_register_date", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_register_date;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmd.Parameters.Add("IOU_register_rowid", MySqlDbType.Int32).Value = ObjContext.document.context.Header.IOU_register_rowid;
                cmd.Parameters.Add("IOU_register_no", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_register_no;
                cmd.Parameters.Add(new MySqlParameter("IOU_register_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_register_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                if (ret == 0)
                {
                    mysqltrans.Rollback();
                    errorNo = (string)cmd.Parameters["errorNo"].Value;
                    errorMsg = ObjErrormsg.ErrorMessage(errorNo);
                    ObjSaveDoc.ApplicationException.errorNumber = errorNo;
                    ObjSaveDoc.ApplicationException.errorDescription = errorMsg;

                }
                else
                {
                    ObjSaveDoc.context.orgnId = ObjContext.document.context.orgnId;
                    ObjSaveDoc.context.locnId = ObjContext.document.context.locnId;
                    ObjSaveDoc.context.userId = ObjContext.document.context.userId;
                    ObjSaveDoc.context.localeId = ObjContext.document.context.localeId;
                    ObjSaveDoc.context.Header.IOU_register_no = (string)cmd.Parameters["IOU_register_no1"].Value;
                    ObjSaveDoc.context.Header.IOU_register_rowid = (Int32)cmd.Parameters["IOU_register_rowid1"].Value;

                    if (ObjContext.document.context.Detail.Count > 0)
                    {

                        foreach (var Details in ObjContext.document.context.Detail)
                        {
                            MySqlCommand cmds = new MySqlCommand("FIS_iud_allotment_share_register", MysqlCon.con);
                            cmds.CommandType = CommandType.StoredProcedure;
                            cmds.Parameters.Add("IOU_register_no", MySqlDbType.VarChar).Value = ObjSaveDoc.context.Header.IOU_register_no;
                            cmds.Parameters.Add("In_fpoorgn_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_fpoorgn_code;
                            cmds.Parameters.Add("In_shareapp_rowid", MySqlDbType.Int32).Value = Convert.ToInt32(Details.In_shareapp_rowid);
                            cmds.Parameters.Add("In_shareapp_no", MySqlDbType.VarChar).Value = Details.In_shareapp_no;
                            cmds.Parameters.Add("In_farmer_code", MySqlDbType.VarChar).Value = Details.In_farmer_code;
                            cmds.Parameters.Add("In_fpomember_code", MySqlDbType.VarChar).Value = Details.In_fpomember_code;
                            cmds.Parameters.Add("In_member_name", MySqlDbType.VarChar).Value = Details.In_member_name;
                            cmds.Parameters.Add("In_member_sur_name", MySqlDbType.VarChar).Value = Details.In_member_sur_name;
                            cmds.Parameters.Add("In_applied_shares", MySqlDbType.Int32).Value = Convert.ToInt32(Details.In_applied_shares);
                            cmds.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = Details.In_status_code;
                            cmds.Parameters.Add("In_chklist_status_flag", MySqlDbType.VarChar).Value = Details.In_chklist_status_flag;
                            cmds.Parameters.Add("In_shareapp_remark", MySqlDbType.VarChar).Value = Details.In_shareapp_remark;
                            cmds.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_mode_flag;
                            cmds.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_row_timestamp;

                            retdtls = cmds.ExecuteNonQuery();
                            LogHelper.ConvertCmdIntoString(cmd);
                            //if (retdtls == 0)
                            //{
                            //    errorcount = 1;
                            //    mysqltrans.Rollback();
                            //    break;
                            //}                         

                        }
                       
                            mysqltrans.Commit();
                        }
                    
                    else
                    {
                        mysqltrans.Rollback();
                    }

                }

                            
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                //  throw ex;
                logger.Error("USERNAME :" + ObjContext.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }

            return ObjSaveDoc;
        }


    }
}
