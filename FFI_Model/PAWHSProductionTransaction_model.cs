using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class PAWHSProductionTransaction_model
    {
    }
    #region list
    public class PAWHSProductionTransactionList
    {
        public int Out_pro_tran_rowid { get; set; }
        public string Out_fg_code { get; set; }
        public string Out_fg_desc { get; set; }
        public string Out_stage_document_id { get; set; }
        public string Out_stage_description { get; set; }
        public string Out_stage_start_datetime { get; set; }
        public string Out_stage_end_datetime { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_row_timestamp { get; set; }

    }
    public class PAWHSProductionTransactionContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<PAWHSProductionTransactionList> List { get; set; }
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }

    }
    public class PAWHSProductionTransactionApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSProductionTransactionApplication
    {
        public PAWHSProductionTransactionContext context { get; set; }
        public PAWHSProductionTransactionApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region save
    public class PAWHSProductionTransactionSHeader
    {
        public int IOU_pro_tran_rowid { get; set; }
        public string IOU_fg_code { get; set; }
        public string In_stage_document_id { get; set; }
        public string In_production_stage_code { get; set; }
        public string In_stage_start_datetime { get; set; }
        public string In_stage_end_datetime { get; set; }
        public string In_tran_type { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class PAWHSProductionTransactionSList
    {
        public int In_pro_tran_dtl_rowid { get; set; }
        public string In_input_or_output { get; set; }
        public string In_item { get; set; }
        public string In_uom { get; set; }
        public int In_qty { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSProductionTransactionSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSProductionTransactionSHeader Header { get; set; }
        public IList<PAWHSProductionTransactionSList> List { get; set; }

    }
    public class PAWHSProductionTransactionSDocument
    {
        public PAWHSProductionTransactionSContext context { get; set; }
        public PAWHSProductionTransactionSApplicationException ApplicationException { get; set; }
    }
    public class PAWHSProductionTransactionSApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSProductionTransactionSApplication
    {
        public PAWHSProductionTransactionSDocument document { get; set; }

    }
    #endregion
    #region single fetch
    public class PAWHSProductionTransactionFHeader
    {
        public int IOU_pro_tran_rowid { get; set; }
        public string IOU_fg_code { get; set; }
        public string In_stage_document_id { get; set; }
        public string In_production_stage_code { get; set; }
        public string In_production_stage_desc { get; set; }
        public string In_stage_start_datetime { get; set; }
        public string In_stage_end_datetime { get; set; }
        public string In_tran_type { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class PAWHSProductionTransactionFList
    {
        public int In_pro_tran_dtl_rowid { get; set; }
        public string In_input_or_output { get; set; }
        public string In_item { get; set; }
        public string In_uom { get; set; }
        public int In_qty { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSProductionTransactionFContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSProductionTransactionFHeader Header { get; set; }
        public IList<PAWHSProductionTransactionFList> List { get; set; }
        public int pro_tran_rowid { get; set; }
        public string fg_code { get; set; }

    }
    public class PAWHSProductionTransactionFApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSProductionTransactionFApplication
    {
        public PAWHSProductionTransactionFContext context { get; set; }
        public PAWHSProductionTransactionFApplicationException ApplicationException { get; set; }

    }
    #endregion
}
