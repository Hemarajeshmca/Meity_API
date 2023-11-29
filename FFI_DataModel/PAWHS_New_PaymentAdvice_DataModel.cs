using System;
using System.Collections.Generic;
using System.Text;
using FFI_Model;
using MySql.Data.MySqlClient;
using System.Data;
namespace FFI_DataModel
{
   public class PAWHS_New_PaymentAdvice_DataModel
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHS_New_PaymentAdvice_DataModel)); //Declaring Log4Net.


        //start 
        public PAWHS_New_PaymentAdvice_List_Application PAWHS_New_PaymentAdvice_All(PAWHS_New_PaymentAdvice_ALL_Context objPAWHSNewPaymentAdviceontext, string mysqlcon)
        {
            DataTable dt = new DataTable();

            PAWHS_New_PaymentAdvice_List_Application objPAWHSNewPaymentAdviceRoot = new PAWHS_New_PaymentAdvice_List_Application();
            PAWHS_New_PaymentAdvice_DataModel objDataModel = new PAWHS_New_PaymentAdvice_DataModel();

            objPAWHSNewPaymentAdviceRoot.context = new PAWHS_New_PaymentAdvice_ALL_Context();
            objPAWHSNewPaymentAdviceRoot.context.List = new List<PAWHS_New_PaymentAdvice_List>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_fetch_paymentadvice_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objPAWHSNewPaymentAdviceontext.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objPAWHSNewPaymentAdviceontext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objPAWHSNewPaymentAdviceontext.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objPAWHSNewPaymentAdviceontext.localeId;
                cmd.Parameters.Add("in_filterby_option", MySqlDbType.VarChar).Value = objPAWHSNewPaymentAdviceontext.filterby_option;
                cmd.Parameters.Add("in_filterby_code", MySqlDbType.VarChar).Value = objPAWHSNewPaymentAdviceontext.filterby_code;
                cmd.Parameters.Add("in_filterby_fromvalue", MySqlDbType.VarChar).Value = objPAWHSNewPaymentAdviceontext.filterby_fromvalue;
                cmd.Parameters.Add("in_filterby_tovalue", MySqlDbType.VarChar).Value = objPAWHSNewPaymentAdviceontext.filterby_tovalue;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PAWHS_New_PaymentAdvice_List objList = new PAWHS_New_PaymentAdvice_List();
                    objList.Out_payment_rowid = Convert.ToInt32(dt.Rows[i]["Out_payment_rowid"]);
                    objList.Out_payment_id = dt.Rows[i]["Out_payment_id"].ToString();
                    objList.Out_date = dt.Rows[i]["Out_date"].ToString();
                    objList.Out_period_from = dt.Rows[i]["Out_period_from"].ToString();
                    objList.Out_period_to = dt.Rows[i]["Out_period_to"].ToString();
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.Out_status_desc = dt.Rows[i]["Out_status_desc"].ToString();
                    objList.out_agg_code = dt.Rows[i]["out_agg_code"].ToString();
                    objList.out_agg_name = dt.Rows[i]["out_agg_name"].ToString();

                    objPAWHSNewPaymentAdviceRoot.context.List.Add(objList);

                }
                objPAWHSNewPaymentAdviceRoot.context.orgnId = objPAWHSNewPaymentAdviceontext.orgnId;
                objPAWHSNewPaymentAdviceRoot.context.locnId = objPAWHSNewPaymentAdviceontext.locnId;
                objPAWHSNewPaymentAdviceRoot.context.localeId = objPAWHSNewPaymentAdviceontext.localeId;
                objPAWHSNewPaymentAdviceRoot.context.userId = objPAWHSNewPaymentAdviceontext.userId;
                objPAWHSNewPaymentAdviceRoot.context.filterby_code = objPAWHSNewPaymentAdviceontext.filterby_code;
                objPAWHSNewPaymentAdviceRoot.context.filterby_fromvalue = objPAWHSNewPaymentAdviceontext.filterby_fromvalue;
                objPAWHSNewPaymentAdviceRoot.context.filterby_option = objPAWHSNewPaymentAdviceontext.filterby_option;
                objPAWHSNewPaymentAdviceRoot.context.filterby_tovalue = objPAWHSNewPaymentAdviceontext.filterby_tovalue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objPAWHSNewPaymentAdviceRoot;
        }

        //End

        //Single Fetch Start 

        public PAWHS_New_PaymentAdvice_Single_FApplication PAWHS_New_PaymentAdvice_Single(PAWHS_New_PaymentAdvice_Single_FContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();

            MysqlCon = new DataConnection(mysqlcon);

            PAWHS_New_PaymentAdvice_Single_FApplication ObjPawhsNewPaymentAdviceSingleRoot = new PAWHS_New_PaymentAdvice_Single_FApplication();
            PAWHS_New_PaymentAdvice_DataModel objDataModel = new PAWHS_New_PaymentAdvice_DataModel();

            DataTable InvoiceDetail = new DataTable();
            DataTable Header = new DataTable();

            ObjPawhsNewPaymentAdviceSingleRoot.context = new PAWHS_New_PaymentAdvice_Single_FContext();
            ObjPawhsNewPaymentAdviceSingleRoot.context.Header = new PAWHS_New_PaymentAdvice_Single_FHeader();
            ObjPawhsNewPaymentAdviceSingleRoot.context.Detail = new List<PAWHS_New_PaymentAdvice_Single_FDetail>();

            try
            {

                MySqlCommand cmd = new MySqlCommand("New_PAWHS_fetch_paymentadvice", MysqlCon.con);
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
                cmd.Parameters.Add(new MySqlParameter("In_agg_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_agg_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_payment_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();

                if (ds.Tables.Count > 0)
                {
                    ObjPawhsNewPaymentAdviceSingleRoot.context.Header.IOU_payment_id = (string)cmd.Parameters["IOU_payment_id1"].Value;
                    ObjPawhsNewPaymentAdviceSingleRoot.context.Header.IOU_payment_rowid = (Int32)cmd.Parameters["IOU_payment_rowid1"].Value;
                    ObjPawhsNewPaymentAdviceSingleRoot.context.Header.In_agg_code = (string)cmd.Parameters["In_agg_code"].Value.ToString(); 
                    ObjPawhsNewPaymentAdviceSingleRoot.context.Header.In_agg_name = (string)cmd.Parameters["In_agg_name"].Value.ToString(); 
                    ObjPawhsNewPaymentAdviceSingleRoot.context.Header.IOU_from_date = (string)cmd.Parameters["IOU_from_date1"].Value.ToString();
                    ObjPawhsNewPaymentAdviceSingleRoot.context.Header.IOU_to_date = (string)cmd.Parameters["IOU_to_date1"].Value.ToString();
                    ObjPawhsNewPaymentAdviceSingleRoot.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                    ObjPawhsNewPaymentAdviceSingleRoot.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                    ObjPawhsNewPaymentAdviceSingleRoot.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                    ObjPawhsNewPaymentAdviceSingleRoot.context.Header.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();
                    InvoiceDetail = ds.Tables[0];
                    for (int i = 0; i < InvoiceDetail.Rows.Count; i++)
                    {
                        PAWHS_New_PaymentAdvice_Single_FDetail objInvList = new PAWHS_New_PaymentAdvice_Single_FDetail();
                        objInvList.In_paymentdtl_rowid = Convert.ToInt32(InvoiceDetail.Rows[i]["In_paymentdtl_rowid"]);
                        objInvList.In_lot_no = InvoiceDetail.Rows[i]["In_lot_no"].ToString();
                        objInvList.In_farmer_code = InvoiceDetail.Rows[i]["In_farmer_code"].ToString();
                        objInvList.In_farmer_name = InvoiceDetail.Rows[i]["In_farmer_name"].ToString();
                        objInvList.In_procurment_date = InvoiceDetail.Rows[i]["In_procurment_date"].ToString() == "" ? "" : Convert.ToDateTime(InvoiceDetail.Rows[i]["In_procurment_date"]).ToString("yyyy-MM-dd");
                        objInvList.In_qty = Convert.ToDecimal(InvoiceDetail.Rows[i]["In_qty"]);
                        objInvList.In_price = Convert.ToDecimal(InvoiceDetail.Rows[i]["In_price"]);
                        objInvList.In_amount_paid = Convert.ToDecimal(InvoiceDetail.Rows[i]["In_amount_paid"]);
                        objInvList.In_total_othercost = Convert.ToDecimal(InvoiceDetail.Rows[i]["In_total_othercost"]);
                        objInvList.In_advance = Convert.ToDecimal(InvoiceDetail.Rows[i]["In_advance"]);
                        objInvList.In_balance = Convert.ToDecimal(InvoiceDetail.Rows[i]["In_balance"]);
                        objInvList.In_status_code = InvoiceDetail.Rows[i]["In_status_code"].ToString();
                        objInvList.In_status_desc = InvoiceDetail.Rows[i]["In_status_desc"].ToString();
                        objInvList.In_mode_flag = InvoiceDetail.Rows[i]["In_mode_flag"].ToString();
                        
                        ObjPawhsNewPaymentAdviceSingleRoot.context.Detail.Add(objInvList);
                    }
                }
                ObjPawhsNewPaymentAdviceSingleRoot.context.orgnId = ObjContext.orgnId;
                ObjPawhsNewPaymentAdviceSingleRoot.context.locnId = ObjContext.locnId;
                ObjPawhsNewPaymentAdviceSingleRoot.context.userId = ObjContext.userId;
                ObjPawhsNewPaymentAdviceSingleRoot.context.localeId = ObjContext.localeId;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjPawhsNewPaymentAdviceSingleRoot;
        }

        //Single Fetch End


        //Save And Update  Start 

        public PAWHS_New_PaymentAdvice_SDocument PAWHS_New_PaymentAdvice_Save(PAWHS_New_PaymentAdvice_SApplication ObjContext, string mysqlcon)
        {
            int ret = 0;
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            PAWHS_New_PaymentAdvice_SDocument objresFarmer = new PAWHS_New_PaymentAdvice_SDocument();
            objresFarmer.context = new PAWHS_New_PaymentAdvice_SContext();
            objresFarmer.context.Header = new PAWHS_New_PaymentAdvice_SHeader();
            objresFarmer.context.Detail = new List<PAWHS_New_PaymentAdvice_SDetail>();
            Int32 IOU_payment_rowid1 = 0;
            string IOU_payment_no1 = "";
            string errorNo = "";
            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                MySqlCommand cmd = new MySqlCommand("New_PAWHS_insupd_payment_advice", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_payment_advice_no", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_payment_advice_no;
                cmd.Parameters.Add("In_period_from", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_from_date;
                cmd.Parameters.Add("In_period_to", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_to_date;
                cmd.Parameters.Add("In_bank_name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_bank_name;
                cmd.Parameters.Add("IOU_payment_no", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_payment_no;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmd.Parameters.Add("IOU_payment_rowid", MySqlDbType.Int32).Value = ObjContext.document.context.Header.IOU_payment_rowid;
                cmd.Parameters.Add(new MySqlParameter("IOU_payment_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_payment_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();

                if (ret > 0)
                {
                    IOU_payment_rowid1 = (Int32)cmd.Parameters["IOU_payment_rowid1"].Value;
                    IOU_payment_no1 = (string)cmd.Parameters["IOU_payment_no1"].Value;


                    objresFarmer.context.Header.IOU_payment_rowid = IOU_payment_rowid1;
                    objresFarmer.context.Header.IOU_payment_no = IOU_payment_no1;

                }
                if (objresFarmer.context.Header.IOU_payment_rowid > 0)
                {
                    string FarmersMapped = "";
                    FarmersMapped = SaveProcCal(ObjContext, objresFarmer, mysqlcon, MysqlCon);
                    if (FarmersMapped != "")
                    {
                        mysqltrans.Rollback();
                        return objresFarmer;
                    }
                }
                mysqltrans.Commit();
                if (MysqlCon.con.State == ConnectionState.Open)
                {
                    
                    MysqlCon.con.Close();
                }
               
              
                return objresFarmer;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                MysqlCon.con.Close();
                throw ex;

            }
        }

        public string SaveProcCal(PAWHS_New_PaymentAdvice_SApplication Objmodel, PAWHS_New_PaymentAdvice_SDocument objfarmer, string MysqlCons, DataConnection MysqlCon)
        {
            string result = "";
            string errorNo = "";
            DataTable tab = new DataTable();
            PAWHS_New_PaymentAdvice_SDetail objFarmersMapped = new PAWHS_New_PaymentAdvice_SDetail();
            try
            {
                PAWHS_New_PaymentAdvice_DataModel objproduct1 = new PAWHS_New_PaymentAdvice_DataModel();
                foreach (var FarmersMap in Objmodel.document.context.Detail)
                {
                    objFarmersMapped.In_paymentdtl_rowid = FarmersMap.In_paymentdtl_rowid;
                    objFarmersMapped.In_req_no = FarmersMap.In_req_no;
                    objFarmersMapped.In_farmer_code = FarmersMap.In_farmer_code;
                    objFarmersMapped.In_balance = FarmersMap.In_balance;
                    objFarmersMapped.In_status_code = FarmersMap.In_status_code;
                    objFarmersMapped.In_mode_flag = FarmersMap.In_mode_flag;
                    //objFarmersMapped.In_payment_remark = FarmersMap.In_payment_remark;
                    objFarmersMapped.In_lot_no = FarmersMap.In_lot_no;
                    result = objproduct1.SaveProcCalNew(objFarmersMapped, objfarmer, Objmodel, MysqlCons, MysqlCon);
                    if (result != "")
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
        public string SaveProcCalNew(PAWHS_New_PaymentAdvice_SDetail ObjKycDtl, PAWHS_New_PaymentAdvice_SDocument ObjFarmer, PAWHS_New_PaymentAdvice_SApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {
            string errorNo = "";
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_iud_payment_advice_detail", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("IOU_payment_rowid", MySqlDbType.Int32).Value = ObjFarmer.context.Header.IOU_payment_rowid;
                cmd.Parameters.Add("In_payadvicedtl_rowid", MySqlDbType.Int32).Value = ObjKycDtl.In_paymentdtl_rowid;
                cmd.Parameters.Add("In_req_no", MySqlDbType.VarChar).Value = ObjKycDtl.In_req_no;
                cmd.Parameters.Add("In_farmer_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_farmer_code;
                cmd.Parameters.Add("In_amount", MySqlDbType.Decimal).Value = ObjKycDtl.In_balance;
                cmd.Parameters.Add("In_payment_remark", MySqlDbType.VarChar).Value = ObjKycDtl.In_payment_remark;
                cmd.Parameters.Add("In_lot_no", MySqlDbType.VarChar).Value = ObjKycDtl.In_lot_no;
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

        //Save And Update End


        //Start 
        public PAWHS_New_PaymentAdvice_fetchgrid_FApplication PAWHS_New_PaymentAdvice_Fetch_Gridvalue(PAWHS_New_PaymentAdvice_fetchgrid_FContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();

            MysqlCon = new DataConnection(mysqlcon);

            PAWHS_New_PaymentAdvice_fetchgrid_FApplication ObjPawhsNewPaymentAdviceSingleRoot = new PAWHS_New_PaymentAdvice_fetchgrid_FApplication();
            PAWHS_New_PaymentAdvice_DataModel objDataModel = new PAWHS_New_PaymentAdvice_DataModel();

            DataTable InvoiceDetail = new DataTable();
           // DataTable Header = new DataTable();

            ObjPawhsNewPaymentAdviceSingleRoot.context = new PAWHS_New_PaymentAdvice_fetchgrid_FContext();
            //ObjPawhsNewPaymentAdviceSingleRoot.context.Header = new PAWHS_New_PaymentAdvice_Single_FHeader();
            ObjPawhsNewPaymentAdviceSingleRoot.context.Detail = new List<PAWHS_New_PaymentAdvice_fetchgrid_FDetail>();

            try
            {

                MySqlCommand cmd = new MySqlCommand("New_PAWHS_fetch_PaymentAdvice_Gridvalues", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("In_from_date", MySqlDbType.VarChar).Value = ObjContext.from_date;
                cmd.Parameters.Add("In_to_date", MySqlDbType.VarChar).Value = ObjContext.to_date; 
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();

                if (ds.Tables.Count > 0)
                {
                    InvoiceDetail = ds.Tables[0];
                    for (int i = 0; i < InvoiceDetail.Rows.Count; i++)
                    {
                        PAWHS_New_PaymentAdvice_fetchgrid_FDetail objInvList = new PAWHS_New_PaymentAdvice_fetchgrid_FDetail();
                        objInvList.In_paymentdtl_rowid = Convert.ToInt32(InvoiceDetail.Rows[i]["In_paymentdtl_rowid"]);
                        objInvList.In_lot_no = InvoiceDetail.Rows[i]["In_lot_no"].ToString();
                        objInvList.In_farmer_code = InvoiceDetail.Rows[i]["In_farmer_code"].ToString();
                        objInvList.In_farmer_name = InvoiceDetail.Rows[i]["In_farmer_name"].ToString();
                        objInvList.In_procurment_date = Convert.ToDateTime(InvoiceDetail.Rows[i]["In_procurment_date"]).ToString("yyyy-MM-dd"); 
                        objInvList.In_qty = Convert.ToDecimal(InvoiceDetail.Rows[i]["In_qty"]);
                        objInvList.In_price = Convert.ToDecimal(InvoiceDetail.Rows[i]["In_price"]);
                        objInvList.In_amount_paid = Convert.ToDecimal(InvoiceDetail.Rows[i]["In_amount_paid"]);
                        objInvList.In_total_othercost = Convert.ToDecimal(InvoiceDetail.Rows[i]["In_total_othercost"]);
                        objInvList.In_advance = Convert.ToDecimal(InvoiceDetail.Rows[i]["In_advance"]);
                        objInvList.In_balance = Convert.ToDecimal(InvoiceDetail.Rows[i]["In_balance"]);
                        objInvList.In_status_code = InvoiceDetail.Rows[i]["In_status_code"].ToString();
                        objInvList.In_status_desc = InvoiceDetail.Rows[i]["In_status_desc"].ToString();
                        objInvList.In_mode_flag = InvoiceDetail.Rows[i]["In_mode_flag"].ToString();
                        ObjPawhsNewPaymentAdviceSingleRoot.context.Detail.Add(objInvList);
                    }
                }
                ObjPawhsNewPaymentAdviceSingleRoot.context.orgnId = ObjContext.orgnId;
                ObjPawhsNewPaymentAdviceSingleRoot.context.locnId = ObjContext.locnId;
                ObjPawhsNewPaymentAdviceSingleRoot.context.userId = ObjContext.userId;
                ObjPawhsNewPaymentAdviceSingleRoot.context.localeId = ObjContext.localeId;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjPawhsNewPaymentAdviceSingleRoot;
        }


        //End

    }
}
