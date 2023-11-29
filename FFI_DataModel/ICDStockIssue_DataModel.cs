using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace FFI_DataModel
{
    public class ICDStockIssue_DataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FarmerReg_DataModel)); //Declaring Log4Net. 
        string methodName = "";
        public ICDStockIssue_Model IssueTransferList(string org, string locn, string user, string lang, string filterby_option, string filterby_code, string filterby_fromvalue, string filterby_tovalue, string issue_status, string mysqlcon)
        {
            ICDStockIssue_Model ObjIssue = new ICDStockIssue_Model();
            try
            {
                methodName = MethodBase.GetCurrentMethod().Name;
                DataTable dt = new DataTable();

                MysqlCon = new DataConnection(mysqlcon);
                MySqlCommand cmd = new MySqlCommand("ICDMOB_fetch_stockIssue_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                cmd.Parameters.Add("in_filterby_option", MySqlDbType.VarChar).Value = filterby_option;
                cmd.Parameters.Add("in_filterby_code", MySqlDbType.VarChar).Value = filterby_code;
                cmd.Parameters.Add("in_filterby_fromvalue", MySqlDbType.VarChar).Value = filterby_fromvalue;
                cmd.Parameters.Add("in_filterby_tovalue", MySqlDbType.VarChar).Value = filterby_tovalue;
                cmd.Parameters.Add("In_issue_status", MySqlDbType.VarChar).Value = issue_status;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                LogHelper.ConvertCmdIntoString(cmd);
                MysqlCon.con.Close();

                List<StockIssueList> objIssueList = new List<StockIssueList>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    StockIssueList objList = new StockIssueList();
                    objList.Out_inward_rowid = Convert.ToInt32(dt.Rows[i]["Out_inward_rowid"]);
                    objList.Out_ic_code = dt.Rows[i]["Out_ic_code"].ToString();
                    objList.Out_ic_name = dt.Rows[i]["Out_ic_name"].ToString();
                    objList.Out_grn_no = dt.Rows[i]["Out_grn_no"].ToString();
                    objList.Out_grn_date = dt.Rows[i]["Out_grn_date"].ToString();
                    objList.Out_supplier_name = dt.Rows[i]["Out_supplier_name"].ToString();
                    objList.Out_supplier_location = dt.Rows[i]["Out_supplier_location"].ToString();
                    objList.Out_from_state = dt.Rows[i]["Out_from_state"].ToString();
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.received_qty = Convert.ToDecimal(dt.Rows[i]["received_qty"].ToString());
                    objList.accepted_qty = Convert.ToDecimal(dt.Rows[i]["accepted_qty"].ToString());
                    objList.product_code = dt.Rows[i]["product_code"].ToString();
                    objList.uom_code = dt.Rows[i]["uom_code"].ToString();
                    objList.Out_product_name = dt.Rows[i]["Out_product_name"].ToString();
                    objList.noofstock = Convert.ToDecimal(dt.Rows[i]["noofstock"].ToString());
                    objIssueList.Add(objList);
                }
                ObjIssue.IssueTransferList = objIssueList;
            }
            catch (Exception ex)
            {
            }
            return ObjIssue;
        }
    }
}
