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
using Newtonsoft.Json;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mobile_FDR_ProfileADSController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Mobile_FDR_ProfileADSController)); //Declaring Log4Net.       

        public Mobile_FDR_ProfileADSController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        #region               
        [HttpPost("MFarmerProfileADSSave")]
        public FDRRootObjectads MFarmerProfileSave(FDRRootObjectads objfarmer)
        {           
            
            FDRHeaderads objadsvalue = new FDRHeaderads();
            string db = objfarmer.context.instance;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            //objadsvalue = (FDRHeaderads)JsonConvert.DeserializeObject(objfarmer.context.adsvalue,typeof(FDRHeaderads));
            FDRRootObjectads ObjList = new FDRRootObjectads();
            try
            {
                ObjList = Mobile_FDR_ProfileADS_srv.FarmerProfileSaveADS_Srv(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
        #endregion
    }
}

