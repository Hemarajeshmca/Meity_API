using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
   public class ICDMOB_PAYTMModel
    {
        #region generate and save oderid 
        public class ICDMOBPO_Order
        {
            public int IOU_po_rowid { get; set; }
            public string In_PO_Orderid { get; set; }
            public string In_orgn_code { get; set; }
            public string In_invoice_no { get; set; }
            public string In_channel { get; set; }
            public string In_po_date { get; set; }
            public string In_invoice_amount { get; set; }
            public string In_mode_flag { get; set; }
    
        }
        public class ICDMOBPOORDERContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public ICDMOBPO_Order Header { get; set; }
        }

        public class ICDMOPOORDERDocument
        {
            public ICDMOBPOORDERContext context { get; set; }
            public ICDMOBApplicationException ApplicationException { get; set; }
        }

        public class ICDMOPOORDERRoot
        {
            public ICDMOPOORDERDocument document { get; set; }
        }
        public class ICDMOBApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }

        #endregion

        #region save PaytmHistory
        public class ICDMOBPTMHIS
        {


            public int IOU_pth_rowid { get; set; }
            public string In_merchantId { get; set; }
            public string In_orderId { get; set; }
            public string In_txnId { get; set; }
            public string In_authCode { get; set; }
            public string In_txnDate { get; set; }
            public string In_rrn { get; set; }
            public string In_cardNo { get; set; }
            public string In_issuingBank { get; set; }
            public string In_amount { get; set; }
            public string In_txnType { get; set; }
            public string In_invoiceNumber { get; set; }
            public string In_extendInfo { get; set; }
            public string In_printInfo { get; set; }
            public string In_tid { get; set; }
            public string In_aid { get; set; }
            public string In_payMethod { get; set; }
            public string In_cardType { get; set; }
            public string In_cardScheme { get; set; }
            public string In_bankResponseCode { get; set; }

            public string In_bankMid { get; set; }
            public string In_bankTid { get; set; }
            public string In_productManufacturer { get; set; }
            public string In_productCategory { get; set; }
            public string In_productSerialNoType { get; set; }
            public string In_productSerialNoValue { get; set; }
            public string In_productName { get; set; }
            public string In_emiTxnType { get; set; }
            public string In_emiTenure { get; set; }

            public string In_emiInterestRate { get; set; }
            public string In_emiMonthlyAmount { get; set; }
            public string In_emiTotalAmount { get; set; }
            public string In_bankOfferApplied { get; set; }
            public string In_bankOfferType { get; set; }
            public string In_bankOfferAmount { get; set; }
            public string In_subventionCreated { get; set; }
            public string In_subventionType { get; set; }
            public string In_subventionOfferAmount { get; set; }
            public string In_acquiringBank { get; set; }
            public string In_virtualPaymentAddress { get; set; }
            public string In_statusCode { get; set; }
            public string In_statusMessage { get; set; }
            public string In_mode_flag { get; set; }
          
        }
        public class ICDMOBPTMHISContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public ICDMOBPTMHIS Header { get; set; }
        }

        public class ICDMOBPTMHISDocument
        {
            public ICDMOBPTMHISContext context { get; set; }
        }

        public class ICDMOBPTMHISRoot
        {
            public ICDMOBPTMHISDocument document { get; set; }
        }


        #endregion

        #region fetch
    
        public class Invoicepatmfetchlist
        {
       
            public string In_fpo_code { get; set; }
            public string In_Order_Id { get; set; }
            public string In_invoice_no { get; set; }
            public string In_invoice_date { get; set; }
            public string In_paid_date { get; set; }
            public string In_invoice_amount { get; set; }
            public string In_paid_amount { get; set; }
            public string In_balance_amount { get; set; }
            public string In_status_code { get; set; }
          
        
        }
        public class ICDInvoicePaymentContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public string orgn_code { get; set; }
            public string status_code { get; set; }
            public string invoice_date { get; set; }
            public IList<Invoicepatmfetchlist> List { get; set; }


        }
        public class FApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class ICDInvoicePaytmApplication
        {
            public ICDInvoicePaymentContext context { get; set; }
            public FApplicationException ApplicationException { get; set; }

        }
        #endregion
    }
}
