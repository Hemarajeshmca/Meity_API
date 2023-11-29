using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using static FFI_Model.FDRFarmerInfo_Model;

namespace FFI_Service
{
    public class FDRFarmerInfo_Service
    {
        FDRFarmerInfo_DataModel objData = new FDRFarmerInfo_DataModel();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FDRFarmerInfo_Service));
        public FarmerNew GetFarmernewData(SMSGetFarmerInfoModel objInput, string ConString)
        {
            FarmerNew objFarmer = new FarmerNew();
            try
            {
               // objInput.StartDate = DateTime.ParseExact(objInput.StartDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
               // objInput.EndDate = DateTime.ParseExact(objInput.EndDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

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

                List<FarmerHeaderNew> objFarmerHeader = new List<FarmerHeaderNew>();
                for (int i = 0; i < dtFarmerHeader.Rows.Count; i++)
                {
                    FarmerHeaderNew Obj_farmerdetails = new FarmerHeaderNew();
                    Obj_farmerdetails.FARMERCODE = dtFarmerHeader.Rows[i]["FarmerCode"].ToString();
                    Obj_farmerdetails.FPONAME = dtFarmerHeader.Rows[i]["FPOName"].ToString();
                    Obj_farmerdetails.FARMERNAME = dtFarmerHeader.Rows[i]["FarmerName"].ToString();
                    Obj_farmerdetails.SUR_NAME= dtFarmerHeader.Rows[i]["Sur_Name"].ToString();
                    Obj_farmerdetails.FATHER_NAME = dtFarmerHeader.Rows[i]["Father_Name"].ToString();
                    Obj_farmerdetails.FARMER_DOB = Convert.ToDateTime(dtFarmerHeader.Rows[i]["Farmer_Dob"].ToString());
                    Obj_farmerdetails.FARMER_ADDRESS1 = dtFarmerHeader.Rows[i]["Farmer_Address1"].ToString();
                    Obj_farmerdetails.FARMER_COUNTRY = dtFarmerHeader.Rows[i]["Farmer_Country"].ToString();
                    Obj_farmerdetails.FARMER_STATE = dtFarmerHeader.Rows[i]["Farmer_State"].ToString();
                    Obj_farmerdetails.FARMER_DISTRICT = dtFarmerHeader.Rows[i]["Farmer_District"].ToString();
                    Obj_farmerdetails.FARMER_TALUK = dtFarmerHeader.Rows[i]["Farmer_Taluk"].ToString();
                    Obj_farmerdetails.FARMER_PANCHAYAT = dtFarmerHeader.Rows[i]["Farmer_Panchayat"].ToString();
                    Obj_farmerdetails.FARMER_VILLAGE = dtFarmerHeader.Rows[i]["Farmer_Village"].ToString();
                    Obj_farmerdetails.FARMER_PANCHAYAT = dtFarmerHeader.Rows[i]["Farmer_Panchayat"].ToString();
                    Obj_farmerdetails.FARMER_HAMLET = dtFarmerHeader.Rows[i]["Farmer_Hamlet"].ToString();
                    Obj_farmerdetails.FARMER_PINCODE = dtFarmerHeader.Rows[i]["Farmer_Pincode"].ToString();
                    Obj_farmerdetails.GENDER = dtFarmerHeader.Rows[i]["Gender"].ToString();
                    Obj_farmerdetails.MOBILE_NO = dtFarmerHeader.Rows[i]["Mobile_No"].ToString();
                    Obj_farmerdetails.FARMER_LATITUDE = dtFarmerHeader.Rows[i]["Latitude"].ToString();
                    Obj_farmerdetails.FARMER_LONGITUDE = dtFarmerHeader.Rows[i]["Longitude"].ToString();

                    try
                    {
                        var bankdtls = (from e in dtFarmerBankDetailNew.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (bankdtls.Count != 0)
                        {
                            List<FarmerBankdetails> objFarmerBank = new List<FarmerBankdetails>();
                            DataTable dt = dtFarmerBankDetailNew.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FarmerBankdetails objFarmerbnk = new FarmerBankdetails();
                                objFarmerbnk.ACCOUNTNO = dt.Rows[j]["BankAccoutNo"].ToString();
                                objFarmerbnk.ACCOUNTTYPE = dt.Rows[j]["BankAccountType"].ToString();
                                objFarmerbnk.BANK = dt.Rows[j]["Bankcode"].ToString();
                                objFarmerbnk.BRANCH= dt.Rows[j]["Branch"].ToString();
                                objFarmerbnk.IFSCCODE = dt.Rows[j]["IFSCCode"].ToString();
                                objFarmerbnk.DEFAULTDEBITACCOUT = dt.Rows[j]["DefaultDebitAccout"].ToString();
                                objFarmerbnk.DEFAULTCREDITACCOUT = dt.Rows[j]["DefaultCreditAccout"].ToString();
                                objFarmerBank.Add(objFarmerbnk);
                            }
                            Obj_farmerdetails.FARMERBANKLDETAILS = objFarmerBank;
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                    try
                    {
                        var kycdtls = (from e in dtFarmerKYCDetailNew.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (kycdtls.Count != 0)
                        {
                            List<FarmerkYCDetails> objKYCDetails = new List<FarmerkYCDetails>();
                            DataTable dt = dtFarmerKYCDetailNew.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FarmerkYCDetails objFarmerkyc = new FarmerkYCDetails();
                                objFarmerkyc.PROOFTYPE = dt.Rows[j]["ProofType"].ToString();
                                objFarmerkyc.PROOFSUBTYPE = dt.Rows[j]["ProofSubType"].ToString();
                                objFarmerkyc.DOCUMENTNO = dt.Rows[j]["DocumentNo"].ToString();
                                objFarmerkyc.CONFIRMDOCUMENTNO = dt.Rows[j]["ConfirmDocumentNo"].ToString();
                                if (!string.IsNullOrEmpty((dt.Rows[j]["ValidTill"].ToString())))
                                {
                                    objFarmerkyc.VALIDTILL = Convert.ToDateTime(dt.Rows[j]["ValidTill"].ToString());
                                }
                               // objFarmerkyc.VALIDTILL= Convert.ToDateTime(dt.Rows[j]["ValidTill"].ToString());
                                objKYCDetails.Add(objFarmerkyc);
                            }
                            Obj_farmerdetails.FARMERKYCDETAILS = objKYCDetails;
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                    try
                    {
                        var personaldtls = (from e in dtFarmerPersonalDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (personaldtls.Count != 0)
                        {
                            List<FarmerPersonalDetailsNew> objpersonal = new List<FarmerPersonalDetailsNew>();
                            DataTable dt = dtFarmerPersonalDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FarmerPersonalDetailsNew objFarmerPersonal = new FarmerPersonalDetailsNew();
                                objFarmerPersonal.MARITALSTATUS = dt.Rows[j]["MaritalStatus"].ToString();
                                objFarmerPersonal.MOBILE = dt.Rows[j]["Mobile"].ToString();
                                objFarmerPersonal.EMAILID = dt.Rows[j]["EmailID"].ToString();
                                objFarmerPersonal.LANDLINE = dt.Rows[j]["Landline"].ToString();
                                objFarmerPersonal.QUALIFICATION = dt.Rows[j]["Qualification"].ToString();
                                objFarmerPersonal.CASTE = dt.Rows[j]["Caste"].ToString();
                                objFarmerPersonal.RELIGION = dt.Rows[j]["Religion"].ToString();
                                objFarmerPersonal.MINORITY = dt.Rows[j]["Minority"].ToString();
                                objpersonal.Add(objFarmerPersonal);
                            }
                            Obj_farmerdetails.FARMERPERSONALDETAILS = objpersonal;
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }

                    try
                    {
                        var addressdtls = (from e in dtFarmerAddressDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (addressdtls.Count != 0)
                        {
                            List<FarmerAddressDetailsNew> objAddress = new List<FarmerAddressDetailsNew>();
                            DataTable dt = dtFarmerAddressDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FarmerAddressDetailsNew objFarmerAddress = new FarmerAddressDetailsNew();
                                objFarmerAddress.ADDRESSTYPE = dt.Rows[j]["AddressType"].ToString();
                                objFarmerAddress.ADDRESS = dt.Rows[j]["Address"].ToString();
                                objFarmerAddress.PINCODE = Convert.ToInt32(dt.Rows[j]["Pincode"].ToString() == "" ? "0" : dt.Rows[j]["Pincode"].ToString());
                                objFarmerAddress.COUNTRY = dt.Rows[j]["Country"].ToString();
                                objFarmerAddress.STATE = dt.Rows[j]["State"].ToString();
                                objFarmerAddress.DISTRICT = dt.Rows[j]["District"].ToString();
                                objFarmerAddress.TALUK = dt.Rows[j]["Taluk"].ToString();
                                objFarmerAddress.VILLAGE = dt.Rows[j]["Village"].ToString();
                                objAddress.Add(objFarmerAddress);
                            }
                            Obj_farmerdetails.FARMERADDRESSDETAILS = objAddress;
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                    try
                    {
                        var famdtl = (from e in dtFarmerFamilyDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (famdtl.Count != 0)
                        {
                            List<FarmerFamilyDetailsNew> objFamily = new List<FarmerFamilyDetailsNew>();
                            DataTable dt = dtFarmerFamilyDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FarmerFamilyDetailsNew objfam = new FarmerFamilyDetailsNew();
                                if (!string.IsNullOrEmpty((dt.Rows[j]["DOB"].ToString())))
                                {
                                    objfam.DOB = Convert.ToDateTime(dt.Rows[j]["DOB"].ToString());
                                }
                              //  objfam.DOB = Convert.ToDateTime(dt.Rows[j]["DOB"].ToString());
                                objfam.GENDER = dt.Rows[j]["Gender"].ToString();
                                objfam.RELATIONSHIP = dt.Rows[j]["Relationship"].ToString();
                                objfam.QUALIFICATION = dt.Rows[j]["Qualification"].ToString();
                                objfam.OCCUPATION = dt.Rows[j]["Occupation"].ToString();
                                objfam.FAMILYTYPE = dt.Rows[j]["FamilyType"].ToString();
                                objfam.FAMILYMEMBER = dt.Rows[j]["MemberName"].ToString();
                                objFamily.Add(objfam);
                            }
                            Obj_farmerdetails.FARMERFAMILYDETAILS = objFamily;
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }

                    try
                    {
                        var loandtl = (from e in dtFarmerLoanDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (loandtl.Count != 0)
                        {
                            List<FarmerLoanDetailsNew> objLoan = new List<FarmerLoanDetailsNew>();
                            DataTable dt = dtFarmerLoanDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FarmerLoanDetailsNew objln = new FarmerLoanDetailsNew();
                                objln.LOANTYPE = dt.Rows[j]["LoanType"].ToString();
                                objln.LOANFROM = dt.Rows[j]["LoanFrom"].ToString();
                                objln.INSTITUTIONNAME = dt.Rows[j]["InstitutionName"].ToString();
                                objln.BRANCH = dt.Rows[j]["InstitutionBranch"].ToString();
                                objln.LOANACCOUNTNO = dt.Rows[j]["LoanAccountNo"].ToString();
                                if (!string.IsNullOrEmpty((dt.Rows[j]["StartDate"].ToString())))
                                {
                                    objln.STARTDATE = Convert.ToDateTime(dt.Rows[j]["StartDate"].ToString());
                                }
                                if (!string.IsNullOrEmpty((dt.Rows[j]["EndDate"].ToString())))
                                {
                                    objln.ENDDATE = Convert.ToDateTime(dt.Rows[j]["EndDate"].ToString());
                                }
                                objln.STARTDATE = Convert.ToDateTime(dt.Rows[j]["StartDate"].ToString());
                                objln.ENDDATE = Convert.ToDateTime(dt.Rows[j]["EndDate"].ToString());
                                objln.LOANAMOUNT = Convert.ToDecimal(dt.Rows[j]["LoanAmount"].ToString() == "" ? "0.00" : dt.Rows[j]["LoanAmount"].ToString());
                                objln.INTERESTRATE = Convert.ToDecimal(dt.Rows[j]["InterestRate"].ToString() == "" ? "0.00" : dt.Rows[j]["InterestRate"].ToString());
                                objln.TENOR = dt.Rows[j]["LoanTenor"].ToString();
                                objln.EMI = dt.Rows[j]["EMI"].ToString();
                                objLoan.Add(objln);
                            }
                            Obj_farmerdetails.FARMERLOANDETAILS = objLoan;
                        }

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }

                    try
                    {
                        var loanrepaydtl = (from e in dtFarmerLoanRepaymentDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (loanrepaydtl.Count != 0)
                        {
                            List<FarmerLoanRepaymentDetailsNew> objLoanRepay = new List<FarmerLoanRepaymentDetailsNew>();
                            DataTable dt = dtFarmerLoanRepaymentDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FarmerLoanRepaymentDetailsNew objlnrapay = new FarmerLoanRepaymentDetailsNew();
                                objlnrapay.LOANACCOUNTNO = dt.Rows[j]["AccountNo"].ToString();
                                objlnrapay.REPAYMENTMODE = dt.Rows[j]["RepayMode"].ToString();
                                if (!string.IsNullOrEmpty((dt.Rows[j]["RepaymentDate"].ToString())))
                                {
                                    objlnrapay.REPAYMENTDATE = Convert.ToDateTime(dt.Rows[j]["RepaymentDate"].ToString());
                                }
                               // objlnrapay.REPAYMENTDATE = Convert.ToDateTime(dt.Rows[j]["RepaymentDate"].ToString());
                                objlnrapay.REPAYMENTAMT = dt.Rows[j]["Amount"].ToString();
                                objLoanRepay.Add(objlnrapay);
                            }
                            Obj_farmerdetails.FARMERLOANREPAYMENTDETAILS = objLoanRepay;
                        }

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }

                    try
                    {
                        var landdtl = (from e in dtFarmerLandDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (landdtl.Count != 0)
                        {
                            List<FarmerLandDetailsNew> objLand = new List<FarmerLandDetailsNew>();
                            DataTable dt = dtFarmerLandDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FarmerLandDetailsNew objlnd = new FarmerLandDetailsNew();
                                objlnd.LANDTYPE = dt.Rows[j]["LandType"].ToString();
                                objlnd.OWNERSHIP = dt.Rows[j]["Ownership"].ToString();
                                objlnd.NOOFACRES = Convert.ToDecimal(dt.Rows[j]["NoOfAcres"].ToString() == "" ? "0" : dt.Rows[j]["NoOfAcres"].ToString());
                                objlnd.SOILTYPE = dt.Rows[j]["SoilType"].ToString();
                                objlnd.IRRIGATIONSOURCE = dt.Rows[j]["IrrigationSource"].ToString();
                                objlnd.LATITUDE = dt.Rows[j]["Latitude"].ToString();
                                objlnd.LONGITUDE = dt.Rows[j]["Longitude"].ToString();
                                objlnd.VILLAGE = dt.Rows[j]["Village"].ToString();
                                objlnd.POLYHOUSE = dt.Rows[j]["Polyhouse"].ToString();
                                objlnd.SlNo = dt.Rows[j]["row_slno"].ToString(); //ramya added on 08 jun 21
                                objLand.Add(objlnd);
                            }
                            Obj_farmerdetails.FARMERLANDDETAILS = objLand;
                        }

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                    try
                    {
                        var livestokdtl = (from e in dtFarmerLiveStockDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (livestokdtl.Count != 0)
                        {
                            List<FarmerLiveStockDetailsNew> objLiveStock = new List<FarmerLiveStockDetailsNew>();
                            DataTable dt = dtFarmerLiveStockDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FarmerLiveStockDetailsNew objlive = new FarmerLiveStockDetailsNew();
                                objlive.LIVESTOCKTYPE = dt.Rows[j]["LivestockType"].ToString();
                                objlive.LIVESTOCKSUBTYPE = dt.Rows[j]["LivestockSubType"].ToString();
                                objlive.OWNERSHIP = dt.Rows[j]["Ownership"].ToString();
                                objlive.NUMBERPROCESSED = Convert.ToInt32(dt.Rows[j]["NumberPossessed"].ToString() == "" ? "0" : dt.Rows[j]["NumberPossessed"].ToString());
                                objlive.PURPOSE = dt.Rows[j]["Purpose"].ToString();
                                objLiveStock.Add(objlive);
                            }
                            Obj_farmerdetails.FARMERLIVESTOCKDETAILS = objLiveStock;
                        }

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                    try
                    {
                        var assetdtls = (from e in dtFarmerAssetsDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (assetdtls.Count != 0)
                        {
                            List<FarmerAssetsDetailsNew> objAssetDtl = new List<FarmerAssetsDetailsNew>();
                            DataTable dt = dtFarmerAssetsDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FarmerAssetsDetailsNew objasst = new FarmerAssetsDetailsNew();
                                objasst.ASSETTYPE = dt.Rows[j]["AssetType"].ToString();
                                objasst.ASSETSUBTYPE = dt.Rows[j]["AssetSubType"].ToString();
                                if (!string.IsNullOrEmpty((dt.Rows[j]["PurchaseDate"].ToString())))
                                {
                                    objasst.PURCHASEDATE = Convert.ToDateTime(dt.Rows[j]["PurchaseDate"].ToString());
                                }
                                //objasst.PURCHASEDATE = Convert.ToDateTime(dt.Rows[j]["PurchaseDate"].ToString());
                                objasst.NOOFASSETS = Convert.ToInt32(dt.Rows[j]["NoofAssets"].ToString() == "" ? "0" : dt.Rows[j]["NoofAssets"].ToString());
                                objasst.ASSET_SL_NO = dt.Rows[j]["AssetSerialNo"].ToString();
                                objasst.PURPOSE = dt.Rows[j]["Purpose"].ToString();
                                objAssetDtl.Add(objasst);
                            }
                            Obj_farmerdetails.FARMERASSETSDETAILS = objAssetDtl;
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                    try
                    {
                        var isurancedtls = (from e in dtFarmerInsuranceDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (isurancedtls.Count != 0)
                        {
                            List<FarmerInsuranceDetailsNew> objInsuranceDtl = new List<FarmerInsuranceDetailsNew>();
                            DataTable dt = dtFarmerInsuranceDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FarmerInsuranceDetailsNew objinsur = new FarmerInsuranceDetailsNew();
                                objinsur.INSURERTYPE = dt.Rows[j]["InsurerType"].ToString();
                                objinsur.INSURERNAME = dt.Rows[j]["InsurerName"].ToString();
                                objinsur.AGENCYNAME= dt.Rows[j]["AgencyName"].ToString();
                                objinsur.POLICYNO = dt.Rows[j]["PolicyNo"].ToString();
                                objinsur.INSUREDON = dt.Rows[j]["InsuredOn"].ToString();
                                if (!string.IsNullOrEmpty((dt.Rows[j]["PolicyDate"].ToString())))
                                {
                                    objinsur.POLICYDATE = Convert.ToDateTime(dt.Rows[j]["PolicyDate"].ToString());
                                }
                                if (!string.IsNullOrEmpty((dt.Rows[j]["MaturityDate"].ToString())))
                                {
                                    objinsur.MATURITYDATE = Convert.ToDateTime(dt.Rows[j]["MaturityDate"].ToString());
                                }
                               // objinsur.POLICYDATE = Convert.ToDateTime(dt.Rows[j]["PolicyDate"].ToString());
                                //objinsur.MATURITYDATE = Convert.ToDateTime(dt.Rows[j]["MaturityDate"].ToString());
                                objinsur.PREMIUM = dt.Rows[j]["Premium"].ToString();
                                objinsur.PAYMODE = dt.Rows[j]["PayMode"].ToString();
                                objinsur.NOMINEE = dt.Rows[j]["Nominee"].ToString();
                                objInsuranceDtl.Add(objinsur);

                            }
                            Obj_farmerdetails.FARMERINSURANCEDETAILS = objInsuranceDtl;
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                    try
                    {
                        var cropdtl = (from e in dtFarmerCroppingDetailsNew.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (cropdtl.Count != 0)
                        {
                            List<FarmerCroppingDetailsNew> objCrop = new List<FarmerCroppingDetailsNew>();
                            DataTable dt = dtFarmerCroppingDetailsNew.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FarmerCroppingDetailsNew objcrp = new FarmerCroppingDetailsNew();
                                objcrp.YEAR = dt.Rows[j]["Year"].ToString();
                                objcrp.SEASON = dt.Rows[j]["Season"].ToString();
                                objcrp.CROPTYPE = dt.Rows[j]["CropType"].ToString();
                                objcrp.VARIETY = dt.Rows[j]["Variety"].ToString();
                                objcrp.LANDTYPE = dt.Rows[j]["LandType"].ToString();
                                objcrp.LANDSIZE = Convert.ToDecimal(dt.Rows[j]["LandSize"].ToString() == "" ? "0.00" : dt.Rows[j]["LandSize"].ToString());
                                objCrop.Add(objcrp);

                            }
                            Obj_farmerdetails.FARMERCROPPINGDETAILS = objCrop;
                        }

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                    try
                    { 
                        var sowingdtl = (from e in dtFarmerSowingDetailsNew.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (sowingdtl.Count != 0)
                        {
                            List<FarmerSowingDetailsNew> objSowing = new List<FarmerSowingDetailsNew>();
                            DataTable dt = dtFarmerSowingDetailsNew.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FarmerSowingDetailsNew objsow = new FarmerSowingDetailsNew();
                                objsow.YEAR = dt.Rows[j]["Year"].ToString();                               
                                objsow.SEASON = dt.Rows[j]["Season"].ToString();
                                objsow.CROPCLASS = dt.Rows[j]["CropClass"].ToString();
                                objsow.CROPTYPE = dt.Rows[j]["CropType"].ToString();
                                objsow.VARIETY = dt.Rows[j]["Variety"].ToString();
                                objsow.SEEDNAME = dt.Rows[j]["SeedName"].ToString(); 
                                objsow.SEEDQTY = Convert.ToDecimal(dt.Rows[j]["SeedQty"].ToString() == "" ? "0.00" : dt.Rows[j]["SeedQty"].ToString());
                                objsow.SOWINGAREA = Convert.ToDecimal(dt.Rows[j]["SowingArea"].ToString() == "" ? "0.00" : dt.Rows[j]["SowingArea"].ToString());
                                objsow.EXPECTEDYIELD = Convert.ToDecimal(dt.Rows[j]["ExpectedYield"].ToString() == "" ? "0.00" : dt.Rows[j]["ExpectedYield"].ToString());
                               // objsow.SURPLUS = Convert.ToDecimal(dt.Rows[j]["Surplus"].ToString() == "" ? "0.00" : dt.Rows[j]["Surplus"].ToString());
                                objsow.EXPECTEDPRICE = Convert.ToDecimal(dt.Rows[j]["ExpectedPrice"].ToString() == "" ? "0.00" : dt.Rows[j]["ExpectedPrice"].ToString());
                                objsow.EXPECYIELDTOBESOLD = Convert.ToDecimal(dt.Rows[j]["ExpectedYieldSold"].ToString() == "" ? "0.00" : dt.Rows[j]["ExpectedYieldSold"].ToString());
                                 if (!string.IsNullOrEmpty((dt.Rows[j]["SowingDate"].ToString())))
                                {
                                    objsow.SOWINGDATE = Convert.ToDateTime(dt.Rows[j]["SowingDate"].ToString());
                                }

                                ////objsow.LANDTYPE = dt.Rows[j]["LandType"].ToString();
                                ////objsow.MONTH = dt.Rows[j]["Month"].ToString();
                                // objsow.TRANSACTIONDATE = Convert.ToDateTime(dt.Rows[j]["TransactionDate"].ToString());
                                //  objsow.DWEEDINGDATE = Convert.ToDateTime(dt.Rows[j]["DweedingDate"].ToString());
                                ////if (!string.IsNullOrEmpty((dt.Rows[j]["TransactionDate"].ToString())))
                                ////{
                                ////    objsow.TRANSACTIONDATE = Convert.ToDateTime(dt.Rows[j]["TransactionDate"].ToString());
                                ////}

                                ////if (!string.IsNullOrEmpty((dt.Rows[j]["DweedingDate"].ToString())))
                                ////{
                                ////    objsow.DWEEDINGDATE = Convert.ToDateTime(dt.Rows[j]["DweedingDate"].ToString());
                                ////}
                                ////if (!string.IsNullOrEmpty((dt.Rows[j]["HarvestDate"].ToString())))
                                ////{
                                ////    objsow.HARVESTDATE = Convert.ToDateTime(dt.Rows[j]["HarvestDate"].ToString());
                                ////}
                                // objsow.HARVESTDATE = Convert.ToDateTime(dt.Rows[j]["HarvestDate"].ToString());
                               
                                objSowing.Add(objsow);
                            }
                            Obj_farmerdetails.FARMERSOWINGDETAILS = objSowing;
                        }

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                    try
                    {
                        var inputdtl = (from e in dtFarmerInputDetailsNew.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (inputdtl.Count != 0)
                        {
                            List<FarmerInputDetailsNew> objInputDet = new List<FarmerInputDetailsNew>();
                            DataTable dt = dtFarmerInputDetailsNew.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FarmerInputDetailsNew objinpu = new FarmerInputDetailsNew();
                                objinpu.YEAR = dt.Rows[j]["Year"].ToString();
                                objinpu.SEASON = dt.Rows[j]["Season"].ToString();
                                objinpu.CROPTYPE = dt.Rows[j]["CropType"].ToString();
                                objinpu.VARIETY = dt.Rows[j]["Variety"].ToString();
                                objinpu.LANDTYPE = dt.Rows[j]["LandType"].ToString();
                                objinpu.QTY = Convert.ToInt32(dt.Rows[j]["Qty"].ToString() == "" ? "0" : dt.Rows[j]["Qty"].ToString());
                                objinpu.INPUTTYPE = dt.Rows[j]["InputType"].ToString();
                                objinpu.INPUTNAME = dt.Rows[j]["InputName"].ToString();
                                objinpu.USEDDATE = Convert.ToDateTime(dt.Rows[j]["UsedDate"].ToString());
                                objinpu.ICNAME = dt.Rows[j]["ICName"].ToString();
                                objinpu.REMARKS = dt.Rows[j]["Remarks"].ToString();
                                objinpu.RATE = Convert.ToDecimal(dt.Rows[j]["Rate"].ToString() == "" ? "0.00" : dt.Rows[j]["Rate"].ToString());
                                objinpu.AMOUNT = Convert.ToDecimal(dt.Rows[j]["Amount"].ToString() == "" ? "0.00" : dt.Rows[j]["Amount"].ToString());
                                objInputDet.Add(objinpu);
                            }
                            Obj_farmerdetails.FARMERINPUTDETAILS = objInputDet;
                        }

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                    try
                    {
                        var productiondtl = (from e in dtFarmerProductionDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (productiondtl.Count != 0)
                        {
                            List<FarmerProductionDetailsNew> objProduction = new List<FarmerProductionDetailsNew>();
                            DataTable dt = dtFarmerProductionDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FarmerProductionDetailsNew objprod = new FarmerProductionDetailsNew();
                                objprod.YEAR = dt.Rows[j]["Year"].ToString();
                                objprod.SEASON = dt.Rows[j]["Season"].ToString();
                                objprod.CROPTYPE = dt.Rows[j]["CropType"].ToString();
                                objprod.VARIETY = dt.Rows[j]["Variety"].ToString();
                               // objprod.LANDTYPE = dt.Rows[j]["LandType"].ToString();
                                objprod.ACTUALPRODUCTION = Convert.ToInt32(dt.Rows[j]["ActualProduction"].ToString() == "" ? "0" : dt.Rows[j]["ActualProduction"].ToString());
                                objprod.CROPCLASS = dt.Rows[j]["CropClass"].ToString();
                                objprod.SEEDNAME = dt.Rows[j]["SeedName"].ToString();
                                objprod.AVAILABLEFORSALE = dt.Rows[j]["AvailableForSale"].ToString();
                                objprod.LRPNAME = dt.Rows[j]["LRPName"].ToString();
                                objProduction.Add(objprod);
                            }
                            Obj_farmerdetails.FARMERPRODUCTIONDETAILS = objProduction;
                        }

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                    try
                    {
                        var saledtl = (from e in dtFarmerSaleDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (saledtl.Count != 0)
                        {
                            List<FarmerSaleDetailsNew> objSale = new List<FarmerSaleDetailsNew>();
                            DataTable dt = dtFarmerSaleDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FarmerSaleDetailsNew objsl = new FarmerSaleDetailsNew();
                                objsl.YEAR= dt.Rows[j]["Year"].ToString();
                                objsl.SEASON = dt.Rows[j]["Season"].ToString();
                                objsl.CROPTYPE = dt.Rows[j]["CropType"].ToString();
                                objsl.VARIETY = dt.Rows[j]["Variety"].ToString();
                                objsl.LANDTYPE = dt.Rows[j]["LandType"].ToString();
                                objsl.QUANTITY = Convert.ToInt32(dt.Rows[j]["Quantity"].ToString() == "" ? "0" : dt.Rows[j]["Quantity"].ToString());
                                objsl.SALEPRICE = Convert.ToDecimal(dt.Rows[j]["SalePrice"].ToString() == "" ? "0.00" : dt.Rows[j]["SalePrice"].ToString());
                                objsl.SALEVALUE = Convert.ToDecimal(dt.Rows[j]["SaleValue"].ToString() == "" ? "0.00" : dt.Rows[j]["SaleValue"].ToString());
                                objsl.BUYER = dt.Rows[j]["Buyer"].ToString();
                                objsl.TERMSOFPAYMENT = dt.Rows[j]["TermsofPayment"].ToString();
                                objsl.REMARKS = dt.Rows[j]["Remarks"].ToString();
                                objSale.Add(objsl);
                            }
                            Obj_farmerdetails.FARMERSALEDETAILS= objSale;
                        }

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                    try
                    {
                        var stockdtl = (from e in dtFarmerStockDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (stockdtl.Count != 0)
                        {
                            List<FarmerStockDetailsNew> objStock = new List<FarmerStockDetailsNew>();
                            DataTable dt = dtFarmerStockDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FarmerStockDetailsNew objstk = new FarmerStockDetailsNew();
                                objstk.YEAR = dt.Rows[j]["Year"].ToString();
                                objstk.SEASON = dt.Rows[j]["Season"].ToString();
                                objstk.CROPTYPE = dt.Rows[j]["CropType"].ToString();
                                objstk.VARIETY = dt.Rows[j]["Variety"].ToString();
                                objstk.LANDTYPE = dt.Rows[j]["LandType"].ToString();
                                objstk.STOCKUNSOLD = Convert.ToInt32(dt.Rows[j]["StockUnsold"].ToString() == "" ? "0" : dt.Rows[j]["StockUnsold"].ToString());
                                objStock.Add(objstk);
                            }
                            Obj_farmerdetails.FARMERSTOCKDETAILS = objStock;
                        }

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                    try
                    {
                        var trainingdtl = (from e in dtFarmerTrainingDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (trainingdtl.Count != 0)
                        {
                            List<FarmerTrainingDetailsNew> objTraining = new List<FarmerTrainingDetailsNew>();
                            DataTable dt = dtFarmerTrainingDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FarmerTrainingDetailsNew objtrain = new FarmerTrainingDetailsNew();
                                objtrain.YEAR = dt.Rows[j]["Year"].ToString();
                                objtrain.SEASON = dt.Rows[j]["Season"].ToString();
                                objtrain.AGENDA = dt.Rows[j]["Agenda"].ToString();
                                objtrain.DURATION = dt.Rows[j]["Duration"].ToString();
                                objtrain.PLACE = dt.Rows[j]["Place"].ToString();
                                if (!string.IsNullOrEmpty((dt.Rows[j]["TrainingDate"].ToString())))
                                {
                                    objtrain.TRAININGDATE = Convert.ToDateTime(dt.Rows[j]["TrainingDate"].ToString());
                                }
                               // objtrain.TRAININGDATE = Convert.ToDateTime(dt.Rows[j]["TrainingDate"].ToString());
                                objtrain.EXPERTDETAILS = dt.Rows[j]["ExpertDetails"].ToString();
                                objTraining.Add(objtrain);
                            }
                            Obj_farmerdetails.FARMERTRAININGDETAILS = objTraining;
                        }

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                    try
                    {
                        var shareholdingdtl = (from e in dtFarmerShareHoldingDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (shareholdingdtl.Count != 0)
                        {
                            List<FarmerShareHoldingDetailsNew> objShare = new List<FarmerShareHoldingDetailsNew>();
                            DataTable dt = dtFarmerShareHoldingDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FarmerShareHoldingDetailsNew objshr = new FarmerShareHoldingDetailsNew();
                                objshr.FPONAME = dt.Rows[j]["FPOName"].ToString();
                                objshr.FIGNAME = dt.Rows[j]["FIGName"].ToString();
                                objshr.SHARES = dt.Rows[j]["Shares"].ToString();
                                objshr.AMOUNT = dt.Rows[j]["Amount"].ToString();
                                objShare.Add(objshr);
                            }
                            Obj_farmerdetails.FARMERSHAREHOLDINGDETAILS = objShare;
                        }

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                    try
                    {
                        var businnessdtl = (from e in dtFarmerBusinessDetailsNew.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (businnessdtl.Count != 0)
                        {
                            List<FarmerBusinessDetailsNew> objBusiness = new List<FarmerBusinessDetailsNew>();
                            DataTable dt = dtFarmerBusinessDetailsNew.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FarmerBusinessDetailsNew objbuss = new FarmerBusinessDetailsNew();
                                objbuss.BUSINESSSEGMENT = dt.Rows[j]["BusinessSegment"].ToString();
                                objbuss.DESCRIPTION = dt.Rows[j]["Description"].ToString();
                                objbuss.PERIOD = Convert.ToDateTime(dt.Rows[j]["Period"].ToString());
                                objbuss.AMOUNT = dt.Rows[j]["Amount"].ToString();
                                objBusiness.Add(objbuss);
                            }
                            Obj_farmerdetails.FARMERBUSINESSDETAILS = objBusiness;
                        }

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                    try
                    {
                        var loanrequiredtl = (from e in dtFarmerLoanRequirementDetails.AsEnumerable() where e.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (loanrequiredtl.Count != 0)
                        {
                            List<FarmerLoanRequirementDetailsNew> objLoanRequirement = new List<FarmerLoanRequirementDetailsNew>();
                            DataTable dt = dtFarmerLoanRequirementDetails.AsEnumerable().Where(r => r.Field<string>("FarmerCode") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FarmerLoanRequirementDetailsNew objloanreq = new FarmerLoanRequirementDetailsNew();
                                objloanreq.TYPEOFLOAN = dt.Rows[j]["TypeOfLoan"].ToString();
                                objloanreq.DESCRIPTION = dt.Rows[j]["Description"].ToString();
                                objloanreq.WHENREQUIRED = dt.Rows[j]["WhenRequired"].ToString();
                                objloanreq.AMOUNT = dt.Rows[j]["Amount"].ToString();
                                objLoanRequirement.Add(objloanreq);
                            }
                            Obj_farmerdetails.FARMERLOANREQUIREMENTDETAILS= objLoanRequirement;
                        }

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex);
                    }
                    objFarmerHeader.Add(Obj_farmerdetails);
                }

                objFarmer.FARMERDATA = objFarmerHeader;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return objFarmer;
        }


        public GetFarmerInfoOdisha GetFarmerInfoOdisha(SMSGetFarmerInfoModelOdisha objInput,string FPO_CODE,string District,string Taluk,string Village, string ConString)
        {
            GetFarmerInfoOdisha objFarmer = new GetFarmerInfoOdisha();
            try
            {
                
                DataTable dt = objData.GetFarmerInfoOdisha(objInput, FPO_CODE, District, Taluk, Village, ConString);
                List<GetOdishaFarmers> objFarmerHeader = new List<GetOdishaFarmers>(); 
                for (int i = 0; i < dt.Rows.Count; i++)                {
                    GetOdishaFarmers Obj_farmerdetails = new GetOdishaFarmers();
                    Obj_farmerdetails.FPO_NAME = dt.Rows[i]["FPOName"].ToString();
                    Obj_farmerdetails.FARMER_NAME = dt.Rows[i]["farmer_name"].ToString();
                    Obj_farmerdetails.SUR_NAME = dt.Rows[i]["sur_name"].ToString();
                    Obj_farmerdetails.FHW_NAME = dt.Rows[i]["fhw_name"].ToString();
                    Obj_farmerdetails.DOB =  DateTime.ParseExact(dt.Rows[i]["dob"].ToString(),"dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);                    
                    Obj_farmerdetails.DISTRICT = dt.Rows[i]["farmer_dist"].ToString();
                    Obj_farmerdetails.TALUK = dt.Rows[i]["farmer_taluk"].ToString();
                    Obj_farmerdetails.GP = dt.Rows[i]["farmer_panchayat"].ToString();
                    Obj_farmerdetails.VILLAGE = dt.Rows[i]["farmer_village"].ToString();
                    Obj_farmerdetails.HAMLET = dt.Rows[i]["farmer_addr2"].ToString();
                    Obj_farmerdetails.PINCODE = dt.Rows[i]["farmer_pincode"].ToString();
                    Obj_farmerdetails.GENDER = dt.Rows[i]["gender_flag"].ToString();
                    Obj_farmerdetails.MOBILE_NO = dt.Rows[i]["reg_mobile_no"].ToString();
                    Obj_farmerdetails.FARMER_CODE = dt.Rows[i]["farmer_code"].ToString();
                    Obj_farmerdetails.GROUP_NAME = dt.Rows[i]["GroupName"].ToString();
                    Obj_farmerdetails.LOCAL_TRADERS_IN_HAMLET_NAME = dt.Rows[i]["LTHName"].ToString();
                    Obj_farmerdetails.LOCAL_TRADERS_IN_MOBILE_NO = dt.Rows[i]["LTHMobileNo"].ToString();
                    Obj_farmerdetails.NO_OF_MILLING_MACHINE_IN_VILLAGES = dt.Rows[i]["No_of_Milling_machine_in_villages"].ToString();
                    Obj_farmerdetails.NO_OF_TRACTORS_IN_VILLAGES = dt.Rows[i]["No_of_Tractors_in_Village"].ToString();
                    Obj_farmerdetails.DISTANCE_OF_WAREHOUSE = dt.Rows[i]["Distance_of_Warehouse"].ToString(); //Ramya Modified 01 Apr 21
                    Obj_farmerdetails.WAREHOUSE_TYPE = dt.Rows[i]["WareHouse_Type"].ToString();
                    Obj_farmerdetails.BANK_ACCOUNT = dt.Rows[i]["BANK_AC"].ToString();
                    Obj_farmerdetails.BANK_ACCOUNT_NO = dt.Rows[i]["Bank_Account_No"].ToString();
                    Obj_farmerdetails.BANK_NAME = dt.Rows[i]["Bank_Name"].ToString();
                    Obj_farmerdetails.BRANCH_NAME = dt.Rows[i]["Branch_Name"].ToString();
                    Obj_farmerdetails.IFSC_CODE = dt.Rows[i]["IFSC_Code"].ToString();
                    Obj_farmerdetails.CASTE = dt.Rows[i]["CASTE"].ToString();
                    Obj_farmerdetails.EDUCATION = dt.Rows[i]["Education"].ToString();
                    Obj_farmerdetails.LEAD_FARMER = dt.Rows[i]["LF"].ToString();
                    Obj_farmerdetails.AADHAR_NO = dt.Rows[i]["Aadhar_No"].ToString();
                    Obj_farmerdetails.FAMILY_NO = dt.Rows[i]["Family_No"].ToString();
                    Obj_farmerdetails.WORKING_NO = dt.Rows[i]["Working_No"].ToString();
                    Obj_farmerdetails.FAMILY_MEMBER_MIGRATED = dt.Rows[i]["family_member_migrated"].ToString();
                    Obj_farmerdetails.OTHER_INCOME_SOURCE_LABOUR = dt.Rows[i]["OISLabour"].ToString();
                    Obj_farmerdetails.OTHER_INCOME_SOURCE_JOB = dt.Rows[i]["OISJob"].ToString();
                    Obj_farmerdetails.OTHER_INCOME_SOURCE_BUSINESS = dt.Rows[i]["OISBusiness"].ToString();
                    Obj_farmerdetails.HOUSE = dt.Rows[i]["House"].ToString();
                    Obj_farmerdetails.TRACTOR = dt.Rows[i]["Tractor"].ToString();
                    Obj_farmerdetails.IRRIGATIONSOURCE_TUBEWELL = dt.Rows[i]["ISTubewell"].ToString();
                    Obj_farmerdetails.IRRIGATIONSOURCE_CANAL = dt.Rows[i]["ISCanal"].ToString();
                    Obj_farmerdetails.IRRIGATIONSOURCE_FARMPOND = dt.Rows[i]["F_Pond"].ToString();
                    Obj_farmerdetails.POP_INFORMATION_SOURCE_LOCAL_TRADER = dt.Rows[i]["PISLTrader"].ToString();
                    Obj_farmerdetails.POP_INFORMATION_SOURCE_GOVT = dt.Rows[i]["PISGOVT"].ToString();
                    Obj_farmerdetails.POP_INFORMATION_SOURCE_FPO = dt.Rows[i]["PISFpo"].ToString();
                    Obj_farmerdetails.SH_CARD = dt.Rows[i]["SHCard"].ToString();
                    Obj_farmerdetails.LARGE_RUMINANTS = dt.Rows[i]["Large_Ruminants"].ToString();
                    Obj_farmerdetails.POULTRY = dt.Rows[i]["Poultry"].ToString();
                    Obj_farmerdetails.SMALL_RUMINANTS = dt.Rows[i]["Small_Ruminants"].ToString();
                    Obj_farmerdetails.OWN_LAND_ACR = dt.Rows[i]["Own_land_Acr"].ToString();
                    Obj_farmerdetails.LEASE_LAND_ACR = dt.Rows[i]["Lease_land_Acr"].ToString();
                    Obj_farmerdetails.FY_2019_20_KHARIF_AREA_MAIZE = dt.Rows[i]["FY_2019_20_kharif_area_Maize"].ToString();
                    Obj_farmerdetails.FY_2019_20_KHARIF_AREA_PADDY = dt.Rows[i]["FY_2019_20_kharif_area_Paddy"].ToString();
                    Obj_farmerdetails.FY_2019_20_KHARIF_AREA_VEG = dt.Rows[i]["FY_2019_20_kharif_area_Veg"].ToString();
                    Obj_farmerdetails.FY_2020_21_KHARIF_AREA_MAIZE = dt.Rows[i]["FY_2020_21_kharif_area_Maize"].ToString();
                    Obj_farmerdetails.FY_2020_21_KHARIF_AREA_PADDY = dt.Rows[i]["FY_2020_21_kharif_area_Paddy"].ToString();
                    Obj_farmerdetails.FY_2020_21_KHARIF_AREA_VEG = dt.Rows[i]["FY_2020_21_kharif_area_Veg"].ToString();
                    Obj_farmerdetails.FY_2019_20_RABI_AREA_MAIZE = dt.Rows[i]["FY_2019_20_rabi_area_Maize"].ToString();
                    Obj_farmerdetails.FY_2019_20_RABI_AREA_PADDY = dt.Rows[i]["FY_2019_20_rabi_area_Paddy"].ToString();
                    Obj_farmerdetails.FY_2019_20_RABI_AREA_VEG = dt.Rows[i]["FY_2019_20_rabi_area_Veg"].ToString();
                    Obj_farmerdetails.FY_2020_21_RABI_AREA_MAIZE = dt.Rows[i]["FY_2020_21_rabi_area_Maize"].ToString();
                    Obj_farmerdetails.FY_2020_21_RABI_AREA_PADDY = dt.Rows[i]["FY_2020_21_rabi_area_Paddy"].ToString();
                    Obj_farmerdetails.FY_2020_21_RABI_AREA_VEG = dt.Rows[i]["FY_2020_21_rabi_area_Veg"].ToString();
                    Obj_farmerdetails.MAIZE_YIELD_QTL_ACRE = dt.Rows[i]["Maize_yield_qtl_acre"].ToString();
                    Obj_farmerdetails.MAIZE_YIELD_KH_RA = dt.Rows[i]["Maize_yield_Kh_Ra"].ToString();
                    Obj_farmerdetails.RAGI_2020_ACRE = dt.Rows[i]["Ragi_2020_Acre"].ToString();
                    Obj_farmerdetails.RAGI_2021_ACRE = dt.Rows[i]["Ragi_2021_Acre"].ToString();
                    Obj_farmerdetails.LIFE_INSURANCE = dt.Rows[i]["INS_Life"].ToString();
                    Obj_farmerdetails.HEALTH_INSURANCE = dt.Rows[i]["INS_Health"].ToString();
                    Obj_farmerdetails.CROP_INSURANCE = dt.Rows[i]["INS_Crop"].ToString();
                    Obj_farmerdetails.LOAN_VILLAGE = dt.Rows[i]["Loan_Vill"].ToString();
                    Obj_farmerdetails.LOAN_MFI = dt.Rows[i]["Loan_MFI"].ToString();
                    Obj_farmerdetails.LOAN_BANK = dt.Rows[i]["Loan_Bank"].ToString();
                    Obj_farmerdetails.KALIA = dt.Rows[i]["Kalia"].ToString();
                    Obj_farmerdetails.PM_KISAN_NIDHI = dt.Rows[i]["PM_Kisan_Nidhi"].ToString();
                    Obj_farmerdetails.REGISTRATION_IN_ENAM = dt.Rows[i]["eNAM_Reg"].ToString();
                    Obj_farmerdetails.REGISTRATION_IN_RMC = dt.Rows[i]["RMC_Reg"].ToString();
                    Obj_farmerdetails.INPUT_PURCHASE_FROM_LOCALTRADER = dt.Rows[i]["INPLTrader"].ToString();
                    Obj_farmerdetails.INPUT_PURCHASE_FROM_SOCIETY = dt.Rows[i]["INPSociety"].ToString();
                    Obj_farmerdetails.INPUT_PURCHASE_FROM_FPO = dt.Rows[i]["INPFPO"].ToString();
                    Obj_farmerdetails.MAIZE_SOLD_TO_LOCALTRADER = dt.Rows[i]["MSTLTrader"].ToString();
                    Obj_farmerdetails.MAIZE_SOLD_TO_RMC = dt.Rows[i]["MSTRMC"].ToString();
                    Obj_farmerdetails.MAIZE_SOLD_TO_FPO = dt.Rows[i]["MSTFPO"].ToString();
                    Obj_farmerdetails.SOURCE_OF_MARKET_PRICE_LOCALTRADER = dt.Rows[i]["SMPLTrader"].ToString();
                    Obj_farmerdetails.SOURCE_OF_MARKET_PRICE_RMC = dt.Rows[i]["SMPRMC"].ToString();
                    Obj_farmerdetails.SOURCE_OF_MARKET_PRICE_FPO = dt.Rows[i]["SMPFPO"].ToString();
                    Obj_farmerdetails.FPC_SHARE_PAID_RS = dt.Rows[i]["FPC_share_paid_Rs"].ToString();
                    Obj_farmerdetails.SHARE_CERTIFICATE = dt.Rows[i]["Share_Certificate"].ToString();
                    Obj_farmerdetails.SHARE_CERTIFICATE_NO = dt.Rows[i]["Share_Certificate_No"].ToString();
                    Obj_farmerdetails.OWN_MAIZE_STORAGE_KUCCHA = dt.Rows[i]["Own_Maize_storage_Kuccha"].ToString();
                    Obj_farmerdetails.OWN_MAIZE_STORAGE_PUCCA = dt.Rows[i]["Own_Maize_storage_Pucca"].ToString();
                    Obj_farmerdetails.DRYING_PRACTICES_ROAD = dt.Rows[i]["Drying_practices_Road"].ToString();
                    Obj_farmerdetails.DRYING_PRACTICES_KUCCHA = dt.Rows[i]["Drying_practices_Kuccha"].ToString();
                    Obj_farmerdetails.DRYING_PRACTICES_PUCCA = dt.Rows[i]["Drying_practices_Pucca"].ToString();
                    Obj_farmerdetails.DRYING_PRACTICES_PLATFORM = dt.Rows[i]["Drying_practices_Platform"].ToString();
                    Obj_farmerdetails.REASON_FOR_CROP_LOSS_WEATHER = dt.Rows[i]["Reason_for_crop_loss_Weather"].ToString();
                    Obj_farmerdetails.REASON_FOR_CROP_LOSS_PEST = dt.Rows[i]["Reason_for_crop_loss_Pest"].ToString();
                    Obj_farmerdetails.REASON_FOR_CROP_LOSS_PHM = dt.Rows[i]["Reason_for_crop_loss_PHM"].ToString();
                    Obj_farmerdetails.SHARE_OF_REASON_FOR_CROP_LOSS_WEATHER = dt.Rows[i]["share_of_RCLWeather"].ToString();
                    Obj_farmerdetails.SHARE_OF_REASON_FOR_CROP_LOSS_PEST = dt.Rows[i]["share_of_RCLPest"].ToString();
                    Obj_farmerdetails.SHARE_OF_REASON_FOR_CROP_LOSSL_PHM = dt.Rows[i]["share_of_RCLPHM"].ToString();
                    Obj_farmerdetails.INTERESTED_TO_SELL_TO_FPC = dt.Rows[i]["Interested_to_sell_to_FPC"].ToString();
                    Obj_farmerdetails.WHETHER_AGGREGATOR = dt.Rows[i]["Whether_Aggregator"].ToString();
                    Obj_farmerdetails.MAIZE_SOLD_IN_MONTH_0TO1 = dt.Rows[i]["of_maize_sold_in_Month_0_1"].ToString();
                    Obj_farmerdetails.MAIZE_SOLD_IN_MONTH_2TO3 = dt.Rows[i]["of_maize_sold_in_Month_2_3"].ToString();
                    Obj_farmerdetails.MAIZE_SOLD_IN_MONTH_3PLUS = dt.Rows[i]["of_maize_sold_in_Month_3"].ToString();
                    Obj_farmerdetails.FORM_OF_STORAGE_COB = dt.Rows[i]["Form_of_storage_Cob"].ToString();
                    Obj_farmerdetails.FORM_OF_STORAGE_LOOSE = dt.Rows[i]["Form_of_storage_Loose"].ToString();
                    Obj_farmerdetails.FORM_OF_STORAGE_BAGS = dt.Rows[i]["Form_of_storage_Bags"].ToString();
                    Obj_farmerdetails.SALE_OF_MAIZE_TO_HAT = dt.Rows[i]["sale_of_maize_to_Hat"].ToString();
                    Obj_farmerdetails.SALE_OF_MAIZE_TO_LOCALTRADER = dt.Rows[i]["sale_of_maize_to_LTrader"].ToString();
                    Obj_farmerdetails.SALE_OF_MAIZE_TO_RMC = dt.Rows[i]["sale_of_maize_to_RMC"].ToString();
                    Obj_farmerdetails.PAYMENT_RECEIVED_IN_DAYS_HAT = dt.Rows[i]["Payment_received_in_days_Hat"].ToString();
                    Obj_farmerdetails.PAYMENT_RECEIVED_IN_DAYS_LTRADER = dt.Rows[i]["Payment_received_in_days_LTrader"].ToString();
                    Obj_farmerdetails.PAYMENT_RECEIVED_IN_DAYS_RMC = dt.Rows[i]["Payment_received_in_days_RMC"].ToString();
                    Obj_farmerdetails.IDEA_OF_MAIZE_QC_MOISTURE = dt.Rows[i]["Idea_of_maize_QC_M"].ToString();
                    Obj_farmerdetails.IDEA_OF_MAIZE_QC_FUNGUS = dt.Rows[i]["Idea_of_maize_QC_F"].ToString();
                    Obj_farmerdetails.IDEA_OF_MAIZE_QC_DD = dt.Rows[i]["Idea_of_maize_QC_DD"].ToString();
                    Obj_farmerdetails.INTEREST_TO_CWH_SUBSIDY = dt.Rows[i]["Interest_to_WH_Subsidy"].ToString();
                    Obj_farmerdetails.INTEREST_TO_WR_FINANCE = dt.Rows[i]["Interest_to_WR_Finance"].ToString();
                    Obj_farmerdetails.CONCERN_LRP_ME = dt.Rows[i]["Concern_LRP_ME"].ToString();
                    objFarmerHeader.Add(Obj_farmerdetails);
                }
                objFarmer.ODISHAFARMER = objFarmerHeader;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return objFarmer;
        }
        public GetFarmerInfoOdisha GetFarmerInfoOdishaold(SMSGetFarmerInfoModel objInput, string ConString)
        {
            GetFarmerInfoOdisha objFarmer = new GetFarmerInfoOdisha();
            try
            {
                DataTable dt = objData.GetFarmerInfoOdishaold(objInput, ConString);

                List<GetOdishaFarmers> objFarmerHeader = new List<GetOdishaFarmers>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    GetOdishaFarmers Obj_farmerdetails = new GetOdishaFarmers();
                    Obj_farmerdetails.FARMER_CODE = dt.Rows[i]["farmer_code"].ToString();
                    Obj_farmerdetails.GROUP_NAME = dt.Rows[i]["EC_ADS_GROUPNAME"].ToString();
                    Obj_farmerdetails.LOCAL_TRADERS_IN_HAMLET_NAME = dt.Rows[i]["EC_ADS_LTHNAME"].ToString();
                    Obj_farmerdetails.LOCAL_TRADERS_IN_MOBILE_NO = dt.Rows[i]["EC_ADS_LTHMOBILENO"].ToString();
                    Obj_farmerdetails.NO_OF_MILLING_MACHINE_IN_VILLAGES = dt.Rows[i]["EC_ADS_NOOFMMACHINE"].ToString();
                    Obj_farmerdetails.NO_OF_TRACTORS_IN_VILLAGES = dt.Rows[i]["EC_ADS_NTRACTORVILL"].ToString();
                    Obj_farmerdetails.DISTANCE_OF_WAREHOUSE = dt.Rows[i]["EC_ADS_DISWAREHOUSE"].ToString();
                    Obj_farmerdetails.WAREHOUSE_TYPE = dt.Rows[i]["EC_ADS_WAREHOUSETYPE"].ToString();
                    Obj_farmerdetails.BANK_ACCOUNT = dt.Rows[i]["EC_ADS_BANKACC"].ToString();
                    Obj_farmerdetails.BANK_ACCOUNT_NO = dt.Rows[i]["EC_ADS_BankAccNo"].ToString();
                    Obj_farmerdetails.BANK_NAME = dt.Rows[i]["EC_ADS_BankName"].ToString();
                    Obj_farmerdetails.BRANCH_NAME = dt.Rows[i]["EC_ADS_BankBranName"].ToString();
                    Obj_farmerdetails.IFSC_CODE = dt.Rows[i]["EC_ADS_BankIFSC"].ToString();
                    Obj_farmerdetails.CASTE = dt.Rows[i]["EC_ADS_CASTE"].ToString();
                    Obj_farmerdetails.EDUCATION = dt.Rows[i]["EC_ADS_EDUCATION"].ToString();
                    Obj_farmerdetails.LEAD_FARMER = dt.Rows[i]["EC_ADS_LF"].ToString();
                    Obj_farmerdetails.AADHAR_NO = dt.Rows[i]["EC_ADS_AadharNo"].ToString();
                    Obj_farmerdetails.FAMILY_NO = dt.Rows[i]["EC_ADS_FamilyNo"].ToString();
                    Obj_farmerdetails.WORKING_NO = dt.Rows[i]["EC_ADS_WorkingNo"].ToString();
                    Obj_farmerdetails.FAMILY_MEMBER_MIGRATED = dt.Rows[i]["EC_ADS_NFMMIGRATED"].ToString();
                    Obj_farmerdetails.OTHER_INCOME_SOURCE_LABOUR = dt.Rows[i]["EC_ADS_OICLABOUR"].ToString();
                    Obj_farmerdetails.OTHER_INCOME_SOURCE_JOB = dt.Rows[i]["EC_ADS_OICJOB"].ToString();
                    Obj_farmerdetails.OTHER_INCOME_SOURCE_BUSINESS = dt.Rows[i]["EC_ADS_OICBusiness"].ToString();
                    Obj_farmerdetails.HOUSE = dt.Rows[i]["EC_ADS_HOUSE"].ToString();
                    Obj_farmerdetails.TRACTOR = dt.Rows[i]["EC_ADS_TRACTOR"].ToString();
                    Obj_farmerdetails.IRRIGATIONSOURCE_TUBEWELL = dt.Rows[i]["EC_ADS_ISTubewell"].ToString();
                    Obj_farmerdetails.IRRIGATIONSOURCE_CANAL = dt.Rows[i]["EC_ADS_ISCanal"].ToString();
                    Obj_farmerdetails.IRRIGATIONSOURCE_FARMPOND = dt.Rows[i]["EC_ADS_ISFPond"].ToString();
                    Obj_farmerdetails.POP_INFORMATION_SOURCE_LOCAL_TRADER = dt.Rows[i]["EC_ADS_PISTRADER"].ToString();
                    Obj_farmerdetails.POP_INFORMATION_SOURCE_GOVT = dt.Rows[i]["EC_ADS_PISGOVT"].ToString();
                    Obj_farmerdetails.POP_INFORMATION_SOURCE_FPO = dt.Rows[i]["EC_ADS_PISFPO"].ToString();
                    Obj_farmerdetails.SH_CARD = dt.Rows[i]["EC_ADS_SHCard"].ToString();
                    Obj_farmerdetails.LARGE_RUMINANTS = dt.Rows[i]["EC_ADS_Largeruminants"].ToString();
                    Obj_farmerdetails.POULTRY = dt.Rows[i]["EC_ADS_Poultry"].ToString();
                    Obj_farmerdetails.SMALL_RUMINANTS = dt.Rows[i]["EC_ADS_Smallruminants"].ToString();
                    Obj_farmerdetails.OWN_LAND_ACR = dt.Rows[i]["EC_ADS_Ownland"].ToString();
                    Obj_farmerdetails.LEASE_LAND_ACR = dt.Rows[i]["EC_ADS_Leaseland"].ToString();
                    Obj_farmerdetails.FY_2019_20_KHARIF_AREA_MAIZE = dt.Rows[i]["EC_ADS_19_20KA_MAIZE"].ToString();
                    Obj_farmerdetails.FY_2019_20_KHARIF_AREA_PADDY = dt.Rows[i]["EC_ADS_19_20KA_Paddy"].ToString();
                    Obj_farmerdetails.FY_2019_20_KHARIF_AREA_VEG = dt.Rows[i]["EC_ADS_19_20KA_Veg"].ToString();
                    Obj_farmerdetails.FY_2020_21_KHARIF_AREA_MAIZE = dt.Rows[i]["EC_ADS_20_21KA_MAIZE"].ToString();
                    Obj_farmerdetails.FY_2020_21_KHARIF_AREA_PADDY = dt.Rows[i]["EC_ADS_20_21KA_Paddy"].ToString();
                    Obj_farmerdetails.FY_2020_21_KHARIF_AREA_VEG = dt.Rows[i]["EC_ADS_20_21KA_Veg"].ToString();
                    Obj_farmerdetails.FY_2019_20_RABI_AREA_MAIZE = dt.Rows[i]["EC_ADS_19_20RA_MAIZE"].ToString();
                    Obj_farmerdetails.FY_2019_20_RABI_AREA_PADDY = dt.Rows[i]["EC_ADS_19_20RA_Paddy"].ToString();
                    Obj_farmerdetails.FY_2019_20_RABI_AREA_VEG = dt.Rows[i]["EC_ADS_19_20RA_Veg"].ToString();
                    Obj_farmerdetails.FY_2020_21_RABI_AREA_MAIZE = dt.Rows[i]["EC_ADS_20_21RA_MAIZE"].ToString();
                    Obj_farmerdetails.FY_2020_21_RABI_AREA_PADDY = dt.Rows[i]["EC_ADS_20_21RA_Paddy"].ToString();
                    Obj_farmerdetails.FY_2020_21_RABI_AREA_VEG = dt.Rows[i]["EC_ADS_20_21RA_Veg"].ToString();
                    Obj_farmerdetails.MAIZE_YIELD_QTL_ACRE = dt.Rows[i]["EC_ADS_Maizeyieldqtlacre"].ToString();
                    Obj_farmerdetails.MAIZE_YIELD_KH_RA = dt.Rows[i]["EC_ADS_MaizeyieldKhRa"].ToString();
                    Obj_farmerdetails.RAGI_2020_ACRE = dt.Rows[i]["EC_ADS_Ragi2020"].ToString();
                    Obj_farmerdetails.RAGI_2021_ACRE = dt.Rows[i]["EC_ADS_Ragi2021"].ToString();
                    Obj_farmerdetails.LIFE_INSURANCE = dt.Rows[i]["EC_ADS_INSLife"].ToString();
                    Obj_farmerdetails.HEALTH_INSURANCE = dt.Rows[i]["EC_ADS_INSHealth"].ToString();
                    Obj_farmerdetails.CROP_INSURANCE = dt.Rows[i]["EC_ADS_INSCrop"].ToString();
                    Obj_farmerdetails.LOAN_VILLAGE = dt.Rows[i]["EC_ADS_LoanVill"].ToString();
                    Obj_farmerdetails.LOAN_MFI = dt.Rows[i]["EC_ADS_LoanMFI"].ToString();
                    Obj_farmerdetails.LOAN_BANK = dt.Rows[i]["EC_ADS_LoanBank"].ToString();
                    Obj_farmerdetails.KALIA = dt.Rows[i]["EC_ADS_Kalia"].ToString();
                    Obj_farmerdetails.PM_KISAN_NIDHI = dt.Rows[i]["EC_ADS_PMKisanNidhi"].ToString();
                    Obj_farmerdetails.REGISTRATION_IN_ENAM = dt.Rows[i]["EC_ADS_eNAMReg"].ToString();
                    Obj_farmerdetails.REGISTRATION_IN_RMC = dt.Rows[i]["EC_ADS_RMCReg"].ToString();
                    Obj_farmerdetails.INPUT_PURCHASE_FROM_LOCALTRADER = dt.Rows[i]["EC_ADS_INPLTRADER"].ToString();
                    Obj_farmerdetails.INPUT_PURCHASE_FROM_SOCIETY = dt.Rows[i]["EC_ADS_INPSOCIETY"].ToString();
                    Obj_farmerdetails.INPUT_PURCHASE_FROM_FPO = dt.Rows[i]["EC_ADS_INPFPO"].ToString();
                    Obj_farmerdetails.MAIZE_SOLD_TO_LOCALTRADER = dt.Rows[i]["EC_ADS_MSTLTRAADER"].ToString();
                    Obj_farmerdetails.MAIZE_SOLD_TO_RMC = dt.Rows[i]["EC_ADS_MSTRMC"].ToString();
                    Obj_farmerdetails.MAIZE_SOLD_TO_FPO = dt.Rows[i]["EC_ADS_MSTFPO"].ToString();
                    Obj_farmerdetails.SOURCE_OF_MARKET_PRICE_LOCALTRADER = dt.Rows[i]["EC_ADS_SMPLTRADER"].ToString();
                    Obj_farmerdetails.SOURCE_OF_MARKET_PRICE_RMC = dt.Rows[i]["EC_ADS_SMPRMC"].ToString();
                    Obj_farmerdetails.SOURCE_OF_MARKET_PRICE_FPO = dt.Rows[i]["EC_ADS_SMPFPO"].ToString();
                    Obj_farmerdetails.FPC_SHARE_PAID_RS = dt.Rows[i]["EC_ADS_FPCsharepaidRs"].ToString();
                    Obj_farmerdetails.SHARE_CERTIFICATE = dt.Rows[i]["EC_ADS_SHARECERT"].ToString();
                    Obj_farmerdetails.SHARE_CERTIFICATE_NO = dt.Rows[i]["EC_ADS_SHARECERTNO"].ToString();
                    Obj_farmerdetails.OWN_MAIZE_STORAGE_KUCCHA = dt.Rows[i]["EC_ADS_OMSKuccha"].ToString();
                    Obj_farmerdetails.OWN_MAIZE_STORAGE_PUCCA = dt.Rows[i]["EC_ADS_OMSPucca"].ToString();
                    Obj_farmerdetails.DRYING_PRACTICES_ROAD = dt.Rows[i]["EC_ADS_DPROAD"].ToString();
                    Obj_farmerdetails.DRYING_PRACTICES_KUCCHA = dt.Rows[i]["EC_ADS_DPKuccha"].ToString();
                    Obj_farmerdetails.DRYING_PRACTICES_PUCCA = dt.Rows[i]["EC_ADS_DPPucca"].ToString();
                    Obj_farmerdetails.DRYING_PRACTICES_PLATFORM = dt.Rows[i]["EC_ADS_DPPlatform"].ToString();
                    Obj_farmerdetails.REASON_FOR_CROP_LOSS_WEATHER = dt.Rows[i]["EC_ADS_RCLWeather"].ToString();
                    Obj_farmerdetails.REASON_FOR_CROP_LOSS_PEST = dt.Rows[i]["EC_ADS_RCLPest"].ToString();
                    Obj_farmerdetails.REASON_FOR_CROP_LOSS_PHM = dt.Rows[i]["EC_ADS_SRCLPHM"].ToString();
                    Obj_farmerdetails.SHARE_OF_REASON_FOR_CROP_LOSS_WEATHER = dt.Rows[i]["EC_ADS_SRCLWeather"].ToString();
                    Obj_farmerdetails.SHARE_OF_REASON_FOR_CROP_LOSS_PEST = dt.Rows[i]["EC_ADS_SRCLPest"].ToString();
                    Obj_farmerdetails.SHARE_OF_REASON_FOR_CROP_LOSSL_PHM = dt.Rows[i]["EC_ADS_SRCLPHM"].ToString();
                    Obj_farmerdetails.INTERESTED_TO_SELL_TO_FPC = dt.Rows[i]["EC_ADS_IFPC"].ToString();
                    Obj_farmerdetails.WHETHER_AGGREGATOR = dt.Rows[i]["EC_ADS_WhetherAggregator"].ToString();
                    Obj_farmerdetails.MAIZE_SOLD_IN_MONTH_0TO1 = dt.Rows[i]["EC_ADS_maizesoldMonth01"].ToString();
                    Obj_farmerdetails.MAIZE_SOLD_IN_MONTH_2TO3 = dt.Rows[i]["EC_ADS_maizesoldMonth13"].ToString();
                    Obj_farmerdetails.MAIZE_SOLD_IN_MONTH_3PLUS = dt.Rows[i]["EC_ADS_maizesoldMonth3"].ToString();
                    Obj_farmerdetails.FORM_OF_STORAGE_COB = dt.Rows[i]["EC_ADS_FSCob"].ToString();
                    Obj_farmerdetails.FORM_OF_STORAGE_LOOSE = dt.Rows[i]["EC_ADS_FSLoose"].ToString();
                    Obj_farmerdetails.FORM_OF_STORAGE_BAGS = dt.Rows[i]["EC_ADS_FSBags"].ToString();
                    Obj_farmerdetails.SALE_OF_MAIZE_TO_HAT = dt.Rows[i]["EC_ADS_SMHat"].ToString();
                    Obj_farmerdetails.SALE_OF_MAIZE_TO_LOCALTRADER = dt.Rows[i]["EC_ADS_SMLTRADER"].ToString();
                    Obj_farmerdetails.SALE_OF_MAIZE_TO_RMC = dt.Rows[i]["EC_ADS_SMRMC"].ToString();
                    Obj_farmerdetails.PAYMENT_RECEIVED_IN_DAYS_HAT = dt.Rows[i]["EC_ADS_PAYHAT"].ToString();
                    Obj_farmerdetails.PAYMENT_RECEIVED_IN_DAYS_LTRADER = dt.Rows[i]["EC_ADS_PAYLTRADER"].ToString();
                    Obj_farmerdetails.PAYMENT_RECEIVED_IN_DAYS_RMC = dt.Rows[i]["EC_ADS_PAYRMC"].ToString();
                    Obj_farmerdetails.IDEA_OF_MAIZE_QC_MOISTURE = dt.Rows[i]["EC_ADS_MAIZE_M"].ToString();
                    Obj_farmerdetails.IDEA_OF_MAIZE_QC_FUNGUS = dt.Rows[i]["EC_ADS_MAIZE_F"].ToString();
                    Obj_farmerdetails.IDEA_OF_MAIZE_QC_DD = dt.Rows[i]["EC_ADS_MAIZE_DD"].ToString();
                    Obj_farmerdetails.INTEREST_TO_CWH_SUBSIDY = dt.Rows[i]["EC_ADS_WHSubsidy"].ToString();
                    Obj_farmerdetails.INTEREST_TO_WR_FINANCE = dt.Rows[i]["EC_ADS_WRFinance"].ToString();
                    Obj_farmerdetails.CONCERN_LRP_ME = dt.Rows[i]["EC_ADS_ConcernLRPME"].ToString();
                    objFarmerHeader.Add(Obj_farmerdetails);
                }
                objFarmer.ODISHAFARMER = objFarmerHeader;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return objFarmer;
        }

        

        public DataTable GetFarmerBasicInfo(SMSGetFarmerInfoModel objInput,string orgn_code, string ConString)
        {
            string type = "PERSONAL_DETAIL";
            FarmerBasicInfoNew objFarmer = new FarmerBasicInfoNew();
            DataTable dtFarmerHeader = new DataTable();
            try
            {
                // objInput.StartDate = DateTime.ParseExact(objInput.StartDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                // objInput.EndDate = DateTime.ParseExact(objInput.EndDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                
                DataSet ds = objData.Fdr_GetFarmerInfO(objInput, type, orgn_code, ConString);
                dtFarmerHeader = ds.Tables[0];
               // DataTable dtFarmerPersonalDetails = ds.Tables[1]; 

                //List<FarmerHeaderBasicInfo> objFarmerHeader = new List<FarmerHeaderBasicInfo>();
                //for (int i = 0; i < dtFarmerHeader.Rows.Count; i++)
                //{
                //    FarmerHeaderBasicInfo Obj_farmerdetails = new FarmerHeaderBasicInfo();
                //    Obj_farmerdetails.FARMERCODE = dtFarmerHeader.Rows[i]["FarmerCode"].ToString();
                //    Obj_farmerdetails.FPONAME = dtFarmerHeader.Rows[i]["FPOName"].ToString();
                //    Obj_farmerdetails.FARMERNAME = dtFarmerHeader.Rows[i]["FarmerName"].ToString();
                //    Obj_farmerdetails.SUR_NAME = dtFarmerHeader.Rows[i]["Sur_Name"].ToString();
                //    Obj_farmerdetails.FATHER_NAME = dtFarmerHeader.Rows[i]["Father_Name"].ToString(); 
                //    Obj_farmerdetails.FARMER_DISTRICT = dtFarmerHeader.Rows[i]["Farmer_District"].ToString(); 
                //    Obj_farmerdetails.FARMER_VILLAGE = dtFarmerHeader.Rows[i]["Farmer_Village"].ToString(); 
                //    Obj_farmerdetails.GENDER = dtFarmerHeader.Rows[i]["Gender"].ToString();
                //    Obj_farmerdetails.MOBILE_NO = dtFarmerHeader.Rows[i]["Mobile_No"].ToString();
                    //Obj_farmerdetails.MARITALSTATUS = dtFarmerHeader.Rows[i]["MaritalStatus"].ToString();
                    //Obj_farmerdetails.MOBILE = dtFarmerHeader.Rows[i]["Mobile"].ToString();
                    //Obj_farmerdetails.EMAILID = dtFarmerHeader.Rows[i]["EmailID"].ToString();
                    //Obj_farmerdetails.LANDLINE = dtFarmerHeader.Rows[i]["Landline"].ToString();
                    //Obj_farmerdetails.QUALIFICATION = dtFarmerHeader.Rows[i]["Qualification"].ToString();
                    //Obj_farmerdetails.CASTE = dtFarmerHeader.Rows[i]["Caste"].ToString();
                    //Obj_farmerdetails.RELIGION = dtFarmerHeader.Rows[i]["Religion"].ToString();
                    //Obj_farmerdetails.MINORITY = dtFarmerHeader.Rows[i]["Minority"].ToString(); 
                //    Obj_farmerdetails.LATITUDE = dtFarmerHeader.Rows[i]["Latitude"].ToString();
                //    Obj_farmerdetails.LONGITUDE = dtFarmerHeader.Rows[i]["Longitude"].ToString();

                //    objFarmerHeader.Add(Obj_farmerdetails);
                //}

                //objFarmer.FARMERBASICINFODETAILS = objFarmerHeader;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return dtFarmerHeader;
        }

        public DataTable GetFarmerBankDetail(SMSGetFarmerInfoModel objInput,string orgn_code, string ConString)
        {
            string type = "BANK_DETAIL";
            FarmerBankInfoNew objFarmer = new FarmerBankInfoNew();
            DataTable dtFarmerHeader = new DataTable();
            try
            {
                // objInput.StartDate = DateTime.ParseExact(objInput.StartDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                // objInput.EndDate = DateTime.ParseExact(objInput.EndDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

                DataSet ds = objData.Fdr_GetFarmerInfO(objInput, type,orgn_code, ConString);
                dtFarmerHeader = ds.Tables[0];  
     //           List<FarmerHeaderBankInfo> objFarmerHeader = new List<FarmerHeaderBankInfo>();
     //           for (int i = 0; i < dtFarmerHeader.Rows.Count; i++)
     //           {
     //               FarmerHeaderBankInfo Obj_farmerdetails = new FarmerHeaderBankInfo();
     //               Obj_farmerdetails.ROW_ID = Convert.ToInt64(dtFarmerHeader.Rows[i]["Row_ID"].ToString());
     //               Obj_farmerdetails.FARMERCODE = dtFarmerHeader.Rows[i]["FarmerCode"].ToString();
     //               Obj_farmerdetails.FPONAME = dtFarmerHeader.Rows[i]["FPOName"].ToString();
     //               Obj_farmerdetails.FARMERNAME = dtFarmerHeader.Rows[i]["FarmerName"].ToString();
     //               Obj_farmerdetails.SUR_NAME = dtFarmerHeader.Rows[i]["Sur_Name"].ToString();
     //               Obj_farmerdetails.FATHER_NAME = dtFarmerHeader.Rows[i]["Father_Name"].ToString(); 
     //               Obj_farmerdetails.FARMER_DISTRICT = dtFarmerHeader.Rows[i]["Farmer_District"].ToString(); 
     //               Obj_farmerdetails.FARMER_VILLAGE = dtFarmerHeader.Rows[i]["Farmer_Village"].ToString(); 
     //               Obj_farmerdetails.GENDER = dtFarmerHeader.Rows[i]["Gender"].ToString();
     //               Obj_farmerdetails.MOBILE_NO = dtFarmerHeader.Rows[i]["Mobile_No"].ToString();
     //               //bankdetails
     //               Obj_farmerdetails.ACCOUNTNO = dtFarmerHeader.Rows[i]["BankAccoutNo"].ToString();
     //               Obj_farmerdetails.ACCOUNTTYPE = dtFarmerHeader.Rows[i]["BankAccountType"].ToString();
     //               Obj_farmerdetails.BANK = dtFarmerHeader.Rows[i]["Bankcode"].ToString();
     //               Obj_farmerdetails.BRANCH = dtFarmerHeader.Rows[i]["Branch"].ToString();
     //               Obj_farmerdetails.IFSCCODE = dtFarmerHeader.Rows[i]["IFSCCode"].ToString();
     //               Obj_farmerdetails.DEFAULTDEBITACCOUT = dtFarmerHeader.Rows[i]["DefaultDebitAccout"].ToString();
     //               Obj_farmerdetails.DEFAULTCREDITACCOUT = dtFarmerHeader.Rows[i]["DefaultCreditAccout"].ToString();
					//Obj_farmerdetails.LATITUDE = dtFarmerHeader.Rows[i]["Latitude"].ToString();
     //               Obj_farmerdetails.LONGITUDE = dtFarmerHeader.Rows[i]["Longitude"].ToString();
     //               objFarmerHeader.Add(Obj_farmerdetails);
     //           }
     //           objFarmer.FARMERBANKLDETAILS = objFarmerHeader;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return dtFarmerHeader;
        } 
        public DataTable GetFarmerKYCDetail(SMSGetFarmerInfoModel objInput, string orgn_code, string ConString)
        {
            string type = "KYC_DETAIL";
            FarmerKYCInfoNew objFarmer = new FarmerKYCInfoNew();
            DataTable dtFarmerHeader = new DataTable();
            try
            {
                // objInput.StartDate = DateTime.ParseExact(objInput.StartDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                // objInput.EndDate = DateTime.ParseExact(objInput.EndDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

                DataSet ds = objData.Fdr_GetFarmerInfO(objInput, type,orgn_code, ConString);
                 dtFarmerHeader = ds.Tables[0];  

                //List<FarmerHeaderKYCInfo> objFarmerHeader = new List<FarmerHeaderKYCInfo>();
                //for (int i = 0; i < dtFarmerHeader.Rows.Count; i++)
                //{
                //    FarmerHeaderKYCInfo Obj_farmerdetails = new FarmerHeaderKYCInfo();
                //    Obj_farmerdetails.ROW_ID = Convert.ToInt64(dtFarmerHeader.Rows[i]["Row_ID"].ToString());
                //    Obj_farmerdetails.FARMERCODE = dtFarmerHeader.Rows[i]["FarmerCode"].ToString();
                //    Obj_farmerdetails.FPONAME = dtFarmerHeader.Rows[i]["FPOName"].ToString();
                //    Obj_farmerdetails.FARMERNAME = dtFarmerHeader.Rows[i]["FarmerName"].ToString();
                //    Obj_farmerdetails.SUR_NAME = dtFarmerHeader.Rows[i]["Sur_Name"].ToString();
                //    Obj_farmerdetails.FATHER_NAME = dtFarmerHeader.Rows[i]["Father_Name"].ToString();
                //    Obj_farmerdetails.FARMER_DISTRICT = dtFarmerHeader.Rows[i]["Farmer_District"].ToString();
                //    Obj_farmerdetails.FARMER_VILLAGE = dtFarmerHeader.Rows[i]["Farmer_Village"].ToString();
                //    Obj_farmerdetails.GENDER = dtFarmerHeader.Rows[i]["Gender"].ToString();
                //    Obj_farmerdetails.MOBILE_NO = dtFarmerHeader.Rows[i]["Mobile_No"].ToString();
                //    //Kyc Details
                //    Obj_farmerdetails.PROOFTYPE = dtFarmerHeader.Rows[i]["ProofType"].ToString();
                //    Obj_farmerdetails.PROOFSUBTYPE = dtFarmerHeader.Rows[i]["ProofSubType"].ToString();
                //    Obj_farmerdetails.DOCUMENTNO = dtFarmerHeader.Rows[i]["DocumentNo"].ToString();
                //    Obj_farmerdetails.CONFIRMDOCUMENTNO = dtFarmerHeader.Rows[i]["ConfirmDocumentNo"].ToString();
                //    if (!string.IsNullOrEmpty((dtFarmerHeader.Rows[i]["ValidTill"].ToString())))
                //    {  
                //        Obj_farmerdetails.VALIDTILL = DateTime.ParseExact(dtFarmerHeader.Rows[i]["ValidTill"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                //        // Obj_farmerdetails.VALIDTILL = Convert.ToString(dtFarmerHeader.Rows[i]["ValidTill"].ToString());
                //    }
                //     Obj_farmerdetails.LATITUDE = dtFarmerHeader.Rows[i]["Latitude"].ToString();
                //    Obj_farmerdetails.LONGITUDE = dtFarmerHeader.Rows[i]["Longitude"].ToString();
                //    objFarmerHeader.Add(Obj_farmerdetails);
                //}

                //objFarmer.FARMERKYCDETAILS = objFarmerHeader;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return dtFarmerHeader;
        }

        public DataTable GetFarmerLandDetails(SMSGetFarmerInfoModel objInput, string orgn_code, string ConString)
        {
            string type = "LAND_DETAIL";
            FarmerLandInfoNew objFarmer = new FarmerLandInfoNew();
            DataTable dtFarmerHeader = new DataTable();
            try
            {
                // objInput.StartDate = DateTime.ParseExact(objInput.StartDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                // objInput.EndDate = DateTime.ParseExact(objInput.EndDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

                DataSet ds = objData.Fdr_GetFarmerInfO(objInput, type,orgn_code, ConString);
                dtFarmerHeader = ds.Tables[0]; 

                //List<FarmerHeaderLandInfo> objFarmerHeader = new List<FarmerHeaderLandInfo>();
                //for (int i = 0; i < dtFarmerHeader.Rows.Count; i++)
                //{
                //    FarmerHeaderLandInfo Obj_farmerdetails = new FarmerHeaderLandInfo();
                //    Obj_farmerdetails.FARMERCODE = dtFarmerHeader.Rows[i]["FarmerCode"].ToString();
                //    Obj_farmerdetails.ROW_SlNo = Convert.ToInt64(dtFarmerHeader.Rows[i]["row_slno"].ToString());
                //    Obj_farmerdetails.FPONAME = dtFarmerHeader.Rows[i]["FPOName"].ToString();
                //    Obj_farmerdetails.FARMERNAME = dtFarmerHeader.Rows[i]["FarmerName"].ToString();
                //    Obj_farmerdetails.SUR_NAME = dtFarmerHeader.Rows[i]["Sur_Name"].ToString();
                //    Obj_farmerdetails.FATHER_NAME = dtFarmerHeader.Rows[i]["Father_Name"].ToString();
                //    Obj_farmerdetails.FARMER_DISTRICT = dtFarmerHeader.Rows[i]["Farmer_District"].ToString();
                //    Obj_farmerdetails.FARMER_VILLAGE = dtFarmerHeader.Rows[i]["Farmer_Village"].ToString();
                //    Obj_farmerdetails.GENDER = dtFarmerHeader.Rows[i]["Gender"].ToString();
                //    Obj_farmerdetails.MOBILE_NO = dtFarmerHeader.Rows[i]["Mobile_No"].ToString();
                //    //Land Details

                //    Obj_farmerdetails.LANDTYPE = dtFarmerHeader.Rows[i]["LandType"].ToString();
                //    Obj_farmerdetails.OWNERSHIP = dtFarmerHeader.Rows[i]["Ownership"].ToString();
                //    Obj_farmerdetails.NOOFACRES = Convert.ToDecimal(dtFarmerHeader.Rows[i]["NoOfAcres"].ToString() == "" ? "0" : dtFarmerHeader.Rows[i]["NoOfAcres"].ToString());
                //    Obj_farmerdetails.SOILTYPE = dtFarmerHeader.Rows[i]["SoilType"].ToString();
                //    Obj_farmerdetails.IRRIGATIONSOURCE = dtFarmerHeader.Rows[i]["IrrigationSource"].ToString();
                //    Obj_farmerdetails.LATITUDE = dtFarmerHeader.Rows[i]["Latitude"].ToString();
                //    Obj_farmerdetails.LONGITUDE = dtFarmerHeader.Rows[i]["Longitude"].ToString();
                //    Obj_farmerdetails.VILLAGE = dtFarmerHeader.Rows[i]["Village"].ToString();
                //    Obj_farmerdetails.POLYHOUSE = dtFarmerHeader.Rows[i]["Polyhouse"].ToString();
                //   // Obj_farmerdetails.SlNo = dtFarmerHeader.Rows[i]["row_slno"].ToString();

 
                //    objFarmerHeader.Add(Obj_farmerdetails);
                //}

                //    objFarmer.FARMERLANDDETAILS = objFarmerHeader;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return dtFarmerHeader;
        }
        public DataTable GetFarmerSowingDetails(SMSGetFarmerInfoModel objInput, string orgn_code, string ConString)
        {
            string type = "SOWING_DETAIL";
            FarmerSowingInfoNew objFarmer = new FarmerSowingInfoNew();
            DataTable dtFarmerHeader = new DataTable();
            try
            {
                // objInput.StartDate = DateTime.ParseExact(objInput.StartDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                // objInput.EndDate = DateTime.ParseExact(objInput.EndDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

                DataSet ds = objData.Fdr_GetFarmerInfO(objInput, type,orgn_code, ConString);
                dtFarmerHeader = ds.Tables[0];  
                //List<FarmerHeaderSowingInfo> objFarmerHeader = new List<FarmerHeaderSowingInfo>();
                //for (int i = 0; i < dtFarmerHeader.Rows.Count; i++)
                //{
                //    FarmerHeaderSowingInfo Obj_farmerdetails = new FarmerHeaderSowingInfo(); 
                //    Obj_farmerdetails.FARMERCODE = dtFarmerHeader.Rows[i]["FarmerCode"].ToString();
                //    Obj_farmerdetails.ROW_SlNo = Convert.ToInt64(dtFarmerHeader.Rows[i]["row_slno"].ToString());
                //    Obj_farmerdetails.FPONAME = dtFarmerHeader.Rows[i]["FPOName"].ToString();
                //    Obj_farmerdetails.FARMERNAME = dtFarmerHeader.Rows[i]["FarmerName"].ToString();
                //    Obj_farmerdetails.SUR_NAME = dtFarmerHeader.Rows[i]["Sur_Name"].ToString();
                //    Obj_farmerdetails.FATHER_NAME = dtFarmerHeader.Rows[i]["Father_Name"].ToString();
                //    Obj_farmerdetails.FARMER_DISTRICT = dtFarmerHeader.Rows[i]["Farmer_District"].ToString();
                //    Obj_farmerdetails.FARMER_VILLAGE = dtFarmerHeader.Rows[i]["Farmer_Village"].ToString();
                //    Obj_farmerdetails.GENDER = dtFarmerHeader.Rows[i]["Gender"].ToString();
                //    Obj_farmerdetails.MOBILE_NO = dtFarmerHeader.Rows[i]["Mobile_No"].ToString();
                //    //Sowing Details
                //    Obj_farmerdetails.YEAR = dtFarmerHeader.Rows[i]["Year"].ToString();
                //    Obj_farmerdetails.SEASON = dtFarmerHeader.Rows[i]["Season"].ToString();
                //    Obj_farmerdetails.CROPCLASS = dtFarmerHeader.Rows[i]["CropClass"].ToString();
                //    Obj_farmerdetails.CROPTYPE = dtFarmerHeader.Rows[i]["CropType"].ToString();
                //    Obj_farmerdetails.VARIETY = dtFarmerHeader.Rows[i]["Variety"].ToString();
                //    Obj_farmerdetails.SEEDNAME = dtFarmerHeader.Rows[i]["SeedName"].ToString();
                //    Obj_farmerdetails.SEEDQTY = Convert.ToDecimal(dtFarmerHeader.Rows[i]["SeedQty"].ToString() == "" ? "0.00" : dtFarmerHeader.Rows[i]["SeedQty"].ToString());
                //    Obj_farmerdetails.SOWINGAREA = Convert.ToDecimal(dtFarmerHeader.Rows[i]["SowingArea"].ToString() == "" ? "0.00" : dtFarmerHeader.Rows[i]["SowingArea"].ToString());
                //    Obj_farmerdetails.EXPECTEDYIELD = Convert.ToDecimal(dtFarmerHeader.Rows[i]["ExpectedYield"].ToString() == "" ? "0.00" : dtFarmerHeader.Rows[i]["ExpectedYield"].ToString());
                //    // objsow.SURPLUS = Convert.ToDecimal(dt.Rows[j]["Surplus"].ToString() == "" ? "0.00" : dt.Rows[j]["Surplus"].ToString());
                //    Obj_farmerdetails.EXPECTEDPRICE = Convert.ToDecimal(dtFarmerHeader.Rows[i]["ExpectedPrice"].ToString() == "" ? "0.00" : dtFarmerHeader.Rows[i]["ExpectedPrice"].ToString());
                //    Obj_farmerdetails.EXPECYIELDTOBESOLD = Convert.ToDecimal(dtFarmerHeader.Rows[i]["ExpectedYieldSold"].ToString() == "" ? "0.00" : dtFarmerHeader.Rows[i]["ExpectedYieldSold"].ToString());
                //    if (!string.IsNullOrEmpty((dtFarmerHeader.Rows[i]["SowingDate"].ToString())))
                //    {
                //        Obj_farmerdetails.SOWINGDATE= DateTime.ParseExact(dtFarmerHeader.Rows[i]["SowingDate"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                //       // Obj_farmerdetails.SOWINGDATE = Convert.ToString(dtFarmerHeader.Rows[i]["SowingDate"].ToString());
                //    }
                //     Obj_farmerdetails.LATITUDE = dtFarmerHeader.Rows[i]["Latitude"].ToString();
                //    Obj_farmerdetails.LONGITUDE = dtFarmerHeader.Rows[i]["Longitude"].ToString();
                //    objFarmerHeader.Add(Obj_farmerdetails);
                //}

                //    objFarmer.FARMERSOWINGDETAILS = objFarmerHeader;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + "ERROR  : " + ex);
            }
            return dtFarmerHeader;
        }

        public DataTable GetFarmerBasicInfonew(SMSGetFarmerInfoModel objInput,string orgn_code, string ConString)
        {
            DataTable dtFarmerHeader = new DataTable();
            string type = "PERSONAL_DETAIL"; 
            try
            {
                // objInput.StartDate = DateTime.ParseExact(objInput.StartDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                // objInput.EndDate = DateTime.ParseExact(objInput.EndDate, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

                DataSet ds = objData.Fdr_GetFarmerInfO(objInput, type, orgn_code, ConString);
                dtFarmerHeader = ds.Tables[0]; 
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return dtFarmerHeader;
        }

        public DataTable GetDailyProgress_srv(dailyprogressModel objInput, string ConString)
        {
            DataTable dtFarmerHeader = new DataTable();           
            try
            {
                DataSet ds = objData.GetDailyProgress_db(objInput, ConString);
                dtFarmerHeader = ds.Tables[0];
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return dtFarmerHeader;
        }

    }
}
