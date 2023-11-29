using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using FFI_Model;
using FFI_Service;
using FFI_DataModel;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ICDStockAdjustmentController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDStockInwardController)); //Declaring Log4Net.       
        // Exception Log Method Name Purpose written start                                                                                        
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public ICDStockAdjustmentController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("allstockAdjustment")]
        public ICDStockAdjRootObject allstockAdjustment(ICDStockAdjContext objICDStockAdjContext)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(objICDStockAdjContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objICDStockAdjContext.locnId, this.appSettings.Value);
            ICDStockAdjRootObject ObjList = new ICDStockAdjRootObject();
            try
            {
                ObjList = ICDStockAdjust_Service.GetAllICDStockDtls_Srv(objICDStockAdjContext, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objICDStockAdjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("stockAdjustmentfetch")]
        public SingleICDStockAdjApplication SinglestockAdjust(SingleICDStockAdjContext SobjICDStockAdjContext)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(SobjICDStockAdjContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjICDStockAdjContext.locnId, this.appSettings.Value);

            SingleICDStockAdjApplication ObjList = new SingleICDStockAdjApplication();
            try
            {
                ObjList = ICDStockAdjust_Service.SingleICDstockAdj(SobjICDStockAdjContext, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + SobjICDStockAdjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return ObjList;
        }


        [HttpPost("newSaveStockAdjustment")]
        public IUStockADocument newSaveStockAdjustment(IUStockAApplication SobjICDStockAdjContext)
        {

            //log Input information
            LogHelper.ConvertObjIntoString(SobjICDStockAdjContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjICDStockAdjContext.document.context.locnId, this.appSettings.Value);
            string[] response = { };
            IUStockADocument Objresult = new IUStockADocument();
            try
            {
                //SetLog4NetConfiguration();
                Objresult = ICDStockAdjust_Service.SaveICDStockAdj(SobjICDStockAdjContext, ConString);
                LogHelper.ConvertObjIntoString(Objresult, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + SobjICDStockAdjContext.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //  logger.Error(ex);
            }
            return Objresult;
        }

    }
}
