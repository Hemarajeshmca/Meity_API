using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using static FFI_Model.New_Pawhs_SaleEntryModel;

namespace FFI_DataModel
{
    public class New_Pawhs_SaleEntry_DataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(New_Pawhs_BatchCreation_DataModel)); //Declaring Log4Net. 
        string methodName = MethodBase.GetCurrentMethod().Name;

        public PawhsBatSaleEntryApplication PawhsSaleEntry_List(PawhsSaleEntryContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            PawhsBatSaleEntryApplication ObjFetchAll = new PawhsBatSaleEntryApplication();
            ObjFetchAll.context = new PawhsSaleEntryContext();
            ObjFetchAll.context.List = new List<PawhsSaleEntryList>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_fetch_whs_sale_entry_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("In_filterby_option", MySqlDbType.VarChar).Value = ObjContext.FilterBy_Option;
                cmd.Parameters.Add("In_filterby_code", MySqlDbType.VarChar).Value = ObjContext.FilterBy_Code;
                cmd.Parameters.Add("In_filterby_fromvalue", MySqlDbType.VarChar).Value = ObjContext.FilterBy_FromValue;
                cmd.Parameters.Add("In_filterby_tovalue", MySqlDbType.VarChar).Value = ObjContext.FilterBy_ToValue;
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PawhsSaleEntryList objList = new PawhsSaleEntryList();
                    objList.Out_sale_rowid = Convert.ToInt32(dt.Rows[i]["Out_sale_rowid"]);
                    objList.Out_sale_code = dt.Rows[i]["Out_sale_code"].ToString();
                    objList.Out_orgn_code = dt.Rows[i]["Out_orgn_code"].ToString();
                    objList.Out_agg_code = dt.Rows[i]["Out_agg_code"].ToString();
                    objList.Out_buyer_code = dt.Rows[i]["Out_buyer_code"].ToString();
                    objList.Out_buyer_name = dt.Rows[i]["Out_buyer_name"].ToString();
                    objList.Out_item_code = dt.Rows[i]["Out_item_code"].ToString();
                    objList.Out_item_name = dt.Rows[i]["Out_item_name"].ToString();
                    objList.Out_qty = Convert.ToDouble(dt.Rows[i]["Out_qty"]);
                    objList.Out_price = Convert.ToDouble(dt.Rows[i]["Out_price"]);
                    objList.Out_value = Convert.ToDouble(dt.Rows[i]["Out_value"]);
                    objList.Out_whs_code = dt.Rows[i]["Out_whs_code"].ToString();
                    objList.whs_name = dt.Rows[i]["whs_name"].ToString();
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
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
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }

            return ObjFetchAll;
        }
        public PAWHSSaleEntryFetchApplication PawhsSaleEntry_SingleFetch(PAWHSSaleEntry_FetchContext objfpoSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();

            PAWHSSaleEntryFetchApplication objfpoSearchRoot = new PAWHSSaleEntryFetchApplication();

            DataTable Map = new DataTable();
            DataTable OtherDt = new DataTable();
            DataTable SlnoDt = new DataTable();

            objfpoSearchRoot.context = new PAWHSSaleEntry_FetchContext();
            objfpoSearchRoot.context.Header = new PAWHSSaleEntry_FetchHeader();
            objfpoSearchRoot.context.SaleEntryList = new List<PAWHSSaleEntry_Fetch_List>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("New_PAWHS_fetch_whs_sale_entry", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;
                cmd.Parameters.Add("IOU_sale_rowid", MySqlDbType.Int32).Value = objfpoSearch.IOU_sale_rowid;
                cmd.Parameters.Add(new MySqlParameter("In_sale_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_orgn_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_agg_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_buyer_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_buyer_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_item_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_item_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_qty", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_price", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_value", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_whs_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_whs_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_sale_rowid1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();
                if (ds.Tables.Count > 0)
                {
                    OtherDt = ds.Tables[0];
                    for (int i = 0; i < OtherDt.Rows.Count; i++)
                    {
                        PAWHSSaleEntry_Fetch_List ObjOtherList = new PAWHSSaleEntry_Fetch_List();
                        ObjOtherList.In_salevehicle_rowid = (Int32)OtherDt.Rows[i]["In_salevehicle_rowid"];
                        ObjOtherList.In_whs_saleno = OtherDt.Rows[i]["In_whs_saleno"].ToString();
                        ObjOtherList.In_vehicle_no = OtherDt.Rows[i]["In_vehicle_no"].ToString();
                        ObjOtherList.In_sl_no = OtherDt.Rows[i]["In_sl_no"].ToString();
                        ObjOtherList.In_remarks = OtherDt.Rows[i]["In_remarks"].ToString();
                        ObjOtherList.In_status_code = OtherDt.Rows[i]["In_status_code"].ToString();
                        ObjOtherList.In_status_desc = OtherDt.Rows[i]["In_status_desc"].ToString();
                        ObjOtherList.In_mode_flag = OtherDt.Rows[i]["In_mode_flag"].ToString();
                        objfpoSearchRoot.context.SaleEntryList.Add(ObjOtherList);
                    }


                    objfpoSearchRoot.context.orgnId = objfpoSearch.orgnId;
                    objfpoSearchRoot.context.locnId = objfpoSearch.locnId;
                    objfpoSearchRoot.context.userId = objfpoSearch.userId;
                    objfpoSearchRoot.context.localeId = objfpoSearch.localeId;
                    objfpoSearchRoot.context.IOU_sale_rowid = objfpoSearch.IOU_sale_rowid;
                    objfpoSearchRoot.context.Header.In_sale_code = (string)cmd.Parameters["In_sale_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_orgn_code = (string)cmd.Parameters["In_orgn_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_agg_code = (string)cmd.Parameters["In_agg_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_buyer_code = (string)cmd.Parameters["In_buyer_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_buyer_name = (string)cmd.Parameters["In_buyer_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_item_code = (string)cmd.Parameters["In_item_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_item_name = (string)cmd.Parameters["In_item_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_qty = (double)cmd.Parameters["In_qty"].Value;
                    objfpoSearchRoot.context.Header.In_price = (double)cmd.Parameters["In_price"].Value;
                    objfpoSearchRoot.context.Header.In_value = (double)cmd.Parameters["In_value"].Value;
                    objfpoSearchRoot.context.Header.In_whs_code = (string)cmd.Parameters["In_whs_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_whs_name = (string)cmd.Parameters["In_whs_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                    objfpoSearchRoot.context.Header.IOU_sale_rowid1 = (string)cmd.Parameters["IOU_sale_rowid1"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objfpoSearch.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }
            return objfpoSearchRoot;
        }
        public PAWHSSaleEntry_Save_Document save_new_saleentry_DB(PAWHSSaleEntry_Save_Application objAG, string ConString)
        {
            string[] response = { };
            PAWHSSaleEntry_Save_Document ObjFetch = new PAWHSSaleEntry_Save_Document();
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            try
            {
                int ret = 0;
                int retdtls = 0;
                MysqlCon = new DataConnection(ConString);
                PAWHSSaleEntry_Save_Context objContext = new PAWHSSaleEntry_Save_Context();
                PAWHSSaleEntry_Save_Header objOutHeader = new PAWHSSaleEntry_Save_Header();
                ObjFetch.context = objContext;
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                MySqlCommand cmd = new MySqlCommand("New_PAWHS_insupd_whs_sale_entry", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("IOU_sale_rowid", MySqlDbType.Int32).Value = objAG.document.context.Header.IOU_sale_rowid;
                cmd.Parameters.Add("In_sale_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_sale_code;
                cmd.Parameters.Add("In_agg_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_agg_code;
                cmd.Parameters.Add("In_buyer_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_buyer_code;
                cmd.Parameters.Add("In_buyer_name", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_buyer_name;
                cmd.Parameters.Add("In_item_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_item_code;
                cmd.Parameters.Add("In_item_name", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_item_name;
                cmd.Parameters.Add("In_qty", MySqlDbType.Double).Value = objAG.document.context.Header.In_qty;
                cmd.Parameters.Add("In_price", MySqlDbType.Double).Value = objAG.document.context.Header.In_price;
                cmd.Parameters.Add("In_value", MySqlDbType.Double).Value = objAG.document.context.Header.In_value;
                cmd.Parameters.Add("In_whs_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_whs_code;
                cmd.Parameters.Add("In_whs_name", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_whs_name;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objAG.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objAG.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objAG.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objAG.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("IOU_sale_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                retdtls = cmd.ExecuteNonQuery();

                if (retdtls > 0)
                {
                    objOutHeader.IOU_sale_rowid = (Int32)cmd.Parameters["IOU_sale_rowid1"].Value;
                }
                objContext.Header = objOutHeader;
                bool isvaild = true;
                if (objOutHeader.IOU_sale_rowid > 0)
                {
                    foreach (var Details in objAG.document.context.Detail)
                    {
                        MySqlCommand cmds = new MySqlCommand("New_PAWHS_iud_whssale_vehicle", MysqlCon.con);
                        cmds.CommandType = CommandType.StoredProcedure;
                        cmds.Parameters.Add("IOU_salevehicle_rowid", MySqlDbType.VarChar).Value = Details.IOU_salevehicle_rowid;
                        cmds.Parameters.Add("In_whs_saleno", MySqlDbType.VarChar).Value = Details.In_whs_saleno;
                        cmds.Parameters.Add("In_vehicle_no", MySqlDbType.VarChar).Value = Details.In_vehicle_no;
                        cmds.Parameters.Add("In_sl_no", MySqlDbType.Int32).Value = Details.In_sl_no;
                        cmds.Parameters.Add("In_remarks", MySqlDbType.VarChar).Value = Details.In_remarks;
                        cmds.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Details.In_mode_flag;
                        cmds.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objAG.document.context.orgnId;
                        cmds.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objAG.document.context.locnId;
                        cmds.Parameters.Add("userId", MySqlDbType.VarChar).Value = objAG.document.context.userId;
                        cmds.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objAG.document.context.localeId; ret = cmds.ExecuteNonQuery();
                        if (ret == 0)
                        {
                            mysqltrans.Rollback();
                            isvaild = false;
                            break;
                        }
                    }
                }
                else
                {
                    mysqltrans.Rollback();
                }
                if (MysqlCon.con.State == ConnectionState.Open)
                {
                    mysqltrans.Commit();
                    MysqlCon.con.Close();
                }

            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                throw (ex);
            }
            return ObjFetch;
        }


    }


}
