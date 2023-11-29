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
    public class FDR_ProductionDataController : ControllerBase
    {

        FDRProductionData_Service objserv = new FDRProductionData_Service();

        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        private IConfiguration _configuration;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FDR_ProductionDataController)); //Declaring Log4Net.       

        public FDR_ProductionDataController(IOptions<MySettingsModel> app, IConfiguration configuration)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
            _configuration = configuration;
        }


        [HttpPost("GetProductionDataUP")]
        public string GetProductionDataList([FromBody] ProductionDataInputParams objparam)
        {
            FDRProductDataCapture ObjProdDet = new FDRProductDataCapture();
            DataSet ds = new DataSet();
            try
            {
                string condition_set = "TRUE";
                string Queryset = "";
                string Queryset1 = objparam.InstanceName;
                //dynamic connection string
                AllConnectionString rcon = new AllConnectionString();
                this.ConString = rcon.getRightConString(Queryset, this.appSettings.Value);
                if (condition_set == "TRUE")
                {
                    ObjProdDet = objserv.GetProductionDataCapture_srv(objparam, Queryset1, ConString);
                }


            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(ObjProdDet, Formatting.Indented);
            return serializedProduct;

        }
        [HttpPost("GetProductionDataCaptureUP")]
        public string GetProductionDataListCapture([FromBody] ProductionDataInputParams objparam)
        {
            // FDRProductDataCapture ObjProdDet = new FDRProductDataCapture();
            DataTable dt = new DataTable();
            try
            {
                string condition_set = "TRUE";
                string Queryset = "";
                string Queryset1 = objparam.InstanceName;
                //dynamic connection string
                AllConnectionString rcon = new AllConnectionString();
                this.ConString = rcon.getRightConString(Queryset, this.appSettings.Value);
                if (condition_set == "TRUE")
                {
                    dt = objserv.GetProductionDataCapture_service(objparam, Queryset1, ConString);
                }


            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(dt, Formatting.Indented);
            return serializedProduct;

        }


    }
}
