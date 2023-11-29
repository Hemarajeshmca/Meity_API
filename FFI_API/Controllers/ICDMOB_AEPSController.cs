using FFI_DataModel;
using FFI_Model;
using FFI_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FFI_Model.ICDMOB_AEPSModel;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ICDMOB_AEPSController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInvoiceController)); //Declaring Log4Net.       
        // Exception Log Method Name Purpose written start                                                                                        
        string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //End
        public ICDMOB_AEPSController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("OrderIdGenerationAEPS")]
        public string AEPS_OrderIDGenerate(ICDMOAEPSORDERRoot ObjModel)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(ObjModel, "Input");

            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            ICDMOAEPSORDERDocument Objresult = new ICDMOAEPSORDERDocument();
            try
            {
                //SetLog4NetConfiguration();
                Objresult = ICDMOB_AEPSService.SaveAEPS_OrderIDGenerate(ObjModel, ConString);
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
        [HttpPost("PaymentHistoryResponseSaveAEPS")]
        public string AEPSPayHistoryRes_Save(ICDMOBAEPSHISRoot ObjModel)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(ObjModel, "Input");

            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);

            string[] response = { };
            ICDMOBAEPSHISDocument Objresult = new ICDMOBAEPSHISDocument();
            try
            {
                //SetLog4NetConfiguration();
                Objresult = ICDMOB_AEPSService.SavePayHisReponse_AEPSservice(ObjModel, ConString);
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

        [HttpPost("PaymentOnlineAEPSfetch")]
        public ICDInvoiceAEPSApplication ICDInvoicefetchAEPS(ICDInvoicePaymentContext ObjContext)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(ObjContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjContext.locnId, this.appSettings.Value);

            ICDInvoiceAEPSApplication ObjRootList = new ICDInvoiceAEPSApplication();
            try
            {
                ObjRootList = ICDMOB_AEPSService.GetSingleICDInvoicefetchAEPS_Srv(ObjContext, ConString);
                LogHelper.ConvertObjIntoString(ObjRootList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //  logger.Error(ex);
            }
            return ObjRootList;
        }
    }
}
