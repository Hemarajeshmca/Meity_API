using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
    public class Mobile_FDR_FList_DB
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Mobile_FDR_FList_DB)); //Declaring Log4Net. 
        public FDRFarmerRootObject GetAllFarmerList_DB(FDRFarmerContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();

            FDRFarmerRootObject objinvoiceRoot = new FDRFarmerRootObject();
            Mobile_FDR_Datamodel objDataModel = new Mobile_FDR_Datamodel();

            objinvoiceRoot.context = new FDRFarmerContext();
            objinvoiceRoot.context.List = new List<FDRFarmerList>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("FDRMOB_fetch_farmer_reg_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_filterby_option", MySqlDbType.VarChar).Value = objinvoice.FilterBy_Option;
                cmd.Parameters.Add("In_filterby_code", MySqlDbType.VarChar).Value = objinvoice.FilterBy_Code;
                cmd.Parameters.Add("In_filterby_fromvalue", MySqlDbType.VarChar).Value = objinvoice.FilterBy_FromValue;
                cmd.Parameters.Add("In_filterby_tovalue", MySqlDbType.VarChar).Value = objinvoice.FilterBy_ToValue;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FDRFarmerList objList = new FDRFarmerList();
                    objList.farmer_rowid = Convert.ToInt32(dt.Rows[i]["farmer_rowid"]);
                    objList.farmer_code = dt.Rows[i]["farmer_code"].ToString();
                    objList.farmer_name = dt.Rows[i]["farmer_name"].ToString();
                    objList.farmer = dt.Rows[i]["farmer"].ToString();
                    objList.father_name = dt.Rows[i]["father_name"].ToString();
                    objList.farmer_state = dt.Rows[i]["farmer_state"].ToString();
                    objList.farmer_state_desc = dt.Rows[i]["farmer_state_desc"].ToString();
                    objList.farmer_dist = dt.Rows[i]["farmer_dist"].ToString();
                    objList.farmer_dist_desc = dt.Rows[i]["farmer_dist_desc"].ToString();
                    objList.farmer_taluk = dt.Rows[i]["farmer_taluk"].ToString();
                    objList.farmer_taluk_desc = dt.Rows[i]["farmer_taluk_desc"].ToString();
                    objList.farmer_panchayat = dt.Rows[i]["farmer_panchayat"].ToString();
                    objList.farmer_panchayat_desc = dt.Rows[i]["farmer_panchayat_desc"].ToString();
                    objList.farmer_village = dt.Rows[i]["farmer_village"].ToString();
                    objList.farmer_village_desc = dt.Rows[i]["farmer_village_desc"].ToString();
                    objList.Contact_No = dt.Rows[i]["Contact_No"].ToString();
                    objList.farmer_surname = dt.Rows[i]["sur_name"].ToString();
                    objList.farmer_dob = dt.Rows[i]["farmer_dob"].ToString();
                    objList.ic_code = dt.Rows[i]["ic_code"].ToString();
                    objList.verified_flag = dt.Rows[i]["verified_flag"].ToString();
                    objList.fpoorgn_code = dt.Rows[i]["fpoorgn_code"].ToString();
                    objList.fpomember_code = dt.Rows[i]["fpomember_code"].ToString();
                    objinvoiceRoot.context.List.Add(objList);

                }
                objinvoiceRoot.context.orgnId = objinvoice.orgnId;
                objinvoiceRoot.context.locnId = objinvoice.locnId;
                objinvoiceRoot.context.localeId = objinvoice.localeId;
                objinvoiceRoot.context.userId = objinvoice.userId;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }
        public FDRRootObject GetmobFarmerSinglefetch_DB(FDRContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();

            MysqlCon = new DataConnection(mysqlcon);

            FDRRootObject ObjFarmerRoot = new FDRRootObject();
            Mobile_FDR_FList_DB objDataModel = new Mobile_FDR_FList_DB();

            DataTable kycdt1 = new DataTable();
            DataTable Bankdt1 = new DataTable();
            DataTable Header1 = new DataTable();

            ObjFarmerRoot.context = new FDRContext();
            ObjFarmerRoot.context.header = new FDRHeader();
            ObjFarmerRoot.context.bank = new List<FDRBank>();
            ObjFarmerRoot.context.kyc = new List<FDRKyc>();

            try
            {

                MySqlCommand cmd = new MySqlCommand("FDRMOB_fetch_farmer_reg", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("in_farmer_rowid", MySqlDbType.Int32).Value = ObjContext.header.in_farmer_rowid;
                cmd.Parameters.Add("in_farmer_code", MySqlDbType.VarChar).Value = ObjContext.header.in_farmer_code;

                cmd.Parameters.Add(new MySqlParameter("in_farmer_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_version_no1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_photo_farmer", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_sur_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_fhw_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_dob", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_addr1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_addr2", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_ll_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_sur_ll_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_fhw_ll_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_ll_addr1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_ll_addr2", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_country", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_country_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_country_ll_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_state", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_state_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_state_ll_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_dist", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_dist_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_dist_ll_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_taluk", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_taluk_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_taluk_ll_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_panchayat", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_panchayat_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_panchayat_ll_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_village", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_village_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_village_ll_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_pincode", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_pincode_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_marital_status", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_marital_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_gender_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_gender_flag_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_reg_mobile_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_reg_note", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("Aadhar_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();

                if (ds.Tables.Count > 0)
                {
                    Bankdt1 = ds.Tables[0];
                    kycdt1 = ds.Tables[1];


                    for (int i = 0; i < Bankdt1.Rows.Count; i++)
                    {
                        FDRBank objBankList = new FDRBank();
                        objBankList.in_farmerbank_rowid = Convert.ToInt32(Bankdt1.Rows[i]["in_farmerbank_rowid"]);
                        objBankList.in_bank_acc_no = Bankdt1.Rows[i]["in_bank_acc_no"].ToString();
                        objBankList.in_bank_acc_type = Bankdt1.Rows[i]["in_bank_acc_type"].ToString();
                        objBankList.in_bank_acc_type_desc = Bankdt1.Rows[i]["in_bank_acc_type_desc"].ToString();
                        objBankList.in_bank_code = Bankdt1.Rows[i]["in_bank_code"].ToString();
                        objBankList.in_bank_desc = Bankdt1.Rows[i]["in_bank_desc"].ToString();
                        objBankList.in_branch_code = Bankdt1.Rows[i]["in_branch_code"].ToString();
                        objBankList.in_branch_desc = Bankdt1.Rows[i]["in_branch_desc"].ToString();
                        objBankList.in_ifsc_code = Bankdt1.Rows[i]["in_ifsc_code"].ToString();
                        objBankList.in_dflt_dr_acc = Bankdt1.Rows[i]["in_dflt_dr_acc"].ToString();
                        objBankList.in_dflt_dr_acc_desc = Bankdt1.Rows[i]["in_dflt_dr_acc_desc"].ToString();
                        objBankList.in_dflt_cr_acc = Bankdt1.Rows[i]["in_dflt_cr_acc"].ToString();
                        objBankList.in_dflt_cr_acc_desc = Bankdt1.Rows[i]["in_dflt_cr_acc_desc"].ToString();
                        objBankList.in_status_code = Bankdt1.Rows[i]["in_status_code"].ToString();
                        objBankList.in_status_desc = Bankdt1.Rows[i]["in_status_desc"].ToString();
                        objBankList.in_mode_flag = Bankdt1.Rows[i]["in_mode_flag"].ToString();

                        ObjFarmerRoot.context.bank.Add(objBankList);
                    }
                    for (int i = 0; i < kycdt1.Rows.Count; i++)
                    {
                        FDRKyc objKycList = new FDRKyc();
                        objKycList.in_farmerkyc_rowid = Convert.ToInt32(kycdt1.Rows[i]["in_farmerkyc_rowid"]);
                        objKycList.in_proof_type = kycdt1.Rows[i]["in_proof_type"].ToString();
                        objKycList.in_proof_type_desc = kycdt1.Rows[i]["in_proof_type_desc"].ToString();
                        objKycList.in_proof_doc = kycdt1.Rows[i]["in_proof_doc"].ToString();
                        objKycList.in_proof_doc_desc = kycdt1.Rows[i]["in_proof_doc_desc"].ToString();
                        objKycList.in_proof_doc_no = kycdt1.Rows[i]["in_proof_doc_no"].ToString();
                        objKycList.in_proof_doc_adharno = kycdt1.Rows[i]["in_proof_doc_adharno"].ToString();
                        objKycList.in_proof_valid_till = kycdt1.Rows[i]["in_proof_valid_till"].ToString();
                        objKycList.in_photo_kyc = kycdt1.Rows[i]["in_photo_kyc"].ToString();
                        objKycList.in_status_code = kycdt1.Rows[i]["in_status_code"].ToString();
                        objKycList.in_status_desc = kycdt1.Rows[i]["in_status_desc"].ToString();
                        objKycList.in_mode_flag = kycdt1.Rows[i]["in_mode_flag"].ToString();

                        ObjFarmerRoot.context.kyc.Add(objKycList);
                    }

                }
                ObjFarmerRoot.context.orgnId = ObjContext.orgnId;
                ObjFarmerRoot.context.locnId = ObjContext.locnId;
                ObjFarmerRoot.context.userId = ObjContext.userId;
                ObjFarmerRoot.context.localeId = ObjContext.localeId;

                ObjFarmerRoot.context.header.in_farmer_rowid = (Int32)cmd.Parameters["in_farmer_rowid1"].Value;
                ObjFarmerRoot.context.header.in_farmer_code = (string)cmd.Parameters["in_farmer_code1"].Value.ToString();
                ObjFarmerRoot.context.header.in_version_no = (Int32)cmd.Parameters["in_version_no1"].Value;
                ObjFarmerRoot.context.header.in_photo_farmer = (string)cmd.Parameters["in_photo_farmer"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_name = (string)cmd.Parameters["in_farmer_name"].Value.ToString();
                ObjFarmerRoot.context.header.in_sur_name = (string)cmd.Parameters["in_sur_name"].Value.ToString();
                ObjFarmerRoot.context.header.in_fhw_name = (string)cmd.Parameters["in_fhw_name"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_dob = (string)cmd.Parameters["in_farmer_dob"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_addr1 = (string)cmd.Parameters["in_farmer_addr1"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_addr2 = (string)cmd.Parameters["in_farmer_addr2"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_ll_name = (string)cmd.Parameters["in_farmer_ll_name"].Value.ToString();
                ObjFarmerRoot.context.header.in_sur_ll_name = (string)cmd.Parameters["in_sur_ll_name"].Value.ToString();
                ObjFarmerRoot.context.header.in_fhw_ll_name = (string)cmd.Parameters["in_fhw_ll_name"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_ll_addr1 = (string)cmd.Parameters["in_farmer_ll_addr1"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_ll_addr2 = (string)cmd.Parameters["in_farmer_ll_addr2"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_country = (string)cmd.Parameters["in_farmer_country"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_country_desc = (string)cmd.Parameters["in_farmer_country_desc"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_country_ll_desc = (string)cmd.Parameters["in_farmer_country_ll_desc"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_state = (string)cmd.Parameters["in_farmer_state"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_state_desc = (string)cmd.Parameters["in_farmer_state_desc"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_state_ll_desc = (string)cmd.Parameters["in_farmer_state_ll_desc"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_dist = (string)cmd.Parameters["in_farmer_dist"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_dist_desc = (string)cmd.Parameters["in_farmer_dist_desc"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_dist_ll_desc = (string)cmd.Parameters["in_farmer_dist_ll_desc"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_taluk = (string)cmd.Parameters["in_farmer_taluk"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_taluk_desc = (string)cmd.Parameters["in_farmer_taluk_desc"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_taluk_ll_desc = (string)cmd.Parameters["in_farmer_taluk_ll_desc"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_panchayat = (string)cmd.Parameters["in_farmer_panchayat"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_panchayat_desc = (string)cmd.Parameters["in_farmer_panchayat_desc"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_panchayat_ll_desc = (string)cmd.Parameters["in_farmer_panchayat_ll_desc"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_village = (string)cmd.Parameters["in_farmer_village"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_village_desc = (string)cmd.Parameters["in_farmer_village_desc"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_village_ll_desc = (string)cmd.Parameters["in_farmer_village_ll_desc"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_pincode = (string)cmd.Parameters["in_farmer_pincode"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_pincode_desc = (string)cmd.Parameters["in_farmer_pincode_desc"].Value.ToString();
                ObjFarmerRoot.context.header.in_marital_status = (string)cmd.Parameters["in_marital_status"].Value.ToString();
                ObjFarmerRoot.context.header.in_marital_status_desc = (string)cmd.Parameters["in_marital_status_desc"].Value.ToString();
                ObjFarmerRoot.context.header.in_gender_flag = (string)cmd.Parameters["in_gender_flag"].Value.ToString();
                ObjFarmerRoot.context.header.in_gender_flag_desc = (string)cmd.Parameters["in_gender_flag_desc"].Value.ToString();
                ObjFarmerRoot.context.header.in_reg_mobile_no = (string)cmd.Parameters["in_reg_mobile_no"].Value.ToString();
                ObjFarmerRoot.context.header.in_reg_note = (string)cmd.Parameters["in_reg_note"].Value.ToString();
                ObjFarmerRoot.context.header.in_status_code = (string)cmd.Parameters["in_status_code"].Value.ToString();
                ObjFarmerRoot.context.header.in_status_desc = (string)cmd.Parameters["in_status_desc"].Value.ToString();
                ObjFarmerRoot.context.header.in_mode_flag = (string)cmd.Parameters["in_mode_flag"].Value.ToString();
                ObjFarmerRoot.context.header.in_row_timestamp = (string)cmd.Parameters["in_row_timestamp"].Value.ToString();
                ObjFarmerRoot.context.header.Aadhar_no = (string)cmd.Parameters["Aadhar_no"].Value.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFarmerRoot;
        }


    }
}

