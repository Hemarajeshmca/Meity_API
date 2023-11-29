using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
    public class Mobile_FDR_FHeader_DB
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Mobile_FDR_FHeader_DB));
        public MFHDocument SaveNewMobileFarmerHeader_DB(MFHApplication ObjFarmer, string mysqlcon)
        {
            int ret = 0;
            MysqlCon = new DataConnection(mysqlcon);
            MFHDocument objProcessDoc = new MFHDocument();
            objProcessDoc.context = new MFHContext();
            objProcessDoc.context.Header = new MFHHeader();
            objProcessDoc.ApplicationException = new MFHApplicationException();
            string in_farmer_rowid1 = "";
            string in_farmer_code1 = "";
            string in_version_no1 = "";
            try
            {
                string date1 = ObjFarmer.document.context.Header.in_farmer_dob;
                ///  2021/03/02
                ///  02/03/2021
                logger.Debug("Receiveing Date Format :" + ObjFarmer.document.context.Header.in_farmer_dob);
                int dd = Convert.ToInt32(date1.Split("/")[0].Length == 4 ? date1.Split("/")[2] : date1.Split("/")[0]);
                int mm = Convert.ToInt32(date1.Split("/")[1]);
                int yy = Convert.ToInt32(date1.Split("/")[0].Length == 4 ? date1.Split("/")[0] : date1.Split("/")[2]); // Convert.ToInt32(date1.Split("/")[2]);
                logger.Debug("Date: " + dd + " Month: " + mm + " Year: " + yy);
                DateTime dttest = new DateTime(yy, mm, dd);
                logger.Debug("Converting DOB Format 2 :" + dttest.ToString());
                // DateTime dt = Convert.ToDateTime(date1);
                //string[] dtsplit =
                string dob = dttest.ToString("yyyy-MM-dd");
                //dob = dob.Replace();
                logger.Debug("Converting DOB Format 2: " + dob);
                MySqlCommand cmd = new MySqlCommand("FDRMOB_insupd_farmer_registration", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("in_farmer_rowid", MySqlDbType.Int32).Value = ObjFarmer.document.context.Header.in_farmer_rowid;
                cmd.Parameters.Add("in_farmer_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_code;
                cmd.Parameters.Add("in_version_no", MySqlDbType.Int32).Value = ObjFarmer.document.context.Header.in_version_no;
                cmd.Parameters.Add("in_fpo_orgncode", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_fpo_orgncode;
                cmd.Parameters.Add("in_photo_farmer", MySqlDbType.LongText).Value = ObjFarmer.document.context.Header.in_photo_farmer;
                cmd.Parameters.Add("in_farmer_name", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_name;
                cmd.Parameters.Add("in_sur_name", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_sur_name;
                cmd.Parameters.Add("in_fhw_name", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_fhw_name;
                cmd.Parameters.Add("in_farmer_dob", MySqlDbType.VarChar).Value = dob;
                cmd.Parameters.Add("in_farmer_addr1", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_addr1;
                cmd.Parameters.Add("in_farmer_addr2", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_addr2;
                cmd.Parameters.Add("in_farmer_country", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_country;
                cmd.Parameters.Add("in_farmer_state", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_state;
                cmd.Parameters.Add("in_farmer_dist", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_dist;
                cmd.Parameters.Add("in_farmer_taluk", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_taluk;
                cmd.Parameters.Add("in_farmer_panchayat", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_panchayat;
                cmd.Parameters.Add("in_farmer_village", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_village;
                cmd.Parameters.Add("in_farmer_pincode", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_pincode;
                cmd.Parameters.Add("in_marital_status", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_marital_status;
                cmd.Parameters.Add("in_gender_flag", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_gender_flag;
                cmd.Parameters.Add("in_reg_mobile_no", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_reg_mobile_no;
                cmd.Parameters.Add("in_status_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_status_code;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_mode_flag;
                cmd.Parameters.Add("in_row_timestamp", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_row_timestamp;
                cmd.Parameters.Add("created_by", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_created_by;
                cmd.Parameters.Add("Aadhar_no", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.Aadhar_no; //live changes field visit on April 17th
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.localeId;
                cmd.Parameters.Add("DupFlag", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_dup_flag;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_rowid1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_version_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                ret = cmd.ExecuteNonQuery();
                MysqlCon.con.Close();
                if (ret > 0 && (string)cmd.Parameters["errorNo"].Value== "")
                {
                    in_farmer_rowid1 = (string)cmd.Parameters["in_farmer_rowid1"].Value;
                    in_farmer_code1 = (string)cmd.Parameters["in_farmer_code1"].Value;
                    in_version_no1 = (string)cmd.Parameters["in_version_no1"].Value;

                    objProcessDoc.context.Header.in_farmer_rowid = Convert.ToInt32(in_farmer_rowid1);
                    objProcessDoc.context.Header.in_farmer_code = in_farmer_code1;
                    objProcessDoc.context.Header.in_version_no = Convert.ToInt32(in_version_no1);
                }
                else
                {
                    objProcessDoc.ApplicationException.errorNumber = (string)cmd.Parameters["errorNo"].Value;
                    objProcessDoc.ApplicationException.errorDescription = ObjErrormsg.ErrorMessage((string)cmd.Parameters["errorNo"].Value);
                }
            }
            catch (Exception ex)
            {
                logger.Debug(ex.ToString());
                throw ex;
            }
            return objProcessDoc;
        }

        public MFKDocument SaveNewMobileFarmerkyc_DB(MFKApplication ObjFarmer, string mysqlcon)
        {
            int ret = 0;
            MysqlCon = new DataConnection(mysqlcon);
            MFKDocument objProcessDoc = new MFKDocument();
            objProcessDoc.context = new MFKContext();
            objProcessDoc.context.KYC = new MFKKYC();
            objProcessDoc.ApplicationException = new MFKApplicationException();

            try
            {
                MySqlCommand cmd = new MySqlCommand("FDRMOB_iud_farmer_kyc", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("in_farmer_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.KYC.in_farmer_code;
                cmd.Parameters.Add("in_farmerkyc_rowid", MySqlDbType.Int32).Value = ObjFarmer.document.context.KYC.in_farmerkyc_rowid;
                cmd.Parameters.Add("in_proof_type", MySqlDbType.LongText).Value = ObjFarmer.document.context.KYC.in_proof_type;
                cmd.Parameters.Add("in_proof_doc", MySqlDbType.VarChar).Value = ObjFarmer.document.context.KYC.in_proof_doc;
                cmd.Parameters.Add("in_proof_doc_no", MySqlDbType.VarChar).Value = ObjFarmer.document.context.KYC.in_proof_doc_no;
                cmd.Parameters.Add("in_proof_doc_adharno", MySqlDbType.VarChar).Value = ObjFarmer.document.context.KYC.in_proof_doc_adharno;
                cmd.Parameters.Add("in_proof_valid_till", MySqlDbType.VarChar).Value = ObjFarmer.document.context.KYC.in_proof_valid_till;
                cmd.Parameters.Add("in_photo_kyc", MySqlDbType.LongText).Value = ObjFarmer.document.context.KYC.in_photo_kyc;
                cmd.Parameters.Add("in_status_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.KYC.in_status_code;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = ObjFarmer.document.context.KYC.in_mode_flag;
                cmd.Parameters.Add("created_by", MySqlDbType.VarChar).Value = ObjFarmer.document.context.KYC.in_created_by;
                cmd.Parameters.Add("modified_by", MySqlDbType.VarChar).Value = ObjFarmer.document.context.KYC.in_modified_by;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("in_farmerkyc_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                ret = cmd.ExecuteNonQuery();
                MysqlCon.con.Close();
                if (ret > 0)
                {
                    objProcessDoc.context.KYC.in_farmerkyc_rowid = (Int32)cmd.Parameters["in_farmerkyc_rowid1"].Value;
                }
                else
                {
                    objProcessDoc.ApplicationException.errorNumber = (string)cmd.Parameters["errorNo"].Value;
                    objProcessDoc.ApplicationException.errorDescription = (string)cmd.Parameters["errorNo"].Value;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objProcessDoc;
        }
        public MFBDocument SaveNewMobileFarmerBank_DB(MFBApplication ObjFarmer, string mysqlcon)
        {
            int ret = 0;
            MysqlCon = new DataConnection(mysqlcon);
            MFBDocument objProcessDoc = new MFBDocument();
            objProcessDoc.context = new MFBContext();
            objProcessDoc.context.Bank = new MFBBank();
            objProcessDoc.ApplicationException = new MFBApplicationException();
            try
            {
                MySqlCommand cmd = new MySqlCommand("FDRMOB_iud_farmerbank", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("in_farmer_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Bank.in_farmer_code;

                cmd.Parameters.Add("in_farmerbank_rowid", MySqlDbType.Int32).Value = ObjFarmer.document.context.Bank.in_farmerbank_rowid;
                cmd.Parameters.Add("in_bank_acc_no", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Bank.in_bank_acc_no;
                cmd.Parameters.Add("in_bank_acc_type", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Bank.in_bank_acc_type;
                cmd.Parameters.Add("in_bank_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Bank.in_bank_code;
                cmd.Parameters.Add("in_branch_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Bank.in_branch_code;
                cmd.Parameters.Add("in_ifsc_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Bank.in_ifsc_code;
                cmd.Parameters.Add("in_dflt_dr_acc", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Bank.in_dflt_dr_acc;
                cmd.Parameters.Add("in_dflt_cr_acc", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Bank.in_dflt_cr_acc;
                cmd.Parameters.Add("in_status_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Bank.in_status_code;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Bank.in_mode_flag;
                cmd.Parameters.Add("created_by", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Bank.in_created_by;
                cmd.Parameters.Add("modified_by", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Bank.in_modified_by;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("in_farmerbank_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                ret = cmd.ExecuteNonQuery();
                MysqlCon.con.Close();
                if (ret > 0)
                {
                    objProcessDoc.context.Bank.in_farmerbank_rowid = (Int32)cmd.Parameters["in_farmerbank_rowid1"].Value;
                }
                else
                {
                    objProcessDoc.ApplicationException.errorNumber = (string)cmd.Parameters["errorNo"].Value;
                    objProcessDoc.ApplicationException.errorDescription = (string)cmd.Parameters["errorNo"].Value;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objProcessDoc;
        }
    }
}