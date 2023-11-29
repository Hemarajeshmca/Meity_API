using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using FFI_Model;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using MySqlX.XDevAPI.Common;

namespace FFI_DataModel
{
    public class PAWHSItemMaster_DataModel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        public ItemMasterApplication GetAllItemMasterList(ItemMasterContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            ItemMasterApplication ObjFetchAll = new ItemMasterApplication();
            ObjFetchAll.context = new ItemMasterContext();
            ObjFetchAll.context.List = new List<ItemMasterList>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_item_master_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("In_filterby_option", MySqlDbType.VarChar).Value = ObjContext.FilterBy_Option;
                cmd.Parameters.Add("In_filterby_code", MySqlDbType.VarChar).Value = ObjContext.FilterBy_Code;
                cmd.Parameters.Add("In_filterby_fromvalue", MySqlDbType.VarChar).Value = ObjContext.FilterBy_FromValue;
                cmd.Parameters.Add("In_filterby_tovalue", MySqlDbType.VarChar).Value = ObjContext.FilterBy_ToValue;

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ItemMasterList objList = new ItemMasterList();
                    objList.Out_item_rowid = Convert.ToInt32(dt.Rows[i]["Out_item_rowid"]);
                    objList.Out_agg_code = dt.Rows[i]["Out_agg_code"].ToString();
                    objList.Out_item_code = dt.Rows[i]["Out_item_code"].ToString();
                    objList.Out_item_name = dt.Rows[i]["Out_item_name"].ToString();
                    objList.Out_item_ll_name = dt.Rows[i]["Out_item_ll_name"].ToString();
                    objList.Out_item_type = dt.Rows[i]["Out_item_type"].ToString();
                    objList.Out_fg_category = dt.Rows[i]["Out_fg_category"].ToString();
                    objList.Out_fg_subcategory = dt.Rows[i]["Out_fg_subcategory"].ToString();
                    objList.Out_uom_code = dt.Rows[i]["Out_uom_code"].ToString();
                    objList.Out_hsn_code = dt.Rows[i]["Out_hsn_code"].ToString();
                    objList.Out_hsn_description = dt.Rows[i]["Out_hsn_description"].ToString();
                    objList.Out_status_code = dt.Rows[i]["Out_status_code"].ToString();
                    objList.Out_status_desc = dt.Rows[i]["Out_status_desc"].ToString();
                    objList.Out_row_timestamp = dt.Rows[i]["Out_row_timestamp"].ToString();                   

                    ObjFetchAll.context.List.Add(objList);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjFetchAll;
        }
        public SingleItemMasterApplication GetSingleItemMasterDtl(SingleItemMasterContext ObjContext, string mysqlcon)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            MysqlCon = new DataConnection(mysqlcon);

