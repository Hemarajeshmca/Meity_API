using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using FFI_Model;
using FFI_Service;
using FFI_DataModel;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ICDInputCenterController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInputCenterController)); //Declaring Log4Net.
        // Exception Log Method Name Purpose written start 
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //Endz
        public ICDInputCenterController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("ICDInputCenter_List")]
        public ICDInputApplication ICDInputCenter_List(ICDInputContext objfarmer)
        {
            //log Input information sheebatest
            LogHelper.ConvertObjIntoString(objfarmer, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objfarmer.locnId, this.appSettings.Value);

            ICDInputApplication ObjList = new ICDInputApplication();
            try
            {
                ObjList = ICDInputCenter_service.ICDInputCenter_List(objfarmer, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");

            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objfarmer.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }

        [HttpPost("ICDInputCenter_SingleFetch")]
        public ICDInputCenter_FApplication ICDInputCenter_SingleFetch(ICDInputCenter_FContext SobjContext)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(SobjContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjContext.locnId, this.appSettings.Value);

            ICDInputCenter_FApplication ObjList = new ICDInputCenter_FApplication();
            try
            {
                ObjList = ICDInputCenter_service.ICDInputCenter_SingleFetch(SobjContext, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + SobjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }

        [HttpPost("ICDInputCenter_Save")]
        public ICDInput_SDocument ICDInputCenter_Save(ICDInput_SApplication ObjModel)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(ObjModel, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            ICDInput_SDocument Objresult = new ICDInput_SDocument();
            try
            {
                //SetLog4NetConfiguration();
                Objresult = ICDInputCenter_service.ICDInputCenter_Save(ObjModel, ConString);
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
