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
    public class FISGenerateShareCertificateController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(FISGenerateShareCertificateController)); //Declaring Log4Net.
        string methodName = "";
        public FISGenerateShareCertificateController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("allshareRegister")]
        public GenerateShareApplication allshareRegister(GenerateShareContext ObjModel)
        {
            LogHelper.ConvertObjIntoString(ObjModel, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
            GenerateShareApplication Objresult = new GenerateShareApplication();
            try
            {
                Objresult = FISGenerateShareCertificate_Service.GetAllGenerateShareList(ObjModel, ConString);
                LogHelper.ConvertObjIntoString(Objresult, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjModel.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                //logger.Error(ex);
            }
            return Objresult;
        }
        [HttpPost("allotment_shareregister")]
        public GenerateShareFetchApplication allotment_shareregister(GenerateShareFetchContext ObjModel)
        {
            LogHelper.ConvertObjIntoString(ObjModel, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
            GenerateShareFetchApplication Objresult = new GenerateShareFetchApplication();
            try
            {
                Objresult = FISGenerateShareCertificate_Service.GetSingleGenerateShareList(ObjModel, ConString);
                LogHelper.ConvertObjIntoString(Objresult, "Output");
            }
            catch (Exception ex)
            {
                logger.Error("USERNAME :" + ObjModel.userId + "  " + "METHOD NAME  :" + methodName + " " + "ERROR  : " + ex);
                // logger.Error(ex);
            }
            return Objresult;
        }
        [HttpPost("newGenerateShareCertificate")]
        public GenerateShareDocument newGenerateShareCertificate(GenerateShareSaveApplication ObjModel)
        {
            LogHelper.ConvertObjIntoString(ObjModel, "Input");
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);
            methodName = MethodBase.GetCurrentMethod().Name;
            GenerateShareDocument Objresult = new GenerateShareDocument();
            try
            {
                Objresult = FISGenerateShareCertificate_Service.SaveGenerateShareList(ObjModel, ConString);
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