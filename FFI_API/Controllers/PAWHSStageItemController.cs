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
    public class PAWHSStageItemController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSStageItemController)); //Declaring Log4Net.       

        public PAWHSStageItemController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("allstageitem_definition")]
        public PAWHSStageItemApplication allstageitem_definition(PAWHSStageItemContext objinvoice)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objinvoice.locnId, this.appSettings.Value);

            PAWHSStageItemApplication ObjList = new PAWHSStageItemApplication();
            try
            {
                ObjList = PAWHSStageItem_srv.Getallstageitem_definition_Srv(objinvoice, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("stageitem_definition")]
        public PAWHSStageItemFApplication stageitem_definition(PAWHSStageItemFContext ObjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjContext.locnId, this.appSettings.Value);

            PAWHSStageItemFApplication ObjRootList = new PAWHSStageItemFApplication();
            try
            {
                ObjRootList = PAWHSStageItem_srv.Getstageitem_definition_Srv(ObjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex); 
            }
            return ObjRootList;
        }
        [HttpPost("stage_definition")]
        public PAWHSStageItemIApplication stage_definition(PAWHSStageItemIContext ObjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjContext.locnId, this.appSettings.Value);

            PAWHSStageItemIApplication ObjRootList = new PAWHSStageItemIApplication();
            try
            {
                ObjRootList = PAWHSStageItem_srv.Getstage_definition_Srv(ObjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjRootList;
        }
        [HttpPost("new_stage_item_definition")]
        public PAWHSStageItemSDocument new_stage_item_definition(PAWHSStageItemSApplication ObjModel)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            PAWHSStageItemSDocument Objresult = new PAWHSStageItemSDocument();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = PAWHSStageItem_srv.Savenew_stage_item_definition_srv(ObjModel, ConString);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;
        }
    }
}