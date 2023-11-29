using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using FFI_Model;
using FFI_Service;
using static FFI_Model.ICDStockInwardModel;
using FFI_DataModel;
using Newtonsoft.Json;
using System.Collections;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ICDStockInwardController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDStockInwardController)); //Declaring Log4Net.       
        // Exception Log Method Name Purpose written start                                                                                        
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public ICDStockInwardController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("allStockInwardList")]
        public ICDStockRootObject allStockInwardList(ICDStockContext objICDStockContext)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(objICDStockContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objICDStockContext.locnId, this.appSettings.Value);

            ICDStockRootObject ObjList = new ICDStockRootObject();
            try
            {
                ObjList = ICDStockInward_Service.GetAllICDStockDtls_Srv(objICDStockContext, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objICDStockContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("stockInward")]
        public SICDStockRootObject stockInward(SICDStockContext SobjICDStockContext)
        {

            //log Input information
            LogHelper.ConvertObjIntoString(SobjICDStockContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(SobjICDStockContext.locnId, this.appSettings.Value);
            SICDStockRootObject ObjList = new SICDStockRootObject();
            try
            {
                ObjList = ICDStockInward_Service.SingleICDstockInward(SobjICDStockContext, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + SobjICDStockContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("newSaveStockInward")]
        public IUStockDocument newSaveStockInward(IUStockApplication ObjModel)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(ObjModel, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            IUStockDocument Objresult = new IUStockDocument();
            try
            {
                //SetLog4NetConfiguration();
                Objresult = ICDStockInward_Service.SaveICDStock(ObjModel, ConString);
                LogHelper.ConvertObjIntoString(Objresult, "Output");
            }
            catch (Exception ex)
            {
                // logger.Error(ex);
                logger.Error("USERNAME :" + ObjModel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            return Objresult;

        }
        [HttpPost("ProductsearchStockInward")]
        public PApplication ProductsearchStockInward(PContext ObjModel)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(ObjModel, "Input");

            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.locnId, this.appSettings.Value);
            string[] response = { };
            PApplication Objresult = new PApplication();
            try
            {
                //SetLog4NetConfiguration();
                Objresult = ICDStockInward_Service.ProductsearchStock(ObjModel, ConString);
                LogHelper.ConvertObjIntoString(Objresult, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjModel.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return Objresult;

        } 

        [HttpPost("new_inward_payment")]
        public Document new_inward_payment(PSApplication ObjModel)
{
             
            LogHelper.ConvertObjIntoString(ObjModel, "Input");

            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            Document Objresult = new Document();
            try
            {
                //SetLog4NetConfiguration();
                Objresult = ICDStockInward_Service.Saveinwardpayment(ObjModel, ConString);
                LogHelper.ConvertObjIntoString(Objresult, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjModel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return Objresult;
        }


        [HttpPost("ICDInwardPayfetch")]
        public ICDInvoicepayApplication ICDInwardPayfetch(ICDInvoicepayContext ObjPayfetcht)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(ObjPayfetcht, "Input");


            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjPayfetcht.locnId, this.appSettings.Value);

            ICDInvoicepayApplication ObjRootList = new ICDInvoicepayApplication();
            try
            {
                ObjRootList = ICDStockInward_Service.GetSingleICDInwardPayfetch_Srv(ObjPayfetcht, ConString);
                LogHelper.ConvertObjIntoString(ObjRootList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjPayfetcht.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return ObjRootList;
        }

        [HttpGet("Inwardpaymentcollection")]
        public string paymentcollection_InwardList(string org, string locn, string user, string lang, int invoice_rowid)
        {
            ArrayList objArr = new ArrayList();
            objArr.Add(org);
            objArr.Add(locn);
            objArr.Add(user);
            objArr.Add(lang);
            //log Input information
            LogHelper.ConvertObjIntoString(objArr, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(locn, this.appSettings.Value);
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            MOBPAYRoot ObjList = new MOBPAYRoot();
            try
            {
                ObjList = ICDStockInward_Service.paymentcollection_InwardList(org, locn, user, lang, invoice_rowid, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                // logger.Error(ex);
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(ObjList, Formatting.Indented);
            return serializedProduct;
        }



    }
}
