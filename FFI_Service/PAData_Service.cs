using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using static FFI_Model.PADataModel;

namespace FFI_Service
{
    public class PAData_Service
    {
        PAData_DataModel objdata_PA = new PAData_DataModel();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAData_Service));
        public DataTable GetPAPurchaseList(PAPurchaseParams objparam, string constring)
        {
            DataTable dtPAPur = new DataTable();
            try
            {
                DataSet ds = objdata_PA.GetPAPurchaseList(objparam, constring);
                dtPAPur = ds.Tables[0];
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return dtPAPur;
        }
        public PASaleDetails GetPASaleList(PASaleInputParams objparam,  string constring)
        {
            PASaleDetails objMain = new PASaleDetails();
            PADataModel.ServiceStatus objstatus = new PADataModel.ServiceStatus();
            try
            {
                DataSet ds = objdata_PA.GetPASaleList(objparam, constring);
                DataTable dtStatus = new DataTable();
                DataTable dtsaleHeader = new DataTable();
                DataTable dtsaleDetail = new DataTable();
                dtStatus = ds.Tables[0];
                if (dtStatus.Rows[0]["Status"].ToString() == "Success")
                {
                    dtsaleHeader = ds.Tables[1];
                    dtsaleDetail = ds.Tables[2];
                    List<GetPASaleList> objlist = new List<GetPASaleList>();
                    for (int i = 0; i < dtsaleHeader.Rows.Count; i++)
                    {
                        GetPASaleList objheader = new GetPASaleList();

                        objheader.SALE_NO = dtsaleHeader.Rows[i]["SALE_NO"].ToString();
                        objheader.SALE_DATE = dtsaleHeader.Rows[i]["SALE_DATE"].ToString();
                        objheader.AGGREGATOR_CODE = dtsaleHeader.Rows[i]["AGGREGATOR_CODE"].ToString();
                        objheader.AGGREGATOR_NAME = dtsaleHeader.Rows[i]["AGGREGATOR_NAME"].ToString();
                        objheader.BUYER_CODE = dtsaleHeader.Rows[i]["BUYER_CODE"].ToString();
                        objheader.BUYER_NAME = dtsaleHeader.Rows[i]["BUYER_NAME"].ToString();
                        objheader.SALE_AMOUNT = Convert.ToDecimal(dtsaleHeader.Rows[i]["SALE_AMOUNT"].ToString());
                        objheader.PAYMENT_MODE = dtsaleHeader.Rows[i]["PAYMENT_MODE"].ToString();
                        objheader.AMOUNT_PAID = Convert.ToDecimal(dtsaleHeader.Rows[i]["AMOUNT_PAID"].ToString());
                        objheader.BALANCE_AMOUNT = Convert.ToDecimal(dtsaleHeader.Rows[i]["BALANCE_AMOUNT"].ToString());
                        List<SaleDetails> objinvdet = new List<SaleDetails>();

                        var saledtl = (from e in dtsaleDetail.AsEnumerable() where e.Field<string>("SALE_NO") == objheader.SALE_NO select e).ToList();

                        if (saledtl.Count > 0)
                        {
                            DataTable dtdtl = dtsaleDetail.AsEnumerable().Where(r => r.Field<string>("SALE_NO") == objheader.SALE_NO).CopyToDataTable();

                            for (int j = 0; j < dtdtl.Rows.Count; j++)
                            {
                                SaleDetails objdet = new SaleDetails();
                                objdet.ITEM_NAME = dtdtl.Rows[j]["ITEM_NAME"].ToString();
                                objdet.ITEM_CATEGORY = dtdtl.Rows[j]["ITEM_CATEGORY"].ToString();
                                objdet.QUANTITY_PROCURED = Convert.ToDecimal(dtdtl.Rows[j]["QUANTITY_PROCURED"].ToString());
                                objdet.SALE_RATE = Convert.ToDecimal(dtdtl.Rows[j]["SALE_RATE"].ToString());
                                objdet.UOM = dtdtl.Rows[j]["UOM"].ToString();
                                objdet.CGST = Convert.ToDecimal(dtdtl.Rows[j]["CGST"].ToString());
                                objdet.SGST = Convert.ToDecimal(dtdtl.Rows[j]["SGST"].ToString());
                                objdet.IGST = Convert.ToDecimal(dtdtl.Rows[j]["IGST"].ToString());
                                objdet.DISCOUNT = Convert.ToDecimal(dtdtl.Rows[j]["DISCOUNT"].ToString());
                                objdet.WITHOUT_TAX_AMOUNT = Convert.ToDecimal(dtdtl.Rows[j]["WITHOUT_TAX_AMOUNT"].ToString());
                                objdet.TOTAL_AMOUNT = Convert.ToDecimal(dtdtl.Rows[j]["TOTAL_AMOUNT"].ToString());
                                objinvdet.Add(objdet);
                            }
                            objheader.SALEDETAILS = objinvdet;
                        }

                        objlist.Add(objheader);
                    }
                    if (dtsaleHeader.Rows.Count > 0) { objstatus.Message = dtStatus.Rows[0]["Status"].ToString(); }
                    else { objstatus.Message = "No Data availble in the given Date"; }

                    objMain.ServiceResponse = objstatus;
                    objMain.PASALE = objlist;
                }
                else
                {
                    objstatus.Message = dtStatus.Rows[0]["Status"].ToString();
                    objMain.ServiceResponse = objstatus;
                    objMain.PASALE = null;
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return objMain;
        }
    }

}
