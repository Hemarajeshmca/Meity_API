using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
    public class Admin_GSTDataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        Admin_ErrorMessageModel ObjErrormsg = new Admin_ErrorMessageModel();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Admin_GSTDataModel));
        // Exception Log Method Name Purpose written start 
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public GSTList GSTList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue, string ConString)
        {
            GSTList ObjFetchAll = new GSTList();
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MysqlCon = new DataConnection(ConString);
                GSTContext objContext = new GSTContext();
                objContext.orgnId = org;
                objContext.localeId = lang;
                objContext.locnId = locn;
                objContext.userId = user;
                ObjFetchAll.context = objContext;
                MySqlCommand cmd = new MySqlCommand("Admin_fetch_gst_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("in_FilterBy_Option", MySqlDbType.VarChar).Value = filterby_option;
                cmd.Parameters.Add("in_FilterBy_Code", MySqlDbType.VarChar).Value = filterby_code;
                cmd.Parameters.Add("in_FilterBy_FromValue", MySqlDbType.VarChar).Value = filterby_fromvalue;
                cmd.Parameters.Add("in_FilterBy_ToValue", MySqlDbType.VarChar).Value = filterby_tovalue;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
              
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                List<GST> objRoleLst = new List<GST>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    GST objList = new GST();
                    objList.Out_taxrate_rowid = Convert.ToInt32(dt.Rows[i]["Out_taxrate_rowid"].ToString());
                    objList.Out_provider_location = dt.Rows[i]["Out_provider_location"].ToString();
                    objList.Out_provider_location_desc = dt.Rows[i]["Out_provider_location_desc"].ToString();
                    objList.Out_reciver_location = dt.Rows[i]["Out_reciver_location"].ToString();
                    objList.Out_reciver_location_desc = dt.Rows[i]["Out_reciver_location_desc"].ToString();
                    objList.Out_hsn_code = dt.Rows[i]["Out_hsn_code"].ToString();
                    objList.Out_hsn_category_code = dt.Rows[i]["Out_hsn_category_code"].ToString();
                    objList.Out_hsn_category = dt.Rows[i]["Out_hsn_category"].ToString();
                    objList.Out_hsn_description = dt.Rows[i]["Out_hsn_description"].ToString();
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

        public FetchGST FetchGST(string org, string locn, string user, string lang, int taxrate_rowid, string provider_location, string ConString)
        {
            FetchGST ObjFetch = new FetchGST();
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MysqlCon = new DataConnection(ConString);
                FetchGSTContext objContext = new FetchGSTContext();
                objContext.orgnId = org;
                objContext.localeId = lang;
                objContext.locnId = locn;
                objContext.userId = user;
                ObjFetch.context = objContext;
                MySqlCommand cmd = new MySqlCommand("Admin_fetch_gst", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

               
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("IOU_taxrate_rowid", MySqlDbType.Int32).Value = taxrate_rowid;
                cmd.Parameters.Add("IOU_provider_location", MySqlDbType.VarChar).Value = provider_location;

                cmd.Parameters.Add(new MySqlParameter("IOU_taxrate_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_provider_location1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_provider_location_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_reciver_location", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_reciver_location_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;


                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                FetchGSTHeader objHeader = new FetchGSTHeader();

                objHeader.IOU_taxrate_rowid = (int)cmd.Parameters["IOU_taxrate_rowid1"].Value;
                objHeader.IOU_provider_location = (string)cmd.Parameters["IOU_provider_location"].Value.ToString();
                objHeader.In_provider_location_desc = (string)cmd.Parameters["In_provider_location_desc"].ToString();
                objHeader.In_reciver_location = (string)cmd.Parameters["In_reciver_location"].Value.ToString();
                objHeader.In_reciver_location_desc = (string)cmd.Parameters["In_reciver_location_desc"].Value.ToString();
                objHeader.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                objHeader.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                objHeader.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();
                objHeader.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                ObjFetch.context.Header = objHeader;

                List<FetchGSTDetail> ObjRoleList = new List<FetchGSTDetail>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FetchGSTDetail objList = new FetchGSTDetail();
                    objList.In_taxratedtl_rowid = Convert.ToInt32(dt.Rows[i]["In_taxratedtl_rowid"]);
                    objList.In_hsn_code = dt.Rows[i]["In_hsn_code"].ToString();
                    objList.In_hsn_category_code = dt.Rows[i]["In_hsn_category_code"].ToString();
                    objList.In_hsn_category = dt.Rows[i]["In_hsn_category"].ToString();
                    objList.In_hsn_description = dt.Rows[i]["In_hsn_description"].ToString();
                    objList.In_cgst_rate = Convert.ToDouble (dt.Rows[i]["In_cgst_rate"]);
                    objList.In_sgst_rate = Convert.ToDouble(dt.Rows[i]["In_sgst_rate"]);
                    objList.In_igst_rate = Convert.ToDouble(dt.Rows[i]["In_igst_rate"]);
                    objList.In_ugst_rate = Convert.ToDouble(dt.Rows[i]["In_ugst_rate"]);
                    objList.In_status_code = dt.Rows[i]["In_status_code"].ToString();
                    objList.In_status_desc = dt.Rows[i]["In_status_desc"].ToString();
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

        public SaveGSTDocument SaveGST(SaveGST objGST, string ConString)
        {
            SaveGSTDocument ObjFetch = new SaveGSTDocument();
            try
            {
                int ret = 0;
                int retdtls = 0;
                MysqlCon = new DataConnection(ConString);

                SaveGSTContext objContext = new SaveGSTContext();
                objContext.orgnId = objGST.document.context.orgnId;
                objContext.localeId = objGST.document.context.localeId;
                objContext.locnId = objGST.document.context.locnId;
                objContext.userId = objGST.document.context.userId;
                ObjFetch.context = objContext;
                SaveGSTHeader objOutHeader = new SaveGSTHeader();

                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                FFI_Model.ApplicationException objex = new FFI_Model.ApplicationException();
                MySqlCommand cmd = new MySqlCommand("Admin_insupd_gst", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_provider_location", MySqlDbType.VarChar).Value = objGST.document.context.Header.In_provider_location;
                cmd.Parameters.Add("In_reciver_location", MySqlDbType.VarChar).Value = objGST.document.context.Header.In_reciver_location;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = objGST.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = objGST.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objGST.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objGST.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objGST.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objGST.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objGST.document.context.localeId;
                cmd.Parameters.Add("IOU_taxrate_rowid", MySqlDbType.Int32).Value = objGST.document.context.Header.IOU_taxrate_rowid;
                cmd.Parameters.Add(new MySqlParameter("IOU_taxrate_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                retdtls = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);

                if (retdtls > 0)
                {
                    objOutHeader.IOU_taxrate_rowid = (Int32)cmd.Parameters["IOU_taxrate_rowid1"].Value;
                }
                objContext.Header = objOutHeader;

                bool isvaild = true;
                if (objOutHeader.IOU_taxrate_rowid > 0)
                {
                    foreach (var Details in objGST.document.context.Detail)
                    {
                        MySqlCommand cmds = new MySqlCommand("Admin_iud_gst_detail", MysqlCon.con);
                        cmds.CommandType = CommandType.StoredProcedure;
                        cmds.Parameters.Add("IOU_taxrate_rowid", MySqlDbType.Int32).Value = objOutHeader.IOU_taxrate_rowid;
                        cmds.Parameters.Add("In_taxratedtl_rowid", MySqlDbType.Int32).Value = Details.In_taxratedtl_rowid;
                        cmds.Parameters.Add("In_hsn_code", MySqlDbType.VarChar).Value = Details.In_hsn_code;
                        cmds.Parameters.Add("In_hsn_category_code", MySqlDbType.VarChar).Value = Details.In_hsn_category_code;
                        cmds.Parameters.Add("In_hsn_description", MySqlDbType.VarChar).Value = Details.In_hsn_description;
                        cmds.Parameters.Add("In_cgst_rate", MySqlDbType.Float).Value = Details.In_cgst_rate;
                        cmds.Parameters.Add("In_sgst_rate", MySqlDbType.Float).Value = Details.In_sgst_rate;
                        cmds.Parameters.Add("In_igst_rate", MySqlDbType.Float).Value = Details.In_igst_rate;
                        cmds.Parameters.Add("In_ugst_rate", MySqlDbType.Float).Value = Details.In_ugst_rate;
                        cmds.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = Details.In_status_code;
                        cmds.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Details.In_mode_flag;
                        cmds.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objGST.document.context.orgnId;
                        cmds.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objGST.document.context.locnId;
                        cmds.Parameters.Add("userId", MySqlDbType.VarChar).Value = objGST.document.context.userId;
                        cmds.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objGST.document.context.localeId;

                        ret = cmds.ExecuteNonQuery();
                        LogHelper.ConvertCmdIntoString(cmd);

                        if (ret == 0)
                        {
                            mysqltrans.Rollback();
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
                MySqlCommand vcmd = new MySqlCommand("Admin_validate_gst", MysqlCon.con);
                vcmd.CommandType = CommandType.StoredProcedure;
                vcmd.Parameters.Add("p_taxrate_rowid", MySqlDbType.Int32).Value = objGST.document.context.Header.IOU_taxrate_rowid;
                vcmd.Parameters.Add("p_provider_location", MySqlDbType.VarChar).Value = objGST.document.context.Header.In_provider_location;
                vcmd.Parameters.Add("p_reciver_location", MySqlDbType.VarChar).Value = objGST.document.context.Header.In_reciver_location;
                vcmd.Parameters.Add("p_status_code", MySqlDbType.VarChar).Value = objGST.document.context.Header.In_status_code;
                vcmd.Parameters.Add("p_row_timestamp", MySqlDbType.VarChar).Value = objGST.document.context.Header.In_row_timestamp;
                vcmd.Parameters.Add("p_mode_flag", MySqlDbType.VarChar).Value = objGST.document.context.Header.In_mode_flag;
                vcmd.Parameters.Add("p_orgnId", MySqlDbType.VarChar).Value = objGST.document.context.orgnId;
                vcmd.Parameters.Add("p_locnId", MySqlDbType.VarChar).Value = objGST.document.context.locnId;
                vcmd.Parameters.Add("p_userId", MySqlDbType.VarChar).Value = objGST.document.context.userId;
                vcmd.Parameters.Add("p_localeId", MySqlDbType.VarChar).Value = objGST.document.context.localeId;
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
                logger.Error("USERNAME :" + objGST.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }

        //public OutGST SaveGST(SaveGST objGST, string ConString)
        //{
        //    OutGST ObjFetch = new OutGST();
        //    try
        //    {
        //        int ret = 0;
        //        int retdtls = 0;
        //        MysqlCon = new DataConnection(ConString);

        //        OutGSTContext objContext = new OutGSTContext();
        //        objContext.orgnId = objGST.document.context.orgnId;
        //        objContext.localeId = objGST.document.context.localeId;
        //        objContext.locnId = objGST.document.context.locnId;
        //        objContext.userId = objGST.document.context.userId;
        //        ObjFetch.context = objContext;
        //        OutGSTHeader objOutHeader = new OutGSTHeader();

        //        if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
        //        {
        //            MysqlCon.con.Open();
        //            mysqltrans = MysqlCon.con.BeginTransaction();
        //        }

        //        FFI_Model.ApplicationException objex = new FFI_Model.ApplicationException();
        //        MySqlCommand cmd = new MySqlCommand("Admin_insupd_gst", MysqlCon.con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("In_provider_location", MySqlDbType.Int32).Value = objGST.document.context.Header.In_provider_location;
        //        cmd.Parameters.Add("In_reciver_location", MySqlDbType.VarChar).Value = objGST.document.context.Header.In_reciver_location;
        //        cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = objGST.document.context.Header.In_status_code;
        //        cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = objGST.document.context.Header.In_row_timestamp;
        //        cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objGST.document.context.Header.In_mode_flag;
        //        cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objGST.document.context.orgnId;
        //        cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objGST.document.context.locnId;
        //        cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objGST.document.context.userId;
        //        cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objGST.document.context.localeId;
        //        cmd.Parameters.Add("IOU_taxrate_rowid", MySqlDbType.VarChar).Value = objGST.document.context.Header.IOU_taxrate_rowid;
        //        cmd.Parameters.Add(new MySqlParameter("IOU_taxrate_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
        //        retdtls = cmd.ExecuteNonQuery();
        //        if (retdtls > 0)
        //        {
        //            objOutHeader.IOU_taxrate_rowid = (Int32)cmd.Parameters["IOU_taxrate_rowid1"].Value;
        //        }
        //        objContext.Header = objOutHeader;

        //        bool isvaild = true;
        //        if (objOutHeader.IOU_taxrate_rowid > 0)
        //        {
        //            foreach (var Details in objGST.document.context.Detail)
        //            {
        //                MySqlCommand cmds = new MySqlCommand("Admin_iud_gst_detail", MysqlCon.con);
        //                cmds.CommandType = CommandType.StoredProcedure;
        //                cmds.Parameters.Add("IOU_taxrate_rowid", MySqlDbType.Int32).Value = objOutHeader.IOU_taxrate_rowid;
        //                cmds.Parameters.Add("In_taxratedtl_rowid", MySqlDbType.Int32).Value = Details.In_taxratedtl_rowid;
        //                cmds.Parameters.Add("In_hsn_code", MySqlDbType.VarChar).Value = Details.In_hsn_code;
        //                cmds.Parameters.Add("In_hsn_category_code", MySqlDbType.VarChar).Value = Details.In_hsn_category_code;
        //                cmds.Parameters.Add("In_hsn_description", MySqlDbType.VarChar).Value = Details.In_hsn_description;
        //                cmds.Parameters.Add("In_cgst_rate", MySqlDbType.Int32).Value = Details.In_cgst_rate;
        //                cmds.Parameters.Add("In_sgst_rate", MySqlDbType.Int32).Value = Details.In_sgst_rate;
        //                cmds.Parameters.Add("In_igst_rate", MySqlDbType.Int32).Value = Details.In_igst_rate;
        //                cmds.Parameters.Add("In_ugst_rate", MySqlDbType.Int32).Value = Details.In_ugst_rate;
        //                cmds.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = Details.In_status_code;
        //                cmds.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Details.In_mode_flag;
        //                cmds.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objGST.document.context.orgnId;
        //                cmds.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objGST.document.context.locnId;
        //                cmds.Parameters.Add("userId", MySqlDbType.VarChar).Value = objGST.document.context.userId;
        //                cmds.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objGST.document.context.localeId;

        //                ret = cmds.ExecuteNonQuery();
        //                if (ret == 0)
        //                {
        //                    mysqltrans.Rollback();
        //                    isvaild = false;
        //                    break;
        //                }
        //            }
        //            if (isvaild == true)
        //            {
        //                mysqltrans.Commit();
        //            }
        //        }
        //        else
        //        {
        //            mysqltrans.Rollback();
        //        }
        //        MySqlCommand vcmd = new MySqlCommand("Admin_validate_gst", MysqlCon.con);
        //        vcmd.CommandType = CommandType.StoredProcedure;
        //        vcmd.Parameters.Add("p_taxrate_rowid", MySqlDbType.Int32).Value = objGST.document.context.Header.IOU_taxrate_rowid;
        //        vcmd.Parameters.Add("p_provider_location", MySqlDbType.Int32).Value = objGST.document.context.Header.In_provider_location;
        //        vcmd.Parameters.Add("p_reciver_location", MySqlDbType.VarChar).Value = objGST.document.context.Header.In_reciver_location;
        //        vcmd.Parameters.Add("p_status_code", MySqlDbType.VarChar).Value = objGST.document.context.Header.In_status_code;
        //        vcmd.Parameters.Add("p_row_timestamp", MySqlDbType.VarChar).Value = objGST.document.context.Header.In_row_timestamp;
        //        vcmd.Parameters.Add("p_mode_flag", MySqlDbType.VarChar).Value = objGST.document.context.Header.In_mode_flag;
        //        vcmd.Parameters.Add("p_orgnId", MySqlDbType.VarChar).Value = objGST.document.context.orgnId;
        //        vcmd.Parameters.Add("p_locnId", MySqlDbType.VarChar).Value = objGST.document.context.locnId;
        //        vcmd.Parameters.Add("p_userId", MySqlDbType.VarChar).Value = objGST.document.context.userId;
        //        vcmd.Parameters.Add("p_localeId", MySqlDbType.VarChar).Value = objGST.document.context.localeId;
        //        ret = vcmd.ExecuteNonQuery();

        //        if (MysqlCon.con.State == ConnectionState.Open)
        //        {
        //            MysqlCon.con.Close();
        //        }

        //        ObjFetch.ApplicationException = objex;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ObjFetch;
        //}
    }
}
