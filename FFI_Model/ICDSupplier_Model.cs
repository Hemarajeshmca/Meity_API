using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    public class ICDSupplier_Model
    {
        #region List
        public class ICDSupplierRootObject
        {
            public ICDSupplierContext context { get; set; }
            public ICDSupplierApplicationException ApplicationException { get; set; }
        }
        public class ICDSupplierApplication
        {
            public ICDSupplierContext context { get; set; }
            public ICDSupplierApplicationException ApplicationException { get; set; }

        }
        public class ICDSupplierApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class ICDSupplierContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public string FilterBy_Option { get; set; }
            public string FilterBy_Code { get; set; }
            public string FilterBy_FromValue { get; set; }
            public string FilterBy_ToValue { get; set; }
            public IList<ICDSupplierList> List { get; set; }

        }
        public class ICDSupplierList
        {

            public int Out_supplier_rowid { get; set; }
            public string Out_supplier_code { get; set; }
            public string Out_version_no { get; set; }
            public string Out_supplier_name { get; set; }
            public string Out_pan_no { get; set; }
            public string Out_status_code { get; set; }
            public string Out_status_desc { get; set; }
            public string Out_row_timestamp { get; set; }
            public string Out_ic_name { get; set; }

        }
        #endregion
        #region Fetch 

        public class ICDSupplierFetchApplication
        {

            public ICDSupplierFetchContext context { get; set; }

        }
        public class ICDSupplierFetchContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }

            public int supplier_rowid { get; set; }
            public string supplier_code { get; set; }
            public int version_no { get; set; }
            public ICDSupplierFetchHeader Header { get; set; }
            public IList<ICDSupplierFetchAddress> SupplierAddress { get; set; }
            public IList<ICDSupplierFetchTax> SupplierTax { get; set; }
        }
        public class ICDSupplierFetchHeader
        {
            public Int32 In_supplier_rowid { get; set; }
            public string In_ic_code { get; set; }
            public string In_ic_name { get; set; }
            public string In_supplier_code { get; set; }
            public Int32 In_version_no { get; set; }
            public string In_supplier_name { get; set; }
            public string In_pan_no { get; set; }
            public string In_status_code { get; set; }
            public string In_status_desc { get; set; }
            public string In_mode_flag { get; set; }
            public string In_row_timestamp { get; set; }
        }
        public class ICDSupplierFetchAddress
        {
            public string SupplierAddress { get; set; }
            public int In_supplier_addr_rowid { get; set; }
            public string In_supplier_addr_type { get; set; }
            public string In_supplier_addr_type_desc { get; set; }
            public string In_supplier_addr1 { get; set; }
            public string In_supplier_addr2 { get; set; }
            public string In_supplier_country { get; set; }
            public string In_supplier_country_desc { get; set; }
            public string In_supplier_state { get; set; }
            public string In_supplier_state_desc { get; set; }
            public string In_supplier_dist { get; set; }
            public string In_supplier_dist_desc { get; set; }
            public string In_supplier_taluk { get; set; }
            public string In_supplier_taluk_desc { get; set; }
            public string In_supplier_panchayat { get; set; }
            public string In_supplier_panchayat_desc { get; set; }
            public string In_supplier_village { get; set; }
            public string In_supplier_village_desc { get; set; }
            public string In_supplier_pincode { get; set; }
            public string In_supplier_pincode_desc { get; set; }
            public string In_status_code { get; set; }
            public string In_status_desc { get; set; }
            public string In_mode_flag { get; set; }
        }
        public class ICDSupplierFetchTax
        {
            public string SupplierTax { get; set; }
            public int In_tax_rowid { get; set; }
            public string In_tax_type { get; set; }
            public string In_tax_reg_no { get; set; }
            public string In_state_code { get; set; }
            public string In_state_desc { get; set; }
            public string In_status_code { get; set; }
            public string In_status_desc { get; set; }
            public string In_mode_flag { get; set; }
        }


        #endregion
        #region Save
        public class SaveSupplierHeader
        {
            public int In_supplier_rowid { get; set; }
            public string In_supplier_code { get; set; }
            public int In_version_no { get; set; }
            public string In_supplier_name { get; set; }
            public string In_pan_no { get; set; }
            public string In_status_code { get; set; }
            public string In_mode_flag { get; set; }
            public string In_row_timestamp { get; set; }
            public int In_supplier_rowid1 { get; set; }
            public string In_supplier_code1 { get; set; }
            public string errorNo { get; set; }

        }
        public class SaveSupplierAddress
        {
            public string In_supplier_code { get; set; }
            public int In_version_no { get; set; }
            public int In_supplier_addr_rowid { get; set; }
            public string In_supplieraddr_type { get; set; }
            public string In_supplier_addr1 { get; set; }
            public string In_supplier_addr2 { get; set; }
            public string In_supplier_country { get; set; }
            public string In_supplier_state { get; set; }
            public string In_supplier_dist { get; set; }
            public string In_supplier_taluk { get; set; }
            public string In_supplier_panchayat { get; set; }
            public string In_supplier_village { get; set; }
            public string In_supplier_pincode { get; set; }
            public string In_status_code { get; set; }
            public string In_mode_flag { get; set; }
            public string errorNo { get; set; }
        }
        public class SaveSupplierTax
        {
            public string In_supplier_code { get; set;}
            public int In_version_no { get; set; }
            public int In_tax_rowid { get; set; }
            public string In_tax_type { get; set; }
            public string In_tax_reg_no { get; set; }
            public string In_state_code { get; set; }
            public string In_status_code { get; set; }
            public string In_mode_flag { get; set; }

        }
        public class SaveSupplierContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public SaveSupplierHeader Header { get; set; }
            public IList<SaveSupplierAddress> SupplierAddress { get; set; }
            public IList<SaveSupplierTax> SupplierTax { get; set; }

        }
        public class SaveSupplierDocument
        {
            public SaveSupplierContext context { get; set; }
            public ApplicationException ApplicationException { get; set; }

        }
        public class SaveSupplierApplication
        {
            public SaveSupplierDocument document { get; set; }

        }
        #endregion
    }
}
