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
    public class PAWHS_NEW_LocalizationController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Mobile_FDRController)); //Declaring Log4Net.  
        public PAWHS_NEW_LocalizationController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }

        [HttpPost("Apilocalization")]
        public MFMApplication Farmermaster(MFMContext objfarmer)
        {
            string db = objfarmer.instance;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

          
            MFMApplication ObjList = new MFMApplication();
            try
            {
                ObjList = PAWHS_NEW_Localization_SRV.GetAllFarmermaster_Srv(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
    }
}
