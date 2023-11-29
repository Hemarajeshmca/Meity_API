using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace FFI_DataModel
{
   public  class FISDividentRegister_DataModel
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInvoice_DataModel)); //Declaring Log4Net. 
        string methodName = "";
        public DivRegApplication divident_reg(DivRegContext objinvoice, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataTable dt = new DataTable();

            DivRegApplication objinvoiceRoot = new DivRegApplication();
            FISDividentRegister_DataModel objDataModel = new FISDividentRegister_DataModel();
            objinvoiceRoot.context = new DivRegContext();
            objinvoiceRoot.context.Header = new DivRegHeader();
            objinvoiceRoot.context.Detail = new List<DivRegDetail>();
            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("FIS_fetch_divident_register", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
                cmd.Parameters.Add("IOU_register_rowid", MySqlDbType.Int32).Value = objinvoice.Header.IOU_register_rowid;
                cmd.Parameters.Add("IOU_register_no", MySqlDbType.VarChar).Value = objinvoice.Header.IOU_register_no;
                cmd.Parameters.Add("IOU_register_name", MySqlDbType.VarChar).Value = objinvoice.Header.IOU_register_name;
                cmd.Parameters.Add("IOU_report_date", MySqlDbType.VarChar).Value = objinvoice.Header.IOU_report_date;
                cmd.Parameters.Add("IOU_declared_date", MySqlDbType.VarChar).Value = objinvoice.Header.IOU_declared_date;
                cmd.Parameters.Add("In_dividendstru_rowid", MySqlDbType.Int32).Value = objinvoice.Header.In_dividendstru_rowid;
                cmd.Parameters.Add("IOU_payor_bank_code", MySqlDbType.VarChar).Value = objinvoice.Header.IOU_payor_bank_code;
                cmd.Parameters.Add("IOU_fpoorgn_code", MySqlDbType.VarChar).Value = objinvoice.Header.IOU_fpoorgn_code;
                cmd.Parameters.Add(new MySqlParameter("IOU_register_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_register_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_register_name1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_report_date1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_declared_date1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_dividendstru_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_payor_bank_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_fpoorgn_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DivRegDetail objList = new DivRegDetail();
                    objList.In_dividend_rowid = Convert.ToInt32(dt.Rows[i]["In_dividend_rowid"]);
                    objList.In_fpomember_rowid = Convert.ToInt32(dt.Rows[i]["In_fpomember_rowid"]);
                    objList.In_farmer_code = dt.Rows[i]["In_farmer_code"].ToString();
                    objList.In_fpomember_code = dt.Rows[i]["In_fpomember_code"].ToString();
                    objList.In_farmer_name = dt.Rows[i]["In_farmer_name"].ToString();
                    objList.In_member_name = dt.Rows[i]["In_member_name"].ToString();
                    objList.In_certificate_no = dt.Rows[i]["In_certificate_no"].ToString();
                    objList.In_dist_from = Convert.ToInt32(dt.Rows[i]["In_dist_from"]);
                    objList.In_dist_to = Convert.ToInt32(dt.Rows[i]["In_dist_to"]);
                    objList.In_dividend_due = Convert.ToDecimal(dt.Rows[i]["In_dividend_due"]);
                    objList.In_bank_code = dt.Rows[i]["In_bank_code"].ToString();
                    objList.In_bank_acc_type = dt.Rows[i]["In_bank_acc_type"].ToString();
                    objList.In_bank_acc_type_desc = dt.Rows[i]["In_bank_acc_type_desc"].ToString();
                    objList.In_bank_acc_no = dt.Rows[i]["In_bank_acc_no"].ToString();
                    objList.In_branch_name = dt.Rows[i]["In_branch_name"].ToString();
                    objList.In_ifsc_code = dt.Rows[i]["In_ifsc_code"].ToString();
                    objList.In_bank_ref_no = dt.Rows[i]["In_bank_ref_no"].ToString();
                    objList.In_mode_flag = dt.Rows[i]["In_mode_flag"].ToString();
                    objList.In_row_timestamp = dt.Rows[i]["In_row_timestamp"].ToString();
                    objinvoiceRoot.context.Detail.Add(objList);
                }
                objinvoiceRoot.context.Header.IOU_register_rowid = (Int32)cmd.Parameters["IOU_register_rowid1"].Value;
                objinvoiceRoot.context.Header.IOU_register_no = (string)cmd.Parameters["IOU_register_no1"].Value.ToString();
                objinvoiceRoot.context.Header.IOU_register_name = (string)cmd.Parameters["IOU_register_name1"].Value.ToString();
                objinvoiceRoot.context.Header.IOU_report_date = (string)cmd.Parameters["IOU_report_date1"].Value.ToString();                
                objinvoiceRoot.context.Header.IOU_declared_date = (string)cmd.Parameters["IOU_declared_date1"].Value.ToString();
                objinvoiceRoot.context.Header.In_dividendstru_rowid = (Int32)cmd.Parameters["In_dividendstru_rowid1"].Value;
                objinvoiceRoot.context.Header.IOU_payor_bank_code = (string)cmd.Parameters["IOU_payor_bank_code1"].Value.ToString();
                objinvoiceRoot.context.Header.IOU_fpoorgn_code = (string)cmd.Parameters["IOU_fpoorgn_code1"].Value.ToString();
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objinvoice.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }
            return objinvoiceRoot;


        }

        public SDivRegDocument SaveDividendRegister(SDivRegApplication ObjFarmer, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            int ret = 0;

            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            SDivRegDocument objsinvoice = new SDivRegDocument();
            objsinvoice.context = new SDivRegContext();
            objsinvoice.context.Header = new SDivRegHeader();
         //   objsinvoice.ApplicationException = new sdiv(); 
            try
            {

                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                MySqlCommand cmd = new MySqlCommand("FIS_insupd_divident_register", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_register_name", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_register_name;
                cmd.Parameters.Add("In_report_date", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_report_date;
                cmd.Parameters.Add("In_declared_date", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_declared_date;
                cmd.Parameters.Add("In_dividendstru_rowid", MySqlDbType.Int32).Value = ObjFarmer.document.context.Header.In_dividendstru_rowid;
                cmd.Parameters.Add("In_payor_bank_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_payor_bank_code;
                cmd.Parameters.Add("In_fpoorgn_code", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.In_fpoorgn_code;
                cmd.Parameters.Add("IOU_register_rowid", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.IOU_register_rowid;
                cmd.Parameters.Add("IOU_register_no", MySqlDbType.VarChar).Value = ObjFarmer.document.context.Header.IOU_register_no; 
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjFarmer.document.context.localeId;  
                cmd.Parameters.Add(new MySqlParameter("IOU_register_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_register_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                if (ret > 0)
                { 
                    objsinvoice.context.Header.IOU_register_rowid = (Int32)cmd.Parameters["IOU_register_rowid1"].Value;
                    objsinvoice.context.Header.IOU_register_no = cmd.Parameters["IOU_register_no1"].Value.ToString();
                    objsinvoice.context.Header.In_report_date = ObjFarmer.document.context.Header.In_report_date;
                    objsinvoice.context.Header.In_report_date = ObjFarmer.document.context.Header.In_report_date;
                    objsinvoice.context.Header.In_declared_date = ObjFarmer.document.context.Header.In_declared_date;
                    objsinvoice.context.Header.In_dividendstru_rowid = ObjFarmer.document.context.Header.In_dividendstru_rowid;
                    objsinvoice.context.Header.In_payor_bank_code = ObjFarmer.document.context.Header.In_payor_bank_code;
                    objsinvoice.context.Header.In_fpoorgn_code = ObjFarmer.document.context.Header.In_fpoorgn_code;
                }
                if (objsinvoice.context.Header.IOU_register_rowid > 0)
                {
                    string resultinvdetail = "";
                    resultinvdetail = SaveDivRegister(ObjFarmer, objsinvoice, mysqlcon, MysqlCon);
                    if (resultinvdetail != "")
                    {
                        mysqltrans.Rollback(); 
                        return objsinvoice;
                    }
                    mysqltrans.Commit();
                    return objsinvoice;

                }
               
            }//---
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                //throw ex;
                logger.Error("USERNAME :" + ObjFarmer.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            } 
            return objsinvoice;
        }

        public string SaveDivRegister(SDivRegApplication Objmodel, SDivRegDocument objInvoice, string MysqlCons, DataConnection MysqlCon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            string errorNo = "";
            DataTable tab = new DataTable();
            SDivRegDetail objinvdtl = new SDivRegDetail();
            try
            {
                FISDividentRegister_DataModel objproduct1 = new FISDividentRegister_DataModel();
                foreach (var InvoiceDetail in Objmodel.document.context.Detail)
                {
                    objinvdtl.In_dividend_rowid = InvoiceDetail.In_dividend_rowid;
                    objinvdtl.In_fpomember_rowid = InvoiceDetail.In_fpomember_rowid;
                    objinvdtl.In_farmer_code = InvoiceDetail.In_farmer_code;
                    objinvdtl.In_fpomember_code = InvoiceDetail.In_fpomember_code;
                    objinvdtl.In_certificate_no = InvoiceDetail.In_certificate_no;
                    objinvdtl.In_dist_from = InvoiceDetail.In_dist_from;
                    objinvdtl.In_dist_to = InvoiceDetail.In_dist_to;
                    objinvdtl.In_dividend_due = InvoiceDetail.In_dividend_due;
                    objinvdtl.In_bank_code = InvoiceDetail.In_bank_code;
                    objinvdtl.In_bank_acc_type = InvoiceDetail.In_bank_acc_type;
                    objinvdtl.In_bank_acc_no = InvoiceDetail.In_bank_acc_no;
                    objinvdtl.In_ifsc_code = InvoiceDetail.In_ifsc_code;
                    objinvdtl.In_bank_ref_no = InvoiceDetail.In_bank_ref_no; 
                    objinvdtl.In_mode_flag = InvoiceDetail.In_mode_flag;
                    objinvdtl.In_row_timestamp = InvoiceDetail.In_row_timestamp;  
                    errorNo = objproduct1.SaveFISDIVREG(objinvdtl, objInvoice, Objmodel, MysqlCons, MysqlCon);
                    if (errorNo != "")
                    {
                        break;
                    }
                }
               
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }
            return errorNo;
        }

        public string SaveFISDIVREG(SDivRegDetail objinvdtl, SDivRegDocument ObjFarmer, SDivRegApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            string errorMsg = "";
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("FIS_iud_dividend_register", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("IOU_register_rowid", MySqlDbType.Int32).Value = ObjFarmer.context.Header.IOU_register_rowid;
                cmd.Parameters.Add("IOU_register_no", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.IOU_register_no;
                cmd.Parameters.Add("In_register_name", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.In_register_name;
                cmd.Parameters.Add("In_report_date", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.In_report_date;
                cmd.Parameters.Add("In_declared_date", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.In_declared_date;
                cmd.Parameters.Add("In_dividendstru_rowid", MySqlDbType.Int32).Value = ObjFarmer.context.Header.In_dividendstru_rowid;
                cmd.Parameters.Add("In_payor_bank_code", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.In_payor_bank_code;
                cmd.Parameters.Add("In_fpoorgn_code", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.In_fpoorgn_code;
                cmd.Parameters.Add("In_dividend_rowid", MySqlDbType.Int32).Value = objinvdtl.In_dividend_rowid;
                cmd.Parameters.Add("In_fpomember_rowid", MySqlDbType.Int32).Value = objinvdtl.In_fpomember_rowid;
                cmd.Parameters.Add("In_farmer_code", MySqlDbType.VarChar).Value = objinvdtl.In_farmer_code;
                cmd.Parameters.Add("In_fpomember_code", MySqlDbType.VarChar).Value = objinvdtl.In_fpomember_code;
                cmd.Parameters.Add("In_certificate_no", MySqlDbType.VarChar).Value = objinvdtl.In_certificate_no;
                cmd.Parameters.Add("In_dist_from", MySqlDbType.Int32).Value = objinvdtl.In_dist_from;
                cmd.Parameters.Add("In_dist_to", MySqlDbType.Int32).Value = objinvdtl.In_dist_to;
                cmd.Parameters.Add("In_dividend_due", MySqlDbType.Double).Value = objinvdtl.In_dividend_due;
                cmd.Parameters.Add("In_bank_code", MySqlDbType.VarChar).Value = objinvdtl.In_bank_code;
                cmd.Parameters.Add("In_bank_acc_type", MySqlDbType.VarChar).Value = objinvdtl.In_bank_acc_type;
                cmd.Parameters.Add("In_bank_acc_no", MySqlDbType.VarChar).Value = objinvdtl.In_bank_acc_no;
                cmd.Parameters.Add("In_ifsc_code", MySqlDbType.VarChar).Value = objinvdtl.In_ifsc_code;
                cmd.Parameters.Add("In_bank_ref_no", MySqlDbType.VarChar).Value = objinvdtl.In_bank_ref_no;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objinvdtl.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = objinvdtl.In_row_timestamp; 
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId; 
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                if (ret == 0)
                {
                    errorMsg = "Error";
                }
                
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //throw ex;
            }
            return errorMsg;
        }
    }
}
