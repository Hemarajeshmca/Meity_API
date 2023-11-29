using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace FFI_DataModel
{
   public class PAWHS_NEW_BookInvoice_datamodel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHS_NEW_BookInvoice_datamodel));
        string methodName = MethodBase.GetCurrentMethod().Name;
        public PAWHSBookInvoiceApplication GetAllnew_bookinvoiceList_DB(PAWHSBookInvoiceContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();
            PAWHSBookInvoiceApplication objinvoiceRoot = new PAWHSBookInvoiceApplication();
            PAWHSRaiseInvoice_DB objDataModel = new PAWHSRaiseInvoice_DB();

            objinvoiceRoot.context = new PAWHSBookInvoiceContext();
            objinvoiceRoot.context.List = new List<PAWHSBookInvoiceList>();
            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_fetch_book_invoice_list", MysqlCon.con);
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
                    PAWHSBookInvoiceList objList = new PAWHSBookInvoiceList();
                    objList.Out_Book_invoce_rowid = Convert.ToInt32(dt.Rows[i]["Out_Book_invoce_rowid"]);
                    objList.Out_invoice_no = dt.Rows[i]["Out_invoice_no"].ToString();
                    objList.Out_invoice_date = dt.Rows[i]["Out_invoice_date"].ToString();
                    objList.Out_po_id = dt.Rows[i]["Out_po_id"].ToString();
                    objList.Out_Buyer_name = dt.Rows[i]["Out_Buyer_name"].ToString();
                    objList.Out_Buyer_Location = dt.Rows[i]["Out_Buyer_Location"].ToString();
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.Out_status_desc = dt.Rows[i]["Out_status_desc"].ToString();
                    objList.Out_agg_code = dt.Rows[i]["Out_agg_code"].ToString();
                    objList.Out_agg_name = dt.Rows[i]["Out_agg_name"].ToString();
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

        public PAWHSBookInvoiceSDocument save_new_book_invoice_DB(PAWHSBookInvoiceSApplication objAG, string ConString)
        {
            string[] response = { };
            PAWHSBookInvoiceSDocument ObjFetch = new PAWHSBookInvoiceSDocument();
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            try
            {
                int ret = 0;
                int retdtls = 0;
                MysqlCon = new DataConnection(ConString);
                PAWHSBookInvoiceSContext objContext = new PAWHSBookInvoiceSContext();
                PAWHSBookInvoiceSHeader objOutHeader = new PAWHSBookInvoiceSHeader();
                ObjFetch.context = objContext;
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }
                
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_insupd_book_invoice", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("IOU_invoice_rowid", MySqlDbType.Int32).Value = objAG.document.context.Header.IOU_invoice_rowid;
                cmd.Parameters.Add("IOU_invoice_no", MySqlDbType.VarChar).Value = objAG.document.context.Header.IOU_invoice_no;
                cmd.Parameters.Add("In_agg_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_agg_code;
                cmd.Parameters.Add("In_invoice_date", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_invoice_date;
                cmd.Parameters.Add("In_po_ID", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_po_ID;
                cmd.Parameters.Add("In_Buyer_Location", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_Buyer_Location;
                cmd.Parameters.Add("In_provider_state", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_provider_state;               
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = objAG.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("In_tranport", MySqlDbType.Double).Value = objAG.document.context.Header.In_tranport;
                cmd.Parameters.Add("In_discount", MySqlDbType.Double).Value = objAG.document.context.Header.In_discount;
                cmd.Parameters.Add("In_net_amount", MySqlDbType.Double).Value = objAG.document.context.Header.In_net_amount;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objAG.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objAG.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objAG.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objAG.document.context.localeId;               
                cmd.Parameters.Add(new MySqlParameter("IOU_invoice_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_invoice_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                retdtls = cmd.ExecuteNonQuery();

                //Information Log Purpose Written Start 
                logger.Debug("SP Name  - Admin_PAWHS_insupd_aggr_reg");
                logger.Debug("Input Parameters" + objAG.document.context.orgnId + "," + objAG.document.context.locnId + "," + objAG.document.context.userId + "," + objAG.document.context.localeId);


                if (retdtls > 0)
                {
                    objOutHeader.IOU_invoice_rowid = (Int32)cmd.Parameters["IOU_invoice_rowid1"].Value;
                    objOutHeader.IOU_invoice_no = (string)cmd.Parameters["IOU_invoice_no1"].Value;
                }               
                objContext.Header = objOutHeader;              
                bool isvaild = true;
                if (objOutHeader.IOU_invoice_rowid > 0)
                {
                    foreach (var Details in objAG.document.context.Header.InvoiceDetails)
                    {
                        MySqlCommand cmds = new MySqlCommand("New_PAWHS_iud_book_invoice_details", MysqlCon.con);
                        cmds.CommandType = CommandType.StoredProcedure;
                        cmds.Parameters.Add("IOU_invoice_no", MySqlDbType.VarChar).Value = objOutHeader.IOU_invoice_no;
                        cmds.Parameters.Add("In_invoice_details_rowid", MySqlDbType.Int32).Value = Details.In_invoice_details_rowid;
                        cmds.Parameters.Add("In_item_code", MySqlDbType.VarChar).Value = Details.In_item_code;
                        cmds.Parameters.Add("In_item_desc", MySqlDbType.VarChar).Value = Details.In_item_desc;
                        cmds.Parameters.Add("In_item_name", MySqlDbType.VarChar).Value = Details.In_item_name;
                        cmds.Parameters.Add("In_type", MySqlDbType.VarChar).Value = Details.In_type;
                        cmds.Parameters.Add("In_qty", MySqlDbType.Double).Value = Details.In_qty;
                        cmds.Parameters.Add("In_uom_code", MySqlDbType.VarChar).Value = Details.In_uom_code;
                        cmds.Parameters.Add("In_rate", MySqlDbType.Double).Value = Details.In_rate;
                        cmds.Parameters.Add("In_amount", MySqlDbType.Double).Value = Details.In_amount;
                        cmds.Parameters.Add("In_tax_amount", MySqlDbType.Double).Value = Details.In_tax_amount;
                        cmds.Parameters.Add("In_net_amount", MySqlDbType.Double).Value = Details.In_net_amount;
                        cmds.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = Details.In_status_code;
                        cmds.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Details.In_mode_flag;
                        cmds.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objAG.document.context.orgnId;
                        cmds.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objAG.document.context.locnId;
                        cmds.Parameters.Add("userId", MySqlDbType.VarChar).Value = objAG.document.context.userId;
                        cmds.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objAG.document.context.localeId;
                        ret = cmds.ExecuteNonQuery();
                        if (ret == 0)
                        {
                            mysqltrans.Rollback();
                            isvaild = false;
                            break;
                        }
                    }
                    if (isvaild == true)
                    {
                        foreach (var Details in objAG.document.context.Header.TaxDetails)
                        {
                            MySqlCommand cmdb = new MySqlCommand("New_PAWHS_iud_invoiceTax", MysqlCon.con);
                            cmdb.CommandType = CommandType.StoredProcedure;
                            cmdb.Parameters.Add("In_bitax_rowid", MySqlDbType.Int32).Value = Details.In_bitax_rowid;
                            cmdb.Parameters.Add("IOU_invoice_no", MySqlDbType.VarChar).Value = objOutHeader.IOU_invoice_no;
                            cmdb.Parameters.Add("In_taxrate_rowid", MySqlDbType.Int32).Value = Details.In_taxrate_rowid;
                            cmdb.Parameters.Add("In_taxratedtl_rowid", MySqlDbType.Int32).Value = Details.In_taxratedtl_rowid;
                            cmdb.Parameters.Add("In_tax_sub_type", MySqlDbType.VarChar).Value = Details.In_tax_sub_type;
                            cmdb.Parameters.Add("In_taxable_amt", MySqlDbType.Double).Value = Details.In_taxable_amt;
                            cmdb.Parameters.Add("In_tax_rate", MySqlDbType.Double).Value = Details.In_tax_rate;
                            cmdb.Parameters.Add("In_tax_gst", MySqlDbType.Double).Value = Details.In_tax_gst;
                            cmdb.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Details.In_mode_flag;
                            cmdb.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objAG.document.context.orgnId;
                            cmdb.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objAG.document.context.locnId;
                            cmdb.Parameters.Add("userId", MySqlDbType.VarChar).Value = objAG.document.context.userId;
                            cmdb.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objAG.document.context.localeId;
                            ret = cmdb.ExecuteNonQuery();
                            if (ret == 0)
                            {
                                mysqltrans.Rollback();
                                isvaild = false;
                                break;
                            }
                        }
                    }
                    //if (isvaild == true)
                    //{
                    //    foreach (var Details in objAG.document.context.Header.othercost)
                    //    {
                    //        MySqlCommand cmdb = new MySqlCommand("New_PAWHS_iud_book_invoice_othercost", MysqlCon.con);
                    //        cmdb.CommandType = CommandType.StoredProcedure;
                    //        cmdb.Parameters.Add("IOU_invoice_no", MySqlDbType.VarChar).Value = objOutHeader.IOU_invoice_no;
                    //        cmdb.Parameters.Add("In_othercostdtl_rowid", MySqlDbType.Int32).Value = Details.In_othercostdtl_rowid;
                    //        cmdb.Parameters.Add("In_cost_type", MySqlDbType.VarChar).Value = Details.In_cost_type;
                    //        cmdb.Parameters.Add("In_othercost_amt", MySqlDbType.Double).Value = Details.In_othercost_amt;                            
                    //        cmdb.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Details.In_mode_flag; 
                    //        cmdb.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objAG.document.context.orgnId;
                    //        cmdb.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objAG.document.context.locnId;
                    //        cmdb.Parameters.Add("userId", MySqlDbType.VarChar).Value = objAG.document.context.userId;
                    //        cmdb.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objAG.document.context.localeId;                           
                    //        ret = cmdb.ExecuteNonQuery();
                    //        if (ret == 0)
                    //        {
                    //            mysqltrans.Rollback();
                    //            isvaild = false;
                    //            break;
                    //        }
                    //    }
                    //}
                    //if (isvaild == true)
                    //{
                    //    foreach (var Details in objAG.document.context.Header.transport)
                    //    {
                    //        MySqlCommand cmdf = new MySqlCommand("New_PAWHS_iud_book_invoice_transport", MysqlCon.con);
                    //        cmdf.CommandType = CommandType.StoredProcedure;
                    //        cmdf.Parameters.Add("IOU_invoice_no", MySqlDbType.VarChar).Value = objOutHeader.IOU_invoice_no;
                    //        cmdf.Parameters.Add("In_transdtl_rowid", MySqlDbType.Int32).Value = Details.In_transdtl_rowid;
                    //        cmdf.Parameters.Add("In_vehicle_no", MySqlDbType.VarChar).Value = Details.In_vehicle_no;
                    //        cmdf.Parameters.Add("In_vehicle_weight", MySqlDbType.VarChar).Value = Details.In_vehicle_weight;
                    //        cmdf.Parameters.Add("In_prodcut_code", MySqlDbType.VarChar).Value = Details.In_prodcut_code;
                    //        cmdf.Parameters.Add("In_prodcut_qty", MySqlDbType.Double).Value = Details.In_prodcut_qty;
                    //        cmdf.Parameters.Add("In_no_of_bags", MySqlDbType.VarChar).Value = Details.In_no_of_bags;
                    //        cmdf.Parameters.Add("In_location", MySqlDbType.VarChar).Value = Details.In_location;
                    //        cmdf.Parameters.Add("In_sl_no", MySqlDbType.Int32).Value = Details.In_sl_no;
                    //        cmdf.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Details.In_mode_flag;

                    //        cmdf.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objAG.document.context.orgnId;
                    //        cmdf.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objAG.document.context.locnId;
                    //        cmdf.Parameters.Add("userId", MySqlDbType.VarChar).Value = objAG.document.context.userId;
                    //        cmdf.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objAG.document.context.localeId;
                    //        cmdf.Parameters.Add(new MySqlParameter("In_transdtl_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                    //        string Reponse2 = LogHelper.ConvertObjectIntoString(Details);
                    //        logger.Debug("Input Parameters -" + Reponse2);
                    //        ret = cmdf.ExecuteNonQuery();
                    //        int transdtl_rowid = 0;
                    //        if (ret > 0)
                    //        {
                    //            transdtl_rowid = (Int32)cmdf.Parameters["In_transdtl_rowid1"].Value;
                    //        }
                    //        foreach (var Details1 in Details.transportslno)
                    //        {
                    //            MySqlCommand cmdg = new MySqlCommand("New_PAWHS_iud_invoice_transportslnodtl", MysqlCon.con);
                    //            cmdg.CommandType = CommandType.StoredProcedure;
                    //            cmdg.Parameters.Add("In_slno_rowid", MySqlDbType.Int32).Value = Details1.In_slno_rowid;
                    //            cmdg.Parameters.Add("IOU_invoice_no", MySqlDbType.VarChar).Value = objOutHeader.IOU_invoice_no;
                    //            cmdg.Parameters.Add("In_sl_no", MySqlDbType.VarChar).Value = Details1.In_sl_no;
                    //            cmdg.Parameters.Add("In_sl_qty", MySqlDbType.Double).Value = Details1.In_sl_qty;
                    //            cmdg.Parameters.Add("In_UOM", MySqlDbType.VarChar).Value = Details1.In_UOM;
                    //            cmdg.Parameters.Add("In_transdtl_rowid", MySqlDbType.Int32).Value = transdtl_rowid;
                    //            cmdg.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Details.In_mode_flag;
                    //            cmdg.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objAG.document.context.orgnId;
                    //            cmdg.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objAG.document.context.locnId;
                    //            cmdg.Parameters.Add("userId", MySqlDbType.VarChar).Value = objAG.document.context.userId;
                    //            cmdg.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objAG.document.context.localeId;
                    //            ret = cmdg.ExecuteNonQuery();
                    //        }
                    //    }
                    //}
                    if (isvaild == true)
                    {
                        mysqltrans.Commit();
                    }                   
                }
                else
                {
                    mysqltrans.Rollback();
                }
                if (MysqlCon.con.State == ConnectionState.Open)
                {
                    MysqlCon.con.Close();
                }
                
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                throw (ex);
            }
            return ObjFetch;

        }

        public PAWHSBookInvoiceFApplication Single_new_new_book_invoice_DB(PAWHSBookInvoiceFContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();

            MysqlCon = new DataConnection(mysqlcon);

            PAWHSBookInvoiceFApplication ObjinvRoot = new PAWHSBookInvoiceFApplication();
            PAWHSRaiseInvoice_DB objDataModel = new PAWHSRaiseInvoice_DB();

            DataTable InvoiceDetail = new DataTable();
            DataTable InvoiceTax = new DataTable();
            DataTable othercost = new DataTable();
            DataTable transport = new DataTable();
            DataTable Header = new DataTable();

            ObjinvRoot.context = new PAWHSBookInvoiceFContext();
            ObjinvRoot.context.Header = new PAWHSBookInvoiceFHeader();
            ObjinvRoot.context.Header.InvoiceDetails = new List<PAWHSBookInvoiceFInvoiceDetails>();
            ObjinvRoot.context.Header.TaxDetails = new List<PAWHSBookInvoiceFTaxDetails>();
            ObjinvRoot.context.Header.othercost = new List<PAWHSBookInvoiceFothercost>();
            ObjinvRoot.context.Header.transport = new List<PAWHSBookInvoiceFtransport>();

            try
            {

                MySqlCommand cmd = new MySqlCommand("New_PAWHS_fetch_book_invoice", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("IOU_invoice_rowid", MySqlDbType.Int32).Value = ObjContext.IOU_invoice_rowid;
               
                cmd.Parameters.Add(new MySqlParameter("In_invoice_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_invoice_no", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_buyer_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_buyer_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_po_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_po_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_Transport_Amt", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_Discount_Amt", MySqlDbType.Double)).Direction = ParameterDirection.Output;              
                cmd.Parameters.Add(new MySqlParameter("In_net_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_bal_amount", MySqlDbType.Double)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_customer_state", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_provider_state", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_agg_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_agg_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_invoice_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();

                if (ds.Tables.Count > 0)
                {
                    InvoiceDetail = ds.Tables[0];
                    InvoiceTax = ds.Tables[1];
                    othercost = ds.Tables[2];
                    transport = ds.Tables[3];

                    for (int i = 0; i < InvoiceDetail.Rows.Count; i++)
                    {
                        PAWHSBookInvoiceFInvoiceDetails objInvList = new PAWHSBookInvoiceFInvoiceDetails();
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
                        objInvList.In_tax_amount = Convert.ToDouble(InvoiceDetail.Rows[i]["In_tax_amount"]);
                        objInvList.In_net_amount = Convert.ToDouble(InvoiceDetail.Rows[i]["In_net_amount"]);                       
                        objInvList.In_mode_flag = InvoiceDetail.Rows[i]["In_mode_flag"].ToString();
                        objInvList.In_current_qty = Convert.ToDouble(InvoiceDetail.Rows[i]["In_current_qty"]);
                        objInvList.In_discount = Convert.ToDouble(InvoiceDetail.Rows[i]["In_discount"]);
                        objInvList.In_others = InvoiceDetail.Rows[i]["In_others"].ToString();
                        ObjinvRoot.context.Header.InvoiceDetails.Add(objInvList);
                    }
                    for (int i = 0; i < InvoiceTax.Rows.Count; i++)
                    {
                        PAWHSBookInvoiceFTaxDetails objInvtaxList = new PAWHSBookInvoiceFTaxDetails();
                        objInvtaxList.In_taxdetails_rowid = Convert.ToInt32(InvoiceTax.Rows[i]["In_taxdetails_rowid"]);
                        objInvtaxList.In_product_code = InvoiceTax.Rows[i]["In_Product_Code"].ToString();
                        objInvtaxList.In_product_name = InvoiceTax.Rows[i]["In_product_name"].ToString();
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
                    for (int i = 0; i < othercost.Rows.Count; i++)                 
                    {
                        PAWHSBookInvoiceFothercost objothercost = new PAWHSBookInvoiceFothercost();
                        objothercost.In_othercost_rowid = Convert.ToInt32(othercost.Rows[i]["In_othercost_rowid"].ToString());
                        objothercost.In_cost_type = othercost.Rows[i]["In_cost_type"].ToString();
                        objothercost.In_cost_name = othercost.Rows[i]["In_cost_name"].ToString();
                        objothercost.In_cost_value = Convert.ToDouble(othercost.Rows[i]["In_cost_value"].ToString());
                        objothercost.In_mode_flag = othercost.Rows[i]["In_mode_flag"].ToString();
                        ObjinvRoot.context.Header.othercost.Add(objothercost);
                    }
                    for (int i = 0; i < transport.Rows.Count; i++)
                    {
                        PAWHSBookInvoiceFtransport objtransport = new PAWHSBookInvoiceFtransport();
                        objtransport.In_transdtl_rowid = Convert.ToInt32(transport.Rows[i]["In_transdtl_rowid"]);
                        objtransport.In_vehicle_no = transport.Rows[i]["In_vehicle_no"].ToString();
                        objtransport.In_vehicle_weight = transport.Rows[i]["In_vehicle_weight"].ToString();
                        objtransport.In_prodcut_code = transport.Rows[i]["In_prodcut_code"].ToString();
                        objtransport.In_prodcut_qty = Convert.ToDouble(transport.Rows[i]["In_prodcut_qty"]);
                        objtransport.In_no_of_bags = Convert.ToInt32(transport.Rows[i]["In_no_of_bags"]);
                        objtransport.In_sl_no = Convert.ToInt32(transport.Rows[i]["In_sl_no"]);
                        objtransport.In_location = transport.Rows[i]["In_location"].ToString();                        
                        objtransport.In_mode_flag = transport.Rows[i]["In_mode_flag"].ToString();
                        ObjinvRoot.context.Header.transport.Add(objtransport);
                    }
                }
                ObjinvRoot.context.orgnId = ObjContext.orgnId;
                ObjinvRoot.context.locnId = ObjContext.locnId;
                ObjinvRoot.context.userId = ObjContext.userId;
                ObjinvRoot.context.localeId = ObjContext.localeId;

                ObjinvRoot.context.Header.IOU_invoice_rowid = (Int32)cmd.Parameters["IOU_invoice_rowid"].Value;
                ObjinvRoot.context.Header.In_agg_name = (string)cmd.Parameters["In_agg_name"].Value.ToString();
                ObjinvRoot.context.Header.In_agg_code = (string)cmd.Parameters["In_agg_code"].Value.ToString();
                ObjinvRoot.context.Header.In_invoice_date = (string)cmd.Parameters["In_invoice_date"].Value.ToString();
                ObjinvRoot.context.Header.In_invoice_no = (string)cmd.Parameters["In_invoice_no"].Value.ToString();
                ObjinvRoot.context.Header.In_buyer_code = (string)cmd.Parameters["In_buyer_code"].Value.ToString();
                ObjinvRoot.context.Header.In_buyer_name = (string)cmd.Parameters["In_buyer_name"].Value.ToString();
                ObjinvRoot.context.Header.In_po_no = (string)cmd.Parameters["In_po_no"].Value.ToString();
                ObjinvRoot.context.Header.In_po_date = (string)cmd.Parameters["In_po_date"].Value.ToString();
                ObjinvRoot.context.Header.In_Transport_Amt = (double)cmd.Parameters["In_Transport_Amt"].Value;
                ObjinvRoot.context.Header.In_Discount_Amt = (double)cmd.Parameters["In_Discount_Amt"].Value;
                ObjinvRoot.context.Header.In_bal_amount = (double)cmd.Parameters["In_bal_amount"].Value;
                ObjinvRoot.context.Header.In_net_amount = (double)cmd.Parameters["In_net_amount"].Value;
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
        public PAWHSBookInvoicenewProductApplication Getproductsearch_DB(PAWHSBookInvoicenewProductContext objproductSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();

            PAWHSBookInvoicenewProductApplication objproductSearchRoot = new PAWHSBookInvoicenewProductApplication();
            PAWHS_NEW_BookInvoice_datamodel objDataModel = new PAWHS_NEW_BookInvoice_datamodel();

            DataTable Detail = new DataTable();
            DataTable InvoiceTax = new DataTable();
            DataTable dtOthercost = new DataTable();

            objproductSearchRoot.context = new PAWHSBookInvoicenewProductContext();           
            objproductSearchRoot.context.Detail = new List<PAWHSBookInvoicenewProductDetail>();
            objproductSearchRoot.context.InvoiceTax = new List<PAWHSBookInvoicenewInvoiceTax>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("New_PAWHS_fetch_batchproductsearch", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objproductSearch.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objproductSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objproductSearch.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objproductSearch.localeId;
                cmd.Parameters.Add("In_location_code", MySqlDbType.VarChar).Value = objproductSearch.In_location_code;
                cmd.Parameters.Add("In_batch_no", MySqlDbType.VarChar).Value = objproductSearch.In_po_no;               
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();
               
                if (ds.Tables.Count > 0)
                {
                    Detail = ds.Tables[0];
                    InvoiceTax = ds.Tables[1];
                    dtOthercost = ds.Tables[2];
                    for (int i = 0; i < Detail.Rows.Count; i++)
                    {
                        PAWHSBookInvoicenewProductDetail objDetailList = new PAWHSBookInvoicenewProductDetail();
                        objDetailList.In_ic_code = Detail.Rows[i]["In_ic_code"].ToString();
                        objDetailList.In_product_code = Detail.Rows[i]["In_product_code"].ToString();
                        objDetailList.In_product_name = Detail.Rows[i]["In_product_name"].ToString();
                        objDetailList.In_uomtype_code = Detail.Rows[i]["In_uomtype_code"].ToString();
                        objDetailList.In_uomtype_desc = Detail.Rows[i]["In_uomtype_desc"].ToString();
                        objDetailList.In_qty = Detail.Rows[i]["In_qty"].ToString();
                        objDetailList.In_rate = Detail.Rows[i]["In_rate"].ToString();
                        objDetailList.In_amount = Detail.Rows[i]["In_amount"].ToString();
                        objDetailList.In_tax_amount = Detail.Rows[i]["In_tax_amount"].ToString();
                        objDetailList.In_net_amount = Convert.ToDouble(Detail.Rows[i]["In_net_amount"]);
                        objDetailList.In_discount = Detail.Rows[i]["In_discount"].ToString();
                        objDetailList.In_others = Detail.Rows[i]["In_others"].ToString();
                        objproductSearchRoot.context.Detail.Add(objDetailList);
                    }
                    for (int i = 0; i < InvoiceTax.Rows.Count; i++)
                    {
                        PAWHSBookInvoicenewInvoiceTax objPInvoiceTaxList = new PAWHSBookInvoicenewInvoiceTax();
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
                    List<BIBatchOtherDetails> objFetchBatchOtherDtls = new List<BIBatchOtherDetails>();
                    for (int i = 0; i < dtOthercost.Rows.Count; i++)
                    {
                        BIBatchOtherDetails objFetch = new BIBatchOtherDetails();
                        objFetch.In_othercost_rowid = Convert.ToInt32(dtOthercost.Rows[i]["In_othercost_rowid"].ToString());
                        objFetch.In_cost_type = dtOthercost.Rows[i]["In_cost_type"].ToString();
                        objFetch.In_cost_name = dtOthercost.Rows[i]["In_cost_name"].ToString();
                        objFetch.In_cost_value = Convert.ToDouble(dtOthercost.Rows[i]["In_cost_value"]);
                        objFetch.In_mode_flag = dtOthercost.Rows[i]["In_mode_flag"].ToString();
                        objFetchBatchOtherDtls.Add(objFetch);
                    }
                    objproductSearchRoot.context.OtherDtl = objFetchBatchOtherDtls;
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objproductSearchRoot;
        }
        public POLocApplication Getpolocationsearch_DB(POLocContext objproductSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();

            POLocApplication objproductSearchRoot = new POLocApplication();
            PAWHS_NEW_BookInvoice_datamodel objDataModel = new PAWHS_NEW_BookInvoice_datamodel();

            DataTable Detail = new DataTable();
            DataTable InvoiceTax = new DataTable();
            objproductSearchRoot.context = new POLocContext();
            objproductSearchRoot.context.Header = new PAWHSPO_FHeader();
            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("new_PAWHS_Poloactionsearch", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objproductSearch.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objproductSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objproductSearch.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objproductSearch.localeId;               
                cmd.Parameters.Add("In_batch_no", MySqlDbType.VarChar).Value = objproductSearch.In_po_no;
                cmd.Parameters.Add(new MySqlParameter("In_buyer_location", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_buyer_location_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_buyer_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();
               
                objproductSearchRoot.context.Header.In_buyer_location = (string)cmd.Parameters["In_buyer_location"].Value.ToString();
                objproductSearchRoot.context.Header.In_buyer_location_code = (string)cmd.Parameters["In_buyer_location_code"].Value.ToString();
                objproductSearchRoot.context.Header.In_buyer_date = (string)cmd.Parameters["In_buyer_date"].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objproductSearchRoot;
        }
        public PAWHSBookInvoiceFTRANS Gettransportslnofetch_DB(PAWHSBookInvoiceFTRANSContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();
            PAWHSBookInvoiceFTRANS objinvoiceRoot = new PAWHSBookInvoiceFTRANS();
            PAWHSRaiseInvoice_DB objDataModel = new PAWHSRaiseInvoice_DB();

            objinvoiceRoot.context = new PAWHSBookInvoiceFTRANSContext();
            objinvoiceRoot.context.transport = new List<PAWHSBookInvoiceFtransportslno>();
            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_Fetch_translno", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
                cmd.Parameters.Add("in_transdtl_rowid", MySqlDbType.VarChar).Value = objinvoice.In_transdtl_rowid;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PAWHSBookInvoiceFtransportslno objList = new PAWHSBookInvoiceFtransportslno();
                    objList.In_slno_rowid = Convert.ToInt32(dt.Rows[i]["In_slno_rowid"]);
                    objList.In_sl_no = dt.Rows[i]["In_sl_no"].ToString();
                    objList.In_sl_qty = dt.Rows[i]["In_sl_qty"].ToString();
                    objList.In_mode_flag = dt.Rows[i]["In_mode_flag"].ToString();                   
                    objinvoiceRoot.context.transport.Add(objList);
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
        public ICDInvoicepayApplication GetPAWHSProductInvPayfetch_DB(ICDInvoicepayContext ObjContext, string mysqlcon)
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

                MySqlCommand cmd = new MySqlCommand("New_PAWHS_fetch_payment_collection_invoice", MysqlCon.con);
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
        public Document SavePAWHSinvoicepayment_DB(PSApplication ObjFarmer, string mysqlcon)
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
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_insupd_invoice_payment", MysqlCon.con);
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
                }
                objsinvoice.context.Header.IOU_invoice_rowid = Convert.ToInt32(IOU_invoice_rowid1);
                objsinvoice.context.Header.IOU_invoice_no = IOU_invoice_no1;

                if (objsinvoice.context.Header.IOU_invoice_rowid > 0)
                {
                    foreach (var objinvdtl in ObjFarmer.document.context.Detail)
                    {
                        MySqlCommand cmds = new MySqlCommand("New_PAWHS_iud_invoice_payment_detail", MysqlCon.con);
                        cmds.CommandType = CommandType.StoredProcedure;
                        cmds.Parameters.Add("In_paymentcollection_rowid", MySqlDbType.Int32).Value = objinvdtl.In_paymentcollection_rowid;
                        cmds.Parameters.Add("In_payment_type", MySqlDbType.VarChar).Value = objinvdtl.In_payment_type;
                        cmds.Parameters.Add("In_payment_no", MySqlDbType.VarChar).Value = objinvdtl.In_payment_no;
                        cmds.Parameters.Add("In_balance_amount", MySqlDbType.Double).Value = objinvdtl.In_balance_amount;
                        cmds.Parameters.Add("In_payment_amount", MySqlDbType.Double).Value = objinvdtl.In_payment_amount;
                        cmds.Parameters.Add("In_payment_mode", MySqlDbType.VarChar).Value = objinvdtl.In_payment_mode;
                        cmds.Parameters.Add("In_ref_no", MySqlDbType.VarChar).Value = objinvdtl.In_ref_no;
                        cmds.Parameters.Add("In_payment_date", MySqlDbType.VarChar).Value = objinvdtl.In_payment_date;
                        cmds.Parameters.Add("In_process_status", MySqlDbType.VarChar).Value = objinvdtl.In_process_status;
                        cmds.Parameters.Add("In_paid_amount", MySqlDbType.Double).Value = objinvdtl.In_paid_amount;
                        cmds.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objinvdtl.In_mode_flag;
                        cmds.Parameters.Add("IOU_invoice_rowid", MySqlDbType.Int32).Value = ObjFarmer.document.context.Header.IOU_invoice_rowid;
                        cmds.Parameters.Add("IOU_invoice_no", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.IOU_invoice_no;
                        cmds.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.orgnId;
                        cmds.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.locnId;
                        cmds.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.userId;
                        cmds.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.localeId;
                        cmds.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                        ret = cmds.ExecuteNonQuery();
                      
                    }

                }
                string[] returnvalues = { IOU_invoice_rowid1 };

                mysqltrans.Commit();
                if (MysqlCon.con.State == ConnectionState.Open)
                {
                    MysqlCon.con.Close();
                }
                return objsinvoice;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                logger.Error("USERNAME :" + ObjFarmer.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return objsinvoice;
            }
        }
        
    }
}