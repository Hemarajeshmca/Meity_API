using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static FFI_Model.ProcurementSales_Model;

namespace FFI_DataModel
{
   public class ProcurementSales_DataModel
    {
        public DataConnection MysqlCon;
        public MySqlConnection con;
        private MySqlCommand cmd;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ProcurementSales_DataModel)); //Declaring Log4Net.


        public DataTable GetProcurementAndSalesReport(ProcurementSalesInfoParams obj,string mysql)
        {
            DataTable dt = new DataTable();
            try
            {  
                using (con = new MySqlConnection(mysql))
                {
                    using (cmd = new MySqlCommand("Report_yieldandprocurement", con))
                    {
                        cmd.Parameters.AddWithValue("in_Start_year", obj.Start_Year);
                        cmd.Parameters.AddWithValue("in_End_year", obj.End_Year); 
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }





    }
}
