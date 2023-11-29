using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
   public class Mobile_FDR_FDetailFetch_DB
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Mobile_FDR_FList_DB)); //Declaring Log4Net. 
        public FarmerdetailfetchApplication GetallFarmerdetailfetch_DB(FarmerdetailfetchContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();

            FarmerdetailfetchApplication objinvoiceRoot = new FarmerdetailfetchApplication();
            Mobile_FDR_FDetailFetch_DB objDataModel = new Mobile_FDR_FDetailFetch_DB();

            objinvoiceRoot.context = new FarmerdetailfetchContext();
            objinvoiceRoot.context.Farmerdetailfetch = new List<Farmerdetailfetch>();
            objinvoiceRoot.context.Farmerdetailfetchcrop = new List<Farmerdetailfetchcrop>();
            objinvoiceRoot.context.Farmerdetailfetchcropsowing = new List<Farmerdetailfetchcropsowing>();
            objinvoiceRoot.context.Farmerdetailfetchpersonal = new List<Farmerdetailfetchpersonal>();
            objinvoiceRoot.context.FarmerdetailfetchFamily = new List<FarmerdetailfetchFamily>();
            objinvoiceRoot.context.FarmerdetailfetchOWNEDLAND = new List<FarmerdetailfetchOWNEDLAND>();
            objinvoiceRoot.context.FarmerdetailfetchProduction = new List<FarmerdetailfetchProduction>();
            objinvoiceRoot.context.FarmerdetailfetchLIVESTOCK = new List<FarmerdetailfetchLIVESTOCK>();
            objinvoiceRoot.context.FarmerdetailfetchLoan = new List<FarmerdetailfetchLoan>();
            objinvoiceRoot.context.FarmerdetailfetchLoanRepay = new List<FarmerdetailfetchLoanRepay>();
            objinvoiceRoot.context.FarmerdetailfetchAssets = new List<FarmerdetailfetchAssets>();
            objinvoiceRoot.context.FarmerdetailfetchInsurance = new List<FarmerdetailfetchInsurance>();
            objinvoiceRoot.context.FarmerdetailfetchInputs = new List<FarmerdetailfetchInputs>();
            objinvoiceRoot.context.FarmerdetailfetchSALE = new List<FarmerdetailfetchSALE>();
            objinvoiceRoot.context.FarmerdetailfetchStock = new List<FarmerdetailfetchStock>();
            objinvoiceRoot.context.FarmerdetailfetchTraining = new List<FarmerdetailfetchTraining>();
            objinvoiceRoot.context.FarmerdetailfetchShareholding = new List<FarmerdetailfetchShareholding>();
            objinvoiceRoot.context.FarmerdetailfetchBusiness = new List<FarmerdetailfetchBusiness>();
            objinvoiceRoot.context.FarmerdetailfetchLoanRequrement = new List<FarmerdetailfetchLoanRequrement>();
            objinvoiceRoot.context.FarmerdetailfetchADS = new List<FarmerdetailfetchADS>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("FDRMOB_fetch_Profiledata", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
                cmd.Parameters.Add("Farmer_code", MySqlDbType.VarChar).Value = objinvoice.farmer_code;
                cmd.Parameters.Add("entity_code", MySqlDbType.VarChar).Value = objinvoice.entity_code;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                if (objinvoice.entity_code == "EC_ADDR")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Farmerdetailfetch objList = new Farmerdetailfetch();
                        objList.sno = Convert.ToInt32(dt.Rows[i]["sno"]);
                        objList.farmer_code = dt.Rows[i]["farmer_code"].ToString();
                        objList.ADDR_TYPE = dt.Rows[i]["ADDR_TYPE"].ToString();
                        objList.ADDR_TYPE_desc = dt.Rows[i]["ADDR_TYPE_desc"].ToString();
                        objList.COUNTRY = dt.Rows[i]["COUNTRY"].ToString();
                        objList.EC_STATE = dt.Rows[i]["EC_STATE"].ToString();
                        objList.EC_DIST = dt.Rows[i]["EC_DIST"].ToString();
                        objList.EC_TALUK = dt.Rows[i]["EC_TALUK"].ToString();
                        objList.EC_GRAMPAN = dt.Rows[i]["EC_GRAMPAN"].ToString();
                        objList.EC_VILLAGE = dt.Rows[i]["EC_VILLAGE"].ToString();
                        objList.COUNTRY_desc = dt.Rows[i]["COUNTRY_desc"].ToString();
                        objList.EC_STATE_desc = dt.Rows[i]["EC_STATE_desc"].ToString();
                        objList.EC_DIST_desc = dt.Rows[i]["EC_DIST_desc"].ToString();
                        objList.EC_TALUK_desc = dt.Rows[i]["EC_TALUK_desc"].ToString();
                        objList.EC_GRAMPAN_desc = dt.Rows[i]["EC_GRAMPAN_desc"].ToString();
                        objList.EC_VILLAGE_desc = dt.Rows[i]["EC_VILLAGE_desc"].ToString();
                        objList.EC_ADDR1 = dt.Rows[i]["EC_ADDR1"].ToString();
                        objList.EC_ADDR2 = dt.Rows[i]["EC_ADDR2"].ToString();
                        objList.EC_PINCODE = dt.Rows[i]["EC_PINCODE"].ToString();
                        objinvoiceRoot.context.Farmerdetailfetch.Add(objList);
                    }
                }else if(objinvoice.entity_code == "EC_PRODUCTION")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        FarmerdetailfetchProduction objList = new FarmerdetailfetchProduction();
                    objList.sno = Convert.ToInt32(dt.Rows[i]["sno"]);
                    objList.farmer_code = dt.Rows[i]["farmer_code"].ToString();
                    objList.Year = dt.Rows[i]["Year"].ToString();
                    objList.Year_desc = dt.Rows[i]["Year_desc"].ToString();
                    objList.Season = dt.Rows[i]["Season"].ToString();
                    objList.Season_desc = dt.Rows[i]["Season_desc"].ToString();
                    objList.Croptype = dt.Rows[i]["Croptype"].ToString();
                    objList.Croptype_desc = dt.Rows[i]["Croptype_desc"].ToString();
                    objList.Vareity = dt.Rows[i]["Vareity"].ToString();
                    objList.Vareity_desc = dt.Rows[i]["Vareity_desc"].ToString();
                    objList.ActualProduction = dt.Rows[i]["ActualProduction"].ToString();
                    objinvoiceRoot.context.FarmerdetailfetchProduction.Add(objList);
                    }
                }
                else if (objinvoice.entity_code == "EC_TRAINING")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        FarmerdetailfetchTraining objList = new FarmerdetailfetchTraining();
                        objList.sno = Convert.ToInt32(dt.Rows[i]["sno"]);
                        objList.farmer_code = dt.Rows[i]["farmer_code"].ToString();
                        objList.TRAIN_Date = dt.Rows[i]["TRAIN_Date"].ToString();
                        objList.TRAIN_Agenda = dt.Rows[i]["TRAIN_Agenda"].ToString();
                        objList.TRAIN_Duration = dt.Rows[i]["TRAIN_Duration"].ToString();
                        objList.TRAIN_ExperDet = dt.Rows[i]["TRAIN_ExperDet"].ToString();
                        objList.TRAIN_Season = dt.Rows[i]["TRAIN_Season"].ToString();
                        objList.TRAIN_YEAR = dt.Rows[i]["TRAIN_YEAR"].ToString();
                        objList.TRAIN_Place = dt.Rows[i]["TRAIN_Place"].ToString();                     
                        objinvoiceRoot.context.FarmerdetailfetchTraining.Add(objList);
                    }
                }
                else if (objinvoice.entity_code == "EC_LIVESTOCKDET")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        FarmerdetailfetchLIVESTOCK objList = new FarmerdetailfetchLIVESTOCK();
                        objList.sno = Convert.ToInt32(dt.Rows[i]["sno"]);
                        objList.farmer_code = dt.Rows[i]["farmer_code"].ToString();
                        objList.LSDCOUNT = dt.Rows[i]["LSDCOUNT"].ToString();
                        objList.LSDOWNSHIP = dt.Rows[i]["LSDOWNSHIP"].ToString();
                        objList.LSDPUR = dt.Rows[i]["LSDPUR"].ToString();
                        objList.LSDSUBTYPE = dt.Rows[i]["LSDSUBTYPE"].ToString();
                        objList.LSDTYPE = dt.Rows[i]["LSDTYPE"].ToString();                       
                        objinvoiceRoot.context.FarmerdetailfetchLIVESTOCK.Add(objList);
                    }
                }
                else if (objinvoice.entity_code == "EC_ASSET")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        FarmerdetailfetchAssets objList = new FarmerdetailfetchAssets();
                        objList.sno = Convert.ToInt32(dt.Rows[i]["sno"]);
                        objList.farmer_code = dt.Rows[i]["farmer_code"].ToString();
                        objList.ADCOUNT = dt.Rows[i]["ADCOUNT"].ToString();
                        objList.ADPURPOSE = dt.Rows[i]["ADPURPOSE"].ToString();
                        objList.ADPURYEAR = dt.Rows[i]["ADPURYEAR"].ToString();
                        objList.ADSERIALNO = dt.Rows[i]["ADSERIALNO"].ToString();
                        objList.ADSUBTYPE = dt.Rows[i]["ADSUBTYPE"].ToString();
                        objList.ADTYPE = dt.Rows[i]["ADTYPE"].ToString();
                        objinvoiceRoot.context.FarmerdetailfetchAssets.Add(objList);
                    }
                }
                else if (objinvoice.entity_code == "EC_INSURANCE")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        FarmerdetailfetchInsurance objList = new FarmerdetailfetchInsurance();
                        objList.sno = Convert.ToInt32(dt.Rows[i]["sno"]);
                        objList.farmer_code = dt.Rows[i]["farmer_code"].ToString();
                        objList.AGENCY_NAME = dt.Rows[i]["AGENCY_NAME"].ToString();
                        objList.INSURANCE_TYPE = dt.Rows[i]["INSURANCE_TYPE"].ToString();
                        objList.INSURED_ON = dt.Rows[i]["INSURED_ON"].ToString();
                        objList.INSURER_NAME = dt.Rows[i]["INSURER_NAME"].ToString();
                        objList.MATURITY_DATE = dt.Rows[i]["MATURITY_DATE"].ToString();
                        objList.NOMINEE = dt.Rows[i]["NOMINEE"].ToString();
                        objList.PAYMENT_MODE = dt.Rows[i]["PAYMENT_MODE"].ToString();
                        objList.POLICY_DATE = dt.Rows[i]["POLICY_DATE"].ToString();
                        objList.POLICY_NO = dt.Rows[i]["POLICY_NO"].ToString();
                        objList.PREMIUM = dt.Rows[i]["PREMIUM"].ToString();
                        objinvoiceRoot.context.FarmerdetailfetchInsurance.Add(objList);
                    }
                }
                else if (objinvoice.entity_code == "EC_SALE")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        FarmerdetailfetchSALE objList = new FarmerdetailfetchSALE();
                        objList.sno = Convert.ToInt32(dt.Rows[i]["sno"]);
                        objList.farmer_code = dt.Rows[i]["farmer_code"].ToString();
                        objList.SALE_Buyer = dt.Rows[i]["SALE_Buyer"].ToString();
                        objList.SALE_Croptype = dt.Rows[i]["SALE_Croptype"].ToString();
                        objList.SALE_Price = dt.Rows[i]["SALE_Price"].ToString();
                        objList.SALE_Qty = dt.Rows[i]["SALE_Qty"].ToString();
                        objList.SALE_Remark = dt.Rows[i]["SALE_Remark"].ToString();
                        objList.SALE_Season = dt.Rows[i]["SALE_Season"].ToString();
                        objList.SALE_Terms = dt.Rows[i]["SALE_Terms"].ToString();
                        objList.SALE_Value = dt.Rows[i]["SALE_Value"].ToString();
                        objList.SALE_Vareity = dt.Rows[i]["SALE_Vareity"].ToString();
                        objList.SALE_Year = dt.Rows[i]["SALE_Year"].ToString();
                        objinvoiceRoot.context.FarmerdetailfetchSALE.Add(objList);
                    }
                }
                else if (objinvoice.entity_code == "EC_STOCK")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        FarmerdetailfetchStock objList = new FarmerdetailfetchStock();
                        objList.sno = Convert.ToInt32(dt.Rows[i]["sno"]);
                        objList.farmer_code = dt.Rows[i]["farmer_code"].ToString();
                        objList.Stock_Season = dt.Rows[i]["Stock_Season"].ToString();
                        objList.Stock_Type = dt.Rows[i]["Stock_Type"].ToString();
                        objList.Stock_Unsold = dt.Rows[i]["Stock_Unsold"].ToString();
                        objList.Stock_Variety = dt.Rows[i]["Stock_Variety"].ToString();
                        objList.Stock_year = dt.Rows[i]["Stock_year"].ToString();                      
                        objinvoiceRoot.context.FarmerdetailfetchStock.Add(objList);
                    }
                }
                else if (objinvoice.entity_code == "EC_INPUTS")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        FarmerdetailfetchInputs objList = new FarmerdetailfetchInputs();
                        objList.sno = Convert.ToInt32(dt.Rows[i]["sno"]);
                        objList.farmer_code = dt.Rows[i]["farmer_code"].ToString();
                        objList.EC_INP_Amount = dt.Rows[i]["EC_INP_Amount"].ToString();
                        objList.EC_INP_CropType = dt.Rows[i]["EC_INP_CropType"].ToString();
                        objList.EC_INP_ICName = dt.Rows[i]["EC_INP_ICName"].ToString();
                        objList.EC_INP_Name = dt.Rows[i]["EC_INP_Name"].ToString();
                        objList.EC_INP_Qty = dt.Rows[i]["EC_INP_Qty"].ToString();
                        objList.EC_INP_Rate = dt.Rows[i]["EC_INP_Rate"].ToString();
                        objList.EC_INP_Remarks = dt.Rows[i]["EC_INP_Remarks"].ToString();
                        objList.EC_INP_Season = dt.Rows[i]["EC_INP_Season"].ToString();
                        objList.EC_INP_Type = dt.Rows[i]["EC_INP_Type"].ToString();
                        objList.EC_INP_UsedDate = dt.Rows[i]["EC_INP_UsedDate"].ToString();
                        objList.EC_INP_Variety = dt.Rows[i]["EC_INP_Variety"].ToString();
                        objList.EC_INP_Year = dt.Rows[i]["EC_INP_Year"].ToString();
                        objinvoiceRoot.context.FarmerdetailfetchInputs.Add(objList);
                    }
                }
                else if (objinvoice.entity_code == "EC_LOAN_REPAY")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        FarmerdetailfetchLoanRepay objList = new FarmerdetailfetchLoanRepay();
                        objList.sno = Convert.ToInt32(dt.Rows[i]["sno"]);
                        objList.farmer_code = dt.Rows[i]["farmer_code"].ToString();
                        objList.LOANACCNO = dt.Rows[i]["LOANACCNO"].ToString();
                        objList.LOANREPAYAMT = dt.Rows[i]["LOANREPAYAMT"].ToString();
                        objList.LOANREPAYDATE = dt.Rows[i]["LOANREPAYDATE"].ToString();
                        objList.LOANREPAYMODE = dt.Rows[i]["LOANREPAYMODE"].ToString();                       
                        objinvoiceRoot.context.FarmerdetailfetchLoanRepay.Add(objList);
                    }
                }
                else if (objinvoice.entity_code == "EC_LOAN_REQUIRMENT")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        FarmerdetailfetchLoanRequrement objList = new FarmerdetailfetchLoanRequrement();
                        objList.sno = Convert.ToInt32(dt.Rows[i]["sno"]);
                        objList.farmer_code = dt.Rows[i]["farmer_code"].ToString();
                        objList.REQUIRED = dt.Rows[i]["REQUIRED"].ToString();
                        objList.DESCRIPITION = dt.Rows[i]["DESCRIPITION"].ToString();
                        objList.REQ_AMOUNT = dt.Rows[i]["REQ_AMOUNT"].ToString();
                        objList.REQ_TYPE = dt.Rows[i]["REQ_TYPE"].ToString();
                        objinvoiceRoot.context.FarmerdetailfetchLoanRequrement.Add(objList);
                    }
                }
                else if (objinvoice.entity_code == "EC_SHARE")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        FarmerdetailfetchShareholding objList = new FarmerdetailfetchShareholding();
                        objList.sno = Convert.ToInt32(dt.Rows[i]["sno"]);
                        objList.farmer_code = dt.Rows[i]["farmer_code"].ToString();
                        objList.FIGName = dt.Rows[i]["FIGName"].ToString();
                        objList.FPOName = dt.Rows[i]["FPOName"].ToString();
                        objList.ShareAmount = dt.Rows[i]["ShareAmount"].ToString();
                        objList.Shares = dt.Rows[i]["Shares"].ToString();
                        objinvoiceRoot.context.FarmerdetailfetchShareholding.Add(objList);
                    }
                }
                else if (objinvoice.entity_code == "EC_BUSINESS")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        FarmerdetailfetchBusiness objList = new FarmerdetailfetchBusiness();
                        objList.sno = Convert.ToInt32(dt.Rows[i]["sno"]);
                        objList.farmer_code = dt.Rows[i]["farmer_code"].ToString();
                        objList.BusinessAmount = dt.Rows[i]["BusinessAmount"].ToString();
                        objList.BusinessSegment = dt.Rows[i]["BusinessSegment"].ToString();
                        objList.Description = dt.Rows[i]["Description"].ToString();
                        objList.Period = dt.Rows[i]["Period"].ToString();
                        objinvoiceRoot.context.FarmerdetailfetchBusiness.Add(objList);
                    }
                }
                else if (objinvoice.entity_code == "EC_LOANDET")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        FarmerdetailfetchLoan objList = new FarmerdetailfetchLoan();
                        objList.sno = Convert.ToInt32(dt.Rows[i]["sno"]);
                        objList.farmer_code = dt.Rows[i]["farmer_code"].ToString();
                        objList.LDLOANTYPE = dt.Rows[i]["LDLOANTYPE"].ToString();
                        objList.LDINSTYPE = dt.Rows[i]["LDINSTYPE"].ToString();
                        objList.LDINSNAME = dt.Rows[i]["LDINSNAME"].ToString();
                        objList.LDINSBRANCH = dt.Rows[i]["LDINSBRANCH"].ToString();
                        objList.LDAMOUNT = dt.Rows[i]["LDAMOUNT"].ToString();
                        objList.LDTENOR = dt.Rows[i]["LDTENOR"].ToString();
                        objList.LDINTEREST = dt.Rows[i]["LDINTEREST"].ToString();
                        objList.LDEMI = dt.Rows[i]["LDEMI"].ToString();
                        objList.LDSTARTDATE = dt.Rows[i]["LDSTARTDATE"].ToString();
                        objList.LDACCNO = dt.Rows[i]["LDACCNO"].ToString();
                        objList.LDENDDATE = dt.Rows[i]["LDENDDATE"].ToString();
                        objinvoiceRoot.context.FarmerdetailfetchLoan.Add(objList);
                    }
                }
                else if (objinvoice.entity_code == "EC_PER_FARMER")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Farmerdetailfetchpersonal objList = new Farmerdetailfetchpersonal();
                        objList.sno = Convert.ToInt32(dt.Rows[i]["sno"]);
                        objList.farmer_code = dt.Rows[i]["farmer_code"].ToString();
                        objList.MaritalStatus = dt.Rows[i]["MaritalStatus"].ToString();
                        objList.MaritalStatus_desc = dt.Rows[i]["MaritalStatus_desc"].ToString();
                        objList.eMailId = dt.Rows[i]["eMailId"].ToString();
                        objList.EducationalQuali = dt.Rows[i]["Qualification"].ToString();
                        objList.EducationalQuali_desc = dt.Rows[i]["Qualification_desc"].ToString();
                        objList.PhoneLandline = dt.Rows[i]["Landline"].ToString();
                        objList.Caste = dt.Rows[i]["Caste"].ToString();
                        objList.Caste_desc = dt.Rows[i]["Caste_desc"].ToString();                        
                        objList.Religion = dt.Rows[i]["Religion"].ToString();
                        objList.Religion_desc = dt.Rows[i]["Religion_desc"].ToString();
                        objList.Minority = dt.Rows[i]["Minority"].ToString();
                        objList.Minority_desc = dt.Rows[i]["Minority_desc"].ToString();
                        objList.Mobile = dt.Rows[i]["Mobile"].ToString();
                        objinvoiceRoot.context.Farmerdetailfetchpersonal.Add(objList);
                    }
                }
                else if (objinvoice.entity_code == "EC_FAMILYDET")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        FarmerdetailfetchFamily objList = new FarmerdetailfetchFamily();
                        objList.sno = Convert.ToInt32(dt.Rows[i]["sno"]);
                        objList.farmer_code = dt.Rows[i]["farmer_code"].ToString();
                        objList.FamilyType = dt.Rows[i]["FamilyType"].ToString();
                        objList.FamilyType_desc = dt.Rows[i]["FamilyType_desc"].ToString();
                        objList.Gender = dt.Rows[i]["Gender"].ToString();
                        objList.Gender_desc = dt.Rows[i]["Gender_desc"].ToString();
                        objList.Relationship = dt.Rows[i]["Relationship"].ToString();
                        objList.Relationship_desc = dt.Rows[i]["Relationship_desc"].ToString();
                        objList.HighEduQuali = dt.Rows[i]["HighEduQuali"].ToString();
                        objList.HighEduQuali_desc = dt.Rows[i]["HighEduQuali_desc"].ToString();
                        objList.Occupation = dt.Rows[i]["Occupation"].ToString();
                        objList.Occupation_desc = dt.Rows[i]["Occupation_desc"].ToString();                       
                        objList.FamilyMemberName = dt.Rows[i]["FamilyMemberName"].ToString();
                        objList.DOB = dt.Rows[i]["DOB"].ToString();                        
                        objinvoiceRoot.context.FarmerdetailfetchFamily.Add(objList);
                    }
                }
                else if (objinvoice.entity_code == "EC_OWNEDLAND")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        FarmerdetailfetchOWNEDLAND objList = new FarmerdetailfetchOWNEDLAND();
                        objList.sno = Convert.ToInt32(dt.Rows[i]["sno"]);
                        objList.farmer_code = dt.Rows[i]["farmer_code"].ToString();
                        objList.Irrigation = dt.Rows[i]["Irrigation"].ToString();
                        objList.Irrigation_desc = dt.Rows[i]["Irrigation_desc"].ToString();
                        objList.SoilType = dt.Rows[i]["SoilType"].ToString();
                        objList.SoilType_desc = dt.Rows[i]["SoilType_desc"].ToString();
                        objList.LandType = dt.Rows[i]["LandType"].ToString();
                        objList.LandType_desc = dt.Rows[i]["LandType_desc"].ToString();
                        objList.Ownership = dt.Rows[i]["Ownership"].ToString();
                        objList.Ownership_desc = dt.Rows[i]["Ownership_desc"].ToString();
                        objList.Noof_Acres = Convert.ToDouble(dt.Rows[i]["Noof_Acres"]);
                        objList.Latitude = dt.Rows[i]["Latitude"].ToString();
                        objList.Longitude = dt.Rows[i]["Longitude"].ToString();
                        objList.LandVillage = dt.Rows[i]["LandVillage"].ToString();
                        objList.PolyHouse = dt.Rows[i]["PolyHouse"].ToString();
                        objinvoiceRoot.context.FarmerdetailfetchOWNEDLAND.Add(objList);
                    }
                }               
                else if (objinvoice.entity_code == "EC_CROP")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Farmerdetailfetchcrop objList = new Farmerdetailfetchcrop();
                        objList.sno = Convert.ToInt32(dt.Rows[i]["sno"]);
                        objList.farmer_code = dt.Rows[i]["farmer_code"].ToString();
                        objList.Year = dt.Rows[i]["Year"].ToString();
                        objList.Year_desc = dt.Rows[i]["Year_desc"].ToString();
                        objList.Season = dt.Rows[i]["Season"].ToString();
                        objList.Season_desc = dt.Rows[i]["Season_desc"].ToString();
                        objList.Croptype = dt.Rows[i]["Croptype"].ToString();
                        objList.Croptype_desc = dt.Rows[i]["Croptype_desc"].ToString();
                        objList.Vareity = dt.Rows[i]["Vareity"].ToString();
                        objList.Acres = dt.Rows[i]["Acres"].ToString();
                        objList.Total = dt.Rows[i]["Total"].ToString();
                        objinvoiceRoot.context.Farmerdetailfetchcrop.Add(objList);
                    }
                }
                else if (objinvoice.entity_code == "EC_CROP_SOWING")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Farmerdetailfetchcropsowing objList = new Farmerdetailfetchcropsowing();
                        objList.sno = Convert.ToInt32(dt.Rows[i]["sno"]);
                        objList.farmer_code = dt.Rows[i]["farmer_code"].ToString();
                        objList.Year = dt.Rows[i]["Year"].ToString();
                        objList.Year_desc = dt.Rows[i]["Year_desc"].ToString();
                        objList.Season = dt.Rows[i]["Season"].ToString();
                        objList.Season_desc = dt.Rows[i]["Season_desc"].ToString();
                        objList.Croptype = dt.Rows[i]["Croptype"].ToString();
                        objList.Croptype_desc = dt.Rows[i]["Croptype_desc"].ToString();
                        objList.Vareity = dt.Rows[i]["Vareity"].ToString();
                        objList.SeedName = dt.Rows[i]["SeedName"].ToString();
                        objList.SeedName_desc = dt.Rows[i]["SeedName_desc"].ToString();
                        objList.SeedQty = dt.Rows[i]["SeedQty"].ToString();
                        objList.SowingArea = dt.Rows[i]["SowingArea"].ToString();
                        objList.ExpectedYield = dt.Rows[i]["ExpectedYield"].ToString();
                        objList.Surplus = dt.Rows[i]["Surplus"].ToString();
                        objList.ExpectedPrice = dt.Rows[i]["ExpectedPrice"].ToString();
                        objList.SowingDate = dt.Rows[i]["SowingDate"].ToString();
                        objList.TransactionDate = dt.Rows[i]["TransactionDate"].ToString();
                        objList.DeweedingDate = dt.Rows[i]["DeweedingDate"].ToString();
                        objList.HarvestDate = dt.Rows[i]["HarvestDate"].ToString();
                        objList.Cropclassification = dt.Rows[i]["cropclassification"].ToString();
                        objList.Cropclassification_desc = dt.Rows[i]["Cropclassification_desc"].ToString();  //Ramya added on 18 jun 21
                        objList.Months = dt.Rows[i]["months"].ToString();
                        objList.ExpectedYieldToBeSold = dt.Rows[i]["ExpectedYieldToBeSold"].ToString();
                        objinvoiceRoot.context.Farmerdetailfetchcropsowing.Add(objList);
                    }
                }
                else if (objinvoice.entity_code == "EC_ADS")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        FarmerdetailfetchADS objList = new FarmerdetailfetchADS();
                        objList.sno = Convert.ToInt32(dt.Rows[i]["sno"]);
                        objList.farmer_code = dt.Rows[i]["farmer_code"].ToString();
                        objList.EC_ADS_BANKACC = dt.Rows[i]["EC_ADS_BANKACC"].ToString();
                        objList.EC_ADS_CASTE = dt.Rows[i]["EC_ADS_CASTE"].ToString();
                        objList.EC_ADS_EDUCATION = dt.Rows[i]["EC_ADS_EDUCATION"].ToString();
                        objList.EC_ADS_LF = dt.Rows[i]["EC_ADS_LF"].ToString();
                        objList.EC_ADS_AadharNo = dt.Rows[i]["EC_ADS_AadharNo"].ToString();
                        objList.EC_ADS_FamilyNo = dt.Rows[i]["EC_ADS_FamilyNo"].ToString();
                        objList.EC_ADS_WorkingNo = dt.Rows[i]["EC_ADS_WorkingNo"].ToString();
                        objList.EC_ADS_OICLABOUR = dt.Rows[i]["EC_ADS_OICLABOUR"].ToString();
                        objList.EC_ADS_OICJOB = dt.Rows[i]["EC_ADS_OICJOB"].ToString();
                        objList.EC_ADS_OICBusiness = dt.Rows[i]["EC_ADS_OICBusiness"].ToString();
                        objList.EC_ADS_HOUSE = dt.Rows[i]["EC_ADS_HOUSE"].ToString();                       
                        objList.EC_ADS_TRACTOR = dt.Rows[i]["EC_ADS_TRACTOR"].ToString();
                        objList.EC_ADS_ISTubewell = dt.Rows[i]["EC_ADS_ISTubewell"].ToString();
                        objList.EC_ADS_ISCanal = dt.Rows[i]["EC_ADS_ISCanal"].ToString();
                        objList.EC_ADS_ISFPond = dt.Rows[i]["EC_ADS_ISFPond"].ToString();
                        objList.EC_ADS_PISTRADER = dt.Rows[i]["EC_ADS_PISTRADER"].ToString();
                        objList.EC_ADS_PISGOVT = dt.Rows[i]["EC_ADS_PISGOVT"].ToString();
                        objList.EC_ADS_PISFPO = dt.Rows[i]["EC_ADS_PISFPO"].ToString();
                        objList.EC_ADS_SHCard = dt.Rows[i]["EC_ADS_SHCard"].ToString();
                        objList.EC_ADS_Largeruminants = dt.Rows[i]["EC_ADS_Largeruminants"].ToString();
                        objList.EC_ADS_Poultry = dt.Rows[i]["EC_ADS_Poultry"].ToString();
                        objList.EC_ADS_Smallruminants = dt.Rows[i]["EC_ADS_Smallruminants"].ToString();
                        objList.EC_ADS_Ownland = dt.Rows[i]["EC_ADS_Ownland"].ToString();
                        objList.EC_ADS_Leaseland = dt.Rows[i]["EC_ADS_Leaseland"].ToString();
                        objList.EC_ADS_19_20KA_MAIZE = dt.Rows[i]["EC_ADS_19_20KA_MAIZE"].ToString();
                        objList.EC_ADS_19_20KA_Paddy = dt.Rows[i]["EC_ADS_19_20KA_Paddy"].ToString();
                        objList.EC_ADS_19_20KA_Veg = dt.Rows[i]["EC_ADS_19_20KA_Veg"].ToString();
                        objList.EC_ADS_20_21KA_MAIZE = dt.Rows[i]["EC_ADS_20_21KA_MAIZE"].ToString();
                        objList.EC_ADS_20_21KA_Paddy = dt.Rows[i]["EC_ADS_20_21KA_Paddy"].ToString();
                        objList.EC_ADS_20_21KA_Veg = dt.Rows[i]["EC_ADS_20_21KA_Veg"].ToString();
                        objList.EC_ADS_19_20RA_MAIZE = dt.Rows[i]["EC_ADS_19_20RA_MAIZE"].ToString();
                        objList.EC_ADS_19_20RA_Paddy = dt.Rows[i]["EC_ADS_19_20RA_Paddy"].ToString();
                        objList.EC_ADS_19_20RA_Veg = dt.Rows[i]["EC_ADS_19_20RA_Veg"].ToString();
                        objList.EC_ADS_20_21RA_MAIZE = dt.Rows[i]["EC_ADS_20_21RA_MAIZE"].ToString();
                        objList.EC_ADS_20_21RA_Paddy = dt.Rows[i]["EC_ADS_20_21RA_Paddy"].ToString();
                        objList.EC_ADS_20_21RA_Veg = dt.Rows[i]["EC_ADS_20_21RA_Veg"].ToString();
                        objList.EC_ADS_Maizeyieldqtlacre = dt.Rows[i]["EC_ADS_Maizeyieldqtlacre"].ToString();
                        objList.EC_ADS_MaizeyieldKhRa = dt.Rows[i]["EC_ADS_MaizeyieldKhRa"].ToString();
                        objList.EC_ADS_Ragi2020 = dt.Rows[i]["EC_ADS_Ragi2020"].ToString();
                        objList.EC_ADS_Ragi2021 = dt.Rows[i]["EC_ADS_Ragi2021"].ToString();
                        objList.EC_ADS_INSLife = dt.Rows[i]["EC_ADS_INSLife"].ToString();
                        objList.EC_ADS_INSHealth = dt.Rows[i]["EC_ADS_INSHealth"].ToString();
                        objList.EC_ADS_INSCrop = dt.Rows[i]["EC_ADS_INSCrop"].ToString();
                        objList.EC_ADS_LoanVill = dt.Rows[i]["EC_ADS_LoanVill"].ToString();
                        objList.EC_ADS_LoanMFI = dt.Rows[i]["EC_ADS_LoanMFI"].ToString();
                        objList.EC_ADS_LoanBank = dt.Rows[i]["EC_ADS_LoanBank"].ToString();
                        objList.EC_ADS_Kalia = dt.Rows[i]["EC_ADS_Kalia"].ToString();
                        objList.EC_ADS_PMKisanNidhi = dt.Rows[i]["EC_ADS_PMKisanNidhi"].ToString();
                        objList.EC_ADS_eNAMReg = dt.Rows[i]["EC_ADS_eNAMReg"].ToString();
                        objList.EC_ADS_RMCReg = dt.Rows[i]["EC_ADS_RMCReg"].ToString();
                        objList.EC_ADS_INPLTRADER = dt.Rows[i]["EC_ADS_INPLTRADER"].ToString();
                        objList.EC_ADS_INPSOCIETY = dt.Rows[i]["EC_ADS_INPSOCIETY"].ToString();
                        objList.EC_ADS_INPFPO = dt.Rows[i]["EC_ADS_INPFPO"].ToString();
                        objList.EC_ADS_MSTLTRAADER = dt.Rows[i]["EC_ADS_MSTLTRAADER"].ToString();
                        objList.EC_ADS_MSTRMC = dt.Rows[i]["EC_ADS_MSTRMC"].ToString();
                        objList.EC_ADS_MSTFPO = dt.Rows[i]["EC_ADS_MSTFPO"].ToString();
                        objList.EC_ADS_SMPLTRADER = dt.Rows[i]["EC_ADS_SMPLTRADER"].ToString();
                        objList.EC_ADS_SMPRMC = dt.Rows[i]["EC_ADS_SMPRMC"].ToString();
                        objList.EC_ADS_SMPFPO = dt.Rows[i]["EC_ADS_SMPFPO"].ToString();
                        objList.EC_ADS_FPCsharepaidRs = dt.Rows[i]["EC_ADS_FPCsharepaidRs"].ToString();
                        objList.EC_ADS_OMSKuccha = dt.Rows[i]["EC_ADS_OMSKuccha"].ToString();
                        objList.EC_ADS_OMSPucca = dt.Rows[i]["EC_ADS_OMSPucca"].ToString();
                        objList.EC_ADS_DPROAD = dt.Rows[i]["EC_ADS_DPROAD"].ToString();
                        objList.EC_ADS_DPKuccha = dt.Rows[i]["EC_ADS_DPKuccha"].ToString();
                        objList.EC_ADS_DPPucca = dt.Rows[i]["EC_ADS_DPPucca"].ToString();
                        objList.EC_ADS_DPPlatform = dt.Rows[i]["EC_ADS_DPPlatform"].ToString();
                        objList.EC_ADS_RCLWeather = dt.Rows[i]["EC_ADS_RCLWeather"].ToString();
                        objList.EC_ADS_RCLPest = dt.Rows[i]["EC_ADS_RCLPest"].ToString();
                        objList.EC_ADS_RCLPHM = dt.Rows[i]["EC_ADS_RCLPHM"].ToString();
                        objList.EC_ADS_IFPC = dt.Rows[i]["EC_ADS_IFPC"].ToString();
                        objList.EC_ADS_WhetherAggregator = dt.Rows[i]["EC_ADS_WhetherAggregator"].ToString();
                        objList.EC_ADS_maizesoldMonth01 = dt.Rows[i]["EC_ADS_maizesoldMonth01"].ToString();
                        objList.EC_ADS_maizesoldMonth13 = dt.Rows[i]["EC_ADS_maizesoldMonth13"].ToString();
                        objList.EC_ADS_maizesoldMonth3 = dt.Rows[i]["EC_ADS_maizesoldMonth3"].ToString();
                        objList.EC_ADS_FSCob = dt.Rows[i]["EC_ADS_FSCob"].ToString();
                        objList.EC_ADS_FSLoose = dt.Rows[i]["EC_ADS_FSLoose"].ToString();
                        objList.EC_ADS_FSBags = dt.Rows[i]["EC_ADS_FSBags"].ToString();
                        objList.EC_ADS_SMHat = dt.Rows[i]["EC_ADS_SMHat"].ToString();
                        objList.EC_ADS_SMLTRADER = dt.Rows[i]["EC_ADS_SMLTRADER"].ToString();
                        objList.EC_ADS_SMRMC = dt.Rows[i]["EC_ADS_SMRMC"].ToString();
                        objList.EC_ADS_PAYHAT = dt.Rows[i]["EC_ADS_PAYHAT"].ToString();
                        objList.EC_ADS_PAYLTRADER = dt.Rows[i]["EC_ADS_PAYLTRADER"].ToString();
                        objList.EC_ADS_PAYRMC = dt.Rows[i]["EC_ADS_PAYRMC"].ToString();
                        objList.EC_ADS_MAIZE_M = dt.Rows[i]["EC_ADS_MAIZE_M"].ToString();
                        objList.EC_ADS_MAIZE_F = dt.Rows[i]["EC_ADS_MAIZE_F"].ToString();
                        objList.EC_ADS_MAIZE_DD = dt.Rows[i]["EC_ADS_MAIZE_DD"].ToString();
                        objList.EC_ADS_WHSubsidy = dt.Rows[i]["EC_ADS_WHSubsidy"].ToString();
                        objList.EC_ADS_WRFinance = dt.Rows[i]["EC_ADS_WRFinance"].ToString();
                        objList.EC_ADS_LTHMOBILENO = dt.Rows[i]["EC_ADS_LTHMOBILENO"].ToString();
                        objList.EC_ADS_LTHNAME = dt.Rows[i]["EC_ADS_LTHNAME"].ToString();
                        objList.EC_ADS_GROUPNAME = dt.Rows[i]["EC_ADS_GROUPNAME"].ToString();
                        objList.EC_ADS_NOOFMMACHINE = dt.Rows[i]["EC_ADS_NOOFMMACHINE"].ToString();
                        objList.EC_ADS_WAREHOUSETYPE = dt.Rows[i]["EC_ADS_WAREHOUSETYPE"].ToString();
                        objList.EC_ADS_DISWAREHOUSE = dt.Rows[i]["EC_ADS_DISWAREHOUSE"].ToString();
                        objList.EC_ADS_NTRACTORVILL = dt.Rows[i]["EC_ADS_NTRACTORVILL"].ToString();
                        objList.EC_ADS_NFMMIGRATED = dt.Rows[i]["EC_ADS_NFMMIGRATED"].ToString();
                        objList.EC_ADS_ConcernLRPME = dt.Rows[i]["EC_ADS_ConcernLRPME"].ToString();
                        objList.EC_ADS_SRCLWeather = dt.Rows[i]["EC_ADS_SRCLWeather"].ToString();
                        objList.EC_ADS_SRCLPest = dt.Rows[i]["EC_ADS_SRCLPest"].ToString();
                        objList.EC_ADS_SRCLPHM = dt.Rows[i]["EC_ADS_SRCLPHM"].ToString();
                        objList.EC_ADS_BankAccNo = dt.Rows[i]["EC_ADS_BankAccNo"].ToString();
                        objList.EC_ADS_BankName = dt.Rows[i]["EC_ADS_BankName"].ToString();
                        objList.EC_ADS_BankBranName = dt.Rows[i]["EC_ADS_BankBranName"].ToString();
                        objList.EC_ADS_BankIFSC = dt.Rows[i]["EC_ADS_BankIFSC"].ToString();
                        objList.EC_ADS_SHARECERT = dt.Rows[i]["EC_ADS_SHARECERT"].ToString();                       
                        objList.EC_ADS_SHARECERTNO = dt.Rows[i]["EC_ADS_SHARECERTNO"].ToString();                    
                        objinvoiceRoot.context.FarmerdetailfetchADS.Add(objList);
                    }
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
    }
}
