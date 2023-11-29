using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FFI_Model;
using MySqlX.XDevAPI.Common;
using static FFI_Model.ICDStockInwardModel;
using System.Reflection;

namespace FFI_DataModel
{
    public class ICDStockInward_DataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDStockInward_DataModel)); //Declaring Log4Net. 
        string methodName = MethodBase.GetCurrentMethod().Name;
        string In_grn_no1 = "";
        Int32 In_InwardDtl_row_gid = 0;

        public ICDStockRootObject GetAllStockList(ICDStockContext objstock, string mysqlcon)
        {

            int ret = 0;

            //DataConnection con = new DataConnection(mysqlcon);
            //MysqlCon = new DataConnection(mysqlcon);
            //ICDStockDocument objresICDStock = new ICDStockDocument();
            //objresICDStock.context = new ICDStockContext();
            //// objresFarmer.context.Header = new SFarmerHeaderSegment();
            //objresICDStock.ApplicationException = new ICDStockApplicationException();

            //string errorNo = "";

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            ICDStockRootObject ObjstockRoot = new ICDStockRootObject();
            ICDStockInward_DataModel objDataModel = new ICDStockInward_DataModel();

            ObjstockRoot.context = new ICDStockContext();
            ObjstockRoot.context.List = new List<ICDSTList>();



            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("fetch_stockInward_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objstock.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objstock.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objstock.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objstock.localeId;
                cmd.Parameters.Add("In_filterby_option", MySqlDbType.VarChar).Value = objstock.FilterBy_Option;
                cmd.Parameters.Add("In_filterby_code", MySqlDbType.VarChar).Value = objstock.FilterBy_Code;
                cmd.Parameters.Add("In_filterby_fromvalue", MySqlDbType.VarChar).Value = objstock.FilterBy_FromValue;
                cmd.Parameters.Add("In_filterby_tovalue", MySqlDbType.VarChar).Value = objstock.FilterBy_ToValue;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                dt = ds.Tables[1];
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ICDSTList objList = new ICDSTList();
                    objList.Out_inward_rowid = Convert.ToInt32(dt.Rows[i]["Out_inward_rowid"]);
                    objList.Out_ic_code = dt.Rows[i]["Out_ic_code"].ToString();
                    objList.Out_ic_name = dt.Rows[i]["Out_ic_name"].ToString();
                    objList.Out_grn_no = dt.Rows[i]["Out_grn_no"].ToString();
                    objList.Out_grn_date = dt.Rows[i]["Out_grn_date"].ToString();
                    objList.Out_supplier_name = dt.Rows[i]["Out_supplier_name"].ToString();
                    objList.Out_supplier_location = dt.Rows[i]["Out_supplier_location"].ToString();
                    objList.Out_from_state = dt.Rows[i]["Out_from_state"].ToString();
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    ObjstockRoot.context.List.Add(objList);
                }
                ObjstockRoot.context.orgnId = objstock.orgnId;
                ObjstockRoot.context.locnId = objstock.locnId;
                ObjstockRoot.context.localeId = objstock.localeId;
                ObjstockRoot.context.userId = objstock.userId;
                ObjstockRoot.context.FilterBy_Code = objstock.FilterBy_Code;
                ObjstockRoot.context.FilterBy_FromValue = objstock.FilterBy_FromValue;
                ObjstockRoot.context.FilterBy_Option = objstock.FilterBy_Option;
                ObjstockRoot.context.FilterBy_ToValue = objstock.FilterBy_ToValue;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objstock.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //  throw ex;
            }
            return ObjstockRoot;
        }

        public SICDStockRootObject SingleICDStockList(SICDStockContext objstock, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable Header = new DataTable();
            DataTable Detail = new DataTable();
            DataTable Slno = new DataTable();
            DataTable Discount = new DataTable();
            DataTable dtOtherInputs = new DataTable();
            SICDStockRootObject ObjstockRoot = new SICDStockRootObject();
            ICDStockInward_DataModel objDataModel = new ICDStockInward_DataModel();
            List<ICDStockFetchDetail> ObjDetail = new List<ICDStockFetchDetail>();
            ObjstockRoot.context = new SICDStockContext();
            ObjstockRoot.context.Header = new ICDStockFetchHeader();
            ObjstockRoot.context.Detail = new List<ICDStockFetchDetail>();
            ObjstockRoot.context.Slno = new List<ICDStockFetchDetailSlno>(); 
            List<ICDINFetchDetailOtherCost> ObjOtherCostInfo = new List<ICDINFetchDetailOtherCost>();
            List<ICDINFetchOtherInputs> lstOtherInputs = new List<ICDINFetchOtherInputs>();


            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("ICDMOB_fetch_stockInward", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objstock.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objstock.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objstock.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objstock.localeId;
                cmd.Parameters.Add("IOU_inward_rowid", MySqlDbType.VarChar).Value = objstock.inward_rowid;
                cmd.Parameters.Add(new MySqlParameter("In_orgn_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_ic_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_ic_desc", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_inward_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_inward_desc", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_grn_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_grn_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_supplier_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_supplier_location", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_from_state", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_Remarks", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_process_status", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_bill_image", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_transport_amount", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_others", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_loading_unloading_cost", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_local_transport_cost", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_local_loading_unloading_cost", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_roundoff", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_inward_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                da.Fill(ds);
                MysqlCon.con.Close();
                ObjstockRoot.context.Header.IOU_inward_rowid = (int)cmd.Parameters["IOU_inward_rowid1"].Value;
                ObjstockRoot.context.Header.In_orgn_code = (string)cmd.Parameters["In_orgn_code"].Value;
                ObjstockRoot.context.Header.In_ic_code = (string)cmd.Parameters["In_ic_code"].Value;
                ObjstockRoot.context.Header.In_ic_desc = (string)cmd.Parameters["In_ic_desc"].Value;
                ObjstockRoot.context.Header.In_inward_code = (string)cmd.Parameters["In_inward_code"].Value;
                ObjstockRoot.context.Header.In_inward_desc = (string)cmd.Parameters["In_inward_desc"].Value;
                ObjstockRoot.context.Header.In_grn_no = (string)cmd.Parameters["In_grn_no"].Value;
                ObjstockRoot.context.Header.In_grn_date = (string)cmd.Parameters["In_grn_date"].Value;
                ObjstockRoot.context.Header.In_supplier_name = (string)cmd.Parameters["In_supplier_name"].Value;
                ObjstockRoot.context.Header.In_supplier_location = (string)cmd.Parameters["In_supplier_location"].Value;
                ObjstockRoot.context.Header.In_from_state = (string)cmd.Parameters["In_from_state"].Value;
                ObjstockRoot.context.Header.In_Remarks = (string)cmd.Parameters["In_Remarks"].Value;
                ObjstockRoot.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value;
                ObjstockRoot.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value;
                ObjstockRoot.context.Header.In_process_status = (string)cmd.Parameters["In_process_status"].Value;
                ObjstockRoot.context.Header.In_bill_image = (string)cmd.Parameters["In_bill_image"].Value;
                ObjstockRoot.context.Header.In_transport_amount = (Int32)cmd.Parameters["In_transport_amount"].Value;
                ObjstockRoot.context.Header.In_others = (Int32)cmd.Parameters["In_others"].Value;
                ObjstockRoot.context.Header.In_loading_unloading_cost = (Int32)cmd.Parameters["In_loading_unloading_cost"].Value;
                ObjstockRoot.context.Header.In_local_transport_cost = (Int32)cmd.Parameters["In_local_transport_cost"].Value;
                ObjstockRoot.context.Header.In_local_loading_unloading_cost = (Int32)cmd.Parameters["In_local_loading_unloading_cost"].Value;
                ObjstockRoot.context.Header.In_roundoff = (Double)cmd.Parameters["In_roundoff"].Value;
                if (ds.Tables.Count > 0)
                {
                    Detail = ds.Tables[0];
                    for (int i = 0; i < Detail.Rows.Count; i++)
                    {
                        ICDStockFetchDetail objDList = new ICDStockFetchDetail();
                        objDList.In_inwarddtl_rowid = Convert.ToInt32(Detail.Rows[i]["In_inwarddtl_rowid"]);
                        objDList.In_inward_code = Detail.Rows[i]["In_inward_code"].ToString();
                        objDList.In_inward_desc = Detail.Rows[i]["In_inward_desc"].ToString();
                        objDList.In_grn_no = Detail.Rows[i]["In_grn_no"].ToString();
                        objDList.In_product_catg_code = Detail.Rows[i]["In_product_catg_code"].ToString();
                        objDList.In_product_catg_desc = Detail.Rows[i]["In_product_catg_desc"].ToString();
                        objDList.In_product_subcatg_code = Detail.Rows[i]["In_product_subcatg_code"].ToString();
                        objDList.In_product_subcatg_desc = Detail.Rows[i]["In_product_subcatg_desc"].ToString();
                        objDList.In_product_code = Detail.Rows[i]["In_product_code"].ToString();
                        objDList.In_product_desc = Detail.Rows[i]["In_product_desc"].ToString();
                        objDList.In_uomtype_code = Detail.Rows[i]["In_uomtype_code"].ToString();
                        objDList.In_uomtype_desc = Detail.Rows[i]["In_uomtype_desc"].ToString();
                        objDList.In_batch_no = Detail.Rows[i]["In_batch_no"].ToString();
                        objDList.In_received_qty = Convert.ToDouble(Detail.Rows[i]["In_received_qty"]);
                        objDList.In_product_amount = Convert.ToDouble(Detail.Rows[i]["In_product_amount"]);
                        objDList.In_tax_amount = Convert.ToDouble(Detail.Rows[i]["In_tax_amount"]);
                        objDList.In_transport_amount = Convert.ToDouble(Detail.Rows[i]["In_transport_amount"]);
                        objDList.In_net_amount = Convert.ToDouble(Detail.Rows[i]["In_net_amount"]);
                        objDList.In_discount = Convert.ToDouble(Detail.Rows[i]["In_discount"]);
                        objDList.In_cgst_rate = Convert.ToDouble(Detail.Rows[i]["In_cgst_rate"]);
                        objDList.In_sgst_rate = Convert.ToDouble(Detail.Rows[i]["In_sgst_rate"]);
                        objDList.In_igst_rate = Convert.ToDouble(Detail.Rows[i]["In_igst_rate"]);
                        objDList.In_ugst_rate = Convert.ToDouble(Detail.Rows[i]["In_ugst_rate"]);
                        objDList.In_tax_rate = Convert.ToDouble(Detail.Rows[i]["In_tax_rate"]);
                        objDList.In_hsn_code = Detail.Rows[i]["In_hsn_code"].ToString();
                        objDList.In_hsn_desc = Detail.Rows[i]["In_hsn_desc"].ToString();
                        objDList.In_status_code = Detail.Rows[i]["In_status_code"].ToString();
                        objDList.In_status_desc = Detail.Rows[i]["In_status_desc"].ToString();
                        objDList.In_mode_flag = Detail.Rows[i]["In_mode_flag"].ToString();
                        ObjstockRoot.context.Detail.Add(objDList);
                    }
                }
                ObjstockRoot.context.orgnId = objstock.orgnId;
                ObjstockRoot.context.locnId = objstock.locnId;
                ObjstockRoot.context.localeId = objstock.localeId;
                ObjstockRoot.context.userId = objstock.userId;
                if (ds.Tables.Count > 0)
                {
                    Slno = ds.Tables[1];
                    for (int i = 0; i < Slno.Rows.Count; i++)
                    {
                        ICDStockFetchDetailSlno objDList = new ICDStockFetchDetailSlno();
                        objDList.In_inwardslno_rowid = Convert.ToInt32(Slno.Rows[i]["In_inwardslno_rowid"]);
                        objDList.In_inwarddtl_rowid = Convert.ToInt32(Slno.Rows[i]["In_inwarddtl_rowid"]);
                        objDList.In_slno = Slno.Rows[i]["In_slno"].ToString();
                        objDList.In_no_of_bags = Slno.Rows[i]["In_no_of_bags"].ToString();
                        objDList.In_grn_no = Slno.Rows[i]["In_grn_no"].ToString();
                        objDList.In_product_code = Slno.Rows[i]["In_product_code"].ToString();
                        objDList.In_product_catg_code = Slno.Rows[i]["In_product_catg_code"].ToString();
                        objDList.In_product_subcatg_code = Slno.Rows[i]["In_product_subcatg_code"].ToString();
                        ObjstockRoot.context.Slno.Add(objDList);
                    }
                }

                if (ds.Tables.Count > 1)
                {
                    Discount = ds.Tables[2]; 
                    for (int j = 0; j < Discount.Rows.Count; j++)
                    { 
                            ICDINFetchDetailOtherCost objDiscList = new ICDINFetchDetailOtherCost();
                            objDiscList.In_inwardOtherCost_rowid = Discount.Rows[j]["inwardOtherCost_rowid"].ToString();
                            objDiscList.In_inwarddtl_rowid = Convert.ToInt32(Discount.Rows[j]["inwarddtl_rowid"]);
                            objDiscList.In_product_code = Discount.Rows[j]["product_code"].ToString();
                            objDiscList.In_OtherCostCode = Discount.Rows[j]["OtherCostCode"].ToString();
                            objDiscList.In_OtherCostType = Discount.Rows[j]["OtherCostType"].ToString();
                            objDiscList.In_OtherCostOn = Discount.Rows[j]["OtherCostOn"].ToString();
                            objDiscList.In_OtherCostAmount = Discount.Rows[j]["OtherCostAmount"].ToString();
                            objDiscList.In_mode_flag = Discount.Rows[j]["In_mode_flag"].ToString();
                            ObjOtherCostInfo.Add(objDiscList);
                         
                    }

                    ObjstockRoot.context.OtherCostInfo = ObjOtherCostInfo; 
                }
                if (ds.Tables.Count > 2)
                {
                    dtOtherInputs = ds.Tables[3];
                    for (int j = 0; j < dtOtherInputs.Rows.Count; j++)
                    {
                        ICDINFetchOtherInputs objOthInList = new ICDINFetchOtherInputs();
                        objOthInList.In_inwardOtherinput_rowid = dtOtherInputs.Rows[j]["inwardOtherInput_rowid"].ToString();
                        objOthInList.In_inwarddtl_rowid = Convert.ToInt32(dtOtherInputs.Rows[j]["inwarddtl_rowid"]);
                        objOthInList.In_product_code = dtOtherInputs.Rows[j]["product_code"].ToString();
                        objOthInList.In_NoOfLoosePack = Convert.ToInt32(dtOtherInputs.Rows[j]["NoOfLoosePack"].ToString());
                        objOthInList.In_CartonVolume = Convert.ToInt32(dtOtherInputs.Rows[j]["CartonVolume"].ToString());
                        objOthInList.In_Type = dtOtherInputs.Rows[j]["Typedesc"].ToString();
                        objOthInList.In_ManufactureDate = dtOtherInputs.Rows[j]["ManufactureDate"].ToString();
                        objOthInList.In_ExpDate = dtOtherInputs.Rows[j]["ExpDate"].ToString();
                        objOthInList.In_Mrp = Convert.ToDecimal(dtOtherInputs.Rows[j]["MRP"].ToString());
                        lstOtherInputs.Add(objOthInList);

                    }

                    ObjstockRoot.context.OtherInputs = lstOtherInputs;
                }
                //ObjstockRoot.context = ObjDetail;
                ObjstockRoot.context.orgnId = objstock.orgnId;
                ObjstockRoot.context.locnId = objstock.locnId;
                ObjstockRoot.context.localeId = objstock.localeId;
                ObjstockRoot.context.userId = objstock.userId;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objstock.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }
            return ObjstockRoot;
        }

        public IUStockDocument SaveICDStock(IUStockApplication ObjICDStock, string mysqlcon)
        {
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            IUStockDocument objresICDStock = new IUStockDocument();
            objresICDStock.context = new IUStocksaveContext();
            objresICDStock.context.Header = new ICDStocksaveHeader();
            try
            {
                int ret = 0;
                int IOU_inward_rowid1 = 0;
                //string In_grn_no1 = "";
                string errorNo = "";

                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }
                MySqlCommand cmd = new MySqlCommand("ICDMOB_insupd_stockInward", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_orgn_code", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_orgn_code;// ObjFarmer.document.context.Header.in_farmer_rowid;
                cmd.Parameters.Add("In_ic_code", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_ic_code;
                cmd.Parameters.Add("In_inward_code", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_inward_code;
                cmd.Parameters.Add("In_grn_no", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_grn_no;
                cmd.Parameters.Add("In_grn_date", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_grn_date;
                cmd.Parameters.Add("In_supplier_name", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_supplier_name;
                cmd.Parameters.Add("In_supplier_location", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_supplier_location;
                cmd.Parameters.Add("In_from_state", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_from_state;
                cmd.Parameters.Add("In_Remarks", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_Remarks;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_process_status", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_process_status;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_mode_flag;
                if (string.IsNullOrWhiteSpace(ObjICDStock.document.context.Header.In_bill_image))
                {
                    cmd.Parameters.Add("In_bill_image", MySqlDbType.LongText).Value = "";
                }
                else
                {
                    cmd.Parameters.Add("In_bill_image", MySqlDbType.LongText).Value = ObjICDStock.document.context.Header.In_bill_image;
                }
                cmd.Parameters.Add("In_transport_amount", MySqlDbType.Int32).Value = ObjICDStock.document.context.Header.In_transport_amount;
                cmd.Parameters.Add("In_others", MySqlDbType.Int32).Value = ObjICDStock.document.context.Header.In_others;
                cmd.Parameters.Add("In_loading_unloading_cost", MySqlDbType.Int32).Value = ObjICDStock.document.context.Header.In_loading_unloading_cost;
                cmd.Parameters.Add("In_local_transport_cost", MySqlDbType.Int32).Value = ObjICDStock.document.context.Header.In_local_transport_cost;
                cmd.Parameters.Add("In_local_loading_unloading_cost", MySqlDbType.Int32).Value = ObjICDStock.document.context.Header.In_local_loading_unloading_cost;
                cmd.Parameters.Add("In_roundoff", MySqlDbType.Double).Value = Convert.ToDouble(ObjICDStock.document.context.Header.In_roundoff);
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.localeId;
                cmd.Parameters.Add("IOU_inward_rowid", MySqlDbType.Int32).Value = ObjICDStock.document.context.Header.IOU_inward_rowid;
                cmd.Parameters.Add(new MySqlParameter("IOU_inward_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_grn_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                LogHelper.ConvertCmdIntoString(cmd);
                ret = cmd.ExecuteNonQuery();
                if (ret > 0)
                {
                    IOU_inward_rowid1 = (Int32)cmd.Parameters["IOU_inward_rowid1"].Value;
                    In_grn_no1 = (string)cmd.Parameters["In_grn_no1"].Value;
                    objresICDStock.context.Header.IOU_inward_rowid = Convert.ToInt32(IOU_inward_rowid1);
                }
                if (objresICDStock.context.Header.IOU_inward_rowid > 0)
                {
                    int results = 0;
                    results = SaveIDCDetail(ObjICDStock, objresICDStock, mysqlcon, MysqlCon);
                    if (results == 0)
                    {
                        mysqltrans.Rollback();
                        MysqlCon.con.Close();
                        return objresICDStock;
                    }
                    mysqltrans.Commit();
                    MysqlCon.con.Close();
                    return objresICDStock;
                }
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                MysqlCon.con.Close();
                return objresICDStock;
                //  throw ex;
                logger.Error("USERNAME :" + ObjICDStock.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            finally
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Open)
                {
                    MysqlCon.con.Close();
                }

            }
            return objresICDStock;
        }

        public int SaveIDCDetail(IUStockApplication Objmodel, IUStockDocument objIUStock, string MysqlCons, DataConnection MysqlCon)
        {
            int result = 0;
            DataTable tab = new DataTable();
            IUStocksaveDetail objkycdtl = new IUStocksaveDetail();
            try
            {
                ICDStockInward_DataModel objproduct1 = new ICDStockInward_DataModel();
                foreach (var Kyc in Objmodel.document.context.Detail)
                {
                    // inward_id = objIUStock.context.Header.IOU_inward_rowid;// Kyc.In_inwarddtl_rowid;

                    objkycdtl.In_inwarddtl_rowid = Kyc.In_inwarddtl_rowid;
                    objkycdtl.In_inward_code = Kyc.In_inward_code;
                    objkycdtl.In_grn_no = Kyc.In_grn_no;
                    objkycdtl.In_product_catg_code = Kyc.In_product_catg_code;
                    objkycdtl.In_product_subcatg_code = Kyc.In_product_subcatg_code;
                    objkycdtl.In_product_code = Kyc.In_product_code;
                    objkycdtl.In_uomtype_code = Kyc.In_uomtype_code;
                    objkycdtl.In_batch_no = Kyc.In_batch_no;
                    objkycdtl.In_received_qty = Kyc.In_received_qty;
                    objkycdtl.In_product_amount = Kyc.In_product_amount;
                    objkycdtl.In_tax_amount = Kyc.In_tax_amount;
                    objkycdtl.In_transport_amount = Kyc.In_transport_amount;
                    objkycdtl.In_discount = Kyc.In_discount;
                    objkycdtl.In_net_amount = Kyc.In_net_amount;
                    objkycdtl.In_status_code = Kyc.In_status_code;
                    objkycdtl.In_mode_flag = Kyc.In_mode_flag;

                    result = objproduct1.SaveIDCDetailList(objkycdtl, objIUStock, Objmodel, MysqlCons, MysqlCon);
                    /* 18-03-2021 */
                    if (result > 0)
                    {
                        int res = 0;
                        int result1 = 0;
                        ICDINSDetailSlno objdtlslno = new ICDINSDetailSlno();
                        ICDINSDetailOtherCost objOC = new ICDINSDetailOtherCost();
                        ICDINSDetailOtherInputs objOtrInp = new ICDINSDetailOtherInputs();
                        ICDINSDetail ObjKycDtl = new ICDINSDetail();

                        ICDStockInward_DataModel objproduct2 = new ICDStockInward_DataModel();
                        if (Kyc.Slnoinfo != null)
                        {
                            foreach (var Kyc1 in Kyc.Slnoinfo)
                            {
                                objdtlslno.In_inwardslno_rowid = Kyc1.In_inwardslno_rowid;
                                //objdtlslno.In_inwarddtl_rowid = objkycdtl.In_inwarddtl_rowid;//ObjKycDtl.In_inwarddtl_rowid;
                                //Ramya Modified
                                objdtlslno.In_inwarddtl_rowid = result;
                                objdtlslno.In_slno = Kyc1.In_slno;
                                objdtlslno.In_no_of_bags = Kyc1.In_no_of_bags;
                                objdtlslno.In_grn_no = In_grn_no1;
                                objdtlslno.In_product_catg_code = Kyc.In_product_catg_code;
                                objdtlslno.In_product_subcatg_code = Kyc.In_product_subcatg_code;
                                objdtlslno.In_product_code = Kyc.In_product_code;
                                objdtlslno.In_status_code = Kyc1.In_status_code;
                                objdtlslno.In_mode_flag = Kyc1.In_mode_flag;
                                result1 = objproduct2.SaveIDCDetailSlnoList(objdtlslno, objIUStock, Objmodel, MysqlCons, MysqlCon);
                            }
                        }
                        // Other_Cost //
                        if (Objmodel.document.context.locnId.ToString().ToUpper() == "UP")
                        {
                            if (Kyc.OtherCostInfo != null)
                            {
                                foreach (var OC in Kyc.OtherCostInfo)
                                {
                                    objOC.In_inwardOtherCost_rowid = OC.In_inwardOtherCost_rowid;
                                    //objOC.In_inwarddtl_rowid = objkycdtl.In_inwarddtl_rowid;
                                    //Ramya Modified
                                    objOC.In_inwarddtl_rowid = result;
                                    objOC.In_OtherCostCode = OC.In_OtherCostCode;
                                    objOC.In_OtherCostType = OC.In_OtherCostType;
                                    objOC.In_OtherCostOn = OC.In_OtherCostOn;
                                    objOC.In_OtherCostAmount = OC.In_OtherCostAmount;
                                    objOC.In_grn_no = In_grn_no1;
                                    objOC.In_product_catg_code = Kyc.In_product_catg_code;
                                    objOC.In_product_subcatg_code = Kyc.In_product_subcatg_code;
                                    objOC.In_product_code = OC.In_product_code;
                                    objOC.In_status_code = OC.In_status_code;
                                    objOC.In_mode_flag = OC.In_mode_flag;
                                    res = objproduct2.SaveIDCDetailOtherCostList(objOC, objIUStock, Objmodel, MysqlCons, MysqlCon);
                                }

                            }

                            if (Kyc.OtherInputInfo != null)
                            {
                                foreach (var OtrInp in Kyc.OtherInputInfo)
                                {
                                    objOtrInp.In_inwardOtherinput_rowid = OtrInp.In_inwardOtherinput_rowid;
                                    //objOtrInp.In_inwarddtl_rowid = objkycdtl.In_inwarddtl_rowid;
                                    //Ramya Modified
                                    objOtrInp.In_inwarddtl_rowid = result;// Inward Detail Row ID
                                    objOtrInp.In_NoOfLoosePack = OtrInp.In_NoOfLoosePack;
                                    objOtrInp.In_CartonVolume = OtrInp.In_CartonVolume;
                                    objOtrInp.In_Type = OtrInp.In_Type;
                                    objOtrInp.In_ManufactureDate = OtrInp.In_ManufactureDate;
                                    objOtrInp.In_ExpDate = OtrInp.In_ExpDate;
                                    objOtrInp.In_Mrp = OtrInp.In_Mrp;
                                    objOtrInp.In_mode_flag = OtrInp.In_mode_flag;
                                    objOtrInp.In_grn_no = In_grn_no1;
                                    objOtrInp.In_product_catg_code = Kyc.In_product_catg_code;
                                    objOtrInp.In_product_subcatg_code = Kyc.In_product_subcatg_code;
                                    objOtrInp.In_product_code = Kyc.In_product_code;
                                    objOtrInp.In_status_code = OtrInp.In_status_code;
                                    res = objproduct2.SaveIDCDetailOtherInputList(objOtrInp, objIUStock, Objmodel, MysqlCons, MysqlCon);

                                }
                            }

                        }
                    }
                    else
                    {
                        mysqltrans.Rollback();
                        MysqlCon.con.Close();
                    }
                     

                }
                return result;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return result;
            }
        }

        public int SaveIDCDetailList(IUStocksaveDetail ObjKycDtl, IUStockDocument objIUStock, IUStockApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {

            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("ICDMOB_iud_stockInward_detail", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("IOU_inward_rowid", MySqlDbType.Int32).Value = objIUStock.context.Header.IOU_inward_rowid;
                cmd.Parameters.Add("In_inwarddtl_rowid", MySqlDbType.Int32).Value = ObjKycDtl.In_inwarddtl_rowid;
                cmd.Parameters.Add("In_inward_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_inward_code;
                cmd.Parameters.Add("In_grn_no", MySqlDbType.VarChar).Value = ObjKycDtl.In_grn_no;
                cmd.Parameters.Add("In_product_catg_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_product_catg_code;
                cmd.Parameters.Add("In_product_subcatg_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_product_subcatg_code;
                cmd.Parameters.Add("In_product_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_product_code;
                cmd.Parameters.Add("In_uomtype_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_uomtype_code;
                cmd.Parameters.Add("In_batch_no", MySqlDbType.VarChar).Value = ObjKycDtl.In_batch_no;
                cmd.Parameters.Add("In_received_qty", MySqlDbType.Float).Value = ObjKycDtl.In_received_qty;
                cmd.Parameters.Add("In_product_amount", MySqlDbType.Float).Value = ObjKycDtl.In_product_amount;
                cmd.Parameters.Add("In_tax_amount", MySqlDbType.Float).Value = ObjKycDtl.In_tax_amount;
                cmd.Parameters.Add("In_transport_amount", MySqlDbType.Float).Value = ObjKycDtl.In_transport_amount;
                cmd.Parameters.Add("In_discount", MySqlDbType.Float).Value = ObjKycDtl.In_discount;
                cmd.Parameters.Add("In_net_amount", MySqlDbType.Float).Value = ObjKycDtl.In_net_amount;
                cmd.Parameters.Add("In_status_code", MySqlDbType.String).Value = ObjKycDtl.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.String).Value = ObjKycDtl.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("IOU_inwarddtl_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                LogHelper.ConvertCmdIntoString(cmd);
                ret = cmd.ExecuteNonQuery();
                if (ret > 0)
                {
                    ret = (Int32)cmd.Parameters["IOU_inwarddtl_rowid1"].Value; 
                }
                return ret;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return ret;
            }
        }

        public PApplication ProductsearchStock(PContext objproductSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();

            PApplication objproductSearchRoot = new PApplication();
            ICDStockInward_DataModel objDataModel = new ICDStockInward_DataModel();

            DataTable Detail = new DataTable();
            DataTable InvoiceTax = new DataTable();

            objproductSearchRoot.context = new PContext();
            objproductSearchRoot.context.Detail = new List<PDetail>();
            objproductSearchRoot.context.InvoiceTax = new List<PInvoiceTax>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("ICDMOB_fetch_product_search", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objproductSearch.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objproductSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objproductSearch.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objproductSearch.localeId;
                cmd.Parameters.Add("in_filterby_option", MySqlDbType.VarChar).Value = objproductSearch.FilterBy_Option;
                cmd.Parameters.Add("in_filterby_code", MySqlDbType.VarChar).Value = objproductSearch.FilterBy_Code;
                cmd.Parameters.Add("in_filterby_fromvalue", MySqlDbType.VarChar).Value = objproductSearch.FilterBy_FromValue;
                cmd.Parameters.Add("in_filterby_tovalue", MySqlDbType.VarChar).Value = objproductSearch.FilterBy_ToValue;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                if (ds.Tables.Count > 0)
                {
                    Detail = ds.Tables[0];
                    InvoiceTax = ds.Tables[1];


                    for (int i = 0; i < Detail.Rows.Count; i++)
                    {
                        PDetail objDetailList = new PDetail();
                        objDetailList.In_ic_code = Detail.Rows[i]["In_ic_code"].ToString();
                        objDetailList.In_productcategory = Detail.Rows[i]["In_productcategory"].ToString();
                        objDetailList.In_productcategory_desc = Detail.Rows[i]["In_productcategory_desc"].ToString();
                        objDetailList.In_productsubcategory = Detail.Rows[i]["In_productsubcategory"].ToString();
                        objDetailList.In_productsubcategory_desc = Detail.Rows[i]["In_productsubcategory_desc"].ToString();
                        objDetailList.In_product_code = Detail.Rows[i]["In_product_code"].ToString();
                        objDetailList.In_product_name = Detail.Rows[i]["In_product_name"].ToString();
                        objDetailList.In_uomtype_code = Detail.Rows[i]["In_uomtype_code"].ToString();
                        objDetailList.In_uomtype_code_desc = Detail.Rows[i]["In_uomtype_code_desc"].ToString();
                        objDetailList.In_base_price = Convert.ToDouble(Detail.Rows[i]["In_base_price"]);
                        objDetailList.In_current_qty = Convert.ToDouble(Detail.Rows[i]["In_current_qty"]);


                        objproductSearchRoot.context.Detail.Add(objDetailList);
                    }
                    for (int i = 0; i < InvoiceTax.Rows.Count; i++)
                    {
                        PInvoiceTax objPInvoiceTaxList = new PInvoiceTax();
                        objPInvoiceTaxList.In_invoicetax_rowid = Convert.ToInt32(InvoiceTax.Rows[i]["In_invoicetax_rowid"]);
                        objPInvoiceTaxList.In_invoice_no = InvoiceTax.Rows[i]["In_invoice_no"].ToString();
                        objPInvoiceTaxList.In_product_code = InvoiceTax.Rows[i]["In_product_code"].ToString();
                        objPInvoiceTaxList.In_product_name = InvoiceTax.Rows[i]["In_product_name"].ToString();
                        objPInvoiceTaxList.In_hsn_code = InvoiceTax.Rows[i]["In_hsn_code"].ToString();
                        objPInvoiceTaxList.In_hsn_desc = InvoiceTax.Rows[i]["In_hsn_desc"].ToString();
                        objPInvoiceTaxList.In_cgst_rate = Convert.ToDouble(InvoiceTax.Rows[i]["In_cgst_rate"]);
                        objPInvoiceTaxList.In_sgst_rate = Convert.ToDouble(InvoiceTax.Rows[i]["In_sgst_rate"]);
                        objPInvoiceTaxList.In_igst_rate = Convert.ToDouble(InvoiceTax.Rows[i]["In_igst_rate"]);
                        objPInvoiceTaxList.In_ugst_rate = Convert.ToDouble(InvoiceTax.Rows[i]["In_ugst_rate"]);
                        objPInvoiceTaxList.In_tax_type = InvoiceTax.Rows[i]["In_tax_type"].ToString();
                        objPInvoiceTaxList.In_tax_rate = Convert.ToDouble(InvoiceTax.Rows[i]["In_tax_rate"]);
                        objPInvoiceTaxList.In_taxable_amount = Convert.ToDouble(InvoiceTax.Rows[i]["In_taxable_amount"]);
                        objPInvoiceTaxList.In_tax_amount = Convert.ToDouble(InvoiceTax.Rows[i]["In_tax_amount"]);
                        objPInvoiceTaxList.In_status_code = InvoiceTax.Rows[i]["In_status_code"].ToString();
                        objPInvoiceTaxList.In_status_desc = InvoiceTax.Rows[i]["In_status_desc"].ToString();
                        objPInvoiceTaxList.In_mode_flag = InvoiceTax.Rows[i]["In_mode_flag"].ToString();

                        objproductSearchRoot.context.InvoiceTax.Add(objPInvoiceTaxList);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objproductSearch.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }
            return objproductSearchRoot;
        } 

        public int SaveIDCDetailSlnoList(ICDINSDetailSlno ObjDtlSlno, IUStockDocument objIUStock, IUStockApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {

            int ret = 0;
            try
            {
                //ICDINSDetail ObjKycDtl = new ICDINSDetail();
                MySqlCommand cmd = new MySqlCommand("ICDMOB_iud_stockInward_detailslno", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_inwardslno_rowid", MySqlDbType.Int32).Value = Convert.ToInt32(ObjDtlSlno.In_inwardslno_rowid);
                cmd.Parameters.Add("In_inwarddtl_rowid", MySqlDbType.Int32).Value = Convert.ToInt32(ObjDtlSlno.In_inwarddtl_rowid);
                cmd.Parameters.Add("In_slno", MySqlDbType.VarChar).Value = ObjDtlSlno.In_slno;
                cmd.Parameters.Add("In_no_of_bags", MySqlDbType.VarChar).Value = ObjDtlSlno.In_no_of_bags;
                cmd.Parameters.Add("In_grn_no", MySqlDbType.VarChar).Value = ObjDtlSlno.In_grn_no;
                cmd.Parameters.Add("In_product_catg_code", MySqlDbType.VarChar).Value = ObjDtlSlno.In_product_catg_code;
                cmd.Parameters.Add("In_product_subcatg_code", MySqlDbType.VarChar).Value = ObjDtlSlno.In_product_subcatg_code;
                cmd.Parameters.Add("In_product_code", MySqlDbType.VarChar).Value = ObjDtlSlno.In_product_code;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjDtlSlno.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjDtlSlno.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                //LogHelper.ConvertCmdIntoString(cmd);
                ret = cmd.ExecuteNonQuery();

                return ret;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return ret;
            }
        }

        public int SaveIDCDetailOtherCostList(ICDINSDetailOtherCost ObjDtlOC, IUStockDocument objIUStock, IUStockApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {

            int ret = 0; 
            try
            {
                //ICDINSDetail ObjKycDtl = new ICDINSDetail();
                MySqlCommand cmd = new MySqlCommand("ICDMOB_iud_stockInward_detailOtherCost", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("In_inwardOtherCost_rowid", MySqlDbType.Int32).Value = Convert.ToInt32(ObjDtlOC.In_inwardOtherCost_rowid);
                cmd.Parameters.Add("In_inwarddtl_rowid", MySqlDbType.Int32).Value = Convert.ToInt32(ObjDtlOC.In_inwarddtl_rowid);
                cmd.Parameters.Add("In_OtherCostCode", MySqlDbType.VarChar).Value = ObjDtlOC.In_OtherCostCode;
                cmd.Parameters.Add("In_OtherCostType", MySqlDbType.VarChar).Value = ObjDtlOC.In_OtherCostType;
                cmd.Parameters.Add("In_OtherCostOn", MySqlDbType.VarChar).Value = ObjDtlOC.In_OtherCostOn;
                cmd.Parameters.Add("In_OtherCostAmount", MySqlDbType.VarChar).Value = ObjDtlOC.In_OtherCostAmount;

                cmd.Parameters.Add("In_grn_no", MySqlDbType.VarChar).Value = ObjDtlOC.In_grn_no;
                cmd.Parameters.Add("In_product_catg_code", MySqlDbType.VarChar).Value = ObjDtlOC.In_product_catg_code;
                cmd.Parameters.Add("In_product_subcatg_code", MySqlDbType.VarChar).Value = ObjDtlOC.In_product_subcatg_code;
                cmd.Parameters.Add("In_product_code", MySqlDbType.VarChar).Value = ObjDtlOC.In_product_code;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjDtlOC.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjDtlOC.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                //LogHelper.ConvertCmdIntoString(cmd);
                ret = cmd.ExecuteNonQuery();

                return ret;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return ret;
            }
        }

        public int SaveIDCDetailOtherInputList(ICDINSDetailOtherInputs ObjDtlOC, IUStockDocument objIUStock, IUStockApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {

            int ret = 0;
            try
            {
                //ICDINSDetail ObjKycDtl = new ICDINSDetail();
                MySqlCommand cmd = new MySqlCommand("ICDMOB_iud_stockInward_detailOtherInputs", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("In_inwardOtherinput_rowid", MySqlDbType.Int32).Value = Convert.ToInt32(ObjDtlOC.In_inwardOtherinput_rowid);
                cmd.Parameters.Add("In_inwarddtl_rowid", MySqlDbType.Int32).Value = Convert.ToInt32(ObjDtlOC.In_inwarddtl_rowid);
                cmd.Parameters.Add("In_NoOfLoosePack", MySqlDbType.VarChar).Value = ObjDtlOC.In_NoOfLoosePack;
                cmd.Parameters.Add("In_CartonVolume", MySqlDbType.VarChar).Value = ObjDtlOC.In_CartonVolume;
                cmd.Parameters.Add("In_Type", MySqlDbType.VarChar).Value = ObjDtlOC.In_Type;
                cmd.Parameters.Add("In_ManufactureDate", MySqlDbType.VarChar).Value = ObjDtlOC.In_ManufactureDate;
                cmd.Parameters.Add("In_ExpDate", MySqlDbType.VarChar).Value = ObjDtlOC.In_ExpDate;
                cmd.Parameters.Add("In_Mrp", MySqlDbType.VarChar).Value = ObjDtlOC.In_Mrp;
                cmd.Parameters.Add("In_grn_no", MySqlDbType.VarChar).Value = ObjDtlOC.In_grn_no;
                cmd.Parameters.Add("In_product_catg_code", MySqlDbType.VarChar).Value = ObjDtlOC.In_product_catg_code;
                cmd.Parameters.Add("In_product_subcatg_code", MySqlDbType.VarChar).Value = ObjDtlOC.In_product_subcatg_code;
                cmd.Parameters.Add("In_product_code", MySqlDbType.VarChar).Value = ObjDtlOC.In_product_code;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjDtlOC.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjDtlOC.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                //LogHelper.ConvertCmdIntoString(cmd);
                ret = cmd.ExecuteNonQuery();

                return ret;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return ret;
            }
        }

        

        public Document Saveinwardpayment(PSApplication ObjFarmer, string mysqlcon)
        {
            int ret = 0;

            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            Document objsinvoice = new Document();
            objsinvoice.context = new PSContext();
            objsinvoice.context.Header = new PSHeader();
            objsinvoice.ApplicationException = new PSAApplicationException();
            string IOU_invoice_rowid1 = "";
            string IOU_invoice_no1 = "";
            try
            {

                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                //string[] returnvalues = { };
                MySqlCommand cmd = new MySqlCommand("ICDMOB_insupd_inward_payment", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_inward_date", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_invoice_date;
                cmd.Parameters.Add("In_inward_amount", MySqlDbType.Double).Value = ObjFarmer.document.context.Header.In_invoice_amount;
                cmd.Parameters.Add("In_balance_amount", MySqlDbType.Double).Value = ObjFarmer.document.context.Header.In_balance_amount;
                cmd.Parameters.Add("In_payment_mode", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_payment_mode;
                cmd.Parameters.Add("In_ref_no", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_ref_no;
                cmd.Parameters.Add("In_payment_date", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_payment_date;
                cmd.Parameters.Add("In_payment_amount", MySqlDbType.Double).Value = ObjFarmer.document.context.Header.In_payment_amount;
                cmd.Parameters.Add("In_payment_response", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_payment_response;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_check_no", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_check_no;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.localeId;
                cmd.Parameters.Add("IOU_inward_no", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.IOU_invoice_no;
                cmd.Parameters.Add("IOU_inward_rowid", MySqlDbType.Int32).Value = ObjFarmer.document.context.Header.IOU_invoice_rowid;

                cmd.Parameters.Add(new MySqlParameter("IOU_inward_rowid1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_inward_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                if (ret > 0)
                {
                    IOU_invoice_rowid1 = (string)cmd.Parameters["IOU_inward_rowid1"].Value;
                    IOU_invoice_no1 = (string)cmd.Parameters["IOU_inward_no1"].Value;
                    objsinvoice.context.Header.IOU_invoice_rowid = Convert.ToInt32(IOU_invoice_rowid1);
                    objsinvoice.context.Header.IOU_invoice_no = IOU_invoice_no1;
                }
                if (objsinvoice.context.Header.IOU_invoice_rowid > 0)
                {
                    string[] resultinvdetail = { };
                    resultinvdetail = SaveInwrdPaymentDetail(ObjFarmer, objsinvoice, mysqlcon, MysqlCon);
                    if (resultinvdetail[0].Contains("060"))
                    {
                        mysqltrans.Rollback();
                        objsinvoice.ApplicationException.errorNumber = resultinvdetail[0].ToString();
                        objsinvoice.ApplicationException.errorDescription = resultinvdetail[1].ToString();
                        return objsinvoice;
                    }

                }
                string[] returnvalues = { IOU_invoice_rowid1 };

                mysqltrans.Commit();
                return objsinvoice;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                logger.Error("USERNAME :" + ObjFarmer.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return objsinvoice;
            }
        }
        public string[] SaveInwrdPaymentDetail(PSApplication Objmodel, Document objInwrd, string MysqlCons, DataConnection MysqlCon)
        {
            string[] result = { };
            string errorNo = "";
            string errorMsg = "";
            string[] resultinvdetail = new string[2];
            DataTable tab = new DataTable();
            PSDetail objinvdtl = new PSDetail();
            try
            {
                ICDStockInward_DataModel objproduct1 = new ICDStockInward_DataModel();
                foreach (var Detail in Objmodel.document.context.Detail)
                {
                    objinvdtl.In_paymentcollection_rowid = Detail.In_paymentcollection_rowid;
                    objinvdtl.In_payment_type = Detail.In_payment_type;
                    objinvdtl.In_payment_no = Detail.In_payment_no;
                    objinvdtl.In_balance_amount = Detail.In_balance_amount;
                    objinvdtl.In_payment_amount = Detail.In_payment_amount;
                    objinvdtl.In_payment_mode = Detail.In_payment_mode;
                    objinvdtl.In_ref_no = Detail.In_ref_no;
                    objinvdtl.In_payment_date = Detail.In_payment_date;
                    objinvdtl.In_process_status = Detail.In_process_status;
                    objinvdtl.In_paid_amount = Detail.In_paid_amount;
                    objinvdtl.In_mode_flag = Detail.In_mode_flag;
                    result = objproduct1.SaveInwrdPaymentDetailNew(objinvdtl, objInwrd, Objmodel, MysqlCons, MysqlCon);

                    //if (result[0].Contains("060"))
                    //{
                    //    errorNo = result[0].ToString();
                    //    errorMsg = result[1].ToString();
                    //    break;
                    //}
                }
                //string[] resultinvdetail = { errorNo, errorMsg };
                resultinvdetail[0] = errorNo;
                resultinvdetail[1] = errorMsg;
                return resultinvdetail;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return resultinvdetail;
            }

        }

        public string[] SaveInwrdPaymentDetailNew(PSDetail objinvdtl, Document ObjFarmer, PSApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {
            string errorNo = "";
            string errorMsg = "";
            string[] result = new string[2];
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("ICDMOB_iud_inward_payment_detail", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_paymentcollection_rowid", MySqlDbType.Int32).Value = objinvdtl.In_paymentcollection_rowid;
                cmd.Parameters.Add("In_payment_type", MySqlDbType.VarChar).Value = objinvdtl.In_payment_type;
                cmd.Parameters.Add("In_payment_no", MySqlDbType.VarChar).Value = objinvdtl.In_payment_no;
                cmd.Parameters.Add("In_balance_amount", MySqlDbType.Double).Value = objinvdtl.In_balance_amount;
                cmd.Parameters.Add("In_payment_amount", MySqlDbType.Double).Value = objinvdtl.In_payment_amount;
                cmd.Parameters.Add("In_payment_mode", MySqlDbType.VarChar).Value = objinvdtl.In_payment_mode;
                cmd.Parameters.Add("In_ref_no", MySqlDbType.VarChar).Value = objinvdtl.In_ref_no;
                cmd.Parameters.Add("In_payment_date", MySqlDbType.VarChar).Value = objinvdtl.In_payment_date;
                cmd.Parameters.Add("In_process_status", MySqlDbType.VarChar).Value = objinvdtl.In_process_status;
                cmd.Parameters.Add("In_paid_amount", MySqlDbType.Double).Value = objinvdtl.In_paid_amount;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objinvdtl.In_mode_flag;
                cmd.Parameters.Add("IOU_inward_rowid", MySqlDbType.Int32).Value = ObjFarmer.context.Header.IOU_invoice_rowid;
                cmd.Parameters.Add("IOU_inward_no", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.IOU_invoice_no;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                //if (ret == 0)
                //{

                //    errorNo = (string)cmd.Parameters["errorNo"].Value;
                //    errorMsg = ObjErrormsg.ErrorMessage(errorNo);

                //}
                //string[] result = { errorNo, errorMsg };
                result[0] = errorNo;
                result[1] = errorMsg;
                return result;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return result;
            }
        }



        public ICDInvoicepayApplication GetICDProductInwardPayfetch(ICDInvoicepayContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();

            MysqlCon = new DataConnection(mysqlcon);

            ICDInvoicepayApplication ObjinvRoot = new ICDInvoicepayApplication();
            ICDStockInward_DataModel objDataModel = new ICDStockInward_DataModel();

            DataTable Detail = new DataTable();
            DataTable Header = new DataTable();

            ObjinvRoot.context = new ICDInvoicepayContext();
            ObjinvRoot.context.Header = new ICDInvoicepayHeader();
            ObjinvRoot.context.Detail = new List<ICDInvoicepayDetail>();
            try
            {

                MySqlCommand cmd = new MySqlCommand("ICDMOB_fetch_payment_collection_inward", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("In_inward_rowid", MySqlDbType.Int32).Value = ObjContext.invoice_rowid;

                cmd.Parameters.Add(new MySqlParameter("In_inward_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_inward_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_inward_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_balance_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                if (ds.Tables.Count > 0)
                {
                    Detail = ds.Tables[0];
                    for (int i = 0; i < Detail.Rows.Count; i++)
                    {
                        ICDInvoicepayDetail objInvpayList = new ICDInvoicepayDetail();
                        objInvpayList.In_paymentcollection_rowid = Convert.ToInt32(Detail.Rows[i]["In_paymentcollection_rowid"]);
                        objInvpayList.In_payment_type = Detail.Rows[i]["In_payment_type"].ToString();
                        objInvpayList.In_payment_type_desc = Detail.Rows[i]["In_payment_type_desc"].ToString();
                        objInvpayList.In_payment_no = Detail.Rows[i]["In_payment_no"].ToString();
                        objInvpayList.In_balance_amount = Convert.ToDouble(Detail.Rows[i]["In_balance_amount"]);
                        objInvpayList.In_payment_amount = Convert.ToDouble(Detail.Rows[i]["In_payment_amount"]);
                        objInvpayList.In_payment_mode = Detail.Rows[i]["In_payment_mode"].ToString();
                        objInvpayList.In_ref_no = Detail.Rows[i]["In_ref_no"].ToString();
                        objInvpayList.In_payment_date = Detail.Rows[i]["In_payment_date"].ToString();
                        objInvpayList.In_process_status = Detail.Rows[i]["In_process_status"].ToString();
                        objInvpayList.In_process_status_desc = Detail.Rows[i]["In_process_status_desc"].ToString();
                        objInvpayList.In_paid_amount = Convert.ToDouble(Detail.Rows[i]["In_paid_amount"]);
                        objInvpayList.In_mode_flag = Detail.Rows[i]["In_mode_flag"].ToString();
                        objInvpayList.In_payment_mode_desc= Detail.Rows[i]["In_payment_mode_desc"].ToString(); //ramya added on 07 jun 21

                        ObjinvRoot.context.Detail.Add(objInvpayList);
                    }
                }
                ObjinvRoot.context.orgnId = ObjContext.orgnId;
                ObjinvRoot.context.locnId = ObjContext.locnId;
                ObjinvRoot.context.userId = ObjContext.userId;
                ObjinvRoot.context.localeId = ObjContext.localeId;

                ObjinvRoot.context.Header.In_invoice_no = (string)cmd.Parameters["In_inward_no"].Value;
                ObjinvRoot.context.Header.In_invoice_date = (string)cmd.Parameters["In_inward_date"].Value.ToString();
                ObjinvRoot.context.Header.In_invoice_amount = (double)cmd.Parameters["In_inward_amount"].Value;
                ObjinvRoot.context.Header.In_balance_amount = (double)cmd.Parameters["In_balance_amount"].Value;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return ObjinvRoot;
        }



        public MOBPAYRoot paymentcollection_InwardList(string org, string locn, string user, string lang, int invoice_rowid, string mysqlcon)
        {
            DataSet ds = new DataSet();

            MysqlCon = new DataConnection(mysqlcon);

            MOBPAYRoot ObjinvRoot = new MOBPAYRoot();
            ICDStockInward_DataModel objDataModel = new ICDStockInward_DataModel();

            DataTable Detail = new DataTable();
            DataTable Header = new DataTable();

            ObjinvRoot.context = new MOBPAYContext();
            ObjinvRoot.context.Header = new MOBPAYHeader();
            ObjinvRoot.context.Detail = new List<MOBPAYDetail>();
            try
            {

                MySqlCommand cmd = new MySqlCommand("ICDMOB_fetch_payment_collection_inward", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("In_inward_rowid", MySqlDbType.Int32).Value = invoice_rowid;

                cmd.Parameters.Add(new MySqlParameter("In_inward_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_inward_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_inward_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_balance_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                if (ds.Tables.Count > 0)
                {
                    Detail = ds.Tables[0];
                    for (int i = 0; i < Detail.Rows.Count; i++)
                    {
                        MOBPAYDetail objInvpayList = new MOBPAYDetail();
                        objInvpayList.In_paymentcollection_rowid = Convert.ToInt32(Detail.Rows[i]["In_paymentcollection_rowid"]);
                        objInvpayList.In_payment_type = Detail.Rows[i]["In_payment_type"].ToString();
                        objInvpayList.In_payment_type_desc = Detail.Rows[i]["In_payment_type_desc"].ToString();
                        objInvpayList.In_payment_no = Detail.Rows[i]["In_payment_no"].ToString();
                        objInvpayList.In_balance_amount = Convert.ToDouble(Detail.Rows[i]["In_balance_amount"]);
                        objInvpayList.In_payment_amount = Convert.ToDouble(Detail.Rows[i]["In_payment_amount"]);
                        objInvpayList.In_payment_mode = Detail.Rows[i]["In_payment_mode"].ToString();
                        objInvpayList.In_payment_mode_desc = Detail.Rows[i]["In_payment_mode_desc"].ToString();
                        objInvpayList.In_ref_no = Detail.Rows[i]["In_ref_no"].ToString();
                        objInvpayList.In_payment_date = Detail.Rows[i]["In_payment_date"].ToString();
                        objInvpayList.In_process_status = Detail.Rows[i]["In_process_status"].ToString();
                        objInvpayList.In_process_status_desc = Detail.Rows[i]["In_process_status_desc"].ToString();
                        objInvpayList.In_paid_amount = Convert.ToDouble(Detail.Rows[i]["In_paid_amount"]);
                        objInvpayList.In_mode_flag = Detail.Rows[i]["In_mode_flag"].ToString();

                        ObjinvRoot.context.Detail.Add(objInvpayList);
                    }
                }
                ObjinvRoot.context.orgnId = org;
                ObjinvRoot.context.locnId = locn;
                ObjinvRoot.context.userId = user;
                ObjinvRoot.context.localeId = lang;

                ObjinvRoot.context.Header.In_invoice_no = (string)cmd.Parameters["In_inward_no"].Value;
                ObjinvRoot.context.Header.In_invoice_date = (string)cmd.Parameters["In_inward_date"].Value.ToString();
                ObjinvRoot.context.Header.In_invoice_amount = (double)cmd.Parameters["In_inward_amount"].Value;
                ObjinvRoot.context.Header.In_balance_amount = (double)cmd.Parameters["In_balance_amount"].Value;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return ObjinvRoot;
        }
         

    }
}
