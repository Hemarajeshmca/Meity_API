using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
   public class Mobile_FDR_ProfileADS_DB
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        public void FarmerAddressDetailsSave(MFPAdderssDetails objFamerAddress, string orgnId, string locnId, string userId, string localeId, string farmer_code, string mysqlcon)
        {
            string response = "";
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MysqlCon.con.Open();
                MySqlCommand cmd = new MySqlCommand("FDRMOB_iud_farmer_pofile_save", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("farmer_code", MySqlDbType.VarChar).Value = farmer_code;
                cmd.Parameters.Add("version_no", MySqlDbType.Int32).Value = 1;
                cmd.Parameters.Add("farmerdetail_rowid", MySqlDbType.Int32).Value = objFamerAddress.in_farmerdetail_rowid;
                cmd.Parameters.Add("entitygrp_code", MySqlDbType.VarChar).Value = objFamerAddress.in_entitygrp_code;
                cmd.Parameters.Add("entity_code", MySqlDbType.VarChar).Value = objFamerAddress.in_entity_code;
                cmd.Parameters.Add("row_slno", MySqlDbType.Int32).Value = Convert.ToInt32(objFamerAddress.in_row_slno);
                cmd.Parameters.Add("entity_value", MySqlDbType.VarChar).Value = objFamerAddress.in_entity_value;
                cmd.Parameters.Add("mode_flag", MySqlDbType.VarChar).Value = objFamerAddress.in_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = localeId;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MysqlCon.con.Close();
            }
            finally
            {
                MysqlCon.con.Close();
            }
        }
    }
}
