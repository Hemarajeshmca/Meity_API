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
using static FFI_Model.PADataModel;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PADataController : ControllerBase
    {
        PAData_Service ObjSerPA = new PAData_Service();
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        private IConfiguration _configuration;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PADataController)); //Declaring Log4Net.       

        public PADataController(IOptions<MySettingsModel> app, IConfiguration configuration)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
            _configuration = configuration;
        }

        #region PA Purchase List

        [HttpPost("GetPAPurchaseListUP")]
        public string GetPAPurchaseList([FromBody] PAPurchaseParams objparam)
        {
            PAPurchaseList ObjPAPurchaseDet = new PAPurchaseList();
            DataSet ds = new DataSet();
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
                    dt = ObjSerPA.GetPAPurchaseList(objparam, ConString);
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

        #region PA Sale List

        [HttpPost("GetPASaleListUP")]
        public string GetPASaleList([FromBody] PASaleInputParams objparam)
        {
            PASaleDetails ObjsalDet = new PASaleDetails();
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
                    ObjsalDet = ObjSerPA.GetPASaleList(objparam, ConString);
                }


            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(ObjsalDet, Formatting.Indented);
            return serializedProduct;

        }



        #endregion
    }
}
