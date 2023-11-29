using System;
using System.Collections.Generic;
using System.Text;

namespace FFI_Model
{
   public class LRS_FPOLoanModel
    {
        #region ListFPO
        public class LRSFpoLoanList
        {
            public int Out_fpoloan_rowid { get; set; }
            public string Out_fpoorgn_code { get; set; }
            public string Out_fpoloan_no { get; set; }
            public string Out_lending_institution { get; set; }
            public string Out_institution_type { get; set; }
            public string Out_institution_type_desc { get; set; }
            public string Out_sanctioned_date { get; set; }
            public string Out_fpoloan_start_date { get; set; }
            public string Out_fpoloan_mat_date { get; set; }
            public string Out_sanctioned_amount { get; set; }
            public string Out_received_amount { get; set; }
            public string Out_emi_amount { get; set; }
            public string Out_interest_rate { get; set; }
            public string Out_repayment_in_yrs { get; set; }
            public string Out_repayment_in_months { get; set; }
            public string Out_repayment_freq { get; set; }
            public string Out_repayment_freq_desc { get; set; }
            public string Out_collateral_type { get; set; }
            public string Out_collateral_type_desc { get; set; }
            public string Out_collateral_amount { get; set; }
            public string Out_payable_amount { get; set; }
            public string Out_payable_exception { get; set; }
            public string Out_interest_amount { get; set; }
            public string Out_interest_paid { get; set; }
            public string Out_refund_received { get; set; }
            public string Out_closed_date { get; set; }
            public string Out_settlement_amount { get; set; }
            public string Out_waive_amount { get; set; }
            public string Out_status_code { get; set; }
            public string Out_status_desc { get; set; }

        }
        public class LRSFpoLoanContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public IList<LRSFpoLoanList> List { get; set; }
            public string FilterBy_Option { get; set; }
            public string FilterBy_Code { get; set; }
            public string FilterBy_FromValue { get; set; }
            public string FilterBy_ToValue { get; set; }

        }
        public class LRSFpoLoanApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class LRSFpoLoanApplication
        {
            public LRSFpoLoanContext context { get; set; }
            public LRSFpoLoanApplicationException ApplicationException { get; set; }

        }

        #endregion

        #region Single fetch
    
        public class LRSFpoLoanFHeader
        {
            public int IOU_fpoloan_rowid { get; set; }
            public string In_fpoorgn_code { get; set; }
            public string In_fpoloan_no { get; set; }
            public string In_Institution_lending { get; set; }
            public string In_institution_type { get; set; }
            public string In_institution_type_desc { get; set; }
            public string In_sanctioned_date { get; set; }
            public string In_fpoloan_start_date { get; set; }
            public string In_fpoloan_mat_date { get; set; }
            public double In_Loan_amount { get; set; }
            public double In_received_amount { get; set; }
            public double In_emi_amount { get; set; }
            public double In_interest_rate { get; set; }
            public int In_repayment_in_yrs { get; set; }
            public int In_repayment_in_months { get; set; }
            public string In_repayment_freq { get; set; }
            public string In_repayment_freq_desc { get; set; }
            public string In_collateral_type { get; set; }
            public string In_collateral_type_desc { get; set; }
            public double In_collateral_amount { get; set; }
            public double In_payable_amount { get; set; }
            public string In_payable_exception { get; set; }
            public double In_interest_amount { get; set; }
            public double In_principle_paid { get; set; }
            public double In_interest_paid { get; set; }
            public double In_refund_received { get; set; }
            public string In_closed_date { get; set; }
            public double In_settlement_amount { get; set; }
            public double In_waive_amount { get; set; }
            public double In_lend_balance_amount { get; set; }
            public double In_balance_amount { get; set; }
            public string In_status_code { get; set; }
            public string In_status_desc { get; set; }
            public string In_mode_flag { get; set; }
            public string In_row_timestamp { get; set; }
            public IList<LRSFpoLoanTranche> LRSFPOLoanTranche { get; set; }
            public IList<LRSFpoLoanRepayment> LRSFPOLoanRepayment { get; set; }
        }

        public class LRSFpoLoanRepayment
        {

