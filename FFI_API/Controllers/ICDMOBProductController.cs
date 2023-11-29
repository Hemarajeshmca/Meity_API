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
using Newtonsoft.Json;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ICDMOBProductController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDProductController)); //Declaring Log4Net. 
        public ICDMOBProductController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpGet("ICD_MOBILE_Product")]
        public string ICDProduct_List(string org, string locn, string user, string lang)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            //log Input information
            LogHelper.ConvertObjIntoString(objArr, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            ICDMOBPRoot ObjList = new ICDMOBPRoot();
            try
            {
                ObjList = ICDMOBProduct_service.ICDProduct_List(org, locn, user, lang, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                // logger.Error(ex);
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(ObjList, Formatting.Indented);
            return serializedProduct;
        }
        [HttpGet("paymentcollection")]
        public string paymentcollection_List(string org, string locn, string user, string lang,int invoice_rowid)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            //log Input information
            LogHelper.ConvertObjIntoString(objArr, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            MOBPAYRoot ObjList = new MOBPAYRoot();
            try
            {
                ObjList = ICDMOBProduct_service.paymentcollection_List_srv(org, locn, user, lang, invoice_rowid, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                // logger.Error(ex);
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(ObjList, Formatting.Indented);
            return serializedProduct;
        }
    }
}
