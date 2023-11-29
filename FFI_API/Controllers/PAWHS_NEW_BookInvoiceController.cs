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
    public class PAWHS_NEW_BookInvoiceController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHS_NEW_BookInvoiceController)); //Declaring Log4Net.    
        // Exception Log Method Name Purpose written start                                                                                        
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public PAWHS_NEW_BookInvoiceController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
       
        [HttpPost("new_book_invoice_List")]
        public PAWHSBookInvoiceApplication new_book_invoice_List(PAWHSBookInvoiceContext objfarmer)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objfarmer.locnId, this.appSettings.Value);

            PAWHSBookInvoiceApplication ObjList = new PAWHSBookInvoiceApplication();
            try
            {
                ObjList = PAWHS_NEW_BookInvoice_service.GetAllnew_bookinvoiceList_srv(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("new_book_invoice_single")]
        public PAWHSBookInvoiceFApplication Single_new_book_invoice(PAWHSBookInvoiceFContext SobjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjContext.locnId, this.appSettings.Value);

            PAWHSBookInvoiceFApplication ObjList = new PAWHSBookInvoiceFApplication();
            try
            {
                ObjList = PAWHS_NEW_BookInvoice_service.Single_new_new_book_invoice_srv(SobjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("new_book_invoice_save")]
        public PAWHSBookInvoiceSDocument save_new_book_invoice(PAWHSBookInvoiceSApplication SobjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjContext.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            PAWHSBookInvoiceSDocument Objresult = new PAWHSBookInvoiceSDocument();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = PAWHS_NEW_BookInvoice_service.save_new_book_invoice_srv(SobjContext, ConString);

            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;

        }
        [HttpPost("poproductsearch")]
        public PAWHSBookInvoicenewProductApplication Getproductsearch(PAWHSBookInvoicenewProductContext SobjICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjICDStockAdjContext.locnId, this.appSettings.Value);

            PAWHSBookInvoicenewProductApplication ObjList = new PAWHSBookInvoicenewProductApplication();
            try
            {
                ObjList = PAWHS_NEW_BookInvoice_service.Getproductsearch_srv(SobjICDStockAdjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("polocationsearch")]
        public POLocApplication Getpolocationsearch(POLocContext SobjICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjICDStockAdjContext.locnId, this.appSettings.Value);

            POLocApplication ObjList = new POLocApplication();
            try
            {
                ObjList = PAWHS_NEW_BookInvoice_service.Getpolocationsearch_srv(SobjICDStockAdjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("transportslnofetch")]
        public PAWHSBookInvoiceFTRANS Gettransportslnofetch(PAWHSBookInvoiceFTRANSContext SobjICDStockAdjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjICDStockAdjContext.locnId, this.appSettings.Value);

            PAWHSBookInvoiceFTRANS ObjList = new PAWHSBookInvoiceFTRANS();
            try
            {
                ObjList = PAWHS_NEW_BookInvoice_service.Gettransportslnofetch_srv(SobjICDStockAdjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("PAWHSInvoicePayfetch")]
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
                ObjRootList = PAWHS_NEW_BookInvoice_service.GetSinglePAWHSInvoicePayfetch_Srv(ObjPayfetcht, ConString);
                LogHelper.ConvertObjIntoString(ObjRootList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjPayfetcht.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return ObjRootList;
        }
        [HttpPost("new_PAWHS_invoice_payment")]
        public Document new_PAWHS_invoice_payment(PSApplication ObjModel)
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
                Objresult = PAWHS_NEW_BookInvoice_service.SavePAWHSinvoicepayment(ObjModel, ConString);
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