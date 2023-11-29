using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FFI_Model;


namespace FFI_DataModel
{
   public class PAWHS_New_Aggregator_Datamodel
    {
        //
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        Admin_ErrorMessageModel ObjErrormsg = new Admin_ErrorMessageModel();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Admin_RoleManagementDataModel));
        // Exception Log Method Name Purpose written start 
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public New_PAWHSAggregator_all_Application GetAllpawhs_aggregator_List(New_PAWHSAggregator_all_Context ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            New_PAWHSAggregator_all_Application ObjFetchAll = new New_PAWHSAggregator_all_Application();
            ObjFetchAll.context = new New_PAWHSAggregator_all_Context();
            ObjFetchAll.context.List = new List<New_PAWHSAggregator_all_List>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Admin_PAWHS_fetch_aggr_reg_list", MysqlCon.con);
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
                    New_PAWHSAggregator_all_List objList = new New_PAWHSAggregator_all_List();
                    objList.Out_orgn_rowid = Convert.ToInt32(dt.Rows[i]["Out_orgn_rowid"]);
                    objList.Out_aggregator_code = dt.Rows[i]["Out_aggregator_code"].ToString();
                    objList.Out_aggregator_name = dt.Rows[i]["Out_aggregator_name"].ToString();
                    objList.Out_orgn_level = dt.Rows[i]["Out_orgn_level"].ToString();
                    objList.Out_aggregator_type = dt.Rows[i]["Out_aggregator_type"].ToString(); 
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

        public New_PAWHSAggregator_single_Application Single_new_pawhs_aggregator(New_PAWHSAggregator_single_Context objfpoSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();

            New_PAWHSAggregator_single_Application objfpoSearchRoot = new New_PAWHSAggregator_single_Application();
            PAWHSProductmaster_Datamodel objDataModel = new PAWHSProductmaster_Datamodel();

            DataTable Map = new DataTable();


            objfpoSearchRoot.context = new New_PAWHSAggregator_single_Context();
            objfpoSearchRoot.context.Header = new New_PAWHSAggregator_single_Header();
            objfpoSearchRoot.context.Address = new List<New_PAWHSAggregator_single_Address>();
            objfpoSearchRoot.context.Bank = new List<New_PAWHSAggregator_single_Bank>();
            objfpoSearchRoot.context.FIG = new List<New_PAWHSAggregator_single_FIG>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("Admin_PAWHS_fetch_aggr_reg", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;
                cmd.Parameters.Add("IOU_orgn_rowid", MySqlDbType.Int32).Value = objfpoSearch.Header. IOU_orgn_rowid;
                cmd.Parameters.Add("IOU_aggregator_code", MySqlDbType.VarChar).Value = objfpoSearch.Header.IOU_aggregator_code; 
                cmd.Parameters.Add(new MySqlParameter("IOU_orgn_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
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
                if (ds.Tables.Count > 0)
                {
                    objfpoSearchRoot.context.orgnId = objfpoSearch.orgnId;
                    objfpoSearchRoot.context.locnId = objfpoSearch.locnId;
                    objfpoSearchRoot.context.userId = objfpoSearch.userId;
                    objfpoSearchRoot.context.localeId = objfpoSearch.localeId;                     
                    objfpoSearchRoot.context.Header.IOU_orgn_rowid = (Int32)cmd.Parameters["IOU_orgn_rowid1"].Value;
                    objfpoSearchRoot.context.Header.IOU_aggregator_code = (string)cmd.Parameters["IOU_aggregator_code1"].Value.ToString();
                    objfpoSearchRoot.context.Header.Out_aggregator_type = (string)cmd.Parameters["Out_aggregator_type"].Value.ToString();
                    objfpoSearchRoot.context.Header.Out_fpo_code = (string)cmd.Parameters["Out_fpo_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.Out_fpo_desc = (string)cmd.Parameters["Out_fpo_desc"].Value.ToString();
                    objfpoSearchRoot.context.Header.Out_aggregator_name = (string)cmd.Parameters["Out_aggregator_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.Out_aggregator_ll_name = (string)cmd.Parameters["Out_aggregator_ll_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.Out_orgn_level = (string)cmd.Parameters["Out_orgn_level"].Value.ToString();
                    objfpoSearchRoot.context.Header.Out_facilitator_code = (string)cmd.Parameters["Out_facilitator_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.Out_facilitator_name = (string)cmd.Parameters["Out_facilitator_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.Out_facilitator_ll_code = (string)cmd.Parameters["Out_facilitator_ll_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.Out_facilitator_ll_name = (string)cmd.Parameters["Out_facilitator_ll_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.Out_member_name = (string)cmd.Parameters["Out_member_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.Out_member_ll_name = (string)cmd.Parameters["Out_member_ll_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.Out_status_code = (string)cmd.Parameters["Out_status_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.Out_status_desc = (string)cmd.Parameters["Out_status_desc"].Value.ToString();
                    objfpoSearchRoot.context.Header.Out_mode_flag = (string)cmd.Parameters["Out_mode_flag"].Value.ToString();
                    objfpoSearchRoot.context.Header.Out_row_timestamp = (string)cmd.Parameters["Out_row_timestamp"].Value.ToString();


                    Map = ds.Tables[0];
                    for (int i = 0; i < Map.Rows.Count; i++)
                    {
                        New_PAWHSAggregator_single_Address objadd = new New_PAWHSAggregator_single_Address();
                        objadd.IOU_orgn_rowid = Convert.ToInt32(objfpoSearchRoot.context.Header.IOU_orgn_rowid);
                        objadd.Out_orgnaddr_rowid = Convert.ToInt32(Map.Rows[i]["Out_orgnaddr_rowid"]);
                        objadd.Out_addr_type = Map.Rows[i]["Out_addr_type"].ToString();
                        objadd.Out_addr_type_desc = Map.Rows[i]["Out_addr_type_desc"].ToString();
                        objadd.Out_orgn_addr1 = Map.Rows[i]["Out_orgn_addr1"].ToString();
                        objadd.Out_orgn_addr2 = Map.Rows[i]["Out_orgn_addr2"].ToString();
                        objadd.Out_orgn_country =Map.Rows[i]["Out_orgn_country"].ToString();
                        objadd.Out_orgn_country_desc = Map.Rows[i]["Out_orgn_country_desc"].ToString();
                        objadd.Out_orgn_state = Map.Rows[i]["Out_orgn_state"].ToString();
                        objadd.Out_orgn_state_desc = Map.Rows[i]["Out_orgn_state_desc"].ToString();
                        objadd.Out_orgn_dist = Map.Rows[i]["Out_orgn_dist"].ToString();
                        objadd.Out_orgn_dist_desc = Map.Rows[i]["Out_orgn_dist_desc"].ToString();
                        objadd.Out_orgn_taluk = Map.Rows[i]["Out_orgn_taluk"].ToString();
                        objadd.Out_orgn_taluk_desc = Map.Rows[i]["Out_orgn_taluk_desc"].ToString();
                        objadd.Out_orgn_panchayat = Map.Rows[i]["Out_orgn_panchayat"].ToString(); 
                        objadd.Out_orgn_panchayat_desc = Map.Rows[i]["Out_orgn_panchayat_desc"].ToString();
                        objadd.Out_orgn_village = Map.Rows[i]["Out_orgn_village"].ToString();
                        objadd.Out_orgn_village_desc = Map.Rows[i]["Out_orgn_village_desc"].ToString();
                        objadd.Out_orgn_pincode = Map.Rows[i]["Out_orgn_pincode"].ToString();
                        objadd.Out_orgn_pincode_desc = Map.Rows[i]["Out_orgn_pincode_desc"].ToString();
                        objadd.Out_status_code = Map.Rows[i]["Out_status_code"].ToString();
                        objadd.Out_status_desc = Map.Rows[i]["Out_status_desc"].ToString();
                        objadd.Out_mode_flag = Map.Rows[i]["Out_mode_flag"].ToString();
                        objfpoSearchRoot.context.Address.Add(objadd);
                    }

                    Map = ds.Tables[1];
                    for (int i = 0; i < Map.Rows.Count; i++)
                    {
                        New_PAWHSAggregator_single_Bank objbank = new New_PAWHSAggregator_single_Bank();
                        objbank.IOU_orgn_rowid = Convert.ToInt32(objfpoSearchRoot.context.Header.IOU_orgn_rowid);
                        objbank.Out_orgnbank_rowid = Convert.ToInt32(Map.Rows[i]["Out_orgnbank_rowid"]);
                        objbank.Out_bank_acc_no = Map.Rows[i]["Out_bank_acc_no"].ToString();
                        objbank.Out_bank_acc_type = Map.Rows[i]["Out_bank_acc_type"].ToString();
                        objbank.Out_bank_acc_type_desc = Map.Rows[i]["Out_bank_acc_type_desc"].ToString();
                        objbank.Out_bank_code = Map.Rows[i]["Out_bank_code"].ToString();
                        objbank.Out_bank_desc = Map.Rows[i]["Out_bank_desc"].ToString();
                        objbank.Out_branch_code = Map.Rows[i]["Out_branch_code"].ToString();
                        objbank.Out_branch_desc = Map.Rows[i]["Out_branch_desc"].ToString();
                        objbank.Out_ifsc_code = Map.Rows[i]["Out_ifsc_code"].ToString();
                        objbank.Out_dflt_dr_acc = Map.Rows[i]["Out_dflt_dr_acc"].ToString();
                        objbank.Out_dflt_dr_acc_desc = Map.Rows[i]["Out_dflt_dr_acc_desc"].ToString();
                        objbank.Out_dflt_cr_acc = Map.Rows[i]["Out_dflt_cr_acc"].ToString();
                        objbank.Out_dflt_cr_acc_desc = Map.Rows[i]["Out_dflt_cr_acc_desc"].ToString();
                        objbank.Out_bank_acc_purpose = Map.Rows[i]["Out_bank_acc_purpose"].ToString();
                        objbank.Out_bank_acc_purpose_desc = Map.Rows[i]["Out_bank_acc_purpose_desc"].ToString();
                        objbank.Out_status_code = Map.Rows[i]["Out_status_code"].ToString();
                        objbank.Out_status_desc = Map.Rows[i]["Out_status_desc"].ToString();
                        objbank.Out_mode_flag = Map.Rows[i]["Out_mode_flag"].ToString();
                        objfpoSearchRoot.context.Bank.Add(objbank);
                    }
                    Map = ds.Tables[2];
                    for (int i = 0; i < Map.Rows.Count; i++)
                    {
                        New_PAWHSAggregator_single_FIG objbank = new New_PAWHSAggregator_single_FIG();
                        objbank.IOU_orgn_rowid = Convert.ToInt32(objfpoSearchRoot.context.Header.IOU_orgn_rowid);
                        objbank.Out_aggrfig_rowid = Convert.ToInt32(Map.Rows[i]["Out_aggrfig_rowid"]);
                        objbank.Out_aggrfig_type = Map.Rows[i]["Out_aggrfig_type"].ToString();
                        objbank.Out_aggrfig_type_desc = Map.Rows[i]["Out_aggrfig_type_desc"].ToString();
                        objbank.Out_aggrfig_code = Map.Rows[i]["Out_aggrfig_code"].ToString();
                        objbank.Out_aggrfig_name = Map.Rows[i]["Out_aggrfig_name"].ToString();
                        objbank.Out_aggrvillage_code = Map.Rows[i]["Out_aggrvillage_code"].ToString();
                        objbank.Out_aggrvillage_name = Map.Rows[i]["Out_aggrvillage_name"].ToString();
                        objbank.Out_contact_person = Map.Rows[i]["Out_contact_person"].ToString();
                        objbank.Out_contact_no = Map.Rows[i]["Out_contact_no"].ToString(); 
                        objbank.Out_status_code = Map.Rows[i]["Out_status_code"].ToString();
                        objbank.Out_status_desc = Map.Rows[i]["Out_status_desc"].ToString();
                        objbank.Out_mode_flag = Map.Rows[i]["Out_mode_flag"].ToString();
                        objfpoSearchRoot.context.FIG.Add(objbank);
                    }
                   

                }
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objfpoSearch.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objfpoSearchRoot;
        }

       
        public New_PAWHSAggregator_SDocument save_new_pawhs_aggregator(New_PAWHSAggregator_SApplication ObjContext, string mysqlcon)
        {
            int ret = 0;
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            New_PAWHSAggregator_SDocument objresFarmer = new New_PAWHSAggregator_SDocument();
            objresFarmer.context = new New_PAWHSAggregator_SContext();
            objresFarmer.context.Header = new New_PAWHSAggregator_saveHeader();
            objresFarmer.context.Address = new List<New_PAWHSAggregator_save_Address>();
            objresFarmer.context.Bank = new List<New_PAWHSAggregator_save_Bank>();
            objresFarmer.context.FIG = new List<New_PAWHSAggregator_save_FIG>();
            int IOU_orgn_rowid1 = 0;
            string IOU_aggregator_code1 = "";

            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                MySqlCommand cmd = new MySqlCommand("Admin_PAWHS_insupd_aggr_reg", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("Out_aggregator_type", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.Out_aggregator_type;
                cmd.Parameters.Add("Out_fpo_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.Out_fpo_code;
                cmd.Parameters.Add("Out_aggregator_name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.Out_aggregator_name;
                cmd.Parameters.Add("Out_aggregator_ll_name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.Out_aggregator_ll_name;
                cmd.Parameters.Add("Out_orgn_level", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.Out_orgn_level;
                cmd.Parameters.Add("Out_facilitator_code", MySqlDbType.Text).Value = ObjContext.document.context.Header.Out_facilitator_code;
                cmd.Parameters.Add("Out_facilitator_ll_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.Out_facilitator_ll_code;
                cmd.Parameters.Add("Out_member_name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.Out_member_name;
                cmd.Parameters.Add("Out_member_ll_name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.Out_member_ll_name;
                cmd.Parameters.Add("Out_status_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.Out_status_code;
                cmd.Parameters.Add("Out_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.Out_mode_flag;
                cmd.Parameters.Add("Out_row_timestamp", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.Out_row_timestamp;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmd.Parameters.Add("IOU_orgn_rowid", MySqlDbType.Int32).Value = ObjContext.document.context.Header.IOU_orgn_rowid;
                cmd.Parameters.Add("IOU_aggregator_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_aggregator_code;
                cmd.Parameters.Add(new MySqlParameter("IOU_orgn_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_aggregator_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);

                if (ret > 0)
                {
                    IOU_orgn_rowid1 = (Int32)cmd.Parameters["IOU_orgn_rowid1"].Value;
                    IOU_aggregator_code1 = (string)cmd.Parameters["IOU_aggregator_code1"].Value;
                    objresFarmer.context.Header.IOU_orgn_rowid = Convert.ToInt32(IOU_orgn_rowid1);
                    objresFarmer.context.Header.IOU_aggregator_code = IOU_aggregator_code1;
                    objresFarmer.context.orgnId = ObjContext.document.context.orgnId;
                    objresFarmer.context.locnId = ObjContext.document.context.locnId;
                    objresFarmer.context.userId = ObjContext.document.context.userId;
                    objresFarmer.context.localeId = ObjContext.document.context.localeId;

                    if (objresFarmer.context.Header.IOU_orgn_rowid > 0)
                    {
                        if(ObjContext.document.context.Address != null)
                        {
                            ret = SaveAddress(ObjContext, objresFarmer, mysqlcon, MysqlCon);
                        }
                        if (ObjContext.document.context.Bank != null)
                        {
                            ret = SaveBank(ObjContext, objresFarmer, mysqlcon, MysqlCon);
                        }
                        if (ObjContext.document.context.FIG != null)
                        {
                            ret = SaveFIG(ObjContext, objresFarmer, mysqlcon, MysqlCon);
                        }
                        //if (ret == 0)
                        //{
                        //    mysqltrans.Rollback();
                        //    return objresFarmer;
                        //}
                       
                        //if (ret == 0)
                        //{
                        //    mysqltrans.Rollback();
                        //    return objresFarmer;
                        //}
                       
                        //if (ret == 0)
                        //{
                        //    mysqltrans.Rollback();
                        //    return objresFarmer;
                        //}

                        mysqltrans.Commit();
                    }

                }
                else
                {
                    mysqltrans.Rollback();
                    return objresFarmer;
                }
                

            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                logger.Error("USERNAME :" + ObjContext.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objresFarmer;

        }

        public int SaveAddress(New_PAWHSAggregator_SApplication Objmodel, New_PAWHSAggregator_SDocument objfarmer, string MysqlCons, DataConnection MysqlCon)
        {
            int saving = 0;
            int count = 1;
            DataTable tab = new DataTable();
            New_PAWHSAggregator_save_Address objFarmersMapped = new New_PAWHSAggregator_save_Address();
            try
            {
                PAWHS_New_Aggregator_Datamodel objproduct1 = new PAWHS_New_Aggregator_Datamodel();
                foreach (var FarmersMap in Objmodel.document.context.Address)
                {
                    objFarmersMapped.Out_orgnaddr_rowid = FarmersMap.Out_orgnaddr_rowid;
                    objFarmersMapped.Out_addr_type = FarmersMap.Out_addr_type; 
                    objFarmersMapped.Out_orgn_addr1 = FarmersMap.Out_orgn_addr1;
                    objFarmersMapped.Out_orgn_addr2 = FarmersMap.Out_orgn_addr2;
                    objFarmersMapped.Out_orgn_country = FarmersMap.Out_orgn_country;
                    objFarmersMapped.Out_orgn_state = FarmersMap.Out_orgn_state;
                    objFarmersMapped.Out_orgn_dist = FarmersMap.Out_orgn_dist;
                    objFarmersMapped.Out_orgn_taluk = FarmersMap.Out_orgn_taluk;
                    objFarmersMapped.Out_orgn_panchayat = FarmersMap.Out_orgn_panchayat;
                    objFarmersMapped.Out_orgn_village = FarmersMap.Out_orgn_village;
                    objFarmersMapped.Out_orgn_pincode = FarmersMap.Out_orgn_pincode;
                    objFarmersMapped.Out_status_code = FarmersMap.Out_status_code;
                    objFarmersMapped.Out_mode_flag = FarmersMap.Out_mode_flag; 
                    saving = objproduct1.SaveAddressSP(objFarmersMapped, objfarmer, Objmodel, MysqlCons, MysqlCon);
                    count = count + 1;
                    if (saving == 0)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objfarmer.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return saving;

        }
        public int SaveAddressSP(New_PAWHSAggregator_save_Address ObjKycDtl, New_PAWHSAggregator_SDocument ObjFarmer, New_PAWHSAggregator_SApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("Admin_PAWHS_iud_aggr_reg_address", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("Out_orgnaddr_rowid", MySqlDbType.Int32).Value = ObjKycDtl.Out_orgnaddr_rowid;
                cmd.Parameters.Add("Out_addr_type", MySqlDbType.VarChar).Value = ObjKycDtl.Out_addr_type;
                cmd.Parameters.Add("Out_orgn_addr1", MySqlDbType.VarChar).Value = ObjKycDtl.Out_orgn_addr1;
                cmd.Parameters.Add("Out_orgn_addr2", MySqlDbType.VarChar).Value = ObjKycDtl.Out_orgn_addr2;
                cmd.Parameters.Add("Out_orgn_country", MySqlDbType.VarChar).Value = ObjKycDtl.Out_orgn_country;
                cmd.Parameters.Add("Out_orgn_state", MySqlDbType.VarChar).Value = ObjKycDtl.Out_orgn_state;
                cmd.Parameters.Add("Out_orgn_dist", MySqlDbType.VarChar).Value = ObjKycDtl.Out_orgn_dist;
                cmd.Parameters.Add("Out_orgn_taluk", MySqlDbType.VarChar).Value = ObjKycDtl.Out_orgn_taluk;
                cmd.Parameters.Add("Out_orgn_panchayat", MySqlDbType.VarChar).Value = ObjKycDtl.Out_orgn_panchayat;
                cmd.Parameters.Add("Out_orgn_village", MySqlDbType.VarChar).Value = ObjKycDtl.Out_orgn_village;
                cmd.Parameters.Add("Out_orgn_pincode", MySqlDbType.VarChar).Value = ObjKycDtl.Out_orgn_pincode;
                cmd.Parameters.Add("Out_status_code", MySqlDbType.VarChar).Value = ObjKycDtl.Out_status_code;
                cmd.Parameters.Add("Out_mode_flag", MySqlDbType.VarChar).Value = ObjKycDtl.Out_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                cmd.Parameters.Add("IOU_orgn_rowid", MySqlDbType.Int32).Value = ObjFarmer.context.Header.IOU_orgn_rowid;
                cmd.Parameters.Add("IOU_aggregator_code", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.IOU_aggregator_code;
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);

            }
            catch (Exception ex)
            {
                ret = 0;
                logger.Error("USERNAME :" + ObjFarmer.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ret;

        }

        // -- 

        public int SaveBank(New_PAWHSAggregator_SApplication Objmodel, New_PAWHSAggregator_SDocument objfarmer, string MysqlCons, DataConnection MysqlCon)
        {
            int saving = 0;
            int count = 1;
            DataTable tab = new DataTable();
            New_PAWHSAggregator_save_Bank objFarmersMapped = new New_PAWHSAggregator_save_Bank();
            try
            {
                PAWHS_New_Aggregator_Datamodel objproduct1 = new PAWHS_New_Aggregator_Datamodel();
                foreach (var FarmersMap in Objmodel.document.context.Bank)
                {
                    objFarmersMapped.Out_orgnbank_rowid = FarmersMap.Out_orgnbank_rowid;
                    objFarmersMapped.Out_bank_acc_no = FarmersMap.Out_bank_acc_no;
                    objFarmersMapped.Out_bank_acc_type = FarmersMap.Out_bank_acc_type;
                    objFarmersMapped.Out_bank_code = FarmersMap.Out_bank_code;
                    objFarmersMapped.Out_branch_code = FarmersMap.Out_branch_code;
                    objFarmersMapped.Out_ifsc_code = FarmersMap.Out_ifsc_code;
                    objFarmersMapped.Out_dflt_dr_acc = FarmersMap.Out_dflt_dr_acc;
                    objFarmersMapped.Out_dflt_cr_acc = FarmersMap.Out_dflt_cr_acc;
                    objFarmersMapped.Out_bank_acc_purpose = FarmersMap.Out_bank_acc_purpose; 
                    objFarmersMapped.Out_status_code = FarmersMap.Out_status_code;
                    objFarmersMapped.Out_mode_flag = FarmersMap.Out_mode_flag;
                    saving = objproduct1.SaveBankSP(objFarmersMapped, objfarmer, Objmodel, MysqlCons, MysqlCon);
                    count = count + 1;
                    if (saving == 0)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objfarmer.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return saving;

        }
        public int SaveBankSP(New_PAWHSAggregator_save_Bank ObjKycDtl, New_PAWHSAggregator_SDocument ObjFarmer, New_PAWHSAggregator_SApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("Admin_PAWHS_iud_aggr_reg_bank", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("Out_orgnbank_rowid", MySqlDbType.Int32).Value = ObjKycDtl.Out_orgnbank_rowid;
                cmd.Parameters.Add("Out_bank_acc_no", MySqlDbType.VarChar).Value = ObjKycDtl.Out_bank_acc_no;
                cmd.Parameters.Add("Out_bank_acc_type", MySqlDbType.VarChar).Value = ObjKycDtl.Out_bank_acc_type;
                cmd.Parameters.Add("Out_bank_code", MySqlDbType.VarChar).Value = ObjKycDtl.Out_bank_code;
                cmd.Parameters.Add("Out_branch_code", MySqlDbType.VarChar).Value = ObjKycDtl.Out_branch_code;
                cmd.Parameters.Add("Out_ifsc_code", MySqlDbType.VarChar).Value = ObjKycDtl.Out_ifsc_code;
                cmd.Parameters.Add("Out_dflt_dr_acc", MySqlDbType.VarChar).Value = ObjKycDtl.Out_dflt_dr_acc;
                cmd.Parameters.Add("Out_dflt_cr_acc", MySqlDbType.VarChar).Value = ObjKycDtl.Out_dflt_cr_acc;
                cmd.Parameters.Add("Out_bank_acc_purpose", MySqlDbType.VarChar).Value = ObjKycDtl.Out_bank_acc_purpose; 
                cmd.Parameters.Add("Out_status_code", MySqlDbType.VarChar).Value = ObjKycDtl.Out_status_code;
                cmd.Parameters.Add("Out_mode_flag", MySqlDbType.VarChar).Value = ObjKycDtl.Out_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                cmd.Parameters.Add("IOU_orgn_rowid", MySqlDbType.Int32).Value = ObjFarmer.context.Header.IOU_orgn_rowid;
                cmd.Parameters.Add("IOU_aggregator_code", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.IOU_aggregator_code;
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);

            }
            catch (Exception ex)
            {
                ret = 0;
                logger.Error("USERNAME :" + ObjFarmer.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ret;

        }

        public int SaveFIG(New_PAWHSAggregator_SApplication Objmodel, New_PAWHSAggregator_SDocument objfarmer, string MysqlCons, DataConnection MysqlCon)
        {
            int saving = 0;
            int count = 1;
            DataTable tab = new DataTable();
            New_PAWHSAggregator_save_FIG objFarmersMapped = new New_PAWHSAggregator_save_FIG();
            try
            {
                PAWHS_New_Aggregator_Datamodel objproduct1 = new PAWHS_New_Aggregator_Datamodel();
                foreach (var FarmersMap in Objmodel.document.context.FIG)
                {
                    objFarmersMapped.Out_aggrfig_rowid = FarmersMap.Out_aggrfig_rowid;
                    objFarmersMapped.Out_aggrfig_type = FarmersMap.Out_aggrfig_type;
                    objFarmersMapped.Out_aggrfig_code = FarmersMap.Out_aggrfig_code;
                    objFarmersMapped.Out_aggrfig_name = FarmersMap.Out_aggrfig_name;
                    objFarmersMapped.Out_aggrvillage_code = FarmersMap.Out_aggrvillage_code;
                    objFarmersMapped.Out_aggrvillage_name = FarmersMap.Out_aggrvillage_name;
                    objFarmersMapped.Out_contact_person = FarmersMap.Out_contact_person;
                    objFarmersMapped.Out_contact_no = FarmersMap.Out_contact_no; 
                    objFarmersMapped.Out_status_code = FarmersMap.Out_status_code;
                    objFarmersMapped.Out_mode_flag = FarmersMap.Out_mode_flag;
                    saving = objproduct1.SaveFIGSP(objFarmersMapped, objfarmer, Objmodel, MysqlCons, MysqlCon);
                    count = count + 1;
                    if (saving == 0)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return saving;

        }
        public int SaveFIGSP(New_PAWHSAggregator_save_FIG ObjKycDtl, New_PAWHSAggregator_SDocument ObjFarmer, New_PAWHSAggregator_SApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("Admin_PAWHS_iud_aggr_reg_fig", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("Out_aggrfig_rowid", MySqlDbType.Int32).Value = ObjKycDtl.Out_aggrfig_rowid;
                cmd.Parameters.Add("Out_aggrfig_type", MySqlDbType.VarChar).Value = ObjKycDtl.Out_aggrfig_type;
                cmd.Parameters.Add("Out_aggrfig_code", MySqlDbType.VarChar).Value = ObjKycDtl.Out_aggrfig_code;
                cmd.Parameters.Add("Out_aggrfig_name", MySqlDbType.VarChar).Value = ObjKycDtl.Out_aggrfig_name;
                cmd.Parameters.Add("Out_aggrvillage_code", MySqlDbType.VarChar).Value = ObjKycDtl.Out_aggrvillage_code;
                cmd.Parameters.Add("Out_aggrvillage_name", MySqlDbType.VarChar).Value = ObjKycDtl.Out_aggrvillage_name;
                cmd.Parameters.Add("Out_contact_person", MySqlDbType.VarChar).Value = ObjKycDtl.Out_contact_person;
                cmd.Parameters.Add("Out_contact_no", MySqlDbType.VarChar).Value = ObjKycDtl.Out_contact_no; 
                cmd.Parameters.Add("Out_status_code", MySqlDbType.VarChar).Value = ObjKycDtl.Out_status_code;
                cmd.Parameters.Add("Out_mode_flag", MySqlDbType.VarChar).Value = ObjKycDtl.Out_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                cmd.Parameters.Add("IOU_orgn_rowid", MySqlDbType.Int32).Value = ObjFarmer.context.Header.IOU_orgn_rowid;
                cmd.Parameters.Add("IOU_aggregator_code", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.IOU_aggregator_code;
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);

            }
            catch (Exception ex)
            {
                ret = 0;
                logger.Error("USERNAME :" + ObjFarmer.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ret;

        }


    }
}
