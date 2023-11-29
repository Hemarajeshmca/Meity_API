using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace FFI_DataModel
{
   public class FISUpdateservice_DB
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInvoice_DataModel)); //Declaring Log4Net. 
        string methodName = "";
        public FISUpdateserviceApplication Getservice_req_update_DB(FISUpdateserviceContext ObjContext, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);
            FISUpdateserviceApplication ObjFetchAll = new FISUpdateserviceApplication();
            ObjFetchAll.context = new FISUpdateserviceContext();          
            ObjFetchAll.context.Detail = new List<FISUpdateserviceDetail>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("FIS_fetch_service_request_update", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;               
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("In_fpoorgn_code", MySqlDbType.VarChar).Value = ObjContext.Header.In_fpoorgn_code;
                cmd.Parameters.Add("In_process_code", MySqlDbType.VarChar).Value = ObjContext.Header.In_process_status;
                cmd.Parameters.Add("In_Approval_date", MySqlDbType.VarChar).Value = ObjContext.Header.In_Approval_date;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FISUpdateserviceDetail objList = new FISUpdateserviceDetail();
                    objList.In_servicereq_rowid = Convert.ToInt32(dt.Rows[i]["In_servicereq_rowid"]);
                    objList.In_servicereq_no = dt.Rows[i]["In_servicereq_no"].ToString();
                    objList.In_servicereq_date = dt.Rows[i]["In_servicereq_date"].ToString();
                    objList.In_request_type = dt.Rows[i]["In_request_type"].ToString();
                    objList.In_request_type_desc = dt.Rows[i]["In_request_type_desc"].ToString();
                    objList.In_requestsub_type = dt.Rows[i]["In_requestsub_type"].ToString();
                    objList.In_requestsub_type_desc = dt.Rows[i]["In_requestsub_type_desc"].ToString();
                    objList.In_farmer_name = dt.Rows[i]["In_farmer_name"].ToString();
                    objList.In_sur_name = dt.Rows[i]["In_sur_name"].ToString();
                    objList.In_certificate_sno = dt.Rows[i]["In_certificate_sno"].ToString();
                    objList.In_Approvaldate = dt.Rows[i]["In_Approvaldate"].ToString();
                    objList.In_processstatus = dt.Rows[i]["In_processstatus"].ToString();                   
                    objList.In_process_status_desc = dt.Rows[i]["In_process_status_desc"].ToString();
                    objList.In_reject_comments = dt.Rows[i]["In_reject_comments"].ToString();
                    objList.In_sr_comments = dt.Rows[i]["In_sr_comments"].ToString();
                    objList.In_certificate_no = dt.Rows[i]["In_certificate_no"].ToString();
                    objList.In_certificate_desc = dt.Rows[i]["In_certificate_desc"].ToString();
                    objList.In_status_code = dt.Rows[i]["In_status_code"].ToString();
                    objList.In_status_desc = dt.Rows[i]["In_status_desc"].ToString();                  
                    objList.In_mode_flag = dt.Rows[i]["In_mode_flag"].ToString();
                    objList.In_row_timestamp = dt.Rows[i]["In_row_timestamp"].ToString();
                    objList.In_chklist_status_flag = dt.Rows[i]["In_chklist_status_flag"].ToString();

                    ObjFetchAll.context.Detail.Add(objList);

                }
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
        public FISUpdateserviceSDocument SavenewservicerequestUpdate_DB(FISUpdateserviceSApplication ObjContext, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            int ret = 0;
            string errorNo = "";
            string errorMsg = "";

            MysqlCon = new DataConnection(mysqlcon);
            FISUpdateserviceSDocument ObjSaveDoc = new FISUpdateserviceSDocument();
            ObjSaveDoc.context = new FISUpdateserviceSContext();
            ObjSaveDoc.context.Header = new FISUpdateserviceSHeader();
            ObjSaveDoc.context.Detail = new List<FISUpdateserviceSDetail>();

            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                foreach (var Details in ObjContext.document.context.Detail)
                {
                    MySqlCommand cmd = new MySqlCommand("FIS_iud_Service_Request_Update", MysqlCon.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("In_servicereq_rowid", MySqlDbType.Int32).Value = Convert.ToInt32(Details.In_servicereq_rowid);
                    cmd.Parameters.Add("In_servicereq_no", MySqlDbType.VarChar).Value = Details.In_servicereq_no;
                    cmd.Parameters.Add("In_request_type", MySqlDbType.VarChar).Value = Details.In_request_type;
                    cmd.Parameters.Add("In_requestsub_type", MySqlDbType.VarChar).Value = Details.In_requestsub_type;
                    cmd.Parameters.Add("In_farmer_name", MySqlDbType.VarChar).Value = Details.In_farmer_name;
                    cmd.Parameters.Add("In_sur_name", MySqlDbType.VarChar).Value =Details.In_sur_name;
                    cmd.Parameters.Add("In_certificate_sno", MySqlDbType.VarChar).Value = Details.In_certificate_sno;
                    cmd.Parameters.Add("In_Approvaldate", MySqlDbType.VarChar).Value = Details.In_Approvaldate;
                    cmd.Parameters.Add("In_processstatus", MySqlDbType.VarChar).Value = Details.In_processstatus;
                    cmd.Parameters.Add("In_reject_comments", MySqlDbType.VarChar).Value = Details.In_reject_comments;
                    cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = Details.In_status_code;
                    cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Details.In_mode_flag;
                    cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = Details.In_row_timestamp;
                    cmd.Parameters.Add("In_chklist_status_flag", MySqlDbType.VarChar).Value = Details.In_chklist_status_flag;
                    cmd.Parameters.Add("In_sr_comments", MySqlDbType.VarChar).Value = Details.In_sr_comments;
                    cmd.Parameters.Add("In_fpoorgn_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_fpoorgn_code;
                    cmd.Parameters.Add("In_process_status", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_process_status;
                    cmd.Parameters.Add("In_Approval_date", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_Approval_date;
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
                        ObjSaveDoc.context.Header.In_process_status = ObjContext.document.context.Header.In_process_status;
                        ObjSaveDoc.context.Header.In_Approval_date = ObjContext.document.context.Header.In_Approval_date;
                    }
                }

                mysqltrans.Commit();


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
