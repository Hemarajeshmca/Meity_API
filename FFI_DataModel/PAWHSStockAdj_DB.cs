using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
    public class PAWHSStockAdj_DB
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInvoice_DataModel)); //Declaring Log4Net. 
        public PAWHSStockAdjApplication Getallstock_adjustment_DB(PAWHSStockAdjContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();

            PAWHSStockAdjApplication objinvoiceRoot = new PAWHSStockAdjApplication();
            PAWHSStockAdj_DB objDataModel = new PAWHSStockAdj_DB();

            objinvoiceRoot.context = new PAWHSStockAdjContext();
            objinvoiceRoot.context.List = new List<PAWHSStockAdjList>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_stockadjustment_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
                cmd.Parameters.Add("In_filterby_option", MySqlDbType.VarChar).Value = objinvoice.filterby_option;
                cmd.Parameters.Add("In_filterby_code", MySqlDbType.VarChar).Value = objinvoice.filterby_code;
                cmd.Parameters.Add("In_filterby_fromvalue", MySqlDbType.VarChar).Value = objinvoice.filterby_fromvalue;
                cmd.Parameters.Add("In_filterby_tovalue", MySqlDbType.VarChar).Value = objinvoice.filterby_tovalue;


                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PAWHSStockAdjList objList = new PAWHSStockAdjList();
                    objList.Out_adjustment_rowid = Convert.ToInt32(dt.Rows[i]["Out_adjustment_rowid"]);
                    objList.Out_adjustment_no = dt.Rows[i]["Out_adjustment_no"].ToString();
                    objList.Out_adjustment_date = dt.Rows[i]["Out_adjustment_date"].ToString();                    
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.Out_status_desc = dt.Rows[i]["Out_status_desc"].ToString();                  
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
        public PAWHSStockAdjFApplication Getstock_adjustment_DB(PAWHSStockAdjFContext objfpoSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();

            PAWHSStockAdjFApplication objfpoSearchRoot = new PAWHSStockAdjFApplication();
            PAWHSStockAdj_DB objDataModel = new PAWHSStockAdj_DB();

            DataTable Map = new DataTable();


            objfpoSearchRoot.context = new PAWHSStockAdjFContext();
            objfpoSearchRoot.context.Header = new PAWHSStockAdjFHeader();
            objfpoSearchRoot.context.Detail = new List<PAWHSStockAdjFDetail>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_stockadjustment", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;
                cmd.Parameters.Add("IOU_adjustment_rowid", MySqlDbType.VarChar).Value = objfpoSearch.adjustment_rowid;
                cmd.Parameters.Add("IOU_adjustment_no", MySqlDbType.VarChar).Value = objfpoSearch.adjustment_no;
                cmd.Parameters.Add(new MySqlParameter("In_whs_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_whs_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_adjustment_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;               
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_process_status", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_adjustment_rowid1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_adjustment_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();
                if (ds.Tables.Count > 0)
                {
                    Map = ds.Tables[0];

                    for (int i = 0; i < Map.Rows.Count; i++)
                    {
                        PAWHSStockAdjFDetail objDetailList = new PAWHSStockAdjFDetail();
                        objDetailList.In_adjustmentdtl_rowid = Convert.ToInt32(Map.Rows[i]["In_adjustmentdtl_rowid"]);
                        objDetailList.In_grn_invoiceno = Map.Rows[i]["In_grn_invoiceno"].ToString();
                        objDetailList.In_adjustment_type = Map.Rows[i]["In_adjustment_type"].ToString();
                        objDetailList.In_adjustment_desc = Map.Rows[i]["In_adjustment_desc"].ToString();
                        objDetailList.In_item_code = Map.Rows[i]["In_adjustment_desc"].ToString();
                        objDetailList.In_item_name = Map.Rows[i]["In_item_name"].ToString();
                        objDetailList.In_inward_outward = Map.Rows[i]["In_inward_outward"].ToString();
                        objDetailList.In_uom = Map.Rows[i]["In_uom"].ToString();
                        objDetailList.In_quantity = Convert.ToDouble(Map.Rows[i]["In_quantity"]);
                        objDetailList.In_adjustment_qty = Convert.ToDouble(Map.Rows[i]["In_adjustment_qty"]);
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

                    objfpoSearchRoot.context.Header.IOU_adjustment_rowid = (Int32)cmd.Parameters["IOU_adjustment_rowid"].Value;
                    objfpoSearchRoot.context.Header.IOU_adjustment_no = (string)cmd.Parameters["IOU_adjustment_no"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_whs_code = (string)cmd.Parameters["In_whs_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_whs_name = (string)cmd.Parameters["In_whs_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_adjustment_date = (string)cmd.Parameters["In_adjustment_date"].Value.ToString();                   
                    objfpoSearchRoot.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_process_status = (string)cmd.Parameters["In_process_status"].Value.ToString();
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
        public PAWHSStockAdjSDocument SavenewSaveStockAdjustment_DB(PAWHSStockAdjSApplication ObjContext, string mysqlcon)
        {
            int ret = 0;
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            PAWHSStockAdjSDocument objresFarmer = new PAWHSStockAdjSDocument();
            objresFarmer.context = new PAWHSStockAdjSContext();
            objresFarmer.context.Header = new PAWHSStockAdjSHeader();
            objresFarmer.context.Detail = new List<PAWHSStockAdjSDetail>();
            objresFarmer.ApplicationException = new PAWHSStockAdjSApplicationException();
            string IOU_adjustment_rowid1 = "";
            string IOU_adjustment_no1 = "";
            string errorNo = "";
            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                MySqlCommand cmd = new MySqlCommand("PAWHS_insupd_stock_adjustment", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_whs_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_whs_code;
                cmd.Parameters.Add("In_adjustment_date", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_adjustment_date;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_process_status", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_process_status;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmd.Parameters.Add("IOU_adjustment_rowid", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_adjustment_rowid;
                cmd.Parameters.Add("IOU_adjustment_no", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_adjustment_no;
                cmd.Parameters.Add(new MySqlParameter("IOU_adjustment_rowid1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_adjustment_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();

                if (ret > 0)
                {
                    IOU_adjustment_rowid1 = (string)cmd.Parameters["IOU_adjustment_rowid1"].Value;
                    IOU_adjustment_no1 = (string)cmd.Parameters["IOU_adjustment_no1"].Value;
                   
                    objresFarmer.context.Header.IOU_adjustment_rowid = Convert.ToInt32(IOU_adjustment_rowid1);
                    objresFarmer.context.Header.IOU_adjustment_no = IOU_adjustment_no1;

                }
                if (objresFarmer.context.Header.IOU_adjustment_rowid > 0)
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
                string[] returnvalues = { IOU_adjustment_rowid1, IOU_adjustment_no1, errorNo };

                mysqltrans.Commit();
                return objresFarmer;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                throw ex;

            }
        }
        public string[] SaveProcCal(PAWHSStockAdjSApplication Objmodel, PAWHSStockAdjSDocument objfarmer, string MysqlCons, DataConnection MysqlCon)
        {
            string[] result = { };
            string errorNo = "";
            string errorMsg = "";
            DataTable tab = new DataTable();
            PAWHSStockAdjSDetail objFarmersMapped = new PAWHSStockAdjSDetail();
            try
            {
                PAWHSStockAdj_DB objproduct1 = new PAWHSStockAdj_DB();
                foreach (var FarmersMap in Objmodel.document.context.Detail)
                {
                    objFarmersMapped.In_adjustmentdtl_rowid = FarmersMap.In_adjustmentdtl_rowid;
                    objFarmersMapped.In_grn_invoiceno = FarmersMap.In_grn_invoiceno;
                    objFarmersMapped.In_adjustment_type = FarmersMap.In_adjustment_type;
                    objFarmersMapped.In_item_code = FarmersMap.In_item_code;
                    objFarmersMapped.In_inward_outward = FarmersMap.In_inward_outward;
                    objFarmersMapped.In_uom = FarmersMap.In_uom;
                    objFarmersMapped.In_quantity = FarmersMap.In_quantity;
                    objFarmersMapped.In_adjustment_qty = FarmersMap.In_adjustment_qty;
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

        public string[] SaveProcCalNew(PAWHSStockAdjSDetail ObjKycDtl, PAWHSStockAdjSDocument ObjFarmer, PAWHSStockAdjSApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {
            string errorNo = "";
            string errorMsg = "";
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_iud_stockadjustment_detail", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.Add("In_adjustmentdtl_rowid", MySqlDbType.Int32).Value = ObjKycDtl.In_adjustmentdtl_rowid;
                cmd.Parameters.Add("In_grn_invoiceno", MySqlDbType.VarChar).Value = ObjKycDtl.In_grn_invoiceno;
                cmd.Parameters.Add("In_adjustment_type", MySqlDbType.VarChar).Value = ObjKycDtl.In_adjustment_type;
                cmd.Parameters.Add("In_item_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_item_code;
                cmd.Parameters.Add("In_inward_outward", MySqlDbType.VarChar).Value = ObjKycDtl.In_inward_outward;
                cmd.Parameters.Add("In_uom", MySqlDbType.VarChar).Value = ObjKycDtl.In_uom;
                cmd.Parameters.Add("In_quantity", MySqlDbType.Double).Value = ObjKycDtl.In_quantity;
                cmd.Parameters.Add("In_adjustment_qty", MySqlDbType.Double).Value = ObjKycDtl.In_adjustment_qty;
                cmd.Parameters.Add("In_remarks", MySqlDbType.VarChar).Value = ObjKycDtl.In_remarks;                
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_status_code;               
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjKycDtl.In_mode_flag;
                cmd.Parameters.Add("IOU_adjustment_rowid", MySqlDbType.Int32).Value = ObjFarmer.context.Header.IOU_adjustment_rowid;
                cmd.Parameters.Add("IOU_adjustment_no", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.IOU_adjustment_no;
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
