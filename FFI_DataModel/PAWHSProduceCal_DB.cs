using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
   public class PAWHSProduceCal_DB
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInvoice_DataModel)); //Declaring Log4Net. 
        public PAWHSProduceCalApplication Getallproduce_calendar_DB(PAWHSProduceCalContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();

            PAWHSProduceCalApplication objinvoiceRoot = new PAWHSProduceCalApplication();
            PAWHSProduceCal_DB objDataModel = new PAWHSProduceCal_DB();

            objinvoiceRoot.context = new PAWHSProduceCalContext();
            objinvoiceRoot.context.List = new List<PAWHSProduceCalList>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_produce_calendar_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
                cmd.Parameters.Add("In_filterby_option", MySqlDbType.VarChar).Value = objinvoice.FilterBy_Option;
                cmd.Parameters.Add("In_filterby_code", MySqlDbType.VarChar).Value = objinvoice.FilterBy_Code;
                cmd.Parameters.Add("In_filterby_fromvalue", MySqlDbType.VarChar).Value = objinvoice.FilterBy_FromValue;
                cmd.Parameters.Add("In_filterby_tovalue", MySqlDbType.VarChar).Value = objinvoice.FilterBy_ToValue;
                

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PAWHSProduceCalList objList = new PAWHSProduceCalList();
                    objList.Out_producecal_rowid = Convert.ToInt32(dt.Rows[i]["Out_producecal_rowid"]);
                    objList.Out_pac_no = dt.Rows[i]["Out_pac_no"].ToString();
                    objList.Out_pac_year = dt.Rows[i]["Out_pac_year"].ToString();
                    objList.Out_pac_date = dt.Rows[i]["Out_pac_date"].ToString();
                    objList.Out_agg_code = dt.Rows[i]["Out_agg_code"].ToString();
                    objList.Out_farmer_code = dt.Rows[i]["Out_farmer_code"].ToString();
                    objList.Out_item_code = dt.Rows[i]["Out_item_code"].ToString();
                    objList.Out_jan = Convert.ToInt32(dt.Rows[i]["Out_jan"]);
                    objList.Out_feb = Convert.ToInt32(dt.Rows[i]["Out_feb"]);
                    objList.Out_mar = Convert.ToInt32(dt.Rows[i]["Out_mar"]);
                    objList.Out_apr = Convert.ToInt32(dt.Rows[i]["Out_apr"]);
                    objList.Out_may = Convert.ToInt32(dt.Rows[i]["Out_may"]);
                    objList.Out_jun = Convert.ToInt32(dt.Rows[i]["Out_jun"]);
                    objList.Out_jul = Convert.ToInt32(dt.Rows[i]["Out_jul"]);
                    objList.Out_aug = Convert.ToInt32(dt.Rows[i]["Out_aug"]);
                    objList.Out_sep = Convert.ToInt32(dt.Rows[i]["Out_sep"]);
                    objList.Out_oct = Convert.ToInt32(dt.Rows[i]["Out_oct"]);
                    objList.Out_nov = Convert.ToInt32(dt.Rows[i]["Out_nov"]);
                    objList.Out_dec = Convert.ToInt32(dt.Rows[i]["Out_dec"]);
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.Out_status_desc = dt.Rows[i]["Out_status_desc"].ToString();                   
                    objList.Out_row_timestamp = dt.Rows[i]["Out_row_timestamp"].ToString();
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
        public PAWHSProduceCalFApplication Getproduce_calendar_DB(PAWHSProduceCalFContext objfpoSearch, string mysqlcon)
        {
            DataSet ds = new DataSet();

            PAWHSProduceCalFApplication objfpoSearchRoot = new PAWHSProduceCalFApplication();
            PAWHSProduceCal_DB objDataModel = new PAWHSProduceCal_DB();

            DataTable Map = new DataTable();


            objfpoSearchRoot.context = new PAWHSProduceCalFContext();
            objfpoSearchRoot.context.Header = new PAWHSProduceCalFHeader();
            objfpoSearchRoot.context.List = new List<PAWHSProduceCalFList>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_produce_calendar", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objfpoSearch.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objfpoSearch.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objfpoSearch.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objfpoSearch.localeId;
                cmd.Parameters.Add("IOU_producecal_rowid", MySqlDbType.VarChar).Value = objfpoSearch.producecal_rowid;
                cmd.Parameters.Add("IOU_pac_no", MySqlDbType.VarChar).Value = objfpoSearch.pac_no;
                cmd.Parameters.Add(new MySqlParameter("In_pac_date", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_pac_year", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_farmer_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_farmer_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_producecal_rowid1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_pac_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                MysqlCon.con.Close();
                if (ds.Tables.Count > 0)
                {
                    Map = ds.Tables[0];

                    for (int i = 0; i < Map.Rows.Count; i++)
                    {
                        PAWHSProduceCalFList objDetailList = new PAWHSProduceCalFList();
                        objDetailList.In_item_rowid = Convert.ToInt32(Map.Rows[i]["In_item_rowid"]);
                        objDetailList.In_item_code = Map.Rows[i]["In_item_code"].ToString();
                        objDetailList.In_item_desc = Map.Rows[i]["In_item_desc"].ToString();
                        objDetailList.In_uom = Map.Rows[i]["In_uom"].ToString();
                        objDetailList.In_jan = Convert.ToInt32(Map.Rows[i]["In_jan"]);
                        objDetailList.In_feb = Convert.ToInt32(Map.Rows[i]["In_feb"]);
                        objDetailList.In_mar = Convert.ToInt32(Map.Rows[i]["In_mar"]);
                        objDetailList.In_apr = Convert.ToInt32(Map.Rows[i]["In_apr"]);
                        objDetailList.In_may = Convert.ToInt32(Map.Rows[i]["In_may"]);
                        objDetailList.In_jun = Convert.ToInt32(Map.Rows[i]["In_jun"]);
                        objDetailList.In_jul = Convert.ToInt32(Map.Rows[i]["In_jul"]);
                        objDetailList.In_aug = Convert.ToInt32(Map.Rows[i]["In_aug"]);
                        objDetailList.In_sep = Convert.ToInt32(Map.Rows[i]["In_sep"]);
                        objDetailList.In_oct = Convert.ToInt32(Map.Rows[i]["In_oct"]);
                        objDetailList.In_nov = Convert.ToInt32(Map.Rows[i]["In_nov"]);
                        objDetailList.In_dec = Convert.ToInt32(Map.Rows[i]["In_dec"]);
                        objDetailList.In_status_code = Map.Rows[i]["In_status_code"].ToString();
                        objDetailList.In_status_desc = Map.Rows[i]["In_status_desc"].ToString();
                        objDetailList.In_mode_flag = Map.Rows[i]["In_mode_flag"].ToString();
                        objfpoSearchRoot.context.List.Add(objDetailList);
                    }
                    objfpoSearchRoot.context.orgnId = objfpoSearch.orgnId;
                    objfpoSearchRoot.context.locnId = objfpoSearch.locnId;
                    objfpoSearchRoot.context.userId = objfpoSearch.userId;
                    objfpoSearchRoot.context.localeId = objfpoSearch.localeId;

                    objfpoSearchRoot.context.Header.IOU_producecal_rowid = (Int32)cmd.Parameters["IOU_producecal_rowid"].Value;
                    objfpoSearchRoot.context.Header.IOU_pac_no = (string)cmd.Parameters["IOU_pac_no"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_pac_date = (string)cmd.Parameters["In_pac_date"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_pac_year = (string)cmd.Parameters["In_pac_year"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_farmer_code = (string)cmd.Parameters["In_farmer_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_farmer_name = (string)cmd.Parameters["IOU_pac_no"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                    objfpoSearchRoot.context.Header.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objfpoSearchRoot;
        }
        public PAWHSProduceCalSDocument Savenew_produce_calendar_DB(PAWHSProduceCalSApplication ObjContext, string mysqlcon)
        {
            int ret = 0;
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            PAWHSProduceCalSDocument objresFarmer = new PAWHSProduceCalSDocument();
            objresFarmer.context = new PAWHSProduceCalSContext();
            objresFarmer.context.Header = new PAWHSProduceCalSHeader();
            objresFarmer.context.List = new List<PAWHSProduceCalSList>();
            objresFarmer.ApplicationException = new PAWHSProduceCalSApplicationException();
            string IOU_producecal_rowid1 = "";
            string IOU_pac_no1 = "";
            string errorNo = "";
            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }

                MySqlCommand cmd = new MySqlCommand("PAWHS_insupd_produce_calendar", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_pac_date", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_pac_date;
                cmd.Parameters.Add("In_pac_year", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_pac_year;
                cmd.Parameters.Add("In_farmer_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_farmer_code;
                cmd.Parameters.Add("In_farmer_name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_farmer_name;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_status_desc", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_status_desc;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmd.Parameters.Add("IOU_producecal_rowid", MySqlDbType.Int32).Value = ObjContext.document.context.Header.IOU_producecal_rowid;
                cmd.Parameters.Add("IOU_pac_no", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_pac_no;
                cmd.Parameters.Add(new MySqlParameter("IOU_producecal_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_pac_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                ret = cmd.ExecuteNonQuery();

                if (ret > 0)
                {
                   
                    IOU_pac_no1 = (string)cmd.Parameters["IOU_pac_no1"].Value;
                    
                    objresFarmer.context.Header.IOU_producecal_rowid = (Int32)cmd.Parameters["IOU_producecal_rowid1"].Value;
                    objresFarmer.context.Header.IOU_pac_no = IOU_pac_no1;

                }
                if (objresFarmer.context.Header.IOU_producecal_rowid > 0)
                {
                    string[] FarmersMapped = { };
                    FarmersMapped = SaveProcCal(ObjContext, objresFarmer, mysqlcon, MysqlCon);
                    if (FarmersMapped[0].Contains("060"))
                    {
                        mysqltrans.Rollback();
                        objresFarmer.ApplicationException.errorNumber = FarmersMapped[0].ToString();
                        objresFarmer.ApplicationException.errorDescription = FarmersMapped[1].ToString();
                        return objresFarmer;
                    }
                }
                string[] returnvalues = { IOU_producecal_rowid1, IOU_pac_no1, errorNo };

                mysqltrans.Commit();
                return objresFarmer;
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                throw ex;

            }
        }
        public string[] SaveProcCal(PAWHSProduceCalSApplication Objmodel, PAWHSProduceCalSDocument objfarmer, string MysqlCons, DataConnection MysqlCon)
        {
            string[] result = { };
            string errorNo = "";
            string errorMsg = "";
            DataTable tab = new DataTable();
            PAWHSProduceCalSList objFarmersMapped = new PAWHSProduceCalSList();
            try
            {
                PAWHSProduceCal_DB objproduct1 = new PAWHSProduceCal_DB();
                foreach (var FarmersMap in Objmodel.document.context.List)
                {
                    objFarmersMapped.In_item_rowid = FarmersMap.In_item_rowid;
                    objFarmersMapped.In_item_code = FarmersMap.In_item_code;
                    objFarmersMapped.In_item_desc = FarmersMap.In_item_desc;
                    objFarmersMapped.In_uom = FarmersMap.In_uom;
                    objFarmersMapped.In_jan = FarmersMap.In_jan;
                    objFarmersMapped.In_feb = FarmersMap.In_feb;
                    objFarmersMapped.In_mar = FarmersMap.In_mar;
                    objFarmersMapped.In_apr = FarmersMap.In_apr;
                    objFarmersMapped.In_may = FarmersMap.In_may;
                    objFarmersMapped.In_jun = FarmersMap.In_jun;
                    objFarmersMapped.In_jul = FarmersMap.In_jul;
                    objFarmersMapped.In_aug = FarmersMap.In_aug;
                    objFarmersMapped.In_sep = FarmersMap.In_sep;
                    objFarmersMapped.In_oct = FarmersMap.In_oct;
                    objFarmersMapped.In_nov = FarmersMap.In_nov;
                    objFarmersMapped.In_dec = FarmersMap.In_dec;
                    objFarmersMapped.In_status_code = FarmersMap.In_status_code;
                    objFarmersMapped.In_status_desc = FarmersMap.In_status_desc;
                    objFarmersMapped.In_mode_flag = FarmersMap.In_mode_flag;
                    result = objproduct1.SaveProcCalNew(objFarmersMapped, objfarmer, Objmodel, MysqlCons, MysqlCon);

                    if (result[0].Contains("060"))
                    {
                        errorNo = result[0].ToString();
                        errorMsg = result[1].ToString();
                        break;
                    }
                }
                string[] FarmersMapped = { errorNo, errorMsg };
                return FarmersMapped;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public string[] SaveProcCalNew(PAWHSProduceCalSList ObjKycDtl, PAWHSProduceCalSDocument ObjFarmer, PAWHSProduceCalSApplication Objmodel, string mysqlcons, DataConnection MysqlCon)
        {

            string errorNo = "";
            string errorMsg = "";
            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_iud_produce_calendar", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("IOU_producecal_rowid", MySqlDbType.Int32).Value = ObjFarmer.context.Header.IOU_producecal_rowid;
                cmd.Parameters.Add("IOU_pac_no", MySqlDbType.VarChar).Value = ObjFarmer.context.Header.IOU_pac_no;
                cmd.Parameters.Add("In_item_rowid", MySqlDbType.Int32).Value = ObjKycDtl.In_item_rowid;
                cmd.Parameters.Add("In_item_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_item_code;
                cmd.Parameters.Add("In_item_desc", MySqlDbType.VarChar).Value = ObjKycDtl.In_item_desc;
                cmd.Parameters.Add("In_uom", MySqlDbType.VarChar).Value = ObjKycDtl.In_uom;
                cmd.Parameters.Add("In_jan", MySqlDbType.Int32).Value = ObjKycDtl.In_jan;
                cmd.Parameters.Add("In_feb", MySqlDbType.Int32).Value = ObjKycDtl.In_feb;
                cmd.Parameters.Add("In_mar", MySqlDbType.Int32).Value = ObjKycDtl.In_mar;
                cmd.Parameters.Add("In_apr", MySqlDbType.Int32).Value = ObjKycDtl.In_apr;
                cmd.Parameters.Add("In_may", MySqlDbType.Int32).Value = ObjKycDtl.In_may;
                cmd.Parameters.Add("In_jun", MySqlDbType.Int32).Value = ObjKycDtl.In_jun;
                cmd.Parameters.Add("In_jul", MySqlDbType.Int32).Value = ObjKycDtl.In_jul;
                cmd.Parameters.Add("In_aug", MySqlDbType.Int32).Value = ObjKycDtl.In_aug;
                cmd.Parameters.Add("In_sep", MySqlDbType.Int32).Value = ObjKycDtl.In_sep;
                cmd.Parameters.Add("In_oct", MySqlDbType.Int32).Value = ObjKycDtl.In_oct;
                cmd.Parameters.Add("In_nov", MySqlDbType.Int32).Value = ObjKycDtl.In_nov;
                cmd.Parameters.Add("In_dec", MySqlDbType.Int32).Value = ObjKycDtl.In_dec;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_status_code;
                cmd.Parameters.Add("In_status_desc", MySqlDbType.VarChar).Value = ObjKycDtl.In_status_desc;
                cmd.Parameters.Add("in_mode_flag", MySqlDbType.VarChar).Value = ObjKycDtl.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;

                ret = cmd.ExecuteNonQuery();
                if (ret == 0)
                {

                    errorNo = (string)cmd.Parameters["errorNo"].Value;
                    errorMsg = ObjErrormsg.ErrorMessage(errorNo);

                }
                string[] result = { errorNo, errorMsg };
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
