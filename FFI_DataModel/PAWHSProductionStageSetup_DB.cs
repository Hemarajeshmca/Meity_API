using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
    public class PAWHSProductionStageSetup_DB
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInvoice_DataModel)); //Declaring Log4Net. 
        public PAWHSProductionStageSetupApplication Getallproduce_calendar_DB(PAWHSProductionStageSetupContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();

            PAWHSProductionStageSetupApplication objinvoiceRoot = new PAWHSProductionStageSetupApplication();
            PAWHSProductionStageSetup_DB objDataModel = new PAWHSProductionStageSetup_DB();

            objinvoiceRoot.context = new PAWHSProductionStageSetupContext();
            objinvoiceRoot.context.List = new List<PAWHSProductionStageSetupList>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_production_stagesetup_list", MysqlCon.con);
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
                    PAWHSProductionStageSetupList objList = new PAWHSProductionStageSetupList();
                    objList.Out_production_rowid = Convert.ToInt32(dt.Rows[i]["Out_production_rowid"]);
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
        public PAWHSProductionStageSetupFApplication Getproduce_calendar_DB(PAWHSProductionStageSetupFContext objfpoSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();

            PAWHSProductionStageSetupFApplication objfpoSearchRoot = new PAWHSProductionStageSetupFApplication();
            PAWHSProductionStageSetup_DB objDataModel = new PAWHSProductionStageSetup_DB();

            DataTable Map = new DataTable();


            objfpoSearchRoot.context = new PAWHSProductionStageSetupFContext();
            objfpoSearchRoot.context.Header = new PAWHSProductionStageSetupFHeader();
            objfpoSearchRoot.context.Stage = new List<PAWHSProductionStageSetupFStage>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_production_stagesetup", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;
                cmd.Parameters.Add("IOU_production_rowid", MySqlDbType.Int32).Value = objfpoSearch.production_rowid;
                cmd.Parameters.Add("IOU_agg_code", MySqlDbType.VarChar).Value = objfpoSearch.agg_code;
                cmd.Parameters.Add(new MySqlParameter("In_fg_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_final_output_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_final_output", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;                
                cmd.Parameters.Add(new MySqlParameter("IOU_production_rowid1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_agg_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();
                if (ds.Tables.Count > 0)
                {
                    Map = ds.Tables[0];

                    for (int i = 0; i < Map.Rows.Count; i++)
                    {
                        PAWHSProductionStageSetupFStage objDetailList = new PAWHSProductionStageSetupFStage();
                        objDetailList.In_stage_rowid = Convert.ToInt32(Map.Rows[i]["In_stage_rowid"]);
                        objDetailList.In_stage_code = Map.Rows[i]["In_stage_code"].ToString();
                        objDetailList.In_stage_desc = Map.Rows[i]["In_stage_desc"].ToString();                       
                        objDetailList.In_seq_no = Convert.ToInt32(Map.Rows[i]["In_seq_no"]);                        
                        objDetailList.In_status_code = Map.Rows[i]["In_status_code"].ToString();
                        objDetailList.In_status_desc = Map.Rows[i]["In_status_desc"].ToString();
                        objDetailList.In_mode_flag = Map.Rows[i]["In_mode_flag"].ToString();
                        objfpoSearchRoot.context.Stage.Add(objDetailList);
                    }
                    objfpoSearchRoot.context.orgnId = objfpoSearch.orgnId;
                    objfpoSearchRoot.context.locnId = objfpoSearch.locnId;
                    objfpoSearchRoot.context.userId = objfpoSearch.userId;
                    objfpoSearchRoot.context.localeId = objfpoSearch.localeId;

                    objfpoSearchRoot.context.Header.IOU_production_rowid = (Int32)cmd.Parameters["IOU_production_rowid"].Value;
                    objfpoSearchRoot.context.Header.IOU_agg_code = (string)cmd.Parameters["IOU_agg_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_fg_code = (string)cmd.Parameters["In_fg_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_final_output_code = (string)cmd.Parameters["In_final_output_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_final_output = (string)cmd.Parameters["In_final_output"].Value.ToString();                   
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
        public PAWHSProductionStageSetupSDocument Savenew_produce_calendar_DB(PAWHSProductionStageSetupSApplication ObjContext, string mysqlcon)
        {
            int ret = 0;
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            PAWHSProductionStageSetupSDocument objresFarmer = new PAWHSProductionStageSetupSDocument();
            objresFarmer.context = new PAWHSProductionStageSetupSContext();
            objresFarmer.context.Header = new PAWHSProductionStageSetupSHeader();
            objresFarmer.context.Stage = new List<PAWHSProductionStageSetupSStage>();
            objresFarmer.ApplicationException = new PAWHSProductionStageSetupSApplicationException();
            string IOU_fg_code1 = "";
            string errorNo = "";
            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                MySqlCommand cmd = new MySqlCommand("PAWHS_insupd_production_stagesetup", MysqlCon.con);               
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_production_rowid", MySqlDbType.Int32).Value = ObjContext.document.context.Header.In_production_rowid;
                cmd.Parameters.Add("In_agg_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_agg_code;                
                cmd.Parameters.Add("In_final_output_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_final_output_code;
                cmd.Parameters.Add("In_final_output", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_final_output;
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

                if (ret > 0)
                {                   
                    IOU_fg_code1 = (string)cmd.Parameters["IOU_fg_code1"].Value;
                    objresFarmer.context.Header.IOU_fg_code = IOU_fg_code1;

                }
                if (objresFarmer.context.Header.IOU_fg_code !="")
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
        public string[] SaveProcCal(PAWHSProductionStageSetupSApplication Objmodel, PAWHSProductionStageSetupSDocument objfarmer, string MysqlCons, DataConnection MysqlCon)
        {
            string[] result = { };
            string errorNo = "";
            string errorMsg = "";
            DataTable tab = new DataTable();
            PAWHSProductionStageSetupSStage objFarmersMapped = new PAWHSProductionStageSetupSStage();
            try
            {
                PAWHSProductionStageSetup_DB objproduct1 = new PAWHSProductionStageSetup_DB();
                foreach (var FarmersMap in Objmodel.document.context.Stage)
                {
                    objFarmersMapped.In_stage_rowid = FarmersMap.In_stage_rowid;
                    objFarmersMapped.In_stage_code = FarmersMap.In_stage_code;
                    objFarmersMapped.In_seq_no = FarmersMap.In_seq_no;                   
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

        public string[] SaveProcCalNew(PAWHSProductionStageSetupSStage ObjKycDtl, PAWHSProductionStageSetupSDocument ObjFarmer, PAWHSProductionStageSetupSApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {

            string errorNo = "";
            string errorMsg = "";
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_iud_production_stagesetup", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;               
                cmd.Parameters.Add("IOU_fg_code", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.IOU_fg_code;
                cmd.Parameters.Add("In_stage_rowid", MySqlDbType.Int32).Value = ObjKycDtl.In_stage_rowid;
                cmd.Parameters.Add("In_stage_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_stage_code;
                cmd.Parameters.Add("In_seq_no", MySqlDbType.Int32).Value = ObjKycDtl.In_seq_no;               
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
