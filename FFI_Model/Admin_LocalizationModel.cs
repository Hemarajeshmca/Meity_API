using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class Admin_LocalizationModel
    {
    }
    #region Fetch
    public class FetchLocalizationScreen
    {
        public int In_localization_rowid { get; set; }
        public string In_control_type { get; set; }
        public string In_control_type_desc { get; set; }
        public string In_control_code { get; set; }
        public string In_data_field { get; set; }
        public string In_locale_desc { get; set; }
        public string In_locale_ll_desc { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }
    }

    public class FetchLocalizationFE
    {
        public int In_localization_rowid { get; set; }
        public string In_control_type { get; set; }
        public string In_control_type_desc { get; set; }
        public string In_control_code { get; set; }
        public string In_data_field { get; set; }
        public string In_locale_desc { get; set; }
        public string In_locale_ll_desc { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }
    }

    public class FetchLocalizationBE
    {
        public int In_localization_rowid { get; set; }
        public string In_control_type { get; set; }
        public string In_control_type_desc { get; set; }
        public string In_control_code { get; set; }
        public string In_data_field { get; set; }
        public string In_locale_desc { get; set; }
        public string In_locale_ll_desc { get; set; }
        public string In_row_timestamp { get; set; }
        public string In_mode_flag { get; set; }
    }

    public class FetchLocalizationContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public List<FetchLocalizationScreen> Screen { get; set; }
        public List<FetchLocalizationFE> FE { get; set; }
        public List<FetchLocalizationBE> BE { get; set; }
    }
    public class LocalizationList
    {
        public FetchLocalizationContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion

    #region SaveInput
    public class SaveLocalizationDetail
    {
        public int In_localization_rowid { get; set; }
        public string In_activity_code { get; set; }
        public string In_control_type { get; set; }
        public string In_control_code { get; set; }
        public string In_data_field { get; set; }
        public string In_locale_desc { get; set; }
        public string In_locale_ll_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }
    }

    public class SaveLocalizationContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public List<SaveLocalizationDetail> Detail { get; set; }
    }

    public class SaveLocalizationDocument
    {
        public SaveLocalizationContext context { get; set; }
    }

    public class SaveLocalization
    {
        public SaveLocalizationDocument document { get; set; }
    }
    #endregion
    #region LocalizationOutput
    public class LocalOutputContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
    }
    public class LocalOutput
    {
        public LocalOutputContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }
    }
    #endregion
}
