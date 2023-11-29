using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    public class New_Pawhs_BatchCreation_Model
    {
        #region List
        public class PawhsBatchCreationRootObject
        {
            public PawhsBatchCreationContext context { get; set; }
            public PawhsBatchCreationApplicationException ApplicationException { get; set; }
        }
        public class PawhsBatchCreationApplication
        {
            public PawhsBatchCreationContext context { get; set; }
            public PawhsBatchCreationApplicationException ApplicationException { get; set; }

        }
        public class PawhsBatchCreationApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class PawhsBatchCreationContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public string FilterBy_Option { get; set; }
            public string FilterBy_Code { get; set; }
            public string FilterBy_FromValue { get; set; }
            public string FilterBy_ToValue { get; set; }
            public IList<PawhsBatchCreationList> List { get; set; }

        }
        public class PawhsBatchCreationList
        {
           
            public string Out_agg_code { get; set; }
            public string Out_batch_no { get; set; }
            public string Out_created_datetime { get; set; }
            public int Out_no_of_vehicles { get; set; }
            public int Out_no_of_lots { get; set; }           


        }
        #endregion

        #region GridList

        public class PawhsBatchCreationLotApplication
        {
            public PawhsBatchCreationLotContext Context { get; set; }
            public PawhsBatchCreationApplicationException ApplicationException { get; set; }
        }

        public class PawhsBatchCreationLotContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public string In_vehicle_no { get; set; }
            public IList<PawhsBatchCreationLotList> List { get; set; }
        }
        public class PawhsBatchCreationLotList
        {
            public int In_act_row_id { get; set; }
            public string In_orgn_code { get; set; }
            public string In_agg_code { get; set; }
            public string In_lotno { get; set; }
            public string In_vehicle_no { get; set; }
            public string In_farmer_code { get; set; }
            public string In_farmer_name { get; set; }
            public string In_member_type { get; set; }
            public string In_item_code { get; set; }
            public string In_item_name { get; set; }
            public double In_actual_qty { get; set; }
            public double In_actual_price { get; set; }
            public double In_actual_value { get; set; }
            public double In_advance_amt { get; set; }
            public int In_no_of_bags { get; set; }
        }
        #endregion

        #region Save
        public class PAWHSBatchCreation_Save_Application
        {
            public PAWHSBatchCreation_Save_Document document { get; set; }

        }
        public class PAWHSBatchCreation_Save_Document
        {
            public PAWHSBatchCreation_Save_Context context { get; set; }
            public PawhsBatchCreationApplicationException ApplicationException { get; set; }

        }

        public class PAWHSBatchCreation_Save_Context
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public string in_selected_lot_id { get; set; }
            public string Out_batch_no { get; set; }
            public string Out_error_msg { get; set; }
            public IList<PAWHSBacthCreation_Save_Header> Header { get; set; }
            public IList<PAWHSBatchCreation_Save_Otherdtl> OtherDtl { get; set; }
        }
        public class PAWHSBacthCreation_Save_Header
        {
            public int In_batch_rowid { get; set; }
            public string in_batch_no { get; set; }
            public string In_vehicle_no { get; set; }
            public int In_Total_No_of_lots { get; set; }
            public int In_No_of_batch_creation { get; set; }
            public int In_No_of_Pending { get; set; }          
            public string in_mode_flag { get; set; }           
            public string Out_batch_no { get; set; }
            public string Out_error_msg { get; set; }
         
            
        }
        public class PAWHSBatchCreation_Save_Otherdtl
        {
            public int In_batch_other_id { get; set; }
            public string In_batch_no { get; set; }
            public string In_cost_name { get; set; }
            public decimal In_cost_value { get; set; }
            public string in_mode_flag { get; set; }           
            public int inout_batchotherdtl_row_id { get; set; }
            public string inout_batchno { get; set; }
        }
        #endregion

        #region Single
        public class PAWHSBatchCreationFetchApplication
        {
            public PAWHSBatchCreation_FetchContext context { get; set; }
        }
        public class PAWHSBatchCreation_FetchContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public int In_batch_rowid { get; set; }
            public string In_batch_no { get; set; }
            public string IOU_agg_code { get; set; }
            public string IOU_batch_no { get; set; }
            public IList<PAWHSBatchCreation_FetchHeader> Header { get; set; }
            public IList<PAWHSBatchCreation_FetchBatch_List> BatchList { get; set; }
            public IList<PAWHSBatchCreation_FetchOther_List> OtherList { get; set; }

        }
        public class PAWHSBatchCreation_FetchHeader
        {
            public int In_batch_rowid { get; set; }  
            public string In_vehicle_no { get; set; }
            public int In_Total_No_of_lots { get; set; }
            public int In_No_of_batch_creation { get; set; }
            public int In_No_of_Pending { get; set; }
            public string in_mode_flag { get; set; }
        }
        public class PAWHSBatchCreation_FetchBatch_List
        {
            public int In_act_row_id { get; set; }
            public string In_orgn_code { get; set; }
            public string In_agg_code { get; set; }
            public string In_lotno { get; set; }
            public string In_vehicle_no { get; set; }
            public string In_farmer_code { get; set; }
            public string In_farmer_name { get; set; }
            public string In_member_type { get; set; }
            public string In_item_code { get; set; }
            public string In_item_name { get; set; }
            public double In_actual_qty { get; set; }
            public double In_actual_price { get; set; }
            public double In_actual_value { get; set; }
            public double In_advance_amt { get; set; }
            public int In_no_of_bags { get; set; }
        }
        public class PAWHSBatchCreation_FetchOther_List
        {
            public int In_batch_other_id { get; set; }
            public string In_batch_no { get; set; }
            public string In_cost_name { get; set; }
            public double In_cost_value { get; set; }
            public string in_mode_flag { get; set; }
        }
        #endregion
    }

}
