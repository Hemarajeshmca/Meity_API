using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class ICDMOBStockadj_model
    {
    }
    #region stockadj save
    public class ICDMOBSAHeader
    {
        public string IOU_adjustment_rowid { get; set; }
        public string In_orgn_code { get; set; }
        public string In_ic_code { get; set; }
        public string In_ic_desc { get; set; }
        public string In_adjustment_no { get; set; }
        public string In_adjustment_date { get; set; }
        public string In_status_code { get; set; }
        public string In_process_status { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }
    }

    public class ICDMOBSADetail
    {
        public string In_adjustmentdtl_rowid { get; set; }
        public string In_adjustment_no { get; set; }
        public string In_receipt_ref_doc_no { get; set; }
        public string In_ref_doc_date { get; set; }
        public string In_adjustment_type { get; set; }
        public string In_lrp_name { get; set; }
        public string In_product_catg_code { get; set; }
        public string In_product_catg_desc { get; set; }
        public string In_product_subcatg_code { get; set; }
        public string In_product_subcatg_desc { get; set; }
        public string In_product_code { get; set; }
        public string In_product_desc { get; set; }
        public string In_adjustment_qty { get; set; }
        public string In_uom_type { get; set; }
        public string In_remarks { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_out_qty { get; set; }
        public string In_adj_amt { get; set; }
    }

    public class ICDMOBSAContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public ICDMOBSAHeader Header { get; set; }
        public List<ICDMOBSADetail> Detail { get; set; }
    }

    public class ICDMOBSADocument
    {
        public ICDMOBSAContext context { get; set; }
    }

    public class ICDMOBSARoot
    {
        public ICDMOBSADocument document { get; set; }
    }


    #endregion
    #region LRPNAME

    public class IICDMOBSALRPNAMEList
    {
        public string In_lrp_name { get; set; }
       
    }

    public class ICDMOBCContext1
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public string In_orgn_code { get; set; }

        public List<IICDMOBSALRPNAMEList> LRPList { get; set; }
    }

    public class ICDMOBApplicationException1
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }
    }

    public class ICDMOBCRoot1
    {
        public ICDMOBCContext1 context { get; set; }
        public ICDMOBApplicationException1 ApplicationException { get; set; }
    }

    #endregion
}
