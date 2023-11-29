using FFI_Model;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.Json.Serialization;
using static FFI_Model.Admin_BulkUpload_Model;

namespace FFI_DataModel
{
   public class Admin_BulkUpload_Datamodel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        //ErrorMessages ObjErrormsg = new ErrorMessages();
        Admin_ErrorMessageModel ObjErrormsg = new Admin_ErrorMessageModel();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Admin_RoleManagementDataModel));
        public BulkExceltempApplication exceltempfetch(string org, string locn, string user, string lang, string excel_upload_code, string ConString)
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            BulkExceltempApplication ObjFetch = new BulkExceltempApplication();
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MysqlCon = new DataConnection(ConString);
                BulkExceltempContext objContext = new BulkExceltempContext();
                objContext.orgnId = org;
                objContext.localeId = lang;
                objContext.locnId = locn;
                objContext.userId = user;
                ObjFetch.context = objContext;
                MySqlCommand cmd = new MySqlCommand("Admin_fetch_excel_template", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("in_orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("in_locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("in_userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("in_localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("IN_excel_upload_code", MySqlDbType.VarChar).Value = excel_upload_code;
                cmd.Parameters.Add(new MySqlParameter("out_entity_group_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_procedure_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_procedure_type", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("out_no_of_columns", MySqlDbType.Int32)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);

                MysqlCon.con.Close();

                BulkExceltempHeader objHeader = new BulkExceltempHeader();

                objHeader.out_entity_group_code = (string)cmd.Parameters["out_entity_group_code"].Value.ToString();
                objHeader.out_procedure_name = (string)cmd.Parameters["out_procedure_name"].Value.ToString();
                objHeader.out_procedure_type = (string)cmd.Parameters["out_procedure_type"].Value.ToString();
                objHeader.out_no_of_columns = (int)cmd.Parameters["out_no_of_columns"].Value;
                ObjFetch.context.Header = objHeader;
                List<BulkExceltempExcelColumn> ObjRoleList = new List<BulkExceltempExcelColumn>();
                dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BulkExceltempExcelColumn objList = new BulkExceltempExcelColumn();
                    objList.excel_column = dt.Rows[i]["excel_column"].ToString();
                    objList.column_name = dt.Rows[i]["column_name"].ToString();
                    objList.column_type = dt.Rows[i]["column_type"].ToString();
                    objList.max_len = Convert.ToInt32(dt.Rows[i]["max_len"]);
                    objList.seq_no = Convert.ToInt32(dt.Rows[i]["seq_no"]);
                  
                    ObjRoleList.Add(objList);
                }
                ObjFetch.context.excelColumn = ObjRoleList;
                dt = ds.Tables[1];
                List<BulkExceltempExcelHistory> ObjexcelhistoryList = new List<BulkExceltempExcelHistory>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BulkExceltempExcelHistory objEHList = new BulkExceltempExcelHistory();
                    objEHList.history_log = dt.Rows[i]["history_log"].ToString();
                    objEHList.excel_filename = dt.Rows[i]["excel_filename"].ToString();
                    objEHList.status_desc = dt.Rows[i]["status_desc"].ToString();
                    objEHList.uploaded_by = dt.Rows[i]["uploaded_by"].ToString();
                    objEHList.uploaded_datetime = dt.Rows[i]["uploaded_datetime"].ToString();

                    ObjexcelhistoryList.Add(objEHList);
                }
                ObjFetch.context.excelHistory = ObjexcelhistoryList;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return ObjFetch;
        }
        public savevectorApplicationouput SaveBulkvector(vectorApplication objRole, string ConString)
        { 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            savevectorApplicationouput objOut = new savevectorApplicationouput();
            try
            {
                string jsonformat = JsonConvert.SerializeObject(objRole.document.context.Detail);
                int retdtls = 0;
                MysqlCon = new DataConnection(ConString);

                savevectorContextRes objContext = new savevectorContextRes();
                objContext.orgnId = objRole.document.context.orgnId;
                objContext.localeId = objRole.document.context.localeId;
                objContext.locnId = objRole.document.context.locnId;
                objContext.userId = objRole.document.context.userId;
                objOut.context = objContext;
                savevectoroutput objOutvector = new savevectoroutput();

                savevectorApplicationException objex = new savevectorApplicationException();
                savevectorContext objCotext = objRole.document.context;
                MySqlCommand cmd = new MySqlCommand("Admin_iud_excel_vector", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objRole.document.context.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objRole.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objRole.document.context.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objRole.document.context.localeId;
                cmd.Parameters.Add("In_farmer_code", MySqlDbType.VarChar).Value = objRole.document.context.Header.In_farmer_code;
                cmd.Parameters.Add("In_version_no", MySqlDbType.VarChar).Value = objRole.document.context.Header.In_version_no;
                cmd.Parameters.Add("In_farmer_name", MySqlDbType.VarChar).Value = objRole.document.context.Header.In_farmer_name;
                cmd.Parameters.Add("In_sur_name", MySqlDbType.VarChar).Value = objRole.document.context.Header.In_sur_name;
                cmd.Parameters.Add("detail_formatted", MySqlDbType.VarChar).Value = jsonformat;
              
                cmd.Parameters.Add(new MySqlParameter("Out_tran_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
             
                MysqlCon.con.Open();
                retdtls = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);

                MysqlCon.con.Close();

                objOutvector.Out_tran_status_desc = (string)cmd.Parameters["Out_tran_status_desc"].Value;

                objOut.context.Header = objOutvector;

                if (objOutvector.Out_tran_status_desc !="")
                {
                    foreach (var Details in objRole.document.context.Detail)
                    {
                        MySqlCommand cmds = new MySqlCommand("", MysqlCon.con);
                        cmds.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objRole.document.context.orgnId;
                        cmds.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objRole.document.context.locnId;
                        cmds.Parameters.Add("userId", MySqlDbType.VarChar).Value = objRole.document.context.userId;
                        cmds.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objRole.document.context.localeId;
                        MysqlCon.con.Open();
                        retdtls = cmds.ExecuteNonQuery();
                        LogHelper.ConvertCmdIntoString(cmd);
                        MysqlCon.con.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                MysqlCon.con.Close();
                logger.Error("USERNAME :" + objRole.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return objOut; 
        }
        public ScalerApplicationRes SaveBulkScalar(ScalerApplication objRole, string ConString)
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ScalerApplicationRes objOut = new ScalerApplicationRes();
            try
            {
                int retdtls = 0;
                MysqlCon = new DataConnection(ConString);

                ScalerContextRes objContext = new ScalerContextRes();
                objContext.orgnId = objRole.document.context.orgnId;
                objContext.localeId = objRole.document.context.localeId;
                objContext.locnId = objRole.document.context.locnId;
                objContext.userId = objRole.document.context.userId;
                objOut.context = objContext;
                HeaderScalarouput objOutscalar = new HeaderScalarouput();

                ScalerApplicationExceptionRes objex = new ScalerApplicationExceptionRes();
                ScalerContext objCotext = objRole.document.context;
                MySqlCommand cmd = new MySqlCommand("Admin_insupd_excel_scalar", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objRole.document.context.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objRole.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objRole.document.context.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objRole.document.context.localeId;
                cmd.Parameters.Add("option_type", MySqlDbType.VarChar).Value = objRole.document.context.header.option_type;
                cmd.Parameters.Add("parameters", MySqlDbType.VarChar).Value = objRole.document.context.header.parameters;
                cmd.Parameters.Add(new MySqlParameter("tran_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("tran_farmer_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("tran_farmer_rowID", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                retdtls = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();
                objOutscalar.tran_status_desc = (string)cmd.Parameters["tran_status_desc"].Value;
                objOutscalar.tran_farmer_code= (string)cmd.Parameters["tran_farmer_code"].Value;
              //  objOutscalar.tran_farmer_rowID = (Int32)cmd.Parameters["tran_farmer_rowID"].Value;
                objOut.context.headerouput = objOutscalar;
           
            }
            catch (Exception ex)
            {
                MysqlCon.con.Close();
                logger.Error("USERNAME :" + objRole.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return objOut; 
        }
        public SaveHistoryContextRes SaveexcelHistory(SaveHistoryApplication objRole, string ConString)
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            SaveHistoryContextRes objOutHistory = new SaveHistoryContextRes();
            try
            {
                int retdtls = 0;
                MysqlCon = new DataConnection(ConString);

                SaveHistoryContext objContext = new SaveHistoryContext();
                objContext.orgnId = objRole.document.context.orgnId;
                objContext.localeId = objRole.document.context.localeId;
                objContext.locnId = objRole.document.context.locnId;
                objContext.userId = objRole.document.context.userId;               

                SaveHistoryApplicationExceptionRes objex = new SaveHistoryApplicationExceptionRes();
                SaveHistoryContext objCotext = objRole.document.context;
                MySqlCommand cmd = new MySqlCommand("Admin_insupd_excel_history_log", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objRole.document.context.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objRole.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objRole.document.context.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objRole.document.context.localeId;
                cmd.Parameters.Add("excel_upload_code", MySqlDbType.VarChar).Value = objRole.document.context.excelHistory.excel_upload_code;
                cmd.Parameters.Add("excel_filename", MySqlDbType.VarChar).Value = objRole.document.context.excelHistory.excel_filename;
                cmd.Parameters.Add("uploaded_by", MySqlDbType.VarChar).Value = objRole.document.context.excelHistory.uploaded_by;
                cmd.Parameters.Add("uploaded_datetime", MySqlDbType.VarChar).Value = objRole.document.context.excelHistory.uploaded_datetime;
                cmd.Parameters.Add("status_code", MySqlDbType.VarChar).Value = objRole.document.context.excelHistory.status_code;

                MysqlCon.con.Open();
                retdtls = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();
                objOutHistory.orgnId = (string)cmd.Parameters["orgnId"].Value;
                objOutHistory.locnId = (string)cmd.Parameters["locnId"].Value;
                objOutHistory.userId = (string)cmd.Parameters["userId"].Value;
                objOutHistory.localeId = (string)cmd.Parameters["localeId"].Value;

            }
            catch (Exception ex)
            {
                MysqlCon.con.Close();
                logger.Error("USERNAME :" + objRole.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return objOutHistory;
        }
        //Ramya Added
        public ScalerApplicationRes SaveBulkDuplicateCheck(duplicatefarmerdata objRole, string ConString)
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ScalerApplicationRes objOut = new ScalerApplicationRes();
            try
            {
                int retdtls = 0;
                MysqlCon = new DataConnection(ConString);

                ScalerContextRes objContext = new ScalerContextRes();
                objContext.orgnId = objRole.orgnId;
                objContext.localeId = objRole.localeId;
                objContext.locnId = objRole.locnId;
                objContext.userId = objRole.userId;
                objOut.context = objContext;
                HeaderScalarouput objOutscalar = new HeaderScalarouput();

                ScalerApplicationExceptionRes objex = new ScalerApplicationExceptionRes();
                MySqlCommand cmd = new MySqlCommand("Admin_farmer_registration_excel_Duplicate", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objRole.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objRole.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objRole.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objRole.localeId;
                cmd.Parameters.Add("In_farmer_name", MySqlDbType.VarChar).Value = objRole.In_farmer_name;
                cmd.Parameters.Add("In_sur_name", MySqlDbType.VarChar).Value = objRole.In_sur_name;
                cmd.Parameters.Add("In_fhw_name", MySqlDbType.VarChar).Value = objRole.In_fhw_name;
                cmd.Parameters.Add("In_farmer_dob", MySqlDbType.VarChar).Value = objRole.In_farmer_dob;
                cmd.Parameters.Add(new MySqlParameter("tran_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                retdtls = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();
                objOutscalar.tran_status_desc = (string)cmd.Parameters["tran_status_desc"].Value;

                objOut.context.headerouput = objOutscalar;

            }
            catch (Exception ex)
            {
                MysqlCon.con.Close();
                logger.Error("USERNAME :" + objRole.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return objOut;
        }
    }
}
