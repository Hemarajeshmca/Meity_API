using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FFI_Model;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;

namespace FFI_DataModel
{
   public  class Mobile_FDR_FarmerInfo_DB
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        private MySqlCommand cmd;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FarmerReg_DataModel)); //Declaring Log4Net. 
        public DataSet GetFarmerInfonew(MobileFDRFarmerContext ObjFarmer, string mysqlcon)
        {
            DataSet Table1 = new DataSet();
            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("FDRMOB_GetFarmerInfoNew", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjFarmer.userId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjFarmer.orgnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjFarmer.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjFarmer.localeId;
                cmd.Parameters.Add("In_Taluk", MySqlDbType.VarChar).Value = ObjFarmer.In_Taluk;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(Table1);
                MysqlCon.con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Table1;
        }
    }
}
