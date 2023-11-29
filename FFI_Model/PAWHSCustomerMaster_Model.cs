using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    class PAWHSCustomerMaster_Model
    {
    }
    public class List
    {
        public int Out_customer_rowid { get; set; }
        public string Out_customer_code { get; set; }
        public string Out_customer_type { get; set; }
        public string Out_customer_name { get; set; }
        public string Out_customer_addr1 { get; set; }
        public string Out_customer_addr2 { get; set; }
        public string Out_customer_country { get; set; }
        public string Out_customer_state { get; set; }
        public string Out_customer_dist { get; set; }
        public string Out_customer_taluk { get; set; }
        public string Out_customer_panchayat { get; set; }
        public string Out_customer_village { get; set; }
        public string Out_customer_pincode { get; set; }
        public string Out_status_code { get; set; }
        public string Out_status_desc { get; set; }
        public string Out_row_timestamp { get; set; }

    }
    public class FarmerFilterCustomer
    {
        public string FilterBy_Option { get; set; }
        public string FilterBy_Code { get; set; }
        public string FilterBy_FromValue { get; set; }
        public string FilterBy_ToValue { get; set; }
        public int out_record_count { get; set; }
        public int from_index { get; set; }
        public int to_index { get; set; }
        public int record_count { get; set; }
    }
    public class Context
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public FarmerFilterCustomer Filter { get; set; }
        public IList<List> List { get; set; }

    }
 
    public class PAWHSCustomerApplication
    {
        public Context context { get; set; }
        public ApplicationException ApplicationException { get; set; }

    }
    public class Header
    {
        public int IOU_customer_rowid { get; set; }
        public string IOU_customer_code { get; set; }
        public string In_customer_type { get; set; }
        public string In_customer_name { get; set; }
        public string In_customer_addr1 { get; set; }
        public string In_customer_addr2 { get; set; }
        public string In_customer_country { get; set; }
        public string In_customer_country_desc { get; set; }
        public string In_customer_state { get; set; }
        public string In_customer_state_desc { get; set; }
        public string In_customer_dist { get; set; }
        public string In_customer_dist_desc { get; set; }
        public string In_customer_taluk { get; set; }
        public string In_customer_taluk_desc { get; set; }
        public string In_customer_panchayat { get; set; }
        public string In_customer_panchayat_desc { get; set; }
        public string In_customer_village { get; set; }
        public string In_customer_village_desc { get; set; }
        public string In_customer_pincode { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class SingleContext
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public Header Header { get; set; }

    }

    public class SingleApplication
    {
        public SingleContext context { get; set; }
        public ApplicationException ApplicationException { get; set; }

    }
    public class SaveHeaderCustomer
    {
        public int IOU_customer_rowid { get; set; }
        public string IOU_customer_code { get; set; }
        public string In_customer_type { get; set; }
        public string In_customer_name { get; set; }
        public string In_customer_addr1 { get; set; }
        public string In_customer_addr2 { get; set; }
        public string In_customer_country { get; set; }
        public string In_customer_state { get; set; }
        public string In_customer_dist { get; set; }
        public string In_customer_taluk { get; set; }
        public string In_customer_panchayat { get; set; }
        public string In_customer_village { get; set; }
        public string In_customer_pincode { get; set; }
        public string In_status_code { get; set; }
        public string In_status_desc { get; set; }
        public string In_mode_flag { get; set; }
        public string In_row_timestamp { get; set; }

    }
    public class SaveContextCustomer
    {
        public string orgnId { get; set; }
        public string locnId { get; set; }
        public string userId { get; set; }
        public string localeId { get; set; }
        public SaveHeaderCustomer Header { get; set; }

    }
    public class DocumentCustomer
    {
        public SaveContextCustomer context { get; set; }

    }
    public class SaveApplication
    {
        public DocumentCustomer document { get; set; }

    }
}
