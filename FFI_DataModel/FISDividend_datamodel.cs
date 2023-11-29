using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace FFI_DataModel
{
   public class FISDividend_datamodel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FarmerReg_DataModel)); //Declaring Log4Net. 
        string methodName = "";
        public FISDividendApplication GetallDividend_DB(FISDividendContext objfarmer, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataTable dt = new DataTable();

            FISDividendApplication ObjFarmerRoot = new FISDividendApplication();
            FISDividend_datamodel objDataModel = new FISDividend_datamodel();

            ObjFarmerRoot.context = new FISDividendContext();
            ObjFarmerRoot.context.List = new List<FISDividendList>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("FIS_fetch_dividend_structure_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfarmer.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfarmer.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfarmer.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfarmer.localeId;
                cmd.Parameters.Add("In_filterby_option", MySqlDbType.VarChar).Value = objfarmer.Filter.FilterBy_Option;
                cmd.Parameters.Add("In_filterby_code", MySqlDbType.VarChar).Value = objfarmer.Filter.FilterBy_Code;
                cmd.Parameters.Add("In_filterby_fromvalue", MySqlDbType.VarChar).Value = objfarmer.Filter.FilterBy_FromValue;
                cmd.Parameters.Add("In_filterby_tovalue", MySqlDbType.VarChar).Value = objfarmer.Filter.FilterBy_ToValue;               
                cmd.Parameters.Add(new MySqlParameter("out_record_count", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.Int32)).Direction = ParameterDirection.Output;


                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FISDividendList objList = new FISDividendList();
                    objList.Out_dividendstru_rowid = Convert.ToInt32(dt.Rows[i]["Out_dividendstru_rowid"]);
                    objList.Out_fpoorgn_code = dt.Rows[i]["Out_fpoorgn_code"].ToString();
                    objList.Out_finyear_code =dt.Rows[i]["Out_finyear_code"].ToString();
                    objList.Out_finyear_desc = dt.Rows[i]["Out_finyear_desc"].ToString();
                    objList.Out_period_from = dt.Rows[i]["Out_period_from"].ToString();
                    objList.Out_period_to = dt.Rows[i]["Out_period_to"].ToString();
                    objList.Out_dividend_type = dt.Rows[i]["Out_dividend_type"].ToString();
                    objList.Out_dividend_type_desc = dt.Rows[i]["Out_dividend_type_desc"].ToString();
                    objList.Out_dividend_percent = Convert.ToDouble(dt.Rows[i]["Out_dividend_percent"]);
                    objList.Out_report_date = dt.Rows[i]["Out_report_date"].ToString();
                    objList.Out_declared_date = dt.Rows[i]["Out_declared_date"].ToString();
                    objList.Out_payor_bank_code = dt.Rows[i]["Out_payor_bank_code"].ToString();
                    objList.Out_payor_bank_desc = dt.Rows[i]["Out_payor_bank_desc"].ToString();
                    objList.Out_payor_bank_acc_type = dt.Rows[i]["Out_payor_bank_acc_type"].ToString();
                    objList.Out_payor_bank_acc_type_desc = dt.Rows[i]["Out_payor_bank_acc_type_desc"].ToString();
                    objList.Out_payor_bank_acc_no = dt.Rows[i]["Out_payor_bank_acc_no"].ToString();
                    objList.Out_payor_ifsc_code = dt.Rows[i]["Out_payor_ifsc_code"].ToString();
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.Out_status_desc = dt.Rows[i]["Out_status_desc"].ToString();
                    objList.Out_row_timestamp = dt.Rows[i]["Out_row_timestamp"].ToString();
                    objList.Out_mode_flag = dt.Rows[i]["Out_mode_flag"].ToString();
                    
                    ObjFarmerRoot.context.List.Add(objList);

                }
                ObjFarmerRoot.context.orgnId = objfarmer.orgnId;
                ObjFarmerRoot.context.locnId = objfarmer.locnId;
                ObjFarmerRoot.context.localeId = objfarmer.localeId;
                ObjFarmerRoot.context.userId = objfarmer.userId;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objfarmer.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }
            return ObjFarmerRoot;
        }
        public FISDividendFApplication GetDividendfetch_DB(FISDividendFContext ObjContext, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataSet ds = new DataSet();

            MysqlCon = new DataConnection(mysqlcon);

            FISDividendFApplication ObjFarmerRoot = new FISDividendFApplication();
            FISDividend_datamodel objDataModel = new FISDividend_datamodel();

            DataTable kycdt = new DataTable();
            DataTable Bankdt = new DataTable();
            DataTable Header = new DataTable();

            ObjFarmerRoot.context = new FISDividendFContext();
            ObjFarmerRoot.context.Header = new FISDividendFHeader();
          

            try
            {

                MySqlCommand cmd = new MySqlCommand("FIS_fetch_dividend_structure", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("IOU_dividendstru_rowid", MySqlDbType.Int32).Value = ObjContext.Header.IOU_dividendstru_rowid;
                cmd.Parameters.Add("IOU_fpoorgn_code", MySqlDbType.VarChar).Value = ObjContext.Header.IOU_fpoorgn_code;
               
                cmd.Parameters.Add(new MySqlParameter("IOU_dividendstru_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_fpoorgn_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_finyear_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_finyear_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_period_from", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_period_to", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_dividend_type", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_dividend_type_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_dividend_percent", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_report_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_declared_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_payor_bank_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_payor_bank_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_payor_bank_acc_type", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_payor_bank_acc_type_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_payor_bank_acc_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_payor_ifsc_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
               
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

               
                ObjFarmerRoot.context.orgnId = ObjContext.orgnId;
                ObjFarmerRoot.context.locnId = ObjContext.locnId;
                ObjFarmerRoot.context.userId = ObjContext.userId;
                ObjFarmerRoot.context.localeId = ObjContext.localeId;

                ObjFarmerRoot.context.Header.IOU_dividendstru_rowid = (Int32)cmd.Parameters["IOU_dividendstru_rowid"].Value;
                ObjFarmerRoot.context.Header.IOU_fpoorgn_code = (string)cmd.Parameters["IOU_fpoorgn_code"].Value.ToString();
                ObjFarmerRoot.context.Header.In_finyear_code = (string)cmd.Parameters["In_finyear_code"].Value.ToString();
                ObjFarmerRoot.context.Header.In_finyear_desc = (string)cmd.Parameters["In_finyear_desc"].Value.ToString();
                ObjFarmerRoot.context.Header.In_period_from = (string)cmd.Parameters["In_period_from"].Value.ToString();
                ObjFarmerRoot.context.Header.In_period_to = (string)cmd.Parameters["In_period_to"].Value.ToString();
                ObjFarmerRoot.context.Header.In_dividend_type = (string)cmd.Parameters["In_dividend_type"].Value.ToString();
                ObjFarmerRoot.context.Header.In_dividend_type_desc = (string)cmd.Parameters["In_dividend_type_desc"].Value.ToString();
                ObjFarmerRoot.context.Header.In_dividend_percent = (double)cmd.Parameters["In_dividend_percent"].Value;
                ObjFarmerRoot.context.Header.In_report_date = (string)cmd.Parameters["In_report_date"].Value.ToString();
                ObjFarmerRoot.context.Header.In_declared_date = (string)cmd.Parameters["In_declared_date"].Value.ToString();
                ObjFarmerRoot.context.Header.In_payor_bank_code = (string)cmd.Parameters["In_payor_bank_code"].Value.ToString();
                ObjFarmerRoot.context.Header.In_payor_bank_desc = (string)cmd.Parameters["In_payor_bank_desc"].Value.ToString();
                ObjFarmerRoot.context.Header.In_payor_bank_acc_type = (string)cmd.Parameters["In_payor_bank_acc_type"].Value.ToString();
                ObjFarmerRoot.context.Header.In_payor_bank_acc_type_desc = (string)cmd.Parameters["In_payor_bank_acc_type_desc"].Value.ToString();
                ObjFarmerRoot.context.Header.In_payor_bank_acc_no = (string)cmd.Parameters["In_payor_bank_acc_no"].Value.ToString();
                ObjFarmerRoot.context.Header.In_payor_ifsc_code = (string)cmd.Parameters["In_payor_ifsc_code"].Value.ToString();
                ObjFarmerRoot.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                ObjFarmerRoot.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                ObjFarmerRoot.context.Header.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();
                ObjFarmerRoot.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();               
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //  throw ex;
            }
            return ObjFarmerRoot;
        }
        public FISDividendSDocument newDividendStructure_DB(FISDividendSApplication ObjContext, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            int ret = 0;
            MysqlCon = new DataConnection(mysqlcon);
            FISDividendSDocument objProcessDoc = new FISDividendSDocument();
            objProcessDoc.context = new FISDividendSContext();
            objProcessDoc.context.Header = new FISDividendSHeader();
            objProcessDoc.ApplicationException = new FISDividendSApplicationException();
            string errorNo = "";
            string errorMsg = "";
            try
            {
                MySqlCommand cmd = new MySqlCommand("FIS_insupd_dividend_structure", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("In_finyear_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_finyear_code;
                cmd.Parameters.Add("In_period_from", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_period_from;
                cmd.Parameters.Add("In_period_to", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_period_to;
                cmd.Parameters.Add("In_dividend_type", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_dividend_type;
                cmd.Parameters.Add("In_dividend_percent", MySqlDbType.Double).Value = ObjContext.document.context.Header.In_dividend_percent;
                cmd.Parameters.Add("In_report_date", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_report_date;
                cmd.Parameters.Add("In_declared_date", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_declared_date;
                cmd.Parameters.Add("In_payor_bank_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_payor_bank_code;
                cmd.Parameters.Add("In_payor_bank_acc_type", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_payor_bank_acc_type;
                cmd.Parameters.Add("In_payor_bank_acc_no", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_payor_bank_acc_no;
                cmd.Parameters.Add("In_payor_ifsc_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_payor_ifsc_code;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_mode_flag;               

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmd.Parameters.Add("IOU_dividendstru_rowid", MySqlDbType.Int32).Value = ObjContext.document.context.Header.IOU_dividendstru_rowid;
                cmd.Parameters.Add("IOU_fpoorgn_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_fpoorgn_code;

                cmd.Parameters.Add(new MySqlParameter("IOU_dividendstru_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_fpoorgn_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
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

                    objProcessDoc.context.Header.IOU_dividendstru_rowid = (Int32)cmd.Parameters["IOU_dividendstru_rowid1"].Value;
                    objProcessDoc.context.Header.IOU_fpoorgn_code = (string)cmd.Parameters["IOU_fpoorgn_code1"].Value.ToString();
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
