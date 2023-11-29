using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
    public class PAWHSRaiseInvoice_DB
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSRaiseInvoice_DB)); //Declaring Log4Net. 
        public PAWHSRaiseInvoiceApplication Getallraise_invoice_DB(PAWHSRaiseInvoiceContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();

            PAWHSRaiseInvoiceApplication objinvoiceRoot = new PAWHSRaiseInvoiceApplication();
            PAWHSRaiseInvoice_DB objDataModel = new PAWHSRaiseInvoice_DB();

            objinvoiceRoot.context = new PAWHSRaiseInvoiceContext();
            objinvoiceRoot.context.List = new List<PAWHSRaiseInvoiceList>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_raise_invoice_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
                cmd.Parameters.Add("in_filterby_option", MySqlDbType.VarChar).Value = objinvoice.Filter.FilterBy_Option;
                cmd.Parameters.Add("in_filterby_code", MySqlDbType.VarChar).Value = objinvoice.Filter.FilterBy_Code;
                cmd.Parameters.Add("in_filterby_fromvalue", MySqlDbType.VarChar).Value = objinvoice.Filter.FilterBy_FromValue;
                cmd.Parameters.Add("in_filterby_tovalue", MySqlDbType.VarChar).Value = objinvoice.Filter.FilterBy_ToValue;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PAWHSRaiseInvoiceList objList = new PAWHSRaiseInvoiceList();
                    objList.Out_raise_invoce_rowid = Convert.ToInt32(dt.Rows[i]["Out_raise_invoce_rowid"]);
                    objList.Out_invoice_no = dt.Rows[i]["Out_invoice_no"].ToString();
                    objList.Out_invoice_date = dt.Rows[i]["Out_invoice_date"].ToString();
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.Out_status_desc = dt.Rows[i]["Out_status_desc"].ToString();
                    objinvoiceRoot.context.List.Add(objList);

                }
                objinvoiceRoot.context.orgnId = objinvoice.orgnId;
                objinvoiceRoot.context.locnId = objinvoice.locnId;
                objinvoiceRoot.context.localeId = objinvoice.localeId;
                objinvoiceRoot.context.userId = objinvoice.userId;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }
        public PAWHSRaiseInvoiceFApplication Getraise_invoice_DB(PAWHSRaiseInvoiceFContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();

            MysqlCon = new DataConnection(mysqlcon);

            PAWHSRaiseInvoiceFApplication ObjinvRoot = new PAWHSRaiseInvoiceFApplication();
            PAWHSRaiseInvoice_DB objDataModel = new PAWHSRaiseInvoice_DB();

            DataTable InvoiceDetail = new DataTable();
            DataTable InvoiceTax = new DataTable();
            DataTable PaymentCollection = new DataTable();
            DataTable Header = new DataTable();

            ObjinvRoot.context = new PAWHSRaiseInvoiceFContext();
            ObjinvRoot.context.Header = new PAWHSRaiseInvoiceFHeader();
            ObjinvRoot.context.Header.InvoiceDetails = new List<PAWHSRaiseInvoiceFInvoiceDetails>();
            ObjinvRoot.context.Header.TaxDetails = new List<PAWHSRaiseInvoiceFTaxDetails>();
            
            try
            {

                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_raise_invoice", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("IOU_invoice_rowid", MySqlDbType.Int32).Value = ObjContext.IOU_invoice_rowid;

                cmd.Parameters.Add(new MySqlParameter("In_fpo_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_invoice_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_invoice_no", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_customer_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_customer_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_customer_state", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_provider_state", MySqlDbType.LongText)).Direction = ParameterDirection.Output;                
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_invoice_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();

                if (ds.Tables.Count > 0)
                {
                    InvoiceDetail = ds.Tables[0];
                    InvoiceTax = ds.Tables[1];
                    PaymentCollection = ds.Tables[2];


                    for (int i = 0; i < InvoiceDetail.Rows.Count; i++)
                    {
                        PAWHSRaiseInvoiceFInvoiceDetails objInvList = new PAWHSRaiseInvoiceFInvoiceDetails();
                        objInvList.In_invoice_details_rowid = Convert.ToInt32(InvoiceDetail.Rows[i]["In_invoice_details_rowid"]);
                        objInvList.In_item_code = InvoiceDetail.Rows[i]["In_item_code"].ToString();
                        objInvList.In_item_desc = InvoiceDetail.Rows[i]["In_item_desc"].ToString();
                        objInvList.In_item_name = InvoiceDetail.Rows[i]["In_item_name"].ToString();
                        objInvList.In_type = InvoiceDetail.Rows[i]["In_type"].ToString();
                        objInvList.In_qty = Convert.ToDouble(InvoiceDetail.Rows[i]["In_qty"]);
                        objInvList.In_uom_code = InvoiceDetail.Rows[i]["In_uom_code"].ToString();
                        objInvList.In_uom_desc = InvoiceDetail.Rows[i]["In_uom_desc"].ToString();
                        objInvList.In_rate = Convert.ToDouble(InvoiceDetail.Rows[i]["In_rate"]);
                        objInvList.In_amount = Convert.ToDouble(InvoiceDetail.Rows[i]["In_amount"]);                        
                        objInvList.In_discount = Convert.ToDouble(InvoiceDetail.Rows[i]["In_discount"]);
                        objInvList.In_tax_amount = Convert.ToDouble(InvoiceDetail.Rows[i]["In_tax_amount"]);
                        objInvList.In_net_amount = Convert.ToDouble(InvoiceDetail.Rows[i]["In_net_amount"]);                        
                        objInvList.In_status_code = InvoiceDetail.Rows[i]["In_status_code"].ToString();
                        objInvList.In_status_desc = InvoiceDetail.Rows[i]["In_status_desc"].ToString();
                        objInvList.In_mode_flag = InvoiceDetail.Rows[i]["In_mode_flag"].ToString();
                        ObjinvRoot.context.Header.InvoiceDetails.Add(objInvList);
                    }
                    for (int i = 0; i < InvoiceTax.Rows.Count; i++)
                    {
                        PAWHSRaiseInvoiceFTaxDetails objInvtaxList = new PAWHSRaiseInvoiceFTaxDetails();
                        objInvtaxList.In_taxdetails_rowid = Convert.ToInt32(InvoiceTax.Rows[i]["In_taxdetails_rowid"]);
                        objInvtaxList.In_state = InvoiceTax.Rows[i]["In_state"].ToString();
                        objInvtaxList.In_hsn_code = InvoiceTax.Rows[i]["In_hsn_code"].ToString();
                        objInvtaxList.In_hsn_desc = InvoiceTax.Rows[i]["In_hsn_desc"].ToString();
                        objInvtaxList.In_tax_rate = Convert.ToDouble(InvoiceTax.Rows[i]["In_tax_rate"]);
                        objInvtaxList.In_taxable_amount = Convert.ToDouble(InvoiceTax.Rows[i]["In_taxable_amount"]);
                        objInvtaxList.In_tax_amount = Convert.ToDouble(InvoiceTax.Rows[i]["In_tax_amount"]);
                        objInvtaxList.In_cgst_rate = Convert.ToDouble(InvoiceTax.Rows[i]["In_cgst_rate"]);
                        objInvtaxList.In_sgst_rate = Convert.ToDouble(InvoiceTax.Rows[i]["In_sgst_rate"]);
                        objInvtaxList.In_igst_rate = Convert.ToDouble(InvoiceTax.Rows[i]["In_igst_rate"]);
                        objInvtaxList.In_status_code = InvoiceTax.Rows[i]["In_status_code"].ToString();
                        objInvtaxList.In_status_desc = InvoiceTax.Rows[i]["In_status_desc"].ToString();
                        objInvtaxList.In_mode_flag = InvoiceTax.Rows[i]["In_mode_flag"].ToString();


                        ObjinvRoot.context.Header.TaxDetails.Add(objInvtaxList);
                    }                    
                }
                ObjinvRoot.context.orgnId = ObjContext.orgnId;
                ObjinvRoot.context.locnId = ObjContext.locnId;
                ObjinvRoot.context.userId = ObjContext.userId;
                ObjinvRoot.context.localeId = ObjContext.localeId;

                ObjinvRoot.context.Header.IOU_invoice_rowid = (Int32)cmd.Parameters["IOU_invoice_rowid"].Value;
                ObjinvRoot.context.Header.In_fpo_name = (string)cmd.Parameters["In_fpo_name"].Value.ToString();
                ObjinvRoot.context.Header.In_invoice_date = (string)cmd.Parameters["In_invoice_date"].Value.ToString();
                ObjinvRoot.context.Header.In_invoice_no = (string)cmd.Parameters["In_invoice_no"].Value.ToString();
                ObjinvRoot.context.Header.In_customer_code = (string)cmd.Parameters["In_customer_code"].Value.ToString();
                ObjinvRoot.context.Header.In_customer_name = (string)cmd.Parameters["In_customer_name"].Value.ToString();
                ObjinvRoot.context.Header.In_customer_state = (string)cmd.Parameters["In_customer_state"].Value.ToString();
                ObjinvRoot.context.Header.In_provider_state = (string)cmd.Parameters["In_provider_state"].Value.ToString();               
                ObjinvRoot.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                ObjinvRoot.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                ObjinvRoot.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                ObjinvRoot.context.Header.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();
                           
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjinvRoot;
        }
        public PAWHSRaiseInvoiceProductApplication Getproductsearch_DB(PAWHSRaiseInvoiceProductContext objproductSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();

            PAWHSRaiseInvoiceProductApplication objproductSearchRoot = new PAWHSRaiseInvoiceProductApplication();
            PAWHSRaiseInvoice_DB objDataModel = new PAWHSRaiseInvoice_DB();

            DataTable Detail = new DataTable();
            DataTable InvoiceTax = new DataTable();

            objproductSearchRoot.context = new PAWHSRaiseInvoiceProductContext();
            objproductSearchRoot.context.Detail = new List<PAWHSRaiseInvoiceProductDetail>();
            objproductSearchRoot.context.InvoiceTax = new List<PAWHSRaiseInvoiceInvoiceTax>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("ICDMOB_fetch_product_search", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objproductSearch.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objproductSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objproductSearch.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objproductSearch.localeId;
                cmd.Parameters.Add("in_filterby_option", MySqlDbType.VarChar).Value = objproductSearch.Filter.FilterBy_Option;
                cmd.Parameters.Add("in_filterby_code", MySqlDbType.VarChar).Value = objproductSearch.Filter.FilterBy_Code;
                cmd.Parameters.Add("in_filterby_fromvalue", MySqlDbType.VarChar).Value = objproductSearch.Filter.FilterBy_FromValue;
                cmd.Parameters.Add("in_filterby_tovalue", MySqlDbType.VarChar).Value = objproductSearch.Filter.FilterBy_ToValue;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();

                if (ds.Tables.Count > 0)
                {
                    Detail = ds.Tables[0];
                    InvoiceTax = ds.Tables[1];


                    for (int i = 0; i < Detail.Rows.Count; i++)
                    {
                        PAWHSRaiseInvoiceProductDetail objDetailList = new PAWHSRaiseInvoiceProductDetail();
                        objDetailList.In_ic_code = Detail.Rows[i]["In_ic_code"].ToString();
                        objDetailList.In_productcategory = Detail.Rows[i]["In_productcategory"].ToString();
                        objDetailList.In_productcategory_desc = Detail.Rows[i]["In_productcategory_desc"].ToString();
                        objDetailList.In_productsubcategory = Detail.Rows[i]["In_productsubcategory"].ToString();
                        objDetailList.In_productsubcategory_desc = Detail.Rows[i]["In_productsubcategory_desc"].ToString();
                        objDetailList.In_product_code = Detail.Rows[i]["In_product_code"].ToString();
                        objDetailList.In_product_name = Detail.Rows[i]["In_product_name"].ToString();
                        objDetailList.In_uomtype_code = Detail.Rows[i]["In_uomtype_code"].ToString();
                        objDetailList.In_uomtype_code_desc = Detail.Rows[i]["In_uomtype_code_desc"].ToString();
                        objDetailList.In_base_price = Convert.ToDouble(Detail.Rows[i]["In_base_price"]);
                        objDetailList.In_current_qty = Convert.ToDouble(Detail.Rows[i]["In_current_qty"]);


                        objproductSearchRoot.context.Detail.Add(objDetailList);
                    }
                    for (int i = 0; i < InvoiceTax.Rows.Count; i++)
                    {
                        PAWHSRaiseInvoiceInvoiceTax objPInvoiceTaxList = new PAWHSRaiseInvoiceInvoiceTax();
                        objPInvoiceTaxList.In_invoicetax_rowid = Convert.ToInt32(InvoiceTax.Rows[i]["In_invoicetax_rowid"]);
                        objPInvoiceTaxList.In_invoice_no = InvoiceTax.Rows[i]["In_invoice_no"].ToString();
                        objPInvoiceTaxList.In_product_code = InvoiceTax.Rows[i]["In_product_code"].ToString();
                        objPInvoiceTaxList.In_product_name = InvoiceTax.Rows[i]["In_product_name"].ToString();
                        objPInvoiceTaxList.In_hsn_code = InvoiceTax.Rows[i]["In_hsn_code"].ToString();
                        objPInvoiceTaxList.In_hsn_desc = InvoiceTax.Rows[i]["In_hsn_desc"].ToString();
                        objPInvoiceTaxList.In_cgst_rate = Convert.ToDouble(InvoiceTax.Rows[i]["In_cgst_rate"]);
                        objPInvoiceTaxList.In_sgst_rate = Convert.ToDouble(InvoiceTax.Rows[i]["In_sgst_rate"]);
                        objPInvoiceTaxList.In_igst_rate = Convert.ToDouble(InvoiceTax.Rows[i]["In_igst_rate"]);
                        objPInvoiceTaxList.In_ugst_rate = Convert.ToDouble(InvoiceTax.Rows[i]["In_ugst_rate"]);
                        objPInvoiceTaxList.In_tax_type = InvoiceTax.Rows[i]["In_tax_type"].ToString();
                        objPInvoiceTaxList.In_tax_rate = Convert.ToDouble(InvoiceTax.Rows[i]["In_tax_rate"]);
                        objPInvoiceTaxList.In_taxable_amount = Convert.ToDouble(InvoiceTax.Rows[i]["In_taxable_amount"]);
                        objPInvoiceTaxList.In_tax_amount = Convert.ToDouble(InvoiceTax.Rows[i]["In_tax_amount"]);
                        objPInvoiceTaxList.In_status_code = InvoiceTax.Rows[i]["In_status_code"].ToString();
                        objPInvoiceTaxList.In_status_desc = InvoiceTax.Rows[i]["In_status_desc"].ToString();
                        objPInvoiceTaxList.In_mode_flag = InvoiceTax.Rows[i]["In_mode_flag"].ToString();

                        objproductSearchRoot.context.InvoiceTax.Add(objPInvoiceTaxList);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objproductSearchRoot;
        }
        public PAWHSRaiseInvoiceSDocument Savenew_pawhs_service_receipting_DB(PAWHSRaiseInvoiceSApplication ObjFarmer, string mysqlcon)
        {
            int ret = 0;

            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            PAWHSRaiseInvoiceSDocument objsinvoice = new PAWHSRaiseInvoiceSDocument();
            objsinvoice.context = new PAWHSRaiseInvoiceSContext();
            objsinvoice.context.Header = new PAWHSRaiseInvoiceSHeader();
            objsinvoice.ApplicationException = new PAWHSRaiseInvoiceSApplicationException();
            Int32 IOU_invoice_rowid1 = 0;
            string IOU_invoice_no1 = "";
            try
            {

                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                //string[] returnvalues = { };
                MySqlCommand cmd = new MySqlCommand("PAWHS_insupd_raise_invoice", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_fpo_name", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_fpo_name;
                cmd.Parameters.Add("In_invoice_date", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_invoice_date;
                cmd.Parameters.Add("In_customer_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_customer_code;
                cmd.Parameters.Add("In_customer_state", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_customer_state;
                cmd.Parameters.Add("In_provider_state", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_provider_state;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.localeId;
                cmd.Parameters.Add("IOU_invoice_rowid", MySqlDbType.Int32).Value = ObjFarmer.document.context.Header.IOU_invoice_rowid;
                cmd.Parameters.Add("IOU_invoice_no", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.IOU_invoice_no;
               
                cmd.Parameters.Add(new MySqlParameter("IOU_invoice_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_invoice_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();

                if (ret > 0)
                {
                    IOU_invoice_rowid1 = (Int32)cmd.Parameters["IOU_invoice_rowid1"].Value;
                    IOU_invoice_no1 = (string)cmd.Parameters["IOU_invoice_no1"].Value;
                    objsinvoice.context.Header.IOU_invoice_rowid = Convert.ToInt32(IOU_invoice_rowid1);
                    objsinvoice.context.Header.IOU_invoice_no = IOU_invoice_no1;
                }
                if (objsinvoice.context.Header.IOU_invoice_rowid > 0)
                {
                    string resultinvdetail = "";
                    resultinvdetail = SaveInvoiceDetail(ObjFarmer, objsinvoice, mysqlcon, MysqlCon);
                    if (resultinvdetail != "")
                    {
                        mysqltrans.Rollback();
                        objsinvoice.ApplicationException.errorNumber = resultinvdetail[0].ToString();
                        objsinvoice.ApplicationException.errorDescription = resultinvdetail[1].ToString();
                        return objsinvoice;
                    }

                }
                mysqltrans.Commit();
                return objsinvoice;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                throw ex;

            }
        }
        public string SaveInvoiceDetail(PAWHSRaiseInvoiceSApplication Objmodel, PAWHSRaiseInvoiceSDocument objInvoice, string MysqlCons, DataConnection MysqlCon)
        {
            string result = "";
            string errorNo = "";
            DataTable tab = new DataTable();
            PAWHSRaiseInvoiceSInvoiceDetails objinvdtl = new PAWHSRaiseInvoiceSInvoiceDetails();
            try
            {
                PAWHSRaiseInvoice_DB objproduct1 = new PAWHSRaiseInvoice_DB();
                foreach (var InvoiceDetail in Objmodel.document.context.Header.InvoiceDetails)
                {
                    objinvdtl.In_invoice_details_rowid = InvoiceDetail.In_invoice_details_rowid;
                    objinvdtl.In_item_code = InvoiceDetail.In_item_code;
                    objinvdtl.In_item_desc = InvoiceDetail.In_item_desc;
                    objinvdtl.In_item_name = InvoiceDetail.In_item_name;
                    objinvdtl.In_type = InvoiceDetail.In_type;
                    objinvdtl.In_qty = InvoiceDetail.In_qty;
                    objinvdtl.In_uom_code = InvoiceDetail.In_uom_code;
                    objinvdtl.In_rate = InvoiceDetail.In_rate;
                    objinvdtl.In_amount = InvoiceDetail.In_amount;
                    objinvdtl.In_discount = InvoiceDetail.In_discount;
                    objinvdtl.In_tax_amount = InvoiceDetail.In_tax_amount;
                    objinvdtl.In_net_amount = InvoiceDetail.In_net_amount;
                    objinvdtl.In_status_code = InvoiceDetail.In_status_code;
                    objinvdtl.In_mode_flag = InvoiceDetail.In_mode_flag;
                    errorNo = objproduct1.SaveInvoiceDetailNew(objinvdtl, objInvoice, Objmodel, MysqlCons, MysqlCon);
                    if (errorNo != "")
                    {
                        break;
                    }
                }
                return errorNo;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public string SaveInvoiceDetailNew(PAWHSRaiseInvoiceSInvoiceDetails objinvdtl, PAWHSRaiseInvoiceSDocument ObjFarmer, PAWHSRaiseInvoiceSApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {
            string errorNo = "";
            string errorMsg = "";
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_iud_invoice_details", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("IOU_invoice_rowid", MySqlDbType.Int32).Value = ObjFarmer.context.Header.IOU_invoice_rowid;
                cmd.Parameters.Add("IOU_invoice_no", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.IOU_invoice_no;
                cmd.Parameters.Add("In_invoice_details_rowid", MySqlDbType.Int32).Value = objinvdtl.In_invoice_details_rowid;
                cmd.Parameters.Add("In_item_code", MySqlDbType.VarChar).Value = objinvdtl.In_item_code;
                cmd.Parameters.Add("In_item_desc", MySqlDbType.VarChar).Value = objinvdtl.In_item_desc;
                cmd.Parameters.Add("In_item_name", MySqlDbType.VarChar).Value = objinvdtl.In_item_name;
                cmd.Parameters.Add("In_type", MySqlDbType.Double).Value = objinvdtl.In_type;
                cmd.Parameters.Add("In_qty", MySqlDbType.Double).Value = objinvdtl.In_qty;
                cmd.Parameters.Add("In_uom_code", MySqlDbType.VarChar).Value = objinvdtl.In_uom_code;
                cmd.Parameters.Add("In_rate", MySqlDbType.Double).Value = objinvdtl.In_rate;
                cmd.Parameters.Add("In_amount", MySqlDbType.Double).Value = objinvdtl.In_amount;
                cmd.Parameters.Add("In_discount", MySqlDbType.Double).Value = objinvdtl.In_discount;
                cmd.Parameters.Add("In_tax_amount", MySqlDbType.Double).Value = objinvdtl.In_tax_amount;
                cmd.Parameters.Add("In_net_amount", MySqlDbType.Double).Value = objinvdtl.In_net_amount;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = objinvdtl.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objinvdtl.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                if (ret == 0)
                {
                    errorNo = (string)cmd.Parameters["errorNo"].Value;
                    errorMsg = ObjErrormsg.ErrorMessage(errorNo);
                }
                return errorNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PAWHSRaiseInvoicePApplication Getpayment_collection_DB(PAWHSRaiseInvoicePContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();

            MysqlCon = new DataConnection(mysqlcon);

            PAWHSRaiseInvoicePApplication ObjinvRoot = new PAWHSRaiseInvoicePApplication();
            PAWHSRaiseInvoice_DB objDataModel = new PAWHSRaiseInvoice_DB();

            DataTable Detail = new DataTable();
            DataTable Header = new DataTable();

            ObjinvRoot.context = new PAWHSRaiseInvoicePContext();
            ObjinvRoot.context.Header = new PAWHSRaiseInvoicePHeader();
            ObjinvRoot.context.Detail = new List<PAWHSRaiseInvoicePDetail>();
            try
            {

                MySqlCommand cmd = new MySqlCommand("PAWHS_raiseInvoice_fetch_payment_collection", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("In_invoice_rowid", MySqlDbType.Int32).Value = ObjContext.IOU_invoice_rowid;
               
                cmd.Parameters.Add(new MySqlParameter("In_invoice_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_balance_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_paymode_code", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_paymode_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_ref_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_payment_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_payment_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();

                if (ds.Tables.Count > 0)
                {
                    Detail = ds.Tables[0];
                    for (int i = 0; i < Detail.Rows.Count; i++)
                    {
                        PAWHSRaiseInvoicePDetail objInvpayList = new PAWHSRaiseInvoicePDetail();
                        objInvpayList.In_paymentcollection_rowid = Convert.ToInt32(Detail.Rows[i]["In_paymentcollection_rowid"]);
                        objInvpayList.In_payment_type = Detail.Rows[i]["In_payment_type"].ToString();
                        objInvpayList.In_payment_type_desc = Detail.Rows[i]["In_payment_type_desc"].ToString();
                        objInvpayList.In_payment_no = Detail.Rows[i]["In_payment_no"].ToString();
                        objInvpayList.In_balance_amount = Convert.ToDouble(Detail.Rows[i]["In_balance_amount"]);
                        objInvpayList.In_payment_amount = Convert.ToDouble(Detail.Rows[i]["In_payment_amount"]);
                        objInvpayList.In_payment_mode = Detail.Rows[i]["In_payment_mode"].ToString();
                        objInvpayList.In_ref_no = Detail.Rows[i]["In_ref_no"].ToString();
                        objInvpayList.In_payment_date = Detail.Rows[i]["In_payment_date"].ToString();
                        objInvpayList.In_process_status = Detail.Rows[i]["In_process_status"].ToString();
                        objInvpayList.In_process_status_desc = Detail.Rows[i]["In_process_status_desc"].ToString();
                        objInvpayList.In_paid_amount = Convert.ToDouble(Detail.Rows[i]["In_paid_amount"]);
                        objInvpayList.In_mode_flag = Detail.Rows[i]["In_mode_flag"].ToString();

                        ObjinvRoot.context.Detail.Add(objInvpayList);
                    }
                }
                ObjinvRoot.context.orgnId = ObjContext.orgnId;
                ObjinvRoot.context.locnId = ObjContext.locnId;
                ObjinvRoot.context.userId = ObjContext.userId;
                ObjinvRoot.context.localeId = ObjContext.localeId;

                ObjinvRoot.context.Header.In_invoice_no = (string)cmd.Parameters["In_invoice_no"].Value;
                ObjinvRoot.context.Header.In_amount = (double)cmd.Parameters["In_amount"].Value;
                ObjinvRoot.context.Header.In_balance_amount = (double)cmd.Parameters["In_balance_amount"].Value;
                ObjinvRoot.context.Header.In_paymode_code = (string)cmd.Parameters["In_paymode_code"].Value;
                ObjinvRoot.context.Header.In_paymode_desc = (string)cmd.Parameters["In_paymode_desc"].Value;
                ObjinvRoot.context.Header.In_ref_no = (string)cmd.Parameters["In_ref_no"].Value;
                ObjinvRoot.context.Header.In_payment_date = (string)cmd.Parameters["In_payment_date"].Value;
                ObjinvRoot.context.Header.In_payment_amount = (double)cmd.Parameters["In_payment_amount"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjinvRoot;
        }
        public PAWHSRaiseInvoicePSDocument Savenew_payment_collection_raise_invoice_DB(PAWHSRaiseInvoicePSApplication ObjFarmer, string mysqlcon)
        {
            int ret = 0;

            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            PAWHSRaiseInvoicePSDocument objsinvoice = new PAWHSRaiseInvoicePSDocument();
            objsinvoice.context = new PAWHSRaiseInvoicePSContext();
            objsinvoice.context.Header = new PAWHSRaiseInvoicePSHeader();
            objsinvoice.ApplicationException = new PAWHSRaiseInvoicePSApplicationException();
            string IOU_invoice_rowid1 = "";
            string IOU_invoice_no1 = "";
            try
            {

                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                //string[] returnvalues = { };
                MySqlCommand cmd = new MySqlCommand("PAWHS_raiseInvoice_insupd_payment_collection", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_invoice_rowid", MySqlDbType.Int32).Value = ObjFarmer.document.context.Header.In_invoice_rowid;
                cmd.Parameters.Add("In_invoice_no", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_invoice_no;
                cmd.Parameters.Add("In_amount", MySqlDbType.Double).Value = ObjFarmer.document.context.Header.In_amount;
                cmd.Parameters.Add("In_balance_amount", MySqlDbType.Double).Value = ObjFarmer.document.context.Header.In_balance_amount;
                cmd.Parameters.Add("In_paymode_code", MySqlDbType.Double).Value = ObjFarmer.document.context.Header.In_paymode_code;
                cmd.Parameters.Add("In_ref_no", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_ref_no;
                cmd.Parameters.Add("In_payment_date", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_payment_date;
                cmd.Parameters.Add("In_payment_amount", MySqlDbType.Double).Value = ObjFarmer.document.context.Header.In_payment_amount;                
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_status_code;                
                cmd.Parameters.Add("In_modeflag", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_modeflag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.localeId;
                ret = cmd.ExecuteNonQuery();

                if (ret > 0)
                {
                    IOU_invoice_rowid1 = (string)cmd.Parameters["IOU_invoice_rowid1"].Value;
                    IOU_invoice_no1 = (string)cmd.Parameters["IOU_invoice_no1"].Value;
                    
                }
                
                string[] returnvalues = { IOU_invoice_rowid1, IOU_invoice_no1 };

                mysqltrans.Commit();
                return objsinvoice;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                throw ex;

            }
        }
        
    }
}
