using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using FFI_Model;
using FFI_Service;
using static FFI_Model.Mobile_FDR_FarmerInfo_Model;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mobile_FDR_FarmerInfoController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Mobile_FDR_FarmerInfoController)); //Declaring Log4Net. 
        public Mobile_FDR_FarmerInfoController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }


        [HttpPost("Mobile_GetFarmerInfo")]
        public FDRFarmerNew Mobile_GetFarmerInfo_List(MobileFDRFarmerContext objfarmer)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(objfarmer.locnId, this.appSettings.Value);

            FDRFarmerNew ObjList = new FDRFarmerNew();
            Mobile_FDR_FarmerInfo_Service objService = new Mobile_FDR_FarmerInfo_Service();
            try
            {
                ObjList = objService.GetFarmernewData(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }

    }
}