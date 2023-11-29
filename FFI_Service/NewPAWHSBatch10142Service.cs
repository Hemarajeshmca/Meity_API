using FFI_DataModel;
using FFI_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static FFI_Model.New_Pawhs_BatchCreation_Model;

namespace FFI_Service
{
    public class NewPAWHSBatch10142Service
    {
        NewPAWHSBatch10142_DataModel objDataModel = new NewPAWHSBatch10142_DataModel();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(NewPAWHSBatch10142Service)); //Declaring Log4Net.     
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        public FetchBatchListNew BatchCreation_List(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue, string ConString)
        {
            FetchBatchListNew ObjFectList = new FetchBatchListNew();
            List<FetchBatchListNewPAWHS> objSaveHeader = new List<FetchBatchListNewPAWHS>();
            try
            {
                DataTable dt = objDataModel.BatchCreation_List(org, locn, user, lang, filterby_option, filterby_code, filterby_fromvalue, filterby_tovalue, ConString);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FetchBatchListNewPAWHS objList = new FetchBatchListNewPAWHS();
                    objList.Out_batch_rowid = Convert.ToInt32(dt.Rows[i]["Out_batch_rowid"]);
                    objList.Out_batch_no = dt.Rows[i]["Out_batch_no"].ToString();
                    objList.Out_batch_date = dt.Rows[i]["Out_batch_date"].ToString();
                    objList.Out_buyer_name = dt.Rows[i]["Out_buyer_name"].ToString();
                    objList.Out_Vehicle_no = dt.Rows[i]["Out_Vehicle_no"].ToString();
                    //objList.In_no_of_bags = Convert.ToInt32(dt.Rows[i]["In_no_of_bags"]);
                    objSaveHeader.Add(objList);
                }
                ObjFectList.BatchList = objSaveHeader;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //logger.Error(ex);
            }
            return ObjFectList;
        }

        public BatchCreationSingleFetch FectNewPAWHSBatchCreation(string org, string locn, string user, string lang, int batch_rowid, string batch_no, string ConString)
        {
            BatchCreationSingleFetch ObjBatchFetch = new BatchCreationSingleFetch();
            ObjBatchFetch.orgnId = org;
            ObjBatchFetch.userId = user;
            ObjBatchFetch.localeId = lang;
            ObjBatchFetch.locnId = locn;
            try
            {
                DataSet ds = objDataModel.FectNewPAWHSBatchCreation(org, locn, user, lang, batch_rowid, batch_no, ConString);
                DataTable dtBatch = ds.Tables[0];
                DataTable dtBatchDtls = ds.Tables[1];
                DataTable dtOtherDtls = ds.Tables[2];
                DataTable dtPODetails = ds.Tables[3];
                DataTable dtPOTax = ds.Tables[4];
                DataTable dtAttachment = ds.Tables[5];

                PAWHSNewBatchCreation_Save_Header objHeader = new PAWHSNewBatchCreation_Save_Header();
                objHeader.In_batch_rowid = Convert.ToInt32(dtBatch.Rows[0]["In_batch_rowid"].ToString());
                objHeader.In_batch_no = dtBatch.Rows[0]["In_batch_no"].ToString();
                objHeader.In_buyer_code = dtBatch.Rows[0]["In_buyer_code"].ToString();
                objHeader.In_buyer_name = dtBatch.Rows[0]["In_buyer_name"].ToString();
                objHeader.In_remarks = dtBatch.Rows[0]["In_remarks"].ToString();
                objHeader.In_po_no = dtBatch.Rows[0]["In_po_no"].ToString();
                objHeader.In_Vehicle_no = dtBatch.Rows[0]["In_vehicle_no"].ToString();
                objHeader.In_mode_flag = dtBatch.Rows[0]["In_mode_flag"].ToString();

                ObjBatchFetch.Header = objHeader;

                List<BatchDetails> objFetchBatchDtls = new List<BatchDetails>();
                for (int i = 0; i < dtBatchDtls.Rows.Count; i++)
                {
                    BatchDetails objFetch = new BatchDetails();
                    objFetch.In_act_row_id = Convert.ToInt32(dtBatchDtls.Rows[i]["In_act_row_id"].ToString());
                    objFetch.In_orgn_code = dtBatchDtls.Rows[i]["In_orgn_code"].ToString();
                    objFetch.In_agg_code = dtBatchDtls.Rows[i]["In_agg_code"].ToString();
                    objFetch.In_product_type = dtBatchDtls.Rows[i]["In_product_type"].ToString();
                    objFetch.In_lot_type = dtBatchDtls.Rows[i]["In_lot_type"].ToString();
                    objFetch.In_farmer_code = dtBatchDtls.Rows[i]["In_farmer_code"].ToString();
                    objFetch.In_farmer_name = dtBatchDtls.Rows[i]["In_farmer_name"].ToString();
                    objFetch.In_item_code = dtBatchDtls.Rows[i]["In_item_code"].ToString();
                    objFetch.In_item_name = dtBatchDtls.Rows[i]["In_item_name"].ToString();
                    objFetch.In_actual_qty = Convert.ToDecimal(dtBatchDtls.Rows[i]["In_actual_qty"].ToString());
                    objFetch.In_actual_price = Convert.ToDouble(dtBatchDtls.Rows[i]["In_actual_price"].ToString());
                    objFetch.In_actual_value = Convert.ToDouble(dtBatchDtls.Rows[i]["In_actual_value"].ToString());
                    objFetch.In_advance_amt = Convert.ToDouble(dtBatchDtls.Rows[i]["In_advance_amt"].ToString());
                    objFetch.In_no_of_bags = Convert.ToInt32(dtBatchDtls.Rows[i]["In_no_of_bags"].ToString());
                    objFetch.In_mode_flag = dtBatchDtls.Rows[i]["In_mode_flag"].ToString();
                    objFetchBatchDtls.Add(objFetch);
                }
                ObjBatchFetch.Batch = objFetchBatchDtls;

                List<BatchOtherDetails> objFetchBatchOtherDtls = new List<BatchOtherDetails>();
                for (int i = 0; i < dtOtherDtls.Rows.Count; i++)
                {
                    BatchOtherDetails objFetch = new BatchOtherDetails();
                    objFetch.In_othercost_rowid = Convert.ToInt32(dtOtherDtls.Rows[i]["In_othercost_rowid"].ToString());
                    objFetch.In_cost_type = dtOtherDtls.Rows[i]["In_cost_type"].ToString();
                    objFetch.In_cost_name = dtOtherDtls.Rows[i]["In_cost_name"].ToString();
                    objFetch.In_cost_value = Convert.ToInt32(dtOtherDtls.Rows[i]["In_cost_value"].ToString());
                    objFetch.In_mode_flag = dtOtherDtls.Rows[i]["In_mode_flag"].ToString();
                    objFetchBatchOtherDtls.Add(objFetch);
                }
                ObjBatchFetch.OtherDtl = objFetchBatchOtherDtls;

                List<BatchProductDetails> objFetchBatchInvoiceDtls = new List<BatchProductDetails>();
                for (int i = 0; i < dtPODetails.Rows.Count; i++)
                {
                    BatchProductDetails objFetch = new BatchProductDetails();
                    objFetch.In_podtl_rowid = Convert.ToInt32(dtPODetails.Rows[i]["In_podtl_rowid"].ToString());
                    objFetch.In_sln_no = Convert.ToInt32(dtPODetails.Rows[i]["In_sln_no"].ToString());
                    objFetch.In_po_no = dtPODetails.Rows[i]["In_po_no"].ToString();
                    objFetch.In_item_code = dtPODetails.Rows[i]["In_item_code"].ToString();
                    objFetch.In_item_name = dtPODetails.Rows[i]["In_item_name"].ToString();
                    objFetch.In_hsn_desc = dtPODetails.Rows[i]["In_hsn_desc"].ToString();
                    objFetch.In_hsn_code = dtPODetails.Rows[i]["In_hsn_code"].ToString();
                    objFetch.In_qty = dtPODetails.Rows[i]["In_qty"].ToString();
                    objFetch.In_rate = dtPODetails.Rows[i]["In_rate"].ToString();
                    objFetch.In_tax_rate = dtPODetails.Rows[i]["In_tax_rate"].ToString();
                    objFetch.In_product_amount = dtPODetails.Rows[i]["In_product_amount"].ToString();
                    objFetch.In_discount = dtPODetails.Rows[i]["In_discount"].ToString();
                    objFetch.In_othercharges = Convert.ToDouble(dtPODetails.Rows[i]["In_othercharges"].ToString());
                    objFetch.In_tax = dtPODetails.Rows[i]["In_tax"].ToString();
                    objFetch.In_gross_amount = Convert.ToDouble(dtPODetails.Rows[i]["In_gross_amount"].ToString());
                    objFetch.In_mode_flag = dtPODetails.Rows[i]["In_mode_flag"].ToString();
                    objFetchBatchInvoiceDtls.Add(objFetch);
                }
                ObjBatchFetch.Invoice = objFetchBatchInvoiceDtls;

                //List<BatchProductTaxDetails> objFetchBatchOTaxDtls = new List<BatchProductTaxDetails>();
                //for (int i = 0; i < dtBatchDtls.Rows.Count; i++)
                //{
                //    BatchProductTaxDetails objFetch = new BatchProductTaxDetails();
                //    objFetch.In_potax_rowid = Convert.ToInt32(dtPOTax.Rows[0]["In_potax_rowid"].ToString());
                //    //objFetch.In_po_no = dtPOTax.Rows[0]["In_po_no"].ToString();
                //    objFetch.In_product_code = dtPOTax.Rows[0]["In_product_code"].ToString();
                //    objFetch.In_product_name = dtPOTax.Rows[0]["In_product_name"].ToString();
                //    objFetch.In_hsn_code = dtPOTax.Rows[0]["In_hsn_code"].ToString();
                //    objFetch.In_hsn_code_desc = dtPOTax.Rows[0]["In_hsn_code_desc"].ToString();
                //    objFetch.In_hsn_desc = dtPOTax.Rows[0]["In_hsn_desc"].ToString();
                //    objFetch.In_cgst_rate = dtPOTax.Rows[0]["In_cgst_rate"].ToString();
                //    objFetch.In_sgst_rate = dtPOTax.Rows[0]["In_sgst_rate"].ToString();
                //    objFetch.In_sugst_rate = dtPOTax.Rows[0]["In_sugst_rate"].ToString();
                //    objFetch.In_sugst_rate = dtPOTax.Rows[0]["In_sugst_rate"].ToString();
                //    objFetch.In_sugst_rate = dtPOTax.Rows[0]["In_sugst_rate"].ToString();
                //    objFetch.In_igst_rate = dtPOTax.Rows[0]["In_igst_rate"].ToString();
                //    objFetch.In_tax_rate = dtPOTax.Rows[0]["In_tax_rate"].ToString();
                //    objFetch.In_taxable_amount = dtPOTax.Rows[0]["In_taxable_amount"].ToString();
                //    objFetch.In_tax_amount = dtPOTax.Rows[0]["In_tax_amount"].ToString();
                //    objFetch.In_status_code = dtPOTax.Rows[0]["In_status_code"].ToString();
                //    objFetch.In_mode_flag = dtPOTax.Rows[0]["In_mode_flag"].ToString();
                //    objFetchBatchOTaxDtls.Add(objFetch);
                //}
                //ObjBatchFetch.Tax = objFetchBatchOTaxDtls;

                List<BatchAttachments> objFetchBatchAttachDtls = new List<BatchAttachments>();
                for (int i = 0; i < dtBatchDtls.Rows.Count; i++)
                {
                    BatchAttachments objFetch = new BatchAttachments();
                    objFetch.In_attch_rowid = Convert.ToInt32(dtAttachment.Rows[i]["In_attch_rowid"].ToString());
                    objFetch.In_filename = dtAttachment.Rows[i]["In_filename"].ToString();
                    objFetch.In_document = dtAttachment.Rows[i]["In_document"].ToString();
                    objFetch.In_description = dtAttachment.Rows[i]["In_description"].ToString();
                    objFetch.In_attch_date = dtAttachment.Rows[i]["In_attch_date"].ToString();
                    objFetch.In_attch_upload = dtAttachment.Rows[i]["In_attch_upload"].ToString();
                    objFetch.In_attch_unique_id = dtAttachment.Rows[i]["In_attch_unique_id"].ToString();
                    objFetch.In_mode_flag = dtAttachment.Rows[i]["In_mode_flag"].ToString();
                    objFetchBatchAttachDtls.Add(objFetch);
                }
                ObjBatchFetch.Attachment = objFetchBatchAttachDtls;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjBatchFetch;
        }

        public BatchDetailsBasedOnDest BatchDetailsBasedonDestination(string org, string locn, string user, string lang, string destination, string locn_code, string ConString)
        {
            BatchDetailsBasedOnDest objBatchDtlsBasednDest = new BatchDetailsBasedOnDest();
            try
            {
                DataSet ds = objDataModel.BatchDetailsBasedonDestination(org, locn, user, lang, destination, locn_code, ConString);
                DataTable dtBatch = ds.Tables[0];
                DataTable dtProduct = ds.Tables[1];
                DataTable dtTax = ds.Tables[2];
                List<BatchDetails> objBatchdtls = new List<BatchDetails>();
                for (int i = 0; i < dtBatch.Rows.Count; i++)
                {
                    BatchDetails objBatch = new BatchDetails();
                    objBatch.In_act_row_id = Convert.ToInt32(dtBatch.Rows[i]["In_act_row_id"].ToString());
                    objBatch.In_orgn_code = dtBatch.Rows[i]["In_orgn_code"].ToString();
                    objBatch.In_agg_code = dtBatch.Rows[i]["In_agg_code"].ToString();
                    objBatch.In_product_type = dtBatch.Rows[i]["In_product_type"].ToString();
                    objBatch.In_lot_type = dtBatch.Rows[i]["In_lot_type"].ToString();
                    objBatch.In_farmer_code = dtBatch.Rows[i]["In_farmer_code"].ToString();
                    objBatch.In_farmer_name = dtBatch.Rows[i]["In_farmer_name"].ToString();
                    objBatch.In_item_code = dtBatch.Rows[i]["In_item_code"].ToString();
                    objBatch.In_item_name = dtBatch.Rows[i]["In_item_name"].ToString();
                    objBatch.In_actual_qty = Convert.ToDecimal(dtBatch.Rows[i]["In_actual_qty"].ToString());
                    objBatch.In_actual_price = Convert.ToDouble(dtBatch.Rows[i]["In_actual_price"].ToString());
                    objBatch.In_actual_value = Convert.ToDouble(dtBatch.Rows[i]["In_actual_value"].ToString());
                    objBatch.In_advance_amt = Convert.ToDouble(dtBatch.Rows[i]["In_advance_amt"].ToString());
                    objBatch.In_no_of_bags = Convert.ToInt32(dtBatch.Rows[i]["In_no_of_bags"].ToString());
                    objBatch.In_hsn_code = dtBatch.Rows[i]["In_hsn_code"].ToString();
                    objBatch.In_hsn_desc = dtBatch.Rows[i]["In_hsn_desc"].ToString();
                    objBatch.tax_rate = Convert.ToDouble(dtBatch.Rows[i]["tax_rate"].ToString());
                    objBatchdtls.Add(objBatch);
                }
                objBatchDtlsBasednDest.BatchDetails = objBatchdtls;

                List<BatchProductDetails> objBatchProductdtls = new List<BatchProductDetails>();
                for (int i = 0; i < dtBatch.Rows.Count; i++)
                {
                    BatchProductDetails objProduct = new BatchProductDetails();
                    objProduct.In_podtl_rowid = Convert.ToInt32(dtProduct.Rows[i]["In_podtl_rowid"].ToString());
                    objProduct.In_sln_no = Convert.ToInt32(dtProduct.Rows[i]["In_sln_no"].ToString());
                    objProduct.In_item_code = dtProduct.Rows[i]["In_item_code"].ToString();
                    objProduct.In_item_name = dtProduct.Rows[i]["In_item_name"].ToString();
                    objProduct.In_product_Variety = dtProduct.Rows[i]["In_product_Variety"].ToString();
                    objProduct.In_hsn_code = dtProduct.Rows[i]["In_hsn_code"].ToString();
                    objProduct.In_qty = dtProduct.Rows[i]["In_qty"].ToString();
                    objProduct.In_rate = dtProduct.Rows[i]["In_rate"].ToString();
                    objProduct.In_tax_rate = dtProduct.Rows[i]["In_tax_rate"].ToString();
                    objProduct.In_product_amount = dtProduct.Rows[i]["In_product_amount"].ToString();
                    objProduct.In_discount = dtProduct.Rows[i]["In_discount"].ToString();
                    objProduct.In_othercharges = Convert.ToDouble(dtProduct.Rows[i]["In_othercharges"].ToString());
                    objProduct.In_tax = dtProduct.Rows[i]["In_tax"].ToString();
                    objProduct.In_gross_amount = Convert.ToDouble(dtProduct.Rows[i]["In_gross_amount"].ToString());
                    objProduct.In_remarks = dtProduct.Rows[i]["In_remarks"].ToString();
                    objProduct.In_ShipDetail = dtProduct.Rows[i]["In_ShipDetail"].ToString();
                    objProduct.In_unique_id = dtProduct.Rows[i]["In_unique_id"].ToString();
                    objProduct.In_cgst_rate = dtProduct.Rows[i]["In_cgst_rate"].ToString();
                    objProduct.In_sgst_rate = dtProduct.Rows[i]["In_sgst_rate"].ToString();
                    objProduct.In_igst_rate = dtProduct.Rows[i]["In_igst_rate"].ToString();
                    objProduct.In_product_code = dtProduct.Rows[i]["In_product_code"].ToString();
                    objProduct.In_mode_flag = dtProduct.Rows[i]["In_mode_flag"].ToString();
                    objBatchProductdtls.Add(objProduct);
                }
                objBatchDtlsBasednDest.ProductDetails = objBatchProductdtls;

                List<BatchProductTaxDetails> objBatchTaxdtls = new List<BatchProductTaxDetails>();
                for (int i = 0; i < dtBatch.Rows.Count; i++)
                {
                    BatchProductTaxDetails objtax = new BatchProductTaxDetails();
                    objtax.In_product_code = dtTax.Rows[i]["In_product_code"].ToString();
                    objtax.In_product_name = dtTax.Rows[i]["In_product_name"].ToString();
                    objtax.In_hsn_code = dtTax.Rows[i]["In_hsn_code"].ToString();
                    objtax.In_hsn_code_desc = dtTax.Rows[i]["In_hsn_code_desc"].ToString();
                    //objtax.In_hsn_desc = dtTax.Rows[i]["In_hsn_desc"].ToString();
                    objtax.In_cgst_rate = dtTax.Rows[i]["In_cgst_rate"].ToString();
                    objtax.In_sgst_rate = dtTax.Rows[i]["In_sgst_rate"].ToString();
                    objtax.In_sugst_rate = dtTax.Rows[i]["In_sugst_rate"].ToString();
                    objtax.In_igst_rate = dtTax.Rows[i]["In_igst_rate"].ToString();
                    objtax.In_tax_rate = dtTax.Rows[i]["In_tax_rate"].ToString();
                    objtax.In_taxable_amount = dtTax.Rows[i]["In_taxable_amount"].ToString();
                    objtax.In_tax_amount = dtTax.Rows[i]["In_tax_amount"].ToString();
                    objtax.In_mode_flag = dtTax.Rows[i]["In_mode_flag"].ToString();
                    objBatchTaxdtls.Add(objtax);
                }
                objBatchDtlsBasednDest.ProductTaxDetails = objBatchTaxdtls;
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
            }
            return objBatchDtlsBasednDest;
        }

        public PAWHSNewBatchCreation_Save_Context SaveBatchDetailsBasedonDestination(PAWHSNewBatchCreation_Save_Context objContext, string ConString)
        {
            try
            {
                PAWHSNewBatchCreation_Save_Header objHeader = objContext.Header;
                //string batch_no = objDataModel.SaveBatchCreationHeder(objContext.orgnId, objContext.locnId, objContext.userId, objContext.localeId, objHeader, ConString);
                string batch_no = objDataModel.SaveBatchCreationHeder(objContext, ConString);
                if (batch_no != "")
                {
                    objContext.Header.In_batch_no = batch_no;
                }
            }
            catch (Exception ex)
            {

            }
            return objContext;
        }

        public FetchPODetails FetchPODetails(string org, string locn, string user, string lang, string po_no, string ConString)
        {
            FetchPODetails objBatch = new FetchPODetails();
            //dynamic connection string
            List<BatchProductDetails> objPODtls = new List<BatchProductDetails>();
            List<BatchProductTaxDetails> objPOTaxDtls = new List<BatchProductTaxDetails>();
            try
            {
                DataSet ds = objDataModel.FetchPODetails(org, locn, user, lang, po_no, ConString);
                if (ds.Tables.Count > 1)
                {
                    DataTable dtPO = ds.Tables[0];
                    DataTable dtPOTax = ds.Tables[1];
                    for (int i = 0; i < dtPO.Rows.Count; i++)
                    {
                        BatchProductDetails objPO = new BatchProductDetails();
                        objPO.In_podtl_rowid = Convert.ToInt32(dtPO.Rows[i]["In_podtl_rowid"].ToString());
                        objPO.In_sln_no = Convert.ToInt32(dtPO.Rows[i]["In_sln_no"].ToString());
                        objPO.In_item_code = dtPO.Rows[i]["In_item_code"].ToString();
                        objPO.In_item_name = dtPO.Rows[i]["In_item_name"].ToString();
                        objPO.In_hsn_code = dtPO.Rows[i]["In_hsn_code"].ToString();
                        objPO.In_hsn_desc = dtPO.Rows[i]["In_hsn_desc"].ToString();
                        objPO.In_qty = dtPO.Rows[i]["In_qty"].ToString();
                        objPO.In_rate = dtPO.Rows[i]["In_rate"].ToString();
                        objPO.In_tax_rate = dtPO.Rows[i]["In_tax_rate"].ToString();
                        objPO.In_tax = dtPO.Rows[i]["In_tax"].ToString();
                        objPO.In_product_amount = dtPO.Rows[i]["In_product_amount"].ToString();
                        objPO.In_discount = dtPO.Rows[i]["In_discount"].ToString();
                        objPO.In_othercharges = Convert.ToDouble(dtPO.Rows[i]["In_othercharges"].ToString());
                        objPO.In_gross_amount = Convert.ToDouble(dtPO.Rows[i]["In_gross_amount"].ToString());
                        objPODtls.Add(objPO);
                    }
                    objBatch.PODetails = objPODtls;

                    for (int i = 0; i < dtPOTax.Rows.Count; i++)
                    {
                        BatchProductTaxDetails objPOTax = new BatchProductTaxDetails();
                        objPOTax.In_product_code = dtPOTax.Rows[i]["In_product_code"].ToString();
                        objPOTax.In_product_name = dtPOTax.Rows[i]["In_product_name"].ToString();
                        objPOTax.In_hsn_code = dtPOTax.Rows[i]["In_hsn_code"].ToString();
                        objPOTax.In_hsn_code_desc = dtPOTax.Rows[i]["In_hsn_code_desc"].ToString();
                        objPOTax.In_hsn_desc = dtPOTax.Rows[i]["In_hsn_desc"].ToString();
                        objPOTax.In_cgst_rate = dtPOTax.Rows[i]["In_cgst_rate"].ToString();
                        objPOTax.In_sgst_rate = dtPOTax.Rows[i]["In_sgst_rate"].ToString();
                        objPOTax.In_igst_rate = dtPOTax.Rows[i]["In_igst_rate"].ToString();
                        objPOTax.In_sugst_rate = dtPOTax.Rows[i]["In_sugst_rate"].ToString();
                        objPOTax.In_tax_rate = dtPOTax.Rows[i]["In_tax_rate"].ToString();
                        objPOTax.In_taxable_amount = dtPOTax.Rows[i]["In_taxable_amount"].ToString();
                        objPOTax.In_tax_amount = dtPOTax.Rows[i]["In_tax_amount"].ToString();
                        objPOTaxDtls.Add(objPOTax);
                    }
                    objBatch.POTaxDetails = objPOTaxDtls;
                    LogHelper.ConvertObjIntoString(objBatch, "Output");
                }
            }
            catch (Exception ex)
            {

            }
            return objBatch;
        }

        public DataTable GetPOBasedOnBuyer(string org, string locn, string user, string lang, string buyer_code, string ConString)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = objDataModel.GetPOBasedOnBuyer(org, locn, user, lang, buyer_code, ConString);
            }
            catch (Exception ex)
            {
            }
            return dt;
        }
    }
}
