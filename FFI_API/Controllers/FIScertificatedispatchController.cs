using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc; 
using Microsoft.Extensions.Options;
using FFI_Model;
using FFI_Service;
using FFI_DataModel;
using System.Reflection;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

       
    public class FIScertificatedispatchController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FIScertificatedispatchController));
        //Declaring Log4Net.
        string methodName = "";
        public FIScertificatedispatchController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }

        [HttpPost("sharedespatch")]
        public FsharecertallApplication allSharedispend(FsharecertallContext objICDStockContext)
        {
            LogHelper.ConvertObjIntoString(objICDStockContext, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objICDStockContext.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
            FsharecertallApplication ObjList = new FsharecertallApplication();
            try
            {
                ObjList = FIScertificatedispatch_Service.GetAllshare_pending(objICDStockContext, ConString);
                LogHelper.ConvertObjIntoString(ObjList, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + objICDStockContext.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("newShareDespatch")]
        public SavecertDisDocument newCertificateDispatch(SavecertDisApplication ObjModel)
        {
            LogHelper.ConvertObjIntoString(ObjModel, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
            string[] response = { };
            SavecertDisDocument Objresult = new SavecertDisDocument();
            try
            {

                //SetLog4NetConfiguration();
                Objresult = FIScertificatedispatch_Service.newCertificateDispatch(ObjModel, ConString);
                LogHelper.ConvertObjIntoString(Objresult, "Output");

            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjModel.document.context.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //logger.Error(ex);
            }
            return Objresult;

        }


    }
}
