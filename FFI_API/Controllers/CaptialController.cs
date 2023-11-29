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
    public class CaptialController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(CaptialController)); //Declaring Log4Net.       

        public CaptialController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }


        [HttpPost("capital_struct")]
        public CaptialRootObject capital_struct(CaptialContext ObjModel)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.locnId, this.appSettings.Value);

            CaptialRootObject Objresult = new CaptialRootObject();
            try
            {
                Objresult = Captial_Service.GetCaptialDtl(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;
        }
        [HttpPost("newcapital")]
        public CaptialDocument newcapital(CaptialApplication ObjContext)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjContext.document.context.locnId, this.appSettings.Value);

            CaptialDocument ObjRootList = new CaptialDocument();
            try
            {
                ObjRootList = Captial_Service.SaveCaptialDtl(ObjContext, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjRootList;
        }
    }
}