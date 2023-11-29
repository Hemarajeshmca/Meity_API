using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FFI_Model;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Reflection;

namespace FFI_DataModel
{
    public class New_PAWHS_PO_DB
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(New_PAWHS_PO_DB)); //Declaring Log4Net. 
        string methodName = "";
        public PORootObject GetAllPODtls(POContext objfarmer, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataTable dt = new DataTable();
            PORootObject ObjFarmerRoot = new PORootObject();
            New_PAWHS_PO_DB objDataModel = new New_PAWHS_PO_DB();

            ObjFarmerRoot.context = new POContext();
            ObjFarmerRoot.context.List = new List<POLIst>();

            MysqlCon = new DataConnection(mysqlcon);

            logger.Error("call AllPOList" + "call ICDMOB_fetch_stockAdjustment_list(" + "'" + objfarmer.userId + "'" + ", " + "'" + objfarmer.orgnId + "'" + ", " + "'" + objfarmer.locnId + "'" + "," + "'" + objfarmer.localeId + "'" + "," + "'" + objfarmer.FilterBy_Option + "'" + "," + "'" + objfarmer.FilterBy_Code + "'" + "," + "'" + objfarmer.FilterBy_FromValue + "'" + "," + "'" + objfarmer.FilterBy_ToValue + "'" + " )");

            try
            {
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_Fetch_PO_List", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfarmer.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfarmer.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfarmer.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfarmer.localeId;
                cmd.Parameters.Add("in_filterby_option", MySqlDbType.VarChar).Value = objfarmer.FilterBy_Option;
                cmd.Parameters.Add("in_filterby_code", MySqlDbType.VarChar).Value = objfarmer.FilterBy_Code;
                cmd.Parameters.Add("in_filterby_fromvalue", MySqlDbType.VarChar).Value = objfarmer.FilterBy_FromValue;
                cmd.Parameters.Add("in_filterby_tovalue", MySqlDbType.VarChar).Value = objfarmer.FilterBy_ToValue;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    POLIst objList = new POLIst();
                    objList.Out_po_rowid = Convert.ToInt32(dt.Rows[i]["Out_po_rowid"]);
                    objList.Out_agg_code = dt.Rows[i]["Out_agg_code"].ToString();
                    objList.Out_agg_name = dt.Rows[i]["Out_agg_name"].ToString();
                    objList.Out_po_no = dt.Rows[i]["Out_po_no"].ToString();
                    objList.Out_po_date = dt.Rows[i]["Out_po_date"].ToString();
                    objList.Out_buyer_code = dt.Rows[i]["Out_buyer_code"].ToString();
                    objList.Out_buyer_name = dt.Rows[i]["Out_buyer_name"].ToString();
                    objList.Out_buyer_location = dt.Rows[i]["Out_buyer_location"].ToString();
                    objList.Out_po_remarks = dt.Rows[i]["Out_po_remarks"].ToString();
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.Out_row_timestamp = dt.Rows[i]["Out_row_timestamp"].ToString();

                    objList.Out_GivenBy = dt.Rows[i]["Out_GivenBy"].ToString();
                    objList.Out_GivenByNo = dt.Rows[i]["Out_GivenByNo"].ToString();
                    objList.Out_TakenBy = dt.Rows[i]["Out_TakenBy"].ToString();
                    objList.OutTakenByNo = dt.Rows[i]["OutTakenByNo"].ToString();
                    ObjFarmerRoot.context.List.Add(objList);
                }
                ObjFarmerRoot.context.orgnId = objfarmer.orgnId;
                ObjFarmerRoot.context.locnId = objfarmer.locnId;
                ObjFarmerRoot.context.localeId = objfarmer.localeId;
                ObjFarmerRoot.context.userId = objfarmer.userId;
                ObjFarmerRoot.context.FilterBy_Code = objfarmer.FilterBy_Code;
                ObjFarmerRoot.context.FilterBy_FromValue = objfarmer.FilterBy_FromValue;
                ObjFarmerRoot.context.FilterBy_Option = objfarmer.FilterBy_Option;
                ObjFarmerRoot.context.FilterBy_ToValue = objfarmer.FilterBy_ToValue;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjFarmerRoot.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFarmerRoot;
        }

        public PAWHSPO_Save_Document SavePODetails(PAWHSPO_Save_Application ObjPODtls, string mysqlcon)
        {
            int ret = 0;
            int QtyDtl = 0;
            int TaxDtl = 0;
            int AttchDtl = 0;

            methodName = MethodBase.GetCurrentMethod().Name;
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            PAWHSPO_Save_Document objresFarmer = new PAWHSPO_Save_Document();
            objresFarmer.ApplicationException = new POApplicationException();
            objresFarmer.context = new PAWHSPO_Save_Context();
            objresFarmer.context.Header = new PAWHSPO_Save_Header();
            objresFarmer.context.QtyDetail = new List<PAWHSPO_Save_PODetail>();
            //objresFarmer.context.ShipDetail = new List<PAWHSPO_Save_POShipDtl>();
            //  objresFarmer.context.AttchDetail = new List<PAWHSPO_Save_POAttchDtl>();          
            int IOU_po_rowid = 0;
            string IOU_PO_No = "";
            string IOU_ErroNo = "";
            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }


                logger.Error("Call PAWHS_PO_save" + "set @IOU_po_rowid = 0;set @IOU_PO_No = '0';set @IOU_ErroNo = '0';call  New_PAWHS_insupd_PO(" + ObjPODtls.document.context.Header.In_po_rowid + ", " + "'" + ObjPODtls.document.context.Header.In_agg_code + "'" + ", " + "'" + ObjPODtls.document.context.Header.In_po_no + "'" + ", " + "'" + ObjPODtls.document.context.Header.In_po_date + "'" + ", " + "'" + ObjPODtls.document.context.Header.In_buyer_code + "'" + ", " + "'" + ObjPODtls.document.context.Header.In_buyer_name + "'" + ", " + "'" + ObjPODtls.document.context.Header.In_buyer_location + "'" + ", " + "'" + ObjPODtls.document.context.Header.In_po_remarks + "'" + "," + "'" + ObjPODtls.document.context.Header.In_status_code + "'" + ", " + "'" + ObjPODtls.document.context.Header.In_mode_flag + "'" + ", " + "'" + ObjPODtls.document.context.Header.In_row_timestamp + "'" + ", " + "'" + ObjPODtls.document.context.Header.In_bill_attachment + "'" + ", " + "'" + ObjPODtls.document.context.orgnId + "'" + ", " + "'" + ObjPODtls.document.context.locnId + "'" + ", " + "'" + ObjPODtls.document.context.userId + "'" + ", " + "'" + ObjPODtls.document.context.localeId + "'" + ", " + "'" + ObjPODtls.document.context.Header.In_OrderBy + "'" + ", " + "'" + ObjPODtls.document.context.Header.In_OrderByNO + "'" + ", " + "'" + ObjPODtls.document.context.Header.In_TakenBy + "'" + ", " + "'" + ObjPODtls.document.context.Header.In_TakenByNo + "'" + ", @IOU_po_rowid, @IOU_PO_No, @IOU_ErroNo);select @IOU_po_rowid, @IOU_PO_No, @IOU_ErroNo; ");

                MySqlCommand cmd = new MySqlCommand("New_PAWHS_insupd_PO", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_po_rowid", MySqlDbType.Int32).Value = ObjPODtls.document.context.Header.In_po_rowid;
                cmd.Parameters.Add("In_agg_code", MySqlDbType.VarChar).Value = ObjPODtls.document.context.Header.In_agg_code;
                cmd.Parameters.Add("In_po_no", MySqlDbType.VarChar).Value = ObjPODtls.document.context.Header.In_po_no;
                cmd.Parameters.Add("In_po_date", MySqlDbType.VarChar).Value = ObjPODtls.document.context.Header.In_po_date;
                cmd.Parameters.Add("In_buyer_code", MySqlDbType.VarChar).Value = ObjPODtls.document.context.Header.In_buyer_code;
                cmd.Parameters.Add("In_buyer_name", MySqlDbType.VarChar).Value = ObjPODtls.document.context.Header.In_buyer_name;
                cmd.Parameters.Add("In_buyer_location", MySqlDbType.VarChar).Value = ObjPODtls.document.context.Header.In_buyer_location;
                cmd.Parameters.Add("In_po_remarks", MySqlDbType.VarChar).Value = ObjPODtls.document.context.Header.In_po_remarks;

                cmd.Parameters.Add("In_OrderBy", MySqlDbType.VarChar).Value = ObjPODtls.document.context.Header.In_OrderBy;
                cmd.Parameters.Add("In_OrderByNO", MySqlDbType.VarChar).Value = ObjPODtls.document.context.Header.In_OrderByNO;
                cmd.Parameters.Add("In_TakenBy", MySqlDbType.VarChar).Value = ObjPODtls.document.context.Header.In_TakenBy;
                cmd.Parameters.Add("In_TakenByNo", MySqlDbType.VarChar).Value = ObjPODtls.document.context.Header.In_TakenByNo;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjPODtls.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjPODtls.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjPODtls.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("In_bill_attachment", MySqlDbType.VarChar).Value = ObjPODtls.document.context.Header.In_bill_attachment;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjPODtls.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjPODtls.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjPODtls.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjPODtls.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("IOU_po_rowid", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_PO_No", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_ErroNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                if (ret > 0)
                {
                    IOU_po_rowid = (Int32)cmd.Parameters["IOU_po_rowid"].Value;
                    IOU_PO_No = (string)cmd.Parameters["IOU_PO_No"].Value;
                    IOU_ErroNo = (string)cmd.Parameters["IOU_ErroNo"].Value;

                    if (IOU_ErroNo.Contains("P0"))
                    {
                        mysqltrans.Rollback();
                        objresFarmer.ApplicationException.errorNumber = IOU_ErroNo;
                        objresFarmer.ApplicationException.errorDescription = ObjErrormsg.ErrorMessage(IOU_ErroNo);
                        return objresFarmer;
                    }

                    objresFarmer.context.Header.In_po_rowid = Convert.ToInt32(IOU_po_rowid);
                    objresFarmer.context.Header.IOU_po_rowid = Convert.ToInt32(IOU_po_rowid);
                    objresFarmer.context.Header.In_po_no = IOU_PO_No;
                    objresFarmer.context.Header.IOU_PO_No = IOU_PO_No;
                    objresFarmer.context.orgnId = ObjPODtls.document.context.orgnId;
                    objresFarmer.context.locnId = ObjPODtls.document.context.locnId;
                    objresFarmer.context.userId = ObjPODtls.document.context.userId;
                    objresFarmer.context.localeId = ObjPODtls.document.context.localeId;
                }
                else
                {
                    IOU_ErroNo = (string)cmd.Parameters["IOU_ErroNo"].Value;
                    mysqltrans.Rollback();
                    objresFarmer.ApplicationException.errorNumber = IOU_ErroNo;
                    objresFarmer.ApplicationException.errorDescription = IOU_ErroNo;
                    return objresFarmer;

                }
                if (objresFarmer.context.Header.In_po_rowid > 0)
                {
                    if (ObjPODtls.document.context.QtyDetail.Count > 0)
                    {
                        QtyDtl = SaveQtyDtl(ObjPODtls, objresFarmer, mysqlcon, MysqlCon);
                    }
                    else
                    {
                        objresFarmer.ApplicationException.errorNumber = "0001";
                        objresFarmer.ApplicationException.errorDescription = "PO Details Cannot be empty.";
                        mysqltrans.Rollback();
                        return objresFarmer;

                    }

                    //if (ObjPODtls.document.context.AttchDetail.Count > 0)
                    //{
                    //    AttchDtl = SaveAttchDtl(ObjPODtls, objresFarmer, mysqlcon, MysqlCon);
                    //}
                    mysqltrans.Commit();
                }
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objresFarmer.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objresFarmer;
        }
        public int SaveQtyDtl(PAWHSPO_Save_Application Objmodel, PAWHSPO_Save_Document objfarmer, string MysqlCons, DataConnection MysqlCon)
        {
            int ret = 0;
            int shipdtl = 0;
            methodName = MethodBase.GetCurrentMethod().Name;
            DataTable tab = new DataTable();
            PAWHSPO_Save_PODetail objPODtl = new PAWHSPO_Save_PODetail();
            try
            {

                foreach (var QtyDetails in Objmodel.document.context.QtyDetail)
                {
                    MySqlCommand cmd = new MySqlCommand("New_PAWHS_iud_POdtl", MysqlCon.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("In_podtl_rowid", MySqlDbType.Int32).Value = QtyDetails.In_podtl_rowid;
                    cmd.Parameters.Add("In_po_no", MySqlDbType.VarChar).Value = objfarmer.context.Header.In_po_no;
                    cmd.Parameters.Add("In_sln_no", MySqlDbType.Int32).Value = QtyDetails.In_sln_no;
                    cmd.Parameters.Add("In_product_code", MySqlDbType.VarChar).Value = QtyDetails.In_product_code;
                    cmd.Parameters.Add("In_hsn_code", MySqlDbType.VarChar).Value = QtyDetails.In_hsn_code;
                    cmd.Parameters.Add("In_qty", MySqlDbType.Double).Value = QtyDetails.In_qty;
                    cmd.Parameters.Add("In_rate", MySqlDbType.Double).Value = QtyDetails.In_rate;
                    cmd.Parameters.Add("In_product_amount", MySqlDbType.Double).Value = QtyDetails.In_product_amount;
                    cmd.Parameters.Add("In_discount", MySqlDbType.Double).Value = QtyDetails.In_discount;
                    cmd.Parameters.Add("In_othercharges", MySqlDbType.Double).Value = QtyDetails.In_othercharges;
                    cmd.Parameters.Add("In_tax", MySqlDbType.Double).Value = QtyDetails.In_tax;
                    cmd.Parameters.Add("In_gross_amount", MySqlDbType.Double).Value = QtyDetails.In_gross_amount;
                    cmd.Parameters.Add("In_remarks", MySqlDbType.VarChar).Value = QtyDetails.In_remarks;
                    cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = QtyDetails.In_mode_flag;
                    cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfarmer.context.orgnId;
                    cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfarmer.context.locnId;
                    cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfarmer.context.userId;
                    cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfarmer.context.localeId;
                    cmd.Parameters.Add(new MySqlParameter("IOU_podtl_rowid", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new MySqlParameter("IOU_po_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new MySqlParameter("IOU_Error", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                    ret = cmd.ExecuteNonQuery();
                    LogHelper.ConvertCmdIntoString(cmd);
                    if (ret == 0)
                    {
                        objPODtl.IOU_Error = (string)cmd.Parameters["IOU_Error"].Value;
                        break;
                    }
                    else
                    {
                        objPODtl.IOU_podtl_rowid = (Int32)cmd.Parameters["IOU_podtl_rowid"].Value;
                        objPODtl.IOU_po_no = (string)cmd.Parameters["IOU_po_no"].Value;
                        objPODtl.IOU_Error = (string)cmd.Parameters["IOU_Error"].Value;


                        if (objPODtl.IOU_podtl_rowid > 0)
                        {
                            foreach (var ShipDetails in Objmodel.document.context.QtyDetail[0].ShipDetail)
                            {
                                //if (QtyDetails.In_product_code == ShipDetails.In_product_code)
                                //{
                                shipdtl = SaveShipDtl(ShipDetails, objfarmer, objPODtl, MysqlCons, MysqlCon);
                                if (shipdtl == 0)
                                {
                                    break;
                                }
                                // }
                            }

                        }
                    }
                    objfarmer.context.QtyDetail.Add(objPODtl);
                }
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ret;
        }

        public int SaveShipDtl(PAWHSPO_Save_POShipDtl ObjShipdtl, PAWHSPO_Save_Document objfarmer, PAWHSPO_Save_PODetail objPODtl, string MysqlCons, DataConnection MysqlCon)
        {
            int ret = 0;
            methodName = MethodBase.GetCurrentMethod().Name;
            DataTable tab = new DataTable();
            PAWHSPO_Save_POShipDtl objship = new PAWHSPO_Save_POShipDtl();

            try
            {
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_iud_POShipment", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_shipment_rowid", MySqlDbType.Int32).Value = ObjShipdtl.In_shipment_rowid;
                cmd.Parameters.Add("In_POdtl_rowid", MySqlDbType.Int32).Value = objPODtl.IOU_podtl_rowid;
                cmd.Parameters.Add("In_po_no", MySqlDbType.VarChar).Value = objfarmer.context.Header.In_po_no;
                cmd.Parameters.Add("In_sl_no", MySqlDbType.Int32).Value = ObjShipdtl.In_sl_no;
                cmd.Parameters.Add("In_address", MySqlDbType.VarChar).Value = ObjShipdtl.In_address;
                cmd.Parameters.Add("In_qty", MySqlDbType.Double).Value = ObjShipdtl.In_qty;
                cmd.Parameters.Add("In_product_code", MySqlDbType.VarChar).Value = ObjShipdtl.In_product_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjShipdtl.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfarmer.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfarmer.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfarmer.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfarmer.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("IOU_shipment_rowid", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_podtl_rowid", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_po_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_Error", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();
                LogHelper.ConvertCmdIntoString(cmd);
                if (ret == 0)
                {
                    objship.IOU_Error = (string)cmd.Parameters["IOU_Error"].Value;
                }
                else
                {

                    objship.IOU_Error = (string)cmd.Parameters["IOU_Error"].Value;
                }
                //objfarmer.context.QtyDetail[0].ShipDetail.Add(objship);

            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objfarmer.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ret;
        }

        //public int SaveAttchDtl(PAWHSPO_Save_Application Objmodel, PAWHSPO_Save_Document objfarmer, string MySqlCons, DataConnection MySqlCon)
        //{
        //    int ret = 0;
        //    methodName = MethodBase.GetCurrentMethod().Name;
        //    DataTable tab = new DataTable();
        //    PAWHSPO_Save_POAttchDtl ObjAttchDtl = new PAWHSPO_Save_POAttchDtl();
        //    try
        //    {
        //        foreach (var AttchDetails in Objmodel.document.context.AttchDetail)
        //        {
        //            MySqlCommand cmd = new MySqlCommand("New_PAWHS_iud_POAttachment", MysqlCon.con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add("In_attch_rowid", MySqlDbType.Int32).Value = AttchDetails.In_attch_rowid;
        //            cmd.Parameters.Add("In_po_no", MySqlDbType.VarChar).Value = objfarmer.context.Header.In_po_no;
        //            cmd.Parameters.Add("In_filename", MySqlDbType.VarChar).Value = AttchDetails.In_filename;
        //            cmd.Parameters.Add("In_document", MySqlDbType.VarChar).Value = AttchDetails.In_document;
        //            cmd.Parameters.Add("In_description", MySqlDbType.VarChar).Value = AttchDetails.In_description;
        //            cmd.Parameters.Add("In_attch_date", MySqlDbType.VarChar).Value = AttchDetails.In_attch_date;
        //            cmd.Parameters.Add("In_attach_fileupload", MySqlDbType.VarChar).Value = AttchDetails.In_attch_upload;
        //            cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = AttchDetails.In_mode_flag;
        //            cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfarmer.context.orgnId;
        //            cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfarmer.context.locnId;
        //            cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfarmer.context.userId;
        //            cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfarmer.context.localeId;
        //            cmd.Parameters.Add(new MySqlParameter("IOU_attch_rowid", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
        //            cmd.Parameters.Add(new MySqlParameter("IOU_po_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
        //            cmd.Parameters.Add(new MySqlParameter("IOU_Error", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
        //            ret = cmd.ExecuteNonQuery();
        //            LogHelper.ConvertCmdIntoString(cmd);
        //            if (ret == 0)
        //            {
        //                ObjAttchDtl.IOU_Error = (string)cmd.Parameters["IOU_Error"].Value;
        //                break;
        //            }
        //            else
        //            {
        //                ObjAttchDtl.IOU_attch_rowid = (Int32)cmd.Parameters["IOU_attch_rowid"].Value;
        //                ObjAttchDtl.IOU_po_no = (string)cmd.Parameters["IOU_po_no"].Value;
        //                ObjAttchDtl.IOU_Error = (string)cmd.Parameters["IOU_Error"].Value;

        //            }
        //            objfarmer.context.AttchDetail.Add(ObjAttchDtl);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
        //    }
        //    return ret;
        //}
        public PAWHSPOFetchApplication Single_FetchPO(PAWHSPO_FetchContext objfpoSearch, string mysqlcon)
        {
            methodName = MethodBase.GetCurrentMethod().Name;
            DataSet ds = new DataSet();
            PAWHSPOFetchApplication objfpoSearchRoot = new PAWHSPOFetchApplication();

            DataTable QtyDt = new DataTable();
            DataTable ShipDt = new DataTable();
            DataTable TaxDt = new DataTable();
            DataTable AttchDt = new DataTable();

            objfpoSearchRoot.context = new PAWHSPO_FetchContext();
            objfpoSearchRoot.context.Header = new PAWHSPO_FetchHeader();
            objfpoSearchRoot.context.QtyDetail = new List<PAWHSPO_Fetch_QtyDetail>();
            objfpoSearchRoot.context.TaxDetail = new List<PAWHSPO_Fetch_TaxDetail>();
            //   objfpoSearchRoot.context.AttchDetail = new List<PAWHSPO_Fetch_AttchDetail>();
            logger.Error("Call PAWHS_Fetch_PO" + "set @In_po_date = '0';set @In_buyer_code = '0';set @In_buyer_name = '0';set @In_buyer_location = '0';set @In_buyer_location_desc = '0'; set @In_po_remarks = '0'; set @In_status_code = '0'; set @In_bill_attachment = '0'; set @In_mode_flag = '0'; set @IOU_PO_rowid = 0; set @IOU_agg_code = '0'; set @IOU_agg_name = '0'; set @IOU_PO_No = '0'; set @In_OrderBy = '0'; set @In_OrderByNO = '0'; set @In_TakenBy = '0'; set @In_TakenByNo = '0';call New_PAWHS_Fetch_PO(" + "'" + objfpoSearch.orgnId + "'" + ", " + "'" + objfpoSearch.locnId + "'" + ", " + "'" + objfpoSearch.userId + "'" + ", " + "'" + objfpoSearch.localeId + "'" + ", objfpoSearch.IOU_PO_rowid, " + "'" + objfpoSearch.IOU_agg_code + "'" + "," + "'" + objfpoSearch.IOU_PONo + "'" + ", @In_po_date, @In_buyer_code, @In_buyer_name, @In_buyer_location, @In_buyer_location_desc, @In_po_remarks, @In_status_code, @In_bill_attachment, @In_mode_flag, @IOU_PO_rowid, @IOU_agg_code, @IOU_agg_name, @IOU_PO_No, @In_OrderBy, @In_OrderByNO, @In_TakenBy, @In_TakenByNo); select @In_po_date, @In_buyer_code, @In_buyer_name, @In_buyer_location, @In_buyer_location_desc, @In_po_remarks, @In_status_code, @In_bill_attachment, @In_mode_flag, @IOU_PO_rowid, @IOU_agg_code, @IOU_agg_name, @IOU_PO_No, @In_OrderBy, @In_OrderByNO, @In_TakenBy, @In_TakenByNo; ");
            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_Fetch_PO", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;
                cmd.Parameters.Add("In_po_rowid", MySqlDbType.Int32).Value = objfpoSearch.IOU_PO_rowid;
                cmd.Parameters.Add("In_agg_code", MySqlDbType.VarChar).Value = objfpoSearch.IOU_agg_code;
                cmd.Parameters.Add("In_po_no", MySqlDbType.VarChar).Value = objfpoSearch.IOU_PONo;
                cmd.Parameters.Add(new MySqlParameter("In_po_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_buyer_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_buyer_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_buyer_location", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_buyer_location_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_po_remarks", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_bill_attachment", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_PO_rowid", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_agg_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_agg_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_PO_No", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_OrderBy", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_OrderByNO", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_TakenBy", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_TakenByNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                LogHelper.ConvertCmdIntoString(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();
                if (ds.Tables.Count > 0)
                {
                    QtyDt = ds.Tables[0];
                    for (int i = 0; i < QtyDt.Rows.Count; i++)
                    {
                        PAWHSPO_Fetch_QtyDetail objQtyDetail = new PAWHSPO_Fetch_QtyDetail();
                        objQtyDetail.In_podtl_rowid = Convert.ToInt32(QtyDt.Rows[i]["In_podtl_rowid"]);
                        objQtyDetail.In_po_no = QtyDt.Rows[i]["In_po_no"].ToString();
                        objQtyDetail.In_sln_no = Convert.ToInt32(QtyDt.Rows[i]["In_sln_no"]);
                        objQtyDetail.In_product_code = QtyDt.Rows[i]["In_product_code"].ToString();
                        objQtyDetail.In_product_Type = QtyDt.Rows[i]["In_product_Type"].ToString();
                        objQtyDetail.In_product_Name = QtyDt.Rows[i]["In_product_Name"].ToString();
                        objQtyDetail.In_product_Variety = QtyDt.Rows[i]["In_product_Variety"].ToString();
                        objQtyDetail.In_hsn_code = QtyDt.Rows[i]["In_hsn_code"].ToString();
                        objQtyDetail.In_qty = Convert.ToDouble(QtyDt.Rows[i]["In_qty"]);
                        objQtyDetail.In_rate = Convert.ToDouble(QtyDt.Rows[i]["In_rate"]);
                        objQtyDetail.In_product_amount = Convert.ToDouble(QtyDt.Rows[i]["In_product_amount"]);
                        objQtyDetail.In_discount = Convert.ToDouble(QtyDt.Rows[i]["In_discount"]);
                        objQtyDetail.In_othercharges = Convert.ToDouble(QtyDt.Rows[i]["In_othercharges"]);
                        objQtyDetail.In_tax = Convert.ToDouble(QtyDt.Rows[i]["In_tax"]);
                        objQtyDetail.In_gross_amount = Convert.ToDouble(QtyDt.Rows[i]["In_gross_amount"]);
                        objQtyDetail.In_Stock_Qty = Convert.ToDouble(QtyDt.Rows[i]["In_Stock_Qty"]);
                        objQtyDetail.In_remarks = QtyDt.Rows[i]["In_remarks"].ToString();
                        objQtyDetail.In_mode_flag = QtyDt.Rows[i]["In_mode_flag"].ToString();
                        objfpoSearchRoot.context.QtyDetail.Add(objQtyDetail);
                    }

                    TaxDt = ds.Tables[2];
                    for (int i = 0; i < TaxDt.Rows.Count; i++)
                    {
                        PAWHSPO_Fetch_TaxDetail ObjTaxDtls = new PAWHSPO_Fetch_TaxDetail();
                        ObjTaxDtls.In_product_code = TaxDt.Rows[i]["In_product_code"].ToString();
                        ObjTaxDtls.In_product_name = TaxDt.Rows[i]["In_product_name"].ToString();
                        ObjTaxDtls.In_potax_rowid = Convert.ToInt32(TaxDt.Rows[i]["In_potax_rowid"]);
                        ObjTaxDtls.In_po_no = TaxDt.Rows[i]["In_po_no"].ToString();
                        ObjTaxDtls.In_taxdetails_rowid = Convert.ToInt32(TaxDt.Rows[i]["In_taxdetails_rowid"]);
                        ObjTaxDtls.In_state = TaxDt.Rows[i]["In_state"].ToString();
                        ObjTaxDtls.In_hsn_code = TaxDt.Rows[i]["In_hsn_code"].ToString();
                        ObjTaxDtls.In_hsn_desc = TaxDt.Rows[i]["In_hsn_desc"].ToString();
                        ObjTaxDtls.In_tax_rate = Convert.ToDouble(TaxDt.Rows[i]["In_tax_rate"]);
                        ObjTaxDtls.In_taxable_amount = Convert.ToDouble(TaxDt.Rows[i]["In_taxable_amount"]);
                        ObjTaxDtls.In_tax = Convert.ToDouble(TaxDt.Rows[i]["In_tax_amount"]);
                        ObjTaxDtls.In_cgst_rate = Convert.ToDouble(TaxDt.Rows[i]["In_cgst_rate"]);
                        ObjTaxDtls.In_sgst_rate = Convert.ToDouble(TaxDt.Rows[i]["In_sgst_rate"]);
                        ObjTaxDtls.In_igst_rate = Convert.ToDouble(TaxDt.Rows[i]["In_igst_rate"]);
                        ObjTaxDtls.In_ugst_rate = Convert.ToDouble(TaxDt.Rows[i]["In_ugst_rate"]);
                        ObjTaxDtls.In_status_code = TaxDt.Rows[i]["In_status_code"].ToString();
                        ObjTaxDtls.In_status_desc = TaxDt.Rows[i]["In_status_desc"].ToString();
                        ObjTaxDtls.In_mode_flag = TaxDt.Rows[i]["In_mode_flag"].ToString();
                        objfpoSearchRoot.context.TaxDetail.Add(ObjTaxDtls);
                    }
                    //AttchDt = ds.Tables[3];
                    //for (int i = 0; i < AttchDt.Rows.Count; i++)
                    //{
                    //    PAWHSPO_Fetch_AttchDetail ObjAttchDtls = new PAWHSPO_Fetch_AttchDetail();
                    //    ObjAttchDtls.In_attch_rowid = Convert.ToInt32(AttchDt.Rows[i]["In_attch_rowid"]);
                    //    ObjAttchDtls.In_po_no = AttchDt.Rows[i]["In_po_no"].ToString();
                    //    ObjAttchDtls.In_filename = AttchDt.Rows[i]["In_filename"].ToString();
                    //    ObjAttchDtls.In_document = AttchDt.Rows[i]["In_Document"].ToString();
                    //    ObjAttchDtls.In_description = AttchDt.Rows[i]["In_Description"].ToString();
                    //    ObjAttchDtls.In_attch_date = AttchDt.Rows[i]["In_attch_date"].ToString();
                    //    ObjAttchDtls.In_attch_upload = AttchDt.Rows[i]["In_attch_upload"].ToString();
                    //    ObjAttchDtls.In_mode_flag = AttchDt.Rows[i]["In_mode_flag"].ToString();
                    //    objfpoSearchRoot.context.AttchDetail.Add(ObjAttchDtls);

                    //}
                    objfpoSearchRoot.context.orgnId = objfpoSearch.orgnId;
                    objfpoSearchRoot.context.locnId = objfpoSearch.locnId;
                    objfpoSearchRoot.context.userId = objfpoSearch.userId;
                    objfpoSearchRoot.context.localeId = objfpoSearch.localeId;
                    objfpoSearchRoot.context.IOU_PO_rowid = objfpoSearch.IOU_PO_rowid;
                    objfpoSearchRoot.context.IOU_agg_code = objfpoSearch.IOU_agg_code;
                    objfpoSearchRoot.context.IOU_PONo = objfpoSearch.IOU_PONo;
                    objfpoSearchRoot.context.Header.In_po_date = (string)cmd.Parameters["In_po_date"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_buyer_code = (string)cmd.Parameters["In_buyer_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_buyer_name = (string)cmd.Parameters["In_buyer_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_buyer_location = (string)cmd.Parameters["In_buyer_location"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_buyer_location_desc = (string)cmd.Parameters["In_buyer_location_desc"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_po_remarks = (string)cmd.Parameters["In_po_remarks"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_bill_attachment = (string)cmd.Parameters["In_bill_attachment"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                    objfpoSearchRoot.context.Header.IOU_PO_rowid = (Int32)cmd.Parameters["IOU_PO_rowid"].Value;
                    objfpoSearchRoot.context.Header.IOU_agg_code = (string)cmd.Parameters["IOU_agg_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.IOU_agg_name = (string)cmd.Parameters["IOU_agg_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.IOU_PO_No = (string)cmd.Parameters["IOU_PO_No"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_OrderBy = (string)cmd.Parameters["In_OrderBy"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_OrderByNO = (string)cmd.Parameters["In_OrderByNO"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_TakenBy = (string)cmd.Parameters["In_TakenBy"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_TakenByNo = (string)cmd.Parameters["In_TakenByNo"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objfpoSearchRoot.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return objfpoSearchRoot;
        }

        public PAWHSPurchaseOrderShipment Getshipmentfetch_DB(PAWHSPurchaseOrderShipmentContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();
            PAWHSPurchaseOrderShipment objinvoiceRoot = new PAWHSPurchaseOrderShipment();
            // PAWHSRaiseInvoice_DB objDataModel = new PAWHSRaiseInvoice_DB();

            objinvoiceRoot.context = new PAWHSPurchaseOrderShipmentContext();
            objinvoiceRoot.context.ShipDetail = new List<PAWHSPO_Fetch_ShipDetail>();
            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_Fetch_shipment", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
                cmd.Parameters.Add("In_podtl_rowid", MySqlDbType.VarChar).Value = objinvoice.In_podtl_rowid;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PAWHSPO_Fetch_ShipDetail ObjShipDtls = new PAWHSPO_Fetch_ShipDetail();
                    ObjShipDtls.In_shipment_rowid = Convert.ToInt32(dt.Rows[i]["In_shipment_rowid"]);
                    ObjShipDtls.In_podtl_rowid = Convert.ToInt32(dt.Rows[i]["In_podtl_rowid"]);
                    ObjShipDtls.In_po_no = dt.Rows[i]["In_po_no"].ToString();
                    ObjShipDtls.In_sl_no = Convert.ToInt32(dt.Rows[i]["In_sl_no"]);
                    ObjShipDtls.In_address = dt.Rows[i]["In_address"].ToString();
                    ObjShipDtls.In_qty = Convert.ToDouble(dt.Rows[i]["In_qty"]);
                    ObjShipDtls.In_product_code = dt.Rows[i]["In_product_code"].ToString();
                    ObjShipDtls.In_mode_flag = dt.Rows[i]["In_mode_flag"].ToString();
                    objinvoiceRoot.context.ShipDetail.Add(ObjShipDtls);

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
    }

}


