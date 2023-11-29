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
using static FFI_Model.FISChecklistModel;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FISChecklistController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDStockInwardController)); //Declaring Log4Net.       
                                                                                              // Exception Log Method Name Purpose written start                                                                                        
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public FISChecklistController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }

        [HttpPost("FISChecklistfetchtran")]
        public FApplication FISChecklistFetchtran(FISChecklistModel.FContext SobjContext)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(SobjContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjContext.locnId, this.appSettings.Value);
            FApplication ObjList = new FApplication();
            try
            {
                ObjList = FISChecklistService.FISChecklistFetchSrtran(SobjContext, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + SobjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjList;
        }

        [HttpPost("FISChecklistfetchHistory")]
        public HApplication FISChecklistFetchHistory(FISChecklistModel.HContext SobjContextH)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(SobjContextH, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjContextH.locnId, this.appSettings.Value);
            HApplication ObjListH = new HApplication();
            try
            {
                ObjListH = FISChecklistService.FISChecklistFetchSrHistory(SobjContextH, ConString);
                LogHelper.ConvertObjIntoString(ObjListH, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + SobjContextH.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjListH;
        }

        [HttpPost("newFISChecklist")]
        public SaveCheckTranDocument SaveCheckTran (SaveCheckTranApplication ObjModel)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(ObjModel, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            SaveCheckTranDocument Objresult = new SaveCheckTranDocument();
            try
            {
                //SetLog4NetConfiguration();
                Objresult = FISChecklistService.SaveCheckTransrv(ObjModel, ConString);
                LogHelper.ConvertObjIntoString(Objresult, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjModel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //logger.Error(ex);
            }
            return Objresult;

        }


    }
}
