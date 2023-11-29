using System;
using System.Collections.Generic;
using System.Text;
using FFI_Model;
using MySql.Data.MySqlClient;
using System.Data;
namespace FFI_DataModel
{
   public class PAWHS_New_PaymentAdvice_Update_DataModel
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHS_New_PaymentAdvice_Update_DataModel)); //Declaring Log4Net.


        //start 
        public PAWHS_New_PaymentAdvice_UpdateApplication all_pawhs_payment_update(PAWHS_New_PaymentAdvice_UpdateContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();

            PAWHS_New_PaymentAdvice_UpdateApplication objinvoiceRoot = new PAWHS_New_PaymentAdvice_UpdateApplication();
            PAWHS_New_PaymentAdvice_Update_DataModel objDataModel = new PAWHS_New_PaymentAdvice_Update_DataModel();

            objinvoiceRoot.context = new PAWHS_New_PaymentAdvice_UpdateContext();
            objinvoiceRoot.context.PaymentDtl = new List<PAWHS_New_PaymentAdvice_UpdatePaymentDtl>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_fetch_payment_update", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
                cmd.Parameters.Add("In_payment_status", MySqlDbType.VarChar).Value = objinvoice.payment_status;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PAWHS_New_PaymentAdvice_UpdatePaymentDtl objList = new PAWHS_New_PaymentAdvice_UpdatePaymentDtl();
                    objList.In_paymentdtl_rowid = Convert.ToInt32(dt.Rows[i]["In_payadvicedtl_rowid"]);
                    objList.In_payment_advice_no = dt.Rows[i]["In_payment_advice_no"].ToString();
                   // objList.In_receipt_id = dt.Rows[i]["In_receipt_id"].ToString();
                    objList.In_farmer_name = dt.Rows[i]["In_farmer_name"].ToString();
                    objList.In_payment_amount = Convert.ToDouble(dt.Rows[i]["In_payment_amount"]);
                    objList.In_payment_date = dt.Rows[i]["In_payment_date"].ToString();
                    objList.In_payment_mode = dt.Rows[i]["In_payment_mode"].ToString();
                    objList.In_payment_mode_desc = dt.Rows[i]["In_payment_mode_desc"].ToString();
                    objList.In_payment_remark = dt.Rows[i]["In_payment_remark"].ToString();
                    objList.In_bank_ref_no = dt.Rows[i]["In_bank_ref_no"].ToString();
                    objList.In_payment_status = dt.Rows[i]["In_payment_status"].ToString();
                    objList.In_payment_status_desc = dt.Rows[i]["In_payment_status_desc"].ToString();
                    objList.In_row_timestamp = dt.Rows[i]["In_row_timestamp"].ToString();
                    objList.In_mode_flag = dt.Rows[i]["In_mode_flag"].ToString();
                    objinvoiceRoot.context.PaymentDtl.Add(objList);
                }
                objinvoiceRoot.context.orgnId = objinvoice.orgnId;
                objinvoiceRoot.context.locnId = objinvoice.locnId;
                objinvoiceRoot.context.localeId = objinvoice.localeId;
                objinvoiceRoot.context.userId = objinvoice.userId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }

        //End


        //Start 

        public PAWHS_New_PaymentAdvice_UpdateSDocument new_pawhs_payment_update(PAWHS_New_PaymentAdvice_UpdateSApplication ObjFarmer, string mysqlcon)
        {
            int ret = 0;

            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            PAWHS_New_PaymentAdvice_UpdateSDocument objsinvoice = new PAWHS_New_PaymentAdvice_UpdateSDocument();
            objsinvoice.context = new PAWHS_New_PaymentAdvice_UpdateSContext();
            string errorNo = "";
            if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
            {
                MysqlCon.con.Open();
                mysqltrans = MysqlCon.con.BeginTransaction();
            }
            PAWHS_New_PaymentAdvice_UpdateSPaymentDtl objinvdtl = new PAWHS_New_PaymentAdvice_UpdateSPaymentDtl();
            try
            {
                PAWHS_New_PaymentAdvice_Update_DataModel objproduct1 = new PAWHS_New_PaymentAdvice_Update_DataModel();
                foreach (var InvoiceDetail in ObjFarmer.document.context.PaymentDtl)
                {
                    objinvdtl.In_paymentdtl_rowid = InvoiceDetail.In_paymentdtl_rowid;
                    objinvdtl.In_payment_advice_no = InvoiceDetail.In_payment_advice_no;
                   // objinvdtl.In_receipt_id = InvoiceDetail.In_receipt_id;
                    objinvdtl.In_farmer_name = InvoiceDetail.In_farmer_name;
                    objinvdtl.In_payment_amount = InvoiceDetail.In_payment_amount;
                    objinvdtl.In_payment_date = InvoiceDetail.In_payment_date;
                    objinvdtl.In_payment_mode = InvoiceDetail.In_payment_mode;
                    objinvdtl.In_payment_remark = InvoiceDetail.In_payment_remark;
                    objinvdtl.In_bank_ref_no = InvoiceDetail.In_bank_ref_no;
                    objinvdtl.In_payment_status = InvoiceDetail.In_payment_status;
                    objinvdtl.In_row_timestamp = InvoiceDetail.In_row_timestamp;
                    objinvdtl.In_mode_flag = InvoiceDetail.In_mode_flag;
                    errorNo = objproduct1.SaveInvoiceDetailNew(objinvdtl, objsinvoice, ObjFarmer, MysqlCon);
                    if (errorNo != "")
                    {
                        mysqltrans.Rollback();
                        return objsinvoice;
                    }
                }

            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                return objsinvoice;
                throw ex;
            }
            mysqltrans.Commit();
            return objsinvoice;

        }

        public string SaveInvoiceDetailNew(PAWHS_New_PaymentAdvice_UpdateSPaymentDtl objinvdtl, PAWHS_New_PaymentAdvice_UpdateSDocument objsinvoice, PAWHS_New_PaymentAdvice_UpdateSApplication Objmodel, DataConnection MysqlCon)
        {
            string errorNo = "";
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_iud_payment_status_update", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_paymentdtl_rowid", MySqlDbType.Int32).Value = objinvdtl.In_paymentdtl_rowid;
                cmd.Parameters.Add("In_payment_advice_no", MySqlDbType.VarChar).Value = objinvdtl.In_payment_advice_no;
               // cmd.Parameters.Add("In_receipt_id", MySqlDbType.VarChar).Value = objinvdtl.In_receipt_id;
                cmd.Parameters.Add("In_farmer_name", MySqlDbType.VarChar).Value = objinvdtl.In_farmer_name;
                cmd.Parameters.Add("In_payment_amount", MySqlDbType.Double).Value = objinvdtl.In_payment_amount;
                cmd.Parameters.Add("In_payment_date", MySqlDbType.VarChar).Value = objinvdtl.In_payment_date;
                cmd.Parameters.Add("In_payment_mode", MySqlDbType.VarChar).Value = objinvdtl.In_payment_mode;
                cmd.Parameters.Add("In_payment_remark", MySqlDbType.VarChar).Value = objinvdtl.In_payment_remark;
                cmd.Parameters.Add("In_bank_ref_no", MySqlDbType.VarChar).Value = objinvdtl.In_bank_ref_no;
                cmd.Parameters.Add("In_payment_status", MySqlDbType.VarChar).Value = objinvdtl.In_payment_status;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = objinvdtl.In_row_timestamp;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objinvdtl.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                ret = cmd.ExecuteNonQuery();
                if (ret == 0)
                {
                    errorNo = "Error";
                }
                return errorNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //End
    }
}
