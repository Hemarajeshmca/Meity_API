using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
   public class Mobile_FDR_Offlinesave_DB
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        public FarmerProfileOutput SaveFarmerHeaderData(MFPHeaderDetails objMFPHeader,string mysqlcon)
        {
            int ret = 0;
            string in_farmer_rowid1 = "";
            string in_farmer_code1 = "";
            string in_version_no1 = "";
            string Err_Msg = "";
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            SFarmerDocument objresFarmer = new SFarmerDocument();
            objresFarmer.context = new SFarmerContext();
            objresFarmer.context.Header = new SFarmerHeaderSegment();
            objresFarmer.ApplicationException = new FFI_Model.ApplicationException();
            FarmerProfileOutput ObjOutput = new FarmerProfileOutput();
            try
            {
                string date = objMFPHeader.in_farmer_dob;
                DateTime dt = Convert.ToDateTime(date);
                string dob = dt.ToString("yyyy-MM-dd");
                MySqlCommand cmd = new MySqlCommand("FDRMOB_insupd_farmer_registration", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("in_farmer_rowid", MySqlDbType.Int32).Value = objMFPHeader.in_farmer_rowid;
                cmd.Parameters.Add("in_farmer_code", MySqlDbType.VarChar).Value = objMFPHeader.in_farmer_code;
                cmd.Parameters.Add("in_fpo_orgncode", MySqlDbType.VarChar).Value = objMFPHeader.in_fpo_orgncode;
                cmd.Parameters.Add("in_version_no", MySqlDbType.Int32).Value = objMFPHeader.in_version_no;
                cmd.Parameters.Add("in_photo_farmer", MySqlDbType.LongText).Value = objMFPHeader.in_photo_farmer;
                cmd.Parameters.Add("in_farmer_name", MySqlDbType.VarChar).Value = objMFPHeader.in_farmer_name;
                cmd.Parameters.Add("in_sur_name", MySqlDbType.VarChar).Value = objMFPHeader.in_sur_name;
                cmd.Parameters.Add("in_fhw_name", MySqlDbType.VarChar).Value = objMFPHeader.in_fhw_name;
                cmd.Parameters.Add("in_farmer_dob", MySqlDbType.VarChar).Value = dob;
                cmd.Parameters.Add("in_farmer_addr1", MySqlDbType.VarChar).Value = objMFPHeader.in_farmer_addr1;
                cmd.Parameters.Add("in_farmer_addr2", MySqlDbType.VarChar).Value = objMFPHeader.in_farmer_addr2;
                cmd.Parameters.Add("in_farmer_country", MySqlDbType.VarChar).Value = objMFPHeader.in_farmer_country;
                cmd.Parameters.Add("in_farmer_state", MySqlDbType.VarChar).Value = objMFPHeader.in_farmer_state;
                cmd.Parameters.Add("in_farmer_dist", MySqlDbType.VarChar).Value = objMFPHeader.in_farmer_dist;
                cmd.Parameters.Add("in_farmer_taluk", MySqlDbType.VarChar).Value = objMFPHeader.in_farmer_taluk;
                cmd.Parameters.Add("in_farmer_panchayat", MySqlDbType.VarChar).Value = objMFPHeader.in_farmer_panchayat;
                cmd.Parameters.Add("in_farmer_village", MySqlDbType.VarChar).Value = objMFPHeader.in_farmer_village;
                cmd.Parameters.Add("in_farmer_pincode", MySqlDbType.VarChar).Value = objMFPHeader.in_farmer_pincode;
                cmd.Parameters.Add("in_marital_status", MySqlDbType.VarChar).Value = objMFPHeader.in_marital_status;
                cmd.Parameters.Add("in_gender_flag", MySqlDbType.VarChar).Value = objMFPHeader.in_gender_flag;
                cmd.Parameters.Add("in_reg_mobile_no", MySqlDbType.VarChar).Value = objMFPHeader.in_reg_mobile_no;
                cmd.Parameters.Add("in_status_code", MySqlDbType.VarChar).Value = objMFPHeader.in_status_code;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = objMFPHeader.in_mode_flag; 
                cmd.Parameters.Add("created_by", MySqlDbType.VarChar).Value = objMFPHeader.userId;                
                cmd.Parameters.Add("in_row_timestamp", MySqlDbType.VarChar).Value = objMFPHeader.in_row_timestamp;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objMFPHeader.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objMFPHeader.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objMFPHeader.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objMFPHeader.localeId;
                cmd.Parameters.Add("DupFlag", MySqlDbType.VarChar).Value = objMFPHeader.in_dup_flag;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_rowid1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_version_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                ret = cmd.ExecuteNonQuery();
                if (ret > 0)
                {
                    in_farmer_rowid1 = (string)cmd.Parameters["in_farmer_rowid1"].Value;
                    in_farmer_code1 = (string)cmd.Parameters["in_farmer_code1"].Value;
                    in_version_no1 = (string)cmd.Parameters["in_version_no1"].Value;
                    Err_Msg = (string)cmd.Parameters["errorNo"].Value;

                ObjOutput.in_farmer_rowid = Convert.ToInt32(in_farmer_rowid1);
                ObjOutput.in_farmer_code = in_farmer_code1;
                ObjOutput.in_version_no = Convert.ToInt32(in_version_no1);
                    ObjOutput.error_msg = Err_Msg;
                }
                else
                {
                    
                    Err_Msg = (string)cmd.Parameters["errorNo"].Value;

                  
                    ObjOutput.error_msg = Err_Msg;
                }
          
            }
            catch (Exception ex)
            {
                ObjOutput.error_msg = ex.ToString();
                MysqlCon.con.Close();
            }
            finally
            {
                MysqlCon.con.Close();
            }
            return ObjOutput;
        }

        public void FarmerBankDetailsSave(MFPBankDetails objBank, string orgnId, string locnId, string userId, string localeId, string farmer_code,string mysqlcon)
        {

            string response = "";
            try
            {
                MysqlCon.con.Open();
                MySqlCommand cmd = new MySqlCommand("FDR_iud_farmerbank", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("in_farmer_code", MySqlDbType.VarChar).Value = farmer_code;
                cmd.Parameters.Add("in_version_no", MySqlDbType.Int32).Value = 1;
                cmd.Parameters.Add("in_farmerbank_rowid", MySqlDbType.Int32).Value = objBank.in_farmerbank_rowid;
                cmd.Parameters.Add("in_bank_acc_no", MySqlDbType.VarChar).Value = objBank.in_bank_acc_no;
                cmd.Parameters.Add("in_bank_acc_type", MySqlDbType.VarChar).Value = objBank.in_bank_acc_type;
                cmd.Parameters.Add("in_bank_code", MySqlDbType.VarChar).Value = objBank.in_bank_code;
                cmd.Parameters.Add("in_branch_code", MySqlDbType.VarChar).Value = objBank.in_branch_code;
                cmd.Parameters.Add("in_ifsc_code", MySqlDbType.VarChar).Value = objBank.in_ifsc_code;
                cmd.Parameters.Add("in_dflt_dr_acc", MySqlDbType.VarChar).Value = objBank.in_dflt_dr_acc;
                cmd.Parameters.Add("in_dflt_cr_acc", MySqlDbType.VarChar).Value = objBank.in_dflt_cr_acc;
                cmd.Parameters.Add("in_status_code", MySqlDbType.VarChar).Value = objBank.in_status_code;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = objBank.in_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = localeId;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                response = (string)cmd.Parameters["errorNo"].Value;
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
        public void FarmerKYCDetailsSave(MFPkYCDetails objKyc, string orgnId, string locnId, string userId, string localeId, string farmer_code, string mysqlcon)
        {
            string response = "";
            try
            {
                MysqlCon.con.Open();
                MySqlCommand cmd = new MySqlCommand("FDRMOB_iud_farmer_kyc", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("in_farmer_code", MySqlDbType.VarChar).Value =farmer_code;               
                cmd.Parameters.Add("in_farmerkyc_rowid", MySqlDbType.Int32).Value = objKyc.in_farmerkyc_rowid;
                cmd.Parameters.Add("in_proof_type", MySqlDbType.VarChar).Value = objKyc.in_proof_type;
                cmd.Parameters.Add("in_proof_doc", MySqlDbType.VarChar).Value = objKyc.in_proof_doc;
                cmd.Parameters.Add("in_proof_doc_no", MySqlDbType.VarChar).Value = objKyc.in_proof_doc_no;
                cmd.Parameters.Add("in_proof_doc_adharno", MySqlDbType.VarChar).Value = objKyc.in_proof_doc_adharno;
                cmd.Parameters.Add("in_proof_valid_till", MySqlDbType.VarChar).Value = objKyc.in_proof_valid_till;
                cmd.Parameters.Add("in_photo_kyc", MySqlDbType.LongText).Value = objKyc.in_photo_kyc;
                cmd.Parameters.Add("in_status_code", MySqlDbType.VarChar).Value = objKyc.in_status_code;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = objKyc.in_mode_flag;
                cmd.Parameters.Add("created_by", MySqlDbType.VarChar).Value = userId;
                cmd.Parameters.Add("modified_by", MySqlDbType.VarChar).Value = userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = localeId;
                cmd.Parameters.Add(new MySqlParameter("in_farmerkyc_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                response = (string)cmd.Parameters["errorNo"].Value;
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
        public void FarmerAddressDetailsSave(MFPAdderssDetails objFamerAddress, string orgnId, string locnId, string userId, string localeId, string farmer_code, string mysqlcon)
        {
            string response = "";
            try
            {
                MysqlCon.con.Open();
                MySqlCommand cmd = new MySqlCommand("FDRMOB_iud_farmer_pofile_save", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("farmer_code", MySqlDbType.VarChar).Value = farmer_code;
                cmd.Parameters.Add("version_no",  MySqlDbType.Int32).Value = 1;
                cmd.Parameters.Add("farmerdetail_rowid",MySqlDbType.Int32).Value = objFamerAddress.in_farmerdetail_rowid;
                cmd.Parameters.Add("entitygrp_code",MySqlDbType.VarChar).Value = objFamerAddress.in_entitygrp_code;
                cmd.Parameters.Add("entity_code", MySqlDbType.VarChar).Value = objFamerAddress.in_entity_code;
                cmd.Parameters.Add("row_slno",  MySqlDbType.Int32).Value = Convert.ToInt32(objFamerAddress.in_row_slno);
                cmd.Parameters.Add("entity_value",MySqlDbType.VarChar).Value = objFamerAddress.in_entity_value;
                cmd.Parameters.Add("ownedpicture", MySqlDbType.LongText).Value = objFamerAddress.in_owned_picture;
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
