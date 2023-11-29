using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FFI_Model;
using System.Reflection;

namespace FFI_DataModel
{
    public class FISsharecertifcatedispatch_DataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FISsharecertifcatedispatch_DataModel)); //Declaring Log4Net. 
        string methodName = "";
        public FsharecertallApplication GetAllshare_pending(FsharecertallContext objstock, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            int ret = 0;
            //string errorNo = "";

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            FsharecertallApplication ObjstockRoot = new FsharecertallApplication();
            FISsharecertifcatedispatch_DataModel objDataModel = new FISsharecertifcatedispatch_DataModel();
            ObjstockRoot.context = new FsharecertallContext();
            ObjstockRoot.context.Detail = new List<FsharecertallDetail>();


            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("FIS_fetch_share_despatch", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_fpoorgn_code", MySqlDbType.VarChar).Value = objstock.fpoorgn_code;
                cmd.Parameters.Add("In_despatch_status", MySqlDbType.VarChar).Value = objstock.despatch_status;
                cmd.Parameters.Add("In_despatch_date", MySqlDbType.VarChar).Value = objstock.despatch_date;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objstock.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objstock.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objstock.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objstock.localeId;


                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FsharecertallDetail objList = new FsharecertallDetail();
                    objList.In_shareapp_rowid = Convert.ToInt32(dt.Rows[i]["In_shareapp_rowid"]);
                    objList.In_shareapp_no = dt.Rows[i]["In_shareapp_no"].ToString();
                    objList.In_shareapp_date = dt.Rows[i]["In_shareapp_date"].ToString();
                    objList.In_fpomember_code = dt.Rows[i]["In_fpomember_code"].ToString();
                    objList.In_farmer_code = dt.Rows[i]["In_farmer_code"].ToString();
                    objList.In_member_name = dt.Rows[i]["In_member_name"].ToString();
                    objList.In_certificate_no = dt.Rows[i]["In_certificate_no"].ToString();
                    objList.In_folio_no = dt.Rows[i]["In_folio_no"].ToString();
                    objList.In_despatch_date = dt.Rows[i]["In_despatch_date"].ToString();
                    objList.In_despatch_awb_no = dt.Rows[i]["In_despatch_awb_no"].ToString();
                    objList.In_process_status = dt.Rows[i]["In_process_status"].ToString();
                    objList.In_process_status_desc = dt.Rows[i]["In_process_status_desc"].ToString();
                    objList.In_despatch_remark = dt.Rows[i]["In_despatch_remark"].ToString();
                    objList.In_despatch_awb_no = dt.Rows[i]["In_despatch_awb_no"].ToString();
                    objList.In_row_timestamp = dt.Rows[i]["In_row_timestamp"].ToString();
                    objList.In_mode_flag = dt.Rows[i]["In_mode_flag"].ToString();
                    ObjstockRoot.context.Detail.Add(objList);
                }
                ObjstockRoot.context.orgnId = objstock.orgnId;
                ObjstockRoot.context.locnId = objstock.locnId;
                ObjstockRoot.context.localeId = objstock.localeId;
                ObjstockRoot.context.userId = objstock.userId;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objstock.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }
            return ObjstockRoot;
        }

        public SavecertDisDocument newCertificateDispatch(SavecertDisApplication ObjICDStock, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            SavecertDisDocument objresICDStock = new SavecertDisDocument();
            objresICDStock.context = new SavecertDisContext();
            objresICDStock.context.Header = new SavecertDisHeader();
            objresICDStock.context.Detail = new List<SavecertDisDetail>();
            string errorNo = "";
            string errorMsg = "";
            try
            {
                int ret = 0;
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }
                foreach (var Kyc in ObjICDStock.document.context.Detail)
                {

                    MySqlCommand cmd = new MySqlCommand("FIS_iud_share_despatch", MysqlCon.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("In_fpoorgn_code", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_fpoorgn_code;// ObjFarmer.document.context.Header.in_farmer_rowid;
                    cmd.Parameters.Add("In_despatch_status", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_despatch_status;
                    cmd.Parameters.Add("In_despatch_date", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_despatch_date;
                    cmd.Parameters.Add("In_shareapp_rowid", MySqlDbType.Int32).Value = Kyc.In_shareapp_rowid;
                    cmd.Parameters.Add("In_shareapp_no", MySqlDbType.VarChar).Value = Kyc.In_shareapp_no;
                    cmd.Parameters.Add("In_fpomember_code", MySqlDbType.VarChar).Value = Kyc.In_fpomember_code;
                    cmd.Parameters.Add("In_farmer_code", MySqlDbType.VarChar).Value = Kyc.In_farmer_code;
                    cmd.Parameters.Add("In_certificate_no", MySqlDbType.VarChar).Value = Kyc.In_certificate_no;
                    cmd.Parameters.Add("In_despatch_date1", MySqlDbType.VarChar).Value = Kyc.In_despatch_date;
                    cmd.Parameters.Add("In_despatch_awb_no", MySqlDbType.VarChar).Value = Kyc.In_despatch_awb_no;
                    cmd.Parameters.Add("In_process_status", MySqlDbType.VarChar).Value = Kyc.In_process_status;
                    cmd.Parameters.Add("In_despatch_remark", MySqlDbType.LongText).Value = Kyc.In_despatch_remark;
                    cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = Kyc.In_row_timestamp;
                    cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Kyc.In_mode_flag;

                    cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.orgnId;
                    cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.locnId;
                    cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.userId;
                    cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.localeId;
                    cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                    ret = cmd.ExecuteNonQuery();
                    LogHelper.ConvertCmdIntoString(cmd);
                    if (ret == 0)
                    {
                        mysqltrans.Rollback();

                        errorNo = (string)cmd.Parameters["errorNo"].Value;
                        errorMsg = ObjErrormsg.ErrorMessage(errorNo);

                        objresICDStock.ApplicationException.errorNumber = (string)cmd.Parameters["errorNo"].Value;
                        objresICDStock.ApplicationException.errorDescription = errorMsg;
                        break;
                    }
                    else
                    {
                        objresICDStock.context.orgnId = ObjICDStock.document.context.orgnId;
                        objresICDStock.context.userId = ObjICDStock.document.context.userId;
                        objresICDStock.context.locnId = ObjICDStock.document.context.locnId;
                        objresICDStock.context.localeId = ObjICDStock.document.context.localeId;
                        objresICDStock.context.Header.In_fpoorgn_code = ObjICDStock.document.context.Header.In_fpoorgn_code;
                        objresICDStock.context.Header.In_despatch_status = ObjICDStock.document.context.Header.In_despatch_status;
                    }
                }

                mysqltrans.Commit();


            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                // throw ex;
                logger.Error("USERNAME :" + ObjICDStock.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }

            return objresICDStock;
        }
    }
}

