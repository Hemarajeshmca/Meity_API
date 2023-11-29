using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using FFI_Model;
using System.Linq;

namespace FFI_DataModel
{
    public class ICDProduct_DB
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDProduct_DB));
        // Exception Log Method Name Purpose written start 
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public ICDProductApplication ICDProduct_List(ICDProductContext ObjContext, string mysqlcon)
        {


            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);
            ICDProductApplication ObjFetchAll = new ICDProductApplication();
            ObjFetchAll.context = new ICDProductContext();
            ObjFetchAll.context.List = new List<ICDProductList>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("fetch_product_list", MysqlCon.con);
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
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ICDProductList objList = new ICDProductList();
                    objList.Out_product_rowid = Convert.ToInt32(dt.Rows[i]["Out_product_rowid"]);
                    objList.Out_product_catg_code = dt.Rows[i]["Out_product_catg_code"].ToString();
                    objList.Out_product_catg_desc = dt.Rows[i]["Out_product_catg_desc"].ToString();
                    objList.Out_product_subcatg_code = dt.Rows[i]["Out_product_subcatg_code"].ToString();
                    objList.Out_product_subcatg_desc = dt.Rows[i]["Out_product_subcatg_desc"].ToString();
                    objList.Out_product_code = dt.Rows[i]["Out_product_code"].ToString();
                    objList.Out_product_name = dt.Rows[i]["Out_product_name"].ToString();
                    objList.Out_product_tax_verified = dt.Rows[i]["Out_product_tax_verified"].ToString();
                    objList.Out_gstrate_verified = dt.Rows[i]["Out_gstrate_verified"].ToString();
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.Out_status_desc = dt.Rows[i]["Out_status_desc"].ToString();
                    objList.Out_base_price = dt.Rows[i]["Out_base_price"].ToString();
                    objList.Out_ic_name = dt.Rows[i]["Out_ic_name"].ToString();

                    ObjFetchAll.context.List.Add(objList);
                }
                ObjFetchAll.context.orgnId = ObjContext.orgnId;
                ObjFetchAll.context.locnId = ObjContext.locnId;
                ObjFetchAll.context.userId = ObjContext.userId;
                ObjFetchAll.context.localeId = ObjContext.localeId;
            }
            catch (Exception ex)
            {
                // throw ex;
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetchAll;
        }
        public ICDProduct_FApplication ICDProduct_SingleFetch(ICDProduct_FContext objfpoSearch, string mysqlcon)
        {
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            DataSet ds = new DataSet();
            ICDProduct_FApplication objfpoSearchRoot = new ICDProduct_FApplication();
            DataTable Map = new DataTable();
            DataTable OtherDt = new DataTable();
            DataTable SlnoDt = new DataTable();
            objfpoSearchRoot.context = new ICDProduct_FContext();
            objfpoSearchRoot.context.Detail = new ICDProduct_Detail();
            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("fetch_product", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;
                cmd.Parameters.Add("IOU_product_rowid", MySqlDbType.Int32).Value = objfpoSearch.product_rowid;

                //Information Log Purpose Written Start 
                //  logger.Debug("SP Name  - fetch_product");
                //  logger.Debug("Input Parameters" + objfpoSearch.orgnId + "," + objfpoSearch.locnId + "," + objfpoSearch.userId + "," + objfpoSearch.localeId + "," + objfpoSearch.product_rowid);

                cmd.Parameters.Add(new MySqlParameter("In_orgn_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_ic_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_ic_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_taxrate_rowid", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_product_catg_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_product_catg_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_product_subcatg_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_product_subcatg_desc", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_product_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_product_name", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_hsn_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_hsn_description", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_base_price", MySqlDbType.Float)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_base_price_extax", MySqlDbType.Float)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_base_price_intax", MySqlDbType.Float)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_product_tax_verified", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_value_addproduct_verified", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_GSTRATE_verified", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_current_qty", MySqlDbType.Float)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_uomtype_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_uomtype_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_effective_from", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_effective_to", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_product_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                objfpoSearchRoot.context.orgnId = objfpoSearch.orgnId;
                objfpoSearchRoot.context.locnId = objfpoSearch.locnId;
                objfpoSearchRoot.context.userId = objfpoSearch.userId;
                objfpoSearchRoot.context.localeId = objfpoSearch.localeId;
                objfpoSearchRoot.context.product_rowid = (Int32)cmd.Parameters["IOU_product_rowid1"].Value;
                objfpoSearchRoot.context.Detail.IOU_product_rowid = (Int32)cmd.Parameters["IOU_product_rowid1"].Value;
                objfpoSearchRoot.context.Detail.In_ic_code = cmd.Parameters["In_ic_code"].Value.ToString();
                objfpoSearchRoot.context.Detail.In_orgn_code = (string)cmd.Parameters["In_orgn_code"].Value.ToString();
                objfpoSearchRoot.context.Detail.In_ic_name = (string)cmd.Parameters["In_ic_name"].Value.ToString();
                objfpoSearchRoot.context.Detail.In_taxrate_rowid = (Int32)cmd.Parameters["In_taxrate_rowid"].Value;
                objfpoSearchRoot.context.Detail.In_product_catg_code = (string)cmd.Parameters["In_product_catg_code"].Value.ToString();
                objfpoSearchRoot.context.Detail.In_product_catg_desc = (string)cmd.Parameters["In_product_catg_desc"].Value.ToString();
                objfpoSearchRoot.context.Detail.In_product_subcatg_code = (string)cmd.Parameters["In_product_subcatg_code"].Value.ToString();
                objfpoSearchRoot.context.Detail.In_product_subcatg_desc = (string)cmd.Parameters["In_product_subcatg_desc"].Value.ToString();
                objfpoSearchRoot.context.Detail.In_product_code = (string)cmd.Parameters["In_product_code"].Value.ToString();
                objfpoSearchRoot.context.Detail.In_product_name = (string)cmd.Parameters["In_product_name"].Value.ToString();
                objfpoSearchRoot.context.Detail.In_hsn_code = (string)cmd.Parameters["In_hsn_code"].Value.ToString();
                objfpoSearchRoot.context.Detail.In_hsn_description = (string)cmd.Parameters["In_hsn_description"].Value.ToString();
                objfpoSearchRoot.context.Detail.In_base_price = (float)cmd.Parameters["In_base_price"].Value;
                objfpoSearchRoot.context.Detail.In_base_price_extax = (float)cmd.Parameters["In_base_price_extax"].Value;
                objfpoSearchRoot.context.Detail.In_base_price_intax = (float)cmd.Parameters["In_base_price_intax"].Value;
                objfpoSearchRoot.context.Detail.In_productwithtax = (string)cmd.Parameters["In_product_tax_verified"].Value.ToString();
                objfpoSearchRoot.context.Detail.In_valuewithtax = (string)cmd.Parameters["In_value_addproduct_verified"].Value.ToString();
                objfpoSearchRoot.context.Detail.In_gstrate = (string)cmd.Parameters["In_GSTRATE_verified"].Value.ToString();
                objfpoSearchRoot.context.Detail.In_current_qty = (float)cmd.Parameters["In_current_qty"].Value;
                objfpoSearchRoot.context.Detail.In_uomtype_code = (string)cmd.Parameters["In_uomtype_code"].Value.ToString();
                objfpoSearchRoot.context.Detail.In_uomtype_desc = (string)cmd.Parameters["In_uomtype_desc"].Value.ToString();
                objfpoSearchRoot.context.Detail.In_effective_from = (string)cmd.Parameters["In_effective_from"].Value.ToString();
                objfpoSearchRoot.context.Detail.In_effective_to = (string)cmd.Parameters["In_effective_to"].Value.ToString();
                objfpoSearchRoot.context.Detail.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                objfpoSearchRoot.context.Detail.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                objfpoSearchRoot.context.Detail.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();
                objfpoSearchRoot.context.Detail.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();

                //Information Log Purpose Written Start 
                // string Reponse = LogHelper.ConvertObjectIntoString(objfpoSearchRoot.context.Detail);
                //logger.Debug("Output Parameters -" + Reponse);

                MysqlCon.con.Close();
                //MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                //da.Fill(ds);
                //MysqlCon.con.Close();
                //if (ds.Tables.Count > 0)
                //{  

                //}
            }
            catch (Exception ex)
            {
                MysqlCon.con.Close();
                // throw ex;
                logger.Error("USERNAME :" + objfpoSearch.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objfpoSearchRoot;
        }

        public ICDProduct_Document ICDProduct_Save(ICDProduct_SApplication ObjICDSupplier, string mysqlcon)
        {

            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End


            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            ICDProduct_Document ObjresICDSupplier = new ICDProduct_Document();
            ObjresICDSupplier.ApplicationException = new ICDProductSAApplicationException();
            ObjresICDSupplier.context = new ICDProduct_SContext();
            ObjresICDSupplier.context.Detail = new ICDProduct_SDetail();
            try
            {
                int ret = 0;
                string errorNo = "";
                string errorMsg = "";
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }
                MySqlCommand cmd = new MySqlCommand("iud_product_detail", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("IOU_product_rowid", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Detail.IOU_product_rowid;// ObjFarmer.document.context.Header.in_farmer_rowid;
                cmd.Parameters.Add("In_orgn_code", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Detail.In_orgn_code;
                cmd.Parameters.Add("In_ic_code", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Detail.In_ic_code;
                cmd.Parameters.Add("In_taxrate_rowid", MySqlDbType.Int32).Value = (Int32)ObjICDSupplier.document.context.Detail.In_taxrate_rowid;
                cmd.Parameters.Add("In_product_catg_code", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Detail.In_product_catg_code;
                cmd.Parameters.Add("In_product_subcatg_code", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Detail.In_product_subcatg_code;
                cmd.Parameters.Add("In_product_code", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Detail.In_product_code;
                cmd.Parameters.Add("In_current_product", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Detail.In_current_product;
                cmd.Parameters.Add("In_hsn_code", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Detail.In_hsn_code;
                cmd.Parameters.Add("In_hsn_description", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Detail.In_hsn_description;
                cmd.Parameters.Add("In_base_price", MySqlDbType.Float).Value = Convert.ToDecimal(ObjICDSupplier.document.context.Detail.In_base_price);
                cmd.Parameters.Add("In_base_price_extax", MySqlDbType.Float).Value = Convert.ToDecimal(ObjICDSupplier.document.context.Detail.In_base_price_extax);
                cmd.Parameters.Add("In_base_price_intax", MySqlDbType.Float).Value = Convert.ToDecimal(ObjICDSupplier.document.context.Detail.In_base_price_intax);
                cmd.Parameters.Add("In_product_tax_verified", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Detail.In_productwithtax;
                cmd.Parameters.Add("In_value_addproduct_verified", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Detail.In_valuewithtax;
                cmd.Parameters.Add("In_current_qty", MySqlDbType.Float).Value = Convert.ToDecimal(ObjICDSupplier.document.context.Detail.In_current_qty);
                cmd.Parameters.Add("In_GSTRATE_verified", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Detail.In_gstrate; 
                cmd.Parameters.Add("In_uomtype_code", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Detail.In_uomtype_code;
                cmd.Parameters.Add("In_effective_from", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Detail.In_effective_from;
                cmd.Parameters.Add("In_effective_to", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Detail.In_effective_to;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Detail.In_status_code;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Detail.In_row_timestamp;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Detail.In_mode_flag;
                cmd.Parameters.Add("In_product_name", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Detail.In_product_name;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("IOU_product_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_product_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                if (ret > 0)
                {
                    ObjresICDSupplier.context.Detail.IOU_product_rowid = (Int32)cmd.Parameters["IOU_product_rowid1"].Value;

                    ObjresICDSupplier.context.Detail.IOU_product_rowid = (Int32)cmd.Parameters["IOU_product_rowid1"].Value;
                    mysqltrans.Commit();
                    return ObjresICDSupplier;
                }
                else
                {
                    ObjresICDSupplier.context.Detail.errorNo = (string)cmd.Parameters["errorNo"].Value;
                    errorNo = (string)cmd.Parameters["errorNo"].Value;
                    errorMsg = errorNo;
                    ObjresICDSupplier.ApplicationException.errorNumber = errorNo;
                    ObjresICDSupplier.ApplicationException.errorDescription = errorMsg;
                    mysqltrans.Rollback();
                    return ObjresICDSupplier;
                }
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                // throw ex;
                logger.Error("USERNAME :" + ObjICDSupplier.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjresICDSupplier;
        }

    }
}
