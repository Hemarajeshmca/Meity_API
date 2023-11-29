using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FFI_Model;
using FFI_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using static FFI_Model.ProcurementSales_Model;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcurementSalesController : ControllerBase
    {

        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        private IConfiguration _configuration;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ProcurementSalesController));

        public ProcurementSalesController(IOptions<MySettingsModel> app, IConfiguration configuration)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
            _configuration = configuration;
        }

        [Authorize]
        [HttpPost("GetProcurementAndSalesReport")]
        public string GetProcurementAndSalesReport([FromBody] ProcurementSalesInfoParams objInput)
        {
            AllConnectionString rcon = new AllConnectionString();
            ProcurementSalesList Objresult = new ProcurementSalesList();
            ProcurementSales_Service objService = new ProcurementSales_Service();
            try
            {

                string Queryset = objInput.InstanceName;
                //dynamic connection string
                
                this.ConString = rcon.getRightConString(Queryset, this.appSettings.Value);
                Objresult = objService.GetProcurementAndSalesReport(objInput, ConString);
               

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            finally
            {
                rcon = null;
                objInput = null;
            }
            var serializedProduct = JsonConvert.SerializeObject(Objresult, Formatting.Indented);
            return serializedProduct;
        }

    }
}
