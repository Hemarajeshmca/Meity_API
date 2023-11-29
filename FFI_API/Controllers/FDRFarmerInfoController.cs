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
using static FFI_Model.FDRFarmerInfo_Model;
using System.Data;
 

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FDRFarmerInfoController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        private IConfiguration _configuration;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FDRFarmerInfoController));
        public FDRFarmerInfoController(IOptions<MySettingsModel> app, IConfiguration configuration)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
            _configuration = configuration;
        }
        [Authorize]
        [HttpPost("GetFarmerInfoNew")]
        public string GetFarmerInfoNew([FromBody] SMSGetFarmerInfoModel objInput)
        {           

            FarmerNew Objresult = new FarmerNew();
            FDRFarmerInfo_Service objService = new FDRFarmerInfo_Service();
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
                string Queryset = objInput.InstanceName;

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
                    Objresult = objService.GetFarmernewData(objInput, ConString);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(Objresult, Formatting.Indented);

            return serializedProduct;
        }

        [Authorize]
        [HttpPost("GetFarmerInfoOdisha")]
        public string GetFarmerInfoOdisha([FromBody] SMSGetFarmerInfoModelOdisha objInput)
        {
            GetFarmerInfoOdisha Objresult = new GetFarmerInfoOdisha();
            FDRFarmerInfo_Service objService = new FDRFarmerInfo_Service();
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
                string Queryset = objInput.InstanceName;

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
                    Objresult = objService.GetFarmerInfoOdisha(objInput, "All", objInput.District, "All", "All", ConString);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(Objresult, Formatting.Indented);
            return serializedProduct;
        }

        [Authorize]
        [HttpPost("GetFarmerBasicInfo")]
        public string GetFarmerBasicInfo([FromBody] SMSGetFarmerInfoModel objInput)
        {

            FarmerBasicInfoNew Objresult = new FarmerBasicInfoNew();
            FDRFarmerInfo_Service objService = new FDRFarmerInfo_Service();
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
                string Queryset = objInput.InstanceName;

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
                    dt = objService.GetFarmerBasicInfo(objInput, Queryset, ConString);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(dt, Formatting.Indented);

            return serializedProduct;
        }


        [Authorize]
        [HttpPost("GetFarmerBankDetail")]
        public string GetFarmerBankDetail([FromBody] SMSGetFarmerInfoModel objInput)
        {

            FarmerBankInfoNew Objresult = new FarmerBankInfoNew();
            FDRFarmerInfo_Service objService = new FDRFarmerInfo_Service();
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
                string Queryset = objInput.InstanceName;

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
                    dt = objService.GetFarmerBankDetail(objInput, Queryset, ConString);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(dt, Formatting.Indented);

            return serializedProduct;
        }

        [Authorize]
        [HttpPost("GetFarmerKYCDetail")]
        public string GetFarmerKYCDetail([FromBody] SMSGetFarmerInfoModel objInput)
        {

            FarmerKYCInfoNew Objresult = new FarmerKYCInfoNew();
            FDRFarmerInfo_Service objService = new FDRFarmerInfo_Service();
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
                string Queryset = objInput.InstanceName;

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
                    dt = objService.GetFarmerKYCDetail(objInput, Queryset, ConString);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(dt, Formatting.Indented);

            return serializedProduct;
        }

        [Authorize]
        [HttpPost("GetFarmerLandDetails")]
        public string GetFarmerLandDetails([FromBody] SMSGetFarmerInfoModel objInput)
        {

            FarmerLandInfoNew Objresult = new FarmerLandInfoNew();
            FDRFarmerInfo_Service objService = new FDRFarmerInfo_Service();
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
                string Queryset = objInput.InstanceName;

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
                    dt = objService.GetFarmerLandDetails(objInput, Queryset, ConString);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(dt,Formatting.Indented);

            return serializedProduct;
        }

        [Authorize]
        [HttpPost("GetFarmerSowingDetails")]
        public string GetFarmerSowingDetails([FromBody] SMSGetFarmerInfoModel objInput)
        {

            FarmerSowingInfoNew Objresult = new FarmerSowingInfoNew();
            FDRFarmerInfo_Service objService = new FDRFarmerInfo_Service();
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
                string Queryset = objInput.InstanceName;

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
                    dt = objService.GetFarmerSowingDetails (objInput, Queryset, ConString);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(dt, Formatting.Indented);

            return serializedProduct;
        }

        [Authorize]
        [HttpPost("GetFarmerBasicInfonew")]
        public string GetFarmerBasicInfonew([FromBody] SMSGetFarmerInfoModel objInput)
        {
            DataTable dtresult = new DataTable();
           // FarmerBasicInfoNew Objresult = new FarmerBasicInfoNew();
            FDRFarmerInfo_Service objService = new FDRFarmerInfo_Service();
            try
            {
                string Queryset = objInput.InstanceName;
                //dynamic connection string
                AllConnectionString rcon = new AllConnectionString();
                this.ConString = rcon.getRightConString("", this.appSettings.Value);

                dtresult = objService.GetFarmerBasicInfonew(objInput, Queryset, ConString);
                 
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(dtresult, Formatting.Indented);

            return serializedProduct;
        }

        [Authorize]
        [HttpPost("GetDailyProgress")]
        public string GetDailyProgress([FromBody] dailyprogressModel objInput)
        {
            DataTable dtresult = new DataTable();
            // FarmerBasicInfoNew Objresult = new FarmerBasicInfoNew();
            FDRFarmerInfo_Service objService = new FDRFarmerInfo_Service();
            try
            {
                //dynamic connection string
                AllConnectionString rcon = new AllConnectionString();
                this.ConString = rcon.getRightConString("", this.appSettings.Value);

                dtresult = objService.GetDailyProgress_srv(objInput, ConString);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(dtresult, Formatting.Indented);

            return serializedProduct;
        }



    }
}
