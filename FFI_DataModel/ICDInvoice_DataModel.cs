using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace FFI_DataModel
{
    public class ICDInvoice_DataModel
    {

        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInvoice_DataModel)); //Declaring Log4Net. 
        string methodName = MethodBase.GetCurrentMethod().Name;
        public ICDInvoiceApplication GetAllICDInvoice_DB(ICDInvoiceContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();
            ICDInvoiceApplication objinvoiceRoot = new ICDInvoiceApplication();
            ICDInvoice_DataModel objDataModel = new ICDInvoice_DataModel();
            objinvoiceRoot.context = new ICDInvoiceContext();
            objinvoiceRoot.context.List = new List<ICDInvoiceList>();
            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("ICDMOB_fetch_invoice_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
                cmd.Parameters.Add("in_filterby_option", MySqlDbType.VarChar).Value = objinvoice.FilterBy_Option;
                cmd.Parameters.Add("in_filterby_code", MySqlDbType.VarChar).Value = objinvoice.FilterBy_Code;
                cmd.Parameters.Add("in_filterby_fromvalue", MySqlDbType.VarChar).Value = objinvoice.FilterBy_FromValue;
                cmd.Parameters.Add("in_filterby_tovalue", MySqlDbType.VarChar).Value = objinvoice.FilterBy_ToValue;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);

                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ICDInvoiceList objList = new ICDInvoiceList();
                    objList.Out_invoice_rowid = Convert.ToInt32(dt.Rows[i]["Out_invoice_rowid"]);
                    objList.Out_ic_code = dt.Rows[i]["Out_ic_code"].ToString();
                    objList.Out_ic_name = dt.Rows[i]["Out_ic_name"].ToString();
                    objList.Out_invoice_no = dt.Rows[i]["Out_invoice_no"].ToString();
                    objList.Out_invoice_date = dt.Rows[i]["Out_invoice_date"].ToString();
                    objList.Out_customer_type = dt.Rows[i]["Out_customer_type"].ToString();
                    objList.Out_customer_type_desc = dt.Rows[i]["Out_customer_type_desc"].ToString();
                    objList.Out_customer_name = dt.Rows[i]["Out_customer_name"].ToString();
                    objList.Out_reciver_location = dt.Rows[i]["Out_reciver_location"].ToString();
                    objList.Out_reciver_address = dt.Rows[i]["Out_reciver_address"].ToString();
                    objList.Out_process_status = dt.Rows[i]["Out_process_status"].ToString();
                    objList.Out_process_status_desc = dt.Rows[i]["Out_process_status_desc"].ToString();
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.Out_status_desc = dt.Rows[i]["Out_status_desc"].ToString();
                    objList.Out_totalinvoice_amount = dt.Rows[i]["Out_totalinvoice_amount"].ToString();
                    objList.Out_reciver_location_desc = dt.Rows[i]["Out_reciver_location_desc"].ToString(); //ramya added on 07 Jun 21
                    objinvoiceRoot.context.List.Add(objList);
                }
                objinvoiceRoot.context.orgnId = objinvoice.orgnId;
                objinvoiceRoot.context.locnId = objinvoice.locnId;
                objinvoiceRoot.context.localeId = objinvoice.localeId;
                objinvoiceRoot.context.userId = objinvoice.userId;
                objinvoiceRoot.context.FilterBy_Code = objinvoice.FilterBy_Code;
                objinvoiceRoot.context.FilterBy_FromValue = objinvoice.FilterBy_FromValue;
                objinvoiceRoot.context.FilterBy_Option = objinvoice.FilterBy_Option;
                objinvoiceRoot.context.FilterBy_ToValue = objinvoice.FilterBy_ToValue;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objinvoice.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objinvoiceRoot;
        }
        public ICDInvoiceFApplication GetSingleICDInvoicefetch(ICDInvoiceFContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            MysqlCon = new DataConnection(mysqlcon);
            ICDInvoiceFApplication ObjinvRoot = new ICDInvoiceFApplication();
            ICDInvoice_DataModel objDataModel = new ICDInvoice_DataModel();
            DataTable InvoiceDetail = new DataTable();
            DataTable InvoiceTax = new DataTable();
            DataTable PaymentCollection = new DataTable();
            DataTable InvoiceDetailSlno = new DataTable();

            DataTable Header = new DataTable();

            ObjinvRoot.context = new ICDInvoiceFContext();
            ObjinvRoot.context.Header = new ICDInvoiceHeader();
            ObjinvRoot.context.Header.InvoiceDetail = new List<ICDInvoiceDetail>();
            ObjinvRoot.context.Header.InvoiceTax = new List<ICDInvoiceTax>();
            ObjinvRoot.context.Header.PaymentCollection = new List<ICDInvoicePaymentCollection>();
            ObjinvRoot.context.Header.Slno = new List<ICDInvoiceDetailSlno>();

            try
            {
                MySqlCommand cmd = new MySqlCommand("ICDMOB_fetch_invoice", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("IOU_invoice_rowid", MySqlDbType.Int32).Value = ObjContext.invoice_rowid;

                cmd.Parameters.Add(new MySqlParameter("In_orgn_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_invoice_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_ic_code", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_ic_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_invoice_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_customer_type", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_customer_type_desc", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_customer_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_customer_address", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_farmer_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_farmer_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_provider_location", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_provider_location_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_reciver_location", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_reciver_location_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_totalinvoice_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_balance_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_process_status", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_process_status_desc", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_transport_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_others", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_phone_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_invoice_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);

                MysqlCon.con.Close();

                if (ds.Tables.Count > 0)
                {
                    InvoiceDetail = ds.Tables[0];
                    InvoiceTax = ds.Tables[1];
                    PaymentCollection = ds.Tables[2];
                    InvoiceDetailSlno = ds.Tables[3];

                    for (int i = 0; i < InvoiceDetail.Rows.Count; i++)
                    {
                        ICDInvoiceDetail objInvList = new ICDInvoiceDetail();
                        objInvList.In_invoicedtl_rowid = Convert.ToInt32(InvoiceDetail.Rows[i]["In_invoicedtl_rowid"]);
                        objInvList.In_invoice_no = InvoiceDetail.Rows[i]["In_invoice_no"].ToString();
                        objInvList.In_product_catg_code = InvoiceDetail.Rows[i]["In_product_catg_code"].ToString();
                        objInvList.In_product_catg_desc = InvoiceDetail.Rows[i]["In_product_catg_desc"].ToString();
                        objInvList.In_product_subcatg_code = InvoiceDetail.Rows[i]["In_product_subcatg_code"].ToString();
                        objInvList.In_product_subcatg_desc = InvoiceDetail.Rows[i]["In_product_subcatg_desc"].ToString();
                        objInvList.In_product_code = InvoiceDetail.Rows[i]["In_product_code"].ToString();
                        objInvList.In_product_desc = InvoiceDetail.Rows[i]["In_product_desc"].ToString();
                        objInvList.In_hsn_code = InvoiceDetail.Rows[i]["In_hsn_code"].ToString();
                        objInvList.In_hsn_desc = InvoiceDetail.Rows[i]["In_hsn_desc"].ToString();
                        objInvList.In_qty = Convert.ToDouble(InvoiceDetail.Rows[i]["In_qty"]);
                        objInvList.In_uomtype_code = InvoiceDetail.Rows[i]["In_uomtype_code"].ToString();
                        objInvList.In_uomtype_desc = InvoiceDetail.Rows[i]["In_uomtype_desc"].ToString();
                        objInvList.In_base_price = Convert.ToDouble(InvoiceDetail.Rows[i]["In_base_price"]);
                        objInvList.In_product_amount = Convert.ToDouble(InvoiceDetail.Rows[i]["In_product_amount"]);
                        objInvList.In_discount_amount = Convert.ToDouble(InvoiceDetail.Rows[i]["In_discount_amount"]);
                        objInvList.In_tax_amount = Convert.ToDouble(InvoiceDetail.Rows[i]["In_tax_amount"]);
                        objInvList.In_tax_rate = Convert.ToDouble(InvoiceDetail.Rows[i]["In_tax_rate"]);
                        objInvList.In_net_amount = Convert.ToDouble(InvoiceDetail.Rows[i]["In_net_amount"]);

                        objInvList.In_status_code = InvoiceDetail.Rows[i]["In_status_code"].ToString();
                        objInvList.In_status_desc = InvoiceDetail.Rows[i]["In_status_desc"].ToString();
                        objInvList.In_mode_flag = InvoiceDetail.Rows[i]["In_mode_flag"].ToString();
                        ObjinvRoot.context.Header.InvoiceDetail.Add(objInvList);
                    }
                    for (int i = 0; i < InvoiceTax.Rows.Count; i++)
                    {
                        ICDInvoiceTax objInvtaxList = new ICDInvoiceTax();
                        objInvtaxList.In_invoicetax_rowid = Convert.ToInt32(InvoiceTax.Rows[i]["In_invoicetax_rowid"]);
                        objInvtaxList.In_invoice_no = InvoiceTax.Rows[i]["In_invoice_no"].ToString();
                        objInvtaxList.In_product_code = InvoiceTax.Rows[i]["In_product_code"].ToString();
                        objInvtaxList.In_product_name = InvoiceTax.Rows[i]["In_product_name"].ToString();
                        objInvtaxList.In_hsn_code = InvoiceTax.Rows[i]["In_hsn_code"].ToString();
                        objInvtaxList.In_hsn_desc = InvoiceTax.Rows[i]["In_hsn_desc"].ToString();
                        objInvtaxList.In_cgst_rate = Convert.ToDouble(InvoiceTax.Rows[i]["In_cgst_rate"]);
                        objInvtaxList.In_sgst_rate = Convert.ToDouble(InvoiceTax.Rows[i]["In_sgst_rate"]);
                        objInvtaxList.In_igst_rate = Convert.ToDouble(InvoiceTax.Rows[i]["In_igst_rate"]);
                        objInvtaxList.In_ugst_rate = Convert.ToDouble(InvoiceTax.Rows[i]["In_ugst_rate"]);
                        objInvtaxList.In_tax_type = InvoiceTax.Rows[i]["In_tax_type"].ToString();
                        objInvtaxList.In_tax_rate = Convert.ToDouble(InvoiceTax.Rows[i]["In_tax_rate"]);
                        objInvtaxList.In_taxable_amount = Convert.ToDouble(InvoiceTax.Rows[i]["In_taxable_amount"]);
                        objInvtaxList.In_tax_amount = Convert.ToDouble(InvoiceTax.Rows[i]["In_tax_amount"]);
                        objInvtaxList.In_status_code = InvoiceTax.Rows[i]["In_status_code"].ToString();
                        objInvtaxList.In_status_desc = InvoiceTax.Rows[i]["In_status_desc"].ToString();
                        objInvtaxList.In_mode_flag = InvoiceTax.Rows[i]["In_mode_flag"].ToString();


                        ObjinvRoot.context.Header.InvoiceTax.Add(objInvtaxList);
                    }
                    for (int i = 0; i < PaymentCollection.Rows.Count; i++)
                    {
                        ICDInvoicePaymentCollection objInvpayList = new ICDInvoicePaymentCollection();
                        objInvpayList.In_paymentcollection_rowid = Convert.ToInt32(PaymentCollection.Rows[i]["In_paymentcollection_rowid"]);
                        objInvpayList.In_payment_type = PaymentCollection.Rows[i]["In_payment_type"].ToString();
                        objInvpayList.In_payment_no = PaymentCollection.Rows[i]["In_payment_no"].ToString();
                        objInvpayList.In_balance_amount = Convert.ToDouble(PaymentCollection.Rows[i]["In_balance_amount"]);
                        objInvpayList.In_payment_amount = Convert.ToDouble(PaymentCollection.Rows[i]["In_payment_amount"]);
                        objInvpayList.In_payment_mode = PaymentCollection.Rows[i]["In_payment_mode"].ToString();
                        objInvpayList.In_ref_no = PaymentCollection.Rows[i]["In_ref_no"].ToString();
                        objInvpayList.In_payment_date = PaymentCollection.Rows[i]["In_payment_date"].ToString();
                        objInvpayList.In_process_status = PaymentCollection.Rows[i]["In_process_status"].ToString();
                        objInvpayList.In_process_desc = PaymentCollection.Rows[i]["In_process_desc"].ToString();
                        objInvpayList.In_mode_flag = PaymentCollection.Rows[i]["In_mode_flag"].ToString();

                        ObjinvRoot.context.Header.PaymentCollection.Add(objInvpayList);
                    }
                    for (int i = 0; i < InvoiceDetailSlno.Rows.Count; i++)
                    {
                        ICDInvoiceDetailSlno objInvpayList = new ICDInvoiceDetailSlno();
                        objInvpayList.In_invoicedtl_rowid = Convert.ToInt32(InvoiceDetailSlno.Rows[i]["invoicedtl_rowid"]);
                        objInvpayList.In_slno = InvoiceDetailSlno.Rows[i]["slno"].ToString();
                        objInvpayList.In_no_of_bags = InvoiceDetailSlno.Rows[i]["no_of_bags"].ToString();
                        objInvpayList.In_invoice_no = InvoiceDetailSlno.Rows[i]["invoice_no"].ToString();
                        objInvpayList.In_product_code = InvoiceDetailSlno.Rows[i]["product_code"].ToString();
                        objInvpayList.In_product_name = InvoiceDetailSlno.Rows[i]["product_name"].ToString();
                        objInvpayList.In_mode_flag = InvoiceDetailSlno.Rows[i]["In_mode_flag"].ToString();
                        ObjinvRoot.context.Header.Slno.Add(objInvpayList);
                    }
                }
                ObjinvRoot.context.orgnId = ObjContext.orgnId;
                ObjinvRoot.context.locnId = ObjContext.locnId;
                ObjinvRoot.context.userId = ObjContext.userId;
                ObjinvRoot.context.localeId = ObjContext.localeId;

                ObjinvRoot.context.Header.IOU_invoice_rowid = (Int32)cmd.Parameters["IOU_invoice_rowid"].Value;
                ObjinvRoot.context.Header.In_orgn_code = (string)cmd.Parameters["In_orgn_code"].Value.ToString();
                ObjinvRoot.context.Header.In_invoice_no = (string)cmd.Parameters["In_invoice_no"].Value.ToString();
                ObjinvRoot.context.Header.In_ic_code = (string)cmd.Parameters["In_ic_code"].Value.ToString();
                ObjinvRoot.context.Header.In_ic_desc = (string)cmd.Parameters["In_ic_desc"].Value.ToString();
                ObjinvRoot.context.Header.In_invoice_date = (string)cmd.Parameters["In_invoice_date"].Value.ToString();
                ObjinvRoot.context.Header.In_customer_type = (string)cmd.Parameters["In_customer_type"].Value.ToString();
                ObjinvRoot.context.Header.In_customer_type_desc = (string)cmd.Parameters["In_customer_type_desc"].Value.ToString();
                ObjinvRoot.context.Header.In_customer_name = (string)cmd.Parameters["In_customer_name"].Value.ToString();
                ObjinvRoot.context.Header.In_customer_address = (string)cmd.Parameters["In_customer_address"].Value.ToString();
                ObjinvRoot.context.Header.In_farmer_code = (string)cmd.Parameters["In_farmer_code"].Value.ToString();
                ObjinvRoot.context.Header.In_farmer_name = (string)cmd.Parameters["In_farmer_name"].Value.ToString();
                ObjinvRoot.context.Header.In_provider_location = (string)cmd.Parameters["In_provider_location"].Value.ToString();
                ObjinvRoot.context.Header.In_provider_location_desc = (string)cmd.Parameters["In_provider_location_desc"].Value.ToString();
                ObjinvRoot.context.Header.In_reciver_location = (string)cmd.Parameters["In_reciver_location"].Value.ToString();
                ObjinvRoot.context.Header.In_reciver_location_desc = (string)cmd.Parameters["In_reciver_location_desc"].Value.ToString();
                ObjinvRoot.context.Header.In_totalinvoice_amount = (double)cmd.Parameters["In_totalinvoice_amount"].Value;
                ObjinvRoot.context.Header.In_balance_amount = (double)cmd.Parameters["In_balance_amount"].Value;
                ObjinvRoot.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                ObjinvRoot.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                ObjinvRoot.context.Header.In_process_status = (string)cmd.Parameters["In_process_status"].Value.ToString();
                ObjinvRoot.context.Header.In_process_status_desc = (string)cmd.Parameters["In_process_status_desc"].Value.ToString();
                ObjinvRoot.context.Header.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();
                ObjinvRoot.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                ObjinvRoot.context.Header.In_transport_amount = (double)cmd.Parameters["In_transport_amount"].Value;
                ObjinvRoot.context.Header.In_others = (string)cmd.Parameters["In_others"].Value.ToString();
                ObjinvRoot.context.Header.In_phone_no = (string)cmd.Parameters["In_phone_no"].Value.ToString();
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjinvRoot;
        }
        public ICDSIProApplication GetICDProductInvfetch(ICDSIProContext objproductSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();

            ICDSIProApplication objproductSearchRoot = new ICDSIProApplication();
            ICDInvoice_DataModel objDataModel = new ICDInvoice_DataModel();

            DataTable Detail = new DataTable();
            DataTable InvoiceTax = new DataTable();

            objproductSearchRoot.context = new ICDSIProContext();
            objproductSearchRoot.context.Detail = new List<ICDSIProDetail>();
            objproductSearchRoot.context.InvoiceTax = new List<ICDSIProInvoiceTax>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("ICDMOB_fetch_product_search", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objproductSearch.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objproductSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objproductSearch.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objproductSearch.localeId;
                cmd.Parameters.Add("in_filterby_option", MySqlDbType.VarChar).Value = objproductSearch.FilterBy_Option;
                cmd.Parameters.Add("in_filterby_code", MySqlDbType.VarChar).Value = objproductSearch.FilterBy_Code;
                cmd.Parameters.Add("in_filterby_fromvalue", MySqlDbType.VarChar).Value = objproductSearch.FilterBy_FromValue;
                cmd.Parameters.Add("in_filterby_tovalue", MySqlDbType.VarChar).Value = objproductSearch.FilterBy_ToValue;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                if (ds.Tables.Count > 0)
                {
                    Detail = ds.Tables[0];
                    InvoiceTax = ds.Tables[1];


                    for (int i = 0; i < Detail.Rows.Count; i++)
                    {
                        ICDSIProDetail objDetailList = new ICDSIProDetail();
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
                        ICDSIProInvoiceTax objPInvoiceTaxList = new ICDSIProInvoiceTax();
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
                logger.Error("USERNAME :" + objproductSearch.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return objproductSearchRoot;
        }
        public ICDInvoiceSADocument SaveinvoiceNew(ICDInvoiceSAApplication ObjFarmer, string mysqlcon)
        {
            int ret = 0;
            string errorNo = "";
            string errorMsg = "";
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            ICDInvoiceSADocument objsinvoice = new ICDInvoiceSADocument();
            objsinvoice.context = new ICDInvoiceSAContext();
            objsinvoice.context.Header = new ICDInvoiceSAHeader();
            objsinvoice.ApplicationException = new ICDInvoiceSAApplicationException();
            Int32 IOU_invoice_rowid1 = 0;

            try
            {

                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                //string[] returnvalues = { };
                MySqlCommand cmd = new MySqlCommand("ICDMOB_insupd_invoice", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_orgn_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_orgn_code;
                cmd.Parameters.Add("In_invoice_no", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_invoice_no;
                cmd.Parameters.Add("In_ic_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_ic_code;
                cmd.Parameters.Add("In_invoice_date", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_invoice_date;
                cmd.Parameters.Add("In_customer_type", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_customer_type;
                cmd.Parameters.Add("In_customer_name", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_customer_name;
                cmd.Parameters.Add("In_customer_address", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_customer_address;
                cmd.Parameters.Add("In_farmer_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_farmer_code;
                cmd.Parameters.Add("In_provider_location", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_provider_location;
                cmd.Parameters.Add("In_reciver_location", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_reciver_location;
                cmd.Parameters.Add("In_totalinvoice_amount", MySqlDbType.Double).Value = ObjFarmer.document.context.Header.In_totalinvoice_amount;
                cmd.Parameters.Add("In_balance_amount", MySqlDbType.Double).Value = ObjFarmer.document.context.Header.In_balance_amount;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_process_status", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_process_status;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_transport_amount", MySqlDbType.Int32).Value = ObjFarmer.document.context.Header.In_transport_amount;
                cmd.Parameters.Add("In_others", MySqlDbType.Int32).Value = ObjFarmer.document.context.Header.In_others;
                cmd.Parameters.Add("In_phone_no", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_phone_no;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.localeId;
                cmd.Parameters.Add("IOU_invoice_rowid", MySqlDbType.Int32).Value = ObjFarmer.document.context.Header.IOU_invoice_rowid;

                cmd.Parameters.Add(new MySqlParameter("IOU_invoice_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_invoice_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                if (ret > 0)
                {
                    IOU_invoice_rowid1 = (Int32)cmd.Parameters["IOU_invoice_rowid1"].Value;
                    objsinvoice.context.Header.IOU_invoice_rowid = Convert.ToInt32(IOU_invoice_rowid1);
                    objsinvoice.context.Header.In_invoice_no = cmd.Parameters["In_invoice_no1"].Value.ToString();
                }
                else
                {
                    errorNo = (string)cmd.Parameters["errorNo"].Value;
                    errorMsg = ObjErrormsg.ErrorMessage(errorNo);
                    mysqltrans.Rollback();
                    objsinvoice.ApplicationException.errorNumber = errorNo.ToString();
                    objsinvoice.ApplicationException.errorDescription = errorMsg.ToString();
                    return objsinvoice;
                }
                string[] result = { errorNo, errorMsg };
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
                    string resultserialno = "";
                    resultserialno = SaveSerialno(ObjFarmer, objsinvoice, mysqlcon, MysqlCon);
                    if (resultserialno != "")
                    {
                        mysqltrans.Rollback();
                        objsinvoice.ApplicationException.errorNumber = resultserialno[0].ToString();
                        objsinvoice.ApplicationException.errorDescription = resultserialno[1].ToString();
                        return objsinvoice;
                    }
                }
                mysqltrans.Commit();
                return objsinvoice;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                logger.Error("USERNAME :" + ObjFarmer.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return objsinvoice;

            }
        }
        public string SaveInvoiceDetail(ICDInvoiceSAApplication Objmodel, ICDInvoiceSADocument objInvoice, string MysqlCons, DataConnection MysqlCon)
        {
            string result = "";
            string errorNo = "";
            DataTable tab = new DataTable();
            ICDInvoiceSAInvoiceDetail objinvdtl = new ICDInvoiceSAInvoiceDetail();
            try
            {
                ICDInvoice_DataModel objproduct1 = new ICDInvoice_DataModel();
                foreach (var InvoiceDetail in Objmodel.document.context.InvoiceDetail)
                {
                    objinvdtl.In_invoicedtl_rowid = InvoiceDetail.In_invoicedtl_rowid;
                    objinvdtl.In_product_catg_code = InvoiceDetail.In_product_catg_code;
                    objinvdtl.In_product_subcatg_code = InvoiceDetail.In_product_subcatg_code;
                    objinvdtl.In_product_code = InvoiceDetail.In_product_code;
                    objinvdtl.In_hsn_code = InvoiceDetail.In_hsn_code;
                    objinvdtl.In_qty = InvoiceDetail.In_qty;
                    objinvdtl.In_base_price = InvoiceDetail.In_base_price;
                    objinvdtl.In_product_amount = InvoiceDetail.In_product_amount;
                    objinvdtl.In_discount_amount = InvoiceDetail.In_discount_amount;
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
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return errorNo;
            }
        }
        public string SaveSerialno(ICDInvoiceSAApplication Objmodel, ICDInvoiceSADocument objInvoice, string MysqlCons, DataConnection MysqlCon)
        {
            string result = "";
            string errorNo = "";
            DataTable tab = new DataTable();
            ICDInvoiceDetailSerialno objserialno = new ICDInvoiceDetailSerialno();
            try
            {
                ICDInvoice_DataModel objproduct1 = new ICDInvoice_DataModel();
                foreach (var InvoiceDetail1 in Objmodel.document.context.serialno)
                {
                    objserialno.In_slno_row_id = InvoiceDetail1.In_slno_row_id;
                    objserialno.In_slno = InvoiceDetail1.In_slno;
                    objserialno.In_no_of_bags = InvoiceDetail1.In_no_of_bags;
                    objserialno.In_product_code = InvoiceDetail1.In_product_code;
                    //objdtlslno.In_status_code = InvoiceDetail1.In_status_code;
                    objserialno.In_mode_flag = InvoiceDetail1.In_mode_flag;
                    errorNo = objproduct1.SaveInvoiceserialno(objserialno, objInvoice, Objmodel, MysqlCons, MysqlCon);
                }
                return errorNo;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return errorNo;
            }

        }

        public string SaveInvoiceDetailNew(ICDInvoiceSAInvoiceDetail objinvdtl, ICDInvoiceSADocument ObjFarmer, ICDInvoiceSAApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {
            string errorNo = "";
            string errorMsg = "";
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("ICDMOB_iud_invoice_detail", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("IOU_invoice_rowid", MySqlDbType.Int32).Value = ObjFarmer.context.Header.IOU_invoice_rowid;
                cmd.Parameters.Add("In_invoicedtl_rowid", MySqlDbType.Int32).Value = objinvdtl.In_invoicedtl_rowid;
                cmd.Parameters.Add("In_product_catg_code", MySqlDbType.VarChar).Value = objinvdtl.In_product_catg_code;
                cmd.Parameters.Add("In_product_subcatg_code", MySqlDbType.VarChar).Value = objinvdtl.In_product_subcatg_code;
                cmd.Parameters.Add("In_product_code", MySqlDbType.VarChar).Value = objinvdtl.In_product_code;
                cmd.Parameters.Add("In_hsn_code", MySqlDbType.VarChar).Value = objinvdtl.In_hsn_code;
                cmd.Parameters.Add("In_qty", MySqlDbType.Double).Value = objinvdtl.In_qty;
                cmd.Parameters.Add("In_base_price", MySqlDbType.Double).Value = objinvdtl.In_base_price;
                cmd.Parameters.Add("In_product_amount", MySqlDbType.Double).Value = objinvdtl.In_product_amount;
                cmd.Parameters.Add("In_discount_amount", MySqlDbType.Double).Value = objinvdtl.In_discount_amount;
                cmd.Parameters.Add("In_tax_amount", MySqlDbType.Double).Value = objinvdtl.In_tax_amount;
                cmd.Parameters.Add("In_net_amount", MySqlDbType.Double).Value = objinvdtl.In_net_amount;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = objinvdtl.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objinvdtl.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_invoicedtl_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                if (ret == 0)
                {

                    errorNo = (string)cmd.Parameters["errorNo"].Value;
                    errorMsg = ObjErrormsg.ErrorMessage(errorNo);

                }
                return errorNo;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return errorNo;
            }
        }
        public string SaveInvoiceserialno(ICDInvoiceDetailSerialno objinvdtlslno, ICDInvoiceSADocument ObjFarmer, ICDInvoiceSAApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {
            string errorNo = "";
            string errorMsg = "";
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("ICDMOB_iud_invoice_detailslno", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_invoiceslno_rowid", MySqlDbType.Int32).Value = Convert.ToInt32(objinvdtlslno.In_slno_row_id);
                cmd.Parameters.Add("In_invoicedtl_rowid", MySqlDbType.Int32).Value = 0;
                cmd.Parameters.Add("In_slno", MySqlDbType.VarChar).Value = objinvdtlslno.In_slno;
                cmd.Parameters.Add("In_no_of_bags", MySqlDbType.VarChar).Value = objinvdtlslno.In_no_of_bags;
                cmd.Parameters.Add("In_invoice_no", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.In_invoice_no;
                cmd.Parameters.Add("In_product_code", MySqlDbType.VarChar).Value = objinvdtlslno.In_product_code;
                //cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = objinvdtlslno.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objinvdtlslno.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                // LogHelper.ConvertCmdIntoString(cmd);
                if (ret == 0)
                {

                    errorNo = (string)cmd.Parameters["errorNo"].Value;
                    errorMsg = ObjErrormsg.ErrorMessage(errorNo);

                }
                return errorNo;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return errorNo;
            }
        }
        public ICDInvoicepayApplication GetICDProductInvPayfetch(ICDInvoicepayContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();

            MysqlCon = new DataConnection(mysqlcon);

            ICDInvoicepayApplication ObjinvRoot = new ICDInvoicepayApplication();
            ICDInvoice_DataModel objDataModel = new ICDInvoice_DataModel();

            DataTable Detail = new DataTable();
            DataTable Header = new DataTable();

            ObjinvRoot.context = new ICDInvoicepayContext();
            ObjinvRoot.context.Header = new ICDInvoicepayHeader();
            ObjinvRoot.context.Detail = new List<ICDInvoicepayDetail>();
            try
            {

                MySqlCommand cmd = new MySqlCommand("ICDMOB_fetch_payment_collection_invoice", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("In_invoice_rowid", MySqlDbType.Int32).Value = ObjContext.invoice_rowid;

                cmd.Parameters.Add(new MySqlParameter("In_invoice_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_invoice_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_invoice_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_balance_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                if (ds.Tables.Count > 0)
                {
                    Detail = ds.Tables[0];
                    for (int i = 0; i < Detail.Rows.Count; i++)
                    {
                        ICDInvoicepayDetail objInvpayList = new ICDInvoicepayDetail();
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
                        objInvpayList.In_payment_mode_desc = Detail.Rows[i]["In_payment_mode_desc"].ToString(); //ramya added on 07 jun 21

                        ObjinvRoot.context.Detail.Add(objInvpayList);
                    }
                }
                ObjinvRoot.context.orgnId = ObjContext.orgnId;
                ObjinvRoot.context.locnId = ObjContext.locnId;
                ObjinvRoot.context.userId = ObjContext.userId;
                ObjinvRoot.context.localeId = ObjContext.localeId;

                ObjinvRoot.context.Header.In_invoice_no = (string)cmd.Parameters["In_invoice_no"].Value;
                ObjinvRoot.context.Header.In_invoice_date = (string)cmd.Parameters["In_invoice_date"].Value.ToString();
                ObjinvRoot.context.Header.In_invoice_amount = (double)cmd.Parameters["In_invoice_amount"].Value;
                ObjinvRoot.context.Header.In_balance_amount = (double)cmd.Parameters["In_balance_amount"].Value;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return ObjinvRoot;
        }
        public Document Saveinvoicepayment(PSApplication ObjFarmer, string mysqlcon)
        {
            int ret = 0;

            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            Document objsinvoice = new Document();
            objsinvoice.context = new PSContext();
            objsinvoice.context.Header = new PSHeader();
            objsinvoice.ApplicationException = new PSAApplicationException();
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
                MySqlCommand cmd = new MySqlCommand("ICDMOB_insupd_invoice_payment", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_invoice_date", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_invoice_date;
                cmd.Parameters.Add("In_invoice_amount", MySqlDbType.Double).Value = ObjFarmer.document.context.Header.In_invoice_amount;
                cmd.Parameters.Add("In_balance_amount", MySqlDbType.Double).Value = ObjFarmer.document.context.Header.In_balance_amount;
                cmd.Parameters.Add("In_payment_mode", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_payment_mode;
                cmd.Parameters.Add("In_ref_no", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_ref_no;
                cmd.Parameters.Add("In_payment_date", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_payment_date;
                cmd.Parameters.Add("In_payment_amount", MySqlDbType.Double).Value = ObjFarmer.document.context.Header.In_payment_amount;
                cmd.Parameters.Add("In_payment_response", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_payment_response;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_check_no", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_check_no;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.localeId;
                cmd.Parameters.Add("IOU_invoice_no", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.IOU_invoice_no;
                cmd.Parameters.Add("IOU_invoice_rowid", MySqlDbType.Int32).Value = ObjFarmer.document.context.Header.IOU_invoice_rowid;

                cmd.Parameters.Add(new MySqlParameter("IOU_invoice_rowid1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_invoice_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                if (ret > 0)
                {
                    IOU_invoice_rowid1 = (string)cmd.Parameters["IOU_invoice_rowid1"].Value;
                    IOU_invoice_no1 = (string)cmd.Parameters["IOU_invoice_no1"].Value;
                    objsinvoice.context.Header.IOU_invoice_rowid = Convert.ToInt32(IOU_invoice_rowid1);
                    objsinvoice.context.Header.IOU_invoice_no = IOU_invoice_no1;
                }
                if (objsinvoice.context.Header.IOU_invoice_rowid > 0)
                {
                    string[] resultinvdetail = { };
                    resultinvdetail = SaveInvoicePaymentDetail(ObjFarmer, objsinvoice, mysqlcon, MysqlCon);
                    if (resultinvdetail[0].Contains("060"))
                    {
                        mysqltrans.Rollback();
                        objsinvoice.ApplicationException.errorNumber = resultinvdetail[0].ToString();
                        objsinvoice.ApplicationException.errorDescription = resultinvdetail[1].ToString();
                        return objsinvoice;
                    }

                }
                string[] returnvalues = { IOU_invoice_rowid1 };

                mysqltrans.Commit();
                return objsinvoice;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                logger.Error("USERNAME :" + ObjFarmer.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return objsinvoice;
            }
        }
        public string[] SaveInvoicePaymentDetail(PSApplication Objmodel, Document objInvoice, string MysqlCons, DataConnection MysqlCon)
        {
            string[] result = { };
            string errorNo = "";
            string errorMsg = "";
            string[] resultinvdetail = new string[2];
            DataTable tab = new DataTable();
            PSDetail objinvdtl = new PSDetail();
            try
            {
                ICDInvoice_DataModel objproduct1 = new ICDInvoice_DataModel();
                foreach (var Detail in Objmodel.document.context.Detail)
                {
                    objinvdtl.In_paymentcollection_rowid = Detail.In_paymentcollection_rowid;
                    objinvdtl.In_payment_type = Detail.In_payment_type;
                    objinvdtl.In_payment_no = Detail.In_payment_no;
                    objinvdtl.In_balance_amount = Detail.In_balance_amount;
                    objinvdtl.In_payment_amount = Detail.In_payment_amount;
                    objinvdtl.In_payment_mode = Detail.In_payment_mode;
                    objinvdtl.In_ref_no = Detail.In_ref_no;
                    objinvdtl.In_payment_date = Detail.In_payment_date;
                    objinvdtl.In_process_status = Detail.In_process_status;
                    objinvdtl.In_paid_amount = Detail.In_paid_amount;
                    objinvdtl.In_mode_flag = Detail.In_mode_flag;
                    result = objproduct1.SaveInvoicePaymentDetailNew(objinvdtl, objInvoice, Objmodel, MysqlCons, MysqlCon);

                    //if (result[0].Contains("060"))
                    //{
                    //    errorNo = result[0].ToString();
                    //    errorMsg = result[1].ToString();
                    //    break;
                    //}
                }
                //string[] resultinvdetail = { errorNo, errorMsg };
                resultinvdetail[0] = errorNo;
                resultinvdetail[1] = errorMsg;
                return resultinvdetail;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return resultinvdetail;
            }

        }

        public string[] SaveInvoicePaymentDetailNew(PSDetail objinvdtl, Document ObjFarmer, PSApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {
            string errorNo = "";
            string errorMsg = "";
            string[] result = new string[2];
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("ICDMOB_iud_invoice_payment_detail", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_paymentcollection_rowid", MySqlDbType.Int32).Value = objinvdtl.In_paymentcollection_rowid;
                cmd.Parameters.Add("In_payment_type", MySqlDbType.VarChar).Value = objinvdtl.In_payment_type;
                cmd.Parameters.Add("In_payment_no", MySqlDbType.VarChar).Value = objinvdtl.In_payment_no;
                cmd.Parameters.Add("In_balance_amount", MySqlDbType.Double).Value = objinvdtl.In_balance_amount;
                cmd.Parameters.Add("In_payment_amount", MySqlDbType.Double).Value = objinvdtl.In_payment_amount;
                cmd.Parameters.Add("In_payment_mode", MySqlDbType.VarChar).Value = objinvdtl.In_payment_mode;
                cmd.Parameters.Add("In_ref_no", MySqlDbType.VarChar).Value = objinvdtl.In_ref_no;
                cmd.Parameters.Add("In_payment_date", MySqlDbType.VarChar).Value = objinvdtl.In_payment_date;
                cmd.Parameters.Add("In_process_status", MySqlDbType.VarChar).Value = objinvdtl.In_process_status;
                cmd.Parameters.Add("In_paid_amount", MySqlDbType.Double).Value = objinvdtl.In_paid_amount;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objinvdtl.In_mode_flag;
                cmd.Parameters.Add("IOU_invoice_rowid", MySqlDbType.Int32).Value = ObjFarmer.context.Header.IOU_invoice_rowid;
                cmd.Parameters.Add("IOU_invoice_no", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.IOU_invoice_no;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                //if (ret == 0)
                //{

                //    errorNo = (string)cmd.Parameters["errorNo"].Value;
                //    errorMsg = ObjErrormsg.ErrorMessage(errorNo);

                //}
                //string[] result = { errorNo, errorMsg };
                result[0] = errorNo;
                result[1] = errorMsg;
                return result;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return result;
            }
        }

        public InvoiceApplication GetAllInvoiceList_DB(InvoiceContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();
            InvoiceApplication objinvoiceRoot = new InvoiceApplication();
            ICDInvoice_DataModel objDataModel = new ICDInvoice_DataModel();
            objinvoiceRoot.context = new InvoiceContext();
            objinvoiceRoot.context.List = new List<InvoiceList>();
            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("ICD_Invoice_List", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);

                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    InvoiceList objList = new InvoiceList();
                    objList.Out_invoice_rowid = Convert.ToInt32(dt.Rows[i]["Out_invoice_rowid"]);
                    objList.Out_ic_code = dt.Rows[i]["Out_ic_code"].ToString();
                    objList.Out_ic_name = dt.Rows[i]["Out_ic_name"].ToString();
                    objList.Out_invoice_no = dt.Rows[i]["Out_invoice_no"].ToString();
                    objList.Out_invoice_date = dt.Rows[i]["Out_invoice_date"].ToString();
                    objList.Out_customer_name = dt.Rows[i]["Out_customer_name"].ToString();
                    objList.Out_totalinvoice_amount = dt.Rows[i]["Out_totalinvoice_amount"].ToString();
                    objList.Out_balance_amount = dt.Rows[i]["Out_balance_amount"].ToString();
                    objinvoiceRoot.context.List.Add(objList);
                }
                objinvoiceRoot.context.orgnId = objinvoice.orgnId;
                objinvoiceRoot.context.locnId = objinvoice.locnId;
                objinvoiceRoot.context.localeId = objinvoice.localeId;
                objinvoiceRoot.context.userId = objinvoice.userId; 
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objinvoice.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objinvoiceRoot;
        }

        public InvoicePayApplication GetAllInvoicePayList_DB(InvoicePayContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();
            InvoicePayApplication objinvoiceRoot = new InvoicePayApplication();
            ICDInvoice_DataModel objDataModel = new ICDInvoice_DataModel();
            objinvoiceRoot.context = new InvoicePayContext();
            objinvoiceRoot.context.List = new List<InvoicePayList>();
            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("ICD_InvoicePayment_List", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
                cmd.Parameters.Add("invoice_no", MySqlDbType.VarChar).Value = objinvoice.invoice_no;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);

                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    InvoicePayList objList = new InvoicePayList();
                    objList.Out_invoice_rowid = Convert.ToInt32(dt.Rows[i]["Out_invoicepay_rowid"]);
                    objList.Out_invoice_no = dt.Rows[i]["Out_invoicepay_no"].ToString();
                    objList.Out_invoice_date = dt.Rows[i]["Out_invoicepay_date"].ToString();
                    objList.Out_reference_no = dt.Rows[i]["Out_reference_no"].ToString();
                    objList.Out_paymode = dt.Rows[i]["Out_paymode"].ToString();
                    objList.Out_totalinvoice_amount = dt.Rows[i]["Out_payment_amount"].ToString();
                    objList.Out_balance_amount = dt.Rows[i]["Out_balance_amount"].ToString();
                    objList.Out_status = dt.Rows[i]["Out_status"].ToString();
                    objinvoiceRoot.context.List.Add(objList);
                }
                objinvoiceRoot.context.orgnId = objinvoice.orgnId;
                objinvoiceRoot.context.locnId = objinvoice.locnId;
                objinvoiceRoot.context.localeId = objinvoice.localeId;
                objinvoiceRoot.context.userId = objinvoice.userId;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objinvoice.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objinvoiceRoot;
        }
    }
}
