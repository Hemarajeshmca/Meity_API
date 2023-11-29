using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using static FFI_Model.New_Pawhs_BatchCreation_Model;

namespace FFI_DataModel
{
    public class New_Pawhs_BatchCreation_DataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(New_Pawhs_BatchCreation_DataModel)); //Declaring Log4Net. 
        string methodName = MethodBase.GetCurrentMethod().Name;

        public PawhsBatchCreationApplication PawhsBatchCreation_List(PawhsBatchCreationContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            PawhsBatchCreationApplication ObjFetchAll = new PawhsBatchCreationApplication();
            ObjFetchAll.context = new PawhsBatchCreationContext();
            ObjFetchAll.context.List = new List<PawhsBatchCreationList>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_fetch_Batch_Creation_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("In_filterby_option", MySqlDbType.VarChar).Value = ObjContext.FilterBy_Option;
                cmd.Parameters.Add("In_filterby_code", MySqlDbType.VarChar).Value = ObjContext.FilterBy_Code;
                cmd.Parameters.Add("In_filterby_fromvalue", MySqlDbType.VarChar).Value = ObjContext.FilterBy_FromValue;
                cmd.Parameters.Add("In_filterby_tovalue", MySqlDbType.VarChar).Value = ObjContext.FilterBy_ToValue;
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PawhsBatchCreationList objList = new PawhsBatchCreationList();
                    objList.Out_agg_code = dt.Rows[i]["Out_agg_code"].ToString();
                    objList.Out_batch_no = dt.Rows[i]["Out_batch_no"].ToString();
                    objList.Out_created_datetime = dt.Rows[i]["Out_created_datetime"].ToString();
                    objList.Out_no_of_vehicles = Convert.ToInt32(dt.Rows[i]["Out_no_of_vehicles"]);
                    objList.Out_no_of_lots = Convert.ToInt32(dt.Rows[i]["Out_no_of_lots"]);
                    ObjFetchAll.context.List.Add(objList);
                }
                ObjFetchAll.context.orgnId = ObjContext.orgnId;
                ObjFetchAll.context.locnId = ObjContext.locnId;
                ObjFetchAll.context.userId = ObjContext.userId;
                ObjFetchAll.context.localeId = ObjContext.localeId;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }

            return ObjFetchAll;
        }
        public PawhsBatchCreationLotApplication PawhsBatchCreationLotNo_List(PawhsBatchCreationLotContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            PawhsBatchCreationLotApplication ObjFetchAll = new PawhsBatchCreationLotApplication();
            ObjFetchAll.Context = new PawhsBatchCreationLotContext();
            ObjFetchAll.Context.List = new List<PawhsBatchCreationLotList>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_fetch_Batch_LotList", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("In_vehicle_no", MySqlDbType.VarChar).Value = ObjContext.In_vehicle_no;
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PawhsBatchCreationLotList objList = new PawhsBatchCreationLotList();
                    objList.In_act_row_id = Convert.ToInt32(dt.Rows[i]["In_act_row_id"]);
                    objList.In_orgn_code = dt.Rows[i]["In_orgn_code"].ToString();
                    objList.In_agg_code = dt.Rows[i]["In_agg_code"].ToString();
                    objList.In_lotno = dt.Rows[i]["In_lotno"].ToString();
                    objList.In_vehicle_no = dt.Rows[i]["In_vehicle_no"].ToString();
                    objList.In_farmer_code = dt.Rows[i]["In_farmer_code"].ToString();
                    objList.In_farmer_name = dt.Rows[i]["In_farmer_name"].ToString();
                    objList.In_member_type = dt.Rows[i]["In_member_type"].ToString();
                    objList.In_item_code = dt.Rows[i]["In_item_code"].ToString();
                    objList.In_item_name = dt.Rows[i]["In_item_name"].ToString();
                    objList.In_actual_qty = Convert.ToDouble(dt.Rows[i]["In_actual_qty"]);
                    objList.In_actual_price = Convert.ToDouble(dt.Rows[i]["In_actual_price"]);
                    objList.In_actual_value = Convert.ToDouble(dt.Rows[i]["In_actual_value"]);
                    objList.In_advance_amt = Convert.ToDouble(dt.Rows[i]["In_advance_amt"]);
                    objList.In_no_of_bags = Convert.ToInt32(dt.Rows[i]["In_no_of_bags"]);
                    ObjFetchAll.Context.List.Add(objList);
                }
                ObjFetchAll.Context.orgnId = ObjContext.orgnId;
                ObjFetchAll.Context.locnId = ObjContext.locnId;
                ObjFetchAll.Context.userId = ObjContext.userId;
                ObjFetchAll.Context.localeId = ObjContext.localeId;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }

            return ObjFetchAll;
        }
        public PAWHSBatchCreation_Save_Document NewSaveBatchCreation(PAWHSBatchCreation_Save_Application ObjContext, string mysqlcon)
        {
            int ret = 0;
            string errmsg = "";
            int Transportdtl = 0;
            int OtherDtls = 0;
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            PAWHSBatchCreation_Save_Document objresFarmer = new PAWHSBatchCreation_Save_Document();
            objresFarmer.ApplicationException = new PawhsBatchCreationApplicationException();
            objresFarmer.context = new PAWHSBatchCreation_Save_Context();
            objresFarmer.context.Header = new List<PAWHSBacthCreation_Save_Header>();
            objresFarmer.context.OtherDtl = new List<PAWHSBatchCreation_Save_Otherdtl>();
            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                MySqlCommand cmd = new MySqlCommand("New_PAWHS_Ins_BatchCreation", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("Out_batch_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_error_msg", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                errmsg = (string)cmd.Parameters["Out_error_msg"].Value;
                if (errmsg != "")
                {
                    mysqltrans.Rollback();
                    objresFarmer.ApplicationException.errorDescription = (string)cmd.Parameters["Out_error_msg"].Value;
                    return objresFarmer;
                }
                else
                {

                    objresFarmer.context.Out_batch_no = (string)cmd.Parameters["Out_batch_no"].Value;
                    objresFarmer.context.Out_error_msg = (string)cmd.Parameters["Out_error_msg"].Value;
                    objresFarmer.context.orgnId = ObjContext.document.context.orgnId;
                    objresFarmer.context.locnId = ObjContext.document.context.locnId;
                    objresFarmer.context.userId = ObjContext.document.context.userId;
                    objresFarmer.context.localeId = ObjContext.document.context.localeId;
                    objresFarmer.context.in_selected_lot_id = ObjContext.document.context.in_selected_lot_id;
                    objresFarmer.ApplicationException.errorDescription = (string)cmd.Parameters["Out_error_msg"].Value;

                }
                if (objresFarmer.context.Out_batch_no != "")
                {
                    Transportdtl = SaveTransportDtl(ObjContext, objresFarmer, mysqlcon, MysqlCon);
                    if (Transportdtl == 0)
                    {
                        objresFarmer.ApplicationException.errorDescription = "Transport Details Not available";
                        mysqltrans.Rollback();
                        return objresFarmer;
                    }
                    OtherDtls = SaveOtherDtls(ObjContext, objresFarmer, mysqlcon, MysqlCon);
                    if (OtherDtls == 0)
                    {
                        objresFarmer.ApplicationException.errorDescription = "Other Details Not available";
                        mysqltrans.Rollback();
                        return objresFarmer;
                    }
                }

                mysqltrans.Commit();

            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                throw ex;
            }
            return objresFarmer;
        }
        public int SaveTransportDtl(PAWHSBatchCreation_Save_Application Objmodel, PAWHSBatchCreation_Save_Document objfarmer, string MysqlCons, DataConnection MysqlCon)
        {
            int ret = 0;
            DataTable tab = new DataTable();
            PAWHSBacthCreation_Save_Header objFarmersMapped = new PAWHSBacthCreation_Save_Header();
            try
            {
                foreach (var TranpotDetails in Objmodel.document.context.Header)
                {

                    MySqlCommand cmd = new MySqlCommand("New_PAWHS_Ins_Batch_Transport", MysqlCon.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("In_batch_no", MySqlDbType.VarChar).Value = objfarmer.context.Out_batch_no;
                    cmd.Parameters.Add("In_vehicle_no", MySqlDbType.VarChar).Value = TranpotDetails.In_vehicle_no;
                    cmd.Parameters.Add("In_total_no_of_lots", MySqlDbType.Int32).Value = TranpotDetails.In_Total_No_of_lots;
                    cmd.Parameters.Add("In_batchcreate_lots", MySqlDbType.Int32).Value = TranpotDetails.In_No_of_batch_creation;
                    cmd.Parameters.Add("In_pending_lots", MySqlDbType.Int32).Value = TranpotDetails.In_No_of_Pending;
                    cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = TranpotDetails.in_mode_flag;
                    cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                    cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                    cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                    cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                    cmd.Parameters.Add(new MySqlParameter("Out_batch_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new MySqlParameter("Out_error_msg", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                    ret = cmd.ExecuteNonQuery();

                    if (ret == 0)
                    {
                        break;
                    }

                }
                return ret;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                throw ex;
            }
        }
        public int SaveOtherDtls(PAWHSBatchCreation_Save_Application Objmodel, PAWHSBatchCreation_Save_Document objfarmer, string MysqlCons, DataConnection MysqlCon)
        {
            int ret = 0;
            int batchOtherdtl = 0;
            DataTable tab = new DataTable();
            PAWHSBacthCreation_Save_Header objFarmersMapped = new PAWHSBacthCreation_Save_Header();
            try
            {
                foreach (var OtherDetails in Objmodel.document.context.OtherDtl)
                {

                    MySqlCommand cmd = new MySqlCommand("New_PAWHS_iud_Batch_Otherdtl", MysqlCon.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("In_batch_other_id", MySqlDbType.Int32).Value = OtherDetails.In_batch_other_id;
                    cmd.Parameters.Add("In_batch_no", MySqlDbType.VarChar).Value = objfarmer.context.Out_batch_no;
                    cmd.Parameters.Add("In_cost_name", MySqlDbType.VarChar).Value = OtherDetails.In_cost_name;
                    cmd.Parameters.Add("In_cost_value", MySqlDbType.Double).Value = OtherDetails.In_cost_value;
                    cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = OtherDetails.in_mode_flag;
                    cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                    cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                    cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                    cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                    cmd.Parameters.Add("in_selected_lot_id", MySqlDbType.LongText).Value = Objmodel.document.context.in_selected_lot_id;
                    cmd.Parameters.Add(new MySqlParameter("inout_batchotherdtl_row_id", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new MySqlParameter("inout_batchno", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                    ret = cmd.ExecuteNonQuery();
                    batchOtherdtl = (Int32)cmd.Parameters["inout_batchotherdtl_row_id"].Value;
                    if (batchOtherdtl == 0)
                    {
                        break;
                    }

                }
                return batchOtherdtl;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                throw ex;
            }
        }
        public PAWHSBatchCreationFetchApplication Single_BatchCreation(PAWHSBatchCreation_FetchContext objfpoSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();

            PAWHSBatchCreationFetchApplication objfpoSearchRoot = new PAWHSBatchCreationFetchApplication();
            objfpoSearchRoot.context = new PAWHSBatchCreation_FetchContext();
            objfpoSearchRoot.context.Header = new List<PAWHSBatchCreation_FetchHeader>();
            objfpoSearchRoot.context.BatchList = new List<PAWHSBatchCreation_FetchBatch_List>();
            objfpoSearchRoot.context.OtherList = new List<PAWHSBatchCreation_FetchOther_List>();

            DataTable BatchList = new DataTable();
            DataTable TranList = new DataTable();
            DataTable OtherList = new DataTable();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("New_PAWHS_Fetch_Batch_Creation", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;
                cmd.Parameters.Add("In_batch_no", MySqlDbType.VarChar).Value = objfpoSearch.In_batch_no;
                cmd.Parameters.Add(new MySqlParameter("IOU_agg_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_batch_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();
                if (ds.Tables.Count > 0)
                {
                    TranList = ds.Tables[0];
                    for (int i = 0; i < TranList.Rows.Count; i++)
                    {
                        PAWHSBatchCreation_FetchHeader HeaderList = new PAWHSBatchCreation_FetchHeader();
                        HeaderList.In_batch_rowid = Convert.ToInt32(TranList.Rows[i]["In_batch_rowid"]);
                        HeaderList.In_vehicle_no = TranList.Rows[i]["In_vehicle_no"].ToString();
                        HeaderList.In_Total_No_of_lots = Convert.ToInt32(TranList.Rows[i]["In_Total_No_of_lots"]);
                        HeaderList.In_No_of_batch_creation = Convert.ToInt32(TranList.Rows[i]["In_No_of_batch_creation"]);
                        HeaderList.In_No_of_Pending = Convert.ToInt32(TranList.Rows[i]["In_No_of_Pending"]);
                        HeaderList.in_mode_flag = "I";
                        objfpoSearchRoot.context.Header.Add(HeaderList);
                    }
                    BatchList = ds.Tables[1];
                    for (int i = 0; i < BatchList.Rows.Count; i++)
                    {
                        PAWHSBatchCreation_FetchBatch_List objDetailList = new PAWHSBatchCreation_FetchBatch_List();
                        objDetailList.In_act_row_id = Convert.ToInt32(BatchList.Rows[i]["In_act_row_id"]);
                        objDetailList.In_orgn_code = BatchList.Rows[i]["In_orgn_code"].ToString();
                        objDetailList.In_agg_code = BatchList.Rows[i]["In_agg_code"].ToString();
                        objDetailList.In_lotno = BatchList.Rows[i]["In_lotno"].ToString();
                        objDetailList.In_vehicle_no = BatchList.Rows[i]["In_vehicle_no"].ToString();
                        objDetailList.In_farmer_code = BatchList.Rows[i]["In_farmer_code"].ToString();
                        objDetailList.In_farmer_name = BatchList.Rows[i]["In_farmer_name"].ToString();
                        objDetailList.In_member_type = BatchList.Rows[i]["In_member_type"].ToString();
                        objDetailList.In_item_code = BatchList.Rows[i]["In_item_code"].ToString();
                        objDetailList.In_item_name = BatchList.Rows[i]["In_item_name"].ToString();
                        objDetailList.In_actual_qty = Convert.ToDouble(BatchList.Rows[i]["In_actual_qty"]);
                        objDetailList.In_actual_price = Convert.ToDouble(BatchList.Rows[i]["In_actual_price"]);
                        objDetailList.In_actual_value = Convert.ToDouble(BatchList.Rows[i]["In_actual_value"]);
                        objDetailList.In_advance_amt = Convert.ToDouble(BatchList.Rows[i]["In_advance_amt"]);
                        objDetailList.In_no_of_bags = Convert.ToInt32(BatchList.Rows[i]["In_no_of_bags"]);
                        objfpoSearchRoot.context.BatchList.Add(objDetailList);
                    }
                    OtherList = ds.Tables[2];
                    for (int i = 0; i < OtherList.Rows.Count; i++)
                    {
                        PAWHSBatchCreation_FetchOther_List ObjOtherList = new PAWHSBatchCreation_FetchOther_List();
                        ObjOtherList.In_batch_other_id = Convert.ToInt32(OtherList.Rows[i]["In_batch_other_id"]);
                        ObjOtherList.In_batch_no = OtherList.Rows[i]["In_batch_no"].ToString();
                        ObjOtherList.In_cost_name = OtherList.Rows[i]["In_cost_name"].ToString();
                        ObjOtherList.In_cost_value = Convert.ToDouble(OtherList.Rows[i]["In_cost_value"]);
                        objfpoSearchRoot.context.OtherList.Add(ObjOtherList);
                    }

                }
                objfpoSearchRoot.context.orgnId = objfpoSearch.orgnId;
                objfpoSearchRoot.context.locnId = objfpoSearch.locnId;
                objfpoSearchRoot.context.userId = objfpoSearch.userId;
                objfpoSearchRoot.context.localeId = objfpoSearch.localeId;
                objfpoSearchRoot.context.IOU_batch_no = (string)cmd.Parameters["IOU_batch_no"].Value.ToString();
                objfpoSearchRoot.context.IOU_agg_code = (string)cmd.Parameters["IOU_agg_code"].Value.ToString();
               

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objfpoSearchRoot;

        }
    }
}
