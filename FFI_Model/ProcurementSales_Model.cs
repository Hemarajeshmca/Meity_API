using System.Collections.Generic;

namespace FFI_Model
{
    public class ProcurementSales_Model
    { 
        public class ProcurementSalesInfoParams
        {
            public string InstanceName { get; set; }
            public int Start_Year { get; set; }
            public int End_Year { get; set; }
        }

        public class ProcurementSalesList
        {
            public List<ProcurementSalesInfo> PROCUREMENTANDSALES { get; set; }
        }
        public class ProcurementSalesInfo
        {
            public int YEAR { get; set; }
            public string FPONAME { get; set; }
            public string FARMERCODE { get; set; }
            public string FARMERNAME { get; set; }
            public string TYPE { get; set; }
            public string CROPTYPE { get; set; }
            public string CROPNAME { get; set; }
            public string CROPVARIETY { get; set; }
            public decimal QUANTITY { get; set; }
            public decimal RATE { get; set; }
            public decimal TOTALAMOUNT { get; set; }
            public string LOTNUMBER { get; set; }

        }

    }
}
