using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FFI_Model
{
   public class ICDMOBInward_model
    {
       
    }
    #region save
    public class ICDINSHeader
    {
        public string IOU_inward_rowid { get; set; }
        public string In_orgn_code { get; set; }
        public string In_ic_code { get; set; }
        public string In_inward_code { get; set; }
        public string In_grn_no { get; set; }
        public string In_grn_date { get; set; }
        public string In_supplier_name { get; set; }
        public string In_supplier_location { get; set; }
        public string In_from_state { get; set; }
        public string In_Remarks { get; set; }
        public string In_status_code { get; set; }
        public string In_process_status { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }
        public string In_bill_image { get; set; }
        public string In_transport_amount { get; set; }
        public string In_others { get; set; }
        public string In_loading_unloading_cost { get; set; }
        public string In_local_transport_cost { get; set; }
        public string In_local_loading_unloading_cost { get; set; }
        public string In_roundoff { get; set; }
    }

    public class ICDINSDetail
    {
        public int In_inwarddtl_rowid { get; set; }
        public string In_inward_code { get; set; }
        public string In_grn_no { get; set; }
        public string In_product_catg_code { get; set; }
        public string In_product_subcatg_code { get; set; }
        public string In_product_code { get; set; }
        public string In_uomtype_code { get; set; }
        public string In_batch_no { get; set; }
        public string In_received_qty { get; set; }
        public string In_product_amount { get; set; }
        public string In_tax_amount { get; set; }
        public int In_transport_amount { get; set; }
        public string In_discount { get; set; }
        public string In_net_amount { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public IList<ICDINSDetailSlno> Slnoinfo { get; set; }
        public IList<ICDINSDetailOtherCost> OtherCostInfo { get; set; }
        public IList<ICDINSDetailOtherInputs> OtherInputInfo { get; set; }
        
    }

    public class ICDINSDetailSlno
    {
        public string In_inwardslno_rowid { get; set; }
        public int In_inwarddtl_rowid { get; set; }

        public string In_slno { get; set; }
        public string In_no_of_bags { get; set; }
        public string In_grn_no { get; set; }
        public string In_product_catg_code { get; set; }
        public string In_product_subcatg_code { get; set; }
        public string In_product_code { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
    }
    public class ICDINSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public ICDINSHeader Header { get; set; }
        public IList<ICDINSDetail> Detail { get; set; }
    }

    public class ICDINSDocument
    {
        public ICDINSContext context { get; set; }
    }

    public class ICDINSRoot
    {
        public ICDINSDocument document { get; set; }
    }


    #endregion

    #region IssueList
    public class IssueList
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public List<IssueDetailsList> IssueDetails { get; set; }
    }

    public class IssueDetailsList
    {
        public string inward_no { get; set; }
        public string Product_code { get; set; }
        public string Product_name { get; set; }
        public string issued_qty { get; set; }
    }
    #endregion


    #region InwardOtherCost
    public class ICDINSDetailOtherCost
    {
        public string In_inwardOtherCost_rowid { get; set; }
        public int In_inwarddtl_rowid { get; set; }
        public string In_OtherCostCode { get; set; }
        public string In_OtherCostType { get; set; }
        public string In_OtherCostOn { get; set; }
        public string In_OtherCostAmount { get; set; }
        public string In_grn_no { get; set; }
        public string In_product_catg_code { get; set; }
        public string In_product_subcatg_code { get; set; }
        public string In_product_code { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
    }

    #endregion


    #region InwardOtherCost
    public class ICDINSDetailOtherInputs
    {
        public string In_inwardOtherinput_rowid { get; set; }
        public int In_inwarddtl_rowid { get; set; }
        public int In_NoOfLoosePack { get; set; }
        public int In_CartonVolume { get; set; }
        public string In_Type { get; set; }
        public string In_ManufactureDate { get; set; }
        public string In_ExpDate { get; set; }
        public string In_mode_flag { get; set; }
        public string In_grn_no { get; set; }
        public string In_product_catg_code { get; set; }
        public string In_product_subcatg_code { get; set; }
        public string In_product_code { get; set; }
        public string In_status_code { get; set; }
        public decimal In_Mrp { get; set; } 
    }

    #endregion




}


