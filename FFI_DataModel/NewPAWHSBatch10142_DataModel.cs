using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static FFI_Model.New_Pawhs_BatchCreation_Model;

namespace FFI_DataModel
{
    public class NewPAWHSBatch10142_DataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInvoice_DataModel)); //Declaring Log4Net. 
        string methodName = "";

        public DataSet BatchDetailsBasedonDestination(string org, string locn, string user, string lang, string destination, string location_code, string ConString)
        {
            DataSet ds = new DataSet();
            try
            {
                MysqlCon = new DataConnection(ConString);
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_fetch_batchdetailsbasedonDest_10142", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("In_Destination", MySqlDbType.VarChar).Value = destination;
                cmd.Parameters.Add("In_location_code", MySqlDbType.VarChar).Value = location_code;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ds;
        }
        public string SaveBatchCreationHeder(PAWHSNewBatchCreation_Save_Context objContext, string ConString)
        {
            string batch_no = "";
            try
            {
                int ret = 0;
                int retdtls = 0;
                MysqlCon = new DataConnection(ConString);
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }
                FFI_Model.ApplicationException objex = new FFI_Model.ApplicationException();
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_Insupd_Batch_Creation_10142", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_batch_rowid", MySqlDbType.Int32).Value = objContext.Header.In_batch_rowid;
                cmd.Parameters.Add("In_batch_no", MySqlDbType.VarChar).Value = objContext.Header.In_batch_no;
                cmd.Parameters.Add("In_destination", MySqlDbType.VarChar).Value = objContext.Header.In_Vehicle_no;
                cmd.Parameters.Add("In_buyer_code", MySqlDbType.VarChar).Value = objContext.Header.In_buyer_code;
                cmd.Parameters.Add("In_buyer_name", MySqlDbType.VarChar).Value = objContext.Header.In_buyer_name;
                cmd.Parameters.Add("In_buyer_location", MySqlDbType.VarChar).Value = objContext.Header.In_buyer_location;
                cmd.Parameters.Add("In_po_no", MySqlDbType.VarChar).Value = objContext.Header.In_po_no;
                cmd.Parameters.Add("In_remarks", MySqlDbType.VarChar).Value = objContext.Header.In_remarks;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objContext.Header.In_mode_flag;
                cmd.Parameters.Add("In_orgId", MySqlDbType.VarChar).Value = objContext.orgnId;
                cmd.Parameters.Add("In_locnId", MySqlDbType.VarChar).Value = objContext.locnId;
                cmd.Parameters.Add("In_userId", MySqlDbType.VarChar).Value = objContext.userId;
                cmd.Parameters.Add("In_locale_Id", MySqlDbType.VarChar).Value = objContext.localeId;
                cmd.Parameters.Add(new MySqlParameter("In_batch_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                retdtls = cmd.ExecuteNonQuery();

                batch_no = cmd.Parameters["In_batch_no1"].Value.ToString();
                if (batch_no != "")
                {
                    foreach (var Details in objContext.Batch)
                    {
                        MySqlCommand cmds = new MySqlCommand("New_PAWHS_Iud_Batch_Creation_Dtls_10142", MysqlCon.con);
                        cmds.CommandType = CommandType.StoredProcedure;
                        cmds.Parameters.Add("In_batch_no", MySqlDbType.VarChar).Value = batch_no;
                        cmds.Parameters.Add("In_orgn_code", MySqlDbType.VarChar).Value = Details.In_orgn_code;
                        cmds.Parameters.Add("In_agg_code", MySqlDbType.VarChar).Value = Details.In_agg_code;
                        cmds.Parameters.Add("In_lotno", MySqlDbType.VarChar).Value = Details.In_product_type;
                        cmds.Parameters.Add("In_destination", MySqlDbType.VarChar).Value = Details.In_lot_type;
                        cmds.Parameters.Add("In_farmer_code", MySqlDbType.VarChar).Value = Details.In_farmer_code;
                        cmds.Parameters.Add("In_farmer_name", MySqlDbType.VarChar).Value = Details.In_farmer_name;
                        cmds.Parameters.Add("In_item_code", MySqlDbType.VarChar).Value = Details.In_item_code;
                        cmds.Parameters.Add("In_item_name", MySqlDbType.VarChar).Value = Details.In_item_name;
                        cmds.Parameters.Add("In_actual_qty", MySqlDbType.Decimal).Value = Details.In_actual_qty;
                        cmds.Parameters.Add("In_actual_price", MySqlDbType.Double).Value = Details.In_actual_price;
                        cmds.Parameters.Add("In_actual_value", MySqlDbType.Double).Value = Details.In_actual_value;
                        cmds.Parameters.Add("In_advance_amt", MySqlDbType.Double).Value = Details.In_advance_amt;
                        cmds.Parameters.Add("In_no_of_bags", MySqlDbType.Int32).Value = Details.In_no_of_bags;
                        cmds.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Details.In_mode_flag;
                        cmds.Parameters.Add("In_orgnId", MySqlDbType.VarChar).Value = objContext.orgnId;
                        cmds.Parameters.Add("In_locnId", MySqlDbType.VarChar).Value = objContext.locnId;
                        cmds.Parameters.Add("In_userId", MySqlDbType.VarChar).Value = objContext.userId;
                        cmds.Parameters.Add("In_localeId", MySqlDbType.VarChar).Value = objContext.localeId;
                        ret = cmds.ExecuteNonQuery();
                        LogHelper.ConvertCmdIntoString(cmd);
                    }
                    foreach (var Details in objContext.OtherDtl)
                    {
                        MySqlCommand cmds = new MySqlCommand("New_PAWHS_Iud_batch_othercost_10142", MysqlCon.con);
                        cmds.CommandType = CommandType.StoredProcedure;
                        cmds.Parameters.Add("In_othercost_rowid", MySqlDbType.Int32).Value = 0;
                        cmds.Parameters.Add("In_batch_no", MySqlDbType.VarChar).Value = batch_no;
                        cmds.Parameters.Add("In_cost_type", MySqlDbType.VarChar).Value = Details.In_cost_type;
                        cmds.Parameters.Add("In_cost_name", MySqlDbType.VarChar).Value = Details.In_cost_name;
                        cmds.Parameters.Add("In_cost_value", MySqlDbType.Int32).Value = Details.In_cost_value;
                        cmds.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Details.In_mode_flag;
                        cmds.Parameters.Add("In_orgnId", MySqlDbType.VarChar).Value = objContext.orgnId;
                        cmds.Parameters.Add("In_locnId", MySqlDbType.VarChar).Value = objContext.locnId;
                        cmds.Parameters.Add("In_userId", MySqlDbType.VarChar).Value = objContext.userId;
                        cmds.Parameters.Add("In_localeId", MySqlDbType.VarChar).Value = objContext.localeId;
                        ret = cmds.ExecuteNonQuery();
                        LogHelper.ConvertCmdIntoString(cmd);
                    }

                    foreach (var Details in objContext.Invoice)
                    {
                        MySqlCommand cmds = new MySqlCommand("New_PAWHS_Iud_batch_podetails_10142", MysqlCon.con);
                        cmds.CommandType = CommandType.StoredProcedure;
                        cmds.Parameters.Add("In_podtl_rowid", MySqlDbType.Int32).Value = Details.In_podtl_rowid;
                        cmds.Parameters.Add("In_batch_no", MySqlDbType.VarChar).Value = batch_no;
                        cmds.Parameters.Add("In_sln_no", MySqlDbType.Int32).Value = Details.In_sln_no;
                        cmds.Parameters.Add("In_po_no", MySqlDbType.VarChar).Value = Details.In_po_no;
                        cmds.Parameters.Add("In_product_code", MySqlDbType.VarChar).Value = Details.In_item_code;
                        cmds.Parameters.Add("In_hsn_code", MySqlDbType.VarChar).Value = Details.In_hsn_code;
                        cmds.Parameters.Add("In_qty", MySqlDbType.Double).Value = Convert.ToDouble(Details.In_qty);
                        cmds.Parameters.Add("In_rate", MySqlDbType.Double).Value = Convert.ToDouble(Details.In_rate);
                        cmds.Parameters.Add("In_product_amount", MySqlDbType.Double).Value = Convert.ToDouble(Details.In_product_amount);
                        cmds.Parameters.Add("In_discount", MySqlDbType.Double).Value = Convert.ToDouble(Details.In_discount);
                        cmds.Parameters.Add("In_othercharges", MySqlDbType.Double).Value = Convert.ToDouble(Details.In_othercharges);
                        cmds.Parameters.Add("In_tax", MySqlDbType.Double).Value = Convert.ToDouble(Details.In_tax_rate);
                        cmds.Parameters.Add("In_gross_amount", MySqlDbType.Double).Value = Convert.ToDouble(Details.In_gross_amount);
                        cmds.Parameters.Add("In_remarks", MySqlDbType.VarChar).Value = Details.In_remarks;
                        cmds.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Details.In_mode_flag;
                        cmds.Parameters.Add("In_orgnId", MySqlDbType.VarChar).Value = objContext.orgnId;
                        cmds.Parameters.Add("In_locnId", MySqlDbType.VarChar).Value = objContext.locnId;
                        cmds.Parameters.Add("In_userId", MySqlDbType.VarChar).Value = objContext.userId;
                        cmds.Parameters.Add("In_localeId", MySqlDbType.VarChar).Value = objContext.localeId;
                        ret = cmds.ExecuteNonQuery();
                        LogHelper.ConvertCmdIntoString(cmd);
                    }
                    //foreach (var Details in objContext.Tax)
                    //{
                    //    MySqlCommand cmds = new MySqlCommand("New_PAWHS_Iud_batch_potax_10142", MysqlCon.con);
                    //    cmds.CommandType = CommandType.StoredProcedure;
                    //    cmds.Parameters.Add("In_batch_no", MySqlDbType.VarChar).Value = batch_no;
                    //    cmds.Parameters.Add("In_potax_rowid", MySqlDbType.Int32).Value = Details.In_potax_rowid;
                    //    cmds.Parameters.Add("In_po_no", MySqlDbType.Int32).Value = Details.In_po_no;
                    //    cmds.Parameters.Add("In_hsn_code", MySqlDbType.VarChar).Value = Details.In_hsn_code;
                    //    cmds.Parameters.Add("In_tax_type", MySqlDbType.VarChar).Value = Details.In_tax_type;
                    //    cmds.Parameters.Add("In_tax_amount", MySqlDbType.VarChar).Value = Details.In_tax_amount;
                    //    cmds.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = Details.In_status_code;
                    //    cmds.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Details.In_mode_flag;
                    //    cmds.Parameters.Add("In_orgId", MySqlDbType.VarChar).Value = objContext.orgnId;
                    //    cmds.Parameters.Add("In_locnId", MySqlDbType.VarChar).Value = objContext.locnId;
                    //    cmds.Parameters.Add("In_userId", MySqlDbType.VarChar).Value = objContext.userId;
                    //    cmds.Parameters.Add("In_localeId", MySqlDbType.VarChar).Value = objContext.localeId;
                    //    ret = cmds.ExecuteNonQuery();
                    //    LogHelper.ConvertCmdIntoString(cmd);
                    //}

                    foreach (var Details in objContext.Attachment)
                    {
                        MySqlCommand cmds = new MySqlCommand("New_PAWHS_Iud_Batch_Creation_PO_Attachment_Dtls_10142", MysqlCon.con);
                        cmds.CommandType = CommandType.StoredProcedure;
                        cmds.Parameters.Add("In_attch_rowid", MySqlDbType.Int32).Value = Details.In_attch_rowid;
                        cmds.Parameters.Add("In_batch_no", MySqlDbType.VarChar).Value = batch_no;
                        cmds.Parameters.Add("In_po_no", MySqlDbType.VarChar).Value = "";
                        cmds.Parameters.Add("In_filename", MySqlDbType.VarChar).Value = Details.In_filename;
                        cmds.Parameters.Add("In_document", MySqlDbType.VarChar).Value = Details.In_document;
                        cmds.Parameters.Add("In_description", MySqlDbType.VarChar).Value = Details.In_description;
                        cmds.Parameters.Add("In_attch_date", MySqlDbType.VarChar).Value = Details.In_attch_date;
                        cmds.Parameters.Add("In_attach_fileupload", MySqlDbType.VarChar).Value = Details.In_attch_upload;
                        cmds.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Details.In_mode_flag;
                        cmds.Parameters.Add("In_orgnId", MySqlDbType.VarChar).Value = objContext.orgnId;
                        cmds.Parameters.Add("In_locnId", MySqlDbType.VarChar).Value = objContext.locnId;
                        cmds.Parameters.Add("In_userId", MySqlDbType.VarChar).Value = objContext.userId;
                        cmds.Parameters.Add("In_localeId", MySqlDbType.VarChar).Value = objContext.localeId;
                        ret = cmds.ExecuteNonQuery();
                        LogHelper.ConvertCmdIntoString(cmd);
                    }
                    mysqltrans.Commit();
                    MysqlCon.con.Close();
                }
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return batch_no;
        }
        public DataSet FetchPODetails(string org, string locn, string user, string lang, string po_no, string ConString)
        {
            DataSet ds = new DataSet();
            try
            {
                MysqlCon = new DataConnection(ConString);
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_fetch_po_dtls_10142", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("In_locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("In_userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("In_localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("In_po_no", MySqlDbType.VarChar).Value = po_no;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ds;
        }
        public DataTable BatchCreation_List(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue, string mysqlcon)
        {
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_fetch_Batch_Creation_list_10142", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_filterby_option", MySqlDbType.VarChar).Value = filterby_option;
                cmd.Parameters.Add("In_filterby_code", MySqlDbType.VarChar).Value = filterby_code;
                cmd.Parameters.Add("In_filterby_fromvalue", MySqlDbType.VarChar).Value = filterby_fromvalue;
                cmd.Parameters.Add("In_filterby_tovalue", MySqlDbType.VarChar).Value = filterby_tovalue;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return dt;
        }
        public DataSet FectNewPAWHSBatchCreation(string org, string locn, string user, string lang, int batch_rowid, string batch_no, string ConString)
        {
            DataSet ds = new DataSet();
            try
            {
                MysqlCon = new DataConnection(ConString);
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_fetch_Batch_Creation_10142", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("In_batch_rowid", MySqlDbType.Int32).Value = batch_rowid;
                cmd.Parameters.Add("In_batch_no", MySqlDbType.VarChar).Value = batch_no;
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ds;
        }
        public DataTable GetPOBasedOnBuyer(string org, string locn, string user, string lang, string buyer_code, string ConString)
        {
            DataTable dt = new DataTable();
            try
            {
                MysqlCon = new DataConnection(ConString);
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_fetch_POBasedOnBuyer", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("In_locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("In_userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("In_localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("In_buyer_code", MySqlDbType.VarChar).Value = buyer_code;
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return dt;
        }
    }
}
