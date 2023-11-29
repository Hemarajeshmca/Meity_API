using FFI_Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace FFI_DataModel
{
    public class ICDMOBInward_Datamodel
    {
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDMOBInward_Datamodel)); //Declaring Log4Net. 
        string methodName = MethodBase.GetCurrentMethod().Name;
        string In_grn_no1 = "";
        int IOU_inward_rowid1 = 0;


        public ICDINSDocument SaveICDStock(ICDINSRoot ObjICDStock, string mysqlcon)
        {
            DataConnection con = new DataConnection(mysqlcon);
            MysqlCon = new DataConnection(mysqlcon);
            ICDINSDocument objresICDStock = new ICDINSDocument();
            objresICDStock.context = new ICDINSContext();
            objresICDStock.context.Header = new ICDINSHeader();

            try
            {
                int ret = 0;

                //string errorNo = "";

                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                }
                MySqlCommand cmd = new MySqlCommand("ICDMOB_insupd_stockInward", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("In_orgn_code", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_orgn_code;// ObjFarmer.document.context.Header.in_farmer_rowid;
                cmd.Parameters.Add("In_ic_code", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_ic_code;
                cmd.Parameters.Add("In_inward_code", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_inward_code;
                cmd.Parameters.Add("In_grn_no", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_grn_no;
                cmd.Parameters.Add("In_grn_date", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_grn_date;
                cmd.Parameters.Add("In_supplier_name", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_supplier_name;
                cmd.Parameters.Add("In_supplier_location", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_supplier_location;
                cmd.Parameters.Add("In_from_state", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_from_state;
                cmd.Parameters.Add("In_Remarks", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_Remarks;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_status_code;
                cmd.Parameters.Add("In_process_status", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_process_status;
                cmd.Parameters.Add("In_row_timestamp", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_row_timestamp;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjICDStock.document.context.Header.In_mode_flag;
                if (string.IsNullOrWhiteSpace(ObjICDStock.document.context.Header.In_bill_image))
                {
                    cmd.Parameters.Add("In_bill_image", MySqlDbType.LongText).Value = "";
                }
                else
                {
                    cmd.Parameters.Add("In_bill_image", MySqlDbType.LongText).Value = ObjICDStock.document.context.Header.In_bill_image;
                }
                cmd.Parameters.Add("In_transport_amount", MySqlDbType.Int32).Value = Convert.ToInt32(ObjICDStock.document.context.Header.In_transport_amount);
                cmd.Parameters.Add("In_others", MySqlDbType.Int32).Value = Convert.ToInt32(ObjICDStock.document.context.Header.In_others);
                cmd.Parameters.Add("In_loading_unloading_cost", MySqlDbType.Int32).Value = Convert.ToInt32(ObjICDStock.document.context.Header.In_loading_unloading_cost);
                cmd.Parameters.Add("In_local_transport_cost", MySqlDbType.Int32).Value = Convert.ToInt32(ObjICDStock.document.context.Header.In_local_transport_cost);
                cmd.Parameters.Add("In_local_loading_unloading_cost", MySqlDbType.Int32).Value = Convert.ToInt32(ObjICDStock.document.context.Header.In_local_loading_unloading_cost);
                cmd.Parameters.Add("In_roundoff", MySqlDbType.Double).Value = Convert.ToDouble(ObjICDStock.document.context.Header.In_roundoff);
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjICDStock.document.context.localeId;
                cmd.Parameters.Add("IOU_inward_rowid", MySqlDbType.Int32).Value = ObjICDStock.document.context.Header.IOU_inward_rowid;
                cmd.Parameters.Add(new MySqlParameter("IOU_inward_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("In_grn_no1", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                LogHelper.ConvertCmdIntoString(cmd);
                ret = cmd.ExecuteNonQuery();
                if (ret > 0)
                {
                    IOU_inward_rowid1 = (Int32)cmd.Parameters["IOU_inward_rowid1"].Value;
                    In_grn_no1 = (string)cmd.Parameters["In_grn_no1"].Value;
                    objresICDStock.context.Header.IOU_inward_rowid = Convert.ToString(IOU_inward_rowid1);
                    objresICDStock.context.Header.In_grn_no = In_grn_no1;
                    objresICDStock.context.Header.In_ic_code= ObjICDStock.document.context.Header.In_ic_code;

                }
                if (IOU_inward_rowid1 > 0)
                {
                    int results = 0;
                    results = SaveIDCDetail(ObjICDStock, objresICDStock, mysqlcon, MysqlCon);
                    if (results == 0)
                    {
                        mysqltrans.Rollback();
                        MysqlCon.con.Close();
                        return objresICDStock;
                    }
                    mysqltrans.Commit();
                    MysqlCon.con.Close();
                    return objresICDStock;
                }
            }
            catch (Exception ex)
            {
                mysqltrans.Rollback();
                MysqlCon.con.Close();
                return objresICDStock;
                  throw ex;
                //logger.Error("USERNAME :" + ObjICDStock.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            finally
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Open)
                {
                    MysqlCon.con.Close();
                }

            }
            return objresICDStock;
        }

        public int SaveIDCDetail(ICDINSRoot Objmodel, ICDINSDocument objIUStock, string MysqlCons, DataConnection MysqlCon)
        {
            int result = 0;
            DataTable tab = new DataTable();
            ICDINSDetail objkycdtl = new ICDINSDetail();
            try
            {
                ICDMOBInward_Datamodel objproduct1 = new ICDMOBInward_Datamodel();
                foreach (var Kyc in Objmodel.document.context.Detail)
                {
                    // inward_id = objIUStock.context.Header.IOU_inward_rowid;// Kyc.In_inwarddtl_rowid;

                    objkycdtl.In_inwarddtl_rowid = Kyc.In_inwarddtl_rowid;
                    objkycdtl.In_inward_code = Kyc.In_inward_code;
                    objkycdtl.In_grn_no = Kyc.In_grn_no;
                    objkycdtl.In_product_catg_code = Kyc.In_product_catg_code;
                    objkycdtl.In_product_subcatg_code = Kyc.In_product_subcatg_code;
                    objkycdtl.In_product_code = Kyc.In_product_code;
                    objkycdtl.In_uomtype_code = Kyc.In_uomtype_code;
                    objkycdtl.In_batch_no = Kyc.In_batch_no;
                    objkycdtl.In_received_qty = Kyc.In_received_qty;
                    objkycdtl.In_product_amount = Kyc.In_product_amount;
                    objkycdtl.In_tax_amount = Kyc.In_tax_amount;
                    objkycdtl.In_transport_amount = Kyc.In_transport_amount;
                    objkycdtl.In_discount = Kyc.In_discount;
                    objkycdtl.In_net_amount = Kyc.In_net_amount;
                    objkycdtl.In_status_code = Kyc.In_status_code;
                    objkycdtl.In_mode_flag = Kyc.In_mode_flag;

                    result = objproduct1.SaveIDCDetailList(objkycdtl, objIUStock, Objmodel, MysqlCons, MysqlCon);
                    if (result > 0)
                    {
                        int res = 0;                        
                        int result1 = 0;
                        ICDINSDetailSlno objdtlslno = new ICDINSDetailSlno();
                        ICDINSDetailOtherCost objOC = new ICDINSDetailOtherCost();
                        ICDINSDetailOtherInputs objOtrInp = new ICDINSDetailOtherInputs();
                        ICDINSDetail ObjKycDtl = new ICDINSDetail();

                        ICDMOBInward_Datamodel objproduct2 = new ICDMOBInward_Datamodel();
                        if (Kyc.Slnoinfo != null) // Ramya Added 26 Mar 21
                        {
                            foreach (var Kyc1 in Kyc.Slnoinfo)
                            {
                                objdtlslno.In_inwardslno_rowid = Kyc1.In_inwardslno_rowid;
                                objdtlslno.In_inwarddtl_rowid = objkycdtl.In_inwarddtl_rowid;//ObjKycDtl.In_inwarddtl_rowid;
                                objdtlslno.In_slno = Kyc1.In_slno;
                                objdtlslno.In_no_of_bags = Kyc1.In_no_of_bags;
                                objdtlslno.In_grn_no = In_grn_no1;
                                objdtlslno.In_product_catg_code = Kyc.In_product_catg_code;
                                objdtlslno.In_product_subcatg_code = Kyc.In_product_subcatg_code;
                                objdtlslno.In_product_code = Kyc.In_product_code;
                                objdtlslno.In_status_code = Kyc1.In_status_code;
                                objdtlslno.In_mode_flag = Kyc1.In_mode_flag;
                                result1 = objproduct2.SaveIDCDetailSlnoList(objdtlslno, objIUStock, Objmodel, MysqlCons, MysqlCon);
                            }
                        }
                        // Other_Cost //
                        if (Objmodel.document.context.locnId.ToString().ToUpper() == "UP")
                        {
                            if (Kyc.OtherCostInfo != null)
                            {
                                foreach (var OC in Kyc.OtherCostInfo)
                                {
                                    objOC.In_inwardOtherCost_rowid = OC.In_inwardOtherCost_rowid;
                                    objOC.In_inwarddtl_rowid = objkycdtl.In_inwarddtl_rowid;
                                    objOC.In_OtherCostCode = OC.In_OtherCostCode;
                                    objOC.In_OtherCostType = OC.In_OtherCostType;
                                    objOC.In_OtherCostOn = OC.In_OtherCostOn;
                                    objOC.In_OtherCostAmount = OC.In_OtherCostAmount;
                                    objOC.In_grn_no = In_grn_no1;
                                    objOC.In_product_catg_code = Kyc.In_product_catg_code;
                                    objOC.In_product_subcatg_code = Kyc.In_product_subcatg_code;
                                    objOC.In_product_code = Kyc.In_product_code;
                                    objOC.In_status_code = OC.In_status_code;
                                    objOC.In_mode_flag = OC.In_mode_flag;
                                    res = objproduct2.SaveIDCDetailOtherCostList(objOC, objIUStock, Objmodel, MysqlCons, MysqlCon);

                                }
                            }
                            if (Kyc.OtherInputInfo != null)
                            {
                                foreach (var OtrInp in Kyc.OtherInputInfo)
                                {
                                    objOtrInp.In_inwardOtherinput_rowid = OtrInp.In_inwardOtherinput_rowid;
                                    objOtrInp.In_inwarddtl_rowid = objkycdtl.In_inwarddtl_rowid;
                                    objOtrInp.In_NoOfLoosePack = OtrInp.In_NoOfLoosePack;
                                    objOtrInp.In_CartonVolume = OtrInp.In_CartonVolume;
                                    objOtrInp.In_Type = OtrInp.In_Type;
                                    objOtrInp.In_ManufactureDate = OtrInp.In_ManufactureDate;
                                    objOtrInp.In_ExpDate = OtrInp.In_ExpDate;
                                    objOtrInp.In_Mrp = OtrInp.In_Mrp;
                                    objOtrInp.In_mode_flag = Kyc.In_mode_flag;
                                    objOtrInp.In_grn_no = In_grn_no1;
                                    objOtrInp.In_product_catg_code = Kyc.In_product_catg_code;
                                    objOtrInp.In_product_subcatg_code = Kyc.In_product_subcatg_code;
                                    objOtrInp.In_product_code = Kyc.In_product_code;
                                    objOtrInp.In_status_code = OtrInp.In_status_code;
                                    res = objproduct2.SaveIDCDetailOtherInputList(objOtrInp, objIUStock, Objmodel, MysqlCons, MysqlCon);

                                }
                            }

                        }
                    }
                    else
                    {
                        mysqltrans.Rollback();
                        MysqlCon.con.Close();
                    }
                    
                }
                return result;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return result;
            }
        }
        public int SaveIDCDetailSlnoList(ICDINSDetailSlno ObjDtlSlno, ICDINSDocument objIUStock, ICDINSRoot Objmodel, string mysqlcons, DataConnection MysqlCon)
        {

            int ret = 0;
            try
            {
                //ICDINSDetail ObjKycDtl = new ICDINSDetail();
                MySqlCommand cmd = new MySqlCommand("ICDMOB_iud_stockInward_detailslno", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("In_inwardslno_rowid", MySqlDbType.Int32).Value = Convert.ToInt32(ObjDtlSlno.In_inwardslno_rowid);
                cmd.Parameters.Add("In_inwarddtl_rowid", MySqlDbType.Int32).Value = Convert.ToInt32(ObjDtlSlno.In_inwarddtl_rowid);
                cmd.Parameters.Add("In_slno", MySqlDbType.VarChar).Value = ObjDtlSlno.In_slno;
                cmd.Parameters.Add("In_no_of_bags", MySqlDbType.VarChar).Value = ObjDtlSlno.In_no_of_bags;
                cmd.Parameters.Add("In_grn_no", MySqlDbType.VarChar).Value = ObjDtlSlno.In_grn_no;
                cmd.Parameters.Add("In_product_catg_code", MySqlDbType.VarChar).Value = ObjDtlSlno.In_product_catg_code;
                cmd.Parameters.Add("In_product_subcatg_code", MySqlDbType.VarChar).Value = ObjDtlSlno.In_product_subcatg_code;
                cmd.Parameters.Add("In_product_code", MySqlDbType.VarChar).Value = ObjDtlSlno.In_product_code;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjDtlSlno.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjDtlSlno.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                //LogHelper.ConvertCmdIntoString(cmd);
                ret = cmd.ExecuteNonQuery();

                return ret;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return ret;
            }
        }
        public int SaveIDCDetailList(ICDINSDetail ObjKycDtl, ICDINSDocument objIUStock, ICDINSRoot Objmodel, string mysqlcons, DataConnection MysqlCon)
        {

            int ret = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand("ICDMOB_iud_stockInward_detail", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("IOU_inward_rowid", MySqlDbType.Int32).Value = Convert.ToInt32(objIUStock.context.Header.IOU_inward_rowid);
                cmd.Parameters.Add("In_inwarddtl_rowid", MySqlDbType.Int32).Value = Convert.ToInt32(ObjKycDtl.In_inwarddtl_rowid);
                cmd.Parameters.Add("In_inward_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_inward_code;
                cmd.Parameters.Add("In_grn_no", MySqlDbType.VarChar).Value = objIUStock.context.Header.In_grn_no;
                cmd.Parameters.Add("In_product_catg_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_product_catg_code;
                cmd.Parameters.Add("In_product_subcatg_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_product_subcatg_code;
                cmd.Parameters.Add("In_product_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_product_code;
                cmd.Parameters.Add("In_uomtype_code", MySqlDbType.VarChar).Value = ObjKycDtl.In_uomtype_code;
                cmd.Parameters.Add("In_batch_no", MySqlDbType.VarChar).Value = ObjKycDtl.In_batch_no;
                cmd.Parameters.Add("In_received_qty", MySqlDbType.Float).Value = Convert.ToDouble(ObjKycDtl.In_received_qty);
                cmd.Parameters.Add("In_product_amount", MySqlDbType.Float).Value = Convert.ToDouble(ObjKycDtl.In_product_amount);
                cmd.Parameters.Add("In_tax_amount", MySqlDbType.Float).Value = Convert.ToDouble(ObjKycDtl.In_tax_amount);
                cmd.Parameters.Add("In_transport_amount", MySqlDbType.Float).Value = ObjKycDtl.In_transport_amount;
                cmd.Parameters.Add("In_discount", MySqlDbType.Float).Value = Convert.ToDouble(ObjKycDtl.In_discount);
                cmd.Parameters.Add("In_net_amount", MySqlDbType.Float).Value = Convert.ToDouble(ObjKycDtl.In_net_amount);
                cmd.Parameters.Add("In_status_code", MySqlDbType.String).Value = ObjKycDtl.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.String).Value = ObjKycDtl.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;      //ramya commentted on 08 jun 21           
                //cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = objIUStock.context.Header.In_ic_code; //ramya added on 08 jun 21, since dtl not saved iccode=orgnid
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                cmd.Parameters.Add(new MySqlParameter("IOU_inwarddtl_rowid1", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                //LogHelper.ConvertCmdIntoString(cmd);
                ret = cmd.ExecuteNonQuery();
                if (ret > 0)
                {
                    IOU_inward_rowid1 = (Int32)cmd.Parameters["IOU_inwarddtl_rowid1"].Value;
                    ObjKycDtl.In_inwarddtl_rowid = IOU_inward_rowid1;
                }
                return ret;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return ret;
            }
        }
        public IssueList IssueList(string org, string locn, string user, string lang, string mysqlcon)
        {
            int ret = 0;
            DataTable dt = new DataTable();
            IssueList objIssue = new IssueList();
            objIssue.orgnId = org;
            objIssue.locnId = locn;
            objIssue.localeId = lang;
            objIssue.userId = user;
            MysqlCon = new DataConnection(mysqlcon);
            try
            {
                MySqlCommand cmd = new MySqlCommand("ICDMOB_issue_list", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = org;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = locn;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = lang;
                MysqlCon.con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                MysqlCon.con.Close();
                List<IssueDetailsList> objIssueDetails = new List<IssueDetailsList>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IssueDetailsList obj = new IssueDetailsList();
                    obj.inward_no = dt.Rows[i]["grn_no"].ToString();
                    obj.Product_code = dt.Rows[i]["product_code"].ToString();
                    obj.Product_name = dt.Rows[i]["Product_name"].ToString();
                    obj.issued_qty = dt.Rows[i]["received_qty"].ToString();
                    objIssueDetails.Add(obj);
                }
                objIssue.IssueDetails = objIssueDetails;
            }
            catch (Exception ex)
            {
                //logger.Error("USERNAME :" + objstock.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //  throw ex;
            }
            return objIssue;
        }


        public int SaveIDCDetailOtherCostList(ICDINSDetailOtherCost ObjDtlOC, ICDINSDocument objIUStock, ICDINSRoot Objmodel, string mysqlcons, DataConnection MysqlCon)
        {

            int ret = 0;
            try
            {
                //ICDINSDetail ObjKycDtl = new ICDINSDetail();
                MySqlCommand cmd = new MySqlCommand("ICDMOB_iud_stockInward_detailOtherCost", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;
                 
                cmd.Parameters.Add("In_inwardOtherCost_rowid", MySqlDbType.Int32).Value = Convert.ToInt32(ObjDtlOC.In_inwardOtherCost_rowid);
                cmd.Parameters.Add("In_inwarddtl_rowid", MySqlDbType.Int32).Value = Convert.ToInt32(ObjDtlOC.In_inwarddtl_rowid);
                cmd.Parameters.Add("In_OtherCostCode", MySqlDbType.VarChar).Value = ObjDtlOC.In_OtherCostCode;
                cmd.Parameters.Add("In_OtherCostType", MySqlDbType.VarChar).Value = ObjDtlOC.In_OtherCostType;
                cmd.Parameters.Add("In_OtherCostOn", MySqlDbType.VarChar).Value = ObjDtlOC.In_OtherCostOn;
                cmd.Parameters.Add("In_OtherCostAmount", MySqlDbType.VarChar).Value = ObjDtlOC.In_OtherCostAmount; 

                cmd.Parameters.Add("In_grn_no", MySqlDbType.VarChar).Value = ObjDtlOC.In_grn_no;
                cmd.Parameters.Add("In_product_catg_code", MySqlDbType.VarChar).Value = ObjDtlOC.In_product_catg_code;
                cmd.Parameters.Add("In_product_subcatg_code", MySqlDbType.VarChar).Value = ObjDtlOC.In_product_subcatg_code;
                cmd.Parameters.Add("In_product_code", MySqlDbType.VarChar).Value = ObjDtlOC.In_product_code;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjDtlOC.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjDtlOC.In_mode_flag;
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                //LogHelper.ConvertCmdIntoString(cmd);
                ret = cmd.ExecuteNonQuery();
                //
                return ret;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return ret;
            }
        }
        // ****   Test ***// 
        public int SaveIDCDetailOtherInputList(ICDINSDetailOtherInputs ObjDtlOC, ICDINSDocument objIUStock, ICDINSRoot Objmodel, string mysqlcons, DataConnection MysqlCon)
        {

            int ret = 0;
            try
            {
                //ICDINSDetail ObjKycDtl = new ICDINSDetail();
                MySqlCommand cmd = new MySqlCommand("ICDMOB_iud_stockInward_detailOtherInputs", MysqlCon.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("In_inwardOtherinput_rowid", MySqlDbType.Int32).Value = Convert.ToInt32(ObjDtlOC.In_inwardOtherinput_rowid);
                cmd.Parameters.Add("In_inwarddtl_rowid", MySqlDbType.Int32).Value = Convert.ToInt32(ObjDtlOC.In_inwarddtl_rowid);
                cmd.Parameters.Add("In_NoOfLoosePack", MySqlDbType.VarChar).Value = ObjDtlOC.In_NoOfLoosePack;
                cmd.Parameters.Add("In_CartonVolume", MySqlDbType.VarChar).Value = ObjDtlOC.In_CartonVolume;
                cmd.Parameters.Add("In_Type", MySqlDbType.VarChar).Value = ObjDtlOC.In_Type;
                cmd.Parameters.Add("In_ManufactureDate", MySqlDbType.VarChar).Value = ObjDtlOC.In_ManufactureDate; 
                cmd.Parameters.Add("In_ExpDate", MySqlDbType.VarChar).Value = ObjDtlOC.In_ExpDate;
                cmd.Parameters.Add("In_Mrp", MySqlDbType.VarChar).Value = ObjDtlOC.In_Mrp;
                cmd.Parameters.Add("In_grn_no", MySqlDbType.VarChar).Value = ObjDtlOC.In_grn_no;
                cmd.Parameters.Add("In_product_catg_code", MySqlDbType.VarChar).Value = ObjDtlOC.In_product_catg_code;
                cmd.Parameters.Add("In_product_subcatg_code", MySqlDbType.VarChar).Value = ObjDtlOC.In_product_subcatg_code;
                cmd.Parameters.Add("In_product_code", MySqlDbType.VarChar).Value = ObjDtlOC.In_product_code;
                cmd.Parameters.Add("In_status_code", MySqlDbType.VarChar).Value = ObjDtlOC.In_status_code;
                cmd.Parameters.Add("In_mode_flag", MySqlDbType.VarChar).Value = ObjDtlOC.In_mode_flag; 
                cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = Objmodel.document.context.orgnId;
                cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = Objmodel.document.context.locnId;
                cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = Objmodel.document.context.userId;
                cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = Objmodel.document.context.localeId;
                //LogHelper.ConvertCmdIntoString(cmd);
                ret = cmd.ExecuteNonQuery();

                return ret;
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + Objmodel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                return ret;
            }
        } 

    }
}
