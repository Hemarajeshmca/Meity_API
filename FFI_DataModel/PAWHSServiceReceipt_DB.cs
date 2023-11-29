using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
   public class PAWHSServiceReceipt_DB
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInvoice_DataModel)); //Declaring Log4Net. 
        public PAWHSServiceReceiptApplication Getallservice_receipting_DB(PAWHSServiceReceiptContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();

            PAWHSServiceReceiptApplication objinvoiceRoot = new PAWHSServiceReceiptApplication();
            PAWHSServiceReceipt_DB objDataModel = new PAWHSServiceReceipt_DB();

            objinvoiceRoot.context = new PAWHSServiceReceiptContext();
            objinvoiceRoot.context.List = new List<PAWHSServiceReceiptList>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_servicereceipting_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
                cmd.Parameters.Add("In_filterby_option", MySqlDbType.VarChar).Value = objinvoice.Filter.FilterBy_Option;
                cmd.Parameters.Add("In_filterby_code", MySqlDbType.VarChar).Value = objinvoice.Filter.FilterBy_Code;
                cmd.Parameters.Add("In_filterby_fromvalue", MySqlDbType.VarChar).Value = objinvoice.Filter.FilterBy_FromValue;
                cmd.Parameters.Add("In_filterby_tovalue", MySqlDbType.VarChar).Value = objinvoice.Filter.FilterBy_ToValue;


                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PAWHSServiceReceiptList objList = new PAWHSServiceReceiptList();
                    objList.Out_receipt_rowid = Convert.ToInt32(dt.Rows[i]["Out_receipt_rowid"]);
                    objList.Out_grn = dt.Rows[i]["Out_grn"].ToString();
                    objList.Out_farmer_code = dt.Rows[i]["Out_farmer_code"].ToString();
                    objList.Out_farmer_name = dt.Rows[i]["Out_farmer_name"].ToString();
                    objList.Out_pickup_request_id = dt.Rows[i]["Out_pickup_request_id"].ToString();
                    objList.Out_pickup_date = dt.Rows[i]["Out_pickup_date"].ToString();
                    objList.Out_pickup_slot = dt.Rows[i]["Out_pickup_slot"].ToString();
                    objList.Out_procurement = dt.Rows[i]["Out_procurement"].ToString();
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.Out_status_desc = dt.Rows[i]["Out_status_desc"].ToString();
                    objList.Out_row_timestamp = dt.Rows[i]["Out_row_timestamp"].ToString();
                    objinvoiceRoot.context.List.Add(objList);

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
        public PAWHSServiceReceiptFApplication Getservice_receipting_DB(PAWHSServiceReceiptFContext objfpoSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();

            PAWHSServiceReceiptFApplication objfpoSearchRoot = new PAWHSServiceReceiptFApplication();
            PAWHSServiceReceipt_DB objDataModel = new PAWHSServiceReceipt_DB();

            DataTable Map = new DataTable();


            objfpoSearchRoot.context = new PAWHSServiceReceiptFContext();
            objfpoSearchRoot.context.Header = new PAWHSServiceReceiptFHeader();
            objfpoSearchRoot.context.Detail = new List<PAWHSServiceReceiptFDetail>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_servicereceipting", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;
                cmd.Parameters.Add("IOU_receipt_rowid", MySqlDbType.VarChar).Value = objfpoSearch.IOU_receipt_rowid;
                cmd.Parameters.Add("IOU_service_receipt_no", MySqlDbType.VarChar).Value = objfpoSearch.IOU_service_receipt_no;
                cmd.Parameters.Add(new MySqlParameter("In_warehouse_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_warehouse_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_service_receipt_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_farmer_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_farmer_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_request_id", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_paid_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_balance_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_remarks", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_output_item", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_service_type", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;               
                cmd.Parameters.Add(new MySqlParameter("IOU_receipt_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_service_receipt_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();
                if (ds.Tables.Count > 0)
                {
                    Map = ds.Tables[0];

                    for (int i = 0; i < Map.Rows.Count; i++)
                    {
                        PAWHSServiceReceiptFDetail objDetailList = new PAWHSServiceReceiptFDetail();
                        objDetailList.In_receiptdtl_rowid = Convert.ToInt32(Map.Rows[i]["In_receiptdtl_rowid"]);
                        objDetailList.In_item_code = Map.Rows[i]["In_item_code"].ToString();
                        objDetailList.In_item_name = Map.Rows[i]["In_item_name"].ToString();
                        objDetailList.In_uom = Map.Rows[i]["In_uom"].ToString();
                        objDetailList.In_quantity = Convert.ToDouble(Map.Rows[i]["In_quantity"]);
                        objDetailList.In_received_qty = Convert.ToDouble(Map.Rows[i]["In_received_qty"]);
                        objDetailList.In_accepted_qty = Convert.ToDouble(Map.Rows[i]["In_accepted_qty"]);                                            
                        objDetailList.In_remarks = Map.Rows[i]["In_remarks"].ToString();
                        objDetailList.In_status_code = Map.Rows[i]["In_status_code"].ToString();
                        objDetailList.In_status_desc = Map.Rows[i]["In_status_desc"].ToString();
                        objDetailList.In_mode_flag = Map.Rows[i]["In_mode_flag"].ToString();
                        objfpoSearchRoot.context.Detail.Add(objDetailList);
                    }
                    objfpoSearchRoot.context.orgnId = objfpoSearch.orgnId;
                    objfpoSearchRoot.context.locnId = objfpoSearch.locnId;
                    objfpoSearchRoot.context.userId = objfpoSearch.userId;
                    objfpoSearchRoot.context.localeId = objfpoSearch.localeId;

                    objfpoSearchRoot.context.Header.IOU_receipt_rowid = (Int32)cmd.Parameters["IOU_receipt_rowid"].Value;
                    objfpoSearchRoot.context.Header.IOU_service_receipt_no = (string)cmd.Parameters["IOU_service_receipt_no1"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_warehouse_code = (string)cmd.Parameters["In_warehouse_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_warehouse_name = (string)cmd.Parameters["In_warehouse_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_service_receipt_date = (string)cmd.Parameters["In_service_receipt_date"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_farmer_code = (string)cmd.Parameters["In_farmer_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_farmer_name = (string)cmd.Parameters["In_farmer_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_request_id = (string)cmd.Parameters["In_request_id"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_amount = (double)cmd.Parameters["In_amount"].Value;
                    objfpoSearchRoot.context.Header.In_paid_amount = (double)cmd.Parameters["In_paid_amount"].Value;
                    objfpoSearchRoot.context.Header.In_balance_amount = (double)cmd.Parameters["In_balance_amount"].Value;
                    objfpoSearchRoot.context.Header.In_remarks = (string)cmd.Parameters["In_remarks"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_output_item = (string)cmd.Parameters["In_output_item"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_service_type = (string)cmd.Parameters["In_service_type"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();                   
                    objfpoSearchRoot.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objfpoSearchRoot;
        }
        public PAWHSServiceReceiptSDocument Savenew_pawhs_service_receipting_DB(PAWHSServiceReceiptSApplication ObjContext, string mysqlcon)
        {
            int ret = 0;
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            PAWHSServiceReceiptSDocument objresFarmer = new PAWHSServiceReceiptSDocument();
            objresFarmer.context = new PAWHSServiceReceiptSContext();
            objresFarmer.context.Header = new PAWHSServiceReceiptSHeader();
            objresFarmer.context.Detail = new List<PAWHSServiceReceiptSDetail>();
            objresFarmer.ApplicationException = new PAWHSServiceReceiptSApplicationException();
            string IOU_receipt_rowid1 = "";
            string IOU_service_receipt_no1 = "";
            string errorNo = "";
            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                MySqlCommand cmd = new MySqlCommand("PAWHS_insupd_service_receipting", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_warehouse_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_warehouse_code;
                cmd.Parameters.Add("In_service_receipt_date", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_service_receipt_date;
                cmd.Parameters.Add("In_farmer_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_farmer_code;
                cmd.Parameters.Add("In_request_id", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_request_id;
                cmd.Parameters.Add("In_amount", MySqlDbType.Double).Value = ObjContext.document.context.Header.In_amount;
                cmd.Parameters.Add("In_paid_amount", MySqlDbType.Double).Value = ObjContext.document.context.Header.In_paid_amount;
                cmd.Parameters.Add("In_remarks", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_remarks;
                cmd.Parameters.Add("In_output_item", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_output_item;
                cmd.Parameters.Add("In_service_type", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_service_type;
                cmd.Parameters.Add("In_balance_amount", MySqlDbType.Double).Value = ObjContext.document.context.Header.In_balance_amount;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmd.Parameters.Add("IOU_receipt_rowid", MySqlDbType.Int32).Value = ObjContext.document.context.Header.IOU_receipt_rowid;
                cmd.Parameters.Add("IOU_service_receipt_no", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_service_receipt_no;
                cmd.Parameters.Add(new MySqlParameter("IOU_receipt_rowid1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_service_receipt_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();

                if (ret > 0)
                {
                    IOU_receipt_rowid1 = (string)cmd.Parameters["IOU_receipt_rowid1"].Value;
                    IOU_service_receipt_no1 = (string)cmd.Parameters["IOU_service_receipt_no1"].Value;
                    

                    objresFarmer.context.Header.IOU_receipt_rowid = Convert.ToInt32(IOU_receipt_rowid1);
                    objresFarmer.context.Header.IOU_service_receipt_no = IOU_service_receipt_no1;

                }
                if (objresFarmer.context.Header.IOU_receipt_rowid > 0)
                {
                    string[] FarmersMapped = { };
                    FarmersMapped = SaveProcCal(ObjContext, objresFarmer, mysqlcon, MysqlCon);
                    if (FarmersMapped[0].Contains("060"))
                    {
                        mysqltrans.Rollback();
                        objresFarmer.ApplicationException.errorNumber = FarmersMapped[0].ToString();
                        objresFarmer.ApplicationException.errorDescription = FarmersMapped[1].ToString();
                        return objresFarmer;
                    }
                }
                string[] returnvalues = { IOU_receipt_rowid1, IOU_service_receipt_no1, errorNo };

                mysqltrans.Commit();
                return objresFarmer;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                throw ex;

            }
        }
        public string[] SaveProcCal(PAWHSServiceReceiptSApplication Objmodel, PAWHSServiceReceiptSDocument objfarmer, string MysqlCons, DataConnection MysqlCon)
        {
            string[] result = { };
            string errorNo = "";
            string errorMsg = "";
            DataTable tab = new DataTable();
            PAWHSServiceReceiptSDetail objFarmersMapped = new PAWHSServiceReceiptSDetail();
            try
            {
                PAWHSServiceReceipt_DB objproduct1 = new PAWHSServiceReceipt_DB();
                foreach (var FarmersMap in Objmodel.document.context.Detail)
                {
                    objFarmersMapped.In_receiptdtl_rowid = FarmersMap.In_receiptdtl_rowid;
                    objFarmersMapped.In_item_code = FarmersMap.In_item_code;
                    objFarmersMapped.In_uom = FarmersMap.In_uom;
                    objFarmersMapped.In_quantity = FarmersMap.In_quantity;
                    objFarmersMapped.In_received_qty = FarmersMap.In_received_qty;
                    objFarmersMapped.In_accepted_qty = FarmersMap.In_accepted_qty;
                    objFarmersMapped.In_remarks = FarmersMap.In_remarks;
                    objFarmersMapped.In_status_code = FarmersMap.In_status_code;
                    objFarmersMapped.In_mode_flag = FarmersMap.In_mode_flag;
                    result = objproduct1.SaveProcCalNew(objFarmersMapped, objfarmer, Objmodel, MysqlCons, MysqlCon);

                    if (result[0].Contains("060"))
                    {
                        errorNo = result[0].ToString();
                        errorMsg = result[1].ToString();
                        break;
                    }
                }
                string[] FarmersMapped = { errorNo, errorMsg };
                return FarmersMapped;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public string[] SaveProcCalNew(PAWHSServiceReceiptSDetail ObjKycDtl, PAWHSServiceReceiptSDocument ObjFarmer, PAWHSServiceReceiptSApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {
            string errorNo = "";
            string errorMsg = "";
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_iud_service_receipting", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.Add("In_receiptdtl_rowid", MySqlDbType.Int32).Value = ObjKycDtl.In_receiptdtl_rowid;
                cmd.Parameters.Add("In_item_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_item_code;
                cmd.Parameters.Add("In_uom", MySqlDbType.VarChar).Value = ObjKycDtl.In_uom;
                cmd.Parameters.Add("In_quantity", MySqlDbType.Double).Value = ObjKycDtl.In_quantity;
                cmd.Parameters.Add("In_received_qty", MySqlDbType.Double).Value = ObjKycDtl.In_received_qty;
                cmd.Parameters.Add("In_accepted_qty", MySqlDbType.Double).Value = ObjKycDtl.In_accepted_qty;
                cmd.Parameters.Add("In_remarks", MySqlDbType.VarChar).Value = ObjKycDtl.In_remarks;               
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_status_code;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = ObjKycDtl.In_mode_flag;
                cmd.Parameters.Add("IOU_receipt_rowid", MySqlDbType.Int32).Value = ObjFarmer.context.Header.IOU_receipt_rowid;
                cmd.Parameters.Add("IOU_service_receipt_no", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.IOU_service_receipt_no;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;

                ret = cmd.ExecuteNonQuery();
                if (ret == 0)
                {

                    errorNo = (string)cmd.Parameters["errorNo"].Value;
                    errorMsg = ObjErrormsg.ErrorMessage(errorNo);

                }
                string[] result = { errorNo, errorMsg };
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

