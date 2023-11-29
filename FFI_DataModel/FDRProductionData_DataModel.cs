using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FFI_Model;
namespace FFI_DataModel
{
   public class FDRProductionData_DataModel
    {
        public DataConnection MysqlCon;
        public MySqlConnection con;
        private MySqlCommand cmd;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FDRProductionData_DataModel)); //Declaring Log4Net. 


        public DataSet GetProductionDataCaptureList(ProductionDataInputParams objparam,string orgn_code, string constring)
        {
            DataSet Table1 = new DataSet();
            try
            {
                using (con = new MySqlConnection(constring))
                {
                    using (cmd = new MySqlCommand("pr_GetProductionDataList", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("in_orgn_code", orgn_code);
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
