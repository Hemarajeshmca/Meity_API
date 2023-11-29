using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FFI_Model;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using MySqlX.XDevAPI.Common;
using System.Reflection;

namespace FFI_DataModel
{
    public class FISAllotmentReg_DataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FDR_FarmerProfileDataModel));
        string methodName = "";

        public AllotemntApplication GetAllAllotmentList(AllotemntContext ObjContext, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            AllotemntApplication ObjFetchAll = new AllotemntApplication();
            ObjFetchAll.context = new AllotemntContext();
            ObjFetchAll.context.List = new List<AllotemntList>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("FIS_fetch_Register_list", MysqlCon.con);
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
                    AllotemntList objList = new AllotemntList();
                    objList.Out_register_rowid = Convert.ToInt32(dt.Rows[i]["Out_register_rowid"]);
                    objList.Out_fpoorgn_code = dt.Rows[i]["Out_fpoorgn_code"].ToString();
                    objList.Out_register_no = dt.Rows[i]["Out_register_no"].ToString();
                    objList.Out_register_type_code = dt.Rows[i]["Out_register_type_code"].ToString();
                    objList.Out_register_type_desc = dt.Rows[i]["Out_register_type_desc"].ToString();
                    objList.Out_register_date = dt.Rows[i]["Out_register_date"].ToString();
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.Out_status_desc = dt.Rows[i]["Out_status_desc"].ToString();

                    ObjFetchAll.context.List.Add(objList);

                }
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }

            return ObjFetchAll;
        }
        public AllotemntFetchApplication GetSingleAllotmentDtls(AllotmentContext ObjContext, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);
            AllotemntFetchApplication ObjFetchAll = new AllotemntFetchApplication();
            ObjFetchAll.context = new AllotmentContext();
            ObjFetchAll.context.Header = new AllotemntHeader();
            ObjFetchAll.context.Detail = new List<Detail>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("FIS_fetch_Allotment_register", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_register_rowid", MySqlDbType.Int32).Value = ObjContext.register_rowid;
                cmd.Parameters.Add("In_fpoorgn_code", MySqlDbType.VarChar).Value = ObjContext.fpoorgn_code;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;

                cmd.Parameters.Add(new MySqlParameter("In_register_type", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_register_type_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_register_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_register_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_record_count", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
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
                    Detail objList = new Detail();
                    objList.In_shareapp_rowid = Convert.ToInt32(dt.Rows[i]["In_shareapp_rowid"]);
                    objList.In_farmer_code = dt.Rows[i]["In_farmer_code"].ToString();
                    objList.In_fpomember_code = dt.Rows[i]["In_fpomember_code"].ToString();
                    objList.In_shareapp_no = dt.Rows[i]["In_shareapp_no"].ToString();
                    objList.In_member_name = dt.Rows[i]["In_member_name"].ToString();
                    objList.In_member_sur_name = dt.Rows[i]["In_member_sur_name"].ToString();
                    objList.In_applied_shares = Convert.ToInt32(dt.Rows[i]["In_applied_shares"]);
                    objList.In_status_code = dt.Rows[i]["In_status_code"].ToString();
                    objList.In_status_desc = dt.Rows[i]["In_status_desc"].ToString();
                    objList.In_chklist_status_flag = dt.Rows[i]["In_chklist_status_flag"].ToString();
                    objList.In_shareapp_remark = dt.Rows[i]["In_shareapp_remark"].ToString();
                    objList.In_mode_flag = dt.Rows[i]["In_mode_flag"].ToString();
                    objList.In_row_timestamp = dt.Rows[i]["In_row_timestamp"].ToString();

                    ObjFetchAll.context.Detail.Add(objList);

                }

                ObjFetchAll.context.Header.In_register_type = (string)cmd.Parameters["In_register_type"].Value;
                ObjFetchAll.context.Header.In_register_type_desc = (string)cmd.Parameters["In_register_type_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_register_no = (string)cmd.Parameters["In_register_no"].Value.ToString();
                ObjFetchAll.context.Header.In_register_date = (string)cmd.Parameters["In_register_date"].Value.ToString();
                ObjFetchAll.context.Header.In_record_count = (Int32)cmd.Parameters["In_record_count"].Value;
                ObjFetchAll.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                ObjFetchAll.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                ObjFetchAll.context.Header.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();

                ObjFetchAll.context.localeId = ObjContext.localeId;
                ObjFetchAll.context.userId = ObjContext.userId;
                ObjFetchAll.context.locnId = ObjContext.locnId;
                ObjFetchAll.context.orgnId = ObjContext.orgnId;


            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }
            return ObjFetchAll;
        }

        public SaveAllotmentDocument SaveAllotmentReg(SaveAllotmentApplication ObjContext, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            int ret = 0;
            MysqlCon = new DataConnection(mysqlcon);
            SaveAllotmentDocument ObjSaveDoc = new SaveAllotmentDocument();
            ObjSaveDoc.context = new SaveAllotmentContext();
            ObjSaveDoc.context.Header = new SaveAllotemntHeader();
            ObjSaveDoc.context.Detail = new List<SaveAllotemntDetail>();
            ObjSaveDoc.ApplicationException = new FFI_Model.ApplicationException();
            string IOU_register_rowid1 = "";
            string IOU_register_no1 = "";           
            string errorNo = "";
            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }
                MySqlCommand cmd = new MySqlCommand("FIS_insupd_allotment_register", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;               
                cmd.Parameters.Add("In_fpoorgn_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_fpoorgn_code;
                cmd.Parameters.Add("In_register_type", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_register_type;
                cmd.Parameters.Add("In_register_date", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_register_date;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmd.Parameters.Add("IOU_register_rowid", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_register_rowid;
                cmd.Parameters.Add("IOU_register_no", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_register_no;
                cmd.Parameters.Add(new MySqlParameter("IOU_register_rowid1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;              
                cmd.Parameters.Add(new MySqlParameter("IOU_register_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                if (ret > 0)
                {
                    IOU_register_rowid1 = (string)cmd.Parameters["IOU_register_rowid1"].Value;
                    IOU_register_no1 = (string)cmd.Parameters["IOU_register_no1"].Value;                   
                    

                    ObjSaveDoc.context.Header.IOU_register_rowid = Convert.ToInt32(IOU_register_rowid1);
                    ObjSaveDoc.context.Header.IOU_register_no = IOU_register_no1;
                }
                if (ObjSaveDoc.context.Header.IOU_register_rowid > 0)
                {
                    string[] Detail = { };
                    Detail = SaveDetail(ObjContext, ObjSaveDoc, mysqlcon, MysqlCon);
                    if (Detail[0].Contains("060"))
                    {
                        mysqltrans.Rollback();
                        ObjSaveDoc.ApplicationException.errorNumber = Detail[0].ToString();
                        ObjSaveDoc.ApplicationException.errorDescription = Detail[1].ToString();
                        return ObjSaveDoc;
                    }
                }
                string[] returnvalues = { IOU_register_rowid1, IOU_register_no1, errorNo };

                mysqltrans.Commit();
                return ObjSaveDoc;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                // throw ex;
                logger.Error("USERNAME :" + ObjContext.document.context.userId+ "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjSaveDoc;
        }
        public string[] SaveDetail(SaveAllotmentApplication Objmodel, SaveAllotmentDocument objfarmer, string MysqlCons, DataConnection MysqlCon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            string[] result = { };
            //string[] resultkyc = { };
            string errorNo = "";
            string errorMsg = "";
            DataTable tab = new DataTable();
            SaveAllotemntDetail objDetail = new SaveAllotemntDetail();
            //try
            //{
                FISAllotmentReg_DataModel objproduct1 = new FISAllotmentReg_DataModel();
                foreach (var Detail in Objmodel.document.context.Detail)
                {
                    objDetail.In_shareapp_rowid = Detail.In_shareapp_rowid;
                    objDetail.In_shareapp_no = Detail.In_shareapp_no;
                    objDetail.In_farmer_code = Detail.In_farmer_code;
                    objDetail.In_fpomember_code = Detail.In_fpomember_code;
                    objDetail.In_member_name = Detail.In_member_name;
                    objDetail.In_member_sur_name = Detail.In_member_sur_name;
                    objDetail.In_applied_shares = Detail.In_applied_shares;
                    objDetail.In_status_code = Detail.In_status_code;
                    objDetail.In_chklist_status_flag = Detail.In_chklist_status_flag;
                    objDetail.In_shareapp_remark = Detail.In_shareapp_remark;
                    objDetail.In_mode_flag = Detail.In_mode_flag;
                    objDetail.In_row_timestamp = Detail.In_row_timestamp;
                    result = objproduct1.SaveDetailNew(objDetail, objfarmer, Objmodel, MysqlCons, MysqlCon);
                    if (result[0].Contains("060"))
                    {
                        errorNo = result[0].ToString();
                        errorMsg = result[1].ToString();
                        break;
                    }
                }
                string[] resultkyc = { errorNo, errorMsg };
                return resultkyc;
                //resultkyc[0] = errorNo;
                //resultkyc[1] = errorMsg;

            //}
            //catch (Exception ex)
            //{
            //    logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            //    //throw ex;
            //}
            //return resultkyc;
        }
        public string[] SaveDetailNew(SaveAllotemntDetail ObjDtl, SaveAllotmentDocument ObjFarmer, SaveAllotmentApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {
            //string[] result = { };
            string errorNo = "";
            string errorMsg = "";
            int ret = 0;
            //try
            //{                
                    MySqlCommand cmd = new MySqlCommand("FIS_iud_allotment_register", MysqlCon.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("IOU_register_no", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.IOU_register_no;
                    cmd.Parameters.Add("In_fpoorgn_code", MySqlDbType.VarChar).Value = Objmodel.document.context.Header.In_fpoorgn_code;
                    cmd.Parameters.Add("In_shareapp_no", MySqlDbType.VarChar).Value = ObjDtl.In_shareapp_no;
                    cmd.Parameters.Add("In_shareapp_rowid", MySqlDbType.Int32).Value = Convert.ToInt32(ObjDtl.In_shareapp_rowid);
                    cmd.Parameters.Add("In_farmer_code", MySqlDbType.VarChar).Value = ObjDtl.In_farmer_code;
                    cmd.Parameters.Add("In_fpomember_code", MySqlDbType.VarChar).Value = ObjDtl.In_fpomember_code;
                    cmd.Parameters.Add("In_member_name", MySqlDbType.VarChar).Value = ObjDtl.In_member_name;
                    cmd.Parameters.Add("In_member_sur_name", MySqlDbType.VarChar).Value = ObjDtl.In_member_sur_name;
                    cmd.Parameters.Add("In_applied_shares", MySqlDbType.Int32).Value = Convert.ToInt32(ObjDtl.In_applied_shares);
                    cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjDtl.In_status_code;
                    cmd.Parameters.Add("In_chklist_status_flag", MySqlDbType.VarChar).Value = ObjDtl.In_chklist_status_flag;
                    cmd.Parameters.Add("In_shareapp_remark", MySqlDbType.VarChar).Value = ObjDtl.In_shareapp_remark;
                    cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Objmodel.document.context.Header.In_mode_flag;
                    cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = Objmodel.document.context.Header.In_row_timestamp;
                    ret = cmd.ExecuteNonQuery();
                   LogHelper.ConvertCmdIntoString(cmd);
                if (ret == 0)
                {

                    errorNo = (string)cmd.Parameters["errorNo"].Value;
                    errorMsg = ObjErrormsg.ErrorMessage(errorNo);

                }
                string[] result = { errorNo, errorMsg };


                //result[0] = errorNo;
                //result[1] = errorMsg;
                return result;
            //}
            //catch (Exception ex)
            //{
            //    logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            //    // throw ex;
            //}
           
        }
    }
}
