using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
    public class New_PAWHS_LoginDB
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(New_PAWHS_LoginDB)); //Declaring Log4Net.
        public PAWHSLoginfetchApplication GetAllLogin_DB(string org, string locn, string user, string lang, string In_user_code, string In_user_pwd,int version_number, string mysqlcon)
        {
            DataTable dt = new DataTable();

            PAWHSLoginfetchApplication objinvoiceRoot = new PAWHSLoginfetchApplication();

            objinvoiceRoot.context = new PAWHSLoginfetchContext();
            objinvoiceRoot.context.List = new List<PAWHSLoginfetch>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("New_PAWHS_Login", MysqlCon.con);
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
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PAWHSLoginfetch objList = new PAWHSLoginfetch();

                    objList.In_FPO_Code = dt.Rows[i]["In_FPO_Code"].ToString();
                    objList.In_FPO_Name = dt.Rows[i]["In_FPO_Name"].ToString();
                    objList.In_orgn_code = dt.Rows[i]["In_orgn_code"].ToString();
                    objList.In_orgn_name = dt.Rows[i]["In_orgn_name"].ToString();
                    objList.In_FPO_ORGN = dt.Rows[i]["In_FPO_ORGN"].ToString();
                    objinvoiceRoot.context.List.Add(objList);

                }
                objinvoiceRoot.context.orgnId = (string)cmd.Parameters["In_orgn_code"].Value.ToString();
                objinvoiceRoot.context.locnId = locn;
                objinvoiceRoot.context.localeId = lang;
                objinvoiceRoot.context.userId = user;
                objinvoiceRoot.context.IOU_Reponse = (string)cmd.Parameters["In_Reponse"].Value.ToString();
                objinvoiceRoot.context.IOU_user_code = (string)cmd.Parameters["In_user_code1"].Value.ToString();
                objinvoiceRoot.context.IOU_user_name = (string)cmd.Parameters["In_user_name"].Value.ToString();
                objinvoiceRoot.context.IOU_role_code = (string)cmd.Parameters["In_role_code"].Value.ToString();
                objinvoiceRoot.context.IOU_role_name = (string)cmd.Parameters["In_role_name"].Value.ToString();
                objinvoiceRoot.context.IOU_orgn_code = (string)cmd.Parameters["In_orgn_code"].Value.ToString();
                objinvoiceRoot.context.IOU_location = (string)cmd.Parameters["In_location"].Value.ToString();
            }
            catch (Exception ex)
            {
                objinvoiceRoot.context.IOU_Reponse = ex.Message;
                throw ex;
            }
            return objinvoiceRoot;
        }
        public PAWHSLoginfetchApplication GetAllGram_DB(string org, string Mdatetime, string mysqlcon)
        {
            DataTable dt = new DataTable();
            PAWHSLoginfetchApplication objinvoiceRoot = new PAWHSLoginfetchApplication();
            objinvoiceRoot.GramFetchContext = new PAWHSGramfetchContext();
            objinvoiceRoot.GramFetchContext.List = new List<PAWHSGramPachayatFetch>();
            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("New_PAWHS_fetch_OrgGrampanchayat", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_OrgnCode", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("In_Mdatetime", MySqlDbType.VarChar).Value = Mdatetime;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PAWHSGramPachayatFetch objList = new PAWHSGramPachayatFetch();

                 
                    objList.country_mst = dt.Rows[i]["country_mst"].ToString();
                    objList.country_desc = dt.Rows[i]["country_desc"].ToString();
                    objList.state_mst = dt.Rows[i]["state_mst"].ToString();
                    objList.state_desc = dt.Rows[i]["state_desc"].ToString();
                    objList.dist_mst = dt.Rows[i]["dist_mst"].ToString();
                    objList.dist_desc = dt.Rows[i]["dist_desc"].ToString();
                    objList.taluk_mst = dt.Rows[i]["taluk_mst"].ToString();
                    objList.taluk_desc = dt.Rows[i]["taluk_desc"].ToString();
                    objList.panchayat_mst = dt.Rows[i]["panchayat_mst"].ToString();
                    objList.panchayat_desc = dt.Rows[i]["panchayat_desc"].ToString();
                    objList.village_mst = dt.Rows[i]["village_mst"].ToString();
                    objList.village_desc = dt.Rows[i]["village_desc"].ToString();
                    objList.pincode = dt.Rows[i]["pincode"].ToString();
                    objinvoiceRoot.GramFetchContext.List.Add(objList);

                }
            
            }
            catch (Exception ex)
            {
                objinvoiceRoot.GramFetchContext.ErrorMsg = ex.Message;
                throw ex;
            }
            return objinvoiceRoot;
        }
    }
}
