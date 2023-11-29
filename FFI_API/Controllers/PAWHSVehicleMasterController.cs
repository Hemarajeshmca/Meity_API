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
    public class PAWHSVehicleMasterController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(PAWHSVehicleMasterController)); //Declaring Log4Net.       

        public PAWHSVehicleMasterController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }

        [HttpPost("allvehicle")]
        public PAWHSVehicleMasterApplication allvehicle(PAWHSVehicleMasterContext ObjModel)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.locnId, this.appSettings.Value);

            PAWHSVehicleMasterApplication Objresult = new PAWHSVehicleMasterApplication();
            try
            {
                Objresult = PAWHSVehicleMaster_srv.Getallvehicle_srv(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;
        }
        [HttpPost("vehicle")]
        public PAWHSVehicleMasterFApplication Getvehicle(PAWHSVehicleMasterFContext ObjModel)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.locnId, this.appSettings.Value);

            PAWHSVehicleMasterFApplication Objresult = new PAWHSVehicleMasterFApplication();
            try
            {
                Objresult = PAWHSVehicleMaster_srv.Getvehicle_srv(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;
        }
        [HttpPost("new_vehicle_master")]
        public PAWHSVehicleMasterSDocument new_vehicle_master(PAWHSVehicleMasterSApplication ObjModel)
        {
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(ObjModel.document.context.locnId, this.appSettings.Value);

            PAWHSVehicleMasterSDocument Objresult = new PAWHSVehicleMasterSDocument();
            try
            {
                Objresult = PAWHSVehicleMaster_srv.Savenew_vehicle_master_srv(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;
        }


    }
}