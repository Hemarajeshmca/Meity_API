using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace FFI_DataModel
{
    public class FISNameChange_DB
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInvoice_DataModel)); //Declaring Log4Net. 
        string methodName = "";

        public FISNameChangeApplication Getallservice_request_DB(FISNameChangeContext ObjContext, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            FISNameChangeApplication ObjFetchAll = new FISNameChangeApplication();
            ObjFetchAll.context = new FISNameChangeContext();
            ObjFetchAll.context.List = new List<FISNameChangeList>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("FIS_fetch_service_request_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_filterby_option", MySqlDbType.VarChar).Value = ObjContext.Filter.FilterBy_Option;
                cmd.Parameters.Add("In_filterby_code", MySqlDbType.VarChar).Value = ObjContext.Filter.FilterBy_Code;
                cmd.Parameters.Add("In_filterby_fromvalue", MySqlDbType.VarChar).Value = ObjContext.Filter.FilterBy_FromValue;
                cmd.Parameters.Add("In_filterby_tovalue", MySqlDbType.VarChar).Value = ObjContext.Filter.FilterBy_ToValue;
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
                    FISNameChangeList objList = new FISNameChangeList();
                    objList.Out_servicereq_rowid = Convert.ToInt32(dt.Rows[i]["Out_servicereq_rowid"]);
                    objList.Out_farmer_code = dt.Rows[i]["Out_farmer_code"].ToString();
                    objList.Out_fpomember_code = dt.Rows[i]["Out_fpomember_code"].ToString();
                    objList.Out_farmer_name = dt.Rows[i]["Out_farmer_name"].ToString();
                    objList.Out_sur_name = dt.Rows[i]["Out_sur_name"].ToString();
                    objList.Out_certificate_no = dt.Rows[i]["Out_certificate_no"].ToString();
                    objList.Out_issued_date = dt.Rows[i]["Out_issued_date"].ToString();
                    objList.Out_dist_from = Convert.ToInt32(dt.Rows[i]["Out_dist_from"]);
                    objList.Out_dist_to = Convert.ToInt32(dt.Rows[i]["Out_dist_to"]); 
                    objList.Out_servicereq_no = dt.Rows[i]["Out_servicereq_no"].ToString();
                    objList.Out_request_date = dt.Rows[i]["Out_request_date"].ToString();
                    objList.Out_request_type = dt.Rows[i]["Out_request_type"].ToString();
                    objList.Out_request_type_desc = dt.Rows[i]["Out_request_type_desc"].ToString();
                    objList.Out_requestsub_type = dt.Rows[i]["Out_requestsub_type"].ToString();
                    objList.Out_requestsub_type_desc = dt.Rows[i]["Out_requestsub_type_desc"].ToString();
                    objList.Out_chklist_status_flag = dt.Rows[i]["Out_chklist_status_flag"].ToString();
                    objList.Out_sr_comments = dt.Rows[i]["Out_sr_comments"].ToString();
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

        public FISNameChangeFApplication Getservice_req_name_DB(FISNameChangeFContext ObjContext, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            FISNameChangeFApplication ObjFetchAll = new FISNameChangeFApplication();
            ObjFetchAll.context = new FISNameChangeFContext();
            ObjFetchAll.context.Header = new FISNameChangeFHeader();
            try
            {
                    MySqlCommand cmd = new MySqlCommand("FIS_fetch_service_request_name", MysqlCon.con);
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
                    cmd.Parameters.Add(new MySqlParameter("In_cur_farmer_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new MySqlParameter("In_cur_sur_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new MySqlParameter("In_changeto_farmer_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new MySqlParameter("In_changeto_sur_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new MySqlParameter("In_chklist_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
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
                    ObjFetchAll.context.Header.In_cur_farmer_name = (string)cmd.Parameters["In_cur_farmer_name"].Value.ToString();
                    ObjFetchAll.context.Header.In_cur_sur_name = (string)cmd.Parameters["In_cur_sur_name"].Value.ToString();
                    ObjFetchAll.context.Header.In_changeto_farmer_name = (string)cmd.Parameters["In_changeto_farmer_name"].Value.ToString();
                    ObjFetchAll.context.Header.In_changeto_sur_name = (string)cmd.Parameters["In_changeto_sur_name"].Value.ToString();
                    ObjFetchAll.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                    ObjFetchAll.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                    ObjFetchAll.context.Header.In_chklist_status_code = (string)cmd.Parameters["In_chklist_status_code"].Value.ToString();
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
        public FISNameChangeFNApplication Getservice_req_DB(FISNameChangeFNContext ObjContext, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataSet ds = new DataSet();

            MysqlCon = new DataConnection(mysqlcon);

            FISNameChangeFNApplication ObjFarmerRoot = new FISNameChangeFNApplication();
            FISNameChange_DB objDataModel = new FISNameChange_DB();

            DataTable Share_certificate = new DataTable();
            DataTable Request_history = new DataTable();
            DataTable Header = new DataTable();

            ObjFarmerRoot.context = new FISNameChangeFNContext();
            ObjFarmerRoot.context.Header = new FISNameChangeFNHeader();
            ObjFarmerRoot.context.Share_certificate = new List<FISNameChangeFNShare_certificate>();
            ObjFarmerRoot.context.Request_history = new List<FISNameChangeFNRequest_history>();

            try
            {

                MySqlCommand cmd = new MySqlCommand("FIS_fetch_service_request_detail", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;              
                cmd.Parameters.Add("In_fpomember_code", MySqlDbType.VarChar).Value = ObjContext.Header.IOU_fpomember_code;
                cmd.Parameters.Add("In_request_type", MySqlDbType.VarChar).Value = ObjContext.Header.IOU_request_type;

                cmd.Parameters.Add(new MySqlParameter("In_farmer_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_farmer_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_sur_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                if (ds.Tables.Count > 0)
                {
                    Share_certificate = ds.Tables[0];
                    Request_history = ds.Tables[1];


                    for (int i = 0; i < Share_certificate.Rows.Count; i++)
                    {
                        FISNameChangeFNShare_certificate objBankList = new FISNameChangeFNShare_certificate();
                        objBankList.In_certificatedist_rowid = Convert.ToInt32(Share_certificate.Rows[i]["In_certificatedist_rowid"]);
                        objBankList.In_certificate_no = Share_certificate.Rows[i]["In_certificate_no"].ToString();
                        objBankList.In_dist_from = Convert.ToInt32(Share_certificate.Rows[i]["In_dist_from"]);
                        objBankList.In_dist_to = Convert.ToInt32(Share_certificate.Rows[i]["In_dist_to"]); ;
                        objBankList.In_issued_date = Share_certificate.Rows[i]["In_issued_date"].ToString();
                        objBankList.In_status_code = Share_certificate.Rows[i]["In_status_code"].ToString();
                        objBankList.In_status_desc = Share_certificate.Rows[i]["In_status_desc"].ToString();
                       

                        ObjFarmerRoot.context.Share_certificate.Add(objBankList);
                    }
                    for (int i = 0; i < Request_history.Rows.Count; i++)
                    {
                        FISNameChangeFNRequest_history Request_his = new FISNameChangeFNRequest_history();
                        Request_his.In_servicereq_rowid = Convert.ToInt32(Request_history.Rows[i]["In_servicereq_rowid"]);
                        Request_his.In_certificate_no = Request_history.Rows[i]["In_certificate_no"].ToString();
                        Request_his.In_issued_date = Request_history.Rows[i]["In_issued_date"].ToString();
                        Request_his.In_servicereq_no = Request_history.Rows[i]["In_servicereq_no"].ToString();
                        Request_his.In_request_date = Request_history.Rows[i]["In_request_date"].ToString();
                        Request_his.In_request_type = Request_history.Rows[i]["In_request_type"].ToString();
                        Request_his.In_request_type_desc = Request_history.Rows[i]["In_request_type_desc"].ToString();
                        Request_his.In_requestsub_type = Request_history.Rows[i]["In_requestsub_type"].ToString();
                        Request_his.In_requestsub_type_desc = Request_history.Rows[i]["In_requestsub_type_desc"].ToString();
                        Request_his.In_status_code = Request_history.Rows[i]["in_status_code"].ToString();
                        Request_his.In_status_desc = Request_history.Rows[i]["in_status_desc"].ToString();
                       

                        ObjFarmerRoot.context.Request_history.Add(Request_his);
                    }

                }
                ObjFarmerRoot.context.orgnId = ObjContext.orgnId;
                ObjFarmerRoot.context.locnId = ObjContext.locnId;
                ObjFarmerRoot.context.userId = ObjContext.userId;
                ObjFarmerRoot.context.localeId = ObjContext.localeId;

              
                ObjFarmerRoot.context.Header.In_farmer_code = (string)cmd.Parameters["In_farmer_code"].Value.ToString();              
                ObjFarmerRoot.context.Header.In_farmer_name = (string)cmd.Parameters["In_farmer_name"].Value.ToString();
                ObjFarmerRoot.context.Header.In_sur_name = (string)cmd.Parameters["In_sur_name"].Value.ToString();                
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }
            return ObjFarmerRoot;
        }
        public FISNameChangeSDocument Savenewservicerequestname_DB(FISNameChangeSApplication ObjContext, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            int ret = 0;
            MysqlCon = new DataConnection(mysqlcon);
            FISNameChangeSDocument objProcessDoc = new FISNameChangeSDocument();
            objProcessDoc.context = new FISNameChangeSContext();
            objProcessDoc.context.Header = new FISNameChangeSHeader();
            objProcessDoc.ApplicationException = new FISNameChangeSApplicationException();
            string errorNo = "";
            string errorMsg = "";
            try
            {
                MySqlCommand cmd = new MySqlCommand("FIS_insupd_service_request_name", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("In_fpomember_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_fpomember_code;
                cmd.Parameters.Add("In_farmer_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_farmer_code;
                cmd.Parameters.Add("In_cur_farmer_name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_cur_farmer_name;
                cmd.Parameters.Add("In_cur_sur_name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_cur_sur_name;
                cmd.Parameters.Add("In_changeto_farmer_name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_changeto_farmer_name;
                cmd.Parameters.Add("In_changeto_sur_name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_changeto_sur_name;
                cmd.Parameters.Add("In_chklst_status_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_chklst_status_flag;
                cmd.Parameters.Add("In_sr_comments", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_sr_comments;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_status_code;
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
                //throw ex;
            }

            return objProcessDoc;

        }
    }
}
