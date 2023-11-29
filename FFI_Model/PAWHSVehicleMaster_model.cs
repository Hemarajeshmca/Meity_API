using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class PAWHSVehicleMaster_model
    {
    }
    #region list
    public class PAWHSVehicleMasterList
    {
        public int Out_vehicle_rowid { get; set; }
        public string Out_agg_code { get; set; }
        public string Out_vehicle_code { get; set; }
        public string Out_vehicle_regno { get; set; }
        public string Out_vehicle_manf_name { get; set; }
        public string Out_max_carrry_weight { get; set; }
        public string Out_loadspace_height { get; set; }
        public string Out_loadspace_width { get; set; }
        public string Out_loadspace_length { get; set; }
        public string Out_gps_id { get; set; }
        public string Out_imei_no { get; set; }
        public string Out_sim_no { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_row_timestamp { get; set; }

    }
    public class PAWHSVehicleMasterContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<PAWHSVehicleMasterList> List { get; set; }
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }

    }
    public class PAWHSVehicleMasterApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSVehicleMasterApplication
    {
        public PAWHSVehicleMasterContext context { get; set; }
        public PAWHSVehicleMasterApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region Singlefetch
    public class PAWHSVehicleMasterFHeader
    {
        public string In_vehicle_code { get; set; }
        public string In_vehicle_regno { get; set; }
        public string In_vehicle_manf_name { get; set; }
        public string In_max_carrry_weight { get; set; }
        public string In_loadspace_height { get; set; }
        public string In_loadspace_width { get; set; }
        public string In_loadspace_length { get; set; }
        public string In_gps_id { get; set; }
        public string In_imei_no { get; set; }
        public string In_sim_no { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class PAWHSVehicleMasterFContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSVehicleMasterFHeader Header { get; set; }
        public int vehicle_rowid { get; set; }
        public string agg_code { get; set; }

    }
    public class PAWHSVehicleMasterFApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSVehicleMasterFApplication
    {
        public PAWHSVehicleMasterFContext context { get; set; }
        public PAWHSVehicleMasterFApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region Save
    public class PAWHSVehicleMasterSHeader
    {
        public int IOU_vehicle_rowid { get; set; }
        public string In_agg_code { get; set; }
        public string IOU_vehicle_code { get; set; }
        public string In_vehicle_regno { get; set; }
        public string In_vehicle_manf_name { get; set; }
        public string In_max_carrry_weight { get; set; }
        public string In_loadspace_height { get; set; }
        public string In_loadspace_width { get; set; }
        public string In_loadspace_length { get; set; }
        public string In_gps_id { get; set; }
        public string In_imei_no { get; set; }
        public string In_sim_no { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class PAWHSVehicleMasterSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSVehicleMasterSHeader Header { get; set; }

    }
    public class PAWHSVehicleMasterSDocument
    {
        public PAWHSVehicleMasterSContext context { get; set; }
        public PAWHSVehicleMasterSApplicationException ApplicationException { get; set; }
    }
    public class PAWHSVehicleMasterSApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSVehicleMasterSApplication
    {
        public PAWHSVehicleMasterSDocument document { get; set; }

    }
    #endregion
}
