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
    public class PAWHSRaiseInvoiceController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSRaiseInvoiceController)); //Declaring Log4Net.       
        public PAWHSRaiseInvoiceController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("allraise_invoice")]
        public PAWHSRaiseInvoiceApplication allraise_invoice(PAWHSRaiseInvoiceContext objICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objICDStockAdjContext.locnId, this.appSettings.Value);

            PAWHSRaiseInvoiceApplication ObjList = new PAWHSRaiseInvoiceApplication();
            try
            {
                ObjList = PAWHSRaiseInvoice_srv.Getallraise_invoice_Srv(objICDStockAdjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("raise_invoice")]
        public PAWHSRaiseInvoiceFApplication Getraise_invoice(PAWHSRaiseInvoiceFContext SobjICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjICDStockAdjContext.locnId, this.appSettings.Value);

            PAWHSRaiseInvoiceFApplication ObjList = new PAWHSRaiseInvoiceFApplication();
            try
            {
                ObjList = PAWHSRaiseInvoice_srv.Getraise_invoice_srv(SobjICDStockAdjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }


        [HttpPost("new_raise_invoice")]
        public PAWHSRaiseInvoiceSDocument Savenew_raise_invoice(PAWHSRaiseInvoiceSApplication SobjICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjICDStockAdjContext.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            PAWHSRaiseInvoiceSDocument Objresult = new PAWHSRaiseInvoiceSDocument();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = PAWHSRaiseInvoice_srv.Savenew_raise_invoice_srv(SobjICDStockAdjContext, ConString);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;

        }
        [HttpPost("payment_collection")]
        public PAWHSRaiseInvoicePApplication Getpayment_collection(PAWHSRaiseInvoicePContext SobjICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjICDStockAdjContext.locnId, this.appSettings.Value);

            PAWHSRaiseInvoicePApplication ObjList = new PAWHSRaiseInvoicePApplication();
            try
            {
                ObjList = PAWHSRaiseInvoice_srv.Getpayment_collection_srv(SobjICDStockAdjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("new_payment_collection_raise_invoice")]
        public PAWHSRaiseInvoicePSDocument new_payment_collection_raise_invoice(PAWHSRaiseInvoicePSApplication SobjICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjICDStockAdjContext.document.context.locnId, this.appSettings.Value);

            PAWHSRaiseInvoicePSDocument ObjList = new PAWHSRaiseInvoicePSDocument();
            try
            {
                ObjList = PAWHSRaiseInvoice_srv.new_payment_collection_raise_invoice_srv(SobjICDStockAdjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("productsearch")]
        public PAWHSRaiseInvoiceProductApplication Getproductsearch(PAWHSRaiseInvoiceProductContext SobjICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjICDStockAdjContext.locnId, this.appSettings.Value);

            PAWHSRaiseInvoiceProductApplication ObjList = new PAWHSRaiseInvoiceProductApplication();
            try
            {
                ObjList = PAWHSRaiseInvoice_srv.Getproductsearch_srv(SobjICDStockAdjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
    }
}