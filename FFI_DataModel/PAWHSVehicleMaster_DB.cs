using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
    public class PAWHSVehicleMaster_DB
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();


        public PAWHSVehicleMasterApplication Getallvehicle_srv_DB(PAWHSVehicleMasterContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            PAWHSVehicleMasterApplication ObjFetchAll = new PAWHSVehicleMasterApplication();
            ObjFetchAll.context = new PAWHSVehicleMasterContext();
            ObjFetchAll.context.List = new List<PAWHSVehicleMasterList>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_vehicle_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("in_FilterBy_Option", MySqlDbType.VarChar).Value = ObjContext.FilterBy_Option;
                cmd.Parameters.Add("in_FilterBy_Code", MySqlDbType.VarChar).Value = ObjContext.FilterBy_Code;
                cmd.Parameters.Add("in_FilterBy_Fromvalue", MySqlDbType.VarChar).Value = ObjContext.FilterBy_FromValue;
                cmd.Parameters.Add("in_FilterBy_Tovalue", MySqlDbType.VarChar).Value = ObjContext.FilterBy_ToValue;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PAWHSVehicleMasterList objList = new PAWHSVehicleMasterList();
                    objList.Out_vehicle_rowid = Convert.ToInt32(dt.Rows[i]["Out_vehicle_rowid"]);
                    objList.Out_agg_code = dt.Rows[i]["Out_agg_code"].ToString();
                    objList.Out_vehicle_code = dt.Rows[i]["Out_vehicle_code"].ToString();
                    objList.Out_vehicle_regno = dt.Rows[i]["Out_vehicle_regno"].ToString();
                    objList.Out_vehicle_manf_name = dt.Rows[i]["Out_vehicle_manf_name"].ToString();
                    objList.Out_max_carrry_weight = dt.Rows[i]["Out_max_carrry_weight"].ToString();
                    objList.Out_loadspace_height = dt.Rows[i]["Out_loadspace_height"].ToString();
                    objList.Out_loadspace_width = dt.Rows[i]["Out_loadspace_width"].ToString();
                    objList.Out_loadspace_length = dt.Rows[i]["Out_loadspace_length"].ToString();
                    objList.Out_gps_id = dt.Rows[i]["Out_gps_id"].ToString();                   
                    objList.Out_imei_no = dt.Rows[i]["Out_imei_no"].ToString();
                    objList.Out_sim_no = dt.Rows[i]["Out_sim_no"].ToString();
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.Out_status_desc = dt.Rows[i]["Out_status_desc"].ToString();
                    objList.Out_row_timestamp = dt.Rows[i]["Out_row_timestamp"].ToString();
                    ObjFetchAll.context.List.Add(objList);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ObjFetchAll;
        }

        public PAWHSVehicleMasterFApplication Getvehicle_srv_DB(PAWHSVehicleMasterFContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);
            int ret = 0;
            PAWHSVehicleMasterFApplication ObjFetchAll = new PAWHSVehicleMasterFApplication();
            ObjFetchAll.context = new PAWHSVehicleMasterFContext();
            ObjFetchAll.context.Header = new PAWHSVehicleMasterFHeader();
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_vehicle", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_vehicle_rowid", MySqlDbType.Int32).Value = ObjContext.vehicle_rowid;
                cmd.Parameters.Add("In_agg_code", MySqlDbType.VarChar).Value = ObjContext.agg_code;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;               
                cmd.Parameters.Add(new MySqlParameter("In_vehicle_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_vehicle_regno", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_vehicle_manf_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_max_carrry_weight", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_loadspace_height", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_loadspace_width", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_loadspace_length", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_gps_id", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_imei_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_sim_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                ret = cmd.ExecuteNonQuery();
                MysqlCon.con.Close();

                ObjFetchAll.context.Header.In_vehicle_code = (string)cmd.Parameters["In_vehicle_code"].Value.ToString();
                ObjFetchAll.context.Header.In_vehicle_regno = (string)cmd.Parameters["In_vehicle_regno"].Value.ToString();
                ObjFetchAll.context.Header.In_vehicle_manf_name = (string)cmd.Parameters["In_vehicle_manf_name"].Value.ToString();
                ObjFetchAll.context.Header.In_max_carrry_weight = (string)cmd.Parameters["In_max_carrry_weight"].Value.ToString();
                ObjFetchAll.context.Header.In_loadspace_height = (string)cmd.Parameters["In_loadspace_height"].Value.ToString();
                ObjFetchAll.context.Header.In_loadspace_width = (string)cmd.Parameters["In_loadspace_width"].Value.ToString();
                ObjFetchAll.context.Header.In_loadspace_length = (string)cmd.Parameters["In_loadspace_length"].Value.ToString();
                ObjFetchAll.context.Header.In_gps_id = (string)cmd.Parameters["In_gps_id"].Value.ToString();
                ObjFetchAll.context.Header.In_imei_no = (string)cmd.Parameters["In_imei_no"].Value.ToString();
                ObjFetchAll.context.Header.In_sim_no = (string)cmd.Parameters["In_sim_no"].Value.ToString();
                ObjFetchAll.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                ObjFetchAll.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                ObjFetchAll.context.Header.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();
                
                ObjFetchAll.context.localeId = ObjContext.localeId;
                ObjFetchAll.context.userId = ObjContext.userId;
                ObjFetchAll.context.locnId = ObjContext.locnId;
                ObjFetchAll.context.orgnId = ObjContext.orgnId;


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }

        public PAWHSVehicleMasterSDocument Savenew_vehicle_master_srv_DB(PAWHSVehicleMasterSApplication ObjContext, string mysqlcon)
        {
            int ret = 0;
            MysqlCon = new DataConnection(mysqlcon);
            PAWHSVehicleMasterSDocument objProcessDoc = new PAWHSVehicleMasterSDocument();
            objProcessDoc.context = new PAWHSVehicleMasterSContext();
            objProcessDoc.context.Header = new PAWHSVehicleMasterSHeader();
            objProcessDoc.ApplicationException = new PAWHSVehicleMasterSApplicationException();
            string errorNo = "";
            string errorMsg = "";
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_insupd_vehicle", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("In_agg_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_agg_code;
                cmd.Parameters.Add("In_vehicle_regno", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_vehicle_regno;
                cmd.Parameters.Add("In_vehicle_manf_name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_vehicle_manf_name;
                cmd.Parameters.Add("In_max_carrry_weight", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_max_carrry_weight;
                cmd.Parameters.Add("In_loadspace_height", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_loadspace_height;
                cmd.Parameters.Add("In_loadspace_width", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_loadspace_width;
                cmd.Parameters.Add("In_loadspace_length", MySqlDbType.Int32).Value = ObjContext.document.context.Header.In_loadspace_length;
                cmd.Parameters.Add("In_gps_id", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_gps_id;
                cmd.Parameters.Add("In_imei_no", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_imei_no;
                cmd.Parameters.Add("In_sim_no", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_sim_no;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_row_timestamp;
              
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmd.Parameters.Add("IOU_vehicle_rowid", MySqlDbType.Int32).Value = ObjContext.document.context.Header.IOU_vehicle_rowid;
                cmd.Parameters.Add("IOU_vehicle_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_vehicle_code;

                cmd.Parameters.Add(new MySqlParameter("IOU_vehicle_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_vehicle_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;


                MysqlCon.con.Open();
                ret = cmd.ExecuteNonQuery();
                MysqlCon.con.Close();


                if (ret > 0)
                {
                    objProcessDoc.context.orgnId = ObjContext.document.context.orgnId;
                    objProcessDoc.context.locnId = ObjContext.document.context.locnId;
                    objProcessDoc.context.userId = ObjContext.document.context.userId;
                    objProcessDoc.context.localeId = ObjContext.document.context.localeId;

                    objProcessDoc.context.Header.IOU_vehicle_rowid = (Int32)cmd.Parameters["IOU_vehicle_rowid1"].Value;
                    objProcessDoc.context.Header.IOU_vehicle_code = (string)cmd.Parameters["IOU_vehicle_code1"].Value.ToString();
                }
                else
                {
                    errorNo = (string)cmd.Parameters["errorNo"].Value;
                    errorMsg = ObjErrormsg.ErrorMessage(errorNo);

                    objProcessDoc.ApplicationException.errorNumber = (string)cmd.Parameters["errorNo"].Value;
                    objProcessDoc.ApplicationException.errorDescription = errorMsg;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objProcessDoc;

        }


    }
}

