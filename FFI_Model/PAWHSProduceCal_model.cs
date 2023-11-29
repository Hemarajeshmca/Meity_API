using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class PAWHSProduceCal_model
    {
    }
    #region list
    public class PAWHSProduceCalList
    {
        public int Out_producecal_rowid { get; set; }
        public string Out_pac_no { get; set; }
        public string Out_pac_year { get; set; }
        public string Out_pac_date { get; set; }
        public string Out_agg_code { get; set; }
        public string Out_farmer_code { get; set; }
        public string Out_item_code { get; set; }
        public int Out_jan { get; set; }
        public int Out_feb { get; set; }
        public int Out_mar { get; set; }
        public int Out_apr { get; set; }
        public int Out_may { get; set; }
        public int Out_jun { get; set; }
        public int Out_jul { get; set; }
        public int Out_aug { get; set; }
        public int Out_sep { get; set; }
        public int Out_oct { get; set; }
        public int Out_nov { get; set; }
        public int Out_dec { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_row_timestamp { get; set; }

    }
    public class PAWHSProduceCalContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public IList<PAWHSProduceCalList> List { get; set; }
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }

    }
    public class PAWHSProduceCalApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSProduceCalApplication
    {
        public PAWHSProduceCalContext context { get; set; }
        public PAWHSProduceCalApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region fetch
    public class PAWHSProduceCalFHeader
    {
        public int IOU_producecal_rowid { get; set; }
        public string IOU_pac_no { get; set; }
        public string In_pac_date { get; set; }
        public string In_pac_year { get; set; }
        public string In_farmer_code { get; set; }
        public string In_farmer_name { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class PAWHSProduceCalFList
    {
        public int In_item_rowid { get; set; }
        public string In_item_code { get; set; }
        public string In_item_desc { get; set; }
        public string In_uom { get; set; }
        public int In_jan { get; set; }
        public int In_feb { get; set; }
        public int In_mar { get; set; }
        public int In_apr { get; set; }
        public int In_may { get; set; }
        public int In_jun { get; set; }
        public int In_jul { get; set; }
        public int In_aug { get; set; }
        public int In_sep { get; set; }
        public int In_oct { get; set; }
        public int In_nov { get; set; }
        public int In_dec { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSProduceCalFContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSProduceCalFHeader Header { get; set; }
        public IList<PAWHSProduceCalFList> List { get; set; }
        public int producecal_rowid { get; set; }
        public string pac_no { get; set; }

    }
    public class PAWHSProduceCalFApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSProduceCalFApplication
    {
        public PAWHSProduceCalFContext context { get; set; }
        public PAWHSProduceCalFApplicationException ApplicationException { get; set; }

    }
    #endregion
    #region Save
    public class PAWHSProduceCalSHeader
    {
        public int IOU_producecal_rowid { get; set; }
        public string IOU_pac_no { get; set; }
        public string In_pac_date { get; set; }
        public string In_pac_year { get; set; }
        public string In_farmer_code { get; set; }
        public string In_farmer_name { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class PAWHSProduceCalSList
    {
        public int In_item_rowid { get; set; }
        public string In_item_code { get; set; }
        public string In_item_desc { get; set; }
        public string In_uom { get; set; }
        public int In_jan { get; set; }
        public int In_feb { get; set; }
        public int In_mar { get; set; }
        public int In_apr { get; set; }
        public int In_may { get; set; }
        public int In_jun { get; set; }
        public int In_jul { get; set; }
        public int In_aug { get; set; }
        public int In_sep { get; set; }
        public int In_oct { get; set; }
        public int In_nov { get; set; }
        public int In_dec { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class PAWHSProduceCalSContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public PAWHSProduceCalSHeader Header { get; set; }
        public IList<PAWHSProduceCalSList> List { get; set; }

    }
    public class PAWHSProduceCalSDocument
    {
        public PAWHSProduceCalSContext context { get; set; }

        public PAWHSProduceCalSApplicationException ApplicationException { get; set; }
    }
    public class PAWHSProduceCalSApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class PAWHSProduceCalSApplication
    {
        public PAWHSProduceCalSDocument document { get; set; }

    }
    #endregion
}
