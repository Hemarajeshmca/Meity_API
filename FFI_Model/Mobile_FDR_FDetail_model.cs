using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class Mobile_FDR_FDetail_model
    {
    }
    #region save
    public class fdrsaveHeader
    {
        public int inout_farmer_rowid { get; set; }
        public string inout_farmer_code { get; set; }
        public int inout_version_no { get; set; }
        public string entitygrp_code { get; set; }
        public string in_created_by { get; set; }
    }

    public class fdrDetail
    {
        public int in_farmerdetail_rowid { get; set; }
        public string in_entitygrp_code { get; set; }
        public string in_entity_code { get; set; }
        public string in_row_slno { get; set; }
        public string in_entity_value { get; set; }
        public string in_mode_flag { get; set; }
        
    }

    public class saveContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public string instance { get; set; }
        public fdrsaveHeader Header { get; set; }
        public List<fdrDetail> Detail { get; set; }
        public string detail_formatted { get; set; }
        public List<fdrDetail> Dtlownland_picture { get; set; }
        public string ownland_picture { get; set; }

    }

    public class fdrDocument
    {
        public saveContext context { get; set; }
        public fdrApplicationException ApplicationException { get; set; }
    }
    public class fdrApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class fdrsaveRootObject
    {
        public fdrDocument document { get; set; }
    }
    #endregion
}
