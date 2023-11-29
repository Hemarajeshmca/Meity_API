using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class PAWHSItemMaster_Model
    {
    }

    #region
    /* Item Master List Loaded 18-05-2020 */
    public class ItemMasterList
    {
        public int Out_item_rowid { get; set; }
        public string Out_agg_code { get; set; }
        public string Out_item_code { get; set; }
        public string Out_item_name { get; set; }
        public string Out_item_ll_name { get; set; }
        public string Out_item_type { get; set; }
        public string Out_fg_category { get; set; }
        public string Out_fg_subcategory { get; set; }
        public string Out_uom_code { get; set; }
        public string Out_hsn_code { get; set; }
        public string Out_hsn_description { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_row_timestamp { get; set; }

    }
    public class ItemMasterContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<ItemMasterList> List { get; set; }
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }

    }
  
    public class ItemMasterApplication
    {
        public ItemMasterContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }

    }

    #endregion

    #region

    /* Item Master Edit Loaded 18-05-2020 */
    public class ItemMasterHeader
    {
        public int IOU_item_rowid { get; set; }
        public string IOU_agg_code { get; set; }
        public string IOU_item_code { get; set; }
        public string In_item_name { get; set; }
        public string In_item_ll_name { get; set; }
        public string In_item_type { get; set; }
        public string In_fg_category { get; set; }
        public string In_fg_subcategory { get; set; }
        public string In_uom_code { get; set; }
        public string In_hsn_code { get; set; }
        public string In_hsn_description { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class ItemMasterDetail
    {
        public int In_item_dtl_rowid { get; set; }
        public string In_item_code { get; set; }
        public string In_quality { get; set; }
        public string In_quality_desc { get; set; }
        public int In_base_price { get; set; }
        public string In_range_1 { get; set; }
        public string In_range_2 { get; set; }
        public string In_range_3 { get; set; }
        public string In_range_4 { get; set; }
        public string In_range_5 { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class SingleItemMasterContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public ItemMasterHeader Header { get; set; }

        public int item_rowid { get; set; }
        public string agg_code { get; set; }
        public string item_code { get; set; }
        public IList<ItemMasterDetail> Detail { get; set; }

    }
 
    public class SingleItemMasterApplication
    {
        public SingleItemMasterContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }

    }
    #endregion

    #region  save
    public class SaveItemMasterHeader
    {
        public int IOU_item_rowid { get; set; }
        public string In_agg_code { get; set; }
        public string IOU_item_code { get; set; }
        public string In_item_name { get; set; }
        public string In_item_ll_name { get; set; }
        public string In_item_type { get; set; }
        public string In_fg_category { get; set; }
        public string In_fg_subcategory { get; set; }
        public string In_uom_code { get; set; }
        public string In_hsn_code { get; set; }
        public string In_hsn_description { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class SaveItemMasterDetail
    {
        public int In_item_dtl_rowid { get; set; }
        public string In_item_code { get; set; }
        public string In_quality { get; set; }
        public int In_base_price { get; set; }
        public string In_range_1 { get; set; }
        public string In_range_2 { get; set; }
        public string In_range_3 { get; set; }
        public string In_range_4 { get; set; }
        public string In_range_5 { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class SaveItemMasterContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public SaveItemMasterHeader Header { get; set; }
        public IList<SaveItemMasterDetail> Detail { get; set; }

    }
    public class SaveItemMasterDocument
    {
        public SaveItemMasterContext context { get; set; }

    }
    public class SaveItemMasterApplication
    {
        public SaveItemMasterDocument document { get; set; }

    }
    #endregion
}
