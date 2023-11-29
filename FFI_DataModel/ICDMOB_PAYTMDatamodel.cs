using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using static FFI_Model.ICDMOB_PAYTMModel;

namespace FFI_DataModel
{
  public class ICDMOB_PAYTMDatamodel
    {
        
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInvoice_DataModel)); //Declaring Log4Net. 
        string methodName = MethodBase.GetCurrentMethod().Name;
        string In_PO_Orderid1 = "";
        int IOU_po_rowid1 = 0;
        public ICDMOPOORDERDocument SSavePO_OrderIDGenerateNew(ICDMOPOORDERRoot ObjFarmer, string mysqlcon)
        {
            int ret = 0;
            string errorNo = "";
            string errorMsg = "";
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            ICDMOPOORDERDocument objsinvoice = new ICDMOPOORDERDocument();
            objsinvoice.context = new ICDMOBPOORDERContext();
            objsinvoice.ApplicationException = new ICDMOBApplicationException();
            objsinvoice.context.Header = new ICDMOBPO_Order();
            Int32 IOU_po_rowid1 = 0;
            try
            {

                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                //string[] returnvalues = { };
                MySqlCommand cmd = new MySqlCommand("ICDMOB_OrderId_generation", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_orgn_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_orgn_code;
                cmd.Parameters.Add("In_invoice_no", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_invoice_no;
                cmd.Parameters.Add("In_channel", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_channel;
                cmd.Parameters.Add("In_po_date", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_po_date;
                cmd.Parameters.Add("In_invoice_amount", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_invoice_amount;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.localeId;
                cmd.Parameters.Add("IOU_po_rowid", MySqlDbType.Int32).Value = Convert.ToInt32(ObjFarmer.document.context.Header.IOU_po_rowid);

                cmd.Parameters.Add(new MySqlParameter("IOU_po_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_PO_Orderid1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_PO_Orderid", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                //LogHelper.ConvertCmdIntoString(cmd);
                if (ret > 0)
                {
                    
                    IOU_po_rowid1 = (Int32)cmd.Parameters["IOU_po_rowid1"].Value;
                    In_PO_Orderid1 = (string)cmd.Parameters["In_PO_Orderid"].Value;
                    objsinvoice.context.Header.IOU_po_rowid = IOU_po_rowid1;
                    objsinvoice.context.Header.In_PO_Orderid = In_PO_Orderid1;
    
 
                }
                else
                {
                    errorNo = (string)cmd.Parameters["errorNo"].Value;
                    errorMsg = ObjErrormsg.ErrorMessage(errorNo);
                    objsinvoice.ApplicationException.errorNumber = errorNo;
                    objsinvoice.ApplicationException.errorDescription = errorMsg;
                    mysqltrans.Rollback();
                    return objsinvoice;
                }
                string[] result = { errorNo, errorMsg };
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
        public ICDMOBPTMHISDocument SSavePayHisReponse_DB(ICDMOBPTMHISRoot ObjFarmer, string mysqlcon)
        {
            int ret = 0;
            string errorNo = "";
            string errorMsg = "";
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            ICDMOBPTMHISDocument objsinvoice = new ICDMOBPTMHISDocument();
            objsinvoice.context = new ICDMOBPTMHISContext();
            objsinvoice.context.Header = new ICDMOBPTMHIS();
            Int32 IOU_pth_rowid1 = 0;
            try
            {

                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                //string[] returnvalues = { };
                MySqlCommand cmd = new MySqlCommand("ICDMOB_insupd_paymenthistory", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_merchantId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_merchantId;
                cmd.Parameters.Add("In_orderId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_orderId;
                cmd.Parameters.Add("In_txnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_txnId;
                cmd.Parameters.Add("In_authCode", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_authCode;
                cmd.Parameters.Add("In_txnDate", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_txnDate;
                cmd.Parameters.Add("In_rrn", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_rrn;
                cmd.Parameters.Add("In_cardNo", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_cardNo;
                cmd.Parameters.Add("In_issuingBank", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_issuingBank;
                cmd.Parameters.Add("In_amount", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_amount;
                cmd.Parameters.Add("In_txnType", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_txnType;
                cmd.Parameters.Add("In_invoiceNumber", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_invoiceNumber;
                cmd.Parameters.Add("In_extendInfo", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_extendInfo;
                cmd.Parameters.Add("In_printInfo", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_printInfo;
                cmd.Parameters.Add("In_tid", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_tid;
                cmd.Parameters.Add("In_aid", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_aid;
                cmd.Parameters.Add("In_payMethod", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_payMethod;
                cmd.Parameters.Add("In_cardType", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_cardType;
                cmd.Parameters.Add("In_cardScheme", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_cardScheme;
                cmd.Parameters.Add("In_bankResponseCode", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_bankResponseCode;
                cmd.Parameters.Add("In_bankMid", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_bankMid;
                cmd.Parameters.Add("In_bankTid", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_bankTid;
                cmd.Parameters.Add("In_productManufacturer", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_productManufacturer;
                cmd.Parameters.Add("In_productCategory", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_productCategory;
                cmd.Parameters.Add("In_productSerialNoType", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_productSerialNoType;
                cmd.Parameters.Add("In_productSerialNoValue", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_productSerialNoValue;
                cmd.Parameters.Add("In_productName", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_productName;
                cmd.Parameters.Add("In_emiTxnType", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_emiTxnType;
                cmd.Parameters.Add("In_emiTenure", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_emiTenure;
                cmd.Parameters.Add("In_emiInterestRate", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_emiInterestRate;
                cmd.Parameters.Add("In_emiMonthlyAmount", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_emiMonthlyAmount;
                cmd.Parameters.Add("In_emiTotalAmount", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_emiTotalAmount;
                cmd.Parameters.Add("In_bankOfferApplied", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_bankOfferApplied;
                cmd.Parameters.Add("In_bankOfferType", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_bankOfferType;
                cmd.Parameters.Add("In_bankOfferAmount", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_bankOfferAmount;
                cmd.Parameters.Add("In_subventionCreated", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_subventionCreated;
                cmd.Parameters.Add("In_subventionType", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_subventionType;
                cmd.Parameters.Add("In_subventionOfferAmount", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_subventionOfferAmount;
                cmd.Parameters.Add("In_acquiringBank", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_acquiringBank;
                cmd.Parameters.Add("In_virtualPaymentAddress", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_virtualPaymentAddress;
                cmd.Parameters.Add("In_statusCode", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_statusCode;
                cmd.Parameters.Add("In_statusMessage", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_statusMessage;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.localeId;
                cmd.Parameters.Add("IOU_pth_rowid", MySqlDbType.Int32).Value = Convert.ToInt32(ObjFarmer.document.context.Header.IOU_pth_rowid);

                cmd.Parameters.Add(new MySqlParameter("IOU_pth_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                if (ret > 0)
                {

                    IOU_pth_rowid1 = (Int32)cmd.Parameters["IOU_pth_rowid1"].Value;
                    objsinvoice.context.Header.IOU_pth_rowid = IOU_pth_rowid1;
                     mysqltrans.Commit();
                }
                else
                {
                    errorNo = (string)cmd.Parameters["errorNo"].Value;
                    errorMsg = ObjErrormsg.ErrorMessage(errorNo);
                    mysqltrans.Rollback();

                }
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

        public ICDInvoicePaytmApplication GetICDInvoicepatymfetch(ICDInvoicePaymentContext ObjContext, string mysqlcon)
        {
            DataTable dt = new DataTable();
            ICDInvoicePaytmApplication ObjinvRoot = new ICDInvoicePaytmApplication();
            ICDMOB_PAYTMDatamodel objDataModel = new ICDMOB_PAYTMDatamodel();
            ObjinvRoot.context = new ICDInvoicePaymentContext();
            ObjinvRoot.context.List = new List<Invoicepatmfetchlist>();
            MysqlCon = new DataConnection(mysqlcon);

            try
            {
                MySqlCommand cmd = new MySqlCommand("Paytmonline_Paymentfetch", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("orgn_code", MySqlDbType.VarChar).Value = ObjContext.orgn_code;
                cmd.Parameters.Add("status_code", MySqlDbType.VarChar).Value = ObjContext.status_code;
                cmd.Parameters.Add("invoice_date", MySqlDbType.VarChar).Value = ObjContext.invoice_date;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);

                MysqlCon.con.Close();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Invoicepatmfetchlist objList = new Invoicepatmfetchlist();
                    objList.In_fpo_code = dt.Rows[i]["In_fpo_code"].ToString();
                    objList.In_Order_Id = dt.Rows[i]["In_Order_Id"].ToString();
                    objList.In_invoice_no = dt.Rows[i]["In_invoice_no"].ToString();
                    objList.In_invoice_date = dt.Rows[i]["In_invoice_date"].ToString();
                    objList.In_paid_date = dt.Rows[i]["In_paid_date"].ToString();
                    objList.In_invoice_amount = dt.Rows[i]["In_invoice_amount"].ToString();
                    objList.In_paid_amount = dt.Rows[i]["In_paid_amount"].ToString();
                    objList.In_balance_amount = dt.Rows[i]["In_balance_amount"].ToString();
                    objList.In_status_code = dt.Rows[i]["In_status_code"].ToString();

                    ObjinvRoot.context.List.Add(objList);
                }               
                ObjinvRoot.context.orgnId = ObjContext.orgnId;
                ObjinvRoot.context.locnId = ObjContext.locnId;
                ObjinvRoot.context.userId = ObjContext.userId;
                ObjinvRoot.context.localeId = ObjContext.localeId;
                ObjinvRoot.context.orgn_code = ObjContext.orgn_code;
                ObjinvRoot.context.status_code = ObjContext.status_code;
                ObjinvRoot.context.invoice_date = ObjContext.invoice_date;
               
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjinvRoot;
        }
    }
}
