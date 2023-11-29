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
    public class PAWHSWarehouseMasterController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSWarehouseMasterController)); //Declaring Log4Net.
        public PAWHSWarehouseMasterController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("allwarehouse_registration")]
        public WarehouseMstApplication allwarehouse_registration(WarehouseMstContext ObjModel)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.locnId, this.appSettings.Value);

            WarehouseMstApplication Objresult = new WarehouseMstApplication();
            try
            {
                Objresult = PAWHSWarehouseMaster_Service.GetAllWarehouseList(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;
        }
        [HttpPost("warehouse_registration")]
        public WarehouseMstSingleApplication warehouse_registration(WarehouseMstSingleContext ObjModel)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.locnId, this.appSettings.Value);

            WarehouseMstSingleApplication Objresult = new WarehouseMstSingleApplication();
            try
            {
                Objresult = PAWHSWarehouseMaster_Service.GetSingleWarehouseList(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;
        }
        [HttpPost("new_warehouse_registration")]
        public WarehouseMstDocument new_warehouse_registration(WarehouseMstSaveApplication ObjModel)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);

            WarehouseMstDocument Objresult = new WarehouseMstDocument();
            try
            {
                Objresult = PAWHSWarehouseMaster_Service.SaveWarehouseMaster(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;
        }
    }
}