            SingleItemMasterApplication ObjFetchAll = new SingleItemMasterApplication();
            ObjFetchAll.context = new SingleItemMasterContext();
            ObjFetchAll.context.Header = new ItemMasterHeader();
            ObjFetchAll.context.Detail =new List<ItemMasterDetail>();
            try
            {
                MySqlCommand cmd = new MySqlCommand("PAWHS_fetch_item_master", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.localeId;
                cmd.Parameters.Add("IOU_item_rowid", MySqlDbType.Int32).Value = ObjContext.item_rowid;
                cmd.Parameters.Add("IOU_agg_code", MySqlDbType.VarChar).Value = ObjContext.agg_code;
                cmd.Parameters.Add("IOU_item_code", MySqlDbType.VarChar).Value = ObjContext.item_code;

                cmd.Parameters.Add(new MySqlParameter("In_item_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_item_ll_name", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_item_type", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_fg_category", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_fg_subcategory", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_uom_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_hsn_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_hsn_description", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_code", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_status_desc", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_mode_flag", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_row_timestamp", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_item_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_agg_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_item_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
               

                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ItemMasterDetail objList = new ItemMasterDetail();
                    objList.In_item_dtl_rowid = Convert.ToInt32(dt.Rows[i]["In_item_dtl_rowid"]);
                    objList.In_item_code = dt.Rows[i]["In_item_code"].ToString();
                    objList.In_quality = dt.Rows[i]["In_quality"].ToString();
                    objList.In_quality_desc = dt.Rows[i]["In_quality_desc"].ToString();
                    objList.In_base_price =Convert.ToInt32(dt.Rows[i]["In_base_price"]);
                    objList.In_range_1 = dt.Rows[i]["In_range_1"].ToString();
                    objList.In_range_2 = dt.Rows[i]["In_range_2"].ToString();
                    objList.In_range_3 = dt.Rows[i]["In_range_3"].ToString();
                    objList.In_range_4 = dt.Rows[i]["In_range_4"].ToString();
                    objList.In_range_5 = dt.Rows[i]["In_range_5"].ToString();
                    objList.In_status_code = dt.Rows[i]["In_status_code"].ToString();
                    objList.In_mode_flag = dt.Rows[i]["In_mode_flag"].ToString();
                    ObjFetchAll.context.Detail.Add(objList);
                }

                ObjFetchAll.context.Header.In_item_name = (string)cmd.Parameters["In_item_name"].Value.ToString();
                ObjFetchAll.context.Header.In_item_ll_name = (string)cmd.Parameters["In_item_ll_name"].Value.ToString();
                ObjFetchAll.context.Header.In_item_type = (string)cmd.Parameters["In_item_type"].Value.ToString();
                ObjFetchAll.context.Header.In_fg_category = (string)cmd.Parameters["In_fg_category"].Value;
                ObjFetchAll.context.Header.In_fg_subcategory = (string)cmd.Parameters["In_fg_subcategory"].Value.ToString();
                ObjFetchAll.context.Header.In_uom_code = (string)cmd.Parameters["In_uom_code"].Value.ToString();
                ObjFetchAll.context.Header.In_hsn_code = (string)cmd.Parameters["In_hsn_code"].Value.ToString();
                ObjFetchAll.context.Header.In_hsn_description = (string)cmd.Parameters["In_hsn_description"].Value.ToString();
                ObjFetchAll.context.Header.In_status_code = (string)cmd.Parameters["In_status_code"].Value.ToString();
                ObjFetchAll.context.Header.In_status_desc = (string)cmd.Parameters["In_status_desc"].Value.ToString();
                ObjFetchAll.context.Header.In_mode_flag = (string)cmd.Parameters["In_mode_flag"].Value.ToString();
                ObjFetchAll.context.Header.In_row_timestamp = (string)cmd.Parameters["In_row_timestamp"].Value.ToString();
                ObjFetchAll.context.Header.IOU_item_rowid = (Int32)cmd.Parameters["IOU_item_rowid1"].Value;
                ObjFetchAll.context.Header.IOU_agg_code = (string)cmd.Parameters["IOU_agg_code1"].Value.ToString();
                ObjFetchAll.context.Header.IOU_item_code = (string)cmd.Parameters["IOU_item_code1"].Value.ToString();
               
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ObjFetchAll;
        }
        public SaveItemMasterDocument SaveItemMaster(SaveItemMasterApplication ObjContext, string mysqlcon)
        {
            int ret = 0;
            int retdtls = 0;
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);            
            SaveItemMasterDocument ObjSaveDoc = new SaveItemMasterDocument();
            ObjSaveDoc.context = new SaveItemMasterContext();
            ObjSaveDoc.context.Header = new SaveItemMasterHeader();

            try
            {
              

                MySqlCommand cmd = new MySqlCommand("PAWHS_insupd_item_master", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_agg_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_agg_code;
                cmd.Parameters.Add("In_item_name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_item_name;
                cmd.Parameters.Add("In_item_ll_name", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_item_ll_name;
                cmd.Parameters.Add("In_item_type", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_item_type;
                cmd.Parameters.Add("In_fg_category", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_fg_category;
                cmd.Parameters.Add("In_fg_subcategory", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_fg_subcategory;
                cmd.Parameters.Add("In_uom_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_uom_code;
                cmd.Parameters.Add("In_hsn_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_hsn_code;
                cmd.Parameters.Add("In_hsn_description", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_hsn_description;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_status_desc", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_status_desc;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_mode_flag;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.In_row_timestamp;                
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                cmd.Parameters.Add("IOU_item_rowid", MySqlDbType.Int32).Value = ObjContext.document.context.Header.IOU_item_rowid;
                cmd.Parameters.Add("IOU_item_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.IOU_item_code;
                cmd.Parameters.Add(new MySqlParameter("IOU_item_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("IOU_item_code1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;

                MysqlCon.con.Open();
                ret = cmd.ExecuteNonQuery();
                MysqlCon.con.Close();

                ObjSaveDoc.context.Header.IOU_item_rowid = (Int32)cmd.Parameters["IOU_item_rowid1"].Value;
                ObjSaveDoc.context.Header.IOU_item_code = (string)cmd.Parameters["IOU_item_code1"].Value;

                if (ObjSaveDoc.context.Header.IOU_item_rowid>0)
                {
                    foreach (var Details in ObjContext.document.context.Detail)
                    {
                        MySqlCommand cmds = new MySqlCommand("PAWHS_iud_item_master_detail", MysqlCon.con);
                        cmds.CommandType = CommandType.StoredProcedure;
                        cmds.Parameters.Add("In_item_dtl_rowid", MySqlDbType.Int32).Value = Details.In_item_dtl_rowid;
                        cmds.Parameters.Add("In_item_code", MySqlDbType.VarChar).Value = Details.In_item_code;
                        cmds.Parameters.Add("In_quality", MySqlDbType.VarChar).Value = Details.In_quality;
                        cmds.Parameters.Add("In_base_price", MySqlDbType.Int32).Value = Details.In_base_price;
                        cmds.Parameters.Add("In_range_1", MySqlDbType.VarChar).Value = Details.In_range_1;
                        cmds.Parameters.Add("In_range_2", MySqlDbType.VarChar).Value = Details.In_range_2;
                        cmds.Parameters.Add("In_range_3", MySqlDbType.VarChar).Value = Details.In_range_3;
                        cmds.Parameters.Add("In_range_4", MySqlDbType.VarChar).Value = Details.In_range_4;
                        cmds.Parameters.Add("In_range_5", MySqlDbType.VarChar).Value = Details.In_range_5;
                        cmds.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = Details.In_status_code;
                        cmds.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = Details.In_mode_flag;
                        cmds.Parameters.Add("IOU_item_rowid", MySqlDbType.Int32).Value = ObjSaveDoc.context.Header.IOU_item_rowid;                       
                        cmds.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                        cmds.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                        cmds.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                        cmds.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;                       

                        MysqlCon.con.Open();
                        retdtls = cmds.ExecuteNonQuery();
                        MysqlCon.con.Close();
                    }
                }            

            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                throw ex;
            }

            return ObjSaveDoc;
        }

        
    }
}
