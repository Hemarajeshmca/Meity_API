using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class PAWHSAggVSFarmap_model
    {
    }
    #region list
    public class PAWHSAggVSFarmapList
    {
        public int In_farmer_rowid { get; set; }
        public string In_farmer_id { get; set; }
        public string In_pa_id { get; set; }
        public string In_given_name { get; set; }
        public string In_sur_name { get; set; }
        public string In_village_code { get; set; }
        public string In_village_name { get; set; }
        public string In_dob { get; set; }
        public string In_gender { get; set; }
        public string In_regd_mobile_no { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class PAWHSAggVSFarmapFilter
    {
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }
              
    }
    public class PAWHSAggVSFarmapContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSAggVSFarmapFilter Filter { get; set; }
        public IList<PAWHSAggVSFarmapList> List { get; set; }

    }
    public class PAWHSAggVSFarmapApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSAggVSFarmapApplication
    {
        public PAWHSAggVSFarmapContext context { get; set; }
        public PAWHSAggVSFarmapApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region fetch
    public class PAWHSAggVSFarmapFHeader
    {
        public int IOU_agg_farmer_rowid { get; set; }
        public string IOU_agg_code { get; set; }
        public string In_aggregator_name { get; set; }
        public string In_village_covered_code { get; set; }
        public string In_village_covered_name { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class PAWHSAggVSFarmapFFarmersNotMapped
    {
        public int In_farmer_rowid { get; set; }
        public string In_farmer_id { get; set; }
        public string In_given_name { get; set; }
        public string In_sur_name { get; set; }
        public string In_village_name { get; set; }
        public string In_dob { get; set; }
        public string In_gender { get; set; }
        public string In_regd_mobile_no { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSAggVSFarmapFContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSAggVSFarmapFHeader Header { get; set; }
        public IList<PAWHSAggVSFarmapFFarmersNotMapped> FarmersNotMapped { get; set; }

    }
    public class PAWHSAggVSFarmapFApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSAggVSFarmapFApplication
    {
        public PAWHSAggVSFarmapFContext context { get; set; }
        public PAWHSAggVSFarmapFApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region save
    public class PAWHSAggVSFarmapSHeader
    {
        public int IOU_agg_farmer_rowid { get; set; }
        public string IOU_agg_code { get; set; }
        public string In_aggregator_name { get; set; }
        public string In_village_covered_code { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class PAWHSAggVSFarmapSFarmersMapped
    {
        public string In_dob { get; set; }
        public string In_farmer_id { get; set; }
        public int In_farmer_rowid { get; set; }
        public string In_gender { get; set; }
        public string In_given_name { get; set; }
        public string In_mode_flag { get; set; }
        public string In_pa_id { get; set; }
        public string In_regd_mobile_no { get; set; }
        public string In_status_code { get; set; }
        public string In_sur_name { get; set; }
        public string In_village_name { get; set; }

    }
    public class PAWHSAggVSFarmapSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSAggVSFarmapSHeader Header { get; set; }
        public IList<PAWHSAggVSFarmapSFarmersMapped> FarmersMapped { get; set; }

    }
    public class PAWHSAggVSFarmapSDocument
    {
        public PAWHSAggVSFarmapSContext context { get; set; }
        public PAWHSAggVSFarmapSApplicationException ApplicationException { get; set; }
    }
    public class PAWHSAggVSFarmapSApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSAggVSFarmapSApplication
    {
        public PAWHSAggVSFarmapSDocument document { get; set; }

    }
    #endregion
}
