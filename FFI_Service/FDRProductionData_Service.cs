using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using FFI_DataModel;
using FFI_Model;
using System.Linq;
using System.Globalization;

namespace FFI_Service
{
    public class FDRProductionData_Service
    {
        FDRProductionData_DataModel objdata = new FDRProductionData_DataModel();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FDRProductionData_Service));


        public FDRProductDataCapture GetProductionDataCapture_srv(ProductionDataInputParams objparam, string orgn_code, string constring)
        {
            FDRProductDataCapture objMain = new FDRProductDataCapture();
            try
            {
                DataSet ds = objdata.GetProductionDataCaptureList(objparam, orgn_code, constring);
                DataTable dtprodlist = new DataTable();
                dtprodlist = ds.Tables[0];
                List<GetFDRProductionData> objlist = new List<GetFDRProductionData>();
                for (int i = 0; i < dtprodlist.Rows.Count; i++)
                {
                    GetFDRProductionData objdet = new GetFDRProductionData();
                    objdet.FPO_NAME = dtprodlist.Rows[i]["FPO_NAME"].ToString();
                    objdet.DISTRICT = dtprodlist.Rows[i]["DISTRICT"].ToString();
                    objdet.VILLAGE = dtprodlist.Rows[i]["VILLAGE"].ToString();
                    objdet.FARMER_CODE = dtprodlist.Rows[i]["FARMER_CODE"].ToString();
                    objdet.FARMER_NAME = dtprodlist.Rows[i]["FARMER_NAME"].ToString();
                    objdet.SURNAME_NAME = dtprodlist.Rows[i]["SURNAME_NAME"].ToString();
                    objdet.FHW_NAME = dtprodlist.Rows[i]["FHW_NAME"].ToString();
                    objdet.GENDER = dtprodlist.Rows[i]["GENDER"].ToString();
                    objdet.MOBILENO = dtprodlist.Rows[i]["MOBILENO"].ToString();
                    objdet.YEAR = Convert.ToInt32(dtprodlist.Rows[i]["YEAR"].ToString());
                    objdet.CROP_SEASON = dtprodlist.Rows[i]["CROP_SEASON"].ToString();
                    objdet.CROP_CLASSIFICATION = dtprodlist.Rows[i]["CROP_CLASSIFICATION"].ToString();
                    objdet.CROP_VARIETY = dtprodlist.Rows[i]["CROP_VARIETY"].ToString();
                    objdet.SEED_NAME = dtprodlist.Rows[i]["SEED_NAME"].ToString();
                    objdet.ACTUAL_PRODUCTION = Convert.ToDecimal(dtprodlist.Rows[i]["ACTUAL_PRODUCTION"].ToString());
                    objdet.AVAIALBLE_FOR_SALE = Convert.ToDecimal(dtprodlist.Rows[i]["AVAIALBLE_FOR_SALE"].ToString());

                    objlist.Add(objdet);
                }

                objMain.FDR_ProductionData = objlist;

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return objMain;
        }
        public DataTable GetProductionDataCapture_service(ProductionDataInputParams objparam,string orgn_code, string constring)
        {
                DataSet ds = objdata.GetProductionDataCaptureList(objparam, orgn_code, constring);
                DataTable dtprodlist = new DataTable();
                dtprodlist = ds.Tables[0];

            return dtprodlist;
        }
    }
}
