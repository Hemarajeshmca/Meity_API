using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
    public class FDRFarmerInfo_DataModel
    {
        public DataConnection MysqlCon;
        public MySqlConnection con;
        private MySqlCommand cmd;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Captial_DataModel)); //Declaring Log4Net. 
        public DataSet GetFarmerInfonew(SMSGetFarmerInfoModel query, string mysql)
        {
            DataSet Table1 = new DataSet();
            try
            {
                using (con = new MySqlConnection(mysql))
                {
                    using (cmd = new MySqlCommand("PR_GetFarmerInfoNew", con))
                    {
                        cmd.Parameters.AddWithValue("in_StartDate", query.StartDate);
                        cmd.Parameters.AddWithValue("in_EndDate", query.EndDate);
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
        public DataTable GetFarmerInfoOdishaold(SMSGetFarmerInfoModel query, string mysql)
        {
            DataTable dt = new DataTable();
            try
            {
                using (con = new MySqlConnection(mysql))
                {
                    using (cmd = new MySqlCommand("SP_GetFarmerInfoOdisha", con))
                    {
                       
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
        public DataTable GetFarmerInfoOdisha(SMSGetFarmerInfoModelOdisha query, string FPO_CODE, string District, string Taluk, string Village, string mysql)
        {
            DataTable dt = new DataTable();
            try
            {

                if (FPO_CODE =="All")
                {
                    FPO_CODE = "QCD_CROPTYPE_ALL";
                }
                if (District == "All")
                {
                    District = "QCD_CROPTYPE_ALL";
                }
                if (Taluk == "All")
                {
                    Taluk = "QCD_CROPTYPE_ALL";
                }
                if (Village == "All")
                {
                    Village = "QCD_CROPTYPE_ALL";
                }


                using (con = new MySqlConnection(mysql))
                {
                    using (cmd = new MySqlCommand("GetFormerInfoOdishaWebservices", con))
                    {
                        cmd.Parameters.AddWithValue("in_Fpoorgn_code", FPO_CODE);
                        cmd.Parameters.AddWithValue("in_District_name", District);
                        cmd.Parameters.AddWithValue("in_Taluk_name", Taluk);
                        cmd.Parameters.AddWithValue("in_Village_name", Village);
                        cmd.Parameters.AddWithValue("in_StartDate", query.StartDate);
                        cmd.Parameters.AddWithValue("in_EndDate", query.EndDate);
                        cmd.Parameters.Add(new MySqlParameter("record_count", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
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

        public DataSet Fdr_GetFarmerInfO(SMSGetFarmerInfoModel query,string type,string orgn_code, string mysql)
        {
            DataSet Table1 = new DataSet();
            try
            {
                using (con = new MySqlConnection(mysql))
                {
                    using (cmd = new MySqlCommand("PR_Get_FDR_FarmerInfoNew", con))
                    {
                        cmd.Parameters.AddWithValue("in_StartDate", query.StartDate);
                        cmd.Parameters.AddWithValue("in_EndDate", query.EndDate);
                        cmd.Parameters.AddWithValue("in_Type", type);
                        cmd.Parameters.AddWithValue("in_orgn_code", orgn_code);
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
                logger.Error("USERNAME :" + "ERROR  : " + ex);
            }
            return Table1;
        }
        public DataSet GetDailyProgress_db(dailyprogressModel query, string mysql)
        {
            DataSet Table1 = new DataSet();
            try
            {
                using (con = new MySqlConnection(mysql))
                {
                    using (cmd = new MySqlCommand("PR_Get_DailyProgress", con))
                    {
                        cmd.Parameters.AddWithValue("in_Date", query.StartDate);
                        cmd.Parameters.AddWithValue("to_Date", query.EndDate);
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
                logger.Error("USERNAME :" + "ERROR  : " + ex);
            }
            return Table1;
        }
    }
}