            public int In_loanrepayment_rowid { get; set; }
            public int In_loaninstalment_rowid { get; set; }
            public string In_fpoloan_no { get; set; }
            public string In_instalment_date { get; set; }
            public double In_instalment_amount { get; set; }
            public double In_principle_amount { get; set; }
            public double In_interest_amount { get; set; }
            public double In_penalty_amount { get; set; }
            public double In_waiver_amount { get; set; }
            public string In_paid_date { get; set; }
            public string In_payment_mode { get; set; }
            public string In_payment_mode_desc { get; set; }
            public string In_bank_code { get; set; }
            public string In_bank_acc_type { get; set; }
            public string In_bank_acc_type_desc { get; set; }
            public string In_bank_acc_no { get; set; }
            public string In_bank_ifsc_code { get; set; }
            public string In_bank_ref_no { get; set; }
            public string In_chq_date { get; set; }
            public string In_chq_no { get; set; }
            public string In_micr_code { get; set; }
            public string In_chq_valid_flag { get; set; }
            public string In_repayment_remark { get; set; }
            public string In_repayment_status { get; set; }
            public string In_repayment_status_desc { get; set; }
            public string In_instalment_no { get; set; }
            public double In_lend_balance_amount { get; set; }
            public string In_status_code { get; set; }
            public string In_status_desc { get; set; }
            public string In_row_timestamp { get; set; }
            public string In_mode_flag { get; set; }

        }
        public class LRSFpoLoanTranche
        {
            public int In_fpoloantranche_rowid { get; set; }
            public string In_fpoloan_no { get; set; }
            public string In_tranche_no { get; set; }
            public double In_tranche_amount { get; set; }
            public string In_received_date { get; set; }
            public string In_status_code { get; set; }
            public string In_status_desc { get; set; }
            public string In_row_timestamp { get; set; }
            public string In_mode_flag { get; set; }

        }
        public class LRSFpoLoanFContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public int IOU_fpoloan_rowid { get; set; }
            public string In_fpoloan_no { get; set; }
            public LRSFpoLoanFHeader Header { get; set; }
          


        }
        public class LRSFpoLoanFApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class LRSFpoLoanFApplication
        {
            public LRSFpoLoanFContext context { get; set; }
            public LRSFpoLoanFApplicationException ApplicationException { get; set; }

        }
        #endregion

        #region Save
        public class LRSSaveHeader
        {
            public int IOU_fpoloan_rowid { get; set; }
            public string In_fpoorgn_code { get; set; }
            public string In_fpoloan_no { get; set; }
            public string In_Institution_lending { get; set; }
            public string In_institution_type { get; set; }
            public string In_sanctioned_date { get; set; }
            public double In_Loan_amount { get; set; }
            public string In_repayment_freq { get; set; }
            public double In_interest_rate { get; set; }
            public int In_repayment_in_months { get; set; }
            public int In_repayment_in_yrs { get; set; }     
            public string In_collateral_type { get; set; }
            public double In_collateral_amount { get; set; }
            public string In_fpoloan_start_date { get; set; }
            public double In_received_amount { get; set; }
            public double In_principle_paid { get; set; }
            public double In_interest_paid { get; set; }
            public double In_princ_outstanding_amount { get; set; }
            public string In_status_code { get; set; }
            public string In_mode_flag { get; set; }
            public string In_row_timestamp { get; set; }

        }
        public class LRSSaveTranche
        {
            public int In_fpoloantranche_rowid { get; set; }
            public string In_fpoloan_no { get; set; }
            public string In_tranche_no { get; set; }
            public double In_tranche_amount { get; set; }
            public string In_received_date { get; set; }
            public string In_status_code { get; set; }
            public string In_status_desc { get; set; }
            public string In_row_timestamp { get; set; }
            public string In_mode_flag { get; set; }


        }
        public class LRSSaveRepayment
        {
            public int In_loanrepayment_rowid { get; set; }
            public int In_loaninstalment_rowid { get; set; }
            public string In_fpoloan_no { get; set; }
            public string In_instalment_date { get; set; }
            public double In_instalment_amount { get; set; }
            public double In_principle_amount { get; set; }
            public double In_interest_amount { get; set; }
            public double In_penalty_amount { get; set; }
            public double In_waiver_amount { get; set; }
            public string In_paid_date { get; set; }
            public string In_payment_mode { get; set; }
            public string In_payment_mode_desc { get; set; }
            public string In_bank_code { get; set; }
            public string In_bank_acc_type { get; set; }
            public string In_bank_acc_type_desc { get; set; }
            public string In_bank_acc_no { get; set; }
            public string In_bank_ifsc_code { get; set; }
            public string In_bank_ref_no { get; set; }
            public string In_chq_date { get; set; }
            public string In_chq_no { get; set; }
            public string In_micr_code { get; set; }
            public string In_chq_valid_flag { get; set; }
            public string In_repayment_remark { get; set; }
            public string In_repayment_status { get; set; }
            public string In_repayment_status_desc { get; set; }
            public string In_instalment_no { get; set; }
            public double In_lend_balance_amount { get; set; }
            public string In_status_code { get; set; }
            public string In_status_desc { get; set; }
            public string In_row_timestamp { get; set; }
            public string In_mode_flag { get; set; }


        }
        public class LRSSaveContext
        {
            public string orgnId { get; set; }
            public string locnId { get; set; }
            public string userId { get; set; }
            public string localeId { get; set; }
            public LRSSaveHeader Header { get; set; }
            public IList<LRSSaveTranche> Tranche { get; set; }
            public IList<LRSSaveRepayment> Repayment { get; set; }

        }
        public class LRSSaveDocument
        {
            public LRSSaveContext context { get; set; }
            public LRSSaveApplicationException ApplicationException { get; set; }
        }
        public class LRSSaveApplicationException
        {
            public string errorNumber { get; set; }
            public string errorDescription { get; set; }

        }
        public class LRSSaveApplication
        {
            public LRSSaveDocument document { get; set; }

        }
        #endregion
    }
}
