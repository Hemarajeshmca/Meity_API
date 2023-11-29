using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
  public class PAWHS_NEW_BulkTrans_DB
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();

        public string Pawhs_bulk_Estimateprod_Save(Esitmated_Prod objestimate, string orgnId, string locnId, string userId, string localeId, string mysqlcon)
        {
            int ret = 0;
            int QltDtl = 0;
            MysqlCon = new DataConnection(mysqlcon);
            string lotNo = "";
            PAWHS_NEW_BulkTrans_SDocument objrespawhs = new PAWHS_NEW_BulkTrans_SDocument();
            

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
                cmd.Parameters.Add("in_Estm_rowid", MySqlDbType.VarChar).Value = objestimate.in_Estm_rowid;
                cmd.Parameters.Add("in_LotNo", MySqlDbType.VarChar).Value =objestimate.in_LotNo;
                cmd.Parameters.Add("in_Farmer_Code", MySqlDbType.VarChar).Value =objestimate.in_Farmer_Code;
                cmd.Parameters.Add("in_Farmer_Name", MySqlDbType.VarChar).Value =objestimate.in_Farmer_Name;
                cmd.Parameters.Add("in_Member_Type", MySqlDbType.VarChar).Value =objestimate.in_Member_Type;
                cmd.Parameters.Add("in_Item_Code", MySqlDbType.Text).Value =objestimate.in_Item_Code;
                cmd.Parameters.Add("in_Item_Name", MySqlDbType.VarChar).Value =objestimate.in_Item_Name;
                cmd.Parameters.Add("in_Estimated_Qty", MySqlDbType.Decimal).Value =objestimate.in_Estimated_Qty;
                cmd.Parameters.Add("in_Estimated_Price", MySqlDbType.Decimal).Value =objestimate.in_Estimated_Price;
                cmd.Parameters.Add("in_Estimated_Value", MySqlDbType.Decimal).Value =objestimate.in_Estimated_Value;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value =objestimate.in_mode_flag;
                cmd.Parameters.Add("in_Estimated_PickDate", MySqlDbType.Date).Value =objestimate.in_Estimated_PickDate;
                cmd.Parameters.Add("in_Estimated_attach", MySqlDbType.LongText).Value = objestimate.in_Estimated_attach;
                cmd.Parameters.Add("in_variety_status", MySqlDbType.VarChar).Value = objestimate.in_variety_status;
                cmd.Parameters.Add("in_Estimated_Status", MySqlDbType.VarChar).Value = objestimate.in_Estimated_Status;
                cmd.Parameters.Add("in_LRP_Name", MySqlDbType.VarChar).Value = objestimate.in_LRP_Name;
                cmd.Parameters.Add("in_Remarks", MySqlDbType.VarChar).Value =objestimate.in_Remarks;
                cmd.Parameters.Add("in_Created_by", MySqlDbType.VarChar).Value = userId;
                cmd.Parameters.Add("in_modified_by", MySqlDbType.VarChar).Value = userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value =orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value =userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = localeId;
                cmd.Parameters.Add(new MySqlParameter("inout_Estm_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("inout_LotNo1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_errmsg", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                if (ret > 0)
                {
                    mysqltrans.Commit();
                    objresFarmer.context.Header.in_Estm_rowid = (Int32)cmd.Parameters["inout_Estm_rowid1"].Value;
                    objresFarmer.context.Header.in_LotNo = (string)cmd.Parameters["inout_LotNo1"].Value;
                    objresFarmer.context.userId = userId;
                    objresFarmer.context.orgnId = orgnId;
                    objresFarmer.context.locnId = locnId;
                    objresFarmer.context.localeId = localeId;

                    lotNo = (string)cmd.Parameters["inout_LotNo1"].Value;
                }

                if (objresFarmer.context.Header.in_Estm_rowid > 0)
                {
                    if (objestimate.QtyDetail.Count > 0)
                    {
                        QltDtl = SaveEstimate_QltDtl(objestimate, objresFarmer, mysqlcon, MysqlCon);
                        if (QltDtl == 0)
                        {

                            objresFarmer.ApplicationException.errorDescription = "Qty Detail Record Not available";
                            mysqltrans.Rollback();
                           
                        }
                    }
                    mysqltrans.Commit();
                }

                return lotNo;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                throw ex;

            }            
        }
        public int SaveEstimate_QltDtl(Esitmated_Prod Objmodel, pawhs_NewEstimate_Proc_SDocument objfarmer, string MysqlCons, DataConnection MysqlCon)
        {
            int ret = 0;
            DataTable tab = new DataTable();
            PAWHSEstimatedProcurment_Save_QltDetail objFarmersMapped = new PAWHSEstimatedProcurment_Save_QltDetail();
            try
            {
                foreach (var QtyDetails in Objmodel.QtyDetail)
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
                        cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfarmer.context.orgnId;
                        cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfarmer.context.locnId;
                        cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfarmer.context.userId;
                        cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfarmer.context.localeId;
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


        public void Pawhs_bulk_newSaveActualProcurment(Actual_Procurment ObjContext, string orgnId, string locnId, string userId, string localeId, string mysqlcon)
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
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("in_Actual_rowid", MySqlDbType.Int32).Value = ObjContext.in_Actual_rowid;
                cmd.Parameters.Add("in_LotNo", MySqlDbType.VarChar).Value = ObjContext.in_LotNo;
                cmd.Parameters.Add("in_Farmer_Code", MySqlDbType.VarChar).Value = ObjContext.in_Farmer_Code;
                cmd.Parameters.Add("in_Farmer_Name", MySqlDbType.VarChar).Value = ObjContext.in_Farmer_Name;
                cmd.Parameters.Add("in_Member_Type", MySqlDbType.VarChar).Value = ObjContext.in_Member_Type;
                cmd.Parameters.Add("in_Item_Code", MySqlDbType.VarChar).Value = ObjContext.in_Item_Code;
                cmd.Parameters.Add("in_Item_Name", MySqlDbType.VarChar).Value = ObjContext.in_Item_Name;
                cmd.Parameters.Add("in_Actual_Qty", MySqlDbType.Double).Value = ObjContext.in_Actual_Qty;
                cmd.Parameters.Add("in_Actual_Price", MySqlDbType.Double).Value = ObjContext.in_Actual_Price;
                cmd.Parameters.Add("in_Actual_Value", MySqlDbType.Double).Value = ObjContext.in_Actual_Value;
                cmd.Parameters.Add("in_advance_amt", MySqlDbType.Double).Value = ObjContext.in_advance_amt;
                cmd.Parameters.Add("in_no_of_bags", MySqlDbType.Int32).Value = ObjContext.in_no_of_bags;
                cmd.Parameters.Add("in_Status", MySqlDbType.VarChar).Value = ObjContext.in_Status;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = ObjContext.in_mode_flag;
                cmd.Parameters.Add("in_actual_remarks", MySqlDbType.LongText).Value = ObjContext.in_actual_remarks;
                cmd.Parameters.Add("in_approved_remarks", MySqlDbType.LongText).Value = ObjContext.in_approved_remarks;
                cmd.Parameters.Add("in_pickup_remarks", MySqlDbType.LongText).Value = ObjContext.in_pickup_remarks;
                cmd.Parameters.Add("in_actual_attach", MySqlDbType.LongText).Value = ObjContext.in_actual_attach;
                cmd.Parameters.Add("in_vehicle_type", MySqlDbType.VarChar).Value = ObjContext.in_vehicle_type;
                cmd.Parameters.Add("in_vehicle_no", MySqlDbType.VarChar).Value = ObjContext.in_vehicle_no;
                cmd.Parameters.Add("in_destination", MySqlDbType.VarChar).Value = ObjContext.in_destination;
                cmd.Parameters.Add("in_qcperson_name", MySqlDbType.LongText).Value = ObjContext.in_qcperson_name;
                cmd.Parameters.Add("in_LRP_Name", MySqlDbType.VarChar).Value = ObjContext.in_LRP_Name;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = localeId;
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

                   
                    objresFarmer.context.Header.in_Actual_rowid = Convert.ToInt32(IOU_Actual_rowid);
                    objresFarmer.context.Header.in_LotNo = IOU_LotNo;
                    objresFarmer.context.Header.in_Item_Code = IOU_Item_Code;
                    objresFarmer.context.orgnId = orgnId;
                    objresFarmer.context.locnId = locnId;
                    objresFarmer.context.userId = userId;
                    objresFarmer.context.localeId = localeId;
                }
               
                if (objresFarmer.context.Header.in_Actual_rowid > 0)
                {
                    if (ObjContext.QtyDetail.Count > 0)
                    {
                        QtyDtl = SaveQtyDtl(ObjContext, objresFarmer, orgnId, locnId, userId, localeId, mysqlcon, MysqlCon);
                        if (QtyDtl == 0)
                        {

                            objresFarmer.ApplicationException.errorDescription = "Qty Detail Record Not available";
                            mysqltrans.Rollback();

                        }
                    }
                    if (ObjContext.OtherDetail.Count > 0)
                    {
                        OtherDtl = SaveOtherDtl(ObjContext, objresFarmer, orgnId, locnId, userId, localeId, mysqlcon, MysqlCon);
                        if (OtherDtl == 0)
                        {
                            objresFarmer.ApplicationException.errorDescription = "Other Detail Record Not available";
                            mysqltrans.Rollback();

                        }
                    }
                    if (ObjContext.SlnoDetail.Count > 0)
                    {
                        SlnoDtl = SaveSlnoDtl(ObjContext, objresFarmer, orgnId, locnId, userId, localeId, mysqlcon, MysqlCon);
                        if (SlnoDtl == 0)
                        {
                            objresFarmer.ApplicationException.errorDescription = "SlNo Detail Record Not available";
                            mysqltrans.Rollback();

                        }
                    }

                    mysqltrans.Commit();
                }
               
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                throw ex;

            }
        }
        public int SaveQtyDtl(Actual_Procurment Objmodel, PAWHSActualProcurment_Save_Document objfarmer, string orgnId, string locnId, string userId, string localeId, string MysqlCons, DataConnection MysqlCon)
        {
            int ret = 0;
            DataTable tab = new DataTable();
            PAWHSActualProcurment_Save_QtyDetail objFarmersMapped = new PAWHSActualProcurment_Save_QtyDetail();
            try
            {
                NewPawhsActualProc_DB objproduct1 = new NewPawhsActualProc_DB();
                foreach (var QtyDetails in Objmodel.QtyDetail)
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
                    cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = orgnId;
                    cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locnId;
                    cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = userId;
                    cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = localeId;
                    cmd.Parameters.Add(new MySqlParameter("inout_qty_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new MySqlParameter("inout_lotno1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                    ret = cmd.ExecuteNonQuery();

                    if (ret == 0)
                    {
                        break;
                    }
                }
                return ret;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public int SaveOtherDtl(Actual_Procurment Objmodel, PAWHSActualProcurment_Save_Document objfarmer, string orgnId, string locnId, string userId, string localeId, string MysqlCons, DataConnection MysqlCon)
        {
            int ret = 0;
            DataTable tab = new DataTable();
            PAWHSActualProcurment_Save_OtherDetail objFarmersMapped = new PAWHSActualProcurment_Save_OtherDetail();
            try
            {
                NewPawhsActualProc_DB objproduct1 = new NewPawhsActualProc_DB();
                foreach (var OtherDetails in Objmodel.OtherDetail)
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
                    cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = orgnId;
                    cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locnId;
                    cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = userId;
                    cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = localeId;
                    cmd.Parameters.Add(new MySqlParameter("inout_otherdtl_row_id1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new MySqlParameter("inout_lotno1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                    ret = cmd.ExecuteNonQuery();

                    if (ret == 0)
                    {
                        break;
                    }
                }
                return ret;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public int SaveSlnoDtl(Actual_Procurment Objmodel, PAWHSActualProcurment_Save_Document objfarmer, string orgnId, string locnId, string userId, string localeId, string MysqlCons, DataConnection MysqlCon)
        {
            int ret = 0;
            DataTable tab = new DataTable();
            PAWHSActualProcurment_Save_SlnoDetail objFarmersMapped = new PAWHSActualProcurment_Save_SlnoDetail();
            try
            {
                NewPawhsActualProc_DB objproduct1 = new NewPawhsActualProc_DB();
                foreach (var SlnoDetails in Objmodel.SlnoDetail)
                {
                    MySqlCommand cmd = new MySqlCommand("New_PAWHS_iud_procurment_slnodtl", MysqlCon.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("in_slno_row_id", MySqlDbType.Int32).Value = SlnoDetails.In_slno_row_id;
                    cmd.Parameters.Add("in_LotNo", MySqlDbType.VarChar).Value = objfarmer.context.Header.in_LotNo;
                    cmd.Parameters.Add("in_slno", MySqlDbType.VarChar).Value = SlnoDetails.In_slno;
                    cmd.Parameters.Add("in_temp1", MySqlDbType.VarChar).Value = SlnoDetails.In_temp1;
                    cmd.Parameters.Add("in_temp2", MySqlDbType.VarChar).Value = SlnoDetails.In_temp2;
                    cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = SlnoDetails.In_mode_flag;
                    cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = orgnId;
                    cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locnId;
                    cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = userId;
                    cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = localeId;
                    cmd.Parameters.Add(new MySqlParameter("inout_slno_row_id1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new MySqlParameter("inout_lotno1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                    ret = cmd.ExecuteNonQuery();

                    if (ret == 0)
                    {
                        break;
                    }
                }
                return ret;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public string Pawhs_bulk_newSaveNewWareHouseReceipt(pawhs_NewWareHouseReceipt ObjContext, string orgnId, string locnId, string userId, string localeId, string mysqlcon)
        {
            int ret = 0;
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            PAWHS_NewWareHouseReceipt_SDocument objresFarmer = new PAWHS_NewWareHouseReceipt_SDocument();
            objresFarmer.context = new PAWHS_NewWareHouseReceipt_SContext();
            objresFarmer.context.Header = new PAWHS_NewWareHouseReceipt_saveHeader();
            string lotNo = "";
            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                MySqlCommand cmd = new MySqlCommand("New_PAWHS_insupd_whsreceipting", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("in_whs_rowid", MySqlDbType.VarChar).Value = ObjContext.in_whs_rowid;
                cmd.Parameters.Add("in_whs_code", MySqlDbType.VarChar).Value = ObjContext.in_whs_code;
                cmd.Parameters.Add("in_LotNo", MySqlDbType.VarChar).Value = ObjContext.in_LotNo;
                cmd.Parameters.Add("in_Accepted_Qty", MySqlDbType.Decimal).Value = ObjContext.in_Accepted_Qty;
                cmd.Parameters.Add("in_Accepted_date", MySqlDbType.Date).Value = ObjContext.in_Accepted_date;
                cmd.Parameters.Add("in_status", MySqlDbType.VarChar).Value = ObjContext.in_status;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = ObjContext.in_mode_flag;
                cmd.Parameters.Add("in_Remarks", MySqlDbType.VarChar).Value = ObjContext.in_Remarks;
                cmd.Parameters.Add("in_Created_by", MySqlDbType.VarChar).Value = userId;
                cmd.Parameters.Add("in_modified_by", MySqlDbType.VarChar).Value =userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value =locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value =localeId;
                cmd.Parameters.Add(new MySqlParameter("inout_whs_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("inout_whs_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                mysqltrans.Commit();
                
                    lotNo = (string)cmd.Parameters["inout_whs_code1"].Value;
                
                return lotNo;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                throw ex;

            }
           
        }

    }
}

