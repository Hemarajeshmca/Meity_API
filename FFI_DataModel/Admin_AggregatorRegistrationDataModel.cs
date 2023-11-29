using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
    public class Admin_AggregatorRegistrationDataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        Admin_ErrorMessageModel ObjErrormsg = new Admin_ErrorMessageModel();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Admin_AggregatorRegistrationDataModel));
        // Exception Log Method Name Purpose written start 
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public PAWHSAggregatorRegistrationList AggregatorRegistrationList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue, string ConString)
        {
            PAWHSAggregatorRegistrationList ObjFetchAll = new PAWHSAggregatorRegistrationList();
            
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MysqlCon = new DataConnection(ConString);
                AGGContext objContext = new AGGContext();
                objContext.orgnId = org;
                objContext.localeId = lang;
                objContext.locnId = locn;
                objContext.userId = user;
                ObjFetchAll.context = objContext;
                MySqlCommand cmd = new MySqlCommand("Admin_PAWHS_fetch_aggr_reg_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("in_FilterBy_Option", MySqlDbType.VarChar).Value = filterby_option;
                cmd.Parameters.Add("in_FilterBy_Code", MySqlDbType.VarChar).Value = filterby_code;
                cmd.Parameters.Add("in_FilterBy_FromValue", MySqlDbType.VarChar).Value = filterby_fromvalue;
                cmd.Parameters.Add("in_FilterBy_ToValue", MySqlDbType.VarChar).Value = filterby_tovalue;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                List<AGGREGList> objRoleLst = new List<AGGREGList>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AGGREGList objList = new AGGREGList();
                    objList.Out_orgn_rowid = Convert.ToInt32(dt.Rows[i]["Out_orgn_rowid"].ToString());
                    objList.Out_aggregator_code = dt.Rows[i]["Out_aggregator_code"].ToString();
                    objList.Out_aggregator_name = dt.Rows[i]["Out_aggregator_name"].ToString();
                    objList.Out_orgn_level = dt.Rows[i]["Out_orgn_level"].ToString();
                    objList.Out_aggregator_type = dt.Rows[i]["Out_aggregator_type"].ToString();
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.Out_status_desc = dt.Rows[i]["Out_status_desc"].ToString();
                    objList.Out_row_timestamp = dt.Rows[i]["Out_row_timestamp"].ToString();
                   
                    objRoleLst.Add(objList);
                }
                ObjFetchAll.context.List = objRoleLst;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetchAll;
        }

        public FectAggregatorRegistration FectAggregatorRegistration(string org, string locn, string user, string lang, int orgn_rowid, string aggregator_code, string ConString)
        {
            FectAggregatorRegistration ObjFetch = new FectAggregatorRegistration();
           
            try
            {
                DataSet ds = new DataSet();
                DataTable dtAddressdtAddress = new DataTable();
                MysqlCon = new DataConnection(ConString);
                FetchARContext objContext = new FetchARContext();
                objContext.orgnId = org;
                objContext.localeId = lang;
                objContext.locnId = locn;
                objContext.userId = user;
                ObjFetch.context = objContext;
                MySqlCommand cmd = new MySqlCommand("Admin_PAWHS_fetch_aggr_reg", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("IOU_orgn_rowid", MySqlDbType.Int32).Value = orgn_rowid;
                cmd.Parameters.Add("IOU_aggregator_code", MySqlDbType.VarChar).Value = aggregator_code;


                cmd.Parameters.Add(new MySqlParameter("IOU_orgn_rowid1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_aggregator_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_aggregator_type", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_fpo_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_fpo_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_aggregator_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_aggregator_ll_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_orgn_level", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_facilitator_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_facilitator_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_facilitator_ll_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_facilitator_ll_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_member_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_member_ll_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);

                MysqlCon.con.Close();
                
                DataTable dtAddress = ds.Tables[0];
                DataTable dtBank = ds.Tables[1];
                DataTable dtFIG = ds.Tables[2];
                FetchARHeader objHeader = new FetchARHeader();

                objHeader.IOU_orgn_rowid = (int)cmd.Parameters["IOU_orgn_rowid"].Value;
                objHeader.IOU_aggregator_code = (string)cmd.Parameters["IOU_aggregator_code"].Value.ToString();
                objHeader.Out_aggregator_type = (string)cmd.Parameters["Out_aggregator_type"].ToString();
                objHeader.Out_fpo_code = (string)cmd.Parameters["Out_fpo_code"].Value.ToString();
                objHeader.Out_fpo_desc = (string)cmd.Parameters["Out_fpo_desc"].Value.ToString();
                objHeader.Out_aggregator_name = (string)cmd.Parameters["Out_aggregator_name"].Value.ToString();
                objHeader.Out_aggregator_ll_name = (string)cmd.Parameters["Out_aggregator_ll_name"].Value.ToString();
                objHeader.Out_orgn_level = (string)cmd.Parameters["Out_orgn_level"].Value.ToString();
                objHeader.Out_facilitator_code = (string)cmd.Parameters["Out_facilitator_code"].Value.ToString();
                objHeader.Out_facilitator_name = (string)cmd.Parameters["Out_facilitator_name"].Value.ToString();
                objHeader.Out_facilitator_ll_code = (string)cmd.Parameters["Out_facilitator_ll_code"].Value.ToString();
                objHeader.Out_member_name = (string)cmd.Parameters["Out_member_name"].Value.ToString();
                objHeader.Out_member_ll_name = (string)cmd.Parameters["Out_member_ll_name"].Value.ToString();
                objHeader.Out_status_code = (string)cmd.Parameters["Out_status_code"].Value.ToString();
                objHeader.Out_status_desc = (string)cmd.Parameters["Out_status_desc"].Value.ToString();
                objHeader.Out_mode_flag = (string)cmd.Parameters["Out_mode_flag"].Value.ToString();
                objHeader.Out_row_timestamp = (string)cmd.Parameters["Out_row_timestamp"].Value.ToString();

                ObjFetch.context.Header = objHeader;


                List<FetchARAddress> ObjAddressList = new List<FetchARAddress>();
                if (dtAddress.Rows.Count > 0)
                {
                    for (int i = 0; i < dtAddress.Rows.Count; i++)
                    {
                        FetchARAddress objList = new FetchARAddress();
                        objList.Out_orgnaddr_rowid = Convert.ToInt32(dtAddress.Rows[i]["Out_orgnaddr_rowid"]);
                        objList.Out_addr_type = dtAddress.Rows[i]["Out_addr_type"].ToString();
                        objList.Out_addr_type_desc = dtAddress.Rows[i]["Out_addr_type_desc"].ToString();
                        objList.Out_orgn_addr1 = dtAddress.Rows[i]["Out_orgn_addr1"].ToString();
                        objList.Out_orgn_addr2 = dtAddress.Rows[i]["Out_orgn_addr2"].ToString();
                        objList.Out_orgn_country = dtAddress.Rows[i]["Out_orgn_country"].ToString();
                        objList.Out_orgn_country_desc = dtAddress.Rows[i]["Out_orgn_country_desc"].ToString();
                        objList.Out_orgn_state = dtAddress.Rows[i]["Out_orgn_state"].ToString();
                        objList.Out_orgn_state_desc = dtAddress.Rows[i]["Out_orgn_state_desc"].ToString();
                        objList.Out_orgn_dist = dtAddress.Rows[i]["Out_orgn_dist"].ToString();
                        objList.Out_orgn_dist_desc = dtAddress.Rows[i]["Out_orgn_dist_desc"].ToString();
                        objList.Out_orgn_taluk = dtAddress.Rows[i]["Out_orgn_taluk"].ToString();
                        objList.Out_orgn_taluk_desc = dtAddress.Rows[i]["Out_orgn_taluk_desc"].ToString();
                        objList.Out_orgn_panchayat = dtAddress.Rows[i]["Out_orgn_panchayat"].ToString();
                        objList.Out_orgn_panchayat_desc = dtAddress.Rows[i]["Out_orgn_panchayat_desc"].ToString();
                        objList.Out_orgn_village = dtAddress.Rows[i]["Out_orgn_village"].ToString();
                        objList.Out_orgn_village_desc = dtAddress.Rows[i]["Out_orgn_village_desc"].ToString();
                        objList.Out_orgn_pincode = dtAddress.Rows[i]["Out_orgn_pincode"].ToString();
                        objList.Out_orgn_pincode_desc = dtAddress.Rows[i]["Out_orgn_pincode_desc"].ToString();
                        objList.Out_status_code = dtAddress.Rows[i]["Out_status_code"].ToString();
                        objList.Out_status_desc = dtAddress.Rows[i]["Out_status_desc"].ToString();
                        objList.Out_mode_flag = dtAddress.Rows[i]["Out_mode_flag"].ToString();
                       
                        ObjAddressList.Add(objList);
                    }
                }
                ObjFetch.context.Header.Address = ObjAddressList;

                List<FetchARBank> ObjBankList = new List<FetchARBank>();
                if (dtBank.Rows.Count > 0)
                {
                    for (int i = 0; i < dtBank.Rows.Count; i++)
                    {
                        FetchARBank objList = new FetchARBank();
                        objList.Out_orgnbank_rowid = Convert.ToInt32(dtBank.Rows[i]["Out_orgnbank_rowid"]);
                        objList.Out_bank_acc_no = dtBank.Rows[i]["Out_bank_acc_no"].ToString();
                        objList.Out_bank_acc_type = dtBank.Rows[i]["Out_bank_acc_type"].ToString();
                        objList.Out_bank_acc_type_desc = dtBank.Rows[i]["Out_bank_acc_type_desc"].ToString();
                        objList.Out_bank_code = dtBank.Rows[i]["Out_bank_code"].ToString();
                        objList.Out_bank_desc = dtBank.Rows[i]["Out_bank_desc"].ToString();
                        objList.Out_branch_code = dtBank.Rows[i]["Out_branch_code"].ToString();
                        objList.Out_branch_desc = dtBank.Rows[i]["Out_branch_desc"].ToString();
                        objList.Out_ifsc_code = dtBank.Rows[i]["Out_ifsc_code"].ToString();
                        objList.Out_dflt_dr_acc = dtBank.Rows[i]["Out_dflt_dr_acc"].ToString();
                        objList.Out_dflt_dr_acc_desc = dtBank.Rows[i]["Out_dflt_dr_acc_desc"].ToString();
                        objList.Out_dflt_cr_acc = dtBank.Rows[i]["Out_dflt_cr_acc"].ToString();
                        objList.Out_dflt_cr_acc_desc = dtBank.Rows[i]["Out_dflt_cr_acc_desc"].ToString();
                        objList.Out_bank_acc_purpose = dtBank.Rows[i]["Out_bank_acc_purpose"].ToString();
                        objList.Out_bank_acc_purpose_desc = dtBank.Rows[i]["Out_bank_acc_purpose_desc"].ToString();
                        objList.Out_status_code = dtBank.Rows[i]["Out_status_code"].ToString();
                        objList.Out_status_desc = dtBank.Rows[i]["Out_status_desc"].ToString();
                        objList.Out_mode_flag = dtBank.Rows[i]["Out_mode_flag"].ToString();
                       
                        ObjBankList.Add(objList);
                    }
                }
                ObjFetch.context.Header.Bank = ObjBankList;

                List<FetchARFig> ObjFigList = new List<FetchARFig>();
                if (dtFIG.Rows.Count > 0)
                {
                    for (int i = 0; i < dtFIG.Rows.Count; i++)
                    {
                        FetchARFig objList = new FetchARFig();
                        objList.Out_aggrfig_rowid = Convert.ToInt32(dtFIG.Rows[i]["Out_aggrfig_rowid"]);
                        objList.Out_aggrfig_type = dtFIG.Rows[i]["Out_aggrfig_type"].ToString();
                        objList.Out_aggrfig_type_desc = dtFIG.Rows[i]["Out_aggrfig_type_desc"].ToString();
                        objList.Out_aggrfig_code = dtFIG.Rows[i]["Out_aggrfig_code"].ToString();
                        objList.Out_aggrvillage_code = dtFIG.Rows[i]["Out_aggrvillage_code"].ToString();
                        objList.Out_aggrvillage_name = dtFIG.Rows[i]["Out_aggrvillage_name"].ToString();
                        objList.Out_contact_person = dtFIG.Rows[i]["Out_contact_person"].ToString();
                        objList.Out_contact_no = dtFIG.Rows[i]["Out_contact_no"].ToString();
                        objList.Out_status_code = dtFIG.Rows[i]["Out_status_code"].ToString();
                        objList.Out_status_desc = dtFIG.Rows[i]["Out_status_desc"].ToString();
                        objList.Out_mode_flag = dtFIG.Rows[i]["Out_mode_flag"].ToString();
                        
                        ObjFigList.Add(objList);
                    }
                }
                ObjFetch.context.Header.Fig = ObjFigList;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }

        public MApplication AggrMemberFetch(string userId, string orgnId, string locnId, string localeId, int orgn_rowid, string orgn_code, string aggregator_code, string fpo_code, string ConString)
        {
            MApplication ObjFetch = new MApplication();
           
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MysqlCon = new DataConnection(ConString);
                MContext objContext = new MContext();
                objContext.orgnId = orgnId;
                objContext.localeId = localeId;
                objContext.locnId = locnId;
                objContext.userId = userId;
                ObjFetch.context = objContext;
                MySqlCommand cmd = new MySqlCommand("Admin_PAWHS_fetch_member_reg", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = localeId;
                cmd.Parameters.Add("IOU_orgn_rowid", MySqlDbType.Int32).Value = orgn_rowid;
                cmd.Parameters.Add("IOU_aggregator_code", MySqlDbType.VarChar).Value = aggregator_code;
                cmd.Parameters.Add("Out_orgn_code", MySqlDbType.VarChar).Value = orgn_code;
                cmd.Parameters.Add("Out_fpo_code", MySqlDbType.VarChar).Value = fpo_code;


                cmd.Parameters.Add(new MySqlParameter("IOU_orgn_rowid1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_aggregator_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_orgn_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_fpo_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_fpo_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_aggregator_type", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_aggregator_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_aggregator_ll_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_orgn_level", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_facilitator_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_facilitator_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_facilitator_ll_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_facilitator_ll_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_member_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_member_ll_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Out_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();
                DataTable dtAddress = ds.Tables[0];
                DataTable dtBank = ds.Tables[1];
                DataTable dtFIG = ds.Tables[2];
                MHeader objHeader = new MHeader();

                objHeader.IOU_orgn_rowid = (int)cmd.Parameters["IOU_orgn_rowid"].Value;
                objHeader.IOU_aggregator_code = (string)cmd.Parameters["IOU_aggregator_code"].Value.ToString();
                objHeader.Out_orgn_code = (string)cmd.Parameters["IOU_aggregator_code"].Value.ToString();
                objHeader.Out_aggregator_type = (string)cmd.Parameters["Out_aggregator_type"].ToString();
                objHeader.Out_fpo_code = (string)cmd.Parameters["Out_fpo_code"].Value.ToString();
                objHeader.Out_fpo_desc = (string)cmd.Parameters["Out_fpo_desc"].Value.ToString();
                objHeader.Out_aggregator_name = (string)cmd.Parameters["Out_aggregator_name"].Value.ToString();
                objHeader.Out_aggregator_ll_name = (string)cmd.Parameters["Out_aggregator_ll_name"].Value.ToString();
                objHeader.Out_orgn_level = (string)cmd.Parameters["Out_orgn_level"].Value.ToString();
                objHeader.Out_facilitator_code = (string)cmd.Parameters["Out_facilitator_code"].Value.ToString();
                objHeader.Out_facilitator_name = (string)cmd.Parameters["Out_facilitator_name"].Value.ToString();
                objHeader.Out_facilitator_ll_code = (string)cmd.Parameters["Out_facilitator_ll_code"].Value.ToString();
                objHeader.Out_member_name = (string)cmd.Parameters["Out_member_name"].Value.ToString();
                objHeader.Out_member_ll_name = (string)cmd.Parameters["Out_member_ll_name"].Value.ToString();
                objHeader.Out_status_code = (string)cmd.Parameters["Out_status_code"].Value.ToString();
                objHeader.Out_status_desc = (string)cmd.Parameters["Out_status_desc"].Value.ToString();
                objHeader.Out_mode_flag = (string)cmd.Parameters["Out_mode_flag"].Value.ToString();
                objHeader.Out_row_timestamp = (string)cmd.Parameters["Out_row_timestamp"].Value.ToString();
               
                ObjFetch.context.Header = objHeader;


                List<MAddress> ObjAddressList = new List<MAddress>();
                if (dtAddress.Rows.Count > 0)
                {
                    for (int i = 0; i < dtAddress.Rows.Count; i++)
                    {
                        MAddress objList = new MAddress();
                        objList.Out_orgnaddr_rowid = Convert.ToInt32(dtAddress.Rows[i]["Out_orgnaddr_rowid"]);
                        objList.Out_addr_type = dtAddress.Rows[i]["Out_addr_type"].ToString();
                        objList.Out_addr_type_desc = dtAddress.Rows[i]["Out_addr_type_desc"].ToString();
                        objList.Out_orgn_addr1 = dtAddress.Rows[i]["Out_orgn_addr1"].ToString();
                        objList.Out_orgn_addr2 = dtAddress.Rows[i]["Out_orgn_addr2"].ToString();
                        objList.Out_orgn_country = dtAddress.Rows[i]["Out_orgn_country"].ToString();
                        objList.Out_orgn_country_desc = dtAddress.Rows[i]["Out_orgn_country_desc"].ToString();
                        objList.Out_orgn_state = dtAddress.Rows[i]["Out_orgn_state"].ToString();
                        objList.Out_orgn_state_desc = dtAddress.Rows[i]["Out_orgn_state_desc"].ToString();
                        objList.Out_orgn_dist = dtAddress.Rows[i]["Out_orgn_dist"].ToString();
                        objList.Out_orgn_dist_desc = dtAddress.Rows[i]["Out_orgn_dist_desc"].ToString();
                        objList.Out_orgn_taluk = dtAddress.Rows[i]["Out_orgn_taluk"].ToString();
                        objList.Out_orgn_taluk_desc = dtAddress.Rows[i]["Out_orgn_taluk_desc"].ToString();
                        objList.Out_orgn_panchayat = dtAddress.Rows[i]["Out_orgn_panchayat"].ToString();
                        objList.Out_orgn_panchayat_desc = dtAddress.Rows[i]["Out_orgn_panchayat_desc"].ToString();
                        objList.Out_orgn_village = dtAddress.Rows[i]["Out_orgn_village"].ToString();
                        objList.Out_orgn_village_desc = dtAddress.Rows[i]["Out_orgn_village_desc"].ToString();
                        objList.Out_orgn_pincode = dtAddress.Rows[i]["Out_orgn_pincode"].ToString();
                        objList.Out_orgn_pincode_desc = dtAddress.Rows[i]["Out_orgn_pincode_desc"].ToString();
                        objList.Out_status_code = dtAddress.Rows[i]["Out_status_code"].ToString();
                        objList.Out_status_desc = dtAddress.Rows[i]["Out_status_desc"].ToString();
                        objList.Out_mode_flag = dtAddress.Rows[i]["Out_mode_flag"].ToString();
                       
                        ObjAddressList.Add(objList);
                    }
                }
                ObjFetch.context.Address = ObjAddressList;

                List<MBank> ObjBankList = new List<MBank>();
                if (dtBank.Rows.Count > 0)
                {
                    for (int i = 0; i < dtBank.Rows.Count; i++)
                    {
                        MBank objList = new MBank();
                        objList.Out_orgnbank_rowid = Convert.ToInt32(dtBank.Rows[i]["Out_orgnbank_rowid"]);
                        objList.Out_bank_acc_no = dtBank.Rows[i]["Out_bank_acc_no"].ToString();
                        objList.Out_bank_acc_type = dtBank.Rows[i]["Out_bank_acc_type"].ToString();
                        objList.Out_bank_acc_type_desc = dtBank.Rows[i]["Out_bank_acc_type_desc"].ToString();
                        objList.Out_bank_code = dtBank.Rows[i]["Out_bank_code"].ToString();
                        objList.Out_bank_desc = dtBank.Rows[i]["Out_bank_desc"].ToString();
                        objList.Out_branch_code = dtBank.Rows[i]["Out_branch_code"].ToString();
                        objList.Out_branch_desc = dtBank.Rows[i]["Out_branch_desc"].ToString();
                        objList.Out_ifsc_code = dtBank.Rows[i]["Out_ifsc_code"].ToString();
                        objList.Out_dflt_dr_acc = dtBank.Rows[i]["Out_dflt_dr_acc"].ToString();
                        objList.Out_dflt_dr_acc_desc = dtBank.Rows[i]["Out_dflt_dr_acc_desc"].ToString();
                        objList.Out_dflt_cr_acc = dtBank.Rows[i]["Out_dflt_cr_acc"].ToString();
                        objList.Out_dflt_cr_acc_desc = dtBank.Rows[i]["Out_dflt_cr_acc_desc"].ToString();
                        objList.Out_bank_acc_purpose = dtBank.Rows[i]["Out_bank_acc_purpose"].ToString();
                        objList.Out_bank_acc_purpose_desc = dtBank.Rows[i]["Out_bank_acc_purpose_desc"].ToString();
                        objList.Out_status_code = dtBank.Rows[i]["Out_status_code"].ToString();
                        objList.Out_status_desc = dtBank.Rows[i]["Out_status_desc"].ToString();
                        objList.Out_mode_flag = dtBank.Rows[i]["Out_mode_flag"].ToString();
                        
                        ObjBankList.Add(objList);
                    }
                }
                ObjFetch.context.Bank = ObjBankList;

                List<MFIG> ObjFigList = new List<MFIG>();
                if (dtFIG.Rows.Count > 0)
                {
                    for (int i = 0; i < dtFIG.Rows.Count; i++)
                    {
                        MFIG objList = new MFIG();
                        objList.Out_aggrfig_rowid = Convert.ToInt32(dtFIG.Rows[i]["Out_aggrfig_rowid"]);
                        objList.Out_aggrfig_type = dtFIG.Rows[i]["Out_aggrfig_type"].ToString();
                        objList.Out_aggrfig_type_desc = dtFIG.Rows[i]["Out_aggrfig_type_desc"].ToString();
                        objList.Out_aggrfig_code = dtFIG.Rows[i]["Out_aggrfig_code"].ToString();
                        objList.Out_aggrvillage_code = dtFIG.Rows[i]["Out_aggrvillage_code"].ToString();
                        objList.Out_aggrvillage_name = dtFIG.Rows[i]["Out_aggrvillage_name"].ToString();
                        objList.Out_contact_person = dtFIG.Rows[i]["Out_contact_person"].ToString();
                        objList.Out_contact_no = dtFIG.Rows[i]["Out_contact_no"].ToString();
                        objList.Out_status_code = dtFIG.Rows[i]["Out_status_code"].ToString();
                        objList.Out_status_desc = dtFIG.Rows[i]["Out_status_desc"].ToString();
                        objList.Out_mode_flag = dtFIG.Rows[i]["Out_mode_flag"].ToString();
                       
                        ObjFigList.Add(objList);
                    }
                }
                ObjFetch.context.FIG = ObjFigList;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }

        public SaveAGGDocument SavePAWHSAggregatorRegistration(SaveAggregatorRegistration objAG, string ConString)
        {
            string[] response = { };
            SaveAGGDocument ObjFetch = new SaveAGGDocument();
           
            try
            {
                int ret = 0;
                int retdtls = 0;
                MysqlCon = new DataConnection(ConString);
                SaveAGGContext objContext = new SaveAGGContext();
                objContext.orgnId = objAG.document.context.orgnId;
                objContext.localeId = objAG.document.context.localeId;
                objContext.locnId = objAG.document.context.locnId;
                objContext.userId = objAG.document.context.userId;
                ObjFetch.context = objContext;
                SaveAGGHeader objOutHeader = new SaveAGGHeader();

                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }


                FFI_Model.ApplicationException objex = new FFI_Model.ApplicationException();
                MySqlCommand cmd = new MySqlCommand("Admin_PAWHS_insupd_aggr_reg", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("Out_aggregator_type", MySqlDbType.VarChar).Value = objAG.document.context.Header.Out_aggregator_type;
                cmd.Parameters.Add("Out_fpo_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.Out_fpo_code;
                cmd.Parameters.Add("Out_orgn_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.Out_orgn_code;
                cmd.Parameters.Add("Out_aggregator_name", MySqlDbType.VarChar).Value = objAG.document.context.Header.Out_aggregator_name;
                cmd.Parameters.Add("Out_aggregator_ll_name", MySqlDbType.VarChar).Value = objAG.document.context.Header.Out_aggregator_ll_name;
                cmd.Parameters.Add("Out_orgn_level", MySqlDbType.VarChar).Value = objAG.document.context.Header.Out_orgn_level;
                cmd.Parameters.Add("Out_facilitator_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.Out_facilitator_code;
                cmd.Parameters.Add("Out_facilitator_ll_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.Out_facilitator_ll_code;
                cmd.Parameters.Add("Out_member_name", MySqlDbType.VarChar).Value = objAG.document.context.Header.Out_member_name;
                cmd.Parameters.Add("Out_member_ll_name", MySqlDbType.VarChar).Value = objAG.document.context.Header.Out_member_ll_name;
                cmd.Parameters.Add("Out_status_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.Out_status_code;
                cmd.Parameters.Add("Out_mode_flag", MySqlDbType.VarChar).Value = objAG.document.context.Header.Out_mode_flag;
                cmd.Parameters.Add("Out_row_timestamp", MySqlDbType.VarChar).Value = objAG.document.context.Header.Out_row_timestamp;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objAG.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objAG.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objAG.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objAG.document.context.localeId;
                cmd.Parameters.Add("IOU_orgn_rowid", MySqlDbType.Int32).Value = objAG.document.context.Header.IOU_orgn_rowid;
                cmd.Parameters.Add("IOU_aggregator_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.IOU_aggregator_code;
                cmd.Parameters.Add(new MySqlParameter("IOU_orgn_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_aggregator_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                retdtls = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);

                if (retdtls > 0)
                {
                    objOutHeader.IOU_orgn_rowid = (Int32)cmd.Parameters["IOU_orgn_rowid1"].Value;
                    objOutHeader.IOU_aggregator_code = (string)cmd.Parameters["IOU_aggregator_code1"].Value;
                }
                objContext.Header = objOutHeader;
                bool isvaild = true;
                if (objOutHeader.IOU_orgn_rowid > 0)
                {
                    foreach (var Details in objAG.document.context.Header.Address)
                    {
                        MySqlCommand cmds = new MySqlCommand("Admin_PAWHS_iud_aggr_reg_address", MysqlCon.con);
                        cmds.CommandType = CommandType.StoredProcedure;
                        cmds.Parameters.Add("Out_orgnaddr_rowid", MySqlDbType.Int32).Value = Details.Out_orgnaddr_rowid;
                        cmds.Parameters.Add("Out_addr_type", MySqlDbType.VarChar).Value = Details.Out_addr_type;
                        cmds.Parameters.Add("Out_orgn_addr1", MySqlDbType.VarChar).Value = Details.Out_orgn_addr1;
                        cmds.Parameters.Add("Out_orgn_addr2", MySqlDbType.VarChar).Value = Details.Out_orgn_addr2;
                        cmds.Parameters.Add("Out_orgn_country", MySqlDbType.VarChar).Value = Details.Out_orgn_country;
                        cmds.Parameters.Add("Out_orgn_state", MySqlDbType.VarChar).Value = Details.Out_orgn_state;
                        cmds.Parameters.Add("Out_orgn_dist", MySqlDbType.VarChar).Value = Details.Out_orgn_dist;
                        cmds.Parameters.Add("Out_orgn_taluk", MySqlDbType.VarChar).Value = Details.Out_orgn_taluk;
                        cmds.Parameters.Add("Out_orgn_panchayat", MySqlDbType.VarChar).Value = Details.Out_orgn_panchayat;
                        cmds.Parameters.Add("Out_orgn_village", MySqlDbType.VarChar).Value = Details.Out_orgn_village;
                        cmds.Parameters.Add("Out_orgn_pincode", MySqlDbType.VarChar).Value = Details.Out_orgn_pincode;
                        cmds.Parameters.Add("Out_status_code", MySqlDbType.VarChar).Value = Details.Out_status_code;
                        cmds.Parameters.Add("Out_mode_flag", MySqlDbType.VarChar).Value = Details.Out_mode_flag;
                        cmds.Parameters.Add("IOU_orgn_rowid", MySqlDbType.VarChar).Value = objAG.document.context.Header.IOU_orgn_rowid;
                        cmds.Parameters.Add("IOU_aggregator_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.IOU_aggregator_code;
                        cmds.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objAG.document.context.orgnId;
                        cmds.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objAG.document.context.locnId;
                        cmds.Parameters.Add("userId", MySqlDbType.VarChar).Value = objAG.document.context.userId;
                        cmds.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objAG.document.context.localeId;
                        cmds.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                       
                        ret = cmds.ExecuteNonQuery();
                        LogHelper.ConvertCmdIntoString(cmd);

                        if (ret == 0)
                        {
                            mysqltrans.Rollback();
                            isvaild = false;
                            break;
                        }
                    }
                    if (isvaild == true)
                    {
                        foreach (var Details in objAG.document.context.Header.Bank)
                        {
                            MySqlCommand cmdb = new MySqlCommand("Admin_PAWHS_iud_aggr_reg_bank", MysqlCon.con);
                            cmdb.CommandType = CommandType.StoredProcedure;
                            cmdb.Parameters.Add("Out_orgnbank_rowid", MySqlDbType.Int32).Value = Details.Out_orgnbank_rowid;
                            cmdb.Parameters.Add("Out_bank_acc_no", MySqlDbType.VarChar).Value = Details.Out_bank_acc_no;
                            cmdb.Parameters.Add("Out_bank_acc_type", MySqlDbType.VarChar).Value = Details.Out_bank_acc_type;
                            cmdb.Parameters.Add("Out_bank_code", MySqlDbType.VarChar).Value = Details.Out_bank_code;
                            cmdb.Parameters.Add("Out_branch_code", MySqlDbType.VarChar).Value = Details.Out_branch_code;
                            cmdb.Parameters.Add("Out_ifsc_code", MySqlDbType.VarChar).Value = Details.Out_ifsc_code;
                            cmdb.Parameters.Add("Out_dflt_dr_acc", MySqlDbType.VarChar).Value = Details.Out_dflt_dr_acc;
                            cmdb.Parameters.Add("Out_dflt_cr_acc", MySqlDbType.VarChar).Value = Details.Out_dflt_cr_acc;
                            cmdb.Parameters.Add("Out_bank_acc_purpose", MySqlDbType.VarChar).Value = Details.Out_bank_acc_purpose;
                            cmdb.Parameters.Add("Out_status_code", MySqlDbType.VarChar).Value = Details.Out_status_code;
                            cmdb.Parameters.Add("Out_mode_flag", MySqlDbType.VarChar).Value = Details.Out_mode_flag;
                            cmdb.Parameters.Add("IOU_orgn_rowid", MySqlDbType.VarChar).Value = objAG.document.context.Header.IOU_orgn_rowid;
                            cmdb.Parameters.Add("IOU_aggregator_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.IOU_aggregator_code;
                            cmdb.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objAG.document.context.orgnId;
                            cmdb.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objAG.document.context.locnId;
                            cmdb.Parameters.Add("userId", MySqlDbType.VarChar).Value = objAG.document.context.userId;
                            cmdb.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objAG.document.context.localeId;
                            string Reponse4 = LogHelper.ConvertObjectIntoString(Details);
                            logger.Debug("Input Parameters -" + Reponse4);
                            ret = cmdb.ExecuteNonQuery();
                            LogHelper.ConvertCmdIntoString(cmd);

                            if (ret == 0)
                            {
                                mysqltrans.Rollback();
                                isvaild = false;
                                break;
                            }
                        }
                    }
                    if (isvaild == true)
                    {
                        foreach (var Details in objAG.document.context.Header.Fig)
                        {
                            MySqlCommand cmdf = new MySqlCommand("Admin_PAWHS_iud_aggr_reg_fig", MysqlCon.con);
                            cmdf.CommandType = CommandType.StoredProcedure;
                            cmdf.Parameters.Add("Out_aggrfig_rowid", MySqlDbType.Int32).Value = Details.Out_aggrfig_rowid;
                            cmdf.Parameters.Add("Out_aggrfig_type", MySqlDbType.VarChar).Value = Details.Out_aggrfig_type;
                            cmdf.Parameters.Add("Out_aggrfig_code", MySqlDbType.VarChar).Value = Details.Out_aggrfig_code;
                            cmdf.Parameters.Add("Out_aggrfig_name", MySqlDbType.VarChar).Value = Details.Out_aggrfig_name;
                            cmdf.Parameters.Add("Out_aggrvillage_code", MySqlDbType.VarChar).Value = Details.Out_aggrvillage_code;
                            cmdf.Parameters.Add("Out_aggrvillage_name", MySqlDbType.VarChar).Value = Details.Out_aggrvillage_name;
                            cmdf.Parameters.Add("Out_contact_person", MySqlDbType.VarChar).Value = Details.Out_contact_person;
                            cmdf.Parameters.Add("Out_contact_no", MySqlDbType.VarChar).Value = Details.Out_contact_no;
                            cmdf.Parameters.Add("Out_status_code", MySqlDbType.VarChar).Value = Details.Out_status_code;
                            cmdf.Parameters.Add("Out_mode_flag", MySqlDbType.VarChar).Value = Details.Out_mode_flag;
                            cmdf.Parameters.Add("IOU_orgn_rowid", MySqlDbType.VarChar).Value = objAG.document.context.Header.IOU_orgn_rowid;
                            cmdf.Parameters.Add("IOU_aggregator_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.IOU_aggregator_code;
                            cmdf.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objAG.document.context.orgnId;
                            cmdf.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objAG.document.context.locnId;
                            cmdf.Parameters.Add("userId", MySqlDbType.VarChar).Value = objAG.document.context.userId;
                            cmdf.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objAG.document.context.localeId;
                            
                            ret = cmdf.ExecuteNonQuery();
                            LogHelper.ConvertCmdIntoString(cmd);

                            if (ret == 0)
                            {
                                mysqltrans.Rollback();
                                isvaild = false;
                                break;
                            }
                        }
                    }
                    if (isvaild == true)
                    {
                        mysqltrans.Commit();
                    }
                    MySqlCommand vcmd = new MySqlCommand("Admin_PAWHS_validate_aggr_reg", MysqlCon.con);
                    vcmd.CommandType = CommandType.StoredProcedure;
                    vcmd.Parameters.Add("IOU_orgn_rowid", MySqlDbType.Int32).Value = objAG.document.context.Header.IOU_orgn_rowid;
                    vcmd.Parameters.Add("IOU_aggregator_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.IOU_aggregator_code;
                    vcmd.Parameters.Add("Out_aggregator_type", MySqlDbType.VarChar).Value = objAG.document.context.Header.Out_aggregator_type;
                    vcmd.Parameters.Add("Out_fpo_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.Out_fpo_code;
                    vcmd.Parameters.Add("Out_aggregator_name", MySqlDbType.VarChar).Value = objAG.document.context.Header.Out_aggregator_name;
                    vcmd.Parameters.Add("Out_aggregator_ll_name", MySqlDbType.VarChar).Value = objAG.document.context.Header.Out_aggregator_ll_name;
                    vcmd.Parameters.Add("Out_orgn_level", MySqlDbType.VarChar).Value = objAG.document.context.Header.Out_orgn_level;
                    vcmd.Parameters.Add("Out_facilitator_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.Out_facilitator_code;
                    vcmd.Parameters.Add("Out_facilitator_ll_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.Out_facilitator_ll_code;
                    vcmd.Parameters.Add("Out_member_name", MySqlDbType.VarChar).Value = objAG.document.context.Header.Out_member_name;
                    vcmd.Parameters.Add("Out_member_ll_name", MySqlDbType.VarChar).Value = objAG.document.context.Header.Out_member_ll_name;
                    vcmd.Parameters.Add("Out_status_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.Out_status_code;
                    vcmd.Parameters.Add("Out_mode_flag", MySqlDbType.VarChar).Value = objAG.document.context.Header.Out_mode_flag;
                    vcmd.Parameters.Add("Out_row_timestamp", MySqlDbType.VarChar).Value = objAG.document.context.Header.Out_row_timestamp;
                    vcmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objAG.document.context.userId;
                    vcmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objAG.document.context.orgnId;
                    vcmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objAG.document.context.locnId;
                    vcmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objAG.document.context.localeId;
                    
                    ret = vcmd.ExecuteNonQuery();
                    LogHelper.ConvertCmdIntoString(cmd);

                }
                else
                {
                    mysqltrans.Rollback();
                }
                if (MysqlCon.con.State == ConnectionState.Open)
                {
                    MysqlCon.con.Close();
                }
                ObjFetch.ApplicationException = objex;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                logger.Error("USERNAME :" + objAG.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;

        }
        public AggregatorFetch_application FetchMobileList (AggrFetchContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            AggregatorFetch_application ObjFetchAll = new AggregatorFetch_application();
            ObjFetchAll.context = new AggrFetchContext();
            ObjFetchAll.context.AggrFetchList_Mob = new List<AggeFetchList_Mobile>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_Fetch_Aggregator_Mob", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;            

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AggeFetchList_Mobile objList = new AggeFetchList_Mobile();
                    objList.FPO_Code = dt.Rows[i]["FPO_Code"].ToString();
                    objList.FPO_Name = dt.Rows[i]["FPO_Name"].ToString();
                    objList.orgn_code = dt.Rows[i]["orgn_code"].ToString();
                    objList.orgn_name = dt.Rows[i]["orgn_name"].ToString();
                    objList.FPO_ORGN = dt.Rows[i]["FPO_ORGN"].ToString();
                  
                    ObjFetchAll.context.AggrFetchList_Mob.Add(objList);
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
    }
}
