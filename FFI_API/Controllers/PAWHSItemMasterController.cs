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
    public class PAWHSItemMasterController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSItemMasterController)); //Declaring Log4Net.
        public PAWHSItemMasterController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("allitem_master")]
        public ItemMasterApplication allitem_master(ItemMasterContext ObjModel)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.locnId, this.appSettings.Value);

            ItemMasterApplication Objresult = new ItemMasterApplication();
            try
            {
                Objresult = PAWHSItemMaster_Service.GetAllItemMasterList(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;
        }
        [HttpPost("item_master")]
        public SingleItemMasterApplication item_master(SingleItemMasterContext ObjModel)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.locnId, this.appSettings.Value);

            SingleItemMasterApplication Objresult = new SingleItemMasterApplication();
            try
            {
                Objresult = PAWHSItemMaster_Service.GetSingleItemMaster(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;
        }
        [HttpPost("new_item_master")]
        public SaveItemMasterDocument new_item_master(SaveItemMasterApplication ObjModel)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);

            SaveItemMasterDocument Objresult = new SaveItemMasterDocument();
            try
            {
                Objresult = PAWHSItemMaster_Service.SaveItemMasterDtls(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;
        }
    }
}