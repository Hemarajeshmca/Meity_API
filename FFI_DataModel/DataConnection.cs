using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using FFI_Model;
using System.Data;
using System.Diagnostics;


namespace FFI_DataModel
{
   public class DataConnection
    {
        public MySqlConnection con;
        private MySqlCommand cmd;

        public DataConnection(MySettingsModel ObjModel)
        {
            con = new MySqlConnection(ObjModel.mysqlcon);
            cmd = new MySqlCommand();
            cmd.CommandTimeout = 0;
            cmd.Connection = con;
         
        }
        public DataConnection(string dbsource)
        {
            con = new MySqlConnection(dbsource);
            cmd = new MySqlCommand();
            cmd.CommandTimeout = 0;
            cmd.Connection = con;
        }
        public DataTable RunDataSetProc(string command, Dictionary<string, Object> values = null)
        {
            DataTable temp = new DataTable();
            cmd.CommandText = command;
            cmd.CommandType = CommandType.StoredProcedure;
            string method_name = (new StackTrace()).GetFrame(0).GetMethod().Name;
            string source_name = this.GetType().ToString();
            string retmsg = string.Empty;
            string retresult = string.Empty;
            try
            {

                if (values != null)
                {

                    foreach (string key in values.Keys)
                    {

                        if (values[key] == "out")
                        {
                            cmd.Parameters.Add(key, MySqlDbType.VarChar);
                            cmd.Parameters[key].Direction = ParameterDirection.Output;

                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(key, values[key]);
                        }
                    }
                }
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(temp);
                cmd.Parameters.Clear();
                cmd.Dispose();
                return temp;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                con.Open();               
                cmd.Parameters.Clear();
                cmd.Dispose();
                con.Close();
                return temp;

            }
        }

        public DataTable RunProc(string command, Dictionary<string, Object> values = null)
        {
            DataTable temp = new DataTable();
            cmd.CommandText = command;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                if (values != null)
                {
                    foreach (string key in values.Keys)
                    {

                        cmd.Parameters.AddWithValue(key, values[key]);


                    }
                }
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(temp);
                return temp;
            }
            catch (Exception ex)
            {
                return temp;

            }

        }

        public string[] RunDmlProcMultiple(string command, Dictionary<string, Object> values = null)
        {
            int rowsChanged = 0;
            cmd.CommandText = command;
            cmd.CommandType = CommandType.StoredProcedure;

            string retmsg = string.Empty;
            string retresult = string.Empty;
            string tranfield = string.Empty;

            try
            {

                if (values != null)
                {

                    foreach (string key in values.Keys)
                    {

                        if (values[key] == "out")
                        {
                            cmd.Parameters.Add(key, MySqlDbType.VarChar);
                            cmd.Parameters[key].Direction = ParameterDirection.Output;

                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(key, values[key]);
                        }
                    }
                }
                con.Open();
                rowsChanged = cmd.ExecuteNonQuery();
                tranfield = (string)cmd.Parameters["out_field_name"].Value;
                retmsg = (string)cmd.Parameters["out_msg"].Value;
                retresult = (string)cmd.Parameters["out_result"].Value;

                string[] returnvalues = { tranfield, retmsg, retresult };
                con.Close();
                return returnvalues;
            }
            catch (Exception ex)
            {
                string[] returnvalues = { };
                return returnvalues;

            }

        }
        public string[] RunDmlProc_FileConvert(string command, Dictionary<string, Object> values = null)
        {
            int rowsChanged = 0;
            cmd.CommandText = command;
            cmd.CommandType = CommandType.StoredProcedure;
            string method_name = (new StackTrace()).GetFrame(0).GetMethod().Name;
            string source_name = this.GetType().ToString();

            string retmsg = string.Empty;
            string retresult = string.Empty;

            try
            {

                if (values != null)
                {

                    foreach (string key in values.Keys)
                    {

                        if (values[key] == "out")
                        {
                            cmd.Parameters.Add(key, MySqlDbType.VarChar);
                            cmd.Parameters[key].Direction = ParameterDirection.Output;


                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(key, values[key]);

                        }
                    }
                }
                con.Open();
                rowsChanged = cmd.ExecuteNonQuery();
                retmsg = (string)cmd.Parameters["out_msg"].Value;
                retresult = (string)cmd.Parameters["out_result"].Value;

                string[] returnvalues = { retmsg, retresult };
                con.Close();
                return returnvalues;
            }

            catch (Exception ex)
            {
                string error = ex.ToString();
             
                string[] returnvalues = { "failed", "0" };
                return returnvalues;

            }

        }
        public string[] RunDmlProc(string command, Dictionary<string, Object> values = null)
        {
            int rowsChanged = 0;
            cmd.CommandText = command;
            cmd.CommandType = CommandType.StoredProcedure;
            string method_name = (new StackTrace()).GetFrame(0).GetMethod().Name;
            string source_name = this.GetType().ToString();
            string retmsg = string.Empty;
            string retresult = string.Empty; ;

            try
            {

                if (values != null)
                {

                    foreach (string key in values.Keys)
                    {

                        if (values[key] == "out")
                        {
                            cmd.Parameters.Add(key, MySqlDbType.VarChar);
                            cmd.Parameters[key].Direction = ParameterDirection.Output;
                        }
                        else
                        {
                            if (values[key] == null)
                            {
                                cmd.Parameters.AddWithValue(key, null);
                            }
                            else if (values[key].ToString() != "null")
                            {
                                cmd.Parameters.AddWithValue(key, values[key]);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue(key, null);
                            }
                        }
                    }
                }
                con.Open();
                rowsChanged = cmd.ExecuteNonQuery();
                retmsg = (string)cmd.Parameters["out_msg"].Value;
                retresult = (string)cmd.Parameters["out_result"].Value;

                string[] returnvalues = { retmsg, retresult };
                con.Close();
                return returnvalues;
            }
            catch (Exception ex)
            {

                string error = ex.ToString();
               
                string[] returnvalues = { "failed", "0" };
                return returnvalues;
            }
        }

