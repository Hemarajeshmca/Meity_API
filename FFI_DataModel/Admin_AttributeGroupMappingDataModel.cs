using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
    public class Admin_AttributeGroupMappingDataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        Admin_ErrorMessageModel ObjErrormsg = new Admin_ErrorMessageModel();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Admin_AttributeGroupMappingDataModel));
        // Exception Log Method Name Purpose written start 
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public AttributeGroupMappingList AttributeGroupMappingList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue, string ConString)
        {
            AttributeGroupMappingList ObjFetchAll = new AttributeGroupMappingList();
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MysqlCon = new DataConnection(ConString);
                AGMContext objContext = new AGMContext();
                objContext.orgnId = org;
                objContext.localeId = lang;
                objContext.locnId = locn;
                objContext.userId = user;
                ObjFetchAll.context = objContext;
                MySqlCommand cmd = new MySqlCommand("Admin_fetch_attr_grp_activity_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("in_FilterBy_Option", MySqlDbType.VarChar).Value = filterby_option;
                cmd.Parameters.Add("in_FilterBy_Code", MySqlDbType.VarChar).Value = filterby_code;
                cmd.Parameters.Add("in_FilterBy_FromValue", MySqlDbType.VarChar).Value = filterby_fromvalue;
                cmd.Parameters.Add("in_FilterBy_ToValue", MySqlDbType.VarChar).Value = filterby_tovalue;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);

                MysqlCon.con.Close();

                List<AGMList> objRoleLst = new List<AGMList>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AGMList objList = new AGMList();
                    objList.Out_entitygrpacitivity_rowid = Convert.ToInt32(dt.Rows[i]["Out_entitygrpacitivity_rowid"].ToString());
                    objList.Out_activity_code = dt.Rows[i]["Out_activity_code"].ToString();
                    objList.Out_activity_desc = dt.Rows[i]["Out_activity_desc"].ToString();
                    objList.Out_entitygrp_code = dt.Rows[i]["Out_entitygrp_code"].ToString();
                    objList.Out_entitygrp_name = dt.Rows[i]["Out_entitygrp_name"].ToString();
                    objList.Out_row_slno = Convert.ToInt32(dt.Rows[i]["Out_row_slno"].ToString());
                    objList.Out_mode_flag = dt.Rows[i]["Out_mode_flag"].ToString();
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.Out_status_desc = dt.Rows[i]["Out_status_desc"].ToString();
                    
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

        public FtchAttributeGroupMapping FetchAttributeGroupMapping(string org, string locn, string user, string lang, string activity_code, string ConString)
        {
            FtchAttributeGroupMapping ObjFetch = new FtchAttributeGroupMapping();
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MysqlCon = new DataConnection(ConString);
                FetchAGMContext objContext = new FetchAGMContext();
                objContext.orgnId = org;
                objContext.localeId = lang;
                objContext.locnId = locn;
                objContext.userId = user;
                ObjFetch.context = objContext;
                MySqlCommand cmd = new MySqlCommand("Admin_fetch_attr_grp_activity", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("activity_code", MySqlDbType.VarChar).Value = activity_code;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                List<FetchAGMDetail> ObjRoleList = new List<FetchAGMDetail>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FetchAGMDetail objList = new FetchAGMDetail();
                    objList.In_entitygrpacitivity_rowid = Convert.ToInt32(dt.Rows[i]["In_entitygrpacitivity_rowid"]);
                    objList.In_entitygrp_code = dt.Rows[i]["In_entitygrp_code"].ToString();
                    objList.In_entitygrp_name = dt.Rows[i]["In_entitygrp_name"].ToString();
                    objList.In_row_slno = Convert.ToInt32(dt.Rows[i]["In_row_slno"]);
                    objList.In_mode_flag = dt.Rows[i]["In_mode_flag"].ToString();
                    objList.In_status_code = dt.Rows[i]["In_status_code"].ToString();
                    objList.In_status_desc = dt.Rows[i]["In_status_desc"].ToString();
                    ObjRoleList.Add(objList);
                }
                ObjFetch.context.Detail = ObjRoleList;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }

        public OutputAGM SaveAttributeGroupMapping(SaveAttributeGroupMapping objAG, string ConString)
        {
            OutputAGM ObjFetch = new OutputAGM();
            try
            {
                int ret = 0;
                int retdtls = 0;
                MysqlCon = new DataConnection(ConString);

                OutputAGMContext objContext = new OutputAGMContext();
                objContext.orgnId = objAG.document.context.orgnId;
                objContext.localeId = objAG.document.context.localeId;
                objContext.locnId = objAG.document.context.locnId;
                objContext.userId = objAG.document.context.userId;
                ObjFetch.context = objContext;
                FFI_Model.ApplicationException objEx = new FFI_Model.ApplicationException();
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                bool isvaild = true;

                foreach (var Details in objAG.document.context.Detail)
                {
                    MySqlCommand cmds = new MySqlCommand("Admin_iud_attr_grp_activity", MysqlCon.con);
                    cmds.CommandType = CommandType.StoredProcedure;
                    cmds.Parameters.Add("In_entitygrpacitivity_rowid", MySqlDbType.Int32).Value = Details.In_entitygrpacitivity_rowid;
                    cmds.Parameters.Add("In_activity_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_activity_code;
                    cmds.Parameters.Add("In_entitygrp_code", MySqlDbType.VarChar).Value = Details.In_entitygrp_code;
                    cmds.Parameters.Add("In_row_slno", MySqlDbType.Int32).Value = Details.In_row_slno;
                    cmds.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Details.In_mode_flag;
                    cmds.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = Details.In_status_code;
                    cmds.Parameters.Add("userId", MySqlDbType.VarChar).Value = objAG.document.context.userId;
                    cmds.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objAG.document.context.orgnId;
                    cmds.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objAG.document.context.locnId;
                    cmds.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objAG.document.context.localeId;
                    cmds.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                    ret = cmds.ExecuteNonQuery();
                    LogHelper.ConvertCmdIntoString(cmds);

                    if (ret == 0)
                    {
                        mysqltrans.Rollback();
                        objEx.errorNumber = (string)cmds.Parameters["errorNo"].Value;
                        objEx.errorDescription = ObjErrormsg.ErrorMessage(objEx.errorNumber);
                        isvaild = false;
                        break;
                    }
                }
                if (isvaild == true)
                {
                    mysqltrans.Commit();
                }
                MySqlCommand vcmd = new MySqlCommand("Admin_validate_attr_grp_activity", MysqlCon.con);
                vcmd.CommandType = CommandType.StoredProcedure;
                vcmd.Parameters.Add("in_activity_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_activity_code;
                vcmd.Parameters.Add("in_orgnId", MySqlDbType.VarChar).Value = objAG.document.context.orgnId;
                vcmd.Parameters.Add("in_locnId", MySqlDbType.VarChar).Value = objAG.document.context.locnId;
                vcmd.Parameters.Add("in_userId", MySqlDbType.VarChar).Value = objAG.document.context.userId;
                vcmd.Parameters.Add("in_localeId", MySqlDbType.VarChar).Value = objAG.document.context.localeId;
                vcmd.Parameters.Add(new MySqlParameter("in_errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = vcmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(vcmd);

                if (MysqlCon.con.State == ConnectionState.Open)
                {
                    MysqlCon.con.Close();
                }
                ObjFetch.ApplicationException = objEx;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                logger.Error("USERNAME :" + objAG.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }

    }
}
