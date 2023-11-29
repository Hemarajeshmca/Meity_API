using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
   public class FISChecklistModel
    {
        #region fetch
        public class Element
        {
            public int In_chklstelement_rowid { get; set; }
            public string In_element_code { get; set; }
            public string In_element_desc { get; set; }
            public string In_subelement_code { get; set; }
            public string In_subelement_desc { get; set; }
            public string In_allowed_option { get; set; }
            public string In_mandatory_flag { get; set; }
            public string In_any_all_flag { get; set; }
            public string In_element_value { get; set; }
            public string In_complied_flag { get; set; }
            public string In_verified_on { get; set; }
            public string In_verified_by { get; set; }
            public string In_remarks { get; set; }
            public string In_status_code { get; set; }
            public string In_status_desc { get; set; }
            public string In_mode_flag { get; set; }

        }
        public class History
        {
            public int In_row_id { get; set; }
            public string In_edit_date { get; set; }
            public string In_edited_by { get; set; }
            public string In_mode_flag { get; set; }

        }
        public class FContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public IList<Element> Element { get; set; }
            public IList<History> History { get; set; }
            public int doc_rowid { get; set; }
            public string doc_no { get; set; }
            public string doc_type { get; set; }

        }
        public class ApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class FApplication
        {
            public FContext context { get; set; }
            public ApplicationException ApplicationException { get; set; }

        }
        #endregion
        #region history
        public class Chklist_Element
        {
            public int In_chklstelement_rowid { get; set; }
            public string In_element_code { get; set; }
            public string In_element_desc { get; set; }
            public string In_subelement_code { get; set; }
            public string In_subelement_desc { get; set; }
            public string In_mandatory_flag { get; set; }
            public string In_allowed_option { get; set; }
            public string In_any_all_flag { get; set; }
            public string In_element_value { get; set; }
            public string In_complied_flag { get; set; }
            public string In_remarks { get; set; }
            public string In_mode_flag { get; set; }

        }
        public class HContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public IList<Chklist_Element> Chklist_Element { get; set; }
            public int doc_rowid { get; set; }
            public int row_id { get; set; }
            public string doc_no { get; set; }
            public string doc_type { get; set; }
            public string edit_date { get; set; }
            public string edited_by { get; set; }
            public string mode_flag { get; set; }
        }
        public class HApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class HApplication
        {
            public HContext context { get; set; }
            public HApplicationException ApplicationException { get; set; }

        }
        #endregion
        #region save
        public class SaveCheckTranElement
        {
            public int IOU_doc_rowid { get; set; }
            public string In_doc_no { get; set; }
            public string In_doc_type { get; set; }
            public int In_chklstelement_rowid { get; set; }
            public string In_element_code { get; set; }
            public string In_subelement_code { get; set; }
            public string In_mandatory_flag { get; set; }
            public string In_allowed_option { get; set; }
            public string In_any_all_flag { get; set; }
            public string In_element_value { get; set; }
            public string In_complied_flag { get; set; }
            public string In_verified_on { get; set; }
            public string In_verified_by { get; set; }
            public string In_remarks { get; set; }
            public string In_status_code { get; set; }
            public string In_status_desc { get; set; }
            public string In_mode_flag { get; set; }

        }
        public class SaveCheckTranContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public IList<SaveCheckTranElement> Element { get; set; }
          
            
        }
        public class SaveCheckTranDocument
        {
            public SaveCheckTranContext context { get; set; }

        }
        public class SaveCheckTranApplication
        {
            public SaveCheckTranDocument document { get; set; }

        }
        #endregion
    }
}
