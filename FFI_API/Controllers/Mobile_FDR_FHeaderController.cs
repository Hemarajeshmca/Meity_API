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
    public class Mobile_FDR_FHeaderController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        string ConString;

        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Mobile_FDR_FHeaderController)); //Declaring Log4Net.       

        public Mobile_FDR_FHeaderController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ConString = appSettings.Value.mysqlcon;
        }
        [HttpPost("NewMobileFarmerHeader")]
        public MFHDocument newNewMobileFarmerHeader(MFHApplication ObjModel)
        {
            logger.Debug("Going to Insert the Farmer ");
            string db = ObjModel.document.context.instance;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            string[] response = { };
            MFHDocument Objresult = new MFHDocument();
            try
            {
                Objresult = Mobile_FDR_FHeader_srv.SaveNewMobileFarmerHeader_Srv(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                logger.Debug("While Inserting the Farmer Faced Error :" + ex.ToString());
                logger.Error(ex);
            }
            return Objresult;
        }
        [HttpPost("NewMobileFarmerkyc")]
        public MFKDocument NewMobileFarmerkyc(MFKApplication ObjModel)
        {
            string db = ObjModel.document.context.instance;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            string[] response = { };
            MFKDocument Objresult = new MFKDocument();
            try
            {
                Objresult = Mobile_FDR_FHeader_srv.SaveNewMobileFarmerkyc_Srv(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;
        }
        [HttpPost("NewMobileFarmerBank")]
        public MFBDocument NewMobileFarmerBank(MFBApplication ObjModel)
        {
            string db = ObjModel.document.context.instance;
            //dynamic connection string
            AllConnectionString rcon = new AllConnectionString();
            this.ConString = rcon.getRightConString(db, this.appSettings.Value);

            string[] response = { };
            MFBDocument Objresult = new MFBDocument();
            try
            {
                Objresult = Mobile_FDR_FHeader_srv.SaveNewMobileFarmerBank_Srv(ObjModel, ConString);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return Objresult;
        }

    }
}