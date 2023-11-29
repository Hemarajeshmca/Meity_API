using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using FFI_Model;
using FFI_Service;
using System.Runtime.Serialization;
using FFI_DataModel;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChecklistDefinitionController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ChecklistDefinitionController)); //Declaring Log4Net.
        // Exception Log Method Name Purpose written start 
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public ChecklistDefinitionController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("ChecklistDefinition_List")]
        public Chklist_FetchApplication ChecklistDefinition_List(Chklist_FetchContext objfarmer)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(objfarmer, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objfarmer.locnId, this.appSettings.Value);
            Chklist_FetchApplication ObjList = new Chklist_FetchApplication();
            try
            {
                ObjList = ChecklistDefinition_service.ChecklistDefinition_List(objfarmer, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");

            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objfarmer.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);

            }
            return ObjList;
        }

        [HttpPost("ChecklistDefinition_save")]
        public Chklist_SDocument ChecklistDefinition_save(Chklist_SApplication ObjModel)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(ObjModel, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);
            string[] response = { };
            Chklist_SDocument Objresult = new Chklist_SDocument();
            try
            {
                Objresult = ChecklistDefinition_service.ChecklistDefinition_save(ObjModel, ConString);
                LogHelper.ConvertObjIntoString(Objresult, "Output");


            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjModel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return Objresult;

        }


    }
}
