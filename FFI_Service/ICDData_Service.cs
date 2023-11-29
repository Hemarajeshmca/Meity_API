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
   public class ICDData_Service
    {
        ICDData_DataModel ObjICDDataModel = new ICDData_DataModel();

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDData_Service));

        public DataTable GetICDProductList(ICDDataInputParams objparam, string constring)
        {
            DataTable dtICDProductList = new DataTable();
            try
            {
                DataSet ds = ObjICDDataModel.GetICDProductList(objparam, constring);
                dtICDProductList = ds.Tables[0];
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return dtICDProductList;
        }


        public ICDInvoiceDetails GetICDInvoiceList(ICDInvoiceInputParams objparam,string orgn_code, string constring)
        {
            ICDInvoiceDetails objMain = new ICDInvoiceDetails();
            ServiceStatus objstatus = new ServiceStatus();
            try
            {
                DataSet ds = ObjICDDataModel.GetICDInvoiceList(objparam, orgn_code, constring);
                DataTable dtStatus = new DataTable();
                DataTable dtInvHeader = new DataTable();
                DataTable dtInvDetail = new DataTable();
                dtStatus = ds.Tables[0];
                if (dtStatus.Rows[0]["Status"].ToString() == "Success")
                {
                    dtInvHeader = ds.Tables[1];
                    dtInvDetail = ds.Tables[2];  
                    List<GetIcdInvoiceList> objlist = new List<GetIcdInvoiceList>();
                    for (int i = 0; i < dtInvHeader.Rows.Count; i++)
                    {
                        GetIcdInvoiceList objheader = new GetIcdInvoiceList();

                        objheader.FARMER_NAME = dtInvHeader.Rows[i]["FARMER_NAME"].ToString();
                        objheader.FARMER_CODE = dtInvHeader.Rows[i]["FARMER_CODE"].ToString();
                        objheader.MEMBER_TYPE = dtInvHeader.Rows[i]["MEMBER_TYPE"].ToString();
                        objheader.STATE = dtInvHeader.Rows[i]["STATE"].ToString();
                        objheader.DISTRICT = dtInvHeader.Rows[i]["DISTRICT"].ToString();
                        objheader.TALUK = dtInvHeader.Rows[i]["TALUK"].ToString();
                        objheader.VILLAGE = dtInvHeader.Rows[i]["VILLAGE"].ToString();
                        objheader.MOBILE_NUMBER = dtInvHeader.Rows[i]["MOBILE_NUMBER"].ToString();
                        objheader.GENDER = dtInvHeader.Rows[i]["GENDER"].ToString();
                        objheader.IC_CODE = dtInvHeader.Rows[i]["IC_CODE"].ToString();
                        objheader.ICD_NAME = dtInvHeader.Rows[i]["ICD_NAME"].ToString();
                        objheader.INVOICE_NUMBER = dtInvHeader.Rows[i]["INVOICE_NUMBER"].ToString();
                        objheader.INVOICE_DATE = dtInvHeader.Rows[i]["INVOICE_DATE"].ToString();
                        objheader.INVOICE_AMOUNT = Convert.ToDecimal(dtInvHeader.Rows[i]["INVOICE_AMOUNT"].ToString());
                        objheader.PAYMENT_MODE = dtInvHeader.Rows[i]["PAYMENT_MODE"].ToString();
                        objheader.AMOUNT_PAID = Convert.ToDecimal(dtInvHeader.Rows[i]["AMOUNT_PAID"].ToString());
                        objheader.BALANCE_AMOUNt = Convert.ToDecimal(dtInvHeader.Rows[i]["BALANCE_AMOUNt"].ToString());
                        List<InvoiceDetails> objinvdet = new List<InvoiceDetails>();

                        var invdtl = (from e in dtInvDetail.AsEnumerable() where e.Field<string>("INVOICE_NUMBER") == objheader.INVOICE_NUMBER select e).ToList();

                        if (invdtl.Count > 0)
                        {
                            DataTable dtdtl = dtInvDetail.AsEnumerable().Where(r => r.Field<string>("INVOICE_NUMBER") == objheader.INVOICE_NUMBER).CopyToDataTable();

                            for (int j = 0; j < dtdtl.Rows.Count; j++)
                            {
                                InvoiceDetails objdet = new InvoiceDetails();
                                objdet.PRODUCT_NAME = dtdtl.Rows[j]["PRODUCT_NAME"].ToString();
                                objdet.PRODUCT_CATEGORY = dtdtl.Rows[j]["PRODUCT_CATEGORY"].ToString();
                                objdet.UOM = dtdtl.Rows[j]["UOM"].ToString();
                                objdet.RATE = Convert.ToDecimal(dtdtl.Rows[j]["RATE"].ToString());
                                objdet.QUANTITY = Convert.ToDecimal(dtdtl.Rows[j]["QUANTITY"].ToString());
                                objdet.WITHOUT_TAX_AMOUNT = Convert.ToDecimal(dtdtl.Rows[j]["WITHOUT_TAX_AMOUNT"].ToString());
                                objdet.CGST = Convert.ToDecimal(dtdtl.Rows[j]["CGST"].ToString());
                                objdet.SGST = Convert.ToDecimal(dtdtl.Rows[j]["SGST"].ToString());
                                objdet.IGST = Convert.ToDecimal(dtdtl.Rows[j]["IGST"].ToString());
                                objdet.DISCOUNT = Convert.ToDecimal(dtdtl.Rows[j]["DISCOUNT"].ToString());
                                objdet.TOTAL_AMOUNT = Convert.ToDecimal(dtdtl.Rows[j]["TOTAL_AMOUNT"].ToString());
                                objinvdet.Add(objdet);
                            }
                            objheader.INVOICEDETAILS = objinvdet;
                        }

                        objlist.Add(objheader);
                    }
                    if (dtInvHeader.Rows.Count > 0) { objstatus.Message = dtStatus.Rows[0]["Status"].ToString(); }
                    else { objstatus.Message = "No Data availble in the given Date"; }
                    
                    objMain.ServiceResponse = objstatus;
                    objMain.ICD_INVOICE = objlist;
                }
                else
                {
                    objstatus.Message = dtStatus.Rows[0]["Status"].ToString();
                    objMain.ServiceResponse = objstatus; 
                     objMain.ICD_INVOICE = null;
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return objMain;
        }


        public ICDSupplierList GetICDSupplierList(ICDSupplierInputParams objparam, string constring)
        {
            ICDSupplierList objMain = new ICDSupplierList();
            try
            {
                DataSet ds = ObjICDDataModel.GetICDSupplierList(objparam, constring);
                DataTable dtICDSupplierList = new DataTable();
                dtICDSupplierList = ds.Tables[0];
                List<GetICDSupplierList> objlist = new List<GetICDSupplierList>();
                for (int i = 0; i < dtICDSupplierList.Rows.Count; i++)
                {
                    GetICDSupplierList objdet = new GetICDSupplierList();
                    objdet.IC_CODE = dtICDSupplierList.Rows[i]["IC_CODE"].ToString();
                    objdet.IC_NAME = dtICDSupplierList.Rows[i]["IC_NAME"].ToString();
                    objdet.FPO_Name = dtICDSupplierList.Rows[i]["FPO_Name"].ToString();
                    objdet.SUPPLIER_CODE = dtICDSupplierList.Rows[i]["SUPPLIER_CODE"].ToString();
                    objdet.SUPPLIER_NAME = dtICDSupplierList.Rows[i]["SUPPLIER_NAME"].ToString();
                    objdet.STATE = dtICDSupplierList.Rows[i]["STATE"].ToString();
                    
                    objlist.Add(objdet);
                }

                objMain.ICD_SupplierList = objlist;

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return objMain;
        }

        public ICDStockTransferList GetICDStockTransferList(ICDStockTransferParams objparam, string constring)
        {
            ICDStockTransferList objMain = new ICDStockTransferList();
            ServiceStatus objstatus = new ServiceStatus();
            try
            {
                DataSet ds = ObjICDDataModel.GetICDStockTransferList(objparam, constring);
                DataTable dtStatus = new DataTable();
                DataTable dtTrnsHeader = new DataTable();
                DataTable dtTrnsDetail = new DataTable();
                dtStatus = ds.Tables[0];
                if (dtStatus.Rows[0]["Status"].ToString() == "Success")
                {
                    dtTrnsHeader = ds.Tables[1];
                    dtTrnsDetail = ds.Tables[2];
                    List<GetIcdStockTransferList> objlist = new List<GetIcdStockTransferList>();
                    for (int i = 0; i < dtTrnsHeader.Rows.Count; i++)
                    {
                        GetIcdStockTransferList objheader = new GetIcdStockTransferList();

                        objheader.GRN_NO = dtTrnsHeader.Rows[i]["GRN_NO"].ToString();
                        objheader.FPO_NAME = dtTrnsHeader.Rows[i]["FPO_NAME"].ToString();
                        objheader.IC_CODE = dtTrnsHeader.Rows[i]["IC_CODE"].ToString();
                        objheader.IC_NAME = dtTrnsHeader.Rows[i]["IC_NAME"].ToString();
                        objheader.DISTRICT = dtTrnsHeader.Rows[i]["DISTRICT"].ToString();
                        objheader.GRN_DATE = dtTrnsHeader.Rows[i]["GRN_DATE"].ToString();
                        objheader.REMARKS = dtTrnsHeader.Rows[i]["REMARKS"].ToString();

                        List<StockTransferDetails> obtrnsdet = new List<StockTransferDetails>();

                        var trnsdtl = (from e in dtTrnsDetail.AsEnumerable() where e.Field<string>("GRN_NO") == objheader.GRN_NO select e).ToList();

                        if (trnsdtl.Count > 0)
                        {
                            DataTable dtdtl = dtTrnsDetail.AsEnumerable().Where(r => r.Field<string>("GRN_NO") == objheader.GRN_NO).CopyToDataTable();

                            for (int j = 0; j < dtdtl.Rows.Count; j++)
                            {
                                StockTransferDetails objdet = new StockTransferDetails();
                                objdet.ITEM = dtdtl.Rows[j]["ITEM"].ToString();
                                objdet.UOM = dtdtl.Rows[j]["UOM"].ToString();
                                objdet.RECEIVED_STOCK = Convert.ToDecimal(dtdtl.Rows[j]["RECEIVED_STOCK"].ToString());
                                objdet.ACCEPTED_STOCK = Convert.ToDecimal(dtdtl.Rows[j]["ACCEPTED_STOCK"].ToString());

                                obtrnsdet.Add(objdet);
                            }
                            objheader.StockTransferDetails = obtrnsdet;
                        }

                        objlist.Add(objheader);
                    }

                    if (dtTrnsHeader.Rows.Count > 0) { objstatus.Message = dtStatus.Rows[0]["Status"].ToString(); }
                    else { objstatus.Message = "No Data availble in the given Date"; }
                    objMain.ServiceResponse = objstatus;
                    objMain.ICD_StockTransferList = objlist;
                }
                else
                {
                    objstatus.Message = dtStatus.Rows[0]["Status"].ToString();
                    objMain.ServiceResponse = objstatus;
                    objMain.ICD_StockTransferList = null;
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return objMain;
        }


        public ICDStockInwardList GetICDStockInwardList(ICDStockInwardParams objparam, string constring)
        {
            ICDStockInwardList objMain = new ICDStockInwardList();
            ServiceStatus objstatus = new ServiceStatus();
            try
            {
                DataSet ds = ObjICDDataModel.GetICDStockInwardList(objparam, constring);
                DataTable dtStatus = new DataTable();
                DataTable dtInwrdHeader = new DataTable();
                DataTable dtInwrdDetail = new DataTable();
                dtStatus = ds.Tables[0];
                if (dtStatus.Rows[0]["Status"].ToString() == "Success")
                {
                 dtInwrdHeader = ds.Tables[1];
                dtInwrdDetail = ds.Tables[2];
                List<GetIcdStockInwardList> objlist = new List<GetIcdStockInwardList>();
                for (int i = 0; i < dtInwrdHeader.Rows.Count; i++)
                {
                    GetIcdStockInwardList objheader = new GetIcdStockInwardList();

                    objheader.GRN_NO = dtInwrdHeader.Rows[i]["GRN_NO"].ToString();
                    objheader.GRN_DATE = dtInwrdHeader.Rows[i]["GRN_DATE"].ToString();
                    objheader.FPO_NAME = dtInwrdHeader.Rows[i]["FPO_NAME"].ToString();
                    objheader.IC_CODE = dtInwrdHeader.Rows[i]["IC_CODE"].ToString();
                    objheader.IC_NAME = dtInwrdHeader.Rows[i]["IC_NAME"].ToString();
                    objheader.DISTRICT = dtInwrdHeader.Rows[i]["DISTRICT"].ToString();
                    objheader.SUPPLIER_NAME = dtInwrdHeader.Rows[i]["SUPPLIER_NAME"].ToString();
                    objheader.SUPPLIER_LOCATION = dtInwrdHeader.Rows[i]["SUPPLIER_LOCATION"].ToString();
                    objheader.SUPPLIER_STATE = dtInwrdHeader.Rows[i]["SUPPLIER_STATE"].ToString();
                    objheader.TOTAL_TAXAMOUNT = Convert.ToDecimal(dtInwrdHeader.Rows[i]["TOTAL_TAX"].ToString());
                    objheader.TOTAL_AMOUNT = Convert.ToDecimal(dtInwrdHeader.Rows[i]["TOTAL_AMOUNT"].ToString());

                    List<StockInwardDetails> obinwrdsdet = new List<StockInwardDetails>();

                    var inwrddtl = (from e in dtInwrdDetail.AsEnumerable() where e.Field<string>("GRN_NO") == objheader.GRN_NO select e).ToList();

                    if (inwrddtl.Count > 0)
                    {
                        DataTable dtdtl = dtInwrdDetail.AsEnumerable().Where(r => r.Field<string>("GRN_NO") == objheader.GRN_NO).CopyToDataTable();

                        for (int j = 0; j < dtdtl.Rows.Count; j++)
                        {
                            StockInwardDetails objdet = new StockInwardDetails();
                            objdet.PRODUCT_NAME = dtdtl.Rows[j]["PRODUCT_NAME"].ToString();
                            objdet.PRODUCT_CATEGORY = dtdtl.Rows[j]["PRODUCT_CATEGORY"].ToString();
                            objdet.HSN_CODE = dtdtl.Rows[j]["HSN_CODE"].ToString();
                            objdet.UOM = dtdtl.Rows[j]["UOM"].ToString();
                            objdet.QUANTITY_PURCHASED = Convert.ToDecimal(dtdtl.Rows[j]["QUANTITY_PURCHASED"].ToString());
                            objdet.RATE = Convert.ToDecimal(dtdtl.Rows[j]["RATE"].ToString());
                            objdet.CGST = Convert.ToDecimal(dtdtl.Rows[j]["CGST"].ToString());
                            objdet.SGST = Convert.ToDecimal(dtdtl.Rows[j]["SGST"].ToString());
                            objdet.IGST = Convert.ToDecimal(dtdtl.Rows[j]["IGST"].ToString());
                            objdet.DISCOUNT = Convert.ToDecimal(dtdtl.Rows[j]["DISCOUNT"].ToString());
                            objdet.AMOUNT = Convert.ToDecimal(dtdtl.Rows[j]["AMOUNT"].ToString());
                            obinwrdsdet.Add(objdet);
                        }
                        objheader.StockInwardDetails = obinwrdsdet;
                    }

                    objlist.Add(objheader);
                    }

                    if (dtInwrdHeader.Rows.Count > 0) { objstatus.Message = dtStatus.Rows[0]["Status"].ToString(); }
                    else { objstatus.Message = "No Data availble in the given Date"; }
                    objMain.ServiceResponse = objstatus;
                    objMain.ICD_StockInwardList = objlist;
                }
                else
                {
                    objstatus.Message = dtStatus.Rows[0]["Status"].ToString();
                    objMain.ServiceResponse = objstatus;
                    objMain.ICD_StockInwardList =  null;
                }
                 

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            return objMain;
        }


        public ICDstockadjDetails GetICDstockadj_srv(ICDstockadjInputParams objparam, string constring)
        {
            ICDstockadjDetails objMain = new ICDstockadjDetails();
            ServiceStatus objstatus = new ServiceStatus();
            try
            {
                DataSet ds = ObjICDDataModel.GetICDstockadj_db(objparam, constring);
                DataTable dtStatus = new DataTable();
                DataTable dtstockadjHeader = new DataTable();
                DataTable dtstockadjpurDetail = new DataTable();
                DataTable dtstockadjsaleDetail = new DataTable();
                DataTable dtstockadjopenDetail = new DataTable();
                dtStatus = ds.Tables[0];
                if (dtStatus.Rows[0]["Status"].ToString() == "Success")
                {
                    dtstockadjHeader = ds.Tables[1];
                    dtstockadjpurDetail = ds.Tables[2];
                    dtstockadjsaleDetail = ds.Tables[3];
                    dtstockadjopenDetail = ds.Tables[4];
                    List<GetIcdstockadjList> objlist = new List<GetIcdstockadjList>();
                    for (int i = 0; i < dtstockadjHeader.Rows.Count; i++)
                    {
                        GetIcdstockadjList objheader = new GetIcdstockadjList();

                        objheader.ICD = dtstockadjHeader.Rows[i]["ICD"].ToString();
                        objheader.FPO = dtstockadjHeader.Rows[i]["FPO"].ToString();
                        objheader.Stock_Adjusrment_No = dtstockadjHeader.Rows[i]["Stock_Adjusrment_No"].ToString();
                        objheader.District = dtstockadjHeader.Rows[i]["District"].ToString();
                        objheader.DATE = dtstockadjHeader.Rows[i]["DATE"].ToString();
                        List<purchasedetails> objinvdet = new List<purchasedetails>();

                        var purdtl = (from e in dtstockadjpurDetail.AsEnumerable() where e.Field<string>("ST") == objheader.Stock_Adjusrment_No select e).ToList();

                        if (purdtl.Count > 0)
                        {
                            DataTable dtdtl = dtstockadjpurDetail.AsEnumerable().Where(r => r.Field<string>("ST") == objheader.Stock_Adjusrment_No).CopyToDataTable();

                            for (int j = 0; j < dtdtl.Rows.Count; j++)
                            {
                                purchasedetails objdet = new purchasedetails();
                                objdet.ST = dtdtl.Rows[j]["ST"].ToString();
                                objdet.Item = dtdtl.Rows[j]["Item"].ToString();
                                objdet.UOM = dtdtl.Rows[j]["UOM"].ToString();
                                objdet.grnno = dtdtl.Rows[j]["grnno"].ToString();
                                objdet.supplier_name = dtdtl.Rows[j]["supplier_name"].ToString();
                                objdet.adjust_quantity = Convert.ToDecimal(dtdtl.Rows[j]["adjust_quantity"].ToString());
                                objdet.revise_quantity = Convert.ToDecimal(dtdtl.Rows[j]["revise_quantity"].ToString());
                                objinvdet.Add(objdet);
                            }
                            objheader.purchasedetails = objinvdet;
                        }
                        else
                        {
                            objheader.purchasedetails = objinvdet;
                        }
                        List<saledetails> objsaledet = new List<saledetails>();
                        var saledtl = (from e in dtstockadjsaleDetail.AsEnumerable() where e.Field<string>("ST") == objheader.Stock_Adjusrment_No select e).ToList();

                        if (saledtl.Count > 0)
                        {
                            DataTable dtdtl = dtstockadjsaleDetail.AsEnumerable().Where(r => r.Field<string>("ST") == objheader.Stock_Adjusrment_No).CopyToDataTable();

                            for (int j = 0; j < dtdtl.Rows.Count; j++)
                            {
                                saledetails objdet = new saledetails();
                                objdet.ST = dtdtl.Rows[j]["ST"].ToString();
                                objdet.Item = dtdtl.Rows[j]["Item"].ToString();
                                objdet.UOM = dtdtl.Rows[j]["UOM"].ToString();
                                objdet.Invoiceno = dtdtl.Rows[j]["Invoiceno"].ToString();
                                objdet.Farmername = dtdtl.Rows[j]["Farmername"].ToString();
                                objdet.adjust_quantity = Convert.ToDecimal(dtdtl.Rows[j]["adjust_quantity"].ToString());
                                objdet.sales_return = Convert.ToDecimal(dtdtl.Rows[j]["sales_return"].ToString());
                                objsaledet.Add(objdet);
                            }
                            objheader.saledetails = objsaledet;
                        }
                        else
                        {
                            objheader.saledetails = objsaledet;
                        }
                        List<openingbaldetails> objopendet = new List<openingbaldetails>();
                        var opendet = (from e in dtstockadjopenDetail.AsEnumerable() where e.Field<string>("ST") == objheader.Stock_Adjusrment_No select e).ToList();

                        if (opendet.Count > 0)
                        {
                            DataTable dtdtl = dtstockadjopenDetail.AsEnumerable().Where(r => r.Field<string>("ST") == objheader.Stock_Adjusrment_No).CopyToDataTable();

                            for (int j = 0; j < dtdtl.Rows.Count; j++)
                            {
                                openingbaldetails objdet1 = new openingbaldetails();
                                objdet1.ST = dtdtl.Rows[j]["ST"].ToString();
                                objdet1.Item = dtdtl.Rows[j]["Item"].ToString();
                                objdet1.UOM = dtdtl.Rows[j]["UOM"].ToString();
                                objdet1.adjust_quantity = Convert.ToDecimal(dtdtl.Rows[j]["adjust_quantity"].ToString());
                                objopendet.Add(objdet1);
                            }
                            objheader.openingbaldetails = objopendet;
                        }
                        else
                        {
                            objheader.openingbaldetails = objopendet;
                        }
                        objlist.Add(objheader);
                    }

                    if (dtstockadjHeader.Rows.Count > 0) { objstatus.Message = dtStatus.Rows[0]["Status"].ToString(); }
                    else { objstatus.Message = "No Data availble in the given Date"; }
                    objMain.ServiceResponse = objstatus;
                    objMain.ICD_STOCKADJ = objlist;
                }
                else
                {
                    objstatus.Message = dtStatus.Rows[0]["Status"].ToString();
                    objMain.ServiceResponse = objstatus;
                    objMain.ICD_STOCKADJ = null;
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
