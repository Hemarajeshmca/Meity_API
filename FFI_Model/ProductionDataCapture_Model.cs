using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    public class ProductionDataCapture_Model
    {
        public string InstanceName { get; set; }
      //  public string FROMDATE { get; set; }
      //  public string TODATE { get; set; }
    }
    public class Result
    {
       public string Reason { get; set; }
       public string Status { get; set; }
    }
     
    public class ProductionDataContext
    { 
        public  List<ProductionDataHeader> Header { get; set; } 
        public Result Result { get; set; }
    }

    public class ProductionDataHeader
    {
        public string FARMER_CODE { get; set; }
        public string FARMER_NAME { get; set; } 
        public string FHWNAME { get; set; }
        public string FARMER_STATE { get; set; }
        public string FARMER_DISTRICT { get; set; }
        public string FARMER_TALUK { get; set; }
        public string FARMER_PANCHAYAT { get; set; }
        public string FARMER_VILLAGE { get; set; }
        public string FPO_NAME { get; set; }
        public string FPO_DISTRICT { get; set; }
        public string FPO_TALUK { get; set; }
        public List<ProductionDataDetails> Detail { get; set; }
    }
    public class ProductionDataDetails
    {
        //public string farmer_code { get; set; }
        public string YEAR { get; set; } 
        public string SEASON { get; set; } 
        public string CROPTYPE { get; set; }
        public string CROPCLASS { get; set; }
        public string VAREITY { get; set; }
        public string SEEDNAME { get; set; }
        public decimal ACTUALPRODUCTION { get; set; }
        public decimal AVAILABLEFORSALE { get; set; }
        public string CREATEDDATE { get; set; }
        public string CREATEDBY { get; set; }
        public int ROW_SLNO { get; set; } 
    }

    public class ProducationDataAApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }

}
