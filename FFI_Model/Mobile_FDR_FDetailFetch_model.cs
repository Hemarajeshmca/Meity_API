using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class Mobile_FDR_FDetailFetch_model
    {
    }
    #region detailfetch
    public class Farmerdetailfetch
    {
        public string farmer_code { get; set; }
        public string ADDR_TYPE { get; set; }
        public string ADDR_TYPE_desc { get; set; }
        public string COUNTRY { get; set; }
        public string EC_STATE { get; set; }
        public string EC_DIST { get; set; }
        public string EC_TALUK { get; set; }
        public string EC_GRAMPAN { get; set; }
        public string EC_VILLAGE { get; set; }
        public string COUNTRY_desc { get; set; }
        public string EC_STATE_desc { get; set; }
        public string EC_DIST_desc { get; set; }
        public string EC_TALUK_desc { get; set; }
        public string EC_GRAMPAN_desc { get; set; }
        public string EC_VILLAGE_desc { get; set; }
        public string EC_ADDR1 { get; set; }
        public string EC_ADDR2 { get; set; }
        public string EC_PINCODE { get; set; }
        public int sno { get; set; }

    }
    public class Farmerdetailfetchcrop
    {
        public string farmer_code { get; set; }
        public string Year { get; set; }
        public string Year_desc { get; set; }
        public string Season { get; set; }
        public string Season_desc { get; set; }
        public string Croptype { get; set; }
        public string Croptype_desc { get; set; }
        public string Vareity { get; set; }
        public string Acres { get; set; }
        public string Total { get; set; }
        public int sno { get; set; }
    }
    public class FarmerdetailfetchProduction
    {
        public string farmer_code { get; set; }
        public string Year { get; set; }
        public string Year_desc { get; set; }
        public string Season { get; set; }
        public string Season_desc { get; set; }
        public string Croptype { get; set; }
        public string Croptype_desc { get; set; }
        public string Vareity { get; set; }
        public string Vareity_desc { get; set; }
        public string ActualProduction { get; set; }
        public int sno { get; set; }
    }
    public class Farmerdetailfetchcropsowing
    {
        public string farmer_code { get; set; }
        public string Year { get; set; }
        public string Year_desc { get; set; }
        public string Season { get; set; }
        public string Season_desc { get; set; }
        public string Croptype { get; set; }
        public string Croptype_desc { get; set; }
        public string Vareity { get; set; }
        public string SeedName { get; set; }
        public string SeedName_desc { get; set; }
        public string UOM { get; set; }
        public string SeedQty { get; set; }
        public string SowingArea { get; set; }
        public string ExpectedYield { get; set; }
        public string Surplus { get; set; }
        public string ExpectedPrice { get; set; }
        public string SowingDate { get; set; }
        public string TransactionDate { get; set; }
        public string DeweedingDate { get; set; }
        public string HarvestDate { get; set; }
        public string Cropclassification { get; set; }
        public string Cropclassification_desc { get; set; } //Ramya added on 18 jun 21
        public string Months { get; set; }
        public int sno { get; set; }
        public string ExpectedYieldToBeSold { get; set; }
    }
    public class Farmerdetailfetchpersonal
    {
        public string farmer_code { get; set; }
        public string MaritalStatus { get; set; }
        public string MaritalStatus_desc { get; set; }
        public string eMailId { get; set; }
        public string EducationalQuali { get; set; }
        public string EducationalQuali_desc { get; set; }
        public string PhoneLandline { get; set; }
        public string Caste { get; set; }
        public string Caste_desc { get; set; }
        public string Religion { get; set; }
        public string Religion_desc { get; set; }
        public string Minority { get; set; }
        public string Minority_desc { get; set; }
        public string Mobile { get; set; }

        public int sno { get; set; }

    }
    public class FarmerdetailfetchFamily
    {
        public string farmer_code { get; set; }
        public string FamilyType { get; set; }
        public string FamilyType_desc { get; set; }
        public string Gender { get; set; }
        public string Gender_desc { get; set; }
        public string Relationship { get; set; }
        public string Relationship_desc { get; set; }
        public string HighEduQuali { get; set; }
        public string HighEduQuali_desc { get; set; }
        public string Occupation { get; set; }
        public string Occupation_desc { get; set; }
        public string FamilyMemberName { get; set; }
        public string DOB { get; set; }
        public int sno { get; set; }

    }
    public class FarmerdetailfetchOWNEDLAND
    {
        public string farmer_code { get; set; }
        public string Irrigation { get; set; }
        public string Irrigation_desc { get; set; }
        public string SoilType { get; set; }
        public string SoilType_desc { get; set; }
        public string LandType { get; set; }
        public string LandType_desc { get; set; }
        public string Ownership { get; set; }
        public string Ownership_desc { get; set; }
        public double Noof_Acres { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string LandVillage { get; set; }

        public string PolyHouse { get; set; }
        public int sno { get; set; }

    }
    public class FarmerdetailfetchLIVESTOCK
    {
        public string farmer_code { get; set; }
        public string LSDCOUNT { get; set; }
        public string LSDOWNSHIP { get; set; }
        public string LSDPUR { get; set; }
        public string LSDSUBTYPE { get; set; }
        public string LSDTYPE { get; set; }
        public int sno { get; set; }

    }
    public class FarmerdetailfetchLoanRepay
    {
        public string farmer_code { get; set; }
        public string LOANACCNO { get; set; }
        public string LOANREPAYAMT { get; set; }
        public string LOANREPAYDATE { get; set; }
        public string LOANREPAYMODE { get; set; }
        public int sno { get; set; }

    }
    public class FarmerdetailfetchAssets
    {
        public string farmer_code { get; set; }
        public string ADCOUNT { get; set; }
        public string ADPURPOSE { get; set; }
        public string ADPURYEAR { get; set; }
        public string ADSERIALNO { get; set; }
        public string ADSUBTYPE { get; set; }
        public string ADTYPE { get; set; }
        public int sno { get; set; }

    }
    public class FarmerdetailfetchInsurance
    {
        public string farmer_code { get; set; }
        public string AGENCY_NAME { get; set; }
        public string INSURANCE_TYPE { get; set; }
        public string INSURED_ON { get; set; }
        public string INSURER_NAME { get; set; }
        public string MATURITY_DATE { get; set; }
        public string NOMINEE { get; set; }
        public string PAYMENT_MODE { get; set; }
        public string POLICY_DATE { get; set; }
        public string POLICY_NO { get; set; }
        public string PREMIUM { get; set; }
        public int sno { get; set; }

    }
    public class FarmerdetailfetchInputs
    {
        public string farmer_code { get; set; }
        public string EC_INP_Amount { get; set; }
        public string EC_INP_CropType { get; set; }
        public string EC_INP_ICName { get; set; }
        public string EC_INP_Name { get; set; }
        public string EC_INP_Qty { get; set; }
        public string EC_INP_Rate { get; set; }
        public string EC_INP_Remarks { get; set; }
        public string EC_INP_Season { get; set; }
        public string EC_INP_Type { get; set; }
        public string EC_INP_UsedDate { get; set; }
        public string EC_INP_Variety { get; set; }
        public string EC_INP_Year { get; set; }
        public int sno { get; set; }

    }
    public class FarmerdetailfetchLoan
    {
        public string farmer_code { get; set; }
        public string LDLOANTYPE { get; set; }
        public string LDINSTYPE { get; set; }
        public string LDINSNAME { get; set; }
        public string LDINSBRANCH { get; set; }
        public string LDAMOUNT { get; set; }
        public string LDTENOR { get; set; }
        public string LDINTEREST { get; set; }
        public string LDEMI { get; set; }
        public string LDSTARTDATE { get; set; }
        public string LDACCNO { get; set; }
        public string LDENDDATE { get; set; }
        public int sno { get; set; }

    }
    public class FarmerdetailfetchSALE
    {
        public string farmer_code { get; set; }
        public string SALE_Buyer { get; set; }
        public string SALE_Croptype { get; set; }
        public string SALE_Price { get; set; }
        public string SALE_Qty { get; set; }
        public string SALE_Remark { get; set; }
        public string SALE_Season { get; set; }
        public string SALE_Terms { get; set; }
        public string SALE_Value { get; set; }
        public string SALE_Vareity { get; set; }
        public string SALE_Year { get; set; }
        public int sno { get; set; }

    }
    public class FarmerdetailfetchStock
    {
        public string farmer_code { get; set; }
        public string Stock_Season { get; set; }
        public string Stock_Type { get; set; }
        public string Stock_Unsold { get; set; }
        public string Stock_Variety { get; set; }
        public string Stock_year { get; set; }
        public int sno { get; set; }

    }
    public class FarmerdetailfetchTraining
    {
        public string farmer_code { get; set; }
        public string TRAIN_Date { get; set; }
        public string TRAIN_Agenda { get; set; }
        public string TRAIN_Duration { get; set; }
        public string TRAIN_ExperDet { get; set; }
        public string TRAIN_Season { get; set; }
        public string TRAIN_YEAR { get; set; }
        public string TRAIN_Place { get; set; }
        public int sno { get; set; }

    }
    public class FarmerdetailfetchShareholding
    {
        public string farmer_code { get; set; }
        public string FIGName { get; set; }
        public string FPOName { get; set; }
        public string ShareAmount { get; set; }
        public string Shares { get; set; }
        public int sno { get; set; }

    }
    public class FarmerdetailfetchBusiness
    {
        public string farmer_code { get; set; }
        public string BusinessAmount { get; set; }
        public string BusinessSegment { get; set; }
        public string Description { get; set; }
        public string Period { get; set; }
        public int sno { get; set; }

    }
    public class FarmerdetailfetchLoanRequrement
    {
        public string farmer_code { get; set; }
        public string REQUIRED { get; set; }
        public string DESCRIPITION { get; set; }
        public string REQ_AMOUNT { get; set; }
        public string REQ_TYPE { get; set; }
        public int sno { get; set; }

    }
    public class FarmerdetailfetchADS
    {
        public string farmer_code { get; set; }
        public int sno { get; set; }
        public string EC_ADS_BANKACC { get; set; }
        public string EC_ADS_CASTE { get; set; }
        public string EC_ADS_EDUCATION { get; set; }
        public string EC_ADS_LF { get; set; }
        public string EC_ADS_AadharNo { get; set; }
        public string EC_ADS_FamilyNo { get; set; }
        public string EC_ADS_WorkingNo { get; set; }
        public string EC_ADS_OICLABOUR { get; set; }
        public string EC_ADS_OICJOB { get; set; }
        public string EC_ADS_OICBusiness { get; set; }
        public string EC_ADS_HOUSE { get; set; }
        public string EC_ADS_TRACTOR { get; set; }
        public string EC_ADS_ISTubewell { get; set; }
        public string EC_ADS_ISCanal { get; set; }
        public string EC_ADS_ISFPond { get; set; }
        public string EC_ADS_PISTRADER { get; set; }
        public string EC_ADS_PISGOVT { get; set; }
        public string EC_ADS_PISFPO { get; set; }
        public string EC_ADS_SHCard { get; set; }
        public string EC_ADS_Largeruminants { get; set; }
        public string EC_ADS_Poultry { get; set; }
        public string EC_ADS_Smallruminants { get; set; }
        public string EC_ADS_Ownland { get; set; }
        public string EC_ADS_Leaseland { get; set; }
        public string EC_ADS_19_20KA_MAIZE { get; set; }
        public string EC_ADS_19_20KA_Paddy { get; set; }
        public string EC_ADS_19_20KA_Veg { get; set; }
        public string EC_ADS_20_21KA_MAIZE { get; set; }
        public string EC_ADS_20_21KA_Paddy { get; set; }
        public string EC_ADS_20_21KA_Veg { get; set; }
        public string EC_ADS_19_20RA_MAIZE { get; set; }
        public string EC_ADS_19_20RA_Paddy { get; set; }
        public string EC_ADS_19_20RA_Veg { get; set; }
        public string EC_ADS_20_21RA_MAIZE { get; set; }
        public string EC_ADS_20_21RA_Paddy { get; set; }
        public string EC_ADS_20_21RA_Veg { get; set; }
        public string EC_ADS_Maizeyieldqtlacre { get; set; }
        public string EC_ADS_MaizeyieldKhRa { get; set; }
        public string EC_ADS_Ragi2020 { get; set; }
        public string EC_ADS_Ragi2021 { get; set; }
        public string EC_ADS_INSLife { get; set; }
        public string EC_ADS_INSHealth { get; set; }
        public string EC_ADS_INSCrop { get; set; }
        public string EC_ADS_LoanVill { get; set; }
        public string EC_ADS_LoanMFI { get; set; }
        public string EC_ADS_LoanBank { get; set; }
        public string EC_ADS_Kalia { get; set; }
        public string EC_ADS_PMKisanNidhi { get; set; }
        public string EC_ADS_eNAMReg { get; set; }
        public string EC_ADS_RMCReg { get; set; }
        public string EC_ADS_INPLTRADER { get; set; }
        public string EC_ADS_INPSOCIETY { get; set; }
        public string EC_ADS_INPFPO { get; set; }
        public string EC_ADS_MSTLTRAADER { get; set; }
        public string EC_ADS_MSTRMC { get; set; }
        public string EC_ADS_MSTFPO { get; set; }
        public string EC_ADS_SMPLTRADER { get; set; }
        public string EC_ADS_SMPRMC { get; set; }
        public string EC_ADS_SMPFPO { get; set; }
        public string EC_ADS_FPCsharepaidRs { get; set; }
        public string EC_ADS_OMSKuccha { get; set; }
        public string EC_ADS_OMSPucca { get; set; }
        public string EC_ADS_DPROAD { get; set; }
        public string EC_ADS_DPKuccha { get; set; }
        public string EC_ADS_DPPucca { get; set; }
        public string EC_ADS_DPPlatform { get; set; }
        public string EC_ADS_RCLWeather { get; set; }
        public string EC_ADS_RCLPest { get; set; }
        public string EC_ADS_RCLPHM { get; set; }
        public string EC_ADS_IFPC { get; set; }
        public string EC_ADS_WhetherAggregator { get; set; }
        public string EC_ADS_maizesoldMonth01 { get; set; }
        public string EC_ADS_maizesoldMonth13 { get; set; }
        public string EC_ADS_maizesoldMonth3 { get; set; }
        public string EC_ADS_FSCob { get; set; }
        public string EC_ADS_FSLoose { get; set; }
        public string EC_ADS_FSBags { get; set; }
        public string EC_ADS_SMHat { get; set; }
        public string EC_ADS_SMLTRADER { get; set; }
        public string EC_ADS_SMRMC { get; set; }
        public string EC_ADS_PAYHAT { get; set; }
        public string EC_ADS_PAYLTRADER { get; set; }
        public string EC_ADS_PAYRMC { get; set; }
        public string EC_ADS_MAIZE_M { get; set; }
        public string EC_ADS_MAIZE_F { get; set; }
        public string EC_ADS_MAIZE_DD { get; set; }
        public string EC_ADS_WHSubsidy { get; set; }
        public string EC_ADS_WRFinance { get; set; }
        public string EC_ADS_LTHMOBILENO { get; set; }
        public string EC_ADS_LTHNAME { get; set; }
        public string EC_ADS_GROUPNAME { get; set; }
        public string EC_ADS_NOOFMMACHINE { get; set; }
        public string EC_ADS_WAREHOUSETYPE { get; set; }
        public string EC_ADS_DISWAREHOUSE { get; set; }
        public string EC_ADS_NTRACTORVILL { get; set; }
        public string EC_ADS_NFMMIGRATED { get; set; }
        public string EC_ADS_ConcernLRPME { get; set; }
        public string EC_ADS_SRCLWeather { get; set; }
        public string EC_ADS_SRCLPest { get; set; }
        public string EC_ADS_SRCLPHM { get; set; }
        public string EC_ADS_BankAccNo { get; set; }
        public string EC_ADS_BankName { get; set; }
        public string EC_ADS_BankBranName { get; set; }
        public string EC_ADS_BankIFSC { get; set; }
        public string EC_ADS_SHARECERT { get; set; }
        public string EC_ADS_SHARECERTNO { get; set; }
    }
    public class FarmerdetailfetchContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<Farmerdetailfetch> Farmerdetailfetch { get; set; }
        public IList<Farmerdetailfetchcrop> Farmerdetailfetchcrop { get; set; }
        public IList<Farmerdetailfetchcropsowing> Farmerdetailfetchcropsowing { get; set; }

        public IList<Farmerdetailfetchpersonal> Farmerdetailfetchpersonal { get; set; }
        public IList<FarmerdetailfetchFamily> FarmerdetailfetchFamily { get; set; }
        public IList<FarmerdetailfetchOWNEDLAND> FarmerdetailfetchOWNEDLAND { get; set; }
        public IList<FarmerdetailfetchProduction> FarmerdetailfetchProduction { get; set; }
        public IList<FarmerdetailfetchLIVESTOCK> FarmerdetailfetchLIVESTOCK { get; set; }
        public IList<FarmerdetailfetchLoan> FarmerdetailfetchLoan { get; set; }
        public IList<FarmerdetailfetchLoanRepay> FarmerdetailfetchLoanRepay { get; set; }
        public IList<FarmerdetailfetchAssets> FarmerdetailfetchAssets { get; set; }
        public IList<FarmerdetailfetchInsurance> FarmerdetailfetchInsurance { get; set; }
        public IList<FarmerdetailfetchInputs> FarmerdetailfetchInputs { get; set; }
        public IList<FarmerdetailfetchSALE> FarmerdetailfetchSALE { get; set; }
        public IList<FarmerdetailfetchStock> FarmerdetailfetchStock { get; set; }
        public IList<FarmerdetailfetchTraining> FarmerdetailfetchTraining { get; set; }
        public IList<FarmerdetailfetchShareholding> FarmerdetailfetchShareholding { get; set; }
        public IList<FarmerdetailfetchBusiness> FarmerdetailfetchBusiness { get; set; }
        public IList<FarmerdetailfetchLoanRequrement> FarmerdetailfetchLoanRequrement { get; set; }

        public IList<FarmerdetailfetchADS> FarmerdetailfetchADS { get; set; }

        public string instance { get; set; }
        public string farmer_code { get; set; }
        public string entity_code { get; set; }

    }
    public class FarmerdetailfetchApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class FarmerdetailfetchApplication
    {
        public FarmerdetailfetchContext context { get; set; }
        public FarmerdetailfetchApplicationException ApplicationException { get; set; }

    }
    #endregion
}


