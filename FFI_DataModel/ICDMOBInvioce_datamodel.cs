using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using static FFI_Model.ICDMOBInvoice_model;

namespace FFI_DataModel
{
    public class ICDMOBInvioce_datamodel
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInvoice_DataModel)); //Declaring Log4Net. 
        string methodName = MethodBase.GetCurrentMethod().Name;
        string In_invoice_no1 = "";
        int IOU_invoice_rowid1 = 0;
        public ICDMOBIDocument SaveinvoiceNew(ICDMOBIRoot ObjFarmer, string mysqlcon)
        {
            int ret = 0;
            string errorNo = "";
            string errorMsg = "";
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            ICDMOBIDocument objsinvoice = new ICDMOBIDocument();
            objsinvoice.context = new ICDMOBIContext();
            objsinvoice.context.Header = new ICDMOBIHeader();           
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
                cmd.Parameters.Add("In_transport_amount", MySqlDbType.Double).Value = Convert.ToDouble(ObjFarmer.document.context.Header.In_transport_amount);
                cmd.Parameters.Add("In_others", MySqlDbType.Double).Value = Convert.ToDouble(ObjFarmer.document.context.Header.In_others);
                cmd.Parameters.Add("In_phone_no", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_phone_no;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.localeId;
                cmd.Parameters.Add("IOU_invoice_rowid", MySqlDbType.Int32).Value = Convert.ToInt32(ObjFarmer.document.context.Header.IOU_invoice_rowid);

                cmd.Parameters.Add(new MySqlParameter("IOU_invoice_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_invoice_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                //LogHelper.ConvertCmdIntoString(cmd);
                if (ret > 0)
                {
                    IOU_invoice_rowid1 = (Int32)cmd.Parameters["IOU_invoice_rowid1"].Value;
                    In_invoice_no1 = (string)cmd.Parameters["In_invoice_no1"].Value;
                    objsinvoice.context.Header.IOU_invoice_rowid = Convert.ToString(IOU_invoice_rowid1);
                    objsinvoice.context.Header.In_invoice_no = In_invoice_no1;

                }
                else
                {
                    errorNo = (string)cmd.Parameters["errorNo"].Value;
                    errorMsg = ObjErrormsg.ErrorMessage(errorNo);
                    mysqltrans.Rollback();
                    objsinvoice.context.Header.errorNo = errorMsg;
                    return objsinvoice;
                }
                string[] result = { errorNo, errorMsg };
                if (IOU_invoice_rowid1 > 0)
                {
                    string resultinvdetail = "";
                    resultinvdetail = SaveInvoiceDetail(ObjFarmer, objsinvoice, mysqlcon, MysqlCon);
                    if (resultinvdetail != "")
                    {
                        errorNo = resultinvdetail;
                        errorMsg = resultinvdetail;
                        mysqltrans.Rollback();
                        objsinvoice.context.Header.IOU_invoice_rowid = "0";
                        objsinvoice.context.Header.In_invoice_no = "0";
                        objsinvoice.context.Header.errorNo = errorMsg;
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
        public string SaveInvoiceDetail(ICDMOBIRoot Objmodel, ICDMOBIDocument objInvoice, string MysqlCons, DataConnection MysqlCon)
        {
            string result = "";
            string errorNo = "";
            DataTable tab = new DataTable();
            ICDMOBIInvoiceDetail objinvdtl = new ICDMOBIInvoiceDetail();
            try
            {
                ICDMOBInvioce_datamodel objproduct1 = new ICDMOBInvioce_datamodel();
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
                    if (InvoiceDetail.In_discount_amount == "") { objinvdtl.In_discount_amount = "0"; } 
                    else { objinvdtl.In_discount_amount = InvoiceDetail.In_discount_amount; }
                    if (InvoiceDetail.In_tax_amount == "") { objinvdtl.In_tax_amount = "0"; }
                    else { objinvdtl.In_tax_amount = InvoiceDetail.In_tax_amount; }
                    objinvdtl.In_net_amount = InvoiceDetail.In_net_amount;
                    objinvdtl.In_status_code = InvoiceDetail.In_status_code;
                    objinvdtl.In_mode_flag = InvoiceDetail.In_mode_flag;
                    errorNo = objproduct1.SaveInvoiceDetailNew(objinvdtl, objInvoice, Objmodel, MysqlCons, MysqlCon);
                    if (errorNo != "")
                    {
                        break;
                    }
                    else 
                    {
                        ICDMOBIInvoiceDetailSlno objdtlslno = new ICDMOBIInvoiceDetailSlno();
                        ICDMOBIInvoiceDetail ObjKycDtl = new ICDMOBIInvoiceDetail();

                        ICDMOBInvioce_datamodel objproduct2 = new ICDMOBInvioce_datamodel();
                        foreach (var InvoiceDetail1 in InvoiceDetail.Slnoinfo)
                        {
                            objdtlslno.In_invoiceslno_rowid = InvoiceDetail1.In_invoiceslno_rowid;
                            objdtlslno.In_invoicedtl_rowid = objinvdtl.In_invoicedtl_rowid;
                            objdtlslno.In_slno = InvoiceDetail1.In_slno;
                            objdtlslno.In_no_of_bags = InvoiceDetail1.In_no_of_bags;
                            objdtlslno.In_invoice_no = In_invoice_no1;
                            objdtlslno.In_product_code = InvoiceDetail.In_product_code;
                            //objdtlslno.In_status_code = InvoiceDetail1.In_status_code;
                            objdtlslno.In_mode_flag = InvoiceDetail1.In_mode_flag;
                            errorNo = objproduct2.SaveInvoiceDetailNewSlno(objdtlslno, objInvoice, Objmodel, MysqlCons, MysqlCon);
                        }
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

        public string SaveInvoiceDetailNew(ICDMOBIInvoiceDetail objinvdtl, ICDMOBIDocument ObjFarmer, ICDMOBIRoot Objmodel, string mysqlcons, DataConnection MysqlCon)
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
                if (ret > 0)
                {
                    IOU_invoice_rowid1 = (Int32)cmd.Parameters["IOU_invoicedtl_rowid1"].Value;
                    objinvdtl.In_invoicedtl_rowid = IOU_invoice_rowid1;
                }
                return errorNo;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return errorNo;
            }
        }
        public string SaveInvoiceDetailNewSlno(ICDMOBIInvoiceDetailSlno objinvdtlslno, ICDMOBIDocument ObjFarmer, ICDMOBIRoot Objmodel, string mysqlcons, DataConnection MysqlCon)
        {
            string errorNo = "";
            string errorMsg = "";
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("ICDMOB_iud_invoice_detailslno", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_invoiceslno_rowid", MySqlDbType.Int32).Value = Convert.ToInt32(objinvdtlslno.In_invoiceslno_rowid);
                cmd.Parameters.Add("In_invoicedtl_rowid", MySqlDbType.Int32).Value = objinvdtlslno.In_invoicedtl_rowid;
                cmd.Parameters.Add("In_slno", MySqlDbType.VarChar).Value = objinvdtlslno.In_slno;
                cmd.Parameters.Add("In_no_of_bags", MySqlDbType.VarChar).Value = objinvdtlslno.In_no_of_bags;
                cmd.Parameters.Add("In_invoice_no", MySqlDbType.VarChar).Value = objinvdtlslno.In_invoice_no;
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
        public ICDMOBIPDocument mobnewsavePaymentCollection_Db(ICDMOBIPRoot ObjFarmer, string mysqlcon)
        {
            int ret = 0;

            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            ICDMOBIPDocument objsinvoice = new ICDMOBIPDocument();
            objsinvoice.context = new ICDMOBIPContext();
            objsinvoice.context.Header = new ICDMOBIPHeader();            
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
                    objsinvoice.context.Header.IOU_invoice_rowid = Convert.ToString(IOU_invoice_rowid1);
                    objsinvoice.context.Header.IOU_invoice_no = IOU_invoice_no1;
                }
                if (Convert.ToInt32(objsinvoice.context.Header.IOU_invoice_rowid) > 0)
                {
                    string[] resultinvdetail = { };
                    resultinvdetail = SaveInvoicePaymentDetail(ObjFarmer, objsinvoice, mysqlcon, MysqlCon);
                    if (resultinvdetail[0].Contains("060"))
                    {
                        mysqltrans.Rollback();
                        objsinvoice.context.Header.IOU_invoice_rowid ="0";
                        objsinvoice.context.Header.IOU_invoice_no = "0";
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
        public string[] SaveInvoicePaymentDetail(ICDMOBIPRoot Objmodel, ICDMOBIPDocument objInvoice, string MysqlCons, DataConnection MysqlCon)
        {
            string[] result = { };
            string errorNo = "";
            string errorMsg = "";
            string[] resultinvdetail = new string[2];
            DataTable tab = new DataTable();
            ICDMOBIPDetail objinvdtl = new ICDMOBIPDetail();
            try
            {
                ICDMOBInvioce_datamodel objproduct1 = new ICDMOBInvioce_datamodel();
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

        public string[] SaveInvoicePaymentDetailNew(ICDMOBIPDetail objinvdtl, ICDMOBIPDocument ObjFarmer, ICDMOBIPRoot Objmodel, string mysqlcons, DataConnection MysqlCon)
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
    }
}
