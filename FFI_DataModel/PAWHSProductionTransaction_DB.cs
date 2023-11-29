using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
   public class PAWHSProductionTransaction_DB
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSProductionTransaction_DB)); //Declaring Log4Net. 
        public PAWHSProductionTransactionApplication Getallproduction_transaction_DB(PAWHSProductionTransactionContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();

            PAWHSProductionTransactionApplication objinvoiceRoot = new PAWHSProductionTransactionApplication();
            PAWHSProductionTransaction_DB objDataModel = new PAWHSProductionTransaction_DB();

            objinvoiceRoot.context = new PAWHSProductionTransactionContext();
            objinvoiceRoot.context.List = new List<PAWHSProductionTransactionList>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_production_trans_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
                cmd.Parameters.Add("In_filterby_option", MySqlDbType.VarChar).Value = objinvoice.FilterBy_Option;
                cmd.Parameters.Add("In_filterby_code", MySqlDbType.VarChar).Value = objinvoice.FilterBy_Code;
                cmd.Parameters.Add("In_filterby_fromvalue", MySqlDbType.VarChar).Value = objinvoice.FilterBy_FromValue;
                cmd.Parameters.Add("In_filterby_tovalue", MySqlDbType.VarChar).Value = objinvoice.FilterBy_ToValue;


                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PAWHSProductionTransactionList objList = new PAWHSProductionTransactionList();
                    objList.Out_pro_tran_rowid = Convert.ToInt32(dt.Rows[i]["Out_pro_tran_rowid"]);
                    objList.Out_fg_code = dt.Rows[i]["Out_fg_code"].ToString();
                    objList.Out_fg_desc = dt.Rows[i]["Out_fg_desc"].ToString();
                    objList.Out_stage_document_id = dt.Rows[i]["Out_stage_document_id"].ToString();
                    objList.Out_stage_description = dt.Rows[i]["Out_stage_description"].ToString();
                    objList.Out_stage_start_datetime = dt.Rows[i]["Out_stage_start_datetime"].ToString();
                    objList.Out_stage_end_datetime = dt.Rows[i]["Out_stage_end_datetime"].ToString();                   
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
        public PAWHSProductionTransactionFApplication Getproduction_transaction_DB(PAWHSProductionTransactionFContext objfpoSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();

            PAWHSProductionTransactionFApplication objfpoSearchRoot = new PAWHSProductionTransactionFApplication();
            PAWHSProductionTransaction_DB objDataModel = new PAWHSProductionTransaction_DB();

            DataTable Map = new DataTable();


            objfpoSearchRoot.context = new PAWHSProductionTransactionFContext();
            objfpoSearchRoot.context.Header = new PAWHSProductionTransactionFHeader();
            objfpoSearchRoot.context.List = new List<PAWHSProductionTransactionFList>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_production_transaction", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;
                cmd.Parameters.Add("IOU_pro_tran_rowid", MySqlDbType.VarChar).Value = objfpoSearch.pro_tran_rowid;
                cmd.Parameters.Add("IOU_fg_code", MySqlDbType.VarChar).Value = objfpoSearch.fg_code;
                cmd.Parameters.Add(new MySqlParameter("In_stage_document_id", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_production_stage_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_production_stage_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_stage_start_datetime", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_stage_end_datetime", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_tran_type", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_pro_tran_rowid1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_fg_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();
                if (ds.Tables.Count > 0)
                {
                    Map = ds.Tables[0];

                    for (int i = 0; i < Map.Rows.Count; i++)
                    {
                        PAWHSProductionTransactionFList objDetailList = new PAWHSProductionTransactionFList();
                        objDetailList.In_pro_tran_dtl_rowid = Convert.ToInt32(Map.Rows[i]["In_pro_tran_dtl_rowid"]);
                        objDetailList.In_input_or_output = Map.Rows[i]["In_input_or_output"].ToString();
                        objDetailList.In_uom = Map.Rows[i]["In_uom"].ToString();
                        objDetailList.In_qty = Convert.ToInt32(Map.Rows[i]["In_qty"]);
                        objDetailList.In_status_code = Map.Rows[i]["In_status_code"].ToString();
                        objDetailList.In_status_desc = Map.Rows[i]["In_status_desc"].ToString();
                        objDetailList.In_mode_flag = Map.Rows[i]["In_mode_flag"].ToString();
                        objfpoSearchRoot.context.List.Add(objDetailList);
                    }
                    
                    objfpoSearchRoot.context.Header.In_stage_document_id = (string)cmd.Parameters["In_stage_document_id"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_production_stage_code = (string)cmd.Parameters["In_production_stage_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_production_stage_code = (string)cmd.Parameters["In_production_stage_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_stage_start_datetime = (string)cmd.Parameters["In_stage_start_datetime"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_stage_end_datetime = (string)cmd.Parameters["In_stage_end_datetime"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_tran_type = (string)cmd.Parameters["In_tran_type"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();
                    objfpoSearchRoot.context.Header.IOU_pro_tran_rowid = (Int32)cmd.Parameters["IOU_pro_tran_rowid"].Value;
                    objfpoSearchRoot.context.Header.IOU_fg_code = (string)cmd.Parameters["IOU_fg_code"].Value.ToString();
                    objfpoSearchRoot.context.orgnId = objfpoSearch.orgnId;
                    objfpoSearchRoot.context.locnId = objfpoSearch.locnId;
                    objfpoSearchRoot.context.userId = objfpoSearch.userId;
                    objfpoSearchRoot.context.localeId = objfpoSearch.localeId;


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objfpoSearchRoot;
        }
        public PAWHSProductionTransactionSDocument Savenew_production_transaction_DB(PAWHSProductionTransactionSApplication ObjContext, string mysqlcon)
        {
            int ret = 0;
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            PAWHSProductionTransactionSDocument objresFarmer = new PAWHSProductionTransactionSDocument();
            objresFarmer.context = new PAWHSProductionTransactionSContext();
            objresFarmer.context.Header = new PAWHSProductionTransactionSHeader();
            objresFarmer.context.List = new List<PAWHSProductionTransactionSList>();
            objresFarmer.ApplicationException = new PAWHSProductionTransactionSApplicationException();
            string IOU_fg_code1 = "";
            string IOU_pro_tran_rowid1 = ""; 
            string errorNo = "";
            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                MySqlCommand cmd = new MySqlCommand("PAWHS_insupd_prod_trans", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_stage_document_id", MySqlDbType.Int32).Value = ObjContext.document.context.Header.In_stage_document_id;
                cmd.Parameters.Add("In_production_stage_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_production_stage_code;
                cmd.Parameters.Add("In_stage_start_datetime", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_stage_start_datetime;
                cmd.Parameters.Add("In_stage_end_datetime", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_stage_end_datetime;
                cmd.Parameters.Add("In_tran_type", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_tran_type;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmd.Parameters.Add("IOU_pro_tran_rowid", MySqlDbType.Int32).Value = ObjContext.document.context.Header.IOU_pro_tran_rowid;
                cmd.Parameters.Add("IOU_fg_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_fg_code;
                cmd.Parameters.Add(new MySqlParameter("IOU_pro_tran_rowid1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_fg_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();

                if (ret > 0)
                {
                    IOU_pro_tran_rowid1 = (string)cmd.Parameters["IOU_pro_tran_rowid1"].Value;
                    IOU_fg_code1 = (string)cmd.Parameters["IOU_fg_code1"].Value;
                   
                    objresFarmer.context.Header.IOU_fg_code = IOU_fg_code1;
                    objresFarmer.context.Header.IOU_pro_tran_rowid = Convert.ToInt32(IOU_pro_tran_rowid1);

                }
                if (objresFarmer.context.Header.IOU_fg_code != "")
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
                string[] returnvalues = { IOU_pro_tran_rowid1, IOU_fg_code1, errorNo };

                mysqltrans.Commit();
                return objresFarmer;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                throw ex;

            }
        }
        public string[] SaveProcCal(PAWHSProductionTransactionSApplication Objmodel, PAWHSProductionTransactionSDocument objfarmer, string MysqlCons, DataConnection MysqlCon)
        {
            string[] result = { };
            string errorNo = "";
            string errorMsg = "";
            DataTable tab = new DataTable();
            PAWHSProductionTransactionSList objFarmersMapped = new PAWHSProductionTransactionSList();
            try
            {
                PAWHSProductionTransaction_DB objproduct1 = new PAWHSProductionTransaction_DB();
                foreach (var FarmersMap in Objmodel.document.context.List)
                {
                    objFarmersMapped.In_pro_tran_dtl_rowid = FarmersMap.In_pro_tran_dtl_rowid;
                    objFarmersMapped.In_input_or_output = FarmersMap.In_input_or_output;
                    objFarmersMapped.In_item = FarmersMap.In_item;
                    objFarmersMapped.In_uom = FarmersMap.In_uom;
                    objFarmersMapped.In_qty = FarmersMap.In_qty;
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

        public string[] SaveProcCalNew(PAWHSProductionTransactionSList ObjKycDtl, PAWHSProductionTransactionSDocument ObjFarmer, PAWHSProductionTransactionSApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {

            string errorNo = "";
            string errorMsg = "";
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_iud_prod_trans_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;               
                cmd.Parameters.Add("IOU_pro_tran_rowid", MySqlDbType.Int32).Value = ObjFarmer.context.Header.IOU_pro_tran_rowid;
                cmd.Parameters.Add("IOU_fg_code", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.IOU_fg_code;
                cmd.Parameters.Add("In_pro_tran_dtl_rowid", MySqlDbType.Int32).Value = ObjKycDtl.In_pro_tran_dtl_rowid;
                cmd.Parameters.Add("In_input_or_output", MySqlDbType.VarChar).Value = ObjKycDtl.In_input_or_output;
                cmd.Parameters.Add("In_item", MySqlDbType.VarChar).Value = ObjKycDtl.In_item;
                cmd.Parameters.Add("In_uom", MySqlDbType.VarChar).Value = ObjKycDtl.In_uom;
                cmd.Parameters.Add("In_qty", MySqlDbType.Int32).Value = ObjKycDtl.In_qty;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_status_code;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = ObjKycDtl.In_mode_flag;
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

