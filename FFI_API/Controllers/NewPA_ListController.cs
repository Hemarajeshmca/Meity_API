using FFI_DataModel;
using FFI_Model;
using FFI_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FFI_Model.NewPA_ListModel;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewPA_ListController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDProductController)); //Declaring Log4Net. 
        public NewPA_ListController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpGet("PA_paymentcollection")]
        public string paymentcollection_List(string org, string locn, string user, string lang, int invoice_rowid)
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
            MOBPA_PAYRoot ObjList = new MOBPA_PAYRoot();
            try
            {
                ObjList = NewPA_ListService.PA_paymentcollection_List_srv(org, locn, user, lang, invoice_rowid, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + user + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
            }
            var serializedProduct = JsonConvert.SerializeObject(ObjList, Formatting.Indented);
            return serializedProduct;
        }

        [HttpPost("PA_SaleList")]
        public PA_SaleApplication PASaleList(PA_SaleContext objinvoice)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(objinvoice, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objinvoice.locnId, this.appSettings.Value);
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            PA_SaleApplication ObjList = new PA_SaleApplication();
            try
            {
                ObjList = NewPA_ListService.GetAllPASaleList_Srv(objinvoice, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objinvoice.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("PA_SalePaymentList")]
        public PASalePayApplication PA_SalePaymentList(PASalePayContext objinvoice)
        {
            //log Input information
            LogHelper.ConvertObjIntoString(objinvoice, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objinvoice.locnId, this.appSettings.Value);
            // Exception Log Method Name Purpose written start 
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            //End
            PASalePayApplication ObjList = new PASalePayApplication();
            try
            {
                ObjList = NewPA_ListService.GetAllPASalePayList_Srv(objinvoice, ConString);
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
