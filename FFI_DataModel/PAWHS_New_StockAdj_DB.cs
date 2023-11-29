using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FFI_Model;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Reflection;

namespace FFI_DataModel
{
    public class PAWHS_New_StockAdj_DB
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHS_New_StockAdj_DB)); //Declaring Log4Net. 
        string methodName = "";
        public StockRootObject GetAllStockDtls(StockContext ObjModel, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataTable dt = new DataTable();
            StockRootObject ObjModelRoot = new StockRootObject();
            PAWHS_New_StockAdj_DB objDataModel = new PAWHS_New_StockAdj_DB();

            ObjModelRoot.context = new StockContext();
            ObjModelRoot.context.List = new List<StockLIst>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("New_PAWHS_StockAdjustment_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjModel.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjModel.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjModel.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjModel.localeId;
                cmd.Parameters.Add("in_filterby_option", MySqlDbType.VarChar).Value = ObjModel.FilterBy_Option;
                cmd.Parameters.Add("in_filterby_code", MySqlDbType.VarChar).Value = ObjModel.FilterBy_Code;
                cmd.Parameters.Add("in_filterby_fromvalue", MySqlDbType.VarChar).Value = ObjModel.FilterBy_FromValue;
                cmd.Parameters.Add("in_filterby_tovalue", MySqlDbType.VarChar).Value = ObjModel.FilterBy_ToValue;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    StockLIst objList = new StockLIst();
                    objList.Out_adjustment_rowid = Convert.ToInt32(dt.Rows[i]["Out_adjustment_rowid"]);
                    objList.Out_agg_code = dt.Rows[i]["Out_agg_code"].ToString();
                    objList.Out_adjustment_no = dt.Rows[i]["Out_adjustment_no"].ToString();
                    objList.Out_adjustment_date = dt.Rows[i]["Out_adjustment_date"].ToString();
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.Out_status_desc = dt.Rows[i]["Out_status_desc"].ToString();
                    ObjModelRoot.context.List.Add(objList);
                }
                ObjModelRoot.context.orgnId = ObjModel.orgnId;
                ObjModelRoot.context.locnId = ObjModel.locnId;
                ObjModelRoot.context.localeId = ObjModel.localeId;
                ObjModelRoot.context.userId = ObjModel.userId;
                ObjModelRoot.context.FilterBy_Code = ObjModel.FilterBy_Code;
                ObjModelRoot.context.FilterBy_FromValue = ObjModel.FilterBy_FromValue;
                ObjModelRoot.context.FilterBy_Option = ObjModel.FilterBy_Option;
                ObjModelRoot.context.FilterBy_ToValue = ObjModel.FilterBy_ToValue;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjModelRoot.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjModelRoot;
        }

        public PAWHSStock_Save_Document SaveStockDetails(PAWHSStock_Save_Application ObjStoclDtls, string mysqlcon)
        {
            string[] response = { };
            PAWHSStock_Save_Document ObjFetch = new PAWHSStock_Save_Document();
            // Exception Log Method Name Purpose written start 
            methodName = MethodBase.GetCurrentMethod().Name;
            try
            {
                int ret = 0;
                int retdtls = 0;
                MysqlCon = new DataConnection(mysqlcon);
                ObjFetch.ApplicationException = new StockApplicationException();
                ObjFetch.context = new PAWHSStock_Save_Context();
                ObjFetch.context.Header = new PAWHSStock_Save_Header();
                ObjFetch.context.QtyDetail = new List<PAWHSStock_Save_PODetail>();

                ObjFetch.context.orgnId = ObjStoclDtls.document.context.orgnId;
                ObjFetch.context.localeId = ObjStoclDtls.document.context.localeId;
                ObjFetch.context.locnId = ObjStoclDtls.document.context.locnId;
                ObjFetch.context.userId = ObjStoclDtls.document.context.userId;

                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                MySqlCommand cmd = new MySqlCommand("New_PAWHS_Insupd_StockAdjustment", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_adjustment_rowid", MySqlDbType.Int32).Value = ObjStoclDtls.document.context.Header.In_adjustment_rowid;
                cmd.Parameters.Add("In_agg_code", MySqlDbType.VarChar).Value = ObjStoclDtls.document.context.Header.In_agg_code;
                cmd.Parameters.Add("In_adjustment_no", MySqlDbType.VarChar).Value = ObjStoclDtls.document.context.Header.In_adjustment_no;
                cmd.Parameters.Add("In_adjustment_date", MySqlDbType.VarChar).Value = ObjStoclDtls.document.context.Header.In_adjustment_date;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjStoclDtls.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_process_status", MySqlDbType.VarChar).Value = ObjStoclDtls.document.context.Header.In_process_status;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = ObjStoclDtls.document.context.Header.in_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjStoclDtls.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjStoclDtls.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjStoclDtls.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjStoclDtls.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("IOU_adjustment_rowid", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_adjustment_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_ErroNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                if (ret > 0)
                {
                    ObjFetch.context.Header.IOU_adjustment_rowid = (Int32)cmd.Parameters["IOU_adjustment_rowid"].Value;
                    ObjFetch.context.Header.IOU_adjustment_no = (string)cmd.Parameters["IOU_adjustment_no"].Value;
                    ObjFetch.context.Header.IOU_ErroNo = (string)cmd.Parameters["IOU_ErroNo"].Value;
                }
                bool isvaild = true;
                if (ObjFetch.context.Header.IOU_ErroNo != "")
                {
                    isvaild = false;
                    mysqltrans.Rollback();
                    ObjFetch.ApplicationException.errorNumber = ObjFetch.context.Header.IOU_ErroNo;
                    ObjFetch.ApplicationException.errorDescription = ObjErrormsg.ErrorMessage(ObjFetch.context.Header.IOU_ErroNo);
                    return ObjFetch;
                }

                if (ObjFetch.context.Header.IOU_adjustment_rowid > 0)
                {
                    foreach (var Details in ObjStoclDtls.document.context.QtyDetail)
                    {
                        MySqlCommand cmds = new MySqlCommand("New_PAWHS_Iud_StockAdjustment", MysqlCon.con);
                        cmds.CommandType = CommandType.StoredProcedure;
                        cmds.Parameters.Add("IOU_adjustment_rowid", MySqlDbType.Int32).Value = ObjFetch.context.Header.IOU_adjustment_rowid;
                        cmds.Parameters.Add("IOU_adjustment_no", MySqlDbType.VarChar).Value = ObjFetch.context.Header.IOU_adjustment_no;
                        cmds.Parameters.Add("In_adjustmentdtl_rowid", MySqlDbType.VarChar).Value = Details.In_adjustmentdtl_rowid;
                        cmds.Parameters.Add("In_receipt_ref_doc_no", MySqlDbType.VarChar).Value = Details.In_receipt_ref_doc_no;
                        cmds.Parameters.Add("In_ref_doc_date", MySqlDbType.VarChar).Value = Details.In_ref_doc_date;
                        cmds.Parameters.Add("In_adjustment_type", MySqlDbType.VarChar).Value = Details.In_adjustment_type;
                        cmds.Parameters.Add("In_product_catg_code", MySqlDbType.VarChar).Value = Details.In_product_catg_code;
                        cmds.Parameters.Add("In_product_catg_desc", MySqlDbType.VarChar).Value = Details.In_product_catg_desc;
                        cmds.Parameters.Add("In_product_subcatg_code", MySqlDbType.VarChar).Value = Details.In_product_subcatg_code;
                        cmds.Parameters.Add("In_product_subcatg_desc", MySqlDbType.VarChar).Value = Details.In_product_subcatg_desc;
                        cmds.Parameters.Add("In_product_code", MySqlDbType.VarChar).Value = Details.In_product_code;
                        cmds.Parameters.Add("In_adjustment_qty", MySqlDbType.Double).Value = Details.In_adjustment_qty;
                        cmds.Parameters.Add("In_uom_type", MySqlDbType.VarChar).Value = Details.In_uom_type;
                        cmds.Parameters.Add("In_remarks", MySqlDbType.VarChar).Value = Details.In_remarks;
                        cmds.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = Details.In_status_code;
                        cmds.Parameters.Add("In_status_desc", MySqlDbType.VarChar).Value = Details.In_status_desc;
                        cmds.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Details.In_mode_flag;
                        cmds.Parameters.Add("In_out_qty", MySqlDbType.Double).Value = Details.In_out_qty;
                        cmds.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjStoclDtls.document.context.orgnId;
                        cmds.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjStoclDtls.document.context.locnId;
                        cmds.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjStoclDtls.document.context.userId;
                        cmds.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjStoclDtls.document.context.localeId;
                        retdtls = cmds.ExecuteNonQuery();
                        LogHelper.ConvertCmdIntoString(cmds);
                        if (retdtls == 0)
                        {
                            mysqltrans.Rollback();
                            isvaild = false;
                            break;
                        }
                    }
                    if (isvaild == true)
                    {
                        mysqltrans.Commit();
                    }

                }
                else
                {
                    mysqltrans.Rollback();
                }
                if (MysqlCon.con.State == ConnectionState.Open)
                {
                    MysqlCon.con.Close();
                }
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                logger.Error("USERNAME :" + ObjFetch.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }

        public PAWHSStockFetchApplication Single_FetchStock(PAWHSStock_FetchContext objfpoSearch, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataSet ds = new DataSet();
            PAWHSStockFetchApplication objfpoSearchRoot = new PAWHSStockFetchApplication();
            DataTable QtyDt = new DataTable();
            objfpoSearchRoot.context = new PAWHSStock_FetchContext();
            objfpoSearchRoot.context.Header = new PAWHSStock_FetchHeader();
            objfpoSearchRoot.context.QtyDetail = new List<PAWHSStock_Fetch_QtyDetail>();
            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_Fetch_StockAdjustment", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;
                cmd.Parameters.Add("IOU_adjustment_rowid", MySqlDbType.Int32).Value = objfpoSearch.IOU_adjustment_rowid;
                cmd.Parameters.Add("IOU_agg_code", MySqlDbType.VarChar).Value = objfpoSearch.IOU_agg_code;
                cmd.Parameters.Add("IOU_adjustment_no", MySqlDbType.VarChar).Value = objfpoSearch.IOU_adjustment_no;
                cmd.Parameters.Add(new MySqlParameter("In_agg_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_adjustment_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_adjustment_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_process_status", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_adjustment_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                LogHelper.ConvertCmdIntoString(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();
                if (ds.Tables.Count > 0)
                {
                    QtyDt = ds.Tables[0];
                    for (int i = 0; i < QtyDt.Rows.Count; i++)
                    {
                        PAWHSStock_Fetch_QtyDetail objQtyDetail = new PAWHSStock_Fetch_QtyDetail();
                        objQtyDetail.In_adjustmentdtl_rowid = Convert.ToInt32(QtyDt.Rows[i]["In_adjustmentdtl_rowid"]);
                        objQtyDetail.In_adjustment_no = QtyDt.Rows[i]["In_adjustment_no"].ToString();
                        objQtyDetail.In_receipt_ref_doc_no = QtyDt.Rows[i]["In_ref_doc_no"].ToString();
                        objQtyDetail.In_ref_doc_date = QtyDt.Rows[i]["In_ref_doc_date"].ToString();
                        objQtyDetail.In_adjustment_type = QtyDt.Rows[i]["In_adjustment_type"].ToString();
                        objQtyDetail.In_adjustment_desc = QtyDt.Rows[i]["In_adjustment_desc"].ToString();
                        objQtyDetail.In_product_catg_code = QtyDt.Rows[i]["In_product_catg_code"].ToString();
                        objQtyDetail.In_product_catg_desc = QtyDt.Rows[i]["In_product_catg_desc"].ToString ();
                        objQtyDetail.In_product_subcatg_code = QtyDt.Rows[i]["In_product_subcatg_code"].ToString();
                        objQtyDetail.In_product_subcatg_desc = QtyDt.Rows[i]["In_product_subcatg_desc"].ToString();
                        objQtyDetail.In_product_code =QtyDt.Rows[i]["In_product_code"].ToString();
                        objQtyDetail.In_product_desc= QtyDt.Rows[i]["In_product_desc"].ToString();
                        objQtyDetail.In_uom_type = QtyDt.Rows[i]["In_uom_code"].ToString();
                        objQtyDetail.In_uom_type_desc = QtyDt.Rows[i]["In_uom_code"].ToString();
                        objQtyDetail.In_adjustment_qty = Convert.ToDouble(QtyDt.Rows[i]["In_adjustment_qty"]);
                        objQtyDetail.In_remarks = QtyDt.Rows[i]["In_remarks"].ToString();
                        objQtyDetail.In_status_desc = QtyDt.Rows[i]["In_status_desc"].ToString();
                        objQtyDetail.In_mode_flag = QtyDt.Rows[i]["In_mode_flag"].ToString();
                        objQtyDetail.In_out_qty = Convert.ToDouble(QtyDt.Rows[i]["In_out_qty"]);
                        objfpoSearchRoot.context.QtyDetail.Add(objQtyDetail);
                    }
                    objfpoSearchRoot.context.orgnId = objfpoSearch.orgnId;
                    objfpoSearchRoot.context.locnId = objfpoSearch.locnId;
                    objfpoSearchRoot.context.userId = objfpoSearch.userId;
                    objfpoSearchRoot.context.localeId = objfpoSearch.localeId;
                    objfpoSearchRoot.context.IOU_adjustment_rowid = objfpoSearch.IOU_adjustment_rowid;
                    objfpoSearchRoot.context.IOU_agg_code = objfpoSearch.IOU_agg_code;
                    objfpoSearchRoot.context.IOU_adjustment_no = objfpoSearch.IOU_adjustment_no;
                    objfpoSearchRoot.context.Header.In_agg_code = (string)cmd.Parameters["In_agg_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_adjustment_no = (string)cmd.Parameters["In_adjustment_no"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_adjustment_date = (string)cmd.Parameters["In_adjustment_date"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_process_status = (string)cmd.Parameters["In_process_status"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                    objfpoSearchRoot.context.Header.IOU_adjustment_rowid1 = (Int32)cmd.Parameters["IOU_adjustment_rowid1"].Value;
                }
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objfpoSearchRoot.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return objfpoSearchRoot;

        }
    }
}
