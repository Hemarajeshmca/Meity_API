using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
   public class FISFarmermapping_model
    {

    }
    #region list
    public class fpofarmerList
    {
        public string In_sel_flag { get; set; }
        public string In_farmer_code { get; set; }
        public string In_farmer_name { get; set; }
        public string In_sur_name { get; set; }
        public string In_farmer_dob { get; set; }
        public string In_gender_flag { get; set; }
        public string In_gender_flag_desc { get; set; }
        public string In_reg_mobile_no { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_village { get; set; }


    }
    public class fpoFarmerFilter
    {
        public string FilterBy_Option { get; set; }
        public string fpoorgn_code { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }
    }
        public class fpofarmerContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public fpoFarmerFilter Filter { get; set; }
        public IList<fpofarmerList> List { get; set; }

    }
    public class fpofarmerApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class fpofarmerApplication
    {
        public fpofarmerContext context { get; set; }
        public fpofarmerApplicationException ApplicationException { get; set; }

    }
    #endregion

    #region fetch
    public class fpofarmerHeader
    {
        public string In_fpoorgn_desc { get; set; }

    }
    public class Map
    {
        public int In_fpomember_rowid { get; set; }
        public string In_fpomember_code { get; set; }
        public string In_farmer_code { get; set; }
        public string In_member_name { get; set; }
        public string In_member_sur_name { get; set; }
        public string In_member_dob { get; set; }
        public string In_member_gender_flag { get; set; }
        public string In_member_gender_flag_desc { get; set; }
        public string In_member_reg_mob_no { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }
        public string In_village { get; set; }

    }
    public class fpofarmerFContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public fpofarmerHeader Header { get; set; }
        public IList<Map> Map { get; set; }
        public fpoFarmerFilter Filter { get; set; }

    }
    public class fpofarmerFApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class fpofarmerFApplication
    {
        public fpofarmerFContext context { get; set; }
        public fpofarmerFApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region save
    public class fpofarmerSHeader
    {
        public string In_fpoorgn_code { get; set; }

    }
    public class fpofarmerSMap
    {
        public int In_fpomember_rowid { get; set; }
        public string In_fpomember_code { get; set; }
        public string In_farmer_code { get; set; }
        public string In_status_code { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class fpofarmerSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public fpofarmerSHeader Header { get; set; }
        public List<fpofarmerSMap> Map { get; set; }

    }
    public class fpofarmerSDocument
    {
        public fpofarmerSContext context { get; set; }
        public fpofarmerSApplicationException ApplicationException { get; set; }
    }
    public class fpofarmerSApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class fpofarmerSApplication
    {
        public fpofarmerSDocument document { get; set; }

    }
    #endregion
}
