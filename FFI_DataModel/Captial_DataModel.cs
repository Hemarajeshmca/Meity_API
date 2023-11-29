using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FFI_Model;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;

namespace FFI_DataModel
{
    public class Captial_DataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Captial_DataModel)); //Declaring Log4Net. 

        public CaptialRootObject GetSingleCaptialDtls(CaptialContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            MysqlCon = new DataConnection(mysqlcon);
            int ret = 0;
            CaptialRootObject ObjCaptialRoot = new CaptialRootObject();
            ObjCaptialRoot.context = new CaptialContext();
            ObjCaptialRoot.context.Header = new CaptialHeader();
            try
            {
                MySqlCommand cmd = new MySqlCommand("FIS_fetch_capital", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("IOU_capital_rowid", MySqlDbType.Int32).Value = ObjContext.Filter.captial_rowid;
                cmd.Parameters.Add("IOU_fpoorgn_code", MySqlDbType.VarChar).Value = ObjContext.Filter.fpoorgn_code;

                cmd.Parameters.Add(new MySqlParameter("IOU_capital_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_fpoorgn_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_fpoorgn_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_authorized_capital", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_paid_capital", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_max_shares_per_applicant", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_share_price", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                ret = cmd.ExecuteNonQuery();
                MysqlCon.con.Close();

                ObjCaptialRoot.context.orgnId = ObjContext.orgnId;
                ObjCaptialRoot.context.locnId = ObjContext.locnId;
                ObjCaptialRoot.context.userId = ObjContext.userId;
                ObjCaptialRoot.context.localeId = ObjContext.localeId;
                ObjCaptialRoot.context.Header.IOU_capital_rowid1 = (Int32)cmd.Parameters["IOU_capital_rowid1"].Value;
                ObjCaptialRoot.context.Header.IOU_fpoorgn_code1 = (string)cmd.Parameters["IOU_fpoorgn_code1"].Value.ToString();
                ObjCaptialRoot.context.Header.In_fpoorgn_desc = (string)cmd.Parameters["In_fpoorgn_desc"].Value.ToString();
                ObjCaptialRoot.context.Header.In_authorized_capital = (string)cmd.Parameters["In_authorized_capital"].Value.ToString();
                ObjCaptialRoot.context.Header.In_paid_capital = (string)cmd.Parameters["In_paid_capital"].Value.ToString();
                ObjCaptialRoot.context.Header.In_max_shares_per_applicant = (Int32)cmd.Parameters["In_max_shares_per_applicant"].Value;
                ObjCaptialRoot.context.Header.In_share_price = (string)cmd.Parameters["In_share_price"].Value.ToString();
                ObjCaptialRoot.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                ObjCaptialRoot.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                ObjCaptialRoot.context.Header.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ObjCaptialRoot;
        }
        public CaptialDocument SaveCaptialDtls(CaptialApplication ObjContext, string mysqlcon)
        {
            int ret = 0;
            MysqlCon = new DataConnection(mysqlcon);
            CaptialDocument objCaptialDoc = new CaptialDocument();
            objCaptialDoc.context = new SCaptialContext();
            objCaptialDoc.context.Header = new SCaptialHeader();
            try
            {
                MySqlCommand cmd = new MySqlCommand("FIS_insupd_capital", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add("In_authorized_capital", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_authorized_capital;
                cmd.Parameters.Add("In_paid_capital", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_paid_capital;
                cmd.Parameters.Add("In_max_shares_per_applicant", MySqlDbType.Int32).Value = ObjContext.document.context.Header.In_max_shares_per_applicant;
                cmd.Parameters.Add("In_share_price", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_share_price;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_row_timestamp;       

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;

                cmd.Parameters.Add("IOU_capital_rowid", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_capital_rowid;
                cmd.Parameters.Add("IOU_fpoorgn_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_fpoorgn_code;

                cmd.Parameters.Add(new MySqlParameter("IOU_capital_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_fpoorgn_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
             

                MysqlCon.con.Open();
                ret = cmd.ExecuteNonQuery();
                MysqlCon.con.Close();

                objCaptialDoc.context.orgnId = ObjContext.document.context.orgnId;
                objCaptialDoc.context.locnId = ObjContext.document.context.locnId;
                objCaptialDoc.context.userId = ObjContext.document.context.userId;
                objCaptialDoc.context.localeId = ObjContext.document.context.localeId;
                objCaptialDoc.context.Header.IOU_capital_rowid = (Int32)cmd.Parameters["IOU_capital_rowid1"].Value;
                objCaptialDoc.context.Header.IOU_fpoorgn_code = (string)cmd.Parameters["IOU_fpoorgn_code1"].Value.ToString();
             

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objCaptialDoc;
        }

    }
}
