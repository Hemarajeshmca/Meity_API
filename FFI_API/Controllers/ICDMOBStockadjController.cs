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
    public class ICDMOBStockadjController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDStockInwardController)); //Declaring Log4Net.       
        // Exception Log Method Name Purpose written start                                                                                        
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public ICDMOBStockadjController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("newSaveStockAdjustment")]
        public string newSaveStockAdjustment(ICDMOBSARoot SobjICDStockAdjContext)
        {

            //log Input information
            LogHelper.ConvertObjIntoString(SobjICDStockAdjContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjICDStockAdjContext.document.context.locnId, this.appSettings.Value);
            string[] response = { };
            ICDMOBSADocument Objresult = new ICDMOBSADocument();
            try
            {
                //SetLog4NetConfiguration();
                Objresult = ICDMOBStockadj_service.SaveICDStockAdj(SobjICDStockAdjContext, ConString);
                LogHelper.ConvertObjIntoString(Objresult, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + SobjICDStockAdjContext.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //  logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(Objresult, Formatting.Indented);
            return serializedProduct;
        }
        [HttpGet("StockadjLRP")]
        public string StockadjLRP(string org, string locn, string user, string lang, string In_orgn_code)
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
            ICDMOBCRoot1 ObjList = new ICDMOBCRoot1();
            try
            {
                ObjList = ICDMOBStockadj_service.icdStockadjLRP (org, locn, user, lang,In_orgn_code, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                throw ex;
                //logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(ObjList, Formatting.Indented);
            return serializedProduct;
        }
    }
}
