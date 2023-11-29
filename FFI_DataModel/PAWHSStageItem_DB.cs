using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
   public class PAWHSStageItem_DB
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInvoice_DataModel)); //Declaring Log4Net. 
        public PAWHSStageItemApplication Getallstageitem_definition_Srv(PAWHSStageItemContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();

            PAWHSStageItemApplication objinvoiceRoot = new PAWHSStageItemApplication();
            PAWHSStageItem_DB objDataModel = new PAWHSStageItem_DB();

            objinvoiceRoot.context = new PAWHSStageItemContext();
            objinvoiceRoot.context.List = new List<PAWHSStageItemList>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_stageItemDefinition_list", MysqlCon.con);
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
                    PAWHSStageItemList objList = new PAWHSStageItemList();
                    objList.Out_stage_item_rowid = Convert.ToInt32(dt.Rows[i]["Out_stage_item_rowid"]);
                    objList.Out_aggregator_code = dt.Rows[i]["Out_aggregator_code"].ToString();
                    objList.Out_fg_code = dt.Rows[i]["Out_fg_code"].ToString();
                    objList.Out_no_of_stage = Convert.ToInt32(dt.Rows[i]["Out_no_of_stage"]);
                    objList.Out_final_output = dt.Rows[i]["Out_final_output"].ToString();
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
        public PAWHSStageItemFApplication Getstageitem_definition_DB(PAWHSStageItemFContext objfpoSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();

            PAWHSStageItemFApplication objfpoSearchRoot = new PAWHSStageItemFApplication();
            PAWHSStageItem_DB objDataModel = new PAWHSStageItem_DB();

            DataTable Map = new DataTable();


            objfpoSearchRoot.context = new PAWHSStageItemFContext();
            objfpoSearchRoot.context.Header = new PAWHSStageItemFHeader();
            objfpoSearchRoot.context.Stage = new List<PAWHSStageItemFStage>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_stageItemDefinition", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;
                cmd.Parameters.Add("IOU_stage_rowid", MySqlDbType.VarChar).Value = objfpoSearch.stage_rowid;
                cmd.Parameters.Add("IOU_fg_code", MySqlDbType.VarChar).Value = objfpoSearch.fg_code;
                cmd.Parameters.Add(new MySqlParameter("In_production_stage_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_production_stage_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_stage_rowid1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
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
                        PAWHSStageItemFStage objDetailList = new PAWHSStageItemFStage();
                        objDetailList.In_stage_item_rowid = Convert.ToInt32(Map.Rows[i]["In_stage_item_rowid"]);
                        objDetailList.In_input_output_code = Map.Rows[i]["In_input_output_code"].ToString();
                        objDetailList.In_input_output_desc = Map.Rows[i]["In_input_output_desc"].ToString();
                        objDetailList.In_item_code = Map.Rows[i]["In_item_code"].ToString();
                        objDetailList.In_item_desc = Map.Rows[i]["In_input_output_desc"].ToString();
                        objDetailList.In_uom = Map.Rows[i]["In_uom"].ToString();
                        objDetailList.In_quantity = Convert.ToDouble(Map.Rows[i]["In_quantity"]);
                        objDetailList.In_status_code = Map.Rows[i]["In_status_code"].ToString();
                        objDetailList.In_status_desc = Map.Rows[i]["In_status_desc"].ToString();
                        objDetailList.In_mode_flag = Map.Rows[i]["In_mode_flag"].ToString();
                        objfpoSearchRoot.context.Stage.Add(objDetailList);
                    }
                    objfpoSearchRoot.context.orgnId = objfpoSearch.orgnId;
                    objfpoSearchRoot.context.locnId = objfpoSearch.locnId;
                    objfpoSearchRoot.context.userId = objfpoSearch.userId;
                    objfpoSearchRoot.context.localeId = objfpoSearch.localeId;

                    objfpoSearchRoot.context.Header.IOU_stage_rowid = (Int32)cmd.Parameters["IOU_stage_rowid"].Value;
                    objfpoSearchRoot.context.Header.IOU_fg_code = (string)cmd.Parameters["IOU_fg_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_production_stage_code = (string)cmd.Parameters["In_production_stage_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_production_stage_desc = (string)cmd.Parameters["In_production_stage_desc"].Value.ToString();
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
        public PAWHSStageItemIApplication Getstage_definition_DB(PAWHSStageItemIContext objfpoSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();

            PAWHSStageItemIApplication objfpoSearchRoot = new PAWHSStageItemIApplication();
            PAWHSStageItem_DB objDataModel = new PAWHSStageItem_DB();

            DataTable Map = new DataTable();


            objfpoSearchRoot.context = new PAWHSStageItemIContext();
            objfpoSearchRoot.context.Header = new PAWHSStageItemIHeader();
            objfpoSearchRoot.context.Stage = new List<PAWHSStageItemIStage>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("getProductionStage", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;               
                cmd.Parameters.Add("IOU_fg_code", MySqlDbType.VarChar).Value = objfpoSearch.fg_code;
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
                        PAWHSStageItemIStage objDetailList = new PAWHSStageItemIStage();
                        objDetailList.In_stage_rowid = Convert.ToInt32(Map.Rows[i]["In_stage_rowid"]);
                        objDetailList.In_stage_code = Map.Rows[i]["In_stage_code"].ToString();
                        objDetailList.In_stage_desc = Map.Rows[i]["In_stage_desc"].ToString();
                        objDetailList.In_seq_no = Convert.ToInt32(Map.Rows[i]["In_seq_no"]);
                        objDetailList.In_status_code = Map.Rows[i]["In_status_code"].ToString();
                        objDetailList.In_status_desc = Map.Rows[i]["In_status_desc"].ToString();
                        objfpoSearchRoot.context.Stage.Add(objDetailList);
                    }
                    objfpoSearchRoot.context.orgnId = objfpoSearch.orgnId;
                    objfpoSearchRoot.context.locnId = objfpoSearch.locnId;
                    objfpoSearchRoot.context.userId = objfpoSearch.userId;
                    objfpoSearchRoot.context.localeId = objfpoSearch.localeId;

                    
                    objfpoSearchRoot.context.Header.IOU_fg_code = (string)cmd.Parameters["IOU_fg_code"].Value.ToString();
                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objfpoSearchRoot;
        }
        public PAWHSStageItemSDocument Savenew_produce_calendar_DB(PAWHSStageItemSApplication ObjContext, string mysqlcon)
        {
            int ret = 0;
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            PAWHSStageItemSDocument objresFarmer = new PAWHSStageItemSDocument();
            objresFarmer.context = new PAWHSStageItemSContext();
            objresFarmer.context.Header = new PAWHSStageItemSHeader();
            objresFarmer.context.Stage = new List<PAWHSStageItemSStage>();
            objresFarmer.ApplicationException = new PAWHSStageItemSApplicationException();
            string IOU_fg_code1 = "";
            string errorNo = "";
            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                MySqlCommand cmd = new MySqlCommand("PAWHS_insupd_stage_item_definition", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_stage_rowid", MySqlDbType.Int32).Value = ObjContext.document.context.Header.In_stage_rowid;
                cmd.Parameters.Add("In_production_stage_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_production_stage_code;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmd.Parameters.Add("IOU_fg_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_fg_code;
                cmd.Parameters.Add(new MySqlParameter("IOU_fg_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();

              
                    IOU_fg_code1 = ObjContext.document.context.Header.IOU_fg_code;                   

                    objresFarmer.context.Header.IOU_fg_code = IOU_fg_code1;

               
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
                string[] returnvalues = { IOU_fg_code1, errorNo };

                mysqltrans.Commit();
                return objresFarmer;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                throw ex;

            }
        }
        public string[] SaveProcCal(PAWHSStageItemSApplication Objmodel, PAWHSStageItemSDocument objfarmer, string MysqlCons, DataConnection MysqlCon)
        {
            string[] result = { };
            string errorNo = "";
            string errorMsg = "";
            DataTable tab = new DataTable();
            PAWHSStageItemSStage objFarmersMapped = new PAWHSStageItemSStage();
            try
            {
                PAWHSStageItem_DB objproduct1 = new PAWHSStageItem_DB();
                foreach (var FarmersMap in Objmodel.document.context.Stage)
                {
                    objFarmersMapped.In_stage_item_rowid = FarmersMap.In_stage_item_rowid;
                    objFarmersMapped.In_input_output_code = FarmersMap.In_input_output_code;
                    objFarmersMapped.In_item_code = FarmersMap.In_item_code;
                    objFarmersMapped.In_uom = FarmersMap.In_uom;
                    objFarmersMapped.In_quantity = FarmersMap.In_quantity;
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

        public string[] SaveProcCalNew(PAWHSStageItemSStage ObjKycDtl, PAWHSStageItemSDocument ObjFarmer, PAWHSStageItemSApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {

            string errorNo = "";
            string errorMsg = "";
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_iud_stage_item_definition", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("IOU_fg_code", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.IOU_fg_code;
                cmd.Parameters.Add("In_stage_item_rowid", MySqlDbType.Int32).Value = ObjKycDtl.In_stage_item_rowid;
                cmd.Parameters.Add("In_input_output_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_input_output_code;
                cmd.Parameters.Add("In_item_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_item_code;
                cmd.Parameters.Add("In_uom", MySqlDbType.VarChar).Value = ObjKycDtl.In_uom;
                cmd.Parameters.Add("In_quantity", MySqlDbType.Int32).Value = ObjKycDtl.In_quantity;
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
