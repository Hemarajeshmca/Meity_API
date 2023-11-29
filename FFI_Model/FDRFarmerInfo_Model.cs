using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    public class FDRFarmerInfo_Model
    {
        #region GetFarmerInfoNew
        public class FarmerNew
        {
            public List<FarmerHeaderNew> FARMERDATA
            { get; set; }
        }
        public class FarmerHeaderNew
        {
            public string FARMERCODE{ get; set; }
            public string FPONAME { get; set; }
            public string FARMERNAME { get; set; }
            public string SUR_NAME { get; set; }
            public string FATHER_NAME  { get; set; }
            public DateTime FARMER_DOB { get; set; }
            public string FARMER_ADDRESS1 { get; set; }
            public string FARMER_COUNTRY { get; set; }
            public string FARMER_STATE { get; set; }
            public string FARMER_DISTRICT { get; set; }
            public string FARMER_TALUK { get; set; }
            public string FARMER_PANCHAYAT  { get; set; }
            public string FARMER_VILLAGE { get; set; }
            public string FARMER_HAMLET { get; set; }
            public string FARMER_PINCODE { get; set; }
            public string GENDER { get; set; }
            public string MOBILE_NO { get; set; }
            public string FARMER_LATITUDE { get; set; }
            public string FARMER_LONGITUDE { get; set; }
            public List<FarmerBankdetails> FARMERBANKLDETAILS { get; set; }
            public List<FarmerkYCDetails> FARMERKYCDETAILS { get; set; }
            public List<FarmerPersonalDetailsNew> FARMERPERSONALDETAILS { get; set; }
            public List<FarmerAddressDetailsNew> FARMERADDRESSDETAILS{ get; set; }
            public List<FarmerFamilyDetailsNew> FARMERFAMILYDETAILS { get; set; }
            public List<FarmerLoanDetailsNew> FARMERLOANDETAILS { get; set; }
            public List<FarmerLoanRepaymentDetailsNew> FARMERLOANREPAYMENTDETAILS { get; set; }
            public List<FarmerLandDetailsNew> FARMERLANDDETAILS { get; set; }
            public List<FarmerLiveStockDetailsNew> FARMERLIVESTOCKDETAILS { get; set; }
            public List<FarmerAssetsDetailsNew> FARMERASSETSDETAILS { get; set; }
            public List<FarmerInsuranceDetailsNew> FARMERINSURANCEDETAILS{ get; set; }
            public List<FarmerCroppingDetailsNew> FARMERCROPPINGDETAILS { get; set; }
            public List<FarmerSowingDetailsNew>  FARMERSOWINGDETAILS { get; set; }
            public List<FarmerInputDetailsNew> FARMERINPUTDETAILS{ get; set; }
            public List<FarmerProductionDetailsNew> FARMERPRODUCTIONDETAILS { get; set; }
            public List<FarmerSaleDetailsNew> FARMERSALEDETAILS { get; set; }
            public List<FarmerStockDetailsNew> FARMERSTOCKDETAILS { get; set; }
            public List<FarmerTrainingDetailsNew> FARMERTRAININGDETAILS{ get; set; }
            public List<FarmerShareHoldingDetailsNew> FARMERSHAREHOLDINGDETAILS { get; set; }
            public List<FarmerBusinessDetailsNew> FARMERBUSINESSDETAILS { get; set; }
            public List<FarmerLoanRequirementDetailsNew> FARMERLOANREQUIREMENTDETAILS { get; set; }
        }
        public class FarmerBankdetails
        {
            public string ACCOUNTNO
            { get; set; }
            public string ACCOUNTTYPE
            { get; set; }
            public string BANK
            { get; set; }
            public string BRANCH
            { get; set; }
            public string IFSCCODE
            { get; set; }
            public string DEFAULTCREDITACCOUT
            { get; set; }
            public string DEFAULTDEBITACCOUT
            { get; set; }
            public string STATUS
            { get; set; }

        }
        public class FarmerkYCDetails
        {
            public string PROOFTYPE { get; set; }
            public string PROOFSUBTYPE { get; set; }
            public string DOCUMENTNO { get; set; }
            public string CONFIRMDOCUMENTNO { get; set; }
            public DateTime VALIDTILL{ get; set; }
            public string STATUS { get; set; }

        }
        public class FarmerPersonalDetailsNew
        {

            public string MARITALSTATUS
            { get; set; }

            public string LANDLINE
            { get; set; }

            public string MOBILE
            { get; set; }

            public string EMAILID
            { get; set; }

            public string QUALIFICATION
            { get; set; }

            public string RELIGION
            { get; set; }

            public string CASTE
            { get; set; }

            public string MINORITY
            { get; set; }
        }
        public class FarmerAddressDetailsNew
        {

            public string ADDRESSTYPE
            { get; set; }

            public string ADDRESS
            { get; set; }

            public int PINCODE
            { get; set; }

            public string COUNTRY
            { get; set; }

            public string STATE
            { get; set; }

            public string DISTRICT
            { get; set; }

            public string TALUK
            { get; set; }

            public string VILLAGE
            { get; set; }

        }
        public class FarmerFamilyDetailsNew
        {

            public string FAMILYTYPE
            { get; set; }

            public string FAMILYMEMBER
            { get; set; }

            public DateTime DOB
            { get; set; }

            public string GENDER
            { get; set; }

            public string RELATIONSHIP
            { get; set; }

            public string QUALIFICATION
            { get; set; }

            public string OCCUPATION
            { get; set; }
        }
        public class FarmerLoanDetailsNew
        {

            public string LOANTYPE
            { get; set; }

            public string LOANFROM
            { get; set; }

            public string INSTITUTIONNAME
            { get; set; }

            public string BRANCH
            { get; set; }

            public string LOANACCOUNTNO
            { get; set; }

            public DateTime STARTDATE
            { get; set; }

            public DateTime ENDDATE
            { get; set; }

            public decimal LOANAMOUNT
            { get; set; }

            public decimal INTERESTRATE
            { get; set; }

            public string TENOR
            { get; set; }

            public string EMI
            { get; set; }
        }
        public class FarmerLoanRepaymentDetailsNew
        {

            public string LOANACCOUNTNO
            { get; set; }

            public string REPAYMENTMODE
            { get; set; }

            public DateTime REPAYMENTDATE
            { get; set; }

            public string REPAYMENTAMT
            { get; set; }
        }
        public class FarmerLandDetailsNew
        {

            public string LANDTYPE
            { get; set; }

            public string OWNERSHIP
            { get; set; }

            public decimal NOOFACRES
            { get; set; }

            public string SOILTYPE
            { get; set; }

            public string IRRIGATIONSOURCE
            { get; set; }

            public string LATITUDE
            { get; set; }

            public string LONGITUDE
            { get; set; }

            public string VILLAGE
            { get; set; }

            public string POLYHOUSE
            { get; set; }

            public string SlNo  //ramya added 08 Jun 21
            { get; set; }
        }
        public class FarmerLiveStockDetailsNew
        {

            public string LIVESTOCKTYPE
            { get; set; }

            public string LIVESTOCKSUBTYPE
            { get; set; }

            public string OWNERSHIP
            { get; set; }

            public int NUMBERPROCESSED
            { get; set; }

            public string PURPOSE
            { get; set; }
        }
        public class FarmerAssetsDetailsNew
        {
            public string ASSETTYPE
            { get; set; }
            public string ASSETSUBTYPE
            { get; set; }
            public int NOOFASSETS
            { get; set; }
            public DateTime PURCHASEDATE
            { get; set; }
            public string ASSET_SL_NO
            { get; set; }
            public string PURPOSE
            { get; set; }
        }
        public class FarmerInsuranceDetailsNew
        {
            public string INSURERTYPE
            { get; set; }
            public string INSURERNAME
            { get; set; }
            public string AGENCYNAME
            { get; set; }
            public string POLICYNO
            { get; set; }
            public string INSUREDON
            { get; set; }
            public DateTime POLICYDATE
            { get; set; }
            public DateTime MATURITYDATE
            { get; set; }
            public string PREMIUM
            { get; set; }
            public string PAYMODE
            { get; set; }
            public string NOMINEE
            { get; set; }
        }
        public class FarmerCroppingDetailsNew
        {

            public string YEAR { get; set; }
            public string SEASON { get; set; }
            public string CROPTYPE { get; set; }
            public string VARIETY { get; set; }
            public decimal  LANDSIZE { get; set; }
            public string LANDTYPE { get; set; }

        }
        public class FarmerSowingDetailsNew
        {

            public string YEAR
            { get; set; } 

            public string SEASON
            { get; set; }

            public string CROPCLASS
            { get; set; }

            public string CROPTYPE
            { get; set; }

            public string VARIETY
            { get; set; }

            public string SEEDNAME
            { get; set; }

            public Decimal SEEDQTY
            { get; set; }

            public Decimal SOWINGAREA
            { get; set; }

            public Decimal EXPECTEDYIELD
            { get; set; } 

            public decimal EXPECTEDPRICE
            { get; set; } 

            public DateTime SOWINGDATE { get; set; }

            public decimal EXPECYIELDTOBESOLD { get; set; } 
            //public Decimal SURPLUS{ get; set; }
            //public DateTime TRANSACTIONDATE{ get; set; }
            //public DateTime DWEEDINGDATE{ get; set; }
            //public DateTime HARVESTDATE{ get; set; }
            //public string LANDTYPE{ get; set; }
            //public string MONTH{ get; set; }


        }
        public class FarmerInputDetailsNew
        {

            public string YEAR
            { get; set; }

            public string SEASON
            { get; set; }

            public string CROPTYPE
            { get; set; }

            public string VARIETY
            { get; set; }

            public string ICNAME
            { get; set; }

            public string INPUTTYPE
            { get; set; }

            public string INPUTNAME
            { get; set; }

            public DateTime USEDDATE
            { get; set; }

            public int QTY
            { get; set; }

            public decimal RATE
            { get; set; }

            public decimal AMOUNT
            { get; set; }

            public string REMARKS
            { get; set; }

            public string LANDTYPE
            { get; set; }
        }
        public class FarmerProductionDetailsNew
        {

            public string YEAR
            { get; set; }

            public string SEASON
            { get; set; }

            public string CROPTYPE
            { get; set; }

            public string VARIETY
            { get; set; }

            public int ACTUALPRODUCTION
            { get; set; }

            //public string LANDTYPE
            //{ get; set; }

            public string CROPCLASS
            { get; set; }

            public string SEEDNAME
            { get; set; }

            public string AVAILABLEFORSALE
            { get; set; }

            public string LRPNAME
            { get; set; }

        }
        public class FarmerSaleDetailsNew
        {

            public string YEAR
            { get; set; }

            public string SEASON
            { get; set; }

            public string CROPTYPE
            { get; set; }

            public string VARIETY
            { get; set; }

            public int QUANTITY
            { get; set; }

            public decimal SALEPRICE
            { get; set; }

            public decimal SALEVALUE
            { get; set; }

            public string BUYER
            { get; set; }

            public string TERMSOFPAYMENT
            { get; set; }

            public string REMARKS
            { get; set; }

            public string LANDTYPE
            { get; set; }
        }
        public class FarmerStockDetailsNew
        {

            public string YEAR
            { get; set; }

            public string SEASON
            { get; set; }

            public string CROPTYPE
            { get; set; }

            public string VARIETY
            { get; set; }

            public int STOCKUNSOLD
            { get; set; }

            public string LANDTYPE
            { get; set; }
        }
        public class FarmerTrainingDetailsNew
        {

            public string YEAR
            { get; set; }

            public string SEASON
            { get; set; }

            public string AGENDA
            { get; set; }

            public string DURATION
            { get; set; }

            public string PLACE
            { get; set; }

            public DateTime TRAININGDATE
            { get; set; }

            public string EXPERTDETAILS
            { get; set; }
        }
        public class FarmerShareHoldingDetailsNew
        {

            public string FPONAME
            { get; set; }

            public string FIGNAME
            { get; set; }

            public string SHARES
            { get; set; }

            public string AMOUNT
            { get; set; }
        }
        public class FarmerBusinessDetailsNew
        {

            public string BUSINESSSEGMENT
            { get; set; }

            public string DESCRIPTION
            { get; set; }

            public DateTime PERIOD
            { get; set; }

            public string AMOUNT
            { get; set; }
        }
        public class FarmerLoanRequirementDetailsNew
        {
            public string TYPEOFLOAN
            { get; set; }

            public string DESCRIPTION
            { get; set; }

            public string WHENREQUIRED
            { get; set; }

            public string AMOUNT
            { get; set; }
        }
        #endregion

        #region GetFarmerInfoOdisha
        public class GetFarmerInfoOdisha
        {
            public List<GetOdishaFarmers> ODISHAFARMER { get; set; }
        }
        public class GetOdishaFarmers
        {

            public string FPO_NAME { get; set; }
            public string FARMER_CODE { get; set; }
            public string FARMER_NAME { get; set; }
            public string SUR_NAME { get; set; }
            public string FHW_NAME { get; set; }
            public string DOB { get; set; }
            public string DISTRICT { get; set; }
            public string TALUK { get; set; }
            public string GP { get; set; }
            public string VILLAGE { get; set; }
            public string HAMLET { get; set; }
            public string PINCODE { get; set; }
            public string GENDER { get; set; }
            public string MOBILE_NO { get; set; }
             
            public string GROUP_NAME { get; set; }
            public string LOCAL_TRADERS_IN_HAMLET_NAME { get; set; }
            public string LOCAL_TRADERS_IN_MOBILE_NO { get; set; }
            public string NO_OF_MILLING_MACHINE_IN_VILLAGES { get; set; }
            public string NO_OF_TRACTORS_IN_VILLAGES { get; set; }
            public string DISTANCE_OF_WAREHOUSE { get; set; }
            public string WAREHOUSE_TYPE { get; set; }
            public string BANK_ACCOUNT { get; set; }
            public string BANK_ACCOUNT_NO { get; set; }
            public string BANK_NAME { get; set; }
            public string BRANCH_NAME { get; set; }
            public string IFSC_CODE { get; set; }
            public string CASTE { get; set; }
            public string EDUCATION { get; set; }
            public string LEAD_FARMER { get; set; }
            public string AADHAR_NO { get; set; }
            public string FAMILY_NO { get; set; }
            public string WORKING_NO { get; set; }
            public string FAMILY_MEMBER_MIGRATED { get; set; }
            public string OTHER_INCOME_SOURCE_LABOUR { get; set; }
            public string OTHER_INCOME_SOURCE_JOB { get; set; }
            public string OTHER_INCOME_SOURCE_BUSINESS { get; set; }
            public string HOUSE { get; set; }
            public string TRACTOR { get; set; }
            public string IRRIGATIONSOURCE_TUBEWELL { get; set; }
            public string IRRIGATIONSOURCE_CANAL { get; set; }
            public string IRRIGATIONSOURCE_FARMPOND { get; set; }
            public string POP_INFORMATION_SOURCE_LOCAL_TRADER { get; set; }
            public string POP_INFORMATION_SOURCE_GOVT { get; set; }
            public string POP_INFORMATION_SOURCE_FPO { get; set; }
            public string SH_CARD { get; set; }
            public string LARGE_RUMINANTS { get; set; }
            public string POULTRY { get; set; }
            public string SMALL_RUMINANTS { get; set; }
            public string OWN_LAND_ACR { get; set; }
            public string LEASE_LAND_ACR { get; set; }
            public string FY_2019_20_KHARIF_AREA_MAIZE { get; set; }
            public string FY_2019_20_KHARIF_AREA_PADDY { get; set; }
            public string FY_2019_20_KHARIF_AREA_VEG { get; set; }
            public string FY_2020_21_KHARIF_AREA_MAIZE { get; set; }
            public string FY_2020_21_KHARIF_AREA_PADDY { get; set; }
            public string FY_2020_21_KHARIF_AREA_VEG { get; set; }
            public string FY_2019_20_RABI_AREA_MAIZE { get; set; }
            public string FY_2019_20_RABI_AREA_PADDY { get; set; }
            public string FY_2019_20_RABI_AREA_VEG { get; set; }
            public string FY_2020_21_RABI_AREA_MAIZE { get; set; }
            public string FY_2020_21_RABI_AREA_PADDY { get; set; }
            public string FY_2020_21_RABI_AREA_VEG { get; set; }
            public string MAIZE_YIELD_QTL_ACRE { get; set; }
            public string MAIZE_YIELD_KH_RA { get; set; }
            public string RAGI_2020_ACRE { get; set; }
            public string RAGI_2021_ACRE { get; set; }
            public string LIFE_INSURANCE { get; set; }
            public string HEALTH_INSURANCE { get; set; }
            public string CROP_INSURANCE { get; set; }
            public string LOAN_VILLAGE { get; set; }
            public string LOAN_MFI { get; set; }
            public string LOAN_BANK { get; set; }
            public string KALIA { get; set; }
            public string PM_KISAN_NIDHI { get; set; }
            public string REGISTRATION_IN_ENAM { get; set; }
            public string REGISTRATION_IN_RMC { get; set; }
            public string INPUT_PURCHASE_FROM_LOCALTRADER { get; set; }
            public string INPUT_PURCHASE_FROM_SOCIETY { get; set; }
            public string INPUT_PURCHASE_FROM_FPO { get; set; }
            public string MAIZE_SOLD_TO_LOCALTRADER { get; set; }
            public string MAIZE_SOLD_TO_RMC { get; set; }
            public string MAIZE_SOLD_TO_FPO { get; set; }
            public string SOURCE_OF_MARKET_PRICE_LOCALTRADER { get; set; }
            public string SOURCE_OF_MARKET_PRICE_RMC { get; set; }
            public string SOURCE_OF_MARKET_PRICE_FPO { get; set; }
            public string FPC_SHARE_PAID_RS { get; set; }
            public string SHARE_CERTIFICATE { get; set; }
            public string SHARE_CERTIFICATE_NO { get; set; }
            public string OWN_MAIZE_STORAGE_KUCCHA { get; set; }
            public string OWN_MAIZE_STORAGE_PUCCA { get; set; }
            public string DRYING_PRACTICES_ROAD { get; set; }
            public string DRYING_PRACTICES_KUCCHA { get; set; }
            public string DRYING_PRACTICES_PUCCA { get; set; }
            public string DRYING_PRACTICES_PLATFORM { get; set; }
            public string REASON_FOR_CROP_LOSS_WEATHER { get; set; }
            public string REASON_FOR_CROP_LOSS_PEST { get; set; }
            public string REASON_FOR_CROP_LOSS_PHM { get; set; }
            public string SHARE_OF_REASON_FOR_CROP_LOSS_WEATHER { get; set; }
            public string SHARE_OF_REASON_FOR_CROP_LOSS_PEST { get; set; }
            public string SHARE_OF_REASON_FOR_CROP_LOSSL_PHM { get; set; }
            public string INTERESTED_TO_SELL_TO_FPC { get; set; }
            public string WHETHER_AGGREGATOR { get; set; }
            public string MAIZE_SOLD_IN_MONTH_0TO1 { get; set; }
            public string MAIZE_SOLD_IN_MONTH_2TO3 { get; set; }
            public string MAIZE_SOLD_IN_MONTH_3PLUS { get; set; }
            public string FORM_OF_STORAGE_COB { get; set; }
            public string FORM_OF_STORAGE_LOOSE { get; set; }
            public string FORM_OF_STORAGE_BAGS { get; set; }
            public string SALE_OF_MAIZE_TO_HAT { get; set; }
            public string SALE_OF_MAIZE_TO_LOCALTRADER { get; set; }
            public string SALE_OF_MAIZE_TO_RMC { get; set; }
            public string PAYMENT_RECEIVED_IN_DAYS_HAT { get; set; }
            public string PAYMENT_RECEIVED_IN_DAYS_LTRADER { get; set; }
            public string PAYMENT_RECEIVED_IN_DAYS_RMC { get; set; }
            public string IDEA_OF_MAIZE_QC_MOISTURE { get; set; }
            public string IDEA_OF_MAIZE_QC_FUNGUS { get; set; }
            public string IDEA_OF_MAIZE_QC_DD { get; set; }
            public string INTEREST_TO_CWH_SUBSIDY { get; set; }
            public string INTEREST_TO_WR_FINANCE { get; set; }
            public string CONCERN_LRP_ME { get; set; }
        }
        #endregion


        public class FarmerHeaderBasicInfo
        {
            public string FARMERCODE { get; set; }
            public string FPONAME { get; set; }
            public string FARMERNAME { get; set; }
            public string SUR_NAME { get; set; }
            public string FATHER_NAME { get; set; }
            public string GENDER { get; set; }
            public string MOBILE_NO { get; set; }
            public string FARMER_VILLAGE { get; set; }
            public string FARMER_DISTRICT { get; set; }

            //personal details
            //public string MARITALSTATUS { get; set; } 
            //public string LANDLINE { get; set; } 
            //public string MOBILE { get; set; } 
            //public string EMAILID { get; set; } 
            //public string QUALIFICATION { get; set; } 
            //public string RELIGION  { get; set; } 
            //public string CASTE  { get; set; } 
            //public string MINORITY { get; set; }
            public string LATITUDE { get; set; }
            public string LONGITUDE { get; set; }
            //  public List<FarmerPersonalDetailsNew> FARMERPERSONALDETAILS { get; set; }  
        }

        public class FarmerHeaderBankInfo
        {
            public Int64 ROW_ID { get; set; }
            public string FARMERCODE { get; set; }
            public string FPONAME { get; set; }
            public string FARMERNAME { get; set; }
            public string SUR_NAME { get; set; }
            public string FATHER_NAME { get; set; }
            public string GENDER { get; set; }
            public string MOBILE_NO { get; set; }
            public string FARMER_VILLAGE { get; set; }
            public string FARMER_DISTRICT { get; set; }
            //bank details
            public string ACCOUNTNO { get; set; }
            public string ACCOUNTTYPE { get; set; }
            public string BANK  { get; set; }
            public string BRANCH { get; set; }
            public string IFSCCODE { get; set; }
            public string DEFAULTCREDITACCOUT { get; set; }
            public string DEFAULTDEBITACCOUT { get; set; }
            public string STATUS  { get; set; }
            public string LATITUDE { get; set; }
            public string LONGITUDE { get; set; }
        }


        public class FarmerHeaderKYCInfo
        {
            public Int64 ROW_ID { get; set; }
            public string FARMERCODE { get; set; }
            public string FPONAME { get; set; }
            public string FARMERNAME { get; set; }
            public string SUR_NAME { get; set; }
            public string FATHER_NAME { get; set; }
            public string GENDER { get; set; }
            public string MOBILE_NO { get; set; }
            public string FARMER_VILLAGE { get; set; }
            public string FARMER_DISTRICT { get; set; }
            //KYC detailss

            public string PROOFTYPE { get; set; }
            public string PROOFSUBTYPE { get; set; }
            public string DOCUMENTNO { get; set; }
            public string CONFIRMDOCUMENTNO { get; set; }
            public string VALIDTILL { get; set; }
            public string STATUS { get; set; }
            public string LATITUDE { get; set; }
            public string LONGITUDE { get; set; }
        }

        public class FarmerHeaderLandInfo
        {
            public string FARMERCODE { get; set; }
            public string FPONAME { get; set; }
            public string FARMERNAME { get; set; }
            public string SUR_NAME { get; set; }
            public string FATHER_NAME { get; set; }
            public string GENDER { get; set; }
            public string MOBILE_NO { get; set; }
            public string FARMER_VILLAGE { get; set; }
            public string FARMER_DISTRICT { get; set; }
            //Land details

            public string LANDTYPE { get; set; }
            public string OWNERSHIP { get; set; }
            public decimal NOOFACRES { get; set; }
            public string SOILTYPE { get; set; }
            public string IRRIGATIONSOURCE{ get; set; }
            public string LATITUDE { get; set; }
            public string LONGITUDE{ get; set; }
            public string VILLAGE { get; set; }
            public string POLYHOUSE { get; set; }
            public Int64 ROW_SlNo{ get; set; }
        }

        public class FarmerHeaderSowingInfo
        {
            public string FARMERCODE { get; set; }
            public string FPONAME { get; set; }
            public string FARMERNAME { get; set; }
            public string SUR_NAME { get; set; }
            public string FATHER_NAME { get; set; }
            public string GENDER { get; set; }
            public string MOBILE_NO { get; set; }
            public string FARMER_VILLAGE { get; set; }
            public string FARMER_DISTRICT { get; set; }
            //Sowing Details

            public string YEAR { get; set; }
            public string SEASON { get; set;}
            public string CROPCLASS { get; set;} 
            public string CROPTYPE { get; set; } 
            public string VARIETY { get; set; } 
            public string SEEDNAME { get; set; } 
            public Decimal SEEDQTY { get; set; } 
            public Decimal SOWINGAREA { get; set; } 
            public Decimal EXPECTEDYIELD { get; set; } 
            public decimal EXPECTEDPRICE { get; set; } 
            public string SOWINGDATE { get; set; } 
            public decimal EXPECYIELDTOBESOLD { get; set; }
            public Int64 ROW_SlNo { get; set; }
            public string LATITUDE { get; set; }
            public string LONGITUDE { get; set; }
        }

        public class FarmerBasicInfoNew
        {
            public List<FarmerHeaderBasicInfo> FARMERBASICINFODETAILS  { get; set; }
        }
        public class FarmerBankInfoNew
        {
            public List<FarmerHeaderBankInfo> FARMERBANKLDETAILS { get; set; }
        }
        public class FarmerKYCInfoNew
        {
            public List<FarmerHeaderKYCInfo> FARMERKYCDETAILS { get; set; }
        }
        public class FarmerLandInfoNew
        {
            public List<FarmerHeaderLandInfo> FARMERLANDDETAILS { get; set; }
        }
        public class FarmerSowingInfoNew
        {
            public List<FarmerHeaderSowingInfo> FARMERSOWINGDETAILS { get; set; }
        } 

    }
}
