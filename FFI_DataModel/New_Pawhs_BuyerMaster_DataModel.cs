using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using static FFI_Model.New_Pawhs_BuyerMaster_Model;

namespace FFI_DataModel
{
    public class New_Pawhs_BuyerMaster_DataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(New_Pawhs_BuyerMaster_DataModel)); //Declaring Log4Net. 
        string methodName = MethodBase.GetCurrentMethod().Name;

        public PawhsBuyerMasterApplication PawhsBuyerMaster_List(PawhsBuyerMasterContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            PawhsBuyerMasterApplication ObjFetchAll = new PawhsBuyerMasterApplication();
            ObjFetchAll.context = new PawhsBuyerMasterContext();
            ObjFetchAll.context.List = new List<PawhsBuyerMasterList>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_fetch_buyer_reg_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("In_filterby_option", MySqlDbType.VarChar).Value = ObjContext.FilterBy_Option;
                cmd.Parameters.Add("In_filterby_code", MySqlDbType.VarChar).Value = ObjContext.FilterBy_Code;
                cmd.Parameters.Add("In_filterby_fromvalue", MySqlDbType.VarChar).Value = ObjContext.FilterBy_FromValue;
                cmd.Parameters.Add("In_filterby_tovalue", MySqlDbType.VarChar).Value = ObjContext.FilterBy_ToValue;
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PawhsBuyerMasterList objList = new PawhsBuyerMasterList();
                    objList.Out_buyer_rowid = Convert.ToInt32(dt.Rows[i]["Out_buyer_rowid"]);
                    objList.Out_agg_code = dt.Rows[i]["Out_agg_code"].ToString();
                    objList.Out_agg_name = dt.Rows[i]["Out_agg_name"].ToString();
                    objList.Out_buyer_code = dt.Rows[i]["Out_buyer_code"].ToString();
                    objList.Out_version_no = dt.Rows[i]["Out_version_no"].ToString();
                    objList.Out_buyer_name = dt.Rows[i]["Out_buyer_name"].ToString();
                    objList.Out_pan_no = dt.Rows[i]["Out_pan_no"].ToString();
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.Out_status_desc = dt.Rows[i]["Out_status_desc"].ToString();
                    objList.Out_row_timestamp = dt.Rows[i]["Out_row_timestamp"].ToString();
                    objList.Out_mob_no = dt.Rows[i]["Out_mob_no"].ToString();
                    objList.Out_whatsapp_no = dt.Rows[i]["Out_whatsapp_no"].ToString();
                    objList.Out_contact_person = dt.Rows[i]["Out_contact_person"].ToString();
                    objList.Out_emailid = dt.Rows[i]["Out_emailid"].ToString();
                    objList.Out_onboarding_date = dt.Rows[i]["Out_onboarding_date"].ToString();
                    objList.Out_buyer_type = dt.Rows[i]["Out_buyer_type"].ToString();

                    ObjFetchAll.context.List.Add(objList);
                }
                ObjFetchAll.context.orgnId = ObjContext.orgnId;
                ObjFetchAll.context.locnId = ObjContext.locnId;
                ObjFetchAll.context.userId = ObjContext.userId;
                ObjFetchAll.context.localeId = ObjContext.localeId;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }

            return ObjFetchAll;
        }
        public PawhsBuyerMasterFetchApplication PawhsBuyerMaster_SingleFetch(PawhsBuyerMasterFetchContext objfpoSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();

            PawhsBuyerMasterFetchApplication objfpoSearchRoot = new PawhsBuyerMasterFetchApplication();

            DataTable Map = new DataTable();
            DataTable OtherDt = new DataTable();
            DataTable SlnoDt = new DataTable();

            objfpoSearchRoot.context = new PawhsBuyerMasterFetchContext();
            objfpoSearchRoot.context.Header = new PawhsBuyerMasterFetchHeader();
            objfpoSearchRoot.context.buyerAddress = new List<PawhsBuyerMasterFetchAddress>();
            objfpoSearchRoot.context.buyerTax = new List<PawhsBuyerMasterFetchTax>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("New_PAWHS_fetch_buyer_reg", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;
                cmd.Parameters.Add("In_buyer_rowid", MySqlDbType.Int32).Value = objfpoSearch.buyer_rowid;
                cmd.Parameters.Add("In_buyer_code", MySqlDbType.VarChar).Value = objfpoSearch.buyer_code;
                cmd.Parameters.Add("In_version_no", MySqlDbType.VarChar).Value = objfpoSearch.version_no;
                cmd.Parameters.Add(new MySqlParameter("In_buyer_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_buyer_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_version_no1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_buyer_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_pan_no", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.LongText)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_agg_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_agg_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();
                if (ds.Tables.Count > 0)
                {
                    //Map = ds.Tables[0];
                    //for (int i = 0; i < Map.Rows.Count; i++)
                    //{
                    //    PAWHSbuyerFetchDetail objDetailList = new PAWHSbuyerFetchDetail(); 
                    //    objDetailList.In_buyer_name = Map.Rows[i]["In_buyer_name"].ToString();
                    //    objDetailList.In_pan_no = Map.Rows[i]["In_pan_no"].ToString();
                    //    objDetailList.In_status_code = Map.Rows[i]["In_status_code"].ToString();
                    //    objDetailList.In_status_desc = Map.Rows[i]["In_status_desc"].ToString(); 
                    //    objDetailList.In_row_timestamp = Map.Rows[i]["In_row_timestamp"].ToString();
                    //    objDetailList.In_mode_flag = Map.Rows[i]["In_mode_flag"].ToString();
                    //    objfpoSearchRoot.context.Detail.Add(objDetailList);
                    //}
                    OtherDt = ds.Tables[0];
                    for (int i = 0; i < OtherDt.Rows.Count; i++)
                    {
                        PawhsBuyerMasterFetchAddress ObjOtherList = new PawhsBuyerMasterFetchAddress();
                        ObjOtherList.In_buyer_addr_rowid = (Int32)OtherDt.Rows[i]["In_buyer_addr_rowid"];
                        ObjOtherList.In_buyeraddr_type = OtherDt.Rows[i]["In_buyeraddr_type"].ToString();
                        ObjOtherList.In_buyer_addr_type_desc = OtherDt.Rows[i]["In_buyer_addr_type_desc"].ToString();
                        ObjOtherList.In_buyer_addr1 = OtherDt.Rows[i]["In_buyer_addr1"].ToString();
                        ObjOtherList.In_buyer_addr2 = OtherDt.Rows[i]["In_buyer_addr2"].ToString();
                        ObjOtherList.In_buyer_country = OtherDt.Rows[i]["In_buyer_country"].ToString();
                        ObjOtherList.In_buyer_country_desc = OtherDt.Rows[i]["In_buyer_country_desc"].ToString();
                        ObjOtherList.In_buyer_state = OtherDt.Rows[i]["In_buyer_state"].ToString();
                        ObjOtherList.In_buyer_state_desc = OtherDt.Rows[i]["In_buyer_state_desc"].ToString();
                        ObjOtherList.In_buyer_dist = OtherDt.Rows[i]["In_buyer_dist"].ToString();
                        ObjOtherList.In_buyer_dist_desc = OtherDt.Rows[i]["In_buyer_dist_desc"].ToString();
                        ObjOtherList.In_buyer_taluk = OtherDt.Rows[i]["In_buyer_taluk"].ToString();
                        ObjOtherList.In_buyer_taluk_desc = OtherDt.Rows[i]["In_buyer_taluk_desc"].ToString();
                        ObjOtherList.In_buyer_panchayat = OtherDt.Rows[i]["In_buyer_panchayat"].ToString();
                        ObjOtherList.In_buyer_panchayat_desc = OtherDt.Rows[i]["In_buyer_panchayat_desc"].ToString();
                        ObjOtherList.In_buyer_village = OtherDt.Rows[i]["In_buyer_village"].ToString();
                        ObjOtherList.In_buyer_village_desc = OtherDt.Rows[i]["In_buyer_village_desc"].ToString();
                        ObjOtherList.In_buyer_pincode = OtherDt.Rows[i]["In_buyer_pincode"].ToString();
                        ObjOtherList.In_buyer_pincode_desc = OtherDt.Rows[i]["In_buyer_pincode_desc"].ToString();
                        ObjOtherList.In_status_code = OtherDt.Rows[i]["In_status_code"].ToString();
                        ObjOtherList.In_status_desc = OtherDt.Rows[i]["In_status_desc"].ToString();
                        ObjOtherList.In_mode_flag = OtherDt.Rows[i]["In_mode_flag"].ToString();
                        objfpoSearchRoot.context.buyerAddress.Add(ObjOtherList);
                    }
                    SlnoDt = ds.Tables[1];
                    for (int i = 0; i < SlnoDt.Rows.Count; i++)
                    {
                        PawhsBuyerMasterFetchTax ObjSlnoList = new PawhsBuyerMasterFetchTax();
                        ObjSlnoList.In_tax_rowid = Convert.ToInt32(SlnoDt.Rows[i]["In_tax_rowid"]);
                        ObjSlnoList.In_tax_type = SlnoDt.Rows[i]["In_tax_type"].ToString();
                        ObjSlnoList.In_tax_reg_no = SlnoDt.Rows[i]["In_tax_reg_no"].ToString();
                        ObjSlnoList.In_state_code = SlnoDt.Rows[i]["In_state_code"].ToString();
                        ObjSlnoList.In_state_desc = SlnoDt.Rows[i]["In_state_desc"].ToString();
                        ObjSlnoList.In_status_code = SlnoDt.Rows[i]["In_status_code"].ToString();
                        ObjSlnoList.In_status_desc = SlnoDt.Rows[i]["In_status_desc"].ToString();
                        ObjSlnoList.In_mode_flag = SlnoDt.Rows[i]["In_mode_flag"].ToString();
                        objfpoSearchRoot.context.buyerTax.Add(ObjSlnoList);
                    }
                    objfpoSearchRoot.context.orgnId = objfpoSearch.orgnId;
                    objfpoSearchRoot.context.locnId = objfpoSearch.locnId;
                    objfpoSearchRoot.context.userId = objfpoSearch.userId;
                    objfpoSearchRoot.context.localeId = objfpoSearch.localeId;
                    objfpoSearchRoot.context.buyer_rowid = objfpoSearch.buyer_rowid;
                    objfpoSearchRoot.context.buyer_code = objfpoSearch.buyer_code;
                    objfpoSearchRoot.context.version_no = objfpoSearch.version_no;

                    objfpoSearchRoot.context.Header.In_buyer_rowid = (Int32)cmd.Parameters["In_buyer_rowid1"].Value;
                    objfpoSearchRoot.context.Header.In_buyer_code = (string)cmd.Parameters["In_buyer_code1"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_version_no = (Int32)cmd.Parameters["In_version_no1"].Value;
                    objfpoSearchRoot.context.Header.In_buyer_name = (string)cmd.Parameters["In_buyer_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_pan_no = (string)cmd.Parameters["In_pan_no"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_agg_name = (string)cmd.Parameters["In_agg_name"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_agg_code = (string)cmd.Parameters["In_agg_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_MobileNo = objfpoSearch.Header.In_MobileNo;
                    objfpoSearchRoot.context.Header.In_WhatsappeNo = objfpoSearch.Header.In_WhatsappeNo;
                    objfpoSearchRoot.context.Header.In_Contact_name = objfpoSearch.Header.In_Contact_name;
                    objfpoSearchRoot.context.Header.In_Email = objfpoSearch.Header.In_Email;
                    objfpoSearchRoot.context.Header.In_Onboard_Date = objfpoSearch.Header.In_Onboard_Date;
                    objfpoSearchRoot.context.Header.In_buyer_type = objfpoSearch.Header.In_buyer_type;
                }
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objfpoSearch.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // throw ex;
            }
            return objfpoSearchRoot;
        }


        public SavebuyerDocument SaveBuyerMaster_DB(SavebuyerApplication objBuyMas, string ConString)

        {
            string[] response = { };
            SavebuyerDocument ObjFetch = new SavebuyerDocument();
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            try
            {
                int ret = 0;
                int retdtls = 0;
                string errormsg = "";
                MysqlCon = new DataConnection(ConString);
                SavebuyerContext objContext = new SavebuyerContext();
                objContext.orgnId = objBuyMas.document.context.orgnId;
                objContext.localeId = objBuyMas.document.context.localeId;
                objContext.locnId = objBuyMas.document.context.locnId;
                objContext.userId = objBuyMas.document.context.userId;
                ObjFetch.context = objContext;
                SavebuyerHeader objOutHeader = new SavebuyerHeader();
                ObjFetch.ApplicationException = new PawhsBuyerMasterApplicationException();

                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }


                FFI_Model.ApplicationException objex = new FFI_Model.ApplicationException();
                MySqlCommand cmd = new MySqlCommand("New_PAWHS_insupd_buyer_reg", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_buyer_rowid", MySqlDbType.VarChar).Value = objBuyMas.document.context.Header.In_buyer_rowid;
                cmd.Parameters.Add("In_buyer_code", MySqlDbType.VarChar).Value = objBuyMas.document.context.Header.In_buyer_code;
                cmd.Parameters.Add("In_version_no", MySqlDbType.VarChar).Value = objBuyMas.document.context.Header.In_version_no;
                cmd.Parameters.Add("In_buyer_name", MySqlDbType.VarChar).Value = objBuyMas.document.context.Header.In_buyer_name;
                cmd.Parameters.Add("In_pan_no", MySqlDbType.VarChar).Value = objBuyMas.document.context.Header.In_pan_no;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = objBuyMas.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = objBuyMas.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = objBuyMas.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("In_MobileNo", MySqlDbType.VarChar).Value = objBuyMas.document.context.Header.In_MobileNo;
                cmd.Parameters.Add("In_WhatsappNo", MySqlDbType.VarChar).Value = objBuyMas.document.context.Header.In_WhatsappeNo;
                cmd.Parameters.Add("In_ContactPerson", MySqlDbType.VarChar).Value = objBuyMas.document.context.Header.In_Contact_name;
                cmd.Parameters.Add("In_Email", MySqlDbType.VarChar).Value = objBuyMas.document.context.Header.In_Email;
                cmd.Parameters.Add("In_OnBoarding", MySqlDbType.VarChar).Value = objBuyMas.document.context.Header.In_Onboard_Date;
                cmd.Parameters.Add("In_Type", MySqlDbType.VarChar).Value = objBuyMas.document.context.Header.module_code;

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objBuyMas.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objBuyMas.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objBuyMas.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objBuyMas.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("In_buyer_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_buyer_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                retdtls = cmd.ExecuteNonQuery();

                //Information Log Purpose Written Start 
                logger.Debug("SP Name  - New_PAWHS_insupd_buyer_reg");
                logger.Debug("Input Parameters" + objBuyMas.document.context.orgnId + "," + objBuyMas.document.context.locnId + "," + objBuyMas.document.context.userId + "," + objBuyMas.document.context.localeId);

                if (retdtls > 0)
                {
                    objOutHeader.In_buyer_rowid1 = (Int32)cmd.Parameters["In_buyer_rowid1"].Value;
                    objOutHeader.In_buyer_code1 = (string)cmd.Parameters["In_buyer_code1"].Value;
                    objOutHeader.errorNo = (string)cmd.Parameters["errorNo"].Value;
                    errormsg = (string)cmd.Parameters["errorNo"].Value;
                }
                else
                {
                    objOutHeader.errorNo = (string)cmd.Parameters["errorNo"].Value;
                    errormsg = (string)cmd.Parameters["errorNo"].Value;
                }
                bool isvaild = true;
                if (objOutHeader.errorNo != "")
                {
                    mysqltrans.Rollback();
                    isvaild = false;
                    ObjFetch.ApplicationException.errorDescription = errormsg.ToString();
                    return ObjFetch;


                }
                objContext.Header = objOutHeader;

                if (objOutHeader.In_buyer_rowid1 > 0)
                {
                    foreach (var Details in objBuyMas.document.context.buyerAddress)
                    {
                        MySqlCommand cmds = new MySqlCommand("New_PAWHS_iud_buyer_addr", MysqlCon.con);
                        cmds.CommandType = CommandType.StoredProcedure;
                        cmds.Parameters.Add("In_buyeraddr_rowid", MySqlDbType.Int32).Value = Details.In_buyeraddr_rowid;
                        cmds.Parameters.Add("In_version_no", MySqlDbType.Int32).Value = Details.In_version_no;
                        cmds.Parameters.Add("In_buyer_code", MySqlDbType.VarChar).Value = string.IsNullOrEmpty(Details.In_buyer_code) ? objOutHeader.In_buyer_code1 : Details.In_buyer_code;
                        cmds.Parameters.Add("In_buyeraddr_type", MySqlDbType.VarChar).Value = Details.In_buyeraddr_type;
                        cmds.Parameters.Add("In_buyer_addr1", MySqlDbType.VarChar).Value = Details.In_buyer_addr1;
                        cmds.Parameters.Add("In_buyer_addr2", MySqlDbType.VarChar).Value = Details.In_buyer_addr2;
                        cmds.Parameters.Add("In_buyer_country", MySqlDbType.VarChar).Value = Details.In_buyer_country;
                        cmds.Parameters.Add("In_buyer_state", MySqlDbType.VarChar).Value = Details.In_buyer_state;
                        cmds.Parameters.Add("In_buyer_dist", MySqlDbType.VarChar).Value = Details.In_buyer_dist;
                        cmds.Parameters.Add("In_buyer_taluk", MySqlDbType.VarChar).Value = Details.In_buyer_taluk;
                        cmds.Parameters.Add("In_buyer_panchayat", MySqlDbType.VarChar).Value = Details.In_buyer_panchayat;
                        cmds.Parameters.Add("In_buyer_village", MySqlDbType.VarChar).Value = Details.In_buyer_village;
                        cmds.Parameters.Add("In_buyer_pincode", MySqlDbType.VarChar).Value = Details.In_buyer_pincode;
                        cmds.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = Details.In_status_code;
                        cmds.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Details.In_mode_flag;
                        cmds.Parameters.Add("In_buyer_rowid1", MySqlDbType.VarChar).Value = objBuyMas.document.context.Header.In_buyer_rowid1;
                        cmds.Parameters.Add("In_buyer_code1", MySqlDbType.VarChar).Value = objBuyMas.document.context.Header.In_buyer_code1;
                        cmds.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objBuyMas.document.context.orgnId;
                        cmds.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objBuyMas.document.context.locnId;
                        cmds.Parameters.Add("userId", MySqlDbType.VarChar).Value = objBuyMas.document.context.userId;
                        cmds.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objBuyMas.document.context.localeId;
                        cmds.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                        string Reponse3 = LogHelper.ConvertObjectIntoString(Details);
                        logger.Debug("Input Parameters -" + Reponse3);
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
                        foreach (var Details in objBuyMas.document.context.buyerTax)
                        {
                            MySqlCommand cmdf = new MySqlCommand("New_PAWHS_iud_buyer_tax", MysqlCon.con);
                            cmdf.CommandType = CommandType.StoredProcedure;
                            cmdf.Parameters.Add("In_tax_rowid", MySqlDbType.Int32).Value = Details.In_tax_rowid;
                            cmdf.Parameters.Add("In_tax_type", MySqlDbType.VarChar).Value = Details.In_tax_type;
                            cmdf.Parameters.Add("In_buyer_code", MySqlDbType.VarChar).Value = string.IsNullOrEmpty(Details.In_buyer_code) ? objOutHeader.In_buyer_code1 : Details.In_buyer_code;
                            cmdf.Parameters.Add("In_version_no", MySqlDbType.Int32).Value = Details.In_version_no;
                            cmdf.Parameters.Add("In_tax_reg_no", MySqlDbType.VarChar).Value = Details.In_tax_reg_no;
                            cmdf.Parameters.Add("In_state_code", MySqlDbType.VarChar).Value = Details.In_state_code;
                            cmdf.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = Details.In_status_code;
                            cmdf.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Details.In_mode_flag;
                            cmdf.Parameters.Add("In_buyer_rowid1", MySqlDbType.Int32).Value = objBuyMas.document.context.Header.In_buyer_rowid1;
                            cmdf.Parameters.Add("In_buyer_code1", MySqlDbType.VarChar).Value = objBuyMas.document.context.Header.In_buyer_code1;
                            cmdf.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objBuyMas.document.context.orgnId;
                            cmdf.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objBuyMas.document.context.locnId;
                            cmdf.Parameters.Add("userId", MySqlDbType.VarChar).Value = objBuyMas.document.context.userId;
                            cmdf.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objBuyMas.document.context.localeId;
                            string Reponse2 = LogHelper.ConvertObjectIntoString(Details);
                            logger.Debug("Input Parameters -" + Reponse2);
                            ret = cmdf.ExecuteNonQuery();
                            if (ret == 0)
                            {
                                mysqltrans.Rollback();
                                isvaild = false;
                                break;
                            }

                        }
                    }
                    else
                    {
                        mysqltrans.Rollback();
                    }
                    if (MysqlCon.con.State == ConnectionState.Open)
                    {
                        mysqltrans.Commit();
                        MysqlCon.con.Close();
                    }
                    //  ObjFetch.ApplicationException = objex;



                }
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                throw (ex);
            }
            return ObjFetch;



        }
    }
}
