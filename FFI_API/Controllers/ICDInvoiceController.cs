using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ICDInvoiceController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInvoiceController)); //Declaring Log4Net.       
        // Exception Log Method Name Purpose written start                                                                                        
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public ICDInvoiceController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("ICDInvoiceAll")]
        public ICDInvoiceApplication allICDInvoice(ICDInvoiceContext objinvoice)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(objinvoice, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objinvoice.locnId, this.appSettings.Value);

            ICDInvoiceApplication ObjList = new ICDInvoiceApplication();
            try
            {
                ObjList = ICDInvoice_Service.GetAllICDInvoice_Srv(objinvoice, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objinvoice.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("ICDInvoicefetch")]
        public ICDInvoiceFApplication ICDInvoicefetch(ICDInvoiceFContext ObjContext)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(ObjContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjContext.locnId, this.appSettings.Value);

            ICDInvoiceFApplication ObjRootList = new ICDInvoiceFApplication();
            try
            {
                ObjRootList = ICDInvoice_Service.GetSingleICDInvoicefetch_Srv(ObjContext, ConString);
                LogHelper.ConvertObjIntoString(ObjRootList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //  logger.Error(ex);
            }
            return ObjRootList;
        }
        [HttpPost("ICDProductInvfetch")]
        public ICDSIProApplication ICDProductInvfetch(ICDSIProContext ObjContext)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(ObjContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjContext.locnId, this.appSettings.Value);

            ICDSIProApplication ObjRootList = new ICDSIProApplication();
            try
            {
                ObjRootList = ICDInvoice_Service.GetICDProductInvfetch_Srv(ObjContext, ConString);
                LogHelper.ConvertObjIntoString(ObjRootList, "Output");
            }
            catch (Exception ex)
            {
                // logger.Error(ex);
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return ObjRootList;
        }
        [HttpPost("new_Invoice")]
        public ICDInvoiceSADocument new_Invoice(ICDInvoiceSAApplication ObjModel)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(ObjModel, "Input");

            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            ICDInvoiceSADocument Objresult = new ICDInvoiceSADocument();
            try
            {
                //SetLog4NetConfiguration();
                Objresult = ICDInvoice_Service.Saveinvoice(ObjModel, ConString);
                LogHelper.ConvertObjIntoString(Objresult, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjModel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return Objresult;
        }
        [HttpPost("ICDInvoicePayfetch")]
        public ICDInvoicepayApplication ICDInvoicePayfetch(ICDInvoicepayContext ObjPayfetcht)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(ObjPayfetcht, "Input");


            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjPayfetcht.locnId, this.appSettings.Value);

            ICDInvoicepayApplication ObjRootList = new ICDInvoicepayApplication();
            try
            {
                ObjRootList = ICDInvoice_Service.GetSingleICDInvoicePayfetch_Srv(ObjPayfetcht, ConString);
                LogHelper.ConvertObjIntoString(ObjRootList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjPayfetcht.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return ObjRootList;
        }
        [HttpPost("new_invoice_payment")]
        public Document new_invoice_payment(PSApplication ObjModel)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(ObjModel, "Input");

            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            Document Objresult = new Document();
            try
            {
                //SetLog4NetConfiguration();
                Objresult = ICDInvoice_Service.Saveinvoicepayment(ObjModel, ConString);
                LogHelper.ConvertObjIntoString(Objresult, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjModel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return Objresult;
        }

        [HttpPost("InvoiceList")]
        public InvoiceApplication InvoiceList(InvoiceContext objinvoice)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(objinvoice, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objinvoice.locnId, this.appSettings.Value);

            InvoiceApplication ObjList = new InvoiceApplication();
            try
            {
                ObjList = ICDInvoice_Service.GetAllInvoiceList_Srv(objinvoice, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objinvoice.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("InvoicePaymentList")]
        public InvoicePayApplication InvoicePaymentList(InvoicePayContext objinvoice)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(objinvoice, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objinvoice.locnId, this.appSettings.Value);

            InvoicePayApplication ObjList = new InvoicePayApplication();
            try
            {
                ObjList = ICDInvoice_Service.GetAllInvoicePayList_Srv(objinvoice, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objinvoice.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return ObjList;
        }
    }
}