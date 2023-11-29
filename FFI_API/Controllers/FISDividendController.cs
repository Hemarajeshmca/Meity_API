using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    public class FISDividendController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(ICDInvoiceController)); //Declaring Log4Net.       
        string methodName = "";
        public FISDividendController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("alldividends")]
        public FISDividendApplication alldividends(FISDividendContext objinvoice)
        {
            LogHelper.ConvertObjIntoString(objinvoice, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objinvoice.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
            FISDividendApplication ObjList = new FISDividendApplication();
            try
            {
                ObjList = FISDividend_srv.GetallDividend_Srv(objinvoice, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objinvoice.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return ObjList;
        }
        [HttpPost("divident")]
        public FISDividendFApplication dividentfetch(FISDividendFContext ObjContext)
        {
            LogHelper.ConvertObjIntoString(ObjContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjContext.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
            FISDividendFApplication ObjRootList = new FISDividendFApplication();
            try
            {
                ObjRootList = FISDividend_srv.GetDividendfetch_Srv(ObjContext, ConString);
                LogHelper.ConvertObjIntoString(ObjRootList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return ObjRootList;
        }
        [HttpPost("newDividendStructure")]
        public FISDividendSDocument newDividendStructure(FISDividendSApplication ObjModel, string Mysql)
        {
            LogHelper.ConvertObjIntoString(ObjModel, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
            string[] response = { };
            FISDividendSDocument Objresult = new FISDividendSDocument();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = FISDividend_srv.SavenewDividendStructure(ObjModel, ConString);
                LogHelper.ConvertObjIntoString(Objresult, "Output");

            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjModel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //  logger.Error(ex);
            }
            return Objresult;
        }
    }
}