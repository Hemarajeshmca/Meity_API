using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using FFI_Model;
using FFI_Service;
using System.Data;
using Microsoft.Extensions.Configuration;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionDataCaptureController : ControllerBase
    {
        ProductionDataCapture_Service Objsrv = new ProductionDataCapture_Service();

        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        private IConfiguration _configuration;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ProductionDataCaptureController)); //Declaring Log4Net.       

        public ProductionDataCaptureController(IOptions<MySettingsModel> app, IConfiguration configuration)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
            _configuration = configuration;
        }

        [HttpPost("ProductionDataCapture")]
        public string GetProductionDataCapture([FromBody] ProductionDataCapture_Model Query)
        {
            ProductionDataContext Objprod = new ProductionDataContext();
            DataSet ds3 = new DataSet();
            try
            {

                string[] condition =
                {
                    "UPDATE",
                    "DELETE",
                    "INSERT",
                    "EXEC "
                };
                string Queryset = Query.InstanceName;
                string condition_set = "TRUE";
               // string Queryset2 = Query.FROMDATE;
               // string Queryset1 = Query.TODATE;

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
                    Objprod = Objsrv.GetProductionDataCaptureReport(Query, ConString);
                }


            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(Objprod, Formatting.Indented);
            return serializedProduct;
            // return Obj_GetIcdInvoice;
        }





    }
}
