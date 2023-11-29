using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
    public class ProductionDataCapture_DataModel
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public DataConnection MysqlCon;
        public MySqlConnection con;
        private MySqlCommand cmd;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ProductionDataCapture_DataModel)); //Declaring Log4Net. 

        public DataSet GetProductionDataCaputure_Report(ProductionDataCapture_Model query, string mysql)
        {
            DataSet Table1 = new DataSet();
            try
            {
                using (con = new MySqlConnection(mysql))
                {
                    using (cmd = new MySqlCommand("pr_Get_ProductionDataCapture_Report", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("In_StartDate", query.FROMDATE);
                        //cmd.Parameters.AddWithValue("In_EndDate", query.TODATE);
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
