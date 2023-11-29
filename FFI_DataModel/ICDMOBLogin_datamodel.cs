using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
    public class ICDMOBLogin_datamodel
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Mobile_FDR_Datamodel)); //Declaring Log4Net. 
                                                                                         
        public ICDMOBLogin GetAllFdrLogin_DB(string org, string locn, string user, string lang, string In_user_code, string In_user_pwd, string mysqlcon)
        {
            DataSet dt = new DataSet();
            ICDMOBLogin objinvoiceRoot = new ICDMOBLogin();
            ICDMOBLogin_datamodel objDataModel = new ICDMOBLogin_datamodel();
            objinvoiceRoot.context = new ICDMOBLContext();
            objinvoiceRoot.context.Header = new ICDMOBLHeader();
            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("ICDMOB_UserValidation", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("In_user_code", MySqlDbType.VarChar).Value = In_user_code;
                cmd.Parameters.Add("In_user_pwd", MySqlDbType.VarChar).Value = In_user_pwd;
                cmd.Parameters.Add(new MySqlParameter("In_user_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_user_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_role_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_role_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_orgn_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_location", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_Reponse", MySqlDbType.LongText)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                objinvoiceRoot.context.Header.In_user_code = (string)cmd.Parameters["In_user_code1"].Value.ToString();
                objinvoiceRoot.context.Header.In_user_name = (string)cmd.Parameters["In_user_name"].Value.ToString();
                objinvoiceRoot.context.Header.In_role_code = (string)cmd.Parameters["In_role_code"].Value.ToString();
                objinvoiceRoot.context.Header.In_role_name = (string)cmd.Parameters["In_role_name"].Value.ToString();
                objinvoiceRoot.context.Header.In_orgn_code = (string)cmd.Parameters["In_orgn_code"].Value.ToString();
                objinvoiceRoot.context.Header.In_location = (string)cmd.Parameters["In_location"].Value.ToString();
                objinvoiceRoot.context.Header.In_Reponse = (string)cmd.Parameters["In_Reponse"].Value.ToString();
                objinvoiceRoot.context.orgnId = org;
                objinvoiceRoot.context.locnId = locn;
                objinvoiceRoot.context.localeId = user;
                objinvoiceRoot.context.userId = lang;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }

        public ICDMOBLogin1 icdmob_GetAllFdrLogin_DB(string org, string locn, string user, string lang, string In_user_code, string In_user_pwd,int version_number, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable Detail = new DataTable();

            ICDMOBLogin1 objinvoiceRoot = new ICDMOBLogin1();
            ICDMOBLogin_datamodel objDataModel = new ICDMOBLogin_datamodel();

            objinvoiceRoot.context = new ICDMOBLContext1();
            objinvoiceRoot.context.Header = new ICDMOBLHeader();
            objinvoiceRoot.context.Detail = new List<ICDMOBLDetail>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("ICDMOB_NewUserValidation", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("In_user_code", MySqlDbType.VarChar).Value = In_user_code;
                cmd.Parameters.Add("In_user_pwd", MySqlDbType.VarChar).Value = In_user_pwd;
                cmd.Parameters.Add("In_version_no", MySqlDbType.Int32).Value = version_number;
                cmd.Parameters.Add(new MySqlParameter("In_user_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_user_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_role_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_role_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_orgn_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_location", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_Reponse", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_Config", MySqlDbType.LongText)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();

                objinvoiceRoot.context.Header.In_user_code = (string)cmd.Parameters["In_user_code1"].Value.ToString();
                objinvoiceRoot.context.Header.In_user_name = (string)cmd.Parameters["In_user_name"].Value.ToString();
                objinvoiceRoot.context.Header.In_role_code = (string)cmd.Parameters["In_role_code"].Value.ToString();
                objinvoiceRoot.context.Header.In_role_name = (string)cmd.Parameters["In_role_name"].Value.ToString();
                objinvoiceRoot.context.Header.In_orgn_code = (string)cmd.Parameters["In_orgn_code"].Value.ToString();
                objinvoiceRoot.context.Header.In_location = (string)cmd.Parameters["In_location"].Value.ToString();
                objinvoiceRoot.context.Header.In_Reponse = (string)cmd.Parameters["In_Reponse"].Value.ToString();
                objinvoiceRoot.context.Header.config = (string)cmd.Parameters["In_Config"].Value.ToString();
                objinvoiceRoot.context.orgnId = org;
                objinvoiceRoot.context.locnId = locn;
                objinvoiceRoot.context.localeId = user;
                objinvoiceRoot.context.userId = lang;

                if (ds.Tables.Count > 0)
                {
                    Detail = ds.Tables[0];
                    for (int i = 0; i < Detail.Rows.Count; i++)
                    {
                        ICDMOBLDetail objList = new ICDMOBLDetail();
                        objList.In_orgnlvl_code = Detail.Rows[i]["orgn_code"].ToString();
                        objList.In_orgnlvl_name = Detail.Rows[i]["orgn_name"].ToString();
                        objinvoiceRoot.context.Detail.Add(objList);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }
    }
}
