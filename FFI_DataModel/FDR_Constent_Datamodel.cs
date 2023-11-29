using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace FFI_DataModel
{
    public class FDR_Constent_Datamodel
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInvoice_DataModel)); //Declaring Log4Net. 
        string methodName = MethodBase.GetCurrentMethod().Name;
        public tempalteList FarmerConstenttemplatefetch_DB(tempalteContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();
            tempalteList objinvoiceRoot = new tempalteList();
            ICDInvoice_DataModel objDataModel = new ICDInvoice_DataModel();
            objinvoiceRoot.context = new tempalteContext();
            objinvoiceRoot.context.tempalteContextDtl = new List<tempalteContextDtl>();
            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("FDR_fetch_Template_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("in_orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId; 
                cmd.Parameters.Add("in_userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("in_locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("in_localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tempalteContextDtl objList = new tempalteContextDtl();
                    objList.template_id = Convert.ToInt32(dt.Rows[i]["template_id"]);
                    objList.template_consent = dt.Rows[i]["template_consent"].ToString();
                    objList.effective_From = dt.Rows[i]["effective_From"].ToString();
                    objList.effective_to = dt.Rows[i]["effective_to"].ToString();
                    objList.lang_code = dt.Rows[i]["lang_code"].ToString();
                    objList.status_code = dt.Rows[i]["status_code"].ToString();
                    objList.status_desc = dt.Rows[i]["status_desc"].ToString();
                    objinvoiceRoot.context.tempalteContextDtl.Add(objList);
                }
                objinvoiceRoot.context.orgnId = objinvoice.orgnId;
                objinvoiceRoot.context.locnId = objinvoice.locnId;
                objinvoiceRoot.context.localeId = objinvoice.localeId;
                objinvoiceRoot.context.userId = objinvoice.userId;
              
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objinvoice.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objinvoiceRoot;
        }

       public fdrconstentDocument FarmerConstentsave_DB(fdrconstentroot ObjFarmer, string mysqlcon)
        {
            int ret = 0;
            string errorNo = "";
            string errorMsg = "";
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            fdrconstentDocument objsinvoice = new fdrconstentDocument();
            objsinvoice.context = new fdrconstentContext();
            objsinvoice.context.Header = new fdrconstentDetail();
            Int32 IOU_farmerconsent_rowid = 0;
            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                MySqlCommand cmd = new MySqlCommand("FDR_insupd_farmerconstent", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_farmerconsent_rowid", MySqlDbType.Int32).Value = ObjFarmer.document.context.Header.In_farmerconsent_rowid;
                cmd.Parameters.Add("In_template_id", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_template_id;
                cmd.Parameters.Add("In_consent_owner_id", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_consent_owner_id;
                cmd.Parameters.Add("In_consent_to", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_consent_to;
                cmd.Parameters.Add("In_lang_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_lang_code;
                cmd.Parameters.Add("In_otp", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_otp;
                cmd.Parameters.Add("In_otp_flag", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_otp_flag;
                cmd.Parameters.Add("In_isverified", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_isverified;
                cmd.Parameters.Add("In_attach_consent", MySqlDbType.LongText).Value = ObjFarmer.document.context.Header.In_attach_consent;
                cmd.Parameters.Add("In_attachment_flag", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_attachment_flag;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_mode_flag;

                cmd.Parameters.Add("In_mobile_no", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_mobile_no;
                cmd.Parameters.Add("In_attach_type", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_attach_type;
                cmd.Parameters.Add("In_verified_date", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_verified_date;

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.localeId;                

                cmd.Parameters.Add(new MySqlParameter("IOU_farmerconsent_rowid", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                //LogHelper.ConvertCmdIntoString(cmd);
                if (ret > 0)
                {
                   IOU_farmerconsent_rowid = (Int32)cmd.Parameters["IOU_farmerconsent_rowid"].Value;                  
                    objsinvoice.context.Header.In_farmerconsent_rowid = IOU_farmerconsent_rowid;
                }
                else
                {
                    errorNo = (string)cmd.Parameters["errorNo"].Value;
                    errorMsg = ObjErrormsg.ErrorMessage(errorNo);
                    mysqltrans.Rollback();
                    return objsinvoice;
                }               
                mysqltrans.Commit();
                return objsinvoice;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                logger.Error("USERNAME :" + ObjFarmer.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return objsinvoice;
            }
        }

        public fdrconstentfetch FarmerConstentfetch_DB(fdrconstentfetchContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();
            fdrconstentfetch objinvoiceRoot = new fdrconstentfetch();
            ICDInvoice_DataModel objDataModel = new ICDInvoice_DataModel();
            objinvoiceRoot.context = new fdrconstentfetchContext();
            objinvoiceRoot.context.fdrconstentDtl = new List<fdrconstentDtl>();
            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("FDR_fetch_farmerconsent_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("in_orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("in_userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("in_locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("in_localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
                cmd.Parameters.Add("in_farmer_code", MySqlDbType.VarChar).Value = objinvoice.In_farmer_code;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    fdrconstentDtl objList = new fdrconstentDtl();
                    objList.In_farmerconsent_rowid = Convert.ToInt32(dt.Rows[i]["In_farmerconsent_rowid"]);
                    objList.In_template_id = dt.Rows[i]["In_template_id"].ToString();
                    objList.In_consent_owner_id = dt.Rows[i]["In_consent_owner_id"].ToString();
                    objList.In_consent_to = dt.Rows[i]["In_consent_to"].ToString();
                    objList.In_lang_code = dt.Rows[i]["In_lang_code"].ToString();
                    objList.template_consent = dt.Rows[i]["template_consent"].ToString();
                    objList.In_otp_flag = dt.Rows[i]["In_otp_flag"].ToString();
                    objList.In_isverified = dt.Rows[i]["In_isverified"].ToString();
                    objList.In_attach_consent = dt.Rows[i]["In_attach_consent"].ToString();
                    objList.In_attachment_flag = dt.Rows[i]["In_attachment_flag"].ToString();
                    objList.In_mobile_no = dt.Rows[i]["In_mobile_no"].ToString();
                    objList.In_attach_type = dt.Rows[i]["In_attach_type"].ToString();
                    objList.In_verified_date = dt.Rows[i]["In_verified_date"].ToString();
                    objinvoiceRoot.context.fdrconstentDtl.Add(objList);
                }
                objinvoiceRoot.context.orgnId = objinvoice.orgnId;
                objinvoiceRoot.context.locnId = objinvoice.locnId;
                objinvoiceRoot.context.localeId = objinvoice.localeId;
                objinvoiceRoot.context.userId = objinvoice.userId;
                objinvoiceRoot.context.In_farmer_code = objinvoice.In_farmer_code;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objinvoice.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objinvoiceRoot;
        }

        public gpsDocument gpssave_DB(gpsroot ObjFarmer, string mysqlcon)
        {
            int ret = 0;
            string errorNo = "";
            string errorMsg = "";
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            gpsDocument objsinvoice = new gpsDocument();
            objsinvoice.context = new gpsContext();
            objsinvoice.context.Header = new gpsDetail();
            Int32 In_usergps_id = 0;
            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                MySqlCommand cmd = new MySqlCommand("Admin_insupd_usergps", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_usergps_id", MySqlDbType.Int32).Value = ObjFarmer.document.context.Header.In_usergps_id;
                cmd.Parameters.Add("In_qrvalue", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_qrvalue;
                cmd.Parameters.Add("In_latitude", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_latitude;
                cmd.Parameters.Add("In_longitude", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_longitude;
                cmd.Parameters.Add("In_date", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_date;
                cmd.Parameters.Add("In_input_start_time", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_input_start_time;
                cmd.Parameters.Add("In_input_close_time", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_input_close_time;
                cmd.Parameters.Add("In_pa_start_time", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_pa_start_time;
                cmd.Parameters.Add("In_pa_close_time", MySqlDbType.LongText).Value = ObjFarmer.document.context.Header.In_pa_close_time;
                cmd.Parameters.Add("In_usercode", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_usercode;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_mode_flag;
                cmd.Parameters.Add(new MySqlParameter("IOU_usergps_id", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                //LogHelper.ConvertCmdIntoString(cmd);
                if (ret > 0)
                {
                    In_usergps_id = (Int32)cmd.Parameters["IOU_usergps_id"].Value;
                    objsinvoice.context.Header.In_usergps_id = In_usergps_id;
                    errorNo = (string)cmd.Parameters["errorNo"].Value;
                    objsinvoice.context.Header.errorNo = errorNo;
                }
                else
                {
                    errorNo = (string)cmd.Parameters["errorNo"].Value;
                    errorMsg = ObjErrormsg.ErrorMessage(errorNo);
                    mysqltrans.Rollback();
                    return objsinvoice;
                }
                mysqltrans.Commit();
                return objsinvoice;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                logger.Error("USERNAME :" + ObjFarmer.document.context.Header.In_usercode + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return objsinvoice;
            }
        }

    }
}
