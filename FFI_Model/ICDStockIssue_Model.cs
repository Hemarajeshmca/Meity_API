using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
    public class ICDStockIssue_Model
    {
       public List<StockIssueList> IssueTransferList { get; set; }
    }
    public class StockIssueList
    {
        public int Out_inward_rowid { get; set; }
        public string Out_ic_code { get; set; }
        public string Out_ic_name { get; set; }
        public string Out_grn_no { get; set; }
        public string Out_grn_date { get; set; }
        public string Out_supplier_name { get; set; }
        public string Out_supplier_location { get; set; }
        public string Out_from_state { get; set; }
        public string Out_status_code { get; set; }
        public decimal received_qty { get; set; }
        public decimal accepted_qty { get; set; }
        public decimal noofstock { get; set; }
        public string product_code { get; set; }
        public string uom_code { get; set; }
        public string Out_product_name { get; set; }
    }
}
