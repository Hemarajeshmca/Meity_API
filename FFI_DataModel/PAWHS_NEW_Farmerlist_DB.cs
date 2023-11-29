using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
   public class PAWHS_NEW_Farmerlist_DB
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Mobile_FDR_FList_DB)); //Declaring Log4Net. 
        public PAWHSFarmerRootObject GetAllFarmerList_DB(PAWHSFarmerContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();

            PAWHSFarmerRootObject objinvoiceRoot = new PAWHSFarmerRootObject();
            Mobile_FDR_Datamodel objDataModel = new Mobile_FDR_Datamodel();

            objinvoiceRoot.context = new PAWHSFarmerContext();
            objinvoiceRoot.context.List = new List<PAWHSFarmerList>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("New_PAWHS_fetch_farmer_reg_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_filterby_option", MySqlDbType.VarChar).Value = objinvoice.FilterBy_Option;
                cmd.Parameters.Add("In_filterby_code", MySqlDbType.VarChar).Value = objinvoice.FilterBy_Code;
                cmd.Parameters.Add("In_filterby_fromvalue", MySqlDbType.VarChar).Value = objinvoice.FilterBy_FromValue;
                cmd.Parameters.Add("In_filterby_tovalue", MySqlDbType.VarChar).Value = objinvoice.FilterBy_ToValue;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    PAWHSFarmerList objList = new PAWHSFarmerList();
                    objList.farmer_rowid = Convert.ToInt32(dt.Rows[i]["farmer_rowid"]);
                    objList.farmer_code = dt.Rows[i]["farmer_code"].ToString();
                    objList.farmer = dt.Rows[i]["farmer"].ToString();                   
                    objList.farmer_name = dt.Rows[i]["farmer_name"].ToString();
                    objList.fhw_name = dt.Rows[i]["fhw_name"].ToString();
                    objList.farmer_dist = dt.Rows[i]["farmer_dist"].ToString();
                    objList.farmer_dist_desc = dt.Rows[i]["farmer_dist_desc"].ToString();
                    objList.farmer_taluk = dt.Rows[i]["farmer_taluk"].ToString();
                    objList.farmer_taluk_desc = dt.Rows[i]["farmer_taluk_desc"].ToString();
                    objList.farmer_panchayat = dt.Rows[i]["farmer_panchayat"].ToString();
                    objList.farmer_panchayat_desc = dt.Rows[i]["farmer_panchayat_desc"].ToString();
                    objList.farmer_village = dt.Rows[i]["farmer_village"].ToString();
                    objList.farmer_village_desc = dt.Rows[i]["farmer_village_desc"].ToString();
                    objList.farmer_surname = dt.Rows[i]["sur_name"].ToString();
                    objList.farmer_dob = dt.Rows[i]["farmer_dob"].ToString();
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
    }
}
