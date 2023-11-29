using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace FFI_DataModel
{
    public class FDRFpoReg_DB
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FDRFpoReg_DB));
        string methodName = "";
        Admin_ErrorMessageModel ObjErrormsg = new Admin_ErrorMessageModel();
        public RootObjectlist GetAllFPOList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue, string Mysql)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            RootObjectlist ObjFetchAll = new RootObjectlist();
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MysqlCon = new DataConnection(Mysql);
                Contextlist objContext = new Contextlist();
                objContext.orgnId = org;
                objContext.localeId = lang;
                objContext.locnId = locn;
                objContext.userId = user;
                ObjFetchAll.context = objContext;
                MySqlCommand cmd = new MySqlCommand("FDR_fetch_fpo_reg_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("in_filterby_option", MySqlDbType.VarChar).Value = filterby_option;
                cmd.Parameters.Add("in_filterby_code", MySqlDbType.VarChar).Value = filterby_code;
                cmd.Parameters.Add("in_filterby_fromvalue", MySqlDbType.VarChar).Value = filterby_fromvalue;
                cmd.Parameters.Add("in_filterby_tovalue", MySqlDbType.VarChar).Value = filterby_tovalue;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();
                List<FPOList> objRoleLst = new List<FPOList>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FPOList objList = new FPOList();
                    objList.out_orgn_rowid = Convert.ToInt32(dt.Rows[i]["out_orgn_rowid"].ToString());
                    objList.out_orgn_code = dt.Rows[i]["out_orgn_code"].ToString();
                    objList.out_version_no = Convert.ToInt32(dt.Rows[i]["out_version_no"].ToString());
                    objList.out_orgn_cin = dt.Rows[i]["out_orgn_cin"].ToString();
                    objList.out_primary_lang_code = dt.Rows[i]["out_primary_lang_code"].ToString();
                    objList.out_parent_code = dt.Rows[i]["out_parent_code"].ToString();
                    objList.out_orgn_name = dt.Rows[i]["out_orgn_name"].ToString();
                    objList.out_orgn_ll_name = dt.Rows[i]["out_orgn_ll_name"].ToString();
                    objList.out_orgn_level = dt.Rows[i]["out_orgn_level"].ToString();
                    objList.out_orgn_level_desc = dt.Rows[i]["out_orgn_level_desc"].ToString();
                    objList.out_orgn_type = dt.Rows[i]["out_orgn_type"].ToString();
                    objList.out_orgn_type_desc = dt.Rows[i]["out_orgn_type_desc"].ToString();
                    objList.out_orgn_subtype = dt.Rows[i]["out_orgn_subtype"].ToString();
                    objList.out_orgn_subtype_desc = dt.Rows[i]["out_orgn_subtype_desc"].ToString();
                    objList.out_secondary_lang_code = dt.Rows[i]["out_secondary_lang_code"].ToString();
                    objList.out_orgn_logo = dt.Rows[i]["out_orgn_logo"].ToString();
                    objList.out_orgn_auth_sign = dt.Rows[i]["out_orgn_auth_sign"].ToString();
                    objList.out_status_code = dt.Rows[i]["out_status_code"].ToString();
                    objList.out_status_desc = dt.Rows[i]["out_status_desc"].ToString();
                    objList.out_row_timestamp = dt.Rows[i]["out_row_timestamp"].ToString();
                    objRoleLst.Add(objList);
                }
                ObjFetchAll.context.list = objRoleLst;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetchAll;
        }
        public RootObjectFetch FetchFPOReg(string org, string locn, string user, string lang, int fpo_rowid, string fpo_org_code, int version_no, string ConString)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            RootObjectFetch objFetch = new RootObjectFetch();
            DataSet ds = new DataSet();
            DataTable Address = new DataTable();
            DataTable Fig = new DataTable();
            DataTable Bearers = new DataTable();
            DataTable Bank = new DataTable();
            DataTable User = new DataTable();
            DataTable Tax = new DataTable();
            DataTable GeoLoc = new DataTable();
            DataTable Checklist = new DataTable();
            DataTable LoanDet = new DataTable();
            try
            {
                Context1 objContext = new Context1();
                objContext.orgnId = org;
                objContext.localeId = lang;
                objContext.locnId = locn;
                objContext.userId = user;
                objFetch.context = objContext;
                objFetch.context.Header = new Header1();
                objFetch.context.Header.Address = new List<Address1>();
                objFetch.context.Header.Fig = new List<Fig1>();
                objFetch.context.Header.Bearers = new List<Bearer1>();
                objFetch.context.Header.Bank = new List<Bank1>();
                objFetch.context.Header.User = new List<User1>();
                objFetch.context.Header.Tax = new List<Tax1>();
                objFetch.context.Header.GeoLoc = new List<GeoLoc>();
                objFetch.context.Header.CheckList = new List<CheckList1>();
                objFetch.context.Header.LoanDet = new List<LoanDet1>();

                MysqlCon = new DataConnection(ConString);
                MySqlCommand cmd = new MySqlCommand("FDR_fetch_fpo_reg", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("in_orgn_rowid", MySqlDbType.Int32).Value = fpo_rowid;
                cmd.Parameters.Add("in_orgn_code", MySqlDbType.VarChar).Value = fpo_org_code;
                cmd.Parameters.Add("in_version_no", MySqlDbType.Int32).Value = version_no;

                cmd.Parameters.Add(new MySqlParameter("out_orgn_rowid", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_orgn_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_version_no", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_orgn_cin", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_parent_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_orgn_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_orgn_ll_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_orgn_level", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_orgn_level_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_orgn_type", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_orgn_type_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_orgn_subtype", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_orgn_subtype_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_primary_lang_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_secondary_lang_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_orgn_logo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_orgn_auth_sign", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("userId1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("orgnId1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("locnId1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("localeId1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                objFetch.context.Header.out_orgn_rowid = (Int32)cmd.Parameters["out_orgn_rowid"].Value;
                objFetch.context.Header.out_orgn_code = (string)cmd.Parameters["out_orgn_code"].Value;
                objFetch.context.Header.out_version_no = (Int32)cmd.Parameters["out_version_no"].Value;
                objFetch.context.Header.out_orgn_cin = (string)cmd.Parameters["out_orgn_cin"].Value;
                objFetch.context.Header.out_parent_code = (string)cmd.Parameters["out_parent_code"].Value;
                objFetch.context.Header.out_orgn_name = (string)cmd.Parameters["out_orgn_name"].Value;
                objFetch.context.Header.out_orgn_ll_name = (string)cmd.Parameters["out_orgn_ll_name"].Value;
                objFetch.context.Header.out_orgn_level = (string)cmd.Parameters["out_orgn_level"].Value;
                objFetch.context.Header.out_orgn_level_desc = (string)cmd.Parameters["out_orgn_level_desc"].Value;
                objFetch.context.Header.out_orgn_type = (string)cmd.Parameters["out_orgn_type"].Value;
                objFetch.context.Header.out_orgn_type_desc = (string)cmd.Parameters["out_orgn_type_desc"].Value;
                objFetch.context.Header.out_orgn_subtype = (string)cmd.Parameters["out_orgn_subtype"].Value;
                objFetch.context.Header.out_orgn_subtype_desc = (string)cmd.Parameters["out_orgn_subtype_desc"].Value;
                objFetch.context.Header.out_primary_lang_code = (string)cmd.Parameters["out_primary_lang_code"].Value;
                objFetch.context.Header.out_secondary_lang_code = (string)cmd.Parameters["out_secondary_lang_code"].Value;
                objFetch.context.Header.out_status_code = (string)cmd.Parameters["out_status_code"].Value;
                objFetch.context.Header.out_status_desc = (string)cmd.Parameters["out_status_desc"].Value;
                objFetch.context.Header.out_mode_flag = (string)cmd.Parameters["out_mode_flag"].Value;
                objFetch.context.Header.out_row_timestamp = (string)cmd.Parameters["out_row_timestamp"].Value;
                objFetch.context.Header.out_orgn_logo = (string)cmd.Parameters["out_orgn_logo"].Value;
                objFetch.context.Header.out_orgn_auth_sign = (string)cmd.Parameters["out_orgn_auth_sign"].Value;

                if (ds.Tables.Count > 0)
                {
                    Address = ds.Tables[0];
                    for (int i = 0; i < Address.Rows.Count; i++)
                    {
                        Address1 ObjAddr = new Address1();
                        ObjAddr.in_orgnaddr_rowid = Convert.ToInt32(Address.Rows[i]["in_orgnaddr_rowid"]);
                        ObjAddr.in_addr_type = Address.Rows[i]["in_addr_type"].ToString();
                        ObjAddr.addr_type_desc = Address.Rows[i]["addr_type_desc"].ToString();
                        ObjAddr.in_orgn_add1 = Address.Rows[i]["in_orgn_add1"].ToString();
                        ObjAddr.in_orgn_addr2 = Address.Rows[i]["in_orgn_addr2"].ToString();
                        ObjAddr.in_orgn_country = Address.Rows[i]["in_orgn_country"].ToString();
                        ObjAddr.orgn_country_desc = Address.Rows[i]["orgn_country_desc"].ToString();
                        ObjAddr.in_orgn_state = Address.Rows[i]["in_orgn_state"].ToString();
                        ObjAddr.orgn_state_desc = Address.Rows[i]["orgn_state_desc"].ToString();
                        ObjAddr.in_orgn_dist = Address.Rows[i]["in_orgn_dist"].ToString();
                        ObjAddr.orgn_dist_desc = Address.Rows[i]["orgn_dist_desc"].ToString();
                        ObjAddr.in_orgn_taluk = Address.Rows[i]["in_orgn_taluk"].ToString();
                        ObjAddr.orgn_taluk_desc = Address.Rows[i]["orgn_taluk_desc"].ToString();
                        ObjAddr.in_orgn_panchayat = Address.Rows[i]["in_orgn_panchayat"].ToString();
                        ObjAddr.orgn_panchayat_desc = Address.Rows[i]["orgn_panchayat_desc"].ToString();
                        ObjAddr.in_orgn_village = Address.Rows[i]["in_orgn_village"].ToString();
                        ObjAddr.orgn_village_desc = Address.Rows[i]["orgn_village_desc"].ToString();
                        ObjAddr.in_orgn_pincode = Address.Rows[i]["in_orgn_pincode"].ToString();
                        ObjAddr.orgn_pincode_desc = Address.Rows[i]["orgn_pincode_desc"].ToString();
                        ObjAddr.in_status_code = Address.Rows[i]["in_status_code"].ToString();
                        ObjAddr.status_desc = Address.Rows[i]["status_desc"].ToString();
                        ObjAddr.in_mode_flag = Address.Rows[i]["in_mode_flag"].ToString();
                        objFetch.context.Header.Address.Add(ObjAddr);
                    }
                    Fig = ds.Tables[1];
                    for (int i = 0; i < Fig.Rows.Count; i++)
                    {
                        Fig1 ObjFig = new Fig1();
                        ObjFig.in_orgnfig_rowid = Convert.ToInt32(Fig.Rows[i]["in_orgnfig_rowid"]);
                        ObjFig.in_fig_type = Fig.Rows[i]["in_fig_type"].ToString();
                        ObjFig.fig_type_desc = Fig.Rows[i]["fig_type_desc"].ToString();
                        ObjFig.in_fig_short_name = Fig.Rows[i]["in_fig_short_name"].ToString();
                        ObjFig.in_fig_name = Fig.Rows[i]["in_fig_name"].ToString();
                        ObjFig.in_fig_village_covered = Fig.Rows[i]["in_fig_village_covered"].ToString();
                        ObjFig.fig_village_covered_desc = Fig.Rows[i]["fig_village_covered_desc"].ToString();
                        ObjFig.in_fig_president = Fig.Rows[i]["in_fig_president"].ToString();
                        ObjFig.in_fig_treasurer = Fig.Rows[i]["in_fig_treasurer"].ToString();
                        ObjFig.in_fig_secretary = Fig.Rows[i]["in_fig_secretary"].ToString();
                        ObjFig.in_fig_contact_person = Fig.Rows[i]["in_fig_contact_person"].ToString();
                        ObjFig.in_status_code = Fig.Rows[i]["in_status_code"].ToString();
                        ObjFig.status_desc = Fig.Rows[i]["status_desc"].ToString();
                        ObjFig.in_mode_flag = Fig.Rows[i]["in_mode_flag"].ToString();
                        objFetch.context.Header.Fig.Add(ObjFig);
                    }
                    Bearers = ds.Tables[2];
                    for (int i = 0; i < Bearers.Rows.Count; i++)
                    {
                        Bearer1 ObjBearers = new Bearer1();
                        ObjBearers.in_orgnofficebearers_rowid = Convert.ToInt32(Bearers.Rows[i]["in_orgnofficebearers_rowid"]);
                        ObjBearers.in_officebearer_role = Bearers.Rows[i]["in_officebearer_role"].ToString();
                        ObjBearers.officebearer_role_desc = Bearers.Rows[i]["officebearer_role_desc"].ToString();
                        ObjBearers.in_officebearer_name = Bearers.Rows[i]["in_officebearer_name"].ToString();
                        ObjBearers.in_officebearer_contact_no = Bearers.Rows[i]["in_officebearer_contact_no"].ToString();
                        ObjBearers.in_status_code = Bearers.Rows[i]["in_status_code"].ToString();
                        ObjBearers.status_desc = Bearers.Rows[i]["status_desc"].ToString();
                        ObjBearers.in_mode_flag = Bearers.Rows[i]["in_mode_flag"].ToString();
                        objFetch.context.Header.Bearers.Add(ObjBearers);
                    }
                    Bank = ds.Tables[3];
                    for (int i = 0; i < Bank.Rows.Count; i++)
                    {
                        Bank1 ObjBank = new Bank1();
                        ObjBank.in_orgnbank_rowid = Convert.ToInt32(Bank.Rows[i]["in_orgnbank_rowid"]);
                        ObjBank.in_bank_acc_no = Bank.Rows[i]["in_bank_acc_no"].ToString();
                        ObjBank.in_bank_acc_type = Bank.Rows[i]["in_bank_acc_type"].ToString();
                        ObjBank.bank_acc_type_desc = Bank.Rows[i]["bank_acc_type_desc"].ToString();
                        ObjBank.in_bank_code = Bank.Rows[i]["in_bank_code"].ToString();
                        ObjBank.bank_desc = Bank.Rows[i]["bank_desc"].ToString();
                        ObjBank.in_branch_code = Bank.Rows[i]["in_branch_code"].ToString();
                        ObjBank.branch_desc = Bank.Rows[i]["branch_desc"].ToString();
                        ObjBank.in_ifsc_code = Bank.Rows[i]["in_ifsc_code"].ToString();
                        ObjBank.in_dflt_dr_acc = Bank.Rows[i]["in_dflt_dr_acc"].ToString();
                        ObjBank.dflt_dr_acc_desc = Bank.Rows[i]["dflt_dr_acc_desc"].ToString();
                        ObjBank.dflt_cr_acc_desc = Bank.Rows[i]["dflt_cr_acc_desc"].ToString();
                        ObjBank.in_bank_acc_purpose = Bank.Rows[i]["in_bank_acc_purpose"].ToString();
                        ObjBank.bank_acc_purpose_desc = Bank.Rows[i]["bank_acc_purpose_desc"].ToString();
                        ObjBank.in_status_code = Bank.Rows[i]["in_status_code"].ToString();
                        ObjBank.status_desc = Bank.Rows[i]["status_desc"].ToString();
                        ObjBank.in_mode_flag = Bank.Rows[i]["in_mode_flag"].ToString();
                        ObjBank.in_dflt_cr_acc = Bank.Rows[i]["in_dflt_cr_acc"].ToString();
                        objFetch.context.Header.Bank.Add(ObjBank);

                    }
                    User = ds.Tables[4];
                    for (int i = 0; i < User.Rows.Count; i++)
                    {
                        User1 ObjUser = new User1();
                        ObjUser.in_aggrlocuser_rowid = Convert.ToInt32(User.Rows[i]["in_aggrlocuser_rowid"]);
                        ObjUser.in_aggrorgn_type = User.Rows[i]["in_aggrorgn_type"].ToString();
                        ObjUser.aggrorgn_type_desc = User.Rows[i]["aggrorgn_type_desc"].ToString();
                        ObjUser.in_aggrorgn_code = User.Rows[i]["in_aggrorgn_code"].ToString();
                        ObjUser.in_aggrloc_type = User.Rows[i]["in_aggrloc_type"].ToString();
                        ObjUser.aggrloc_type_desc = User.Rows[i]["aggrloc_type_desc"].ToString();
                        ObjUser.in_aggrloc_code = User.Rows[i]["in_aggrloc_code"].ToString();
                        ObjUser.in_role_code = User.Rows[i]["in_role_code"].ToString();
                        ObjUser.in_user_code = User.Rows[i]["in_user_code"].ToString();
                        ObjUser.user_name = User.Rows[i]["user_name"].ToString();
                        ObjUser.email_id = User.Rows[i]["email_id"].ToString();
                        ObjUser.contact_no = User.Rows[i]["contact_no"].ToString();
                        ObjUser.valid_till = User.Rows[i]["valid_till"].ToString();
                        ObjUser.in_status_code = User.Rows[i]["in_status_code"].ToString();
                        ObjUser.status_desc = User.Rows[i]["status_desc"].ToString();
                        ObjUser.in_mode_flag = User.Rows[i]["in_mode_flag"].ToString();
                        objFetch.context.Header.User.Add(ObjUser);
                    }
                    Tax = ds.Tables[5];
                    for (int i = 0; i < Tax.Rows.Count; i++)
                    {
                        Tax1 ObjTax = new Tax1();
                        ObjTax.in_tax_rowid = Convert.ToInt32(Tax.Rows[i]["in_tax_rowid"]);
                        ObjTax.in_tax_type = Tax.Rows[i]["in_tax_type"].ToString();
                        ObjTax.in_tax_reg_no = Tax.Rows[i]["in_tax_reg_no"].ToString();
                        ObjTax.in_state_code = Tax.Rows[i]["in_state_code"].ToString();
                        ObjTax.state_desc = Tax.Rows[i]["state_desc"].ToString();
                        ObjTax.in_status_code = Tax.Rows[i]["in_status_code"].ToString();
                        ObjTax.status_desc = Tax.Rows[i]["status_desc"].ToString();
                        ObjTax.in_mode_flag = Tax.Rows[i]["in_mode_flag"].ToString();
                        objFetch.context.Header.Tax.Add(ObjTax);
                    }
                    GeoLoc = ds.Tables[6];
                    for (int i = 0; i < GeoLoc.Rows.Count; i++)
                    {
                        GeoLoc Objloc = new GeoLoc();
                        Objloc.in_geoloc_rowid = Convert.ToInt32(GeoLoc.Rows[i]["in_orgngeoloc_rowid"]);
                        Objloc.in_geoloc_state = GeoLoc.Rows[i]["in_orgn_state"].ToString(); 
                        Objloc.geoloc_state_desc = GeoLoc.Rows[i]["orgn_state_desc"].ToString();
                        Objloc.in_geoloc_dist = GeoLoc.Rows[i]["in_orgn_dist"].ToString();
                        Objloc.geoloc_dist_desc = GeoLoc.Rows[i]["orgn_dist_desc"].ToString();
                        Objloc.in_geoloc_taluk = GeoLoc.Rows[i]["in_orgn_taluk"].ToString();
                        Objloc.geoloc_taluk_desc = GeoLoc.Rows[i]["orgn_taluk_desc"].ToString();
                        Objloc.in_geoloc_panchayat = GeoLoc.Rows[i]["in_orgn_panchayat"].ToString();
                        Objloc.geoloc_panchayat_desc = GeoLoc.Rows[i]["orgn_panchayat_desc"].ToString();
                        Objloc.in_geoloc_village = GeoLoc.Rows[i]["in_orgn_village"].ToString();
                        Objloc.geoloc_village_desc = GeoLoc.Rows[i]["orgn_village_desc"].ToString();
                        Objloc.in_status_code = GeoLoc.Rows[i]["in_status_code"].ToString();
                        Objloc.status_desc = GeoLoc.Rows[i]["status_desc"].ToString();
                        Objloc.in_mode_flag = GeoLoc.Rows[i]["in_mode_flag"].ToString();
                        objFetch.context.Header.GeoLoc.Add(Objloc);
                    }
                    Checklist = ds.Tables[7];
                    for (int i = 0; i < Checklist.Rows.Count; i++)
                    {
                        CheckList1 Objchklst = new CheckList1();
                        Objchklst.in_checklist_rowid = Convert.ToInt32(Checklist.Rows[i]["in_checklist_rowid"]);
                        Objchklst.in_checklist_code = Checklist.Rows[i]["in_checklist_code"].ToString();
                        Objchklst.checklist_desc = Checklist.Rows[i]["checklist_desc"].ToString();
                        Objchklst.in_complied_code = Checklist.Rows[i]["in_complied_code"].ToString();
                        Objchklst.in_complied_desc = Checklist.Rows[i]["in_complied_desc"].ToString();
                        Objchklst.in_attachment = Checklist.Rows[i]["in_attachment"].ToString();
                        Objchklst.in_status_code = Checklist.Rows[i]["in_status_code"].ToString();
                        Objchklst.status_desc = Checklist.Rows[i]["status_desc"].ToString();
                        Objchklst.in_mode_flag = Checklist.Rows[i]["in_mode_flag"].ToString();
                        objFetch.context.Header.CheckList.Add(Objchklst);
                    }
                    LoanDet = ds.Tables[8];
                    for (int i = 0; i < LoanDet.Rows.Count; i++)
                    {
                        LoanDet1 Objloandet = new LoanDet1();
                        Objloandet.in_loan_rowid = Convert.ToInt32(LoanDet.Rows[i]["in_loan_rowid"]);
                        Objloandet.in_loan_type = LoanDet.Rows[i]["in_loan_type"].ToString();
                        Objloandet.in_loan_from = LoanDet.Rows[i]["in_loan_from"].ToString();
                        Objloandet.in_loan_amount = LoanDet.Rows[i]["in_loan_amount"].ToString();
                        Objloandet.in_loan_tenor = LoanDet.Rows[i]["in_loan_tenor"].ToString();
                        Objloandet.in_institution_name = LoanDet.Rows[i]["in_institution_name"].ToString();
                        Objloandet.in_institution_branch = LoanDet.Rows[i]["in_institution_branch"].ToString();
                        Objloandet.in_interest_rate = LoanDet.Rows[i]["in_interest_rate"].ToString();
                        Objloandet.in_emi_amount = LoanDet.Rows[i]["in_emi_amount"].ToString();
                        Objloandet.in_loan_start_date = LoanDet.Rows[i]["in_loan_start_date"].ToString();
                        Objloandet.in_loan_end_date = LoanDet.Rows[i]["in_loan_end_date"].ToString();
                        Objloandet.in_collateral_security = LoanDet.Rows[i]["in_collateral_security"].ToString();
                        Objloandet.in_status_code = LoanDet.Rows[i]["in_status_code"].ToString();
                        Objloandet.status_desc = LoanDet.Rows[i]["status_desc"].ToString();
                        Objloandet.in_mode_flag = LoanDet.Rows[i]["in_mode_flag"].ToString();
                        objFetch.context.Header.LoanDet.Add(Objloandet);
                    }

                }
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objFetch;
        }
        public FPODocument SaveFPOReg(FPORootObject objFP, string ConString)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            FPODocument objOutFp = new FPODocument();
            int ret = 0;
            string[] resultAddr = { };
            string[] resultFig = { };
            string[] resultBearer = { };
            string[] resultBankDtl = { };
            string[] resultUserDtl = { };
            string[] resultTaxDtl = { };
            string[] resultGeoLocDtl = { };
            string[] resultChecklistDtl = { };
            string[] resultLoanDtl = { };
            DataConnection con = new DataConnection(ConString);
            MysqlCon = new DataConnection(ConString);
            objOutFp.ApplicationException = new ApplicationExceptionlist();
            objOutFp.context = new FPOContext();
            objOutFp.context.header = new FPOHeader();
            objOutFp.context.header.address = new List<FPOAddress>();
            objOutFp.context.header.fig = new List<Fig>();
            objOutFp.context.header.bearers = new List<Bearer>();
            objOutFp.context.header.bank = new List<Bank>();
            objOutFp.context.header.user = new List<User>();
            objOutFp.context.header.tax = new List<Tax>();
            objOutFp.context.header.GeoLoc = new List<GeoLoc>();
            objOutFp.context.header.CheckList = new List<CheckList>();
            objOutFp.context.header.LoanDet = new List<LoanDet>();
            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }
                MySqlCommand cmd = new MySqlCommand("FDR_insupd_fpo_reg", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objFP.document.context.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objFP.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objFP.document.context.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objFP.document.context.localeId;
                cmd.Parameters.Add("inout_orgn_rowid", MySqlDbType.Int32).Value = objFP.document.context.header.inout_orgn_rowid;
                cmd.Parameters.Add("inout_orgn_code", MySqlDbType.VarChar).Value = objFP.document.context.header.inout_orgn_code;
                cmd.Parameters.Add("inout_version_no", MySqlDbType.Int32).Value = objFP.document.context.header.inout_version_no;
                cmd.Parameters.Add("in_orgn_cin", MySqlDbType.VarChar).Value = objFP.document.context.header.in_orgn_cin;
                cmd.Parameters.Add("in_parent_code", MySqlDbType.VarChar).Value = objFP.document.context.header.in_parent_code;
                cmd.Parameters.Add("in_orgn_name", MySqlDbType.VarChar).Value = objFP.document.context.header.in_orgn_name;
                cmd.Parameters.Add("in_orgn_ll_name", MySqlDbType.VarChar).Value = objFP.document.context.header.in_orgn_ll_name;
                cmd.Parameters.Add("in_orgn_level", MySqlDbType.VarChar).Value = objFP.document.context.header.in_orgn_level;
                cmd.Parameters.Add("in_orgn_type", MySqlDbType.VarChar).Value = objFP.document.context.header.in_orgn_type;
                cmd.Parameters.Add("in_orgn_subtype", MySqlDbType.VarChar).Value = objFP.document.context.header.in_orgn_subtype;
                cmd.Parameters.Add("in_primary_lang_code", MySqlDbType.VarChar).Value = objFP.document.context.header.in_primary_lang_code;
                cmd.Parameters.Add("in_secondary_lang_code", MySqlDbType.VarChar).Value = objFP.document.context.header.in_secondary_lang_code;
                cmd.Parameters.Add("in_orgn_logo", MySqlDbType.VarChar).Value = objFP.document.context.header.in_orgn_logo;
                cmd.Parameters.Add("in_orgn_auth_sign", MySqlDbType.VarChar).Value = objFP.document.context.header.in_orgn_auth_sign;
                cmd.Parameters.Add("in_status_code", MySqlDbType.VarChar).Value = objFP.document.context.header.in_status_code;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = objFP.document.context.header.in_mode_flag;
                cmd.Parameters.Add("in_row_timestamp", MySqlDbType.VarChar).Value = objFP.document.context.header.in_row_timestamp;

                cmd.Parameters.Add(new MySqlParameter("inout_orgn_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("inout_orgn_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("inout_version_no1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                if (ret > 0)
                {
                    objOutFp.context.header.inout_orgn_rowid = (Int32)cmd.Parameters["inout_orgn_rowid1"].Value;
                    objOutFp.context.header.inout_orgn_code = (string)cmd.Parameters["inout_orgn_code1"].Value;
                    objOutFp.context.header.inout_version_no = (Int32)cmd.Parameters["inout_version_no1"].Value;
                    objOutFp.context.orgnId = objFP.document.context.orgnId;
                    objOutFp.context.locnId = objFP.document.context.locnId;
                    objOutFp.context.userId = objFP.document.context.userId;
                    objOutFp.context.localeId = objFP.document.context.localeId;
                }
                if (cmd.Parameters["errorNo"].Value.ToString() != "")
                {
                    objOutFp.ApplicationException.errorNumber = cmd.Parameters["errorNo"].Value.ToString();
                    objOutFp.ApplicationException.errorDescription = ObjErrormsg.ErrorMessage(objOutFp.ApplicationException.errorNumber);
                    mysqltrans.Rollback();
                    return objOutFp;
                }

                if (objOutFp.context.header.inout_orgn_rowid > 0)
                {
                    if (objFP.document.context.header.address.Count > 0)
                    {
                        resultAddr = SaveAddrDtl(objFP, objOutFp, ConString, MysqlCon);
                        if (resultAddr[0].ToString() != "")
                        {
                            mysqltrans.Rollback();
                            objOutFp.ApplicationException.errorNumber = resultAddr[0].ToString();
                            objOutFp.ApplicationException.errorDescription = resultAddr[1].ToString();
                            return objOutFp;
                        }
                    }
                    if (objFP.document.context.header.fig.Count > 0)
                    {
                        resultFig = SaveFigDtl(objFP, objOutFp, ConString, MysqlCon);
                        if (resultFig[0].ToString() != "")
                        {
                            mysqltrans.Rollback();
                            objOutFp.ApplicationException.errorNumber = resultFig[0].ToString();
                            objOutFp.ApplicationException.errorDescription = resultFig[1].ToString();
                            return objOutFp;
                        }
                    }
                    if (objFP.document.context.header.bearers.Count>0)
                    {
                        resultBearer = SaveBearerDtl(objFP, objOutFp, ConString, MysqlCon);
                        if (resultBearer[0].ToString() != "")
                        {
                            mysqltrans.Rollback();
                            objOutFp.ApplicationException.errorNumber = resultBearer[0].ToString();
                            objOutFp.ApplicationException.errorDescription = resultBearer[1].ToString();
                            return objOutFp;
                        }
                    }
                    if (objFP.document.context.header.bank.Count > 0)
                    {
                        resultBankDtl = SaveBankDtl(objFP, objOutFp, ConString, MysqlCon);
                        if (resultBankDtl[0].ToString() != "")
                        {
                            mysqltrans.Rollback();
                            objOutFp.ApplicationException.errorNumber = resultBankDtl[0].ToString();
                            objOutFp.ApplicationException.errorDescription = resultBankDtl[1].ToString();
                            return objOutFp;
                        }
                    }
                    if(objFP.document.context.header.tax.Count > 0)
                    {
                        resultTaxDtl = SaveTaxDtl(objFP, objOutFp, ConString, MysqlCon);
                        if (resultTaxDtl[0].ToString() != "")
                        {
                            mysqltrans.Rollback();
                            objOutFp.ApplicationException.errorNumber = resultTaxDtl[0].ToString();
                            objOutFp.ApplicationException.errorDescription = resultTaxDtl[1].ToString();
                            return objOutFp;
                        }
                    }

                    if (objFP.document.context.header.GeoLoc.Count > 0)
                    {
                        resultGeoLocDtl = SaveGeoLocation(objFP, objOutFp, ConString, MysqlCon);
                        if (resultGeoLocDtl[0].ToString() != "")
                        {
                            mysqltrans.Rollback();
                            objOutFp.ApplicationException.errorNumber = resultGeoLocDtl[0].ToString();
                            objOutFp.ApplicationException.errorDescription = resultGeoLocDtl[1].ToString();
                            return objOutFp;
                        }
                    }
                    if (objFP.document.context.header.CheckList.Count > 0)
                    {
                        resultChecklistDtl = SaveCheckList(objFP, objOutFp, ConString, MysqlCon);
                        if (resultChecklistDtl[0].ToString() != "")
                        {
                            mysqltrans.Rollback();
                            objOutFp.ApplicationException.errorNumber = resultChecklistDtl[0].ToString();
                            objOutFp.ApplicationException.errorDescription = resultChecklistDtl[1].ToString();
                            return objOutFp;
                        }
                    }
                    if (objFP.document.context.header.LoanDet.Count > 0)
                    {
                        resultLoanDtl = SaveLoanDet(objFP, objOutFp, ConString, MysqlCon);
                        if (resultLoanDtl[0].ToString() != "")
                        {
                            mysqltrans.Rollback();
                            objOutFp.ApplicationException.errorNumber = resultLoanDtl[0].ToString();
                            objOutFp.ApplicationException.errorDescription = resultLoanDtl[1].ToString();
                            return objOutFp;
                        }
                    }




                    mysqltrans.Commit();
                }
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objFP.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objOutFp;
        }
        public string[] SaveAddrDtl(FPORootObject Objmodel, FPODocument objFPODocument, string MysqlCons, DataConnection MysqlCon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            int ret = 0;

            string errorNo = "";
            string errorMsg = "";
            try
            {
                foreach (var AddrDetails in Objmodel.document.context.header.address)
                {
                    MySqlCommand cmd = new MySqlCommand("FDR_iud_fpo_reg", MysqlCon.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("inout_orgn_code", MySqlDbType.VarChar).Value = objFPODocument.context.header.inout_orgn_code;
                    cmd.Parameters.Add("inout_version_no", MySqlDbType.Int32).Value = objFPODocument.context.header.inout_version_no;
                    cmd.Parameters.Add("in_orgnaddr_rowid", MySqlDbType.Int32).Value = AddrDetails.in_orgnaddr_rowid;
                    cmd.Parameters.Add("in_addr_type", MySqlDbType.VarChar).Value = AddrDetails.in_addr_type;
                    cmd.Parameters.Add("in_orgn_add1", MySqlDbType.VarChar).Value = AddrDetails.in_orgn_add1;
                    cmd.Parameters.Add("in_orgn_addr2", MySqlDbType.VarChar).Value = AddrDetails.in_orgn_addr2;
                    cmd.Parameters.Add("in_orgn_country", MySqlDbType.VarChar).Value = AddrDetails.in_orgn_country;
                    cmd.Parameters.Add("in_orgn_state", MySqlDbType.VarChar).Value = AddrDetails.in_orgn_state;
                    cmd.Parameters.Add("in_orgn_dist", MySqlDbType.VarChar).Value = AddrDetails.in_orgn_dist;
                    cmd.Parameters.Add("in_orgn_taluk", MySqlDbType.VarChar).Value = AddrDetails.in_orgn_taluk;
                    cmd.Parameters.Add("in_orgn_panchayat", MySqlDbType.VarChar).Value = AddrDetails.in_orgn_panchayat;
                    cmd.Parameters.Add("in_orgn_village", MySqlDbType.VarChar).Value = AddrDetails.in_orgn_village;
                    cmd.Parameters.Add("in_orgn_pincode", MySqlDbType.VarChar).Value = AddrDetails.in_orgn_pincode;
                    cmd.Parameters.Add("in_status_code", MySqlDbType.VarChar).Value = AddrDetails.in_status_code;
                    cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = AddrDetails.in_mode_flag;
                    cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                    cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                    cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                    cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                    cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                    ret = cmd.ExecuteNonQuery();
                    LogHelper.ConvertCmdIntoString(cmd);
                    if (ret == 0)
                    {
                        errorNo = (string)cmd.Parameters["errorNo"].Value;
                        errorMsg = ObjErrormsg.ErrorMessage(errorNo);
                        break;
                    }
                }
                string[] result = { errorNo, errorMsg };
                return result;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                throw ex;
            }
        }
        public string[] SaveFigDtl(FPORootObject Objmodel, FPODocument objFPODocument, string MysqlCons, DataConnection MysqlCon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            int ret = 0;

            string errorNo = "";
            string errorMsg = "";
            try
            {
                foreach (var FigDetails in Objmodel.document.context.header.fig)
                {
                    MySqlCommand cmd = new MySqlCommand("FDR_iud_fpo_fig", MysqlCon.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("inout_orgn_code", MySqlDbType.VarChar).Value = objFPODocument.context.header.inout_orgn_code;
                    cmd.Parameters.Add("inout_version_no", MySqlDbType.Int32).Value = objFPODocument.context.header.inout_version_no;
                    cmd.Parameters.Add("in_orgnfig_rowid", MySqlDbType.Int32).Value = FigDetails.in_orgnfig_rowid;
                    cmd.Parameters.Add("in_fig_type", MySqlDbType.VarChar).Value = FigDetails.in_fig_type;
                    cmd.Parameters.Add("in_fig_short_name", MySqlDbType.VarChar).Value = FigDetails.in_fig_short_name;
                    cmd.Parameters.Add("in_fig_name", MySqlDbType.VarChar).Value = FigDetails.in_fig_name;
                    cmd.Parameters.Add("in_fig_village_covered", MySqlDbType.VarChar).Value = FigDetails.in_fig_village_covered;
                    cmd.Parameters.Add("in_fig_president", MySqlDbType.VarChar).Value = FigDetails.in_fig_president;
                    cmd.Parameters.Add("in_fig_treasurer", MySqlDbType.VarChar).Value = FigDetails.in_fig_treasurer;
                    cmd.Parameters.Add("in_fig_secretary", MySqlDbType.VarChar).Value = FigDetails.in_fig_secretary;
                    cmd.Parameters.Add("in_fig_contact_person", MySqlDbType.VarChar).Value = FigDetails.in_fig_contact_person;
                    cmd.Parameters.Add("in_status_code", MySqlDbType.VarChar).Value = FigDetails.in_status_code;
                    cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = FigDetails.in_mode_flag;
                    cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                    cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                    cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                    cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                    cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                    ret = cmd.ExecuteNonQuery();
                    LogHelper.ConvertCmdIntoString(cmd);
                    if (ret == 0)
                    {
                        errorNo = (string)cmd.Parameters["errorNo"].Value;
                        errorMsg = ObjErrormsg.ErrorMessage(errorNo);
                        break;
                    }
                }
                string[] result = { errorNo, errorMsg };
                return result;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                throw ex;
            }
        }
        public string[] SaveBearerDtl(FPORootObject Objmodel, FPODocument objFPODocument, string MysqlCons, DataConnection MysqlCon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            int ret = 0;

            string errorNo = "";
            string errorMsg = "";
            try
            {
                foreach (var BearerDetails in Objmodel.document.context.header.bearers)
                {
                    MySqlCommand cmd = new MySqlCommand("FDR_iud_fpo_bearers", MysqlCon.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("inout_orgn_code", MySqlDbType.VarChar).Value = objFPODocument.context.header.inout_orgn_code;
                    cmd.Parameters.Add("inout_version_no", MySqlDbType.Int32).Value = objFPODocument.context.header.inout_version_no;
                    cmd.Parameters.Add("in_orgnofficebearers_rowid", MySqlDbType.Int32).Value = BearerDetails.in_orgnofficebearers_rowid;
                    cmd.Parameters.Add("in_officebearer_role", MySqlDbType.VarChar).Value = BearerDetails.in_officebearer_role;
                    cmd.Parameters.Add("in_officebearer_name", MySqlDbType.VarChar).Value = BearerDetails.in_officebearer_name;
                    cmd.Parameters.Add("in_officebearer_contact_no", MySqlDbType.VarChar).Value = BearerDetails.in_officebearer_contact_no;
                    cmd.Parameters.Add("in_status_code", MySqlDbType.VarChar).Value = BearerDetails.in_status_code;
                    cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = BearerDetails.in_mode_flag;                   
                    cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                    cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                    cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                    cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                    cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                    ret = cmd.ExecuteNonQuery();
                    LogHelper.ConvertCmdIntoString(cmd);
                    if (ret == 0)
                    {
                        errorNo = (string)cmd.Parameters["errorNo"].Value;
                        errorMsg = ObjErrormsg.ErrorMessage(errorNo);
                        break;
                    }
                }
                string[] result = { errorNo, errorMsg };
                return result;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                throw ex;
            }
        }
        public string[] SaveBankDtl(FPORootObject Objmodel, FPODocument objFPODocument, string MysqlCons, DataConnection MysqlCon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            int ret = 0;

            string errorNo = "";
            string errorMsg = "";
            try
            {
                foreach (var BankDetails in Objmodel.document.context.header.bank)
                {
                    MySqlCommand cmd = new MySqlCommand("FDR_iud_fpo_reg_bank", MysqlCon.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("inout_orgn_code", MySqlDbType.VarChar).Value = objFPODocument.context.header.inout_orgn_code;
                    cmd.Parameters.Add("inout_version_no", MySqlDbType.Int32).Value = objFPODocument.context.header.inout_version_no;
                    cmd.Parameters.Add("in_orgnbank_rowid", MySqlDbType.Int32).Value = BankDetails.in_orgnbank_rowid;
                    cmd.Parameters.Add("in_bank_acc_no", MySqlDbType.VarChar).Value = BankDetails.in_bank_acc_no;
                    cmd.Parameters.Add("in_bank_acc_type", MySqlDbType.VarChar).Value = BankDetails.in_bank_acc_type;
                    cmd.Parameters.Add("in_bank_code", MySqlDbType.VarChar).Value = BankDetails.in_bank_code;
                    cmd.Parameters.Add("in_branch_code", MySqlDbType.VarChar).Value = BankDetails.in_branch_code;
                    cmd.Parameters.Add("in_ifsc_code", MySqlDbType.VarChar).Value = BankDetails.in_ifsc_code;
                    cmd.Parameters.Add("in_dflt_dr_acc", MySqlDbType.VarChar).Value = BankDetails.in_dflt_dr_acc;
                    cmd.Parameters.Add("in_dflt_cr_acc", MySqlDbType.VarChar).Value = BankDetails.in_dflt_cr_acc;
                    cmd.Parameters.Add("in_bank_acc_purpose", MySqlDbType.VarChar).Value = BankDetails.in_bank_acc_purpose;
                    cmd.Parameters.Add("in_status_code", MySqlDbType.VarChar).Value = BankDetails.in_status_code;
                    cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = BankDetails.in_mode_flag;
                    cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                    cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                    cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                    cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                    cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                    ret = cmd.ExecuteNonQuery();
                    LogHelper.ConvertCmdIntoString(cmd);
                    if (ret == 0)
                    {
                        errorNo = (string)cmd.Parameters["errorNo"].Value;
                        errorMsg = ObjErrormsg.ErrorMessage(errorNo);
                        break;
                    }
                }
                string[] result = { errorNo, errorMsg };
                return result;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                throw ex;
            }
        }
        public string[] SaveTaxDtl(FPORootObject Objmodel, FPODocument objFPODocument, string MysqlCons, DataConnection MysqlCon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            int ret = 0;

            string errorNo = "";
            string errorMsg = "";
            try
            {
                foreach (var TaxDetails in Objmodel.document.context.header.tax)
                {
                    MySqlCommand cmd = new MySqlCommand("FDR_iud_fpo_reg_tax", MysqlCon.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("inout_orgn_code", MySqlDbType.VarChar).Value = objFPODocument.context.header.inout_orgn_code;
                    cmd.Parameters.Add("inout_version_no", MySqlDbType.Int32).Value = objFPODocument.context.header.inout_version_no;
                    cmd.Parameters.Add("in_tax_rowid", MySqlDbType.Int32).Value = TaxDetails.in_tax_rowid;
                    cmd.Parameters.Add("in_tax_type", MySqlDbType.VarChar).Value = TaxDetails.in_tax_type;
                    cmd.Parameters.Add("in_tax_reg_no", MySqlDbType.VarChar).Value = TaxDetails.in_tax_reg_no;
                    cmd.Parameters.Add("in_state_code", MySqlDbType.VarChar).Value = TaxDetails.in_state_code;
                    cmd.Parameters.Add("in_status_code", MySqlDbType.VarChar).Value = TaxDetails.in_status_code;
                    cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = TaxDetails.in_mode_flag;                   
                    cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                    cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                    cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                    cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;                  
                    ret = cmd.ExecuteNonQuery();
                    LogHelper.ConvertCmdIntoString(cmd);
                    if (ret == 0)
                    {
                        errorNo = "18028";
                        errorMsg = ObjErrormsg.ErrorMessage(errorNo);
                        break;
                    }
                }
                string[] result = { errorNo, errorMsg };
                return result;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                throw ex;
            }
        }
        public string[] SaveGeoLocation(FPORootObject Objmodel, FPODocument objFPODocument, string MysqlCons, DataConnection MysqlCon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            int ret = 0;

            string errorNo = "";
            string errorMsg = "";
            try
            {
                foreach (var GeoDetails in Objmodel.document.context.header.GeoLoc)
                {
                    MySqlCommand cmd = new MySqlCommand("FDR_iud_fporeg_geolocation", MysqlCon.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("inout_orgn_code", MySqlDbType.VarChar).Value = objFPODocument.context.header.inout_orgn_code;
                    cmd.Parameters.Add("inout_version_no", MySqlDbType.Int32).Value = objFPODocument.context.header.inout_version_no;
                    cmd.Parameters.Add("in_orgnaddr_rowid", MySqlDbType.Int32).Value = GeoDetails.in_geoloc_rowid; 
                    cmd.Parameters.Add("in_orgn_country", MySqlDbType.VarChar).Value = GeoDetails.in_geoloc_country;
                    cmd.Parameters.Add("in_orgn_state", MySqlDbType.VarChar).Value = GeoDetails.in_geoloc_state;
                    cmd.Parameters.Add("in_orgn_dist", MySqlDbType.VarChar).Value = GeoDetails.in_geoloc_dist;
                    cmd.Parameters.Add("in_orgn_taluk", MySqlDbType.VarChar).Value = GeoDetails.in_geoloc_taluk;
                    cmd.Parameters.Add("in_orgn_panchayat", MySqlDbType.VarChar).Value = GeoDetails.in_geoloc_panchayat;
                    cmd.Parameters.Add("in_orgn_village", MySqlDbType.VarChar).Value = GeoDetails.in_geoloc_village; 
                    cmd.Parameters.Add("in_status_code", MySqlDbType.VarChar).Value = GeoDetails.in_status_code;
                    cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = GeoDetails.in_mode_flag;
                    cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                    cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                    cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                    cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                    cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                    ret = cmd.ExecuteNonQuery();
                    LogHelper.ConvertCmdIntoString(cmd);
                    if (ret == 0)
                    {
                        errorNo = (string)cmd.Parameters["errorNo"].Value;
                        errorMsg = ObjErrormsg.ErrorMessage(errorNo);
                        break;
                    }
                }
                string[] result = { errorNo, errorMsg };
                return result;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                throw ex;
            }
        }
        public string[] SaveCheckList(FPORootObject Objmodel, FPODocument objFPODocument, string MysqlCons, DataConnection MysqlCon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            int ret = 0;

            string errorNo = "";
            string errorMsg = "";
            try
            {
                foreach (var ChecklistDetails in Objmodel.document.context.header.CheckList)
                {
                    MySqlCommand cmd = new MySqlCommand("FDR_iud_fporeg_checklist", MysqlCon.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("inout_orgn_code", MySqlDbType.VarChar).Value = objFPODocument.context.header.inout_orgn_code;
                    cmd.Parameters.Add("inout_version_no", MySqlDbType.Int32).Value = objFPODocument.context.header.inout_version_no;
                    cmd.Parameters.Add("in_checklist_rowid", MySqlDbType.Int32).Value = ChecklistDetails.in_checklist_rowid;
                    cmd.Parameters.Add("in_checklist_code", MySqlDbType.VarChar).Value = ChecklistDetails.in_checklist_code;
                    cmd.Parameters.Add("checklist_desc", MySqlDbType.VarChar).Value = ChecklistDetails.checklist_desc;
                    cmd.Parameters.Add("in_complied_code", MySqlDbType.VarChar).Value = ChecklistDetails.in_complied_code;
                    cmd.Parameters.Add("in_complied_desc", MySqlDbType.VarChar).Value = ChecklistDetails.in_complied_desc;
                    cmd.Parameters.Add("in_attachment", MySqlDbType.VarChar).Value = ChecklistDetails.in_attachment;
                    cmd.Parameters.Add("in_status_code", MySqlDbType.VarChar).Value = ChecklistDetails.in_status_code;
                    cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = ChecklistDetails.in_mode_flag;
                    cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                    cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                    cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                    cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                    cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                    ret = cmd.ExecuteNonQuery();
                    LogHelper.ConvertCmdIntoString(cmd);
                    if (ret == 0)
                    {
                        errorNo = (string)cmd.Parameters["errorNo"].Value;
                        errorMsg = ObjErrormsg.ErrorMessage(errorNo);
                        break;
                    }
                }
                string[] result = { errorNo, errorMsg };
                return result;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                throw ex;
            }
        }
        public string[] SaveLoanDet(FPORootObject Objmodel, FPODocument objFPODocument, string MysqlCons, DataConnection MysqlCon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            int ret = 0;

            string errorNo = "";
            string errorMsg = "";
            try
            {
                foreach (var LoanDetails in Objmodel.document.context.header.LoanDet)
                {
                    MySqlCommand cmd = new MySqlCommand("FDR_iud_fporeg_loandetails", MysqlCon.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("inout_orgn_code", MySqlDbType.VarChar).Value = objFPODocument.context.header.inout_orgn_code;
                    cmd.Parameters.Add("inout_version_no", MySqlDbType.Int32).Value = objFPODocument.context.header.inout_version_no;
                    cmd.Parameters.Add("in_loan_rowid", MySqlDbType.Int32).Value = LoanDetails.in_loan_rowid;
                    cmd.Parameters.Add("in_loan_type", MySqlDbType.VarChar).Value = LoanDetails.in_loan_type;
                    cmd.Parameters.Add("in_loan_from", MySqlDbType.VarChar).Value = LoanDetails.in_loan_from;
                    cmd.Parameters.Add("in_loan_amount", MySqlDbType.Double).Value = LoanDetails.in_loan_amount;
                    cmd.Parameters.Add("in_loan_tenor", MySqlDbType.Double).Value = LoanDetails.in_loan_tenor;
                    cmd.Parameters.Add("in_loan_start_date", MySqlDbType.Date).Value = LoanDetails.in_loan_start_date;
                    cmd.Parameters.Add("in_loan_end_date", MySqlDbType.Date).Value = LoanDetails.in_loan_end_date;
                    cmd.Parameters.Add("in_institution_name", MySqlDbType.VarChar).Value = LoanDetails.in_institution_name;
                    cmd.Parameters.Add("in_institution_branch", MySqlDbType.VarChar).Value = LoanDetails.in_institution_branch;
                    cmd.Parameters.Add("in_interest_rate", MySqlDbType.Double).Value = LoanDetails.in_interest_rate;
                    cmd.Parameters.Add("in_emi_amount", MySqlDbType.Double).Value = LoanDetails.in_emi_amount;
                    cmd.Parameters.Add("in_collateral_security", MySqlDbType.Double).Value = LoanDetails.in_collateral_security;
                    cmd.Parameters.Add("in_status_code", MySqlDbType.VarChar).Value = LoanDetails.in_status_code;
                    cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = LoanDetails.in_mode_flag;
                    cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                    cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                    cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                    cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                    cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                    ret = cmd.ExecuteNonQuery();
                    LogHelper.ConvertCmdIntoString(cmd);
                    if (ret == 0)
                    {
                        errorNo = (string)cmd.Parameters["errorNo"].Value;
                        errorMsg = ObjErrormsg.ErrorMessage(errorNo);
                        break;
                    }
                }
                string[] result = { errorNo, errorMsg };
                return result;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                throw ex;
            }
        }


    }
}
