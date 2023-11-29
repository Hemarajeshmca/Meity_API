using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FFI_DataModel
{
  public class PAWHS_NEW_Localization_DB
    {
        public DataConnection MysqlCon;
        MySqlTransaction mysqltrans;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHS_NEW_Localization_DB)); //Declaring Log4Net. 
        public MFMApplication GetallFarmermaster_DB(MFMContext objinvoice, string mysqlcon)
        {
            DataTable dt = new DataTable();

            MFMApplication objinvoiceRoot = new MFMApplication();
            Mobile_FDR_Datamodel objDataModel = new Mobile_FDR_Datamodel();

            objinvoiceRoot.context = new MFMContext();
            objinvoiceRoot.context.detail = new List<MFMDetail>();

            MysqlCon = new DataConnection(mysqlcon);
            try
            {

                MySqlCommand cmd = new MySqlCommand("NEW_PAWHS_master_definition", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objinvoice.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = objinvoice.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = objinvoice.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = objinvoice.localeId;
                cmd.Parameters.Add("in_MODULE", MySqlDbType.VarChar).Value = objinvoice.module;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MFMDetail objList = new MFMDetail();
                    objList.out_master_rowid = Convert.ToInt32(dt.Rows[i]["out_master_rowid"]);
                    objList.out_parent_code = dt.Rows[i]["out_parent_code"].ToString();
                    objList.out_master_code = dt.Rows[i]["out_master_code"].ToString();
                    objList.out_master_description = dt.Rows[i]["out_master_description"].ToString();
                    objList.out_depend_code = dt.Rows[i]["out_depend_code"].ToString();
                    objList.out_depend_desc = dt.Rows[i]["out_depend_desc"].ToString();
                    objList.out_locallang_flag = dt.Rows[i]["out_locallang_flag"].ToString();
                    objList.out_status_code = dt.Rows[i]["out_status_code"].ToString();
                    objList.out_status_desc = dt.Rows[i]["out_status_desc"].ToString();
                    objinvoiceRoot.context.detail.Add(objList);

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
