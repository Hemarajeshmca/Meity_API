using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FFI_DataModel;
using FFI_Model;
using FFI_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FISFarmermappingController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FISFarmermappingController)); //Declaring Log4Net.       
        string methodName = "";
        public FISFarmermappingController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("allFPOFarmer_map")]
        public fpofarmerApplication allFPOFarmer_map(fpofarmerContext objinvoice)
        {
            LogHelper.ConvertObjIntoString(objinvoice, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objinvoice.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
            fpofarmerApplication ObjList = new fpofarmerApplication();
            try
            {
                ObjList = FISFarmermapping_srv.GetallFPOFarmer_map_Srv(objinvoice, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objinvoice.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //  logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("FPOFarmer_map")]
        public fpofarmerFApplication FPOFarmer_map(fpofarmerFContext ObjContext)
        {
            LogHelper.ConvertObjIntoString(ObjContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjContext.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
            fpofarmerFApplication ObjRootList = new fpofarmerFApplication();
            try
            {
                ObjRootList = FISFarmermapping_srv.GetSingleFPOFarmer_map_Srv(ObjContext, ConString);
                LogHelper.ConvertObjIntoString(ObjRootList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return ObjRootList;
        }
        [HttpPost("newFPOFarmerMap")]
        public fpofarmerSDocument newFPOFarmerMap(fpofarmerSApplication ObjModel)
        {
            LogHelper.ConvertObjIntoString(ObjModel, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
            string[] response = { };
            fpofarmerSDocument Objresult = new fpofarmerSDocument();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = FISFarmermapping_srv.SaveFPOFarmerMap(ObjModel, ConString);
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