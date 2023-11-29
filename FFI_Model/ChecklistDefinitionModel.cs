
using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class ChecklistDefinitionModel
    {
    }
    #region fetch
    public class Chklist_FetchHeader
    {
        public int IOU_chklst_rowid { get; set; }
        public string IOU_activity_code { get; set; }
        public string In_activity_desc { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class Chklist_FetchElement
    {
        public int In_chklstelement_rowid { get; set; }
        public string In_element_code { get; set; }
        public string In_element_desc { get; set; }
        public string In_subelement_code { get; set; }
        public string In_subelement_desc { get; set; }
        public string In_mandatory_flag { get; set; }
        public string In_allowed_option { get; set; }
        public string In_any_all_flag { get; set; }
        public string In_any_all_flag_desc { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class Chklist_FetchContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public Chklist_FetchHeader Header { get; set; }
        public IList<Chklist_FetchElement> Element { get; set; }
        public string activity_code { get; set; }
        public int chklst_rowid { get; set; }


    }
    public class Chklist_FetchApplicationException
    {
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
    public class Chklist_FetchApplication
    {
        public Chklist_FetchContext context { get; set; }
        public Chklist_FetchApplicationException ApplicationException { get; set; }

    }
    #endregion

    #region SAVE
    public class Chklist_SHeader
    {
        public int IOU_chklst_rowid { get; set; }
        public string In_activity_code { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class Chklist_SElement
    {
        public int In_chklstelement_rowid { get; set; }
        public string In_element_code { get; set; }
        public string In_subelement_code { get; set; }
        public string In_mandatory_flag { get; set; }
        public string In_allowed_option { get; set; }
        public string In_any_all_flag { get; set; }
        public string In_status_code { get; set; }
        public string In_mode_flag { get; set; }

    }
    public class Chklist_SContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public Chklist_SHeader Header { get; set; }
        public IList<Chklist_SElement> Element { get; set; }

    }
    public class Chklist_SDocument
    {
        public Chklist_SContext context { get; set; }

    }
    public class Chklist_SApplication
    {
        public Chklist_SDocument document { get; set; }

    }
    #endregion
}
