using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
    public class ICDMOBList_datamodel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDMOBList_datamodel)); //Declaring Log4Net. 

        public ADJCOUNTRoot ICDProduct_List(string org, string locn, string user, string lang, string customer_code, string product_code, string adjustment_type, string adjustment_date ,string mysqlcon)
        {
            DataSet ds = new DataSet();

            MysqlCon = new DataConnection(mysqlcon);

            ADJCOUNTRoot ObjinvRoot = new ADJCOUNTRoot();
            ICDMOBList_datamodel objDataModel = new ICDMOBList_datamodel();

            DataTable Detail = new DataTable();
            DataTable Header = new DataTable();

            ObjinvRoot.context = new ADJCOUNTContext();          
            ObjinvRoot.context.List = new List<ADJCOUNTList>();
            try
            {

                MySqlCommand cmd = new MySqlCommand("ICDMOB_fetch_adjustmentcount", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("In_customer_code", MySqlDbType.VarChar).Value = customer_code;
                cmd.Parameters.Add("In_product_code", MySqlDbType.VarChar).Value = product_code;
                cmd.Parameters.Add("In_adjustment_type", MySqlDbType.VarChar).Value = adjustment_type;
                cmd.Parameters.Add("In_adjustment_date", MySqlDbType.VarChar).Value = adjustment_date;

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
                        ADJCOUNTList objInvpayList = new ADJCOUNTList();
                        objInvpayList.grn_or_invoice_no = Detail.Rows[i]["grn_or_invoice_no"].ToString();
                        objInvpayList.product_code = Detail.Rows[i]["product_code"].ToString();
                        objInvpayList.product_name = Detail.Rows[i]["product_name"].ToString();
                        objInvpayList.adjustment_qty =Convert.ToInt32(Detail.Rows[i]["adjustment_qty"].ToString());
                        objInvpayList.adjusted_qty = Convert.ToInt32(Detail.Rows[i]["adjusted_qty"].ToString());
                        objInvpayList.avl_adjust_qty = Convert.ToInt32(Detail.Rows[i]["avl_adjust_qty"].ToString());
                        objInvpayList.product_price = Detail.Rows[i]["product_price"].ToString();
                        ObjinvRoot.context.List.Add(objInvpayList);
                    }
                }
                ObjinvRoot.context.orgnId = org;
                ObjinvRoot.context.locnId = locn;
                ObjinvRoot.context.userId = user;
                ObjinvRoot.context.localeId = lang;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return ObjinvRoot;
        }
        public ICDMOBSRoot ICD_Supplier_list_DB(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            ICDMOBSRoot ObjFetchAll = new ICDMOBSRoot();
            ObjFetchAll.context = new ICDMOBSContext();
            ObjFetchAll.context.List = new List<ICDMOBSList>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("ICDMOB_fetch_supplier_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value =org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("In_filterby_option", MySqlDbType.VarChar).Value = filterby_option;
                cmd.Parameters.Add("In_filterby_code", MySqlDbType.VarChar).Value = filterby_code;
                cmd.Parameters.Add("In_filterby_fromvalue", MySqlDbType.VarChar).Value = filterby_fromvalue;
                cmd.Parameters.Add("In_filterby_tovalue", MySqlDbType.VarChar).Value = filterby_tovalue;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ICDMOBSList objList = new ICDMOBSList();
                    objList.In_supplier_rowid = Convert.ToInt32(dt.Rows[i]["In_supplier_rowid"]);
                    objList.In_supplier_code = dt.Rows[i]["In_supplier_code"].ToString();
                    objList.In_version_no = Convert.ToInt32(dt.Rows[i]["In_version_no"]);
                    objList.In_supplier_name = dt.Rows[i]["In_supplier_name"].ToString();
                    objList.In_pan_no = dt.Rows[i]["In_pan_no"].ToString();
                    objList.In_supplier_state_code = dt.Rows[i]["In_supplier_state_code"].ToString();
                    objList.In_supplier_state_desc = dt.Rows[i]["In_supplier_state_desc"].ToString();
                    objList.In_supplier_location = dt.Rows[i]["In_supplier_location"].ToString();
                    objList.In_ic_code = dt.Rows[i]["In_ic_code"].ToString();
                    objList.In_status_code = dt.Rows[i]["In_status_code"].ToString();
                    objList.In_row_timestamp = dt.Rows[i]["In_row_timestamp"].ToString();
                    ObjFetchAll.context.List.Add(objList);
                }
                ObjFetchAll.context.orgnId = org;
                ObjFetchAll.context.locnId = locn;
                ObjFetchAll.context.userId = user;
                ObjFetchAll.context.localeId = lang;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }

            return ObjFetchAll;
        }

        public ICDMOBCRoot Customerslist_DB(string org, string locn, string user, string lang, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            ICDMOBCRoot ObjFetchAll = new ICDMOBCRoot();
            ObjFetchAll.context = new ICDMOBCContext();
            ObjFetchAll.context.CustomerList = new List<ICDMOBCustomerList>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("ICDMOB_fetch_customerlist", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;               
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ICDMOBCustomerList objList = new ICDMOBCustomerList();
                    objList.farmer_code = dt.Rows[i]["farmer_code"].ToString();
                    objList.farmer_name = dt.Rows[i]["farmer_name"].ToString();
                    objList.sur_name = dt.Rows[i]["sur_name"].ToString();
                    objList.fhw_name = dt.Rows[i]["fhw_name"].ToString();
                    objList.village_name = dt.Rows[i]["village_name"].ToString();
                    objList.farmer_address = dt.Rows[i]["farmer_address"].ToString();
                    objList.state_name = dt.Rows[i]["state_name"].ToString();
                    objList.farmer_village_code = dt.Rows[i]["farmer_village_code"].ToString();
                    objList.farmer_state_code = dt.Rows[i]["farmer_state_code"].ToString();
                    objList.phone_no = dt.Rows[i]["phone_no"].ToString();
                    objList.ic_code = dt.Rows[i]["ic_code"].ToString();
                    ObjFetchAll.context.CustomerList.Add(objList);
                }
                ObjFetchAll.context.orgnId = org;
                ObjFetchAll.context.locnId = locn;
                ObjFetchAll.context.userId = user;
                ObjFetchAll.context.localeId = lang;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }

            return ObjFetchAll;
        }

        public MasterRootObject allmasterlist_DB(string org, string locn, string user, string lang, string parent_code, string mysqlcon)
        {
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            int j = 0;
            string pc = "";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);
            MasterRootObject ObjFetchAll = new MasterRootObject();
            MasterApplicationException maserror = new MasterApplicationException();
            ObjFetchAll.context = new MasterContext();
            ObjFetchAll.context.detail = new List<MasterDetailItem>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Admin_fetch_master_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("in_orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("in_locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("in_userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("in_localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("in_parent_code", MySqlDbType.VarChar).Value = parent_code;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MasterDetailItem objList = new MasterDetailItem();
                    j = Convert.ToInt32(dt.Rows[i]["out_master_rowid"]);
                    pc = dt.Rows[i]["out_parent_code"].ToString();
                    objList.out_master_rowid = Convert.ToInt32(dt.Rows[i]["out_master_rowid"]);
                    objList.out_parent_code = dt.Rows[i]["out_parent_code"].ToString();
                    objList.out_parent_descripton = dt.Rows[i]["out_parent_descripton"].ToString();
                    objList.out_master_code = dt.Rows[i]["out_master_code"].ToString();
                    objList.out_master_description = dt.Rows[i]["out_master_description"].ToString();
                    objList.out_master_ll_description = dt.Rows[i]["out_master_ll_description"].ToString();
                    objList.out_depend_desc = dt.Rows[i]["out_depend_desc"].ToString();
                    objList.out_status_desc = dt.Rows[i]["out_status_desc"].ToString();

                    ObjFetchAll.context.detail.Add(objList);
                }
                ObjFetchAll.context.orgnId =org;
                ObjFetchAll.context.locnId = locn;
                ObjFetchAll.context.userId = user;
                ObjFetchAll.context.localeId = lang;
            }
            catch (Exception ex)
            {
                //maserror.errorDescription = j + " - " + pc + " - " + ex.Message.ToString();
                //ObjFetchAll.ApplicationException = maserror;
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }

            return ObjFetchAll;
        }
        public ICDMOBTRoot geticdtransactionlist_DB(string org, string locn, string user, string lang, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            ICDMOBTRoot ObjFetchAll = new ICDMOBTRoot();
            ObjFetchAll.context = new ICDMOBTContext();
         
            try
            {
                MySqlCommand cmd = new MySqlCommand("ICDMOB_transaction", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add(new MySqlParameter("In_inward_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_invoice_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_adjustment_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_ic_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                ICDMOBTHeader objHeader = new ICDMOBTHeader();
                objHeader.In_inward_no = (string)cmd.Parameters["In_inward_no"].Value.ToString();
                objHeader.In_invoice_no = (string)cmd.Parameters["In_invoice_no"].Value.ToString();
                objHeader.In_adjustment_no = (string)cmd.Parameters["In_adjustment_no"].Value.ToString();
                objHeader.In_ic_code = (string)cmd.Parameters["In_ic_code"].Value.ToString();
                ObjFetchAll.context.Header = objHeader;
                ObjFetchAll.context.orgnId = org;
                ObjFetchAll.context.locnId = locn;
                ObjFetchAll.context.userId = user;
                ObjFetchAll.context.localeId = lang;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }

            return ObjFetchAll;
        }
    }
}
