using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class PAWHSManageForPickUp_model
    {
    }
    #region list
    public class PAWHSManageForPickUpList
    {
        public int Out_pickup_rowid { get; set; }
        public string Out_farmer_code { get; set; }
        public string Out_farmer_name { get; set; }
        public string Out_pickup_request_id { get; set; }
        public string Out_pickup_date { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_row_timestamp { get; set; }

    }
    public class PAWHSManageForPickUpContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<PAWHSManageForPickUpList> List { get; set; }
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }

    }
    public class PAWHSManageForPickUpApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSManageForPickUpApplication
    {
        public PAWHSManageForPickUpContext context { get; set; }
        public PAWHSManageForPickUpApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region single fetch
    public class PAWHSManageForPickUpFHeader
    {
        public int IOU_pickup_rowid { get; set; }
        public string IOU_farmer_code { get; set; }
        public string In_farmer_name { get; set; }
        public string In_pickup_request_id { get; set; }
        public string In_pickup_date { get; set; }
        public string In_village { get; set; }
        public string In_fig { get; set; }
        public string In_fig_contact_person { get; set; }
        public string In_fig_contact_no { get; set; }
        public string In_pickup_slot_code { get; set; }
        public string In_pickup_slot_desc { get; set; }
        public string In_vehicle_code { get; set; }
        public string In_vehicle_desc { get; set; }
        public string In_vehicle_reg_no { get; set; }
        public string In_quantity { get; set; }
        public string In_warehouse_code { get; set; }
        public string In_warehouse_name { get; set; }
        public string In_max_carry_weight { get; set; }
        public string In_load_sapce_volume { get; set; }
        public string In_load_floor_length { get; set; }
        public string In_load_floor_width { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class PAWHSManageForPickUpFContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSManageForPickUpFHeader Header { get; set; }
        public string farmer_code { get; set; }
        public int pickup_rowid { get; set; }


    }
    public class PAWHSManageForPickUpFApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSManageForPickUpFApplication
    {
        public PAWHSManageForPickUpFContext context { get; set; }
        public PAWHSManageForPickUpFApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region save
    public class PAWHSManageForPickUpSHeader
    {
        public int IOU_pickup_rowid { get; set; }
        public string IOU_farmer_code { get; set; }
        public string In_pickup_request_id { get; set; }
        public string In_pickup_date { get; set; }
        public string In_village { get; set; }
        public string In_fig { get; set; }
        public string In_fig_contact_person { get; set; }
        public string In_fig_contact_no { get; set; }
        public string In_pickup_slot_code { get; set; }
        public string In_vehicle_code { get; set; }
        public string In_vehicle_reg_no { get; set; }
        public string In_quantity { get; set; }
        public string In_warehouse_code { get; set; }
        public string In_max_carry_weight { get; set; }
        public string In_load_sapce_volume { get; set; }
        public string In_load_floor_length { get; set; }
        public string In_load_floor_width { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class PAWHSManageForPickUpSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSManageForPickUpSHeader Header { get; set; }

    }
    public class PAWHSManageForPickUpSDocument
    {
        public PAWHSManageForPickUpSContext context { get; set; }
        public PAWHSManageForPickUpSApplicationException ApplicationException { get; set; }

    }
    public class PAWHSManageForPickUpSApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSManageForPickUpSApplication
    {
        public PAWHSManageForPickUpSDocument document { get; set; }

    }
    #endregion
}
