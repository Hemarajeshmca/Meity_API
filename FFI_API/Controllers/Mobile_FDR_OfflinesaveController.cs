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
    public class Mobile_FDR_OfflinesaveController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Mobile_FDR_OfflinesaveController)); //Declaring Log4Net.       

        public Mobile_FDR_OfflinesaveController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        #region               
        [HttpPost("MFarmerProfileSave")]
        public FarmerProfileOutput MFarmerProfileSave(Mobile_FDR_FarmerProfile_model objfarmer)
        {           
            Mobile_FDR_Offlinesave_srv objFarmerProfileBL = new Mobile_FDR_Offlinesave_srv();
            string db = objfarmer.MFarmerHeaderDetails.instance;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            FarmerProfileOutput ObjList = new FarmerProfileOutput();
            try
            {
                ObjList = objFarmerProfileBL.FarmerProfileSave_Srv(objfarmer,ConString);
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
