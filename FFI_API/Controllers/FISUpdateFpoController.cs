using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    public class FISUpdateFpoController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FISUpdateFpoController)); //Declaring Log4Net.  
        string methodName = "";
        public FISUpdateFpoController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }

        [HttpPost("update_share")]
        public UpdateFetchApplication Fetchupdate_share(UpdateFetchContext objICDStockContext)
        {
            LogHelper.ConvertObjIntoString(objICDStockContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objICDStockContext.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
            UpdateFetchApplication ObjList = new UpdateFetchApplication();
            try
            {
                ObjList = FISUpdateFpo_Service.GetUpdatetList(objICDStockContext, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objICDStockContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("newUpdateShareAllotment")]
        public UpdateSaveDocument newUpdateShareAllotment(UpdateSaveApplication objICDStockContext)
        {
            LogHelper.ConvertObjIntoString(objICDStockContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objICDStockContext.document.context.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
            UpdateSaveDocument ObjList = new UpdateSaveDocument();
            try
            {
                ObjList = FISUpdateFpo_Service.SaveUpdateFpo(objICDStockContext, ConString);
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
