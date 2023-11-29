using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class pawhs_NewEstimated_Procurment_model
    {
    }

    #region list
    public class pawhs_NewEstimate_Proc_ALL_RootObject
    {
        public pawhs_NewEstimate_Proc_ALL_Context context { get; set; }
        public pawhs_NewEstimate_Proc_ALL_ApplicationException ApplicationException { get; set; }
    }
    public class pawhs_NewEstimate_Proc_ALL_Application
    {
        public pawhs_NewEstimate_Proc_ALL_Context context { get; set; }
        public pawhs_NewEstimate_Proc_ALL_ApplicationException ApplicationException { get; set; }

    }

    public class pawhs_NewEstimate_Proc_ALL_ApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class pawhs_NewEstimate_Proc_ALL_Context
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; } 
        public IList<pawhs_NewEstimate_Proc_ALL_List> List { get; set; }

    } 

    public class pawhs_NewEstimate_Proc_ALL_List
    { 
        public int Out_Estm_rowid { get; set; }
        public string Out_LotNo { get; set; }
        public string Out_Agg_code { get; set; }
        public string Out_Agg_name { get; set; }
        public string Out_Farmer_Code { get; set; }
        public string Out_Farmer_Name { get; set; }
        public string Out_Member_Type { get; set; }
        public string Out_Item_Code { get; set; }
        public string Out_Item_Name { get; set; }
        public string Out_Estimated_Qty { get; set; }
        public string Out_Estimated_Price { get; set; }
        public string Out_Estimated_Value { get; set; }
        public string Out_Estimated_PickDate { get; set; }
//        public string Out_status { get; set; }
        public string Out_row_timestamp { get; set; }
        public string Out_Remarks { get; set; }

    }


    #endregion


    #region Fetch 

    public class pawhs_NewEstimate_Proc_single_Application
    { 
        public pawhs_NewEstimate_Proc_single_Context context { get; set; }

    }

    public class pawhs_NewEstimate_Proc_single_Context
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; } 
        public pawhs_NewEstimate_Proc_single_Header Header { get; set; }
        public IList<pawhs_NewEstimate_Proc_Single_Quality> QualityDt { get; set; }
        public int in_Estm_rowid { get; set; }
        public string in_LotNo { get; set; }
    }

    public class pawhs_NewEstimate_Proc_single_Header
    {
        public int in_Estm_rowid { get; set; }
        public string in_LotNo { get; set; }
        public string in_Agg_code { get; set; }
        public string in_Agg_name { get; set; }
        public string in_Farmer_Code { get; set; }
        public string in_Farmer_Name { get; set; }
        public string in_Member_Type { get; set; }
        public string in_Item_Code { get; set; }
        public string in_Item_Name { get; set; }
        public decimal in_Estimated_Qty { get; set; }
        public decimal in_Estimated_Price { get; set; }
        public decimal in_Estimated_Value { get; set; }
        public string in_Estimated_PickDate { get; set; }   
        public string in_Estimated_attach { get; set; }
        public string in_variety_status { get; set; }
        public string in_Estimated_Status { get; set; }
        public string in_LRP_Name { get; set; }
        public string in_LRP_Mobile_no { get; set; }
        public string in_Remarks { get; set; } 
    }
    public class pawhs_NewEstimate_Proc_Single_Quality
    {
        public int Out_qty_row_id { get; set; }
        public string Out_agg_code { get; set; }
        public string Out_lotno { get; set; }
        public string Out_qlt_code { get; set; }
        public string Out_Qlt_name { get; set; }
        public string Out_Qlt_value { get; set; }
    }

    #endregion

    #region save
    public class PAWHSEstimateProcurmentApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class pawhs_NewEstimate_Proc_SApplication
    {
        public pawhs_NewEstimate_Proc_SDocument document { get; set; }

    }
    public class pawhs_NewEstimate_Proc_SDocument
    {
        public pawhs_NewEstimate_Proc_SContext context { get; set; }
        public PAWHSEstimateProcurmentApplicationException ApplicationException { get; set; }

    }
    public class pawhs_NewEstimate_Proc_SContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public pawhs_NewEstimate_Proc_saveHeader Header { get; set; }
        public IList<PAWHSEstimatedProcurment_Save_QltDetail> QtyDetail { get; set; }

    }

    public class pawhs_NewEstimate_Proc_saveHeader
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
        public string in_LRP_Mobile_no { get; set; }
        public string in_status { get; set; }
        public string in_Remarks { get; set; }
        public string in_mode_flag { get; set; }
        public string in_Created_by { get; set; }      
        public string in_modified_by { get; set; }         
    }
    public class PAWHSEstimatedProcurment_Save_QltDetail
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


    #endregion
}
