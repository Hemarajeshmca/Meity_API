using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FFI_Model;
using System.Text.Json;
using System.Reflection;

namespace FFI_DataModel
{
    public class FISshareRefund_DataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FISshareRefund_DataModel)); //Declaring Log4Net. 
        string methodName = "";

        public ShareRefundApplication GetAllsharerefund(ShareRefundContext objstock, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            int ret = 0;
            //string errorNo = "";

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            ShareRefundApplication ObjstockRoot = new ShareRefundApplication();
            ObjstockRoot.context = new ShareRefundContext();
            ObjstockRoot.context.Detail = new List<ShareRefundDetail>();
            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("FIS_fetch_share_refund", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objstock.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objstock.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objstock.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objstock.localeId;
                cmd.Parameters.Add("In_fpoorgn_code", MySqlDbType.VarChar).Value = objstock.In_fpoorgn_code;
                cmd.Parameters.Add("In_refund_status", MySqlDbType.VarChar).Value = objstock.In_refund_status;
                cmd.Parameters.Add("In_refund_date", MySqlDbType.VarChar).Value = objstock.In_refund_date;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ShareRefundDetail objList = new ShareRefundDetail();
                    objList.In_shareapp_rowid = Convert.ToInt32(dt.Rows[i]["In_shareapp_rowid"]);
                    objList.In_refund_rowid = (Int64)(dt.Rows[i]["In_refund_rowid"]);
                    objList.In_shareapp_no = dt.Rows[i]["In_shareapp_no"].ToString();
                    objList.In_shareapp_date = dt.Rows[i]["In_shareapp_date"].ToString();
                    objList.In_member_name = dt.Rows[i]["In_member_name"].ToString();
                    objList.In_farmer_name = dt.Rows[i]["In_farmer_name"].ToString();
                    objList.In_applied_shares = (Int32)dt.Rows[i]["In_applied_shares"];
                    objList.In_rejected_shares = (Int64)dt.Rows[i]["In_rejected_shares"];
                    objList.In_payment_mode = dt.Rows[i]["In_payment_mode"].ToString();
                    objList.In_payment_mode_desc = dt.Rows[i]["In_payment_mode_desc"].ToString();
                    objList.In_refund_date = dt.Rows[i]["In_refund_date"].ToString();
                    objList.In_refund_amount = (decimal)dt.Rows[i]["In_refund_amount"];
                    objList.In_payment_ref_no = dt.Rows[i]["In_payment_ref_no"].ToString();
                    objList.In_status_code = dt.Rows[i]["In_status_code"].ToString();
                    objList.In_status_desc = dt.Rows[i]["In_status_desc"].ToString();
                    objList.In_mode_flag = dt.Rows[i]["In_mode_flag"].ToString();
                    objList.In_row_timestamp = dt.Rows[i]["In_row_timestamp"].ToString();
                    ObjstockRoot.context.Detail.Add(objList);
                }

            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objstock.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }
            return ObjstockRoot;


        }

        public IUSrefundDocument newShareRefund(IUSrefundApplication ObjICDStock, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            int ret = 0;
            string errorNo = "";
            string errorMsg = "";
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            IUSrefundDocument objresICDStock = new IUSrefundDocument();
            objresICDStock.context = new IUSrefundContext();
            objresICDStock.context.Header = new IUSrefundHeader();
            objresICDStock.context.Detail = new List<IUSrefundDetail>();
            string detail_formatted;
            detail_formatted = JsonSerializer.Serialize(ObjICDStock.document.context.Detail);
            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }
                foreach (var Kyc in ObjICDStock.document.context.Detail)
                {

                    MySqlCommand cmd = new MySqlCommand("FIS_iud_share_refund", MysqlCon.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("In_refund_status", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_refund_status;// ObjFarmer.document.context.Header.in_farmer_rowid;
                    cmd.Parameters.Add("In_fpoorgn_code", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_fpoorgn_code;
                    cmd.Parameters.Add("In_refund_date", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_refund_date;
                    cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.orgnId;
                    cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.locnId;
                    cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.userId;
                    cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.localeId;
                    cmd.Parameters.Add("detail_formatted", MySqlDbType.LongText).Value = detail_formatted;
                    cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                    ret = cmd.ExecuteNonQuery();
                    LogHelper.ConvertCmdIntoString(cmd);
                    if (ret == 0)
                    {
                        mysqltrans.Rollback();

                        errorNo = (string)cmd.Parameters["errorNo"].Value;
                        errorMsg = ObjErrormsg.ErrorMessage(errorNo);
                    }
                    else
                    {
                        objresICDStock.context.orgnId = ObjICDStock.document.context.orgnId;
                        objresICDStock.context.userId = ObjICDStock.document.context.userId;
                        objresICDStock.context.locnId = ObjICDStock.document.context.locnId;
                        objresICDStock.context.localeId = ObjICDStock.document.context.localeId;
                        objresICDStock.context.Header.In_fpoorgn_code = ObjICDStock.document.context.Header.In_fpoorgn_code;
                        objresICDStock.context.Header.In_refund_status = ObjICDStock.document.context.Header.In_refund_status;
                    }
                }

                mysqltrans.Commit();


            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                //  throw ex;

                logger.Error("USERNAME :" + ObjICDStock.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }

            return objresICDStock;
        }
    }
}