        public string[] RunDmlProcNew(string command, Dictionary<string, Object> values = null)
        {
            int rowsChanged = 0;
            cmd.CommandText = command;
            cmd.CommandType = CommandType.StoredProcedure;
            //IDbTransaction transactionScope = null;
            string retmsg = string.Empty;
            string retresult = string.Empty;
            string method_name = (new StackTrace()).GetFrame(0).GetMethod().Name;
            string source_name = this.GetType().ToString();
            List<string> outfield = new List<string>();
            List<string> outresult = new List<string>();
            string outvalue;
            try
            {
                if (values != null)
                {
                    foreach (string key in values.Keys)
                    {
                        if (values[key] == "out")
                        {
                            cmd.Parameters.Add(key, MySqlDbType.VarChar);
                            cmd.Parameters[key].Direction = ParameterDirection.Output;
                            outfield.Add(key);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(key, values[key]);
                        }
                    }
                  
                }
                //con.Open();
                //transactionScope = con.BeginTransaction();
                rowsChanged = cmd.ExecuteNonQuery();
              
                //transactionScope.Commit();
                for (int i = 0; i < outfield.Count; i++)
                {
                    outvalue = (string)cmd.Parameters[outfield[i]].Value;
                    outresult.Add(outvalue);
                }
              
                //retmsg = (string)cmd.Parameters["out_msg"].Value;
                //retresult = (string)cmd.Parameters["out_result"].Value;
                //string[] returnvalues = { retmsg, retresult };
                //con.Close();
                return outresult.ToArray();
                //return returnvalues;
            }

            catch (Exception ex)
            {
                string error = ex.ToString();
                con.Close();
                string[] returnvalues = { "0", "failed" };
                //transactionScope.Rollback();
                return returnvalues;
            }
            //finally
            //{
            //    con.Close();
            //}
        }

        public string[] Runfieldtype(string command, Dictionary<string, Object> values = null)
        {
            int rowsChanged = 0;
            cmd.CommandText = command;
            cmd.CommandType = CommandType.StoredProcedure;
            string method_name = (new StackTrace()).GetFrame(0).GetMethod().Name;
            string source_name = this.GetType().ToString();
            string retmsg = string.Empty;
            string retresult = string.Empty;
            try
            {
                if (values != null)
                {
                    foreach (string key in values.Keys)
                    {
                        if (values[key] == "out")
                        {
                            cmd.Parameters.Add(key, MySqlDbType.VarChar);
                            cmd.Parameters[key].Direction = ParameterDirection.Output;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(key, values[key]);
                        }
                    }
                }
                con.Open();
                rowsChanged = cmd.ExecuteNonQuery();
                retmsg = (string)cmd.Parameters["out_field_type"].Value;
                retresult = "0";

                string[] returnvalues = { retmsg, retresult };
                con.Close();
                return returnvalues;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
              
                string[] returnvalues = { "failed", "0" };
                return returnvalues;
            }
        }
        public string[] RunDmlProcFileIns(string command, Dictionary<string, Object> values = null)
        {
            int rowsChanged = 0;
            cmd.CommandText = command;
            cmd.CommandType = CommandType.StoredProcedure;

            string retmsg = string.Empty;
            string retresult = string.Empty;
            string tranfield = string.Empty;
            string[] Out_values = { };
            //List<string> Out_values = new List<string>();

            try
            {
                if (values != null)
                {
                    foreach (string key in values.Keys)
                    {
                        if (values[key] == "out")
                        {
                            //Out_values.Add(key);
                            cmd.Parameters.Add(key, MySqlDbType.VarChar);
                            cmd.Parameters[key].Direction = ParameterDirection.Output;
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue(key, values[key]);
                        }
                    }
                }
                con.Open();
                rowsChanged = cmd.ExecuteNonQuery();
                tranfield = (string)cmd.Parameters["out_file_gid"].Value;
                retmsg = (string)cmd.Parameters["out_msg"].Value;
                retresult = (string)cmd.Parameters["out_result"].Value;

                string[] returnvalues = { tranfield, retmsg, retresult };
                con.Close();
                return returnvalues;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                string[] returnvalues = { error, command };
                return returnvalues;
            }

        }
        public string[] errorlog(string user_code, string ip_address, string method_name, string error, string source_name)
        {
            string retmsg = string.Empty;
            string retresult = string.Empty;

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("pr_ins_errorlog", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("in_user_code", MySqlDbType.VarChar).Value = user_code;
            cmd.Parameters.Add("in_ip_addr", MySqlDbType.VarChar).Value = ip_address;
            cmd.Parameters.Add("in_source_name", MySqlDbType.VarChar).Value = source_name;
            cmd.Parameters.Add("in_proc_name", MySqlDbType.VarChar).Value = method_name;
            cmd.Parameters.Add("in_errorlog_text", MySqlDbType.VarChar).Value = error;
            cmd.Parameters.Add("out_msg", MySqlDbType.VarChar).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("out_result", MySqlDbType.Int32).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            string str = cmd.Parameters["out_msg"].Value.ToString();
            string[] returnvalues = { "failed", "0" };
            return returnvalues;
            //return str;
        }

    }
}
