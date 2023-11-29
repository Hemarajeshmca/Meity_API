using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FFI_DataModel;
using FFI_Model;
using FFI_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using static FFI_Model.LRS_FPOLoanModel;

namespace FFI_API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LRS_FPOLoanController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(LRS_FPOLoanController)); //Declaring Log4Net.       
        // Exception Log Method Name Purpose written start                                                                                        
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public LRS_FPOLoanController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("LRSFPOLoanList")]
        public LRSFpoLoanApplication LRSFpoLoanListAll (LRSFpoLoanContext objlrs)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(objlrs, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objlrs.locnId, this.appSettings.Value);

            LRSFpoLoanApplication ObjList = new LRSFpoLoanApplication();
            try
            {
                ObjList = LRS_FPOLoanService.GetAllLoanFPO_Srv(objlrs, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objlrs.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("LRSFpoLoanfetch")]
        public LRSFpoLoanFApplication LRSFpoLoanfetch(LRSFpoLoanFContext ObjContext)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(ObjContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjContext.locnId, this.appSettings.Value);

            LRSFpoLoanFApplication ObjRootList = new LRSFpoLoanFApplication();
            try
            {
                ObjRootList = LRS_FPOLoanService.GetSingleLRSFpoLoanfetch_Srv(ObjContext, ConString);
                LogHelper.ConvertObjIntoString(ObjRootList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //  logger.Error(ex);
            }
            return ObjRootList;
        }
        [HttpPost("new_LrsFPOLoan")]
        public LRSSaveDocument new_LrsFPOLoan(LRSSaveApplication ObjModel)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(ObjModel, "Input");

            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            LRSSaveDocument Objresult = new LRSSaveDocument();
            try
            {
                //SetLog4NetConfiguration();
                Objresult = LRS_FPOLoanService.SaveLRSFpoLoan(ObjModel, ConString);
                LogHelper.ConvertObjIntoString(Objresult, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjModel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return Objresult;
        }
    }
}
