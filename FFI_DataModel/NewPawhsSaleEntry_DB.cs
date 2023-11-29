using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FFI_Model;
using System.Linq;

namespace FFI_DataModel
{
    public class NewPawhsSaleEntry_DB
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(NewPawhsSaleEntry_DB));
        #region List
        public PAWHSSaleEntryApplication GetSaleEntryList(PAWHSSaleEntryContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            PAWHSSaleEntryApplication ObjFetchAll = new PAWHSSaleEntryApplication();
            ObjFetchAll.context = new PAWHSSaleEntryContext();
            ObjFetchAll.context.List = new List<PAWHSSaleEntryList>();

            logger.Error("call SaleEntryList" + "call New_PAWHS_Fetch_SaleEntry_List(" + "'" + ObjContext.orgnId + "'" + ", " + "'" + ObjContext.locnId + "'" + ", " + "'" + ObjContext.userId + "'" + "," + "'" + ObjContext.localeId + "'" + "," + "'" + ObjContext.FilterBy_Option + "'" + "," + "'" + ObjContext.FilterBy_Code + "'" + "," + "'" + ObjContext.FilterBy_FromValue + "'" + "," + "'" + ObjContext.FilterBy_ToValue + "'" + " )");

            try
            {
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_Fetch_SaleEntry_List", MysqlCon.con);
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
                    PAWHSSaleEntryList objList = new PAWHSSaleEntryList();
                    objList.Out_sale_rowid = Convert.ToInt32(dt.Rows[i]["Out_sale_rowid"]);
                    objList.Out_agg_code = dt.Rows[i]["Out_agg_code"].ToString();
                    objList.Out_agg_name = dt.Rows[i]["Out_agg_name"].ToString();
                    objList.Out_saleno = dt.Rows[i]["Out_saleno"].ToString();
                    objList.Out_buyer_code = dt.Rows[i]["Out_buyer_code"].ToString();
                    objList.Out_buyer_name = dt.Rows[i]["Out_buyer_name"].ToString();
                    objList.Out_item_code = dt.Rows[i]["Out_item_code"].ToString();
                    objList.Out_item_name = dt.Rows[i]["Out_item_name"].ToString();
                    objList.Out_sale_qty = Convert.ToDouble(dt.Rows[i]["Out_sale_qty"]);
                    objList.Out_sale_price = Convert.ToDouble(dt.Rows[i]["Out_sale_price"]);
                    objList.Out_sale_remarks = dt.Rows[i]["Out_sale_remarks"].ToString();
                    objList.Out_status = dt.Rows[i]["Out_status"].ToString();
                    objList.Out_rowtimestamp = dt.Rows[i]["Out_row_timestamp"].ToString();
                    objList.Out_invoice_date = dt.Rows[i]["Out_invoice_date"].ToString();
                    objList.Out_NoOf_bags = Convert.ToDecimal(dt.Rows[i]["Out_NoOf_bags"].ToString());
                    objList.Out_vehicle_type = dt.Rows[i]["Out_vehicle_type"].ToString();
                    objList.Out_vehicle_No = dt.Rows[i]["Out_vehicle_No"].ToString();
                    objList.Out_QC_person = dt.Rows[i]["Out_QC_person"].ToString();
                    objList.Out_Lrp_Name = dt.Rows[i]["Out_Lrp_Name"].ToString();

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
        #endregion
        #region Fetch
        public PAWHS_SaleEntryFetchApplication Single_SaleEntry(PAWHS_SaleEntry_FetchContext objfpoSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();

            PAWHS_SaleEntryFetchApplication objfpoSearchRoot = new PAWHS_SaleEntryFetchApplication();

            DataTable SlnoDt = new DataTable();
            DataTable QlyDt = new DataTable();


            objfpoSearchRoot.context = new PAWHS_SaleEntry_FetchContext();
            objfpoSearchRoot.context.Header = new PAWHS_SaleEntry_FetchHeader();
            objfpoSearchRoot.context.SlnoDetail = new List<PAWHS_SaleEntry_Fetch_SlnoDetail>();
            //objfpoSearchRoot.context.QlyDetail = new List<PAWHS_SaleEntry_Fetch_QlyDetail>();

            MysqlCon = new DataConnection(mysqlcon);
            logger.Error("Call FetchSaleEntry" + " set @In_buyer_code = '0'; set @In_buyer_name = '0'; set @In_item_name = '0'; set @In_sale_qty = 0; set @In_sale_price = 0; set @In_sale_value = 0; set @In_sale_date = '0'; set @In_advance_amt = 0; set @In_pickup_date = '0'; set @In_no_of_bags = 0;set @In_payment_type = '0'; set @In_bank_acc_no = '0'; set @In_cheque_no = '0'; set @In_status = '0'; set @In_sale_remarks = '0'; set @In_sale_attach = '0'; set @In_vehicle_type = '0'; set @In_vehicle_no = '0'; set @In_qcperson_name = '0'; set @In_LRP_Name = '0'; set @In_LRP_Mobile_no = '0'; set @In_whs_code = '0'; set @In_whs_name = '0'; set @IOU_sale_rowid1 = 0; set @IOU_agg_code1 = '0'; set @IOU_sale_no1 = '0'; set @In_crop_variety = '0'; call odisha_pilot.New_PAWHS_Fetch_SaleEntry(" + "'" + objfpoSearch.orgnId + "'" + ", " + "'" + objfpoSearch.locnId + "'" + ", " + "'" + objfpoSearch.userId + "'" + ", " + "'" + objfpoSearch.localeId + "'" + ", " + objfpoSearch.IOU_sale_rowid + ", " + "'" + objfpoSearch.IOU_agg_code + "'" + ", " + "'" + objfpoSearch.IOU_sale_no + "'" + ", @In_buyer_code, @In_buyer_name, @In_item_name, @In_sale_qty, @In_sale_price, @In_sale_value, @In_sale_date, @In_advance_amt, @In_pickup_date, @In_no_of_bags, @In_payment_type, @In_bank_acc_no, @In_cheque_no, @In_status, @In_sale_remarks, @In_sale_attach, @In_vehicle_type, @In_vehicle_no, @In_qcperson_name, @In_LRP_Name, @In_LRP_Mobile_no, @In_whs_code, @In_whs_name, @IOU_sale_rowid1, @IOU_agg_code1, @IOU_sale_no1, @In_crop_variety);select @In_buyer_code, @In_buyer_name, @In_item_name, @In_sale_qty, @In_sale_price, @In_sale_value, @In_sale_date, @In_advance_amt, @In_pickup_date, @In_no_of_bags, @In_payment_type, @In_bank_acc_no, @In_cheque_no, @In_status, @In_sale_remarks, @In_sale_attach, @In_vehicle_type, @In_vehicle_no, @In_qcperson_name, @In_LRP_Name, @In_LRP_Mobile_no, @In_whs_code, @In_whs_name, @IOU_sale_rowid1, @IOU_agg_code1, @IOU_sale_no1, @In_crop_variety;");
            try
            {
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_Fetch_SaleEntry", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;
                cmd.Parameters.Add("IOU_sale_rowid", MySqlDbType.Int32).Value = objfpoSearch.IOU_sale_rowid;
                cmd.Parameters.Add("IOU_agg_code", MySqlDbType.VarChar).Value = objfpoSearch.IOU_agg_code;
                cmd.Parameters.Add("IOU_sale_no", MySqlDbType.VarChar).Value = objfpoSearch.IOU_sale_no;
                cmd.Parameters.Add(new MySqlParameter("In_buyer_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_buyer_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add(new MySqlParameter("In_item_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_item_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_sale_qty", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_sale_price", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_sale_value", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_sale_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_advance_amt", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_pickup_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_no_of_bags", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_payment_type", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_bank_acc_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_cheque_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_sale_remarks", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_sale_attach", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_vehicle_type", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_vehicle_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_qcperson_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_LRP_Name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_LRP_Mobile_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_whs_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_whs_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_sale_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_agg_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_sale_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_crop_variety", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();
                if (ds.Tables.Count > 0)
                {
                    SlnoDt = ds.Tables[0];
                    for (int i = 0; i < SlnoDt.Rows.Count; i++)
                    {
                        PAWHS_SaleEntry_Fetch_SlnoDetail ObjSlnoList = new PAWHS_SaleEntry_Fetch_SlnoDetail();
                        ObjSlnoList.In_slno_row_id = Convert.ToInt32(SlnoDt.Rows[i]["In_slno_row_id"]);
                        ObjSlnoList.In_agg_code = SlnoDt.Rows[i]["In_agg_code"].ToString();
                        ObjSlnoList.In_lotno = SlnoDt.Rows[i]["In_lotno"].ToString();
                        ObjSlnoList.In_slno = SlnoDt.Rows[i]["In_slno"].ToString();
                        ObjSlnoList.In_temp1 = SlnoDt.Rows[i]["In_temp1"].ToString();
                        ObjSlnoList.In_temp2 = SlnoDt.Rows[i]["In_temp2"].ToString();
                        ObjSlnoList.In_qty = SlnoDt.Rows[i]["In_qty"].ToString();
                        ObjSlnoList.In_PO_serialno = SlnoDt.Rows[i]["In_PO_serialno"].ToString();
                        ObjSlnoList.In_PO_lotno = SlnoDt.Rows[i]["In_PO_lotno"].ToString();
                        ObjSlnoList.In_farmername = SlnoDt.Rows[i]["In_farmername"].ToString();
                        QlyDt = ds.Tables[1];

                        List<PAWHS_SaleEntry_Fetch_QlyDetail> objQltyDtls = new List<PAWHS_SaleEntry_Fetch_QlyDetail>();
                        var qltydtls = (from e in QlyDt.AsEnumerable() where e.Field<string>("In_slno") == ObjSlnoList.In_slno select e).ToList();
                        if (qltydtls.Count > 0)
                        {
                            DataTable dt = (from myRow in QlyDt.AsEnumerable() where myRow.Field<string>("In_slno") == ObjSlnoList.In_slno select myRow).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                PAWHS_SaleEntry_Fetch_QlyDetail ObjQlyList = new PAWHS_SaleEntry_Fetch_QlyDetail();
                                ObjQlyList.In_qly_row_id = Convert.ToInt32(dt.Rows[j]["In_qly_row_id"]);
                                ObjQlyList.In_agg_code = dt.Rows[j]["In_agg_code"].ToString();
                                ObjQlyList.In_sale_no = dt.Rows[j]["In_sale_no"].ToString();
                                ObjQlyList.In_slno_rowid = Convert.ToInt32(dt.Rows[j]["In_slno_rowid"]);
                                ObjQlyList.In_slno = dt.Rows[j]["In_slno"].ToString();
                                ObjQlyList.In_item_code = dt.Rows[j]["In_item_code"].ToString();
                                ObjQlyList.In_qly_code = dt.Rows[j]["In_qly_code"].ToString();
                                ObjQlyList.In_actual_value = dt.Rows[j]["In_actual_value"].ToString();
                                ObjQlyList.In_wr_qly_value = Convert.ToDouble(dt.Rows[j]["In_wr_qly_value"]);
                                ObjQlyList.In_estimate_qly_value = Convert.ToDouble(dt.Rows[j]["In_estimate_qly_value"]);
                                objQltyDtls.Add(ObjQlyList);
                            }
                            ObjSlnoList.QlyDetail = objQltyDtls;
                        }
                        objfpoSearchRoot.context.SlnoDetail.Add(ObjSlnoList);
                    }
                    objfpoSearchRoot.context.orgnId = objfpoSearch.orgnId;
                    objfpoSearchRoot.context.locnId = objfpoSearch.locnId;
                    objfpoSearchRoot.context.userId = objfpoSearch.userId;
                    objfpoSearchRoot.context.localeId = objfpoSearch.localeId;
                    objfpoSearchRoot.context.Header.IOU_sale_rowid = (Int32)cmd.Parameters["IOU_sale_rowid1"].Value;
                    objfpoSearchRoot.context.Header.IOU_agg_code = (string)cmd.Parameters["IOU_agg_code1"].Value.ToString();
                    objfpoSearchRoot.context.Header.IOU_sale_no = (string)cmd.Parameters["IOU_sale_no1"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_buyer_code = (string)cmd.Parameters["In_buyer_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_buyer_name = (string)cmd.Parameters["In_buyer_name"].Value.ToString();
                    //objfpoSearchRoot.context.Header.In_item_code = (string)cmd.Parameters["In_item_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_crop_variety = (string)cmd.Parameters["In_crop_variety"].Value.ToString(); //ramya added on 13 jul 21
                    objfpoSearchRoot.context.Header.In_item_name = (string)cmd.Parameters["In_item_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_sale_qty = (double)cmd.Parameters["In_sale_qty"].Value;
                    objfpoSearchRoot.context.Header.In_sale_price = (double)cmd.Parameters["In_sale_price"].Value;
                    objfpoSearchRoot.context.Header.In_sale_value = (double)cmd.Parameters["In_sale_value"].Value;
                    objfpoSearchRoot.context.Header.In_sale_date = (string)cmd.Parameters["In_sale_date"].Value;
                    objfpoSearchRoot.context.Header.In_advance_amt = (double)cmd.Parameters["In_advance_amt"].Value;
                    objfpoSearchRoot.context.Header.In_pickup_date = (string)cmd.Parameters["In_pickup_date"].Value;
                    objfpoSearchRoot.context.Header.In_no_of_bags = (Int32)cmd.Parameters["In_no_of_bags"].Value;
                    objfpoSearchRoot.context.Header.In_payment_type = (string)cmd.Parameters["In_payment_type"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_bank_acc_no = (string)cmd.Parameters["In_bank_acc_no"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_cheque_no = (string)cmd.Parameters["In_cheque_no"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_status = (string)cmd.Parameters["In_status"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_sale_remarks = (string)cmd.Parameters["In_sale_remarks"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_sale_attach = (string)cmd.Parameters["In_sale_attach"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_vehicle_type = (string)cmd.Parameters["In_vehicle_type"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_vehicle_no = (string)cmd.Parameters["In_vehicle_no"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_qcperson_name = (string)cmd.Parameters["In_qcperson_name"].Value;
                    objfpoSearchRoot.context.Header.In_LRP_Name = (string)cmd.Parameters["In_LRP_Name"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_LRP_Mobile_no = (string)cmd.Parameters["In_LRP_Mobile_no"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_whs_code = (string)cmd.Parameters["In_whs_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_whs_name = (string)cmd.Parameters["In_whs_name"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objfpoSearchRoot;
        }
        #endregion
        #region SAVE

        public PAWHSSalesEntry_Save_Document NewSaveSaleEntry(PAWHSSalesEntry_Save_Application ObjContext, string mysqlcon)
        {
            int ret = 0;
            int QtyDtl = 0;
            int SlnoDtl = 0;
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            PAWHSSalesEntry_Save_Document objresFarmer = new PAWHSSalesEntry_Save_Document();
            objresFarmer.ApplicationException = new PAWHSSaleEntryApplicationException();
            objresFarmer.context = new PAWHSSalesEntry_Save_Context();
            objresFarmer.context.Header = new PAWHSSalesEntry_Save_Header();
            objresFarmer.context.SlnoDetail = new List<PAWHSSaleEntry_Save_SlnoDetail>();
            objresFarmer.context.QlyDetail1 = new List<PAWHSSaleEntry_Save_QlyDetail1>();
            int IOU_Sale_rowid = 0;
            string IOU_SaleNo = "";
            string IOU_Item_Code = "";
            string IOU_ErroNo = "";

            logger.Error("Call SaleEntrySave " + "set @IOU_Sale_rowid = 0; set @IOU_SaleNo = '0'; set @IOU_Item_Code = '0'; set @IOU_ErroNo = '0'; call New_PAWHS_insupd_SaleEntry(" + ObjContext.document.context.Header.in_Sale_rowid + ", " + "'" + ObjContext.document.context.Header.in_SaleNo + "'" + ", " + "'" + ObjContext.document.context.Header.In_Buyer_code + "'" + ", " + "'" + ObjContext.document.context.Header.In_Buyer_name + "'" + ", " + "'" + ObjContext.document.context.Header.in_Item_Code + "'" + ", " + "'" + ObjContext.document.context.Header.in_Item_Name + "'" + "," + ObjContext.document.context.Header.in_Sale_Qty + ", " + ObjContext.document.context.Header.in_Sale_Price + "," + ObjContext.document.context.Header.in_Sale_Value + ", " + ObjContext.document.context.Header.in_advance_amt + ", " + ObjContext.document.context.Header.in_no_of_bags + ", " + "'" + ObjContext.document.context.Header.in_Status + "'" + ", " + "'" + ObjContext.document.context.Header.in_mode_flag + "'" + ", " + "'" + ObjContext.document.context.Header.in_sale_remarks + "'" + ", " + "'" + ObjContext.document.context.Header.in_sale_attach + "'" + ", " + "'" + ObjContext.document.context.Header.in_vehicle_type + "'" + ", " + "'" + ObjContext.document.context.Header.in_vehicle_no + "'" + ", " + "'" + ObjContext.document.context.Header.in_qcperson_name + "'" + ", " + "'" + ObjContext.document.context.Header.in_LRP_Name + "'" + ", " + "'" + ObjContext.document.context.Header.In_LRP_Mobile_no + "'" + ", " + "'" + ObjContext.document.context.Header.In_Payment_type + "'" + ", " + "'" + ObjContext.document.context.Header.In_Bank_acc_no + "'" + ", " + "'" + ObjContext.document.context.Header.In_cheque_no + "'" + ", " + "'" + ObjContext.document.context.Header.In_whs_code + "'" + ", " + "'" + ObjContext.document.context.Header.In_whs_name + "'" + ", " + "'" + ObjContext.document.context.Header.In_Saledate + "'" + ", " + "'" + ObjContext.document.context.orgnId + "'" + ", " + "'" + ObjContext.document.context.locnId + "'" + ", " + "'" + ObjContext.document.context.userId + "'" + ", " + "'" + ObjContext.document.context.localeId + "'" + ", @IOU_Sale_rowid, @IOU_SaleNo, @IOU_Item_Code, @IOU_ErroNo); select @IOU_Sale_rowid, @IOU_SaleNo, @IOU_Item_Code, @IOU_ErroNo; ");
            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                MySqlCommand cmd = new MySqlCommand("New_PAWHS_insupd_SaleEntry", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("in_Sale_rowid", MySqlDbType.Int32).Value = ObjContext.document.context.Header.in_Sale_rowid;
                cmd.Parameters.Add("in_SaleNo", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_SaleNo;
                cmd.Parameters.Add("In_Buyer_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_Buyer_code;
                cmd.Parameters.Add("In_Buyer_name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_Buyer_name;
                cmd.Parameters.Add("in_Item_Code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_Item_Code;
                cmd.Parameters.Add("in_Item_Name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_Item_Name;
                cmd.Parameters.Add("in_Sale_Qty", MySqlDbType.Double).Value = ObjContext.document.context.Header.in_Sale_Qty;
                cmd.Parameters.Add("in_Sale_Price", MySqlDbType.Double).Value = ObjContext.document.context.Header.in_Sale_Price;
                cmd.Parameters.Add("in_Sale_Value", MySqlDbType.Double).Value = ObjContext.document.context.Header.in_Sale_Value;
                cmd.Parameters.Add("in_advance_amt", MySqlDbType.Double).Value = ObjContext.document.context.Header.in_advance_amt;
                cmd.Parameters.Add("in_no_of_bags", MySqlDbType.Int32).Value = ObjContext.document.context.Header.in_no_of_bags;
                cmd.Parameters.Add("in_Status", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_Status;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_mode_flag;
                cmd.Parameters.Add("in_sale_remarks", MySqlDbType.LongText).Value = ObjContext.document.context.Header.in_sale_remarks;
                cmd.Parameters.Add("in_sale_attach", MySqlDbType.LongText).Value = ObjContext.document.context.Header.in_sale_attach;
                cmd.Parameters.Add("in_vehicle_type", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_vehicle_type;
                cmd.Parameters.Add("in_vehicle_no", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_vehicle_no;
                cmd.Parameters.Add("in_qcperson_name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_qcperson_name;
                cmd.Parameters.Add("in_LRP_Name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_LRP_Name;
                cmd.Parameters.Add("In_LRP_Mobile_no", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_LRP_Mobile_no;
                cmd.Parameters.Add("In_Payment_type", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_Payment_type;
                cmd.Parameters.Add("In_Bank_acc_no", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_Bank_acc_no;
                cmd.Parameters.Add("In_cheque_no", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_cheque_no;
                cmd.Parameters.Add("In_whs_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_whs_code;
                cmd.Parameters.Add("In_whs_name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_whs_name;
                cmd.Parameters.Add("In_Saledate", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_Saledate;
                cmd.Parameters.Add("In_batch_type", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_batch_type;
                cmd.Parameters.Add("In_buyer_mobileno", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_buyer_mobileno;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("IOU_Sale_rowid", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_SaleNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_Item_Code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_ErroNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                if (ret > 0)
                {
                    IOU_Sale_rowid = (Int32)cmd.Parameters["IOU_Sale_rowid"].Value;
                    IOU_SaleNo = (string)cmd.Parameters["IOU_SaleNo"].Value;
                    IOU_Item_Code = (string)cmd.Parameters["IOU_Item_Code"].Value;
                    IOU_ErroNo = (string)cmd.Parameters["IOU_ErroNo"].Value;
                    logger.Error("Reponse sale Entry" + IOU_Sale_rowid + "," + IOU_SaleNo + "," + IOU_Item_Code + "," + IOU_ErroNo);
                    objresFarmer.context.errorMsg = IOU_ErroNo;
                    if (IOU_ErroNo != "")
                    {
                        mysqltrans.Rollback();
                        objresFarmer.context.errorMsg = IOU_ErroNo;
                        objresFarmer.ApplicationException.errorNumber = IOU_ErroNo;
                        objresFarmer.ApplicationException.errorDescription = IOU_ErroNo;
                        return objresFarmer;
                    }

                    objresFarmer.context.Header.in_Sale_rowid = Convert.ToInt32(IOU_Sale_rowid);
                    objresFarmer.context.Header.in_SaleNo = IOU_SaleNo;
                    objresFarmer.context.Header.in_Item_Code = IOU_Item_Code;
                    objresFarmer.context.orgnId = ObjContext.document.context.orgnId;
                    objresFarmer.context.locnId = ObjContext.document.context.locnId;
                    objresFarmer.context.userId = ObjContext.document.context.userId;
                    objresFarmer.context.localeId = ObjContext.document.context.localeId;
                }
                else
                {
                    IOU_ErroNo = (string)cmd.Parameters["IOU_ErroNo"].Value;

                    if (IOU_ErroNo != "")
                    {
                        objresFarmer.context.errorMsg = IOU_ErroNo;
                        objresFarmer.ApplicationException.errorNumber = IOU_ErroNo;
                        objresFarmer.ApplicationException.errorDescription = IOU_ErroNo;
                    }
                    mysqltrans.Rollback();
                    return objresFarmer;
                }

                if (objresFarmer.context.Header.in_Sale_rowid > 0)
                {

                    if (ObjContext.document.context.SlnoDetail.Count > 0)
                    {
                        SlnoDtl = SaveSlnoDtl(ObjContext, objresFarmer, mysqlcon, MysqlCon);
                        if (SlnoDtl == 0)
                        {
                            objresFarmer.context.errorMsg = "SlNo Detail Record Not available";
                            objresFarmer.ApplicationException.errorDescription = "SlNo Detail Record Not available";
                            mysqltrans.Rollback();
                            return objresFarmer;
                        }
                    }
                    else
                    {
                        if (ObjContext.document.context.QlyDetail1.Count > 0)
                        {
                            PAWHSSaleEntry_Save_SlnoDetail objdtlslno = new PAWHSSaleEntry_Save_SlnoDetail();
                            objdtlslno.QlyDetail = new List<PAWHSSaleEntry_Save_QlyDetail>();
                            objdtlslno.In_slno_row_id = 0;
                            objdtlslno.lotno = objresFarmer.context.Header.in_SaleNo;
                            objdtlslno.In_slno = "NA";
                            objdtlslno.In_temp1 = "NA";
                            objdtlslno.In_temp2 = "NA";
                            objdtlslno.in_qty = "0";
                            objdtlslno.In_mode_flag = "I";
                            foreach (var QlyDetails1 in ObjContext.document.context.QlyDetail1)
                            {
                                PAWHSSaleEntry_Save_QlyDetail objQly = new PAWHSSaleEntry_Save_QlyDetail();
                                objQly.In_qly_dtl_rowid = 0;
                                objQly.In_slno = "NA";
                                objQly.In_qly_code = QlyDetails1.In_qly_code;
                                objQly.In_actual_value = QlyDetails1.In_actual_value;
                                objQly.In_wr_qly_value = QlyDetails1.In_wr_qly_value;
                                objQly.in_estimate_qly_value = QlyDetails1.in_estimate_qly_value;
                                objQly.In_mode_flag = QlyDetails1.In_mode_flag;
                                objdtlslno.QlyDetail.Add(objQly);
                            }
                            ObjContext.document.context.SlnoDetail.Add(objdtlslno);
                            SlnoDtl = SaveSlnoDtl(ObjContext, objresFarmer, mysqlcon, MysqlCon);
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
        public int SaveSlnoDtl(PAWHSSalesEntry_Save_Application Objmodel, PAWHSSalesEntry_Save_Document objfarmer, string MysqlCons, DataConnection MysqlCon)
        {
            int ret = 0;
            int Qlyres = 0;
            DataTable tab = new DataTable();
            PAWHSSaleEntry_Save_SlnoDetail ObjSlnoDtl = new PAWHSSaleEntry_Save_SlnoDetail();
            try
            {


                foreach (var SlnoDetails in Objmodel.document.context.SlnoDetail)
                {
                    if (objfarmer.context.Header.in_SaleNo == SlnoDetails.lotno || SlnoDetails.lotno == null)
                    {
                        logger.Error("set @inout_slno_row_id1 = 0; set @inout_lotno1 = '';call New_PAWHS_iud_procurment_slnodtl(" + SlnoDetails.In_slno_row_id + ", " + "'" + objfarmer.context.Header.in_SaleNo + "'" + ", " + "'" + SlnoDetails.In_slno + "'" + ", " + "'" + SlnoDetails.In_temp2 + "'" + ", " + "'" + SlnoDetails.In_mode_flag + "'" + ", " + "'" + Objmodel.document.context.orgnId + "'" + ", " + "'" + Objmodel.document.context.locnId + "'" + ", " + "'" + Objmodel.document.context.userId + "'" + ", " + "'" + Objmodel.document.context.localeId + "', @inout_qly_rowid1, @inout_lotno1;");

                        MySqlCommand cmd = new MySqlCommand("New_PAWHS_iud_procurment_slnodtl", MysqlCon.con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("in_slno_row_id", MySqlDbType.Int32).Value = SlnoDetails.In_slno_row_id;
                        cmd.Parameters.Add("in_LotNo", MySqlDbType.VarChar).Value = objfarmer.context.Header.in_SaleNo;
                        cmd.Parameters.Add("in_slno", MySqlDbType.VarChar).Value = SlnoDetails.In_slno;
                        cmd.Parameters.Add("in_temp1", MySqlDbType.VarChar).Value = SlnoDetails.In_temp1;
                        cmd.Parameters.Add("in_temp2", MySqlDbType.VarChar).Value = SlnoDetails.In_temp2;
                        cmd.Parameters.Add("in_qty", MySqlDbType.Double).Value =Convert.ToDouble(SlnoDetails.in_qty);
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
                        else
                        {
                            ObjSlnoDtl.IOU_slno_row_id = (Int32)cmd.Parameters["inout_slno_row_id1"].Value;
                            ObjSlnoDtl.IOU_lotno = (string)cmd.Parameters["inout_lotno1"].Value;
                        }

                        if (ObjSlnoDtl.IOU_slno_row_id > 0)
                        {
                            foreach (var QlyDetails in SlnoDetails.QlyDetail)
                            {
                                if (SlnoDetails.In_slno == QlyDetails.In_slno)
                                {
                                    Qlyres = SaveQlyDtl(Objmodel, QlyDetails, objfarmer, ObjSlnoDtl, MysqlCon);
                                    if (Qlyres == 0)
                                    {
                                        ret = 0;
                                        break;
                                    }
                                }
                            }
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
        public int SaveQlyDtl(PAWHSSalesEntry_Save_Application Objmodel, PAWHSSaleEntry_Save_QlyDetail QlyDetails, PAWHSSalesEntry_Save_Document objfarmer, PAWHSSaleEntry_Save_SlnoDetail ObjSlnoDtl, DataConnection MysqlCon)
        {
            int ret = 0;
            DataTable tab = new DataTable();
            PAWHSActualProcurment_Save_QtyDetail objFarmersMapped = new PAWHSActualProcurment_Save_QtyDetail();
            try
            {
                logger.Error("set @inout_qly_rowid1 = 0; set @inout_lotno1 = '0';call New_PAWHS_iud_SaleEntry_qlydtl(" + QlyDetails.In_qly_dtl_rowid + ", " + ObjSlnoDtl.IOU_slno_row_id + ", " + "'" + QlyDetails.In_slno + "'" +
                    objfarmer.context.Header.in_SaleNo + "'" + ", " + "'" + objfarmer.context.Header.in_SaleNo + "'" + ", " + "'" +
                    objfarmer.context.Header.in_Item_Code + "'" + ", " + "'" + QlyDetails.In_qly_code + "'" + ", " + "'" +
                    QlyDetails.In_actual_value + "'" + ", " + "'" + QlyDetails.In_wr_qly_value + "'" + ", " + "'" +
                    QlyDetails.in_estimate_qly_value + "'" + ", " + "'" + QlyDetails.In_mode_flag + "'" + ", " + "'" +
                    Objmodel.document.context.orgnId + "'" + ", " + "'" + Objmodel.document.context.locnId + "'" + ", " + "'" +
                    Objmodel.document.context.userId + "'" + ", " + "'" + Objmodel.document.context.localeId + "', @inout_qly_rowid1, @inout_lotno1;");


                MySqlCommand cmd = new MySqlCommand("New_PAWHS_iud_SaleEntry_qlydtl", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("in_qly_row_id", MySqlDbType.Int32).Value = QlyDetails.In_qly_dtl_rowid;
                cmd.Parameters.Add("In_slno_rowid", MySqlDbType.Int32).Value = ObjSlnoDtl.IOU_slno_row_id;
                cmd.Parameters.Add("In_slno", MySqlDbType.VarChar).Value = QlyDetails.In_slno;
                cmd.Parameters.Add("in_LotNo", MySqlDbType.VarChar).Value = objfarmer.context.Header.in_SaleNo;
                cmd.Parameters.Add("in_item_code", MySqlDbType.VarChar).Value = objfarmer.context.Header.in_Item_Code;
                cmd.Parameters.Add("in_qly_code", MySqlDbType.VarChar).Value = QlyDetails.In_qly_code;
                cmd.Parameters.Add("in_actual_value", MySqlDbType.Double).Value = QlyDetails.In_actual_value;
                cmd.Parameters.Add("in_wr_qly_value", MySqlDbType.Double).Value = QlyDetails.In_wr_qly_value;
                cmd.Parameters.Add("in_estimate_qly_value", MySqlDbType.Double).Value = QlyDetails.in_estimate_qly_value;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = QlyDetails.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("inout_qly_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("inout_lotno1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();

                return ret;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                throw ex;
            }
        }
        #endregion

        #region SaleEntrydub
        public string GetSaleEntrydub(string ObjContext, string saleno, string mysqlcon)
        {
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);
            string error = "";
            logger.Error("call SaleEntrydub" + "call New_PAWHS_SaleEntry_dub(" + "'" + saleno + "'" + "'" + ObjContext + "'" + ", @errormsg; ");

            try
            {
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_SaleEntrydub", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("In_Seial_no", MySqlDbType.VarChar).Value = ObjContext;
                cmd.Parameters.Add("In_sale_no", MySqlDbType.VarChar).Value = saleno;
                cmd.Parameters.Add(new MySqlParameter("errormsg", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                error = (string)cmd.Parameters["errormsg"].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return error;
        }
        #endregion

        #region PurchaseEntrydub
        public string GetPurchaseEntrydub(string ObjContext, string purchaseno, string mysqlcon)
        {
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);
            string error = "";
            logger.Error("call SaleEntrydub" + "call New_PAWHS_PurchaseEntrydub(" + "'" + purchaseno + "'" + "'" + ObjContext + "'" + ", @errormsg; ");

            try
            {
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_PurchaseEntrydub", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("In_Seial_no", MySqlDbType.VarChar).Value = ObjContext;
                cmd.Parameters.Add("In_purchase_no", MySqlDbType.VarChar).Value = purchaseno;
                cmd.Parameters.Add(new MySqlParameter("errormsg", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                error = (string)cmd.Parameters["errormsg"].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return error;
        }
        #endregion

        #region sale qty
        public PAWHSsaleqtyContext Pawhs_sale_qty_db(PAWHSsaleqtyContext objfpoSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();

            PAWHSsaleqtyContext objfpoSearchRoot = new PAWHSsaleqtyContext();

            DataTable SlnoDt = new DataTable();

            objfpoSearchRoot.List = new List<PAWHSsaleqty>();
           
            MysqlCon = new DataConnection(mysqlcon);
           try
            {
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_Fetch_SaleEntry_qty", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("fpo_code", MySqlDbType.VarChar).Value = objfpoSearch.fpocode;
                cmd.Parameters.Add("agg_code", MySqlDbType.VarChar).Value = objfpoSearch.aggcode;                          
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();
                if (ds.Tables.Count > 0)
                {
                    SlnoDt = ds.Tables[0];
                    for (int i = 0; i < SlnoDt.Rows.Count; i++)
                    {
                        PAWHSsaleqty ObjSlnoList = new PAWHSsaleqty();
                        ObjSlnoList.serial_rowid = Convert.ToInt32(SlnoDt.Rows[i]["serial_rowid"]);
                        ObjSlnoList.lotno = SlnoDt.Rows[i]["lotno"].ToString();
                        ObjSlnoList.serial_qty = SlnoDt.Rows[i]["serial_qty"].ToString();
                        ObjSlnoList.serial_no = SlnoDt.Rows[i]["serial_no"].ToString();
                        ObjSlnoList.product_code = SlnoDt.Rows[i]["product_code"].ToString();
                        objfpoSearchRoot.List.Add(ObjSlnoList);
                    }                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objfpoSearchRoot;
        }
        #endregion
    }
}
