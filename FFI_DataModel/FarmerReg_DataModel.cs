using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FFI_Model;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Reflection;

namespace FFI_DataModel
{
    public class FarmerReg_DataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FarmerReg_DataModel)); //Declaring Log4Net. 
        string methodName = "";
        public SFarmerDocument SaveFarmerNew(SFarmerRootObject ObjFarmer, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            int ret = 0;

            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            SFarmerDocument objresFarmer = new SFarmerDocument();
            objresFarmer.context = new SFarmerContext();
            objresFarmer.context.Header = new SFarmerHeaderSegment();
            objresFarmer.ApplicationException = new FFI_Model.ApplicationException();
            string in_farmer_rowid1 = "";
            string in_farmer_code1 = "";
            string in_version_no1 = "";
            string errorNo = "";
            string errorMsg = "";
            try
            {

                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                //string[] returnvalues = { };
                MySqlCommand cmd = new MySqlCommand("FDR_insupd_farmer_registration", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("in_farmer_rowid", MySqlDbType.Int32).Value = ObjFarmer.document.context.Header.in_farmer_rowid;
                cmd.Parameters.Add("in_farmer_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_code;
                cmd.Parameters.Add("in_version_no", MySqlDbType.Int32).Value = ObjFarmer.document.context.Header.in_version_no;

                cmd.Parameters.Add("in_fpo_orgncode", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_fpo_orgncode;
                cmd.Parameters.Add("in_photo_farmer", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_photo_farmer;
                cmd.Parameters.Add("in_farmer_name", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_name;
                cmd.Parameters.Add("in_sur_name", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_sur_name;
                cmd.Parameters.Add("in_fhw_name", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_fhw_name;
                cmd.Parameters.Add("in_farmer_dob", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_dob;
                cmd.Parameters.Add("in_farmer_addr1", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_addr1;
                cmd.Parameters.Add("in_farmer_addr2", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_addr2;
                cmd.Parameters.Add("in_farmer_ll_name", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_ll_name;
                cmd.Parameters.Add("in_sur_ll_name", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_sur_ll_name;
                cmd.Parameters.Add("in_fhw_ll_name", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_fhw_ll_name;
                cmd.Parameters.Add("in_farmer_ll_addr1", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_ll_addr1;
                cmd.Parameters.Add("in_farmer_ll_addr2", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_farmer_ll_addr2;
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
                cmd.Parameters.Add("in_reg_note", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_reg_note;
                cmd.Parameters.Add("in_status_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_status_code;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_mode_flag;
                cmd.Parameters.Add("in_row_timestamp", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_row_timestamp;
                cmd.Parameters.Add("Aadhar_no", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.Aadhar_no; //live changes field visit on April 17th
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.localeId;
                cmd.Parameters.Add("DupFlag", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.in_dup_flag;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_rowid1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                // cmd.Parameters["in_farmer_rowid1"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_version_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                errorNo = (string)cmd.Parameters["errorNo"].Value;
                if (ret > 0 && errorNo == "") //Sanjay Field visit changes on April 12
                {
                    in_farmer_rowid1 = (string)cmd.Parameters["in_farmer_rowid1"].Value;
                    in_farmer_code1 = (string)cmd.Parameters["in_farmer_code1"].Value;
                    in_version_no1 = (string)cmd.Parameters["in_version_no1"].Value;
                   
                    objresFarmer.context.Header.in_farmer_rowid = Convert.ToInt32(in_farmer_rowid1);
                    objresFarmer.context.Header.in_farmer_code = in_farmer_code1;
                    objresFarmer.context.Header.in_version_no = Convert.ToInt32(in_version_no1);
                }
                else
                {                                             
                    errorNo = (string)cmd.Parameters["errorNo"].Value;//Sanjay Field visit changes on April 12
                    errorMsg = ObjErrormsg.ErrorMessage(errorNo);
                    objresFarmer.ApplicationException.errorNumber = (string)cmd.Parameters["errorNo"].Value;
                    objresFarmer.ApplicationException.errorDescription = errorNo; //ramya modified on 10 jun 21
                    //errorNo = (string)cmd.Parameters["errorNo"].Value;
                }
                if (objresFarmer.context.Header.in_farmer_rowid > 0)
                {
                    string[] resultkyc = { };
                    string[] resultbank = { };
                    resultkyc = SaveFarmerKyc(ObjFarmer, objresFarmer, mysqlcon, MysqlCon);
                    if (resultkyc[0].Contains("060"))
                    {
                        mysqltrans.Rollback();
                        objresFarmer.ApplicationException.errorNumber = resultkyc[0].ToString();
                        objresFarmer.ApplicationException.errorDescription = resultkyc[1].ToString();
                        return objresFarmer;
                    }
                    else
                    {
                        resultbank = SaveFarmerBank(ObjFarmer, objresFarmer, mysqlcon, MysqlCon);
                        if (resultbank[0].Contains("060"))
                        {
                            mysqltrans.Rollback();
                            objresFarmer.ApplicationException.errorNumber = resultkyc[0].ToString();
                            objresFarmer.ApplicationException.errorDescription = resultkyc[1].ToString();
                            return objresFarmer;
                        }
                    }
                }
                string[] returnvalues = { in_farmer_rowid1, in_farmer_code1, in_version_no1, errorNo };

                mysqltrans.Commit();
                return objresFarmer;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                logger.Error("USERNAME :" + objresFarmer.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objresFarmer;
        }

        public string[] SaveFarmerKyc(SFarmerRootObject Objmodel, SFarmerDocument objfarmer, string MysqlCons, DataConnection MysqlCon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            string[] result = { };
            //string[] resultkyc = { };
            string errorNo = "";
            string errorMsg = "";
            DataTable tab = new DataTable();
            SFarmerKycSegment objkycdtl = new SFarmerKycSegment();
            //try
            //{
                FarmerReg_DataModel objproduct1 = new FarmerReg_DataModel();
                foreach (var Kyc in Objmodel.document.context.KYC)
                {
                    objkycdtl.in_farmerkyc_rowid = Kyc.in_farmerkyc_rowid;
                    objkycdtl.in_proof_type = Kyc.in_proof_type;
                    objkycdtl.in_proof_doc = Kyc.in_proof_doc;
                    objkycdtl.in_proof_doc_no = Kyc.in_proof_doc_no;
                    objkycdtl.in_proof_doc_adharno = Kyc.in_proof_doc_adharno;
                    objkycdtl.in_proof_valid_till = Kyc.in_proof_valid_till;
                    objkycdtl.in_status_code = Kyc.in_status_code;
                    objkycdtl.in_mode_flag = Kyc.in_mode_flag;
                    result = objproduct1.SaveFarmerKycNew(objkycdtl, objfarmer, Objmodel, MysqlCons, MysqlCon);

                    if (result[0].Contains("060"))
                    {
                        errorNo = result[0].ToString();
                        errorMsg = result[1].ToString();
                        //resultkyc[0] = errorNo;
                        //resultkyc[1] = errorMsg;
                        break;
                    }
                }
                string[] resultkyc = { errorNo, errorMsg };
                //resultkyc[0] = errorNo;
                //resultkyc[1] = errorMsg;
            //}
            //catch (Exception ex)
            //{
            //    logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            //}
            return resultkyc;
        }

        public string[] SaveFarmerKycNew(SFarmerKycSegment ObjKycDtl, SFarmerDocument ObjFarmer, SFarmerRootObject Objmodel, string mysqlcons, DataConnection MysqlCon)
        {
            //string[] result = { };
            methodName = MethodBase.GetCurrentMethod().Name;
            string errorNo = "";
            string errorMsg = "";
            int ret = 0;
            //try
            //{
                MySqlCommand cmd = new MySqlCommand("FDR_iud_farmer_kyc", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("in_farmer_code", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.in_farmer_code;
                cmd.Parameters.Add("in_version_no", MySqlDbType.Int32).Value = ObjFarmer.context.Header.in_version_no;
                cmd.Parameters.Add("in_farmerkyc_rowid", MySqlDbType.Int32).Value = ObjKycDtl.in_farmerkyc_rowid;
                cmd.Parameters.Add("in_proof_type", MySqlDbType.VarChar).Value = ObjKycDtl.in_proof_type;
                cmd.Parameters.Add("in_proof_doc", MySqlDbType.VarChar).Value = ObjKycDtl.in_proof_doc;
                cmd.Parameters.Add("in_proof_doc_no", MySqlDbType.VarChar).Value = ObjKycDtl.in_proof_doc_no;
                cmd.Parameters.Add("in_proof_doc_adharno", MySqlDbType.VarChar).Value = ObjKycDtl.in_proof_doc_adharno;
                cmd.Parameters.Add("in_proof_valid_till", MySqlDbType.VarChar).Value = ObjKycDtl.in_proof_valid_till;
                cmd.Parameters.Add("in_status_code", MySqlDbType.VarChar).Value = ObjKycDtl.in_status_code;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = ObjKycDtl.in_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                if (ret == 0)
                {
                    errorNo = (string)cmd.Parameters["errorNo"].Value;
                    errorMsg = ObjErrormsg.ErrorMessage(errorNo);
                    //result[0] = errorNo;
                    //result[1] = errorMsg;
                }
                string[] result = { errorNo, errorMsg };
                
            //}
            //catch (Exception ex)
            //{
            //    logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            //}
            return result;
        }

        public string[] SaveFarmerBank(SFarmerRootObject Objmodel, SFarmerDocument objfarmer, string MySqlCons, DataConnection MySqlCon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            string[] result = { };
            //string[] resultbank = { };
            string errorNo = "";
            string errorMsg = "";
            DataTable tab = new DataTable();
            SFarmerBankSegment objBankdtl = new SFarmerBankSegment();
            //try
            //{
                FarmerReg_DataModel objproduct1 = new FarmerReg_DataModel();
                foreach (var BankDtl in Objmodel.document.context.Bank)
                {
                    objBankdtl.in_farmerbank_rowid = BankDtl.in_farmerbank_rowid;
                    objBankdtl.in_bank_acc_no = BankDtl.in_bank_acc_no;
                    objBankdtl.in_bank_acc_type = BankDtl.in_bank_acc_type;
                    objBankdtl.in_bank_code = BankDtl.in_bank_code;
                    objBankdtl.in_branch_code = BankDtl.in_branch_code;
                    objBankdtl.in_ifsc_code = BankDtl.in_ifsc_code;
                    objBankdtl.in_dflt_dr_acc = BankDtl.in_dflt_dr_acc;
                    objBankdtl.in_dflt_cr_acc = BankDtl.in_dflt_cr_acc;
                    objBankdtl.in_status_code = BankDtl.in_status_code;
                    objBankdtl.in_mode_flag = BankDtl.in_mode_flag;
                    result = objproduct1.SaveFarmerBankRegNew(objBankdtl, objfarmer, Objmodel, MySqlCons, MySqlCon);
                    if (result[0].Contains("060"))
                    {
                        errorNo = result[0].ToString();
                        errorMsg = result[1].ToString();
                        break;
                    }
                }
                string[] resultbank = { errorNo, errorMsg };
                //resultbank[0] = errorNo;
                //resultbank[1] = errorMsg;
            //}
            //catch (Exception ex)
            //{
            //    logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            //}
            return resultbank;
        }

        public string[] SaveFarmerBankRegNew(SFarmerBankSegment ObjBank, SFarmerDocument ObjFarmer, SFarmerRootObject Objmodel, string mysqlcons, DataConnection MysqlCon)
        {
            //string[] result = new string[2];
            methodName = MethodBase.GetCurrentMethod().Name;
            string errorNo = "";
            string errorMsg = "";
            int ret = 0;
            //try
            //{
                MySqlCommand cmd = new MySqlCommand("FDR_iud_farmerbank", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("in_farmer_code", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.in_farmer_code;
                cmd.Parameters.Add("in_version_no", MySqlDbType.Int32).Value = ObjFarmer.context.Header.in_version_no;
                cmd.Parameters.Add("in_farmerbank_rowid", MySqlDbType.Int32).Value = ObjBank.in_farmerbank_rowid;
                cmd.Parameters.Add("in_bank_acc_no", MySqlDbType.VarChar).Value = ObjBank.in_bank_acc_no;
                cmd.Parameters.Add("in_bank_acc_type", MySqlDbType.VarChar).Value = ObjBank.in_bank_acc_type;
                cmd.Parameters.Add("in_bank_code", MySqlDbType.VarChar).Value = ObjBank.in_bank_code;
                cmd.Parameters.Add("in_branch_code", MySqlDbType.VarChar).Value = ObjBank.in_branch_code;
                cmd.Parameters.Add("in_ifsc_code", MySqlDbType.VarChar).Value = ObjBank.in_ifsc_code;
                cmd.Parameters.Add("in_dflt_dr_acc", MySqlDbType.VarChar).Value = ObjBank.in_dflt_dr_acc;
                cmd.Parameters.Add("in_dflt_cr_acc", MySqlDbType.VarChar).Value = ObjBank.in_dflt_cr_acc;
                cmd.Parameters.Add("in_status_code", MySqlDbType.VarChar).Value = ObjBank.in_status_code;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = ObjBank.in_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                if (ret == 0)
                {
                    errorNo = (string)cmd.Parameters["errorNo"].Value;
                    errorMsg = ObjErrormsg.ErrorMessage(errorNo);
                }
            string[] result = { errorNo, errorMsg };
                //result[0] = errorNo;
                //result[1] = errorMsg;
            return result;
            //}
            //catch (Exception ex)
            //{
            //    return result;
            //    logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            //}

        }

        public FarmerRootObject GetAllFarmerDtls(FarmerContext objfarmer, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataTable dt = new DataTable();

            FarmerRootObject ObjFarmerRoot = new FarmerRootObject();
            FarmerReg_DataModel objDataModel = new FarmerReg_DataModel();

            ObjFarmerRoot.context = new FarmerContext();
            ObjFarmerRoot.context.List = new List<FarmerList>();
            ObjFarmerRoot.context.Filter = new FarmerFilter();
            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("FDR_fetch_farmer_registration_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfarmer.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfarmer.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfarmer.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfarmer.localeId;
                cmd.Parameters.Add("in_filterby_option", MySqlDbType.VarChar).Value = objfarmer.Filter.FilterBy_Option;
                cmd.Parameters.Add("in_filterby_code", MySqlDbType.VarChar).Value = objfarmer.Filter.FilterBy_Code;
                cmd.Parameters.Add("in_filterby_fromvalue", MySqlDbType.VarChar).Value = objfarmer.Filter.FilterBy_FromValue;
                cmd.Parameters.Add("in_filterby_tovalue", MySqlDbType.VarChar).Value = objfarmer.Filter.FilterBy_ToValue;
                cmd.Parameters.Add("in_from_index", MySqlDbType.Int32).Value = objfarmer.Filter.from_index;
                cmd.Parameters.Add("in_to_index", MySqlDbType.Int32).Value = objfarmer.Filter.to_index;
                cmd.Parameters.Add("in_record_count", MySqlDbType.Int32).Value = objfarmer.Filter.record_count;
                cmd.Parameters.Add(new MySqlParameter("out_record_count", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.Int32)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                //LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FarmerList objList = new FarmerList();
                    objList.out_farmer_rowid = Convert.ToInt32(dt.Rows[i]["out_farmer_rowid"]);
                    objList.out_farmer_code = dt.Rows[i]["out_farmer_code"].ToString();
                    objList.out_version_no = Convert.ToInt32(dt.Rows[i]["out_version_no"].ToString());
                    objList.out_photo_farmer = dt.Rows[i]["out_photo_farmer"].ToString();
                    //Prema added for meity demo changes on may 16
                    objList.out_member_id = dt.Rows[i]["out_member_id"].ToString();
                    objList.out_fpo_name = dt.Rows[i]["out_fpo_name"].ToString();
                    //END
                    objList.out_farmer_name = dt.Rows[i]["out_farmer_name"].ToString();
                    objList.out_sur_name = dt.Rows[i]["out_sur_name"].ToString();
                    objList.out_fhw_name = dt.Rows[i]["out_fhw_name"].ToString();
                    objList.out_farmer_dob = dt.Rows[i]["out_farmer_dob"].ToString();
                    objList.out_farmer_addr1 = dt.Rows[i]["out_farmer_addr1"].ToString();
                    objList.Hamlet = dt.Rows[i]["Hamlet"].ToString(); ////Sanjay Field visit changes on April 12
                    objList.out_farmer_ll_name = dt.Rows[i]["out_farmer_ll_name"].ToString();
                    objList.out_sur_ll_name = dt.Rows[i]["out_sur_ll_name"].ToString();
                    objList.out_fhw_ll_name = dt.Rows[i]["out_fhw_ll_name"].ToString();
                    objList.out_farmer_ll_addr1 = dt.Rows[i]["out_farmer_ll_addr1"].ToString();
                    objList.out_farmer_ll_addr2 = dt.Rows[i]["out_farmer_ll_addr2"].ToString();
                    objList.out_farmer_country = dt.Rows[i]["out_farmer_country"].ToString();
                    objList.out_farmer_country_desc = dt.Rows[i]["out_farmer_country_desc"].ToString();
                    objList.out_farmer_state = dt.Rows[i]["out_farmer_state"].ToString();
                    objList.out_farmer_state_desc = dt.Rows[i]["out_farmer_state_desc"].ToString();
                    objList.out_farmer_dist = dt.Rows[i]["out_farmer_dist"].ToString();
                    objList.out_farmer_dist_desc = dt.Rows[i]["out_farmer_dist_desc"].ToString();
                    objList.out_farmer_taluk = dt.Rows[i]["out_farmer_taluk"].ToString();
                    objList.out_farmer_taluk_desc = dt.Rows[i]["out_farmer_taluk_desc"].ToString();
                    objList.out_farmer_panchayat = dt.Rows[i]["out_farmer_panchayat"].ToString();
                    objList.out_farmer_panchayat_desc = dt.Rows[i]["out_farmer_panchayat_desc"].ToString();
                    objList.out_farmer_village = dt.Rows[i]["out_farmer_village"].ToString();
                    objList.out_farmer_village_desc = dt.Rows[i]["out_farmer_village_desc"].ToString();
                    objList.out_farmer_pincode = dt.Rows[i]["out_farmer_pincode"].ToString();
                    objList.out_farmer_pincode_desc = dt.Rows[i]["out_farmer_pincode_desc"].ToString();
                    objList.out_marital_status = dt.Rows[i]["out_marital_status"].ToString();
                    objList.out_marital_status_desc = dt.Rows[i]["out_marital_status_desc"].ToString();
                    objList.out_gender_flag = dt.Rows[i]["out_gender_flag"].ToString();
                    objList.out_gender_flag_desc = dt.Rows[i]["out_gender_flag_desc"].ToString();
                    objList.out_reg_mobile_no = dt.Rows[i]["out_reg_mobile_no"].ToString();
                    objList.out_reg_note = dt.Rows[i]["out_reg_note"].ToString();
                    objList.out_status_code = dt.Rows[i]["out_status_code"].ToString();
                    objList.out_status_desc = dt.Rows[i]["out_status_desc"].ToString();
                    objList.out_row_timestamp = dt.Rows[i]["out_row_timestamp"].ToString();
                    ObjFarmerRoot.context.List.Add(objList);

                }
                ObjFarmerRoot.context.orgnId = objfarmer.orgnId;
                ObjFarmerRoot.context.locnId = objfarmer.locnId;
                ObjFarmerRoot.context.localeId = objfarmer.localeId;
                ObjFarmerRoot.context.userId = objfarmer.userId;
                ObjFarmerRoot.context.Filter.FilterBy_Code = objfarmer.Filter.FilterBy_Code;
                ObjFarmerRoot.context.Filter.FilterBy_FromValue = objfarmer.Filter.FilterBy_FromValue;
                ObjFarmerRoot.context.Filter.FilterBy_Option = objfarmer.Filter.FilterBy_Option;
                ObjFarmerRoot.context.Filter.FilterBy_ToValue = objfarmer.Filter.FilterBy_ToValue;
                ObjFarmerRoot.context.Filter.to_index = objfarmer.Filter.to_index;
                ObjFarmerRoot.context.Filter.record_count = objfarmer.Filter.record_count;
                ObjFarmerRoot.context.Filter.out_record_count = (Int32)cmd.Parameters["out_record_count"].Value;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjFarmerRoot.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFarmerRoot;
        }
        public FRootObject GetSingleFarmerDtls(FContext ObjContext, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataSet ds = new DataSet();
            MysqlCon = new DataConnection(mysqlcon);

            FRootObject ObjFarmerRoot = new FRootObject();
            FarmerReg_DataModel objDataModel = new FarmerReg_DataModel();

            DataTable kycdt = new DataTable();
            DataTable Bankdt = new DataTable();
            DataTable Header = new DataTable();
            DataTable consent = new DataTable();

            ObjFarmerRoot.context = new FContext();
            ObjFarmerRoot.context.header = new FHeader();
            ObjFarmerRoot.context.bank = new List<FBank>();
            ObjFarmerRoot.context.kyc = new List<FKyc>();
            ObjFarmerRoot.context.consent = new List<constentDtl>();
            try
            {

                MySqlCommand cmd = new MySqlCommand("FDR_fetch_farmer_registration", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("in_farmer_rowid", MySqlDbType.Int32).Value = ObjContext.header.in_farmer_rowid;
                cmd.Parameters.Add("in_farmer_code", MySqlDbType.VarChar).Value = ObjContext.header.in_farmer_code;
                cmd.Parameters.Add("in_version_no", MySqlDbType.Int32).Value = ObjContext.header.in_version_no;

                cmd.Parameters.Add(new MySqlParameter("in_farmer_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                //Prema added for meity demo changes on may 16
                cmd.Parameters.Add(new MySqlParameter("in_member_id", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_fpo_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                //END
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
                //cmd.Parameters.Add(new MySqlParameter("Aadhar_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output; //ramya commentted on 10 jun 21 since its not needed for UP
                cmd.Parameters.Add(new MySqlParameter("in_reg_note", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
               
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                if (ds.Tables.Count > 0)
                {
                    Bankdt = ds.Tables[0];
                    kycdt = ds.Tables[1];
                    consent = ds.Tables[2];
                    for (int i = 0; i < Bankdt.Rows.Count; i++)
                    {
                        FBank objBankList = new FBank();
                        objBankList.in_farmerbank_rowid = Convert.ToInt32(Bankdt.Rows[i]["in_farmerbank_rowid"]);
                        objBankList.in_bank_acc_no = Bankdt.Rows[i]["in_bank_acc_no"].ToString();
                        objBankList.in_bank_acc_type = Bankdt.Rows[i]["in_bank_acc_type"].ToString();
                        objBankList.in_bank_acc_type_desc = Bankdt.Rows[i]["in_bank_acc_type_desc"].ToString();
                        objBankList.in_bank_code = Bankdt.Rows[i]["in_bank_code"].ToString();
                        objBankList.in_bank_desc = Bankdt.Rows[i]["in_bank_desc"].ToString();
                        objBankList.in_branch_code = Bankdt.Rows[i]["in_branch_code"].ToString();
                        objBankList.in_branch_desc = Bankdt.Rows[i]["in_branch_desc"].ToString();
                        objBankList.in_ifsc_code = Bankdt.Rows[i]["in_ifsc_code"].ToString();
                        objBankList.in_dflt_dr_acc = Bankdt.Rows[i]["in_dflt_dr_acc"].ToString();
                        objBankList.in_dflt_dr_acc_desc = Bankdt.Rows[i]["in_dflt_dr_acc_desc"].ToString();
                        objBankList.in_dflt_cr_acc = Bankdt.Rows[i]["in_dflt_cr_acc"].ToString();
                        objBankList.in_dflt_cr_acc_desc = Bankdt.Rows[i]["in_dflt_cr_acc_desc"].ToString();
                        objBankList.in_status_code = Bankdt.Rows[i]["in_status_code"].ToString();
                        objBankList.in_status_desc = Bankdt.Rows[i]["in_status_desc"].ToString();
                        objBankList.in_mode_flag = Bankdt.Rows[i]["in_mode_flag"].ToString();
                        ObjFarmerRoot.context.bank.Add(objBankList);
                    }
                    for (int i = 0; i < kycdt.Rows.Count; i++)
                    {
                        FKyc objKycList = new FKyc();
                        objKycList.in_farmerkyc_rowid = Convert.ToInt32(kycdt.Rows[i]["in_farmerkyc_rowid"]);
                        objKycList.in_proof_type = kycdt.Rows[i]["in_proof_type"].ToString();
                        objKycList.in_proof_type_desc = kycdt.Rows[i]["in_proof_type_desc"].ToString();
                        objKycList.in_proof_doc = kycdt.Rows[i]["in_proof_doc"].ToString();
                        objKycList.in_proof_doc_desc = kycdt.Rows[i]["in_proof_doc_desc"].ToString();
                        objKycList.in_proof_doc_no = kycdt.Rows[i]["in_proof_doc_no"].ToString();
                        objKycList.in_proof_doc_adharno = kycdt.Rows[i]["in_proof_doc_adharno"].ToString();
                        objKycList.in_proof_valid_till = kycdt.Rows[i]["in_proof_valid_till"].ToString();
                        objKycList.in_status_code = kycdt.Rows[i]["in_status_code"].ToString();
                        objKycList.in_status_desc = kycdt.Rows[i]["in_status_desc"].ToString();
                        objKycList.in_mode_flag = kycdt.Rows[i]["in_mode_flag"].ToString();
                        objKycList.in_photo_kyc = kycdt.Rows[i]["In_photo_kyc"].ToString();
                        ObjFarmerRoot.context.kyc.Add(objKycList);
                    }
                    for (int i = 0; i < consent.Rows.Count; i++)
                    {
                        constentDtl objconsentList = new constentDtl();
                        objconsentList.In_farmerconsent_rowid = Convert.ToInt32(consent.Rows[i]["In_farmerconsent_rowid"]);
                        objconsentList.In_template_id = consent.Rows[i]["In_template_id"].ToString();
                        objconsentList.In_consent_owner_id = consent.Rows[i]["In_consent_owner_id"].ToString();
                        objconsentList.In_consent_to = consent.Rows[i]["In_consent_to"].ToString();
                        objconsentList.In_lang_code = consent.Rows[i]["In_lang_code"].ToString();
                        objconsentList.template_consent = consent.Rows[i]["template_consent"].ToString();
                        objconsentList.In_otp_flag = consent.Rows[i]["In_otp_flag"].ToString();
                        objconsentList.In_isverified = consent.Rows[i]["In_isverified"].ToString();
                        objconsentList.In_attach_consent = consent.Rows[i]["In_attach_consent"].ToString();
                        objconsentList.In_attachment_flag = consent.Rows[i]["In_attachment_flag"].ToString();
                        objconsentList.In_mobile_no = consent.Rows[i]["In_mobile_no"].ToString();
                        objconsentList.In_attach_type = consent.Rows[i]["In_attach_type"].ToString();
                        objconsentList.In_verified_date = consent.Rows[i]["In_verified_date"].ToString();
                        objconsentList.In_consent_to_desc = consent.Rows[i]["In_consent_to_desc"].ToString();
                        objconsentList.in_isverified_code = consent.Rows[i]["in_isverified_code"].ToString();                       
                        ObjFarmerRoot.context.consent.Add(objconsentList);
                    }
                }
                ObjFarmerRoot.context.orgnId = ObjContext.orgnId;
                ObjFarmerRoot.context.locnId = ObjContext.locnId;
                ObjFarmerRoot.context.userId = ObjContext.userId;
                ObjFarmerRoot.context.localeId = ObjContext.localeId;

                ObjFarmerRoot.context.header.in_farmer_rowid = (Int32)cmd.Parameters["in_farmer_rowid1"].Value;
                ObjFarmerRoot.context.header.in_farmer_code = (string)cmd.Parameters["in_farmer_code1"].Value.ToString();
                //Prema added for meity demo changes on may 16
                ObjFarmerRoot.context.header.in_member_id = (string)cmd.Parameters["in_member_id"].Value.ToString();
                ObjFarmerRoot.context.header.in_fpo_name = (string)cmd.Parameters["in_fpo_name"].Value.ToString();
                //END
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
                //ObjFarmerRoot.context.header.Aadhar_no = (string)cmd.Parameters["Aadhar_no"].Value.ToString(); //ramya commentted on 10 jun 21 since its not needed for UP
                ObjFarmerRoot.context.header.in_reg_note = (string)cmd.Parameters["in_reg_note"].Value.ToString();
                ObjFarmerRoot.context.header.in_status_code = (string)cmd.Parameters["in_status_code"].Value.ToString();
                ObjFarmerRoot.context.header.in_status_desc = (string)cmd.Parameters["in_status_desc"].Value.ToString();
                ObjFarmerRoot.context.header.in_mode_flag = (string)cmd.Parameters["in_mode_flag"].Value.ToString();
                ObjFarmerRoot.context.header.in_row_timestamp = (string)cmd.Parameters["in_row_timestamp"].Value.ToString();
             
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjFarmerRoot.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFarmerRoot;
        }

        public FRootObjectview GetSingleFarmerDtlsView(FContextview ObjContext, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataSet ds = new DataSet();
            MysqlCon = new DataConnection(mysqlcon);

            FRootObjectview ObjFarmerRoot = new FRootObjectview();
            FarmerReg_DataModel objDataModel = new FarmerReg_DataModel();

            DataTable kycdt = new DataTable();
            DataTable Bankdt = new DataTable();
            DataTable Header = new DataTable();

            ObjFarmerRoot.context = new FContextview();
            ObjFarmerRoot.context.header = new FView();
            try
            {

                MySqlCommand cmd = new MySqlCommand("FDR_ViewContent", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("in_farmer_code", MySqlDbType.VarChar).Value = ObjContext.header.in_farmer_code;


                cmd.Parameters.Add(new MySqlParameter("in_farmer_tacrowid", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_codeview", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_OTP", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_farmer_URL", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("in_created_datetime", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("FPO_Name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();


                ObjFarmerRoot.context.orgnId = ObjContext.orgnId;
                ObjFarmerRoot.context.locnId = ObjContext.locnId;
                ObjFarmerRoot.context.userId = ObjContext.userId;
                ObjFarmerRoot.context.localeId = ObjContext.localeId;
    
                ObjFarmerRoot.context.header.in_farmer_tacrowid = (Int32)cmd.Parameters["in_farmer_tacrowid"].Value;
                ObjFarmerRoot.context.header.in_farmer_codeview = (string)cmd.Parameters["in_farmer_codeview"].Value.ToString();
                ObjFarmerRoot.context.header.in_farmer_OTP = (Int32)cmd.Parameters["in_farmer_OTP"].Value;
                ObjFarmerRoot.context.header.in_farmer_URl = (string)cmd.Parameters["in_farmer_URL"].Value.ToString();
                ObjFarmerRoot.context.header.in_created_datetime = (string)cmd.Parameters["in_created_datetime"].Value.ToString();
                ObjFarmerRoot.context.header.FPO_Name = (string)cmd.Parameters["FPO_Name"].Value.ToString();

            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjFarmerRoot.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFarmerRoot;
        }
    }
}
