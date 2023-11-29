using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
    public class Admin_AttributeGroupDataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        Admin_ErrorMessageModel ObjErrormsg = new Admin_ErrorMessageModel();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Admin_AttributeGroupDataModel));
        // Exception Log Method Name Purpose written start 
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public AttributeGroupList AttributeGroupList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue, string ConString)
        {
            AttributeGroupList ObjFetchAll = new AttributeGroupList();
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MysqlCon = new DataConnection(ConString);
                AttributeGroupContext objContext = new AttributeGroupContext();
                objContext.orgnId = org;
                objContext.localeId = lang;
                objContext.locnId = locn;
                objContext.userId = user;
                ObjFetchAll.context = objContext;
                MySqlCommand cmd = new MySqlCommand("Admin_fetch_attribute_group_list", MysqlCon.con);
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

                List<AGList> objRoleLst = new List<AGList>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AGList objList = new AGList();
                    objList.Out_entitygrp_rowid = Convert.ToInt32(dt.Rows[i]["Out_entitygrp_rowid"].ToString());
                    objList.Out_entitygrp_code = dt.Rows[i]["Out_entitygrp_code"].ToString();
                    objList.Out_entitygrp_name = dt.Rows[i]["Out_entitygrp_name"].ToString();
                    objList.Out_entitygrp_ll_name = dt.Rows[i]["Out_entitygrp_ll_name"].ToString();
                    objList.Out_multiline_flag = dt.Rows[i]["Out_multiline_flag"].ToString();
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

        public FetchAttributeGroup FetchAttributeGroup(string org, string locn, string user, string lang, int entitygrp_rowid, string entitygrp_code,string ConString)
        {
            FetchAttributeGroup ObjFetch = new FetchAttributeGroup();
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MysqlCon = new DataConnection(ConString);
                FetchAttributeGroupContext objContext = new FetchAttributeGroupContext();
                objContext.orgnId = org;
                objContext.localeId = lang;
                objContext.locnId = locn;
                objContext.userId = user;
                ObjFetch.context = objContext;
                MySqlCommand cmd = new MySqlCommand("Admin_fetch_attribute_group", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("in_entitygrp_rowid", MySqlDbType.Int32).Value = entitygrp_rowid;
                cmd.Parameters.Add("in_entitygrp_code", MySqlDbType.VarChar).Value = entitygrp_code;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
            
                cmd.Parameters.Add(new MySqlParameter("in_entitygrp_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_entitygrp_ll_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_multiline_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();


                FetchAttributeGroupHeader objHeader = new FetchAttributeGroupHeader();
                objHeader.In_entitygrp_name = (string)cmd.Parameters["In_entitygrp_name"].Value.ToString();
                objHeader.In_entitygrp_ll_name = (string)cmd.Parameters["In_entitygrp_ll_name"].Value.ToString();
                objHeader.In_multiline_flag = (string)cmd.Parameters["In_multiline_flag"].Value.ToString();
                objHeader.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                objHeader.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                objHeader.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                objHeader.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();

                ObjFetch.context.Header = objHeader;

                List<FetchAttributeGroupDetail> ObjRoleList = new List<FetchAttributeGroupDetail>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FetchAttributeGroupDetail objList = new FetchAttributeGroupDetail();
                    objList.In_entity_rowid = Convert.ToInt32(dt.Rows[i]["In_entity_rowid"]);
                    objList.In_row_slno = Convert.ToInt32(dt.Rows[i]["In_row_slno"]);
                    objList.In_entity_code = dt.Rows[i]["In_entity_code"].ToString();
                    objList.In_entity_name = dt.Rows[i]["In_entity_name"].ToString();
                    objList.In_entity_ll_name = dt.Rows[i]["In_entity_ll_name"].ToString();
                    objList.In_entity_type = dt.Rows[i]["In_entity_type"].ToString();
                    objList.In_entity_type_desc = dt.Rows[i]["In_entity_type_desc"].ToString();
                    objList.In_entity_length = dt.Rows[i]["In_entity_length"].ToString();
                    objList.In_entity_width = Convert.ToInt32(dt.Rows[i]["In_entity_width"].ToString());
                    objList.In_depend_code = dt.Rows[i]["In_depend_code"].ToString();
                    objList.In_depend_desc = dt.Rows[i]["In_depend_desc"].ToString();
                    objList.In_mode_flag = dt.Rows[i]["In_mode_flag"].ToString();
                    
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

        public OutputAG SaveAttributeGroup(SaveAG objAG, string ConString)
        {
            OutputAG ObjFetch = new OutputAG();
            try
            {
                int ret = 0;
                int retdtls = 0;
                MysqlCon = new DataConnection(ConString);

                OutputAGContext objContext = new OutputAGContext();
                objContext.orgnId = objAG.document.context.orgnId;
                objContext.localeId = objAG.document.context.localeId;
                objContext.locnId = objAG.document.context.locnId;
                objContext.userId = objAG.document.context.userId;
                ObjFetch.context = objContext;
                OutputAGHeader objOutHeader = new OutputAGHeader();

                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }


                FFI_Model.ApplicationException objex = new FFI_Model.ApplicationException();
                MySqlCommand cmd = new MySqlCommand("Admin_insupd_attribute_group", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_entitygrp_rowid", MySqlDbType.Int32).Value = objAG.document.context.Header.In_entitygrp_rowid;
                cmd.Parameters.Add("In_entitygrp_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_entitygrp_code;
                cmd.Parameters.Add("In_entitygrp_name", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_entitygrp_name;
                cmd.Parameters.Add("In_entitygrp_ll_name", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_entitygrp_ll_name;
                cmd.Parameters.Add("In_multiline_flag", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_multiline_flag;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objAG.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objAG.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objAG.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objAG.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("In_entitygrp_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                
                retdtls = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);

                if (retdtls > 0)
                {
                    objOutHeader.In_entitygrp_rowid = (Int32)cmd.Parameters["In_entitygrp_rowid1"].Value;
                }
                if (cmd.Parameters["errorNo"].Value.ToString() != "")
                {
                    objex.errorNumber = cmd.Parameters["errorNo"].Value.ToString();
                    objex.errorDescription = ObjErrormsg.ErrorMessage(objex.errorNumber);
                }
                objContext.Header = objOutHeader;

                bool isvaild = true;
                if (objOutHeader.In_entitygrp_rowid > 0)
                {
                    foreach (var Details in objAG.document.context.Detail)
                    {
                        MySqlCommand cmds = new MySqlCommand("Admin_iud_attribute_group_detail", MysqlCon.con);
                        cmds.CommandType = CommandType.StoredProcedure;
                        cmds.Parameters.Add("In_entitygrp_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_entitygrp_code;
                        cmds.Parameters.Add("In_entity_rowid", MySqlDbType.Int32).Value = Details.In_entity_rowid;
                        cmds.Parameters.Add("In_row_slno", MySqlDbType.Int32).Value = Details.In_row_slno;
                        cmds.Parameters.Add("In_entity_code", MySqlDbType.VarChar).Value = Details.In_entity_code;
                        cmds.Parameters.Add("In_entity_name", MySqlDbType.VarChar).Value = Details.In_entity_name;
                        cmds.Parameters.Add("In_entity_ll_name", MySqlDbType.VarChar).Value = Details.In_entity_ll_name;
                        cmds.Parameters.Add("In_entity_type", MySqlDbType.VarChar).Value = Details.In_entity_type;
                        cmds.Parameters.Add("In_entity_length", MySqlDbType.VarChar).Value = Details.In_entity_length;
                        cmds.Parameters.Add("In_entity_width", MySqlDbType.Int32).Value = Details.In_entity_width;
                        cmds.Parameters.Add("In_depend_code", MySqlDbType.VarChar).Value = Details.In_depend_code;
                        cmds.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Details.In_mode_flag;
                        cmds.Parameters.Add("userId", MySqlDbType.VarChar).Value = objAG.document.context.userId;
                        cmds.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objAG.document.context.orgnId;
                        cmds.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objAG.document.context.locnId;
                        cmds.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objAG.document.context.localeId;
                        cmds.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                        ret = cmds.ExecuteNonQuery();
                        LogHelper.ConvertCmdIntoString(cmd);

                        if (ret == 0)
                        {
                            mysqltrans.Rollback();
                            objex.errorNumber = (string)cmds.Parameters["errorNo"].Value;
                            objex.errorDescription = ObjErrormsg.ErrorMessage(objex.errorNumber);
                            isvaild = false;
                            break;
                        }
                    }
                    if (isvaild == true)
                    {
                        mysqltrans.Commit();
                    }
                }
                else
                {
                    mysqltrans.Rollback();
                }
                MySqlCommand vcmd = new MySqlCommand("Admin_validate_attribute_group", MysqlCon.con);
                vcmd.CommandType = CommandType.StoredProcedure;
                vcmd.Parameters.Add("entitygrp_rowid", MySqlDbType.Int32).Value = objAG.document.context.Header.In_entitygrp_rowid;
                vcmd.Parameters.Add("entitygrp_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_entitygrp_code;
                vcmd.Parameters.Add("entitygrp_name", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_entitygrp_name;
                vcmd.Parameters.Add("entitygrp_ll_name", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_entitygrp_ll_name;
                vcmd.Parameters.Add("multiline_flag", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_multiline_flag;
                vcmd.Parameters.Add("status_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_status_code;
                vcmd.Parameters.Add("mode_flag", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_mode_flag;
                vcmd.Parameters.Add("row_timestamp", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_row_timestamp;
                vcmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objAG.document.context.userId;
                vcmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objAG.document.context.orgnId;
                vcmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objAG.document.context.locnId;
                vcmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objAG.document.context.localeId;
                vcmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
               
                ret = vcmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);

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
    }
}
