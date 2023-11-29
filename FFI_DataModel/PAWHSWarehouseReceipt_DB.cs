using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
   public class PAWHSWarehouseReceipt_DB
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInvoice_DataModel)); //Declaring Log4Net. 
        public PAWHSWarehouseReceiptApplication Getallwarehouse_receipt_DB(PAWHSWarehouseReceiptContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();

            PAWHSWarehouseReceiptApplication objinvoiceRoot = new PAWHSWarehouseReceiptApplication();
            PAWHSWarehouseReceipt_DB objDataModel = new PAWHSWarehouseReceipt_DB();

            objinvoiceRoot.context = new PAWHSWarehouseReceiptContext();
            objinvoiceRoot.context.List = new List<PAWHSWarehouseReceiptList>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_whs_receipt_list", MysqlCon.con);
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
                    PAWHSWarehouseReceiptList objList = new PAWHSWarehouseReceiptList();
                    objList.Out_whs_receipt_rowid = Convert.ToInt32(dt.Rows[i]["Out_adjustment_rowid"]);
                    objList.Out_grn = dt.Rows[i]["Out_grn"].ToString();
                    objList.Out_farmer_code = dt.Rows[i]["Out_farmer_code"].ToString();
                    objList.Out_farmer_name = dt.Rows[i]["Out_farmer_name"].ToString();
                    objList.Out_pickup_request_id = dt.Rows[i]["Out_pickup_request_id"].ToString();
                    objList.Out_pickup_date = dt.Rows[i]["Out_pickup_date"].ToString();
                    objList.Out_pickup_slot = dt.Rows[i]["Out_pickup_slot"].ToString();
                    objList.Out_procurement = dt.Rows[i]["Out_procurement"].ToString();
                    objList.Out_farmer_code = dt.Rows[i]["Out_farmer_code"].ToString();                   
                    objList.Out_status_code = dt.Rows[i]["In_status_code"].ToString();
                    objList.Out_status_desc = dt.Rows[i]["In_status_desc"].ToString();
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
        public PAWHSWarehouseReceiptFApplication Getwarehouse_receipt_DB(PAWHSWarehouseReceiptFContext objfpoSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();

            PAWHSWarehouseReceiptFApplication objfpoSearchRoot = new PAWHSWarehouseReceiptFApplication();
            PAWHSWarehouseReceipt_DB objDataModel = new PAWHSWarehouseReceipt_DB();

            DataTable Map = new DataTable();


            objfpoSearchRoot.context = new PAWHSWarehouseReceiptFContext();
            objfpoSearchRoot.context.Header = new PAWHSWarehouseReceiptFHeader();
            objfpoSearchRoot.context.Detail = new List<PAWHSWarehouseReceiptFDetail>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_whs_receipt", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;
                cmd.Parameters.Add("IOU_whs_receipt_rowid", MySqlDbType.VarChar).Value = objfpoSearch.IOU_whs_receipt_rowid;
                cmd.Parameters.Add("IOU_grn_invoice_no", MySqlDbType.VarChar).Value = objfpoSearch.IOU_grn_invoice_no;
                cmd.Parameters.Add(new MySqlParameter("In_whs_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_whs_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_receipt_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_farmer_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_farmer_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_reg_mobile_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_pickup_request_id", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_item_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_item_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_uom", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_quantity", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_quality", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_quality_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_received_qty", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_accepted_qty", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_rate", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_paid_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_balance_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;               
                cmd.Parameters.Add(new MySqlParameter("IOU_whs_receipt_rowid1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_grn_invoice_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();
                if (ds.Tables.Count > 0)
                {
                    Map = ds.Tables[0];

                    for (int i = 0; i < Map.Rows.Count; i++)
                    {
                        PAWHSWarehouseReceiptFDetail objDetailList = new PAWHSWarehouseReceiptFDetail();
                        objDetailList.In_quality_code = Map.Rows[i]["In_quality_code"].ToString();
                        objDetailList.In_quality_desc = Map.Rows[i]["In_quality_desc"].ToString();
                        objDetailList.In_range_1 = Map.Rows[i]["In_range_1"].ToString();
                        objDetailList.In_range_2 = Map.Rows[i]["In_range_2"].ToString();
                        objDetailList.In_range_3 = Map.Rows[i]["In_range_3"].ToString();
                        objDetailList.In_range_4 = Map.Rows[i]["In_range_4"].ToString();
                        objDetailList.In_range_5 = Map.Rows[i]["In_range_5"].ToString();
                        objDetailList.In_product_range = Map.Rows[i]["In_product_range"].ToString();
                        objDetailList.In_product_range_desc = Map.Rows[i]["In_product_range_desc"].ToString();
                        objDetailList.In_status_code = Map.Rows[i]["In_status_code"].ToString();
                        objDetailList.In_status_desc = Map.Rows[i]["In_status_desc"].ToString();
                        objDetailList.In_mode_flag = Map.Rows[i]["In_mode_flag"].ToString();
                        objfpoSearchRoot.context.Detail.Add(objDetailList);
                    }
                    objfpoSearchRoot.context.orgnId = objfpoSearch.orgnId;
                    objfpoSearchRoot.context.locnId = objfpoSearch.locnId;
                    objfpoSearchRoot.context.userId = objfpoSearch.userId;
                    objfpoSearchRoot.context.localeId = objfpoSearch.localeId;

                    objfpoSearchRoot.context.Header.IOU_whs_receipt_rowid = (Int32)cmd.Parameters["IOU_whs_receipt_rowid"].Value;
                    objfpoSearchRoot.context.Header.IOU_grn_invoice_no = (string)cmd.Parameters["IOU_grn_invoice_no1"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_whs_code = (string)cmd.Parameters["In_whs_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_whs_name = (string)cmd.Parameters["In_whs_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_receipt_date = (string)cmd.Parameters["In_receipt_date"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_farmer_code = (string)cmd.Parameters["In_farmer_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_farmer_name = (string)cmd.Parameters["In_farmer_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_reg_mobile_no = (string)cmd.Parameters["In_reg_mobile_no"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_pickup_request_id = (string)cmd.Parameters["In_pickup_request_id"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_item_code = (string)cmd.Parameters["In_item_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_item_name = (string)cmd.Parameters["In_item_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_whs_name = (string)cmd.Parameters["In_whs_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_uom = (string)cmd.Parameters["In_uom"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_quantity = (double)cmd.Parameters["In_quantity"].Value;
                    objfpoSearchRoot.context.Header.In_quality = (double)cmd.Parameters["In_quality"].Value;
                    objfpoSearchRoot.context.Header.In_quality_desc = (string)cmd.Parameters["In_quality_desc"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_received_qty = (double)cmd.Parameters["In_received_qty"].Value;
                    objfpoSearchRoot.context.Header.In_accepted_qty = (double)cmd.Parameters["In_accepted_qty"].Value;
                    objfpoSearchRoot.context.Header.In_rate = (double)cmd.Parameters["In_rate"].Value;
                    objfpoSearchRoot.context.Header.In_amount = (double)cmd.Parameters["In_amount"].Value;
                    objfpoSearchRoot.context.Header.In_paid_amount = (double)cmd.Parameters["In_paid_amount"].Value;
                    objfpoSearchRoot.context.Header.In_balance_amount = (double)cmd.Parameters["In_balance_amount"].Value;
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
        public PAWHSWarehouseReceiptSDocument Savenew_warehouse_receipt_DB(PAWHSWarehouseReceiptSApplication ObjContext, string mysqlcon)
        {
            int ret = 0;
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            PAWHSWarehouseReceiptSDocument objresFarmer = new PAWHSWarehouseReceiptSDocument();
            objresFarmer.context = new PAWHSWarehouseReceiptSContext();
            objresFarmer.context.Header = new PAWHSWarehouseReceiptSHeader();
            objresFarmer.context.Detail = new List<PAWHSWarehouseReceiptSDetail>();
            objresFarmer.ApplicationException = new PAWHSWarehouseReceiptSApplicationException();
            string IOU_whs_receipt_rowid1 = "";
            string IOU_grn_invoice_no1 = "";
            string IOU_pickup_request_id1 = "";
            string errorNo = "";
            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                MySqlCommand cmd = new MySqlCommand("PAWHS_insupd_warehouse_receipt", MysqlCon.con);          
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_whs_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_whs_code;
                cmd.Parameters.Add("In_receipt_date", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_receipt_date;
                cmd.Parameters.Add("In_farmer_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_farmer_code;
                cmd.Parameters.Add("In_reg_mobile_no", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_reg_mobile_no;
                cmd.Parameters.Add("In_item_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_item_code;
                cmd.Parameters.Add("In_uom", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_uom;
                cmd.Parameters.Add("In_quantity", MySqlDbType.Double).Value = ObjContext.document.context.Header.In_quantity;
                cmd.Parameters.Add("In_quality", MySqlDbType.Double).Value = ObjContext.document.context.Header.In_quality;
                cmd.Parameters.Add("In_received_qty", MySqlDbType.Double).Value = ObjContext.document.context.Header.In_received_qty;
                cmd.Parameters.Add("In_accepted_qty", MySqlDbType.Double).Value = ObjContext.document.context.Header.In_accepted_qty;
                cmd.Parameters.Add("In_rate", MySqlDbType.Double).Value = ObjContext.document.context.Header.In_rate;
                cmd.Parameters.Add("In_amount", MySqlDbType.Double).Value = ObjContext.document.context.Header.In_amount;
                cmd.Parameters.Add("In_paid_amount", MySqlDbType.Double).Value = ObjContext.document.context.Header.In_paid_amount;
                cmd.Parameters.Add("In_balance_amount", MySqlDbType.Double).Value = ObjContext.document.context.Header.In_balance_amount;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmd.Parameters.Add("IOU_whs_receipt_rowid", MySqlDbType.Int32).Value = ObjContext.document.context.Header.IOU_whs_receipt_rowid;
                cmd.Parameters.Add("IOU_grn_invoice_no", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_grn_invoice_no;
                cmd.Parameters.Add("IOU_pickup_request_id", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_pickup_request_id;
                cmd.Parameters.Add(new MySqlParameter("IOU_whs_receipt_rowid1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_grn_invoice_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_pickup_request_id1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();

                if (ret > 0)
                {
                    IOU_whs_receipt_rowid1 = (string)cmd.Parameters["IOU_whs_receipt_rowid1"].Value;
                    IOU_grn_invoice_no1 = (string)cmd.Parameters["IOU_grn_invoice_no1"].Value;
                    IOU_pickup_request_id1 = (string)cmd.Parameters["IOU_pickup_request_id1"].Value;
                    

                    objresFarmer.context.Header.IOU_whs_receipt_rowid = Convert.ToInt32(IOU_whs_receipt_rowid1);
                    objresFarmer.context.Header.IOU_grn_invoice_no = IOU_grn_invoice_no1;
                    objresFarmer.context.Header.IOU_pickup_request_id = IOU_pickup_request_id1;

                }
                if (objresFarmer.context.Header.IOU_whs_receipt_rowid > 0)
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
                string[] returnvalues = { IOU_whs_receipt_rowid1, IOU_grn_invoice_no1, IOU_pickup_request_id1, errorNo };

                mysqltrans.Commit();
                return objresFarmer;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                throw ex;

            }
        }
        public string[] SaveProcCal(PAWHSWarehouseReceiptSApplication Objmodel, PAWHSWarehouseReceiptSDocument objfarmer, string MysqlCons, DataConnection MysqlCon)
        {
            string[] result = { };
            string errorNo = "";
            string errorMsg = "";
            DataTable tab = new DataTable();
            PAWHSWarehouseReceiptSDetail objFarmersMapped = new PAWHSWarehouseReceiptSDetail();
            try
            {
                PAWHSWarehouseReceipt_DB objproduct1 = new PAWHSWarehouseReceipt_DB();
                foreach (var FarmersMap in Objmodel.document.context.Detail)
                {
                    objFarmersMapped.In_quality_code = FarmersMap.In_quality_code;
                    objFarmersMapped.In_range_1 = FarmersMap.In_range_1;
                    objFarmersMapped.In_range_2 = FarmersMap.In_range_2;
                    objFarmersMapped.In_range_3 = FarmersMap.In_range_3;
                    objFarmersMapped.In_range_4 = FarmersMap.In_range_4;
                    objFarmersMapped.In_range_5 = FarmersMap.In_range_5;
                    objFarmersMapped.In_product_range = FarmersMap.In_product_range;                    
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

        public string[] SaveProcCalNew(PAWHSWarehouseReceiptSDetail ObjKycDtl, PAWHSWarehouseReceiptSDocument ObjFarmer, PAWHSWarehouseReceiptSApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {
            string errorNo = "";
            string errorMsg = "";
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_iud_warehouse_receipt_detail", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
               
                cmd.Parameters.Add("In_quality_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_quality_code;
                cmd.Parameters.Add("In_range1", MySqlDbType.VarChar).Value = ObjKycDtl.In_range_1;
                cmd.Parameters.Add("In_range2", MySqlDbType.VarChar).Value = ObjKycDtl.In_range_2;
                cmd.Parameters.Add("In_range3", MySqlDbType.VarChar).Value = ObjKycDtl.In_range_3;
                cmd.Parameters.Add("In_range4", MySqlDbType.VarChar).Value = ObjKycDtl.In_range_4;
                cmd.Parameters.Add("In_range5", MySqlDbType.VarChar).Value = ObjKycDtl.In_range_5;
                cmd.Parameters.Add("In_product_range", MySqlDbType.VarChar).Value = ObjKycDtl.In_product_range;               
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_status_code;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = ObjKycDtl.In_mode_flag;
                cmd.Parameters.Add("IOU_whs_receipt_rowid", MySqlDbType.Int32).Value = ObjFarmer.context.Header.IOU_whs_receipt_rowid;
                cmd.Parameters.Add("IOU_grn_invoice_no", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.IOU_grn_invoice_no;
                cmd.Parameters.Add("IOU_pickup_request_id", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.IOU_pickup_request_id;
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
        public PAWHSWarehouseReceiptIApplication Getitem_master_DB(PAWHSWarehouseReceiptIContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            PAWHSWarehouseReceiptIApplication ObjFetchAll = new PAWHSWarehouseReceiptIApplication();
            ObjFetchAll.context = new PAWHSWarehouseReceiptIContext();
            ObjFetchAll.context.Header = new PAWHSWarehouseReceiptIHeader();
            ObjFetchAll.context.Detail = new List<PAWHSWarehouseReceiptIDetail>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_item_master", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("IOU_item_rowid", MySqlDbType.Int32).Value = ObjContext.Header.IOU_item_rowid;
                cmd.Parameters.Add("IOU_agg_code", MySqlDbType.VarChar).Value = ObjContext.Header.IOU_agg_code;
                cmd.Parameters.Add("IOU_item_code", MySqlDbType.VarChar).Value = ObjContext.Header.IOU_item_code;

                cmd.Parameters.Add(new MySqlParameter("In_item_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_item_ll_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_item_type", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_fg_category", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_fg_subcategory", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_uom_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_hsn_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_hsn_description", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_item_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_agg_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_item_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;


                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PAWHSWarehouseReceiptIDetail objList = new PAWHSWarehouseReceiptIDetail();
                    objList.In_item_dtl_rowid = Convert.ToInt32(dt.Rows[i]["In_item_dtl_rowid"]);
                    objList.In_item_code = dt.Rows[i]["In_item_code"].ToString();
                    objList.In_quality = dt.Rows[i]["In_quality"].ToString();
                    objList.In_quality_desc = dt.Rows[i]["In_quality_desc"].ToString();
                    objList.In_base_price = Convert.ToInt32(dt.Rows[i]["In_base_price"]);
                    objList.In_range_1 = dt.Rows[i]["In_range_1"].ToString();
                    objList.In_range_2 = dt.Rows[i]["In_range_2"].ToString();
                    objList.In_range_3 = dt.Rows[i]["In_range_3"].ToString();
                    objList.In_range_4 = dt.Rows[i]["In_range_4"].ToString();
                    objList.In_range_5 = dt.Rows[i]["In_range_5"].ToString();
                    objList.In_status_code = dt.Rows[i]["In_status_code"].ToString();
                    objList.In_mode_flag = dt.Rows[i]["In_mode_flag"].ToString();
                    ObjFetchAll.context.Detail.Add(objList);
                }

                ObjFetchAll.context.Header.In_item_name = (string)cmd.Parameters["In_item_name"].Value.ToString();
                ObjFetchAll.context.Header.In_item_ll_name = (string)cmd.Parameters["In_item_ll_name"].Value.ToString();
                ObjFetchAll.context.Header.In_item_type = (string)cmd.Parameters["In_item_type"].Value.ToString();
                ObjFetchAll.context.Header.In_fg_category = (string)cmd.Parameters["In_fg_category"].Value;
                ObjFetchAll.context.Header.In_fg_subcategory = (string)cmd.Parameters["In_fg_subcategory"].Value.ToString();
                ObjFetchAll.context.Header.In_uom_code = (string)cmd.Parameters["In_uom_code"].Value.ToString();
                ObjFetchAll.context.Header.In_hsn_code = (string)cmd.Parameters["In_hsn_code"].Value.ToString();
                ObjFetchAll.context.Header.In_hsn_description = (string)cmd.Parameters["In_hsn_description"].Value.ToString();
                ObjFetchAll.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                ObjFetchAll.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                ObjFetchAll.context.Header.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();
                ObjFetchAll.context.Header.IOU_item_rowid = (Int32)cmd.Parameters["IOU_item_rowid1"].Value;
                ObjFetchAll.context.Header.IOU_agg_code = (string)cmd.Parameters["IOU_agg_code1"].Value.ToString();
                ObjFetchAll.context.Header.IOU_item_code = (string)cmd.Parameters["IOU_item_code1"].Value.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ObjFetchAll;
        }
    }
}