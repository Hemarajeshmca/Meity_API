using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using FFI_Model;
namespace FFI_DataModel
{
    public class ICDInputCenter_DB
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        Admin_ErrorMessageModel ObjErrormsg = new Admin_ErrorMessageModel();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInputCenter_DB));
        // Exception Log Method Name Purpose written start 
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public ICDInputApplication ICDInputCenter_List(ICDInputContext ObjContext, string mysqlcon)
        {
            int j = 0;
            string pc = "";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);
            ICDInputApplication ObjFetchAll = new ICDInputApplication();
            //    MasterApplicationException maserror = new MasterApplicationException();
            ObjFetchAll.context = new ICDInputContext();
            ObjFetchAll.context.List = new List<ICDInputList>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Admin_fetch_input_center_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("in_orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("in_locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("in_userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("in_localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
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
                    ICDInputList objList = new ICDInputList();
                    objList.Out_ic_rowid = Convert.ToInt32(dt.Rows[i]["Out_ic_rowid"]);
                    objList.Out_ic_code = dt.Rows[i]["Out_ic_code"].ToString();
                    objList.Out_ic_name = dt.Rows[i]["Out_ic_name"].ToString();
                    objList.Out_orgn_code = dt.Rows[i]["Out_orgn_code"].ToString();
                    objList.Out_version_no = Convert.ToInt32(dt.Rows[i]["Out_version_no"]);
                    objList.Out_orgn_cin = dt.Rows[i]["Out_orgn_cin"].ToString();
                    objList.Out_primary_lang_code = dt.Rows[i]["Out_primary_lang_code"].ToString();
                    objList.Out_parent_code = dt.Rows[i]["Out_parent_code"].ToString();

                    objList.Out_orgn_name = dt.Rows[i]["Out_orgn_name"].ToString();
                    objList.Out_orgn_ll_name = dt.Rows[i]["Out_orgn_ll_name"].ToString();
                    objList.Out_orgn_level = dt.Rows[i]["Out_orgn_level"].ToString();
                    objList.Out_orgn_level_desc = dt.Rows[i]["Out_orgn_level_desc"].ToString();
                    objList.Out_orgn_type = dt.Rows[i]["Out_orgn_type"].ToString();
                    objList.Out_orgn_type_desc = dt.Rows[i]["Out_orgn_type_desc"].ToString();
                    objList.Out_orgn_subtype = dt.Rows[i]["Out_orgn_subtype"].ToString();
                    objList.Out_orgn_subtype_desc = dt.Rows[i]["Out_orgn_subtype_desc"].ToString();
                    objList.Out_secondary_lang_code = dt.Rows[i]["Out_secondary_lang_code"].ToString();

                    objList.Out_orgn_logo = dt.Rows[i]["Out_orgn_logo"].ToString();
                    objList.Out_orgn_auth_sign = dt.Rows[i]["Out_orgn_auth_sign"].ToString();
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.Out_status_desc = dt.Rows[i]["Out_status_desc"].ToString();
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
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }

            return ObjFetchAll;
        }

        public ICDInputCenter_FApplication ICDInputCenter_SingleFetch(ICDInputCenter_FContext objfpoSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();

            DataTable add = new DataTable();
            DataTable bank = new DataTable();
            DataTable user = new DataTable();

            ICDInputCenter_FApplication objfpoSearchRoot = new ICDInputCenter_FApplication();

            objfpoSearchRoot.context = new ICDInputCenter_FContext();
            objfpoSearchRoot.context.Header = new ICDInputCenter_FHeader();
            objfpoSearchRoot.context.Address = new List<ICDInputCenter_FAddress>();
            objfpoSearchRoot.context.Bank = new List<ICDInputCenter_FBank>();
            objfpoSearchRoot.context.User = new List<ICDInputCenter_FUser>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("Admin_fetch_input_Center", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;
                cmd.Parameters.Add("IOU_ic_rowid", MySqlDbType.VarChar).Value = objfpoSearch.ic_rowid;
                cmd.Parameters.Add("IOU_orgn_code", MySqlDbType.VarChar).Value = objfpoSearch.orgn_code;
                cmd.Parameters.Add("IOU_version_no", MySqlDbType.VarChar).Value = objfpoSearch.version_no;

                cmd.Parameters.Add(new MySqlParameter("IOU_ic_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_orgn_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_version_no1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_orgn_cin", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_parent_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_orgn_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_orgn_ll_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_orgn_level", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_orgn_level_desc", MySqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_orgn_type", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_orgn_type_desc", MySqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_orgn_subtype", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_orgn_subtype_desc", MySqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_primary_lang_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_secondary_lang_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.Text)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_ic_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_ic_type", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_ic_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_fpo_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();
                objfpoSearchRoot.context.Header.IOU_orgn_rowid = (Int32)cmd.Parameters["IOU_ic_rowid1"].Value;
                objfpoSearchRoot.context.Header.IOU_orgn_code = (string)cmd.Parameters["IOU_orgn_code1"].Value.ToString();
                objfpoSearchRoot.context.Header.IOU_version_no = (Int32)cmd.Parameters["IOU_version_no1"].Value;
                objfpoSearchRoot.context.Header.In_orgn_cin = (string)cmd.Parameters["In_orgn_cin"].Value.ToString();
                objfpoSearchRoot.context.Header.In_parent_code = (string)cmd.Parameters["In_parent_code"].Value.ToString();
                objfpoSearchRoot.context.Header.In_orgn_name = (string)cmd.Parameters["In_orgn_name"].Value.ToString();
                objfpoSearchRoot.context.Header.In_orgn_ll_name = (string)cmd.Parameters["In_orgn_ll_name"].Value.ToString();
                objfpoSearchRoot.context.Header.In_orgn_level = (string)cmd.Parameters["In_orgn_level"].Value.ToString();
                objfpoSearchRoot.context.Header.In_orgn_level_desc = (string)cmd.Parameters["In_orgn_level_desc"].Value.ToString();
                objfpoSearchRoot.context.Header.In_orgn_type = (string)cmd.Parameters["In_orgn_type"].Value.ToString();
                objfpoSearchRoot.context.Header.In_orgn_type_desc = (string)cmd.Parameters["In_orgn_type_desc"].Value.ToString();
                objfpoSearchRoot.context.Header.In_orgn_subtype = (string)cmd.Parameters["In_orgn_subtype"].Value.ToString();
                objfpoSearchRoot.context.Header.In_orgn_subtype_desc = (string)cmd.Parameters["In_orgn_subtype_desc"].Value.ToString();
                objfpoSearchRoot.context.Header.In_primary_lang_code = (string)cmd.Parameters["In_primary_lang_code"].Value.ToString();
                objfpoSearchRoot.context.Header.In_secondary_lang_code = (string)cmd.Parameters["In_secondary_lang_code"].Value.ToString();
                objfpoSearchRoot.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                objfpoSearchRoot.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                objfpoSearchRoot.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                objfpoSearchRoot.context.Header.In_ic_code = (string)cmd.Parameters["In_ic_code"].Value.ToString();
                objfpoSearchRoot.context.Header.In_ic_type = (string)cmd.Parameters["In_ic_type"].Value.ToString();
                objfpoSearchRoot.context.Header.In_ic_name = (string)cmd.Parameters["In_ic_name"].Value.ToString();
                objfpoSearchRoot.context.Header.In_fpo_name = (string)cmd.Parameters["In_fpo_name"].Value.ToString();


                if (ds.Tables.Count > 0)
                {
                    for (int j = 0; j < ds.Tables.Count; j++)
                    {
                        add = ds.Tables[j];
                        if (add.Columns[0].ColumnName == "Address")
                        {
                            for (int i = 0; i < add.Rows.Count; i++)
                            {
                                ICDInputCenter_FAddress objList = new ICDInputCenter_FAddress();
                                objList.In_orgnaddr_rowid = Convert.ToInt32(add.Rows[i]["In_orgnaddr_rowid"]);
                                objList.In_addr_type = add.Rows[i]["In_addr_type"].ToString();
                                objList.In_addr_type_desc = add.Rows[i]["In_addr_type_desc"].ToString();
                                objList.In_orgn_add1 = add.Rows[i]["In_orgn_add1"].ToString();
                                objList.In_orgn_addr2 = add.Rows[i]["In_orgn_addr2"].ToString();
                                objList.In_orgn_country = add.Rows[i]["In_orgn_country"].ToString();
                                objList.In_orgn_country_desc = add.Rows[i]["In_orgn_country_desc"].ToString();
                                objList.In_orgn_state = add.Rows[i]["In_orgn_state"].ToString();
                                objList.In_orgn_state_desc = add.Rows[i]["In_orgn_state_desc"].ToString();
                                objList.In_orgn_dist = add.Rows[i]["In_orgn_dist"].ToString();
                                objList.In_orgn_dist_desc = add.Rows[i]["In_orgn_dist_desc"].ToString();
                                objList.In_orgn_taluk = add.Rows[i]["In_orgn_taluk"].ToString();
                                objList.In_orgn_taluk_desc = add.Rows[i]["In_orgn_taluk_desc"].ToString();
                                objList.In_orgn_panchayat = add.Rows[i]["In_orgn_panchayat"].ToString();
                                objList.In_orgn_panchayat_desc = add.Rows[i]["In_orgn_panchayat_desc"].ToString();
                                objList.In_orgn_village = add.Rows[i]["In_orgn_village"].ToString();
                                objList.In_orgn_village_desc = add.Rows[i]["In_orgn_village_desc"].ToString();
                                objList.In_orgn_pincode = add.Rows[i]["In_orgn_pincode"].ToString();
                                objList.In_orgn_pincode_desc = add.Rows[i]["In_orgn_pincode_desc"].ToString();
                                objList.In_status_code = add.Rows[i]["In_status_code"].ToString();
                                objList.In_status_desc = add.Rows[i]["In_status_desc"].ToString();
                                objList.In_mode_flag = add.Rows[i]["In_mode_flag"].ToString();
                                objfpoSearchRoot.context.Address.Add(objList);
                            }
                        }
                        if (add.Columns[0].ColumnName == "Bank")
                        {
                            for (int i = 0; i < add.Rows.Count; i++)
                            {
                                ICDInputCenter_FBank objList = new ICDInputCenter_FBank();
                                objList.In_orgnbank_rowid = Convert.ToInt32(add.Rows[i]["In_orgnbank_rowid"]);
                                objList.In_bank_acc_no = add.Rows[i]["In_bank_acc_no"].ToString();
                                objList.In_bank_acc_type = add.Rows[i]["In_bank_acc_type"].ToString();
                                objList.In_bank_acc_type_desc = add.Rows[i]["In_bank_acc_type_desc"].ToString();
                                objList.In_bank_code = add.Rows[i]["In_bank_code"].ToString();
                                objList.In_bank_desc = add.Rows[i]["In_bank_desc"].ToString();
                                objList.In_branch_code = add.Rows[i]["In_branch_code"].ToString();
                                objList.In_branch_desc = add.Rows[i]["In_branch_desc"].ToString();
                                objList.In_ifsc_code = add.Rows[i]["In_ifsc_code"].ToString();
                                objList.In_dflt_dr_acc = add.Rows[i]["In_dflt_dr_acc"].ToString();
                                objList.In_dflt_dr_acc_desc = add.Rows[i]["In_dflt_dr_acc_desc"].ToString();
                                objList.In_dflt_cr_acc = add.Rows[i]["In_dflt_cr_acc"].ToString();
                                objList.In_dflt_cr_acc_desc = add.Rows[i]["In_dflt_cr_acc_desc"].ToString();
                                objList.In_bank_acc_purpose = add.Rows[i]["In_bank_acc_purpose"].ToString();
                                objList.In_bank_acc_purpose_desc = add.Rows[i]["In_bank_acc_purpose_desc"].ToString();
                                objList.In_status_code = add.Rows[i]["In_status_code"].ToString();
                                objList.In_status_desc = add.Rows[i]["In_status_desc"].ToString();
                                objList.In_mode_flag = add.Rows[i]["In_mode_flag"].ToString();
                                objfpoSearchRoot.context.Bank.Add(objList);
                            }
                        }
                        if (add.Columns[0].ColumnName == "User")
                        {
                            for (int i = 0; i < add.Rows.Count; i++)
                            {
                                ICDInputCenter_FUser objList = new ICDInputCenter_FUser();
                                objList.In_aggrlocuser_rowid = Convert.ToInt32(add.Rows[i]["In_aggrlocuser_rowid"]);
                                objList.In_aggrorgn_type = add.Rows[i]["In_aggrorgn_type"].ToString();
                                objList.In_aggrorgn_type_desc = add.Rows[i]["In_aggrorgn_type_desc"].ToString();
                                objList.In_aggrorgn_code = add.Rows[i]["In_aggrorgn_code"].ToString();
                                objList.In_aggrloc_type = add.Rows[i]["In_aggrloc_type"].ToString();
                                objList.In_aggrloc_type_desc = add.Rows[i]["In_aggrloc_type_desc"].ToString();
                                objList.In_aggrloc_code = add.Rows[i]["In_aggrloc_code"].ToString();
                                objList.In_role_code = add.Rows[i]["In_role_code"].ToString();
                                objList.In_user_code = add.Rows[i]["In_user_code"].ToString();
                                objList.In_user_name = add.Rows[i]["In_user_name"].ToString();
                                objList.In_email_id = add.Rows[i]["In_email_id"].ToString();
                                objList.In_contact_no = add.Rows[i]["In_contact_no"].ToString();
                                objList.In_valid_till = add.Rows[i]["In_valid_till"].ToString();
                                objList.In_status_code = add.Rows[i]["In_status_code"].ToString();
                                objList.In_status_desc = add.Rows[i]["In_status_desc"].ToString();
                                objList.In_mode_flag = add.Rows[i]["In_mode_flag"].ToString();
                                objfpoSearchRoot.context.User.Add(objList);
                            }
                        }

                    }
                }
                objfpoSearchRoot.context.orgnId = objfpoSearch.orgnId;
                objfpoSearchRoot.context.locnId = objfpoSearch.locnId;
                objfpoSearchRoot.context.userId = objfpoSearch.userId;
                objfpoSearchRoot.context.localeId = objfpoSearch.localeId;
                MysqlCon.con.Close();
            }
            catch (Exception ex)
            {
                MysqlCon.con.Close();
                logger.Error("USERNAME :" + objfpoSearch.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objfpoSearchRoot;
        }


        public ICDInput_SDocument ICDInputCenter_Save(ICDInput_SApplication ObjICDSupplier, string mysqlcon)
        {
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            ICDInput_SDocument ObjresICDSupplier = new ICDInput_SDocument();
            ObjresICDSupplier.context = new ICDInput_SContext();
            ObjresICDSupplier.context.Header = new ICDInput_SHeader();
            ObjresICDSupplier.context.Address = new List<ICDInput_SAddress>();
            ObjresICDSupplier.context.Bank = new List<ICDInput_SBank>();
            ObjresICDSupplier.context.User = new List<ICDInput_SUser>();
            try
            {
                int ret = 0;
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }
                MySqlCommand cmd = new MySqlCommand("Admin_insupd_input_center", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("IOU_orgn_rowid", MySqlDbType.Int32).Value = (Int32)ObjICDSupplier.document.context.Header.IOU_orgn_rowid;// ObjFarmer.document.context.Header.in_farmer_rowid;
                cmd.Parameters.Add("IOU_orgn_code", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.IOU_orgn_code;
                cmd.Parameters.Add("IOU_version_no", MySqlDbType.Int32).Value = (Int32)ObjICDSupplier.document.context.Header.IOU_version_no;
                cmd.Parameters.Add("In_orgn_cin", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_orgn_cin;
                cmd.Parameters.Add("In_parent_code", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_parent_code;
                cmd.Parameters.Add("In_orgn_name", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_orgn_name;
                cmd.Parameters.Add("In_orgn_ll_name", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_orgn_ll_name;
                cmd.Parameters.Add("In_orgn_level", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_orgn_level;
                cmd.Parameters.Add("In_orgn_type", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_orgn_type;
                cmd.Parameters.Add("In_orgn_subtype", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_orgn_subtype;
                cmd.Parameters.Add("In_primary_lang_code", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_primary_lang_code;
                cmd.Parameters.Add("In_secondary_lang_code", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_secondary_lang_code;
                cmd.Parameters.Add("In_orgn_logo", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_orgn_logo;
                cmd.Parameters.Add("In_orgn_auth_sign", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_orgn_auth_sign;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_inputcenter_code", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_inputcenter_code;
                cmd.Parameters.Add("In_inputcenter_type", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_inputcenter_type;
                cmd.Parameters.Add("In_inputcenter_name", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_inputcenter_name;
                cmd.Parameters.Add("In_fpo_name", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_fpo_name;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("IOU_orgn_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_orgn_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_version_no1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorMsg", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                if (ret > 0)
                {
                    ObjresICDSupplier.context.Header.IOU_orgn_rowid = (Int32)cmd.Parameters["IOU_orgn_rowid1"].Value;
                    ObjresICDSupplier.context.Header.IOU_orgn_code = cmd.Parameters["IOU_orgn_code1"].Value.ToString();
                    ObjresICDSupplier.context.Header.IOU_version_no = (Int32)cmd.Parameters["IOU_version_no1"].Value;
                    ObjresICDSupplier.context.errorMsg = (string)cmd.Parameters["errorMsg"].Value;
                    if (ObjresICDSupplier.context.Header.IOU_orgn_rowid > 0)
                    {
                        if (ObjICDSupplier.document.context.Address != null)
                        {
                            ret = SaveICDInputAddress(ObjICDSupplier, ObjresICDSupplier, mysqlcon, MysqlCon);
                        }
                        if (ObjICDSupplier.document.context.Bank != null)
                        {
                            ret = SaveICDInputBank(ObjICDSupplier, ObjresICDSupplier, mysqlcon, MysqlCon);
                        }
                        if (ObjICDSupplier.document.context.User != null)
                        {
                            ret = SaveICDInputUser(ObjICDSupplier, ObjresICDSupplier, mysqlcon, MysqlCon);
                        }
                        mysqltrans.Commit();
                    }
                }
                else
                {
                    ObjresICDSupplier.context.errorMsg = (string)cmd.Parameters["errorMsg"].Value;
                    mysqltrans.Rollback();
                }
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                logger.Error("USERNAME :" + ObjICDSupplier.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjresICDSupplier;
        }

        public int SaveICDInputAddress(ICDInput_SApplication ObjmodelA, ICDInput_SDocument objIUStock, string MysqlCons, DataConnection MysqlCon)
        {
            int saving = 0;
            int count = 1;
            DataTable tab = new DataTable();
            ICDInput_SAddress objadddtl = new ICDInput_SAddress();
            try
            {
                ICDInputCenter_DB objproduct1 = new ICDInputCenter_DB();
                foreach (var Kyc in ObjmodelA.document.context.Address)
                {
                    objadddtl.In_orgnaddr_rowid = Kyc.In_orgnaddr_rowid;
                    objadddtl.In_addr_type = Kyc.In_addr_type;
                    objadddtl.In_orgn_add1 = Kyc.In_orgn_add1;
                    objadddtl.In_orgn_addr2 = Kyc.In_orgn_addr2;
                    objadddtl.In_orgn_country = Kyc.In_orgn_country;
                    objadddtl.In_orgn_state = Kyc.In_orgn_state;
                    objadddtl.In_orgn_dist = Kyc.In_orgn_dist;
                    objadddtl.In_orgn_taluk = Kyc.In_orgn_taluk;
                    objadddtl.In_orgn_panchayat = Kyc.In_orgn_panchayat;
                    objadddtl.In_orgn_village = Kyc.In_orgn_village;
                    objadddtl.In_orgn_pincode = Kyc.In_orgn_pincode;
                    objadddtl.In_status_code = Kyc.In_status_code;
                    objadddtl.In_mode_flag = Kyc.In_mode_flag;
                    saving = objproduct1.SaveICDInputAddressSP(objadddtl, objIUStock, ObjmodelA, MysqlCons, MysqlCon);
                }
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objIUStock.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return saving;

        }
        public int SaveICDInputAddressSP(ICDInput_SAddress objadddtl, ICDInput_SDocument objIUStock, ICDInput_SApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("Admin_iud_input_center_address", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("IOU_orgn_rowid", MySqlDbType.Int32).Value = objIUStock.context.Header.IOU_orgn_rowid;
                cmd.Parameters.Add("IOU_orgn_code", MySqlDbType.VarChar).Value = objIUStock.context.Header.IOU_orgn_code;
                cmd.Parameters.Add("IOU_version_no", MySqlDbType.Int32).Value = objIUStock.context.Header.IOU_version_no;
                cmd.Parameters.Add("In_orgnaddr_rowid", MySqlDbType.VarChar).Value = objadddtl.In_orgnaddr_rowid;
                cmd.Parameters.Add("In_addr_type", MySqlDbType.VarChar).Value = objadddtl.In_addr_type;
                cmd.Parameters.Add("In_orgn_add1", MySqlDbType.VarChar).Value = objadddtl.In_orgn_add1;
                cmd.Parameters.Add("In_orgn_addr2", MySqlDbType.VarChar).Value = objadddtl.In_orgn_addr2;
                cmd.Parameters.Add("In_orgn_country", MySqlDbType.VarChar).Value = objadddtl.In_orgn_country;
                cmd.Parameters.Add("In_orgn_state", MySqlDbType.VarChar).Value = objadddtl.In_orgn_state;
                cmd.Parameters.Add("In_orgn_dist", MySqlDbType.VarChar).Value = objadddtl.In_orgn_dist;
                cmd.Parameters.Add("In_orgn_taluk", MySqlDbType.VarChar).Value = objadddtl.In_orgn_taluk;
                cmd.Parameters.Add("In_orgn_panchayat", MySqlDbType.VarChar).Value = objadddtl.In_orgn_panchayat;
                cmd.Parameters.Add("In_orgn_village", MySqlDbType.VarChar).Value = objadddtl.In_orgn_village;
                cmd.Parameters.Add("In_orgn_pincode", MySqlDbType.VarChar).Value = objadddtl.In_orgn_pincode;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = objadddtl.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objadddtl.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ret;

        }


        public int SaveICDInputBank(ICDInput_SApplication ObjmodelA, ICDInput_SDocument objIUStock, string MysqlCons, DataConnection MysqlCon)
        {
            int saving = 0;
            int count = 1;
            DataTable tab = new DataTable();
            ICDInput_SBank objadddtl = new ICDInput_SBank();
            try
            {
                ICDInputCenter_DB objproduct1 = new ICDInputCenter_DB();
                foreach (var Kyc in ObjmodelA.document.context.Bank)
                {
                    objadddtl.In_orgnbank_rowid = Kyc.In_orgnbank_rowid;
                    objadddtl.In_bank_acc_no = Kyc.In_bank_acc_no;
                    objadddtl.In_bank_acc_type = Kyc.In_bank_acc_type;
                    objadddtl.In_bank_code = Kyc.In_bank_code;
                    objadddtl.In_branch_code = Kyc.In_branch_code;
                    objadddtl.In_ifsc_code = Kyc.In_ifsc_code;
                    objadddtl.In_dflt_dr_acc = Kyc.In_dflt_dr_acc;
                    objadddtl.In_dflt_cr_acc = Kyc.In_dflt_cr_acc;
                    objadddtl.In_bank_acc_purpose = Kyc.In_bank_acc_purpose;
                    objadddtl.In_status_code = Kyc.In_status_code;
                    objadddtl.In_mode_flag = Kyc.In_mode_flag;
                    saving = objproduct1.SaveICDInputBankSP(objadddtl, objIUStock, ObjmodelA, MysqlCons, MysqlCon);
                }
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objIUStock.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return saving;

        }
        public int SaveICDInputBankSP(ICDInput_SBank objadddtl, ICDInput_SDocument objIUStock, ICDInput_SApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("Admin_iud_input_center_bank", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("IOU_orgn_rowid", MySqlDbType.Int32).Value = objIUStock.context.Header.IOU_orgn_rowid;
                cmd.Parameters.Add("IOU_orgn_code", MySqlDbType.VarChar).Value = objIUStock.context.Header.IOU_orgn_code;
                cmd.Parameters.Add("IOU_version_no", MySqlDbType.Int32).Value = objIUStock.context.Header.IOU_version_no;
                cmd.Parameters.Add("In_orgnbank_rowid", MySqlDbType.VarChar).Value = objadddtl.In_orgnbank_rowid;
                cmd.Parameters.Add("In_bank_acc_no", MySqlDbType.VarChar).Value = objadddtl.In_bank_acc_no;
                cmd.Parameters.Add("In_bank_acc_type", MySqlDbType.VarChar).Value = objadddtl.In_bank_acc_type;
                cmd.Parameters.Add("In_bank_code", MySqlDbType.VarChar).Value = objadddtl.In_bank_code;
                cmd.Parameters.Add("In_branch_code", MySqlDbType.VarChar).Value = objadddtl.In_branch_code;
                cmd.Parameters.Add("In_ifsc_code", MySqlDbType.VarChar).Value = objadddtl.In_ifsc_code;
                cmd.Parameters.Add("In_dflt_dr_acc", MySqlDbType.VarChar).Value = objadddtl.In_dflt_dr_acc;
                cmd.Parameters.Add("In_dflt_cr_acc", MySqlDbType.VarChar).Value = objadddtl.In_dflt_cr_acc;
                cmd.Parameters.Add("In_bank_acc_purpose", MySqlDbType.VarChar).Value = objadddtl.In_bank_acc_purpose;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = objadddtl.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objadddtl.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objIUStock.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ret;

        }

        public int SaveICDInputUser(ICDInput_SApplication ObjmodelA, ICDInput_SDocument objIUStock, string MysqlCons, DataConnection MysqlCon)
        {
            int saving = 0;
            int count = 1;
            DataTable tab = new DataTable();
            ICDInput_SUser objadddtl = new ICDInput_SUser();
            try
            {
                ICDInputCenter_DB objproduct1 = new ICDInputCenter_DB();
                foreach (var Kyc in ObjmodelA.document.context.User)
                {
                    objadddtl.In_aggrlocuser_rowid = Kyc.In_aggrlocuser_rowid;
                    objadddtl.In_aggrorgn_type = Kyc.In_aggrorgn_type;
                    objadddtl.In_aggrorgn_code = Kyc.In_aggrorgn_code;
                    objadddtl.In_aggrloc_type = Kyc.In_aggrloc_type;
                    objadddtl.In_aggrloc_code = Kyc.In_aggrloc_code;
                    objadddtl.In_role_code = Kyc.In_role_code;
                    objadddtl.In_user_code = Kyc.In_user_code;
                    objadddtl.In_status_code = Kyc.In_status_code;
                    objadddtl.In_mode_flag = Kyc.In_mode_flag;
                    saving = objproduct1.SaveICDInputUserSP(objadddtl, objIUStock, ObjmodelA, MysqlCons, MysqlCon);
                }
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objIUStock.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return saving;

        }
        public int SaveICDInputUserSP(ICDInput_SUser objadddtl, ICDInput_SDocument objIUStock, ICDInput_SApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("Admin_iud_input_center_user", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("IOU_orgn_rowid", MySqlDbType.Int32).Value = objIUStock.context.Header.IOU_orgn_rowid;
                cmd.Parameters.Add("IOU_orgn_code", MySqlDbType.VarChar).Value = objIUStock.context.Header.IOU_orgn_code;
                cmd.Parameters.Add("IOU_version_no", MySqlDbType.Int32).Value = objIUStock.context.Header.IOU_version_no;
                cmd.Parameters.Add("In_aggrlocuser_rowid", MySqlDbType.VarChar).Value = objadddtl.In_aggrlocuser_rowid;
                cmd.Parameters.Add("In_aggrorgn_type", MySqlDbType.VarChar).Value = objadddtl.In_aggrorgn_type;
                cmd.Parameters.Add("In_aggrorgn_code", MySqlDbType.VarChar).Value = objadddtl.In_aggrorgn_code;
                cmd.Parameters.Add("In_aggrloc_type", MySqlDbType.VarChar).Value = objadddtl.In_aggrloc_type;
                cmd.Parameters.Add("In_aggrloc_code", MySqlDbType.VarChar).Value = objadddtl.In_aggrloc_code;
                cmd.Parameters.Add("In_role_code", MySqlDbType.VarChar).Value = objadddtl.In_role_code;
                cmd.Parameters.Add("In_user_code", MySqlDbType.VarChar).Value = objadddtl.In_user_code;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = objadddtl.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objadddtl.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objIUStock.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ret;

        }


    }
}
