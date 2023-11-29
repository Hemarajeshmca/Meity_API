using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class PAWHS_NEW_BulkTransaction_model
    {
    }
    #region save
    public class PAWHS_NEW_BulkTrans_SApplication
    {
        public PAWHS_NEW_BulkTrans_SDocument document { get; set; }

    }
    public class PAWHS_NEW_BulkTrans_SDocument
    {
        public PAWHS_NEW_BulkTrans_SContext context { get; set; }

    }
    public class PAWHS_NEW_BulkTrans_SContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHS_NEW_BulkTrans_saveHeader Header { get; set; }
        public List<Esitmated_Prod> Esitmated_Prod { get; set; }
        public List<pawhs_NewWareHouseReceipt> NewWareHouseReceipt { get; set; }
        public List<Actual_Procurment> Actual_Procurment { get; set; }

    }
    public class pawhs_NewWareHouseReceipt
    {
        public int in_whs_rowid { get; set; }
        public string in_whs_code { get; set; }
        public string in_LotNo { get; set; }
        public decimal in_Accepted_Qty { get; set; }
        public DateTime in_Accepted_date { get; set; }
        public string in_status { get; set; }
        public string in_mode_flag { get; set; }
        public string in_Remarks { get; set; }
        public string in_Created_by { get; set; }
        public string in_modified_by { get; set; }


    }
    public class PAWHS_NEW_BulkTrans_saveHeader
    {
        public string aggrcode { get; set; }
        public string username { get; set; }
    }

        public class Esitmated_Prod
    {
        public int in_Estm_rowid { get; set; }
        public string in_LotNo { get; set; }
        public string in_Farmer_Code { get; set; }
        public string in_Farmer_Name { get; set; }
        public string in_Member_Type { get; set; }
        public string in_Item_Code { get; set; }
        public string in_Item_Name { get; set; }
        public decimal in_Estimated_Qty { get; set; }
        public decimal in_Estimated_Price { get; set; }
        public decimal in_Estimated_Value { get; set; }
        public DateTime in_Estimated_PickDate { get; set; }
        public string in_Estimated_attach { get; set; }
        public string in_variety_status { get; set; }
        public string in_Estimated_Status { get; set; }
        public string in_LRP_Name { get; set; }
        public string in_Remarks { get; set; }
        public string in_mode_flag { get; set; }
        public string in_Created_by { get; set; }      
        public string in_modified_by { get; set; }
        public IList<PAWHSEstimatedProcurment_OFFSave_QltDetail> QtyDetail { get; set; }
    }
    public class PAWHSEstimatedProcurment_OFFSave_QltDetail
    {

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

    public class Actual_Procurment
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
        public IList<PAWHSActualProcurment_OFFSave_QtyDetail> QtyDetail { get; set; }
        public IList<PAWHSActualProcurment_OFFSave_OtherDetail> OtherDetail { get; set; }
        public IList<PAWHSActualProcurment_OFFSave_SlnoDetail> SlnoDetail { get; set; }
    }
    public class PAWHSActualProcurment_OFFSave_QtyDetail
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

    }
    public class PAWHSActualProcurment_OFFSave_OtherDetail
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

    }
    public class PAWHSActualProcurment_OFFSave_SlnoDetail
    {

        public Int32 In_slno_row_id { get; set; }
        public string In_slno { get; set; }
        public string In_temp1 { get; set; }
        public string In_temp2 { get; set; }
        public string In_mode_flag { get; set; }
        public int In_rowtimestamp { get; set; }
        public Int32 IOU_slno_row_id { get; set; }

    }
    #endregion
}


