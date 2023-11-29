using FFI_Model;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FFI_DataModel
{
    public class Mobile_FDR_FDetail_DB
    {
        private IDictionary<string, object> jsonData { get; set; }
        private MySqlConnection con;
        MySqlTransaction mysqltrans;
        public DataConnection MysqlCon;
        ErrorMessages ObjErrormsg = new ErrorMessages();
        public fdrDocument SaveNewMobileFarmerCrop_DB(fdrsaveRootObject ObjContext, string mysqlcon)
        {
            int ret = 0;

            fdrsaveRootObject ObjModel = new fdrsaveRootObject();
            MysqlCon = new DataConnection(mysqlcon);
            fdrDocument ObjSaveDoc = new fdrDocument();
            ObjSaveDoc.context = new saveContext();
            ObjSaveDoc.context.Header = new fdrsaveHeader();
            ObjSaveDoc.context.Detail = new List<fdrDetail>();
            ObjSaveDoc.ApplicationException = new fdrApplicationException();
            string errorno = "";
            try
            {
                if (MysqlCon.con != null && MysqlCon.con.State == ConnectionState.Closed)
                {
                    MysqlCon.con.Open();
                    mysqltrans = MysqlCon.con.BeginTransaction();
                    
                    MySqlCommand cmd = new MySqlCommand("FDRMOB_iud_farmer_detail", MysqlCon.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("inout_farmer_code", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.inout_farmer_code;
                    cmd.Parameters.Add("inout_version_no", MySqlDbType.Int32).Value = ObjContext.document.context.Header.inout_version_no;
                    cmd.Parameters.Add("orgnId", MySqlDbType.VarChar).Value = ObjContext.document.context.orgnId;
                    cmd.Parameters.Add("locnId", MySqlDbType.VarChar).Value = ObjContext.document.context.locnId;
                    cmd.Parameters.Add("userId", MySqlDbType.VarChar).Value = ObjContext.document.context.userId;
                    cmd.Parameters.Add("localeId", MySqlDbType.VarChar).Value = ObjContext.document.context.localeId;
                    cmd.Parameters.Add("created_by", MySqlDbType.VarChar).Value = ObjContext.document.context.Header.in_created_by;
                    cmd.Parameters.Add("detail_formatted", MySqlDbType.Text).Value = ObjContext.document.context.detail_formatted;
                    cmd.Parameters.Add("ownland_picture", MySqlDbType.Text).Value = ObjContext.document.context.ownland_picture;
                    cmd.Parameters.Add("in_entitygrp_code", MySqlDbType.Text).Value = ObjContext.document.context.Header.entitygrp_code;
                    cmd.Parameters.Add(new MySqlParameter("errorNo", MySqlDbType.VarChar)).Direction = ParameterDirection.Output;
                    ret = cmd.ExecuteNonQuery();
                    errorno = (string)cmd.Parameters["errorNo"].Value;
                    if (errorno != "")
                    {
                        ObjSaveDoc.ApplicationException.errorNumber = (string)cmd.Parameters["errorNo"].Value;
                        ObjSaveDoc.ApplicationException.errorDescription = (string)cmd.Parameters["errorNo"].Value;
                        mysqltrans.Rollback();
                    }

                    else
                    {
                        // ObjSaveDoc.context.Header.inout_farmer_code = ObjContext.document.context.Header.inout_farmer_code;
                        mysqltrans.Commit();
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

