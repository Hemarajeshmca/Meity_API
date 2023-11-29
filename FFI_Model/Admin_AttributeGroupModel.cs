using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class Admin_AttributeGroupModel
    {
    }
    #region List

    public class AGList
    {
        public int Out_entitygrp_rowid { get; set; }
        public string Out_entitygrp_code { get; set; }
        public string Out_entitygrp_name { get; set; }
        public string Out_entitygrp_ll_name { get; set; }
        public string Out_multiline_flag { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_row_timestamp { get; set; }
    }

    public class AttributeGroupContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public List<AGList> List { get; set; }
    }
    public class AttributeGroupList
    {
        public AttributeGroupContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }

    #endregion

    #region SigleFetch
    public class FetchAttributeGroupHeader
    {
        public string In_entitygrp_name { get; set; }
        public string In_entitygrp_ll_name { get; set; }
        public string In_multiline_flag { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }
    }

    public class FetchAttributeGroupDetail
    {
        public int In_entity_rowid { get; set; }
        public int In_row_slno { get; set; }
        public string In_entity_code { get; set; }
        public string In_entity_name { get; set; }
        public string In_entity_ll_name { get; set; }
        public string In_entity_type { get; set; }
        public string In_entity_type_desc { get; set; }
        public string In_entity_length { get; set; }
        public int In_entity_width { get; set; }
        public string In_depend_code { get; set; }
        public string In_depend_desc { get; set; }
        public string In_mode_flag { get; set; }
    }

    public class FetchAttributeGroupContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FetchAttributeGroupHeader Header { get; set; }
        public List<FetchAttributeGroupDetail> Detail { get; set; }
    }
    public class FetchAttributeGroup
    {
        public FetchAttributeGroupContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion

    #region Save input

    public class SaveAGHeader
    {
        public int In_entitygrp_rowid { get; set; }
        public string In_entitygrp_code { get; set; }
        public string In_entitygrp_name { get; set; }
        public string In_entitygrp_ll_name { get; set; }
        public string In_multiline_flag { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }
    }

    public class SaveAGDetail
    {
        public int In_entity_rowid { get; set; }
        public int In_row_slno { get; set; }
        public string In_entity_code { get; set; }
        public string In_entity_name { get; set; }
        public string In_entity_ll_name { get; set; }
        public string In_entity_type { get; set; }
        public string In_entity_length { get; set; }
        public int In_entity_width { get; set; }
        public string In_depend_code { get; set; }
        public string In_mode_flag { get; set; }
    }

    public class SaveAGContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public SaveAGHeader Header { get; set; }
        public List<SaveAGDetail> Detail { get; set; }
    }

    public class SaveAGDocument
    {
        public SaveAGContext context { get; set; }
    }

    public class SaveAG
    {
        public SaveAGDocument document { get; set; }
    }
    #endregion

    #region SaveOutput
    public class OutputAGHeader
    {
        public int In_entitygrp_rowid { get; set; }
    }

    public class OutputAGContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public OutputAGHeader Header { get; set; }
    }
    public class OutputAG
    {
        public OutputAGContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion
}
