using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using FFI_Model;
using FFI_Service;
using System;
using FFI_DataModel;
using System.Reflection;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FISDupRegisterController : ControllerBase
    {
        
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        public FISDupRegisterController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FISTransferRegisterController)); //Declaring Log4Net.
        string methodName = "";
        [HttpPost("duplicate_register")]
        public FISDupRegApplication FetchfisDupRegister(FISDupRegContext objICDStockContext)
        {
            LogHelper.ConvertObjIntoString(objICDStockContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objICDStockContext.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
            FISDupRegApplication ObjList = new FISDupRegApplication();
            try
            {
                ObjList = FISDupRegister_Service.FetchfisDupRegister(objICDStockContext, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objICDStockContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //  logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("newDuplicateRegister")]
        public SFISDupRegDocument newDuplicateRegister(SFISDupRegApplication objICDStockContext)
        {
            LogHelper.ConvertObjIntoString(objICDStockContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objICDStockContext.document.context.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
            SFISDupRegDocument ObjList = new SFISDupRegDocument();
            try
            {
                ObjList = FISDupRegister_Service.newDuplicateRegister(objICDStockContext, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objICDStockContext.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return ObjList;
        }
    }
}
