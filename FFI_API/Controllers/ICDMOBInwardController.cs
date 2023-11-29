using System;
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
    public class ICDMOBInwardController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDStockInwardController)); //Declaring Log4Net.       
        // Exception Log Method Name Purpose written start                                                                                        
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public ICDMOBInwardController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }


        [HttpPost("newSaveStockInward")]
        public string newSaveStockInward(ICDINSRoot ObjModel)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(ObjModel, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            ICDINSDocument Objresult = new ICDINSDocument();
            try
            {
                //SetLog4NetConfiguration();
                Objresult = ICDMOBInward_service.SaveICDStock(ObjModel, ConString);
                LogHelper.ConvertObjIntoString(Objresult, "Output");
            }
            catch (Exception ex)
            {
                // logger.Error(ex);
                logger.Error("USERNAME :" + ObjModel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(Objresult, Formatting.Indented);
            return serializedProduct;

        }
        [HttpGet("IssueList")]
        public IssueList IssueList(string org, string locn, string user, string lang)
        {
            //log Input information
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);

            IssueList ObjList = new IssueList();
            try
            {
                ObjList = ICDMOBInward_service.IssueList(org, locn, user, lang, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return ObjList;
        }
    }
}
