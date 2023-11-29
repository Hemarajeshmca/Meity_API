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
    public class PAWHSServiceInvoiceController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSServiceInvoiceController)); //Declaring Log4Net.    
        public PAWHSServiceInvoiceController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("all_pawhs_service_invoice")]
        public PAWHSServiceInvoiceApplication all_pawhs_service_invoice(PAWHSServiceInvoiceContext objICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objICDStockAdjContext.locnId, this.appSettings.Value);

            PAWHSServiceInvoiceApplication ObjList = new PAWHSServiceInvoiceApplication();
            try
            {
                ObjList = PAWHSServiceInvoice_service.GetallService_invoice_Srv(objICDStockAdjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("pawhs_service_invoice")]
        public PAWHSFSerInvoiceApplication Getraise_invoice(PAWHSFSerInvoiceContext SobjICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjICDStockAdjContext.locnId, this.appSettings.Value);

            PAWHSFSerInvoiceApplication ObjList = new PAWHSFSerInvoiceApplication();
            try
            {
                ObjList = PAWHSServiceInvoice_service.Getservice_invoice_srv(SobjICDStockAdjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("pawhs_new_service_invoice")]
        public PAWHSServiceInvoiceSDocument pawhs_new_service_invoice(PAWHSServiceInvoiceSApplication SobjICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjICDStockAdjContext.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            PAWHSServiceInvoiceSDocument Objresult = new PAWHSServiceInvoiceSDocument();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = PAWHSServiceInvoice_service.Savenew_service_invoice(SobjICDStockAdjContext, ConString);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;

        }
    }
}
