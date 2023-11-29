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
   public class PAWHSCustomerMaster_DataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        public PAWHSCustomerApplication GetAllCustomerMasterList(Context ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            PAWHSCustomerApplication ObjFetchAll = new PAWHSCustomerApplication();
            ObjFetchAll.context = new Context();
            ObjFetchAll.context.List = new List<List>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_customermaster_list", MysqlCon.con);
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
                    List objList = new List();
                    objList.Out_customer_rowid = Convert.ToInt32(dt.Rows[i]["Out_customer_rowid"]);
                    objList.Out_customer_code = dt.Rows[i]["Out_customer_code"].ToString();
                    objList.Out_customer_type = dt.Rows[i]["Out_customer_type"].ToString();
                    objList.Out_customer_name = dt.Rows[i]["Out_customer_name"].ToString();
                    objList.Out_customer_addr1 = dt.Rows[i]["Out_customer_addr1"].ToString();
                    objList.Out_customer_addr2 = dt.Rows[i]["Out_customer_addr2"].ToString();
                    objList.Out_customer_country = dt.Rows[i]["Out_customer_country"].ToString();
                    objList.Out_customer_state = dt.Rows[i]["Out_customer_state"].ToString();
                    objList.Out_customer_dist = dt.Rows[i]["Out_customer_dist"].ToString();
                    objList.Out_customer_taluk = dt.Rows[i]["Out_customer_taluk"].ToString();
                    objList.Out_customer_panchayat = dt.Rows[i]["Out_customer_panchayat"].ToString();
                    objList.Out_customer_village = dt.Rows[i]["Out_customer_village"].ToString();
                    objList.Out_customer_pincode = dt.Rows[i]["Out_customer_pincode"].ToString();
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
        public SingleApplication GetSingleCustomerMasterDtl(SingleContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            SingleApplication ObjFetchAll = new SingleApplication();
            ObjFetchAll.context = new SingleContext();          
            ObjFetchAll.context.Header = new Header();
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_customermaster", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("IOU_customer_rowid", MySqlDbType.Int32).Value = ObjContext.Header.IOU_customer_rowid;
                cmd.Parameters.Add("IOU_customer_code", MySqlDbType.VarChar).Value = ObjContext.Header.IOU_customer_code;
               
                cmd.Parameters.Add(new MySqlParameter("In_customer_type", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_customer_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_customer_addr1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_customer_addr2", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_customer_country", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_customer_country_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_customer_state", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_customer_state_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_customer_dist", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_customer_dist_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_customer_taluk", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_customer_taluk_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_customer_panchayat", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_customer_panchayat_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_customer_village", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_customer_village_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_customer_pincode", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_customer_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_customer_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
               
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();             

                ObjFetchAll.context.Header.In_customer_type = (string)cmd.Parameters["In_customer_type"].Value.ToString();
                ObjFetchAll.context.Header.In_customer_name = (string)cmd.Parameters["In_customer_name"].Value.ToString();
                ObjFetchAll.context.Header.In_customer_addr1 = (string)cmd.Parameters["In_customer_addr1"].Value.ToString();
                ObjFetchAll.context.Header.In_customer_addr2 = (string)cmd.Parameters["In_customer_addr2"].Value.ToString();
                ObjFetchAll.context.Header.In_customer_country = (string)cmd.Parameters["In_customer_country"].Value.ToString();
                ObjFetchAll.context.Header.In_customer_country_desc = (string)cmd.Parameters["In_customer_country_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_customer_state = (string)cmd.Parameters["In_customer_state"].Value.ToString();
                ObjFetchAll.context.Header.In_customer_state_desc = (string)cmd.Parameters["In_customer_state_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_customer_dist = (string)cmd.Parameters["In_customer_dist"].Value.ToString();
                ObjFetchAll.context.Header.In_customer_dist_desc = (string)cmd.Parameters["In_customer_dist_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_customer_taluk = (string)cmd.Parameters["In_customer_taluk"].Value.ToString();
                ObjFetchAll.context.Header.In_customer_taluk_desc = (string)cmd.Parameters["In_customer_taluk_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_customer_panchayat = (string)cmd.Parameters["In_customer_panchayat"].Value.ToString();
                ObjFetchAll.context.Header.In_customer_panchayat_desc = (string)cmd.Parameters["In_customer_panchayat_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_customer_village = (string)cmd.Parameters["In_customer_village"].Value.ToString();
                ObjFetchAll.context.Header.In_customer_village_desc = (string)cmd.Parameters["In_customer_village_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_customer_pincode = (string)cmd.Parameters["In_customer_pincode"].Value.ToString();
                ObjFetchAll.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                ObjFetchAll.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                ObjFetchAll.context.Header.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();
                ObjFetchAll.context.Header.IOU_customer_rowid = (Int32)cmd.Parameters["IOU_customer_rowid1"].Value;
                ObjFetchAll.context.Header.IOU_customer_code = (string)cmd.Parameters["IOU_customer_code1"].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ObjFetchAll;
        }
        public DocumentCustomer SaveCustomerMaster(SaveApplication ObjContext, string mysqlcon)
        {
            int ret = 0;
            int retdtls = 0;
           
            MysqlCon = new DataConnection(mysqlcon);
            DocumentCustomer ObjSaveDoc = new DocumentCustomer();
            ObjSaveDoc.context = new SaveContextCustomer();
            ObjSaveDoc.context.Header = new SaveHeaderCustomer();
         
            try
            {
               

                MySqlCommand cmd = new MySqlCommand("PAWHS_validate_customermaster", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("IOU_customer_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_customer_code;
                cmd.Parameters.Add("In_customer_type", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_customer_type;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;

                MysqlCon.con.Open();
                ret = cmd.ExecuteNonQuery();
                MysqlCon.con.Close();

                MySqlCommand cmds = new MySqlCommand("PAWHS_insupd_customermaster", MysqlCon.con);
                cmds.CommandType = CommandType.StoredProcedure;
                cmds.Parameters.Add("In_customer_type", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_customer_type;
                cmds.Parameters.Add("In_customer_name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_customer_name;
                cmds.Parameters.Add("In_customer_addr1", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_customer_addr1;
                cmds.Parameters.Add("In_customer_addr2", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_customer_addr2;
                cmds.Parameters.Add("In_customer_country", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_customer_country;
                cmds.Parameters.Add("In_customer_state", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_customer_state;
                cmds.Parameters.Add("In_customer_dist", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_customer_dist;
                cmds.Parameters.Add("In_customer_taluk", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_customer_taluk;
                cmds.Parameters.Add("In_customer_panchayat", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_customer_panchayat;
                cmds.Parameters.Add("In_customer_village", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_customer_village;
                cmds.Parameters.Add("In_customer_pincode", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_customer_pincode;
                cmds.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_status_code;
                cmds.Parameters.Add("In_status_desc", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_status_desc;
                cmds.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_mode_flag;
                cmds.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_row_timestamp;
                cmds.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmds.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmds.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmds.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmds.Parameters.Add("IOU_customer_rowid", MySqlDbType.Int32).Value = ObjContext.document.context.Header.IOU_customer_rowid;
                cmds.Parameters.Add("IOU_customer_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_customer_code;

                cmds.Parameters.Add(new MySqlParameter("IOU_customer_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmds.Parameters.Add(new MySqlParameter("IOU_customer_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                retdtls = cmds.ExecuteNonQuery();
                MysqlCon.con.Close();

                ObjSaveDoc.context.Header.IOU_customer_code = (string)cmds.Parameters["IOU_customer_code1"].Value.ToString();
                ObjSaveDoc.context.Header.IOU_customer_rowid = (Int32)cmds.Parameters["IOU_customer_rowid1"].Value;

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
