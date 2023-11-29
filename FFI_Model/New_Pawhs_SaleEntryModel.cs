using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    public class New_Pawhs_SaleEntryModel
    {
        #region List
        public class PawhsSaleEntryRootObject
        {
            public PawhsSaleEntryContext context { get; set; }
            public PawhsSaleEntryApplicationException ApplicationException { get; set; }
        }
        public class PawhsBatSaleEntryApplication
        {
            public PawhsSaleEntryContext context { get; set; }
            public PawhsSaleEntryApplicationException ApplicationException { get; set; }

        }
        public class PawhsSaleEntryApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class PawhsSaleEntryContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public string FilterBy_Option { get; set; }
            public string FilterBy_Code { get; set; }
            public string FilterBy_FromValue { get; set; }
            public string FilterBy_ToValue { get; set; }
            public IList<PawhsSaleEntryList> List { get; set; }

        }
        public class PawhsSaleEntryList
        {

            public int Out_sale_rowid { get; set; }
            public string Out_sale_code { get; set; }
            public string Out_orgn_code { get; set; }
           public string Out_agg_code { get; set; }
           public string Out_buyer_code { get; set; }
           public string Out_buyer_name { get; set; }
           public string  Out_item_code { get; set; }
           public string Out_item_name { get; set; }
           public double Out_qty { get; set; }
           public double  Out_price { get; set; }
           public double Out_value { get; set; }
           public string Out_whs_code { get; set; }
           public string whs_name { get; set; }
           public string Out_status_code { get; set; }
           public string Out_row_timestamp { get; set; }



}
        #endregion

        #region Single Fetch
        public class PAWHSSaleEntryFetchApplication
        {
            public PAWHSSaleEntry_FetchContext context { get; set; }
        }
        public class PAWHSSaleEntry_FetchContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public int IOU_sale_rowid { get; set; }
            public PAWHSSaleEntry_FetchHeader Header { get; set; }
            public IList<PAWHSSaleEntry_Fetch_List> SaleEntryList { get; set; }
          

        }
        public class PAWHSSaleEntry_FetchHeader
        {
            public string In_sale_code { get; set; }
            public string In_orgn_code { get; set; }
            public string In_agg_code { get; set; }
            public string In_buyer_code { get; set; }
            public string In_buyer_name { get; set; }
            public string In_item_code { get; set; }
            public string In_item_name { get; set; }
            public double In_qty { get; set; }
            public double In_price { get; set; }
            public double In_value { get; set; }
            public string In_whs_code { get; set; }
            public string In_whs_name { get; set; }
            public string In_status_code { get; set; }
            public string In_status_desc { get; set; }
            public string In_mode_flag { get; set; }
            public string IOU_sale_rowid1 { get; set; }
        }
        public class PAWHSSaleEntry_Fetch_List
        {
            public int In_salevehicle_rowid { get; set; }
            public string In_whs_saleno { get; set; }
            public string In_vehicle_no { get; set; }
            public string In_sl_no { get; set; }
            public string In_remarks { get; set; }
            public string In_status_code { get; set; }
            public string In_status_desc { get; set; }
            public string In_mode_flag { get; set; }


        }

        #endregion

        #region Save


        public class PAWHSSaleEntry_Save_Application
        {
            public PAWHSSaleEntry_Save_Document document { get; set; }
        }
        public class PAWHSSaleEntry_Save_Document
        {
            public PAWHSSaleEntry_Save_Context context { get; set; }
            public PAWHSSaleEntryApplicationException ApplicationException { get; set; }

        }
        public class PAWHSSaleEntry_Save_Context
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public PAWHSSaleEntry_Save_Header Header { get; set; }
            public IList<PAWHSSaleEntry_Save_Detail> Detail { get; set; }

        }
        public class PAWHSSaleEntry_Save_Header
        {

            public int IOU_sale_rowid { get; set; }
            public string In_sale_code { get; set; }
            public string In_agg_code { get; set; }
            public string In_buyer_code { get; set; }
            public string In_buyer_name { get; set; }
            public string In_item_code { get; set; }
            public string In_item_name { get; set; }
            public double In_qty { get; set; }
            public double In_price { get; set; }
            public double In_value { get; set; }
            public string In_whs_code { get; set; }
            public string In_whs_name { get; set; }
            public string In_mode_flag { get; set; }

        }
        public class PAWHSSaleEntry_Save_Detail
        {
            public Int32 IOU_salevehicle_rowid { get; set; }
            public string In_whs_saleno { get; set; }
            public string In_vehicle_no { get; set; }
            public Int32 In_sl_no { get; set; }
            public string In_remarks { get; set; }
            public string In_mode_flag { get; set; }

        }
        public class PAWHSSaleEntryApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }

        #endregion
    }
}
