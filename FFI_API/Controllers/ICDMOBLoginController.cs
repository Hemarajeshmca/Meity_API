using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FFI_Model;
using FFI_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ICDMOBLoginController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDMOBLoginController)); //Declaring Log4Net.       

        public ICDMOBLoginController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpGet("user_validation")]
        public string user_validationLogin(string org, string locn, string user, string lang, string In_user_code,string In_user_pwd)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            ICDMOBLogin ObjList = new ICDMOBLogin();
            try
            {
                ObjList = ICDMOBLogin_service.user_validation_Srv(org, locn, user, lang, In_user_code, In_user_pwd, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(ObjList, Formatting.Indented);
            return serializedProduct;
        }
        [HttpGet("icdmob_user_validation")]
        public string icdmob_user_validationLogin(string org, string locn, string user, string lang, string In_user_code, string In_user_pwd,int version_number=0)
        {

            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            ICDMOBLogin1 ObjList = new ICDMOBLogin1();
            try
            {
                ObjList = ICDMOBLogin_service.icdmob_user_validation_Srv(org, locn, user, lang, In_user_code, In_user_pwd, version_number, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(ObjList, Formatting.Indented);
            return serializedProduct;
        }
    }
}
