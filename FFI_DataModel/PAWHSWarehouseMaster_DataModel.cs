using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FFI_Model;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using MySqlX.XDevAPI.Common;

namespace FFI_DataModel
{
    public class PAWHSWarehouseMaster_DataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        public WarehouseMstApplication GetAllWarehouseList(WarehouseMstContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            WarehouseMstApplication ObjFetchAll = new WarehouseMstApplication();
            ObjFetchAll.context = new WarehouseMstContext();
            ObjFetchAll.context.List = new List<WarehouseMstList>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_warehouse_reg_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("In_filterby_option", MySqlDbType.VarChar).Value = ObjContext.Filter.FilterBy_Option;
                cmd.Parameters.Add("In_filterby_code", MySqlDbType.VarChar).Value = ObjContext.Filter.FilterBy_Code;
                cmd.Parameters.Add("In_filterby_fromvalue", MySqlDbType.VarChar).Value = ObjContext.Filter.FilterBy_FromValue;
                cmd.Parameters.Add("In_filterby_tovalue", MySqlDbType.VarChar).Value = ObjContext.Filter.FilterBy_ToValue;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    WarehouseMstList objList = new WarehouseMstList();
                    objList.Out_whs_rowid = Convert.ToInt32(dt.Rows[i]["Out_whs_rowid"]);
                    objList.Out_agg_code = dt.Rows[i]["Out_agg_code"].ToString();
                    objList.Out_whs_code = dt.Rows[i]["Out_whs_code"].ToString();
                    objList.Out_whs_type = dt.Rows[i]["Out_whs_type"].ToString();
                    objList.Out_whs_name = dt.Rows[i]["Out_whs_name"].ToString();
                    objList.Out_whs_addr1 = dt.Rows[i]["Out_whs_addr1"].ToString();
                    objList.Out_whs_addr2 = dt.Rows[i]["Out_whs_addr2"].ToString();
                    objList.Out_whs_country = dt.Rows[i]["Out_whs_country"].ToString();
                    objList.Out_whs_state = dt.Rows[i]["Out_whs_state"].ToString();
                    objList.Out_whs_dist = dt.Rows[i]["Out_whs_dist"].ToString();
                    objList.Out_whs_taluk = dt.Rows[i]["Out_whs_taluk"].ToString();
                    objList.Out_whs_panchayat = dt.Rows[i]["Out_whs_panchayat"].ToString();
                    objList.Out_whs_village = dt.Rows[i]["Out_whs_village"].ToString();
                    objList.Out_whs_pincode = dt.Rows[i]["Out_whs_pincode"].ToString();
                    objList.Out_sqrf_area = Convert.ToInt32(dt.Rows[i]["Out_sqrf_area"]);
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
        public WarehouseMstSingleApplication GetSingleWarehouseMasterDtl(WarehouseMstSingleContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            WarehouseMstSingleApplication ObjFetchAll = new WarehouseMstSingleApplication();
            ObjFetchAll.context = new WarehouseMstSingleContext();
            ObjFetchAll.context.Header = new WarehouseMstHeader();
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_warehouse_reg", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("IOU_whs_rowid", MySqlDbType.Int32).Value = ObjContext.IOU_whs_rowid;
                cmd.Parameters.Add("IOU_agg_code", MySqlDbType.VarChar).Value = ObjContext.IOU_agg_code;
                cmd.Parameters.Add ("IOU_whs_code", MySqlDbType.VarChar).Value = ObjContext.IOU_whs_code;

                cmd.Parameters.Add(new MySqlParameter("In_whs_type", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_whs_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_whs_addr1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_whs_addr2", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_whs_country", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_whs_country_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_whs_state", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_whs_state_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_whs_dist", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_whs_dist_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_whs_taluk", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_whs_taluk_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_whs_panchayat", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_whs_panchayat_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_whs_village", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_whs_village_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_whs_pincode", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_sqrf_area", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_whs_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_agg_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_whs_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                ObjFetchAll.context.Header.In_whs_type = (string)cmd.Parameters["In_whs_type"].Value.ToString();
                ObjFetchAll.context.Header.In_whs_name = (string)cmd.Parameters["In_whs_name"].Value.ToString();
                ObjFetchAll.context.Header.In_whs_addr1 = (string)cmd.Parameters["In_whs_addr1"].Value.ToString();
                ObjFetchAll.context.Header.In_whs_addr2 = (string)cmd.Parameters["In_whs_addr2"].Value;
                ObjFetchAll.context.Header.In_whs_country = (string)cmd.Parameters["In_whs_country"].Value.ToString();
                ObjFetchAll.context.Header.In_whs_country_desc = (string)cmd.Parameters["In_whs_country_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_whs_state = (string)cmd.Parameters["In_whs_state"].Value.ToString();
                ObjFetchAll.context.Header.In_whs_state_desc = (string)cmd.Parameters["In_whs_state_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_whs_dist = (string)cmd.Parameters["In_whs_dist"].Value.ToString();
                ObjFetchAll.context.Header.In_whs_dist_desc = (string)cmd.Parameters["In_whs_dist_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_whs_taluk = (string)cmd.Parameters["In_whs_taluk"].Value.ToString();
                ObjFetchAll.context.Header.In_whs_taluk_desc = (string)cmd.Parameters["In_whs_taluk_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_whs_panchayat = (string)cmd.Parameters["In_whs_panchayat"].Value.ToString();
                ObjFetchAll.context.Header.In_whs_panchayat_desc = (string)cmd.Parameters["In_whs_panchayat_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_whs_village = (string)cmd.Parameters["In_whs_village"].Value.ToString();
                ObjFetchAll.context.Header.In_whs_village_desc = (string)cmd.Parameters["In_whs_village_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_whs_pincode = (string)cmd.Parameters["In_whs_pincode"].Value.ToString();
                ObjFetchAll.context.Header.In_sqrf_area = (Int32)cmd.Parameters["In_sqrf_area"].Value;
                ObjFetchAll.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                ObjFetchAll.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                ObjFetchAll.context.Header.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value;
                ObjFetchAll.context.Header.IOU_whs_rowid = (Int32)cmd.Parameters["IOU_whs_rowid1"].Value;
                ObjFetchAll.context.Header.IOU_agg_code = (string)cmd.Parameters["IOU_agg_code1"].Value.ToString();
                ObjFetchAll.context.Header.IOU_whs_code = (string)cmd.Parameters["IOU_whs_code1"].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ObjFetchAll;
        }
        public WarehouseMstDocument SaveWareHouseMaster(WarehouseMstSaveApplication ObjContext, string mysqlcon)
        {
            int ret = 0;
            int retdtls = 0;

            MysqlCon = new DataConnection(mysqlcon);
            WarehouseMstDocument ObjSaveDoc = new WarehouseMstDocument();
            ObjSaveDoc.context = new WarehouseMstSaveContext();
            ObjSaveDoc.context.Header = new WarehouseMstSaveHeader();

            try
            {


                MySqlCommand cmd = new MySqlCommand("PAWHS_validate_warehouse_reg", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("IOU_whs_rowid", MySqlDbType.Int32).Value = ObjContext.document.context.Header.IOU_whs_rowid;
                cmd.Parameters.Add("In_agg_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_agg_code;
                cmd.Parameters.Add("IOU_whs_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_whs_code;
                cmd.Parameters.Add("In_whs_type", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_whs_type;
                cmd.Parameters.Add("In_whs_name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_whs_name;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;

                MysqlCon.con.Open();
                ret = cmd.ExecuteNonQuery();
                MysqlCon.con.Close();

                MySqlCommand cmds = new MySqlCommand("PAWHS_insupd_warehouse_reg", MysqlCon.con);
                cmds.CommandType = CommandType.StoredProcedure;
                cmds.Parameters.Add("In_agg_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_agg_code;
                cmds.Parameters.Add("In_whs_type", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_whs_type;
                cmds.Parameters.Add("In_whs_name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_whs_name;
                cmds.Parameters.Add("In_whs_addr1", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_whs_addr1;
                cmds.Parameters.Add("In_whs_addr2", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_whs_addr2;
                cmds.Parameters.Add("In_whs_country", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_whs_country;
                cmds.Parameters.Add("In_whs_state", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_whs_state;
                cmds.Parameters.Add("In_whs_dist", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_whs_dist;
                cmds.Parameters.Add("In_whs_taluk", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_whs_taluk;
                cmds.Parameters.Add("In_whs_panchayat", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_whs_panchayat;
                cmds.Parameters.Add("In_whs_village", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_whs_village;
                cmds.Parameters.Add("In_whs_pincode", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_whs_pincode;
                cmds.Parameters.Add("In_sqrf_area", MySqlDbType.Int32).Value = ObjContext.document.context.Header.In_sqrf_area;
                cmds.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_status_code;
                cmds.Parameters.Add("In_status_desc", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_status_desc;
                cmds.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_mode_flag;
                cmds.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_row_timestamp;
                cmds.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmds.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmds.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmds.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmds.Parameters.Add("IOU_whs_rowid", MySqlDbType.Int32).Value = ObjContext.document.context.Header.IOU_whs_rowid;
                cmds.Parameters.Add("IOU_whs_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_whs_code;              

                cmds.Parameters.Add(new MySqlParameter("IOU_whs_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmds.Parameters.Add(new MySqlParameter("IOU_whs_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                retdtls = cmds.ExecuteNonQuery();
                MysqlCon.con.Close();

                ObjSaveDoc.context.Header.IOU_whs_rowid = (Int32)cmds.Parameters["IOU_whs_rowid1"].Value;
                ObjSaveDoc.context.Header.IOU_whs_code = (string)cmds.Parameters["IOU_whs_code1"].Value.ToString();

            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                throw ex;
            }

            return ObjSaveDoc;
        }
    }
}
