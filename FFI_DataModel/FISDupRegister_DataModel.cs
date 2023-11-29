using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace FFI_DataModel
{
    public class FISDupRegister_DataModel
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FISDupRegister_DataModel)); //Declaring Log4Net. 
        string methodName = "";
        public FISDupRegApplication FetchfisDupRegister(FISDupRegContext objinvoice, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataTable dt = new DataTable();

            FISDupRegApplication objinvoiceRoot = new FISDupRegApplication();
            FISDupRegister_DataModel objDataModel = new FISDupRegister_DataModel();

            objinvoiceRoot.context = new FISDupRegContext();
            objinvoiceRoot.context.Header = new FISDupRegHeader();
            objinvoiceRoot.context.Detail = new List<FISDupRegDetail>();
            
            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("FIS_fetch_Duplicate_register", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
                cmd.Parameters.Add("In_register_rowid", MySqlDbType.Int32).Value = objinvoice.In_register_rowid;
                cmd.Parameters.Add("In_fpoorgn_code", MySqlDbType.VarChar).Value = objinvoice.In_fpoorgn_code;

                cmd.Parameters.Add(new MySqlParameter("In_register_type", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_register_type_desc", MySqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_register_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_register_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_record_count", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();
               
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FISDupRegDetail objList = new FISDupRegDetail();
                    objList.In_servicereq_rowid = Convert.ToInt32(dt.Rows[i]["In_servicereq_rowid"]);
                    objList.In_farmer_code = dt.Rows[i]["In_farmer_code"].ToString();
                    objList.In_fpomember_code = dt.Rows[i]["In_fpomember_code"].ToString();
                    objList.In_member_name = dt.Rows[i]["In_member_name"].ToString();
                    objList.In_member_sur_name = dt.Rows[i]["In_member_sur_name"].ToString();
                    objList.In_certificate_sno = dt.Rows[i]["In_certificate_sno"].ToString();
                    objList.In_issued_date = dt.Rows[i]["In_issued_date"].ToString();
                    objList.In_dist_from = Convert.ToInt32(dt.Rows[i]["In_dist_from"]);
                    objList.In_dist_to = Convert.ToInt32(dt.Rows[i]["In_dist_to"]);
                    objList.In_servicereq_no = dt.Rows[i]["In_servicereq_no"].ToString();
                    objList.In_request_date = dt.Rows[i]["In_request_date"].ToString();
                    objList.In_request_type = dt.Rows[i]["In_request_type"].ToString();
                    objList.In_request_type_desc = dt.Rows[i]["In_request_type_desc"].ToString();
                    objList.In_requestsub_type = dt.Rows[i]["In_requestsub_type"].ToString();
                    objList.In_requestsub_type_desc = dt.Rows[i]["In_requestsub_type_desc"].ToString();
                    objList.In_chklist_status_flag = dt.Rows[i]["In_chklist_status_flag"].ToString();
                    objList.In_sr_comments = dt.Rows[i]["In_sr_comments"].ToString();
                    objList.In_status_code = dt.Rows[i]["In_status_code"].ToString();
                    objList.In_status_desc = dt.Rows[i]["In_status_desc"].ToString();
                    objList.In_mode_flag = dt.Rows[i]["In_mode_flag"].ToString();
                    objList.In_row_timestamp = dt.Rows[i]["In_row_timestamp"].ToString();
                    objinvoiceRoot.context.Detail.Add(objList);
                }
                objinvoiceRoot.context.Header.In_register_type = (string)cmd.Parameters["In_register_type"].Value.ToString();
                objinvoiceRoot.context.Header.In_register_type_desc = (string)cmd.Parameters["In_register_type_desc"].Value.ToString();
                objinvoiceRoot.context.Header.In_register_no = (string)cmd.Parameters["In_register_no"].Value.ToString();
                objinvoiceRoot.context.Header.In_register_date = (string)cmd.Parameters["In_register_date"].Value.ToString();
                objinvoiceRoot.context.Header.In_record_count = (Int32)cmd.Parameters["In_record_count"].Value;
                objinvoiceRoot.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                objinvoiceRoot.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                objinvoiceRoot.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                objinvoiceRoot.context.Header.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objinvoice.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //  throw ex;
            }
            return objinvoiceRoot;
        }

        public SFISDupRegDocument newDuplicateRegister(SFISDupRegApplication ObjICDStock, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            SFISDupRegDocument ObjFarmer = new SFISDupRegDocument();
            ObjFarmer.context = new SFISDupRegContext();
            ObjFarmer.context.Header = new SFISDupRegHeader();
            ObjFarmer.context.Detail = new List<SFISDupRegDetail>();
            try
            {
                int ret = 0; 
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                MySqlCommand cmd = new MySqlCommand("FIS_insupd_duplicate_register ", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("IOU_register_rowid", MySqlDbType.Int32).Value = ObjICDStock.document.context.Header.IOU_register_rowid;
                cmd.Parameters.Add("IOU_register_no", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.IOU_register_no;
                cmd.Parameters.Add("In_fpoorgn_code", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_fpoorgn_code;
                cmd.Parameters.Add("In_register_type", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_register_type;
                cmd.Parameters.Add("In_register_date", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_register_date;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("IOU_register_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_register_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                ObjFarmer.context.orgnId = ObjICDStock.document.context.orgnId;
                ObjFarmer.context.locnId = ObjICDStock.document.context.locnId;
                ObjFarmer.context.userId = ObjICDStock.document.context.userId;
                ObjFarmer.context.localeId = ObjICDStock.document.context.localeId;

                if (ret > 0)
                {                    

                    ObjFarmer.context.Header.IOU_register_rowid = (Int32)cmd.Parameters["IOU_register_rowid1"].Value;
                    ObjFarmer.context.Header.IOU_register_no = (string)cmd.Parameters["IOU_register_no1"].Value.ToString();
                }
                else
                {                   

                    ObjFarmer.context.Header.IOU_register_rowid = ObjICDStock.document.context.Header.IOU_register_rowid;
                    ObjFarmer.context.Header.IOU_register_no = ObjICDStock.document.context.Header.IOU_register_no;
                }

                foreach (var Kyc in ObjICDStock.document.context.Detail)
                {
                    MySqlCommand cmdS = new MySqlCommand("FIS_iud_duplicate_register", MysqlCon.con);
                    cmdS.CommandType = CommandType.StoredProcedure;
                    cmdS.Parameters.Add("IOU_register_no", MySqlDbType.VarChar).Value = cmd.Parameters["IOU_register_no1"].Value.ToString();
                    cmdS.Parameters.Add("In_fpoorgn_code", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_fpoorgn_code;
                    cmdS.Parameters.Add("In_servicereq_rowid", MySqlDbType.Int32).Value = Kyc.In_servicereq_rowid;
                    cmdS.Parameters.Add("In_farmer_code", MySqlDbType.VarChar).Value = Kyc.In_farmer_code;
                    cmdS.Parameters.Add("In_fpomember_code", MySqlDbType.VarChar).Value = Kyc.In_fpomember_code;
                    cmdS.Parameters.Add("In_member_name", MySqlDbType.VarChar).Value = Kyc.In_member_name;
                    cmdS.Parameters.Add("In_member_sur_name", MySqlDbType.VarChar).Value = Kyc.In_member_sur_name;
                    cmdS.Parameters.Add("In_certificate_sno", MySqlDbType.VarChar).Value = Kyc.In_certificate_sno;
                    cmdS.Parameters.Add("In_issued_date", MySqlDbType.VarChar).Value = Kyc.In_issued_date;
                    cmdS.Parameters.Add("In_dist_from", MySqlDbType.Int32).Value = Kyc.In_dist_from;
                    cmdS.Parameters.Add("In_dist_to", MySqlDbType.Int32).Value = Kyc.In_dist_to;
                    cmdS.Parameters.Add("In_servicereq_no", MySqlDbType.VarChar).Value = Kyc.In_servicereq_no;
                    cmdS.Parameters.Add("In_request_date", MySqlDbType.VarChar).Value = Kyc.In_request_date;
                    cmdS.Parameters.Add("In_request_type", MySqlDbType.VarChar).Value = Kyc.In_request_type;
                    cmdS.Parameters.Add("In_requestsub_type", MySqlDbType.VarChar).Value = Kyc.In_requestsub_type;
                    cmdS.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = Kyc.In_status_code;
                    cmdS.Parameters.Add("In_chklist_status_flag", MySqlDbType.VarChar).Value = Kyc.In_chklist_status_flag;
                    cmdS.Parameters.Add("In_sr_comments", MySqlDbType.VarChar).Value = Kyc.In_sr_comments;
                    cmdS.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Kyc.In_mode_flag;
                    cmdS.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = Kyc.In_row_timestamp;
                    ret = cmdS.ExecuteNonQuery();
                    LogHelper.ConvertCmdIntoString(cmdS);
                }
                mysqltrans.Commit();
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                MysqlCon.con.Close();
                return ObjFarmer;
                // throw ex;
                logger.Error("USERNAME :" + ObjICDStock.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            finally
            {              
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Open)
                {
                    MysqlCon.con.Close();
                }
            }
            return ObjFarmer;
        }

    }
}
