using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
   public class Mobile_FDR_Login_DB
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Mobile_FDR_Datamodel)); //Declaring Log4Net. 
        public FDRLoginfetchApplication GetAllFdrLogin_DB(string org, string locn, string user, string lang, string In_user_code, string In_user_pwd,int version_number, string mysqlcon)
        {
            DataTable dt = new DataTable();

            FDRLoginfetchApplication objinvoiceRoot = new FDRLoginfetchApplication();
            Mobile_FDR_Datamodel objDataModel = new Mobile_FDR_Datamodel();

            objinvoiceRoot.context = new FDRLoginfetchContext();
            objinvoiceRoot.context.FDRLoginfetch = new FDRLoginfetch();           
            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("FDRMOB_UserValidation", MysqlCon.con);
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

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                objinvoiceRoot.context.FDRLoginfetch.In_user_code1 = (string)cmd.Parameters["In_user_code1"].Value.ToString();
                objinvoiceRoot.context.FDRLoginfetch.In_user_name = (string)cmd.Parameters["In_user_name"].Value.ToString();
                objinvoiceRoot.context.FDRLoginfetch.In_role_code = (string)cmd.Parameters["In_role_code"].Value.ToString();
                objinvoiceRoot.context.FDRLoginfetch.In_role_name = (string)cmd.Parameters["In_role_name"].Value.ToString();
                objinvoiceRoot.context.FDRLoginfetch.In_orgn_code = (string)cmd.Parameters["In_orgn_code"].Value.ToString();
                objinvoiceRoot.context.FDRLoginfetch.In_location = (string)cmd.Parameters["In_location"].Value.ToString();
                objinvoiceRoot.context.FDRLoginfetch.In_Reponse = (string)cmd.Parameters["In_Reponse"].Value.ToString();
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
        public LoginfetchApplication GetAllLogin_DB(LoginfetchContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();

            LoginfetchApplication objinvoiceRoot = new LoginfetchApplication();
            Mobile_FDR_Datamodel objDataModel = new Mobile_FDR_Datamodel();

            objinvoiceRoot.context = new LoginfetchContext();
            objinvoiceRoot.context.List = new List<Loginfetch>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("FDRMOB_Login", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
                cmd.Parameters.Add("In_user_code", MySqlDbType.VarChar).Value = objinvoice.In_user_code;
                cmd.Parameters.Add("In_user_pwd", MySqlDbType.VarChar).Value = objinvoice.In_user_pwd;               
                cmd.Parameters.Add(new MySqlParameter("In_Reponse", MySqlDbType.LongText)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();
                for (int i = 0; i < dt.Rows.Count; i++) {
                    Loginfetch objList = new Loginfetch();
              
                objList.In_parent_code = dt.Rows[i]["In_parent_code"].ToString();
                objList.In_orgn_desc = dt.Rows[i]["In_orgn_desc"].ToString();
                objList.In_orgn_code = dt.Rows[i]["In_orgn_code"].ToString();                          
                objinvoiceRoot.context.List.Add(objList);

            }
                objinvoiceRoot.context.orgnId = objinvoice.orgnId;
                objinvoiceRoot.context.locnId = objinvoice.locnId;
                objinvoiceRoot.context.localeId = objinvoice.localeId;
                objinvoiceRoot.context.userId = objinvoice.userId;
                objinvoiceRoot.context.In_Reponse = (string)cmd.Parameters["In_Reponse"].Value.ToString();
            }
            catch (Exception ex)
            {
                objinvoiceRoot.context.In_Reponse = ex.Message;
                throw ex;
            }
            return objinvoiceRoot;
        }
        public comLoginfetchApplication GetAllmodLogin_DB(string org, string locn, string user, string lang, string In_user_code, string In_user_pwd, int version_number , string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable icd = new DataTable();
            DataTable list = new DataTable();
            DataTable pawhs = new DataTable();
            DataTable fpo = new DataTable();

            comLoginfetchApplication objinvoiceRoot = new comLoginfetchApplication();
            Mobile_FDR_Datamodel objDataModel = new Mobile_FDR_Datamodel();

            objinvoiceRoot.context = new comLoginfetchContext();
            objinvoiceRoot.context.List = new comLoginfetch();
            objinvoiceRoot.icd = new List<ICDMOBLDetailcom>();
            objinvoiceRoot.pawhs = new List<PAWHSLoginfetchcom>();
            objinvoiceRoot.Fpo = new List<Fpolist>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("ffimob_com_login", MysqlCon.con);
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
                cmd.Parameters.Add(new MySqlParameter("In_ic_role_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_ic_orgn_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_ic_role_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_Config", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_orgn_level", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();
              
                objinvoiceRoot.context.orgnId = org;
                objinvoiceRoot.context.locnId = locn;
                objinvoiceRoot.context.localeId = user;
                objinvoiceRoot.context.userId = lang;
                if (ds.Tables.Count > 0)
                {                   
                    icd = ds.Tables[0];
                    for (int i = 0; i < icd.Rows.Count; i++)
                    {
                        ICDMOBLDetailcom objListicd = new ICDMOBLDetailcom();
                        objListicd.In_orgnlvl_code = icd.Rows[i]["orgn_code"].ToString();
                        objListicd.In_orgnlvl_name = icd.Rows[i]["orgn_name"].ToString();                      
                        objinvoiceRoot.icd.Add(objListicd);
                    }
                    pawhs = ds.Tables[1];
                    for (int i = 0; i < pawhs.Rows.Count; i++)
                    {
                        PAWHSLoginfetchcom objList = new PAWHSLoginfetchcom();
                        objList.In_FPO_Code = pawhs.Rows[i]["In_FPO_Code"].ToString();
                        objList.In_FPO_Name = pawhs.Rows[i]["In_FPO_Name"].ToString();
                        objList.In_orgn_code = pawhs.Rows[i]["In_orgn_code"].ToString();
                        objList.In_orgn_name = pawhs.Rows[i]["In_orgn_name"].ToString();
                        objList.In_FPO_ORGN = pawhs.Rows[i]["In_FPO_ORGN"].ToString();
                        objinvoiceRoot.pawhs.Add(objList);
                    }
                    fpo = ds.Tables[2];
                    for (int i = 0; i < fpo.Rows.Count; i++)
                    {
                        Fpolist objList = new Fpolist();
                        objList.fpo_orgn_code = fpo.Rows[i]["orgn_code"].ToString();
                        objList.fpo_role_name = fpo.Rows[i]["orgn_name"].ToString();                       
                        objinvoiceRoot.Fpo.Add(objList);
                    }
                }
                objinvoiceRoot.context.List.In_user_code1 = (string)cmd.Parameters["In_user_code1"].Value.ToString();
                objinvoiceRoot.context.List.In_user_name = (string)cmd.Parameters["In_user_name"].Value.ToString();
                objinvoiceRoot.context.List.In_role_code = (string)cmd.Parameters["In_role_code"].Value.ToString();
                objinvoiceRoot.context.List.In_ic_role_code = (string)cmd.Parameters["In_ic_role_code"].Value.ToString();
                objinvoiceRoot.context.List.in_ic_orgn_code = (string)cmd.Parameters["in_ic_orgn_code"].Value.ToString();
                objinvoiceRoot.context.List.in_ic_role_name = (string)cmd.Parameters["in_ic_role_name"].Value.ToString(); 
                objinvoiceRoot.context.List.In_role_name = (string)cmd.Parameters["In_role_name"].Value.ToString();
                objinvoiceRoot.context.List.In_orgn_code = (string)cmd.Parameters["In_orgn_code"].Value.ToString();
                objinvoiceRoot.context.List.In_location = (string)cmd.Parameters["In_location"].Value.ToString();
                objinvoiceRoot.context.List.In_Reponse = (string)cmd.Parameters["In_Reponse"].Value.ToString();
                objinvoiceRoot.context.List.config = (string)cmd.Parameters["In_Config"].Value.ToString();
                objinvoiceRoot.context.List.In_orgn_level = (string)cmd.Parameters["In_orgn_level"].Value.ToString();
            }
            catch (Exception ex)
            {
                objinvoiceRoot.context.In_Reponse = ex.Message;
                throw ex;
            }
            return objinvoiceRoot;
        }
    }
}
