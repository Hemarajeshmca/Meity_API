using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class Admin_AttributeGroupMappingModel
    {
    }

    #region List
    public class AGMList
    {
        public int Out_entitygrpacitivity_rowid { get; set; }
        public string Out_activity_code { get; set; }
        public string Out_activity_desc { get; set; }
        public string Out_entitygrp_code { get; set; }
        public string Out_entitygrp_name { get; set; }
        public int Out_row_slno { get; set; }
        public string Out_mode_flag { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
    }

    public class AGMContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public List<AGMList> List { get; set; }
    }
    public class AttributeGroupMappingList
    {
        public AGMContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion

    #region SingleFetch
    public class FetchAGMDetail
    {
        public int In_entitygrpacitivity_rowid { get; set; }
        public string In_entitygrp_code { get; set; }
        public string In_entitygrp_name { get; set; }
        public int In_row_slno { get; set; }
        public string In_mode_flag { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
    }

    public class FetchAGMContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public List<FetchAGMDetail> Detail { get; set; }
    }
    public class FtchAttributeGroupMapping
    {
        public FetchAGMContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion

    #region SaveInput
    public class SaveAGMHeader
    {
        public string In_activity_code { get; set; }
    }

    public class SaveAGMDetail
    {
        public int In_entitygrpacitivity_rowid { get; set; }
        public string In_entitygrp_code { get; set; }
        public int In_row_slno { get; set; }
        public string In_mode_flag { get; set; }
        public string In_status_code { get; set; }
    }

    public class SaveAGMContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public SaveAGMHeader Header { get; set; }
        public List<SaveAGMDetail> Detail { get; set; }
    }

    public class SaveAGMDocument
    {
        public SaveAGMContext context { get; set; }
    }

    public class SaveAttributeGroupMapping
    {
        public SaveAGMDocument document { get; set; }
    }
    #endregion

    #region SaveOutput
    public class OutputAGMDetail
    {
        public int In_entitygrpacitivity_rowid { get; set; }
    }
    public class OutputAGMContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public List<OutputAGMDetail> Detail { get; set; }
    }
    public class OutputAGM
    {
        public OutputAGMContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }

    #endregion
}
