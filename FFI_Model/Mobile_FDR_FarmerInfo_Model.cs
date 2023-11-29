using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    public class MobileFDRFarmerContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public string In_Taluk { get; set; }
    }
    public  class Mobile_FDR_FarmerInfo_Model
    {
       
        public class FDRFarmerNew
        {
            public List<FDRFarmerHeaderNew> FarmerData { get; set; }
        }
        public class FDRFarmerHeaderNew
        {
            public Int32 Farmer_Rowid { get; set; }
            public string FarmerCode { get; set; }
            public string FarmerName { get; set; }
            public string Sur_Name { get; set; }
            public string Father_Name { get; set; }
            public string Farmer_Dob { get; set; }
            public string Farmer_Address1 { get; set; }
            public string Farmer_Country_Code { get; set; }
            public string Farmer_Country { get; set; }
            public string Farmer_State_Code { get; set; }
            public string Farmer_State { get; set; }
            public string Farmer_District_Code { get; set; }
            public string Farmer_District { get; set; }
            public string Farmer_Taluk { get; set; }
            public string Farmer_Taluk_Code { get; set; }
            public string  Farmer_Panchayat_code { get; set; }
            public string Farmer_Panchayat { get; set; }
            public string Farmer_Village { get; set; }
            public string Farmer_Village_Code { get; set; }
            public string Farmer_Hamlet { get; set; }
            public string Farmer_Pincode { get; set; }
            public string Gender { get; set; }
            public string Mobile_No { get; set; }
            public Int32 Photo_Status { get; set; }
            public List<FDRFarmerBankdetails> FarmerBanklDetails { get; set; }
            public List<FDRFarmerkYCDetails> FarmerKYCDetails { get; set; }
            public List<FDRFarmerPersonalDetailsNew> FarmerPersonalDetails { get; set; }
            public List<FDRFarmerAddressDetailsNew> FarmerAddressDetails { get; set; }
            public List<FDRFarmerFamilyDetailsNew> FarmerFamilyDetails { get; set; }
            public List<FDRFarmerLoanDetailsNew> FarmerLoanDetails { get; set; }
            public List<FDRFarmerLoanRepaymentDetailsNew> FarmerLoanRepaymentDetails { get; set; }
            public List<FDRFarmerLandDetailsNew> FarmerLandDetails { get; set; }
            public List<FDRFarmerLiveStockDetailsNew> FarmerLiveStockDetail { get; set; }
            public List<FDRFarmerAssetsDetailsNew> FarmerAssetsDetails { get; set; }
            public List<FDRFarmerInsuranceDetailsNew> FarmerInsuranceDetails { get; set; }
            public List<FDRFarmerCroppingDetailsNew> FarmerCroppingDetails { get; set; }
            public List<FDRFarmerSowingDetailsNew> FarmerSowingDetails { get; set; }
            public List<FDRFarmerInputDetailsNew> FarmerInputDetails { get; set; }
            public List<FDRFarmerProductionDetailsNew> FarmerProductionDetails { get; set; }
            public List<FDRFarmerSaleDetailsNew> FarmerSaleDetails { get; set; }
            public List<FDRFarmerStockDetailsNew> FarmerStockDetails { get; set; }
            public List<FDRFarmerTrainingDetailsNew> FarmerTrainingDetails { get; set; }
            public List<FDRFarmerShareHoldingDetailsNew> FarmerShareHoldingDetails { get; set; }
            public List<FDRFarmerBusinessDetailsNew> FarmerBusinessDetails { get; set; }
            public List<FDRFarmerLoanRequirementDetailsNew> FarmerLoanRequirementDetails { get; set; }
        }
        public class FDRFarmerBankdetails
        {
            public Int32 Bank_Rowid { get; set; }
            public string AccountNo { get; set; }
            public string AccountType { get; set; }
            public string AccountType_Name { get; set; }
            public string Bank { get; set; }
            public string Bank_Name { get; set; }
            public string Branch_code { get; set; }
            public string Branch_Name { get; set; }
            public string IFSCCode { get; set; }
            public string DefaultCreditAccout { get; set; }
            public string DefaultDebitAccout { get; set; }
            public string Status { get; set; }

        }
        public class FDRFarmerkYCDetails
        {
            public Int32 Kyc_Rowid { get; set; }
            public string ProofType_Code { get; set; }
            public string ProofType { get; set; }
            public string ProofSubType { get; set; }

            public string ProofSubType_Code { get; set; }
            public string DocumentNo { get; set; }
            public string ConfirmDocumentNo { get; set; }
            public string ValidTill { get; set; }
            public string Status { get; set; }
            public Int32 Photo_Status { get; set; }

        }
        public class FDRFarmerPersonalDetailsNew
        {
            public Int32 Slno { get; set; }
            public string MaritalStatus { get; set; }

            public string Landline { get; set; }

            public string Mobile { get; set; }

            public string EmailID { get; set; }

            public string Qualification { get; set; }

            public string Religion { get; set; }

            public string Caste { get; set; }

            public string Minority { get; set; }
        }
        public class FDRFarmerAddressDetailsNew
        {
            public Int32 Slno { get; set; }
            public string AddressType { get; set; }

            public string Address { get; set; }

            public string Pincode { get; set; }

            public string Country_Code { get; set; }
            public string Country { get; set; }

            public string State_Code { get; set; }
            public string State { get; set; }
            public string District_Code { get; set; }
            public string District { get; set; }

            public string Taluk_Code { get; set; }
            public string Taluk { get; set; }

            public string Village_Code { get; set; }
            public string Village { get; set; }
            public string Panchayat_code { get; set; }

            public string Panchayat_Name { get; set; }

        }
        public class FDRFarmerFamilyDetailsNew
        {
            public Int32 Slno { get; set; }
            public string FamilyType { get; set; }

            public string FamilyMember { get; set; }

            public string DOB { get; set; }

            public string Gender { get; set; }

            public string Relationship { get; set; }

            public string Qualification { get; set; }

            public string Occupation { get; set; }
        }
        public class FDRFarmerLoanDetailsNew
        {
            public Int32 slno { get; set; }
            public string LoanType { get; set; }

            public string LoanFrom { get; set; }

            public string InstitutionName { get; set; }

            public string Branch { get; set; }

            public string LoanAccountNo { get; set; }

            public string StartDate { get; set; }

            public string EndDate { get; set; }

            public decimal LoanAmount { get; set; }

            public decimal InterestRate { get; set; }

            public string Tenor { get; set; }

            public string EMI { get; set; }
        }
        public class FDRFarmerLoanRepaymentDetailsNew
        {
            public Int32 slno { get; set; }
            public string LoanAccountNo { get; set; }

            public string RepaymentMode { get; set; }

            public string RepaymentDate { get; set; }

            public string RepaymentAmt { get; set; }
        }
        public class FDRFarmerLandDetailsNew
        {
            public Int32 slno { get; set; }
            public string LandType { get; set; }

            public string Ownership { get; set; }

            public decimal NoOfAcres { get; set; }

            public string SoilType { get; set; }

            public string IrrigationSource { get; set; }

            public string Latitude { get; set; }

            public string Longitude { get; set; }
        }
        public class FDRFarmerLiveStockDetailsNew
        {
            public Int32 slno { get; set; }
            public string LivestockType { get; set; }

            public string LivestockSubType { get; set; }

            public string Ownership { get; set; }

            public int NumberProcessed { get; set; }

            public string Purpose { get; set; }
        }
        public class FDRFarmerAssetsDetailsNew
        {
            public Int32 slno { get; set; }
            public string AssetType { get; set; }
            public string AssetSubType { get; set; }
            public int NoofAssets { get; set; }
            public string PurchaseDate { get; set; }
            public string Asset_Sl_No { get; set; }
            public string Purpose { get; set; }
        }
        public class FDRFarmerInsuranceDetailsNew
        {
            public Int32 slno { get; set; }
            public string InsurerType { get; set; }
            public string InsurerName { get; set; }
            public string AgencyName { get; set; }
            public string PolicyNo { get; set; }
            public string InsuredOn { get; set; }
            public string PolicyDate { get; set; }
            public string MaturityDate { get; set; }
            public string Premium { get; set; }
            public string PayMode { get; set; }
            public string Nominee { get; set; }
        }
        public class FDRFarmerCroppingDetailsNew
        {
            public Int32 slno { get; set; }
            public string Year { get; set; }
            public string Season { get; set; }
            public string CropType { get; set; }
            public string Variety { get; set; }
            public string LandSize { get; set; }
            public string LandType { get; set; }

        }
        public class FDRFarmerSowingDetailsNew
        {
            public Int32 slno { get; set; }
            public string Year { get; set; }

            public string Season { get; set; }

            public string CropType { get; set; }

            public string Variety { get; set; }

            public Decimal SeedQty { get; set; }

            public Decimal SowingArea { get; set; }

            public Decimal ExpectedYield { get; set; }

            public Decimal Surplus { get; set; }

            public decimal ExpectedPrice { get; set; }

            public string SowingDate { get; set; }
            public string TransactionDate { get; set; }

            public string DweedingDate { get; set; }

            public string HarvestDate { get; set; }

            public string LandType { get; set; }
        }
        public class FDRFarmerInputDetailsNew
        {
            public Int32 slno { get; set; }
            public string Year { get; set; }

            public string Season { get; set; }

            public string CropType { get; set; }

            public string Variety { get; set; }

            public string ICName { get; set; }

            public string InputType { get; set; }

            public string InputName { get; set; }

            public string UsedDate { get; set; }

            public int Qty { get; set; }

            public decimal Rate { get; set; }

            public decimal Amount { get; set; }

            public string Remarks { get; set; }

            public string LandType { get; set; }
        }
        public class FDRFarmerProductionDetailsNew
        {
            public Int32 slno { get; set; }
            public string Year { get; set; }

            public string Season { get; set; }

            public string CropType { get; set; }

            public string Variety { get; set; }

            public int ActualProduction { get; set; }

            public string LandType { get; set; }
        }
        public class FDRFarmerSaleDetailsNew
        {
            public Int32 slno { get; set; }
            public string Year { get; set; }

            public string Season { get; set; }

            public string CropType { get; set; }

            public string Variety { get; set; }

            public int Quantity { get; set; }

            public decimal SalePrice { get; set; }

            public decimal SaleValue { get; set; }

            public string Buyer { get; set; }

            public string TermsofPayment { get; set; }

            public string Remarks { get; set; }

            public string LandType { get; set; }
        }
        public class FDRFarmerStockDetailsNew
        {
            public Int32 slno { get; set; }
            public string Year { get; set; }

            public string Season { get; set; }

            public string CropType { get; set; }

            public string Variety { get; set; }

            public string StockUnsold { get; set; }

            public string LandType { get; set; }
        }
        public class FDRFarmerTrainingDetailsNew
        {
            public Int32 slno { get; set; }
            public string Year { get; set; }

            public string Season { get; set; }

            public string Agenda { get; set; }

            public string Duration { get; set; }

            public string Place { get; set; }

            public string TrainingDate { get; set; }

            public string ExpertDetails { get; set; }
        }
        public class FDRFarmerShareHoldingDetailsNew
        {
            public Int32 slno { get; set; }
            public string FPOName { get; set; }

            public string FIGName { get; set; }

            public string Shares { get; set; }

            public string Amount { get; set; }
        }
        public class FDRFarmerBusinessDetailsNew
        {
            public Int32 slno { get; set; }
            public string BusinessSegment { get; set; }

            public string Desription { get; set; }

            public string Period { get; set; }

            public string Amount { get; set; }
        }
        public class FDRFarmerLoanRequirementDetailsNew
        {
            public Int32 slno { get; set; }
            public string TypeOfLoan { get; set; }

            public string Desription { get; set; }

            public string WhenRequired { get; set; }

            public string Amount { get; set; }
        }

    }
}
