using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FFI_Model;

namespace FFI_DataModel
{
    public class NewPawhsActualProc_DB
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();

        public PAWHSActualProcurmentApplication GetActualProcurmentList(PAWHSActualProcurmentContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            PAWHSActualProcurmentApplication ObjFetchAll = new PAWHSActualProcurmentApplication();
            ObjFetchAll.context = new PAWHSActualProcurmentContext();
            ObjFetchAll.context.List = new List<PAWHSActualProcurmentList>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_Fetch_Actual_procurment_List", MysqlCon.con);
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
                    PAWHSActualProcurmentList objList = new PAWHSActualProcurmentList();
                    objList.Out_act_rowid = Convert.ToInt32(dt.Rows[i]["Out_act_rowid"]);
                    objList.Out_agg_code = dt.Rows[i]["Out_agg_code"].ToString();
                    objList.Out_agg_name = dt.Rows[i]["Out_agg_name"].ToString();
                    objList.Out_date = dt.Rows[i]["Out_date"].ToString();
                    objList.Out_Qty = dt.Rows[i]["Out_Qty"].ToString();
                    objList.Out_UnitPrice = dt.Rows[i]["Out_UnitPrice"].ToString();
                    objList.Out_TotalPrice = dt.Rows[i]["Out_TotalPrice"].ToString();
                    objList.Out_lotno = dt.Rows[i]["Out_lotno"].ToString();
                    //objList.Out_farmer_code = dt.Rows[i]["Out_farmer_code"].ToString();
                    objList.Out_farmer_name = dt.Rows[i]["Out_farmer_name"].ToString();
                    objList.Out_member_type = dt.Rows[i]["Out_member_type"].ToString();
                    //objList.Out_item_code = dt.Rows[i]["Out_item_code"].ToString();
                    objList.Out_item_name = dt.Rows[i]["Out_item_name"].ToString();
                    objList.Out_status = dt.Rows[i]["Out_status"].ToString();
                    objList.Out_row_timestamp = dt.Rows[i]["Out_row_timestamp"].ToString();
                    objList.Out_MobileNo = dt.Rows[i]["Out_MobileNo"].ToString(); //ramya added below on 12 jul 21
                    objList.Out_FHW_Name = dt.Rows[i]["Out_FHW_Name"].ToString();
                    objList.Out_Village = dt.Rows[i]["Out_Village"].ToString();
                    objList.Out_Taluk = dt.Rows[i]["Out_Taluk"].ToString();
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

        public PAWHSActualProcurmentFetchApplication Single_ActualProcurment(PAWHSActualProcurment_FetchContext objfpoSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();

            PAWHSActualProcurmentFetchApplication objfpoSearchRoot = new PAWHSActualProcurmentFetchApplication();

            DataTable Map = new DataTable();
            DataTable OtherDt = new DataTable();
            DataTable OtherDt1 = new DataTable();
            DataTable SlnoDt = new DataTable();

            objfpoSearchRoot.context = new PAWHSActualProcurment_FetchContext();
            objfpoSearchRoot.context.Header = new PAWHSActualProcurment_FetchHeader();
            objfpoSearchRoot.context.QtyDetail = new List<PAWHSActualProcurment_Fetch_QtyDetail>();
            objfpoSearchRoot.context.OtherDetail = new List<PAWHSActualProcurment_Fetch_OtherDetail>();
            objfpoSearchRoot.context.OtherDetail1 = new List<PAWHSActualProcurment_Fetch_OtherDetail1>();
            objfpoSearchRoot.context.SlnoDetail = new List<PAWHSActualProcurment_Fetch_SlnoDetail>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("New_PAWHS_Fetch_Actual_Procurment", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;
                cmd.Parameters.Add("IOU_act_rowid", MySqlDbType.Int32).Value = objfpoSearch.IOU_act_rowid;
                cmd.Parameters.Add("IOU_agg_code", MySqlDbType.VarChar).Value = objfpoSearch.IOU_agg_code;
                cmd.Parameters.Add("IOU_lotno", MySqlDbType.VarChar).Value = objfpoSearch.IOU_lotno;
                cmd.Parameters.Add(new MySqlParameter("In_farmer_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_farmer_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_member_type", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_item_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_item_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_actual_qty", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_actual_price", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_actual_value", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_advance_amt", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_no_of_bags", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_status", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_actual_remarks", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_approved_remarks", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_pickup_remarks", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_wr_remarks", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_whs_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_Accepted_Qty", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_act_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_agg_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_lotno1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_Estimated_PickDate", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_actual_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_approve_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_reject_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_wr_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_payto_farmer", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_actual_attach", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_vehicle_type", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_vehicle_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_destination", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_qcperson_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_LRP_Name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_LRP_Mobile_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_Payment_type", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_Bank_acc_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_cheque_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_Buyer_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_Buyer_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_agg_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                cmd.Parameters.Add(new MySqlParameter("In_FHW_Name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_Village", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_Taluk", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_MobileNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_season", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();
                if (ds.Tables.Count > 0)
                {
                    Map = ds.Tables[0];
                    for (int i = 0; i < Map.Rows.Count; i++)
                    {
                        PAWHSActualProcurment_Fetch_QtyDetail objDetailList = new PAWHSActualProcurment_Fetch_QtyDetail();
                        objDetailList.In_qty_row_id = Convert.ToInt32(Map.Rows[i]["In_qty_row_id"]);
                        objDetailList.In_agg_code = Map.Rows[i]["In_agg_code"].ToString();
                        objDetailList.In_lotno = Map.Rows[i]["In_lotno"].ToString();
                        objDetailList.In_item_code = Map.Rows[i]["In_item_code"].ToString();
                        objDetailList.In_qty_code = Map.Rows[i]["In_qty_code"].ToString();
                        objDetailList.In_qty_name = Map.Rows[i]["In_qty_name"].ToString();
                        objDetailList.In_qty_range = Map.Rows[i]["In_qty_range"].ToString();
                        objDetailList.In_qty_unit = Map.Rows[i]["In_qty_unit"].ToString();
                        objDetailList.In_actual_value = Convert.ToDouble(Map.Rows[i]["In_actual_value"]);
                        objDetailList.In_wr_qty_value = Convert.ToDouble(Map.Rows[i]["In_wr_qty_value"]);
                        objDetailList.In_mode_flag = Map.Rows[i]["In_mode_flag"].ToString();
                        objfpoSearchRoot.context.QtyDetail.Add(objDetailList);
                    }
                    OtherDt = ds.Tables[1];
                    for (int i = 0; i < OtherDt.Rows.Count; i++)
                    {
                        PAWHSActualProcurment_Fetch_OtherDetail ObjOtherList = new PAWHSActualProcurment_Fetch_OtherDetail();
                        ObjOtherList.In_Other_row_id = Convert.ToInt32(OtherDt.Rows[i]["In_Other_row_id"]);
                        ObjOtherList.In_agg_code = OtherDt.Rows[i]["In_agg_code"].ToString();
                        ObjOtherList.In_lotno = OtherDt.Rows[i]["In_lotno"].ToString();
                        ObjOtherList.In_packaging_cost = Convert.ToDouble(OtherDt.Rows[i]["In_packaging_cost"]);
                        ObjOtherList.In_transporting_cost = Convert.ToDouble(OtherDt.Rows[i]["In_transporting_cost"]);
                        ObjOtherList.In_unpacking_cost = Convert.ToDouble(OtherDt.Rows[i]["In_unpacking_cost"]);
                        ObjOtherList.In_local_packaging_cost = Convert.ToDouble(OtherDt.Rows[i]["In_local_packaging_cost"]);
                        ObjOtherList.In_local_transporting_cost = Convert.ToDouble(OtherDt.Rows[i]["In_local_transporting_cost"]);
                        ObjOtherList.In_temp_cost = Convert.ToDouble(OtherDt.Rows[i]["In_temp_cost"]);
                        ObjOtherList.In_temp_cost1 = Convert.ToDouble(OtherDt.Rows[i]["In_temp_cost1"]);
                        ObjOtherList.In_temp_cost2 = Convert.ToDouble(OtherDt.Rows[i]["In_temp_cost2"]);
                        ObjOtherList.In_mode_flag = OtherDt.Rows[i]["In_mode_flag"].ToString();
                        objfpoSearchRoot.context.OtherDetail.Add(ObjOtherList);
                    }
                    SlnoDt = ds.Tables[2];
                    for (int i = 0; i < SlnoDt.Rows.Count; i++)
                    {
                        PAWHSActualProcurment_Fetch_SlnoDetail ObjSlnoList = new PAWHSActualProcurment_Fetch_SlnoDetail();
                        ObjSlnoList.In_slno_row_id = Convert.ToInt32(SlnoDt.Rows[i]["In_slno_row_id"]);
                        ObjSlnoList.In_agg_code = SlnoDt.Rows[i]["In_agg_code"].ToString();
                        ObjSlnoList.In_lotno = SlnoDt.Rows[i]["In_lotno"].ToString();
                        ObjSlnoList.In_slno = SlnoDt.Rows[i]["In_slno"].ToString();
                        ObjSlnoList.In_temp1 = SlnoDt.Rows[i]["In_temp1"].ToString();
                        ObjSlnoList.In_temp2 = SlnoDt.Rows[i]["In_temp2"].ToString();
                        ObjSlnoList.In_qty = SlnoDt.Rows[i]["In_qty"].ToString();
                        ObjSlnoList.In_mode_flag = SlnoDt.Rows[i]["In_mode_flag"].ToString();
                        objfpoSearchRoot.context.SlnoDetail.Add(ObjSlnoList);
                    }
                    OtherDt1 = ds.Tables[3];
                    for (int i = 0; i < OtherDt1.Rows.Count; i++)
                    {
                        PAWHSActualProcurment_Fetch_OtherDetail1 ObjOtherList1 = new PAWHSActualProcurment_Fetch_OtherDetail1();
                        ObjOtherList1.In_lotno = OtherDt1.Rows[i]["In_lotno"].ToString();
                        ObjOtherList1.In_type = OtherDt1.Rows[i]["In_type"].ToString();
                        ObjOtherList1.In_value = Convert.ToDouble(OtherDt1.Rows[i]["In_value"]);
                        objfpoSearchRoot.context.OtherDetail1.Add(ObjOtherList1);
                    }
                    objfpoSearchRoot.context.orgnId = objfpoSearch.orgnId;
                    objfpoSearchRoot.context.locnId = objfpoSearch.locnId;
                    objfpoSearchRoot.context.userId = objfpoSearch.userId;
                    objfpoSearchRoot.context.localeId = objfpoSearch.localeId;
                    objfpoSearchRoot.context.Header.IOU_act_rowid = (Int32)cmd.Parameters["IOU_act_rowid1"].Value;
                    objfpoSearchRoot.context.Header.IOU_agg_code = (string)cmd.Parameters["IOU_agg_code1"].Value.ToString();
                    objfpoSearchRoot.context.Header.IOU_agg_name = (string)cmd.Parameters["IOU_agg_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.IOU_lotno = (string)cmd.Parameters["IOU_lotno1"].Value.ToString();
                    //objfpoSearchRoot.context.Header.In_farmer_code = (string)cmd.Parameters["In_farmer_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_farmer_name = (string)cmd.Parameters["In_farmer_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_member_type = (string)cmd.Parameters["In_member_type"].Value.ToString();
                    //objfpoSearchRoot.context.Header.In_item_code = (string)cmd.Parameters["In_item_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_item_name = (string)cmd.Parameters["In_item_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_actual_qty = (double)cmd.Parameters["In_actual_qty"].Value;
                    objfpoSearchRoot.context.Header.In_actual_price = (double)cmd.Parameters["In_actual_price"].Value;
                    objfpoSearchRoot.context.Header.In_actual_value = (double)cmd.Parameters["In_actual_value"].Value;
                    objfpoSearchRoot.context.Header.in_advance_amt = (double)cmd.Parameters["in_advance_amt"].Value;
                    objfpoSearchRoot.context.Header.In_no_of_bags = (Int32)cmd.Parameters["In_no_of_bags"].Value;
                    objfpoSearchRoot.context.Header.in_status = (string)cmd.Parameters["in_status"].Value.ToString();
                    objfpoSearchRoot.context.Header.in_actual_remarks = (string)cmd.Parameters["in_actual_remarks"].Value.ToString();
                    objfpoSearchRoot.context.Header.in_approved_remarks = (string)cmd.Parameters["in_approved_remarks"].Value.ToString();
                    objfpoSearchRoot.context.Header.in_pickup_remarks = (string)cmd.Parameters["in_pickup_remarks"].Value.ToString();
                    objfpoSearchRoot.context.Header.in_wr_remarks = (string)cmd.Parameters["in_wr_remarks"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_wh_code = (string)cmd.Parameters["IOU_whs_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_accepted_qty = (double)cmd.Parameters["IOU_Accepted_Qty"].Value;
                    objfpoSearchRoot.context.Header.In_Estimated_PickDate = (string)cmd.Parameters["In_Estimated_PickDate"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_actual_date = (string)cmd.Parameters["In_actual_date"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_approve_date = (string)cmd.Parameters["In_approve_date"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_reject_date = (string)cmd.Parameters["In_reject_date"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_wr_date = (string)cmd.Parameters["In_wr_date"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_payto_farmer = (double)cmd.Parameters["In_payto_farmer"].Value;
                    objfpoSearchRoot.context.Header.In_actual_attach = (string)cmd.Parameters["In_actual_attach"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_vehicle_no = (string)cmd.Parameters["In_vehicle_no"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_qcperson_name = (string)cmd.Parameters["In_qcperson_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_vehicle_type = (string)cmd.Parameters["In_vehicle_type"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_destination = (string)cmd.Parameters["In_destination"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_LRP_Name = (string)cmd.Parameters["In_LRP_Name"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_LRP_Mobile_no = (string)cmd.Parameters["In_LRP_Mobile_no"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_Payment_type = (string)cmd.Parameters["In_Payment_type"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_Bank_acc_no = (string)cmd.Parameters["In_Bank_acc_no"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_cheque_no = (string)cmd.Parameters["In_cheque_no"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_Buyer_code = (string)cmd.Parameters["In_Buyer_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_Buyer_name = (string)cmd.Parameters["In_Buyer_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_cheque_no = (string)cmd.Parameters["In_cheque_no"].Value.ToString();

                    objfpoSearchRoot.context.Header.In_FHW_Name = (string)cmd.Parameters["In_FHW_Name"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_Village = (string)cmd.Parameters["In_Village"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_Taluk = (string)cmd.Parameters["In_Taluk"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_MobileNo = (string)cmd.Parameters["In_MobileNo"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_season = (string)cmd.Parameters["In_season"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objfpoSearchRoot;
        }

        public PAWHSActualProcurment_Save_Document newSaveActualProcurment(PAWHSActualProcurment_Save_Application ObjContext, string mysqlcon)
        {
            int ret = 0;
            int QtyDtl = 0;
            int OtherDtl = 0;
            int SlnoDtl = 0;
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            PAWHSActualProcurment_Save_Document objresFarmer = new PAWHSActualProcurment_Save_Document();
            objresFarmer.ApplicationException = new PAWHSActualProcurmentApplicationException();
            objresFarmer.context = new PAWHSActualProcurment_Save_Context();
            objresFarmer.context.Header = new PAWHSActualProcurment_Save_Header();
            objresFarmer.context.QtyDetail = new List<PAWHSActualProcurment_Save_QtyDetail>();
            objresFarmer.context.OtherDetail = new List<PAWHSActualProcurment_Save_OtherDetail>();
            objresFarmer.context.SlnoDetail = new List<PAWHSActualProcurment_Save_SlnoDetail>();
            int IOU_Actual_rowid = 0;
            string IOU_LotNo = "";
            string IOU_Item_Code = "";
            string IOU_ErroNo = "";


            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                MySqlCommand cmd = new MySqlCommand("New_PAWHS_insupd_Actual_Procurment", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("in_Actual_rowid", MySqlDbType.Int32).Value = ObjContext.document.context.Header.in_Actual_rowid;
                cmd.Parameters.Add("in_LotNo", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_LotNo;
                cmd.Parameters.Add("in_Farmer_Code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_Farmer_Code;
                cmd.Parameters.Add("in_Farmer_Name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_Farmer_Name;
                cmd.Parameters.Add("in_Member_Type", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_Member_Type;
                cmd.Parameters.Add("in_Item_Code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_Item_Code;
                cmd.Parameters.Add("in_Item_Name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_Item_Name;
                cmd.Parameters.Add("in_Actual_Qty", MySqlDbType.Double).Value = ObjContext.document.context.Header.in_Actual_Qty;
                cmd.Parameters.Add("in_Actual_Price", MySqlDbType.Double).Value = ObjContext.document.context.Header.in_Actual_Price;
                cmd.Parameters.Add("in_Actual_Value", MySqlDbType.Double).Value = ObjContext.document.context.Header.in_Actual_Value;
                cmd.Parameters.Add("in_advance_amt", MySqlDbType.Double).Value = ObjContext.document.context.Header.in_advance_amt;
                cmd.Parameters.Add("in_no_of_bags", MySqlDbType.Int32).Value = ObjContext.document.context.Header.in_no_of_bags;
                cmd.Parameters.Add("in_Status", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_Status;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_mode_flag;
                cmd.Parameters.Add("in_actual_remarks", MySqlDbType.LongText).Value = ObjContext.document.context.Header.in_actual_remarks;
                cmd.Parameters.Add("in_approved_remarks", MySqlDbType.LongText).Value = ObjContext.document.context.Header.in_approved_remarks;
                cmd.Parameters.Add("in_pickup_remarks", MySqlDbType.LongText).Value = ObjContext.document.context.Header.in_pickup_remarks;
                cmd.Parameters.Add("in_actual_attach", MySqlDbType.LongText).Value = ObjContext.document.context.Header.in_actual_attach;
                cmd.Parameters.Add("in_vehicle_type", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_vehicle_type;
                cmd.Parameters.Add("in_vehicle_no", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_vehicle_no;
                cmd.Parameters.Add("in_destination", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_destination;
                cmd.Parameters.Add("in_qcperson_name", MySqlDbType.LongText).Value = ObjContext.document.context.Header.in_qcperson_name;
                cmd.Parameters.Add("in_LRP_Name", MySqlDbType.LongText).Value = ObjContext.document.context.Header.in_LRP_Name;
                cmd.Parameters.Add("In_LRP_Mobile_no", MySqlDbType.LongText).Value = ObjContext.document.context.Header.In_LRP_Mobile_no;
                cmd.Parameters.Add("In_Payment_type", MySqlDbType.LongText).Value = ObjContext.document.context.Header.In_Payment_type;
                cmd.Parameters.Add("In_Bank_acc_no", MySqlDbType.LongText).Value = ObjContext.document.context.Header.In_Bank_acc_no;
                cmd.Parameters.Add("In_cheque_no", MySqlDbType.LongText).Value = ObjContext.document.context.Header.In_cheque_no;
                cmd.Parameters.Add("In_Buyer_code", MySqlDbType.LongText).Value = ObjContext.document.context.Header.In_Buyer_code;
                cmd.Parameters.Add("In_Buyer_name", MySqlDbType.LongText).Value = ObjContext.document.context.Header.In_Buyer_name;
                cmd.Parameters.Add("In_Acc_Date", MySqlDbType.LongText).Value = ObjContext.document.context.Header.In_Acc_Date;
                cmd.Parameters.Add("In_season", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_season;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("IOU_Actual_rowid", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_LotNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_Item_Code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_ErroNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();

                if (ret > 0)
                {
                    IOU_Actual_rowid = (Int32)cmd.Parameters["IOU_Actual_rowid"].Value;
                    IOU_LotNo = (string)cmd.Parameters["IOU_LotNo"].Value;
                    IOU_Item_Code = (string)cmd.Parameters["IOU_Item_Code"].Value;
                    IOU_ErroNo = (string)cmd.Parameters["IOU_ErroNo"].Value;

                    if (IOU_ErroNo.Contains("060"))
                    {
                        mysqltrans.Rollback();
                        objresFarmer.ApplicationException.errorNumber = IOU_ErroNo;
                        objresFarmer.ApplicationException.errorDescription = ObjErrormsg.ErrorMessage(IOU_ErroNo);
                        return objresFarmer;
                    }

                    objresFarmer.context.Header.in_Actual_rowid = Convert.ToInt32(IOU_Actual_rowid);
                    objresFarmer.context.Header.in_LotNo = IOU_LotNo;
                    objresFarmer.context.Header.in_Item_Code = IOU_Item_Code;
                    objresFarmer.context.orgnId = ObjContext.document.context.orgnId;
                    objresFarmer.context.locnId = ObjContext.document.context.locnId;
                    objresFarmer.context.userId = ObjContext.document.context.userId;
                    objresFarmer.context.localeId = ObjContext.document.context.localeId;
                }
                else
                {
                    IOU_ErroNo = (string)cmd.Parameters["IOU_ErroNo"].Value;

                    if (IOU_ErroNo.Contains("060"))
                    {
                        objresFarmer.ApplicationException.errorNumber = IOU_ErroNo;
                        objresFarmer.ApplicationException.errorDescription = ObjErrormsg.ErrorMessage(IOU_ErroNo);
                    }
                    mysqltrans.Rollback();
                    return objresFarmer;
                }
                if (ObjContext.document.context.Header.in_Status.ToLower() != "approved")
                {
                    if (objresFarmer.context.Header.in_Actual_rowid > 0)
                    {
                        if (ObjContext.document.context.QtyDetail.Count > 0)
                        {
                            QtyDtl = SaveQtyDtl(ObjContext, objresFarmer, mysqlcon, MysqlCon);
                            if (QtyDtl == 0)
                            {

                                objresFarmer.ApplicationException.errorDescription = "Qty Detail Record Not available";
                                mysqltrans.Rollback();
                                return objresFarmer;
                            }
                        }
                        if (ObjContext.document.context.OtherDetail.Count > 0)
                        {
                            OtherDtl = SaveOtherDtl(ObjContext, objresFarmer, mysqlcon, MysqlCon);
                            if (OtherDtl == 0)
                            {
                                objresFarmer.ApplicationException.errorDescription = "Other Detail Record Not available";
                                mysqltrans.Rollback();
                                return objresFarmer;
                            }
                        }
                        if (ObjContext.document.context.SlnoDetail.Count > 0)
                        {
                            SlnoDtl = SaveSlnoDtl(ObjContext, objresFarmer, mysqlcon, MysqlCon);
                            if (SlnoDtl == 0)
                            {
                                objresFarmer.ApplicationException.errorDescription = "SlNo Detail Record Not available";
                                mysqltrans.Rollback();
                                return objresFarmer;
                            }
                        }
                        else
                        {
                            PAWHSActualProcurment_Save_SlnoDetail objdtlslno = new PAWHSActualProcurment_Save_SlnoDetail();                           
                            objdtlslno.In_slno_row_id = 0;
                            objdtlslno.lotno = objresFarmer.context.Header.in_LotNo;
                            objdtlslno.In_slno = "LB" + ObjContext.document.context.Header.in_Item_Code;
                            objdtlslno.In_temp1 = "NA";
                            objdtlslno.In_temp2 = "NA";
                            objdtlslno.in_qty = Convert.ToDouble(ObjContext.document.context.Header.in_Actual_Qty).ToString();
                            objdtlslno.In_mode_flag = ObjContext.document.context.Header.in_mode_flag;
                            ObjContext.document.context.SlnoDetail.Add(objdtlslno);
                            SlnoDtl = SaveSlnoDtl(ObjContext, objresFarmer, mysqlcon, MysqlCon);
                        }
                        mysqltrans.Commit();
                    }
                }
                else
                {
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
        public int SaveQtyDtl(PAWHSActualProcurment_Save_Application Objmodel, PAWHSActualProcurment_Save_Document objfarmer, string MysqlCons, DataConnection MysqlCon)
        {
            int ret = 0;
            DataTable tab = new DataTable();
            PAWHSActualProcurment_Save_QtyDetail objFarmersMapped = new PAWHSActualProcurment_Save_QtyDetail();
            try
            {
                NewPawhsActualProc_DB objproduct1 = new NewPawhsActualProc_DB();
                foreach (var QtyDetails in Objmodel.document.context.QtyDetail)
                {
                    if (objfarmer.context.Header.in_LotNo == QtyDetails.lotno || QtyDetails.lotno == null)
                    {
                        MySqlCommand cmd = new MySqlCommand("New_PAWHS_iud_Procurment_qtydtl", MysqlCon.con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("in_qty_row_id", MySqlDbType.Int32).Value = QtyDetails.In_qty_dtl_rowid;
                        cmd.Parameters.Add("in_LotNo", MySqlDbType.VarChar).Value = objfarmer.context.Header.in_LotNo;
                        cmd.Parameters.Add("in_item_code", MySqlDbType.VarChar).Value = objfarmer.context.Header.in_Item_Code;
                        cmd.Parameters.Add("in_qty_code", MySqlDbType.VarChar).Value = QtyDetails.In_qty_code;
                        cmd.Parameters.Add("in_actual_value", MySqlDbType.Double).Value = QtyDetails.In_actual_value;
                        cmd.Parameters.Add("in_wr_qty_value", MySqlDbType.Double).Value = QtyDetails.In_wr_qty_value;
                        cmd.Parameters.Add("in_estimate_qty_value", MySqlDbType.VarChar).Value = QtyDetails.in_estimate_qty_value;
                        cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = QtyDetails.In_mode_flag;
                        cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                        cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                        cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                        cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                        cmd.Parameters.Add(new MySqlParameter("inout_qty_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new MySqlParameter("inout_lotno1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                        ret = cmd.ExecuteNonQuery();

                        if (ret == 0)
                        {
                            break;
                        }
                    }
                }
                return ret;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                throw ex;
            }

        }
        public int SaveOtherDtl(PAWHSActualProcurment_Save_Application Objmodel, PAWHSActualProcurment_Save_Document objfarmer, string MysqlCons, DataConnection MysqlCon)
        {
            int ret = 0;
            DataTable tab = new DataTable();
            PAWHSActualProcurment_Save_OtherDetail objFarmersMapped = new PAWHSActualProcurment_Save_OtherDetail();
            try
            {
                NewPawhsActualProc_DB objproduct1 = new NewPawhsActualProc_DB();
                foreach (var OtherDetails in Objmodel.document.context.OtherDetail)
                {
                    if (objfarmer.context.Header.in_LotNo == OtherDetails.lotno || OtherDetails.lotno == null)
                    {
                        MySqlCommand cmd = new MySqlCommand("New_PAWHS_iud_Procurment_otherdtl", MysqlCon.con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("in_otherdtl_row_id", MySqlDbType.Int32).Value = OtherDetails.In_otherdtl_row_id;
                        cmd.Parameters.Add("in_LotNo", MySqlDbType.VarChar).Value = objfarmer.context.Header.in_LotNo;
                        cmd.Parameters.Add("in_packaging_cost", MySqlDbType.Double).Value = OtherDetails.In_packaging_cost;
                        cmd.Parameters.Add("in_transporting_cost", MySqlDbType.Double).Value = OtherDetails.In_transporting_cost;
                        cmd.Parameters.Add("in_unpacking_cost", MySqlDbType.Double).Value = OtherDetails.In_unpacking_cost;
                        cmd.Parameters.Add("in_local_packaging_cost", MySqlDbType.Double).Value = OtherDetails.In_local_packaging_cost;
                        cmd.Parameters.Add("in_local_transporting_cost", MySqlDbType.Double).Value = OtherDetails.In_local_transporting_cost;
                        cmd.Parameters.Add("in_temp_cost", MySqlDbType.Double).Value = OtherDetails.In_temp_cost;
                        cmd.Parameters.Add("in_temp_cost1", MySqlDbType.Double).Value = OtherDetails.In_temp_cost1;
                        cmd.Parameters.Add("in_temp_cost2", MySqlDbType.Double).Value = OtherDetails.In_temp_cost2;
                        cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = OtherDetails.In_mode_flag;
                        cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                        cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                        cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                        cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                        cmd.Parameters.Add(new MySqlParameter("inout_otherdtl_row_id1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new MySqlParameter("inout_lotno1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                        ret = cmd.ExecuteNonQuery();

                        if (ret == 0)
                        {
                            break;
                        }
                    }
                }
                return ret;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                throw ex;
            }

        }
        public int SaveSlnoDtl(PAWHSActualProcurment_Save_Application Objmodel, PAWHSActualProcurment_Save_Document objfarmer, string MysqlCons, DataConnection MysqlCon)
        {
            int ret = 0;
            DataTable tab = new DataTable();
            PAWHSActualProcurment_Save_SlnoDetail objFarmersMapped = new PAWHSActualProcurment_Save_SlnoDetail();
            try
            {

                NewPawhsActualProc_DB objproduct1 = new NewPawhsActualProc_DB();
                foreach (var SlnoDetails in Objmodel.document.context.SlnoDetail)
                {
                    if (objfarmer.context.Header.in_LotNo == SlnoDetails.lotno || SlnoDetails.lotno == null)
                    {
                        MySqlCommand cmd = new MySqlCommand("New_PAWHS_iud_procurment_slnodtl", MysqlCon.con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("in_slno_row_id", MySqlDbType.Int32).Value = SlnoDetails.In_slno_row_id;
                        cmd.Parameters.Add("in_LotNo", MySqlDbType.VarChar).Value = objfarmer.context.Header.in_LotNo;
                        cmd.Parameters.Add("in_slno", MySqlDbType.VarChar).Value = SlnoDetails.In_slno;
                        cmd.Parameters.Add("in_temp1", MySqlDbType.VarChar).Value = SlnoDetails.In_temp1;
                        cmd.Parameters.Add("in_temp2", MySqlDbType.VarChar).Value = SlnoDetails.In_temp2;
                        cmd.Parameters.Add("in_qty", MySqlDbType.Double).Value = Convert.ToDouble(SlnoDetails.in_qty);
                        cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = SlnoDetails.In_mode_flag;
                        cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                        cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                        cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                        cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                        cmd.Parameters.Add(new MySqlParameter("inout_slno_row_id1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(new MySqlParameter("inout_lotno1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                        ret = cmd.ExecuteNonQuery();

                        if (ret == 0)
                        {
                            break;
                        }
                    }
                }
                return ret;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();

                throw ex;
            }

        }

        public PAWHSEstimateActWRApplication Estimate_Actual_Approve_List(PAWHSEstimateActWRContext objfpoSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();
            PAWHSEstimateActWRApplication objfpoSearchRoot = new PAWHSEstimateActWRApplication();
            DataTable List_Dt = new DataTable();
            string error_msg = "";

            objfpoSearchRoot.context = new PAWHSEstimateActWRContext();
            objfpoSearchRoot.context.Estimate_List = new List<PAWHSEstimateProcurementList_Mob>();
            objfpoSearchRoot.context.Actual_List = new List<PAWHSActualProcurementList_Mob>();
            objfpoSearchRoot.context.Approved_List = new List<PAWHSActualProcurementList_Mob>();

            objfpoSearchRoot.ApplicationException = new PAWHSActualProcurmentApplicationException();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("New_PAWHS_Fetch_Actual_Status", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;
                cmd.Parameters.Add("In_Status", MySqlDbType.VarChar).Value = objfpoSearch.status;
                cmd.Parameters.Add(new MySqlParameter("IOU_ErroMsg", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();
                if (ds.Tables.Count > 0)
                {
                    List_Dt = ds.Tables[0];
                    if (objfpoSearch.status.ToLower() == "estimate")
                    {
                        for (int i = 0; i < List_Dt.Rows.Count; i++)
                        {
                            PAWHSEstimateProcurementList_Mob objDetailList = new PAWHSEstimateProcurementList_Mob();
                            objDetailList.Out_Estm_rowid = Convert.ToInt32(List_Dt.Rows[i]["Estm_rowid"]);
                            objDetailList.Out_LotNo = List_Dt.Rows[i]["LotNo"].ToString();
                            objDetailList.Out_agg_code = List_Dt.Rows[i]["agg_code"].ToString();
                            objDetailList.Out_agg_name = List_Dt.Rows[i]["agg_name"].ToString();
                            objDetailList.Out_Farmer_Code = List_Dt.Rows[i]["Farmer_Code"].ToString();
                            objDetailList.Out_Farmer_Name = List_Dt.Rows[i]["Farmer_Name"].ToString();
                            objDetailList.Out_Member_Type = List_Dt.Rows[i]["Member_Type"].ToString();
                            objDetailList.Out_Item_Code = List_Dt.Rows[i]["Item_Code"].ToString();
                            objDetailList.Out_Item_Name = List_Dt.Rows[i]["Item_Name"].ToString();
                            objDetailList.Out_Estimated_Qty = Convert.ToDouble(List_Dt.Rows[i]["Estimated_Qty"]);
                            objDetailList.Out_Estimated_Price = Convert.ToDouble(List_Dt.Rows[i]["Estimated_Price"]);
                            objDetailList.Out_Estimated_Value = Convert.ToDouble(List_Dt.Rows[i]["Estimated_Value"]);
                            objDetailList.Out_Estimated_PickupDate = List_Dt.Rows[i]["Estimated_PickDate"].ToString();
                            objDetailList.Out_Remarks = List_Dt.Rows[i]["Remarks"].ToString();
                            objDetailList.Out_Status = List_Dt.Rows[i]["Est_Status"].ToString();

                            objfpoSearchRoot.context.Estimate_List.Add(objDetailList);
                        }
                    }
                    else if (objfpoSearch.status.ToLower() == "actual")
                    {
                        for (int i = 0; i < List_Dt.Rows.Count; i++)
                        {
                            PAWHSActualProcurementList_Mob objDetailList = new PAWHSActualProcurementList_Mob();
                            objDetailList.Out_act_rowid = Convert.ToInt32(List_Dt.Rows[i]["act_rowid"]);
                            objDetailList.Out_agg_code = List_Dt.Rows[i]["agg_code"].ToString();
                            objDetailList.Out_agg_name = List_Dt.Rows[i]["agg_name"].ToString();
                            objDetailList.Out_lotno = List_Dt.Rows[i]["lotno"].ToString();
                            objDetailList.Out_farmer_code = List_Dt.Rows[i]["farmer_code"].ToString();
                            objDetailList.Out_farmer_name = List_Dt.Rows[i]["farmer_name"].ToString();
                            objDetailList.Out_member_type = List_Dt.Rows[i]["member_type"].ToString();
                            objDetailList.Out_item_code = List_Dt.Rows[i]["item_code"].ToString();
                            objDetailList.Out_item_name = List_Dt.Rows[i]["item_name"].ToString();
                            objDetailList.Out_actual_qty = Convert.ToDouble(List_Dt.Rows[i]["actual_qty"]);
                            objDetailList.Out_actual_price = Convert.ToDouble(List_Dt.Rows[i]["actual_price"]);
                            objDetailList.Out_actual_value = Convert.ToDouble(List_Dt.Rows[i]["actual_value"]);
                            objDetailList.Out_actual_date = List_Dt.Rows[i]["actual_date"].ToString();
                            objDetailList.Out_advance_amt = Convert.ToDouble(List_Dt.Rows[i]["advance_amt"]);
                            objDetailList.Out_approve_date = List_Dt.Rows[i]["approve_date"].ToString();
                            objDetailList.Out_pickup_date = List_Dt.Rows[i]["pickup_date"].ToString();
                            objDetailList.Out_wr_date = List_Dt.Rows[i]["wr_date"].ToString();
                            objDetailList.Out_no_of_bags = Convert.ToInt32(List_Dt.Rows[i]["no_of_bags"]);
                            objDetailList.Out_status = List_Dt.Rows[i]["act_status"].ToString();
                            objDetailList.Out_actual_remarks = List_Dt.Rows[i]["actual_remarks"].ToString();
                            objDetailList.Out_approved_remarks = List_Dt.Rows[i]["approved_remarks"].ToString();
                            objDetailList.Out_pickup_remarks = List_Dt.Rows[i]["pickup_remarks"].ToString();
                            objDetailList.Out_wr_remarks = List_Dt.Rows[i]["wr_remarks"].ToString();

                            objfpoSearchRoot.context.Actual_List.Add(objDetailList);
                        }
                    }
                    else if (objfpoSearch.status.ToLower() == "warehouse")
                    {
                        for (int i = 0; i < List_Dt.Rows.Count; i++)
                        {
                            PAWHSActualProcurementList_Mob objDetailList = new PAWHSActualProcurementList_Mob();
                            objDetailList.Out_act_rowid = Convert.ToInt32(List_Dt.Rows[i]["act_rowid"]);
                            objDetailList.Out_agg_code = List_Dt.Rows[i]["agg_code"].ToString();
                            objDetailList.Out_agg_name = List_Dt.Rows[i]["agg_name"].ToString();
                            objDetailList.Out_lotno = List_Dt.Rows[i]["lotno"].ToString();
                            objDetailList.Out_farmer_code = List_Dt.Rows[i]["farmer_code"].ToString();
                            objDetailList.Out_farmer_name = List_Dt.Rows[i]["farmer_name"].ToString();
                            objDetailList.Out_member_type = List_Dt.Rows[i]["member_type"].ToString();
                            objDetailList.Out_item_code = List_Dt.Rows[i]["item_code"].ToString();
                            objDetailList.Out_item_name = List_Dt.Rows[i]["item_name"].ToString();
                            objDetailList.Out_actual_qty = Convert.ToDouble(List_Dt.Rows[i]["actual_qty"]);
                            objDetailList.Out_actual_price = Convert.ToDouble(List_Dt.Rows[i]["actual_price"]);
                            objDetailList.Out_actual_value = Convert.ToDouble(List_Dt.Rows[i]["actual_value"]);
                            objDetailList.Out_actual_date = List_Dt.Rows[i]["actual_date"].ToString();
                            objDetailList.Out_advance_amt = Convert.ToDouble(List_Dt.Rows[i]["advance_amt"]);
                            objDetailList.Out_approve_date = List_Dt.Rows[i]["approve_date"].ToString();
                            objDetailList.Out_pickup_date = List_Dt.Rows[i]["pickup_date"].ToString();
                            objDetailList.Out_wr_date = List_Dt.Rows[i]["wr_date"].ToString();
                            objDetailList.Out_no_of_bags = Convert.ToInt32(List_Dt.Rows[i]["no_of_bags"]);
                            objDetailList.Out_status = List_Dt.Rows[i]["act_status"].ToString();
                            objDetailList.Out_actual_remarks = List_Dt.Rows[i]["actual_remarks"].ToString();
                            objDetailList.Out_approved_remarks = List_Dt.Rows[i]["approved_remarks"].ToString();
                            objDetailList.Out_pickup_remarks = List_Dt.Rows[i]["pickup_remarks"].ToString();
                            objDetailList.Out_wr_remarks = List_Dt.Rows[i]["wr_remarks"].ToString();

                            objfpoSearchRoot.context.Approved_List.Add(objDetailList);
                        }
                    }
                    else if (objfpoSearch.status.ToLower() == "estimateapproved")
                    {
                        for (int i = 0; i < List_Dt.Rows.Count; i++)
                        {
                            PAWHSEstimateProcurementList_Mob objDetailList = new PAWHSEstimateProcurementList_Mob();
                            objDetailList.Out_Estm_rowid = Convert.ToInt32(List_Dt.Rows[i]["rowid"]);
                            objDetailList.Out_LotNo = List_Dt.Rows[i]["lotno"].ToString();
                            objDetailList.Out_agg_code = List_Dt.Rows[i]["agg_code"].ToString();
                            objDetailList.Out_Farmer_Code = List_Dt.Rows[i]["farmer_code"].ToString();
                            objDetailList.Out_Farmer_Name = List_Dt.Rows[i]["farmer_name"].ToString();
                            objDetailList.Out_Member_Type = List_Dt.Rows[i]["member_type"].ToString();
                            objDetailList.Out_Item_Code = List_Dt.Rows[i]["item_code"].ToString();
                            objDetailList.Out_Item_Name = List_Dt.Rows[i]["item_name"].ToString();
                            objDetailList.Out_Estimated_Qty = Convert.ToDouble(List_Dt.Rows[i]["actual_qty"]);
                            objDetailList.Out_Estimated_Price = Convert.ToDouble(List_Dt.Rows[i]["actual_price"]);
                            objDetailList.Out_Estimated_Value = Convert.ToDouble(List_Dt.Rows[i]["actual_value"]);
                            objDetailList.Out_Estimated_PickupDate = List_Dt.Rows[i]["Estimated_PickDate"].ToString();
                            objDetailList.Out_Remarks = List_Dt.Rows[i]["Remarks"].ToString();
                            objDetailList.Out_Status = List_Dt.Rows[i]["status"].ToString();
                            objDetailList.Out_actual_date = List_Dt.Rows[i]["actual_date"].ToString();
                            objDetailList.Out_advance_amt = Convert.ToDouble(List_Dt.Rows[i]["advance_amt"]);
                            objDetailList.Out_approve_date = List_Dt.Rows[i]["approve_date"].ToString();
                            objDetailList.Out_pickup_date = List_Dt.Rows[i]["pickup_date"].ToString();
                            objDetailList.Out_actual_remarks = List_Dt.Rows[i]["actual_remarks"].ToString();
                            objDetailList.Out_approved_remarks = List_Dt.Rows[i]["approved_remarks"].ToString();
                            objDetailList.Out_pickup_remarks = List_Dt.Rows[i]["pickup_remarks"].ToString();

                            objfpoSearchRoot.context.Estimate_List.Add(objDetailList);



                        }

                    }
                }
                objfpoSearchRoot.context.orgnId = objfpoSearch.orgnId;
                objfpoSearchRoot.context.locnId = objfpoSearch.locnId;
                objfpoSearchRoot.context.userId = objfpoSearch.userId;
                objfpoSearchRoot.context.localeId = objfpoSearch.localeId;
                error_msg = (string)cmd.Parameters["IOU_ErroMsg"].Value;

                if (error_msg != "")
                {
                    objfpoSearchRoot.ApplicationException.errorDescription = error_msg;
                }


            }
            catch (Exception ex)
            {
                throw ex;

            }
            return objfpoSearchRoot;
        }

        public PAWHSActualProcurmentSlnoFetchApplication Actual_slno_List(PAWHSActualProcurment_SlnoFetchContext objfpoSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();
            PAWHSActualProcurmentSlnoFetchApplication objfpoSearchRoot = new PAWHSActualProcurmentSlnoFetchApplication();
            DataTable List_Dt = new DataTable();

            objfpoSearchRoot.context = new PAWHSActualProcurment_SlnoFetchContext();
            objfpoSearchRoot.context.SlnoLotDetail = new List<PAWHSActualProcurment_Fetch_SlnoLotDt>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("New_PAWHS_Fetch_Slno_Details", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;
                cmd.Parameters.Add("In_slno", MySqlDbType.VarChar).Value = objfpoSearch.In_slno;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();
                if (ds.Tables.Count > 0)
                {
                    List_Dt = ds.Tables[0];
                    for (int i = 0; i < List_Dt.Rows.Count; i++)
                    {
                        PAWHSActualProcurment_Fetch_SlnoLotDt objSlnoList = new PAWHSActualProcurment_Fetch_SlnoLotDt();
                        objSlnoList.Out_act_rowid = Convert.ToInt32(List_Dt.Rows[i]["Out_act_rowid"]);
                        objSlnoList.Out_lotno = List_Dt.Rows[i]["Out_lotno"].ToString();
                        objSlnoList.Out_farmer_code = List_Dt.Rows[i]["Out_farmer_code"].ToString();
                        objSlnoList.Out_farmer_name = List_Dt.Rows[i]["Out_farmer_name"].ToString();
                        objSlnoList.Out_item_code = List_Dt.Rows[i]["Out_item_code"].ToString();
                        objSlnoList.Out_item_name = List_Dt.Rows[i]["Out_item_name"].ToString();
                        objSlnoList.Out_actual_qty = Convert.ToDouble(List_Dt.Rows[i]["Out_actual_qty"]);
                        objSlnoList.Out_actual_price = Convert.ToDouble(List_Dt.Rows[i]["Out_actual_price"]);
                        objSlnoList.Out_actual_value = Convert.ToDouble(List_Dt.Rows[i]["Out_actual_value"]);
                        objSlnoList.Out_no_of_bags = Convert.ToInt32(List_Dt.Rows[i]["Out_no_of_bags"]);                      

                        objfpoSearchRoot.context.SlnoLotDetail.Add(objSlnoList);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objfpoSearchRoot;
        }
    }
}
