using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using FFI_DataModel;
using FFI_Model;
using System.Linq;

namespace FFI_Service
{
   public class SMSGetFarmerInfo_Service
    {
        SMS_DataModel Obj_SMS_DataModel = new SMS_DataModel();

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(SMSGetFarmerInfo_Service)); //Declaring Log4Net. 

        //start
        public Farmerinfo GetFarmerInfoData(SMSGetFarmerInfoModel Query, string conString)
        {
            string[] test = { };
            Farmerinfo Obj_Farmerinfo = new Farmerinfo();
            DataSet Dset_GetFarmer = new DataSet();
            try
            {
                //DataConnection objData = new DataConnection();
                Dset_GetFarmer = Obj_SMS_DataModel.GetFarmerInfoData(Query, conString);
                DataTable dt = Dset_GetFarmer.Tables[0];
                DataTable dtBankDetilas = Dset_GetFarmer.Tables[1];
                DataTable dtkycDetilas = Dset_GetFarmer.Tables[2];
                DataTable dtPeronalDetilas = Dset_GetFarmer.Tables[3];
                DataTable dtfarmilyDetails = Dset_GetFarmer.Tables[4];
                DataTable dtAssets = Dset_GetFarmer.Tables[5];
                DataTable dtLoanDetails = Dset_GetFarmer.Tables[6];
                DataTable dtLiveStockDetails = Dset_GetFarmer.Tables[7];
                DataTable dtOwnLandDetails = new DataTable();
                DataTable dtLeaeLandDetails = new DataTable();
                DataTable dtCropDetails = new DataTable();
                DataTable dtSellingDetails = new DataTable();
                if (Query.InstanceName != "TAMIL")
                {
                    dtOwnLandDetails = Dset_GetFarmer.Tables[8];
                    dtLeaeLandDetails = Dset_GetFarmer.Tables[9];
                    dtCropDetails = Dset_GetFarmer.Tables[10];
                    dtSellingDetails = Dset_GetFarmer.Tables[11];
                }
                List<FarmerDetailsinfo> objlstfar = new List<FarmerDetailsinfo>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    FarmerDetailsinfo Obj_FarmerDetailsinfo = new FarmerDetailsinfo();
                    Obj_FarmerDetailsinfo.FPONAME= dt.Rows[i]["FPO_Name"].ToString();
                    Obj_FarmerDetailsinfo.FARMERCODE = dt.Rows[i]["Farmer_Code"].ToString();
                    Obj_FarmerDetailsinfo.FARMERNAME = dt.Rows[i]["Farmer_Name"].ToString();
                    Obj_FarmerDetailsinfo.SURNAME = dt.Rows[i]["Sur_Name"].ToString();
                    Obj_FarmerDetailsinfo.FATHERNAME = dt.Rows[i]["Father_Name"].ToString();
                    Obj_FarmerDetailsinfo.FARMERDOB = Convert.ToDateTime(dt.Rows[i]["Farmer_Dob"].ToString());
                    Obj_FarmerDetailsinfo.FARMERADDRESS1 = dt.Rows[i]["Farmer_Address1"].ToString();
                    Obj_FarmerDetailsinfo.FARMERADDRESS2 = dt.Rows[i]["Farmer_Address2"].ToString();
                    Obj_FarmerDetailsinfo.FARMERCOUNTRY = dt.Rows[i]["Farmer_Country"].ToString();
                    Obj_FarmerDetailsinfo.FARMERSTATE= dt.Rows[i]["Farmer_State"].ToString();
                    Obj_FarmerDetailsinfo.FARMERDISTRICT = dt.Rows[i]["Farmer_District"].ToString();
                    Obj_FarmerDetailsinfo.FARMERTALUK = dt.Rows[i]["Farmer_Taluk"].ToString();
                    Obj_FarmerDetailsinfo.FARMERPANCHAYAT = dt.Rows[i]["Farmer_Panchayat"].ToString();
                    Obj_FarmerDetailsinfo.FARMERVILLAGE = dt.Rows[i]["Farmer_Village"].ToString();
                    Obj_FarmerDetailsinfo.FARMERPINCODE = dt.Rows[i]["Farmer_Pincode"].ToString();
                    Obj_FarmerDetailsinfo.GENDER = dt.Rows[i]["Gender"].ToString();
                    Obj_FarmerDetailsinfo.MOBILENO = dt.Rows[i]["Mobile_No"].ToString();
                    Obj_FarmerDetailsinfo.REGISTERDATE = Convert.ToDateTime(dt.Rows[i]["RegisterDate"].ToString());
                    Obj_FarmerDetailsinfo.LATITUDEANDLONGITUDE = dt.Rows[i]["LatitudeAndLongitude"].ToString();
                    //Obj_FarmerDetailsinfo.BankAccountNo = dt.Rows[i]["BankAccountNo"].ToString();
                    //Obj_FarmerDetailsinfo.BankName = dt.Rows[i]["BankName"].ToString();
                    //Obj_FarmerDetailsinfo.NoOfAcres = dt.Rows[i]["NoOfAcres"].ToString();
                  //  Obj_FarmerDetailsinfo.FARMERKYC = dt.Rows[i]["Farmer_KYC"].ToString();

                    try
                    {
                        var kycdtls = (from e in dtkycDetilas.AsEnumerable() where e.Field<string>("farmer_code") == Obj_FarmerDetailsinfo.FARMERCODE select e).ToList();
                        if (kycdtls.Count != 0)
                        {
                            List<FARMERKYCDETAILS> objkycdtls = new List<FARMERKYCDETAILS>();
                            DataTable dtDetails = dtkycDetilas.AsEnumerable().Where(r => r.Field<string>("farmer_code") == Obj_FarmerDetailsinfo.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dtDetails.Rows.Count; j++)
                            {
                                FARMERKYCDETAILS objkyc = new FARMERKYCDETAILS();
                                objkyc.PROOFDOC = dtDetails.Rows[j]["proof_doc"].ToString();
                                //objbank.BankName = dtDetails.Rows[j]["BankName"].ToString() == "" ? "0" : dtDetails.Rows[j]["BankName"].ToString();
                                objkyc.PROOFDOCNO = dtDetails.Rows[j]["proof_doc_no"].ToString();
                                objkycdtls.Add(objkyc);
                            }
                            Obj_FarmerDetailsinfo.KYCDETAILS = objkycdtls;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }


                    //start 
                    try
                    {
                        var bankdtls = (from e in dtBankDetilas.AsEnumerable() where e.Field<string>("farmer_code") == Obj_FarmerDetailsinfo.FARMERCODE select e).ToList();
                        if (bankdtls.Count != 0)
                        {
                            List<FARMERBANKDETAILS> objbankdtls = new List<FARMERBANKDETAILS>();
                            DataTable dtDetails = dtBankDetilas.AsEnumerable().Where(r => r.Field<string>("farmer_code") == Obj_FarmerDetailsinfo.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dtDetails.Rows.Count; j++)
                            {
                                FARMERBANKDETAILS objbank = new FARMERBANKDETAILS();
                                objbank.BANKACCOUNTNO = dtDetails.Rows[j]["BankAccountNo"].ToString();
                                //objbank.BankName = dtDetails.Rows[j]["BankName"].ToString() == "" ? "0" : dtDetails.Rows[j]["BankName"].ToString();
                                objbank.BANKNAME = dtDetails.Rows[j]["BankName"].ToString() ;
                                objbankdtls.Add(objbank);
                            }
                            Obj_FarmerDetailsinfo.BANKDETAILS = objbankdtls;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }


                    try
                    {
                        var personaldtls = (from e in dtPeronalDetilas.AsEnumerable() where e.Field<string>("farmer_code") == Obj_FarmerDetailsinfo.FARMERCODE select e).ToList();
                        if (personaldtls.Count != 0)
                        {
                            List<FARMERPERSONALDETAILS> objpersonal = new List<FARMERPERSONALDETAILS>();
                            DataTable dtDetails = dtPeronalDetilas.AsEnumerable().Where(r => r.Field<string>("farmer_code") == Obj_FarmerDetailsinfo.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dtDetails.Rows.Count; j++)
                            {
                                FARMERPERSONALDETAILS objperdtl = new FARMERPERSONALDETAILS();
                                objperdtl.MARITALSTATUS = dtDetails.Rows[j]["MaritalStatus"].ToString();
                                objperdtl.PHONENO = dtDetails.Rows[j]["PhoneNo"].ToString() == "" ? "0" : dtDetails.Rows[j]["PhoneNo"].ToString();
                                objperdtl.MOBILENO = dtDetails.Rows[j]["MobileNo"].ToString() == "" ? "0" : dtDetails.Rows[j]["MobileNo"].ToString();
                                objperdtl.EMAILID = dtDetails.Rows[j]["EmailID"].ToString();
                                objperdtl.EDUCATIONQUALIFICATION = dtDetails.Rows[j]["EducationQualification"].ToString();
                                objperdtl.CASTEORCATEGORY = dtDetails.Rows[j]["CasteOrCategory"].ToString();
                                objperdtl.RELIGION = dtDetails.Rows[j]["Religion"].ToString();
                              //  objperdtl.POVERTYLINE = dtDetails.Rows[j]["PovertyLine"].ToString();
                                objperdtl.MINORITY = dtDetails.Rows[j]["Minority"].ToString();
                              //  objperdtl.GROSSINCOMEOFINDIVIDUAL = Convert.ToDouble(dtDetails.Rows[j]["GrossIncomeofIndividual"].ToString() == "" ? "0.00" : dtDetails.Rows[j]["GrossIncomeofIndividual"].ToString());
                                objpersonal.Add(objperdtl);
                            }
                            Obj_FarmerDetailsinfo.PERSONALDETAILS = objpersonal;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    // End
                    //start 

                    try
                    {
                        var familydtls = (from e in dtfarmilyDetails.AsEnumerable() where e.Field<string>("farmer_code") == Obj_FarmerDetailsinfo.FARMERCODE select e).ToList();
                        if (familydtls.Count != 0)
                        {
                            List<FARMERFAMILYDETAILS> objfamily = new List<FARMERFAMILYDETAILS>();
                            DataTable dtDetails = dtfarmilyDetails.AsEnumerable().Where(r => r.Field<string>("farmer_code") == Obj_FarmerDetailsinfo.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dtDetails.Rows.Count; j++)
                            {
                                FARMERFAMILYDETAILS objfamilydtl = new FARMERFAMILYDETAILS();
                                objfamilydtl.FAMILYTYPE = dtDetails.Rows[j]["FamilyType"].ToString();
                                objfamilydtl.FAMILYMEMBER = dtDetails.Rows[j]["FamilyMemberName"].ToString(); 
                                    //== "" ? "0" : dtDetails.Rows[j]["PhoneNo"].ToString();
                                objfamilydtl.DOB = dtDetails.Rows[j]["DOB"].ToString();
                                objfamilydtl.GENDER = dtDetails.Rows[j]["Gender"].ToString();
                                objfamilydtl.RELATIONSHIP = dtDetails.Rows[j]["Relationship"].ToString();
                                objfamilydtl.QUALIFICATION = dtDetails.Rows[j]["HighestEducationalQualification"].ToString();
                                objfamilydtl.OCCUPATION = dtDetails.Rows[j]["Occupation"].ToString();
                                //objperdtl.GrossIncomeofIndividual = Convert.ToDouble(dtDetails.Rows[j]["GrossIncomeofIndividual"].ToString() == "" ? "0.00" : dtDetails.Rows[j]["GrossIncomeofIndividual"].ToString());
                                objfamily.Add(objfamilydtl);
                            }
                            Obj_FarmerDetailsinfo.FAMILYDETAILS = objfamily;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    // End
                    // start 
                    try
                    {
                        var assetdtls = (from e in dtAssets.AsEnumerable() where e.Field<string>("farmer_code") == Obj_FarmerDetailsinfo.FARMERCODE select e).ToList();
                        if (assetdtls.Count != 0)
                        {
                            List<FARMERASSETDETAILS> objAssetDtl = new List<FARMERASSETDETAILS>();
                            DataTable dtDetails = dtAssets.AsEnumerable().Where(r => r.Field<string>("farmer_code") == Obj_FarmerDetailsinfo.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dtDetails.Rows.Count; j++)
                            {
                                FARMERASSETDETAILS objasst = new FARMERASSETDETAILS();
                                objasst.ASSETTYPE = dtDetails.Rows[j]["AssetType"].ToString();
                                objasst.ASSETSUBTYPE = dtDetails.Rows[j]["AssetSubType"].ToString();
                               // objasst.OWNERSHIP = dtDetails.Rows[j]["Ownership"].ToString();
                               // objasst.HIREDFROMORHIREDTO = dtDetails.Rows[j]["HiredFromOrHiredTo"].ToString();
                                objasst.NOOFASSETS = Convert.ToInt32(dtDetails.Rows[j]["NoofAssets"].ToString() == "" ? "0" : dtDetails.Rows[j]["NoofAssets"].ToString());
                                objasst.PURCHASEDATE = dtDetails.Rows[j]["Purchasedate"].ToString();
                                objasst.ASSETSERIALNO = dtDetails.Rows[j]["AssetSerialNo"].ToString();
                                objasst.PURPOSE = dtDetails.Rows[j]["Purpose"].ToString();
                                //objasst.ASSESTMANUFACTURER = dtDetails.Rows[j]["AssestManufacturer"].ToString();
                                objAssetDtl.Add(objasst);
                            }
                            Obj_FarmerDetailsinfo.ASSETS = objAssetDtl;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    //End

                    //start 
                    try
                    {
                        var loandtl = (from e in dtLoanDetails.AsEnumerable() where e.Field<string>("farmer_code") == Obj_FarmerDetailsinfo.FARMERCODE select e).ToList();
                        if (loandtl.Count != 0)
                        {
                            List<FARMERLOANDETAILS> objLoanDtl = new List<FARMERLOANDETAILS>();
                            DataTable dtDetails = dtLoanDetails.AsEnumerable().Where(r => r.Field<string>("farmer_code") == Obj_FarmerDetailsinfo.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dtDetails.Rows.Count; j++)
                            {
                                FARMERLOANDETAILS objln = new FARMERLOANDETAILS();
                                objln.LOANTYPE = dtDetails.Rows[j]["LoanType"].ToString();
                                objln.LOANFROM = dtDetails.Rows[j]["LoanFrom"].ToString();
                                objln.INSTITUTIONBORROWEDFROM = dtDetails.Rows[j]["InstitutionBorrowedFrom"].ToString();
                                objln.LOANTENURE = dtDetails.Rows[j]["LoanTenure"].ToString();
                                objln.INTERESTRATE = Convert.ToDouble(dtDetails.Rows[j]["InterestRate"].ToString() == "" ? "0.00" : dtDetails.Rows[j]["InterestRate"].ToString());
                                objln.EMI = dtDetails.Rows[j]["EMI"].ToString();
                                objln.LOANSTARTDATE = dtDetails.Rows[j]["LoanStartDate"].ToString();
                                objln.LOANENDDATE = dtDetails.Rows[j]["LoanEndDate"].ToString();
                                objln.LOANSTATUS = dtDetails.Rows[j]["LoanStatus"].ToString();
                                objLoanDtl.Add(objln);
                            }
                            Obj_FarmerDetailsinfo.LOANDETAILS = objLoanDtl;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    //End

                    //start 
                    try
                    {
                        var livestockdtls = (from e in dtLiveStockDetails.AsEnumerable() where e.Field<string>("farmer_code") == Obj_FarmerDetailsinfo.FARMERCODE select e).ToList();
                        if (livestockdtls.Count != 0)
                        {
                            List<FARMERLIVESTOCKDETAILS> objLivestokDtl = new List<FARMERLIVESTOCKDETAILS>();
                            DataTable dtDetails = dtLiveStockDetails.AsEnumerable().Where(r => r.Field<string>("farmer_code") == Obj_FarmerDetailsinfo.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dtDetails.Rows.Count; j++)
                            {
                                FARMERLIVESTOCKDETAILS objlivestk = new FARMERLIVESTOCKDETAILS();
                                objlivestk.LIVESTOCKTYPE = dtDetails.Rows[j]["LivestockType"].ToString();
                                objlivestk.LIVESTOCKSUBTYPE = dtDetails.Rows[j]["LivestockSubType"].ToString();
                                objlivestk.OWNERSHIP = dtDetails.Rows[j]["Ownership"].ToString();
                                objlivestk.NUMBERPROCESSED = Convert.ToInt32(dtDetails.Rows[j]["NumberProcessed"].ToString() == "" ? "0" : dtDetails.Rows[j]["NumberProcessed"].ToString());
                                objlivestk.PURPOSEFORWHICHUSED = dtDetails.Rows[j]["PurposeForWhichUsed"].ToString();
                               // objlivestk.PRICE = Convert.ToDouble(dtDetails.Rows[j]["Price"].ToString() == "" ? "0.00" : dtDetails.Rows[j]["Price"].ToString());
                               // objlivestk.UOM = dtDetails.Rows[j]["UOM"].ToString();
                                objLivestokDtl.Add(objlivestk);
                            }
                            Obj_FarmerDetailsinfo.LIVESTOCKDETAILS = objLivestokDtl;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }


                    //End

                    //start 

                    if (Query.InstanceName != "TAMIL")
                    {
                        try
                        {
                            var ownlndtls = (from e in dtOwnLandDetails.AsEnumerable() where e.Field<string>("farmer_code") == Obj_FarmerDetailsinfo.FARMERCODE select e).ToList();
                            if (ownlndtls.Count != 0)
                            {
                                List<FARMEROWNEDLAND> objOwnLandtl = new List<FARMEROWNEDLAND>();
                                DataTable dtDetails = dtOwnLandDetails.AsEnumerable().Where(r => r.Field<string>("farmer_code") == Obj_FarmerDetailsinfo.FARMERCODE).CopyToDataTable();
                                for (int j = 0; j < dtDetails.Rows.Count; j++)
                                {
                                    FARMEROWNEDLAND objownln = new FARMEROWNEDLAND();
                                    objownln.OWNERSHIP = dtDetails.Rows[j]["Ownership"].ToString();
                                    objownln.LANDTYPE = dtDetails.Rows[j]["LandType"].ToString();
                                    objownln.NOOFACRES = Convert.ToDecimal(dtDetails.Rows[j]["NoOfAcres"].ToString() == "" ? "0.00" : dtDetails.Rows[j]["NoOfAcres"].ToString());
                                    objownln.SOILTYPE = dtDetails.Rows[j]["SoilType"].ToString();
                                    objownln.IRRIGATIONSERVICES = dtDetails.Rows[j]["IrrigationServices"].ToString();
                                    objOwnLandtl.Add(objownln);
                                }
                                Obj_FarmerDetailsinfo.LANDETAILS = objOwnLandtl;
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    else
                    {
                        Obj_FarmerDetailsinfo.LANDETAILS = null;
                    }

                    //End

                    //start 


                    //if (Query.InstanceName != "TAMIL")
                    //{
                    //    try
                    //    {
                    //        var leaselndtls = (from e in dtLeaeLandDetails.AsEnumerable() where e.Field<string>("farmer_code") == Obj_FarmerDetailsinfo.FARMERCODE select e).ToList();
                    //        if (leaselndtls.Count != 0)
                    //        {
                    //            List<FARMERLEASELAND> objLeaseLandtl = new List<FARMERLEASELAND>();
                    //            DataTable dtDetails = dtLeaeLandDetails.AsEnumerable().Where(r => r.Field<string>("farmer_code") == Obj_FarmerDetailsinfo.FARMERCODE).CopyToDataTable();
                    //            for (int j = 0; j < dtDetails.Rows.Count; j++)
                    //            {
                    //                FARMERLEASELAND objlseln = new FARMERLEASELAND();
                    //                objlseln.CROPSEASON = dtDetails.Rows[j]["CropSeason"].ToString();
                    //                objlseln.OWNERSHIP = dtDetails.Rows[j]["Ownership"].ToString();
                    //                objlseln.NOOFACRES = Convert.ToDecimal(dtDetails.Rows[j]["NoOfAcres"].ToString() == "" ? "0.00" : dtDetails.Rows[j]["NoOfAcres"].ToString());
                    //                objlseln.SOILTYPE = dtDetails.Rows[j]["SoilType"].ToString();
                    //                objlseln.IRRIGATIONSERVICES = dtDetails.Rows[j]["IrrigationServices"].ToString();
                    //                objLeaseLandtl.Add(objlseln);
                    //            }
                    //            Obj_FarmerDetailsinfo.LEASELANDDETAILS = objLeaseLandtl;
                    //        }
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        throw ex;
                    //    }
                    //}
                    //else
                    //{
                    //    Obj_FarmerDetailsinfo.LEASELANDDETAILS = null;
                    //}

                    //End

                    //start 

                    if (Query.InstanceName != "TAMIL")
                    {
                        try
                        {
                            var Cropdtls = (from e in dtCropDetails.AsEnumerable() where e.Field<string>("farmer_code") == Obj_FarmerDetailsinfo.FARMERCODE select e).ToList();
                            if (Cropdtls.Count != 0)
                            {
                                List<FARMERCROPDETAILS> objCropdtl = new List<FARMERCROPDETAILS>();
                                DataTable dtDetails = dtCropDetails.AsEnumerable().Where(r => r.Field<string>("farmer_code") == Obj_FarmerDetailsinfo.FARMERCODE).CopyToDataTable();
                                for (int j = 0; j < dtDetails.Rows.Count; j++)
                                {
                                    FARMERCROPDETAILS objcrpdtl = new FARMERCROPDETAILS();
                                    objcrpdtl.CROPSEASON = dtDetails.Rows[j]["CropSeason"].ToString();
                                    objcrpdtl.CROPTYPE = dtDetails.Rows[j]["CropType"].ToString();
                                    objcrpdtl.VAREITY = dtDetails.Rows[j]["Vareity"].ToString();
                                    objcrpdtl.NOOFACRES = Convert.ToDecimal(dtDetails.Rows[j]["NoOfAcres"].ToString() == "" ? "0.00" : dtDetails.Rows[j]["NoOfAcres"].ToString());
                                    objcrpdtl.LANDTYPE = dtDetails.Rows[j]["Croplandtype"].ToString();
                                    // objcrpdtl.TOTALPRODUCTION = Convert.ToInt32(dtDetails.Rows[j]["TotalProduction"].ToString() == "" ? "0" : dtDetails.Rows[j]["TotalProduction"].ToString());
                                    objCropdtl.Add(objcrpdtl);
                                }
                                Obj_FarmerDetailsinfo.CROPDETAILS = objCropdtl;
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    else
                    {
                        Obj_FarmerDetailsinfo.CROPDETAILS = null;
                    }

                    //End 

                    //start 
                   /* if (Query.InstanceName != "TAMIL")
                    {
                        try
                        {
                            var Sellingdtls = (from e in dtSellingDetails.AsEnumerable() where e.Field<string>("farmer_code") == Obj_FarmerDetailsinfo.FARMERCODE select e).ToList();
                            if (Sellingdtls.Count != 0)
                            {
                                List<FARMERSELLINGDETAILS> objSellingdtl = new List<FARMERSELLINGDETAILS>();
                                DataTable dtDetails = dtSellingDetails.AsEnumerable().Where(r => r.Field<string>("farmer_code") == Obj_FarmerDetailsinfo.FARMERCODE).CopyToDataTable();
                                for (int j = 0; j < dtDetails.Rows.Count; j++)
                                {
                                    FARMERSELLINGDETAILS objSelingdtl = new FARMERSELLINGDETAILS();
                                    objSelingdtl.CROPSEASON = dtDetails.Rows[j]["CropSeason"].ToString();
                                    objSelingdtl.QUANTITY = Convert.ToDecimal(dtDetails.Rows[j]["Quantity"].ToString() == "" ? "0.00" : dtDetails.Rows[j]["Quantity"].ToString());
                                    objSelingdtl.PRICE = Convert.ToDouble(dtDetails.Rows[j]["Price"].ToString() == "" ? "0.00" : dtDetails.Rows[j]["Price"].ToString());
                                    objSelingdtl.TOWHOMORBUYER = dtDetails.Rows[j]["ToWhomOrBuyer"].ToString();
                                    objSelingdtl.TERMSOFPAYMENT = dtDetails.Rows[j]["TermsOfPayment"].ToString();
                                    objSelingdtl.SELLINGDATE = dtDetails.Rows[j]["SellingDate"].ToString();
                                    objSellingdtl.Add(objSelingdtl);
                                }
                                Obj_FarmerDetailsinfo.SELLINGDETAILS = objSellingdtl;
                            }
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    else
                    {
                        Obj_FarmerDetailsinfo.SELLINGDETAILS = null;
                    }
                    */

                    objlstfar.Add(Obj_FarmerDetailsinfo);
                    Obj_Farmerinfo.FARMERDETAILS = objlstfar;
                    //End

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Obj_Farmerinfo;
        }
        //end
        //start
        public SMSICDProducthistory_BO GetPRODUCTHISTORY(SMSIcdDetailsModel query, string conString)
        {
            SMSICDProducthistory_BO objInv = new SMSICDProducthistory_BO();
            try
            {
                DataSet ds = Obj_SMS_DataModel.GetPRODUCTHISTORYDb(query, conString);
                DataTable dtProducthistory = new DataTable();
                DataTable dtProducthistoryinward = new DataTable();
                DataTable dtProducthistoryOutward = new DataTable();
                dtProducthistory = ds.Tables[0];
                dtProducthistoryinward = ds.Tables[1];
                dtProducthistoryOutward = ds.Tables[2];
                List<PRODUCTHISTORYHEADER> objInvHeader = new List<PRODUCTHISTORYHEADER>();
                for (int i = 0; i < dtProducthistory.Rows.Count; i++)
                {
                    PRODUCTHISTORYHEADER objHeader = new PRODUCTHISTORYHEADER();
                    objHeader.PRODUCT_ROWID = Convert.ToInt32(dtProducthistory.Rows[i]["product_rowid"].ToString());
                    objHeader.ORGN_NAME = dtProducthistory.Rows[i]["orgn_name"].ToString();
                    objHeader.PRODUCT_CODE = dtProducthistory.Rows[i]["product_code"].ToString();
                    objHeader.PRODUCT_NAME = dtProducthistory.Rows[i]["product_name"].ToString();
                    objHeader.PRODUCT_CATG_CODE = dtProducthistory.Rows[i]["product_catg_code"].ToString();
                    objHeader.PRODUCT_SUBCATG_CODE = dtProducthistory.Rows[i]["product_subcatg_code"].ToString();
                    objHeader.BASE_PRICE = Convert.ToDecimal(dtProducthistory.Rows[i]["base_price"].ToString());
                    objHeader.CURRENT_QTY = Convert.ToDecimal(dtProducthistory.Rows[i]["current_qty"].ToString());
                    objHeader.UOMTYPE = dtProducthistory.Rows[i]["uomtype"].ToString();
                    List<PRODUCTHISTORYINWARD> objInvoiceDetails = new List<PRODUCTHISTORYINWARD>();

                    var stokdtl = (from e in dtProducthistoryinward.AsEnumerable() where e.Field<string>("inwardProductCode") == objHeader.PRODUCT_CODE select e).ToList();
                    if (stokdtl.Count != 0)
                    {
                        DataTable dtstok = dtProducthistoryinward.AsEnumerable().Where(r => r.Field<string>("inwardProductCode") == objHeader.PRODUCT_CODE).CopyToDataTable();
                        for (int j = 0; j < dtstok.Rows.Count; j++)
                        {
                            PRODUCTHISTORYINWARD objstk = new PRODUCTHISTORYINWARD();
                            objstk.INWARDNO = dtstok.Rows[j]["inwardNo"].ToString();
                            objstk.INWARDDATE = Convert.ToDateTime(dtstok.Rows[j]["inwardDate"].ToString());
                            objstk.INWARDPRODUCTCODE = dtstok.Rows[j]["inwardProductCode"].ToString();
                            objstk.INWARDQTY = Convert.ToDecimal(dtstok.Rows[j]["inwardQty"].ToString());
                            objstk.INWARDPRODCUTAMOUNT = Convert.ToDecimal(dtstok.Rows[j]["inwardProdcutAmount"].ToString());
                            objInvoiceDetails.Add(objstk);
                        }
                        objHeader.PRODUCTHISTORYINWARD = objInvoiceDetails;
                    }
                    List<PRODUCTHISTORYOUTWARD> objInvoiceDetails1 = new List<PRODUCTHISTORYOUTWARD>();
                    var stokdtl1 = (from e in dtProducthistoryOutward.AsEnumerable() where e.Field<string>("outwardProductCode") == objHeader.PRODUCT_CODE select e).ToList();
                    if (stokdtl1.Count != 0)
                    {
                        DataTable dtstok = dtProducthistoryOutward.AsEnumerable().Where(r => r.Field<string>("outwardProductCode") == objHeader.PRODUCT_CODE).CopyToDataTable();
                        for (int j = 0; j < dtstok.Rows.Count; j++)
                        {
                            PRODUCTHISTORYOUTWARD objstk = new PRODUCTHISTORYOUTWARD();
                            objstk.OUTWARDNO = dtstok.Rows[j]["outwardNo"].ToString();
                            objstk.OUTWARDDATE = Convert.ToDateTime(dtstok.Rows[j]["outwardDate"].ToString());
                            objstk.OUTWARDPRODUCTCODE = dtstok.Rows[j]["outwardProductCode"].ToString();
                            objstk.OUTWARDQTY = Convert.ToDecimal(dtstok.Rows[j]["outwardQty"].ToString());
                            objInvoiceDetails1.Add(objstk);
                        }
                        objHeader.PRODUCTHISTORYOUTWARD = objInvoiceDetails1;
                    }
                    objInvHeader.Add(objHeader);
                }

                objInv.PRODUCTHISTORY = objInvHeader;
            }
            catch (Exception e)
            {

            }
            return objInv;
        }
        //End
        //start 
        public SMSICDSTOCK_model GetICDStockDetails(SMSIcdDetailsModel query, string conString)
        {
            SMSICDSTOCK_model objStock = new SMSICDSTOCK_model();
            try
            {
                DataSet ds = Obj_SMS_DataModel.GetICDStockInward(query, conString);
                DataTable dtInward = new DataTable();
                DataTable dtInwardDetails = new DataTable();
                dtInward = ds.Tables[0];
                dtInwardDetails = ds.Tables[1];
                List<STOCKHEADER> objStockHeader = new List<STOCKHEADER>();
                for (int i = 0; i < dtInward.Rows.Count; i++)
                {
                    STOCKHEADER objHeader = new STOCKHEADER();
                    objHeader.INWARDID = Convert.ToInt32(dtInward.Rows[i]["inward_rowid"].ToString());
                    objHeader.INPUT_CENTRE_NAME = dtInward.Rows[i]["inputcenter_name"].ToString();
                    objHeader.FPO_NAME = dtInward.Rows[i]["fpo_name"].ToString();
                    //objHeader.Input_Centre_Name = dtInward.Rows[i]["inputcenter_name"].ToString();
                    objHeader.GRN_NO = dtInward.Rows[i]["grn_no"].ToString();
                    objHeader.SUPPLIER_NAME = dtInward.Rows[i]["supplier_name"].ToString();
                    objHeader.SUPPLIER_LOCATION = dtInward.Rows[i]["supplier_location"].ToString();
                    objHeader.FROM_STATE = dtInward.Rows[i]["from_state"].ToString();
                    objHeader.GRN_DATE = Convert.ToDateTime(dtInward.Rows[i]["grn_date"].ToString());
                    objHeader.BILL_NO = dtInward.Rows[i]["bill_no"].ToString();
                    objHeader.TOTALINWARDAMOUNT = Convert.ToDecimal(dtInward.Rows[i]["total_amount"].ToString());
                    objHeader.TRANSPORT_COST = dtInward.Rows[i]["transport_cost"].ToString();
                    objHeader.LOADING_UNLOADING_COST = dtInward.Rows[i]["loading_unloading_cost"].ToString();
                    objHeader.LOCAL_TRANSPORT_COST = dtInward.Rows[i]["local_transport_cost"].ToString();
                    objHeader.LOCAL_LOADING_UNLOADING_COST = dtInward.Rows[i]["local_loading_unloading_cost"].ToString();
                    objHeader.STATUS = dtInward.Rows[i]["status_code"].ToString();
                    objHeader.FPO_COUNTRY = dtInward.Rows[i]["orgn_country"].ToString();
                    objHeader.FPO_STATE = dtInward.Rows[i]["orgn_state"].ToString();
                    objHeader.FPO_DISTRICT = dtInward.Rows[i]["orgn_dist"].ToString();
                    objHeader.FPO_TALUK = dtInward.Rows[i]["orgn_taluk"].ToString();
                    objHeader.FPO_PANCHAYAT = dtInward.Rows[i]["orgn_panchayat"].ToString();
                    objHeader.FPO_VILLAGE = dtInward.Rows[i]["orgn_village"].ToString();
                    objHeader.FPO_PINCODE = dtInward.Rows[i]["orgn_pincode"].ToString();
                    objHeader.FPO_ADDR1 = dtInward.Rows[i]["orgn_addr1"].ToString();
                    objHeader.FPO_ADDR2 = dtInward.Rows[i]["orgn_addr2"].ToString();
                    List<STOCKDETAILS> objStockDetails = new List<STOCKDETAILS>();

                    var stokdtl = (from e in dtInwardDetails.AsEnumerable() where e.Field<string>("grn_no") == objHeader.GRN_NO select e).ToList();
                    if (stokdtl.Count != 0)
                    {
                        DataTable dtstok = dtInwardDetails.AsEnumerable().Where(r => r.Field<string>("grn_no") == objHeader.GRN_NO).CopyToDataTable();
                        for (int j = 0; j < dtstok.Rows.Count; j++)
                        {
                            STOCKDETAILS objstk = new STOCKDETAILS();
                            objstk.PRODUCTSUB_CATEGORY = dtstok.Rows[j]["product_catg_code"].ToString();
                            objstk.PRODUCTSUB_CATEGORY = dtstok.Rows[j]["product_subcatg_code"].ToString();
                            objstk.PRODUCT_CODE = dtstok.Rows[j]["product_code"].ToString();
                            objstk.PRODUCT_NAME = dtstok.Rows[j]["product_name"].ToString();
                            objstk.HSN_CODE = dtstok.Rows[j]["hsn_code"].ToString();
                            objstk.HSN_DESCRIPTION = dtstok.Rows[j]["hsn_desc"].ToString();
                            objstk.RECEIVED_QUANTITY = Convert.ToInt32(dtstok.Rows[j]["received_qty"].ToString());
                            objstk.RATE = Convert.ToDecimal(dtstok.Rows[j]["rate"].ToString());
                            objstk.PRODUCT_AMOUNT = Convert.ToDecimal(dtstok.Rows[j]["product_amount"].ToString());
                            objstk.TRANSPORTATION_AMOUNT = Convert.ToDecimal(dtstok.Rows[j]["trnasport_amount"].ToString());
                            objstk.DISCOUNT = Convert.ToDecimal(dtstok.Rows[j]["discount"].ToString());
                            objstk.TAX = Convert.ToDecimal(dtstok.Rows[j]["tax_amount"].ToString());
                            objstk.GROSS_AMOUNT = Convert.ToDecimal(dtstok.Rows[j]["gross_amount"].ToString());
                            objStockDetails.Add(objstk);
                        }
                        objHeader.INWARDDETAIL = objStockDetails;
                    }
                    else
                    {

                    }
                    objStockHeader.Add(objHeader);
                }

                objStock.INWARD = objStockHeader;
            }
            catch (Exception e)
            {

            }
            return objStock;
        }
        //End
        //start 
        public SMSICDPayment_model GetICDPaymentDetails(SMSIcdDetailsModel query, string conString)
        {
            DataTable dtAdd = new DataTable();
            dtAdd.Columns.Add("InvoiceNo");
            SMSICDPayment_model objpayment = new SMSICDPayment_model();
            try
            {
                DataSet ds = Obj_SMS_DataModel.GetICDPaymentDetails(query,conString);
                DataTable dtPayment = new DataTable();
                DataTable dtPaymentDetails = new DataTable();
                dtPayment = ds.Tables[0];
                dtPaymentDetails = ds.Tables[1];
                List<ICDPAYMENTHEADER> objPaymentHeader = new List<ICDPAYMENTHEADER>();
                for (int i = 0; i < dtPayment.Rows.Count; i++)
                {
                    dtAdd.Rows.Add(dtPayment.Rows[i]["Invoice_No"].ToString());
                    int count = dtAdd.AsEnumerable().Count(row => row.Field<string>("InvoiceNo") == dtPayment.Rows[i]["Invoice_No"].ToString());
                    if (count == 1)
                    {
                        ICDPAYMENTHEADER objHeader = new ICDPAYMENTHEADER();
                        objHeader.INPUT_CENTRE_NAME = dtPayment.Rows[i]["ICD_Center_name"].ToString();
                        objHeader.FPO_NAME = dtPayment.Rows[i]["FPO_Name"].ToString();
                        objHeader.INVOICE_NO = dtPayment.Rows[i]["Invoice_No"].ToString();
                        objHeader.INVOICEDATE = Convert.ToDateTime(dtPayment.Rows[i]["invoice_date"].ToString());
                        objHeader.INVOICE_AMOUNT = Convert.ToDecimal(dtPayment.Rows[i]["Invoice_Amount"].ToString());
                        objHeader.PAID_AMOUNT = Convert.ToDecimal(dtPayment.Rows[i]["Paid_Amount"].ToString());
                        objHeader.BALANCE_AMOUNT = Convert.ToDecimal(dtPayment.Rows[i]["Balance_Amount"].ToString());
                        objHeader.CUSOTMERTYPE = dtPayment.Rows[i]["customer_type"].ToString();
                        objHeader.FARMER_CODE = dtPayment.Rows[i]["farmer_code"].ToString();
                        objHeader.FARMER_NAME = dtPayment.Rows[i]["farmer_name"].ToString();
                        objHeader.FARMER_COUNTRY = dtPayment.Rows[i]["farmer_country"].ToString();
                        objHeader.FARMER_STATE = dtPayment.Rows[i]["farmer_state"].ToString();
                        objHeader.FARMER_DISTRICT = dtPayment.Rows[i]["farmer_dist"].ToString();
                        objHeader.FARMER_TALUK = dtPayment.Rows[i]["farmer_taluk"].ToString();
                        objHeader.FARMER_PANCHAYAT = dtPayment.Rows[i]["farmer_panchayat"].ToString();
                        objHeader.FARMER_VILLAGE = dtPayment.Rows[i]["farmer_village"].ToString();
                        objHeader.FARMER_HAMLET = dtPayment.Rows[i]["hamlet"].ToString();
                        objHeader.FARMERLATITUDEANDLONGITUDE = dtPayment.Rows[i]["FarmerLatitudeAndLongitude"].ToString();
                        // objHeader.Farmer_Latitude = dtPayment.Rows[i]["latitude"].ToString();
                        // objHeader.Farmer_Longitude = dtPayment.Rows[i]["longitude"].ToString();
                        objHeader.FARMER_PINCODE = dtPayment.Rows[i]["farmer_pincode"].ToString();
                        objHeader.FARMER_ADDRESS = dtPayment.Rows[i]["customer_address"].ToString();
                        List<ICDPAYMENTDETAIL> objpaymentDetails = new List<ICDPAYMENTDETAIL>();

                        var stokdtl = (from e in dtPaymentDetails.AsEnumerable() where e.Field<string>("Invoice_No") == objHeader.INVOICE_NO select e).ToList();
                        if (stokdtl.Count != 0)
                        {
                            DataTable dtstok = dtPaymentDetails.AsEnumerable().Where(r => r.Field<string>("Invoice_No") == objHeader.INVOICE_NO).CopyToDataTable();
                            for (int j = 0; j < dtstok.Rows.Count; j++)
                            {
                                ICDPAYMENTDETAIL objstk = new ICDPAYMENTDETAIL();
                                objstk.PAYMENT_MODE = dtstok.Rows[j]["payment_mode"].ToString();
                                objstk.PAYMENT_REF_NO = dtstok.Rows[j]["ref_no"].ToString();
                                objstk.PAYMENT_AMOUNT = Convert.ToDecimal(dtstok.Rows[j]["payment_amount"].ToString());
                               objstk.PAYMENT_DATE = Convert.ToDateTime(dtstok.Rows[j]["payment_date"].ToString());
                                objpaymentDetails.Add(objstk);
                            }
                            objHeader.PAYMENTDETAIL = objpaymentDetails;
                        }
                        else
                        {

                        }
                        objPaymentHeader.Add(objHeader);
                    }
                }

                objpayment.PAYMENT = objPaymentHeader;
            }
            catch (Exception e)
            {
                throw e;
            }
            return objpayment;

        }
        //End
        //start
        public SMSICDInvoice_model GetICDInvoice(SMSIcdDetailsModel query, string conString)
        {
            SMSICDInvoice_model objInv = new SMSICDInvoice_model();

            try
            {
                DataSet ds = Obj_SMS_DataModel.GetICDInvoiceDetails(query,conString);
                DataTable dtInvoice = new DataTable();
                DataTable dtInvoiceDetails = new DataTable();
                dtInvoice = ds.Tables[0];
                dtInvoiceDetails = ds.Tables[1];
                List<INVOICEHEADER> objInvHeader = new List<INVOICEHEADER>();
                for (int i = 0; i < dtInvoice.Rows.Count; i++)
                {

                    INVOICEHEADER objHeader = new INVOICEHEADER();
                    objHeader.FPO_NAME = dtInvoice.Rows[i]["fpo_name"].ToString();
                    objHeader.INPUT_CENTER_NAME = dtInvoice.Rows[i]["input_center_name"].ToString();
                    objHeader.INVOICEID = Convert.ToInt32(dtInvoice.Rows[i]["invoice_rowid"].ToString());
                    objHeader.INVOICENO = dtInvoice.Rows[i]["Invoice_no"].ToString();
                    objHeader.INVOICEDATE = Convert.ToDateTime(dtInvoice.Rows[i]["invoice_date"].ToString());
                    objHeader.RECEIVER_LOCATION = dtInvoice.Rows[i]["reciver_location"].ToString();
                    objHeader.CUSOTMERTYPE = dtInvoice.Rows[i]["customer_type"].ToString();
                    objHeader.FARMER_CODE = dtInvoice.Rows[i]["farmer_code"].ToString();
                    objHeader.FARMER_NAME = dtInvoice.Rows[i]["farmer_name"].ToString();
                    objHeader.FARMER_COUNTRY = dtInvoice.Rows[i]["farmer_country"].ToString();
                    objHeader.FARMER_STATE = dtInvoice.Rows[i]["farmer_state"].ToString();
                    objHeader.FARMER_DISTRICT = dtInvoice.Rows[i]["farmer_dist"].ToString();
                    objHeader.FARMER_TALUK = dtInvoice.Rows[i]["farmer_taluk"].ToString();
                    objHeader.FARMER_PANCHAYAT = dtInvoice.Rows[i]["farmer_panchayat"].ToString();
                    objHeader.FARMER_VILLAGE = dtInvoice.Rows[i]["farmer_village"].ToString();
                    objHeader.FARMER_HAMLET = dtInvoice.Rows[i]["hamlet"].ToString();
                    objHeader.FARMERLATITUDEANDLONGITUDE = dtInvoice.Rows[i]["FarmerLatitudeAndLongitude"].ToString();
                    //objHeader.Farmer_Longitude = dtInvoice.Rows[i]["longitude"].ToString();
                    objHeader.FARMER_PINCODE = dtInvoice.Rows[i]["farmer_pincode"].ToString();
                    objHeader.FARMER_ADDRESS = dtInvoice.Rows[i]["customer_address"].ToString();
                    objHeader.TOTALINVOICEAMOUNT = Convert.ToDecimal(dtInvoice.Rows[i]["totalinvoice_amout"].ToString());
                    objHeader.BALANCEAMOUNT = Convert.ToDecimal(dtInvoice.Rows[i]["balance_amount"].ToString());
                    objHeader.STATUS = dtInvoice.Rows[i]["status_code"].ToString();
                        List<INVOICEDETAILS> objInvoiceDetails = new List<INVOICEDETAILS>();

                    var stokdtl = (from e in dtInvoiceDetails.AsEnumerable() where e.Field<string>("invoice_no") == objHeader.INVOICENO select e).ToList();
                    //sb.WriteLine("Step 7");
                    if (stokdtl.Count != 0)
                    {
                        DataTable dtstok = dtInvoiceDetails.AsEnumerable().Where(r => r.Field<string>("invoice_no") == objHeader.INVOICENO).CopyToDataTable();
                        for (int j = 0; j < dtstok.Rows.Count; j++)
                        {
                            //sb.WriteLine("Step 8");
                            INVOICEDETAILS objstk = new INVOICEDETAILS();
                            objstk.PRODUCTSUB_CATEGORY = dtstok.Rows[j]["product_catg_code"].ToString();
                            objstk.PRODUCTSUB_CATEGORY = dtstok.Rows[j]["product_subcatg_code"].ToString();
                            objstk.PRODUCT_CODE = dtstok.Rows[j]["product_code"].ToString();
                            objstk.PRODUCT_NAME = dtstok.Rows[j]["product_name"].ToString();
                            objstk.HSN_CODE = dtstok.Rows[j]["hsn_code"].ToString();
                            objstk.HSN_DESCRIPTION = dtstok.Rows[j]["hsn_desc"].ToString();
                            objstk.QUANTITY = Convert.ToInt32(dtstok.Rows[j]["qty"].ToString());
                            objstk.BASEPRICE = Convert.ToDecimal(dtstok.Rows[j]["base_price"].ToString());
                            objstk.PRODUCT_AMOUNT = Convert.ToDecimal(dtstok.Rows[j]["product_amount"].ToString());
                            objstk.TAX = Convert.ToDecimal(dtstok.Rows[j]["tax_amount"].ToString());
                            objstk.DISCOUNT = Convert.ToDecimal(dtstok.Rows[j]["discount_amount"].ToString());
                            objstk.GROSS_AMOUNT = Convert.ToDecimal(dtstok.Rows[j]["net_amount"].ToString());
                            objInvoiceDetails.Add(objstk);
                        }
                        objHeader.INVOICEDETAILS = objInvoiceDetails;
                    }
                    else
                    {

                    }
                    objInvHeader.Add(objHeader);
                }

                objInv.INVOICE = objInvHeader;
                //sb.WriteLine("Step 9");
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return objInv;
        }
        //End
        //start
        public ICD_Stock_Details GetimapTableDtICDSTOCK(SMSIcdDetailsModel query, string conString)
        {
            ICD_Stock_Details Obj_ICD_Stock_Details = new ICD_Stock_Details();
            DataSet ds3 = new DataSet();
            try
            {
                
                ds3 = Obj_SMS_DataModel.GetICDSTKTable(query,conString);
                DataTable dt = ds3.Tables[0];
                List<GetIcdStock> objIcdStocklst = new List<GetIcdStock>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    GetIcdStock Obj_GetIcdStocklst = new GetIcdStock();
                    Obj_GetIcdStocklst.InwardID = dt.Rows[i]["Inward_ID"].ToString();
                    Obj_GetIcdStocklst.FPOName = dt.Rows[i]["FPO_Name"].ToString();
                    Obj_GetIcdStocklst.CenterName = dt.Rows[i]["Center_Name"].ToString();
                    Obj_GetIcdStocklst.InwardNo = dt.Rows[i]["Inward_No"].ToString();
                    Obj_GetIcdStocklst.Date = dt.Rows[i]["Date"].ToString();
                    Obj_GetIcdStocklst.ProductCode = dt.Rows[i]["Product_Code"].ToString();
                    Obj_GetIcdStocklst.ProductName = dt.Rows[i]["Product_Name"].ToString();
                    Obj_GetIcdStocklst.Quantity = dt.Rows[i]["Quantity"].ToString();
                    Obj_GetIcdStocklst.ProductAmount = dt.Rows[i]["Product_Amount"].ToString();
                    Obj_GetIcdStocklst.TaxAmount = dt.Rows[i]["Tax_Amount"].ToString();
                    Obj_GetIcdStocklst.TransportAmount = dt.Rows[i]["Transport_Amount"].ToString();
                    Obj_GetIcdStocklst.TotalAmount = dt.Rows[i]["Total_Amount"].ToString();
                    objIcdStocklst.Add(Obj_GetIcdStocklst);
                    Obj_ICD_Stock_Details.StockDetails = objIcdStocklst;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Obj_ICD_Stock_Details;
        }

        //end
        //start
        public ICD_Payment_Details GetimapTableDtICDPAY(SMSIcdDetailsModel query, string conString)
        {
            ICD_Payment_Details Obj_ICD_Payment_Details = new ICD_Payment_Details();
            DataSet ds3 = new DataSet();
            try
            {
               
                ds3 = Obj_SMS_DataModel.GetICDPAYTable(query, conString);
                DataTable dt = ds3.Tables[0];
                List<GetIcdPayment> objIcdPaymentlst = new List<GetIcdPayment>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    GetIcdPayment Obj_GetIcdPaylst = new GetIcdPayment();
                    Obj_GetIcdPaylst.FPO_Name = dt.Rows[i]["FPO_Name"].ToString();
                    Obj_GetIcdPaylst.ICDCenter_name= dt.Rows[i]["ICDCenter_name"].ToString();
                    Obj_GetIcdPaylst.Invoice_No = dt.Rows[i]["Invoice_No"].ToString();
                    Obj_GetIcdPaylst.Date = dt.Rows[i]["Date"].ToString();
                    Obj_GetIcdPaylst.Invoice_Amount = dt.Rows[i]["Invoice_Amount"].ToString();
                    Obj_GetIcdPaylst.Paid_Amount = dt.Rows[i]["Paid_Amount"].ToString();
                    Obj_GetIcdPaylst.Balance_Amount = dt.Rows[i]["Balance_Amount"].ToString();
                    objIcdPaymentlst.Add(Obj_GetIcdPaylst);
                    Obj_ICD_Payment_Details.PaymentDetails = objIcdPaymentlst;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Obj_ICD_Payment_Details;
        }

        //End

        //End
        //start
        public ICD_Invoice_Details GetimapTableDtICDIN(SMSIcdDetailsModel query, string conString)
        {
            ICD_Invoice_Details Obj_GetIcdInvoice = new ICD_Invoice_Details();
            DataSet ds3 = new DataSet();
            try
            {

                ds3 = Obj_SMS_DataModel.GetICDINTable(query, conString);
                DataTable dt = ds3.Tables[0];
                List<GetIcdInvoice> objIcdlst = new List<GetIcdInvoice>();
                for (int i=0; i < dt.Rows.Count; i++)
                {
                    GetIcdInvoice Obj_GetIcdInv = new GetIcdInvoice();
                    Obj_GetIcdInv.Invoice_ID = dt.Rows[i]["Invoice_ID"].ToString();
                    Obj_GetIcdInv.FPO_Name = dt.Rows[i]["FPO_Name"].ToString();
                    Obj_GetIcdInv.ICDCentername = dt.Rows[i]["ICDCentername"].ToString();
                    Obj_GetIcdInv.Invoiceno = dt.Rows[i]["Invoice_no"].ToString();
                    Obj_GetIcdInv.InvoiceDate = dt.Rows[i]["Invoice_Date"].ToString();
                    Obj_GetIcdInv.Product= dt.Rows[i]["Product"].ToString();
                    Obj_GetIcdInv.Quantity = dt.Rows[i]["Quantity"].ToString();
                    Obj_GetIcdInv.BasePrice = dt.Rows[i]["BasePrice"].ToString();
                    Obj_GetIcdInv.Product_Amount = dt.Rows[i]["Product_Amount"].ToString();
                    Obj_GetIcdInv.Discount = dt.Rows[i]["Discount"].ToString();
                    Obj_GetIcdInv.Total_Amount = dt.Rows[i]["Total_Amount"].ToString();
                    Obj_GetIcdInv.TransportAmount = dt.Rows[i]["TransportAmount"].ToString();
                    Obj_GetIcdInv.OthersAmount = dt.Rows[i]["OthersAmount"].ToString();
                    Obj_GetIcdInv.Invoice_Amount = dt.Rows[i]["Invoice_Amount"].ToString();
                    objIcdlst.Add(Obj_GetIcdInv);
                    Obj_GetIcdInvoice.InvoiceDetails = objIcdlst;
                   
                }
             


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Obj_GetIcdInvoice;
        }

        //End

        //start
        public FARMER GetOdishaFarmerInfo(SMSOdishaFarmerInfoModel Query, string conString)
        {
            FARMER objfar = new FARMER();

            DataSet ds3 = new DataSet();
            try
            {
                // DataConnection objData3 = new DataConnection();
                ds3 = Obj_SMS_DataModel.GetODISHATable(Query, conString);
                DataTable dtfarmer = ds3.Tables[0];
                DataTable dtPeronalDetilas = ds3.Tables[1];
                DataTable dtAddressDetails = ds3.Tables[2];
                DataTable dtFamilyDetails = ds3.Tables[3];
                DataTable dtLoanDetails = ds3.Tables[4];
                DataTable dtBankDetails = ds3.Tables[5];
                DataTable dtLiveStockDetails = ds3.Tables[6];
                DataTable dtAssetDetails = ds3.Tables[7];
                DataTable dtInsuranceDetails = ds3.Tables[8];
                DataTable dtFIGDetails = ds3.Tables[9];
                DataTable dtOwnedLandDetails = ds3.Tables[10];
                DataTable dtLeaseLandDetails = ds3.Tables[11];
                DataTable dtCropDetails = ds3.Tables[12];
                DataTable dtsellingDetails = ds3.Tables[13];
                DataTable dtReasonForSelling = ds3.Tables[14];
                DataTable dtStockReason = ds3.Tables[15];

                List<FARMERDETAILS> objlstfar = new List<FARMERDETAILS>();
                for (int i = 0; i < dtfarmer.Rows.Count; i++)
                {
                    FARMERDETAILS Obj_farmerdetails = new FARMERDETAILS();
                    Obj_farmerdetails.FARMERCODE = dtfarmer.Rows[i]["FarmerCode"].ToString();
                    Obj_farmerdetails.FARMERNAME = dtfarmer.Rows[i]["FarmerName"].ToString();
                    Obj_farmerdetails.GENDER = dtfarmer.Rows[i]["Gender"].ToString();
                    Obj_farmerdetails.TOTALNOOFOWNLAND = Convert.ToDecimal(dtfarmer.Rows[i]["TotalNoOfOwnLand"].ToString() == "" ? "0.00" : dtfarmer.Rows[i]["TotalNoOfOwnLand"].ToString());
                    Obj_farmerdetails.TOTALNOOFLEASELAN = Convert.ToDecimal(dtfarmer.Rows[i]["TotalNoOfLeaseLand"].ToString() == "" ? "0.00" : dtfarmer.Rows[i]["TotalNoOfLeaseLand"].ToString());
                    Obj_farmerdetails.TOTALLANDHOLDING = Convert.ToDecimal(dtfarmer.Rows[i]["TotalLandHolding"].ToString() == "" ? "0.00" : dtfarmer.Rows[i]["TotalLandHolding"].ToString());
                    Obj_farmerdetails.FARMERCLASSIFICATION = dtfarmer.Rows[i]["FarmerClassification"].ToString();
                    Obj_farmerdetails.AREAUNDERMAIZE = Convert.ToDecimal(dtfarmer.Rows[i]["AreaUnderMaize"].ToString() == "" ? "0.00" : dtfarmer.Rows[i]["AreaUnderMaize"].ToString());
                    Obj_farmerdetails.TOTALPRODUCTIONOFMAIZE = Convert.ToDecimal(dtfarmer.Rows[i]["TotalProductionOfMaize"].ToString() == "" ? "0.00" : dtfarmer.Rows[i]["TotalProductionOfMaize"].ToString());
                    Obj_farmerdetails.TOTALQUANTITYSOLD = Convert.ToDecimal(dtfarmer.Rows[i]["TotalQuantitySold"].ToString() == "" ? "0.00" : dtfarmer.Rows[i]["TotalQuantitySold"].ToString());
                    Obj_farmerdetails.SOLDPRICE = Convert.ToDouble(dtfarmer.Rows[i]["SoldPrice"].ToString() == "" ? "0.00" : dtfarmer.Rows[i]["SoldPrice"].ToString());
                    Obj_farmerdetails.STOCKWHICHNOTSOLD = Convert.ToDecimal(dtfarmer.Rows[i]["StockWhichNotSold"].ToString() == "" ? "0.00" : dtfarmer.Rows[i]["StockWhichNotSold"].ToString());
                    //Obj_farmerdetails.FIGName = dtfarmer.Rows[i]["FIGName"].ToString();
                    //Obj_farmerdetails.FPOName = dtfarmer.Rows[i]["FPOName"].ToString();
                    //Obj_farmerdetails.BlockName = dtfarmer.Rows[i]["BlockName"].ToString();
                    try
                    {
                        var personaldtls = (from e in dtPeronalDetilas.AsEnumerable() where e.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (personaldtls.Count != 0)
                        {
                            List<PERSONALDETAILS> objpersonal = new List<PERSONALDETAILS>();
                            DataTable dt = dtPeronalDetilas.AsEnumerable().Where(r => r.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                PERSONALDETAILS objperdtl = new PERSONALDETAILS();
                                objperdtl.MARITALSTATUS = dt.Rows[j]["MaritalStatus"].ToString();
                                objperdtl.PHONENO = Convert.ToInt32(dt.Rows[j]["PhoneNo"].ToString() == "" ? "0" : dt.Rows[j]["PhoneNo"].ToString());
                                objperdtl.EMAILID = dt.Rows[j]["EmailID"].ToString();
                                objperdtl.FARMERTYPE = dt.Rows[j]["FarmerType"].ToString();
                                objperdtl.EDUCATIONQUALIFICATION = dt.Rows[j]["EducationQualification"].ToString();
                                objperdtl.CASTEORCATEGORY = dt.Rows[j]["CasteOrCategory"].ToString();
                                objperdtl.RELIGION = dt.Rows[j]["Religion"].ToString();
                                objperdtl.POVERTYLINE = dt.Rows[j]["PovertyLine"].ToString();
                                //objperdtl.PovertyLine = dt.Rows[j]["PovertyLine"].ToString();
                                objperdtl.MINORITY = dt.Rows[j]["Minority"].ToString();
                                objperdtl.GROSSINCOMEOFINDIVIDUAL = Convert.ToDouble(dt.Rows[j]["GrossIncomeofIndividual"].ToString() == "" ? "0.00" : dt.Rows[j]["GrossIncomeofIndividual"].ToString());
                                objpersonal.Add(objperdtl);
                            }
                            Obj_farmerdetails.PERSONALDETAILS = objpersonal;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    try
                    {
                        var addrdtl = (from e in dtAddressDetails.AsEnumerable() where e.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (addrdtl.Count != 0)
                        {
                            List<ADDRESS> objAddress = new List<ADDRESS>();
                            DataTable dt = dtAddressDetails.AsEnumerable().Where(r => r.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                ADDRESS objadd = new ADDRESS();
                                objadd.ADDRESSTYPE = dt.Rows[j]["AddressType"].ToString();
                                objadd.COUNTRY = dt.Rows[j]["Country"].ToString();
                                objadd.STATE = dt.Rows[j]["State"].ToString();
                                objadd.DISTRICT = dt.Rows[j]["District"].ToString();
                                objadd.BLOCK = dt.Rows[j]["Block"].ToString();
                                objadd.GP = dt.Rows[j]["GP"].ToString();
                                objadd.ADDRESS1 = dt.Rows[j]["Address1"].ToString();
                                objadd.ADDRESS2 = dt.Rows[j]["Address2"].ToString();
                                objadd.PINCODE = Convert.ToInt32(dt.Rows[j]["Pincode"].ToString() == "" ? "0" : dt.Rows[j]["Pincode"].ToString());
                                objAddress.Add(objadd);
                            }
                            Obj_farmerdetails.ADDRESS = objAddress;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    try
                    {
                        var famdtl = (from e in dtFamilyDetails.AsEnumerable() where e.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (famdtl.Count != 0)
                        {
                            List<FAMILYDETAILS> objFamily = new List<FAMILYDETAILS>();
                            DataTable dt = dtFamilyDetails.AsEnumerable().Where(r => r.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FAMILYDETAILS objfam = new FAMILYDETAILS();
                                objfam.FARMERDOB = dt.Rows[j]["FarmerDOB"].ToString();
                                objfam.GENDER = dt.Rows[j]["Gender"].ToString();
                                objfam.RELATIONSHIP = dt.Rows[j]["Relationship"].ToString();
                                objfam.HIGHESTEDUCATION = dt.Rows[j]["HighestEducation"].ToString();
                                objfam.OCCUPATION = dt.Rows[j]["Occupation"].ToString();
                                objfam.GROSSINCOMEOFFAMILY = Convert.ToDouble(dt.Rows[j]["GrossIncomeofFamily"].ToString() == "" ? "0.00" : dt.Rows[j]["GrossIncomeofFamily"].ToString());
                                objfam.FAMILYTYPE = dt.Rows[j]["FamilyType"].ToString();
                                objfam.FAMILYMEMBERNAME = dt.Rows[j]["FamilyMemberName"].ToString();
                                objFamily.Add(objfam);
                            }
                            Obj_farmerdetails.FAMILYDETAILS = objFamily;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    try
                    {
                        var loandtl = (from e in dtLoanDetails.AsEnumerable() where e.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (loandtl.Count != 0)
                        {
                            List<LOANDETAILS> objLoanDtl = new List<LOANDETAILS>();
                            DataTable dt = dtLoanDetails.AsEnumerable().Where(r => r.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                LOANDETAILS objln = new LOANDETAILS();
                                objln.LOANTYPE = dt.Rows[j]["LoanType"].ToString();
                                objln.LOANFROM = dt.Rows[j]["LoanFrom"].ToString();
                                objln.INSTITUTIONBORROWEDFROM = dt.Rows[j]["InstitutionBorrowedFrom"].ToString();
                                objln.LOANTENURE = dt.Rows[j]["LoanTenure"].ToString();
                                objln.INTERESTRATE = Convert.ToDouble(dt.Rows[j]["InterestRate"].ToString() == "" ? "0.00" : dt.Rows[j]["InterestRate"].ToString());
                                objln.EMI = dt.Rows[j]["EMI"].ToString();
                                objln.LOANSTARTDATE = dt.Rows[j]["LoanStartDate"].ToString();
                                objln.LOANENDDATE = dt.Rows[j]["LoanEndDate"].ToString();
                                objln.LOANSTATUS = dt.Rows[j]["LoanStatus"].ToString();
                                objLoanDtl.Add(objln);
                            }
                            Obj_farmerdetails.LOANDETAILS = objLoanDtl;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    try
                    {

                        var bankdtls = (from e in dtBankDetails.AsEnumerable() where e.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (bankdtls.Count != 0)
                        {
                            List<BANKDETAILS> objbnkdtl = new List<BANKDETAILS>();
                            DataTable dt = dtBankDetails.AsEnumerable().Where(r => r.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                BANKDETAILS objBank = new BANKDETAILS();

                                objBank.BANKNAME = dt.Rows[j]["BankName"].ToString();
                                objBank.IFSCCODE = dt.Rows[j]["IFSCCode"].ToString();
                                objBank.BRANCHCODE = dt.Rows[j]["BranchCode"].ToString();
                                objBank.BANKACCOUNTNAME = dt.Rows[j]["BankAccountName"].ToString();
                                objBank.BANKACCOUNTNUMBER = dt.Rows[j]["BankAccountNumber"].ToString();
                                objbnkdtl.Add(objBank);
                            }
                            Obj_farmerdetails.BANKDETAILS = objbnkdtl;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    try
                    {
                        var livestockdtls = (from e in dtLiveStockDetails.AsEnumerable() where e.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (livestockdtls.Count != 0)
                        {
                            List<LIVESTOCKDETAILS> objLivestokDtl = new List<LIVESTOCKDETAILS>();
                            DataTable dt = dtLiveStockDetails.AsEnumerable().Where(r => r.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                LIVESTOCKDETAILS objlivestk = new LIVESTOCKDETAILS();
                                objlivestk.LIVESTOCKTYPE = dt.Rows[j]["LivestockType"].ToString();
                                objlivestk.LIVESTOCKSUBTYPE = dt.Rows[j]["LivestockSubType"].ToString();
                                objlivestk.OWNERSHIP = dt.Rows[j]["Ownership"].ToString();
                                objlivestk.NUMBERPROCESSED = Convert.ToInt32(dt.Rows[j]["NumberProcessed"].ToString() == "" ? "0" : dt.Rows[j]["NumberProcessed"].ToString());
                                objlivestk.PURPOSEFORWHICHUSED = dt.Rows[j]["PurposeForWhichUsed"].ToString();
                                objlivestk.PRICE = Convert.ToDouble(dt.Rows[j]["Price"].ToString() == "" ? "0.00" : dt.Rows[j]["Price"].ToString());
                                objlivestk.UOM = dt.Rows[j]["UOM"].ToString();
                                objLivestokDtl.Add(objlivestk);
                            }
                            Obj_farmerdetails.LIVESTOCKDETAILS = objLivestokDtl;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    try
                    {
                        var assetdtls = (from e in dtAssetDetails.AsEnumerable() where e.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (assetdtls.Count != 0)
                        {
                            List<ASSETDETAILS> objAssetDtl = new List<ASSETDETAILS>();
                            DataTable dt = dtAssetDetails.AsEnumerable().Where(r => r.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                ASSETDETAILS objasst = new ASSETDETAILS();
                                objasst.ASSETTYPE = dt.Rows[j]["AssetType"].ToString();
                                objasst.ASSETSUBTYPE = dt.Rows[j]["AssetSubType"].ToString();
                                objasst.OWNERSHIP = dt.Rows[j]["Ownership"].ToString();
                                objasst.HIREDFROMORHIREDTO = dt.Rows[j]["HiredFromOrHiredTo"].ToString();
                                objasst.NOOFASSETS = Convert.ToInt32(dt.Rows[j]["NoofAssets"].ToString() == "" ? "0" : dt.Rows[j]["NoofAssets"].ToString());
                                objasst.PURPOSEFORWHICHUSED = dt.Rows[j]["PurposeforWhichUsed"].ToString();
                                objasst.ASSESTMANUFACTURER = dt.Rows[j]["AssestManufacturer"].ToString();
                                objasst.YEARPURCHASED = dt.Rows[j]["YearPurchased"].ToString();
                                objasst.ASSETSERIALNO = dt.Rows[j]["AssetSerialNo"].ToString();
                                objAssetDtl.Add(objasst);
                            }
                            Obj_farmerdetails.ASSETDETAILS = objAssetDtl;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    try
                    {
                        var insuarncedtls = (from e in dtInsuranceDetails.AsEnumerable() where e.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (insuarncedtls.Count != 0)
                        {
                            List<INSURANCE> objInsurDtl = new List<INSURANCE>();
                            DataTable dt = dtInsuranceDetails.AsEnumerable().Where(r => r.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                INSURANCE objinsrnce = new INSURANCE();
                                objinsrnce.INSURERNAME = dt.Rows[j]["InsurerName"].ToString();
                                objinsrnce.AGENCYNAME = dt.Rows[j]["AgencyName"].ToString();
                                objinsrnce.INSURANCETYPE = dt.Rows[j]["InsuranceType"].ToString();
                                objinsrnce.INSUREDON = dt.Rows[j]["InsuredOn"].ToString();
                                objinsrnce.POLICYNO = dt.Rows[j]["PolicyNo"].ToString();
                                objinsrnce.MATURITYDATE = dt.Rows[j]["MaturityDate"].ToString();
                                objinsrnce.PREMIUM = dt.Rows[j]["Premium"].ToString();
                                objinsrnce.PAYMENTMODE = dt.Rows[j]["PaymentMode"].ToString();
                                objinsrnce.NOMINEE = dt.Rows[j]["Nominee"].ToString();
                                objInsurDtl.Add(objinsrnce);
                            }
                            Obj_farmerdetails.INSURANCE = objInsurDtl;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    try
                    {
                        var figdtls = (from e in dtFIGDetails.AsEnumerable() where e.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (figdtls.Count != 0)
                        {
                            List<FIG> objFigDtl = new List<FIG>();
                            DataTable dt = dtFIGDetails.AsEnumerable().Where(r => r.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                FIG objfg = new FIG();
                                objfg.FPONAME = dt.Rows[j]["FPOName"].ToString();
                                objfg.VILLAGE = dt.Rows[j]["Village"].ToString();
                                objfg.FIGNAME = dt.Rows[j]["FIGName"].ToString();
                                objFigDtl.Add(objfg);
                            }
                            Obj_farmerdetails.FIG = objFigDtl;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    try
                    {
                        var ownlndtls = (from e in dtOwnedLandDetails.AsEnumerable() where e.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (ownlndtls.Count != 0)
                        {
                            List<OWNEDLAND> objOwnLandtl = new List<OWNEDLAND>();
                            DataTable dt = dtOwnedLandDetails.AsEnumerable().Where(r => r.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                OWNEDLAND objownln = new OWNEDLAND();
                                objownln.OWNERSHIP = dt.Rows[j]["Ownership"].ToString();
                                objownln.LANDTYPE = dt.Rows[j]["LandType"].ToString();
                                objownln.NOOFACRES = Convert.ToDecimal(dt.Rows[j]["NoOfAcres"].ToString() == "" ? "0.00" : dt.Rows[j]["NoOfAcres"].ToString());
                                objownln.SOILTYPE = dt.Rows[j]["SoilType"].ToString();
                                objownln.IRRIGATIONSERVICES = dt.Rows[j]["IrrigationServices"].ToString();
                                objOwnLandtl.Add(objownln);
                            }
                            Obj_farmerdetails.OWNEDLAND = objOwnLandtl;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    try
                    {
                        var leaselndtls = (from e in dtLeaseLandDetails.AsEnumerable() where e.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (leaselndtls.Count != 0)
                        {
                            List<LEASELAND> objLeaseLandtl = new List<LEASELAND>();
                            DataTable dt = dtLeaseLandDetails.AsEnumerable().Where(r => r.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                LEASELAND objlseln = new LEASELAND();
                                objlseln.CROPSEASON = dt.Rows[j]["CropSeason"].ToString();
                                objlseln.OWNERSHIP = dt.Rows[j]["Ownership"].ToString();
                                objlseln.NOOFACRES = Convert.ToDecimal(dt.Rows[j]["NoOfAcres"].ToString() == "" ? "0.00" : dt.Rows[j]["NoOfAcres"].ToString());
                                objlseln.SOILTYPE = dt.Rows[j]["SoilType"].ToString();
                                objlseln.IRRIGATIONSERVICES = dt.Rows[j]["IrrigationServices"].ToString();
                                objLeaseLandtl.Add(objlseln);
                            }
                            Obj_farmerdetails.LEASELAND = objLeaseLandtl;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    try
                    {
                        var cropdtls = (from e in dtCropDetails.AsEnumerable() where e.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (cropdtls.Count != 0)
                        {
                            List<CROPDETAILS> objCropdtl = new List<CROPDETAILS>();
                            DataTable dt = dtCropDetails.AsEnumerable().Where(r => r.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                CROPDETAILS objcrop = new CROPDETAILS();
                                objcrop.CROPSEASON = dt.Rows[j]["CropSeason"].ToString();
                                objcrop.CROPTYPE = dt.Rows[j]["CropType"].ToString();
                                objcrop.NOOFACRES = Convert.ToDecimal(dt.Rows[j]["NoOfAcres"].ToString() == "" ? "0.00" : dt.Rows[j]["NoOfAcres"].ToString());
                                objcrop.TOTALPRODUCTION = dt.Rows[j]["TotalProduction"].ToString();
                                objcrop.VARIETY = dt.Rows[j]["Variety"].ToString();
                                objCropdtl.Add(objcrop);
                            }
                            Obj_farmerdetails.CROPDETAILS = objCropdtl;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    try
                    {

                        var sellingdtls = (from e in dtsellingDetails.AsEnumerable() where e.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (sellingdtls.Count != 0)
                        {
                            List<SELLINGDETAILS> objSelltl = new List<SELLINGDETAILS>();
                            DataTable dt = dtsellingDetails.AsEnumerable().Where(r => r.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                SELLINGDETAILS objsell = new SELLINGDETAILS();
                                objsell.CROPSEASON = dt.Rows[j]["CropSeason"].ToString();
                                objsell.QUANTITY = Convert.ToDecimal(dt.Rows[j]["Quantity"].ToString() == "" ? "0.00" : dt.Rows[j]["Quantity"].ToString());
                                objsell.PRICEATWHICHSOLDININR = Convert.ToDouble(dt.Rows[j]["PriceatWhichSoldInINR"].ToString() == "" ? "0.00" : dt.Rows[j]["PriceatWhichSoldInINR"].ToString());
                                objsell.TOWHOMORBUYER = dt.Rows[j]["ToWhomOrBuyer"].ToString();
                                objsell.TERMSOFPAYMENT = dt.Rows[j]["TermsOfPayment"].ToString();
                                objsell.SELLINGDATE = dt.Rows[j]["SellingDate"].ToString();
                                objSelltl.Add(objsell);
                            }
                            Obj_farmerdetails.SELLINGDETAILS = objSelltl;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    try
                    {

                        var rasonforsell = (from e in dtReasonForSelling.AsEnumerable() where e.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (rasonforsell.Count != 0)
                        {
                            List<REASONFORSELLING> objReanForSell = new List<REASONFORSELLING>();
                            DataTable dt = dtReasonForSelling.AsEnumerable().Where(r => r.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                REASONFORSELLING objrfs = new REASONFORSELLING();
                                objrfs.CROPSEASON = dt.Rows[j]["CropSeason"].ToString();
                                objrfs.INPUTSUPPORTSEEDSORFERTILIZERORPESTICIDES = dt.Rows[j]["InputSupportSeedsOrFertilizerOrPesticides"].ToString();
                                objrfs.FINANCIALINDEBTEDNESS = dt.Rows[j]["FinancialIndebtedness"].ToString();
                                objReanForSell.Add(objrfs);
                            }
                            Obj_farmerdetails.REASONFORSELLING = objReanForSell;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    try
                    {
                        var stockreason = (from e in dtStockReason.AsEnumerable() where e.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE select e).ToList();
                        if (stockreason.Count != 0)
                        {
                            List<STOCKSEASON> objStockSeastl = new List<STOCKSEASON>();
                            DataTable dt = dtStockReason.AsEnumerable().Where(r => r.Field<string>("farmer_code") == Obj_farmerdetails.FARMERCODE).CopyToDataTable();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                STOCKSEASON objss = new STOCKSEASON();
                                objss.STOCKWHICHNOTSOLD = dt.Rows[j]["StockWhichNotSold"].ToString();
                                objss.SUPPORTSREQUIRESEEDS = dt.Rows[j]["SupportsRequireSeeds"].ToString();
                                objss.IFALREADYAVAILEDFROMWHOM = dt.Rows[j]["IfAlreadyAvailedFromWhom"].ToString();
                                objss.WHETHERFARMINGFORRABISEASON = dt.Rows[j]["WhetherFarmingForRabiSeason"].ToString();
                                objStockSeastl.Add(objss);
                            }
                            Obj_farmerdetails.STOCKSEASON = objStockSeastl;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    objlstfar.Add(Obj_farmerdetails);
                }
                objfar.FARMERDETAILS = objlstfar;
            }
            catch (Exception ex)
            {
                string msgd = ex.ToString();
                throw ex;
            }
            return objfar;
        }
    }
    //End


    

}
