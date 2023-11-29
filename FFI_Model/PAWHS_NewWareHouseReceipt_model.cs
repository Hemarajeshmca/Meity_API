using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class PAWHS_NewWareHouseReceipt_model
    {
    }

    #region list
    public class PAWHS_NewWareHouseReceipt_ALL_RootObject
    {
        public PAWHS_NewWareHouseReceipt_ALL_Context context { get; set; }
        public PAWHS_NewWareHouseReceipt_ALL_ApplicationException ApplicationException { get; set; }
    }
    public class PAWHS_NewWareHouseReceipt_ALL_Application
    {
        public PAWHS_NewWareHouseReceipt_ALL_Context context { get; set; }
        public PAWHS_NewWareHouseReceipt_ALL_ApplicationException ApplicationException { get; set; }

    }

    public class PAWHS_NewWareHouseReceipt_ALL_ApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }
    }
    public class PAWHS_NewWareHouseReceipt_ALL_Context
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; } 
        public IList<PAWHS_NewWareHouseReceipt_ALL_List> List { get; set; }

    } 

    public class PAWHS_NewWareHouseReceipt_ALL_List
    {
        public int Out_whs_rowid { get; set; }
        public string Out_LotNo { get; set; }
        public string Out_whs_code { get; set; }
        public string Out_farmer_code { get; set; }
        public string Out_farmer_name { get; set; }
        public string Out_member_type { get; set; }
        public string Out_item_code { get; set; }
        public string Out_item_name { get; set; }
        public string Out_accepted_qty { get; set; }
        public string Out_payment_advcno { get; set; }  
        public string Out_Accepted_date { get; set; }
        public string Out_status { get; set; } 
        public string Out_Remarks { get; set; }
        public string Out_row_timestamp { get; set; }
        public string Out_agg_code { get; set; }
        public string Out_agg_name { get; set; }

    }


    #endregion


    #region Fetch 

    public class PAWHS_NewWareHouseReceipt_single_Application
    {
        //public PAWHSProductmasterFDocument document { get; set; }
        public PAWHS_NewWareHouseReceipt_single_Context context { get; set; }

    }

    public class PAWHS_NewWareHouseReceipt_single_Context
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHS_NewWareHouseReceipt_single_Header Header { get; set; }
        public int in_whs_rowid { get; set; }
        public string in_LotNo { get; set; }
        public string in_whs_Code { get; set; }

    }

    public class PAWHS_NewWareHouseReceipt_single_Header
    {
        public int in_whs_rowid { get; set; }
        public string in_LotNo { get; set; }
        public string in_whs_Code { get; set; }
        public string in_agg_code { get; set; }
        public string in_agg_name { get; set; }
        public string in_payment_advcno { get; set; } 
        public decimal in_Accepted_Qty { get; set; } 
        public string in_Accepted_date { get; set; }
        public string in_status { get; set; }
        public string in_Remarks { get; set; }
    }


    #endregion

    #region save
    public class PAWHS_NewWareHouseReceipt_SApplication
    {
        public PAWHS_NewWareHouseReceipt_SDocument document { get; set; }

    }
    public class PAWHS_NewWareHouseReceipt_SDocument
    {
        public PAWHS_NewWareHouseReceipt_SContext context { get; set; }
        public PAWHS_NewWareHouseReceipt_ApplicationException ApplicationException { get; set; }

    }
    public class PAWHS_NewWareHouseReceipt_SContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHS_NewWareHouseReceipt_saveHeader Header { get; set; }

    }

    public class PAWHS_NewWareHouseReceipt_saveHeader
    {
        public int in_whs_rowid { get; set; }
        public string in_whs_code { get; set; }
        public string in_LotNo { get; set; } 
        public decimal in_Accepted_Qty { get; set; }  
        public DateTime in_Accepted_date { get; set; }
        public string in_status { get; set; }
        public string in_mode_flag { get; set; }
        public string in_Remarks { get; set; }
        public string in_Created_by { get; set; } 
        public string in_modified_by { get; set; }  


    }

    public class PAWHS_NewWareHouseReceipt_ApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }
    }
    #endregion
}
