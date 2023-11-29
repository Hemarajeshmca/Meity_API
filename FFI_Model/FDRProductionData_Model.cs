using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
   public class FDRProductionData_Model
    {

    }


    #region FDR-ProductDataCapture

    public class ProductionDataInputParams
    {
        public string InstanceName { get; set; }
        public string In_FPO_Code { get; set; }
        public string In_From_Date { get; set; }
        public string In_To_Date { get; set; }
    }

    public class FDRProductDataCapture
    {
        public List<GetFDRProductionData> FDR_ProductionData { get; set; }
    }
    public class GetFDRProductionData
    {
        public string FPO_NAME { get; set; }
        public string DISTRICT { get; set; }
        public string VILLAGE { get; set; }
        public string FARMER_CODE { get; set; }
        public string FARMER_NAME { get; set; }
        public string SURNAME_NAME { get; set; }
        public string FHW_NAME { get; set; }
        public string GENDER { get; set; }
        public string MOBILENO { get; set; }
        public int YEAR { get; set; }
        public string CROP_SEASON { get; set; }
        public string CROP_CLASSIFICATION { get; set; }
        public string CROP_VARIETY { get; set; }
        public string SEED_NAME { get; set; }
        public decimal ACTUAL_PRODUCTION { get; set; }
        public decimal AVAIALBLE_FOR_SALE { get; set; }
}

    #endregion





}
