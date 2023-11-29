using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using static FFI_Model.LRS_FPOLoanModel;

namespace FFI_DataModel
{
   
    public class LRS_FPOLoanDataModel
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(LRS_FPOLoanDataModel)); //Declaring Log4Net. 
        string methodName = MethodBase.GetCurrentMethod().Name;

        public LRSFpoLoanApplication GetAllLoanFPO_DB(LRSFpoLoanContext objlrs, string mysqlcon)
        {
            DataTable dt = new DataTable();
            LRSFpoLoanApplication objLrsRoot = new LRSFpoLoanApplication();
            LRS_FPOLoanDataModel objDataModel = new LRS_FPOLoanDataModel();
            objLrsRoot.context = new LRSFpoLoanContext();
            objLrsRoot.context.List = new List<LRSFpoLoanList>();
            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("LRS_fetch_fpoloan_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objlrs.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objlrs.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objlrs.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objlrs.localeId;
                cmd.Parameters.Add("in_filterby_option", MySqlDbType.VarChar).Value = objlrs.FilterBy_Option;
                cmd.Parameters.Add("in_filterby_code", MySqlDbType.VarChar).Value = objlrs.FilterBy_Code;
                cmd.Parameters.Add("in_filterby_fromvalue", MySqlDbType.VarChar).Value = objlrs.FilterBy_FromValue;
                cmd.Parameters.Add("in_filterby_tovalue", MySqlDbType.VarChar).Value = objlrs.FilterBy_ToValue;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);

                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    LRSFpoLoanList objList = new LRSFpoLoanList();
                    objList.Out_fpoloan_rowid = Convert.ToInt32(dt.Rows[i]["Out_fpoloan_rowid"]);
                    objList.Out_fpoorgn_code = dt.Rows[i]["Out_fpoorgn_code"].ToString();
                    objList.Out_fpoloan_no = dt.Rows[i]["Out_fpoloan_no"].ToString();
                    objList.Out_lending_institution=dt.Rows[i]["Out_lending_institution"].ToString();
                    objList.Out_institution_type = dt.Rows[i]["Out_institution_type"].ToString();
                    objList.Out_institution_type_desc = dt.Rows[i]["Out_institution_type_desc"].ToString();
                    objList.Out_sanctioned_date = dt.Rows[i]["Out_sanctioned_date"].ToString();
                    objList.Out_fpoloan_start_date = dt.Rows[i]["Out_fpoloan_start_date"].ToString();
                    objList.Out_fpoloan_mat_date = dt.Rows[i]["Out_fpoloan_mat_date"].ToString();
                    objList.Out_sanctioned_amount = dt.Rows[i]["Out_sanctioned_amount"].ToString();
                    objList.Out_received_amount = dt.Rows[i]["Out_received_amount"].ToString();
                    objList.Out_emi_amount = dt.Rows[i]["Out_emi_amount"].ToString();
                    objList.Out_interest_rate = dt.Rows[i]["Out_interest_rate"].ToString();
                    objList.Out_repayment_in_yrs = dt.Rows[i]["Out_repayment_in_yrs"].ToString();
                    objList.Out_repayment_in_months = dt.Rows[i]["Out_repayment_in_months"].ToString();
                    objList.Out_repayment_freq = dt.Rows[i]["Out_repayment_freq"].ToString();
                    objList.Out_repayment_freq_desc = dt.Rows[i]["Out_repayment_freq_desc"].ToString();
                    objList.Out_collateral_type = dt.Rows[i]["Out_collateral_type"].ToString();
                    objList.Out_collateral_type_desc = dt.Rows[i]["Out_collateral_type_desc"].ToString();
                    objList.Out_collateral_amount = dt.Rows[i]["Out_collateral_amount"].ToString();
                    objList.Out_payable_amount = dt.Rows[i]["Out_payable_amount"].ToString();
                    objList.Out_payable_exception = dt.Rows[i]["Out_payable_exception"].ToString();
                    objList.Out_interest_amount = dt.Rows[i]["Out_interest_amount"].ToString();
                    objList.Out_interest_paid = dt.Rows[i]["Out_interest_paid"].ToString();
                    objList.Out_refund_received = dt.Rows[i]["Out_refund_received"].ToString();
                    objList.Out_closed_date = dt.Rows[i]["Out_closed_date"].ToString();
                    objList.Out_settlement_amount = dt.Rows[i]["Out_settlement_amount"].ToString();
                    objList.Out_waive_amount = dt.Rows[i]["Out_waive_amount"].ToString();
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.Out_status_desc = dt.Rows[i]["Out_status_desc"].ToString();
                    objLrsRoot.context.List.Add(objList);
                }
                objLrsRoot.context.orgnId = objlrs.orgnId;
                objLrsRoot.context.locnId = objlrs.locnId;
                objLrsRoot.context.localeId = objlrs.localeId;
                objLrsRoot.context.userId = objlrs.userId;
                objLrsRoot.context.FilterBy_Code = objlrs.FilterBy_Code;
                objLrsRoot.context.FilterBy_FromValue = objlrs.FilterBy_FromValue;
                objLrsRoot.context.FilterBy_Option = objlrs.FilterBy_Option;
                objLrsRoot.context.FilterBy_ToValue = objlrs.FilterBy_ToValue;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objlrs.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objLrsRoot;
        }
        public LRSFpoLoanFApplication GetSingleLRSFpoLoanfetch_DB(LRSFpoLoanFContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            MysqlCon = new DataConnection(mysqlcon);
            LRSFpoLoanFApplication ObjlrsFRoot = new LRSFpoLoanFApplication();
            LRS_FPOLoanDataModel objDataModel = new LRS_FPOLoanDataModel();
            DataTable LRSFPOLoanTranche = new DataTable();
            DataTable LRSFPOLoanRepayment = new DataTable();
            DataTable Header = new DataTable();

            ObjlrsFRoot.context = new LRSFpoLoanFContext();
            ObjlrsFRoot.context.Header = new LRSFpoLoanFHeader();
            ObjlrsFRoot.context.Header.LRSFPOLoanTranche = new List<LRSFpoLoanTranche>();
            ObjlrsFRoot.context.Header.LRSFPOLoanRepayment = new List<LRSFpoLoanRepayment>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("LRS_fetch_fpoloan_detail", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("IOU_fpoloan_rowid", MySqlDbType.Int32).Value = ObjContext.IOU_fpoloan_rowid;
                cmd.Parameters.Add("IOU_fpoloan_no", MySqlDbType.VarChar).Value = ObjContext.In_fpoloan_no;

                cmd.Parameters.Add(new MySqlParameter("In_fpoorgn_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_fpoloan_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_Institution_lending", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_institution_type", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_institution_type_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_sanctioned_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_fpoloan_start_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_fpoloan_mat_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_Loan_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_received_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_emi_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_interest_rate", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_repayment_in_yrs", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_repayment_in_months", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_repayment_freq", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_repayment_freq_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_collateral_type", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_collateral_type_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_collateral_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_payable_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_payable_exception", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_interest_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_principle_paid", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_interest_paid", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_refund_received", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_closed_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_settlement_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_waive_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_lend_balance_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_balance_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
               // cmd.Parameters.Add(new MySqlParameter("IOU_fpoloan_rowid", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);

                MysqlCon.con.Close();

                if (ds.Tables.Count > 0)
                {
                    LRSFPOLoanTranche = ds.Tables[0];
                    LRSFPOLoanRepayment = ds.Tables[1];
                   

                    for (int i = 0; i < LRSFPOLoanTranche.Rows.Count; i++)
                    {
                        LRSFpoLoanTranche objLrsTList = new LRSFpoLoanTranche();
                        objLrsTList.In_fpoloantranche_rowid = Convert.ToInt32(LRSFPOLoanTranche.Rows[i]["In_fpoloantranche_rowid"]);
                        objLrsTList.In_fpoloan_no = LRSFPOLoanTranche.Rows[i]["In_fpoloan_no"].ToString();
                        objLrsTList.In_tranche_no = LRSFPOLoanTranche.Rows[i]["In_tranche_no"].ToString();
                        objLrsTList.In_tranche_amount = Convert.ToDouble(LRSFPOLoanTranche.Rows[i]["In_tranche_amount"]);
                        objLrsTList.In_received_date = LRSFPOLoanTranche.Rows[i]["In_received_date"].ToString();
                        objLrsTList.In_status_code = LRSFPOLoanTranche.Rows[i]["In_status_code"].ToString();
                        objLrsTList.In_status_desc = LRSFPOLoanTranche.Rows[i]["In_status_desc"].ToString();
                        objLrsTList.In_row_timestamp = LRSFPOLoanTranche.Rows[i]["In_row_timestamp"].ToString();
                        objLrsTList.In_mode_flag = LRSFPOLoanTranche.Rows[i]["In_mode_flag"].ToString();
                        ObjlrsFRoot.context.Header.LRSFPOLoanTranche.Add(objLrsTList);
                    }
                    for (int i = 0; i < LRSFPOLoanRepayment.Rows.Count; i++)
                    {
                        LRSFpoLoanRepayment objFpoLoanRList = new LRSFpoLoanRepayment();
                        objFpoLoanRList.In_loanrepayment_rowid = Convert.ToInt32(LRSFPOLoanRepayment.Rows[i]["In_loanrepayment_rowid"]);
                        objFpoLoanRList.In_loaninstalment_rowid = Convert.ToInt32(LRSFPOLoanRepayment.Rows[i]["In_loaninstalment_rowid"]);
                        objFpoLoanRList.In_fpoloan_no = LRSFPOLoanRepayment.Rows[i]["In_fpoloan_no"].ToString();
                        objFpoLoanRList.In_instalment_date = LRSFPOLoanRepayment.Rows[i]["In_instalment_date"].ToString();
                        objFpoLoanRList.In_instalment_amount = Convert.ToDouble(LRSFPOLoanRepayment.Rows[i]["In_instalment_amount"]);
                        objFpoLoanRList.In_penalty_amount = Convert.ToDouble(LRSFPOLoanRepayment.Rows[i]["In_penalty_amount"]);
                        objFpoLoanRList.In_waiver_amount = Convert.ToDouble(LRSFPOLoanRepayment.Rows[i]["In_waiver_amount"]);
                        objFpoLoanRList.In_paid_date = LRSFPOLoanRepayment.Rows[i]["In_paid_date"].ToString();
                        objFpoLoanRList.In_payment_mode = LRSFPOLoanRepayment.Rows[i]["In_payment_mode"].ToString();
                        objFpoLoanRList.In_payment_mode_desc = LRSFPOLoanRepayment.Rows[i]["In_payment_mode_desc"].ToString();
                        objFpoLoanRList.In_bank_code = LRSFPOLoanRepayment.Rows[i]["In_bank_code"].ToString();
                        objFpoLoanRList.In_bank_acc_type = LRSFPOLoanRepayment.Rows[i]["In_bank_acc_type"].ToString();
                        objFpoLoanRList.In_bank_acc_type_desc = LRSFPOLoanRepayment.Rows[i]["In_bank_acc_type_desc"].ToString();
                        objFpoLoanRList.In_bank_acc_no = LRSFPOLoanRepayment.Rows[i]["In_bank_acc_no"].ToString();
                        objFpoLoanRList.In_bank_ifsc_code = LRSFPOLoanRepayment.Rows[i]["In_bank_ifsc_code"].ToString();
                        objFpoLoanRList.In_bank_ref_no = LRSFPOLoanRepayment.Rows[i]["In_bank_ref_no"].ToString();
                        objFpoLoanRList.In_chq_date = LRSFPOLoanRepayment.Rows[i]["In_chq_date"].ToString();
                        objFpoLoanRList.In_chq_no = LRSFPOLoanRepayment.Rows[i]["In_chq_no"].ToString();
                        objFpoLoanRList.In_micr_code = LRSFPOLoanRepayment.Rows[i]["In_micr_code"].ToString();
                        objFpoLoanRList.In_chq_valid_flag = LRSFPOLoanRepayment.Rows[i]["In_chq_valid_flag"].ToString();
                        objFpoLoanRList.In_repayment_remark = LRSFPOLoanRepayment.Rows[i]["In_repayment_remark"].ToString();
                        objFpoLoanRList.In_repayment_status = LRSFPOLoanRepayment.Rows[i]["In_repayment_status"].ToString();
                        objFpoLoanRList.In_repayment_status_desc = LRSFPOLoanRepayment.Rows[i]["In_repayment_status_desc"].ToString();
                        objFpoLoanRList.In_instalment_no = LRSFPOLoanRepayment.Rows[i]["In_instalment_no"].ToString();
                        objFpoLoanRList.In_principle_amount = Convert.ToDouble(LRSFPOLoanRepayment.Rows[i]["In_principle_amount"]); 
                        objFpoLoanRList.In_interest_amount = Convert.ToDouble(LRSFPOLoanRepayment.Rows[i]["In_interest_amount"]); 
                        objFpoLoanRList.In_lend_balance_amount=Convert.ToDouble(LRSFPOLoanRepayment.Rows[i]["In_lend_balance_amount"]);
                        objFpoLoanRList.In_status_code = LRSFPOLoanRepayment.Rows[i]["In_status_code"].ToString();
                        objFpoLoanRList.In_status_desc = LRSFPOLoanRepayment.Rows[i]["In_status_desc"].ToString();
                        objFpoLoanRList.In_row_timestamp = LRSFPOLoanRepayment.Rows[i]["In_row_timestamp"].ToString();
                        objFpoLoanRList.In_mode_flag = LRSFPOLoanRepayment.Rows[i]["In_mode_flag"].ToString();


                        ObjlrsFRoot.context.Header.LRSFPOLoanRepayment.Add(objFpoLoanRList);
                    }
                }
                ObjlrsFRoot.context.orgnId = ObjContext.orgnId;
                ObjlrsFRoot.context.locnId = ObjContext.locnId;
                ObjlrsFRoot.context.userId = ObjContext.userId;
                ObjlrsFRoot.context.localeId = ObjContext.localeId;

                ObjlrsFRoot.context.Header.IOU_fpoloan_rowid = (Int32)cmd.Parameters["IOU_fpoloan_rowid"].Value;
                ObjlrsFRoot.context.Header.In_fpoorgn_code = (string)cmd.Parameters["In_fpoorgn_code"].Value.ToString();
                ObjlrsFRoot.context.Header.In_fpoloan_no = (string)cmd.Parameters["In_fpoloan_no"].Value.ToString();
                ObjlrsFRoot.context.Header.In_Institution_lending = (string)cmd.Parameters["In_Institution_lending"].Value.ToString();
                ObjlrsFRoot.context.Header.In_institution_type = (string)cmd.Parameters["In_institution_type"].Value.ToString();
                ObjlrsFRoot.context.Header.In_institution_type_desc = (string)cmd.Parameters["In_institution_type_desc"].Value.ToString();
                ObjlrsFRoot.context.Header.In_sanctioned_date = (string)cmd.Parameters["In_sanctioned_date"].Value.ToString();
                ObjlrsFRoot.context.Header.In_fpoloan_start_date = (string)cmd.Parameters["In_fpoloan_start_date"].Value.ToString();
                ObjlrsFRoot.context.Header.In_fpoloan_mat_date = (string)cmd.Parameters["In_fpoloan_mat_date"].Value.ToString();
                ObjlrsFRoot.context.Header.In_Loan_amount = (double)cmd.Parameters["In_Loan_amount"].Value;
                ObjlrsFRoot.context.Header.In_received_amount = (double)cmd.Parameters["In_received_amount"].Value;
                ObjlrsFRoot.context.Header.In_emi_amount = (double)cmd.Parameters["In_emi_amount"].Value;
                ObjlrsFRoot.context.Header.In_interest_rate = (double)cmd.Parameters["In_interest_rate"].Value;
                ObjlrsFRoot.context.Header.In_repayment_in_yrs = (int)cmd.Parameters["In_repayment_in_yrs"].Value;
                ObjlrsFRoot.context.Header.In_repayment_in_months = (int)cmd.Parameters["In_repayment_in_months"].Value;
                ObjlrsFRoot.context.Header.In_repayment_freq = (string)cmd.Parameters["In_repayment_freq"].Value.ToString();
                ObjlrsFRoot.context.Header.In_repayment_freq_desc = (string)cmd.Parameters["In_repayment_freq_desc"].Value.ToString();
                ObjlrsFRoot.context.Header.In_collateral_type = (string)cmd.Parameters["In_collateral_type"].Value.ToString();
                ObjlrsFRoot.context.Header.In_collateral_type_desc = (string)cmd.Parameters["In_collateral_type_desc"].Value.ToString();
                ObjlrsFRoot.context.Header.In_collateral_amount = (double)cmd.Parameters["In_collateral_amount"].Value;
                ObjlrsFRoot.context.Header.In_payable_amount = (double)cmd.Parameters["In_payable_amount"].Value;
                ObjlrsFRoot.context.Header.In_payable_exception = (string)cmd.Parameters["In_payable_exception"].Value.ToString();
                ObjlrsFRoot.context.Header.In_interest_amount = (double)cmd.Parameters["In_interest_amount"].Value;
                ObjlrsFRoot.context.Header.In_principle_paid = (double)cmd.Parameters["In_principle_paid"].Value;
                ObjlrsFRoot.context.Header.In_refund_received = (double)cmd.Parameters["In_refund_received"].Value;
                ObjlrsFRoot.context.Header.In_closed_date = (string)cmd.Parameters["In_closed_date"].Value.ToString();
                ObjlrsFRoot.context.Header.In_settlement_amount = (double)cmd.Parameters["In_settlement_amount"].Value;
                ObjlrsFRoot.context.Header.In_waive_amount = (double)cmd.Parameters["In_waive_amount"].Value;
                ObjlrsFRoot.context.Header.In_lend_balance_amount = (double)cmd.Parameters["In_lend_balance_amount"].Value;
                ObjlrsFRoot.context.Header.In_balance_amount = (double)cmd.Parameters["In_balance_amount"].Value;
                ObjlrsFRoot.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                ObjlrsFRoot.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                ObjlrsFRoot.context.Header.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();
                ObjlrsFRoot.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjlrsFRoot;
        }

        public LRSSaveDocument SaveLrsFpoLoanNew(LRSSaveApplication ObjFarmer, string mysqlcon)
        {
            int ret = 0;
            string errorNo = "";
            string errorMsg = "";
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            LRSSaveDocument objsinvoice = new LRSSaveDocument();
            objsinvoice.context = new LRSSaveContext();
            objsinvoice.context.Header = new LRSSaveHeader();
            objsinvoice.ApplicationException = new LRSSaveApplicationException();
            Int32 IOU_fpoloan_rowid1 = 0;

            try
            {

                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                //string[] returnvalues = { };
                MySqlCommand cmd = new MySqlCommand("LRS_insupd_fpoloan", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_fpoorgn_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_fpoorgn_code;
                cmd.Parameters.Add("In_fpoloan_no", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_fpoloan_no;
                cmd.Parameters.Add("In_Institution_lending", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_Institution_lending;
                cmd.Parameters.Add("In_institution_type", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_institution_type;
                cmd.Parameters.Add("In_sanctioned_date", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_sanctioned_date;
                cmd.Parameters.Add("In_Loan_amount", MySqlDbType.Double).Value = ObjFarmer.document.context.Header.In_Loan_amount;
                cmd.Parameters.Add("In_repayment_freq", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_repayment_freq;
                cmd.Parameters.Add("In_interest_rate", MySqlDbType.Double).Value = ObjFarmer.document.context.Header.In_interest_rate;
                cmd.Parameters.Add("In_repayment_in_months", MySqlDbType.Int32).Value = ObjFarmer.document.context.Header.In_repayment_in_months;
                cmd.Parameters.Add("In_collateral_type", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_collateral_type;
                cmd.Parameters.Add("In_collateral_amount", MySqlDbType.Double).Value = ObjFarmer.document.context.Header.In_collateral_amount;
                cmd.Parameters.Add("In_fpoloan_start_date", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_fpoloan_start_date;
                cmd.Parameters.Add("In_received_amount", MySqlDbType.Double).Value = ObjFarmer.document.context.Header.In_received_amount;
                cmd.Parameters.Add("In_repayment_in_yrs", MySqlDbType.Int32).Value = ObjFarmer.document.context.Header.In_repayment_in_yrs;
                cmd.Parameters.Add("In_principle_paid", MySqlDbType.Double).Value = ObjFarmer.document.context.Header.In_principle_paid;
                cmd.Parameters.Add("In_interest_paid", MySqlDbType.Double).Value = ObjFarmer.document.context.Header.In_interest_paid;
                cmd.Parameters.Add("In_balance_amount", MySqlDbType.Double).Value = ObjFarmer.document.context.Header.In_princ_outstanding_amount;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.localeId;
                cmd.Parameters.Add("IOU_fpoloan_rowid", MySqlDbType.Int32).Value = ObjFarmer.document.context.Header.IOU_fpoloan_rowid;

                cmd.Parameters.Add(new MySqlParameter("IOU_fpoloan_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_fpoloan_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                if (ret > 0)
                {
                    IOU_fpoloan_rowid1 = (Int32)cmd.Parameters["IOU_fpoloan_rowid1"].Value;
                    objsinvoice.context.Header.IOU_fpoloan_rowid = Convert.ToInt32(IOU_fpoloan_rowid1);
                    objsinvoice.context.Header.In_fpoloan_no = cmd.Parameters["In_fpoloan_no1"].Value.ToString();
                }
                else
                {
                    errorNo = (string)cmd.Parameters["errorNo"].Value;
                    errorMsg = ObjErrormsg.ErrorMessage(errorNo);
                    mysqltrans.Rollback();
                    objsinvoice.ApplicationException.errorNumber = errorNo.ToString();
                    objsinvoice.ApplicationException.errorDescription = errorMsg.ToString();
                    return objsinvoice;
                }
                string[] result = { errorNo, errorMsg };
                if (objsinvoice.context.Header.IOU_fpoloan_rowid > 0)
                {
                    string resultTranchedetail = "";
                    resultTranchedetail = SaveLRSTranchedetail(ObjFarmer, objsinvoice, mysqlcon, MysqlCon);
                    if (resultTranchedetail != "")
                    {
                        mysqltrans.Rollback();
                        objsinvoice.ApplicationException.errorNumber = resultTranchedetail[0].ToString();
                        objsinvoice.ApplicationException.errorDescription = resultTranchedetail[1].ToString();
                        return objsinvoice;
                    }
                    string resultRepayment = "";
                    resultRepayment = SaveLRSRepaymentdetail(ObjFarmer, objsinvoice, mysqlcon, MysqlCon);
                    if (resultRepayment != "")
                    {
                        mysqltrans.Rollback();
                        objsinvoice.ApplicationException.errorNumber = resultRepayment[0].ToString();
                        objsinvoice.ApplicationException.errorDescription = resultRepayment[1].ToString();
                        return objsinvoice;
                    }
                }
                mysqltrans.Commit();
                return objsinvoice;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                logger.Error("USERNAME :" + ObjFarmer.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return objsinvoice;

            }
        }
        public string SaveLRSTranchedetail(LRSSaveApplication Objmodel, LRSSaveDocument objInvoice, string MysqlCons, DataConnection MysqlCon)
        {
            string result = "";
            string errorNo = "";
            DataTable tab = new DataTable();
            LRSSaveTranche objTranche = new LRSSaveTranche();
            try
            {
                LRS_FPOLoanDataModel objproduct1 = new LRS_FPOLoanDataModel();
                foreach (var Tranche in Objmodel.document.context.Tranche)
                {
                    objTranche.In_fpoloantranche_rowid = Tranche.In_fpoloantranche_rowid;
                    objTranche.In_fpoloan_no = objInvoice.context.Header.In_fpoloan_no;
                    objTranche.In_tranche_no = Tranche.In_tranche_no;
                    objTranche.In_tranche_amount = Tranche.In_tranche_amount;
                    objTranche.In_received_date = Tranche.In_received_date;
                    objTranche.In_status_code = Tranche.In_status_code;
                    objTranche.In_status_desc = Tranche.In_status_desc;
                    objTranche.In_row_timestamp = Tranche.In_row_timestamp;
                    objTranche.In_mode_flag = Tranche.In_mode_flag;
                    errorNo = objproduct1.SaveLRSFPO_LoanTrancheNew(objTranche, objInvoice, Objmodel, MysqlCons, MysqlCon);
                    if (errorNo != "")
                    {
                        break;
                    }
                }
                return errorNo;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return errorNo;
            }
        }
        public string SaveLRSRepaymentdetail(LRSSaveApplication Objmodel, LRSSaveDocument objLrsDoc, string MysqlCons, DataConnection MysqlCon)
        {
            string result = "";
            string errorNo = "";
            DataTable tab = new DataTable();
            LRSSaveRepayment objrepaymentfpoloan = new LRSSaveRepayment();
            try
            {
                LRS_FPOLoanDataModel objproduct1 = new LRS_FPOLoanDataModel();
                foreach (var LrsRepaymentFpoLoan in Objmodel.document.context.Repayment)
                {
                    objrepaymentfpoloan.In_loaninstalment_rowid = LrsRepaymentFpoLoan.In_loaninstalment_rowid;
                    objrepaymentfpoloan.In_loanrepayment_rowid = LrsRepaymentFpoLoan.In_loanrepayment_rowid;
                    objrepaymentfpoloan.In_fpoloan_no = objLrsDoc.context.Header.In_fpoloan_no;
                    objrepaymentfpoloan.In_instalment_no = LrsRepaymentFpoLoan.In_instalment_no;
                    objrepaymentfpoloan.In_instalment_date = LrsRepaymentFpoLoan.In_instalment_date;
                    objrepaymentfpoloan.In_instalment_amount = LrsRepaymentFpoLoan.In_instalment_amount;
                    objrepaymentfpoloan.In_penalty_amount = LrsRepaymentFpoLoan.In_penalty_amount;
                    objrepaymentfpoloan.In_waiver_amount = LrsRepaymentFpoLoan.In_waiver_amount;
                    objrepaymentfpoloan.In_paid_date = LrsRepaymentFpoLoan.In_paid_date;
                    objrepaymentfpoloan.In_payment_mode = LrsRepaymentFpoLoan.In_payment_mode;
                    objrepaymentfpoloan.In_payment_mode_desc = LrsRepaymentFpoLoan.In_payment_mode_desc;
                    objrepaymentfpoloan.In_bank_code = LrsRepaymentFpoLoan.In_bank_code;
                    objrepaymentfpoloan.In_bank_acc_type = LrsRepaymentFpoLoan.In_bank_acc_type;
                    objrepaymentfpoloan.In_bank_acc_type_desc = LrsRepaymentFpoLoan.In_bank_acc_type_desc;
                    objrepaymentfpoloan.In_bank_acc_no = LrsRepaymentFpoLoan.In_bank_acc_no;
                    objrepaymentfpoloan.In_bank_ifsc_code = LrsRepaymentFpoLoan.In_bank_ifsc_code;
                    objrepaymentfpoloan.In_bank_ref_no = LrsRepaymentFpoLoan.In_bank_ref_no;
                    objrepaymentfpoloan.In_chq_date = LrsRepaymentFpoLoan.In_chq_date;
                    objrepaymentfpoloan.In_chq_no = LrsRepaymentFpoLoan.In_chq_no;
                    objrepaymentfpoloan.In_micr_code = LrsRepaymentFpoLoan.In_micr_code;
                    objrepaymentfpoloan.In_chq_valid_flag = LrsRepaymentFpoLoan.In_chq_valid_flag;
                    objrepaymentfpoloan.In_repayment_remark = LrsRepaymentFpoLoan.In_repayment_remark;
                    objrepaymentfpoloan.In_repayment_status = LrsRepaymentFpoLoan.In_repayment_status;
                    objrepaymentfpoloan.In_repayment_status_desc = LrsRepaymentFpoLoan.In_repayment_status_desc;
                    objrepaymentfpoloan.In_principle_amount = LrsRepaymentFpoLoan.In_principle_amount;
                    objrepaymentfpoloan.In_interest_amount = LrsRepaymentFpoLoan.In_interest_amount;
                    objrepaymentfpoloan.In_lend_balance_amount = LrsRepaymentFpoLoan.In_lend_balance_amount;
                    objrepaymentfpoloan.In_status_desc = LrsRepaymentFpoLoan.In_status_desc;
                    objrepaymentfpoloan.In_status_code = LrsRepaymentFpoLoan.In_status_code;
                    objrepaymentfpoloan.In_mode_flag = LrsRepaymentFpoLoan.In_mode_flag;
                    objrepaymentfpoloan.In_row_timestamp = LrsRepaymentFpoLoan.In_row_timestamp;
                    errorNo = objproduct1.SaveLRSFPO_LoanRepayment(objrepaymentfpoloan, objLrsDoc, Objmodel, MysqlCons, MysqlCon);
                }
                return errorNo;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return errorNo;
            }

        }

        public string SaveLRSFPO_LoanTrancheNew(LRSSaveTranche objinvdtl, LRSSaveDocument ObjFarmer, LRSSaveApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {
            string errorNo = "";
            string errorMsg = "";
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("LRS_iud_fpoloan_tranche", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_fpoloantranche_rowid", MySqlDbType.Int32).Value = objinvdtl.In_fpoloantranche_rowid;
                cmd.Parameters.Add("In_fpoloan_no", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.In_fpoloan_no;
                cmd.Parameters.Add("In_tranche_no", MySqlDbType.VarChar).Value = objinvdtl.In_tranche_no;
                cmd.Parameters.Add("In_tranche_amount", MySqlDbType.Double).Value = objinvdtl.In_tranche_amount;
                cmd.Parameters.Add("In_received_date", MySqlDbType.VarChar).Value = objinvdtl.In_received_date;
                cmd.Parameters.Add("In_status_desc", MySqlDbType.VarChar).Value = objinvdtl.In_status_desc;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = objinvdtl.In_status_code;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = objinvdtl.In_row_timestamp;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objinvdtl.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                if (ret == 0)
                {

                    errorNo = (string)cmd.Parameters["errorNo"].Value;
                    errorMsg = ObjErrormsg.ErrorMessage(errorNo);

                }
                return errorNo;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return errorNo;
            }
        }
        public string SaveLRSFPO_LoanRepayment(LRSSaveRepayment objrepdet, LRSSaveDocument ObjFarmer, LRSSaveApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {
            string errorNo = "";
            string errorMsg = "";
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("LRS_iud_fpoloan_repayment", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_loaninstalment_rowid", MySqlDbType.Int32).Value = Convert.ToInt32(objrepdet.In_loaninstalment_rowid);
                cmd.Parameters.Add("In_loanrepayment_rowid", MySqlDbType.Int32).Value = Convert.ToInt32(objrepdet.In_loanrepayment_rowid);
                cmd.Parameters.Add("In_fpoloan_no", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.In_fpoloan_no;
                cmd.Parameters.Add("In_instalment_no", MySqlDbType.VarChar).Value = objrepdet.In_instalment_no;
                cmd.Parameters.Add("In_instalment_date", MySqlDbType.VarChar).Value = objrepdet.In_instalment_date;
                cmd.Parameters.Add("In_instalment_amount", MySqlDbType.Double).Value = objrepdet.In_instalment_amount;
                cmd.Parameters.Add("In_penalty_amount", MySqlDbType.Double).Value = objrepdet.In_penalty_amount;
                cmd.Parameters.Add("In_waiver_amount", MySqlDbType.Double).Value = objrepdet.In_waiver_amount;
                cmd.Parameters.Add("In_paid_date", MySqlDbType.VarChar).Value = objrepdet.In_paid_date;
                cmd.Parameters.Add("In_payment_mode", MySqlDbType.VarChar).Value = objrepdet.In_payment_mode;
                cmd.Parameters.Add("In_payment_mode_desc", MySqlDbType.VarChar).Value = objrepdet.In_payment_mode_desc;
                cmd.Parameters.Add("In_bank_code", MySqlDbType.VarChar).Value = objrepdet.In_bank_code;
                cmd.Parameters.Add("In_bank_acc_type", MySqlDbType.VarChar).Value = objrepdet.In_bank_acc_type;
                cmd.Parameters.Add("In_bank_acc_type_desc", MySqlDbType.VarChar).Value = objrepdet.In_bank_acc_type_desc;
                cmd.Parameters.Add("In_bank_acc_no", MySqlDbType.VarChar).Value = objrepdet.In_bank_acc_no;
                cmd.Parameters.Add("In_bank_ifsc_code", MySqlDbType.VarChar).Value = objrepdet.In_bank_ifsc_code;
                cmd.Parameters.Add("In_bank_ref_no", MySqlDbType.VarChar).Value = objrepdet.In_bank_ref_no;
                cmd.Parameters.Add("In_chq_date", MySqlDbType.VarChar).Value = objrepdet.In_chq_date;
                cmd.Parameters.Add("In_chq_no", MySqlDbType.VarChar).Value = objrepdet.In_chq_no;
                cmd.Parameters.Add("In_micr_code", MySqlDbType.VarChar).Value = objrepdet.In_micr_code;
                cmd.Parameters.Add("In_chq_valid_flag", MySqlDbType.VarChar).Value = objrepdet.In_chq_valid_flag;
                cmd.Parameters.Add("In_repayment_remark", MySqlDbType.VarChar).Value = objrepdet.In_repayment_remark;
                cmd.Parameters.Add("In_repayment_status", MySqlDbType.VarChar).Value = objrepdet.In_repayment_status;
                cmd.Parameters.Add("In_repayment_status_desc", MySqlDbType.VarChar).Value = objrepdet.In_payment_mode_desc;
                cmd.Parameters.Add("In_principle_amount", MySqlDbType.Double).Value = objrepdet.In_principle_amount;
                cmd.Parameters.Add("In_interest_amount", MySqlDbType.Double).Value = objrepdet.In_interest_amount;
                cmd.Parameters.Add("In_lend_balance_amount", MySqlDbType.Double).Value = objrepdet.In_lend_balance_amount;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = objrepdet.In_status_code;
                cmd.Parameters.Add("In_status_desc", MySqlDbType.VarChar).Value = objrepdet.In_status_desc;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = objrepdet.In_row_timestamp;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objrepdet.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                if (ret == 0)
                {

                    errorNo = (string)cmd.Parameters["errorNo"].Value;
                    errorMsg = ObjErrormsg.ErrorMessage(errorNo);

                }
                return errorNo;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return errorNo;
            }
        }
    }
}
