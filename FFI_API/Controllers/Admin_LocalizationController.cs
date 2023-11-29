using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FFI_DataModel;
using FFI_Model;
using FFI_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Admin_LocalizationController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Admin_LocalizationController)); //Declaring Log4Net.
        Admin_LocalizationService objRoleService = new Admin_LocalizationService();
        // Exception Log Method Name Purpose written start 
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public Admin_LocalizationController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }

        [HttpGet("localization")]
        public LocalizationList LocalizationList(string org, string locn, string user, string lang, string activity_code)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            objArr.Add(activity_code);
            //log Input information
            LogHelper.ConvertObjIntoString(objArr, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
            LocalizationList ObjList = new LocalizationList();
            try
            {
                ObjList = objRoleService.LocalizationList(org, locn, user, lang, activity_code,ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");

            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return ObjList;
        }

        [HttpPost("newlocalization")]
        public LocalOutput SaveLocalization(SaveLocalization objLoc)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(objLoc, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objLoc.document.context.locnId, this.appSettings.Value);
            LocalOutput ObjFetch = new LocalOutput();
            try
            {
                ObjFetch = objRoleService.SaveLocalization(objLoc, ConString);
                LogHelper.ConvertObjIntoString(ObjFetch, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objLoc.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjFetch;
        }
    }
}
