using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace FFI_DataModel
{
    public class FISDivMupdstatus_DataModel
    { 
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FISDivMupdstatus_DataModel)); //Declaring Log4Net. 
        string methodName = "";
        public fisDMPApplication FillDIVupdate(fisDMPContext objinvoice, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataTable dt = new DataTable();

            fisDMPApplication objinvoiceRoot = new fisDMPApplication(); 
            objinvoiceRoot.context = new fisDMPContext();
            objinvoiceRoot.context.Detail = new List<fisDMPDetail>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("FIS_fetch_dividend_update_status", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
                cmd.Parameters.Add("In_despatch_status", MySqlDbType.VarChar).Value = objinvoice.In_despatch_status;
                cmd.Parameters.Add("In_fpoorgn_code", MySqlDbType.VarChar).Value = objinvoice.In_fpoorgn_code;
                cmd.Parameters.Add("In_despatch_date", MySqlDbType.VarChar).Value = objinvoice.In_despatch_date; 
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close(); 
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    fisDMPDetail objList = new fisDMPDetail();
                    objList.In_dividend_rowid = Convert.ToInt32(dt.Rows[i]["In_dividend_rowid"]);
                    objList.In_share_holder_name = dt.Rows[i]["In_share_holder_name"].ToString();
                    objList.In_certificate_no = dt.Rows[i]["In_certificate_no"].ToString();
                    objList.In_ditinct_from_to = dt.Rows[i]["In_ditinct_from_to"].ToString();
                    objList.In_dividend_amount =Convert.ToDecimal(dt.Rows[i]["In_dividend_amount"]);
                    objList.In_payment_mode = dt.Rows[i]["In_payment_mode"].ToString();
                    objList.In_payment_mode_desc = dt.Rows[i]["In_payment_mode_desc"].ToString();
                    objList.In_despatch_date = dt.Rows[i]["In_despatch_date"].ToString();
                    objList.In_bank_ref_no = dt.Rows[i]["In_bank_ref_no"].ToString();
                    objList.In_despatch_status = dt.Rows[i]["In_despatch_status"].ToString();
                    objList.In_despatch_status_desc = dt.Rows[i]["In_despatch_status_desc"].ToString();
                    objList.In_despatch_remark = dt.Rows[i]["In_despatch_remark"].ToString();
                    objList.In_status_code = dt.Rows[i]["In_status_code"].ToString();
                    objList.In_status_desc = dt.Rows[i]["In_status_desc"].ToString(); 
                    objList.In_mode_flag = dt.Rows[i]["In_mode_flag"].ToString();
                    objList.In_row_timestamp = dt.Rows[i]["In_row_timestamp"].ToString();
                    objinvoiceRoot.context.Detail.Add(objList);
                }

            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objinvoice.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //throw ex;
            }
            return objinvoiceRoot;
        }

        public SfisDMPDocument newDividendUpdateStatus(SfisDMPApplication ObjICDStock, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            SfisDMPDocument ObjFarmer = new SfisDMPDocument();
            ObjFarmer.context = new SfisDMPContext();
            ObjFarmer.context.Header = new SfisDMPHeader();
            ObjFarmer.context.Detail = new List<SfisDMPDetail>();
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
                    MySqlCommand cmdS = new MySqlCommand("FIS_iud_dividend_update_status ", MysqlCon.con);
                    cmdS.CommandType = CommandType.StoredProcedure;
                    cmdS.Parameters.Add("In_fpoorgn_code", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_fpoorgn_code;
                    cmdS.Parameters.Add("In_despatch_status", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_despatch_status;
                    cmdS.Parameters.Add("In_despatch_date", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_despatch_date;
                    cmdS.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.orgnId;
                    cmdS.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.locnId;
                    cmdS.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.userId;
                    cmdS.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.localeId; 
                    cmdS.Parameters.Add("In_dividend_rowid", MySqlDbType.Int32).Value = Kyc.In_dividend_rowid;
                    cmdS.Parameters.Add("In_certificate_no", MySqlDbType.VarChar).Value = Kyc.In_certificate_no;
                    cmdS.Parameters.Add("In_ditinct_from_to", MySqlDbType.VarChar).Value = Kyc.In_ditinct_from_to;
                    cmdS.Parameters.Add("In_dividend_amount", MySqlDbType.Decimal).Value = Kyc.In_dividend_amount;
                    cmdS.Parameters.Add("In_payment_mode", MySqlDbType.VarChar).Value = Kyc.In_payment_mode;
                    cmdS.Parameters.Add("In_despatch_date1", MySqlDbType.VarChar).Value = Kyc.In_despatch_date;
                    cmdS.Parameters.Add("In_bank_ref_no", MySqlDbType.VarChar).Value = Kyc.In_bank_ref_no;
                    cmdS.Parameters.Add("In_despatch_status1", MySqlDbType.VarChar).Value = Kyc.In_despatch_status;
                    cmdS.Parameters.Add("In_despatch_remark", MySqlDbType.VarChar).Value = Kyc.In_despatch_remark;
                    cmdS.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = Kyc.In_status_code;
                    cmdS.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Kyc.In_mode_flag;
                    cmdS.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = Kyc.In_row_timestamp; 
                    cmdS.CommandType = CommandType.StoredProcedure;
                    ret = cmdS.ExecuteNonQuery();
                    LogHelper.ConvertCmdIntoString(cmdS);
                }
                mysqltrans.Commit();
                if (ret > 0)
                {
                    ObjFarmer.context.Header = ObjICDStock.document.context.Header;
                }
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
