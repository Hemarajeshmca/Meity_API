using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
   public class SMSOdishaFarmerInfoModel
    {
        public string FROMDATE { get; set; }
        public string TODATE { get; set; }
        public string InstanceName { get; set; }
    }

    public class FARMER
    {
        public List<FARMERDETAILS> FARMERDETAILS { get; set; }
    }
    public class FARMERDETAILS
    {
        public string FARMERCODE { get; set; }
        public string FARMERNAME { get; set; }
        public string GENDER { get; set; }
        public decimal TOTALNOOFOWNLAND { get; set; }
        public decimal TOTALNOOFLEASELAN { get; set; }
        public decimal TOTALLANDHOLDING { get; set; }
        public string FARMERCLASSIFICATION{ get; set; }
        public decimal AREAUNDERMAIZE { get; set; }
        public decimal TOTALPRODUCTIONOFMAIZE { get; set; }
        public decimal TOTALQUANTITYSOLD { get; set; }
        public double SOLDPRICE { get; set; }
        public decimal STOCKWHICHNOTSOLD { get; set; }
        //public string FIGName { get; set; }
        //public string FPOName { get; set; }
        //public string BlockName { get; set; }
        public List<PERSONALDETAILS> PERSONALDETAILS { get; set; }
        public List<ADDRESS> ADDRESS { get; set; }
        public List<FAMILYDETAILS> FAMILYDETAILS { get; set; }
        public List<LOANDETAILS> LOANDETAILS { get; set; }
        public List<BANKDETAILS> BANKDETAILS { get; set; }
        public List<LIVESTOCKDETAILS> LIVESTOCKDETAILS { get; set; }
        public List<ASSETDETAILS> ASSETDETAILS { get; set; }
        public List<INSURANCE> INSURANCE { get; set; }
        public List<FIG> FIG { get; set; }
        public List<OWNEDLAND> OWNEDLAND { get; set; }
        public List<LEASELAND> LEASELAND { get; set; }
        public List<CROPDETAILS> CROPDETAILS { get; set; }
        public List<SELLINGDETAILS> SELLINGDETAILS { get; set; }
        public List<REASONFORSELLING> REASONFORSELLING { get; set; }
        public List<STOCKSEASON> STOCKSEASON { get; set; }
    }
    public class PERSONALDETAILS
    {
        public string MARITALSTATUS{ get; set; }
        public int PHONENO{ get; set; }
        public string EMAILID{ get; set; }
        public string FARMERTYPE{ get; set; }
        public string EDUCATIONQUALIFICATION{ get; set; }
        public string CASTEORCATEGORY{ get; set; }
        public string RELIGION { get; set; }
        public string POVERTYLINE { get; set; }
        public string MINORITY { get; set; }
        public double GROSSINCOMEOFINDIVIDUAL { get; set; }
    }

    public class ADDRESS
    {
        public string ADDRESSTYPE { get; set; }

        public string COUNTRY { get; set; }

        public string STATE { get; set; }

        public string DISTRICT { get; set; }

        public string BLOCK { get; set; }

        public string GP { get; set; }

        public string VILLAGE { get; set; }

        public string ADDRESS1 { get; set; }

        public string ADDRESS2 { get; set; }

        public int PINCODE { get; set; }
    }
    public class FAMILYDETAILS
    {

        public string FARMERDOB { get; set; }

        public string GENDER { get; set; }

        public string RELATIONSHIP { get; set; }

        public string HIGHESTEDUCATION { get; set; }

        public string OCCUPATION { get; set; }

        public double GROSSINCOMEOFFAMILY { get; set; }
        //
        //public string FarmerCode { get; set; }
        //
        //public string FarmerName { get; set; }

        public int NUMBEROFFAMILYMEMBERS { get; set; }

        public string FAMILYTYPE { get; set; }

        public string FAMILYMEMBERNAME { get; set; }
    }
    public class LOANDETAILS
    {

        public string LOANTYPE { get; set; }

        public string LOANFROM { get; set; }

        public string INSTITUTIONBORROWEDFROM { get; set; }

        public string LOANTENURE { get; set; }

        public double INTERESTRATE { get; set; }

        public string EMI { get; set; }

        public string LOANSTARTDATE { get; set; }

        public string LOANENDDATE { get; set; }

        public string LOANSTATUS { get; set; }
    }
    public class BANKDETAILS
    {

        public string BANKNAME { get; set; }

        public string IFSCCODE { get; set; }

        public string BRANCHCODE { get; set; }

        public string BANKACCOUNTNAME { get; set; }

        public string BANKACCOUNTNUMBER { get; set; }
        //
        //public string BankCode { get; set; }
        //
        //public string BankAccNo { get; set; }
        //
        //public string BankAccType { get; set; }
    }
    public class LIVESTOCKDETAILS
    {

        public string LIVESTOCKTYPE { get; set; }

        public string LIVESTOCKSUBTYPE{ get; set; }

        public string OWNERSHIP { get; set; }

        public int NUMBERPROCESSED { get; set; }

        public string PURPOSEFORWHICHUSED { get; set; }

        public double PRICE { get; set; }

        public string UOM { get; set; }
    }
    public class ASSETDETAILS
    {

        public string ASSETTYPE { get; set; }

        public string ASSETSUBTYPE { get; set; }

        public string OWNERSHIP { get; set; }

        public string HIREDFROMORHIREDTO { get; set; }

        public int NOOFASSETS { get; set; }

        public string PURPOSEFORWHICHUSED{ get; set; }

        public string ASSESTMANUFACTURER{ get; set; }

        public string YEARPURCHASED { get; set; }

        public string ASSETSERIALNO{ get; set; }
    }
    public class INSURANCE
    {

        public string INSURERNAME { get; set; }

        public string AGENCYNAME { get; set; }

        public string INSURANCETYPE { get; set; }

        public string INSUREDON { get; set; }

        public string POLICYNO { get; set; }

        public string MATURITYDATE { get; set; }

        public string PREMIUM { get; set; }

        public string PAYMENTMODE { get; set; }

        public string NOMINEE { get; set; }
    }
    public class FIG
    {

        public string FPONAME { get; set; }

        public string VILLAGE { get; set; }

        public string FIGNAME { get; set; }
    }
    public class OWNEDLAND
    {

        public string OWNERSHIP  { get; set; }

        public string LANDTYPE  { get; set; }

        public decimal NOOFACRES { get; set; }

        public string SOILTYPE  { get; set; }

        public string IRRIGATIONSERVICES { get; set; }
    }
    public class LEASELAND
    {

        public string CROPSEASON { get; set; }

        public string OWNERSHIP { get; set; }

        public decimal NOOFACRES { get; set; }

        public string LANDTYPE { get; set; }

        public string SOILTYPE { get; set; }

        public string IRRIGATIONSERVICES { get; set; }
    }
    public class CROPDETAILS
    {

        public string CROPSEASON { get; set; }

        public string CROPTYPE { get; set; }

        public decimal NOOFACRES { get; set; }

        public string TOTALPRODUCTION { get; set; }

        public string VARIETY { get; set; }
    }
    public class SELLINGDETAILS
    {

        public string CROPSEASON { get; set; }

        public decimal QUANTITY { get; set; }

        public double PRICEATWHICHSOLDININR { get; set; }

        public string TOWHOMORBUYER { get; set; }

        public string TERMSOFPAYMENT { get; set; }

        public string SELLINGDATE { get; set; }
    }
    public class REASONFORSELLING
    {

        public string CROPSEASON { get; set; }

        public string INPUTSUPPORTSEEDSORFERTILIZERORPESTICIDES { get; set; }

        public string FINANCIALINDEBTEDNESS { get; set; }
    }
    public class STOCKSEASON
    {

        public string STOCKWHICHNOTSOLD { get; set; }

        public string SUPPORTSREQUIRESEEDS { get; set; }

        public string IFALREADYAVAILEDFROMWHOM { get; set; }

        public string WHETHERFARMINGFORRABISEASON { get; set; }
    }

}
