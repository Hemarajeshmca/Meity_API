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
   public class PAWHSServiceMaster_DataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();

        public ServiceMasterApplication GetAllServiceMasterList(SrviceMasterContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            ServiceMasterApplication ObjFetchAll = new ServiceMasterApplication();
            ObjFetchAll.context = new SrviceMasterContext();
            ObjFetchAll.context.List = new List<ServiceMasterList>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_service_master_list", MysqlCon.con);
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
                    ServiceMasterList objList = new ServiceMasterList();
                    objList.Out_service_rowid = Convert.ToInt32(dt.Rows[i]["Out_service_rowid"]);
                    objList.Out_agg_code = dt.Rows[i]["Out_agg_code"].ToString();
                    objList.Out_service_code = dt.Rows[i]["Out_service_code"].ToString();
                    objList.Out_service_name = dt.Rows[i]["Out_service_name"].ToString();
                    objList.Out_service_ll_name = dt.Rows[i]["Out_service_ll_name"].ToString();
                    objList.Out_hsn_code = dt.Rows[i]["Out_hsn_code"].ToString();
                    objList.Out_hsn_description = dt.Rows[i]["Out_hsn_description"].ToString();
                    objList.Out_rate = Convert.ToInt32(dt.Rows[i]["Out_rate"]);
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
      
        public FetchServiceMasterApplication GetSingleServiceMasterDtl(FetchServiceMasterContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            FetchServiceMasterApplication ObjFetchAll = new FetchServiceMasterApplication();
            ObjFetchAll.context = new FetchServiceMasterContext();
            ObjFetchAll.context.Header = new FetchServiceMasterHeader();
           
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_service_master", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("IOU_service_rowid", MySqlDbType.Int32).Value = ObjContext.service_rowid;
                cmd.Parameters.Add("IOU_agg_code", MySqlDbType.VarChar).Value = ObjContext.agg_code;
                cmd.Parameters.Add("IOU_service_code", MySqlDbType.VarChar).Value = ObjContext.service_code;

                cmd.Parameters.Add(new MySqlParameter("In_service_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_service_ll_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_output_name_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_output_name_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_hsn_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_hsn_description", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_rate", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_service_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_agg_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_service_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                ObjFetchAll.context.Header.In_service_name = (string)cmd.Parameters["In_service_name"].Value.ToString();
                ObjFetchAll.context.Header.In_service_ll_name = (string)cmd.Parameters["In_service_ll_name"].Value.ToString();
                ObjFetchAll.context.Header.In_output_name_code = (string)cmd.Parameters["In_output_name_code"].Value.ToString();
                ObjFetchAll.context.Header.In_output_name_desc = (string)cmd.Parameters["In_output_name_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_hsn_code = (string)cmd.Parameters["In_hsn_code"].Value.ToString();
                ObjFetchAll.context.Header.In_hsn_description = (string)cmd.Parameters["In_hsn_description"].Value.ToString();
                ObjFetchAll.context.Header.In_rate = (Double)cmd.Parameters["In_rate"].Value;
                ObjFetchAll.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                ObjFetchAll.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                ObjFetchAll.context.Header.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();
                ObjFetchAll.context.Header.IOU_service_rowid = (Int32)cmd.Parameters["IOU_service_rowid1"].Value;
                ObjFetchAll.context.Header.IOU_agg_code = (string)cmd.Parameters["IOU_agg_code1"].Value.ToString();
                ObjFetchAll.context.Header.IOU_service_code = (string)cmd.Parameters["IOU_service_code1"].Value.ToString();
                

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ObjFetchAll;
        }
        public SaveServiceMasterDocument SaveCustomerMaster(SaveServiceMasterApplication ObjContext, string mysqlcon)
        {
            int ret = 0;           

            MysqlCon = new DataConnection(mysqlcon);
            SaveServiceMasterDocument ObjSaveDoc = new SaveServiceMasterDocument();
            ObjSaveDoc.context = new SaveServiceMasterContext();
            ObjSaveDoc.context.Header = new SaveServiceMasterHeader();

            try
            {


                MySqlCommand cmd = new MySqlCommand("PAWHS_insupd_service_master", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_agg_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_agg_code;
                cmd.Parameters.Add("In_service_name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_service_name;
                cmd.Parameters.Add("In_service_ll_name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_service_ll_name;
                cmd.Parameters.Add("In_output_name_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_output_name_code;
                cmd.Parameters.Add("In_hsn_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_hsn_code;
                cmd.Parameters.Add("In_hsn_description", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_hsn_description;
                cmd.Parameters.Add("In_rate", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_rate;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmd.Parameters.Add("IOU_service_rowid", MySqlDbType.Int32).Value = ObjContext.document.context.Header.IOU_service_rowid;
                cmd.Parameters.Add("IOU_service_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_service_code;
                cmd.Parameters.Add(new MySqlParameter("IOU_service_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_service_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                ret = cmd.ExecuteNonQuery();
                MysqlCon.con.Close();   

                ObjSaveDoc.context.Header.IOU_service_rowid = (Int32)cmd.Parameters["IOU_service_rowid1"].Value;
                ObjSaveDoc.context.Header.IOU_service_code = (string)cmd.Parameters["IOU_service_code1"].Value.ToString();

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
