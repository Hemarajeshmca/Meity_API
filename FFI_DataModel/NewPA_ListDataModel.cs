using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static FFI_Model.NewPA_ListModel;

namespace FFI_DataModel
{
   public class NewPA_ListDataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDProduct_DB));
        // Exception Log Method Name Purpose written start 
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public MOBPA_PAYRoot PA_paymentcollectionlist_DB(string org, string locn, string user, string lang, int invoice_rowid, string mysqlcon)
        {
            DataSet ds = new DataSet();

            MysqlCon = new DataConnection(mysqlcon);

            MOBPA_PAYRoot ObjinvRoot = new MOBPA_PAYRoot();
            ICDMOBProduct_datamodel objDataModel = new ICDMOBProduct_datamodel();

            DataTable Detail = new DataTable();
            DataTable Header = new DataTable();

            ObjinvRoot.context = new MOBPA_PAYContext();
            ObjinvRoot.context.Header = new MOBPA_PAYHeader();
            ObjinvRoot.context.Detail = new List<MOBPA_PAYDetail>();
            try
            {

                MySqlCommand cmd = new MySqlCommand("NEWPA_fetch_payment_collection_invoice", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("In_invoice_rowid", MySqlDbType.Int32).Value = invoice_rowid;

                cmd.Parameters.Add(new MySqlParameter("In_invoice_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_invoice_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_invoice_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_balance_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                if (ds.Tables.Count > 0)
                {
                    Detail = ds.Tables[0];
                    for (int i = 0; i < Detail.Rows.Count; i++)
                    {
                        MOBPA_PAYDetail objInvpayList = new MOBPA_PAYDetail();
                        objInvpayList.In_paymentcollection_rowid = Convert.ToInt32(Detail.Rows[i]["In_paymentcollection_rowid"]);
                        objInvpayList.In_payment_type = Detail.Rows[i]["In_payment_type"].ToString();
                        objInvpayList.In_payment_type_desc = Detail.Rows[i]["In_payment_type_desc"].ToString();
                        objInvpayList.In_payment_no = Detail.Rows[i]["In_payment_no"].ToString();
                        objInvpayList.In_balance_amount = Convert.ToDouble(Detail.Rows[i]["In_balance_amount"]);
                        objInvpayList.In_payment_amount = Convert.ToDouble(Detail.Rows[i]["In_payment_amount"]);
                        objInvpayList.In_payment_mode = Detail.Rows[i]["In_payment_mode"].ToString();
                        objInvpayList.In_payment_mode_desc = Detail.Rows[i]["In_payment_mode_desc"].ToString();
                        objInvpayList.In_ref_no = Detail.Rows[i]["In_ref_no"].ToString();
                        objInvpayList.In_payment_date = Detail.Rows[i]["In_payment_date"].ToString();
                        objInvpayList.In_process_status = Detail.Rows[i]["In_process_status"].ToString();
                        objInvpayList.In_process_status_desc = Detail.Rows[i]["In_process_status_desc"].ToString();
                        objInvpayList.In_paid_amount = Convert.ToDouble(Detail.Rows[i]["In_paid_amount"]);
                        objInvpayList.In_mode_flag = Detail.Rows[i]["In_mode_flag"].ToString();

                        ObjinvRoot.context.Detail.Add(objInvpayList);
                    }
                }
                ObjinvRoot.context.orgnId = org;
                ObjinvRoot.context.locnId = locn;
                ObjinvRoot.context.userId = user;
                ObjinvRoot.context.localeId = lang;

                ObjinvRoot.context.Header.In_invoice_no = (string)cmd.Parameters["In_invoice_no"].Value;
                ObjinvRoot.context.Header.In_invoice_date = (string)cmd.Parameters["In_invoice_date"].Value.ToString();
                ObjinvRoot.context.Header.In_invoice_amount = (double)cmd.Parameters["In_invoice_amount"].Value;
                ObjinvRoot.context.Header.In_balance_amount = (double)cmd.Parameters["In_balance_amount"].Value;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return ObjinvRoot;
        }

        public PA_SaleApplication GetAllPASaleList_DB(PA_SaleContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();
            PA_SaleApplication objinvoiceRoot = new PA_SaleApplication();
            NewPA_ListDataModel objDataModel = new NewPA_ListDataModel();
            objinvoiceRoot.context = new PA_SaleContext();
            objinvoiceRoot.context.List = new List<PA_SaleList>();
            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("NEWPA_Sale_List", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);

                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PA_SaleList objList = new PA_SaleList();
                    objList.Out_invoice_rowid = Convert.ToInt32(dt.Rows[i]["Out_invoice_rowid"]);
                    objList.Out_agg_code = dt.Rows[i]["Out_agg_code"].ToString();
                    objList.Out_agg_paname = dt.Rows[i]["Out_agg_paname"].ToString();
                    objList.Out_invoice_no = dt.Rows[i]["Out_invoice_no"].ToString();
                    objList.Out_invoice_date = dt.Rows[i]["Out_invoice_date"].ToString();
                    objList.Out_PurchaseOrder_Id = dt.Rows[i]["Out_PurchaseOrder_Id"].ToString();
                    objList.Out_totalinvoice_amount = dt.Rows[i]["Out_totalinvoice_amount"].ToString();
                    objList.Out_balance_amount = dt.Rows[i]["Out_balance_amount"].ToString();
                    objinvoiceRoot.context.List.Add(objList);
                }
                objinvoiceRoot.context.orgnId = objinvoice.orgnId;
                objinvoiceRoot.context.locnId = objinvoice.locnId;
                objinvoiceRoot.context.localeId = objinvoice.localeId;
                objinvoiceRoot.context.userId = objinvoice.userId;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objinvoice.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objinvoiceRoot;
        }

        public PASalePayApplication GetAllPASalePayList_DB(PASalePayContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();
            PASalePayApplication objinvoiceRoot = new PASalePayApplication();
            NewPA_ListDataModel objDataModel = new NewPA_ListDataModel();
            objinvoiceRoot.context = new PASalePayContext();
            objinvoiceRoot.context.List = new List<PASalePayList>();
            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("NewPA_SalePayment_List", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
                cmd.Parameters.Add("sale_no", MySqlDbType.VarChar).Value = objinvoice.sale_no;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);

                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PASalePayList objList = new PASalePayList();
                    objList.Out_pasalepay_rowid = Convert.ToInt32(dt.Rows[i]["Out_pasalepay_rowid"]);
                    objList.Out_pasalepay_no = dt.Rows[i]["Out_pasalepay_no"].ToString();
                    objList.Out_pasalepay_date = dt.Rows[i]["Out_pasalepay_date"].ToString();
                    objList.Out_reference_no = dt.Rows[i]["Out_reference_no"].ToString();
                    objList.Out_paymode = dt.Rows[i]["Out_paymode"].ToString();
                    objList.Out_payment_amount = dt.Rows[i]["Out_payment_amount"].ToString();
                    objList.Out_balance_amount = dt.Rows[i]["Out_balance_amount"].ToString();
                    objList.Out_status = dt.Rows[i]["Out_status"].ToString();
                    objinvoiceRoot.context.List.Add(objList);
                }
                objinvoiceRoot.context.orgnId = objinvoice.orgnId;
                objinvoiceRoot.context.locnId = objinvoice.locnId;
                objinvoiceRoot.context.localeId = objinvoice.localeId;
                objinvoiceRoot.context.userId = objinvoice.userId;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objinvoice.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objinvoiceRoot;
        }
    }
}
