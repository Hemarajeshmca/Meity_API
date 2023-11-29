using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace FFI_DataModel
{
    public class FDR_FarmerProfileDataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FDR_FarmerProfileDataModel));
        string methodName = "";
        Admin_ErrorMessageModel ObjErrormsg = new Admin_ErrorMessageModel();

        LogHelper objHelper = new LogHelper();
        StackTrace stackTrace = new StackTrace();
        object obj = new object();
        public FarmerProfileList FarmerProfileList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue, int from_index, int to_index, int record_count, string ConString)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            FarmerProfileList ObjFetchAll = new FarmerProfileList();
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MysqlCon = new DataConnection(ConString);
                FPContext objContext = new FPContext();
                objContext.orgnId = org;
                objContext.localeId = lang;
                objContext.locnId = locn;
                objContext.userId = user;
                ObjFetchAll.context = objContext;
                MySqlCommand cmd = new MySqlCommand("FDR_fetch_farmer_profile_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("in_filterby_option", MySqlDbType.VarChar).Value = filterby_option;
                cmd.Parameters.Add("in_filterby_code", MySqlDbType.VarChar).Value = filterby_code;
                cmd.Parameters.Add("in_filterby_fromvalue", MySqlDbType.VarChar).Value = filterby_fromvalue;
                cmd.Parameters.Add("in_filterby_tovalue", MySqlDbType.VarChar).Value = filterby_tovalue;
                cmd.Parameters.Add("in_from_index", MySqlDbType.Int32).Value = from_index;
                cmd.Parameters.Add("in_to_index", MySqlDbType.Int32).Value = to_index;
                cmd.Parameters.Add("in_record_count", MySqlDbType.Int32).Value = record_count;
                cmd.Parameters.Add(new MySqlParameter("out_record_count", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.Int32)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();
                FPFilter objheader = new FPFilter();
                objheader.out_record_count = (int)cmd.Parameters["out_record_count"].Value;
                ObjFetchAll.context.Filter = objheader;
                List<FPList> objFPList = new List<FPList>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FPList objList = new FPList();
                    objList.out_farmer_rowid = Convert.ToInt32(dt.Rows[i]["out_farmer_rowid"]);
                    objList.out_farmer_code = dt.Rows[i]["out_farmer_code"].ToString();
                    objList.out_version_no = Convert.ToInt32(dt.Rows[i]["out_version_no"].ToString());
                    objList.out_photo_farmer = dt.Rows[i]["out_photo_farmer"].ToString();
                    objList.out_farmer_name = dt.Rows[i]["out_farmer_name"].ToString();
                    objList.out_sur_name = dt.Rows[i]["out_sur_name"].ToString();
                    objList.out_fhw_name = dt.Rows[i]["out_fhw_name"].ToString();
                    objList.out_farmer_dob = dt.Rows[i]["out_farmer_dob"].ToString();
                    objList.out_farmer_addr1 = dt.Rows[i]["out_farmer_addr1"].ToString();
                    objList.out_farmer_addr2 = dt.Rows[i]["out_farmer_addr2"].ToString();
                    objList.out_farmer_ll_name = dt.Rows[i]["out_farmer_ll_name"].ToString();
                    objList.out_sur_ll_name = dt.Rows[i]["out_sur_ll_name"].ToString();
                    objList.out_fhw_ll_name = dt.Rows[i]["out_fhw_ll_name"].ToString();
                    objList.out_farmer_ll_addr1 = dt.Rows[i]["out_farmer_ll_addr1"].ToString();
                    objList.out_farmer_ll_addr2 = dt.Rows[i]["out_farmer_ll_addr2"].ToString();
                    objList.out_farmer_country = dt.Rows[i]["out_farmer_country"].ToString();
                    objList.out_farmer_country_desc = dt.Rows[i]["out_farmer_country_desc"].ToString();
                    objList.out_farmer_state = dt.Rows[i]["out_farmer_state"].ToString();
                    objList.out_farmer_state_desc = dt.Rows[i]["out_farmer_state_desc"].ToString();
                    objList.out_farmer_dist = dt.Rows[i]["out_farmer_dist"].ToString();
                    objList.out_farmer_dist_desc = dt.Rows[i]["out_farmer_dist_desc"].ToString();
                    objList.out_farmer_taluk = dt.Rows[i]["out_farmer_taluk"].ToString();
                    objList.out_farmer_taluk_desc = dt.Rows[i]["out_farmer_taluk_desc"].ToString();
                    objList.out_farmer_panchayat = dt.Rows[i]["out_farmer_panchayat"].ToString();
                    objList.out_farmer_panchayat_desc = dt.Rows[i]["out_farmer_panchayat_desc"].ToString();
                    objList.out_farmer_village = dt.Rows[i]["out_farmer_village"].ToString();
                    objList.out_farmer_village_desc = dt.Rows[i]["out_farmer_village_desc"].ToString();
                    objList.out_farmer_pincode = dt.Rows[i]["out_farmer_pincode"].ToString();
                    objList.out_farmer_pincode_desc = dt.Rows[i]["out_farmer_pincode_desc"].ToString();
                    objList.out_marital_status = dt.Rows[i]["out_marital_status"].ToString();
                    objList.out_marital_status_desc = dt.Rows[i]["out_marital_status_desc"].ToString();
                    objList.out_gender_flag = dt.Rows[i]["out_gender_flag"].ToString();
                    objList.out_gender_flag_desc = dt.Rows[i]["out_gender_flag_desc"].ToString();
                    objList.out_reg_mobile_no = dt.Rows[i]["out_reg_mobile_no"].ToString();
                    objList.out_reg_note = dt.Rows[i]["out_reg_note"].ToString();
                    objList.out_status_code = dt.Rows[i]["out_status_code"].ToString();
                    objList.out_status_desc = dt.Rows[i]["out_status_desc"].ToString();
                    objList.out_row_timestamp = dt.Rows[i]["out_row_timestamp"].ToString();
                    objList.out_member_id = dt.Rows[i]["out_member_id"].ToString();
                    objList.out_fpo_name = dt.Rows[i]["out_fpo_name"].ToString();
                    objFPList.Add(objList);
                }
                ObjFetchAll.context.List = objFPList;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetchAll;
        }
        public FarmerProfileFetch FetchFarmerProfile(string org, string locn, string user, string lang, int farmer_rowid, string farmer_code, int version_no, string ConString)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            FarmerProfileFetch objFetch = new FarmerProfileFetch();
            DataTable dt = new DataTable();
            try
            {
                FetchFPContext objContext = new FetchFPContext();
                objContext.orgnId = org;
                objContext.localeId = lang;
                objContext.locnId = locn;
                objContext.userId = user;
                objFetch.context = objContext;

                MysqlCon = new DataConnection(ConString);
                MySqlCommand cmd = new MySqlCommand("FDR_fetch_farmer_profile", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("inout_farmer_rowid", MySqlDbType.Int32).Value = farmer_rowid;
                cmd.Parameters.Add("inout_farmer_code", MySqlDbType.VarChar).Value = farmer_code;
                cmd.Parameters.Add("inout_version_no", MySqlDbType.Int32).Value = version_no;

                cmd.Parameters.Add(new MySqlParameter("inout_farmer_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("inout_farmer_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("inout_version_no1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_photo_farmer", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_farmer_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_sur_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_fhw_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_farmer_dob", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_farmer_addr1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_farmer_addr2", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_farmer_ll_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_sur_ll_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_fhw_ll_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_farmer_ll_addr1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_farmer_ll_addr2", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_farmer_country", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_farmer_country_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_farmer_state", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_farmer_state_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_farmer_dist", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_farmer_dist_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_farmer_taluk", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_farmer_taluk_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_farmer_panchayat", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_farmer_panchayat_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_farmer_village", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_farmer_village_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_farmer_pincode", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_farmer_pincode_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_marital_status", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_marital_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_gender_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_gender_flag_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_reg_mobile_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_reg_note", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_fpo_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_member_id", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_detail", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();
                FetchFPHeader objHeader = new FetchFPHeader();

                objHeader.inout_farmer_rowid = (Int32)cmd.Parameters["inout_farmer_rowid"].Value;
                objHeader.inout_farmer_code = (string)cmd.Parameters["inout_farmer_code"].Value.ToString();
                objHeader.inout_version_no = (Int32)cmd.Parameters["inout_version_no"].Value;
                objHeader.out_photo_farmer = (string)cmd.Parameters["out_photo_farmer"].Value.ToString();
                objHeader.out_farmer_name = (string)cmd.Parameters["out_farmer_name"].Value.ToString();
                objHeader.out_sur_name = (string)cmd.Parameters["out_sur_name"].Value.ToString();
                objHeader.out_fhw_name = (string)cmd.Parameters["out_fhw_name"].Value.ToString();
                objHeader.out_farmer_dob = (string)cmd.Parameters["out_farmer_dob"].Value.ToString();
                objHeader.out_farmer_addr1 = (string)cmd.Parameters["out_farmer_addr1"].Value.ToString();
                objHeader.out_farmer_addr2 = (string)cmd.Parameters["out_farmer_addr2"].Value.ToString();
                objHeader.out_farmer_ll_name = (string)cmd.Parameters["out_farmer_ll_name"].Value.ToString();
                objHeader.out_sur_ll_name = (string)cmd.Parameters["out_sur_ll_name"].Value.ToString();
                objHeader.out_fhw_ll_name = (string)cmd.Parameters["out_fhw_ll_name"].Value.ToString();
                objHeader.out_farmer_ll_addr1 = (string)cmd.Parameters["out_farmer_ll_addr1"].Value.ToString();
                objHeader.out_farmer_ll_addr2 = (string)cmd.Parameters["out_farmer_ll_addr2"].Value.ToString();
                objHeader.out_farmer_country = (string)cmd.Parameters["out_farmer_country"].Value.ToString();
                objHeader.out_farmer_country_desc = (string)cmd.Parameters["out_farmer_country_desc"].Value.ToString();
                objHeader.out_farmer_state = (string)cmd.Parameters["out_farmer_state"].Value.ToString();
                objHeader.out_farmer_state_desc = (string)cmd.Parameters["out_farmer_state_desc"].Value.ToString();
                objHeader.out_farmer_dist = (string)cmd.Parameters["out_farmer_dist"].Value.ToString();
                objHeader.out_farmer_dist_desc = (string)cmd.Parameters["out_farmer_dist_desc"].Value.ToString();
                objHeader.out_farmer_taluk = (string)cmd.Parameters["out_farmer_taluk"].Value.ToString();
                objHeader.out_farmer_taluk_desc = (string)cmd.Parameters["out_farmer_taluk_desc"].Value.ToString();
                objHeader.out_farmer_panchayat = (string)cmd.Parameters["out_farmer_panchayat"].Value.ToString();
                objHeader.out_farmer_panchayat_desc = (string)cmd.Parameters["out_farmer_panchayat_desc"].Value.ToString();
                objHeader.out_farmer_village = (string)cmd.Parameters["out_farmer_village"].Value.ToString();
                objHeader.out_farmer_village_desc = (string)cmd.Parameters["out_farmer_village_desc"].Value.ToString();
                objHeader.out_farmer_pincode = (string)cmd.Parameters["out_farmer_pincode"].Value.ToString();
                objHeader.out_farmer_pincode_desc = (string)cmd.Parameters["out_farmer_pincode_desc"].Value.ToString();
                objHeader.out_marital_status = (string)cmd.Parameters["out_marital_status"].Value.ToString();
                objHeader.out_marital_status_desc = (string)cmd.Parameters["out_marital_status_desc"].Value.ToString();
                objHeader.out_gender_flag = (string)cmd.Parameters["out_gender_flag"].Value.ToString();
                objHeader.out_gender_flag_desc = (string)cmd.Parameters["out_gender_flag_desc"].Value.ToString();
                objHeader.out_reg_mobile_no = (string)cmd.Parameters["out_reg_mobile_no"].Value.ToString();
                objHeader.out_reg_note = (string)cmd.Parameters["out_reg_note"].Value.ToString();
                objHeader.out_status_code = (string)cmd.Parameters["out_status_code"].Value.ToString();
                objHeader.out_status_desc = (string)cmd.Parameters["out_status_desc"].Value.ToString();
                objHeader.out_mode_flag = (string)cmd.Parameters["out_mode_flag"].Value.ToString();
                objHeader.out_fpo_name = (string)cmd.Parameters["out_fpo_name"].Value.ToString();
                objHeader.out_member_id = (string)cmd.Parameters["out_member_id"].Value.ToString();
                objHeader.out_row_timestamp = (string)cmd.Parameters["out_row_timestamp"].Value.ToString();
                objHeader.out_detail = (string)cmd.Parameters["out_detail"].Value.ToString();
                objFetch.context.header = objHeader;
                List<FetchFPDynamic> ObjAddressList = new List<FetchFPDynamic>();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        FetchFPDynamic objfp = new FetchFPDynamic();
                        objfp.out_sl_no = 0;
                        objfp.out_dynamic_list = "";
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objFetch;
        }
        public OutputFarmerProfile SaveFarmerProfile(SaveFarmerProfile objFP, string jsonstring, string ConString)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            OutputFarmerProfile objOutFp = new OutputFarmerProfile();
            try
            {
                int ret = 0;
                int retdtls = 0;
                MysqlCon = new DataConnection(ConString);

                OutFPContext objContext = new OutFPContext();
                objContext.orgnId = objFP.document.context.orgnId;
                objContext.localeId = objFP.document.context.localeId;
                objContext.locnId = objFP.document.context.locnId;
                objContext.userId = objFP.document.context.userId;
                objOutFp.context = objContext;
                OutFPHeader objOutHeader = new OutFPHeader();

                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }


                FFI_Model.ApplicationException objex = new FFI_Model.ApplicationException();
                MySqlCommand cmd = new MySqlCommand("FDR_insupd_farmer_profile", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId1", MySqlDbType.VarChar).Value = objFP.document.context.userId;
                cmd.Parameters.Add("orgnId1", MySqlDbType.VarChar).Value = objFP.document.context.orgnId;
                cmd.Parameters.Add("locnId1", MySqlDbType.VarChar).Value = objFP.document.context.locnId;
                cmd.Parameters.Add("localeId1", MySqlDbType.VarChar).Value = objFP.document.context.localeId;
                cmd.Parameters.Add("inout_farmer_rowid1", MySqlDbType.Int32).Value = objFP.document.context.Header.inout_farmer_rowid;
                cmd.Parameters.Add("inout_farmer_code1", MySqlDbType.VarChar).Value = objFP.document.context.Header.inout_farmer_code;
                cmd.Parameters.Add("inout_version_no1", MySqlDbType.Int32).Value = objFP.document.context.Header.inout_version_no;
                cmd.Parameters.Add("in_photo_farmer", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_photo_farmer;
                cmd.Parameters.Add("in_farmer_name", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_farmer_name;
                cmd.Parameters.Add("in_sur_name", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_sur_name;
                cmd.Parameters.Add("in_fhw_name", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_fhw_name;
                cmd.Parameters.Add("in_farmer_dob", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_farmer_dob;
                cmd.Parameters.Add("in_farmer_addr1", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_farmer_addr1;
                cmd.Parameters.Add("in_farmer_addr2", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_farmer_addr2;
                cmd.Parameters.Add("in_farmer_ll_name", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_farmer_ll_name;
                cmd.Parameters.Add("in_sur_ll_name", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_sur_ll_name;
                cmd.Parameters.Add("in_fhw_ll_name", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_fhw_ll_name;
                cmd.Parameters.Add("in_farmer_ll_addr1", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_farmer_ll_addr1;
                cmd.Parameters.Add("in_farmer_ll_addr2", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_farmer_ll_addr2;
                cmd.Parameters.Add("in_farmer_country", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_farmer_country;
                cmd.Parameters.Add("in_farmer_state", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_farmer_state;
                cmd.Parameters.Add("in_farmer_dist", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_farmer_dist;
                cmd.Parameters.Add("in_farmer_taluk", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_farmer_taluk;
                cmd.Parameters.Add("in_farmer_panchayat", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_farmer_panchayat;
                cmd.Parameters.Add("in_farmer_village", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_farmer_village;
                cmd.Parameters.Add("in_farmer_pincode", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_farmer_pincode;
                cmd.Parameters.Add("in_marital_status", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_marital_status;
                cmd.Parameters.Add("in_gender_flag", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_gender_flag;
                cmd.Parameters.Add("in_reg_mobile_no", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_reg_mobile_no;
                cmd.Parameters.Add("in_reg_note", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_reg_note;
                cmd.Parameters.Add("in_status_code", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_status_code;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_mode_flag;
                cmd.Parameters.Add("in_member_id", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_member_id;
                cmd.Parameters.Add("in_fpo_name", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_fpo_name;

                cmd.Parameters.Add("in_row_timestamp", MySqlDbType.VarChar).Value = objFP.document.context.Header.in_row_timestamp;

                cmd.Parameters.Add(new MySqlParameter("userId", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("orgnId", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("locnId", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("localeId", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("inout_farmer_rowid", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("inout_farmer_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("inout_version_no", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                var stringProps = objFP.document.context.Header.GetType().GetProperties();
                retdtls = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                if (retdtls > 0)
                {
                    objOutHeader.inout_farmer_rowid = (Int32)cmd.Parameters["inout_farmer_rowid"].Value;
                    objOutHeader.inout_farmer_code = (string)cmd.Parameters["inout_farmer_code"].Value;
                    objOutHeader.inout_version_no = (Int32)cmd.Parameters["inout_version_no"].Value;
                }
                if (cmd.Parameters["errorNo"].Value.ToString() != "")
                {
                    objex.errorNumber = cmd.Parameters["errorNo"].Value.ToString();
                    objex.errorDescription = ObjErrormsg.ErrorMessage(objex.errorNumber);
                }
                objContext.Header = objOutHeader;

                if (objOutHeader.inout_farmer_rowid > 0)
                {
                    MySqlCommand cmds = new MySqlCommand("FDR_iud_farmer_detail", MysqlCon.con);
                    cmds.CommandType = CommandType.StoredProcedure;
                    cmds.Parameters.Add("inout_farmer_code", MySqlDbType.VarChar).Value = objFP.document.context.Header.inout_farmer_code;
                    cmds.Parameters.Add("inout_version_no", MySqlDbType.Int32).Value = objFP.document.context.Header.inout_version_no;
                    cmds.Parameters.Add("userId", MySqlDbType.VarChar).Value = objFP.document.context.userId;
                    cmds.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objFP.document.context.orgnId;
                    cmds.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objFP.document.context.locnId;
                    cmds.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objFP.document.context.localeId;
                    cmds.Parameters.Add("detail_formatted", MySqlDbType.VarChar).Value = jsonstring;
                    cmds.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                    ret = cmds.ExecuteNonQuery();
                    LogHelper.ConvertCmdIntoString(cmds);
                    if (ret == 0)
                    {
                        mysqltrans.Rollback();
                        objex.errorNumber = (string)cmds.Parameters["errorNo"].Value;
                        objex.errorDescription = ObjErrormsg.ErrorMessage(objex.errorNumber);
                    }
                    else
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
                logger.Error("USERNAME :" + objFP.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objOutFp;
        }
    }
}
