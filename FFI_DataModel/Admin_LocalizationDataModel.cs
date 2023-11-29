using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
    public class Admin_LocalizationDataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        Admin_ErrorMessageModel ObjErrormsg = new Admin_ErrorMessageModel();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Admin_RoleManagementDataModel));
        // Exception Log Method Name Purpose written start 
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public LocalizationList LocalizationList(string org, string locn, string user, string lang, string activity_code, string ConString)
        {
            LocalizationList ObjFetchAll = new LocalizationList();
            try
            {
                DataSet ds = new DataSet();
                MysqlCon = new DataConnection(ConString);
                FetchLocalizationContext objContext = new FetchLocalizationContext();
                objContext.orgnId = org;
                objContext.localeId = lang;
                objContext.locnId = locn;
                objContext.userId = user;
                ObjFetchAll.context = objContext;
                MySqlCommand cmd = new MySqlCommand("Admin_fetch_localization_definition", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("In_activity_code", MySqlDbType.VarChar).Value = activity_code;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();
                DataTable dtScreen = ds.Tables[0];
                DataTable dtFE = ds.Tables[1];
                DataTable dtBE = ds.Tables[2];
                List<FetchLocalizationScreen> objScreenLst = new List<FetchLocalizationScreen>();
                for (int i = 0; i < dtScreen.Rows.Count; i++)
                {
                    FetchLocalizationScreen objList = new FetchLocalizationScreen();
                    objList.In_localization_rowid = Convert.ToInt32(dtScreen.Rows[i]["In_localization_rowid"]);
                    objList.In_control_type = dtScreen.Rows[i]["In_control_type"].ToString();
                    objList.In_control_type_desc = dtScreen.Rows[i]["In_control_type_desc"].ToString();
                    objList.In_control_code = dtScreen.Rows[i]["In_control_code"].ToString();
                    objList.In_data_field = dtScreen.Rows[i]["In_data_field"].ToString();
                    objList.In_locale_desc = dtScreen.Rows[i]["In_locale_desc"].ToString();
                    objList.In_locale_ll_desc = dtScreen.Rows[i]["In_locale_ll_desc"].ToString();
                    objList.In_row_timestamp = dtScreen.Rows[i]["In_row_timestamp"].ToString();
                    objList.In_mode_flag = dtScreen.Rows[i]["In_mode_flag"].ToString();
                    objScreenLst.Add(objList);
                }
                ObjFetchAll.context.Screen = objScreenLst;

                List<FetchLocalizationFE> objFELst = new List<FetchLocalizationFE>();
                for (int i = 0; i < dtFE.Rows.Count; i++)
                {
                    FetchLocalizationFE objList = new FetchLocalizationFE();
                    objList.In_localization_rowid = Convert.ToInt32(dtFE.Rows[i]["In_localization_rowid"]);
                    objList.In_control_type = dtFE.Rows[i]["In_control_type"].ToString();
                    objList.In_control_type_desc = dtFE.Rows[i]["In_control_type_desc"].ToString();
                    objList.In_control_code = dtFE.Rows[i]["In_control_code"].ToString();
                    objList.In_data_field = dtFE.Rows[i]["In_data_field"].ToString();
                    objList.In_locale_desc = dtFE.Rows[i]["In_locale_desc"].ToString();
                    objList.In_locale_ll_desc = dtFE.Rows[i]["In_locale_ll_desc"].ToString();
                    objList.In_row_timestamp = dtFE.Rows[i]["In_row_timestamp"].ToString();
                    objList.In_mode_flag = dtFE.Rows[i]["In_mode_flag"].ToString();
                    objFELst.Add(objList);
                }
                ObjFetchAll.context.FE = objFELst;

                List<FetchLocalizationBE> objBELst = new List<FetchLocalizationBE>();
                for (int i = 0; i < dtBE.Rows.Count; i++)
                {
                    FetchLocalizationBE objList = new FetchLocalizationBE();
                    objList.In_localization_rowid = Convert.ToInt32(dtBE.Rows[i]["In_localization_rowid"]);
                    objList.In_control_type = dtBE.Rows[i]["In_control_type"].ToString();
                    objList.In_control_type_desc = dtBE.Rows[i]["In_control_type_desc"].ToString();
                    objList.In_control_code = dtBE.Rows[i]["In_control_code"].ToString();
                    objList.In_data_field = dtBE.Rows[i]["In_data_field"].ToString();
                    objList.In_locale_desc = dtBE.Rows[i]["In_locale_desc"].ToString();
                    objList.In_locale_ll_desc = dtBE.Rows[i]["In_locale_ll_desc"].ToString();
                    objList.In_row_timestamp = dtBE.Rows[i]["In_row_timestamp"].ToString();
                    objList.In_mode_flag = dtBE.Rows[i]["In_mode_flag"].ToString();
                    objBELst.Add(objList);
                }
                ObjFetchAll.context.BE = objBELst;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetchAll;
        }

        public LocalOutput SaveLocalization(SaveLocalization objLoc, string ConString)
        {
            LocalOutput objOut = new LocalOutput();
            try
            {
                int ret = 0;
                int retdtls = 0;
                MysqlCon = new DataConnection(ConString);

                LocalOutputContext objContext = new LocalOutputContext();
                objContext.orgnId = objLoc.document.context.orgnId;
                objContext.localeId = objLoc.document.context.localeId;
                objContext.locnId = objLoc.document.context.locnId;
                objContext.userId = objLoc.document.context.userId;
                objOut.context = objContext;
                FYOutHeader objOutHeader = new FYOutHeader();

                FFI_Model.ApplicationException objex = new FFI_Model.ApplicationException();

                foreach (var Details in objLoc.document.context.Detail)
                {
                    MySqlCommand cmd = new MySqlCommand("Admin_iud_localization_definition", MysqlCon.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objLoc.document.context.userId;
                    cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objLoc.document.context.orgnId;
                    cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objLoc.document.context.locnId;
                    cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objLoc.document.context.localeId;

                    cmd.Parameters.Add("In_localization_rowid", MySqlDbType.Int32).Value = Details.In_localization_rowid;
                    cmd.Parameters.Add("In_activity_code", MySqlDbType.VarChar).Value = Details.In_activity_code;
                    cmd.Parameters.Add("In_control_type", MySqlDbType.VarChar).Value = Details.In_control_type;
                    cmd.Parameters.Add("In_control_code", MySqlDbType.VarChar).Value = Details.In_control_code;
                    cmd.Parameters.Add("In_data_field", MySqlDbType.VarChar).Value = Details.In_data_field;
                    cmd.Parameters.Add("In_locale_desc", MySqlDbType.VarChar).Value = Details.In_locale_desc;
                    cmd.Parameters.Add("In_locale_ll_desc", MySqlDbType.VarChar).Value = Details.In_locale_ll_desc;
                    cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Details.In_mode_flag;
                    cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = Details.In_row_timestamp;

                    MysqlCon.con.Open();
                    retdtls = cmd.ExecuteNonQuery();
                    LogHelper.ConvertCmdIntoString(cmd);
                    MysqlCon.con.Close();
                    objOut.ApplicationException = objex;
                }
            }
            catch (Exception ex)
            {
                MysqlCon.con.Close();
                logger.Error("USERNAME :" + objLoc.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objOut; ;
        }
    }
}
