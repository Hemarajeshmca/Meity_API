using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
   public class Admin_BulkUpload_Model
    {
        #region excel temp
        public class BulkExceltempHeader
        {
            public string out_entity_group_code { get; set; }
            public string out_procedure_name { get; set; }
            public string out_procedure_type { get; set; }
            public int out_no_of_columns { get; set; }

        }
        public class BulkExceltempExcelColumn
        {
            public string excel_column { get; set; }
            public string column_name { get; set; }
            public string column_type { get; set; }
            public int max_len { get; set; }
            public int seq_no { get; set; }

        }
        public class BulkExceltempExcelHistory
        {
            public string history_log { get; set; }
            public string excel_filename { get; set; }
            public string status_desc { get; set; }
            public string uploaded_by { get; set; }
            public string uploaded_datetime { get; set; }

        }
        public class BulkExceltempContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public BulkExceltempHeader Header { get; set; }
            public IList<BulkExceltempExcelColumn> excelColumn { get; set; }
            public IList<BulkExceltempExcelHistory> excelHistory { get; set; }

        }
        public class BulkExceltempApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class BulkExceltempApplication
        {
            public BulkExceltempContext context { get; set; }
            public BulkExceltempApplicationException ApplicationException { get; set; }

        }
        #endregion
        //save Excelvector Function Input 
        #region
        public class savevectorHeader
        {
            public string In_farmer_code { get; set; }
            public int In_version_no { get; set; }
            public string In_farmer_name { get; set; }
            public string In_sur_name { get; set; }
            public string detail_formatted { get; set; }

        }
        public class savevectorDetail
        {
            public string In_entitygrp_code { get; set; }
            public string In_entity_code { get; set; }
            public string In_row_slno { get; set; }
            public string In_entity_value { get; set; }
          

        }
        public class savevectorContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public savevectorHeader Header { get; set; }
            public IList<savevectorDetail> Detail { get; set; }

        }
        public class savevectorDocument1
        {
            public savevectorContext context { get; set; }

        }
        public class vectorApplication
        {
            public savevectorDocument1 document { get; set; }

        }

        //save Excelvector Function Output 
 
        public class savevectoroutput
        {
            public string Out_tran_status_desc { get; set; }

        }
        public class savevectorContextRes
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public savevectoroutput Header { get; set; }

        }
        public class savevectorApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class savevectorApplicationouput
        {
            public savevectorContextRes context { get; set; }
            public savevectorApplicationException ApplicationException { get; set; }

        }
        #endregion

        //save Scaler Function Input 
        #region
        public class ScalerHeaderinput
        {
            public string option_type { get; set; }
            public string parameters { get; set; }

        }
        public class ScalerContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public ScalerHeaderinput header { get; set; }

        }
        public class ScalerDocument
        {
            public ScalerContext context { get; set; }

        }
        public class ScalerApplication
        {
            public ScalerDocument document { get; set; }

        }

        //Save Scaler Function  Output Response start 24-04-2020
       
        public class HeaderScalarouput
        {
            public string tran_status_desc { get; set; }
            public Int32 tran_farmer_rowID { get; set; }
            public string tran_farmer_code { get; set; }

        }
        public class ScalerContextRes
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public HeaderScalarouput headerouput { get; set; }

        }
        public class ScalerApplicationExceptionRes
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class ScalerApplicationRes
        {
            public ScalerContextRes context { get; set; }
            public ScalerApplicationExceptionRes ApplicationException { get; set; }

        }

        public class duplicatefarmerdata
        {
            public string userId { get; set; }
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string localeId { get; set; }
            public string In_farmer_name { get; set; }
            public string In_sur_name { get; set; }
            public string In_fhw_name { get; set; }
            public string In_farmer_dob { get; set; }
        }
        #endregion

        //save insert_excel_history_log Function Input 
        #region
        public class SaveExcelHistory
        {
            public string excel_upload_code { get; set; }
            public string excel_filename { get; set; }
            public string status_code { get; set; }
            public string uploaded_by { get; set; }
            public string uploaded_datetime { get; set; }

        }
        public class SaveHistoryContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public SaveExcelHistory excelHistory { get; set; }

        }
        public class SaveHistoryDocument
        {
            public SaveHistoryContext context { get; set; }

        }
        public class SaveHistoryApplication
        {
            public SaveHistoryDocument document { get; set; }

        }

        //save insert_excel_history_log Function output 

  
        public class SaveHistoryContextRes
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }

        }
        public class SaveHistoryApplicationExceptionRes
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class SaveHistoryApplicationRes
        {
            public SaveHistoryContextRes context { get; set; }
            public SaveHistoryApplicationExceptionRes ApplicationExceptionRes { get; set; }

        }
        #endregion

    }
}
