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

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mobile_FDR_LoginController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Mobile_FDR_LoginController)); //Declaring Log4Net.       

        public Mobile_FDR_LoginController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpGet("FdrLogin")]
        public FDRLoginfetchApplication FdrLogin(string org, string locn, string user, string lang, string instance, string In_user_code, string In_user_pwd,int version_number=0)
        {
            string db = instance;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            FDRLoginfetchApplication ObjList = new FDRLoginfetchApplication();
            try
            {
                ObjList = Mobile_FDR_Login_srv.GetAllFdrLogin_Srv(org, locn, user, lang, In_user_code, In_user_pwd, version_number, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
        [HttpGet("commonmobLogin")]
        public comLoginfetchApplication commonmobLogin(string org, string locn, string user, string lang, string instance, string In_user_code, string In_user_pwd, int version_number = 0)
        {
            string db = instance;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            comLoginfetchApplication ObjList = new comLoginfetchApplication();
            try
            {
                ObjList = Mobile_FDR_Login_srv.GetAllmodLogin_Srv(org, locn, user, lang, In_user_code, In_user_pwd, version_number, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
    }
}

