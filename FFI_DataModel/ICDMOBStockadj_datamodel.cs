using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace FFI_DataModel
{
    public class ICDMOBStockadj_datamodel
    {

        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDMOBStockadj_datamodel)); //Declaring Log4Net. 
        string methodName = MethodBase.GetCurrentMethod().Name;
        public ICDMOBSADocument SaveICDStockAdj(ICDMOBSARoot ObjICDStock, string mysqlcon)
        {
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            ICDMOBSADocument objresICDStock = new ICDMOBSADocument();
            objresICDStock.context = new ICDMOBSAContext();
            objresICDStock.context.Header = new ICDMOBSAHeader();
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
                cmd.Parameters.Add("IOU_adjustment_rowid", MySqlDbType.Int32).Value = Convert.ToInt32(ObjICDStock.document.context.Header.IOU_adjustment_rowid);

                cmd.Parameters.Add(new MySqlParameter("IOU_adjustment_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_adjustment_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                if (ret > 0)
                {
                    objresICDStock.context.Header.IOU_adjustment_rowid = Convert.ToString((Int32)cmd.Parameters["IOU_adjustment_rowid1"].Value);
                    objresICDStock.context.Header.In_adjustment_no = Convert.ToString((string)cmd.Parameters["In_adjustment_no1"].Value);
                }
                if (Convert.ToInt32(objresICDStock.context.Header.IOU_adjustment_rowid) > 0)
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

        public int SaveIDCADetail(ICDMOBSARoot Objmodel, ICDMOBSADocument objIUStock, string MysqlCons, DataConnection MysqlCon)
        {
            int result = 0;
            DataTable tab = new DataTable();
            ICDMOBSADetail objkycdtl = new ICDMOBSADetail();
            try
            {
                ICDMOBStockadj_datamodel objproduct1 = new ICDMOBStockadj_datamodel();
                foreach (var Kyc in Objmodel.document.context.Detail)
                {

                    objkycdtl.In_adjustmentdtl_rowid = Kyc.In_adjustmentdtl_rowid;
                    objkycdtl.In_adjustment_no = Kyc.In_adjustment_no;
                    objkycdtl.In_receipt_ref_doc_no = Kyc.In_receipt_ref_doc_no;
                    objkycdtl.In_ref_doc_date = Kyc.In_ref_doc_date;
                    objkycdtl.In_adjustment_type = Kyc.In_adjustment_type;
                    objkycdtl.In_lrp_name = Kyc.In_lrp_name;
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

        public int SaveIDCADetailList(ICDMOBSADetail ObjKycDtl, ICDMOBSADocument objIUStock, ICDMOBSARoot Objmodel, string mysqlcons, DataConnection MysqlCon)
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
                cmd.Parameters.Add("In_lrp_name", MySqlDbType.VarChar).Value = ObjKycDtl.In_lrp_name.Trim();
                cmd.Parameters.Add("In_product_catg_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_product_catg_code.Trim();
                cmd.Parameters.Add("In_product_catg_desc", MySqlDbType.LongText).Value = ObjKycDtl.In_product_catg_desc.Trim();
                cmd.Parameters.Add("In_product_subcatg_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_product_subcatg_code.Trim();
                cmd.Parameters.Add("In_product_subcatg_desc", MySqlDbType.LongText).Value = ObjKycDtl.In_product_subcatg_code.Trim();
                cmd.Parameters.Add("In_product_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_product_code.Trim();
                cmd.Parameters.Add("In_product_desc", MySqlDbType.LongText).Value = ObjKycDtl.In_product_desc.Trim();
                cmd.Parameters.Add("In_adjustment_qty", MySqlDbType.Double).Value = Convert.ToDouble(ObjKycDtl.In_adjustment_qty);
                cmd.Parameters.Add("In_uom_type", MySqlDbType.VarChar).Value = ObjKycDtl.In_uom_type.Trim();
                cmd.Parameters.Add("In_remarks", MySqlDbType.VarChar).Value = ObjKycDtl.In_remarks.Trim();
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_status_code.Trim();
                cmd.Parameters.Add("In_status_desc", MySqlDbType.LongText).Value = ObjKycDtl.In_status_desc.Trim();
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjKycDtl.In_mode_flag.Trim();
                cmd.Parameters.Add("In_out_qty", MySqlDbType.Double).Value = Convert.ToDouble(ObjKycDtl.In_out_qty);
                cmd.Parameters.Add("In_adjustment_amount", MySqlDbType.Double).Value = Convert.ToDouble(ObjKycDtl.In_adj_amt);
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
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return ret;
            }
        }

        public ICDMOBCRoot1 icdStockadjLRP_DB(string org, string locn, string user, string lang, string In_orgn_code, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            ICDMOBCRoot1 ObjFetchAll = new ICDMOBCRoot1();
            ObjFetchAll.context = new ICDMOBCContext1();
            ObjFetchAll.context.LRPList = new List<IICDMOBSALRPNAMEList>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("ICDMOB_fetch_LRPNamelist", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("In_orgn_code", MySqlDbType.VarChar).Value = In_orgn_code;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IICDMOBSALRPNAMEList objList = new IICDMOBSALRPNAMEList();
                    objList.In_lrp_name = dt.Rows[i]["In_lrp_name"].ToString();
                    ObjFetchAll.context.LRPList.Add(objList);
                }
                ObjFetchAll.context.orgnId = org;
                ObjFetchAll.context.locnId = locn;
                ObjFetchAll.context.userId = user;
                ObjFetchAll.context.localeId = lang;
                ObjFetchAll.context.In_orgn_code = In_orgn_code;
            }
            catch (Exception ex)
            {
                //logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                throw ex;
            }

            return ObjFetchAll;
        }
    }
}
