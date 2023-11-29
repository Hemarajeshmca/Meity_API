using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using FFI_Model;
namespace FFI_DataModel
{
    public class ChecklistDefinition_DB
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon; 
        Admin_ErrorMessageModel ObjErrormsg = new Admin_ErrorMessageModel();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Admin_RoleManagementDataModel));
        // Exception Log Method Name Purpose written start 
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public Chklist_FetchApplication ChecklistDefinition_List(Chklist_FetchContext ObjContext, string mysqlcon)
        {
            int j = 0;
            string pc = "";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);
            Chklist_FetchApplication ObjFetchAll = new Chklist_FetchApplication();
            Chklist_FetchApplicationException maserror = new Chklist_FetchApplicationException();
            ObjFetchAll.context = new Chklist_FetchContext();
            ObjFetchAll.context.Header = new Chklist_FetchHeader();
            ObjFetchAll.context.Element = new List<Chklist_FetchElement>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("Admin_fetch_checklist", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("IOU_chklst_rowid", MySqlDbType.Int32).Value = ObjContext.chklst_rowid;
                cmd.Parameters.Add("IOU_activity_code", MySqlDbType.VarChar).Value = ObjContext.activity_code; 
                cmd.Parameters.Add(new MySqlParameter("IOU_chklst_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_activity_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_activity_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Chklist_FetchElement objList = new Chklist_FetchElement();
                    j = Convert.ToInt32(dt.Rows[i]["In_chklstelement_rowid"]); 
                    objList.In_chklstelement_rowid = Convert.ToInt32(dt.Rows[i]["In_chklstelement_rowid"]);
                    objList.In_element_code = dt.Rows[i]["In_element_code"].ToString();
                    objList.In_element_desc = dt.Rows[i]["In_element_desc"].ToString();
                    objList.In_subelement_code = dt.Rows[i]["In_subelement_code"].ToString();
                    objList.In_subelement_desc = dt.Rows[i]["In_subelement_desc"].ToString();
                    objList.In_mandatory_flag = dt.Rows[i]["In_mandatory_flag"].ToString();
                    objList.In_allowed_option = dt.Rows[i]["In_allowed_option"].ToString();
                    objList.In_any_all_flag = dt.Rows[i]["In_any_all_flag"].ToString();
                    objList.In_any_all_flag_desc = dt.Rows[i]["In_any_all_flag_desc"].ToString();
                    objList.In_status_code = dt.Rows[i]["In_status_code"].ToString();
                    objList.In_status_desc = dt.Rows[i]["In_status_desc"].ToString();
                    objList.In_mode_flag = dt.Rows[i]["In_mode_flag"].ToString();
                    ObjFetchAll.context.Element.Add(objList);
                }
                ObjFetchAll.context.orgnId = ObjContext.orgnId;
                ObjFetchAll.context.locnId = ObjContext.locnId;
                ObjFetchAll.context.userId = ObjContext.userId;
                ObjFetchAll.context.localeId = ObjContext.localeId;
                ObjFetchAll.context.Header.IOU_chklst_rowid=(Int32)cmd.Parameters["IOU_chklst_rowid1"].Value;
                ObjFetchAll.context.Header.IOU_activity_code = (string)cmd.Parameters["IOU_activity_code1"].Value.ToString();
                ObjFetchAll.context.Header.In_activity_desc = (string)cmd.Parameters["In_activity_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                ObjFetchAll.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                ObjFetchAll.context.Header.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();
            }
            catch (Exception ex)
            {
                MysqlCon.con.Open();
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }

            return ObjFetchAll;
        }

        public Chklist_SDocument ChecklistDefinition_save(Chklist_SApplication ObjICDSupplier, string mysqlcon)
        {
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            Chklist_SDocument ObjresICDSupplier = new Chklist_SDocument();
            ObjresICDSupplier.context = new Chklist_SContext();
            ObjresICDSupplier.context.Header = new Chklist_SHeader();
            try
            {
                int ret = 0; 
                int In_supplier_rowid1 = 0; 
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }
                MySqlCommand cmd = new MySqlCommand("Admin_insupd_checklist", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("IOU_chklst_rowid", MySqlDbType.Int32).Value = ObjICDSupplier.document.context.Header.IOU_chklst_rowid;// ObjFarmer.document.context.Header.in_farmer_rowid;
                cmd.Parameters.Add("In_activity_code", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_activity_code;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.Header.In_row_timestamp; 
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjICDSupplier.document.context.localeId; 
                cmd.Parameters.Add(new MySqlParameter("IOU_chklst_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output; 
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);

                if (ret > 0)
                {
                    In_supplier_rowid1 = (Int32)cmd.Parameters["IOU_chklst_rowid1"].Value;  
                    ObjresICDSupplier.context.Header.IOU_chklst_rowid = Convert.ToInt32(In_supplier_rowid1); 
                    ObjresICDSupplier.context.orgnId = ObjICDSupplier.document.context.orgnId;
                    ObjresICDSupplier.context.locnId = ObjICDSupplier.document.context.locnId;
                    ObjresICDSupplier.context.userId = ObjICDSupplier.document.context.userId;
                    ObjresICDSupplier.context.localeId = ObjICDSupplier.document.context.localeId;

                    if (ObjresICDSupplier.context.Header.IOU_chklst_rowid > 0)
                    {
                        ret = 0;
                        ret = SaveCheklist(ObjICDSupplier, ObjresICDSupplier, mysqlcon, MysqlCon);
                        if(ret > 0)
                        {
                            mysqltrans.Commit();
                        }
                        else
                        {
                            mysqltrans.Rollback();
                        }
                    }

                }
                else
                {
                    mysqltrans.Rollback();
                    return ObjresICDSupplier;
                }


            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                logger.Error("USERNAME :" + ObjICDSupplier.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjresICDSupplier;

        }


        public int SaveCheklist(Chklist_SApplication ObjmodelT, Chklist_SDocument objIUSuppT, string MysqlCons, DataConnection MysqlCon)
        {
            int saving = 0; 
            DataTable tab = new DataTable();
            // SaveSupplierAddress objadddtl = new SaveSupplierAddress();
            Chklist_SElement objtaxdtl = new Chklist_SElement();
            try
            {
                ChecklistDefinition_DB objproduct1 = new ChecklistDefinition_DB();
                foreach (var Kyc in ObjmodelT.document.context.Element)
                {
                    objtaxdtl.In_chklstelement_rowid = Kyc.In_chklstelement_rowid;
                    objtaxdtl.In_element_code = Kyc.In_element_code;
                    objtaxdtl.In_subelement_code = Kyc.In_subelement_code;
                    objtaxdtl.In_mandatory_flag = Kyc.In_mandatory_flag;
                    objtaxdtl.In_allowed_option = Kyc.In_allowed_option;
                    objtaxdtl.In_any_all_flag = Kyc.In_any_all_flag;
                    objtaxdtl.In_status_code = Kyc.In_status_code;
                    objtaxdtl.In_mode_flag = Kyc.In_mode_flag;
                    saving = objproduct1.SaveICDSupplierTaxSP(objtaxdtl, objIUSuppT, ObjmodelT, MysqlCons, MysqlCon); 
                    if (saving == 0)
                    {
                        break;
                    }
                }
            }

            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objIUSuppT.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return saving;

        }
        public int SaveICDSupplierTaxSP(Chklist_SElement objtaxdtl, Chklist_SDocument objIUSuppT, Chklist_SApplication ObjmodelT, string mysqlcons, DataConnection MysqlCon)
        {

            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("Admin_iud_checklist", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_activity_code", MySqlDbType.VarChar).Value = ObjmodelT.document.context.Header.In_activity_code;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjmodelT.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjmodelT.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjmodelT.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjmodelT.document.context.localeId;
                cmd.Parameters.Add("In_chklstelement_rowid", MySqlDbType.Int32).Value = objtaxdtl.In_chklstelement_rowid;
                cmd.Parameters.Add("In_element_code", MySqlDbType.VarChar).Value = objtaxdtl.In_element_code;
                cmd.Parameters.Add("In_subelement_code", MySqlDbType.VarChar).Value = objtaxdtl.In_subelement_code;
                cmd.Parameters.Add("In_mandatory_flag", MySqlDbType.VarChar).Value = objtaxdtl.In_mandatory_flag;
                cmd.Parameters.Add("In_allowed_option", MySqlDbType.VarChar).Value = objtaxdtl.In_allowed_option;
                cmd.Parameters.Add("In_any_all_flag", MySqlDbType.VarChar).Value = objtaxdtl.In_any_all_flag;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = objtaxdtl.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objtaxdtl.In_mode_flag; 
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);

            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objIUSuppT.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ret;

        }

    }
}
