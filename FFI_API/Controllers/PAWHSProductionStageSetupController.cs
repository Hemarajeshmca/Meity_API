using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FFI_Model;
using FFI_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PAWHSProductionStageSetupController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSProductionStageSetupController)); //Declaring Log4Net.       

        public PAWHSProductionStageSetupController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("allproduction_stagesetup")]
        public PAWHSProductionStageSetupApplication allproduction_stagesetup(PAWHSProductionStageSetupContext objinvoice)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objinvoice.locnId, this.appSettings.Value);

            PAWHSProductionStageSetupApplication ObjList = new PAWHSProductionStageSetupApplication();
            try
            {
                ObjList = PAWHSProductionStageSetup_srv.Getallproduction_stagesetup_Srv(objinvoice, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("production_stagesetup")]
        public PAWHSProductionStageSetupFApplication production_stagesetup(PAWHSProductionStageSetupFContext ObjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjContext.locnId, this.appSettings.Value);

            PAWHSProductionStageSetupFApplication ObjRootList = new PAWHSProductionStageSetupFApplication();
            try
            {
                ObjRootList = PAWHSProductionStageSetup_srv.Getproduction_stagesetup_Srv(ObjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjRootList;
        }
        [HttpPost("new_production_stagesetup")]
        public PAWHSProductionStageSetupSDocument new_production_stagesetup(PAWHSProductionStageSetupSApplication ObjModel)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            PAWHSProductionStageSetupSDocument Objresult = new PAWHSProductionStageSetupSDocument();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = PAWHSProductionStageSetup_srv.Savenew_production_stagesetup_srv(ObjModel, ConString);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;
        }
    }
}