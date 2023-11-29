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
    public class FISDivMupdstatusController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        public FISDivMupdstatusController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FISDivMupdstatusController)); //Declaring Log4Net.
        string methodName = "";
        [HttpPost("divident_update_status")]
        public fisDMPApplication FillDIVupdate(fisDMPContext objICDStockContext)
        {
            LogHelper.ConvertObjIntoString(objICDStockContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objICDStockContext.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
            fisDMPApplication ObjList = new fisDMPApplication();
            try
            {
                ObjList = FISDivMupdstatus_Service.FillDIVupdate(objICDStockContext, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objICDStockContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("newDividendUpdateStatus")]
        public SfisDMPDocument newDividendUpdateStatus(SfisDMPApplication objICDStockContext)
        {
            LogHelper.ConvertObjIntoString(objICDStockContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objICDStockContext.document.context.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
            SfisDMPDocument ObjList = new SfisDMPDocument();
            try
            {
                ObjList = FISDivMupdstatus_Service.newDividendUpdateStatus(objICDStockContext, ConString);
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
