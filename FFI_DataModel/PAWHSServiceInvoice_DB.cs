using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
   public class PAWHSServiceInvoice_DB
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSServiceInvoice_DB)); //Declaring Log4Net. 

        public PAWHSServiceInvoiceApplication Getallservice_invoice_DB(PAWHSServiceInvoiceContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();

            PAWHSServiceInvoiceApplication objinvoiceRoot = new PAWHSServiceInvoiceApplication();
            PAWHSServiceInvoice_DB objDataModel = new PAWHSServiceInvoice_DB();

            objinvoiceRoot.context = new PAWHSServiceInvoiceContext();
            objinvoiceRoot.context.List = new List<PAWHSServiceInvoiceList>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_service_invoice_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
                cmd.Parameters.Add("in_filterby_option", MySqlDbType.VarChar).Value = objinvoice.filterby_option;
                cmd.Parameters.Add("in_filterby_code", MySqlDbType.VarChar).Value = objinvoice.filterby_code;
                cmd.Parameters.Add("in_filterby_fromvalue", MySqlDbType.VarChar).Value = objinvoice.filterby_fromvalue;
                cmd.Parameters.Add("in_filterby_tovalue", MySqlDbType.VarChar).Value = objinvoice.filterby_tovalue;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PAWHSServiceInvoiceList objList = new PAWHSServiceInvoiceList();
                    objList.Out_invoce_rowid = Convert.ToInt32(dt.Rows[i]["Out_raise_invoce_rowid"]);
                    objList.Out_customer_name = dt.Rows[i]["Out_customer_name"].ToString();
                    objList.Out_invoice_no = dt.Rows[i]["Out_invoice_no"].ToString();
                    objList.Out_invoice_date = dt.Rows[i]["Out_invoice_date"].ToString();
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.Out_status_desc = dt.Rows[i]["Out_status_desc"].ToString();
                    objList.Out_row_timestamp = dt.Rows[i]["Out_row_timestamp"].ToString();
                    objinvoiceRoot.context.List.Add(objList);

                }
                objinvoiceRoot.context.orgnId = objinvoice.orgnId;
                objinvoiceRoot.context.locnId = objinvoice.locnId;
                objinvoiceRoot.context.localeId = objinvoice.localeId;
                objinvoiceRoot.context.userId = objinvoice.userId;
                objinvoiceRoot.context.filterby_code = objinvoice.filterby_code;
                objinvoiceRoot.context.filterby_fromvalue = objinvoice.filterby_fromvalue;
                objinvoiceRoot.context.filterby_option = objinvoice.filterby_option;
                objinvoiceRoot.context.filterby_tovalue = objinvoice.filterby_tovalue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objinvoiceRoot;
        }

        //Getservice_invoice_DB
        public PAWHSFSerInvoiceApplication Getservice_invoice_DB(PAWHSFSerInvoiceContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();

            MysqlCon = new DataConnection(mysqlcon);

            PAWHSFSerInvoiceApplication ObjinvRoot = new PAWHSFSerInvoiceApplication();
            PAWHSServiceInvoice_DB objDataModel = new PAWHSServiceInvoice_DB();

            DataTable InvoiceDetail = new DataTable();
            DataTable InvoiceTax = new DataTable();
            DataTable PaymentCollection = new DataTable();
            DataTable Header = new DataTable();

            ObjinvRoot.context = new PAWHSFSerInvoiceContext();
            ObjinvRoot.context.Header = new PAWHSFSerInvoiceHeader();
            ObjinvRoot.context.Header.InvoiceDetails = new List<PAWHSFSerInvoiceInvoiceDetails>();
            ObjinvRoot.context.Header.TaxDetails = new List<PAWHSFSerInvoiceTaxDetails>();

            try
            { 
            MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_service_invoice", MysqlCon.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
            cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
            cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
            cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
            cmd.Parameters.Add("IOU_invoice_rowid", MySqlDbType.Int32).Value = ObjContext.invoice_rowid;

            cmd.Parameters.Add(new MySqlParameter("In_fpo_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(new MySqlParameter("In_invoice_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(new MySqlParameter("In_invoice_no", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(new MySqlParameter("In_service_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(new MySqlParameter("In_customer_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(new MySqlParameter("In_customer_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(new MySqlParameter("In_customer_state", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(new MySqlParameter("In_provider_state", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
            cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
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
           //     PaymentCollection = ds.Tables[2];


                for (int i = 0; i < InvoiceDetail.Rows.Count; i++)
                {
                        PAWHSFSerInvoiceInvoiceDetails objInvList = new PAWHSFSerInvoiceInvoiceDetails();
                    objInvList.In_invoice_details_rowid = Convert.ToInt32(InvoiceDetail.Rows[i]["In_invoice_details_rowid"]);
                    objInvList.In_service_code = InvoiceDetail.Rows[i]["In_service_code"].ToString();
                    objInvList.In_service_desc = InvoiceDetail.Rows[i]["In_service_desc"].ToString(); 
                    objInvList.In_qty = Convert.ToInt32(InvoiceDetail.Rows[i]["In_qty"]);
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
                     PAWHSFSerInvoiceTaxDetails objInvtaxList = new PAWHSFSerInvoiceTaxDetails();
                    objInvtaxList.In_taxdetails_rowid = Convert.ToInt32(InvoiceTax.Rows[i]["In_taxdetails_rowid"]);
                    objInvtaxList.In_state = InvoiceTax.Rows[i]["In_state"].ToString();
                    objInvtaxList.In_hsn_code = InvoiceTax.Rows[i]["In_hsn_code"].ToString();
                    objInvtaxList.In_hsn_description = InvoiceTax.Rows[i]["In_hsn_description"].ToString();
                    objInvtaxList.In_tax_rate = Convert.ToDouble(InvoiceTax.Rows[i]["In_tax_rate"]);
                    objInvtaxList.In_taxable_amount = Convert.ToDouble(InvoiceTax.Rows[i]["In_taxable_amount"]);
                    objInvtaxList.In_tax_amount = Convert.ToDouble(InvoiceTax.Rows[i]["In_tax_amount"]);
                    objInvtaxList.In_cgst = Convert.ToDouble(InvoiceTax.Rows[i]["In_cgst"]);
                    objInvtaxList.In_sgst = Convert.ToDouble(InvoiceTax.Rows[i]["In_sgst"]);
                    objInvtaxList.In_igst = Convert.ToDouble(InvoiceTax.Rows[i]["In_igst"]);
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


        public PAWHSServiceInvoiceSDocument Savenew_service_invoice(PAWHSServiceInvoiceSApplication ObjFarmer, string mysqlcon)
        {
            int ret = 0;

            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            PAWHSServiceInvoiceSDocument objsinvoice = new PAWHSServiceInvoiceSDocument();
            objsinvoice.context = new PAWHSServiceInvoiceSContext();
            objsinvoice.context.Header = new PAWHSServiceInvoiceSHeader(); 
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
                MySqlCommand cmd = new MySqlCommand("PAWHS_insupd_service_invoice", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_fpo_name", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_fpo_name;
                cmd.Parameters.Add("In_invoice_date", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_invoice_date;
                cmd.Parameters.Add("In_customer_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_customer_code;
                cmd.Parameters.Add("In_customer_state", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_customer_state;
                cmd.Parameters.Add("In_provider_state", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_provider_state;
                cmd.Parameters.Add("In_output_field", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_output_field;
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
                    if (resultinvdetail == "")
                    {
                        resultinvdetail = SaveInvoiceTaxDetail(ObjFarmer, objsinvoice, mysqlcon, MysqlCon);
                        if (resultinvdetail != "")
                        {
                            mysqltrans.Rollback();
                            return objsinvoice;
                        }
                    }
                    else
                    {
                        mysqltrans.Rollback();
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


        public string SaveInvoiceDetail(PAWHSServiceInvoiceSApplication Objmodel, PAWHSServiceInvoiceSDocument objInvoice, string MysqlCons, DataConnection MysqlCon)
        {
            string result = "";
            string errorNo = "";
            DataTable tab = new DataTable();
            PAWHSServiceInvoiceSInvoiceDetails objinvdtl = new PAWHSServiceInvoiceSInvoiceDetails();
            try
            {
                PAWHSServiceInvoice_DB objproduct1 = new PAWHSServiceInvoice_DB();
                foreach (var InvoiceDetail in Objmodel.document.context.Header.InvoiceDetails)
                {
                    objinvdtl.In_invoice_details_rowid = InvoiceDetail.In_invoice_details_rowid;
                    objinvdtl.In_service_code = InvoiceDetail.In_service_code;
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
        public string SaveInvoiceDetailNew(PAWHSServiceInvoiceSInvoiceDetails objinvdtl, PAWHSServiceInvoiceSDocument ObjFarmer, PAWHSServiceInvoiceSApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {
            string errorNo = ""; 
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_iud_Serviceinvoice_details", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure; 

                cmd.Parameters.Add("IOU_invoice_no", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.IOU_invoice_no;
                cmd.Parameters.Add("In_invoice_details_rowid", MySqlDbType.Int32).Value = objinvdtl.In_invoice_details_rowid;
                cmd.Parameters.Add("In_item_code", MySqlDbType.VarChar).Value = objinvdtl.In_service_code; 
                //cmd.Parameters.Add("In_qty", MySqlDbType.Int32).Value = objinvdtl.In_qty;
                cmd.Parameters.Add("In_uom_code", MySqlDbType.VarChar).Value = objinvdtl.In_uom_code;
                cmd.Parameters.Add("In_rate", MySqlDbType.Double).Value = objinvdtl.In_rate;
                cmd.Parameters.Add("In_amount", MySqlDbType.Double).Value = objinvdtl.In_amount;
                cmd.Parameters.Add("In_discount", MySqlDbType.Double).Value = objinvdtl.In_discount;
                cmd.Parameters.Add("In_tax_amount", MySqlDbType.Double).Value = objinvdtl.In_tax_amount;
                cmd.Parameters.Add("In_net_amount", MySqlDbType.Double).Value = objinvdtl.In_net_amount;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = objinvdtl.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objinvdtl.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
         //       cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
         //       cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
         //       cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                if (ret == 0)
                {
                    errorNo = "Error"; 
                }
                return errorNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // --------------------

        public string SaveInvoiceTaxDetail(PAWHSServiceInvoiceSApplication Objmodel, PAWHSServiceInvoiceSDocument objInvoice, string MysqlCons, DataConnection MysqlCon)
        {
            string result = "";
            string errorNo = "";
            DataTable tab = new DataTable();
            PAWHSServiceInvoiceSTaxDetails objinvdtl = new PAWHSServiceInvoiceSTaxDetails();
            try
            {
                PAWHSServiceInvoice_DB objproduct1 = new PAWHSServiceInvoice_DB();
                foreach (var InvoiceDetail in Objmodel.document.context.Header.TaxDetails)
                {
                    objinvdtl.In_taxdetails_rowid = InvoiceDetail.In_taxdetails_rowid;
                    objinvdtl.In_state = InvoiceDetail.In_state;
                    objinvdtl.In_hsn_code = InvoiceDetail.In_hsn_code;
                    objinvdtl.In_cgst = InvoiceDetail.In_cgst;
                    objinvdtl.In_sgst = InvoiceDetail.In_sgst;
                    objinvdtl.In_igst = InvoiceDetail.In_igst;
                    objinvdtl.In_tax_rate = InvoiceDetail.In_tax_rate;
                    objinvdtl.In_tax_amount = InvoiceDetail.In_tax_amount;
                    objinvdtl.In_taxable_amount = InvoiceDetail.In_taxable_amount;
                    objinvdtl.In_status_code = InvoiceDetail.In_status_code;
                    objinvdtl.In_mode_flag = InvoiceDetail.In_mode_flag;
                    errorNo = objproduct1.SaveInvoiceTaxDetailNew(objinvdtl, objInvoice, Objmodel, MysqlCons, MysqlCon);
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
        public string SaveInvoiceTaxDetailNew(PAWHSServiceInvoiceSTaxDetails objinvdtl, PAWHSServiceInvoiceSDocument ObjFarmer, PAWHSServiceInvoiceSApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {
            string errorNo = "";
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_iud_service_tax_details", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;                 
                cmd.Parameters.Add("In_taxdetails_rowid", MySqlDbType.Int32).Value = objinvdtl.In_taxdetails_rowid;
                cmd.Parameters.Add("In_state", MySqlDbType.VarChar).Value = objinvdtl.In_state;
                cmd.Parameters.Add("In_hsn_code", MySqlDbType.VarChar).Value = objinvdtl.In_hsn_code; 
                cmd.Parameters.Add("In_cgst", MySqlDbType.Double).Value = objinvdtl.In_cgst;
                cmd.Parameters.Add("In_sgst", MySqlDbType.Double).Value = objinvdtl.In_sgst;
                cmd.Parameters.Add("In_igst", MySqlDbType.Double).Value = objinvdtl.In_igst;
                cmd.Parameters.Add("In_tax_rate", MySqlDbType.Double).Value = objinvdtl.In_tax_rate;
                cmd.Parameters.Add("In_taxable_amount", MySqlDbType.Double).Value = objinvdtl.In_taxable_amount;
                cmd.Parameters.Add("In_tax_amount", MySqlDbType.Double).Value = objinvdtl.In_tax_amount;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = objinvdtl.In_status_code;
                cmd.Parameters.Add("IOU_invoice_rowid", MySqlDbType.Int32).Value = ObjFarmer.context.Header.IOU_invoice_rowid;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objinvdtl.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId; 
                ret = cmd.ExecuteNonQuery();
                if (ret == 0)
                {
                    errorNo = "Error";
                }
                return errorNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
