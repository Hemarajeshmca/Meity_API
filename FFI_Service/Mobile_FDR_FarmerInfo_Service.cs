using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using static FFI_Model.Mobile_FDR_FarmerInfo_Model;

namespace FFI_Service
{
    public class Mobile_FDR_FarmerInfo_Service
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Mobile_FDR_FarmerInfo_Service)); //Declaring Log4Net. 
        Mobile_FDR_FarmerInfo_DB objData = new Mobile_FDR_FarmerInfo_DB();
        public FDRFarmerNew GetFarmernewData(MobileFDRFarmerContext objInput, string ConString)
        {
            FDRFarmerNew objFarmer = new FDRFarmerNew();
            try
            {
                DataSet ds = objData.GetFarmerInfonew(objInput, ConString);
                DataTable dtFarmerHeader = ds.Tables[0];
                DataTable dtFarmerPersonalDetails = ds.Tables[1];
                DataTable dtFarmerAddressDetails = ds.Tables[2];
                DataTable dtFarmerFamilyDetails = ds.Tables[3];
                DataTable dtFarmerLoanDetails = ds.Tables[4];
                DataTable dtFarmerLoanRepaymentDetails = ds.Tables[5];
                DataTable dtFarmerLandDetails = ds.Tables[6];
                DataTable dtFarmerLiveStockDetails = ds.Tables[7];
                DataTable dtFarmerAssetsDetails = ds.Tables[8];
                DataTable dtFarmerInsuranceDetails = ds.Tables[9];
                DataTable dtFarmerCroppingDetailsNew = ds.Tables[10];
                DataTable dtFarmerSowingDetailsNew = ds.Tables[11];
                DataTable dtFarmerInputDetailsNew = ds.Tables[12];
                DataTable dtFarmerProductionDetails = ds.Tables[13];
                DataTable dtFarmerSaleDetails = ds.Tables[14];
                DataTable dtFarmerStockDetails = ds.Tables[15];
                DataTable dtFarmerTrainingDetails = ds.Tables[16];
                DataTable dtFarmerShareHoldingDetails = ds.Tables[17];
                DataTable dtFarmerBusinessDetailsNew = ds.Tables[18];
                DataTable dtFarmerLoanRequirementDetails = ds.Tables[19];
                DataTable dtFarmerBankDetailNew = ds.Tables[20];
                DataTable dtFarmerKYCDetailNew = ds.Tables[21];

                List<FDRFarmerHeaderNew> objFarmerHeader = new List<FDRFarmerHeaderNew>();           
              
                for (int i = 0; i < dtFarmerHeader.Rows.Count; i++)
                {
                    FDRFarmerHeaderNew Obj_farmerdetails = new FDRFarmerHeaderNew();
                    Obj_farmerdetails.Farmer_Rowid = Convert.ToInt32(dtFarmerHeader.Rows[i]["farmer_rowid"].ToString());
                    Obj_farmerdetails.FarmerCode = dtFarmerHeader.Rows[i]["FarmerCode"].ToString();
                    Obj_farmerdetails.FarmerName = dtFarmerHeader.Rows[i]["FarmerName"].ToString();
                    Obj_farmerdetails.Sur_Name = dtFarmerHeader.Rows[i]["Sur_Name"].ToString();
                    Obj_farmerdetails.Father_Name = dtFarmerHeader.Rows[i]["Father_Name"].ToString();
                    Obj_farmerdetails.Farmer_Dob = dtFarmerHeader.Rows[i]["Farmer_Dob"].ToString();
                    Obj_farmerdetails.Farmer_Address1 = dtFarmerHeader.Rows[i]["Farmer_Address1"].ToString();
                    Obj_farmerdetails.Farmer_Country_Code = dtFarmerHeader.Rows[i]["farmer_country_code"].ToString();
                    Obj_farmerdetails.Farmer_Country = dtFarmerHeader.Rows[i]["Farmer_Country"].ToString();
                    Obj_farmerdetails.Farmer_State_Code = dtFarmerHeader.Rows[i]["farmer_state_code"].ToString();
                    Obj_farmerdetails.Farmer_State = dtFarmerHeader.Rows[i]["Farmer_State"].ToString();
                    Obj_farmerdetails.Farmer_District_Code = dtFarmerHeader.Rows[i]["farmer_dist_code"].ToString();
                    Obj_farmerdetails.Farmer_District = dtFarmerHeader.Rows[i]["Farmer_District"].ToString();
                    Obj_farmerdetails.Farmer_Taluk_Code = dtFarmerHeader.Rows[i]["farmer_taluk_code"].ToString();
                    Obj_farmerdetails.Farmer_Taluk = dtFarmerHeader.Rows[i]["Farmer_Taluk"].ToString();
                    Obj_farmerdetails.Farmer_Panchayat_code = dtFarmerHeader.Rows[i]["farmer_panchayat_code"].ToString();
                    Obj_farmerdetails.Farmer_Panchayat = dtFarmerHeader.Rows[i]["Farmer_Panchayat"].ToString();
                    Obj_farmerdetails.Farmer_Village_Code = dtFarmerHeader.Rows[i]["farmer_village_code"].ToString();
                    Obj_farmerdetails.Farmer_Village = dtFarmerHeader.Rows[i]["Farmer_Village"].ToString();
                    Obj_farmerdetails.Farmer_Panchayat = dtFarmerHeader.Rows[i]["Farmer_Panchayat"].ToString();
                    Obj_farmerdetails.Farmer_Hamlet = dtFarmerHeader.Rows[i]["Farmer_Hamlet"].ToString();
                    Obj_farmerdetails.Farmer_Pincode = dtFarmerHeader.Rows[i]["Farmer_Pincode"].ToString();
                    Obj_farmerdetails.Gender = dtFarmerHeader.Rows[i]["Gender"].ToString();
                    Obj_farmerdetails.Mobile_No = dtFarmerHeader.Rows[i]["Mobile_No"].ToString();
                    Obj_farmerdetails.Photo_Status = Convert.ToInt32(dtFarmerHeader.Rows[i]["Photo_status"].ToString());
                    try
                    {
                        var bankdtls = (from e in dtFarmerBankDetailNew.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode select e).ToList();
                        List<FDRFarmerBankdetails> objFarmerBank = new List<FDRFarmerBankdetails>();
                        if (bankdtls.Count != 0)
                        {
                          
                            DataTable dt = dtFarmerBankDetailNew.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FDRFarmerBankdetails objFarmerbnk = new FDRFarmerBankdetails();
                                objFarmerbnk.Bank_Rowid = Convert.ToInt32(dt.Rows[j]["bank_rowid"].ToString());
                                objFarmerbnk.AccountNo = dt.Rows[j]["BankAccoutNo"].ToString();
                                objFarmerbnk.AccountType = dt.Rows[j]["BankAccountType"].ToString();
                                objFarmerbnk.AccountType_Name = dt.Rows[j]["BankAccountType_Name"].ToString();
                                objFarmerbnk.Bank = dt.Rows[j]["Bankcode"].ToString();
                                objFarmerbnk.Bank_Name = dt.Rows[j]["Bank_Name"].ToString();
                                objFarmerbnk.Branch_code = dt.Rows[j]["branch_code"].ToString();
                                objFarmerbnk.Branch_Name = dt.Rows[j]["Branch_name"].ToString();
                                objFarmerbnk.IFSCCode = dt.Rows[j]["IFSCCode"].ToString();
                                objFarmerbnk.DefaultDebitAccout = dt.Rows[j]["DefaultDebitAccout"].ToString();
                                objFarmerbnk.DefaultCreditAccout = dt.Rows[j]["DefaultCreditAccout"].ToString();
                                objFarmerBank.Add(objFarmerbnk);
                            }
                           
                        }
                        Obj_farmerdetails.FarmerBanklDetails = objFarmerBank;
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.ToString());
                        throw ex;
                    }
                    try
                    {
                        var kycdtls = (from e in dtFarmerKYCDetailNew.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode select e).ToList();
                        List<FDRFarmerkYCDetails> objKYCDetails = new List<FDRFarmerkYCDetails>();
                        if (kycdtls.Count != 0)
                        {
                           
                            DataTable dt = dtFarmerKYCDetailNew.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FDRFarmerkYCDetails objFarmerkyc = new FDRFarmerkYCDetails();
                                objFarmerkyc.Kyc_Rowid = Convert.ToInt32(dt.Rows[j]["kyc_rowid"].ToString());
                                objFarmerkyc.ProofType_Code = dt.Rows[j]["ProofType_code"].ToString();
                                objFarmerkyc.ProofType = dt.Rows[j]["ProofType"].ToString();
                                objFarmerkyc.ProofSubType_Code = dt.Rows[j]["ProofSubType_code"].ToString();
                                objFarmerkyc.ProofSubType = dt.Rows[j]["ProofSubType"].ToString();
                                objFarmerkyc.DocumentNo = dt.Rows[j]["DocumentNo"].ToString();
                                objFarmerkyc.ConfirmDocumentNo = dt.Rows[j]["ConfirmDocumentNo"].ToString();
                                objFarmerkyc.ValidTill = dt.Rows[j]["ValidTill"].ToString();
                                objFarmerkyc.Photo_Status = Convert.ToInt32(dt.Rows[j]["Photo_status"].ToString());
                                objKYCDetails.Add(objFarmerkyc);
                            }
                           
                        }
                        Obj_farmerdetails.FarmerKYCDetails = objKYCDetails;
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.ToString());
                        throw ex;
                    }
                    try
                    {
                        var personaldtls = (from e in dtFarmerPersonalDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode select e).ToList();
                        List<FDRFarmerPersonalDetailsNew> objpersonal = new List<FDRFarmerPersonalDetailsNew>();
                        if (personaldtls.Count != 0)
                        {
                           
                            DataTable dt = dtFarmerPersonalDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FDRFarmerPersonalDetailsNew objFarmerPersonal = new FDRFarmerPersonalDetailsNew();
                                objFarmerPersonal.Slno = Convert.ToInt32(dt.Rows[j]["slno"].ToString());
                                objFarmerPersonal.MaritalStatus = dt.Rows[j]["MaritalStatus"].ToString();
                                objFarmerPersonal.Mobile = dt.Rows[j]["Mobile"].ToString();
                                objFarmerPersonal.EmailID = dt.Rows[j]["EmailID"].ToString();
                                objFarmerPersonal.Landline = dt.Rows[j]["Landline"].ToString();
                                objFarmerPersonal.Qualification = dt.Rows[j]["Qualification"].ToString();
                                objFarmerPersonal.Caste = dt.Rows[j]["Caste"].ToString();
                                objFarmerPersonal.Religion = dt.Rows[j]["Religion"].ToString();
                                objFarmerPersonal.Minority = dt.Rows[j]["Minority"].ToString();
                                objpersonal.Add(objFarmerPersonal);
                            }
                            
                        }
                        Obj_farmerdetails.FarmerPersonalDetails = objpersonal;
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.ToString());
                        throw ex;
                    }

                    try
                    {
                        var addressdtls = (from e in dtFarmerAddressDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode select e).ToList();
                        List<FDRFarmerAddressDetailsNew> objAddress = new List<FDRFarmerAddressDetailsNew>();
                        if (addressdtls.Count != 0)
                        {
                           
                            DataTable dt = dtFarmerAddressDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FDRFarmerAddressDetailsNew objFarmerAddress = new FDRFarmerAddressDetailsNew();
                                objFarmerAddress.Slno = Convert.ToInt32(dt.Rows[j]["slno"].ToString());
                                objFarmerAddress.AddressType = dt.Rows[j]["AddressType"].ToString();
                                objFarmerAddress.Address = dt.Rows[j]["Address"].ToString();
                                objFarmerAddress.Pincode = dt.Rows[j]["Pincode"].ToString();
                                objFarmerAddress.Country_Code = dt.Rows[j]["Country_Code"].ToString();
                                objFarmerAddress.Country = dt.Rows[j]["Country"].ToString();
                                objFarmerAddress.State_Code = dt.Rows[j]["State_Code"].ToString();
                                objFarmerAddress.State = dt.Rows[j]["State"].ToString();
                                objFarmerAddress.District_Code = dt.Rows[j]["District_code"].ToString();
                                objFarmerAddress.District = dt.Rows[j]["District"].ToString();
                                objFarmerAddress.Taluk_Code = dt.Rows[j]["Taluk_code"].ToString();
                                objFarmerAddress.Taluk = dt.Rows[j]["Taluk"].ToString();
                                objFarmerAddress.Village_Code = dt.Rows[j]["village_code"].ToString();
                                objFarmerAddress.Village = dt.Rows[j]["Village"].ToString();
                                objFarmerAddress.Panchayat_code = dt.Rows[j]["panchayat_code"].ToString();
                                objFarmerAddress.Panchayat_Name = dt.Rows[j]["panchayat_name"].ToString();
                                objAddress.Add(objFarmerAddress);
                            }
                            
                        }
                        Obj_farmerdetails.FarmerAddressDetails = objAddress;
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.ToString());
                        throw ex;
                    }
                    try
                    {
                        var famdtl = (from e in dtFarmerFamilyDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode select e).ToList();
                        List<FDRFarmerFamilyDetailsNew> objFamily = new List<FDRFarmerFamilyDetailsNew>();
                        if (famdtl.Count != 0)
                        {
                           
                            DataTable dt = dtFarmerFamilyDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FDRFarmerFamilyDetailsNew objfam = new FDRFarmerFamilyDetailsNew();
                                objfam.Slno = Convert.ToInt32(dt.Rows[j]["slno"].ToString());
                                objfam.DOB = dt.Rows[j]["DOB"].ToString();
                                objfam.Gender = dt.Rows[j]["Gender"].ToString();
                                objfam.Relationship = dt.Rows[j]["Relationship"].ToString();
                                objfam.Qualification = dt.Rows[j]["Qualification"].ToString();
                                objfam.Occupation = dt.Rows[j]["Occupation"].ToString();
                                objfam.FamilyType = dt.Rows[j]["FamilyType"].ToString();
                                objfam.FamilyMember = dt.Rows[j]["MemberName"].ToString();
                                objFamily.Add(objfam);
                            }
                            
                        }
                        Obj_farmerdetails.FarmerFamilyDetails = objFamily;
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.ToString());
                        throw ex;
                    }

                    try
                    {
                        var loandtl = (from e in dtFarmerLoanDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode select e).ToList();
                        List<FDRFarmerLoanDetailsNew> objLoan = new List<FDRFarmerLoanDetailsNew>();
                        if (loandtl.Count != 0)
                        {
                            
                            DataTable dt = dtFarmerLoanDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FDRFarmerLoanDetailsNew objln = new FDRFarmerLoanDetailsNew();
                                objln.slno = Convert.ToInt32(dt.Rows[j]["slno"].ToString());
                                objln.LoanType = dt.Rows[j]["LoanType"].ToString();
                                objln.LoanFrom = dt.Rows[j]["LoanFrom"].ToString();
                                objln.InstitutionName = dt.Rows[j]["InstitutionName"].ToString();
                                objln.Branch = dt.Rows[j]["InstitutionBranch"].ToString();
                                objln.LoanAccountNo = dt.Rows[j]["LoanAccountNo"].ToString();
                                objln.StartDate = dt.Rows[j]["StartDate"].ToString();
                                objln.EndDate = dt.Rows[j]["EndDate"].ToString();
                                objln.LoanAmount = Convert.ToDecimal(dt.Rows[j]["LoanAmount"].ToString());
                                objln.InterestRate = Convert.ToDecimal(dt.Rows[j]["InterestRate"].ToString());
                                objln.Tenor = dt.Rows[j]["LoanTenor"].ToString();
                                objln.EMI = dt.Rows[j]["EMI"].ToString();
                                objLoan.Add(objln);
                            }
                          
                        }
                        Obj_farmerdetails.FarmerLoanDetails = objLoan;

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.ToString());
                        throw ex;
                    }

                    try
                    {
                        var loanrepaydtl = (from e in dtFarmerLoanRepaymentDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode select e).ToList();
                        List<FDRFarmerLoanRepaymentDetailsNew> objLoanRepay = new List<FDRFarmerLoanRepaymentDetailsNew>();
                        if (loanrepaydtl.Count != 0)
                        {
                            
                            DataTable dt = dtFarmerLoanRepaymentDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FDRFarmerLoanRepaymentDetailsNew objlnrapay = new FDRFarmerLoanRepaymentDetailsNew();
                                objlnrapay.slno = Convert.ToInt32(dt.Rows[j]["slno"].ToString());
                                objlnrapay.LoanAccountNo = dt.Rows[j]["AccountNo"].ToString();
                                objlnrapay.RepaymentMode = dt.Rows[j]["RepayMode"].ToString();
                                objlnrapay.RepaymentDate = dt.Rows[j]["RepaymentDate"].ToString();
                                objlnrapay.RepaymentAmt = dt.Rows[j]["Amount"].ToString();
                                objLoanRepay.Add(objlnrapay);
                            }
                           
                        }
                        Obj_farmerdetails.FarmerLoanRepaymentDetails = objLoanRepay;

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.ToString());
                        throw ex;
                    }

                    try
                    {
                        var landdtl = (from e in dtFarmerLandDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode select e).ToList();
                        List<FDRFarmerLandDetailsNew> objLand = new List<FDRFarmerLandDetailsNew>();
                        if (landdtl.Count != 0)
                        {
                           
                            DataTable dt = dtFarmerLandDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FDRFarmerLandDetailsNew objlnd = new FDRFarmerLandDetailsNew();
                                objlnd.slno = Convert.ToInt32(dt.Rows[j]["slno"].ToString());
                                objlnd.LandType = dt.Rows[j]["LandType"].ToString();
                                objlnd.Ownership = dt.Rows[j]["Ownership"].ToString();
                                objlnd.NoOfAcres = Convert.ToDecimal(dt.Rows[j]["NoOfAcres"].ToString());
                                objlnd.SoilType = dt.Rows[j]["SoilType"].ToString();
                                objlnd.IrrigationSource = dt.Rows[j]["IrrigationSource"].ToString();
                                objlnd.Latitude = dt.Rows[j]["Latitude"].ToString();
                                objlnd.Longitude = dt.Rows[j]["Longitude"].ToString();
                                objLand.Add(objlnd);
                            }
                           
                        }
                        Obj_farmerdetails.FarmerLandDetails = objLand;

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.ToString());
                        throw ex;
                    }
                    try
                    {
                        var livestokdtl = (from e in dtFarmerLiveStockDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode select e).ToList();
                        List<FDRFarmerLiveStockDetailsNew> objLiveStock = new List<FDRFarmerLiveStockDetailsNew>();
                        if (livestokdtl.Count != 0)
                        {
                            
                            DataTable dt = dtFarmerLiveStockDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FDRFarmerLiveStockDetailsNew objlive = new FDRFarmerLiveStockDetailsNew();
                                objlive.slno = Convert.ToInt32(dt.Rows[j]["slno"].ToString());
                                objlive.LivestockType = dt.Rows[j]["LivestockType"].ToString();
                                objlive.LivestockSubType = dt.Rows[j]["LivestockSubType"].ToString();
                                objlive.Ownership = dt.Rows[j]["Ownership"].ToString();
                                objlive.NumberProcessed = Convert.ToInt32(dt.Rows[j]["NumberPossessed"].ToString());
                                objlive.Purpose = dt.Rows[j]["Purpose"].ToString();
                                objLiveStock.Add(objlive);
                            }
                           
                        }
                        Obj_farmerdetails.FarmerLiveStockDetail = objLiveStock;

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.ToString());
                        throw ex;
                    }
                    try
                    {
                        var assetdtls = (from e in dtFarmerAssetsDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode select e).ToList();
                        List<FDRFarmerAssetsDetailsNew> objAssetDtl = new List<FDRFarmerAssetsDetailsNew>();
                        if (assetdtls.Count != 0)
                        {
                           
                            DataTable dt = dtFarmerAssetsDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FDRFarmerAssetsDetailsNew objasst = new FDRFarmerAssetsDetailsNew();
                                objasst.slno = Convert.ToInt32(dt.Rows[j]["slno"].ToString());
                                objasst.AssetType = dt.Rows[j]["AssetType"].ToString();
                                objasst.AssetSubType = dt.Rows[j]["AssetSubType"].ToString();
                                objasst.PurchaseDate = dt.Rows[j]["PurchaseDate"].ToString();
                                objasst.NoofAssets = Convert.ToInt32(dt.Rows[j]["NoofAssets"].ToString() == "" ? "0" : dt.Rows[j]["NoofAssets"].ToString());
                                objasst.Asset_Sl_No = dt.Rows[j]["AssetSerialNo"].ToString();
                                objasst.Purpose = dt.Rows[j]["Purpose"].ToString();
                                objAssetDtl.Add(objasst);
                            }
                           
                        }
                        Obj_farmerdetails.FarmerAssetsDetails = objAssetDtl;
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.ToString());
                        throw ex;
                    }
                    try
                    {
                        var isurancedtls = (from e in dtFarmerInsuranceDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode select e).ToList();
                        List<FDRFarmerInsuranceDetailsNew> objInsuranceDtl = new List<FDRFarmerInsuranceDetailsNew>();
                        if (isurancedtls.Count != 0)
                        {
                           
                            DataTable dt = dtFarmerInsuranceDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FDRFarmerInsuranceDetailsNew objinsur = new FDRFarmerInsuranceDetailsNew();
                                objinsur.slno = Convert.ToInt32(dt.Rows[j]["slno"].ToString());
                                objinsur.InsurerType = dt.Rows[j]["InsurerType"].ToString();
                                objinsur.InsurerName = dt.Rows[j]["InsurerName"].ToString();
                                objinsur.AgencyName = dt.Rows[j]["AgencyName"].ToString();
                                objinsur.PolicyNo = dt.Rows[j]["PolicyNo"].ToString();
                                objinsur.InsuredOn = dt.Rows[j]["InsuredOn"].ToString();
                                objinsur.PolicyDate = dt.Rows[j]["PolicyDate"].ToString();
                                objinsur.MaturityDate = dt.Rows[j]["MaturityDate"].ToString();
                                objinsur.Premium = dt.Rows[j]["Premium"].ToString();
                                objinsur.PayMode = dt.Rows[j]["PayMode"].ToString();
                                objinsur.Nominee = dt.Rows[j]["Nominee"].ToString();
                                objInsuranceDtl.Add(objinsur);

                            }
                            
                        }
                        Obj_farmerdetails.FarmerInsuranceDetails = objInsuranceDtl;
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.ToString());
                        throw ex;
                    }
                    try
                    {
                        var cropdtl = (from e in dtFarmerCroppingDetailsNew.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode select e).ToList();
                        List<FDRFarmerCroppingDetailsNew> objCrop = new List<FDRFarmerCroppingDetailsNew>();
                        if (cropdtl.Count != 0)
                        {
                            
                            DataTable dt = dtFarmerCroppingDetailsNew.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FDRFarmerCroppingDetailsNew objcrp = new FDRFarmerCroppingDetailsNew();
                                objcrp.slno = Convert.ToInt32(dt.Rows[j]["slno"].ToString());
                                objcrp.Year = dt.Rows[j]["Year"].ToString();
                                objcrp.Season = dt.Rows[j]["Season"].ToString();
                                objcrp.CropType = dt.Rows[j]["CropType"].ToString();
                                objcrp.Variety = dt.Rows[j]["Variety"].ToString();
                                objcrp.LandType = dt.Rows[j]["LandType"].ToString();
                                objcrp.LandSize = dt.Rows[j]["LandSize"].ToString();
                                objCrop.Add(objcrp);

                            }
                           
                        }
                        Obj_farmerdetails.FarmerCroppingDetails = objCrop;

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.ToString());
                        throw ex;
                    }
                    try
                    {
                        var sowingdtl = (from e in dtFarmerSowingDetailsNew.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode select e).ToList();
                        List<FDRFarmerSowingDetailsNew> objSowing = new List<FDRFarmerSowingDetailsNew>();
                        if (sowingdtl.Count != 0)
                        {
                           
                            DataTable dt = dtFarmerSowingDetailsNew.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FDRFarmerSowingDetailsNew objsow = new FDRFarmerSowingDetailsNew();
                                objsow.slno = Convert.ToInt32(dt.Rows[j]["slno"].ToString());
                                objsow.Year = dt.Rows[j]["Year"].ToString();
                                objsow.Season = dt.Rows[j]["Season"].ToString();
                                objsow.CropType = dt.Rows[j]["CropType"].ToString();
                                objsow.Variety = dt.Rows[j]["Variety"].ToString();
                                objsow.LandType = dt.Rows[j]["LandType"].ToString();
                                objsow.SeedQty = Convert.ToDecimal(dt.Rows[j]["SeedQty"].ToString());
                                objsow.SowingArea = Convert.ToDecimal(dt.Rows[j]["SowingArea"].ToString());
                                objsow.ExpectedYield = Convert.ToDecimal(dt.Rows[j]["ExpectedYield"].ToString());
                                objsow.Surplus = Convert.ToDecimal(dt.Rows[j]["Surplus"].ToString());
                                objsow.ExpectedPrice = Convert.ToDecimal(dt.Rows[j]["ExpectedPrice"].ToString());
                                objsow.SowingDate = dt.Rows[j]["SowingDate"].ToString();
                                objsow.TransactionDate = dt.Rows[j]["TransactionDate"].ToString();
                                objsow.DweedingDate = dt.Rows[j]["DweedingDate"].ToString();
                                objsow.HarvestDate = dt.Rows[j]["HarvestDate"].ToString();
                                objSowing.Add(objsow);
                            }
                           
                        }
                        Obj_farmerdetails.FarmerSowingDetails = objSowing;

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.ToString());
                        throw ex;
                    }
                    try
                    {
                        var inputdtl = (from e in dtFarmerInputDetailsNew.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode select e).ToList();
                        List<FDRFarmerInputDetailsNew> objInputDet = new List<FDRFarmerInputDetailsNew>();
                        if (inputdtl.Count != 0)
                        {
                           
                            DataTable dt = dtFarmerInputDetailsNew.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FDRFarmerInputDetailsNew objinpu = new FDRFarmerInputDetailsNew();
                                objinpu.slno = Convert.ToInt32(dt.Rows[j]["slno"].ToString());
                                objinpu.Year = dt.Rows[j]["Year"].ToString();
                                objinpu.Season = dt.Rows[j]["Season"].ToString();
                                objinpu.CropType = dt.Rows[j]["CropType"].ToString();
                                objinpu.Variety = dt.Rows[j]["Variety"].ToString();
                                objinpu.LandType = dt.Rows[j]["LandType"].ToString();
                                objinpu.Qty = Convert.ToInt32(dt.Rows[j]["Qty"].ToString());
                                objinpu.InputType = dt.Rows[j]["InputType"].ToString();
                                objinpu.InputName = dt.Rows[j]["InputName"].ToString();
                                objinpu.UsedDate = dt.Rows[j]["UsedDate"].ToString();
                                objinpu.ICName = dt.Rows[j]["ICName"].ToString();
                                objinpu.Remarks = dt.Rows[j]["Remarks"].ToString();
                                objinpu.Rate = Convert.ToDecimal(dt.Rows[j]["Rate"].ToString());
                                objinpu.Amount = Convert.ToDecimal(dt.Rows[j]["Amount"].ToString());
                                objInputDet.Add(objinpu);
                            }
                            
                        }
                        Obj_farmerdetails.FarmerInputDetails = objInputDet;

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.ToString());
                        throw ex;
                    }
                    try
                    {
                        var productiondtl = (from e in dtFarmerProductionDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode select e).ToList();
                        List<FDRFarmerProductionDetailsNew> objProduction = new List<FDRFarmerProductionDetailsNew>();
                        if (productiondtl.Count != 0)
                        {
                            
                            DataTable dt = dtFarmerProductionDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FDRFarmerProductionDetailsNew objprod = new FDRFarmerProductionDetailsNew();
                                objprod.slno = Convert.ToInt32(dt.Rows[j]["slno"].ToString());
                                objprod.Year = dt.Rows[j]["Year"].ToString();
                                objprod.Season = dt.Rows[j]["Season"].ToString();
                                objprod.CropType = dt.Rows[j]["CropType"].ToString();
                                objprod.Variety = dt.Rows[j]["Variety"].ToString();
                                objprod.LandType = dt.Rows[j]["LandType"].ToString();
                                objprod.ActualProduction = Convert.ToInt32(dt.Rows[j]["ActualProduction"].ToString());
                                objProduction.Add(objprod);
                            }
                           
                        }
                        Obj_farmerdetails.FarmerProductionDetails = objProduction;

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.ToString());
                        throw ex;
                    }
                    try
                    {
                        var saledtl = (from e in dtFarmerSaleDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode select e).ToList();
                        List<FDRFarmerSaleDetailsNew> objSale = new List<FDRFarmerSaleDetailsNew>();
                        if (saledtl.Count != 0)
                        {
                           
                            DataTable dt = dtFarmerSaleDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FDRFarmerSaleDetailsNew objsl = new FDRFarmerSaleDetailsNew();
                                objsl.slno = Convert.ToInt32(dt.Rows[j]["slno"].ToString());
                                objsl.Year = dt.Rows[j]["Year"].ToString();
                                objsl.Season = dt.Rows[j]["Season"].ToString();
                                objsl.CropType = dt.Rows[j]["CropType"].ToString();
                                objsl.Variety = dt.Rows[j]["Variety"].ToString();
                                objsl.LandType = dt.Rows[j]["LandType"].ToString();
                                objsl.Quantity = Convert.ToInt32(dt.Rows[j]["Quantity"].ToString());
                                objsl.SalePrice = Convert.ToDecimal(dt.Rows[j]["SalePrice"].ToString());
                                objsl.SaleValue = Convert.ToDecimal(dt.Rows[j]["SaleValue"].ToString());
                                objsl.Buyer = dt.Rows[j]["Buyer"].ToString();
                                objsl.TermsofPayment = dt.Rows[j]["TermsofPayment"].ToString();
                                objsl.Remarks = dt.Rows[j]["Remarks"].ToString();
                                objSale.Add(objsl);
                            }
                           
                        }
                        Obj_farmerdetails.FarmerSaleDetails = objSale;

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.ToString());
                        throw ex;
                    }
                    try
                    {
                        var stockdtl = (from e in dtFarmerStockDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode select e).ToList();
                        List<FDRFarmerStockDetailsNew> objStock = new List<FDRFarmerStockDetailsNew>();
                        if (stockdtl.Count != 0)
                        {
                            
                            DataTable dt = dtFarmerStockDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FDRFarmerStockDetailsNew objstk = new FDRFarmerStockDetailsNew();
                                objstk.slno = Convert.ToInt32(dt.Rows[j]["slno"].ToString());
                                objstk.Year = dt.Rows[j]["Year"].ToString();
                                objstk.Season = dt.Rows[j]["Season"].ToString();
                                objstk.CropType = dt.Rows[j]["CropType"].ToString();
                                objstk.Variety = dt.Rows[j]["Variety"].ToString();
                                objstk.LandType = dt.Rows[j]["LandType"].ToString();
                                objstk.StockUnsold = dt.Rows[j]["StockUnsold"].ToString();
                                objStock.Add(objstk);
                            }
                            
                        }
                        Obj_farmerdetails.FarmerStockDetails = objStock;

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.ToString());
                        throw ex;
                    }
                    try
                    {
                        var trainingdtl = (from e in dtFarmerTrainingDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode select e).ToList();
                        List<FDRFarmerTrainingDetailsNew> objTraining = new List<FDRFarmerTrainingDetailsNew>();
                        if (trainingdtl.Count != 0)
                        {
                            
                            DataTable dt = dtFarmerTrainingDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FDRFarmerTrainingDetailsNew objtrain = new FDRFarmerTrainingDetailsNew();
                                objtrain.slno = Convert.ToInt32(dt.Rows[j]["slno"].ToString());
                                objtrain.Year = dt.Rows[j]["Year"].ToString();
                                objtrain.Season = dt.Rows[j]["Season"].ToString();
                                objtrain.Agenda = dt.Rows[j]["Agenda"].ToString();
                                objtrain.Duration = dt.Rows[j]["Duration"].ToString();
                                objtrain.Place = dt.Rows[j]["Place"].ToString();
                                objtrain.TrainingDate = dt.Rows[j]["TrainingDate"].ToString();
                                objtrain.ExpertDetails = dt.Rows[j]["ExpertDetails"].ToString();
                                objTraining.Add(objtrain);
                            }
                           
                        }
                        Obj_farmerdetails.FarmerTrainingDetails = objTraining;

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.ToString());
                        throw ex;
                    }
                    try
                    {
                        var shareholdingdtl = (from e in dtFarmerShareHoldingDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode select e).ToList();
                        List<FDRFarmerShareHoldingDetailsNew> objShare = new List<FDRFarmerShareHoldingDetailsNew>();
                        if (shareholdingdtl.Count != 0)
                        {
                           
                            DataTable dt = dtFarmerShareHoldingDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FDRFarmerShareHoldingDetailsNew objshr = new FDRFarmerShareHoldingDetailsNew();
                                objshr.slno = Convert.ToInt32(dt.Rows[j]["slno"].ToString());
                                objshr.FPOName = dt.Rows[j]["FPOName"].ToString();
                                objshr.FIGName = dt.Rows[j]["FIGName"].ToString();
                                objshr.Shares = dt.Rows[j]["Shares"].ToString();
                                objshr.Amount = dt.Rows[j]["Amount"].ToString();
                                objShare.Add(objshr);
                            }
                            
                        }
                        Obj_farmerdetails.FarmerShareHoldingDetails = objShare;

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.ToString());
                        throw ex;
                    }
                    try
                    {
                        var businnessdtl = (from e in dtFarmerBusinessDetailsNew.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode select e).ToList();
                        List<FDRFarmerBusinessDetailsNew> objBusiness = new List<FDRFarmerBusinessDetailsNew>();
                        if (businnessdtl.Count != 0)
                        {
                            
                            DataTable dt = dtFarmerBusinessDetailsNew.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FDRFarmerBusinessDetailsNew objbuss = new FDRFarmerBusinessDetailsNew();
                                objbuss.slno = Convert.ToInt32(dt.Rows[j]["slno"].ToString());
                                objbuss.BusinessSegment = dt.Rows[j]["BusinessSegment"].ToString();
                                objbuss.Desription = dt.Rows[j]["Description"].ToString();
                                objbuss.Period = dt.Rows[j]["Period"].ToString();
                                objbuss.Amount = dt.Rows[j]["Amount"].ToString();
                                objBusiness.Add(objbuss);
                            }
                            
                        }
                        Obj_farmerdetails.FarmerBusinessDetails = objBusiness;

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.ToString());
                        throw ex;
                    }
                    try
                    {
                        var loanrequiredtl = (from e in dtFarmerLoanRequirementDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode select e).ToList();
                        List<FDRFarmerLoanRequirementDetailsNew> objLoanRequirement = new List<FDRFarmerLoanRequirementDetailsNew>();
                        if (loanrequiredtl.Count != 0)
                        {
                            
                            DataTable dt = dtFarmerLoanRequirementDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FarmerCode).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FDRFarmerLoanRequirementDetailsNew objloanreq = new FDRFarmerLoanRequirementDetailsNew();
                                objloanreq.slno = Convert.ToInt32(dt.Rows[j]["slno"].ToString());
                                objloanreq.TypeOfLoan = dt.Rows[j]["TypeOfLoan"].ToString();
                                objloanreq.Desription = dt.Rows[j]["Description"].ToString();
                                objloanreq.WhenRequired = dt.Rows[j]["WhenRequired"].ToString();
                                objloanreq.Amount = dt.Rows[j]["Amount"].ToString();
                                objLoanRequirement.Add(objloanreq);
                            }
                            
                        }
                        Obj_farmerdetails.FarmerLoanRequirementDetails = objLoanRequirement;

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex.ToString());
                        throw ex;
                    }
                    objFarmerHeader.Add(Obj_farmerdetails);
                }

                objFarmer.FarmerData = objFarmerHeader;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                throw ex;
            }

            return objFarmer;
        }

    }
}
