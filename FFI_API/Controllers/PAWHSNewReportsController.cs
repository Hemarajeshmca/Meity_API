using FFI_Model;
using FFI_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PAWHSNewReportsController : ControllerBase
    {
        PAWHSNewReports_srv ObjSer = new PAWHSNewReports_srv();

        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        private IConfiguration _configuration;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDDataController)); //Declaring Log4Net.       
        public PAWHSNewReportsController(IOptions<MySettingsModel> app, IConfiguration configuration)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
            _configuration = configuration;
        }
        #region pawhs purchase List

        [HttpPost("GetPAPurchaseList")]
        public string GetPAPurchaseList([FromBody] pareportsInputParams objparam)
        {            
            DataTable dt = new DataTable();
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
                    }
                }
                if (condition_set == "TRUE")
                {
                    dt = ObjSer.GetPAPurchaseList_srv(objparam, Queryset1, ConString);
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
        #region pawhs sale List

        [HttpPost("GetPASaleList")]
        public string GetPASaleList([FromBody] pareportsInputParams objparam)
        {          
            DataTable dt = new DataTable();
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
                    }
                }
                if (condition_set == "TRUE")
                {
                    dt = ObjSer.GetPASaleList_srv(objparam, Queryset1, ConString);
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
    }
}
