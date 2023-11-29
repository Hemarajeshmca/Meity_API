using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FFI_Model;
using FFI_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mobile_FDR_FDetailController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Mobile_FDR_FDetailController)); //Declaring Log4Net.       

        public Mobile_FDR_FDetailController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("NewMobileFarmerCrop")]
        public fdrDocument NewMobileFarmerCrop(fdrsaveRootObject ObjModel)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.instance, this.appSettings.Value);

            
            string[] response = { };
            fdrDocument Objresult = new fdrDocument();
           
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(ObjModel.document.context.Detail);
            ObjModel.document.context.detail_formatted = jsonString;
            var jsonString1 = Newtonsoft.Json.JsonConvert.SerializeObject(ObjModel.document.context.Dtlownland_picture);
            ObjModel.document.context.ownland_picture = jsonString1;
            try
            {
                Objresult = Mobile_FDR_FDetail_srv.SaveNewMobileFarmerCrop_Srv(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;
        }
    }
}