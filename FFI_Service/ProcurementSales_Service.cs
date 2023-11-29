using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using static FFI_Model.ProcurementSales_Model;

namespace FFI_Service
{
   public class ProcurementSales_Service
    {
        ProcurementSales_DataModel objData = new ProcurementSales_DataModel();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ProcurementSales_Service));

        public ProcurementSalesList GetProcurementAndSalesReport(ProcurementSalesInfoParams objInput ,string ConString)
        {
            ProcurementSalesList OBJCOMMON = new ProcurementSalesList();
            try
            {

                DataTable dt = objData.GetProcurementAndSalesReport(objInput,ConString);
                List<ProcurementSalesInfo> objList = new List<ProcurementSalesInfo>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ProcurementSalesInfo Objdet = new ProcurementSalesInfo();
                    Objdet.YEAR = Convert.ToInt32(dt.Rows[i]["SowingYear"].ToString());
                    Objdet.FPONAME = dt.Rows[i]["fponame"].ToString();
                    Objdet.FARMERCODE = dt.Rows[i]["FarmerCode"].ToString();
                    Objdet.FARMERNAME = dt.Rows[i]["FarmerName"].ToString();
                    Objdet.TYPE = dt.Rows[i]["Type"].ToString();                    
                    Objdet.CROPTYPE = dt.Rows[i]["CropType"].ToString();
                    Objdet.CROPNAME = dt.Rows[i]["CropName"].ToString();
                    Objdet.CROPVARIETY = dt.Rows[i]["CropVariety"].ToString();
                    Objdet.QUANTITY =Convert.ToDecimal(dt.Rows[i]["SeedQuantity"].ToString());
                    Objdet.RATE = Convert.ToDecimal(dt.Rows[i]["Seedprice"].ToString());
                    Objdet.TOTALAMOUNT = Convert.ToDecimal(dt.Rows[i]["Pricepaid"].ToString());
                    Objdet.LOTNUMBER = Convert.ToString(dt.Rows[i]["LotNumber"].ToString());


                    objList.Add(Objdet);
                }
                OBJCOMMON.PROCUREMENTANDSALES = objList;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return OBJCOMMON;
        }

    }
}
