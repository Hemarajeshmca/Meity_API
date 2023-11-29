using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class NewPawhsActualProc_Model
    {
    }
    public class PAWHSActualProcurmentRootObject
    {
        public PAWHSActualProcurmentContext context { get; set; }
        public PAWHSActualProcurmentApplicationException ApplicationException { get; set; }
    }
    public class PAWHSActualProcurmentApplication
    {
        public PAWHSActualProcurmentContext context { get; set; }
        public PAWHSActualProcurmentApplicationException ApplicationException { get; set; }

    }
    public class PAWHSActualProcurmentApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSActualProcurmentContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }
        public IList<PAWHSActualProcurmentList> List { get; set; }

    }

    public class PAWHSEstimateActWRApplication
    {
        public PAWHSEstimateActWRContext context { get; set; }
        public PAWHSActualProcurmentApplicationException ApplicationException { get; set; }
    }
    public class PAWHSEstimateActWRContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public string status { get; set; }

        public IList<PAWHSEstimateProcurementList_Mob> Estimate_List { get; set; }
        public IList<PAWHSActualProcurementList_Mob> Actual_List { get; set; }
        public IList<PAWHSActualProcurementList_Mob> Approved_List { get; set; }
    }
    public class PAWHSEstimateProcurementList_Mob
    {
        public Int32 Out_Estm_rowid { get; set; }
        public string Out_LotNo { get; set; }
        public string Out_agg_code { get; set; }
        public string Out_agg_name { get; set; }
        public string Out_Farmer_Code { get; set; }
        public string Out_Farmer_Name { get; set; }
        public string Out_Member_Type { get; set; }
        public string Out_Item_Code { get; set; }
        public string Out_Item_Name { get; set; }
        public double Out_Estimated_Qty { get; set; }
        public double Out_Estimated_Price { get; set; }
        public double Out_Estimated_Value { get; set; }
        public string Out_Estimated_PickupDate { get; set; }
        public string Out_Remarks { get; set; }
        public string Out_Status { get; set; }
        public string Out_actual_date { get; set; }
        public double Out_advance_amt { get; set; }
        public string Out_approve_date { get; set; }
        public string Out_pickup_date { get; set; }
        public string Out_actual_remarks { get; set; }
        public string Out_approved_remarks { get; set; }
        public string Out_pickup_remarks { get; set; }
    }
    public class PAWHSActualProcurementList_Mob
    {
        public Int32 Out_act_rowid { get; set; }
        public string Out_agg_code { get; set; }
        public string Out_agg_name { get; set; }
        public string Out_lotno { get; set; }
        public string Out_farmer_code { get; set; }
        public string Out_farmer_name { get; set; }
        public string Out_member_type { get; set; }
        public string Out_item_code { get; set; }
        public string Out_item_name { get; set; }
        public double Out_actual_qty { get; set; }
        public double Out_actual_price { get; set; }
        public double Out_actual_value { get; set; }
        public string Out_actual_date { get; set; }
        public double Out_advance_amt { get; set; }
        public string Out_approve_date { get; set; }
        public string Out_pickup_date { get; set; }
        public string Out_wr_date { get; set; }
        public Int32 Out_no_of_bags { get; set; }
        public string Out_status { get; set; }
        public string Out_remarks { get; set; }
        public string Out_actual_remarks { get; set; }
        public string Out_approved_remarks { get; set; }
        public string Out_pickup_remarks { get; set; }
        public string Out_wr_remarks { get; set; }
        public string Out_Estimated_PickupDate { get; set; }
    }
    public class PAWHSActualProcurmentList
    {

        public int Out_act_rowid { get; set; }
        public string Out_agg_code { get; set; }
        public string Out_agg_name { get; set; }
        public string Out_date { get; set; }  //ramya added below 4 params on 22 apr 21
        public string Out_Qty { get; set; }
        public string Out_UnitPrice { get; set; }
        public string Out_TotalPrice { get; set; }
        public string Out_lotno { get; set; }
        public string Out_farmer_code { get; set; }
        public string Out_farmer_name { get; set; }
        public string Out_member_type { get; set; }
        public string Out_item_code { get; set; }
        public string Out_item_name { get; set; }
        public string Out_status { get; set; }
        public string Out_row_timestamp { get; set; }
        public string Out_FHW_Name { get; set; }
        public string Out_Village { get; set; }
        public string Out_Taluk { get; set; }
        public string Out_MobileNo { get; set; }

    }

    #region Fetch 

    public class PAWHSActualProcurmentFetchApplication
    {

        public PAWHSActualProcurment_FetchContext context { get; set; }

    }


    public class PAWHSActualProcurment_FetchContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }

        public int IOU_act_rowid { get; set; }
        public string IOU_agg_code { get; set; }
        public string IOU_lotno { get; set; }
        public PAWHSActualProcurment_FetchHeader Header { get; set; }
        public IList<PAWHSActualProcurment_Fetch_QtyDetail> QtyDetail { get; set; }
        public IList<PAWHSActualProcurment_Fetch_OtherDetail> OtherDetail { get; set; }

        public IList<PAWHSActualProcurment_Fetch_OtherDetail1> OtherDetail1 { get; set; }
        public IList<PAWHSActualProcurment_Fetch_SlnoDetail> SlnoDetail { get; set; }
    }

    public class PAWHSActualProcurment_FetchHeader
    {
        public int IOU_act_rowid { get; set; }
        public string IOU_agg_code { get; set; }
        public string IOU_agg_name { get; set; }
        public string IOU_lotno { get; set; }
        public string In_farmer_code { get; set; }

        public string In_farmer_name { get; set; }
        public string In_member_type { get; set; }
        public string In_item_code { get; set; }
        public string In_item_name { get; set; }
        public double In_actual_qty { get; set; }
        public double In_actual_price { get; set; }
        public double In_actual_value { get; set; }
        public double in_advance_amt { get; set; }
        public Int32 In_no_of_bags { get; set; }
        public string in_status { get; set; }
        public string in_actual_remarks { get; set; }
        public string in_approved_remarks { get; set; }
        public string in_pickup_remarks { get; set; }
        public string in_wr_remarks { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_wh_code { get; set; }
        public double In_accepted_qty { get; set; }
        public string In_Estimated_PickDate { get; set; }
        public string In_actual_date { get; set; }
        public string In_approve_date { get; set; }
        public string In_reject_date { get; set; }
        public string In_wr_date { get; set; }
        public double In_payto_farmer { get; set; }
        public string In_actual_attach { get; set; }
        public string In_vehicle_no { get; set; }
        public string In_qcperson_name { get; set; }
        public string In_vehicle_type { get; set; }
        public string In_destination { get; set; }
        public string In_LRP_Name { get; set; }
        public string In_LRP_Mobile_no { get; set; }
        public string In_Payment_type { get; set; }
        public string In_Bank_acc_no { get; set; }
        public string In_cheque_no { get; set; }
        public string In_Buyer_code { get; set; }
        public string In_Buyer_name { get; set; }
        public string In_FHW_Name { get; set; }
        public string In_Village { get; set; }
        public string In_Taluk { get; set; }
        public string In_MobileNo { get; set; }
        public string In_season { get; set; }
    } 
    

    public class PAWHSActualProcurment_Fetch_QtyDetail
    {
        public int In_qty_row_id { get; set; }
        public string In_agg_code { get; set; }
        public string In_lotno { get; set; }
        public string In_item_code { get; set; }
        public string In_qty_code { get; set; }
        public string In_qty_name { get; set; }
        public string In_qty_range { get; set; }
        public string In_qty_unit { get; set; }
        public double In_actual_value { get; set; }
        public double In_wr_qty_value { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSActualProcurment_Fetch_OtherDetail
    {
        public int In_Other_row_id { get; set; }
        public string In_agg_code { get; set; }
        public string In_lotno { get; set; }
        public double In_packaging_cost { get; set; }
        public double In_transporting_cost { get; set; }
        public double In_unpacking_cost { get; set; }
        public double In_local_packaging_cost { get; set; }
        public double In_local_transporting_cost { get; set; }
        public double In_temp_cost { get; set; }
        public double In_temp_cost1 { get; set; }
        public double In_temp_cost2 { get; set; }
        public string In_mode_flag { get; set; }
    }

    public class PAWHSActualProcurment_Fetch_OtherDetail1
    {
        public string In_lotno { get; set; }
        public string In_type { get; set; }
        public double In_value { get; set; }
    }
    public class PAWHSActualProcurment_Fetch_SlnoDetail
    {
        public int In_slno_row_id { get; set; }
        public string In_agg_code { get; set; }
        public string In_lotno { get; set; }
        public string In_slno { get; set; }
        public string In_temp1 { get; set; }
        public string In_temp2 { get; set; }
        public string In_qty { get; set; }
        public string In_mode_flag { get; set; }
    }

    #endregion

    #region Save


    public class PAWHSActualProcurment_Save_Application
    {
        public PAWHSActualProcurment_Save_Document document { get; set; }


    }
    public class PAWHSActualProcurment_Save_Document
    {
        public PAWHSActualProcurment_Save_Context context { get; set; }
        public PAWHSActualProcurmentApplicationException ApplicationException { get; set; }

    }

    public class PAWHSActualProcurment_Save_Context
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<PAWHSActualProcurment_Save_QtyDetail> QtyDetail { get; set; }
        public IList<PAWHSActualProcurment_Save_OtherDetail> OtherDetail { get; set; }
        public IList<PAWHSActualProcurment_Save_SlnoDetail> SlnoDetail { get; set; }
        public PAWHSActualProcurment_Save_Header Header { get; set; }

    }



    public class PAWHSActualProcurment_Save_Header
    {

        public int in_Actual_rowid { get; set; }
        public string in_LotNo { get; set; }
        public string in_Farmer_Code { get; set; }
        public string in_Farmer_Name { get; set; }
        public string in_Member_Type { get; set; }
        public string in_Item_Code { get; set; }
        public string in_Item_Name { get; set; }
        public double in_Actual_Qty { get; set; }
        public double in_Actual_Price { get; set; }
        public double in_Actual_Value { get; set; }
        public double in_advance_amt { get; set; }
        public Int32 in_no_of_bags { get; set; }
        public string in_Status { get; set; }
        public string in_mode_flag { get; set; }
        public string in_actual_remarks { get; set; }
        public string in_approved_remarks { get; set; }
        public string in_pickup_remarks { get; set; }
        public string in_actual_attach { get; set; }
        public string in_vehicle_type { get; set; }
        public string in_vehicle_no { get; set; }
        public string in_destination { get; set; }
        public string in_qcperson_name { get; set; }
        public string in_LRP_Name { get; set; }
        public string In_LRP_Mobile_no { get; set; }
        public string In_Payment_type { get; set; }
        public string In_Bank_acc_no { get; set; }
        public string In_cheque_no { get; set; }
        public string In_Buyer_code { get; set; }
        public string In_Buyer_name { get; set; }
        public string In_Acc_Date { get; set; }
        public string In_season { get; set; }
    }


    public class PAWHSActualProcurment_Save_QtyDetail
    {
        //qty_row_id, agg_code, lotno, item_code, qty_code, actual_value, wr_qty_value,rowtimestamp
        public Int32 In_qty_dtl_rowid { get; set; }
        public string In_qty_code { get; set; }
        public double In_actual_value { get; set; }
        public double In_wr_qty_value { get; set; }
        public string in_estimate_qty_value { get; set; }
        public string In_mode_flag { get; set; }
        public int In_rowtimestamp { get; set; }
        public Int32 IOU_qty_dtl_rowid { get; set; }
        public string lotno { get; set; }

    }
    public class PAWHSActualProcurment_Save_OtherDetail
    {
        //otherdtl_row_id, agg_code, lotno, packaging_cost, transporting_cost, unpacking_cost, local_packaging_cost, 
        //local_transporting_cost, temp_cost, temp_cost1, temp_cost2,rowtimestamp
        public Int32 In_otherdtl_row_id { get; set; }
        public double In_packaging_cost { get; set; }
        public double In_transporting_cost { get; set; }
        public double In_unpacking_cost { get; set; }
        public double In_local_packaging_cost { get; set; }
        public double In_local_transporting_cost { get; set; }
        public double In_temp_cost { get; set; }
        public double In_temp_cost1 { get; set; }
        public double In_temp_cost2 { get; set; }
        public string In_mode_flag { get; set; }
        public int In_rowtimestamp { get; set; }
        public Int32 IOU_otherdtl_row_id { get; set; }
        public string lotno { get; set; }
    }
    public class PAWHSActualProcurment_Save_SlnoDetail
    {

        public Int32 In_slno_row_id { get; set; }
        public string In_slno { get; set; }
        public string In_temp1 { get; set; }
        public string In_temp2 { get; set; }
        public string in_qty { get; set; }
        public string In_mode_flag { get; set; }
        public int In_rowtimestamp { get; set; }
        public Int32 IOU_slno_row_id { get; set; }
        public string lotno { get; set; }

    }
    #endregion

    #region SlnoFetch

    public class PAWHSActualProcurmentSlnoFetchApplication
    {

        public PAWHSActualProcurment_SlnoFetchContext context { get; set; }

    }
    public class PAWHSActualProcurment_SlnoFetchContext
    {

        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
     
        public string In_slno { get; set; }       
        public IList<PAWHSActualProcurment_Fetch_SlnoLotDt> SlnoLotDetail { get; set; }
    }
    public class PAWHSActualProcurment_Fetch_SlnoLotDt
    {
        public int Out_act_rowid { get; set; }
        public string Out_lotno { get; set; }
        public string Out_farmer_code { get; set; }
        public string Out_farmer_name { get; set; }
        public string Out_item_code { get; set; }
        public string Out_item_name { get; set; }
        public double Out_actual_qty { get; set; }
        public double Out_actual_price { get; set; }
        public double Out_actual_value { get; set; }
        public int Out_no_of_bags { get; set; }
    }
    #endregion
}

