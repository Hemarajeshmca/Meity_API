using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    public class SMSGetFarmerInfoModel
    {
        public string InstanceName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
    public class dailyprogressModel
    {
        public string InstanceName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
    public class SMSGetFarmerInfoModelOdisha
    {
        public string InstanceName { get; set; }
        public string District { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
       // public string Taluk { get; set; }
    }

    public class Farmerinfo
    {
        public List<FarmerDetailsinfo> FARMERDETAILS { get; set; }
    }
    public class FarmerDetailsinfo
    {
        public string FPONAME { get; set; }
        public string FARMERCODE { get; set; }
        public string FARMERNAME { get; set; }
        public string SURNAME { get; set; }
        public string FATHERNAME { get; set; }
        public DateTime FARMERDOB { get; set; }
        public string FARMERADDRESS1 { get; set; }
        public string FARMERADDRESS2 { get; set; }
        public string FARMERCOUNTRY { get; set; }
        public string FARMERSTATE { get; set; }
        public string FARMERDISTRICT { get; set; }
        public string FARMERTALUK { get; set; }
        public string FARMERPANCHAYAT { get; set; }
        public string FARMERVILLAGE { get; set; }
        public string FARMERPINCODE { get; set; }
        public string GENDER { get; set; }
        public string MOBILENO { get; set; }
        public DateTime REGISTERDATE { get; set; }
        public string LATITUDEANDLONGITUDE { get; set; }
        //public string BankAccountNo { get; set; }
        //public string BankName { get; set; }
        //public string NOOFACRES { get; set; }
       // public string FARMERKYC { get; set; }
        public List<FARMERKYCDETAILS> KYCDETAILS { get; set; }
        public List<FARMERBANKDETAILS> BANKDETAILS { get; set; }
        public List<FARMERPERSONALDETAILS> PERSONALDETAILS { get; set; }
        public List<FARMERFAMILYDETAILS> FAMILYDETAILS { get; set; }
        public List<FARMERASSETDETAILS> ASSETS { get; set; }
        public List<FARMERLOANDETAILS> LOANDETAILS { get; set; }
        public List<FARMERLIVESTOCKDETAILS> LIVESTOCKDETAILS { get; set; }
        public List<FARMEROWNEDLAND> LANDETAILS { get; set; }
        public List<FARMERCROPDETAILS> CROPDETAILS { get; set; }
       


    }
    public class FARMERKYCDETAILS
    {
        public string PROOFDOC { get; set; }
        public string PROOFDOCNO { get; set; }
    }

    public class FARMERBANKDETAILS
    {
        public string BANKACCOUNTNO { get; set; }
        public string BANKNAME  { get; set; }
    }
    public class FARMERPERSONALDETAILS
    {
        public string MARITALSTATUS{ get; set; }
        public string PHONENO{ get; set; }
        public string MOBILENO{ get; set; }
        public string EMAILID{ get; set; }
        public string EDUCATIONQUALIFICATION{ get; set; }
        public string RELIGION{ get; set; }
        public string CASTEORCATEGORY{ get; set; }
       // public string POVERTYLINE  { get; set; }
        public string MINORITY { get; set; }
       // public double GROSSINCOMEOFINDIVIDUAL { get; set; }
    }

    public class FARMERFAMILYDETAILS
    {
        public string FAMILYTYPE
        { get; set; }
        public string FAMILYMEMBER
        { get; set; }
        public string DOB
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
    public class FARMERASSETDETAILS
    {
        public string ASSETTYPE { get; set; }
        public string ASSETSUBTYPE{ get; set; }
       // public string OWNERSHIP { get; set; }
       // public string HIREDFROMORHIREDTO { get; set; }
        public int NOOFASSETS { get; set; }
        public string ASSETSERIALNO { get; set; }
        public string PURCHASEDATE { get; set; }
        public string PURPOSE{ get; set; }
       // public string ASSESTMANUFACTURER { get; set; }
        
       
    }
    public class FARMERLOANDETAILS
    {
        public string LOANTYPE { get; set; }
        public string LOANFROM{ get; set; }
        public string INSTITUTIONBORROWEDFROM{ get; set; }
        public string LOANTENURE{ get; set; }
        public double INTERESTRATE{ get; set; }
        public string EMI{ get; set; }
        public string LOANSTARTDATE{ get; set; }
        public string LOANENDDATE{ get; set; }
        public string LOANSTATUS{ get; set; }
    }
    public class FARMERLIVESTOCKDETAILS
    {
        public string LIVESTOCKTYPE { get; set; }
        public string LIVESTOCKSUBTYPE{ get; set; }
        public string OWNERSHIP { get; set; }
        public int NUMBERPROCESSED { get; set; }
        public string PURPOSEFORWHICHUSED{ get; set; }
      //  public double PRICE { get; set; }
      //  public string UOM{ get; set; }
    }

    public class FARMEROWNEDLAND
    {
        public string OWNERSHIP
        { get; set; }
        public string LANDTYPE
        { get; set; }
        public decimal NOOFACRES
        { get; set; }
        public string SOILTYPE
        { get; set; }
        public string IRRIGATIONSERVICES
        { get; set; }
    }
    /* public class FARMERLEASELAND
    {
        public string CROPSEASON
        { get; set; }
        public string OWNERSHIP
        { get; set; }
        public decimal NOOFACRES
        { get; set; }
        public string LANDTYPE
        { get; set; }
        public string SOILTYPE
        { get; set; }
        public string IRRIGATIONSERVICES
        { get; set; }
    }
    */
    public class FARMERCROPDETAILS
    {
        public string CROPSEASON
        { get; set; }
        public string CROPTYPE
        { get; set; }
        public string VAREITY
        { get; set; }
        public decimal NOOFACRES
        { get; set; }
        public string LANDTYPE
        { get; set; }
      // public int TOTALPRODUCTION { get; set; }
    }
    /*public class FARMERSELLINGDETAILS
    {

        public string CROPSEASON
        { get; set; }
        public decimal QUANTITY
        { get; set; }
        public double PRICE
        { get; set; }
        public string TOWHOMORBUYER
        { get; set; }
        public string TERMSOFPAYMENT
        { get; set; }
        public string SELLINGDATE
        { get; set; }
    }
    */
}
