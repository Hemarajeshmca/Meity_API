using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFI_Model
{
    public class SMSICDProducthistory_BO
    {
        public List<PRODUCTHISTORYHEADER> PRODUCTHISTORY { get; set; }

    }
    public class PRODUCTHISTORYHEADER
    {
        public int PRODUCT_ROWID { get; set; }
        public string ORGN_NAME { get; set; }
        public string PRODUCT_CODE { get; set; }
        public string PRODUCT_NAME { get; set; }
        public string PRODUCT_CATG_CODE { get; set; }
        public string PRODUCT_SUBCATG_CODE { get; set; }
        public decimal BASE_PRICE { get; set; }
        public decimal CURRENT_QTY { get; set; }
        public string UOMTYPE { get; set; }
        public List<PRODUCTHISTORYINWARD> PRODUCTHISTORYINWARD  { get; set; }
        public List<PRODUCTHISTORYOUTWARD> PRODUCTHISTORYOUTWARD { get; set; }
    }

    public class PRODUCTHISTORYINWARD
    {
        public string INWARDNO { get; set; }
        public DateTime INWARDDATE { get; set; }
        public string INWARDPRODUCTCODE { get; set; }
        public decimal INWARDQTY { get; set; }
        public decimal INWARDPRODCUTAMOUNT { get; set; }
    }
    public class PRODUCTHISTORYOUTWARD
    {
        public string OUTWARDNO { get; set; }
        public DateTime OUTWARDDATE{ get; set; }
        public string OUTWARDPRODUCTCODE { get; set; }
        public decimal OUTWARDQTY { get; set; }
    }
}
