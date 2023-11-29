using FFI_Model;
using FFI_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFI_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FDR_ConstentController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Mobile_FDRController)); //Declaring Log4Net.       

        public FDR_ConstentController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("FarmerConstenttemplatefetch")]
        public tempalteList FarmerConstenttemplatefetch(tempalteContext objfarmer)
        {
            string db = objfarmer.instance;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            tempalteList ObjList = new tempalteList();
            try
            {
                ObjList = FDR_Constent_service.FarmerConstenttemplatefetch_Srv(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("FarmerConstentfetch")]
        public fdrconstentfetch FarmerConstentfetch(fdrconstentfetchContext objfarmer)
        {
            string db = objfarmer.instance;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            fdrconstentfetch ObjList = new fdrconstentfetch();
            try
            {
                ObjList = FDR_Constent_service.FarmerConstentfetch_Srv(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("FarmerConstentsave")]
        public fdrconstentDocument FarmerConstentsave(fdrconstentroot objfarmer)
        {
            string db = objfarmer.document.context.locnId;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            fdrconstentDocument ObjList = new fdrconstentDocument();
            try
            {
                ObjList = FDR_Constent_service.FarmerConstentsave_Srv(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }

        [HttpPost("gpssave")]
        public gpsDocument gpssave(gpsroot objfarmer)
        {
            string db = objfarmer.document.context.instance;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            gpsDocument ObjList = new gpsDocument();
            try
            {
                ObjList = FDR_Constent_service.gpssave_Srv(objfarmer, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return ObjList;
        }
    }
}
