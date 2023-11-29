using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FFI_Model;
namespace FFI_DataModel
{
   public class SMS_DataModel
    {
        public DataConnection MysqlCon;
        public MySqlConnection con;
        private MySqlCommand cmd;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Captial_DataModel)); //Declaring Log4Net. 
        public DataSet GetFarmerInfoData(SMSGetFarmerInfoModel query, string mysql)
        {
            DataSet Table1 = new DataSet();
            try
            {
                using (con = new MySqlConnection(mysql))
                {
                    using (cmd = new MySqlCommand("SMSAPI_GetFarmerInfo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

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
        //End

       // start

        public DataSet GetODISHATable(SMSOdishaFarmerInfoModel query, string mysql)
        {
            DataSet Table1 = new DataSet();
            try
            {
                using (con = new MySqlConnection(mysql))
                {
                    using (cmd = new MySqlCommand("SMSAPI_ReportODISHAFarmerDetails", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

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
        //End

        // start
        public DataSet GetICDINTable(SMSIcdDetailsModel query, string mysql)
        {
            DataSet Table1 = new DataSet();
            try
            {
                using (con = new MySqlConnection(mysql))
                {
                    using (cmd = new MySqlCommand("SMSAPI_GetIcdInvoice", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("From_Date", query.FROMDATE);
                        cmd.Parameters.AddWithValue("To_Date", query.TODATE);
                        cmd.Parameters.AddWithValue("Ic_Code", query.ICCODE);
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
        //end 

        //start
        public DataSet GetICDPAYTable(SMSIcdDetailsModel query, string mysql)
        {
            DataSet Table1 = new DataSet();
            try
            {
                using (con = new MySqlConnection(mysql))
                {
                    using (cmd = new MySqlCommand("SMSAPI_GetIcdPayment", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("From_Date", query.FROMDATE);
                        cmd.Parameters.AddWithValue("To_Date", query.TODATE);
                      
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

        //End
        //start
        public DataSet GetICDSTKTable(SMSIcdDetailsModel query, string mysql)
        {
            DataSet Table1 = new DataSet();
            try
            {
                using (con = new MySqlConnection(mysql))
                {
                    using (cmd = new MySqlCommand("SMSAPI_GetIcdStock", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("From_Date", query.FROMDATE);
                        cmd.Parameters.AddWithValue("To_Date", query.TODATE);

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
        //End


        // start
        public DataSet GetICDInvoiceDetails(SMSIcdDetailsModel query, string mysql)
        {
            DataSet Table1 = new DataSet();
            try
            {
                using (con = new MySqlConnection(mysql))
                {
                    using (cmd = new MySqlCommand("ICDInvoiceDetails", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("in_fromdate", query.FROMDATE);
                        cmd.Parameters.AddWithValue("in_todate", query.TODATE);
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

        //end 

        //start
        public DataSet GetICDPaymentDetails(SMSIcdDetailsModel query, string mysql)
        {
            DataSet Table1 = new DataSet();
            try
            {
                using (con = new MySqlConnection(mysql))
                {
                    using (cmd = new MySqlCommand("ICDPaymentDetails", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("in_fromdate", query.FROMDATE);
                        cmd.Parameters.AddWithValue("in_todate", query.TODATE);
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

        //End 

        //start
        public DataSet GetICDStockInward(SMSIcdDetailsModel query, string mysql)
        {
            DataSet Table1 = new DataSet();
            try
            {
                using (con = new MySqlConnection(mysql))
                {
                    using (cmd = new MySqlCommand("ICDSTOCKDetail", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("in_fromdate", query.FROMDATE);
                        cmd.Parameters.AddWithValue("in_todate", query.TODATE);
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

        //End

        //start 
        public DataSet GetPRODUCTHISTORYDb(SMSIcdDetailsModel query, string mysql)
        {
            DataSet Table1 = new DataSet();
            try
            {
                using (con = new MySqlConnection(mysql))
                {
                    using (cmd = new MySqlCommand("ICDPRODUCTHISTORY", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("in_fromdate", query.FROMDATE);
                        cmd.Parameters.AddWithValue("in_todate", query.TODATE);
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
        //End

    }
}
