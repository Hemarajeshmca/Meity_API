using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using static FFI_Model.FISChecklistModel;

namespace FFI_DataModel
{
   public class FISChecklistDataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FISChecklistDataModel)); //Declaring Log4Net. 
        string methodName = MethodBase.GetCurrentMethod().Name;
        public FApplication FISChecklistFetchDBtran(FContext objfpoSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();
            FApplication objChkfetch = new FApplication();
            DataTable Map = new DataTable();
            DataTable OtherDt = new DataTable();
            DataTable SlnoDt = new DataTable();
            objChkfetch.context = new FContext();
            objChkfetch.context.History = new List<History>();
            objChkfetch.context.Element = new List<Element>();
            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("FIS_fetch_checklist_tran", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;
                cmd.Parameters.Add("In_doc_rowid", MySqlDbType.VarChar).Value = objfpoSearch.doc_rowid;
                cmd.Parameters.Add("In_doc_no", MySqlDbType.VarChar).Value = objfpoSearch.doc_no;
                cmd.Parameters.Add("In_doc_type", MySqlDbType.VarChar).Value = objfpoSearch.doc_type;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();
                if (ds.Tables.Count > 0)
                {
                    OtherDt = ds.Tables[0];
                    for (int i = 0; i < OtherDt.Rows.Count; i++)
                    {
                        Element ObjOtherList = new Element();
                        ObjOtherList.In_chklstelement_rowid = (Int32)OtherDt.Rows[i]["In_chklstelement_rowid"];
                        ObjOtherList.In_element_code = OtherDt.Rows[i]["In_element_code"].ToString();
                        ObjOtherList.In_element_desc = OtherDt.Rows[i]["In_element_desc"].ToString();
                        ObjOtherList.In_subelement_code = OtherDt.Rows[i]["In_subelement_code"].ToString();
                        ObjOtherList.In_subelement_desc = OtherDt.Rows[i]["In_subelement_desc"].ToString();
                        ObjOtherList.In_allowed_option = OtherDt.Rows[i]["In_allowed_option"].ToString();
                        ObjOtherList.In_mandatory_flag = OtherDt.Rows[i]["In_mandatory_flag"].ToString();
                        ObjOtherList.In_any_all_flag = OtherDt.Rows[i]["In_any_all_flag"].ToString();
                        ObjOtherList.In_element_value = OtherDt.Rows[i]["In_element_value"].ToString();
                        ObjOtherList.In_complied_flag = OtherDt.Rows[i]["In_complied_flag"].ToString();
                        ObjOtherList.In_verified_on = OtherDt.Rows[i]["In_verified_on"].ToString();
                        ObjOtherList.In_verified_by = OtherDt.Rows[i]["In_verified_by"].ToString();
                        ObjOtherList.In_remarks = OtherDt.Rows[i]["In_remarks"].ToString();
                        ObjOtherList.In_status_code = OtherDt.Rows[i]["In_status_code"].ToString();
                        ObjOtherList.In_status_desc = OtherDt.Rows[i]["In_status_desc"].ToString();
                        ObjOtherList.In_mode_flag = OtherDt.Rows[i]["In_mode_flag"].ToString();
                        objChkfetch.context.Element.Add(ObjOtherList);
                    }
                    SlnoDt = ds.Tables[1];
                    for (int i = 0; i < SlnoDt.Rows.Count; i++)
                    {
                        History ObjHistoryList = new History();
                        ObjHistoryList.In_row_id = Convert.ToInt32(SlnoDt.Rows[i]["In_row_id"]);
                        ObjHistoryList.In_edit_date = SlnoDt.Rows[i]["In_edit_date"].ToString();
                        ObjHistoryList.In_edited_by = SlnoDt.Rows[i]["In_edited_by"].ToString();
                        ObjHistoryList.In_mode_flag = SlnoDt.Rows[i]["In_mode_flag"].ToString();
                        objChkfetch.context.History.Add(ObjHistoryList);
                    }
                    objChkfetch.context.orgnId = objfpoSearch.orgnId;
                    objChkfetch.context.locnId = objfpoSearch.locnId;
                    objChkfetch.context.userId = objfpoSearch.userId;
                    objChkfetch.context.localeId = objfpoSearch.localeId;
                    objChkfetch.context.doc_rowid = (Int32)cmd.Parameters["In_doc_rowid"].Value;
                    objChkfetch.context.doc_no = (string)cmd.Parameters["In_doc_no"].Value.ToString();
                    objChkfetch.context.doc_type= (string)cmd.Parameters["In_doc_type"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objfpoSearch.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objChkfetch;
        }

        public HApplication FISChecklistFetchDBHistory(HContext objfpoSearchH, string mysqlcon)
        {
            DataSet ds = new DataSet();
            HApplication objChkfetchH = new HApplication();
            DataTable Map = new DataTable();
            DataTable OtherDt = new DataTable();
            DataTable SlnoDt = new DataTable();
            objChkfetchH.context = new HContext();
            objChkfetchH.context.Chklist_Element = new List<Chklist_Element>();
          
            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("FIS_fetch_checklist_tran_history", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearchH.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearchH.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearchH.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearchH.localeId;
                cmd.Parameters.Add("In_row_id", MySqlDbType.VarChar).Value = objfpoSearchH.row_id;
                cmd.Parameters.Add("In_doc_rowid", MySqlDbType.VarChar).Value = objfpoSearchH.doc_rowid;
                cmd.Parameters.Add("In_doc_no", MySqlDbType.VarChar).Value = objfpoSearchH.doc_no;
                cmd.Parameters.Add("In_doc_type", MySqlDbType.VarChar).Value = objfpoSearchH.doc_type;
                cmd.Parameters.Add("In_edit_date", MySqlDbType.VarChar).Value = objfpoSearchH.edit_date;
                cmd.Parameters.Add("In_edited_by", MySqlDbType.VarChar).Value = objfpoSearchH.edited_by;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objfpoSearchH.mode_flag;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();
                if (ds.Tables.Count > 0)
                {
                    OtherDt = ds.Tables[0];
                    for (int i = 0; i < OtherDt.Rows.Count; i++)
                    {
                        Chklist_Element ObjOtherList = new Chklist_Element();
                        ObjOtherList.In_chklstelement_rowid = (Int32)OtherDt.Rows[i]["In_chklstelement_rowid"];
                        ObjOtherList.In_element_code = OtherDt.Rows[i]["In_element_code"].ToString();
                        ObjOtherList.In_element_desc = OtherDt.Rows[i]["In_element_desc"].ToString();
                        ObjOtherList.In_subelement_code = OtherDt.Rows[i]["In_subelement_code"].ToString();
                        ObjOtherList.In_subelement_desc = OtherDt.Rows[i]["In_subelement_desc"].ToString();
                        ObjOtherList.In_allowed_option = OtherDt.Rows[i]["In_allowed_option"].ToString();
                        ObjOtherList.In_mandatory_flag = OtherDt.Rows[i]["In_mandatory_flag"].ToString();
                        ObjOtherList.In_any_all_flag = OtherDt.Rows[i]["In_any_all_flag"].ToString();
                        ObjOtherList.In_element_value = OtherDt.Rows[i]["In_element_value"].ToString();
                        ObjOtherList.In_complied_flag = OtherDt.Rows[i]["In_complied_flag"].ToString();
                        ObjOtherList.In_remarks = OtherDt.Rows[i]["In_remarks"].ToString();
                        ObjOtherList.In_mode_flag = OtherDt.Rows[i]["In_mode_flag"].ToString();
                        objChkfetchH.context.Chklist_Element.Add(ObjOtherList);
                    }
                    objChkfetchH.context.orgnId = objfpoSearchH.orgnId;
                    objChkfetchH.context.locnId = objfpoSearchH.locnId;
                    objChkfetchH.context.userId = objfpoSearchH.userId;
                    objChkfetchH.context.localeId = objfpoSearchH.localeId;
                    objChkfetchH.context.row_id = (Int32)cmd.Parameters["In_row_id"].Value;
                    objChkfetchH.context.doc_rowid = (Int32)cmd.Parameters["In_doc_rowid"].Value;
                    objChkfetchH.context.doc_no = (string)cmd.Parameters["In_doc_no"].Value.ToString();
                    objChkfetchH.context.doc_type = (string)cmd.Parameters["In_doc_type"].Value.ToString();
                    objChkfetchH.context.edit_date = (string)cmd.Parameters["In_edit_date"].Value.ToString();
                    objChkfetchH.context.edited_by = (string)cmd.Parameters["In_edited_by"].Value.ToString();
                    objChkfetchH.context.mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objfpoSearchH.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objChkfetchH;
        }

        public SaveCheckTranDocument SaveCheckTranDB(SaveCheckTranApplication ObjCheckTransS, string mysqlcon)
        {
            string[] response = { };
            SaveCheckTranDocument ObjsaveChkT = new SaveCheckTranDocument();
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            try
            { 
                int ret = 0;
                int IOU_doc_rowid1 = 0;
                MysqlCon = new DataConnection(mysqlcon);
                SaveCheckTranContext objContext = new SaveCheckTranContext();
                objContext.orgnId = ObjCheckTransS.document.context.orgnId;
                objContext.localeId = ObjCheckTransS.document.context.localeId;
                objContext.locnId = ObjCheckTransS.document.context.locnId;
                objContext.userId = ObjCheckTransS.document.context.userId;
                ObjsaveChkT.context = objContext;

                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }
          
            foreach (var Details in ObjCheckTransS.document.context.Element)
                {
                    MySqlCommand cmds = new MySqlCommand("FIS_iud_checklist_tran", MysqlCon.con);
                    cmds.CommandType = CommandType.StoredProcedure;
                    cmds.Parameters.Add("IOU_doc_rowid", MySqlDbType.Int32).Value = Details.IOU_doc_rowid;
                    cmds.Parameters.Add("In_doc_no", MySqlDbType.Int32).Value = Details.In_doc_no;
                    cmds.Parameters.Add("In_doc_type", MySqlDbType.VarChar).Value = Details.In_doc_type;
                    cmds.Parameters.Add("In_chklstelement_rowid", MySqlDbType.Int32).Value = Details.In_chklstelement_rowid;
                    cmds.Parameters.Add("In_element_code", MySqlDbType.VarChar).Value = Details.In_element_code;
                    cmds.Parameters.Add("In_subelement_code", MySqlDbType.VarChar).Value = Details.In_subelement_code;
                    cmds.Parameters.Add("In_mandatory_flag", MySqlDbType.VarChar).Value = Details.In_mandatory_flag;
                    cmds.Parameters.Add("In_allowed_option", MySqlDbType.VarChar).Value = Details.In_allowed_option;
                    cmds.Parameters.Add("In_any_all_flag", MySqlDbType.VarChar).Value = Details.In_any_all_flag;
                    cmds.Parameters.Add("In_element_value", MySqlDbType.VarChar).Value = Details.In_element_value;
                    cmds.Parameters.Add("In_complied_flag", MySqlDbType.VarChar).Value = Details.In_complied_flag;
                    cmds.Parameters.Add("In_verified_on", MySqlDbType.VarChar).Value = Details.In_verified_on;
                    cmds.Parameters.Add("In_verified_by", MySqlDbType.VarChar).Value = Details.In_verified_by;
                    cmds.Parameters.Add("In_remarks", MySqlDbType.VarChar).Value = Details.In_remarks;
                    cmds.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = Details.In_status_code;
                    cmds.Parameters.Add("In_status_desc", MySqlDbType.VarChar).Value = Details.In_status_desc;
                    cmds.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Details.In_mode_flag;
                    cmds.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjCheckTransS.document.context.orgnId;
                    cmds.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjCheckTransS.document.context.locnId;
                    cmds.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjCheckTransS.document.context.userId;
                    cmds.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjCheckTransS.document.context.localeId;
                    cmds.Parameters.Add(new MySqlParameter("IOU_doc_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                    string Reponse3 = LogHelper.ConvertObjectIntoString(Details);
                    logger.Debug("Input Parameters -" + Reponse3);
                    ret = cmds.ExecuteNonQuery();
                    if (ret > 0)
                    {
                        IOU_doc_rowid1 = (Int32)cmds.Parameters["IOU_doc_rowid1"].Value;

                    }
                    //Information Log Purpose Written Start 
                    logger.Debug("SP Name  - FIS_iud_checklist_tran");
                    logger.Debug("Input Parameters" + ObjCheckTransS.document.context.orgnId + "," + ObjCheckTransS.document.context.locnId + "," + ObjCheckTransS.document.context.userId + "," + ObjCheckTransS.document.context.localeId);
                    if (ret == 0)
                    {
                        mysqltrans.Rollback();
                        break;
                    }
                }
                
                if (MysqlCon.con.State == ConnectionState.Open)
                {
                    mysqltrans.Commit();
                    MysqlCon.con.Close();
                }
              
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                throw (ex);
            }
            return ObjsaveChkT;



        }
    
    }
}
