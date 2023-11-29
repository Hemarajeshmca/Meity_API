using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FFI_Model;

namespace FFI_DataModel
{
    public class PAWHS_NewWareHouseReceipt_datamodel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        //
        public PAWHS_NewWareHouseReceipt_ALL_Application pawhs_NewWareHouseReceipt_Lists(PAWHS_NewWareHouseReceipt_ALL_Context ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);
            MysqlCon.con.Close();
            PAWHS_NewWareHouseReceipt_ALL_Application ObjFetchAll = new PAWHS_NewWareHouseReceipt_ALL_Application();
            ObjFetchAll.context = new PAWHS_NewWareHouseReceipt_ALL_Context();
            ObjFetchAll.context.List = new List<PAWHS_NewWareHouseReceipt_ALL_List>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_Fetch_whsreceipting_List", MysqlCon.con);
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
               // ObjFetchAll.context = ObjContext;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PAWHS_NewWareHouseReceipt_ALL_List objList = new PAWHS_NewWareHouseReceipt_ALL_List();
                    objList.Out_whs_rowid = Convert.ToInt32(dt.Rows[i]["Out_whs_rowid"]);
                    objList.Out_agg_code = dt.Rows[i]["Out_agg_code"].ToString();
                    objList.Out_agg_name = dt.Rows[i]["Out_agg_name"].ToString();
                    objList.Out_LotNo = dt.Rows[i]["Out_LotNo"].ToString();
                    objList.Out_whs_code = dt.Rows[i]["Out_whs_code"].ToString();
                    objList.Out_farmer_code = dt.Rows[i]["Out_farmer_code"].ToString();
                    objList.Out_farmer_name = dt.Rows[i]["Out_farmer_name"].ToString();
                    objList.Out_member_type = dt.Rows[i]["Out_member_type"].ToString();
                    objList.Out_item_code = dt.Rows[i]["Out_item_code"].ToString();
                    objList.Out_item_name = dt.Rows[i]["Out_item_name"].ToString();
                    objList.Out_accepted_qty = dt.Rows[i]["Out_accepted_qty"].ToString();
                    objList.Out_payment_advcno = dt.Rows[i]["Out_payment_advcno"].ToString(); 
                    objList.Out_Accepted_date = dt.Rows[i]["Out_Accepted_date"].ToString();
                    objList.Out_status = dt.Rows[i]["Out_status"].ToString(); 
                    objList.Out_Remarks = dt.Rows[i]["Out_Remarks"].ToString();
                    objList.Out_row_timestamp = dt.Rows[i]["Out_row_timestamp"].ToString();
                    ObjFetchAll.context.List.Add(objList);
                }
                ObjFetchAll.context.orgnId = ObjContext.orgnId;
                ObjFetchAll.context.locnId = ObjContext.locnId;
                ObjFetchAll.context.userId = ObjContext.userId;
                ObjFetchAll.context.localeId = ObjContext.localeId;
                ObjFetchAll.context.FilterBy_Option = ObjContext.FilterBy_Option;
                ObjFetchAll.context.FilterBy_Code = ObjContext.FilterBy_Code;
                ObjFetchAll.context.FilterBy_FromValue = ObjContext.FilterBy_FromValue;
                ObjFetchAll.context.FilterBy_ToValue = ObjContext.FilterBy_ToValue;
            }
            catch (Exception ex)
            { 
                throw ex;
            }

            return ObjFetchAll;
        }

        public PAWHS_NewWareHouseReceipt_single_Application Single_pawhs_NewWareHouseReceipt(PAWHS_NewWareHouseReceipt_single_Context objfpoSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();

            PAWHS_NewWareHouseReceipt_single_Application objfpoSearchRoot = new PAWHS_NewWareHouseReceipt_single_Application();
            PAWHS_NewWareHouseReceipt_datamodel objDataModel = new PAWHS_NewWareHouseReceipt_datamodel();

            DataTable Map = new DataTable();


            objfpoSearchRoot.context = new PAWHS_NewWareHouseReceipt_single_Context();
            objfpoSearchRoot.context.Header = new PAWHS_NewWareHouseReceipt_single_Header();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("New_PAWHS_Fetch_whsreceipting", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;
                cmd.Parameters.Add("in_whs_rowid", MySqlDbType.Int32).Value = objfpoSearch.in_whs_rowid;           
                cmd.Parameters.Add("in_LotNo", MySqlDbType.VarChar).Value = objfpoSearch.in_LotNo;
                cmd.Parameters.Add(new MySqlParameter("in_whs_Code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_agg_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_agg_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_payment_advcno", MySqlDbType.VarChar)).Direction = ParameterDirection.Output; 
                cmd.Parameters.Add(new MySqlParameter("in_Accepted_Qty", MySqlDbType.Decimal)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_Accepted_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_status", MySqlDbType.VarChar)).Direction = ParameterDirection.Output; 
                cmd.Parameters.Add(new MySqlParameter("in_Remarks", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();
                if (ds.Tables.Count > 0)
                {
                    objfpoSearchRoot.context.orgnId = objfpoSearch.orgnId;
                    objfpoSearchRoot.context.locnId = objfpoSearch.locnId;
                    objfpoSearchRoot.context.userId = objfpoSearch.userId;
                    objfpoSearchRoot.context.localeId = objfpoSearch.localeId;
                    objfpoSearchRoot.context.in_whs_rowid = objfpoSearch.in_whs_rowid;
                    objfpoSearchRoot.context.in_LotNo = objfpoSearch.in_LotNo;
                    objfpoSearchRoot.context.in_whs_Code = (string)cmd.Parameters["in_whs_Code"].Value.ToString();
                    objfpoSearchRoot.context.Header.in_whs_rowid = objfpoSearch.in_whs_rowid;
                    objfpoSearchRoot.context.Header.in_LotNo = objfpoSearch.in_LotNo;
                    objfpoSearchRoot.context.Header.in_whs_Code = (string)cmd.Parameters["in_whs_Code"].Value.ToString();
                    objfpoSearchRoot.context.Header.in_agg_code = (string)cmd.Parameters["in_agg_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.in_agg_name = (string)cmd.Parameters["in_agg_name"].ToString();
                    objfpoSearchRoot.context.Header.in_payment_advcno = (string)cmd.Parameters["in_payment_advcno"].Value.ToString(); 
                    objfpoSearchRoot.context.Header.in_Accepted_Qty = (decimal)cmd.Parameters["in_Accepted_Qty"].Value; 
                    objfpoSearchRoot.context.Header.in_Accepted_date = Convert.ToDateTime(cmd.Parameters["in_Accepted_date"].Value).ToString("yyyy-MM-dd");
                    objfpoSearchRoot.context.Header.in_status = (string)cmd.Parameters["in_status"].Value.ToString();
                    objfpoSearchRoot.context.Header.in_Remarks = (string)cmd.Parameters["in_Remarks"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objfpoSearchRoot;
        }
        //
        public PAWHS_NewWareHouseReceipt_SDocument save_pawhs_NewWareHouseReceipt(PAWHS_NewWareHouseReceipt_SApplication ObjContext, string mysqlcon)
        {
            int ret = 0;
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            PAWHS_NewWareHouseReceipt_SDocument objresFarmer = new PAWHS_NewWareHouseReceipt_SDocument();
            objresFarmer.context = new PAWHS_NewWareHouseReceipt_SContext();
            objresFarmer.context.Header = new PAWHS_NewWareHouseReceipt_saveHeader();
            
            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                MySqlCommand cmd = new MySqlCommand("New_PAWHS_insupd_whsreceipting", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("in_whs_rowid", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_whs_rowid;
                cmd.Parameters.Add("in_whs_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_whs_code;
                cmd.Parameters.Add("in_LotNo", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_LotNo;
                cmd.Parameters.Add("in_Accepted_Qty", MySqlDbType.Decimal).Value = ObjContext.document.context.Header.in_Accepted_Qty;
                cmd.Parameters.Add("in_Accepted_date", MySqlDbType.Date).Value = ObjContext.document.context.Header.in_Accepted_date;
                cmd.Parameters.Add("in_status", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_status;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_mode_flag; 
                cmd.Parameters.Add("in_Remarks", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_Remarks;
                cmd.Parameters.Add("in_Created_by", MySqlDbType.VarChar).Value = ObjContext.document.context.userId; 
                cmd.Parameters.Add("in_modified_by", MySqlDbType.VarChar).Value = ObjContext.document.context.userId; 
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("inout_whs_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("inout_whs_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery(); 
                mysqltrans.Commit();
                objresFarmer = ObjContext.document;
                objresFarmer.context.Header.in_whs_rowid = (Int32)cmd.Parameters["inout_whs_rowid1"].Value;
                objresFarmer.context.Header.in_whs_code = (string)cmd.Parameters["inout_whs_code1"].Value; 
                return objresFarmer;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                throw ex;

            }
        }
    }
}
