using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
    public class Admin_BankDataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        Admin_ErrorMessageModel ObjErrormsg = new Admin_ErrorMessageModel();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Admin_BankDataModel));
        // Exception Log Method Name Purpose written start 
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public BankList BankList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue, string ConString)
        {
            BankList ObjFetchAll = new BankList();
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MysqlCon = new DataConnection(ConString);
                BankContext objContext = new BankContext();
                objContext.orgnId = org;
                objContext.localeId = lang;
                objContext.locnId = locn;
                objContext.userId = user;
                ObjFetchAll.context = objContext;
                MySqlCommand cmd = new MySqlCommand("Admin_fetch_bank_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("In_filterby_option", MySqlDbType.VarChar).Value = filterby_option;
                cmd.Parameters.Add("In_filterby_code", MySqlDbType.VarChar).Value = filterby_code;
                cmd.Parameters.Add("In_filterby_fromvalue", MySqlDbType.VarChar).Value = filterby_fromvalue;
                cmd.Parameters.Add("In_filterby_tovalue", MySqlDbType.VarChar).Value = filterby_tovalue;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                List<BankDtl> objRoleLst = new List<BankDtl>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BankDtl objList = new BankDtl();
                    objList.Out_bank_rowid = Convert.ToInt32(dt.Rows[i]["Out_bank_rowid"].ToString());
                    objList.Out_bank_code = dt.Rows[i]["Out_bank_code"].ToString();
                    objList.Out_bank_name = dt.Rows[i]["Out_bank_name"].ToString();
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.Out_status_desc = dt.Rows[i]["Out_status_desc"].ToString();
                    //Information Log Purpose Written Start 
                    string Reponse = LogHelper.ConvertObjectIntoString(objList);
                    logger.Debug("Output Parameters -" + Reponse);
                    objRoleLst.Add(objList);
                }
                ObjFetchAll.context.BankDtl = objRoleLst;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetchAll;
        }

        public FetchBank FetchBank(string org, string locn, string user, string lang, int bank_rowid, string ConString)
        {
            FetchBank ObjFetch = new FetchBank();
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MysqlCon = new DataConnection(ConString);
                FBContext objContext = new FBContext();
                objContext.orgnId = org;
                objContext.localeId = lang;
                objContext.locnId = locn;
                objContext.userId = user;
                ObjFetch.context = objContext;
                MySqlCommand cmd = new MySqlCommand("Admin_fetch_bankdet", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("In_bank_rowid", MySqlDbType.Int32).Value = bank_rowid;

                //cmd.Parameters.Add(new MySqlParameter("In_bank_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add(new MySqlParameter("In_bank_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add(new MySqlParameter("out_bank", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add(new MySqlParameter("In_bank_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                FBHeader objHeader = new FBHeader();

                //FBHeader objHeader = new FBHeader();
                //objHeader.In_bank_rowid = (int)cmd.Parameters["In_bank_rowid1"].Value;
                //objHeader.In_bank_code = (string)cmd.Parameters["In_bank_code"].Value.ToString();
                //objHeader.In_bank_name = (string)cmd.Parameters["out_bank"].ToString();
                //objHeader.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                //objHeader.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                //objHeader.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();
                //objHeader.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                //objHeader.In_bankname= (string)cmd.Parameters["out_bank"].ToString();
                if (ds.Tables[0].Rows.Count>0)
                {
                    for(int j=0;j<ds.Tables[0].Rows.Count;j++)
                    {
                         objHeader.In_bank_rowid = Convert.ToInt32(bank_rowid);
                         objHeader.In_bank_code = Convert.ToString(ds.Tables[0].Rows[j]["In_bank_code"]); 
                         objHeader.In_bank_name = Convert.ToString(ds.Tables[0].Rows[j]["In_bank_name"]);
                        objHeader.In_status_code = Convert.ToString(ds.Tables[0].Rows[j]["In_status_code"]);
                        objHeader.In_status_desc = Convert.ToString(ds.Tables[0].Rows[j]["In_status_desc"]);
                        objHeader.In_row_timestamp = Convert.ToString(ds.Tables[0].Rows[j]["In_row_timestamp"]);
                        objHeader.In_mode_flag = Convert.ToString(ds.Tables[0].Rows[j]["In_mode_flag"]);

                    }
                }

                ObjFetch.context.Header = objHeader;

                List<FBBankDtl> ObjRoleList = new List<FBBankDtl>();
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    FBBankDtl objList = new FBBankDtl();
                    objList.In_bankifsc_rowid = Convert.ToInt32(ds.Tables[1].Rows[i]["In_bankifsc_rowid"]);
                    objList.In_ifsc_code = ds.Tables[1].Rows[i]["In_ifsc_code"].ToString();
                    objList.In_branch_name = ds.Tables[1].Rows[i]["In_branch_name"].ToString();
                    objList.In_status_code = ds.Tables[1].Rows[i]["In_status_code"].ToString();
                    objList.In_status_desc = ds.Tables[1].Rows[i]["In_status_desc"].ToString();
                    objList.In_row_timestamp = ds.Tables[1].Rows[i]["In_row_timestamp"].ToString();
                    objList.In_mode_flag = ds.Tables[1].Rows[i]["In_mode_flag"].ToString();

                    ObjRoleList.Add(objList);
                }
                ObjFetch.context.BankDtl = ObjRoleList;
                
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }
        public OutputBank SaveBank(SaveBank objBank, string ConString)
        {
            OutputBank ObjFetch = new OutputBank();
            try
            {
                int ret = 0;
                int retdtls = 0;
                MysqlCon = new DataConnection(ConString);
               
                OBContext objContext = new OBContext();
                objContext.orgnId = objBank.document.context.orgnId;
                objContext.localeId = objBank.document.context.localeId;
                objContext.locnId = objBank.document.context.locnId;
                objContext.userId = objBank.document.context.userId;
                ObjFetch.context = objContext;
               
                OBHeader objOutHeader = new OBHeader();

                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }


                FFI_Model.ApplicationExceptionSB objex = new FFI_Model.ApplicationExceptionSB();
                MySqlCommand cmd = new MySqlCommand("Admin_insupd_bank", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("IOU_bank_rowid", MySqlDbType.Int32).Value = objBank.document.context.Header.IOU_bank_rowid;
                cmd.Parameters.Add("In_bank_code", MySqlDbType.VarChar).Value = objBank.document.context.Header.In_bank_code;
                cmd.Parameters.Add("In_bank_name", MySqlDbType.VarChar).Value = objBank.document.context.Header.In_bank_name;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = objBank.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = objBank.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objBank.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objBank.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objBank.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objBank.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objBank.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("IOU_bank_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
               
                retdtls = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);

                if (retdtls > 0)
                {
                    objOutHeader.IOU_bank_rowid = (Int32)cmd.Parameters["IOU_bank_rowid1"].Value;
                    mysqltrans.Commit();
                }
                if(cmd.Parameters["errorNo"].Value.ToString() !="")
                {
                    objex.errorNumber = cmd.Parameters["errorNo"].Value.ToString();
                    objex.errorDescription = ObjErrormsg.ErrorMessage(objex.errorNumber);
                }
               
                objContext.Header = objOutHeader;

                bool isvaild = true;
                if (objOutHeader.IOU_bank_rowid > 0)
                {
                    foreach (var Details in objBank.document.context.BankDtl)
                   {
                        MySqlCommand cmds = new MySqlCommand("Admin_iud_bank_dtl", MysqlCon.con);
                        cmds.CommandType = CommandType.StoredProcedure;
                        cmds.Parameters.Add("In_bank_code", MySqlDbType.VarChar).Value = objBank.document.context.Header.In_bank_code;
                        cmds.Parameters.Add("In_bankifsc_rowid", MySqlDbType.Int32).Value = Details.In_bankifsc_rowid;
                        cmds.Parameters.Add("In_ifsc_code", MySqlDbType.VarChar).Value = Details.In_ifsc_code;
                        cmds.Parameters.Add("In_branch_name", MySqlDbType.VarChar).Value = Details.In_branch_name;
                        cmds.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = Details.In_status_code;
                        cmds.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = Details.In_row_timestamp;
                        cmds.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Details.In_mode_flag;
                        cmds.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objBank.document.context.orgnId;
                        cmds.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objBank.document.context.locnId;
                        cmds.Parameters.Add("userId", MySqlDbType.VarChar).Value = objBank.document.context.userId;
                        cmds.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objBank.document.context.localeId;
                        cmds.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                        
                        ret = cmds.ExecuteNonQuery();
                        LogHelper.ConvertCmdIntoString(cmd);

                        if (ret == 0)
                        {
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


                MySqlCommand vcmd = new MySqlCommand("Admin_validate_bank", MysqlCon.con);
                    vcmd.CommandType = CommandType.StoredProcedure;
                    vcmd.Parameters.Add("IOU_bank_rowid", MySqlDbType.Int32).Value = objBank.document.context.Header.IOU_bank_rowid;
                    vcmd.Parameters.Add("In_bank_code", MySqlDbType.VarChar).Value = objBank.document.context.Header.In_bank_code;
                    vcmd.Parameters.Add("In_bank_name", MySqlDbType.VarChar).Value = objBank.document.context.Header.In_bank_name;
                    vcmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = objBank.document.context.Header.In_status_code;
                    vcmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = objBank.document.context.Header.In_row_timestamp;
                    vcmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objBank.document.context.Header.In_mode_flag;
                    vcmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objBank.document.context.orgnId;
                    vcmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objBank.document.context.locnId;
                    vcmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objBank.document.context.userId;
                    vcmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objBank.document.context.localeId;

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
                logger.Error("USERNAME :" + objBank.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }
    }
}
