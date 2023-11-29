using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class PAWHSStageItem_model
    {
    }
    #region list
    public class PAWHSStageItemList
    {
        public int Out_stage_item_rowid { get; set; }
        public string Out_aggregator_code { get; set; }
        public string Out_fg_code { get; set; }
        public int Out_no_of_stage { get; set; }
        public string Out_final_output { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_row_timestamp { get; set; }

    }
    public class PAWHSStageItemContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<PAWHSStageItemList> List { get; set; }
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }

    }
    public class PAWHSStageItemApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSStageItemApplication
    {
        public PAWHSStageItemContext context { get; set; }
        public PAWHSStageItemApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region fetch
    public class PAWHSStageItemFHeader
    {
        public int IOU_stage_rowid { get; set; }
        public string IOU_fg_code { get; set; }
        public string In_production_stage_code { get; set; }
        public string In_production_stage_desc { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class PAWHSStageItemFStage
    {
        public int In_stage_item_rowid { get; set; }
        public string In_input_output_code { get; set; }
        public string In_input_output_desc { get; set; }
        public string In_item_code { get; set; }
        public string In_item_desc { get; set; }
        public string In_uom { get; set; }
        public double In_quantity { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSStageItemFContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSStageItemFHeader Header { get; set; }
        public IList<PAWHSStageItemFStage> Stage { get; set; }
        public int stage_rowid { get; set; }
        public string fg_code { get; set; }


    }
    public class PAWHSStageItemFApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSStageItemFApplication
    {
        public PAWHSStageItemFContext context { get; set; }
        public PAWHSStageItemFApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region itemfetch
    public class PAWHSStageItemIHeader
    {
        public string IOU_fg_code { get; set; }

    }
    public class PAWHSStageItemIStage
    {
        public int In_stage_rowid { get; set; }
        public string In_stage_code { get; set; }
        public string In_stage_desc { get; set; }
        public int In_seq_no { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }

    }
    public class PAWHSStageItemIContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSStageItemIHeader Header { get; set; }
        public IList<PAWHSStageItemIStage> Stage { get; set; }
        public string fg_code { get; set; }

    }
    public class PAWHSStageItemIApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSStageItemIApplication
    {
        public PAWHSStageItemIContext context { get; set; }
        public PAWHSStageItemIApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region save
    public class PAWHSStageItemSHeader
    {
        public int In_stage_rowid { get; set; }
        public string IOU_fg_code { get; set; }
        public string In_production_stage_code { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class PAWHSStageItemSStage
    {
        public int In_stage_item_rowid { get; set; }
        public string In_input_output_code { get; set; }
        public string In_item_code { get; set; }
        public string In_uom { get; set; }
        public int In_quantity { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSStageItemSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSStageItemSHeader Header { get; set; }
        public IList<PAWHSStageItemSStage> Stage { get; set; }

    }
    public class PAWHSStageItemSDocument
    {
        public PAWHSStageItemSContext context { get; set; }
        public PAWHSStageItemSApplicationException ApplicationException { get; set; }
    }
    public class PAWHSStageItemSApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSStageItemSApplication
    {
        public PAWHSStageItemSDocument document { get; set; }

    }
    #endregion
}
