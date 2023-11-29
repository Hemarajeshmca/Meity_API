using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace FFI_DataModel
{
   public class FISDublicateReq_DB
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInvoice_DataModel)); //Declaring Log4Net. 
        string methodName = "";

        public FISDublicateReqApplication Getservice_req_duplicate_DB(FISDublicateReqContext ObjContext, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            FISDublicateReqApplication ObjFetchAll = new FISDublicateReqApplication();
            ObjFetchAll.context = new FISDublicateReqContext();
            ObjFetchAll.context.Header = new FISDublicateReqHeader();
            try
            {
                MySqlCommand cmd = new MySqlCommand("FIS_fetch_service_request_duplicate", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("IOU_servicereq_rowid", MySqlDbType.Int32).Value = ObjContext.Header.IOU_servicereq_rowid;
                cmd.Parameters.Add("IOU_fpomember_code", MySqlDbType.VarChar).Value = ObjContext.Header.IOU_fpomember_code;
                cmd.Parameters.Add("IOU_servicereq_no", MySqlDbType.VarChar).Value = ObjContext.Header.IOU_servicereq_no;

                cmd.Parameters.Add(new MySqlParameter("IOU_servicereq_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_fpomember_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_servicereq_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_farmer_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_dup_certificate_reason", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;             
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_chklist_status_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_sr_comments", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                ObjFetchAll.context.orgnId = ObjContext.orgnId;
                ObjFetchAll.context.locnId = ObjContext.locnId;
                ObjFetchAll.context.userId = ObjContext.userId;
                ObjFetchAll.context.localeId = ObjContext.localeId;

                ObjFetchAll.context.Header.IOU_servicereq_rowid = (Int32)cmd.Parameters["IOU_servicereq_rowid1"].Value;
                ObjFetchAll.context.Header.IOU_fpomember_code = (string)cmd.Parameters["IOU_fpomember_code"].Value.ToString();
                ObjFetchAll.context.Header.IOU_servicereq_no = (string)cmd.Parameters["IOU_servicereq_no"].Value.ToString();
                ObjFetchAll.context.Header.In_farmer_code = (string)cmd.Parameters["In_farmer_code"].Value.ToString();
                ObjFetchAll.context.Header.In_dup_certificate_reason = (string)cmd.Parameters["In_dup_certificate_reason"].Value.ToString();            
                ObjFetchAll.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                ObjFetchAll.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_chklist_status_flag = (string)cmd.Parameters["In_chklist_status_flag"].Value.ToString();
                ObjFetchAll.context.Header.In_sr_comments = (string)cmd.Parameters["In_sr_comments"].Value.ToString();
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
        public FISDublicateReqSDocument SavenewServiceRequestDuplicate_DB(FISDublicateReqSApplication ObjContext, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            int ret = 0;
            MysqlCon = new DataConnection(mysqlcon);
            FISDublicateReqSDocument objProcessDoc = new FISDublicateReqSDocument();
            objProcessDoc.context = new FISDublicateReqSContext();
            objProcessDoc.context.Header = new FISDublicateReqSHeader();
            objProcessDoc.ApplicationException = new FISDublicateReqSApplicationException();
            string errorNo = "";
            string errorMsg = "";
            try
            {
                MySqlCommand cmd = new MySqlCommand("FIS_insupd_Service_Request_duplicate", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("In_fpomember_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_fpomember_code;
                cmd.Parameters.Add("In_farmer_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_farmer_code;
                cmd.Parameters.Add("In_dup_certificate_reason", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_dup_certificate_reason;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_chklist_status_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_chklist_status_flag;
                cmd.Parameters.Add("In_sr_comments", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_sr_comments;        
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_row_timestamp;


                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmd.Parameters.Add("IOU_servicereq_rowid", MySqlDbType.Int32).Value = ObjContext.document.context.Header.IOU_servicereq_rowid;
                cmd.Parameters.Add("IOU_servicereq_no", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_servicereq_no;

                cmd.Parameters.Add(new MySqlParameter("IOU_servicereq_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_servicereq_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

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

                    objProcessDoc.context.Header.IOU_servicereq_rowid = (Int32)cmd.Parameters["IOU_servicereq_rowid1"].Value;
                    objProcessDoc.context.Header.IOU_servicereq_no = (string)cmd.Parameters["IOU_servicereq_no1"].Value.ToString();
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
                // throw ex;
            }

            return objProcessDoc;

        }
    }
}
