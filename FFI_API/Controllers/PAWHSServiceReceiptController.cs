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
    public class PAWHSServiceReceiptController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSServiceReceiptController)); //Declaring Log4Net.       
        public PAWHSServiceReceiptController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("allservice_receipting")]
        public PAWHSServiceReceiptApplication allservice_receipting(PAWHSServiceReceiptContext objICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objICDStockAdjContext.locnId, this.appSettings.Value);

            PAWHSServiceReceiptApplication ObjList = new PAWHSServiceReceiptApplication();
            try
            {
                ObjList = PAWHSServiceReceipt_srv.Getallservice_receipting_Srv(objICDStockAdjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("service_receipting")]
        public PAWHSServiceReceiptFApplication Getservice_receipting(PAWHSServiceReceiptFContext SobjICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjICDStockAdjContext.locnId, this.appSettings.Value);

            PAWHSServiceReceiptFApplication ObjList = new PAWHSServiceReceiptFApplication();
            try
            {
                ObjList = PAWHSServiceReceipt_srv.Getservice_receipting_srv(SobjICDStockAdjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }


        [HttpPost("new_pawhs_service_receipting")]
        public PAWHSServiceReceiptSDocument new_pawhs_service_receipting(PAWHSServiceReceiptSApplication SobjICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjICDStockAdjContext.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            PAWHSServiceReceiptSDocument Objresult = new PAWHSServiceReceiptSDocument();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = PAWHSServiceReceipt_srv.Savenew_pawhs_service_receipting_srv(SobjICDStockAdjContext, ConString);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;

        }

    }
}