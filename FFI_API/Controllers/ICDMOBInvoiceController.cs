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
using Newtonsoft.Json;
using static FFI_Model.ICDMOBInvoice_model;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ICDMOBInvoiceController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInvoiceController)); //Declaring Log4Net.       
        // Exception Log Method Name Purpose written start                                                                                        
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public ICDMOBInvoiceController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("newsaveInvoice")]
        public string new_Invoice(ICDMOBIRoot ObjModel)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(ObjModel, "Input");

            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            ICDMOBIDocument Objresult = new ICDMOBIDocument();
            try
            {
                //SetLog4NetConfiguration();
                Objresult = ICDMOBInvioce_service.Saveinvoice(ObjModel, ConString);
                LogHelper.ConvertObjIntoString(Objresult, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjModel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(Objresult, Formatting.Indented);
            return serializedProduct;
            //return Objresult;
        }
        [HttpPost("mobnewsavePaymentCollection")]
        public string mobnewsavePaymentCollection(ICDMOBIPRoot ObjModel)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(ObjModel, "Input");

            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            ICDMOBIPDocument Objresult = new ICDMOBIPDocument();
            try
            {
                //SetLog4NetConfiguration();
                Objresult = ICDMOBInvioce_service.mobnewsavePaymentCollection_srv(ObjModel, ConString);
                LogHelper.ConvertObjIntoString(Objresult, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjModel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(Objresult, Formatting.Indented);
            return serializedProduct;
            //return Objresult;
        }
    }
}
