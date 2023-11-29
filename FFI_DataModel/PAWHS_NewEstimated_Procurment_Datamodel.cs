using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FFI_Model;

namespace FFI_DataModel
{
    public class PAWHS_NewEstimated_Procurment_Datamodel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        public pawhs_NewEstimate_Proc_ALL_Application pawhs_NewEstimated_Procurment_List(pawhs_NewEstimate_Proc_ALL_Context ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            pawhs_NewEstimate_Proc_ALL_Application ObjFetchAll = new pawhs_NewEstimate_Proc_ALL_Application();
            ObjFetchAll.context = new pawhs_NewEstimate_Proc_ALL_Context();
            ObjFetchAll.context.List = new List<pawhs_NewEstimate_Proc_ALL_List>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_Fetch_Estimated_Procurment_List", MysqlCon.con);
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
                    pawhs_NewEstimate_Proc_ALL_List objList = new pawhs_NewEstimate_Proc_ALL_List();
                    objList.Out_Estm_rowid = Convert.ToInt32(dt.Rows[i]["Out_Estm_rowid"]);
                    objList.Out_Agg_code = dt.Rows[i]["Out_agg_code"].ToString();
                    objList.Out_LotNo = dt.Rows[i]["Out_LotNo"].ToString();
                    objList.Out_Farmer_Code = dt.Rows[i]["Out_Farmer_Code"].ToString();
                    objList.Out_Farmer_Name = dt.Rows[i]["Out_Farmer_Name"].ToString();
                    objList.Out_Member_Type = dt.Rows[i]["Out_Member_Type"].ToString();
                    objList.Out_Item_Code = dt.Rows[i]["Out_Item_Code"].ToString();
                    objList.Out_Item_Name = dt.Rows[i]["Out_Item_Name"].ToString();
                    objList.Out_Estimated_Qty = dt.Rows[i]["Out_Estimated_Qty"].ToString();
                    objList.Out_Estimated_Price = dt.Rows[i]["Out_Estimated_Price"].ToString();
                    objList.Out_Estimated_Value = dt.Rows[i]["Out_Estimated_Value"].ToString();
                    objList.Out_Estimated_PickDate = dt.Rows[i]["Out_Estimated_PickDate"].ToString();
                    objList.Out_Remarks = dt.Rows[i]["Out_Remarks"].ToString();
                    objList.Out_Agg_name = dt.Rows[i]["Out_Agg_name"].ToString();
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

        public pawhs_NewEstimate_Proc_single_Application Single_pawhs_NewEstimate_Proc(pawhs_NewEstimate_Proc_single_Context objfpoSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable Qltdt = new DataTable();

            pawhs_NewEstimate_Proc_single_Application objfpoSearchRoot = new pawhs_NewEstimate_Proc_single_Application();
            PAWHS_NewEstimated_Procurment_Datamodel objDataModel = new PAWHS_NewEstimated_Procurment_Datamodel();

            DataTable Map = new DataTable();


            objfpoSearchRoot.context = new pawhs_NewEstimate_Proc_single_Context();
            objfpoSearchRoot.context.Header = new pawhs_NewEstimate_Proc_single_Header();
            objfpoSearchRoot.context.QualityDt = new List<pawhs_NewEstimate_Proc_Single_Quality>();


            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("New_PAWHS_Fetch_Estimated_Procurment", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;
                cmd.Parameters.Add("in_Estm_rowid", MySqlDbType.Int32).Value = objfpoSearch.in_Estm_rowid;
                cmd.Parameters.Add("in_LotNo", MySqlDbType.VarChar).Value = objfpoSearch.in_LotNo;
                cmd.Parameters.Add(new MySqlParameter("in_Agg_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_Agg_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_Farmer_Code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_Farmer_Name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_Member_Type", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_Item_Code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_Item_Name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_Estimated_Qty", MySqlDbType.Decimal)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_Estimated_Price", MySqlDbType.Decimal)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_Estimated_Value", MySqlDbType.Decimal)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_Estimated_PickDate", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_Estimated_attach", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_variety_status", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_Estimated_Status", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_LRP_Name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_LRP_Mobile_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_Remarks", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();
                if (ds.Tables.Count > 0)
                {
                    Qltdt = ds.Tables[0];
                    for (int i = 0; i < Qltdt.Rows.Count; i++)
                    {
                        pawhs_NewEstimate_Proc_Single_Quality objDetailList = new pawhs_NewEstimate_Proc_Single_Quality();
                        objDetailList.Out_qty_row_id = Convert.ToInt32(Qltdt.Rows[i]["Out_qty_row_id"]);
                        objDetailList.Out_agg_code = Qltdt.Rows[i]["Out_agg_code"].ToString();
                        objDetailList.Out_lotno = Qltdt.Rows[i]["Out_lotno"].ToString();
                        objDetailList.Out_qlt_code = Qltdt.Rows[i]["Out_qlt_code"].ToString();
                        objDetailList.Out_Qlt_name = Qltdt.Rows[i]["Out_Qlt_name"].ToString();
                        objDetailList.Out_Qlt_value = Qltdt.Rows[i]["Out_Qlt_value"].ToString();
                        objfpoSearchRoot.context.QualityDt.Add(objDetailList);
                    }
                }

                objfpoSearchRoot.context.orgnId = objfpoSearch.orgnId;
                objfpoSearchRoot.context.locnId = objfpoSearch.locnId;
                objfpoSearchRoot.context.userId = objfpoSearch.userId;
                objfpoSearchRoot.context.localeId = objfpoSearch.localeId;
                objfpoSearchRoot.context.in_Estm_rowid = (Int32)cmd.Parameters["in_Estm_rowid"].Value;
                objfpoSearchRoot.context.in_LotNo = (string)cmd.Parameters["in_LotNo"].Value.ToString();
                objfpoSearchRoot.context.Header.in_Agg_code = (string)cmd.Parameters["in_Agg_code"].Value.ToString();
                objfpoSearchRoot.context.Header.in_Agg_name = (string)cmd.Parameters["in_Agg_name"].Value.ToString();
                objfpoSearchRoot.context.Header.in_Estm_rowid = (Int32)cmd.Parameters["in_Estm_rowid"].Value;
                objfpoSearchRoot.context.Header.in_LotNo = (string)cmd.Parameters["in_LotNo"].Value.ToString();
                objfpoSearchRoot.context.Header.in_Farmer_Code = (string)cmd.Parameters["in_Farmer_Code"].Value.ToString();
                objfpoSearchRoot.context.Header.in_Farmer_Name = (string)cmd.Parameters["in_Farmer_Name"].Value.ToString();
                objfpoSearchRoot.context.Header.in_Member_Type = (string)cmd.Parameters["in_Member_Type"].Value.ToString();
                objfpoSearchRoot.context.Header.in_Item_Code = (string)cmd.Parameters["in_Item_Code"].Value.ToString();
                objfpoSearchRoot.context.Header.in_Item_Name = (string)cmd.Parameters["in_Item_Name"].Value.ToString();
                objfpoSearchRoot.context.Header.in_Estimated_Qty = (decimal)cmd.Parameters["in_Estimated_Qty"].Value;
                objfpoSearchRoot.context.Header.in_Estimated_Price = (decimal)cmd.Parameters["in_Estimated_Price"].Value;
                objfpoSearchRoot.context.Header.in_Estimated_Value = (decimal)cmd.Parameters["in_Estimated_Value"].Value;
                objfpoSearchRoot.context.Header.in_Estimated_PickDate = Convert.ToDateTime(cmd.Parameters["in_Estimated_PickDate"].Value).ToString("dd-MM-yyyy");
                objfpoSearchRoot.context.Header.in_Estimated_attach = (string)cmd.Parameters["in_Estimated_attach"].Value.ToString();
                objfpoSearchRoot.context.Header.in_variety_status = (string)cmd.Parameters["in_variety_status"].Value.ToString();
                objfpoSearchRoot.context.Header.in_Estimated_Status = (string)cmd.Parameters["in_Estimated_Status"].Value.ToString();
                objfpoSearchRoot.context.Header.in_LRP_Name = (string)cmd.Parameters["in_LRP_Name"].Value.ToString();
                objfpoSearchRoot.context.Header.in_LRP_Mobile_no = (string)cmd.Parameters["in_LRP_Mobile_no"].Value.ToString();
                objfpoSearchRoot.context.Header.in_Remarks = (string)cmd.Parameters["in_Remarks"].Value.ToString();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objfpoSearchRoot;
        }

        public pawhs_NewEstimate_Proc_SDocument save_pawhs_NewEstimate_Procurement(pawhs_NewEstimate_Proc_SApplication ObjContext, string mysqlcon)
        {
            int ret = 0;
            int QltDtl = 0;
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            pawhs_NewEstimate_Proc_SDocument objresFarmer = new pawhs_NewEstimate_Proc_SDocument();
            objresFarmer.ApplicationException = new PAWHSEstimateProcurmentApplicationException();
            objresFarmer.context = new pawhs_NewEstimate_Proc_SContext();
            objresFarmer.context.Header = new pawhs_NewEstimate_Proc_saveHeader();
            objresFarmer.context.QtyDetail = new List<PAWHSEstimatedProcurment_Save_QltDetail>();


            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                MySqlCommand cmd = new MySqlCommand("New_PAWHS_insupd_Estimated_Procurment", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("in_Estm_rowid", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_Estm_rowid;
                cmd.Parameters.Add("in_LotNo", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_LotNo;
                cmd.Parameters.Add("in_Farmer_Code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_Farmer_Code;
                cmd.Parameters.Add("in_Farmer_Name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_Farmer_Name;
                cmd.Parameters.Add("in_Member_Type", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_Member_Type;
                cmd.Parameters.Add("in_Item_Code", MySqlDbType.Text).Value = ObjContext.document.context.Header.in_Item_Code;
                cmd.Parameters.Add("in_Item_Name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_Item_Name;
                cmd.Parameters.Add("in_Estimated_Qty", MySqlDbType.Decimal).Value = ObjContext.document.context.Header.in_Estimated_Qty;
                cmd.Parameters.Add("in_Estimated_Price", MySqlDbType.Decimal).Value = ObjContext.document.context.Header.in_Estimated_Price;
                cmd.Parameters.Add("in_Estimated_Value", MySqlDbType.Decimal).Value = ObjContext.document.context.Header.in_Estimated_Value;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_mode_flag;
                cmd.Parameters.Add("in_Estimated_PickDate", MySqlDbType.Date).Value = ObjContext.document.context.Header.in_Estimated_PickDate;
                cmd.Parameters.Add("in_Estimated_attach", MySqlDbType.LongText).Value = ObjContext.document.context.Header.in_Estimated_attach;
                cmd.Parameters.Add("in_variety_status", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_variety_status;
                cmd.Parameters.Add("in_Estimated_Status", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_Estimated_Status;
                cmd.Parameters.Add("in_LRP_Name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_LRP_Name;
                cmd.Parameters.Add("in_LRP_Mobile_no", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_LRP_Mobile_no;
                cmd.Parameters.Add("in_status", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_status;
                cmd.Parameters.Add("in_Remarks", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_Remarks;
                cmd.Parameters.Add("in_Created_by", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("in_modified_by", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("inout_Estm_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("inout_LotNo1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_errmsg", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                if (ret > 0)
                {
                    //mysqltrans.Commit();                     
                    objresFarmer = ObjContext.document;
                    objresFarmer.context.Header.in_Estm_rowid = (Int32)cmd.Parameters["inout_Estm_rowid1"].Value;
                    objresFarmer.context.Header.in_LotNo = (string)cmd.Parameters["inout_LotNo1"].Value;
                    // objresFarmer.ApplicationException.errorDescription = (string)cmd.Parameters["out_errmsg"].Value;
                }
                else
                {
                    objresFarmer.ApplicationException.errorDescription = (string)cmd.Parameters["out_errmsg"].Value;
                    mysqltrans.Rollback();
                    return objresFarmer;
                }

                if (objresFarmer.context.Header.in_Estm_rowid > 0)
                {
                    if (ObjContext.document.context.QtyDetail.Count > 0)
                    {
                        QltDtl = SaveQtyDtl(ObjContext, objresFarmer, mysqlcon, MysqlCon);
                        if (QltDtl == 0)
                        {

                            objresFarmer.ApplicationException.errorDescription = "Qty Detail Record Not available";
                            mysqltrans.Rollback();
                            return objresFarmer;
                        }
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
        public int SaveQtyDtl(pawhs_NewEstimate_Proc_SApplication Objmodel, pawhs_NewEstimate_Proc_SDocument objfarmer, string MysqlCons, DataConnection MysqlCon)
        {
            int ret = 0;
            DataTable tab = new DataTable();
            PAWHSEstimatedProcurment_Save_QltDetail objFarmersMapped = new PAWHSEstimatedProcurment_Save_QltDetail();
            try
            {
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
    }
}


