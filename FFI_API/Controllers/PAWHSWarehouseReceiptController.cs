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
    public class PAWHSWarehouseReceiptController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSWarehouseReceiptController)); //Declaring Log4Net.       
        public PAWHSWarehouseReceiptController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("allwarehouse_receipt")]
        public PAWHSWarehouseReceiptApplication allwarehouse_receipt(PAWHSWarehouseReceiptContext objICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objICDStockAdjContext.locnId, this.appSettings.Value);

            PAWHSWarehouseReceiptApplication ObjList = new PAWHSWarehouseReceiptApplication();
            try
            {
                ObjList = PAWHSWarehouseReceipt_srv.Getallwarehouse_receipt_Srv(objICDStockAdjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("warehouse_receipt")]
        public PAWHSWarehouseReceiptFApplication Getwarehouse_receipt(PAWHSWarehouseReceiptFContext SobjICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjICDStockAdjContext.locnId, this.appSettings.Value);

            PAWHSWarehouseReceiptFApplication ObjList = new PAWHSWarehouseReceiptFApplication();
            try
            {
                ObjList = PAWHSWarehouseReceipt_srv.Getwarehouse_receipt_srv(SobjICDStockAdjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }


        [HttpPost("new_warehouse_receipt")]
        public PAWHSWarehouseReceiptSDocument new_warehouse_receipt(PAWHSWarehouseReceiptSApplication SobjICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjICDStockAdjContext.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            PAWHSWarehouseReceiptSDocument Objresult = new PAWHSWarehouseReceiptSDocument();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = PAWHSWarehouseReceipt_srv.Savenew_warehouse_receipt_srv(SobjICDStockAdjContext, ConString);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;

        }
        [HttpPost("item_master")]
        public PAWHSWarehouseReceiptIApplication Getitem_master(PAWHSWarehouseReceiptIContext SobjICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjICDStockAdjContext.locnId, this.appSettings.Value);

            PAWHSWarehouseReceiptIApplication ObjList = new PAWHSWarehouseReceiptIApplication();
            try
            {
                ObjList = PAWHSWarehouseReceipt_srv.Getitem_master_srv(SobjICDStockAdjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
    }
}