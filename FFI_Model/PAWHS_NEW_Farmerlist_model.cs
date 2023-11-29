using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class PAWHS_NEW_Farmerlist_model
    {
    }
    #region list
    public class PAWHSFarmerList
    {
        public int farmer_rowid { get; set; }
        public string farmer_code { get; set; }
        public string farmer { get; set; }
        public string fhw_name { get; set; }
        public string farmer_name { get; set; }
        public string farmer_dist { get; set; }
        public string farmer_dist_desc { get; set; }
        public string farmer_taluk { get; set; }
        public string farmer_taluk_desc { get; set; }
        public string farmer_panchayat { get; set; }
        public string farmer_panchayat_desc { get; set; }
        public string farmer_village { get; set; }
        public string farmer_village_desc { get; set; }
        public string farmer_surname { get; set; }
        public string farmer_dob { get; set; }
    }


    public class PAWHSFarmerContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public List<PAWHSFarmerList> List { get; set; }
        public string instance { get; set; }
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }
    }
    public class PAWHSFarmerApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }
    }

    public class PAWHSFarmerRootObject
    {
        public PAWHSFarmerContext context { get; set; }
        public PAWHSFarmerApplicationException ApplicationException { get; set; }
    }
    #endregion
}
