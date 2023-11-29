using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static FFI_Model.PADataModel;

namespace FFI_DataModel
{
   public class PAData_DataModel
    {
        public DataConnection MysqlCon;
        public MySqlConnection con;
        private MySqlCommand cmd;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAData_DataModel)); //Declaring Log4Net. 
        public DataSet GetPAPurchaseList(PAPurchaseParams objparam, string constring)
        {
            DataSet Table1 = new DataSet();
            try
            {
                using (con = new MySqlConnection(constring))
                {
                    using (cmd = new MySqlCommand("pr_GetPAPurchaseList", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("in_fpo_code", objparam.In_FPO_Code);
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            sda.Fill(Table1);

                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return Table1;
        }
        public DataSet GetPASaleList(PASaleInputParams objparam, string constring)
        {
            DataSet Table1 = new DataSet();
            try
            {
                using (con = new MySqlConnection(constring))
                {
                    using (cmd = new MySqlCommand("pr_GetPASaleList", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                      //  cmd.Parameters.AddWithValue("in_orgn_code", orgn_code);
                        cmd.Parameters.AddWithValue("in_fpo_code", objparam.In_FPO_Code);
                        cmd.Parameters.AddWithValue("in_fromdate", objparam.In_From_Date);
                        cmd.Parameters.AddWithValue("in_todate", objparam.In_To_Date);

                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            sda.Fill(Table1);

                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return Table1;
        }
    }
}
