using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
   public class PAWHSAggVSFarmap_DB
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInvoice_DataModel)); //Declaring Log4Net. 
        public PAWHSAggVSFarmapApplication Getallmapped_farmers_DB(PAWHSAggVSFarmapContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();

            PAWHSAggVSFarmapApplication objinvoiceRoot = new PAWHSAggVSFarmapApplication();
            PAWHSAggVSFarmap_DB objDataModel = new PAWHSAggVSFarmap_DB();

            objinvoiceRoot.context = new PAWHSAggVSFarmapContext();
            objinvoiceRoot.context.List = new List<PAWHSAggVSFarmapList>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_mapped_farmers_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_filterby_option", MySqlDbType.VarChar).Value = objinvoice.Filter.FilterBy_Option;
                cmd.Parameters.Add("In_filterby_code", MySqlDbType.VarChar).Value = objinvoice.Filter.FilterBy_Code;
                cmd.Parameters.Add("In_filterby_fromvalue", MySqlDbType.VarChar).Value = objinvoice.Filter.FilterBy_FromValue;
                cmd.Parameters.Add("In_filterby_tovalue", MySqlDbType.VarChar).Value = objinvoice.Filter.FilterBy_ToValue;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PAWHSAggVSFarmapList objList = new PAWHSAggVSFarmapList();
                    objList.In_farmer_rowid = Convert.ToInt32(dt.Rows[i]["In_farmer_rowid"]);
                    objList.In_farmer_id = dt.Rows[i]["In_farmer_id"].ToString();
                    objList.In_pa_id = dt.Rows[i]["In_pa_id"].ToString();
                    objList.In_given_name = dt.Rows[i]["In_given_name"].ToString();
                    objList.In_sur_name = dt.Rows[i]["In_sur_name"].ToString();
                    objList.In_village_code = dt.Rows[i]["In_village_code"].ToString();
                    objList.In_village_name = dt.Rows[i]["In_village_name"].ToString();
                    objList.In_dob = dt.Rows[i]["In_dob"].ToString();
                    objList.In_gender = dt.Rows[i]["In_gender"].ToString();
                    objList.In_regd_mobile_no = dt.Rows[i]["In_regd_mobile_no"].ToString();
                    objList.In_status_code = dt.Rows[i]["In_status_code"].ToString();
                    objList.In_status_desc = dt.Rows[i]["In_status_desc"].ToString();
                    objList.In_mode_flag = dt.Rows[i]["In_mode_flag"].ToString();
                    objList.In_row_timestamp = dt.Rows[i]["In_row_timestamp"].ToString();
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
        public PAWHSAggVSFarmapFApplication Getaggr_farmer_map_DB(PAWHSAggVSFarmapFContext objfpoSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();

            PAWHSAggVSFarmapFApplication objfpoSearchRoot = new PAWHSAggVSFarmapFApplication();
            PAWHSAggVSFarmap_DB objDataModel = new PAWHSAggVSFarmap_DB();

            DataTable Map = new DataTable();


            objfpoSearchRoot.context = new PAWHSAggVSFarmapFContext();
            objfpoSearchRoot.context.Header = new PAWHSAggVSFarmapFHeader();
            objfpoSearchRoot.context.FarmersNotMapped = new List<PAWHSAggVSFarmapFFarmersNotMapped>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_AggregatorVsFarMap", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;               
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;
                cmd.Parameters.Add("IOU_agg_farmer_rowid", MySqlDbType.VarChar).Value = objfpoSearch.Header.IOU_agg_farmer_rowid;
                cmd.Parameters.Add("IOU_agg_code", MySqlDbType.VarChar).Value = objfpoSearch.Header.IOU_agg_code;
                cmd.Parameters.Add(new MySqlParameter("IOU_agg_farmer_rowid1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_agg_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_aggregator_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_village_covered_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_village_covered_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();
                if (ds.Tables.Count > 0)
                {
                    Map = ds.Tables[0];

                    for (int i = 0; i < Map.Rows.Count; i++)
                    {
                        PAWHSAggVSFarmapFFarmersNotMapped objDetailList = new PAWHSAggVSFarmapFFarmersNotMapped();
                        objDetailList.In_farmer_rowid = Convert.ToInt32(Map.Rows[i]["In_farmer_rowid"]);
                        objDetailList.In_farmer_id = Map.Rows[i]["In_farmer_id"].ToString();
                        objDetailList.In_given_name = Map.Rows[i]["In_given_name"].ToString();
                        objDetailList.In_sur_name = Map.Rows[i]["In_sur_name"].ToString();
                        objDetailList.In_village_name = Map.Rows[i]["In_village_name"].ToString();
                        objDetailList.In_dob = Map.Rows[i]["In_dob"].ToString();
                        objDetailList.In_gender = Map.Rows[i]["In_gender"].ToString();
                        objDetailList.In_regd_mobile_no = Map.Rows[i]["In_regd_mobile_no"].ToString();
                        objDetailList.In_status_code = Map.Rows[i]["In_status_code"].ToString();
                        objDetailList.In_status_desc = Map.Rows[i]["In_status_desc"].ToString();                       
                        objDetailList.In_mode_flag = Map.Rows[i]["In_mode_flag"].ToString();
                        objfpoSearchRoot.context.FarmersNotMapped.Add(objDetailList);
                    }
                    objfpoSearchRoot.context.orgnId = objfpoSearch.orgnId;
                    objfpoSearchRoot.context.locnId = objfpoSearch.locnId;
                    objfpoSearchRoot.context.userId = objfpoSearch.userId;
                    objfpoSearchRoot.context.localeId = objfpoSearch.localeId;

                    objfpoSearchRoot.context.Header.IOU_agg_farmer_rowid = (Int32)cmd.Parameters["IOU_agg_farmer_rowid"].Value;
                    objfpoSearchRoot.context.Header.IOU_agg_code = (string)cmd.Parameters["IOU_agg_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_aggregator_name = (string)cmd.Parameters["In_aggregator_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_village_covered_code = (string)cmd.Parameters["In_village_covered_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_village_covered_name = (string)cmd.Parameters["In_village_covered_name"].Value.ToString();
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
        public PAWHSAggVSFarmapSDocument Savenew_aggr_vs_farmer_mapping_DB(PAWHSAggVSFarmapSApplication ObjContext, string mysqlcon)
        {
            int ret = 0;
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            PAWHSAggVSFarmapSDocument objresFarmer = new PAWHSAggVSFarmapSDocument();
            objresFarmer.context = new PAWHSAggVSFarmapSContext();
            objresFarmer.context.Header = new PAWHSAggVSFarmapSHeader();
            objresFarmer.context.FarmersMapped = new List<PAWHSAggVSFarmapSFarmersMapped>();
            objresFarmer.ApplicationException = new PAWHSAggVSFarmapSApplicationException();
            string IOU_agg_farmer_rowid1 ="";
            string IOU_agg_code1 = "";
            string errorNo = "";
            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                    MySqlCommand cmd = new MySqlCommand("PAWHS_insupd_aggVsFarMap", MysqlCon.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_aggregator_name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_aggregator_name;
                cmd.Parameters.Add("In_village_covered_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_village_covered_code;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_row_timestamp;               
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                    cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                    cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                    cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmd.Parameters.Add("IOU_agg_farmer_rowid", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_agg_farmer_rowid;
                cmd.Parameters.Add("IOU_agg_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_agg_code;
                cmd.Parameters.Add(new MySqlParameter("IOU_agg_farmer_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_agg_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                
                if (ret >= 0)
                {
                    IOU_agg_code1 = (string)cmd.Parameters["IOU_agg_code1"].Value;
                   
                    objresFarmer.context.Header.IOU_agg_code = IOU_agg_code1; 
                }
                if (objresFarmer.context.Header.IOU_agg_farmer_rowid >= 0)
                {
                    string[] FarmersMapped = { };
                    FarmersMapped = SaveFarmersMapped(ObjContext, objresFarmer, mysqlcon, MysqlCon);
                    if (FarmersMapped[0].Contains("060"))
                    {
                        mysqltrans.Rollback();
                        objresFarmer.ApplicationException.errorNumber = FarmersMapped[0].ToString();
                        objresFarmer.ApplicationException.errorDescription = FarmersMapped[1].ToString();
                        return objresFarmer;
                    }                    
                }
                string[] returnvalues = { IOU_agg_farmer_rowid1, IOU_agg_code1, errorNo };

                mysqltrans.Commit();
                return objresFarmer;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                throw ex;

            }
        }
        public string[] SaveFarmersMapped(PAWHSAggVSFarmapSApplication Objmodel, PAWHSAggVSFarmapSDocument objfarmer, string MysqlCons, DataConnection MysqlCon)
        {
            string[] result = { };
            string errorNo = "";
            string errorMsg = "";
            DataTable tab = new DataTable();
            PAWHSAggVSFarmapSFarmersMapped objFarmersMapped = new PAWHSAggVSFarmapSFarmersMapped();
            try
            {
                PAWHSAggVSFarmap_DB objproduct1 = new PAWHSAggVSFarmap_DB();
                foreach (var FarmersMap in Objmodel.document.context.FarmersMapped)
                {
                    objFarmersMapped.In_dob = FarmersMap.In_dob;
                    objFarmersMapped.In_farmer_id = FarmersMap.In_farmer_id;
                    objFarmersMapped.In_farmer_rowid = FarmersMap.In_farmer_rowid;
                    objFarmersMapped.In_gender = FarmersMap.In_gender;
                    objFarmersMapped.In_given_name = FarmersMap.In_given_name;
                    objFarmersMapped.In_mode_flag = FarmersMap.In_mode_flag;
                    objFarmersMapped.In_pa_id = FarmersMap.In_pa_id;
                    objFarmersMapped.In_regd_mobile_no = FarmersMap.In_regd_mobile_no;
                    objFarmersMapped.In_status_code = FarmersMap.In_status_code;
                    objFarmersMapped.In_sur_name = FarmersMap.In_sur_name;
                    objFarmersMapped.In_village_name = FarmersMap.In_village_name;
                    result = objproduct1.SaveFarmersMappedcNew(objFarmersMapped, objfarmer, Objmodel, MysqlCons, MysqlCon);

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

        public string[] SaveFarmersMappedcNew(PAWHSAggVSFarmapSFarmersMapped ObjKycDtl, PAWHSAggVSFarmapSDocument ObjFarmer, PAWHSAggVSFarmapSApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {

            string errorNo = "";
            string errorMsg = "";
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_iud_farmers_mapped", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("IN_agg_farmer_rowid", MySqlDbType.Int32).Value = ObjFarmer.context.Header.IOU_agg_farmer_rowid;
                cmd.Parameters.Add("IN_agg_code", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.IOU_agg_code;
                cmd.Parameters.Add("IN_farmer_rowid", MySqlDbType.Int32).Value = ObjKycDtl.In_farmer_rowid;
                cmd.Parameters.Add("IN_farmer_id", MySqlDbType.VarChar).Value = ObjKycDtl.In_farmer_id;
                cmd.Parameters.Add("IN_pa_id", MySqlDbType.VarChar).Value = ObjKycDtl.In_pa_id;
                cmd.Parameters.Add("IN_given_name", MySqlDbType.VarChar).Value = ObjKycDtl.In_given_name;
                cmd.Parameters.Add("IN_sur_name", MySqlDbType.VarChar).Value = ObjKycDtl.In_sur_name;
                cmd.Parameters.Add("IN_village_name", MySqlDbType.VarChar).Value = ObjKycDtl.In_village_name;
                cmd.Parameters.Add("IN_dob", MySqlDbType.VarChar).Value = ObjKycDtl.In_dob;
                cmd.Parameters.Add("IN_gender", MySqlDbType.VarChar).Value = ObjKycDtl.In_gender;
                cmd.Parameters.Add("IN_regd_mobile_no", MySqlDbType.VarChar).Value = ObjKycDtl.In_regd_mobile_no;
                cmd.Parameters.Add("IN_status_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_status_code;
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
