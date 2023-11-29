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
    public class PAWHSServiceMasterController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSServiceMasterController)); //Declaring Log4Net.
        public PAWHSServiceMasterController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("all_pawhs_service_master")]
        public ServiceMasterApplication all_pawhs_service_master(SrviceMasterContext ObjModel)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.locnId, this.appSettings.Value);

            ServiceMasterApplication Objresult = new ServiceMasterApplication();
            try
            {
                Objresult = PAWHSServiceMaster_Service.GetAllServiceMasterList(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;
        }
        [HttpPost("pawhs_service_master")]
        public FetchServiceMasterApplication pawhs_service_master(FetchServiceMasterContext ObjModel)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.locnId, this.appSettings.Value);

            FetchServiceMasterApplication Objresult = new FetchServiceMasterApplication();
            try
            {
                Objresult = PAWHSServiceMaster_Service.GetServiceMasterSingle(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;
        }
        [HttpPost("pawhs_new_service_master")]
        public SaveServiceMasterDocument pawhs_new_service_master(SaveServiceMasterApplication ObjModel)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);

            SaveServiceMasterDocument Objresult = new SaveServiceMasterDocument();
            try
            {
                Objresult = PAWHSServiceMaster_Service.SaveServiceMasterDtls(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;
        }
    }
}