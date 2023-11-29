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
   public class ProductionDataCapture_Service
    {
        ProductionDataCapture_DataModel ObjDataModel = new ProductionDataCapture_DataModel();

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ProductionDataCapture_Service)); //Declaring Log4Net. 


        public ProductionDataContext GetProductionDataCaptureReport(ProductionDataCapture_Model query, string conString)
        {
            ProductionDataContext objprddata = new ProductionDataContext();

            try
            {
                Result objres = new Result();
                DataTable dtPrdHdr = new DataTable();
                DataTable dtPrdDetails = new DataTable();
                //if (query.FROMDATE != "" && query.TODATE != "")
                //{
                    DataSet ds = ObjDataModel.GetProductionDataCaputure_Report(query, conString);
                    dtPrdHdr = ds.Tables[0];
                    dtPrdDetails = ds.Tables[1];
               // }
               //if ( query.FROMDATE == "" || query.TODATE=="")
               // {
               //     objres.Reason = "Inputs are not valid";
               //     objres.Status = "Failed";
               // }
              if(dtPrdHdr.Rows.Count>0 || dtPrdDetails.Rows.Count > 0)
                {
                    objres.Reason = "Succeed";
                    objres.Status = "Success";
                }
                else
                {
                    objres.Reason = "There is no record found on this date";
                    objres.Status = "Success";
                }


                List<ProductionDataHeader> objInvHeader = new List<ProductionDataHeader>();
                for (int i = 0; i < dtPrdHdr.Rows.Count; i++)
                {

                    ProductionDataHeader objHeader = new ProductionDataHeader();
                    objHeader.FARMER_CODE = dtPrdHdr.Rows[i]["farmer_code"].ToString();
                    objHeader.FARMER_NAME = dtPrdHdr.Rows[i]["farmer_name"].ToString();
                    objHeader.FHWNAME =  dtPrdHdr.Rows[i]["fhw_name"].ToString() ; 
                    objHeader.FARMER_VILLAGE = dtPrdHdr.Rows[i]["farmer_village"].ToString();
                    objHeader.FARMER_PANCHAYAT = dtPrdHdr.Rows[i]["farmer_panchayat"].ToString();
                    objHeader.FARMER_TALUK = dtPrdHdr.Rows[i]["farmer_taluk"].ToString();
                    objHeader.FARMER_DISTRICT = dtPrdHdr.Rows[i]["farmer_dist"].ToString();
                    objHeader.FARMER_STATE = dtPrdHdr.Rows[i]["farmer_state"].ToString(); 
                    objHeader.FPO_NAME = dtPrdHdr.Rows[i]["fpo_name"].ToString();
                    objHeader.FPO_DISTRICT =  dtPrdHdr.Rows[i]["fpo_dist"].ToString();
                    objHeader.FPO_TALUK = dtPrdHdr.Rows[i]["fpo_taluk"].ToString();
                    
                    List<ProductionDataDetails> objPrdDet = new List<ProductionDataDetails>();

                    var stokdtl = (from e in dtPrdDetails.AsEnumerable() where e.Field<string>("farmer_code") == objHeader.FARMER_CODE select e).ToList();
                    //sb.WriteLine("Step 7");
                    if (stokdtl.Count != 0)
                    {
                        DataTable dtstok = dtPrdDetails.AsEnumerable().Where(r => r.Field<string>("farmer_code") == objHeader.FARMER_CODE).CopyToDataTable();
                        for (int j = 0; j < dtstok.Rows.Count; j++)
                        {
                            //sb.WriteLine("Step 8");
                            ProductionDataDetails objstk = new ProductionDataDetails();
                            objstk.YEAR = dtstok.Rows[j]["Year_desc"].ToString();
                            objstk.SEASON = dtstok.Rows[j]["Season_desc"].ToString();
                            objstk.CROPTYPE = dtstok.Rows[j]["Croptype_desc"].ToString();
                            objstk.CROPCLASS = dtstok.Rows[j]["CropClass_desc"].ToString();
                            objstk.VAREITY = dtstok.Rows[j]["Vareity_desc"].ToString();
                            objstk.SEEDNAME = dtstok.Rows[j]["SeedName_desc"].ToString();
                            objstk.ACTUALPRODUCTION = string.IsNullOrEmpty(dtstok.Rows[j]["ActualProduction"].ToString())?0 : Convert.ToDecimal(dtstok.Rows[j]["ActualProduction"].ToString());                             
                            objstk.AVAILABLEFORSALE = string.IsNullOrEmpty(dtstok.Rows[j]["AvailabeForSale"].ToString())?0 : Convert.ToDecimal(dtstok.Rows[j]["AvailabeForSale"].ToString());
                            objstk.CREATEDDATE = DateTime.ParseExact(dtstok.Rows[j]["CreatedDate"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                            objstk.CREATEDBY= dtstok.Rows[j]["CreatedBy"].ToString(); 
                            objstk.ROW_SLNO = Convert.ToInt32(dtstok.Rows[j]["sno"].ToString());
                            // Convert.ToString(dtstok.Rows[j]["CreatedDate"].ToString());

                            objPrdDet.Add(objstk);
                        }
                        objHeader.Detail = objPrdDet;
                    }
                    else
                    {

                    }
                    objInvHeader.Add(objHeader);
                }

                objprddata.Header = objInvHeader;
                objprddata.Result = objres;
                //sb.WriteLine("Step 9");
            }

            catch (Exception ex)
             {
                throw ex;
            }
            return objprddata;
        }
    }
}
