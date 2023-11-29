using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FFI_Model;

namespace FFI_DataModel
{
    public class PAWHSProductmaster_Datamodel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();

        public PAWHSProductmasterApplication GetAllProductMasterList(PAWHSProductmasterContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            PAWHSProductmasterApplication ObjFetchAll = new PAWHSProductmasterApplication();
            ObjFetchAll.context = new PAWHSProductmasterContext();
            ObjFetchAll.context.List = new List<PAWHSProductmasterList>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_product_master_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("In_filterby_option", MySqlDbType.VarChar).Value = ObjContext.FilterBy_Option;
                cmd.Parameters.Add("In_filterby_code", MySqlDbType.VarChar).Value = ObjContext.FilterBy_Code;
                cmd.Parameters.Add("In_filterby_fromvalue", MySqlDbType.VarChar).Value = ObjContext.FilterBy_FromValue;
                cmd.Parameters.Add("In_filterby_tovalue", MySqlDbType.VarChar).Value = ObjContext.FilterBy_ToValue;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PAWHSProductmasterList objList = new PAWHSProductmasterList();
                    objList.Out_product_rowid = Convert.ToInt32(dt.Rows[i]["Out_product_rowid"]);
                    objList.Out_pawhs_code = dt.Rows[i]["Out_pawhs_code"].ToString();
                    objList.Out_agg_code = dt.Rows[i]["Out_agg_code"].ToString();
                    objList.Out_agg_name = dt.Rows[i]["Out_agg_name"].ToString();                    
                    objList.Out_product_code = dt.Rows[i]["Out_product_code"].ToString();
                    objList.Out_product_name = dt.Rows[i]["Out_product_name"].ToString();
                    objList.Out_product_name_mst = dt.Rows[i]["Out_product_name_mst"].ToString();
                    objList.Out_product_category_mst = dt.Rows[i]["Out_product_category_mst"].ToString();
                    objList.Out_product_subcategory_mst = dt.Rows[i]["Out_product_subcategory_mst"].ToString();
                    objList.Out_crop_variety = dt.Rows[i]["Out_crop_variety"].ToString();
                    objList.Out_crop_variety_mst = dt.Rows[i]["Out_crop_variety_mst"].ToString();
                    objList.Out_product_category = dt.Rows[i]["Out_product_category"].ToString();
                    objList.Out_product_subcategory = dt.Rows[i]["Out_product_subcategory"].ToString();
                    objList.Out_hsn_code = dt.Rows[i]["Out_hsn_code"].ToString();
                    objList.Out_hsn_desctiption = dt.Rows[i]["Out_hsn_desctiption"].ToString();
                    objList.Out_uomtype_code = dt.Rows[i]["Out_uomtype_code"].ToString();
                    objList.Out_uomtype_code_mst = dt.Rows[i]["Out_uomtype_code_mst"].ToString();
                    objList.Out_value_withtax = dt.Rows[i]["Out_value_withtax"].ToString(); 
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.Out_status_desc = dt.Rows[i]["Out_status_desc"].ToString();
                    objList.Out_row_timestamp = dt.Rows[i]["Out_row_timestamp"].ToString();
                    ObjFetchAll.context.List.Add(objList);
                }
                ObjFetchAll.context.orgnId = ObjContext.orgnId;
                ObjFetchAll.context.locnId = ObjContext.locnId;
                ObjFetchAll.context.userId = ObjContext.userId;
                ObjFetchAll.context.localeId = ObjContext.localeId;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ObjFetchAll;
        }


        public PAWHSProductmasterFApplication Single_ProductMaster(PAWHSProductmasterFContext objfpoSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();

            PAWHSProductmasterFApplication objfpoSearchRoot = new PAWHSProductmasterFApplication();
            PAWHSProductmaster_Datamodel objDataModel = new PAWHSProductmaster_Datamodel();

            DataTable Map = new DataTable();
            objfpoSearchRoot.context = new PAWHSProductmasterFContext();
            objfpoSearchRoot.context.Header = new PAWHSProductmasterFHeader();
            objfpoSearchRoot.context.Detail = new List<PAWHSProductmasterFDetail>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_product_master", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;
                cmd.Parameters.Add("IOU_product_rowid", MySqlDbType.Int32).Value = objfpoSearch.Header.IOU_product_rowid;
                cmd.Parameters.Add("IOU_agg_code", MySqlDbType.VarChar).Value = objfpoSearch.Header.IOU_agg_code;
                cmd.Parameters.Add("IOU_pawhs_code", MySqlDbType.VarChar).Value = objfpoSearch.Header.IOU_pawhs_code;
                cmd.Parameters.Add(new MySqlParameter("In_product_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_product_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_product_name_mst", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_crop_variety", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_crop_variety_mst", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_product_category", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_product_season", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_product_season_mst", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_valuewithtax", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_product_subcategory", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_hsn_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_hsn_code_mst", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_hsn_description", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_uomtype_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_uomtype_code_mst", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_agg_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_product_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;               
                cmd.Parameters.Add(new MySqlParameter("IOU_agg_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_pawhs_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();
                if (ds.Tables.Count > 0)
                {
                    Map = ds.Tables[0];
                    for (int i = 0; i < Map.Rows.Count; i++)
                    {
                        PAWHSProductmasterFDetail objDetailList = new PAWHSProductmasterFDetail();
                        objDetailList.In_product_dtl_rowid = Convert.ToInt32(Map.Rows[i]["In_product_dtl_rowid"]);
                        objDetailList.In_pawhs_code = Map.Rows[i]["In_pawhs_code"].ToString();
                        objDetailList.In_row_slno = Convert.ToInt32(Map.Rows[i]["In_row_slno"].ToString());
                        objDetailList.In_maize_code = Map.Rows[i]["In_maize_code"].ToString();
                        objDetailList.In_maize_name = Map.Rows[i]["In_maize_name"].ToString();
                        objDetailList.In_min_value = Convert.ToDouble(Map.Rows[i]["In_min_value"]);
                        objDetailList.In_max_value = Convert.ToDouble(Map.Rows[i]["In_max_value"]);
                        objDetailList.In_range = Map.Rows[i]["In_maize_range"].ToString();
                        objDetailList.In_maize_interval = Map.Rows[i]["In_maize_interval"].ToString();
                        objDetailList.In_maize_unit = Map.Rows[i]["In_maize_unit"].ToString();
                        objDetailList.In_temp_min_value = Convert.ToDouble(Map.Rows[i]["In_temp_min_value"]);
                        objDetailList.In_temp_max_value = Convert.ToDouble(Map.Rows[i]["In_temp_max_value"]);
                        objDetailList.In_status_code = Map.Rows[i]["In_status_code"].ToString();
                        objDetailList.In_mode_flag = Map.Rows[i]["In_mode_flag"].ToString();
                        objfpoSearchRoot.context.Detail.Add(objDetailList);
                    }
                    objfpoSearchRoot.context.orgnId = objfpoSearch.orgnId;
                    objfpoSearchRoot.context.locnId = objfpoSearch.locnId;
                    objfpoSearchRoot.context.userId = objfpoSearch.userId;
                    objfpoSearchRoot.context.localeId = objfpoSearch.localeId;
                    objfpoSearchRoot.context.Header.IOU_product_rowid = (Int32)cmd.Parameters["IOU_product_rowid1"].Value;
                    objfpoSearchRoot.context.Header.IOU_agg_code = (string)cmd.Parameters["IOU_agg_code1"].Value.ToString();
                    objfpoSearchRoot.context.Header.IOU_agg_name = (string)cmd.Parameters["IOU_agg_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.IOU_pawhs_code = (string)cmd.Parameters["IOU_pawhs_code1"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_product_code = (string)cmd.Parameters["In_product_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_product_name = (string)cmd.Parameters["In_product_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_product_name_mst = (string)cmd.Parameters["In_product_name_mst"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_crop_variety = (string)cmd.Parameters["In_crop_variety"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_crop_variety_mst = (string)cmd.Parameters["In_crop_variety_mst"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_cmb_season = (string)cmd.Parameters["In_product_season"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_cmb_season_mst = (string)cmd.Parameters["In_product_season_mst"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_valuewithtax = (string)cmd.Parameters["In_valuewithtax"].Value.ToString(); 
                    objfpoSearchRoot.context.Header.In_product_category = (string)cmd.Parameters["In_product_category"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_product_subcategory = (string)cmd.Parameters["In_product_subcategory"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_hsn_code = (string)cmd.Parameters["In_hsn_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_hsn_code_mst = (string)cmd.Parameters["In_hsn_code_mst"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_hsn_description = (string)cmd.Parameters["In_hsn_description"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_uomtype_code = (string)cmd.Parameters["In_uomtype_code"].Value.ToString(); 
                    objfpoSearchRoot.context.Header.In_uomtype_code_mst = (string)cmd.Parameters["In_uomtype_code_mst"].Value.ToString();
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

        public PAWHSProductmasterSDocument newSaveProductMaster(PAWHSProductmasterSApplication ObjContext, string mysqlcon)
        {
            int ret = 0;
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            PAWHSProductmasterSDocument objresFarmer = new PAWHSProductmasterSDocument();
            objresFarmer.ApplicationException = new PAWHSProductmasteApplicationException();
            objresFarmer.context = new PAWHSProductmasterSContext();
            objresFarmer.context.Header = new PAWHSProductmasterSHeader();
            objresFarmer.context.Detail = new List<PAWHSProductmastersDetail>();
            int IOU_product_rowid1 = 0;
            string IOU_pawhs_code1 = "";
            string IOU_Error = "";
            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                MySqlCommand cmd = new MySqlCommand("PAWHS_insupd_product_master", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_agg_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_agg_code;
                cmd.Parameters.Add("In_product_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_product_code;
                cmd.Parameters.Add("In_product_season", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_cmb_season;
                cmd.Parameters.Add("In_valuewithtax", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_valuewithtax; 
                cmd.Parameters.Add("In_product_category", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_product_category;
                cmd.Parameters.Add("In_product_subcategory", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_product_subcategory;
                cmd.Parameters.Add("In_hsn_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_hsn_code;
                cmd.Parameters.Add("In_hsn_description", MySqlDbType.Text).Value = ObjContext.document.context.Header.In_hsn_description;
                cmd.Parameters.Add("In_uomtype_code", MySqlDbType.Text).Value = ObjContext.document.context.Header.In_uomtype_code;
                cmd.Parameters.Add("In_crop_variety", MySqlDbType.Text).Value = ObjContext.document.context.Header.In_crop_variety;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_status_desc", MySqlDbType.LongText).Value = ObjContext.document.context.Header.In_status_desc;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmd.Parameters.Add("IOU_product_rowid", MySqlDbType.Int32).Value = ObjContext.document.context.Header.IOU_product_rowid;
                cmd.Parameters.Add("IOU_pawhs_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_pawhs_code;
                cmd.Parameters.Add(new MySqlParameter("IOU_product_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_pawhs_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_Error", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();

                if (ret > 0)
                {
                    IOU_product_rowid1 = (Int32)cmd.Parameters["IOU_product_rowid1"].Value;
                    IOU_pawhs_code1 = (string)cmd.Parameters["IOU_pawhs_code1"].Value;
                    IOU_Error = (string)cmd.Parameters["IOU_Error"].Value;

                    if (IOU_Error.ToString() != "")
                    {
                        objresFarmer.ApplicationException.errorDescription = IOU_Error.ToString();
                        mysqltrans.Rollback();
                        return objresFarmer;
                    }


                    objresFarmer.context.Header.IOU_product_rowid = Convert.ToInt32(IOU_product_rowid1);
                    objresFarmer.context.Header.IOU_pawhs_code = IOU_pawhs_code1;
                    objresFarmer.context.orgnId = ObjContext.document.context.orgnId;
                    objresFarmer.context.locnId = ObjContext.document.context.locnId;
                    objresFarmer.context.userId = ObjContext.document.context.userId;
                    objresFarmer.context.localeId = ObjContext.document.context.localeId;
                }
                else
                {
                    IOU_Error = (string)cmd.Parameters["IOU_Error"].Value;

                    if (IOU_Error.ToString() != "")
                    {
                        objresFarmer.ApplicationException.errorDescription = IOU_Error.ToString();
                        mysqltrans.Rollback();
                        return objresFarmer;
                    }
                    else
                    {
                        mysqltrans.Rollback();
                        return objresFarmer;
                    }
                }
                if (objresFarmer.context.Header.IOU_product_rowid > 0)
                {
                    ret = SaveProcCal(ObjContext, objresFarmer, mysqlcon, MysqlCon);
                    if (ret == 0)
                    {
                        mysqltrans.Rollback();
                        return objresFarmer;
                    }
                    mysqltrans.Commit();
                }

                return objresFarmer;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                throw ex;

            }
        }
        public int SaveProcCal(PAWHSProductmasterSApplication Objmodel, PAWHSProductmasterSDocument objfarmer, string MysqlCons, DataConnection MysqlCon)
        {
            int saving = 0;
            int count = 1;
            DataTable tab = new DataTable();
            PAWHSProductmastersDetail objFarmersMapped = new PAWHSProductmastersDetail();
            try
            {
                PAWHSProductmaster_Datamodel objproduct1 = new PAWHSProductmaster_Datamodel();
                foreach (var FarmersMap in Objmodel.document.context.Detail)
                {
                    objFarmersMapped.In_product_dtl_rowid = FarmersMap.In_product_dtl_rowid;
                    objFarmersMapped.In_pawhs_code = objfarmer.context.Header.IOU_pawhs_code;
                    objFarmersMapped.In_row_slno = FarmersMap.In_row_slno;
                    objFarmersMapped.In_maize_code = FarmersMap.In_maize_code;
                    objFarmersMapped.In_maize_name = FarmersMap.In_maize_name;
                    objFarmersMapped.In_min_value = FarmersMap.In_min_value;
                    objFarmersMapped.In_max_value = FarmersMap.In_max_value;
                    objFarmersMapped.In_status_code = FarmersMap.In_status_code;
                    objFarmersMapped.In_mode_flag = FarmersMap.In_mode_flag;
                    objFarmersMapped.IOU_product_rowid = objfarmer.context.Header.IOU_product_rowid;
                    saving = objproduct1.SaveProcCalNew(objFarmersMapped, objfarmer, Objmodel, MysqlCons, MysqlCon);
                    count = count + 1;
                    if (saving == 0)
                    {
                        break;
                    }
                }
                return saving;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public int SaveProcCalNew(PAWHSProductmastersDetail ObjKycDtl, PAWHSProductmasterSDocument ObjFarmer, PAWHSProductmasterSApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_iud_product_master_detail", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_product_dtl_rowid", MySqlDbType.Int32).Value = ObjKycDtl.In_product_dtl_rowid;
                cmd.Parameters.Add("In_pawhs_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_pawhs_code;
                cmd.Parameters.Add("In_row_slno", MySqlDbType.Int32).Value = ObjKycDtl.In_row_slno;
                cmd.Parameters.Add("In_maize_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_maize_code;
                cmd.Parameters.Add("In_maize_name", MySqlDbType.VarChar).Value = ObjKycDtl.In_maize_name;
                cmd.Parameters.Add("In_min_value", MySqlDbType.Double).Value = ObjKycDtl.In_min_value;
                cmd.Parameters.Add("In_max_value", MySqlDbType.Double).Value = ObjKycDtl.In_max_value;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjKycDtl.In_mode_flag;
                cmd.Parameters.Add("IOU_product_rowid", MySqlDbType.Int32).Value = ObjKycDtl.IOU_product_rowid;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                ret = cmd.ExecuteNonQuery();
                return ret;
            }
            catch (Exception ex)
            {
                ret = 0;
                throw ex;
            }
        }

    }
}
