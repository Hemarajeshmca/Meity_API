using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FFI_Model;
using System.Reflection;

namespace FFI_DataModel
{
   public class ICDStockAdjust_DataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDStockAdjust_DataModel)); //Declaring Log4Net. 
        string methodName = MethodBase.GetCurrentMethod().Name;
        public ICDStockAdjRootObject GetAllStockAdjList(ICDStockAdjContext objstock, string mysqlcon)
        {
 
            DataTable dt = new DataTable();

            ICDStockAdjRootObject ObjstockRoot = new ICDStockAdjRootObject();
            ICDStockAdjust_DataModel objDataModel = new ICDStockAdjust_DataModel();

            ObjstockRoot.context = new ICDStockAdjContext();
            ObjstockRoot.context.List = new List<ICDStockAdjList>();
          //  ObjstockRoot.context.Filter = new ICDStockAdjFilter();


            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("ICDMOB_fetch_stockAdjustment_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objstock.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objstock.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objstock.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objstock.localeId;
                cmd.Parameters.Add("In_filterby_option", MySqlDbType.VarChar).Value = objstock.filterby_option;
                cmd.Parameters.Add("In_filterby_code", MySqlDbType.VarChar).Value = objstock.filterby_code;
                cmd.Parameters.Add("In_filterby_fromvalue", MySqlDbType.VarChar).Value = objstock.filterby_fromvalue;
                cmd.Parameters.Add("In_filterby_tovalue", MySqlDbType.VarChar).Value = objstock.filterby_tovalue;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ICDStockAdjList objList = new ICDStockAdjList();
                    objList.Out_adjustment_rowid = Convert.ToInt32(dt.Rows[i]["Out_adjustment_rowid"]);
                    objList.Out_ic_code = dt.Rows[i]["Out_ic_code"].ToString();
                    objList.Out_ic_name = dt.Rows[i]["Out_ic_name"].ToString();
                    objList.Out_adjustment_no = dt.Rows[i]["Out_adjustment_no"].ToString();
                    objList.Out_adjustment_date = dt.Rows[i]["Out_adjustment_date"].ToString();
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.Out_status_desc = dt.Rows[i]["Out_status_desc"].ToString();
                    ObjstockRoot.context.List.Add(objList);
                }
                ObjstockRoot.context.orgnId = objstock.orgnId;
                ObjstockRoot.context.locnId = objstock.locnId;
                ObjstockRoot.context.localeId = objstock.localeId;
                ObjstockRoot.context.userId = objstock.userId;
                ObjstockRoot.context.filterby_code = objstock.filterby_code;
                ObjstockRoot.context.filterby_fromvalue = objstock.filterby_fromvalue;
                ObjstockRoot.context.filterby_option = objstock.filterby_option;
                ObjstockRoot.context.filterby_tovalue = objstock.filterby_tovalue;
            }
            catch (Exception ex)
            {
                //  throw ex;
                logger.Error("USERNAME :" + objstock.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjstockRoot;
        }

        //SingleICDStockAdjList
        public SingleICDStockAdjApplication SingleICDStockAdjList(SingleICDStockAdjContext objstock, string mysqlcon)
        {
            DataSet ds = new DataSet(); 
            DataTable Detail = new DataTable();

            SingleICDStockAdjApplication ObjstockRoot = new SingleICDStockAdjApplication();
            ICDStockAdjust_DataModel objDataModel = new ICDStockAdjust_DataModel();
            ObjstockRoot.context = new SingleICDStockAdjContext();
            ObjstockRoot.context.Header = new SingleICDStockAdjHeader();
            ObjstockRoot.context.Detail = new List<SingleICDStockAdjDetail>(); 
            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("ICDMOB_fetch_stock_adjustment", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objstock.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objstock.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objstock.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objstock.localeId;
                cmd.Parameters.Add("IOU_adjustment_rowid", MySqlDbType.VarChar).Value = objstock.adjustment_rowid;
                cmd.Parameters.Add(new MySqlParameter("In_orgn_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_ic_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_ic_desc", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_adjustment_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_adjustment_date", MySqlDbType.LongText)).Direction = ParameterDirection.Output; 
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_process_status", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output; 
                cmd.Parameters.Add(new MySqlParameter("IOU_adjustment_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output; 
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close(); 
                ObjstockRoot.context.Header.In_orgn_code = (string)cmd.Parameters["In_orgn_code"].Value;
                ObjstockRoot.context.Header.In_ic_code = (string)cmd.Parameters["In_ic_code"].Value;
                ObjstockRoot.context.Header.In_ic_desc = (string)cmd.Parameters["In_ic_desc"].Value;
                ObjstockRoot.context.Header.In_adjustment_no = (string)cmd.Parameters["In_adjustment_no"].Value;
                ObjstockRoot.context.Header.In_adjustment_date = (string)cmd.Parameters["In_adjustment_date"].Value; 
                ObjstockRoot.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value;
                ObjstockRoot.context.Header.In_process_status = (string)cmd.Parameters["In_process_status"].Value;
                ObjstockRoot.context.Header.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value;
                ObjstockRoot.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value; 
                ObjstockRoot.context.Header.IOU_adjustment_rowid = (int)objstock.adjustment_rowid; 
                if (ds.Tables.Count > 0)
                {


                    Detail = ds.Tables[0];
                    for (int i = 0; i < Detail.Rows.Count; i++)
                    {
                        SingleICDStockAdjDetail objDList = new SingleICDStockAdjDetail();
                        objDList.In_adjustmentdtl_rowid = Convert.ToInt32(Detail.Rows[i]["In_adjustmentdtl_rowid"]);
                        objDList.In_adjustment_no = Detail.Rows[i]["In_adjustment_no"].ToString();
                        objDList.In_receipt_ref_doc_no = Detail.Rows[i]["In_receipt_ref_doc_no"].ToString();
                        objDList.In_ref_doc_date = Detail.Rows[i]["In_ref_doc_date"].ToString();
                        objDList.In_adjustment_type = Detail.Rows[i]["In_adjustment_type"].ToString();
                        objDList.In_adjustment_desc = Detail.Rows[i]["In_adjustment_desc"].ToString();
                        objDList.In_product_catg_code = Detail.Rows[i]["In_product_catg_code"].ToString();
                        objDList.In_product_catg_desc = Detail.Rows[i]["In_product_catg_desc"].ToString();
                        objDList.In_product_subcatg_code = Detail.Rows[i]["In_product_subcatg_code"].ToString();
                        objDList.In_product_subcatg_desc = Detail.Rows[i]["In_product_subcatg_desc"].ToString();
                        objDList.In_product_code = Detail.Rows[i]["In_product_code"].ToString();
                        objDList.In_product_desc = Detail.Rows[i]["In_product_desc"].ToString();
                        objDList.In_adjustment_qty = Convert.ToInt32(Detail.Rows[i]["In_adjustment_qty"]);
                        objDList.In_uom_type = Detail.Rows[i]["In_uom_type"].ToString(); 
                        objDList.In_uom_type_desc = Detail.Rows[i]["In_uom_type_desc"].ToString();
                        objDList.In_remarks = Detail.Rows[i]["In_remarks"].ToString();
                        objDList.In_status_code = Detail.Rows[i]["In_status_code"].ToString();
                        objDList.In_status_desc = Detail.Rows[i]["In_status_desc"].ToString(); 
                        objDList.In_mode_flag = Detail.Rows[i]["In_mode_flag"].ToString();
                        objDList.In_out_qty =Convert.ToDecimal(Detail.Rows[i]["In_out_qty"].ToString());
                        objDList.In_adj_amt = Convert.ToDecimal(Detail.Rows[i]["In_adj_amt"].ToString());
                        ObjstockRoot.context.Detail.Add(objDList);
                    }
                }
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

        public IUStockADocument SaveICDStockAdj(IUStockAApplication ObjICDStock, string mysqlcon)
        {
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            IUStockADocument objresICDStock = new IUStockADocument();
            objresICDStock.context = new IUStockAContext();
            objresICDStock.context.Header = new IUStockAHeader();
            objresICDStock.ApplicationException= new IUApplicationException();
            try
            {
                int ret = 0; 
                int IOU_inward_rowid1 = 0;
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }
                MySqlCommand cmd = new MySqlCommand("ICDMOB_insupd_stockAdjustment", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_orgn_code", MySqlDbType.VarChar).Value = ObjICDStock.document.context.orgnId.Trim();// ObjFarmer.document.context.Header.in_farmer_rowid;
                cmd.Parameters.Add("In_ic_code", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_ic_code.Trim();
                cmd.Parameters.Add("In_ic_desc", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_ic_desc.Trim();
                cmd.Parameters.Add("In_adjustment_no", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_adjustment_no.Trim();
                cmd.Parameters.Add("In_adjustment_date", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_adjustment_date.Trim(); 
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_status_code.Trim();
                cmd.Parameters.Add("In_process_status", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_process_status.Trim();
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_row_timestamp.Trim();
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_mode_flag.Trim();
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.orgnId.Trim();
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.locnId.Trim();
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.userId.Trim();
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.localeId.Trim();
                cmd.Parameters.Add("IOU_adjustment_rowid", MySqlDbType.Int32).Value = ObjICDStock.document.context.Header.IOU_adjustment_rowid;

                cmd.Parameters.Add(new MySqlParameter("IOU_adjustment_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_adjustment_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                if (ret > 0)
                { 
                    objresICDStock.context.Header.IOU_adjustment_rowid = (Int32)cmd.Parameters["IOU_adjustment_rowid1"].Value; 
                }
                if (objresICDStock.context.Header.IOU_adjustment_rowid > 0)
                 {
                    int results = 0;
                    results = SaveIDCADetail(ObjICDStock, objresICDStock, mysqlcon, MysqlCon);
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
                logger.Error("USERNAME :" + ObjICDStock.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return objresICDStock;
               // throw ex;
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

        public int SaveIDCADetail(IUStockAApplication Objmodel, IUStockADocument objIUStock, string MysqlCons, DataConnection MysqlCon)
        {
            int result = 0;
            DataTable tab = new DataTable();
            IUStockADetail objkycdtl = new IUStockADetail();
            try
            {
                ICDStockAdjust_DataModel objproduct1 = new ICDStockAdjust_DataModel();
                foreach (var Kyc in Objmodel.document.context.Detail)
                {  
                    objkycdtl.IOU_adjustment_rowid = objIUStock.context.Header.IOU_adjustment_rowid;
                    objkycdtl.In_adjustmentdtl_rowid = Kyc.In_adjustmentdtl_rowid;
                    objkycdtl.In_adjustment_no = Kyc.In_adjustment_no;
                    objkycdtl.In_receipt_ref_doc_no = Kyc.In_receipt_ref_doc_no;
                    objkycdtl.In_ref_doc_date = Kyc.In_ref_doc_date;
                    objkycdtl.In_adjustment_type = Kyc.In_adjustment_type;
                    objkycdtl.In_product_catg_code = Kyc.In_product_catg_code;
                    objkycdtl.In_product_catg_desc = Kyc.In_product_catg_desc;
                    objkycdtl.In_product_subcatg_code = Kyc.In_product_subcatg_code;
                    objkycdtl.In_product_subcatg_desc = Kyc.In_product_subcatg_desc;
                    objkycdtl.In_product_code = Kyc.In_product_code;
                    objkycdtl.In_product_desc = Kyc.In_product_desc;
                    objkycdtl.In_adjustment_qty = Kyc.In_adjustment_qty;
                    objkycdtl.In_uom_type = Kyc.In_uom_type;
                    objkycdtl.In_remarks = Kyc.In_remarks;
                    objkycdtl.In_status_code = Kyc.In_status_code;
                    objkycdtl.In_status_desc = Kyc.In_status_desc; 
                    objkycdtl.In_mode_flag = Kyc.In_mode_flag;
                    objkycdtl.In_out_qty = Kyc.In_out_qty;
                    objkycdtl.In_adj_amt = Kyc.In_adj_amt;                   
                    result = objproduct1.SaveIDCADetailList(objkycdtl, objIUStock, Objmodel, MysqlCons, MysqlCon);
                }
                return result;
            }
            catch (Exception ex)
             {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return result;
            }
        }

        public int SaveIDCADetailList(IUStockADetail ObjKycDtl, IUStockADocument objIUStock, IUStockAApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {

            int ret = 0;
            FFI_Model.ApplicationException objex = new FFI_Model.ApplicationException();
            try
            {
                MySqlCommand cmd = new MySqlCommand("ICDMOB_iud_stockAdjustment_detail", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure; 
                cmd.Parameters.Add("IOU_adjustment_rowid", MySqlDbType.Int32).Value = objIUStock.context.Header.IOU_adjustment_rowid;
                cmd.Parameters.Add("In_adjustmentdtl_rowid", MySqlDbType.Int32).Value = ObjKycDtl.In_adjustmentdtl_rowid;
                cmd.Parameters.Add("In_adjustment_no", MySqlDbType.VarChar).Value = ObjKycDtl.In_adjustment_no.Trim();
                cmd.Parameters.Add("In_receipt_ref_doc_no", MySqlDbType.VarChar).Value = ObjKycDtl.In_receipt_ref_doc_no.Trim(); 
                cmd.Parameters.Add("In_ref_doc_date", MySqlDbType.VarChar).Value = ObjKycDtl.In_ref_doc_date.Trim();
                cmd.Parameters.Add("In_adjustment_type", MySqlDbType.VarChar).Value = ObjKycDtl.In_adjustment_type.Trim();
                cmd.Parameters.Add("In_product_catg_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_product_catg_code.Trim(); 
                cmd.Parameters.Add("In_product_catg_desc", MySqlDbType.LongText).Value = ObjKycDtl.In_product_catg_desc.Trim();
                cmd.Parameters.Add("In_product_subcatg_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_product_subcatg_code.Trim();
                cmd.Parameters.Add("In_product_subcatg_desc", MySqlDbType.LongText).Value = ObjKycDtl.In_product_subcatg_code.Trim();
                cmd.Parameters.Add("In_product_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_product_code.Trim();
                cmd.Parameters.Add("In_product_desc", MySqlDbType.LongText).Value = ObjKycDtl.In_product_desc.Trim();
                cmd.Parameters.Add("In_adjustment_qty", MySqlDbType.Double).Value = ObjKycDtl.In_adjustment_qty;
                cmd.Parameters.Add("In_uom_type", MySqlDbType.VarChar).Value = ObjKycDtl.In_uom_type.Trim(); 
                cmd.Parameters.Add("In_remarks", MySqlDbType.VarChar).Value = ObjKycDtl.In_remarks.Trim();
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_status_code.Trim();
                cmd.Parameters.Add("In_status_desc", MySqlDbType.LongText).Value = ObjKycDtl.In_status_desc.Trim();
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjKycDtl.In_mode_flag.Trim();
                cmd.Parameters.Add("In_out_qty", MySqlDbType.Double).Value = ObjKycDtl.In_out_qty;
                cmd.Parameters.Add("In_adjustment_amount", MySqlDbType.Double).Value = ObjKycDtl.In_adj_amt;               
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId.Trim();
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId.Trim();
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId.Trim();
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId.Trim();
                LogHelper.ConvertCmdIntoString(cmd);
                ret = cmd.ExecuteNonQuery();
                return ret;
            }
            catch (Exception ex)
            {
                objIUStock.ApplicationException.errorDescription = ex.Message;
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return ret;
            }
        }

    }
}
