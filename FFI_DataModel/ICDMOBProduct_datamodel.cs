using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
    public class ICDMOBProduct_datamodel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDProduct_DB));
        // Exception Log Method Name Purpose written start 
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public ICDMOBPRoot ICDProduct_List(string org, string locn, string user, string lang, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);
            ICDMOBPRoot ObjFetchAll = new ICDMOBPRoot();
            ObjFetchAll.context = new ICDMOBPContext();
            ObjFetchAll.context.Detail = new List<ICDMOBPDetail>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("ICDMOB_product", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ICDMOBPDetail objList = new ICDMOBPDetail();                   
                    objList.In_product_code = dt.Rows[i]["In_product_code"].ToString();
                    objList.In_product_name = dt.Rows[i]["In_product_name"].ToString();
                    objList.In_productcategory_code = dt.Rows[i]["In_productcategory_code"].ToString();
                    objList.In_productcategory_desc = dt.Rows[i]["In_productcategory_desc"].ToString();
                    objList.In_productsubcategory_code = dt.Rows[i]["In_productsubcategory_code"].ToString();
                    objList.In_productsubcategory_desc = dt.Rows[i]["In_productsubcategory_desc"].ToString();
                    objList.In_uomtype_code = dt.Rows[i]["In_uomtype_code"].ToString();
                    objList.In_uomtype_desc = dt.Rows[i]["In_uomtype_desc"].ToString();
                    objList.In_hsn_code = dt.Rows[i]["In_hsn_code"].ToString();
                    objList.In_hsn_desc = dt.Rows[i]["In_hsn_desc"].ToString();
                    objList.In_base_price = Convert.ToDouble(dt.Rows[i]["In_base_price"]);
                    objList.In_product_tax_verified = dt.Rows[i]["In_product_tax_verified"].ToString();
                    objList.In_value_addproduct_verified = dt.Rows[i]["In_value_addproduct_verified"].ToString();
                    objList.In_current_qty = Convert.ToDouble(dt.Rows[i]["In_current_qty"]);
                    objList.In_cgst = Convert.ToDecimal(dt.Rows[i]["In_cgst"]);
                    objList.In_sgst = Convert.ToDecimal(dt.Rows[i]["In_sgst"]);
                    objList.In_igst = Convert.ToDecimal(dt.Rows[i]["In_igst"]);
                    objList.In_orgn_code = dt.Rows[i]["In_orgn_code"].ToString();
                    objList.In_ic_code = dt.Rows[i]["In_ic_code"].ToString();

                    ObjFetchAll.context.Detail.Add(objList);
                }
               
            }
            catch (Exception ex)
            {
                // throw ex;
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetchAll;
        }

        public MOBPAYRoot paymentcollectionlist_DB(string org, string locn, string user, string lang, int invoice_rowid, string mysqlcon)
        {
            DataSet ds = new DataSet();

            MysqlCon = new DataConnection(mysqlcon);

            MOBPAYRoot ObjinvRoot = new MOBPAYRoot();
            ICDMOBProduct_datamodel objDataModel = new ICDMOBProduct_datamodel();

            DataTable Detail = new DataTable();
            DataTable Header = new DataTable();

            ObjinvRoot.context = new MOBPAYContext();
            ObjinvRoot.context.Header = new MOBPAYHeader();
            ObjinvRoot.context.Detail = new List<MOBPAYDetail>();
            try
            {

                MySqlCommand cmd = new MySqlCommand("ICDMOB_fetch_payment_collection_invoice", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn ;
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
                        MOBPAYDetail objInvpayList = new MOBPAYDetail();
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
    }
}
