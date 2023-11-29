using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
    public class PAWHSManageForPickUp_DB
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();


        public PAWHSManageForPickUpApplication Getallreadyto_pickup_DB(PAWHSManageForPickUpContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            PAWHSManageForPickUpApplication ObjFetchAll = new PAWHSManageForPickUpApplication();
            ObjFetchAll.context = new PAWHSManageForPickUpContext();
            ObjFetchAll.context.List = new List<PAWHSManageForPickUpList>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_readyto_pickup_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("in_FilterBy_Option", MySqlDbType.VarChar).Value = ObjContext.FilterBy_Option;
                cmd.Parameters.Add("in_FilterBy_Code", MySqlDbType.VarChar).Value = ObjContext.FilterBy_Code;
                cmd.Parameters.Add("in_FilterBy_Fromvalue", MySqlDbType.VarChar).Value = ObjContext.FilterBy_FromValue;
                cmd.Parameters.Add("in_FilterBy_Tovalue", MySqlDbType.VarChar).Value = ObjContext.FilterBy_ToValue;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;


                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PAWHSManageForPickUpList objList = new PAWHSManageForPickUpList();
                    objList.Out_pickup_rowid = Convert.ToInt32(dt.Rows[i]["Out_pickup_rowid"]);
                    objList.Out_farmer_code = dt.Rows[i]["Out_farmer_code"].ToString();
                    objList.Out_farmer_name = dt.Rows[i]["Out_farmer_name"].ToString();
                    objList.Out_farmer_code = dt.Rows[i]["Out_farmer_code"].ToString();
                    objList.Out_pickup_request_id = dt.Rows[i]["Out_pickup_request_id"].ToString();
                    objList.Out_pickup_date = dt.Rows[i]["Out_pickup_date"].ToString();                    
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

        public PAWHSManageForPickUpFApplication Getreadyto_pickup_DB(PAWHSManageForPickUpFContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);
            int ret = 0;
            PAWHSManageForPickUpFApplication ObjFetchAll = new PAWHSManageForPickUpFApplication();
            ObjFetchAll.context = new PAWHSManageForPickUpFContext();
            ObjFetchAll.context.Header = new PAWHSManageForPickUpFHeader();
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_readyto_pickup", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("IOU_pickup_rowid", MySqlDbType.Int32).Value = ObjContext.pickup_rowid;
                cmd.Parameters.Add("IOU_farmer_code", MySqlDbType.VarChar).Value = ObjContext.farmer_code;                
                cmd.Parameters.Add(new MySqlParameter("In_farmer_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_pickup_request_id", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_pickup_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_village", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_fig", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_fig_contact_person", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_fig_contact_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_pickup_slot_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_pickup_slot_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_vehicle_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_vehicle_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_vehicle_reg_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_quantity", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_warehouse_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_warehouse_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_max_carry_weight", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_load_sapce_volume", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_load_floor_length", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_load_floor_width", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;              
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_pickup_rowid1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_farmer_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();

                ObjFetchAll.context.Header.IOU_pickup_rowid = (Int32)cmd.Parameters["IOU_pickup_rowid"].Value;
                ObjFetchAll.context.Header.IOU_farmer_code = (string)cmd.Parameters["IOU_farmer_code"].Value.ToString();
                ObjFetchAll.context.Header.In_farmer_name = (string)cmd.Parameters["In_farmer_name"].Value.ToString();
                ObjFetchAll.context.Header.In_pickup_request_id = (string)cmd.Parameters["In_pickup_request_id"].Value.ToString();
                ObjFetchAll.context.Header.In_pickup_date = (string)cmd.Parameters["In_pickup_date"].Value.ToString();
                ObjFetchAll.context.Header.In_village = (string)cmd.Parameters["In_village"].Value.ToString();
                ObjFetchAll.context.Header.In_fig = (string)cmd.Parameters["In_fig"].Value.ToString();
                ObjFetchAll.context.Header.In_fig_contact_person = (string)cmd.Parameters["In_fig_contact_person"].Value.ToString();
                ObjFetchAll.context.Header.In_fig_contact_no = (string)cmd.Parameters["In_fig_contact_no"].Value.ToString();
                ObjFetchAll.context.Header.In_pickup_slot_code = (string)cmd.Parameters["In_pickup_slot_code"].Value.ToString();
                ObjFetchAll.context.Header.In_pickup_slot_desc = (string)cmd.Parameters["In_pickup_slot_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_vehicle_code = (string)cmd.Parameters["In_vehicle_code"].Value.ToString();
                ObjFetchAll.context.Header.In_vehicle_desc = (string)cmd.Parameters["In_vehicle_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_vehicle_reg_no = (string)cmd.Parameters["In_vehicle_reg_no"].Value.ToString();
                ObjFetchAll.context.Header.In_quantity = (string)cmd.Parameters["In_quantity"].Value.ToString();
                ObjFetchAll.context.Header.In_warehouse_code = (string)cmd.Parameters["In_warehouse_code"].Value.ToString();
                ObjFetchAll.context.Header.In_warehouse_name = (string)cmd.Parameters["In_warehouse_name"].Value.ToString();
                ObjFetchAll.context.Header.In_max_carry_weight = (string)cmd.Parameters["In_max_carry_weight"].Value.ToString();
                ObjFetchAll.context.Header.In_load_sapce_volume = (string)cmd.Parameters["In_load_sapce_volume"].Value.ToString();
                ObjFetchAll.context.Header.In_load_floor_length = (string)cmd.Parameters["In_load_floor_length"].Value.ToString();
                ObjFetchAll.context.Header.In_load_floor_width = (string)cmd.Parameters["In_load_floor_width"].Value.ToString();
                ObjFetchAll.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                ObjFetchAll.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();
                ObjFetchAll.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();

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

        public PAWHSManageForPickUpSDocument Savenew_readyto_pickup_DB(PAWHSManageForPickUpSApplication ObjContext, string mysqlcon)
        {
            int ret = 0;
            MysqlCon = new DataConnection(mysqlcon);
            PAWHSManageForPickUpSDocument objProcessDoc = new PAWHSManageForPickUpSDocument();
            objProcessDoc.context = new PAWHSManageForPickUpSContext();
            objProcessDoc.context.Header = new PAWHSManageForPickUpSHeader();
            objProcessDoc.ApplicationException = new PAWHSManageForPickUpSApplicationException();
            string errorNo = "";
            string errorMsg = "";
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_insupd_readyto_pickup", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("In_pickup_request_id", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_pickup_request_id;
                cmd.Parameters.Add("In_pickup_date", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_pickup_date;
                cmd.Parameters.Add("In_village", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_village;
                cmd.Parameters.Add("In_fig", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_fig;
                cmd.Parameters.Add("In_fig_contact_person", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_fig_contact_person;
                cmd.Parameters.Add("In_fig_contact_no", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_fig_contact_no;
                cmd.Parameters.Add("In_pickup_slot_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_pickup_slot_code;
                cmd.Parameters.Add("In_vehicle_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_vehicle_code;
                cmd.Parameters.Add("In_vehicle_reg_no", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_vehicle_reg_no;
                cmd.Parameters.Add("In_quantity", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_quantity;
                cmd.Parameters.Add("In_warehouse_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_warehouse_code;
                cmd.Parameters.Add("In_max_carry_weight", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_max_carry_weight;
                cmd.Parameters.Add("In_load_sapce_volume", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_load_sapce_volume;
                cmd.Parameters.Add("In_load_floor_length", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_load_floor_length;
                cmd.Parameters.Add("In_load_floor_width", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_load_floor_width;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_mode_flag;

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmd.Parameters.Add("IOU_pickup_rowid", MySqlDbType.Int32).Value = ObjContext.document.context.Header.IOU_pickup_rowid;
                cmd.Parameters.Add("IOU_farmer_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_farmer_code;

                cmd.Parameters.Add(new MySqlParameter("IOU_pickup_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_farmer_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
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

                    objProcessDoc.context.Header.IOU_pickup_rowid = (Int32)cmd.Parameters["IOU_pickup_rowid1"].Value;
                    objProcessDoc.context.Header.IOU_farmer_code = (string)cmd.Parameters["IOU_farmer_code1"].Value.ToString();
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
