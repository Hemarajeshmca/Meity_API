using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace FFI_DataModel
{
    public class PAWHSpaymentadvice_DataModel
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSServiceInvoice_DB)); //Declaring Log4Net. 

        public PAWHSpayadviceApplication allpawhs_payment_advice(PAWHSpayadviceContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();

            PAWHSpayadviceApplication objinvoiceRoot = new PAWHSpayadviceApplication();
            PAWHSServiceInvoice_DB objDataModel = new PAWHSServiceInvoice_DB();

            objinvoiceRoot.context = new PAWHSpayadviceContext();
            objinvoiceRoot.context.List = new List<PAWHSpayadviceList>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_paymentadvice_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
                cmd.Parameters.Add("in_filterby_option", MySqlDbType.VarChar).Value = objinvoice.filterby_option;
                cmd.Parameters.Add("in_filterby_code", MySqlDbType.VarChar).Value = objinvoice.filterby_code;
                cmd.Parameters.Add("in_filterby_fromvalue", MySqlDbType.VarChar).Value = objinvoice.filterby_fromvalue;
                cmd.Parameters.Add("in_filterby_tovalue", MySqlDbType.VarChar).Value = objinvoice.filterby_tovalue;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PAWHSpayadviceList objList = new PAWHSpayadviceList();
                    objList.Out_payment_rowid = Convert.ToInt32(dt.Rows[i]["Out_payment_rowid"]);
                    objList.Out_payment_id = dt.Rows[i]["Out_payment_id"].ToString();
                    objList.Out_date = dt.Rows[i]["Out_date"].ToString();
                    objList.Out_period_from = dt.Rows[i]["Out_period_from"].ToString();
                    objList.Out_period_to = dt.Rows[i]["Out_period_to"].ToString();
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.Out_status_desc = dt.Rows[i]["Out_status_desc"].ToString(); 
                    objinvoiceRoot.context.List.Add(objList);

                }
                objinvoiceRoot.context.orgnId = objinvoice.orgnId;
                objinvoiceRoot.context.locnId = objinvoice.locnId;
                objinvoiceRoot.context.localeId = objinvoice.localeId;
                objinvoiceRoot.context.userId = objinvoice.userId;
                objinvoiceRoot.context.filterby_code = objinvoice.filterby_code;
                objinvoiceRoot.context.filterby_fromvalue = objinvoice.filterby_fromvalue;
                objinvoiceRoot.context.filterby_option = objinvoice.filterby_option;
                objinvoiceRoot.context.filterby_tovalue = objinvoice.filterby_tovalue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }


        public PAWHSpaymentadvice_FApplication Getservice_invoice_DB(PAWHSpaymentadvice_FContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();

            MysqlCon = new DataConnection(mysqlcon);

            PAWHSpaymentadvice_FApplication ObjinvRoot = new PAWHSpaymentadvice_FApplication();
            PAWHSpaymentadvice_DataModel objDataModel = new PAWHSpaymentadvice_DataModel();

            DataTable InvoiceDetail = new DataTable(); 
            DataTable Header = new DataTable();

            ObjinvRoot.context = new PAWHSpaymentadvice_FContext();
            ObjinvRoot.context.Header = new PAWHSpaymentadvice_FHeader();
            ObjinvRoot.context.Detail = new List<PAWHSpaymentadvice_FDetail>(); 

            try
            {

                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_paymentadvice", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("IOU_payment_rowid", MySqlDbType.Int32).Value = ObjContext.payment_rowid;
                cmd.Parameters.Add("IOU_payment_id", MySqlDbType.VarChar).Value = ObjContext.payment_id;
                cmd.Parameters.Add("IOU_from_date", MySqlDbType.VarChar).Value = ObjContext.from_date;
                cmd.Parameters.Add("IOU_to_date", MySqlDbType.VarChar).Value = ObjContext.to_date; 

                cmd.Parameters.Add(new MySqlParameter("IOU_payment_id1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_from_date1", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_to_date1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_payment_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();

                if (ds.Tables.Count > 0)
                {
                    ObjinvRoot.context.Header.IOU_payment_id = (string)cmd.Parameters["IOU_payment_id1"].Value;
                    ObjinvRoot.context.Header.IOU_payment_rowid = (Int32)cmd.Parameters["IOU_payment_rowid1"].Value;
                    ObjinvRoot.context.Header.IOU_from_date = (string)cmd.Parameters["IOU_from_date1"].Value.ToString();
                    ObjinvRoot.context.Header.IOU_to_date = (string)cmd.Parameters["IOU_to_date1"].Value.ToString();  
                    ObjinvRoot.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                    ObjinvRoot.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                    ObjinvRoot.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                    ObjinvRoot.context.Header.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();
                    InvoiceDetail = ds.Tables[0]; 
                    for (int i = 0; i < InvoiceDetail.Rows.Count; i++)
                    {
                        PAWHSpaymentadvice_FDetail objInvList = new PAWHSpaymentadvice_FDetail();
                        objInvList.In_paymentdtl_rowid = Convert.ToInt32(InvoiceDetail.Rows[i]["In_paymentdtl_rowid"]);
                        objInvList.In_farmer_code = InvoiceDetail.Rows[i]["In_farmer_code"].ToString();
                        objInvList.In_farmer_name = InvoiceDetail.Rows[i]["In_farmer_name"].ToString();
                        objInvList.In_amount_paid = Convert.ToDouble(InvoiceDetail.Rows[i]["In_amount_paid"]); 
                        objInvList.In_status_code = InvoiceDetail.Rows[i]["In_status_code"].ToString();
                        objInvList.In_status_desc = InvoiceDetail.Rows[i]["In_status_desc"].ToString();
                        objInvList.In_mode_flag = InvoiceDetail.Rows[i]["In_mode_flag"].ToString();
                        ObjinvRoot.context.Detail.Add(objInvList);
                    }                   
                }
                ObjinvRoot.context.orgnId = ObjContext.orgnId;
                ObjinvRoot.context.locnId = ObjContext.locnId;
                ObjinvRoot.context.userId = ObjContext.userId;
                ObjinvRoot.context.localeId = ObjContext.localeId;
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjinvRoot;
        }

        public PAWHSpaymentadvice_SDocument new_pawhs_payment_advice(PAWHSpaymentadvice_SApplication ObjContext, string mysqlcon)
        {
            int ret = 0;
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            PAWHSpaymentadvice_SDocument objresFarmer = new PAWHSpaymentadvice_SDocument();
            objresFarmer.context = new PAWHSpaymentadvice_SContext();
            objresFarmer.context.Header = new PAWHSpaymentadvice_SHeader();
            objresFarmer.context.Detail = new List<PAWHSpaymentadvice_SDetail>(); 
            Int32 IOU_payment_rowid1 = 0;
            double IOU_total_amount1 = 0;
            string errorNo = "";
            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                MySqlCommand cmd = new MySqlCommand("PAWHS_insupd_payment_advice", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_payment_id", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_payment_id;
                cmd.Parameters.Add("In_from_date", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_from_date;
                cmd.Parameters.Add("In_to_date", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_to_date;
                cmd.Parameters.Add("In_bank_name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_bank_name;
                cmd.Parameters.Add("IOU_total_amount", MySqlDbType.Double).Value = ObjContext.document.context.Header.IOU_total_amount;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmd.Parameters.Add("IOU_payment_rowid", MySqlDbType.Int32).Value = ObjContext.document.context.Header.IOU_payment_rowid;
                cmd.Parameters.Add(new MySqlParameter("IOU_payment_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_total_amount1", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();

                if (ret > 0)
                {
                    IOU_payment_rowid1 = (Int32)cmd.Parameters["IOU_payment_rowid1"].Value;
                    IOU_total_amount1 = (Double)cmd.Parameters["IOU_total_amount1"].Value;
                   

                    objresFarmer.context.Header.IOU_payment_rowid =IOU_payment_rowid1;
                    objresFarmer.context.Header.IOU_total_amount = IOU_total_amount1;

                }
                if (objresFarmer.context.Header.IOU_payment_rowid > 0)
                {
                    string FarmersMapped = "";
                    FarmersMapped = SaveProcCal(ObjContext, objresFarmer, mysqlcon, MysqlCon);
                    if (FarmersMapped !="")
                    {
                        mysqltrans.Rollback(); 
                        return objresFarmer;
                    }
                } 
                mysqltrans.Commit();
                return objresFarmer;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                throw ex;

            }
        }

        public string SaveProcCal(PAWHSpaymentadvice_SApplication Objmodel, PAWHSpaymentadvice_SDocument objfarmer, string MysqlCons, DataConnection MysqlCon)
        {
            string result = "";
            string errorNo = ""; 
            DataTable tab = new DataTable();
            PAWHSpaymentadvice_SDetail objFarmersMapped = new PAWHSpaymentadvice_SDetail();
            try
            {
                PAWHSpaymentadvice_DataModel objproduct1 = new PAWHSpaymentadvice_DataModel();
                foreach (var FarmersMap in Objmodel.document.context.Detail)
                {
                    objFarmersMapped.In_paymentdtl_rowid = FarmersMap.In_paymentdtl_rowid;
                    objFarmersMapped.In_req_no = FarmersMap.In_req_no;
                    objFarmersMapped.In_farmer_code = FarmersMap.In_farmer_code;
                    objFarmersMapped.In_amount_paid = FarmersMap.In_amount_paid; 
                    objFarmersMapped.In_status_code = FarmersMap.In_status_code;
                    objFarmersMapped.In_mode_flag = FarmersMap.In_mode_flag;  
                    result = objproduct1.SaveProcCalNew(objFarmersMapped, objfarmer, Objmodel, MysqlCons, MysqlCon);
                    if (result!="")
                    {
                        errorNo = result.Trim(); 
                        break;
                    }
                } 
                return errorNo;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public string SaveProcCalNew(PAWHSpaymentadvice_SDetail ObjKycDtl, PAWHSpaymentadvice_SDocument ObjFarmer, PAWHSpaymentadvice_SApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {
            string errorNo = ""; 
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_iud_payment_advice_detail", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("IOU_payment_rowid", MySqlDbType.Int32).Value = ObjFarmer.context.Header.IOU_payment_rowid; 
                cmd.Parameters.Add("In_paymentdtl_rowid", MySqlDbType.Int32).Value = ObjKycDtl.In_paymentdtl_rowid;
                cmd.Parameters.Add("In_req_no", MySqlDbType.VarChar).Value = ObjKycDtl.In_req_no;
                cmd.Parameters.Add("In_farmer_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_farmer_code;
                cmd.Parameters.Add("In_amount_paid", MySqlDbType.VarChar).Value = ObjKycDtl.In_amount_paid;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_status_code;                 
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = ObjKycDtl.In_mode_flag;
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

    }
}
