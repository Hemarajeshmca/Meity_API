using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class PAWHSProductionStageSetup_model
    {
    }
    #region list
    public class PAWHSProductionStageSetupList
    {
        public int Out_production_rowid { get; set; }
        public string Out_aggregator_code { get; set; }
        public string Out_fg_code { get; set; }
        public int Out_no_of_stage { get; set; }
        public string Out_final_output { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_row_timestamp { get; set; }

    }
    public class PAWHSProductionStageSetupContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<PAWHSProductionStageSetupList> List { get; set; }
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }
    }
    public class PAWHSProductionStageSetupApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSProductionStageSetupApplication
    {
        public PAWHSProductionStageSetupContext context { get; set; }
        public PAWHSProductionStageSetupApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region fetch
    public class PAWHSProductionStageSetupFHeader
    {
        public int IOU_production_rowid { get; set; }
        public string IOU_agg_code { get; set; }
        public string In_fg_code { get; set; }
        public string In_final_output_code { get; set; }
        public string In_final_output { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class PAWHSProductionStageSetupFStage
    {
        public int In_stage_rowid { get; set; }
        public string In_stage_code { get; set; }
        public string In_stage_desc { get; set; }
        public int In_seq_no { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSProductionStageSetupFContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSProductionStageSetupFHeader Header { get; set; }
        public IList<PAWHSProductionStageSetupFStage> Stage { get; set; }
        public int production_rowid { get; set; }
        public string agg_code { get; set; }


    }
    public class PAWHSProductionStageSetupFApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSProductionStageSetupFApplication
    {
        public PAWHSProductionStageSetupFContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region save
    public class PAWHSProductionStageSetupSHeader
    {
        public int In_production_rowid { get; set; }
        public string In_agg_code { get; set; }
        public string IOU_fg_code { get; set; }
        public string In_final_output_code { get; set; }
        public string In_final_output { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class PAWHSProductionStageSetupSStage
    {
        public int In_stage_rowid { get; set; }
        public string In_stage_code { get; set; }
        public int In_seq_no { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSProductionStageSetupSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSProductionStageSetupSHeader Header { get; set; }
        public IList<PAWHSProductionStageSetupSStage> Stage { get; set; }

    }
    public class PAWHSProductionStageSetupSDocument
    {
        public PAWHSProductionStageSetupSContext context { get; set; }
        public PAWHSProductionStageSetupSApplicationException ApplicationException { get; set; }
    }
    public class PAWHSProductionStageSetupSApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSProductionStageSetupSApplication
    {
        public PAWHSProductionStageSetupSDocument document { get; set; }

    }
    #endregion
}
