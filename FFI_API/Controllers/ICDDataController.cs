using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using FFI_Model;
using FFI_Service;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ICDDataController : ControllerBase
    {

        ICDData_Service ObjSer = new ICDData_Service();

        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        private IConfiguration _configuration;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDDataController)); //Declaring Log4Net.       

        public ICDDataController(IOptions<MySettingsModel> app, IConfiguration configuration)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
            _configuration = configuration;
        }

        #region ICD Prodct List

        [HttpPost("GetICDProductListUP")]
        public string GetICDProductList([FromBody] ICDDataInputParams objparam )
        {
            ICDProductDetails ObjProdDet = new ICDProductDetails(); 
            DataTable dt = new DataTable();
            try
            { 
                string condition_set = "TRUE";
                string Queryset = "";
                //dynamic connection string
                AllConnectionString rcon = new AllConnectionString();
                this.ConString = rcon.getRightConString(Queryset, this.appSettings.Value); 

                if (condition_set == "TRUE")
                {
                    dt = ObjSer.GetICDProductList(objparam, ConString);
                }


            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(dt, Formatting.Indented);
            return serializedProduct; 

        }

        #endregion

        #region ICD Invoice List

        [HttpPost("GetICDInvoiceListUP")]
        public string GetICDInvoiceList([FromBody] ICDInvoiceInputParams objparam)
        {
            ICDInvoiceDetails ObjInvDet = new ICDInvoiceDetails();
            DataSet ds = new DataSet();
            try
            {

                string[] condition =
                {
                    "UPDATE",
                    "DELETE",
                    "INSERT",
                    "EXEC "
                };

                string condition_set = "TRUE";

                string Queryset = "";
                string Queryset1 = objparam.InstanceName;

                //dynamic connection string
                AllConnectionString rcon = new AllConnectionString();
                this.ConString = rcon.getRightConString(Queryset, this.appSettings.Value);

                foreach (string c in condition)
                {

                    if (Queryset.Contains(c))
                    {

                        condition_set = "FALSE";

                        //ds.Columns.Add("ERROR", typeof(string));
                        //ds.Rows.Add("QUERY ERROR");
                    }

                }

                if (condition_set == "TRUE")
                {
                    ObjInvDet = ObjSer.GetICDInvoiceList(objparam, Queryset1, ConString);
                }


            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(ObjInvDet, Formatting.Indented);
            return serializedProduct;

        }



        #endregion




        #region ICD Supplier List

        [HttpPost("GetICDSupplierListUP")]
        public string GetICDSupplierList([FromBody] ICDSupplierInputParams objparam)
        {
            ICDSupplierList ObjProdDet = new ICDSupplierList();
            DataSet ds = new DataSet();
            try
            { 
                string condition_set = "TRUE";
                string Queryset = "";
                //dynamic connection string
                AllConnectionString rcon = new AllConnectionString();
                this.ConString = rcon.getRightConString(Queryset, this.appSettings.Value); 
                if (condition_set == "TRUE")
                {
                    ObjProdDet = ObjSer.GetICDSupplierList(objparam, ConString);
                }


            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(ObjProdDet, Formatting.Indented);
            return serializedProduct;

        }

        #endregion

        #region ICD StockTransfer List

        [HttpPost("GetICDStockTransferListUP")]
        public string GetICDStockTransferList([FromBody] ICDStockTransferParams objparam)
        {
            ICDStockTransferList ObjProdDet = new ICDStockTransferList();
            DataSet ds = new DataSet();
            try
            {
                string condition_set = "TRUE";
                string Queryset = "";
                //dynamic connection string
                AllConnectionString rcon = new AllConnectionString();
                this.ConString = rcon.getRightConString(Queryset, this.appSettings.Value);
                if (condition_set == "TRUE")
                {
                    ObjProdDet = ObjSer.GetICDStockTransferList(objparam, ConString);
                }


            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(ObjProdDet, Formatting.Indented);
            return serializedProduct;

        }

        #endregion

        #region ICD StockInward List

        [HttpPost("GetICDStockInwardListUP")]
        public string GetICDStockInwardList([FromBody] ICDStockInwardParams objparam)
        {
            ICDStockInwardList ObjProdDet = new ICDStockInwardList();
            DataSet ds = new DataSet();
            try
            {
                string condition_set = "TRUE";
                string Queryset = "";
                //dynamic connection string
                AllConnectionString rcon = new AllConnectionString();
                this.ConString = rcon.getRightConString(Queryset, this.appSettings.Value);
                if (condition_set == "TRUE")
                {
                    ObjProdDet = ObjSer.GetICDStockInwardList(objparam, ConString);
                }


            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(ObjProdDet, Formatting.Indented);
            return serializedProduct;

        }

        #endregion


        #region ICD stockadj List

        [HttpPost("GetICDstockadjListUP")]
        public string GetICDstockadjList([FromBody] ICDstockadjInputParams objparam)
        {
            ICDstockadjDetails ObjProdDet = new ICDstockadjDetails();
            DataSet ds = new DataSet();
            try
            {
                string[] condition =
                {
                    "UPDATE",
                    "DELETE",
                    "INSERT",
                    "EXEC "
                };
                string condition_set = "TRUE";
                string Queryset = "up";

                //dynamic connection string
                AllConnectionString rcon = new AllConnectionString();
                this.ConString = rcon.getRightConString(Queryset, this.appSettings.Value);

                foreach (string c in condition)
                {
                    if (Queryset.Contains(c))
                    {
                        condition_set = "FALSE";
                    }
                }
                if (condition_set == "TRUE")
                {
                    ObjProdDet = ObjSer.GetICDstockadj_srv(objparam, ConString);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(ObjProdDet, Formatting.Indented);
            return serializedProduct;
        }
        #endregion




    }
}
