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
    public class FISobjRegisterController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FISobjRegisterController)); //Declaring Log4Net.  
        string methodName = "";
        public FISobjRegisterController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }

        [HttpPost("objection_register")]
        public fisobregisApplication FetchfisObjRegister(fisobregisContext objICDStockContext)
        {
            LogHelper.ConvertObjIntoString(objICDStockContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objICDStockContext.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
            fisobregisApplication ObjList = new fisobregisApplication();
            try
            {
                ObjList = FISobjRegister_Service.allfisObjRegister(objICDStockContext, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objICDStockContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("newObjectionRegister")]
        public SfisobregisDocument newObjectionRegister(SfisobregisApplication objICDStockContext)
        {
            LogHelper.ConvertObjIntoString(objICDStockContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objICDStockContext.document.context.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
            SfisobregisDocument ObjList = new SfisobregisDocument();
            try
            {
                ObjList = FISobjRegister_Service.newObjectionRegister(objICDStockContext, ConString);
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
